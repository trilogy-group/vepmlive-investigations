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
    public partial class getts : System.Web.UI.Page
    {
        XmlDocument docXml = new XmlDocument();
        XmlNode ndMainParent;
        protected string data = "";
        private string period = "";
        private DateTime periodStart;
        private DateTime periodEnd;
        private DataSet dsTimesheets;
        private DataSet dsTimesheetTotals;
        private DataSet dsTimesheetTasks;
        private DataSet dsTimesheetTaskHours;
        private DataSet dsTimesheetTypes;
        private DataSet dsTimesheetNotes;
        private string[] dayDefs;
        SPList list;
        //SPView view;

        private Hashtable hshLists = new Hashtable();
        private Hashtable hshItemNodes = new Hashtable();
        private Hashtable hshResNodes = new Hashtable();
        protected SortedList arrItems = new SortedList();
        protected Queue queueAllItems = new Queue();

        XmlNode ndBeforeInit;

        SqlConnection cn;

        protected string[] arrGroupFields;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            Response.ContentType = "text/xml";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            period = Request["period_id"];

            docXml.LoadXml("<rows></rows>");
            ndMainParent = docXml.ChildNodes[0];

            SPWeb web = SPContext.Current.Web;
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    try
                    {
                        cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                        cn.Open();
                    }
                    catch { }
                });



                string resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, false);
                SPWeb resWeb = null;
                if (resUrl != "")
                { 
                    if (resUrl.ToLower() != web.Url.ToLower())
                    {
                        SPSite tempSite = new SPSite(resUrl);

                        resWeb = tempSite.OpenWeb();
                        if (resWeb.Url.ToLower() != resUrl.ToLower())
                        {
                            resWeb = null;
                        }
                        tempSite.Close();
                    }
                    else
                        resWeb = web;
                    if (resWeb != null)
                    {
                        list = resWeb.Lists["Resources"];
                        addHeader(web);
                        addGroups(resWeb);
                    }
                    if (resWeb.ID != SPContext.Current.Web.ID)
                        resWeb.Close();
                }
                cn.Close();
            }

            data = docXml.OuterXml;
        }

        private void addHeader(SPWeb curWeb)
        {
            XmlNode ndHead = docXml.CreateNode(XmlNodeType.Element, "head", docXml.NamespaceURI);
            docXml.ChildNodes[0].AppendChild(ndHead);
            ndBeforeInit = docXml.CreateNode(XmlNodeType.Element, "beforeInit", docXml.NamespaceURI);
            ndHead.AppendChild(ndBeforeInit);
            XmlNode afterInitNode = docXml.CreateNode(XmlNodeType.Element, "afterInit", docXml.NamespaceURI);
            ndHead.AppendChild(afterInitNode);

            //XmlNode ndSettings = docXml.CreateNode(XmlNodeType.Element, "settings", docXml.NamespaceURI);
            //XmlNode ndColwith = docXml.CreateNode(XmlNodeType.Element, "colwidth", docXml.NamespaceURI);
            //ndColwith.InnerText = "%";
            //ndSettings.AppendChild(ndColwith);
            //ndHead.AppendChild(ndSettings);

            XmlNode ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            ndNewColumn.InnerXml = "#master_checkbox";

            XmlAttribute attrType = docXml.CreateAttribute("type");
            attrType.Value = "ch";
            XmlAttribute attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = "20";
            XmlAttribute attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "center";

            ndNewColumn.Attributes.Append(attrType);
            ndNewColumn.Attributes.Append(attrWidth);
            ndNewColumn.Attributes.Append(attrAlign);
            ndHead.AppendChild(ndNewColumn);

            ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            ndNewColumn.InnerXml = "<![CDATA[Notes]]>";

            attrType = docXml.CreateAttribute("type");
            attrType.Value = "tsnotes";
            attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = "50";
            attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "center";

            ndNewColumn.Attributes.Append(attrType);
            ndNewColumn.Attributes.Append(attrWidth);
            ndNewColumn.Attributes.Append(attrAlign);
            ndHead.AppendChild(ndNewColumn);


            ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            ndNewColumn.InnerXml = "<![CDATA[Resource Name]]>";

            attrType = docXml.CreateAttribute("type");
            attrType.Value = "tree";
            attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = "*";
            attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "left";

            ndNewColumn.Attributes.Append(attrType);
            ndNewColumn.Attributes.Append(attrWidth);
            ndNewColumn.Attributes.Append(attrAlign);
            ndHead.AppendChild(ndNewColumn);


            ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            ndNewColumn.InnerXml = "<![CDATA[TM]]>";

            attrType = docXml.CreateAttribute("type");
            attrType.Value = "ro";
            attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = "35";
            attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "center";

            ndNewColumn.Attributes.Append(attrType);
            ndNewColumn.Attributes.Append(attrWidth);
            ndNewColumn.Attributes.Append(attrAlign);
            ndHead.AppendChild(ndNewColumn);

            ndNewColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            ndNewColumn.InnerXml = "<![CDATA[PM]]>";

            attrType = docXml.CreateAttribute("type");
            attrType.Value = "ro";
            attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = "35";
            attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "center";

            ndNewColumn.Attributes.Append(attrType);
            ndNewColumn.Attributes.Append(attrWidth);
            ndNewColumn.Attributes.Append(attrAlign);
            ndHead.AppendChild(ndNewColumn);

            SqlCommand cmd = new SqlCommand("select period_start,period_end,locked from TSPERIOD where period_id=@period_id and site_id=@siteid", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@period_id", period);
            cmd.Parameters.AddWithValue("@siteid", curWeb.Site.ID);
            SqlDataReader dr = cmd.ExecuteReader();
            //DataSet ds = new DataSet();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(ds);
            if (dr.Read())
            {
                periodStart = dr.GetDateTime(0);
                periodEnd = dr.GetDateTime(1);
            }
            dr.Close();

            dayDefs = EPMLiveCore.CoreFunctions.getConfigSetting(curWeb.Site.RootWeb, "EPMLiveDaySettings").Split('|');

            TimeSpan ts = periodEnd - periodStart;
            for (int i = 0; i <= ts.Days; i++)
            {
                string showday = "";
                try
                {
                    showday = dayDefs[((int)periodStart.AddDays(i).DayOfWeek) * 3];
                }
                catch { }
                if (showday == "True")
                {
                    XmlNode newCol = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
                    newCol.InnerXml = "<![CDATA[" + periodStart.AddDays(i).DayOfWeek.ToString().Substring(0, 3) + "<br>" + periodStart.AddDays(i).Day + "]]>";
                    attrType = docXml.CreateAttribute("type");
                    attrType.Value = "ro[=sum]";
                    attrWidth = docXml.CreateAttribute("width");
                    attrWidth.Value = "40";
                    attrAlign = docXml.CreateAttribute("align");
                    attrAlign.Value = "right";
                    XmlAttribute attrId1 = docXml.CreateAttribute("id");
                    attrId1.Value = "_TsDate_" + periodStart.AddDays(i).ToShortDateString().Replace("/", "_"); ;

                    newCol.Attributes.Append(attrType);
                    newCol.Attributes.Append(attrWidth);
                    newCol.Attributes.Append(attrAlign);
                    newCol.Attributes.Append(attrId1);

                    ndHead.AppendChild(newCol);
                }
            }

            XmlNode newColumn = docXml.CreateNode(XmlNodeType.Element, "column", docXml.NamespaceURI);
            newColumn.InnerXml = "Total";
            attrType = docXml.CreateAttribute("type");
            attrType.Value = "ro[=sum]";
            attrWidth = docXml.CreateAttribute("width");
            attrWidth.Value = "60";
            attrAlign = docXml.CreateAttribute("align");
            attrAlign.Value = "right";
            XmlAttribute attrId = docXml.CreateAttribute("id");
            attrId.Value = "Total";

            newColumn.Attributes.Append(attrType);
            newColumn.Attributes.Append(attrWidth);
            newColumn.Attributes.Append(attrAlign);
            newColumn.Attributes.Append(attrId);

            ndHead.AppendChild(newColumn);


            cmd = new SqlCommand("select ts_uid,username,submitted,approval_status,approval_notes from TSTIMESHEET where period_id=@period_id and site_uid=@siteid", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@period_id", period);
            cmd.Parameters.AddWithValue("@siteid", curWeb.Site.ID);
            dsTimesheets = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dsTimesheets);

            cmd = new SqlCommand("select hours,ts_item_date,ts_uid from vwTSTimesheetTotals where period_id=@period_id and site_uid=@siteid", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@period_id", period);
            cmd.Parameters.AddWithValue("@siteid", curWeb.Site.ID);
            dsTimesheetTotals = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(dsTimesheetTotals);

            cmd = new SqlCommand("select title,project,ts_uid,ts_item_uid,approval_status from vwTSTasks where period_id=@period_id and site_uid=@siteid order by project", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@period_id", period);
            cmd.Parameters.AddWithValue("@siteid", curWeb.Site.ID);
            dsTimesheetTasks = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(dsTimesheetTasks);

            cmd = new SqlCommand("select Hours,ts_item_date,ts_item_uid,ts_item_type_id from vwTSHoursByTask where period_id=@period_id and site_uid=@siteid", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@period_id", period);
            cmd.Parameters.AddWithValue("@siteid", curWeb.Site.ID);
            dsTimesheetTaskHours = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(dsTimesheetTaskHours);

            cmd = new SqlCommand("select tstype_id from TSTYPE where site_uid=@siteid", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@siteid", curWeb.Site.ID);
            dsTimesheetTypes = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(dsTimesheetTypes);

            cmd = new SqlCommand("select ts_item_uid,ts_item_notes,ts_item_date from vwTSNotes where period_id=@period_id and site_uid=@siteid", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@period_id", period);
            cmd.Parameters.AddWithValue("@siteid", curWeb.Site.ID);
            dsTimesheetNotes = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(dsTimesheetNotes);
        }
        private void addGroups(SPWeb curWeb)
        {
            //string query = view.Query;


            //arrGroupFields = new string[arrTempGroups.Count];
            //arrGroupFields[counter++] = s;

            SortedList arrGTemp = new SortedList();

            processList(curWeb, arrGTemp);
            
            TimeSpan ts = periodEnd - periodStart;

            foreach (DictionaryEntry e in arrGTemp)
            {
                string newItem = e.Key.ToString();
                int parentInd = newItem.LastIndexOf("\n");
                string parent = "";

                if (parentInd >= 0)
                {
                    parent = newItem.Substring(0, parentInd);
                    newItem = newItem.Substring(parentInd + 1);
                }

                if ((hshItemNodes.Contains(parent) && !hshItemNodes.Contains(e.Key.ToString())) || (parentInd == -1 && !hshItemNodes.Contains(e.Key.ToString())))
                {
                    XmlNode ndParent = null;
                    if (parentInd == -1)
                        ndParent = ndMainParent;
                    else
                        ndParent = (XmlNode)hshItemNodes[parent];

                    XmlNode newNode = docXml.CreateNode(XmlNodeType.Element, "row", docXml.NamespaceURI);
                    XmlAttribute attrId = docXml.CreateAttribute("id");

                    if (e.Key.ToString() != "")
                        attrId.Value = e.Key.ToString();
                    else
                        attrId.Value = Guid.NewGuid().ToString();

                    newNode.Attributes.Append(attrId);
                    XmlAttribute attrLocked = docXml.CreateAttribute("locked");
                    attrLocked.Value = "1";
                    newNode.Attributes.Append(attrLocked);

                    int indentlevel = e.Key.ToString().Split('\n').Length;

                    XmlAttribute attrExpand = docXml.CreateAttribute("open");
                    attrExpand.Value = "1";
                    newNode.Attributes.Append(attrExpand);

                    ndParent.AppendChild(newNode);

                    XmlNode newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    XmlAttribute attrType = docXml.CreateAttribute("type");
                    attrType.Value = "ro";
                    newCell.Attributes.Append(attrType);
                    newNode.AppendChild(newCell);

                    newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    attrType = docXml.CreateAttribute("type");
                    attrType.Value = "ro";
                    newCell.Attributes.Append(attrType);
                    newNode.AppendChild(newCell);

                    newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    if (newItem == "")
                        newCell.InnerText = "No Value";
                    else
                        newCell.InnerText = newItem;
                    newNode.AppendChild(newCell);
   
                    XmlAttribute attrBold = docXml.CreateAttribute("style");
                    attrBold.Value = "font-weight:bold;background: #B6C8ED";
                    newNode.Attributes.Append(attrBold);

                    newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    newCell.InnerText = "";
                    newNode.AppendChild(newCell);

                    for (int i = 0; i <= ts.Days; i++)
                    {
                        string showday = "";
                        try
                        {
                            showday = dayDefs[((int)periodStart.AddDays(i).DayOfWeek) * 3];
                        }
                        catch { }
                        if (showday == "True")
                        {
                            newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            newCell.InnerText = "";
                            newNode.AppendChild(newCell);
                        }
                    }

                    hshItemNodes.Add(e.Key.ToString(), newNode);
                }
            }
            while (queueAllItems.Count > 0)
            {
                SPListItem li = (SPListItem)queueAllItems.Dequeue();
                if (arrItems.Contains(li.ID.ToString()))
                {
                    string resName = li.Title;
                    string realName = "";
                    string uName = "";
                    try
                    {
                        SPFieldUserValue uv = new SPFieldUserValue(curWeb, li["SharePointAccount"].ToString());
                        uName = uv.User.LoginName;
                        realName = uv.User.Name;
                    }
                    catch { }

                    DataRow[] drs = dsTimesheets.Tables[0].Select("username like '" + uName + "'");

                    if (uName != "" && drs.Length > 0)
                    {


                        string groupname = "";
                        if(arrItems[li.ID.ToString()] == null)
                            groupname = uName;
                        else
                            groupname = arrItems[li.ID.ToString()].ToString() + "\n" + uName;

                        string newItem = groupname;
                        int parentInd = newItem.LastIndexOf("\n");
                        string parent = "";

                        if (parentInd >= 0)
                        {
                            parent = newItem.Substring(0, parentInd);
                            newItem = newItem.Substring(parentInd + 1);
                        }

                        if ((hshItemNodes.Contains(parent) && !hshItemNodes.Contains(groupname)) || (parentInd == -1 && !hshItemNodes.Contains(groupname)))
                        {
                            XmlNode ndParent = null;
                            if (parentInd == -1)
                                ndParent = ndMainParent;
                            else
                                ndParent = (XmlNode)hshItemNodes[parent];

                            XmlNode newNode = docXml.CreateNode(XmlNodeType.Element, "row", docXml.NamespaceURI);
                            XmlAttribute attrId = docXml.CreateAttribute("id");

                            attrId.Value = li.ID.ToString();

                            newNode.Attributes.Append(attrId);


                            XmlAttribute attrExpand = docXml.CreateAttribute("open");
                            //attrExpand.Value = "0";
                            //newNode.Attributes.Append(attrExpand);

                            ndParent.AppendChild(newNode);

                            XmlNode newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            newNode.AppendChild(newCell);

                            XmlNode ndNotes = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            newNode.AppendChild(ndNotes);

                            newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            if (resName.ToLower() != realName.ToLower())
                                newCell.InnerText = resName + " (" + realName + ")";
                            else
                                newCell.InnerText = resName;

                            newNode.AppendChild(newCell);

                            XmlAttribute attrStyle = docXml.CreateAttribute("style");
                            attrStyle.Value = "background: #DFE7F7; font-weight:bold";
                            newNode.Attributes.Append(attrStyle);

                            
                            newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            //if (drs.Length > 0)
                            //{
                                ndNotes.InnerText = drs[0]["approval_notes"].ToString();

                                XmlNode ndTSuid = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                                XmlAttribute attrName = docXml.CreateAttribute("name");
                                attrName.Value = "tsuid";
                                ndTSuid.InnerText = drs[0]["ts_uid"].ToString();
                                ndTSuid.Attributes.Append(attrName);
                                newNode.AppendChild(ndTSuid);

                                if (drs[0]["approval_status"].ToString().ToLower() == "1")
                                {
                                    newCell.InnerXml = "<![CDATA[<img src=\"images/tsflaggreen.gif\" alt=\"Approved\">]]>";
                                }
                                else if (drs[0]["approval_status"].ToString().ToLower() == "2")
                                {
                                    newCell.InnerXml = "<![CDATA[<img src=\"images/tsflagred.gif\" alt=\"Rejected\">]]>";
                                }
                                else if (drs[0]["submitted"].ToString().ToLower() == "true")
                                {
                                    newCell.InnerXml = "<![CDATA[<img src=\"images/tsflagyellow.gif\" alt=\"Submitted\">]]>";
                                }
                                else
                                {
                                    newCell.InnerXml = "<![CDATA[<img src=\"images/tsflagblue.gif\" alt=\"Saved\">]]>";



                                    //newNode.SelectSingleNode("cell").InnerText = "1";
                                    //XmlAttribute attrType = docXml.CreateAttribute("type");
                                    //attrType.Value = "ro";
                                    //ndNotes.Attributes.Append(attrType);
                                    //newNode.SelectSingleNode("cell").Attributes.Append(attrType);
                                    //newNode.SelectSingleNode("cell").InnerText = "<![CDATA[<input type='checkbox' disabled='true'>]]>";
                                }
                                newNode.AppendChild(newCell);



                                XmlNode ndStatus = docXml.CreateNode(XmlNodeType.Element, "userdata", docXml.NamespaceURI);
                                attrName = docXml.CreateAttribute("name");
                                attrName.Value = "Status";
                                ndStatus.InnerText = newCell.InnerText;
                                ndStatus.Attributes.Append(attrName);
                                newNode.AppendChild(ndStatus);
                                
                                //for (int i = 0; i <= ts.Days; i++)
                                //{
                                //    string showday = "";
                                //    try
                                //    {
                                //        showday = dayDefs[((int)periodStart.AddDays(i).DayOfWeek) * 3];
                                //    }
                                //    catch { }
                                //    if (showday == "True")
                                //    {
                                //        DataRow[] drTotal = dsTimesheetTotals.Tables[0].Select("ts_uid = '" + drs[0]["ts_uid"].ToString() + "' AND ts_item_date='" + periodStart.AddDays(i).ToString() + "'");

                                //        newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                                //        if (drTotal.Length > 0)
                                //            newCell.InnerText = drTotal[0][0].ToString();
                                //        else
                                //            newCell.InnerText = "0";
                                //        newNode.AppendChild(newCell);
                                //    }
                                //}

                                for (int i = 0; i <= ts.Days; i++)
                                {
                                    string showday = "";
                                    try
                                    {
                                        showday = dayDefs[((int)periodStart.AddDays(i).DayOfWeek) * 3];
                                    }
                                    catch { }
                                    if (showday == "True")
                                    {
                                        newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                                        newCell.InnerText = "";
                                        newNode.AppendChild(newCell);
                                    }
                                }

                                DataRow[] drTasks = dsTimesheetTasks.Tables[0].Select("ts_uid = '" + drs[0]["ts_uid"].ToString() + "'");

                                XmlNode ndProject = null;
                                string curProject = "";

                                foreach (DataRow drTask in drTasks)
                                {
                                    if (drTask["project"].ToString() != curProject)
                                    {
                                        curProject = drTask["project"].ToString();
                                        ndProject = docXml.CreateNode(XmlNodeType.Element, "row", docXml.NamespaceURI);
                                        
                                        attrId = docXml.CreateAttribute("id");
                                        attrId.Value = li.ID.ToString() + "." + curProject;
                                        ndProject.Attributes.Append(attrId);

                                        attrExpand = docXml.CreateAttribute("open");
                                        attrExpand.Value = "1";
                                        ndProject.Attributes.Append(attrExpand);

                                        newNode.AppendChild(ndProject);

                                        newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                                        XmlAttribute attrType = docXml.CreateAttribute("type");
                                        attrType.Value = "ro";
                                        newCell.Attributes.Append(attrType);
                                        ndProject.AppendChild(newCell);

                                        newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                                        attrType = docXml.CreateAttribute("type");
                                        attrType.Value = "ro";
                                        newCell.Attributes.Append(attrType);
                                        ndProject.AppendChild(newCell);

                                        newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                                        newCell.InnerText = curProject;
                                        ndProject.AppendChild(newCell);

                                        newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                                        newCell.InnerText = "";
                                        ndProject.AppendChild(newCell);

                                        newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                                        newCell.InnerText = "";
                                        ndProject.AppendChild(newCell);

                                        

                                        for (int i = 0; i <= ts.Days; i++)
                                        {
                                            string showday = "";
                                            try
                                            {
                                                showday = dayDefs[((int)periodStart.AddDays(i).DayOfWeek) * 3];
                                            }
                                            catch { }
                                            if (showday == "True")
                                            {
                                                newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                                                newCell.InnerText = "";
                                                ndProject.AppendChild(newCell);
                                            }
                                        }
                                        XmlAttribute attrBold = docXml.CreateAttribute("style");
                                        attrBold.Value = "font-weight:bold;";
                                        ndProject.Attributes.Append(attrBold);
                                        
                                    }

                                    XmlNode ndTask = docXml.CreateNode(XmlNodeType.Element, "row", docXml.NamespaceURI);

                                    attrId = docXml.CreateAttribute("id");
                                    attrId.Value = li.ID.ToString() + "." + curProject + "." + drTask["title"].ToString();
                                    ndTask.Attributes.Append(attrId);

                                    newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                                    XmlAttribute attrTType = docXml.CreateAttribute("type");
                                    attrTType.Value = "ro";
                                    newCell.Attributes.Append(attrTType);
                                    ndTask.AppendChild(newCell);

                                    newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                                    attrTType = docXml.CreateAttribute("type");
                                    attrTType.Value = "ro";
                                    newCell.Attributes.Append(attrTType);
                                    ndTask.AppendChild(newCell);

                                    newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                                    newCell.InnerText = drTask["title"].ToString();
                                    ndTask.AppendChild(newCell);
                                    
                                    newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                                    newCell.InnerText = "";
                                    ndTask.AppendChild(newCell);

                                    newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                                    switch (drTask["APPROVAL_STATUS"].ToString())
                                    {
                                        case "0":
                                            newCell.InnerXml = "<![CDATA[<img src=\"images/tsflagwhite.gif\" alt=\"Pending\">]]>";
                                            break;
                                        case "1":
                                            newCell.InnerXml = "<![CDATA[<img src=\"images/tsflaggreen.gif\" alt=\"Approved\">]]>";
                                            break;
                                        case "2":
                                            newCell.InnerXml = "<![CDATA[<img src=\"images/tsflagred.gif\" alt=\"Rejected\">]]>";
                                            break;
                                    };
                                    ndTask.AppendChild(newCell);

                                    double total = 0;

                                    for (int i = 0; i <= ts.Days; i++)
                                    {
                                        string showday = "";
                                        try
                                        {
                                            showday = dayDefs[((int)periodStart.AddDays(i).DayOfWeek) * 3];
                                        }
                                        catch { }
                                        if (showday == "True")
                                        {

                                            DataRow[] drTaskTimes = dsTimesheetTaskHours.Tables[0].Select("ts_item_uid='" + drTask["ts_item_uid"].ToString() + "' and ts_item_date = '" + periodStart.AddDays(i).ToString() + "'");
                                            DataRow[] drTaskNotes = dsTimesheetNotes.Tables[0].Select("ts_item_uid='" + drTask["ts_item_uid"].ToString() + "' and ts_item_date = '" + periodStart.AddDays(i).ToString() + "'");

                                            newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                                            string hours = "";
                                            //if (drTaskTimes.Length > 0 || drTaskNotes.Length > 0)
                                            //{
                                                if (dsTimesheetTypes.Tables[0].Rows.Count > 0)
                                                {
                                                    attrTType = docXml.CreateAttribute("type");
                                                    attrTType.Value = "timeeditor";
                                                    newCell.Attributes.Append(attrTType);

                                                    foreach (DataRow drType in dsTimesheetTypes.Tables[0].Rows)
                                                    {
                                                        DataRow[] drTaskTypeTime = dsTimesheetTaskHours.Tables[0].Select("ts_item_uid='" + drTask["ts_item_uid"].ToString() + "' and ts_item_date = '" + periodStart.AddDays(i).ToString() + "' and ts_item_type_id=" + drType["tstype_id"].ToString());
                                                        if (drTaskTypeTime.Length > 0)
                                                        {
                                                            hours += "|" + drType["tstype_id"].ToString() + "|" + drTaskTypeTime[0]["hours"].ToString();
                                                            try
                                                            {
                                                                total += double.Parse(drTaskTypeTime[0]["hours"].ToString());
                                                            }
                                                            catch { }
                                                        }
                                                        else
                                                            hours += "|" + drType["tstype_id"].ToString() + "|0";
                                                    }
                                                    hours = hours.Substring(1);
                                                    if (drTaskNotes.Length > 0)
                                                    {
                                                        hours += "|N|" + drTaskNotes[0]["ts_item_notes"].ToString();
                                                    }
                                                }
                                                else
                                                {
                                                    if (drTaskTimes.Length > 0)
                                                        hours = drTaskTimes[0]["hours"].ToString();
                                                    else
                                                        hours = "0";

                                                    try
                                                    {
                                                        total += double.Parse(hours);
                                                    }
                                                    catch { }

                                                    if (drTaskNotes.Length > 0)
                                                    {
                                                        attrTType = docXml.CreateAttribute("type");
                                                        attrTType.Value = "timeeditor";
                                                        newCell.Attributes.Append(attrTType);
                                                        hours = "0|" + hours + "|N|" + drTaskNotes[0]["ts_item_notes"].ToString();
                                                    }
                                                }
                                            //}
                                            //else
                                            //{
                                            //    hours = "0";
                                            //}
                                            newCell.InnerText = hours;

                                            ndTask.AppendChild(newCell);
                                        }
                                    }

                                    newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                                    newCell.InnerText = total.ToString();
                                    ndTask.AppendChild(newCell);

                                    ndProject.AppendChild(ndTask);
                                }
                            //}
                            //else
                            //{
                            //    newCell.InnerXml = "<![CDATA[<img src=\"images/tsflagwhite.gif\" alt=\"No Timesheet\">]]>";
                            //    XmlAttribute attrType = docXml.CreateAttribute("type");
                            //    attrType.Value = "ro";
                            //    //newNode.SelectSingleNode("cell").Attributes.Append(attrType);
                            //    //newNode.SelectSingleNode("cell").InnerXml = "<![CDATA[<input type='checkbox' disabled='true'>]]>";
                            //    newNode.SelectSingleNode("cell").InnerText = "1";
                            //    newNode.SelectNodes("cell")[1].Attributes.Append(attrType);
                            //    newNode.AppendChild(newCell);

                            //    newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            //    newCell.InnerText = "";
                            //    newNode.AppendChild(newCell);

                            //    for (int i = 0; i <= ts.Days; i++)
                            //    {
                            //        string showday = "";
                            //        try
                            //        {
                            //            showday = dayDefs[((int)periodStart.AddDays(i).DayOfWeek) * 3];
                            //        }
                            //        catch { }
                            //        if (showday == "True")
                            //        {
                            //            newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            //            newCell.InnerText = "0";
                            //            newNode.AppendChild(newCell);
                            //        }
                            //    }

                            //    newCell = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                            //    newCell.InnerText = "0";
                            //    newNode.AppendChild(newCell);
                            //}
                            

                            if(!hshItemNodes.Contains(groupname))
                                hshItemNodes.Add(groupname, newNode);

                            if (!hshResNodes.Contains(uName))
                                hshResNodes.Add(uName, newNode);
                        }
                    }
                }
            }

        }

        protected void processList(SPWeb web, SortedList arrGTemp)
        {
            try
            {
                //string squery = view.Query;
                //string newquery = "<Contains><FieldRef Name='TimesheetManager'/><Value Type='User'><UserID/></Value></Contains>";

                //XmlDocument querydoc = new XmlDocument();
                //querydoc.LoadXml("<Query>" + squery + "</Query>");

                //XmlNode ndWhere = querydoc.FirstChild.SelectSingleNode("Where");
                //if (ndWhere == null)
                //{
                //    squery = "<Where>" + newquery + "</Where>" + squery;
                //}
                //else
                //{
                //    ndWhere.InnerXml = "<And>" + newquery + ndWhere.InnerXml + "</And>";
                //    squery = querydoc.FirstChild.InnerXml;
                //}


                //SPQuery query = new SPQuery();
                //query.Query = squery;

                foreach (SPListItem li in list.Items)
                {
                    string group = null;
                    if (arrGroupFields != null)
                    {
                        foreach (string groupby in arrGroupFields)
                        {
                            SPField field = list.Fields.GetFieldByInternalName(groupby);
                            string newgroup = field.GetFieldValueAsText(li[field.Id].ToString());
                            
                            if (group == null)
                                group = newgroup;
                            else
                                group += "\n" + newgroup;

                            if (!arrGTemp.Contains(group))
                            {
                                arrGTemp.Add(group, "");
                            }
                        }
                    }

                    arrItems.Add(li.ID.ToString(), group);
                    queueAllItems.Enqueue(li);
                }
            }
            catch { }

        }

        private SPField getRealField(SPField field)
        {
            try
            {
                if (field.Type == SPFieldType.Computed)
                {
                    {
                        XmlDocument fieldXml = new XmlDocument();
                        fieldXml.LoadXml(field.SchemaXml);

                        string parentField = "";
                        try
                        {
                            parentField = fieldXml.FirstChild.Attributes["DisplayNameSrcField"].Value;
                        }
                        catch { }
                        if (parentField != "")
                        {
                            try
                            {
                                field = field.ParentList.Fields.GetFieldByInternalName(parentField);
                            }
                            catch { }
                        }
                    }
                }
            }
            catch { }
            return field;
        }
    }
}
