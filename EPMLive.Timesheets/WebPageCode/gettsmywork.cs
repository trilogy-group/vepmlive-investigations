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
    public partial class gettsmywork : EPMLiveWebParts.getgriditems
    {
        SPSite site = SPContext.Current.Site;
        int period;
        string username = SPContext.Current.Web.CurrentUser.LoginName;
        DataSet dsTSHours = new DataSet();
        static string bgcolor = "EFEFEF";
        string workType = "";

        public override void getParams(SPWeb curWeb)
        {
            base.getParams(curWeb);
            isTimesheet = true;

            string strPeriod = Request["period"];
            workType = Request["workType"];

            period = int.Parse(strPeriod);

            //base.inEditMode = true;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                string requestedUser = Page.Request["duser"];
                string resname = "";
                if (requestedUser != null && requestedUser != "")
                {
                    if (SharedFunctions.canUserImpersonate(username, requestedUser, site.RootWeb, out resname))
                    {
                        username = requestedUser;
                    }
                }
            });

            gridname = "mywork" + gridname;

            if (workType == "1" || (workType == "4" && Request["allowOther"] == "true"))
            {
                if (inEditMode)
                {
                    filterfield = "IsAssignment";
                    filtervalue = "False";
                }
                else
                {
                    filterfield = "IsAssignment";
                    filtervalue = "0' OR IsAssignment='";
                }

            }
        }

        public override void addGroups(SPWeb web, string spquery, SortedList arrGTemp)
        {
            if (workType == "2")
            {
                try
                {
                    processList(web.Site.RootWeb, spquery, web.Site.RootWeb.Lists[EPMLiveCore.CoreFunctions.getConfigSetting(web.Site.RootWeb, "EPMLiveTSNonWork")], arrGTemp);
                }
                catch { }
            }
            else
                base.addGroups(web, spquery, arrGTemp);
        }

        public override string getQuery()
        {
            string query = base.getQuery();

            XmlDocument docQuery = new XmlDocument();
            docQuery.LoadXml("<Query>" + query + "</Query>");

            string addQuery = "";
            //Bstring flag = EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Web.Site.RootWeb, "EPMLiveTSFlag");


            SPUser u = SPContext.Current.Site.RootWeb.AllUsers[username];


            if (workType == "1")
            {
                addQuery = "<Eq><FieldRef Name=\"Timesheet\" /><Value Type=\"Boolean\">1</Value></Eq>";
            }
            else if (workType == "2")
            {
                addQuery = "";
            }
            else if (workType == "4")
            {
                if (Request["allowOther"] == "true")
                {
                    addQuery = "<And><Contains><FieldRef Name=\"" + Request["searchCol"] + "\" /><Value Type=\"Text\">" + Request["searchTerm"] + "</Value></Contains><Eq><FieldRef Name=\"Timesheet\" /><Value Type=\"Boolean\">1</Value></Eq></And>";
                }
                else
                {
                    addQuery = "<And><Contains><FieldRef Name=\"" + Request["searchCol"] + "\" /><Value Type=\"Text\">" + Request["searchTerm"] + "</Value></Contains><And><Eq><FieldRef Name=\"AssignedTo\" LookupId='True'/><Value Type=\"User\">" + u.ID + "</Value></Eq><Eq><FieldRef Name=\"Timesheet\" /><Value Type=\"Boolean\">1</Value></Eq></And></And>";
                }
            }
            else
            {
                addQuery = "<And><Eq><FieldRef Name=\"AssignedTo\" LookupId='True'/><Value Type=\"User\">" + u.ID + "</Value></Eq><Eq><FieldRef Name=\"Timesheet\" /><Value Type=\"Boolean\">1</Value></Eq></And>";
            }

            if (addQuery != "")
            {
                XmlNode ndWhere = docQuery.SelectSingleNode("//Where");
                if (ndWhere != null)
                {
                    XmlNode ndCurWhere = ndWhere.FirstChild;

                    XmlNode ndNew = docQuery.CreateNode(XmlNodeType.Element, "And", docQuery.NamespaceURI);
                    ndNew.InnerXml = addQuery;
                    ndNew.AppendChild(ndCurWhere);

                    ndWhere.AppendChild(ndNew);
                }
                else
                {
                    ndWhere = docQuery.CreateNode(XmlNodeType.Element, "Where", docQuery.NamespaceURI);
                    ndWhere.InnerXml = addQuery;


                    docQuery.FirstChild.AppendChild(ndWhere);
                }
                query = docQuery.FirstChild.InnerXml;
            }
            return query;
        }

        protected override void outputXml()
        {

            string cols = "";
            string timeperiods = "";
            ArrayList arr = new ArrayList();

            XmlNodeList ndCols = docXml.SelectNodes("//head/column");

            int columnCount = ndCols.Count;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                
                try
                {

                    //=========================================================================
                    bool timeeditor = false;
                    bool timenotes = true;
                    SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(site.WebApplication.Id));
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select TSTYPE_ID from TSTYPE where site_uid=@siteid", cn);
                    cmd.Parameters.AddWithValue("@siteid", site.ID);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        timeperiods += "|" + dr.GetInt32(0).ToString() + "|#";
                        timeeditor = true;
                    }
                    if (EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveTSAllowNotes").ToLower() == "true")
                    {
                        timenotes = true;
                        timeeditor = true;
                        if (timeperiods == "")
                            timeperiods = "|0|0|N|";
                        else
                            timeperiods += "|N|";
                    }
                    if (timeperiods.Length > 1)
                        timeperiods = timeperiods.Substring(1);

                    dr.Close();
                    //=========================================================================

                    cmd = new SqlCommand("spTSgetTSHours", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@siteguid", site.ID);
                    cmd.Parameters.AddWithValue("@period_id", period);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dsTSHours);

                    XmlNode ndHead = docXml.SelectSingleNode("//head");
                    XmlNode ndCol = ndHead.SelectSingleNode("column");
                    //
                    XmlNode ndTreeCol = ndHead.SelectSingleNode("column[@type='tree']");
                    if (ndTreeCol != null)
                    {
                        string val = ndTreeCol.Attributes["width"].Value;
                        val = (float.Parse(val) - 6).ToString();
                        ndTreeCol.Attributes["width"].Value = val;
                    }
                    //
                    if(inEditMode)
                        ndCol.InnerXml = "hideme";

                    XmlNode ndNewCol = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                    ndNewCol.InnerText = "&nbsp;";
                    XmlAttribute attrType = docXml.CreateAttribute("type");
                    attrType.Value = "ch";
                    XmlAttribute attrWidth = docXml.CreateAttribute("width");
                    attrWidth.Value = "40";
                    XmlAttribute attrAlign = docXml.CreateAttribute("align");
                    attrAlign.Value = "center";
                    ndNewCol.Attributes.Append(attrType);
                    ndNewCol.Attributes.Append(attrWidth);
                    ndNewCol.Attributes.Append(attrAlign);

                    ndHead.InsertBefore(ndNewCol, ndCol);

                    //ndCol = ndHead.SelectSingleNode("column");
                    //ndNewCol = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                    //ndNewCol.InnerText = "hideme";
                    //attrType = docXml.CreateAttribute("type");
                    //attrType.Value = "ro";
                    //attrWidth = docXml.CreateAttribute("width");
                    //attrWidth.Value = "5";
                    //attrAlign = docXml.CreateAttribute("align");
                    //attrAlign.Value = "center";
                    //ndNewCol.Attributes.Append(attrType);
                    //ndNewCol.Attributes.Append(attrWidth);
                    //ndNewCol.Attributes.Append(attrAlign);

                    //ndHead.InsertAfter(ndNewCol, ndCol);

                    XmlNode ndbefore = ndHead.SelectSingleNode("beforeInit");
                    ndbefore.RemoveChild(ndbefore.SelectSingleNode("call[@command='attachHeader']"));

                    XmlNode ndFilter = docXml.SelectSingleNode("//head/beforeInit/call[@command='attachHeader']");
                    if (ndFilter != null)
                    {
                        string xml = ndFilter.FirstChild.InnerXml;
                        xml = xml.Replace("<![CDATA[", "<![CDATA[&nbsp;,").Replace("gridfilter" + gridname + "(", "myworkgridfilter" + gridname + "(");
                        ndFilter.FirstChild.InnerXml = xml;
                    }

                    //XmlNode ndattach = ndHead.SelectSingleNode("beforeInit/call[@command='attachHeader']");
                    //ndattach.InnerXml = "<![CDATA[ hi ]]>";

                    cmd = new SqlCommand("select period_start,period_end,locked from TSPERIOD where period_id=@period_id and site_id=@site_id", cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@period_id", period);
                    cmd.Parameters.AddWithValue("@site_id", site.ID);
                    dr = cmd.ExecuteReader();

                    string[] dayDefs = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveDaySettings").Split('|');

                    if (dr.Read())
                    {
                        DateTime dtStart = dr.GetDateTime(0);
                        DateTime dtEnd = dr.GetDateTime(1);
                        TimeSpan ts = dtEnd - dtStart;
                        int colBase = docXml.SelectSingleNode("//head").SelectNodes("column").Count;
                        int colCount = 0;
                        for (int i = 0; i <= ts.Days; i++)
                        {
                            string showday = "";
                            try
                            {
                                showday = dayDefs[((int)dtStart.AddDays(i).DayOfWeek) * 3];
                            }
                            catch { }
                            //if (dtStart.AddDays(i).DayOfWeek != DayOfWeek.Sunday && dtStart.AddDays(i).DayOfWeek != DayOfWeek.Saturday)
                            if (showday == "True")
                            {
                                colCount++;
                                arr.Add(dtStart.AddDays(i));
                                XmlNode newCol = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                                newCol.InnerText = "hideme";
                                attrType = docXml.CreateAttribute("type");
                                if(timeeditor)
                                    attrType.Value = "timeeditor";
                                else
                                    attrType.Value = "edn";
                                attrWidth = docXml.CreateAttribute("width");
                                attrWidth.Value = "1";
                                attrAlign = docXml.CreateAttribute("align");
                                attrAlign.Value = "right";

                                newCol.Attributes.Append(attrType);
                                newCol.Attributes.Append(attrWidth);
                                newCol.Attributes.Append(attrAlign);

                                docXml.SelectSingleNode("//head").AppendChild(newCol);
                            }
                        }

                    }
                    dr.Close();

                    ndNewCol = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                    ndNewCol.InnerText = "hideme";
                    attrType = docXml.CreateAttribute("type");
                    attrType.Value = "ro";
                    attrWidth = docXml.CreateAttribute("width");
                    attrWidth.Value = "5";
                    attrAlign = docXml.CreateAttribute("align");
                    attrAlign.Value = "center";
                    ndNewCol.Attributes.Append(attrType);
                    ndNewCol.Attributes.Append(attrWidth);
                    ndNewCol.Attributes.Append(attrAlign);
                    ndHead.AppendChild(ndNewCol);

                    ndNewCol = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                    ndNewCol.InnerText = "% Work Complete";
                    attrType = docXml.CreateAttribute("type");
                    attrType.Value = "percentwork";
                    attrWidth = docXml.CreateAttribute("width");
                    attrWidth.Value = "125";
                    attrAlign = docXml.CreateAttribute("align");
                    attrAlign.Value = "center";
                    ndNewCol.Attributes.Append(attrType);
                    ndNewCol.Attributes.Append(attrWidth);
                    ndNewCol.Attributes.Append(attrAlign);
                    ndHead.AppendChild(ndNewCol);

                    ndHead.RemoveChild(ndHead.SelectSingleNode("settings"));
                }
                catch { }
            });


            foreach (XmlNode nd in docXml.SelectNodes("//row"))
            {

                XmlNode ndListId = nd.SelectSingleNode("userdata[@name='listid']");
                XmlNode ndItemId = nd.SelectSingleNode("userdata[@name='itemid']");

                if (ndListId != null && ndItemId != null)
                {
                    XmlNode newCol = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                    if (inEditMode)
                        newCol.InnerText = view.ViewFields.Count.ToString();
                    else
                        newCol.InnerText = (view.ViewFields.Count - 1).ToString();
                    XmlAttribute attrName = docXml.CreateAttribute("name");
                    attrName.Value = "fieldcount";
                    newCol.Attributes.Append(attrName);
                    nd.AppendChild(newCol);

                    newCol = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                    newCol.InnerText = arr[0].ToString();
                    attrName = docXml.CreateAttribute("name");
                    attrName.Value = "firstdate";
                    newCol.Attributes.Append(attrName);
                    nd.AppendChild(newCol);

                    newCol = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                    newCol.InnerText = arr.Count.ToString();
                    attrName = docXml.CreateAttribute("name");
                    attrName.Value = "datecount";
                    newCol.Attributes.Append(attrName);
                    nd.AppendChild(newCol);

                    foreach (DateTime dt in arr)
                    {
                        newCol = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        newCol.InnerText = timeperiods.Replace("#", "0");
                        nd.AppendChild(newCol);
                    }
                    //newCol = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    //newCol.InnerText = "0";


                    //nd.AppendChild(newCol);

                    XmlNode ndCell = nd.SelectSingleNode("cell");
                    XmlNode ndNewCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    //nd.InsertBefore(ndNewCell, ndCell);
                    //ndNewCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    nd.InsertBefore(ndNewCell, ndCell);

                    ndNewCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    ndNewCell.InnerText = "";
                    nd.AppendChild(ndNewCell);



                    DataRow[] drTotal = dsTSHours.Tables[3].Select("list_uid='" + ndListId.InnerText + "' and item_id=" + ndItemId.InnerText);

                    XmlNode ndWork = nd.SelectSingleNode("userdata[@name='Work']");

                    ndNewCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    if (drTotal.Length > 0)
                        ndNewCell.InnerText = ndWork.InnerText + "|" + drTotal[0][0].ToString();
                    else
                        ndNewCell.InnerText = ndWork.InnerText + "|0";

                    nd.AppendChild(ndNewCell);
                }
                else
                {
                    foreach (DateTime dt in arr)
                    {
                        XmlNode newCol = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                        newCol.InnerText = "";

                        XmlAttribute attrType = docXml.CreateAttribute("type");
                        attrType.Value = "ro";
                        newCol.Attributes.Append(attrType);
                        

                        nd.AppendChild(newCol);
                    }

                    XmlNode newCol2 = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    newCol2.InnerText = "-";
                    XmlAttribute attrStyle2 = docXml.CreateAttribute("style");
                    attrStyle2.Value = "background: #" + bgcolor;
                    newCol2.Attributes.Append(attrStyle2);

                    XmlAttribute attrType2 = docXml.CreateAttribute("type");
                    attrType2.Value = "ron";
                    newCol2.Attributes.Append(attrType2);

                    nd.AppendChild(newCol2);

                    XmlNode ndCell = nd.SelectSingleNode("cell");
                    XmlNode ndNewCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    XmlAttribute attrType3 = docXml.CreateAttribute("type");
                    attrType3.Value = "ro";
                    ndNewCell.Attributes.Append(attrType3);

                    nd.InsertBefore(ndNewCell, ndCell);
                    //nd.InsertBefore(ndNewCell.Clone(), ndCell);

                    //ndNewCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    //ndNewCell.InnerText = "";
                    //nd.AppendChild(ndNewCell);

                    ndNewCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    ndNewCell.InnerText = "";
                    attrType3 = docXml.CreateAttribute("type");
                    attrType3.Value = "ro";
                    ndNewCell.Attributes.Append(attrType3);
                    nd.AppendChild(ndNewCell);
                }
            }

            XmlNodeList ndNewCols = docXml.SelectNodes("//head/column");
            double fullWidth = double.Parse(Request["width"]);

            fullWidth -= 165;
            int count = 1;
            if (inEditMode)
            {
                count = 2;
                fullWidth = fullWidth / columnCount;
            }
            else
            {
                fullWidth = fullWidth / (columnCount + 1);
            }

            

            if (fullWidth < 50)
                fullWidth = 50;

            

            for (int i = count; i <= columnCount; i++)
            {
                string id = "";
                try
                {
                    id = ndNewCols[i].Attributes["type"].Value;
                }
                catch { }
                if (ndNewCols[i].InnerText != "hideme")
                {
                    if (id == "tree")
                        ndNewCols[i].Attributes["width"].Value = (fullWidth * 2 - 10).ToString();
                    else
                    {
                        ndNewCols[i].Attributes["width"].Value = fullWidth.ToString();
                    }
                }
            }


            if (globalError != "")
            {
                XmlNode nd = docXml.FirstChild.SelectSingleNode("//afterInit");
                if (nd != null)
                {
                    XmlNode ndCall = docXml.CreateNode(XmlNodeType.Element, "call", docXml.NamespaceURI);
                    XmlAttribute attrName = docXml.CreateAttribute("command");
                    attrName.Value = "alerterror";
                    ndCall.Attributes.Append(attrName);

                    XmlNode ndParam = docXml.CreateNode(XmlNodeType.Element, "param", docXml.NamespaceURI);
                    ndParam.InnerText = globalError;

                    ndCall.AppendChild(ndParam);
                    nd.AppendChild(ndCall);
                }
            }

            data = docXml.OuterXml;
        }
        
    }

}
