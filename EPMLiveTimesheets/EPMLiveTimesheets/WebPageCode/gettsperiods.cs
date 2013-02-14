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
using System.Text;
using System.Xml;
using System.Data.SqlClient;

namespace TimeSheets
{
    public partial class gettsperiods : System.Web.UI.Page
    {
        protected XmlDocument docXml;
        protected string data;
        SqlConnection cn;

        protected virtual void outputXml()
        {
            data = docXml.OuterXml;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            Response.ContentType = "text/xml";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            using (SPWeb web = SPContext.Current.Web)
            {

                docXml = new XmlDocument();
                docXml.LoadXml("<rows></rows>");

                addHeader();

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                    cn.Open();
                });

                SqlCommand cmd = new SqlCommand("spTSGetPeriodsInfo", cn);
                cmd.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                int lastperiodid = 1;
                bool lastperiodclosed = false;
                while (dr.Read())
                {
                    XmlNode ndRow = docXml.CreateNode(XmlNodeType.Element, "row", docXml.NamespaceURI);
                    XmlAttribute attrId = docXml.CreateAttribute("id");
                    attrId.Value = dr.GetInt32(0).ToString();
                    ndRow.Attributes.Append(attrId);

                    lastperiodclosed = dr.GetBoolean(3);
                    lastperiodid = dr.GetInt32(0);

                    XmlNode ndCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    ndCell.InnerText = dr.GetDateTime(1).ToShortDateString();
                    ndRow.AppendChild(ndCell);

                    ndCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    ndCell.InnerText = dr.GetDateTime(2).ToShortDateString();
                    ndRow.AppendChild(ndCell);

                    if (dr.GetBoolean(3))
                    {
                        ndCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        ndCell.InnerText = "Closed";
                        ndRow.AppendChild(ndCell);

                        ndCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        ndCell.InnerText = "";
                        ndRow.AppendChild(ndCell);

                        ndCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        ndCell.InnerText = "<a href=\"javascript:void(0);\" onclick=\"javascript:openPeriod('" + dr.GetInt32(0).ToString() + "');\">open</a>";
                        ndRow.AppendChild(ndCell);
                    }
                    else
                    {
                        ndCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        ndCell.InnerText = "Open";
                        ndRow.AppendChild(ndCell);

                        ndCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        attrId = docXml.CreateAttribute("id");
                        attrId.Value = "del";
                        ndCell.Attributes.Append(attrId);
                        ndRow.AppendChild(ndCell);

                        ndCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        ndCell.InnerText = "<a href=\"javascript:void(0);\" onclick=\"javascript:closePeriod('" + dr.GetInt32(0).ToString() + "');\">close</a>";
                        ndRow.AppendChild(ndCell);
                    }

                    ndCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    ndCell.InnerText = dr.GetInt32(5) + " / " + dr.GetInt32(4);
                    ndRow.AppendChild(ndCell);

                    if (dr.GetInt32(4) > 0)
                        lastperiodclosed = true;

                    ndCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    ndCell.InnerXml = "<![CDATA[<a href=\"" + web.Url + "/_layouts/epmlive/viewts.aspx?period_id=" + dr.GetInt32(0).ToString() + "\">view</a>]]>";
                    ndRow.AppendChild(ndCell);

                    docXml.FirstChild.AppendChild(ndRow);
                }

                if (!lastperiodclosed)
                {
                    XmlNode nd = docXml.SelectSingleNode("//row[@id='" + lastperiodid + "']/cell[@id='del']");
                    if (nd != null)
                        nd.InnerText = "<a href=\"javascript:void(0);\" onclick=\"deletePeriod('" + lastperiodid + "');\">delete</a>";
                }

                cn.Close();
                outputXml();
            }
        }

        private void addHeader()
        {
            XmlNode ndHead = docXml.CreateNode(XmlNodeType.Element, "head", docXml.NamespaceURI);
            docXml.ChildNodes[0].AppendChild(ndHead);


            XmlNode ndSettings = docXml.CreateNode(XmlNodeType.Element, "settings", docXml.NamespaceURI);
            XmlNode ndColwith = docXml.CreateNode(XmlNodeType.Element, "colwidth", docXml.NamespaceURI);
            ndColwith.InnerText = "%";
            ndSettings.AppendChild(ndColwith);
            ndHead.AppendChild(ndSettings);

            XmlNode ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            ndNewColumn.InnerText = "Period Start";
            XmlAttribute attrType = docXml.CreateAttribute("type");
            attrType.Value = "ro";
            XmlAttribute attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = "20";
            XmlAttribute attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "center";

            ndNewColumn.Attributes.Append(attrType);
            ndNewColumn.Attributes.Append(attrWidth);
            ndNewColumn.Attributes.Append(attrAlign);
            ndHead.AppendChild(ndNewColumn);


            ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            ndNewColumn.InnerText = "Period End";
            attrType = docXml.CreateAttribute("type");
            attrType.Value = "ro";
            attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = "20";
            attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "center";

            ndNewColumn.Attributes.Append(attrType);
            ndNewColumn.Attributes.Append(attrWidth);
            ndNewColumn.Attributes.Append(attrAlign);
            ndHead.AppendChild(ndNewColumn);



            ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            ndNewColumn.InnerText = "Status";
            attrType = docXml.CreateAttribute("type");
            attrType.Value = "ro";
            attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = "10";
            attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "center";

            ndNewColumn.Attributes.Append(attrType);
            ndNewColumn.Attributes.Append(attrWidth);
            ndNewColumn.Attributes.Append(attrAlign);
            ndHead.AppendChild(ndNewColumn);

            ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            ndNewColumn.InnerText = "Delete";
            attrType = docXml.CreateAttribute("type");
            attrType.Value = "ro";
            attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = "10";
            attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "center";

            ndNewColumn.Attributes.Append(attrType);
            ndNewColumn.Attributes.Append(attrWidth);
            ndNewColumn.Attributes.Append(attrAlign);
            ndHead.AppendChild(ndNewColumn);


            ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            ndNewColumn.InnerText = "Open/Close";
            attrType = docXml.CreateAttribute("type");
            attrType.Value = "ro";
            attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = "10";
            attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "center";

            ndNewColumn.Attributes.Append(attrType);
            ndNewColumn.Attributes.Append(attrWidth);
            ndNewColumn.Attributes.Append(attrAlign);
            ndHead.AppendChild(ndNewColumn);



            ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            ndNewColumn.InnerText = "Submitted";
            attrType = docXml.CreateAttribute("type");
            attrType.Value = "ro";
            attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = "10";
            attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "center";

            ndNewColumn.Attributes.Append(attrType);
            ndNewColumn.Attributes.Append(attrWidth);
            ndNewColumn.Attributes.Append(attrAlign);
            ndHead.AppendChild(ndNewColumn);


            ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            ndNewColumn.InnerText = "View Timesheets";
            attrType = docXml.CreateAttribute("type");
            attrType.Value = "ro";
            attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = "15";
            attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "center";

            ndNewColumn.Attributes.Append(attrType);
            ndNewColumn.Attributes.Append(attrWidth);
            ndNewColumn.Attributes.Append(attrAlign);
            ndHead.AppendChild(ndNewColumn);
        }
    }
}
