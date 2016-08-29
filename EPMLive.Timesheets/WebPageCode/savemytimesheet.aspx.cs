using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Xml;


namespace TimeSheets
{
    public partial class savemytimesheet : System.Web.UI.Page
    {
        protected string data = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(System.Web.HttpUtility.HtmlDecode(Request["Data"]));

            string sPeriodId = doc.FirstChild.SelectSingleNode("//Cfg").Attributes["PeriodId"].Value;
            string tsuid = doc.FirstChild.SelectSingleNode("//Cfg").Attributes["TimesheetUID"].Value;
            bool submit = false;

            try
            {
                submit = bool.Parse(doc.FirstChild.SelectSingleNode("//Cfg").Attributes["SaveAndSubmit"].Value);
            }
            catch { }

            TimesheetSettings settings = new TimesheetSettings(SPContext.Current.Web);

            XmlNodeList ndListItems = doc.FirstChild.SelectNodes("//B/I");

            XmlDocument docTimesheet = new XmlDocument();
            docTimesheet.LoadXml("<Timesheet TSUID=\"" + tsuid + "\" Editable=\"0\" SaveAndSubmit=\"" + submit.ToString() + "\"/>");

            try
            {
                docTimesheet.FirstChild.Attributes["Editable"].Value = doc.FirstChild.SelectSingleNode("//Cfg").Attributes["GridEditable"].Value;
            }
            catch { }

            SqlConnection cn = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Web.Site.WebApplication.Id));
                cn.Open();
            });



            SqlCommand cmd = new SqlCommand("SELECT * FROM TSTYPE where SITE_UID=@siteid", cn);
            cmd.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            DataTable dtTypes = ds.Tables[0];

            bool bTypes = false;

            if (dtTypes.Rows.Count > 0)
                bTypes = true;

            ArrayList arrPeriodDates = TimesheetAPI.GetPeriodDaysArray(cn, settings, SPContext.Current.Web, sPeriodId);
            Hashtable arrPeriodDateCols = new Hashtable();
            foreach (DateTime dt in arrPeriodDates)
            {
                arrPeriodDateCols.Add("P" + dt.Ticks, dt.ToString("s"));
                if (bTypes)
                    arrPeriodDateCols.Add("TSP" + dt.Ticks, dt.ToString("s"));
            }

            cn.Close();

            foreach (XmlNode nd in ndListItems)
            {
                XmlNode ndRow = docTimesheet.CreateNode(XmlNodeType.Element, "Item", docTimesheet.NamespaceURI);
                XmlNode ndRowHours = docTimesheet.CreateNode(XmlNodeType.Element, "Hours", docTimesheet.NamespaceURI);
                ndRow.AppendChild(ndRowHours);

                foreach (XmlAttribute attr in nd.Attributes)
                {
                    if (arrPeriodDateCols.Contains(attr.Name))
                    {
                        if (bTypes)
                        {
                            if (attr.Name.StartsWith("TS"))
                            {
                                JavaScriptSerializer a = new JavaScriptSerializer();
                                object o = a.DeserializeObject(attr.Value);

                                System.Collections.Generic.Dictionary<string, object> oo = (System.Collections.Generic.Dictionary<string, object>)o;

                                XmlNode ndDate = docTimesheet.CreateNode(XmlNodeType.Element, "Date", docTimesheet.NamespaceURI);

                                XmlAttribute attr1 = docTimesheet.CreateAttribute("Value");
                                attr1.Value = arrPeriodDateCols[attr.Name].ToString();
                                ndDate.Attributes.Append(attr1);

                                foreach (DataRow dr in dtTypes.Rows)
                                {
                                    try
                                    {
                                        XmlNode ndTime = docTimesheet.CreateNode(XmlNodeType.Element, "Time", docTimesheet.NamespaceURI);

                                        attr1 = docTimesheet.CreateAttribute("Hours");
                                        attr1.Value = oo["T" + dr["TSTYPE_ID"].ToString()].ToString();
                                        ndTime.Attributes.Append(attr1);

                                        attr1 = docTimesheet.CreateAttribute("Type");
                                        attr1.Value = dr["TSTYPE_ID"].ToString();
                                        ndTime.Attributes.Append(attr1);

                                        ndDate.AppendChild(ndTime);
                                    }
                                    catch { }
                                }

                                if (settings.AllowNotes)
                                {
                                    string notes = "";
                                    try
                                    {
                                        notes = oo["Notes"].ToString();
                                    }
                                    catch { }
                                    if (notes != "")
                                    {
                                        XmlNode ndNotes = docTimesheet.CreateNode(XmlNodeType.Element, "Notes", docTimesheet.NamespaceURI);
                                        ndNotes.InnerText = notes;
                                        ndDate.AppendChild(ndNotes);
                                    }
                                }

                                ndRowHours.AppendChild(ndDate);
                            }
                        }
                        else
                        {

                            XmlNode ndDate = docTimesheet.CreateNode(XmlNodeType.Element, "Date", docTimesheet.NamespaceURI);

                            XmlAttribute attr1 = docTimesheet.CreateAttribute("Value");
                            attr1.Value = arrPeriodDateCols[attr.Name].ToString();
                            ndDate.Attributes.Append(attr1);


                            XmlNode ndTime = docTimesheet.CreateNode(XmlNodeType.Element, "Time", docTimesheet.NamespaceURI);
                            ndDate.AppendChild(ndTime);

                            attr1 = docTimesheet.CreateAttribute("Hours");
                            attr1.Value = attr.Value;
                            ndTime.Attributes.Append(attr1);

                            if (settings.AllowNotes)
                            {
                                string notes = nd.Attributes["TS" + attr.Name].Value;
                                if (notes != "")
                                {
                                    XmlNode ndNotes = docTimesheet.CreateNode(XmlNodeType.Element, "Notes", docTimesheet.NamespaceURI);
                                    ndNotes.InnerText = notes;
                                    ndDate.AppendChild(ndNotes);
                                }
                            }

                            ndRowHours.AppendChild(ndDate);
                        }
                    }
                    else
                    {
                        XmlAttribute attr1 = docTimesheet.CreateAttribute(attr.Name);
                        attr1.Value = attr.Value;
                        ndRow.Attributes.Append(attr1);
                    }


                }

                docTimesheet.FirstChild.AppendChild(ndRow);
            }

            XmlDocument docRes = new XmlDocument();
            docRes.LoadXml(TimesheetAPI.SaveTimesheet(docTimesheet.OuterXml, SPContext.Current.Web));



            if (docRes.FirstChild.Attributes["Status"].Value == "0")
                data = "<Grid><IO Result='" + docRes.FirstChild.Attributes["Status"].Value + "'/></Grid>";
            else
                data = "<Grid><IO Result='" + docRes.FirstChild.Attributes["Status"].Value + "' Message='" + docRes.FirstChild.InnerText + "'/></Grid>";
        }

    }
}