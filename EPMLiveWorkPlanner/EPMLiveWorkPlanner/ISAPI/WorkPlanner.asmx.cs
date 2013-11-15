using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Services;
using System.Xml;

namespace EPMLiveWorkPlanner
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "workengine.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WorkPlannerAPI : System.Web.Services.WebService
    {
        /*
         * Error Code Usage:
         * 1000 - Execute
         * 1001 - TestFunction
         */
        public class PlannerProps
        {
            public PlannerProps()
            {
                rolldowns = new ArrayList();
                rollups = new ArrayList();
            }

            #region KanBan Props
            public string KanBanStatusColumn;
            public string KanBanFilterColumn;
            public string KanBanTitleColumn;
            public string KanBanAdditionalColumns;
            public string KanBanItemStatusFields;
            #endregion

            public string sListProjectCenter;
            public string sListTaskCenter;
            public string sIterationCT;
            public PlannerCore.WorkPlannerProperties wpFields;
            public string sWorkDays;
            public int[] iWorkHours = new int[4];
            public DataTable Holidays;
            public SPFieldLinkCollection oFolderFields;
            public SPFieldLinkCollection oTaskFields;
            public SPFieldLinkCollection oIterationFields;
            public ArrayList rolldowns;
            public ArrayList rollups;
            public SortedList StatusFields;
            public bool bAgile = false;
            public string sProjectField;
            public string sFieldMappings;
            public bool bCalcWork = false;
            public bool bCalcCost = false;
            public bool bUseFolders = false;
            public int iTaskType = 0;
            public bool bEnableLinking = false;
            public bool bStartSoon = false;
        }

        [WebMethod]
        public string Execute(string Functionname, string Dataxml)
        {

            try
            {
                Assembly assemblyInstance = Assembly.GetExecutingAssembly();
                Type thisClass = assemblyInstance.GetType("EPMLiveWorkPlanner.WorkPlannerAPI", true, true);
                MethodInfo m = thisClass.GetMethod(Functionname);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(Dataxml);
                object result = m.Invoke(null, new object[] { doc, SPContext.Current.Web });
                return result.ToString();
            }
            catch (Exception ex)
            {
                return "<Result Status=\"1\"><Error ID=\"1000\">Error executing function: " + ex.Message + "</Error></Result>";
            }

        }

        public static string GetExternalTasks(XmlDocument data, SPWeb oWeb)
        {
            string PlannerID = getAttribute(data.FirstChild, "PlannerID");
            string ProjectID = getAttribute(data.FirstChild, "ProjectID");

            XmlDocument docPlanInfo = new XmlDocument();
            docPlanInfo.LoadXml("<GetTasks Planner=\"" + PlannerID + "\" ID=\"" + ProjectID + "\" View=\"\"/>");

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(iGetGeneralLayout(oWeb, Properties.Resources.txtDefaultConfig, docPlanInfo, false));

            string sListTaskCenter = "";

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                using (SPSite site = new SPSite(oWeb.Site.ID))
                {
                    using (SPWeb iweb = site.OpenWeb(oWeb.ID))
                    {
                        Guid lockWeb = EPMLiveCore.CoreFunctions.getLockedWeb(iweb);
                        if (lockWeb == Guid.Empty || lockWeb == oWeb.ID)
                        {
                            sListTaskCenter = EPMLiveCore.CoreFunctions.getConfigSetting(oWeb, "EPMLivePlanner" + PlannerID + "TaskCenter");
                        }
                        else
                        {
                            using (SPWeb w = site.OpenWeb(lockWeb))
                            {
                                sListTaskCenter = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePlanner" + PlannerID + "TaskCenter");
                            }

                        }
                    }
                }
            });

            //DataTable dtProjects = EPMLiveCore.ReportingData.GetReportingData(oWeb, sListTaskCenter, false, "ProjectID=" + ProjectID + " And IsAssignment = 0", "taskorder");

            XmlAttribute attr = doc.CreateAttribute("Editing");
            attr.Value = "0";
            doc.FirstChild.SelectSingleNode("//Cfg").Attributes.Append(attr);
            attr = doc.CreateAttribute("Dragging");
            attr.Value = "0";
            doc.FirstChild.SelectSingleNode("//Cfg").Attributes.Append(attr);

            XmlNode ndAction = doc.CreateNode(XmlNodeType.Element, "Actions", doc.NamespaceURI);
            attr = doc.CreateAttribute("OnClickCell");
            attr.Value = "ClearSelection,SelectRow";
            ndAction.Attributes.Append(attr);
            doc.FirstChild.AppendChild(ndAction);

            XmlNode ndBody1 = doc.CreateNode(XmlNodeType.Element, "Body", doc.NamespaceURI);
            XmlNode ndBody = doc.CreateNode(XmlNodeType.Element, "B", doc.NamespaceURI);
            ndBody1.AppendChild(ndBody);


            doc.FirstChild.SelectSingleNode("//Foot/I[@id='NewTask2']").Attributes["Visible"].Value = "0";
            doc.FirstChild.SelectSingleNode("//Panel").Attributes["Visible"].Value = "0";
            doc.FirstChild.SelectSingleNode("//D[@Name='Assignment']").Attributes["Visible"].Value = "0";

            SPList oList = oWeb.Lists.TryGetList(sListTaskCenter);

            Hashtable hshUserFields = new Hashtable();

            SPQuery query = new SPQuery();
            query.Query = "<Where><Eq><FieldRef Name='Project' LookupId='TRUE'/><Value Type='Lookup'>" + ProjectID + "</Value></Eq></Where><OrderBy><FieldRef Name='taskorder'/></OrderBy>";

            SPListItemCollection lic = oList.GetItems(query);

            Hashtable arrFields = new Hashtable();
            arrFields.Add("ID", null);

            foreach (SPField field in oList.Fields)
            {
                if (field.Type == SPFieldType.User)
                    hshUserFields.Add(field.InternalName + "ID", field.InternalName);

                if (!field.Hidden && isValidField(field.InternalName, false) && field.Reorderable)
                    arrFields.Add(field.InternalName, field);
            }

            doc.FirstChild.AppendChild(ndBody1);

            SPList list = oWeb.Lists.TryGetList(sListTaskCenter);

            foreach (DictionaryEntry de in arrFields)
            {
                if (de.Key.ToString() != "Title" && de.Key.ToString() != "ID")
                {
                    XmlNode ndCol = doc.CreateNode(XmlNodeType.Element, "C", doc.NamespaceURI);
                    attr = doc.CreateAttribute("Name");
                    attr.Value = de.Key.ToString();
                    ndCol.Attributes.Append(attr);
                    attr = doc.CreateAttribute("Visible");
                    attr.Value = "0";
                    ndCol.Attributes.Append(attr);
                    doc.FirstChild.SelectSingleNode("//LeftCols").AppendChild(ndCol);

                }
            }

            DataTable dtResources = EPMLiveCore.API.APITeam.GetResourcePool("<Data><Columns></Columns></Data>", oWeb);

            foreach (SPListItem li in lic)
            {
                XmlNode ndI = doc.CreateNode(XmlNodeType.Element, "I", doc.NamespaceURI);

                attr = doc.CreateAttribute("Def");
                attr.Value = "Task";
                ndI.Attributes.Append(attr);

                foreach (DictionaryEntry de in arrFields)
                {
                    string col = de.Key.ToString();
                    SPField field = null;
                    try
                    {
                        field = (SPField)de.Value;
                    }
                    catch { }
                    if (col == "ID")
                    {
                        attr = doc.CreateAttribute("id");
                        try
                        {
                            attr.Value = li["taskuid"].ToString();
                        }
                        catch { }
                        ndI.Attributes.Append(attr);
                    }
                    else
                    {
                        if (hshUserFields.Contains(col))
                        {
                            string newusers = "";

                            try
                            {
                                SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(oWeb, li[col].ToString());

                                foreach (SPFieldUserValue uv in uvc)
                                {

                                    DataRow[] drRes = dtResources.Select("SPID='" + uv.LookupId + "'");

                                    if (drRes.Length > 0)
                                        newusers += ";" + drRes[0]["ID"].ToString();

                                }
                            }
                            catch { }

                            attr = doc.CreateAttribute(hshUserFields[col].ToString());
                            attr.Value = newusers.Trim(';');
                            ndI.Attributes.Append(attr);
                        }
                        else
                        {
                            attr = doc.CreateAttribute(col);

                            switch (field.Type)
                            {
                                case SPFieldType.Boolean:
                                    try
                                    {
                                        if (li[col].ToString() == "True")
                                            attr.Value = "1";
                                        else
                                            attr.Value = "0";
                                    }
                                    catch { }
                                    break;
                                case SPFieldType.Number:
                                    SPFieldNumber num = (SPFieldNumber)field;
                                    if (num.ShowAsPercentage)
                                    {
                                        try
                                        {
                                            attr.Value = (float.Parse(li[col].ToString()) * 100).ToString();
                                        }
                                        catch { }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            attr.Value = li[col].ToString();
                                        }
                                        catch { }

                                    }
                                    break;
                                default:
                                    try
                                    {
                                        attr.Value = li[col].ToString();
                                    }
                                    catch { }
                                    break;
                            }


                            ndI.Attributes.Append(attr);
                        }
                    }
                }

                try
                {
                    string WBS = ndI.Attributes["WBS"].Value;

                    if (WBS.Contains("."))
                    {
                        WBS = WBS.Substring(0, WBS.LastIndexOf('.'));

                        XmlNode ndParent = ndBody.SelectSingleNode("//I[@WBS='" + WBS + "']");

                        if (ndParent != null)
                        {
                            ndParent.AppendChild(ndI);
                            ndParent.Attributes["Def"].Value = "Summary";
                        }
                        else
                            ndBody.AppendChild(ndI);
                    }
                    else
                        ndBody.AppendChild(ndI);
                }
                catch { ndBody.AppendChild(ndI); }


            }

            return doc.OuterXml;
        }

        public static string GetExternalProjects(XmlDocument data, SPWeb oWeb)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.txtExternalProjects);

            string sListProjectCenter = "";

            string PlannerID = getAttribute(data.FirstChild, "PlannerID");

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                using (SPSite site = new SPSite(oWeb.Site.ID))
                {
                    using (SPWeb iweb = site.OpenWeb(oWeb.ID))
                    {
                        Guid lockWeb = EPMLiveCore.CoreFunctions.getLockedWeb(iweb);
                        if (lockWeb == Guid.Empty || lockWeb == oWeb.ID)
                        {
                            sListProjectCenter = EPMLiveCore.CoreFunctions.getConfigSetting(oWeb, "EPMLivePlanner" + PlannerID + "ProjectCenter");
                        }
                        else
                        {
                            using (SPWeb w = site.OpenWeb(lockWeb))
                            {
                                sListProjectCenter = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePlanner" + PlannerID + "ProjectCenter");
                            }

                        }
                    }
                }
            });

            SPList oProjectCenter = oWeb.Lists.TryGetList(sListProjectCenter);

            SPField title = oProjectCenter.Fields.GetFieldByInternalName("Title");

            doc.FirstChild.SelectSingleNode("//Header").Attributes["Title"].Value = title.Title;

            string orderby = "";
            string query = EPMLiveCore.ReportingData.GetReportQuery(oWeb, oProjectCenter, "<OrderBy><FieldRef Name='Title'/></OrderBy>", out orderby);
            DataTable dtProjects = EPMLiveCore.ReportingData.GetReportingData(oWeb, oProjectCenter.Title, false, query, orderby);

            XmlNode ndBody = doc.FirstChild.SelectSingleNode("//Body/B");

            foreach (DataRow dr in dtProjects.Rows)
            {
                XmlNode ndI = doc.CreateNode(XmlNodeType.Element, "I", doc.NamespaceURI);

                XmlAttribute attr = doc.CreateAttribute("Title");
                attr.Value = dr["Title"].ToString();
                ndI.Attributes.Append(attr);

                attr = doc.CreateAttribute("Start");
                try
                {
                    attr.Value = DateTime.Parse(dr["Start"].ToString()).ToShortDateString();
                }
                catch { }
                ndI.Attributes.Append(attr);

                attr = doc.CreateAttribute("Finish");
                try
                {
                    attr.Value = DateTime.Parse(dr["Finish"].ToString()).ToShortDateString();
                }
                catch { }
                ndI.Attributes.Append(attr);


                attr = doc.CreateAttribute("id");
                attr.Value = dr["ID"].ToString();
                ndI.Attributes.Append(attr);

                ndBody.AppendChild(ndI);
            }

            return doc.OuterXml;
        }

        public static string ImportTasks(XmlDocument data, SPWeb oWeb)
        {
            XmlDocument docRet = new XmlDocument();
            docRet.LoadXml("<Import Status=\"0\"/>");
            //Props
            string sStructure = "WBS";
            string sUID = "";
            bool bAllowDuplicates = false;
            string sPlanner = "";
            string sID = "";
            string sResField = "SPID";

            try
            {
                sStructure = data.FirstChild.Attributes["Structure"].Value;
            }
            catch { }
            try
            {
                sResField = data.FirstChild.Attributes["ResourceField"].Value;
            }
            catch { }
            try
            {
                sUID = data.FirstChild.Attributes["UIDColumn"].Value;
            }
            catch { }
            try
            {
                bAllowDuplicates = bool.Parse(data.FirstChild.Attributes["AllowDuplicateRows"].Value);
            }
            catch { }
            try
            {
                sPlanner = data.FirstChild.Attributes["Planner"].Value;
            }
            catch { }
            try
            {
                sID = data.FirstChild.Attributes["ID"].Value;
            }
            catch { }

            if (sUID == "" && !bAllowDuplicates)
            {
                return "<Result Status=\"1\"><Error ID=\"7001\">UID Column not specified and allow duplicated is on. You must either specify UID column or you must allow duplicates.</Error></Result>";
            }
            else if (sID == "")
            {
                return "<Result Status=\"1\"><Error ID=\"7002\">ID Not Specified</Error></Result>";
            }
            else if (sPlanner == "")
            {
                return "<Result Status=\"1\"><Error ID=\"7003\">Planner Not Specified</Error></Result>";
            }
            else
            {

                if (sStructure != "Tree")
                    ImportTasksFixXmlStructure(ref data, sUID, sStructure);

                XmlDocument docPlanInfo = new XmlDocument();
                docPlanInfo.LoadXml("<GetTasks Planner=\"" + sPlanner + "\" ID=\"" + sID + "\" View=\"\"/>");

                XmlDocument docPlan = new XmlDocument();
                docPlan.LoadXml(GetTasks(docPlanInfo, oWeb));

                XmlDocument docLayout = new XmlDocument();
                docLayout.LoadXml(iGetGeneralLayout(oWeb, Properties.Resources.txtDefaultConfig, docPlanInfo, false));

                ArrayList arrCols = new ArrayList();
                foreach (XmlNode ndCol in docLayout.FirstChild.SelectSingleNode("//LeftCols").SelectNodes("C"))
                {
                    string sName = getAttribute(ndCol, "Name");
                    if (sName != "")
                    {
                        if (!arrCols.Contains(sName))
                        {
                            if (!bSpecialColumn(sName) && sName != sStructure)
                            {
                                arrCols.Add(sName);
                            }
                        }
                    }
                }

                foreach (XmlNode ndCol in docLayout.FirstChild.SelectSingleNode("//Cols").SelectNodes("C"))
                {
                    string sName = getAttribute(ndCol, "Name");
                    if (sName != "")
                    {
                        if (!arrCols.Contains(sName))
                        {
                            if (!bSpecialColumn(sName) && sName != sStructure)
                            {
                                arrCols.Add(sName);
                            }
                        }
                    }
                }

                int curtaskuid = 1;

                foreach (XmlNode ndT in docPlan.SelectNodes("//I"))
                {
                    int ntid = 0;
                    int.TryParse(getAttribute(ndT, "id"), out ntid);
                    if (ntid > curtaskuid)
                        curtaskuid = ntid;
                }

                PlannerProps props = getSettings(oWeb, sPlanner);

                SPList oProjectList = oWeb.Lists.TryGetList(props.sListProjectCenter);

                DataSet dsResources = GetResourceTable(props, oProjectList.ID, sID, oWeb);

                foreach (XmlNode ndImportTask in data.FirstChild.ChildNodes)
                {
                    if (ndImportTask.Name == "Item")
                    {
                        processTasks(ndImportTask, ref docRet, docPlan.FirstChild.SelectSingleNode("//I[@id='0']"), docPlan, sUID, arrCols, bAllowDuplicates, ref curtaskuid, sResField, dsResources);
                    }
                }

                try
                {
                    XmlAttribute attr = docPlan.CreateAttribute("Planner");
                    attr.Value = sPlanner;
                    docPlan.FirstChild.Attributes.Append(attr);

                    attr = docPlan.CreateAttribute("ID");
                    attr.Value = sID;
                    docPlan.FirstChild.Attributes.Append(attr);

                    SaveWorkPlan(docPlan, oWeb);

                    XmlNode ndNewRet = docRet.CreateNode(XmlNodeType.Element, "SavePlan", docRet.NamespaceURI);

                    attr = docRet.CreateAttribute("Status");
                    attr.Value = "0";
                    ndNewRet.Attributes.Append(attr);

                    docRet.FirstChild.AppendChild(ndNewRet);
                }
                catch (Exception ex)
                {
                    XmlNode ndNewRet = docRet.CreateNode(XmlNodeType.Element, "SavePlan", docRet.NamespaceURI);

                    XmlAttribute attr = docRet.CreateAttribute("Status");
                    attr.Value = "1";
                    ndNewRet.Attributes.Append(attr);

                    ndNewRet.InnerXml = "<Error ID=\"7010\">" + ex.Message + "</Error>";

                    docRet.FirstChild.AppendChild(ndNewRet);

                    docRet.FirstChild.Attributes["Status"].Value = "1";
                }

                if (docRet.SelectSingleNode("//Item[@Status='1']") != null)
                {
                    docRet.FirstChild.Attributes["Status"].Value = "1";
                }
            }

            return docRet.OuterXml;
        }

        private static void processTasks(XmlNode ndImportTask, ref XmlDocument docRet, XmlNode ndParent, XmlDocument docPlan, string sUID, ArrayList arrCols, bool bAllowDuplicates, ref int curtaskuid, string sResField, DataSet dsResources)
        {
            string extid = getAttribute(ndImportTask, sUID);

            if (extid == "" && sUID != "")
                return;

            XmlNode ndCurNode = docPlan.SelectSingleNode("//I[@EXTID='" + extid + "']");

            if (ndCurNode == null || bAllowDuplicates)
            {
                try
                {
                    curtaskuid++;

                    XmlNode ndNew = docPlan.CreateNode(XmlNodeType.Element, "I", docPlan.NamespaceURI);

                    XmlAttribute attr = docPlan.CreateAttribute("EXTID");
                    attr.Value = extid;
                    ndNew.Attributes.Append(attr);

                    attr = docPlan.CreateAttribute("Def");
                    attr.Value = "Task";
                    ndNew.Attributes.Append(attr);

                    attr = docPlan.CreateAttribute("id");
                    attr.Value = curtaskuid.ToString(); ;
                    ndNew.Attributes.Append(attr);

                    foreach (string sCol in arrCols)
                    {
                        attr = docPlan.CreateAttribute(sCol);
                        attr.Value = getAttribute(ndImportTask, sCol);
                        ndNew.Attributes.Append(attr);
                    }

                    ndParent.AppendChild(ndNew);

                    if (ndParent.Attributes["id"].Value != "0")
                        ndParent.Attributes["Def"].Value = "Summary";

                    string assn = "";

                    try
                    {
                        assn = ndNew.Attributes["AssignedTo"].Value;
                    }
                    catch { }
                    if (assn != "")
                    {
                        string resNames = "";

                        string[] sAssns = assn.Split(';');

                        foreach (string sAssn in sAssns)
                        {
                            DataRow[] dr = dsResources.Tables[2].Select(sResField + " = '" + sAssn + "'");
                            if (dr.Length > 0)
                            {
                                resNames += "," + dr[0]["Title"].ToString();

                                XmlNode ndAssnNew = ndNew.CloneNode(false);
                                ndAssnNew.Attributes["Def"].Value = "Assignment";

                                ndAssnNew.Attributes["Title"].Value = dr[0]["Title"].ToString();
                                ndAssnNew.Attributes["id"].Value = ndAssnNew.Attributes["id"].Value + "." + dr[0]["SPID"].ToString();

                                if (ndAssnNew.Attributes["ResourceNames"] == null)
                                {
                                    attr = docPlan.CreateAttribute("ResourceNames");
                                    attr.Value = dr[0]["Title"].ToString();
                                    ndAssnNew.Attributes.Append(attr);
                                }
                                else
                                {
                                    ndAssnNew.Attributes["ResourceNames"].Value = dr[0]["Title"].ToString();
                                }

                                ndNew.AppendChild(ndAssnNew);
                            }
                        }

                        resNames = resNames.Trim(',');

                        if (ndNew.Attributes["ResourceNames"] == null)
                        {
                            attr = docPlan.CreateAttribute("ResourceNames");
                            attr.Value = resNames;
                            ndNew.Attributes.Append(attr);
                        }
                        else
                        {
                            ndNew.Attributes["ResourceNames"].Value = resNames;
                        }
                    }
                    //TODO: Process Assignments

                    foreach (XmlNode ndChildImportTask in ndImportTask.ChildNodes)
                    {
                        if (ndImportTask.Name == "Item")
                        {
                            processTasks(ndChildImportTask, ref docRet, ndNew, docPlan, sUID, arrCols, bAllowDuplicates, ref curtaskuid, sResField, dsResources);
                        }
                    }

                    XmlNode ndNewRet = docRet.CreateNode(XmlNodeType.Element, "Item", docRet.NamespaceURI);

                    attr = docRet.CreateAttribute("ID");
                    attr.Value = extid;
                    ndNewRet.Attributes.Append(attr);

                    attr = docRet.CreateAttribute("Status");
                    attr.Value = "0";
                    ndNewRet.Attributes.Append(attr);

                    docRet.FirstChild.AppendChild(ndNewRet);
                }
                catch (Exception ex)
                {
                    XmlNode ndNewRet = docRet.CreateNode(XmlNodeType.Element, "Item", docRet.NamespaceURI);

                    XmlAttribute attr = docRet.CreateAttribute("ID");
                    attr.Value = extid;
                    ndNewRet.Attributes.Append(attr);

                    attr = docRet.CreateAttribute("Status");
                    attr.Value = "1";
                    ndNewRet.Attributes.Append(attr);

                    ndNewRet.InnerXml = "<Error ID=\"7009\">" + ex.Message + "</Error>";

                    docRet.FirstChild.AppendChild(ndNewRet);
                }

            }
            else
            {
                foreach (XmlNode ndChildImportTask in ndImportTask.ChildNodes)
                {
                    if (ndImportTask.Name == "Item")
                    {
                        processTasks(ndChildImportTask, ref docRet, ndCurNode, docPlan, sUID, arrCols, bAllowDuplicates, ref curtaskuid, sResField, dsResources);
                    }
                }

                XmlNode ndNewRet = docRet.CreateNode(XmlNodeType.Element, "Item", docRet.NamespaceURI);

                XmlAttribute attr = docRet.CreateAttribute("ID");
                attr.Value = extid;
                ndNewRet.Attributes.Append(attr);

                attr = docRet.CreateAttribute("Status");
                attr.Value = "0";
                ndNewRet.Attributes.Append(attr);

                ndNewRet.InnerText = "Duplicate Skipped";

                docRet.FirstChild.AppendChild(ndNewRet);
            }

        }

        private static bool bSpecialColumn(string sCol)
        {
            switch (sCol)
            {
                case "SPID":
                case "EXTID":
                case "CommentCount":
                case "USAGE":
                case "taskorder":
                case "Attachments":
                    return true;
            } return false;
        }

        private static void ImportTasksFixXmlStructure(ref XmlDocument data, string sUID, string sStructure)
        {
            XmlNodeList ndList = data.SelectNodes("//Item");
            foreach (XmlNode ndItem in ndList)
            {
                try
                {
                    string wbs = getAttribute(ndItem, sStructure);
                    if (wbs != "" && wbs.Contains("."))
                    {
                        string parentwbs = wbs.Substring(0, wbs.LastIndexOf("."));

                        XmlNode ndParent = data.SelectSingleNode("//Item[@" + sStructure + "='" + parentwbs + "']");
                        if (ndParent != null)
                        {
                            if (ndParent != ndItem.ParentNode)
                            {
                                ndParent.AppendChild(ndItem);
                            }
                        }
                    }
                }
                catch { }
            }
        }

        public static SortedList GetPlannersByProjectList(string projectList, SPWeb web)
        {
            SortedList arrPlanners = new SortedList();

            string planners = EPMLiveCore.CoreFunctions.getLockConfigSetting(web, "EPMLivePlannerPlanners", false);

            bool foundpj = false;


            bool bDisableProject = false;
            bool bDisablePlan = false;

            bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveDisablePublishing"), out bDisableProject);
            bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveDisablePlanners"), out bDisablePlan);

            foreach (string planner in planners.Split(','))
            {
                string[] sPlanner = planner.Split('|');
                if (EPMLiveCore.CoreFunctions.getLockConfigSetting(web, "EPMLivePlanner" + sPlanner[0] + "ProjectCenter", false) == projectList)
                {
                    bool canProject = false;
                    bool canOnline = false;

                    if (EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + sPlanner[0] + "EnableOnline") == "")
                        canOnline = true;
                    else
                        bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + sPlanner[0] + "EnableOnline"), out canOnline);
                    bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + sPlanner[0] + "EnableProject"), out canProject);

                    if ((!bDisablePlan && canOnline) || (!bDisableProject && canProject))
                    {

                        arrPlanners.Add(sPlanner[0], sPlanner[1]);

                        bool bFPJ = false;

                        bool.TryParse(EPMLiveCore.CoreFunctions.getLockConfigSetting(web, "EPMLivePlanner" + sPlanner[0] + "EnableProject", false), out bFPJ);

                        foundpj = foundpj | bFPJ;
                    }
                }
            }

            if (!foundpj && projectList == "Project Center")
            {

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite rsite = new SPSite(web.Site.ID))
                    {
                        using (SPWeb rweb = rsite.OpenWeb(web.ID))
                        {
                            Guid lwebGuid = EPMLiveCore.CoreFunctions.getLockedWeb(web);

                            using (SPWeb lweb = rsite.OpenWeb(lwebGuid))
                            {
                                if (lweb.Lists.TryGetList("Planner Templates") == null)
                                {
                                    arrPlanners.Add("MPP", "Microsoft Office Project");
                                }
                                else if (EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "useoldeditinproject") == "true")
                                {
                                    arrPlanners.Add("MPP", "Microsoft Office Project");
                                }
                            }
                        }
                    }

                });
            }

            return arrPlanners;
        }

        public static SortedList GetPlannersByTaskList(SPWeb web, string taskList)
        {
            SortedList arrPlanners = new SortedList();

            string planners = EPMLiveCore.CoreFunctions.getLockConfigSetting(web, "EPMLivePlannerPlanners", false);

            foreach (string planner in planners.Split(','))
            {
                string[] sPlanner = planner.Split('|');

                if (EPMLiveCore.CoreFunctions.getLockConfigSetting(web, "EPMLivePlanner" + sPlanner[0] + "TaskCenter", false) == taskList)
                {
                    arrPlanners.Add(sPlanner[0], sPlanner[1]);
                }
            }

            return arrPlanners;
        }

        public static string GetUpdateDetailLayout(XmlDocument data, SPWeb oWeb)
        {


            PlannerProps p = getSettings(oWeb, data.FirstChild.Attributes["Planner"].Value);

            XmlDocument docOut = new XmlDocument();
            docOut.LoadXml(Properties.Resources.txtUpdateDetailLayout);

            SPList list = oWeb.Lists.TryGetList(p.sListTaskCenter);

            EPMLiveCore.GridGanttSettings gSettings = new EPMLiveCore.GridGanttSettings(list);

            Dictionary<string, Dictionary<string, string>> fieldProperties = EPMLiveCore.ListDisplayUtils.ConvertFromString(gSettings.DisplaySettings);

            if (list != null)
            {
                XmlNode ndRows = docOut.SelectSingleNode("//B");

                XmlAttribute attr = docOut.CreateAttribute("N");
                attr.Value = list.Fields.GetFieldByInternalName("Title").Title;

                docOut.SelectSingleNode("//I[@id='Title']").Attributes.Append(attr);

                foreach (SPField oField in list.Fields)
                {
                    if (oField.InternalName != "Title")
                    {
                        //if(arrWPFields.Count > 0)
                        //{
                        if (p.StatusFields.Contains(oField.InternalName))
                        {
                            try
                            {
                                XmlNode ndNew = docOut.CreateNode(XmlNodeType.Element, "I", docOut.NamespaceURI);
                                attr = docOut.CreateAttribute("id");
                                attr.Value = oField.InternalName;
                                ndNew.Attributes.Append(attr);

                                attr = docOut.CreateAttribute("N");
                                attr.Value = oField.Title;
                                ndNew.Attributes.Append(attr);

                                attr = docOut.CreateAttribute("NoColorState");
                                attr.Value = "1";
                                ndNew.Attributes.Append(attr);

                                attr = docOut.CreateAttribute("CanEdit");
                                attr.Value = "0";
                                ndNew.Attributes.Append(attr);

                                attr = docOut.CreateAttribute("NoColor");
                                attr.Value = "0";
                                ndNew.Attributes.Append(attr);

                                attr = docOut.CreateAttribute("NoUpload");
                                attr.Value = "1";
                                ndNew.Attributes.Append(attr);

                                ndRows.AppendChild(ndNew);
                            }
                            catch { }
                        }
                        else if (oField.ShowInEditForm != null && oField.ShowInEditForm.Value && EPMLiveCore.EditableFieldDisplay.isEditable(list, oField, fieldProperties) && oField.Type != SPFieldType.Calculated)
                        {
                            try
                            {
                                XmlNode ndNew = docOut.CreateNode(XmlNodeType.Element, "I", docOut.NamespaceURI);
                                attr = docOut.CreateAttribute("id");
                                attr.Value = oField.InternalName;
                                ndNew.Attributes.Append(attr);

                                attr = docOut.CreateAttribute("N");
                                attr.Value = oField.Title;
                                ndNew.Attributes.Append(attr);

                                attr = docOut.CreateAttribute("NoColorState");
                                attr.Value = "1";
                                ndNew.Attributes.Append(attr);

                                attr = docOut.CreateAttribute("CanEdit");
                                attr.Value = "0";
                                ndNew.Attributes.Append(attr);

                                attr = docOut.CreateAttribute("NoColor");
                                attr.Value = "0";
                                ndNew.Attributes.Append(attr);

                                attr = docOut.CreateAttribute("NoUpload");
                                attr.Value = "1";
                                ndNew.Attributes.Append(attr);

                                ndRows.AppendChild(ndNew);
                            }
                            catch { }
                        }
                    }
                }
            }

            return docOut.OuterXml;
        }

        public static string SaveProject(XmlDocument data, SPWeb oWeb)
        {
            try
            {


                string id = data.FirstChild.Attributes["ID"].Value;
                string planner = data.FirstChild.Attributes["PlannerID"].Value;

                PlannerProps props = getSettings(oWeb, planner);

                oWeb.AllowUnsafeUpdates = true;

                SPList oProjectCenter = oWeb.Lists[props.sListProjectCenter];

                SPListItem oProject = oProjectCenter.GetItemById(int.Parse(id));

                DataSet dsResources = GetResourceTable(props, oProjectCenter.ID, data.FirstChild.Attributes["ID"].Value, oWeb);

                foreach (XmlNode nd in data.FirstChild.SelectNodes("//Field"))
                {
                    string name = nd.Attributes["Name"].Value;
                    string val = nd.InnerText;

                    SPField oField = null;
                    try
                    {
                        oField = oProjectCenter.Fields.GetFieldByInternalName(name);
                    }
                    catch { }
                    if (oField != null)
                    {
                        if (!oField.ReadOnlyField && oField.TypeAsString != "TotalRollup")
                        {
                            switch (oField.Type)
                            {
                                case SPFieldType.DateTime:
                                    if (val == "")
                                        oProject[oField.Id] = null;
                                    else
                                        oProject[oField.Id] = val;
                                    break;
                                case SPFieldType.Currency:
                                    if (val == "" || val == "NaN")
                                        oProject[oField.Id] = null;
                                    else
                                        oProject[oField.Id] = val;
                                    break;
                                case SPFieldType.Number:
                                    if (val == "" || val == "NaN")
                                        oProject[oField.Id] = null;
                                    else
                                    {
                                        if (((SPFieldNumber)oField).ShowAsPercentage)
                                        {
                                            try
                                            {
                                                oProject[oField.Id] = double.Parse(val) / 100;
                                            }
                                            catch { }
                                        }
                                        else
                                        {
                                            oProject[oField.Id] = val;
                                        }
                                    }
                                    break;
                                case SPFieldType.User:
                                    if (val != "")
                                    {
                                        string[] users = val.Split(';');
                                        string uVal = "";
                                        foreach (string user in users)
                                        {
                                            if (user != "")
                                            {
                                                DataRow[] dr = dsResources.Tables[2].Select("ID='" + user + "'");
                                                if (dr.Length > 0)
                                                    uVal += ";#" + dr[0]["SPAccountInfo"].ToString();
                                            }
                                        }
                                        if (uVal.Length > 1)
                                            uVal = uVal.Substring(2);
                                        oProject[oField.Id] = uVal;
                                    }
                                    else
                                        oProject[oField.Id] = null;
                                    break;
                                case SPFieldType.Lookup:
                                    SPFieldLookup l = (SPFieldLookup)oField;
                                    if (l.AllowMultipleValues)
                                    {
                                        if (val == "")
                                        {
                                            oProject[oField.Id] = null;
                                        }
                                        else
                                        {
                                            SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection();
                                            string[] sVals = val.Split(';');
                                            foreach (string sVal in sVals)
                                            {
                                                SPFieldLookupValue lv = new SPFieldLookupValue(sVal);
                                                lvc.Add(lv);
                                            }
                                            oProject[oField.Id] = lvc;
                                        }
                                    }
                                    else
                                        oProject[oField.Id] = val;
                                    break;
                                default:
                                    oProject[oField.Id] = val;
                                    break;
                            }

                        }
                    }
                }

                oProject.Update();

                return "<Result Status=\"0\"></Result>";
            }
            catch (Exception ex)
            {
                return "<Result Status=\"1\"><Error ID=\"1110\">Error executing function: " + ex.Message + "</Error></Result>";
            }
        }

        public static string SaveAgilePlan(XmlDocument data, SPWeb oWeb)
        {



            getSettings(oWeb, data.FirstChild.Attributes["Planner"].Value);

            string id = data.FirstChild.Attributes["ID"].Value + "Agile";
            string planner = data.FirstChild.Attributes["Planner"].Value;

            data.FirstChild.Attributes.Remove(data.FirstChild.Attributes["ID"]);
            data.FirstChild.Attributes.Remove(data.FirstChild.Attributes["Planner"]);

            //ArrayList arrNodes = new ArrayList();
            //foreach(XmlNode nd in data.FirstChild.SelectNodes("//I"))
            //{
            //    if(nd.Attributes["Def"] != null && nd.Attributes["Def"].Value == "Folder")
            //    {
            //        XmlAttribute attr = data.CreateAttribute("Detail");
            //        attr.Value = "WorkPlannerGrid";
            //        nd.Attributes.Append(attr);
            //    }
            //}

            SPDocumentLibrary lib = (SPDocumentLibrary)oWeb.Lists["Project Schedules"];
            oWeb.AllowUnsafeUpdates = true;

            SPFolder folder = oWeb.GetFolder("Project Schedules/" + planner);
            if (!folder.Exists)
                folder = oWeb.Folders["Project Schedules"].SubFolders.Add(planner);

            folder.Files.Add(id + ".xml", StrToByteArray(data.OuterXml), true);

            /*
            ArrayList arrNodes = new ArrayList();
            foreach(XmlNode nd in data.FirstChild.SelectNodes("//I"))
            {
                if(nd.Attributes["Def"] == null || nd.Attributes["Def"].Value != "Folder")
                {
                    arrNodes.Add(nd);
                }
            }

            foreach(XmlNode nd in arrNodes)
            {
                try
                {
                    nd.ParentNode.RemoveChild(nd);
                }
                catch { }
            }

            XmlNode ndNew = data.CreateNode(XmlNodeType.Element, "I", data.NamespaceURI);
            XmlAttribute attr = data.CreateAttribute("id");
            attr.Value = "0";
            ndNew.Attributes.Append(attr);

            attr = data.CreateAttribute("Title");
            attr.Value = "All Folders";
            ndNew.Attributes.Append(attr);

            attr = data.CreateAttribute("Def");
            attr.Value = "Folder";
            ndNew.Attributes.Append(attr);


            XmlNode ndMain = data.FirstChild.FirstChild.FirstChild.FirstChild;

            if(ndMain != null)
            {
                data.FirstChild.FirstChild.FirstChild.InsertBefore(ndNew, ndMain);

                while(data.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling != null)
                {
                    ndNew.AppendChild(ndNew.NextSibling);
                }
            }
            else
            {
                data.FirstChild.FirstChild.FirstChild.AppendChild(ndNew);
            }
            lib.RootFolder.Files.Add(id + "f.xml", StrToByteArray(data.OuterXml), true);
            */
            return "<Grid><IO Result='0'/></Grid>";
        }

        public static string SaveWorkPlan(XmlDocument data, SPWeb oWeb)
        {



            getSettings(oWeb, data.FirstChild.Attributes["Planner"].Value);

            string id = data.FirstChild.Attributes["ID"].Value;
            string planner = data.FirstChild.Attributes["Planner"].Value;

            data.FirstChild.Attributes.Remove(data.FirstChild.Attributes["ID"]);
            data.FirstChild.Attributes.Remove(data.FirstChild.Attributes["Planner"]);

            ArrayList arrNodes = new ArrayList();
            foreach (XmlNode nd in data.FirstChild.SelectNodes("//I"))
            {
                if (nd.Attributes["Def"] != null && nd.Attributes["Def"].Value == "Folder")
                {
                    XmlAttribute attr = data.CreateAttribute("Detail");
                    attr.Value = "WorkPlannerGrid";
                    nd.Attributes.Append(attr);
                }

                if (nd.Attributes["id"] != null && nd.Attributes["id"].Value == "BacklogRow")
                {
                    XmlAttribute attr = data.CreateAttribute("Detail");
                    attr.Value = "AgileGrid";
                    nd.Attributes.Append(attr);
                }
            }

            SPDocumentLibrary lib = (SPDocumentLibrary)oWeb.Lists["Project Schedules"];
            oWeb.AllowUnsafeUpdates = true;

            SPFolder folder = oWeb.GetFolder("Project Schedules/" + planner);
            if (!folder.Exists)
                folder = oWeb.Folders["Project Schedules"].SubFolders.Add(planner);

            folder.Files.Add(id + ".xml", StrToByteArray(data.OuterXml), true);

            /*
            ArrayList arrNodes = new ArrayList();
            foreach(XmlNode nd in data.FirstChild.SelectNodes("//I"))
            {
                if(nd.Attributes["Def"] == null || nd.Attributes["Def"].Value != "Folder")
                {
                    arrNodes.Add(nd);
                }
            }

            foreach(XmlNode nd in arrNodes)
            {
                try
                {
                    nd.ParentNode.RemoveChild(nd);
                }
                catch { }
            }

            XmlNode ndNew = data.CreateNode(XmlNodeType.Element, "I", data.NamespaceURI);
            XmlAttribute attr = data.CreateAttribute("id");
            attr.Value = "0";
            ndNew.Attributes.Append(attr);

            attr = data.CreateAttribute("Title");
            attr.Value = "All Folders";
            ndNew.Attributes.Append(attr);

            attr = data.CreateAttribute("Def");
            attr.Value = "Folder";
            ndNew.Attributes.Append(attr);


            XmlNode ndMain = data.FirstChild.FirstChild.FirstChild.FirstChild;

            if(ndMain != null)
            {
                data.FirstChild.FirstChild.FirstChild.InsertBefore(ndNew, ndMain);

                while(data.FirstChild.FirstChild.FirstChild.FirstChild.NextSibling != null)
                {
                    ndNew.AppendChild(ndNew.NextSibling);
                }
            }
            else
            {
                data.FirstChild.FirstChild.FirstChild.AppendChild(ndNew);
            }
            lib.RootFolder.Files.Add(id + "f.xml", StrToByteArray(data.OuterXml), true);
            */
            return "<Grid><IO Result='0'/></Grid>";
        }

        public static byte[] StrToByteArray(string str)
        {
            return Encoding.GetEncoding("iso-8859-1").GetBytes(str);
            //System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            //return encoding.GetBytes(str);
        }

        public static void UpgradeProjectScheduleLibrary(SPWeb web, string id, string planner, SPFile oFile)
        {
            SPFolder folder = web.GetFolder("Project Schedules/" + planner);
            if (!folder.Exists)
                folder = web.Folders["Project Schedules"].SubFolders.Add(planner);
            web.AllowUnsafeUpdates = true;
            folder.Files.Add(id + ".xml", oFile.OpenBinaryStream());

            oFile.Delete();

        }

        private static void iApplyNewTemplate(SPWeb web, SPWeb lWeb, string planner, string templateid, string itemid, string type, string projectname)
        {

            SPList lib = lWeb.Lists["Planner Templates"];
            SPListItem li = null;

            if (templateid == "")
            {
                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='Title'><Value Type='Text'>Default</Value></Eq></Where>";

                SPListItemCollection lic = lib.GetItems(query);
                if (lic.Count > 0)
                {
                    iApplyNewTemplate(web, lWeb, planner, lic[0].ID.ToString(), itemid, type, projectname);
                }
                else
                    return;
            }
            else
            {
                li = lib.GetItemById(int.Parse(templateid));
            }

            SPFile file = li.File;
            web.AllowUnsafeUpdates = true;
            SPFolder folder = web.GetFolder("Project Schedules/" + planner);
            if (!folder.Exists)
                folder = web.Folders["Project Schedules"].SubFolders.Add(planner);

            string ext = Path.GetExtension(file.Name);
            if (ext == ".mpp")
                folder.Files.Add(projectname + ext, file.OpenBinaryStream());
            else
                folder.Files.Add(itemid + ext, file.OpenBinaryStream());


        }

        public static void ApplyNewTemplate(SPWeb web, string planner, string templateid, string itemid, string type, string projectname)
        {

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(web.Site.ID))
                {
                    using (SPWeb iweb = site.OpenWeb(web.ID))
                    {
                        Guid lockWeb = EPMLiveCore.CoreFunctions.getLockedWeb(iweb);
                        if (lockWeb == Guid.Empty || lockWeb == web.ID)
                        {
                            iApplyNewTemplate(web, web, planner, templateid, itemid, type, projectname);
                        }
                        else
                        {
                            using (SPWeb w = site.OpenWeb(lockWeb))
                            {
                                iApplyNewTemplate(web, w, planner, templateid, itemid, type, projectname);
                            }

                        }
                    }
                }
            });

        }

        private static string getLIField(SPListItem li, string Field)
        {
            try
            {
                return li[Field].ToString();
            }
            catch { }
            return "";
        }

        private static DataTable iGetTemplates(SPWeb web, string planner, string type)
        {


            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Title");
            dt.Columns.Add("Description");
            dt.Columns.Add("Icon");

            try
            {
                SPDocumentLibrary lib = (SPDocumentLibrary)web.Lists["Planner Templates"];

                SPQuery query = new SPQuery();
                query.Folder = lib.RootFolder;
                SPListItemCollection lic = lib.GetItems(query);

                foreach (SPListItem li in lic)
                {
                    if (li.File != null)
                    {
                        SPFile oFile = li.File;
                        if (Path.GetExtension(oFile.Name) == ".xml" && type == "Online")
                        {
                            dt.Rows.Add(new string[] { li.ID.ToString(), li.Title, getLIField(li, "Description") });
                        }

                        if (Path.GetExtension(oFile.Name) == ".mpp" && type == "Project")
                        {
                            dt.Rows.Add(new string[] { li.ID.ToString(), li.Title, getLIField(li, "Description") });
                        }
                    }
                }

                SPFolder folder = lib.RootFolder.SubFolders[planner];

                query = new SPQuery();
                query.Folder = folder;
                lic = lib.GetItems(query);

                foreach (SPListItem li in lic)
                {
                    SPFile oFile = li.File;
                    if (Path.GetExtension(oFile.Name) == ".xml" && type == "Online")
                    {
                        dt.Rows.Add(new string[] { li.ID.ToString(), li.Title.Replace(".xml", ""), getLIField(li, "Description") });
                    }

                    if (Path.GetExtension(oFile.Name) == ".mpp" && type == "Project")
                    {
                        dt.Rows.Add(new string[] { li.ID.ToString(), li.Title.Replace(".mpp", ""), getLIField(li, "Description") });
                    }

                }
            }
            catch { }

            if (type == "Project")
                dt.Rows.Add(new string[] { "-101", "Import Project", "Select this option to upload a project file." });

            return dt;
        }

        private static string iSaveTemplate(string sPlannerId, string sTemplateName, string sDescription, XmlDocument data, SPWeb oWeb)
        {
            data.FirstChild.Attributes.RemoveAll();

            SPList oList = oWeb.Lists.TryGetList("Planner Templates");

            if (oList != null)
            {
                //SPFolder folder = oWeb.GetFolder("Planner Templates/" + sPlannerId);
                //if(!folder.Exists)
                //    folder = oWeb.Folders["Planner Templates"].SubFolders.Add(sPlannerId);
                oWeb.AllowUnsafeUpdates = true;
                SPFolder rFolder = oList.RootFolder;
                SPFolder pFolder = null;
                try
                {
                    pFolder = rFolder.SubFolders[sPlannerId];
                }
                catch { }
                if (pFolder == null)
                {
                    rFolder.SubFolders.Add(sPlannerId);
                    pFolder = rFolder.SubFolders[sPlannerId];
                }

                if (pFolder.Files.Count == 0)
                {
                    SPFile blank = pFolder.Files.Add("Blank Plan.xml", StrToByteArray("<Grid><Body><B><I Def='Folder' Title='All Folders' id='0' Detail='WorkPlannerGrid'/></B></Body></Grid>"), true);
                    try
                    {
                        SPListItem li = blank.GetListItem();
                        li["Description"] = "Create a blank plan.";
                        li.Update();
                    }
                    catch { }

                }

                SPFile file = pFolder.Files.Add(sTemplateName + ".xml", StrToByteArray(data.OuterXml), true);

                try
                {
                    SPListItem li = file.GetListItem();
                    li["Description"] = sDescription;
                    li.Update();
                }
                catch { }

                return "<Result Status=\"0\"></Result>";
            }
            else
            {
                return "<Result Status=\"1\"><Error ID=\"6701\">Planner Templates Library Missing</Error></Result>";
            }
        }

        public static string SaveTemplate(XmlDocument data, SPWeb oWeb)
        {
            try
            {
                string sPlannerId = getAttribute(data.FirstChild, "Planner");
                string sTemplateName = getAttribute(data.FirstChild, "TemplateName");
                string sDescription = getAttribute(data.FirstChild, "Description");



                if (sPlannerId != "")
                {
                    if (sTemplateName != "")
                    {
                        Guid gLweb = EPMLiveCore.CoreFunctions.getLockedWeb(oWeb);

                        if (gLweb == oWeb.ID)
                        {
                            return iSaveTemplate(sPlannerId, sTemplateName, sDescription, data, oWeb);
                        }
                        else
                        {
                            string ret = "";
                            using (SPWeb tWeb = oWeb.Site.OpenWeb(gLweb))
                            {
                                ret = iSaveTemplate(sPlannerId, sTemplateName, sDescription, data, tWeb);
                            }

                            return ret;
                        }
                    }
                    else
                    {
                        return "<Result Status=\"1\"><Error ID=\"6702\">Template Name Not Specified</Error></Result>";
                    }
                }
                else
                {
                    return "<Result Status=\"1\"><Error ID=\"6700\">Planner Not Specified</Error></Result>";
                }
            }
            catch (Exception ex)
            {
                return "<Result Status=\"1\"><Error ID=\"6799\">" + ex.Message + "</Error></Result>";
            }
        }

        public static DataTable GetTemplates(SPWeb web, string planner, string type)
        {
            DataTable dt = null;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(web.Site.ID))
                {
                    using (SPWeb iweb = site.OpenWeb(web.ID))
                    {
                        Guid lockWeb = EPMLiveCore.CoreFunctions.getLockedWeb(iweb);
                        if (lockWeb == Guid.Empty || lockWeb == web.ID)
                        {
                            dt = iGetTemplates(web, planner, type);
                        }
                        else
                        {
                            using (SPWeb w = site.OpenWeb(lockWeb))
                            {
                                dt = iGetTemplates(w, planner, type);
                            }

                        }
                    }
                }
            });

            return dt;
        }

        public static SPFile GetTaskFile(SPWeb web, string id, string planner)
        {
            SPDocumentLibrary lib = (SPDocumentLibrary)web.Lists["Project Schedules"];

            try
            {
                SPFile file = lib.RootFolder.Files[id + "_" + planner + ".xml"];

                if (file.Exists)
                {
                    UpgradeProjectScheduleLibrary(web, id, planner, file);
                }


            }
            catch { }

            try
            {
                return web.GetFile("Project Schedules/" + planner + "/" + id + ".xml");
            }
            catch { }
            return null;
        }

        private static string ProcessTaskXmlFromTaskCenter(XmlDocument doc, PlannerProps props, SPWeb web, string projectid, out int lastid)
        {
            lastid = 0;

            SPList list = web.Lists.TryGetList(props.sListTaskCenter);
            if (list != null)
            {
                try
                {
                    SPQuery query = new SPQuery();
                    query.Query = "<Where><Eq><FieldRef Name='Project' LookupId='TRUE'/><Value Type='Lookup'>" + projectid + "</Value></Eq></Where>";
                    query.ViewFields = "<FieldRef Name='taskuid'/><FieldRef Name='CommentCount'/><FieldRef Name='Attachments'/>";

                    DataTable dtTasks = list.GetItems(query).GetDataTable();

                    foreach (XmlNode ndTask in doc.SelectNodes("//I"))
                    {
                        string id = getAttribute(ndTask, "id");
                        DataRow[] drTask = dtTasks.Select("taskuid='" + id + "'");
                        if (drTask.Length > 0)
                        {
                            XmlAttribute attr = doc.CreateAttribute("CommentCount");
                            try
                            {
                                attr.Value = drTask[0]["CommentCount"].ToString();
                            }
                            catch { }
                            ndTask.Attributes.Append(attr);

                            attr = doc.CreateAttribute("Attachments");
                            try
                            {
                                if (drTask[0]["Attachments"].ToString() == "1")
                                    attr.Value = "True";
                            }
                            catch { }
                            ndTask.Attributes.Append(attr);
                        }

                        try
                        {
                            int iid = int.Parse(id);
                            if (iid > lastid)
                                lastid = iid;
                        }
                        catch { }
                    }

                }
                catch { }
            }

            return doc.OuterXml;
        }

        public static string GetTasks(XmlDocument data, SPWeb oWeb)
        {

            PlannerProps p = getSettings(oWeb, data.FirstChild.Attributes["Planner"].Value);

            XmlDocument doc = new XmlDocument();

            doc.LoadXml("<Grid><Body><B><I Def='Folder' Title='All Folders' id='0' Detail='WorkPlannerGrid'/></B></Body></Grid>");


            try
            {
                SPFile file = GetTaskFile(oWeb, data.FirstChild.Attributes["ID"].Value, data.FirstChild.Attributes["Planner"].Value);

                StreamReader reader = new StreamReader(file.OpenBinaryStream(), Encoding.GetEncoding("iso-8859-1"));

                doc.LoadXml(reader.ReadToEnd());
            }
            catch { }

            if (p.bAgile)
            {
                SPList oProjectCenter = oWeb.Lists[p.sListProjectCenter];

                DataSet dsResources = GetResourceTable(p, oProjectCenter.ID, data.FirstChild.Attributes["ID"].Value, oWeb);

                string xml = AppendNewAgileTasks(oWeb, p, doc, data.FirstChild.Attributes["ID"].Value, dsResources);

                XmlDocument docNew = new XmlDocument();
                docNew.LoadXml(xml);


                XmlAttribute attr = docNew.CreateAttribute("Planner");
                attr.Value = data.FirstChild.Attributes["Planner"].Value;
                docNew.FirstChild.Attributes.Append(attr);

                attr = docNew.CreateAttribute("ID");
                attr.Value = data.FirstChild.Attributes["ID"].Value;
                docNew.FirstChild.Attributes.Append(attr);

                SaveWorkPlan(docNew, oWeb);

                return xml;
            }
            else
            {

                int lastid = 0;

                ProcessTaskXmlFromTaskCenter(doc, p, oWeb, data.FirstChild.Attributes["ID"].Value, out lastid);

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(oWeb.Site.WebApplication.Id));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM PLANNERLINK where PlannerID=@plannerid and SourceProjectId=@projectid", cn);
                    cmd.Parameters.AddWithValue("@plannerid", data.FirstChild.Attributes["Planner"].Value);
                    cmd.Parameters.AddWithValue("@projectid", data.FirstChild.Attributes["ID"].Value);

                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string taskupdates = "";

                        SPList oProjectCenter = oWeb.Lists.TryGetList(p.sListProjectCenter);
                        SPList oListTaskCenter = oWeb.Lists.TryGetList(p.sListTaskCenter);

                        DataSet dsResources = GetResourceTable(p, oProjectCenter.ID, data.FirstChild.Attributes["ID"].Value, oWeb);

                        if (oListTaskCenter != null)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                bool bLinked = false;
                                try
                                {
                                    bLinked = bool.Parse(dr["Linked"].ToString());
                                }
                                catch { }
                                XmlNode ndTsk = doc.SelectSingleNode("//I[@id='" + dr["SourceTaskId"].ToString() + "']");
                                if (ndTsk != null)
                                {
                                    ArrayList arrP = new ArrayList(ndTsk.Attributes["Predecessors"].Value.Split(';'));
                                    ArrayList arrD = new ArrayList(ndTsk.Attributes["Descendants"].Value.Split(';'));

                                    string spredsucc = dr["Predecessors"].ToString();
                                    string[] predsuccs = spredsucc.Split(',');
                                    foreach (string predsucc in predsuccs)
                                    {
                                        string add = ProcessExternal(doc, oListTaskCenter, predsucc, dr["DestProjectId"].ToString(), data.FirstChild.Attributes["Planner"].Value, true, dsResources, ndTsk, bLinked, "", ref lastid);
                                        if (add != "")
                                        {
                                            if (!arrP.Contains(add.Substring(3)))
                                                arrP.Add(add.Substring(3));
                                            //ndTsk.Attributes["Predecessors"].Value += ";" + add.Substring(3);
                                            //ndTsk.Attributes["Predecessors"].Value = ndTsk.Attributes["Predecessors"].Value.Trim(';');
                                            taskupdates += add;
                                        }
                                    }

                                    spredsucc = dr["Successors"].ToString();
                                    predsuccs = spredsucc.Split(',');
                                    foreach (string predsucc in predsuccs)
                                    {
                                        string add = ProcessExternal(doc, oListTaskCenter, predsucc, dr["DestProjectId"].ToString(), data.FirstChild.Attributes["Planner"].Value, false, dsResources, ndTsk, bLinked, "", ref lastid);
                                        if (add != "")
                                        {
                                            if (!arrD.Contains(add.Substring(3)))
                                                arrD.Add(add.Substring(3));
                                            taskupdates += add;
                                        }

                                    }

                                    taskupdates += ProcessExternal(doc, oListTaskCenter, dr["DestTaskId"].ToString(), dr["DestProjectId"].ToString(), data.FirstChild.Attributes["Planner"].Value, false, dsResources, ndTsk, false, dr["SourceTaskId"].ToString(), ref lastid);

                                    ndTsk.Attributes["Predecessors"].Value = String.Join(";", (string[])arrP.ToArray(typeof(string)));
                                    ndTsk.Attributes["Descendants"].Value = String.Join(";", (string[])arrD.ToArray(typeof(string)));
                                }
                            }
                        }
                        cn.Close();

                        if (taskupdates != "")
                            AddCustomFooter(doc, "ExternalTasks", taskupdates.Trim(','));
                    }
                });


                return doc.OuterXml;
            }

        }

        private static string ProcessExternal(XmlDocument doc, SPList oListTaskCenter, string predsucc, string projectid, string plannerid, bool before, DataSet dsResources, XmlNode ndTaskLinkedTO, bool bLinked, string curtaskid, ref int lastid)
        {
            string ret = "";

            if (!string.IsNullOrEmpty(predsucc))
            {
                string sLinked = plannerid + "." + projectid + "." + predsucc;

                XmlNode ndTsk = null;

                if (curtaskid != "")
                    ndTsk = doc.SelectSingleNode("//I[@id='" + curtaskid + "']");
                else
                    ndTsk = doc.SelectSingleNode("//I[@ExternalLink='" + sLinked + "']");

                SPQuery query = new SPQuery();
                query.Query = "<Where><And><Eq><FieldRef Name='Project' LookupId='TRUE'/><Value Type='Lookup'>" + projectid + "</Value></Eq><Eq><FieldRef Name='taskuid'/><Value Type='Text'>" + predsucc + "</Value></Eq></And></Where>";

                SPListItemCollection lic = oListTaskCenter.GetItems(query);

                if (lic.Count > 0)
                {
                    if (ndTsk == null)
                    {
                        if (bLinked)
                        {
                            XmlAttribute attr;

                            XmlNode ndNewTask = doc.CreateNode(XmlNodeType.Element, "I", doc.NamespaceURI);

                            attr = doc.CreateAttribute("Def");
                            attr.Value = "External";
                            ndNewTask.Attributes.Append(attr);

                            lastid++;

                            attr = doc.CreateAttribute("id");
                            attr.Value = lastid.ToString();
                            ndNewTask.Attributes.Append(attr);

                            foreach (SPField oTempField in oListTaskCenter.Fields)
                            {
                                SPField oField = getRealField(oTempField);

                                if (!oField.Hidden && isValidField(oField.InternalName, false) && oField.Reorderable && !bIsSpecialExternalField(oField.InternalName))
                                {
                                    var val = getFieldValue(lic[0], oField, dsResources);

                                    if (oField.Type == SPFieldType.DateTime)
                                    {
                                        if (val != "")
                                        {
                                            attr = doc.CreateAttribute(oField.InternalName);
                                            attr.Value = val;
                                            ndNewTask.Attributes.Append(attr);
                                        }
                                    }
                                    else
                                    {
                                        attr = doc.CreateAttribute(oField.InternalName);
                                        attr.Value = val;
                                        ndNewTask.Attributes.Append(attr);
                                    }

                                }
                            }

                            attr = doc.CreateAttribute("ExternalLink");
                            attr.Value = sLinked;
                            ndNewTask.Attributes.Append(attr);

                            attr = doc.CreateAttribute("IsExternal");
                            attr.Value = "1";
                            ndNewTask.Attributes.Append(attr);

                            attr = doc.CreateAttribute("LinkedTask");
                            attr.Value = "0";
                            ndNewTask.Attributes.Append(attr);


                            //attr = doc.CreateAttribute("MinStart");
                            //attr.Value = ndNewTask.Attributes["StartDate"].Value;
                            //ndNewTask.Attributes.Append(attr);

                            //attr = doc.CreateAttribute("MaxEnd");
                            //attr.Value = ndNewTask.Attributes["DueDate"].Value;
                            //ndNewTask.Attributes.Append(attr);

                            if (before)
                                ndTaskLinkedTO.ParentNode.InsertBefore(ndNewTask, ndTaskLinkedTO);
                            else
                                ndTaskLinkedTO.ParentNode.InsertAfter(ndNewTask, ndTaskLinkedTO);

                            ret = ",A:" + lastid;
                        }
                    }
                    else
                    {


                        string SourceStart = "";
                        string SourceFinish = "";
                        string DestStart = "";
                        string DestFinish = "";

                        try
                        {
                            SourceStart = DateTime.Parse(ndTsk.Attributes["StartDate"].Value).ToString("yyyy-MM-dd");
                        }
                        catch { }
                        try
                        {
                            SourceFinish = DateTime.Parse(ndTsk.Attributes["DueDate"].Value).ToString("yyyy-MM-dd");
                        }
                        catch { }
                        try
                        {
                            DestStart = DateTime.Parse(lic[0]["StartDate"].ToString()).ToString("yyyy-MM-dd");
                        }
                        catch { }
                        try
                        {
                            DestFinish = DateTime.Parse(lic[0]["DueDate"].ToString()).ToString("yyyy-MM-dd");
                        }
                        catch { }

                        if (DestStart != SourceStart || DestFinish != SourceFinish)
                        {
                            ret = ",U:" + ndTsk.Attributes["id"].Value;

                            XmlAttribute attr = ndTsk.Attributes["OldStartDate"];
                            if (attr == null)
                            {
                                attr = doc.CreateAttribute("OldStartDate");
                                ndTsk.Attributes.Append(attr);
                            }
                            attr.Value = ndTsk.Attributes["StartDate"].Value;

                            attr = ndTsk.Attributes["OldDueDate"];
                            if (attr == null)
                            {
                                attr = doc.CreateAttribute("OldDueDate");
                                ndTsk.Attributes.Append(attr);
                            }
                            attr.Value = ndTsk.Attributes["DueDate"].Value;
                        }

                        foreach (SPField oTempField in oListTaskCenter.Fields)
                        {
                            SPField oField = getRealField(oTempField);

                            if (!oField.Hidden && isValidField(oField.InternalName, false) && oField.Reorderable && !bIsSpecialExternalField(oField.InternalName))
                            {
                                try
                                {
                                    ndTsk.Attributes[oField.InternalName].Value = getFieldValue(lic[0], oField, dsResources);
                                }
                                catch { }

                            }
                        }
                    }
                }
            }
            return ret;
        }

        private static bool bIsSpecialExternalField(string field)
        {
            switch (field)
            {
                case "IsExternal":
                case "ExternalLink":
                case "Descendants":
                case "Predecessors":
                    return true;
            }
            return false;
        }

        public static string GetExternalLinkLayout(XmlDocument data, SPWeb oWeb)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.txtExternalLinksApproval);

            return doc.OuterXml;
        }

        private static void AddCustomFooter(XmlDocument doc, string id, string title)
        {
            XmlNode ndFootRow = doc.CreateNode(XmlNodeType.Element, "I", doc.NamespaceURI);

            XmlAttribute attr = doc.CreateAttribute("id");
            attr.Value = id;
            ndFootRow.Attributes.Append(attr);

            attr = doc.CreateAttribute("Type");
            attr.Value = "Data";
            ndFootRow.Attributes.Append(attr);

            attr = doc.CreateAttribute("Visible");
            attr.Value = "0";
            ndFootRow.Attributes.Append(attr);

            attr = doc.CreateAttribute("CanEdit");
            attr.Value = "0";
            ndFootRow.Attributes.Append(attr);

            attr = doc.CreateAttribute("CanMove");
            attr.Value = "0";
            ndFootRow.Attributes.Append(attr);

            attr = doc.CreateAttribute("CanSelect");
            attr.Value = "0";
            ndFootRow.Attributes.Append(attr);

            attr = doc.CreateAttribute("Title");
            attr.Value = title;
            ndFootRow.Attributes.Append(attr);

            XmlNode ndFoot = doc.FirstChild.SelectSingleNode("//Foot");
            if (ndFoot == null)
            {
                ndFoot = doc.CreateNode(XmlNodeType.Element, "Foot", doc.NamespaceURI);
                doc.FirstChild.SelectSingleNode("//Grid").AppendChild(ndFoot);
            }

            ndFoot.AppendChild(ndFootRow);
        }

        public static string GetUpdates(XmlDocument data, SPWeb oWeb)
        {
            DataSet dsUpdates = new DataSet();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<PublishStatus ID=\"\" PlannerID=\"\" ShowResults=\"false\" UserType=\"3\" DateFormat=\"D\"/>");
            doc.FirstChild.Attributes["ID"].Value = data.FirstChild.Attributes["ID"].Value;
            doc.FirstChild.Attributes["PlannerID"].Value = data.FirstChild.Attributes["Planner"].Value;

            XmlDocument docRes = new XmlDocument();
            docRes.LoadXml(EPMLiveCore.WorkEngineAPI.GetUpdates(doc.OuterXml, oWeb));

            if (docRes.FirstChild.Attributes["Status"].Value == "0")
            {


                PlannerProps props = getSettings(oWeb, data.FirstChild.Attributes["Planner"].Value);

                SPList oTaskCenter = oWeb.Lists[props.sListTaskCenter];

                StringReader sr = new StringReader(docRes.FirstChild.InnerXml);

                dsUpdates.ReadXml(sr, XmlReadMode.Auto);

                XmlDocument docGrid = new XmlDocument();
                docGrid.LoadXml(Properties.Resources.txtUpdatesLayout);

                XmlNode ndCols = docGrid.FirstChild.SelectSingleNode("//Cols");
                XmlNode ndHeader = docGrid.FirstChild.SelectSingleNode("//Header");

                XmlNode ndNew = docGrid.CreateNode(XmlNodeType.Element, "C", docGrid.NamespaceURI);
                XmlAttribute attr = docGrid.CreateAttribute("Name");
                attr.Value = "SPID";
                ndNew.Attributes.Append(attr);

                attr = docGrid.CreateAttribute("Visible");
                attr.Value = "0";
                ndNew.Attributes.Append(attr);

                attr = docGrid.CreateAttribute("CanEdit");
                attr.Value = "0";
                ndNew.Attributes.Append(attr);

                ndCols.AppendChild(ndNew);

                if (dsUpdates.Tables.Count > 0)
                {
                    foreach (DataRow row in dsUpdates.Tables[1].Select("Task_Id=0"))
                    {
                        if (row["Name"].ToString() != "Title")
                        {
                            ndNew = docGrid.CreateNode(XmlNodeType.Element, "C", docGrid.NamespaceURI);
                            attr = docGrid.CreateAttribute("Name");
                            attr.Value = row["Name"].ToString();
                            ndNew.Attributes.Append(attr);

                            attr = docGrid.CreateAttribute("CanEdit");
                            attr.Value = "0";
                            ndNew.Attributes.Append(attr);

                            if (row["Name"].ToString() != "PercentComplete")
                            {
                                attr = docGrid.CreateAttribute("Visible");
                                attr.Value = "0";
                                ndNew.Attributes.Append(attr);
                            }

                            ndCols.AppendChild(ndNew);
                        }

                        try
                        {
                            SPField oField = oTaskCenter.Fields.GetFieldByInternalName(row["Name"].ToString());
                            attr = docGrid.CreateAttribute(row["Name"].ToString());
                            attr.Value = oField.Title;
                            ndHeader.Attributes.Append(attr);
                        }
                        catch { }
                    }

                    XmlNode ndBody = docGrid.FirstChild.SelectSingleNode("//B");

                    foreach (DataRow row in dsUpdates.Tables[0].Rows)
                    {
                        ndNew = docGrid.CreateNode(XmlNodeType.Element, "I", docGrid.NamespaceURI);

                        attr = docGrid.CreateAttribute("id");
                        attr.Value = row["uid"].ToString();
                        ndNew.Attributes.Append(attr);

                        attr = docGrid.CreateAttribute("SPID");
                        attr.Value = row["itemid"].ToString();
                        ndNew.Attributes.Append(attr);

                        //attr = docGrid.CreateAttribute("CanFocus");
                        //attr.Value = "0";
                        //ndNew.Attributes.Append(attr);                    

                        foreach (DataRow fieldrow in dsUpdates.Tables[1].Select("Task_Id=" + row["task_id"].ToString()))
                        {
                            attr = docGrid.CreateAttribute(fieldrow["name"].ToString());
                            attr.Value = getFieldValue(fieldrow["name"].ToString(), fieldrow["field_text"].ToString());
                            ndNew.Attributes.Append(attr);
                        }

                        ndBody.AppendChild(ndNew);
                    }

                }
                return docGrid.OuterXml;
            }
            else
            {
                return "<Grid><Cfg id='UpdateGrid'/><Cfg ConstHeight='1'/><Cfg Style='Standard'/><Toolbar Visible='0'/><LeftCols><C Name='Title' RelWidth='100'/></LeftCols><Cols></Cols><Body><B><I id='0' Title='Error: " + docRes.FirstChild.InnerText + "'/></B></Body></Grid>";
            }
        }

        private static string getFieldValue(string field, string value)
        {
            if (field == "PercentComplete")
            {
                try
                {
                    value = (double.Parse(value) * 100).ToString();
                }
                catch { }
            }
            return value;

        }

        private static string getAttribute(XmlNode nd, string attribute)
        {
            try
            {
                return nd.Attributes[attribute].Value;
            }
            catch { }
            return "";
        }

        private static void PublishProcessTasks(XmlNode ndFolder, string parentfolderpath, ref XmlDocument data, SPList oTaskCenter, DataSet dsResources, string iteration, PlannerProps props)
        {
            foreach (XmlNode ndTask in ndFolder.SelectNodes("I[@Def!='Folder']"))
            {
                PublishProcessTask(ndTask, parentfolderpath, ref data, oTaskCenter, dsResources, iteration, props);

                string newI = getAttribute(ndTask, "Def");
                if (newI == "Iteration")
                {
                    PublishProcessTasks(ndTask, parentfolderpath, ref data, oTaskCenter, dsResources, ndTask.Attributes["id"].Value, props);
                }
                else
                {
                    PublishProcessTasks(ndTask, parentfolderpath, ref data, oTaskCenter, dsResources, "", props);
                }
            }
        }

        private static void PublishProcessTask(XmlNode ndTask, string parentfolder, ref XmlDocument data, SPList oTaskCenter, DataSet dsResources, string iteration, PlannerProps props)
        {
            if (ndTask.Attributes["id"].Value == "BacklogRow")
                return;

            string pdef = getAttribute(ndTask.ParentNode, "Def");
            string def = getAttribute(ndTask, "Def");



            if (ndTask.Attributes["Def"].Value == "Assignment" && ndTask.ParentNode.Attributes["TaskType"].Value == "Individual")
            {
                if (pdef != "External")
                {
                    XmlNode ndNew = data.CreateNode(XmlNodeType.Element, "Task", data.NamespaceURI);
                    XmlAttribute attr = data.CreateAttribute("UID");
                    attr.Value = ndTask.Attributes["id"].Value;
                    ndNew.Attributes.Append(attr);

                    attr = data.CreateAttribute("Folder");
                    attr.Value = parentfolder;
                    ndNew.Attributes.Append(attr);

                    attr = data.CreateAttribute("ID");
                    attr.Value = ndTask.Attributes["taskorder"].Value;
                    ndNew.Attributes.Append(attr);



                    XmlNode ndTitle = data.CreateNode(XmlNodeType.Element, "Title", data.NamespaceURI);
                    ndTitle.InnerText = ndTask.ParentNode.Attributes["Title"].Value;

                    ndNew.AppendChild(ndTitle);


                    foreach (XmlAttribute fieldAttr in ndTask.Attributes)
                    {
                        if (PublishIsValidField(fieldAttr.Name))
                        {
                            if (PublishIsAssignmentField(fieldAttr.Name))
                            {
                                XmlNode ndField = data.CreateNode(XmlNodeType.Element, "Field", data.NamespaceURI);

                                ndField.InnerText = PublishGetFieldValue(fieldAttr.Name, ndTask, oTaskCenter, dsResources);

                                attr = data.CreateAttribute("Name");
                                attr.Value = fieldAttr.Name;
                                ndField.Attributes.Append(attr);

                                ndNew.AppendChild(ndField);
                            }
                            else
                            {

                                XmlNode ndField = data.CreateNode(XmlNodeType.Element, "Field", data.NamespaceURI);

                                if (fieldAttr.Name == "IsAssignment")
                                    ndField.InnerText = "true";
                                else
                                    ndField.InnerText = PublishGetFieldValue(fieldAttr.Name, ndTask, oTaskCenter, dsResources);

                                attr = data.CreateAttribute("Name");
                                attr.Value = fieldAttr.Name;
                                ndField.Attributes.Append(attr);

                                ndNew.AppendChild(ndField);
                            }
                        }
                    }
                    if (iteration != "")
                    {
                        try
                        {
                            ndNew.SelectSingleNode("Field[@Name='CT" + props.sIterationCT + "']").InnerText = iteration;
                        }
                        catch { }
                    }
                    data.FirstChild.AppendChild(ndNew);
                }
            }
            else if (ndTask.Attributes["Def"].Value == "Assignment")
            {
                //Do Nothing because it's a shared task type and we will skip assignment publishing
            }
            else
            {
                XmlNode ndNew = data.CreateNode(XmlNodeType.Element, "Task", data.NamespaceURI);
                XmlAttribute attr = data.CreateAttribute("UID");
                attr.Value = ndTask.Attributes["id"].Value;
                ndNew.Attributes.Append(attr);

                attr = data.CreateAttribute("Folder");
                attr.Value = parentfolder;
                ndNew.Attributes.Append(attr);

                attr = data.CreateAttribute("ID");
                attr.Value = ndTask.Attributes["taskorder"].Value;
                ndNew.Attributes.Append(attr);

                try
                {
                    attr = data.CreateAttribute("SPID");
                    attr.Value = ndTask.Attributes["SPID"].Value;
                    ndNew.Attributes.Append(attr);
                }
                catch { }

                XmlNode ndTitle = data.CreateNode(XmlNodeType.Element, "Title", data.NamespaceURI);
                ndTitle.InnerText = ndTask.Attributes["Title"].Value;

                ndNew.AppendChild(ndTitle);

                foreach (XmlAttribute fieldAttr in ndTask.Attributes)
                {
                    if (PublishIsValidField(fieldAttr.Name))
                    {
                        if ((ndTask.Attributes["TaskType"].Value == "Individual" || def == "External") && fieldAttr.Name == "AssignedTo")
                        {
                            XmlNode ndField = data.CreateNode(XmlNodeType.Element, "Field", data.NamespaceURI);

                            ndField.InnerText = "";

                            attr = data.CreateAttribute("Name");
                            attr.Value = fieldAttr.Name;
                            ndField.Attributes.Append(attr);

                            ndNew.AppendChild(ndField);
                        }
                        else if (fieldAttr.Name == "IsExternal")
                        {
                            XmlNode ndField = data.CreateNode(XmlNodeType.Element, "Field", data.NamespaceURI);

                            if (def == "External")
                                ndField.InnerText = "1";
                            else
                                ndField.InnerText = "0";

                            attr = data.CreateAttribute("Name");
                            attr.Value = fieldAttr.Name;
                            ndField.Attributes.Append(attr);

                            ndNew.AppendChild(ndField);



                        }
                        else
                        {
                            XmlNode ndField = data.CreateNode(XmlNodeType.Element, "Field", data.NamespaceURI);

                            ndField.InnerText = PublishGetFieldValue(fieldAttr.Name, ndTask, oTaskCenter, dsResources);

                            attr = data.CreateAttribute("Name");
                            attr.Value = fieldAttr.Name;
                            ndField.Attributes.Append(attr);

                            ndNew.AppendChild(ndField);
                        }
                    }
                }

                if (def == "External")
                {
                    try
                    {
                        ndNew.SelectSingleNode("Field[@Name='Timesheet']").InnerText = "0";
                    }
                    catch { }
                }

                if (ndTask.Attributes["Def"].Value == "Iteration")
                {
                    attr = data.CreateAttribute("Iteration");
                    attr.Value = "1";
                    ndNew.Attributes.Append(attr);
                }

                if (iteration != "")
                {
                    try
                    {
                        ndNew.SelectSingleNode("Field[@Name='CT" + props.sIterationCT + "']").InnerText = iteration;
                    }
                    catch { }
                }


                data.FirstChild.AppendChild(ndNew);
            }
        }

        private static string PublishGetFieldValue(string field, XmlNode ndTask, SPList oTaskCenter, DataSet dsResources)
        {
            string value = "";
            try
            {
                value = ndTask.Attributes[field].Value;

                SPField oField = oTaskCenter.Fields.GetFieldByInternalName(field);

                XmlDocument oDoc = new XmlDocument();
                oDoc.LoadXml(oField.SchemaXml);
                if (field == "Predecessors")
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        XmlDocument doc = ndTask.OwnerDocument;

                        string[] sPreds = value.Split(';');

                        string newPred = "";

                        foreach (string sPred in sPreds)
                        {
                            MatchCollection mc = Regex.Matches(sPred, "[0-9]*");

                            string sPredId = mc[0].Value;
                            string sPredInfo = "";
                            if (sPred.Length > sPredId.Length)
                            {
                                sPredInfo = sPred.Substring(sPredId.Length);
                            }
                            XmlNode nd = doc.FirstChild.SelectSingleNode("//I[@id='" + sPredId + "']");
                            if (nd != null)
                            {
                                try
                                {
                                    newPred += ";" + nd.Attributes["taskorder"].Value + sPredInfo;
                                }
                                catch { }
                            }
                        }
                        value = newPred.Trim(';');
                    }
                }
                else
                {
                    switch (oField.Type)
                    {
                        case SPFieldType.Number:
                            if (oDoc.FirstChild.Attributes["Percentage"] != null && oDoc.FirstChild.Attributes["Percentage"].Value.ToLower() == "true")
                            {
                                try
                                {
                                    value = (double.Parse(value) / 100).ToString();
                                }
                                catch { }
                            }
                            break;
                        case SPFieldType.User:
                            string[] sUsers = value.Split(';');
                            value = "";

                            foreach (string sUser in sUsers)
                            {
                                if (sUser != "" && dsResources.Tables.Count > 2)
                                {
                                    DataRow[] drc = dsResources.Tables[2].Select("ID='" + sUser + "'");
                                    if (drc.Length > 0)
                                    {
                                        value += ";#" + drc[0]["SPAccountInfo"];
                                    }
                                }
                            }
                            if (value.Length > 2)
                                value = value.Substring(2);
                            break;
                        case SPFieldType.MultiChoice:
                            value = value.Replace(";", ";#");
                            break;
                        case SPFieldType.Lookup:
                            XmlDocument docF = new XmlDocument();
                            docF.LoadXml(oField.SchemaXml);
                            SPList lstLookup = oTaskCenter.ParentWeb.Lists[new Guid(docF.FirstChild.Attributes["List"].Value)];

                            string[] sVals = value.Split(';');
                            value = "";
                            SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection();
                            foreach (string sVal in sVals)
                            {
                                try
                                {
                                    SPListItem li = lstLookup.GetItemById(int.Parse(sVal));
                                    SPFieldLookupValue lv = new SPFieldLookupValue(li.ID, li.Title);
                                    lvc.Add(lv);
                                }
                                catch { }
                            }
                            value = lvc.ToString();
                            break;
                    }
                }
            }
            catch { }
            return value;
        }

        private static bool PublishIsAssignmentField(string fieldAttr)
        {
            switch (fieldAttr)
            {
                case "AssignedTo":
                case "RemainingWork":
                case "ActualWork":
                case "PercentComplete":
                case "Work":
                    return true;
            };
            return false;
        }

        private static bool PublishIsValidField(string fieldAttr)
        {
            switch (fieldAttr)
            {
                case "ID":
                case "Title":
                case "id":
                case "Def":
                case "Panel":
                case "ContentType":
                case "Modified":
                case "Created":
                case "Author":
                case "Editor":
                case "_UIVersionString":
                case "Attachments":
                case "Edit":
                case "DocIcon":
                case "ItemChildCount":
                case "FolderChildCount":
                case "Project":
                case "D":
                case "Detail":
                case "taskuid":
                //case "Descendants":
                case "TaskType":
                    return false;
            };
            return true;
        }

        private static void PublishProcessFolders(XmlNode ndFolder, string parentfolderpath, ref XmlDocument data, SPList oTaskCenter, DataSet dsResources, PlannerProps props)
        {
            string folderPath = parentfolderpath + "/" + ndFolder.Attributes["Title"].Value;

            PublishProcessTasks(ndFolder, folderPath, ref data, oTaskCenter, dsResources, "", props);

            foreach (XmlNode ndSubFolder in ndFolder.SelectNodes("I[@Def='Folder']"))
            {
                PublishProcessFolders(ndSubFolder, folderPath, ref data, oTaskCenter, dsResources, props);
            }
        }

        public static string Publish(XmlDocument data, SPWeb oWeb)
        {



            PlannerProps props = getSettings(oWeb, data.FirstChild.Attributes["PlannerID"].Value);

            SPDocumentLibrary lib = (SPDocumentLibrary)oWeb.Lists["Project Schedules"];

            try
            {
                string planner = data.FirstChild.Attributes["PlannerID"].Value;
                string id = data.FirstChild.Attributes["ID"].Value;

                SPFile file = GetTaskFile(oWeb, id, planner);

                if (file != null)
                {
                    StreamReader reader = new StreamReader(file.OpenBinaryStream(), Encoding.GetEncoding("iso-8859-1"));
                    string sXml = reader.ReadToEnd();

                    XmlDocument docProject = new XmlDocument();
                    docProject.LoadXml(sXml);

                    SPList oTaskCenter = oWeb.Lists[props.sListTaskCenter];
                    SPList oProjectCenter = oWeb.Lists[props.sListProjectCenter];

                    DataSet dsResources = GetResourceTable(props, oProjectCenter.ID, data.FirstChild.Attributes["ID"].Value, oWeb);

                    PublishProcessTask(docProject.SelectSingleNode("//B/I"), "", ref data, oTaskCenter, dsResources, "", props);

                    PublishProcessTasks(docProject.SelectSingleNode("//B/I"), "", ref data, oTaskCenter, dsResources, "", props);

                    foreach (XmlNode ndFolder in docProject.SelectSingleNode("//B/I").SelectNodes("I[@Def='Folder']"))
                    {
                        PublishProcessFolders(ndFolder, "", ref data, oTaskCenter, dsResources, props);
                    }

                    string result = EPMLiveCore.WorkEngineAPI.Publish(data.FirstChild.OuterXml, oWeb);
                    //string result = "";
                    return result;
                }
                else
                    return "<Publish Result='1'/>Error: Could not open file</Publish>";
            }
            catch (Exception ex)
            {
                return "<Publish Result='1'/>" + ex.Message + "</Publish>";
            }
        }

        public static void appendSpecialColumns(ref XmlDocument docOut, ref XmlNode ndCols)
        {
            XmlNode ndNew = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
            XmlAttribute attr = docOut.CreateAttribute("Name");
            attr.Value = "Descendants";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Type");
            attr.Value = "Text";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Range");
            attr.Value = "1";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Visible");
            attr.Value = "0";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("CanEdit");
            attr.Value = "0";
            ndNew.Attributes.Append(attr);

            ndCols.AppendChild(ndNew);


            ndNew = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
            attr = docOut.CreateAttribute("Name");
            attr.Value = "TaskType";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Type");
            attr.Value = "Enum";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Enum");
            attr.Value = "|Shared|Individual";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Visible");
            attr.Value = "0";
            ndNew.Attributes.Append(attr);

            ndCols.AppendChild(ndNew);




            ndNew = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
            attr = docOut.CreateAttribute("Name");
            attr.Value = "BaselineDateRange";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Type");
            attr.Value = "Text";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Visible");
            attr.Value = "0";
            ndNew.Attributes.Append(attr);

            ndCols.AppendChild(ndNew);


            ndNew = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
            attr = docOut.CreateAttribute("Name");
            attr.Value = "SPID";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Type");
            attr.Value = "Text";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Visible");
            attr.Value = "0";
            ndNew.Attributes.Append(attr);

            ndCols.AppendChild(ndNew);


            ndNew = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
            attr = docOut.CreateAttribute("Name");
            attr.Value = "USAGE";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Type");
            attr.Value = "Text";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Visible");
            attr.Value = "0";
            ndNew.Attributes.Append(attr);

            ndCols.AppendChild(ndNew);



            ndNew = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
            attr = docOut.CreateAttribute("Name");
            attr.Value = "CommentCount";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Type");
            attr.Value = "Int";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Visible");
            attr.Value = "0";
            ndNew.Attributes.Append(attr);

            ndCols.AppendChild(ndNew);



            ndNew = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
            attr = docOut.CreateAttribute("Name");
            attr.Value = "Attachments";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Type");
            attr.Value = "Text";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Visible");
            attr.Value = "0";
            ndNew.Attributes.Append(attr);

            ndCols.AppendChild(ndNew);


            ndNew = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
            attr = docOut.CreateAttribute("Name");
            attr.Value = "EXTID";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Type");
            attr.Value = "Text";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Visible");
            attr.Value = "0";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("CanEdit");
            attr.Value = "0";
            ndNew.Attributes.Append(attr);

            ndCols.AppendChild(ndNew);


            ndNew = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
            attr = docOut.CreateAttribute("Name");
            attr.Value = "LinkedTask";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Type");
            attr.Value = "Bool";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Visible");
            attr.Value = "0";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("CanEdit");
            attr.Value = "0";
            ndNew.Attributes.Append(attr);

            ndCols.AppendChild(ndNew);


            //ndNew = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
            //attr = docOut.CreateAttribute("Name");
            //attr.Value = "MinStart";
            //ndNew.Attributes.Append(attr);

            //attr = docOut.CreateAttribute("Type");
            //attr.Value = "Date";
            //ndNew.Attributes.Append(attr);

            //attr = docOut.CreateAttribute("Visible");
            //attr.Value = "1";
            //ndNew.Attributes.Append(attr);

            //attr = docOut.CreateAttribute("CanEdit");
            //attr.Value = "1";
            //ndNew.Attributes.Append(attr);

            //ndCols.AppendChild(ndNew);


            //ndNew = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
            //attr = docOut.CreateAttribute("Name");
            //attr.Value = "MaxEnd";
            //ndNew.Attributes.Append(attr);

            //attr = docOut.CreateAttribute("Type");
            //attr.Value = "Date";
            //ndNew.Attributes.Append(attr);

            //attr = docOut.CreateAttribute("Visible");
            //attr.Value = "1";
            //ndNew.Attributes.Append(attr);

            //attr = docOut.CreateAttribute("CanEdit");
            //attr.Value = "1";
            //ndNew.Attributes.Append(attr);

            //ndCols.AppendChild(ndNew);



            ndNew = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
            attr = docOut.CreateAttribute("Name");
            attr.Value = "OldStartDate";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Type");
            attr.Value = "Date";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Visible");
            attr.Value = "0";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("CanEdit");
            attr.Value = "0";
            ndNew.Attributes.Append(attr);

            ndCols.AppendChild(ndNew);


            ndNew = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
            attr = docOut.CreateAttribute("Name");
            attr.Value = "OldDueDate";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Type");
            attr.Value = "Date";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Visible");
            attr.Value = "0";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("CanEdit");
            attr.Value = "0";
            ndNew.Attributes.Append(attr);

            ndCols.AppendChild(ndNew);
        }

        private static string iGetGeneralLayout(SPWeb web, string sPlannerXml, XmlDocument data, bool bIsAgileLayout)
        {
            string sPlannerID = data.FirstChild.Attributes["Planner"].Value;

            PlannerProps p = getSettings(web, sPlannerID);

            SPList oListTaskCenter = web.Lists[p.sListTaskCenter];
            SPList oListProjectCenter = web.Lists[p.sListProjectCenter];

            string sView = data.FirstChild.Attributes["View"].Value;
            SPView oView = oListTaskCenter.DefaultView;
            SPViewFieldCollection oViewFields = oView.ViewFields;

            if (sView != "")
                oView = oListTaskCenter.Views[sView];

            XmlDocument docOut = new XmlDocument();
            docOut.LoadXml(sPlannerXml);

            XmlNode ndCols = docOut.SelectSingleNode("//Cols");
            XmlNode ndConfig = docOut.SelectSingleNode("//Cfg");
            XmlNode ndLeftCols = docOut.SelectSingleNode("//LeftCols");
            XmlNode ndHeader = docOut.SelectSingleNode("//Header");
            XmlNode ndDef = docOut.SelectSingleNode("//Def");
            XmlNode ndRightCols = docOut.FirstChild.SelectSingleNode("//RightCols");

            if (p.bStartSoon)
            {
                docOut.FirstChild.SelectSingleNode("//C[@Name='G']").Attributes["GanttStrict"].Value = "1";
            }

            if (p.bAgile)
            {
                XmlNode ndNewFolder = docOut.CreateNode(XmlNodeType.Element, "D", docOut.NamespaceURI);

                XmlAttribute attrFolder = docOut.CreateAttribute("Name");
                attrFolder.Value = "Folder";
                ndNewFolder.Attributes.Append(attrFolder);

                attrFolder = docOut.CreateAttribute("AcceptDef");
                attrFolder.Value = "Iteration";
                ndNewFolder.Attributes.Append(attrFolder);

                ndDef.AppendChild(ndNewFolder);

                ndNewFolder = docOut.CreateNode(XmlNodeType.Element, "D", docOut.NamespaceURI);

                attrFolder = docOut.CreateAttribute("Name");
                attrFolder.Value = "Iteration";
                ndNewFolder.Attributes.Append(attrFolder);

                attrFolder = docOut.CreateAttribute("Background");
                attrFolder.Value = "241,241,241";
                ndNewFolder.Attributes.Append(attrFolder);

                attrFolder = docOut.CreateAttribute("Class");
                attrFolder.Value = "SummaryTask";
                ndNewFolder.Attributes.Append(attrFolder);

                attrFolder = docOut.CreateAttribute("Calculated");
                attrFolder.Value = "1";
                ndNewFolder.Attributes.Append(attrFolder);

                attrFolder = docOut.CreateAttribute("AcceptDef");
                attrFolder.Value = "Summary,Task";
                ndNewFolder.Attributes.Append(attrFolder);

                ndDef.AppendChild(ndNewFolder);
            }

            ArrayList arrFields = new ArrayList();

            try
            {
                p.oFolderFields = oListTaskCenter.ContentTypes["WEFolder"].FieldLinks;
            }
            catch { }
            try
            {
                p.oTaskFields = oListTaskCenter.ContentTypes["Task"].FieldLinks;
            }
            catch { }
            try
            {
                p.oIterationFields = oListTaskCenter.ContentTypes[p.sIterationCT].FieldLinks;
            }
            catch { }

            DataSet dsResources = GetResourceTable(p, oListProjectCenter.ID, data.FirstChild.Attributes["ID"].Value, web);


            string defaultView = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + sPlannerID + "ViewsDefault");
            string sFullViewsList = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + sPlannerID + "Views");
            string[] sViewList = sFullViewsList.Replace(";#", "\n").Split('\n');

            ArrayList arrLeftCols = new ArrayList();
            ArrayList arrCols = new ArrayList();
            string oViewGroup = "";
            string oViewFilter = "";
            string oViewSort = "";
            string oGantt = "";
            string oAssignments = "";
            string[] sViewAgileData = new string[0] { };

            for (int i = 0; i < sViewList.Length; i++)
            {
                if (sViewList[i] != "")
                {
                    string[] sViewDataWithAgile = sViewList[i].Split('`');
                    string[] sViewData = sViewDataWithAgile[0].Split('|');



                    if (sViewData.Length > 0)
                    {
                        if (sViewData[0].ToString() == defaultView)
                        {
                            try
                            {
                                arrLeftCols = new ArrayList(sViewData[1].Split(','));
                            }
                            catch { }
                            try
                            {
                                arrCols = new ArrayList(sViewData[2].Split(','));
                            }
                            catch { }
                            oViewFilter = sViewData[3];
                            oViewGroup = sViewData[4];
                            oViewSort = sViewData[5];
                            oGantt = sViewData[6];
                            oAssignments = sViewData[9];

                            try
                            {
                                sViewAgileData = sViewDataWithAgile[1].Split('|');
                            }
                            catch { }

                            break;

                        }
                    }
                }
            }

            if (bIsAgileLayout && sViewAgileData.Length > 1)
            {
                try
                {
                    arrLeftCols = new ArrayList(sViewAgileData[0].Split(','));
                }
                catch { }
                try
                {
                    arrCols = new ArrayList(sViewAgileData[1].Split(','));
                }
                catch { }
                oViewFilter = sViewAgileData[2];
                oViewGroup = sViewAgileData[3];
                oViewSort = sViewAgileData[4];
                oGantt = sViewAgileData[5];


            }

            XmlAttribute attrCfg = docOut.CreateAttribute("Group");
            try
            {
                attrCfg.Value = oViewGroup.Split('^')[1];
            }
            catch { }
            ndConfig.Attributes.Append(attrCfg);

            attrCfg = docOut.CreateAttribute("Sort");
            attrCfg.Value = oViewSort;
            ndConfig.Attributes.Append(attrCfg);

            XmlNode ndFilter = docOut.SelectSingleNode("//Head/I[@Kind='Filter']");

            string[] sFilterInfo = oViewFilter.Split('^');

            try
            {
                string[] sFilterFields = sFilterInfo[1].Split(',');
                string[] sFilterFieldVals = sFilterInfo[2].Split(',');
                string[] sFilterFieldTypes = sFilterInfo[3].Split(',');
                for (int i = 0; i < sFilterFields.Length; i++)
                {
                    if (sFilterFields[i] != "")
                    {
                        XmlAttribute attr1 = docOut.CreateAttribute(sFilterFields[i]);
                        attr1.Value = sFilterFieldVals[i];
                        ndFilter.Attributes.Append(attr1);

                        attr1 = docOut.CreateAttribute(sFilterFields[i] + "Filter");
                        attr1.Value = sFilterFieldTypes[i];
                        ndFilter.Attributes.Append(attr1);
                    }
                }
            }
            catch { }

            try
            {
                if (sFilterInfo[0] != "")
                    if (sFilterInfo[0] == "0" || sFilterInfo[0] == "false")
                        ndFilter.Attributes["Visible"].Value = "0";
                    else
                        ndFilter.Attributes["Visible"].Value = "1";
            }
            catch { }

            try
            {
                if (oAssignments == "0" || oAssignments.ToLower() == "false")
                    docOut.SelectSingleNode("//Def/D[@Name='Assignment']").Attributes["Visible"].Value = "0";
                else
                    docOut.SelectSingleNode("//Def/D[@Name='Assignment']").Attributes["Visible"].Value = "1";
            }
            catch { }

            try
            {
                if (oViewGroup.Split('^')[0] != "")
                    docOut.SelectSingleNode("//Solid/Group").Attributes["Visible"].Value = oViewGroup.Split('^')[0];
            }
            catch { }

            try
            {
                if (oGantt != "")
                    docOut.SelectSingleNode("//RightCols/C[@Name='G']").Attributes["Visible"].Value = oGantt;
            }
            catch { }

            bool bHasViewInfo = false;

            foreach (string sField in arrLeftCols)
            {
                try
                {
                    if (sField != "")
                    {
                        SPField oField = getRealField(oListTaskCenter.Fields.GetFieldByInternalName(sField));

                        processField(ref docOut, oField, "1", ref ndLeftCols, ref ndHeader, p, web, dsResources);

                        bHasViewInfo = true;
                    }
                }
                catch { }
            }

            foreach (string sField in arrCols)
            {
                try
                {
                    if (sField != "")
                    {
                        SPField oField = getRealField(oListTaskCenter.Fields.GetFieldByInternalName(sField));

                        processField(ref docOut, oField, "1", ref ndCols, ref ndHeader, p, web, dsResources);

                        bHasViewInfo = true;
                    }
                }
                catch { }
            }


            foreach (SPField oTempField in oListTaskCenter.Fields)
            {
                SPField oField = getRealField(oTempField);

                if (!oField.Hidden && isValidField(oField.InternalName, false) && oField.Reorderable && !arrCols.Contains(oField.InternalName) && !arrLeftCols.Contains(oField.InternalName))
                {
                    if (oViewFields.Exists(oField.InternalName) && !bHasViewInfo)
                        processField(ref docOut, oField, "1", ref ndCols, ref ndHeader, p, web, dsResources);
                    else
                        processField(ref docOut, oField, "0", ref ndCols, ref ndHeader, p, web, dsResources);

                }
            }

            SPList oProjectCenter = web.Lists[p.sListProjectCenter];

            SPListItem oProject = oProjectCenter.GetItemById(int.Parse(data.FirstChild.Attributes["ID"].Value));
            //=================================Add Defaults==============================

            XmlAttribute attrDef;

            XmlNode ndTaskDef = docOut.SelectSingleNode("//Def/D[@Name='Task']");

            foreach (SPField oField in oListTaskCenter.Fields)
            {
                if (oField.Type != SPFieldType.User)
                {
                    try
                    {
                        if (!oField.ReadOnlyField)
                        {
                            XmlDocument docF = new XmlDocument();
                            docF.LoadXml(oField.SchemaXml);

                            string sDefault = docF.SelectSingleNode("//Default").InnerText;
                            if (oField.Type == SPFieldType.DateTime && sDefault == "[today]")
                            {

                            }
                            else if (oField.Type == SPFieldType.Number || oField.Type == SPFieldType.Currency)
                            {
                                if (sDefault != "" && sDefault != "0")
                                {
                                    attrDef = docOut.CreateAttribute(oField.InternalName);
                                    attrDef.Value = sDefault.Replace("\"", "'");
                                    ndTaskDef.Attributes.Append(attrDef);
                                }
                                //if(sDefault != "0" && sDefault != ".00")
                                //sDefaults += oField.InternalName + ":\"" + sDefault.Replace("\"", "'") + "\",";
                            }
                            else if (oField.Type == SPFieldType.Boolean)
                            {
                                if (sDefault != "0")
                                {
                                    attrDef = docOut.CreateAttribute(oField.InternalName);
                                    attrDef.Value = sDefault.Replace("\"", "'");
                                    ndTaskDef.Attributes.Append(attrDef);
                                }
                            }
                            else
                            {
                                attrDef = docOut.CreateAttribute(oField.InternalName);
                                attrDef.Value = sDefault.Replace("\"", "'");
                                ndTaskDef.Attributes.Append(attrDef);

                            }
                        }
                    }
                    catch { }
                }
            }

            try
            {
                attrDef = docOut.CreateAttribute("StartDate");
                attrDef.Value = DateTime.Parse(oProject[oProjectCenter.Fields.GetFieldByInternalName("Start").Id].ToString()).ToString("yyyy-MM-dd") + " " + (p.iWorkHours[0] / 60) + ":00"; //getFieldValue(oProject, oProjectCenter.Fields.GetFieldByInternalName("Start"), dsResources);// oProject[oProjectCenter.Fields.GetFieldByInternalName("Start").Id].ToString();
                ndTaskDef.Attributes.Append(attrDef);

                attrDef = docOut.CreateAttribute("DueDate");
                attrDef.Value = DateTime.Parse(oProject[oProjectCenter.Fields.GetFieldByInternalName("Start").Id].ToString()).ToString("yyyy-MM-dd") + " " + (p.iWorkHours[3] / 60) + ":00"; //getFieldValue(oProject, oProjectCenter.Fields.GetFieldByInternalName("Start"), dsResources);// oProject[oProjectCenter.Fields.GetFieldByInternalName("Start").Id].ToString();
                ndTaskDef.Attributes.Append(attrDef);
            }
            catch
            {
                attrDef = docOut.CreateAttribute("StartDate");
                attrDef.Value = DateTime.Now.ToString("yyyy-MM-dd") + " " + (p.iWorkHours[0] / 60) + ":00";
                ndTaskDef.Attributes.Append(attrDef);

                attrDef = docOut.CreateAttribute("DueDate");
                attrDef.Value = DateTime.Now.ToString("yyyy-MM-dd") + " " + (p.iWorkHours[3] / 60) + ":00";
                ndTaskDef.Attributes.Append(attrDef);
            }

            attrDef = docOut.CreateAttribute("Duration");
            attrDef.Value = "1";
            ndTaskDef.Attributes.Append(attrDef);
            //===============================================================
            appendSpecialColumns(ref docOut, ref ndCols);

            StringBuilder sb = new StringBuilder();
            StringBuilder sbBackGround = new StringBuilder();

            sb.Append("d#0:00~");
            sb.Append(p.iWorkHours[0] / 60);
            sb.Append(":00#4;");

            sb.Append("d#");
            sb.Append(p.iWorkHours[1]);
            sb.Append(":00~");
            sb.Append(p.iWorkHours[2]);
            sb.Append(":00#4;");

            sb.Append("d#");
            sb.Append(p.iWorkHours[3] / 60);
            sb.Append(":00~24:00#4;");

            string[] workdays = p.sWorkDays.Split(',');

            for (int i = 0; i < workdays.Length; i++)
            {
                if (workdays[i] == "0")
                {
                    DateTime dt = new DateTime(633351744000000000);//January 6, 2008 (Sunday)
                    dt = dt.AddDays(i);
                    sb.Append("w#");
                    sbBackGround.Append("d#");
                    sb.Append(dt.ToString("yyyy-MM-dd"));
                    sbBackGround.Append(dt.ToString("yyyy-MM-dd"));
                    sb.Append("~");
                    sbBackGround.Append("~");

                    dt = dt.AddDays(1);

                    sb.Append(dt.ToString("yyyy-MM-dd"));
                    sbBackGround.Append(dt.ToString("yyyy-MM-dd"));
                    sb.Append("#5;");
                    sbBackGround.Append(";");

                }
            }


            double hours = 60000 * (p.iWorkHours[3] - p.iWorkHours[0] - (p.iWorkHours[2] - p.iWorkHours[1]) * 60);

            XmlNode ndG = docOut.SelectSingleNode("//C[@GanttDataUnits='28800000']");
            ndG.Attributes["GanttDataUnits"].Value = hours.ToString();

            try
            {
                foreach (DataRow dr in p.Holidays.Rows)
                {
                    if (String.IsNullOrEmpty(dr["Hours"].ToString()))
                    {
                        DateTime dt = DateTime.Parse(dr["Date"].ToString());
                        sb.Append(dt.ToShortDateString());
                        sbBackGround.Append(dt.ToString("yyyy-MM-dd"));
                        sb.Append("~");
                        sbBackGround.Append("~");
                        dt = dt.AddDays(1);

                        sb.Append(dt.ToShortDateString());
                        sbBackGround.Append(dt.ToString("yyyy-MM-dd"));
                        sb.Append("#3;");
                        sbBackGround.Append(";");
                    }
                    else
                    {
                        DateTime dt = DateTime.Parse(dr["Date"].ToString());
                        sb.Append(dt.ToString("yyyy-MM-dd"));
                        sbBackGround.Append(dt.ToString("yyyy-MM-dd"));
                        sb.Append(" 00:00~");
                        sbBackGround.Append(" 00:00~");
                        sb.Append(dt.ToString("yyyy-MM-dd"));
                        sbBackGround.Append(dt.ToString("yyyy-MM-dd"));
                        sb.Append(" ");
                        sbBackGround.Append(" ");
                        sb.Append(p.iWorkHours[0] / 60);
                        sbBackGround.Append(p.iWorkHours[0] / 60);
                        sb.Append(":00;");
                        sbBackGround.Append(":00;");

                        sb.Append(dt.ToString("yyyy-MM-dd"));
                        sbBackGround.Append(dt.ToString("yyyy-MM-dd"));
                        sb.Append(" ");
                        sbBackGround.Append(" ");
                        sb.Append((p.iWorkHours[3] / 60) - int.Parse(dr["Hours"].ToString()));
                        sbBackGround.Append((p.iWorkHours[3] / 60) - int.Parse(dr["Hours"].ToString()));
                        sb.Append(":00~");
                        sbBackGround.Append(":00~");

                        dt = dt.AddDays(1);

                        sb.Append(dt.ToString("yyyy-MM-dd"));
                        sbBackGround.Append(dt.ToString("yyyy-MM-dd"));
                        sb.Append(" 24:00#3;");
                        sbBackGround.Append(" 24:00;");
                    }

                }
            }
            catch { }



            XmlNode ndNew = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
            XmlAttribute attr = docOut.CreateAttribute("Name");
            attr.Value = "G";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("GanttExclude");
            attr.Value = sb.ToString().Trim(';');
            //attr.Value = "w#1/5/2008~1/7/2008; d#00:00~9:00; d#18:00~24:00";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("GanttNewStart");
            attr.Value = "2000-01-01 " + p.iWorkHours[0] / 60 + ":00";
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("GanttNewEnd");
            attr.Value = "2000-01-01 " + p.iWorkHours[3] / 60 + ":00";
            ndNew.Attributes.Append(attr);

            //attr = docOut.CreateAttribute("GanttBackground");
            //attr.Value = sbBackGround.ToString().Trim(';');
            //ndNew.Attributes.Append(attr);

            ndRightCols.AppendChild(ndNew);
            //<!--<C Name="G" GanttExclude = "w#1/5/2008~1/6/2008;w#1/6/2008~1/7/2008; d#00:00~9:00; d#18:00~24:00"/>-->



            if (oProjectCenter.Fields.ContainsField(sPlannerID + "FAC"))
            {
                try
                {
                    XmlNode ndCfg = docOut.CreateNode(XmlNodeType.Element, "Cfg", docOut.NamespaceURI);
                    XmlAttribute a1 = docOut.CreateAttribute("Calculated");
                    if (oProject[sPlannerID + "FAC"].ToString().ToLower() == "true")
                        a1.Value = "1";
                    else
                        a1.Value = "0";
                    ndCfg.Attributes.Append(a1);

                    docOut.FirstChild.AppendChild(ndCfg);
                }
                catch { }
            }

            if (oProjectCenter.Fields.ContainsField(sPlannerID + "FRL"))
            {
                try
                {
                    XmlNode ndCfg = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
                    XmlAttribute a1 = docOut.CreateAttribute("Name");
                    a1.Value = "G";
                    ndCfg.Attributes.Append(a1);

                    a1 = docOut.CreateAttribute("GanttCorrectDependencies");
                    if (oProject[sPlannerID + "FRL"].ToString().ToLower() == "true")
                        a1.Value = "1";
                    else
                        a1.Value = "0";
                    ndCfg.Attributes.Append(a1);

                    docOut.FirstChild.SelectSingleNode("//RightCols").AppendChild(ndCfg);
                }
                catch { }
            }


            addCalculations(p, ref docOut, ref ndDef, p.bAgile);


            ndG = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
            XmlAttribute ndGa1 = docOut.CreateAttribute("Name");
            ndGa1.Value = "G";
            ndG.Attributes.Append(ndGa1);

            try
            {
                ndGa1 = docOut.CreateAttribute("GanttBase");
                ndGa1.Value = DateTime.Parse(oProject[oProjectCenter.Fields.GetFieldByInternalName("Start").Id].ToString()).ToString("yyyy-MM-dd") + " " + (p.iWorkHours[0] / 60) + ":00"; //getFieldValue(oProject, oProjectCenter.Fields.GetFieldByInternalName("Start"), dsResources);// oProject[oProjectCenter.Fields.GetFieldByInternalName("Start").Id].ToString();
                ndG.Attributes.Append(ndGa1);
            }
            catch
            {
                ndGa1 = docOut.CreateAttribute("GanttBase");
                ndGa1.Value = DateTime.Now.ToString("yyyy-MM-dd") + " " + (p.iWorkHours[0] / 60) + ":00"; //getFieldValue(oProject, oProjectCenter.Fields.GetFieldByInternalName("Start"), dsResources);// oProject[oProjectCenter.Fields.GetFieldByInternalName("Start").Id].ToString();
                ndG.Attributes.Append(ndGa1);
            }
            ndGa1 = docOut.CreateAttribute("GanttBaseProof");
            ndGa1.Value = "1";
            ndG.Attributes.Append(ndGa1);

            docOut.FirstChild.SelectSingleNode("//RightCols").AppendChild(ndG);


            //==============Process Resources=============
            XmlNode ndResources = docOut.SelectSingleNode("//Resources");
            XmlNode ndFoot = docOut.SelectSingleNode("//Foot");

            if (ndResources != null && false)
            {
                foreach (DataRow dr in dsResources.Tables[2].Rows)
                {
                    XmlNode ndRes = docOut.CreateNode(XmlNodeType.Element, "Resource", docOut.NamespaceURI);

                    XmlAttribute Attr = docOut.CreateAttribute("Name");
                    Attr.Value = dr["Title"].ToString();
                    ndRes.Attributes.Append(Attr);

                    Attr = docOut.CreateAttribute("Availability");
                    Attr.Value = ((p.iWorkHours[3] - p.iWorkHours[0] - (p.iWorkHours[2] - p.iWorkHours[1]) * 60) / 60).ToString();
                    ndRes.Attributes.Append(Attr);

                    Attr = docOut.CreateAttribute("Type");
                    Attr.Value = "1";
                    ndRes.Attributes.Append(Attr);

                    ndResources.AppendChild(ndRes);



                    ndRes = docOut.CreateNode(XmlNodeType.Element, "I", docOut.NamespaceURI);

                    Attr = docOut.CreateAttribute("ID");
                    Attr.Value = "R" + dr["SPID"].ToString();
                    ndRes.Attributes.Append(Attr);

                    Attr = docOut.CreateAttribute("Title");
                    Attr.Value = dr["Title"].ToString();
                    ndRes.Attributes.Append(Attr);

                    Attr = docOut.CreateAttribute("Def");
                    Attr.Value = "RES";
                    ndRes.Attributes.Append(Attr);

                    Attr = docOut.CreateAttribute("GGanttChartResource");
                    Attr.Value = dr["Title"].ToString();
                    ndRes.Attributes.Append(Attr);

                    Attr = docOut.CreateAttribute("MidHtml");
                    Attr.Value = "";
                    ndRes.Attributes.Append(Attr);

                    ndFoot.AppendChild(ndRes);
                }
            }

            //if(p.bAgile && !bIsAgileLayout)
            //{
            //    docOut.FirstChild.SelectSingleNode("//I[@id='NewTask2']").Attributes["Visible"].Value = "0";
            //}

            return docOut.OuterXml;

        }

        public static string GetAgileLayout(XmlDocument data, SPWeb oWeb)
        {


            return iGetGeneralLayout(oWeb, Properties.Resources.txtAgileLayout, data, true);

        }

        //public static string GetAgileTasks(XmlDocument data, SPWeb oWeb)
        //{
        //   

        //    PlannerProps p = getSettings(web, data.FirstChild.Attributes["Planner"].Value);

        //    string CurXml = "<Grid><Body><B></B></Body></Grid>";
        //    string TaskXml = "<Grid><Body><B></B></Body></Grid>";
        //    try
        //    {
        //        SPFile file = GetTaskFile(web, data.FirstChild.Attributes["ID"].Value + "Agile", data.FirstChild.Attributes["Planner"].Value);

        //        StreamReader reader = new StreamReader(file.OpenBinaryStream());
        //        CurXml = reader.ReadToEnd();
        //    }
        //    catch {  }

        //    StringReader sr = new StringReader(EPMLiveCore.WorkEngineAPI.GetTeam("<Team><Columns>Title</Columns></Team>"));
        //    DataSet dsResources = new DataSet();
        //    dsResources.ReadXml(sr, XmlReadMode.Auto);

        //    try
        //    {
        //        SPFile file = GetTaskFile(web, data.FirstChild.Attributes["ID"].Value, data.FirstChild.Attributes["Planner"].Value);

        //        StreamReader reader = new StreamReader(file.OpenBinaryStream());
        //        TaskXml = reader.ReadToEnd();
        //    }
        //    catch { }

        //    return AppendNewAgileTasks(web, p, CurXml, TaskXml, data.FirstChild.Attributes["ID"].Value, dsResources);
        //}

        private static bool isNewValidTask(SPListItem li, XmlDocument agileDoc)
        {
            XmlNode nd = agileDoc.FirstChild.SelectSingleNode("//I[@SPID='" + li.ID + "']");
            if (nd != null)
                return false;

            string taskuid = getLIField(li, "taskuid");
            if (taskuid != "")
            {
                nd = agileDoc.FirstChild.SelectSingleNode("//I[@id='" + taskuid + "']");
                if (nd != null)
                    return false;
            }

            //nd = taskDoc.FirstChild.SelectSingleNode("//I[@SPID='" + li.ID + "']");
            //if(nd != null)
            //    return false;

            //if(taskuid != "")
            //{
            //    nd = taskDoc.FirstChild.SelectSingleNode("//I[@id='" + taskuid + "']");
            //    if(nd != null)
            //        return false;
            //}

            return true;
        }

        private static string AppendNewAgileTasks(SPWeb web, PlannerProps p, XmlDocument doc, string projectid, DataSet dsResources)
        {

            XmlNode ndBody = doc.FirstChild.SelectSingleNode("//B/I[@id='0']");

            XmlNode ndBacklog = ndBody.SelectSingleNode("I[@id='BacklogRow']");
            if (ndBacklog == null)
            {
                ndBacklog = doc.CreateNode(XmlNodeType.Element, "I", doc.NamespaceURI);
                XmlAttribute attr = doc.CreateAttribute("id");
                attr.Value = "BacklogRow";
                ndBacklog.Attributes.Append(attr);

                attr = doc.CreateAttribute("Title");
                attr.Value = "Backlog";
                ndBacklog.Attributes.Append(attr);

                attr = doc.CreateAttribute("Detail");
                attr.Value = "AgileGrid";
                ndBacklog.Attributes.Append(attr);

                ndBody.AppendChild(ndBacklog);
            }

            SPList oListTaskCenter = web.Lists.TryGetList(p.sListTaskCenter);
            if (oListTaskCenter != null)
            {
                SPQuery query = new SPQuery();
                query.Query = "<Where><And><Eq><FieldRef Name='Project' LookupId='TRUE'/><Value Type='Lookup'>" + projectid + "</Value></Eq><Neq><FieldRef Name='ContentType'/><Value Type='String'>" + p.sIterationCT + "</Value></Neq></And></Where>";

                SPListItemCollection lic = oListTaskCenter.GetItems(query);

                foreach (SPListItem li in lic)
                {
                    if (isNewValidTask(li, doc))
                    {
                        XmlNode ndNewTask = doc.CreateNode(XmlNodeType.Element, "I", doc.NamespaceURI);
                        XmlAttribute attr = doc.CreateAttribute("SPID");
                        attr.Value = li.ID.ToString();
                        ndNewTask.Attributes.Append(attr);

                        attr = doc.CreateAttribute("Def");
                        attr.Value = "Task";
                        ndNewTask.Attributes.Append(attr);

                        foreach (SPField oTempField in oListTaskCenter.Fields)
                        {
                            SPField oField = getRealField(oTempField);

                            if (!oField.Hidden && isValidField(oField.InternalName, false) && oField.Reorderable)
                            {
                                var val = getFieldValue(li, oField, dsResources);

                                if (oField.Type == SPFieldType.DateTime)
                                {
                                    if (val != "")
                                    {
                                        attr = doc.CreateAttribute(oField.InternalName);
                                        attr.Value = val;
                                        ndNewTask.Attributes.Append(attr);
                                    }
                                }
                                else
                                {
                                    attr = doc.CreateAttribute(oField.InternalName);
                                    attr.Value = val;
                                    ndNewTask.Attributes.Append(attr);
                                }

                            }
                        }

                        ndBacklog.AppendChild(ndNewTask);

                        try
                        {
                            li["IsPublished"] = "1";
                            li.SystemUpdate();
                        }
                        catch { }
                    }
                }
            }

            return doc.OuterXml;
        }

        public static string GetLayout(XmlDocument data, SPWeb oWeb)
        {



            return iGetGeneralLayout(oWeb, Properties.Resources.txtDefaultConfig, data, false);
        }

        private static string GetAgileFolderFieldFormula(string field)
        {
            switch (field)
            {
                case "StartDate":
                    return "min()";
                case "DueDate":
                    return "max()";
                case "ResourcePoints":
                    return "sum()";
                case "WorkCapacity":
                    return "sum()";
            }
            return "";
        }

        private static void addCalculations(PlannerProps p, ref XmlDocument docOut, ref XmlNode ndDef, bool bAgile)
        {
            string calcorder = "StartDate,DueDate,Duration,PercentComplete,G";
            XmlNode ndCol;
            XmlAttribute a1;

            if (bAgile)
            {
                p.wpFields.set("ResourcePoints", "");
                p.wpFields.set("WorkCapacity", "");
            }

            for (int i = 0; i < p.wpFields.count(); i++)
            {
                PlannerCore.WorkPlannerProperty wp = p.wpFields.GetByIndex(i);

                string val = "";

                if (wp.val == "RollDown" || wp.val == "Disallow")
                {
                    calcorder += "," + wp.field;
                }
                else if (wp.field == "PercentComplete")
                {
                }
                else if (wp.field == "StartDate")
                    val = "minimum(min('StartDate'),min('DueDate'))";
                else if (wp.field == "DueDate")
                    val = "maximum(max('StartDate'),max('DueDate'))";
                else
                {
                    calcorder += "," + wp.field;
                    if (wp.val.ToLower() != "")
                        val = wp.val.ToLower() + "()";
                    //val = wp.val.ToLower() + "('" + wp.field + "')";
                }

                string folderformula = val;

                if (val != "")
                {
                    ndCol = docOut.CreateNode(XmlNodeType.Element, "D", docOut.NamespaceURI);
                    a1 = docOut.CreateAttribute("Name");
                    a1.Value = "Summary";
                    ndCol.Attributes.Append(a1);
                    a1 = docOut.CreateAttribute(wp.field + "Formula");
                    a1.Value = val;
                    ndCol.Attributes.Append(a1);

                    ndDef.AppendChild(ndCol);

                    if (p.bAgile)
                    {
                        ndCol = docOut.CreateNode(XmlNodeType.Element, "D", docOut.NamespaceURI);
                        a1 = docOut.CreateAttribute("Name");
                        a1.Value = "Iteration";
                        ndCol.Attributes.Append(a1);
                        a1 = docOut.CreateAttribute(wp.field + "Formula");
                        a1.Value = val;
                        ndCol.Attributes.Append(a1);

                        ndDef.AppendChild(ndCol);
                    }

                }

                if (bAgile)
                {
                    string tFormula = GetAgileFolderFieldFormula(wp.field);
                    if (!string.IsNullOrEmpty(tFormula))
                        folderformula = tFormula;
                }

                if (folderformula != "")
                {
                    ndCol = docOut.CreateNode(XmlNodeType.Element, "D", docOut.NamespaceURI);
                    a1 = docOut.CreateAttribute("Name");
                    a1.Value = "Folder";
                    ndCol.Attributes.Append(a1);
                    a1 = docOut.CreateAttribute(wp.field + "Formula");
                    a1.Value = folderformula;
                    ndCol.Attributes.Append(a1);

                    ndDef.AppendChild(ndCol);
                }
            }

            ndCol = docOut.CreateNode(XmlNodeType.Element, "D", docOut.NamespaceURI);
            a1 = docOut.CreateAttribute("Name");
            a1.Value = "Summary";
            ndCol.Attributes.Append(a1);
            a1 = docOut.CreateAttribute("CalcOrder");
            a1.Value = calcorder;
            ndCol.Attributes.Append(a1);

            ndDef.AppendChild(ndCol);

            ndCol = docOut.CreateNode(XmlNodeType.Element, "D", docOut.NamespaceURI);
            a1 = docOut.CreateAttribute("Name");
            a1.Value = "Folder";
            ndCol.Attributes.Append(a1);
            a1 = docOut.CreateAttribute("CalcOrder");
            a1.Value = calcorder;
            ndCol.Attributes.Append(a1);

            ndDef.AppendChild(ndCol);


            if (bAgile)
            {
                ndCol = docOut.CreateNode(XmlNodeType.Element, "D", docOut.NamespaceURI);
                a1 = docOut.CreateAttribute("Name");
                a1.Value = "Iteration";
                ndCol.Attributes.Append(a1);
                a1 = docOut.CreateAttribute("CalcOrder");
                a1.Value = calcorder + ",Available,AvailableWork";
                ndCol.Attributes.Append(a1);

                ndDef.AppendChild(ndCol);
            }
        }

        public static string GetFolderLayout(XmlDocument data, SPWeb oWeb)
        {



            PlannerProps p = getSettings(oWeb, data.FirstChild.Attributes["Planner"].Value);

            SPList oListTaskCenter = oWeb.Lists[p.sListTaskCenter];
            SPList oListProjectCenter = oWeb.Lists[p.sListProjectCenter];

            string sView = data.FirstChild.Attributes["View"].Value;
            SPView oView = oListTaskCenter.DefaultView;

            if (sView != "")
                oView = oListTaskCenter.Views[sView];

            XmlDocument docOut = new XmlDocument();
            docOut.LoadXml(Properties.Resources.txtFolderLayoutConfig);

            XmlNode ndCols = docOut.SelectSingleNode("//Cols");
            XmlNode ndHeader = docOut.SelectSingleNode("//Header");
            XmlNode ndDef = docOut.SelectSingleNode("//Def");

            ArrayList arrFields = new ArrayList();

            try
            {
                p.oFolderFields = oListTaskCenter.ContentTypes["WEFolder"].FieldLinks;
            }
            catch { }
            try
            {
                p.oTaskFields = oListTaskCenter.ContentTypes["Task"].FieldLinks;
            }
            catch { }

            DataSet dsResources = GetResourceTable(p, oListProjectCenter.ID, data.FirstChild.Attributes["ID"].Value, oWeb);

            foreach (SPField oTempField in oListTaskCenter.Fields)
            {
                SPField oField = getRealField(oTempField);

                if (!oField.Hidden && isValidField(oField.InternalName, false))
                {
                    processField(ref docOut, oField, ((oField.InternalName == "Title") ? "1" : "0"), ref ndCols, ref ndHeader, p, oWeb, dsResources);
                }
            }

            XmlNode ndTitle = docOut.SelectSingleNode("//C[@Name='Title']");

            XmlAttribute attr = docOut.CreateAttribute("RelWidth");
            attr.Value = "100";
            ndTitle.Attributes.Append(attr);

            ndTitle.Attributes.Remove(ndTitle.Attributes["Width"]);

            appendSpecialColumns(ref docOut, ref ndCols);
            addCalculations(p, ref docOut, ref ndDef, p.bAgile);

            return docOut.OuterXml;
        }

        public static string GetViews(XmlDocument data, SPWeb oWeb)
        {


            getSettings(oWeb, data.FirstChild.Attributes["Planner"].Value);

            XmlDocument docOut = new XmlDocument();
            docOut.LoadXml(Properties.Resources.txtViewsLayout);

            return docOut.OuterXml;
        }

        public static bool isValidField(string fieldname, bool isProjectCenter)
        {
            switch (fieldname)
            {
                case "ContentType":
                case "Modified":
                case "Created":
                case "Author":
                case "Editor":
                case "_UIVersionString":
                case "Attachments":
                case "Edit":
                case "ID":
                case "ItemChildCount":
                case "FolderChildCount":
                case "DocIcon":
                case "Def":
                case "Panel":
                case "Project":
                case "D":
                case "Detail":
                    return false;
                case "AssignedTo":
                    if (isProjectCenter)
                        return false;
                    else
                        return true;
            }
            return true;
        }

        public static string GetDetailLayout(XmlDocument data, SPWeb oWeb)
        {



            PlannerProps p = getSettings(oWeb, data.FirstChild.Attributes["Planner"].Value);

            XmlDocument docOut = new XmlDocument();
            docOut.LoadXml(Properties.Resources.txtDetailLayout);

            SPList oListTaskCenter = oWeb.Lists[p.sListTaskCenter];
            SPList oListProjectCenter = oWeb.Lists[p.sListProjectCenter];

            string sView = data.FirstChild.Attributes["View"].Value;
            SPView oView = oListTaskCenter.DefaultView;

            if (sView != "")
                oView = oListTaskCenter.Views[sView];

            XmlNode ndBody = docOut.SelectSingleNode("//B");

            DataSet dsResources = GetResourceTable(p, oListProjectCenter.ID, data.FirstChild.Attributes["ID"].Value, oWeb);

            foreach (SPField oField in oListTaskCenter.Fields)
            {
                if (!oField.Hidden && oField.Type != SPFieldType.Computed && isValidField(oField.InternalName, false) && oField.InternalName != "Notes")
                {
                    XmlNode ndNew = docOut.CreateNode(XmlNodeType.Element, "I", docOut.NamespaceURI);

                    XmlAttribute attr = docOut.CreateAttribute("id");
                    attr.Value = oField.InternalName;
                    ndNew.Attributes.Append(attr);

                    attr = docOut.CreateAttribute("N");
                    attr.Value = oField.Title;
                    ndNew.Attributes.Append(attr);

                    attr = docOut.CreateAttribute("V");
                    attr.Value = "";
                    ndNew.Attributes.Append(attr);

                    string canEdit = "1";

                    XmlDocument docF = new XmlDocument();
                    docF.LoadXml(oField.SchemaXml);
                    string sEditFormat = "";

                    string sFormat = getFormat(oField, docF, out sEditFormat, oWeb);


                    attr = docOut.CreateAttribute("VType");
                    attr.Value = GetFieldType(oField, docF, out canEdit);
                    ndNew.Attributes.Append(attr);

                    if (ReadOnlyField(oField, p))
                        canEdit = "0";

                    switch (oField.Type)
                    {
                        case SPFieldType.Choice:
                        case SPFieldType.Lookup:
                        case SPFieldType.MultiChoice:
                        case SPFieldType.User:
                            setEnumField(oField, ref ndNew, docF, docOut, oWeb, false, "V", dsResources);
                            break;
                    }

                    attr = docOut.CreateAttribute("CanEdit");
                    attr.Value = canEdit;
                    ndNew.Attributes.Append(attr);

                    if (sFormat != "")
                    {
                        attr = docOut.CreateAttribute("VFormat");
                        attr.Value = sFormat;
                        ndNew.Attributes.Append(attr);
                    }

                    if (sFormat != "")
                    {
                        attr = docOut.CreateAttribute("VEditFormat");
                        attr.Value = sEditFormat;
                        ndNew.Attributes.Append(attr);
                    }

                    attr = docOut.CreateAttribute("NoColorState");
                    attr.Value = "1";
                    ndNew.Attributes.Append(attr);


                    ndBody.AppendChild(ndNew);
                }
            }

            return docOut.OuterXml;
        }

        public static string getFieldValue(SPListItem li, SPField oField, DataSet dsResources)
        {
            string val = "";
            try
            {
                switch (oField.Type)
                {
                    case SPFieldType.DateTime:
                        try
                        {
                            val = DateTime.Parse(li[oField.Id].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        catch { }
                        break;
                    case SPFieldType.User:
                        SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(li.ParentList.ParentWeb, li[oField.Id].ToString());
                        foreach (SPFieldUserValue uv in uvc)
                        {
                            DataRow[] dr = dsResources.Tables[2].Select("SPAccountInfo = '" + uv.ToString() + "'");
                            if (dr.Length > 0)
                            {
                                val += ";" + dr[0]["ID"].ToString();
                            }
                        }
                        val = val.Trim(';');
                        break;
                    case SPFieldType.Note:
                        try
                        {
                            val = li[oField.Id].ToString();
                        }
                        catch { }
                        break;
                    case SPFieldType.Calculated:
                        SPFieldCalculated c = (SPFieldCalculated)oField;
                        switch (c.OutputType)
                        {
                            case SPFieldType.Number:
                            case SPFieldType.Currency:
                                val = li[oField.Id].ToString();
                                val = val.Replace(";#", "\n").Split('\n')[1];
                                break;
                            default:
                                val = oField.GetFieldValueAsText(li[oField.Id].ToString());
                                break;
                        };
                        break;
                    case SPFieldType.Number:
                        val = li[oField.Id].ToString();
                        SPFieldNumber oNum = (SPFieldNumber)oField;
                        if (oNum.ShowAsPercentage)
                        {
                            try
                            {
                                val = (float.Parse(val) * 100).ToString();
                            }
                            catch { }
                        }
                        break;
                    case SPFieldType.Currency:
                        val = li[oField.Id].ToString();
                        break;
                    case SPFieldType.Lookup:
                        try
                        {
                            SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(li[oField.Id].ToString());
                            foreach (SPFieldLookupValue uv in lvc)
                            {
                                val += ";" + uv.LookupId;
                            }
                            val = val.Trim(';');
                        }
                        catch { }
                        break;
                    case SPFieldType.Boolean:
                        try
                        {
                            if (li[oField.Id].ToString().ToLower() == "true")
                                val = "1";
                            else
                                val = "0";
                        }
                        catch { val = "0"; }
                        break;
                    default:
                        val = oField.GetFieldValueAsText(li[oField.Id].ToString());
                        break;

                };

                if (oField.Description == "Indicator")
                {
                    string url = li.ParentList.ParentWeb.ServerRelativeUrl;
                    val = "<img src=\"" + ((url == "/") ? "" : url) + "/_layouts/images/" + val + "\">";
                }
            }
            catch { }

            return val;
        }

        private static void SetupProjectCenterList(SPList oProjectCenter, string sPlanner)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(oProjectCenter.ParentWeb.Site.ID))
                {
                    using (SPWeb web = site.OpenWeb(oProjectCenter.ParentWeb.ID))
                    {
                        SPList oTempProjectCenter = web.Lists[oProjectCenter.ID];

                        if (!oTempProjectCenter.Fields.ContainsField(sPlanner + "FAC"))//DisableCalc
                        {
                            oTempProjectCenter.Fields.Add(sPlanner + "FAC", SPFieldType.Boolean, false);
                            SPField fld = oTempProjectCenter.Fields[sPlanner + "FAC"];
                            fld.Title = sPlanner + "FAC";
                            fld.Hidden = true;
                            fld.Sealed = true;
                            fld.Update();
                            oTempProjectCenter.Update();
                        }

                        if (!oTempProjectCenter.Fields.ContainsField(sPlanner + "FRL"))//RespectLinks
                        {
                            oTempProjectCenter.Fields.Add(sPlanner + "FRL", SPFieldType.Boolean, false);
                            SPField fld = oTempProjectCenter.Fields[sPlanner + "FRL"];
                            fld.Title = sPlanner + "FRL";
                            fld.Hidden = true;
                            fld.Sealed = true;
                            fld.Update();
                            oTempProjectCenter.Update();
                        }

                        if (!oTempProjectCenter.Fields.ContainsField(sPlanner + "FSC"))//SummaryRollup
                        {
                            oTempProjectCenter.Fields.Add(sPlanner + "FSC", SPFieldType.Boolean, false);
                            SPField fld = oTempProjectCenter.Fields[sPlanner + "FSC"];
                            fld.Title = sPlanner + "FSC";
                            fld.Hidden = true;
                            fld.Sealed = true;
                            fld.Update();
                            oTempProjectCenter.Update();
                        }

                        if (!oTempProjectCenter.Fields.ContainsField(sPlanner + "BD"))//BaselineDate
                        {
                            oTempProjectCenter.Fields.Add(sPlanner + "BD", SPFieldType.DateTime, false);
                            SPField fld = oTempProjectCenter.Fields[sPlanner + "BD"];
                            fld.Title = sPlanner + " Baseline Date";
                            fld.Hidden = false;
                            fld.Sealed = true;
                            fld.Update();
                            oTempProjectCenter.Update();
                        }
                    }
                }
            });
        }

        public static DataSet GetResourceTable(PlannerProps props, Guid listid, string itemid, SPWeb oWeb)
        {
            DataSet dsResources = new DataSet();

            //if(props.bUseTeam)
            //{
            StringReader sr = new StringReader(EPMLiveCore.WorkEngineAPI.GetTeam("<Team ListId='" + listid + "' ItemId='" + itemid + "'><Columns>Title</Columns></Team>", oWeb));
            dsResources.ReadXml(sr, XmlReadMode.Auto);
            //}
            //else
            //{
            //    StringReader sr = new StringReader(EPMLiveCore.WorkEngineAPI.GetTeam("<Team><Columns>Title</Columns></Team>", oWeb));
            //    dsResources.ReadXml(sr, XmlReadMode.Auto);
            //}

            return dsResources;
        }

        public static string GetProjectInfo(XmlDocument data, SPWeb oWeb)
        {


            string sPlanner = data.FirstChild.Attributes["Planner"].Value;

            PlannerProps p = getSettings(oWeb, sPlanner);

            XmlDocument docOut = new XmlDocument();
            docOut.LoadXml(Properties.Resources.txtProjectLayout);

            SPList oListProjectCenter = oWeb.Lists[p.sListProjectCenter];

            SetupProjectCenterList(oListProjectCenter, sPlanner);

            SPListItem liProject = oListProjectCenter.GetItemById(int.Parse(data.FirstChild.Attributes["ID"].Value));

            XmlNode ndBody = docOut.SelectSingleNode("//B");

            DataSet dsResources = GetResourceTable(p, oListProjectCenter.ID, data.FirstChild.Attributes["ID"].Value, oWeb);

            EPMLiveCore.GridGanttSettings gSettings = EPMLiveCore.API.ListCommands.GetGridGanttSettings(oListProjectCenter);

            Dictionary<string, Dictionary<string, string>> fieldProperties = EPMLiveCore.ListDisplayUtils.ConvertFromString(gSettings.DisplaySettings);

            foreach (SPField oField in oListProjectCenter.Fields)
            {
                if (!oField.Hidden && oField.Type != SPFieldType.Computed && isValidField(oField.InternalName, true))
                {
                    XmlNode ndNew = docOut.CreateNode(XmlNodeType.Element, "I", docOut.NamespaceURI);

                    XmlAttribute attr = docOut.CreateAttribute("id");
                    attr.Value = oField.InternalName;
                    ndNew.Attributes.Append(attr);

                    attr = docOut.CreateAttribute("N");
                    attr.Value = oField.Title;
                    ndNew.Attributes.Append(attr);

                    attr = docOut.CreateAttribute("V");
                    try
                    {
                        attr.Value = getFieldValue(liProject, oField, dsResources);
                    }
                    catch { }
                    ndNew.Attributes.Append(attr);

                    string canEdit = "1";

                    XmlDocument docF = new XmlDocument();
                    docF.LoadXml(oField.SchemaXml);

                    string sEditFormat = "";

                    string sFormat = getFormat(oField, docF, out sEditFormat, oWeb);


                    attr = docOut.CreateAttribute("VType");
                    attr.Value = GetFieldType(oField, docF, out canEdit);
                    ndNew.Attributes.Append(attr);

                    if (oField.InternalName == "Start")
                        canEdit = "0";

                    if (canEdit == "1")
                    {
                        if (!EPMLiveCore.EditableFieldDisplay.isEditable(liProject, oField, fieldProperties))
                            canEdit = "0";
                    }

                    attr = docOut.CreateAttribute("CanEdit");
                    attr.Value = canEdit;
                    ndNew.Attributes.Append(attr);

                    if (sFormat != "")
                    {
                        attr = docOut.CreateAttribute("VFormat");
                        attr.Value = sFormat;
                        ndNew.Attributes.Append(attr);
                    }

                    if (sEditFormat != "")
                    {
                        attr = docOut.CreateAttribute("VEditFormat");
                        attr.Value = sEditFormat;
                        ndNew.Attributes.Append(attr);
                    }


                    switch (oField.Type)
                    {
                        case SPFieldType.Choice:
                        case SPFieldType.Lookup:
                        case SPFieldType.MultiChoice:
                        case SPFieldType.User:
                            setEnumField(oField, ref ndNew, docF, docOut, oWeb, false, "V", dsResources);
                            break;
                    }

                    attr = docOut.CreateAttribute("NoColorState");
                    attr.Value = "1";
                    ndNew.Attributes.Append(attr);

                    ndBody.AppendChild(ndNew);
                }
            }

            return docOut.OuterXml;
        }

        public static void setEnumField(SPField oField, ref XmlNode ndCol, XmlDocument fieldDoc, XmlDocument docOut, SPWeb web, bool multi, string enumattr, DataSet dsResources)
        {

            try
            {
                XmlAttribute attr;
                attr = docOut.CreateAttribute(enumattr + "IconAlign");
                attr.Value = "Right";
                ndCol.Attributes.Append(attr);

                switch (oField.Type)
                {
                    case SPFieldType.Choice:
                        string sEnum = "";
                        XmlNode ndChoices = fieldDoc.SelectSingleNode("//CHOICES");
                        foreach (XmlNode ndChoice in ndChoices.ChildNodes)
                        {
                            sEnum += "|" + ndChoice.InnerText;
                        }
                        attr = docOut.CreateAttribute(enumattr + "Enum");
                        attr.Value = sEnum;
                        ndCol.Attributes.Append(attr);

                        break;
                    case SPFieldType.Lookup:
                        {
                            StringBuilder sbEnum = new StringBuilder();
                            StringBuilder sbEnumKeys = new StringBuilder();

                            if (oField.TypeAsString == "LookupMulti")
                            {
                                attr = docOut.CreateAttribute(enumattr + "Range");
                                attr.Value = "1";
                                ndCol.Attributes.Append(attr);
                            }

                            try
                            {
                                SPList lstLookup = web.Lists[new Guid(fieldDoc.FirstChild.Attributes["List"].Value)];

                                foreach (SPListItem li in lstLookup.Items)
                                {
                                    sbEnumKeys.Append("|");
                                    sbEnumKeys.Append(li.ID);
                                    sbEnum.Append("|");
                                    sbEnum.Append(li.Title);
                                }
                            }
                            catch { }

                            attr = docOut.CreateAttribute(enumattr + "Enum");
                            attr.Value = sbEnum.ToString();

                            ndCol.Attributes.Append(attr);

                            attr = docOut.CreateAttribute(enumattr + "EnumKeys");
                            attr.Value = sbEnumKeys.ToString();

                            ndCol.Attributes.Append(attr);
                        }
                        break;
                    case SPFieldType.MultiChoice:
                        string sEnum1 = "";
                        XmlNode ndChoices1 = fieldDoc.SelectSingleNode("//CHOICES");
                        foreach (XmlNode ndChoice in ndChoices1.ChildNodes)
                        {
                            sEnum1 += "|" + ndChoice.InnerText;
                        }

                        attr = docOut.CreateAttribute(enumattr + "Enum");
                        attr.Value = sEnum1;
                        ndCol.Attributes.Append(attr);


                        attr = docOut.CreateAttribute(enumattr + "Range");
                        attr.Value = "1";
                        ndCol.Attributes.Append(attr);

                        break;
                    case SPFieldType.User:
                        {
                            if (oField.TypeAsString == "UserMulti")
                            {
                                attr = docOut.CreateAttribute(enumattr + "Range");
                                attr.Value = "1";
                                ndCol.Attributes.Append(attr);
                            }

                            StringBuilder sbEnum = new StringBuilder();
                            StringBuilder sbEnumKeys = new StringBuilder();

                            foreach (DataRow dr in dsResources.Tables[2].Rows)
                            {
                                sbEnum.Append("|");
                                sbEnum.Append(dr["Title"].ToString());
                                sbEnumKeys.Append("|");
                                sbEnumKeys.Append(dr["ID"].ToString());
                            }

                            attr = docOut.CreateAttribute(enumattr + "Enum");
                            attr.Value = sbEnum.ToString();

                            ndCol.Attributes.Append(attr);

                            attr = docOut.CreateAttribute(enumattr + "EnumKeys");
                            attr.Value = sbEnumKeys.ToString();

                            ndCol.Attributes.Append(attr);

                        }
                        break;

                }
            }
            catch { }
        }

        public static string GetAssignmentLayout(XmlDocument data, SPWeb oWeb)
        {



            getSettings(oWeb, data.FirstChild.Attributes["Planner"].Value);

            XmlDocument docOut = new XmlDocument();
            docOut.LoadXml(Properties.Resources.txtResourcesLayout);


            return docOut.OuterXml;
        }

        public static string GetLinksLayout(XmlDocument data, SPWeb oWeb)
        {



            getSettings(oWeb, data.FirstChild.Attributes["Planner"].Value);

            XmlDocument docOut = new XmlDocument();
            docOut.LoadXml(Properties.Resources.txtLinksLayout);


            return docOut.OuterXml;
        }

        public static string GetAllocationLayout(XmlDocument data, SPWeb oWeb)
        {

            PlannerProps props = getSettings(oWeb, data.FirstChild.Attributes["Planner"].Value);

            XmlDocument docOut = new XmlDocument();
            docOut.LoadXml(Properties.Resources.txtAllocationGrid);

            XmlNode ndCols = docOut.FirstChild.SelectSingleNode("//Cols");

            if (ndCols == null) { }

            SPList resList = null;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    using (SPSite site = new SPSite(oWeb.Url))
                    {
                        using (SPWeb web = site.OpenWeb())
                        {
                            string resurl = EPMLiveCore.CoreFunctions.getLockConfigSetting(web, "EPMLiveResourceURL", true);
                            using (SPWeb newweb = site.OpenWeb(resurl))
                            {
                                //ProcessAllocationResourcesCols(ndCols, newweb);
                            }
                        }
                    }
                }
                catch { }
            });

            return docOut.OuterXml;
        }

        private static void ProcessAllocationResourcesCols(XmlNode ndCols, SPWeb oWeb)
        {

            SPList list = oWeb.Lists.TryGetList("Resources");
            if (list != null)
            {

                foreach (SPField oField in list.Fields)
                {
                    if (oField.Reorderable)
                    {

                        XmlNode ndCol = ndCols.OwnerDocument.CreateNode(XmlNodeType.Element, "C", ndCols.OwnerDocument.NamespaceURI);
                        XmlAttribute attr = ndCols.OwnerDocument.CreateAttribute("Name");
                        attr.Value = oField.InternalName;
                        ndCol.Attributes.Append(attr);

                        ndCols.AppendChild(ndCol);
                    }
                }

            }
        }

        public static string GetAddLinksLayout(XmlDocument data, SPWeb oWeb)
        {

            getSettings(oWeb, data.FirstChild.Attributes["Planner"].Value);

            XmlDocument docOut = new XmlDocument();
            docOut.LoadXml(Properties.Resources.txtAddLinksLayout);

            return docOut.OuterXml;
        }

        private static string getFormat(SPField oField, XmlDocument oDoc, out string EditFormat, SPWeb oWeb)
        {
            string format = "";
            EditFormat = "";
            switch (oField.Type)
            {
                case SPFieldType.DateTime:
                    try
                    {
                        if (oDoc.FirstChild.Attributes["Format"].Value == "DateOnly")
                        {
                            format = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        }
                        else
                        {
                            format = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FullDateTimePattern;
                        }
                    }
                    catch { }
                    EditFormat = format + " HH:mm";
                    break;
                case SPFieldType.Number:
                    if (oDoc.FirstChild.Attributes["Percentage"] != null && oDoc.FirstChild.Attributes["Percentage"].Value.ToLower() == "true")
                    {
                        format = "0\\%;;0\\%";
                    }
                    else
                    {
                        int decCount = 0;
                        string decimals = "";
                        try
                        {
                            decCount = int.Parse(oDoc.FirstChild.Attributes["Decimals"].Value);
                        }
                        catch { }

                        for (int i = 0; i < decCount; i++)
                        {
                            decimals += "0";
                        }

                        if (decCount > 0)
                            decimals = "." + decimals;

                        format = ",0" + decimals;
                        EditFormat = format;
                        break;
                    }
                    break;
                case SPFieldType.Currency:
                    format = oWeb.Locale.NumberFormat.CurrencySymbol + ",0.00";
                    EditFormat = ",0.00";
                    break;
                case SPFieldType.Calculated:
                    switch (oDoc.FirstChild.Attributes["ResultType"].Value)
                    {
                        case "Currency":
                            format = oWeb.Locale.NumberFormat.CurrencySymbol + ",0.00";
                            break;
                        case "Number":
                            int decCount = 0;
                            string decimals = "";
                            try
                            {
                                decCount = int.Parse(oDoc.FirstChild.Attributes["Decimals"].Value);
                            }
                            catch { }

                            for (int i = 0; i < decCount; i++)
                            {
                                decimals += "0";
                            }

                            if (decCount > 0)
                                decimals = "." + decimals;

                            format = ",0" + decimals;
                            break;
                    };
                    break;

            };

            return format;
        }

        private static bool ReadOnlyField(SPField oField, PlannerProps p)
        {
            switch (oField.InternalName)
            {
                case "ResourceNames":
                case "Summary":
                case "Critical":
                case "Descendants":
                case "Predecessors":
                case "IsAssignment":
                    return true;
                case "Cost":
                case "ActualCost":
                    if (p.bCalcCost)
                        return true;
                    else
                        return false;
            }
            return false;
        }

        private static string GetFieldType(SPField oField, XmlDocument docF, out string canEdit)
        {
            canEdit = "1";

            switch (oField.Type)
            {
                case SPFieldType.Text:
                    return "Text";
                case SPFieldType.Number:
                    return "Float";
                case SPFieldType.Currency:
                    return "Float";
                case SPFieldType.DateTime:
                    return "Date";
                case SPFieldType.Boolean:
                    return "Bool";
                case SPFieldType.Calculated:
                    canEdit = "0";
                    switch (docF.FirstChild.Attributes["ResultType"].Value)
                    {
                        case "Currency":
                        case "Number":
                            return "Float";
                    };
                    if (oField.Description == "Indicator")
                        return "Html";

                    return "Text";
                case SPFieldType.Choice:
                    return "Enum";
                case SPFieldType.Lookup:
                    return "Enum";
                case SPFieldType.MultiChoice:
                    return "Enum";

                case SPFieldType.Note:
                    //canEdit = "0";
                    return "Html";

                case SPFieldType.URL:
                    return "Link";
                case SPFieldType.User:
                    return "Enum";
                case SPFieldType.Invalid:
                    canEdit = "0";
                    return "Text";
            }
            return "Text";
        }

        private static XmlNode addFieldNodeToDef(ref XmlDocument docOut, string defName, string field)
        {
            XmlNode ndTask = docOut.CreateNode(XmlNodeType.Element, "D", docOut.NamespaceURI);
            XmlAttribute attr = docOut.CreateAttribute("Name");
            attr.Value = defName;
            ndTask.Attributes.Append(attr);

            attr = docOut.CreateAttribute(field + "CanEdit");
            attr.Value = "0";
            ndTask.Attributes.Append(attr);

            return ndTask;
        }

        private static bool isAssignmentField(string fieldname, PlannerProps p)
        {
            return p.StatusFields.Contains(fieldname);

            //switch(fieldname)
            //{
            //    case "PercentComplete":
            //    case "Work":
            //    case "ActualStart":
            //    case "ActualFinish":
            //    case "ActualWork":
            //    case "RemainingWork":
            //        return true;
            //};
            //return false;
        }

        private static void processIndividualField(ref XmlDocument docOut, SPField oField, XmlDocument docF, PlannerProps p)
        {
            string fieldname = oField.InternalName;
            XmlNode ndSummary = addFieldNodeToDef(ref docOut, "Summary", fieldname);
            XmlNode ndTask = addFieldNodeToDef(ref docOut, "Task", fieldname);
            XmlNode ndMilestone = addFieldNodeToDef(ref docOut, "Milestone", fieldname);
            XmlNode ndFolder = addFieldNodeToDef(ref docOut, "Folder", fieldname);
            XmlNode ndAssignment = addFieldNodeToDef(ref docOut, "Assignment", fieldname);
            XmlNode ndIteration = null;
            if (p.bAgile)
                ndIteration = addFieldNodeToDef(ref docOut, "Iteration", fieldname);


            bool inTask = false;
            bool inFolder = false;
            bool inSummary = false;
            bool inAssignment = false;
            bool inIteration = false;

            if (p.oTaskFields != null && p.oTaskFields[oField.Id] != null && !p.rolldowns.Contains(fieldname))
                inTask = true;

            if (p.oFolderFields != null && p.oFolderFields[oField.Id] != null && !p.rollups.Contains(fieldname))
                inFolder = true;

            if (p.oTaskFields != null && p.oTaskFields[oField.Id] != null && !p.rollups.Contains(fieldname) && !p.rolldowns.Contains(fieldname))
                inSummary = true;

            if (p.bAgile && p.oIterationFields != null && p.oIterationFields[oField.Id] != null)
                inIteration = true;

            if (inTask)
                inAssignment = isAssignmentField(fieldname, p);

            if (inSummary)
            {
                ndSummary.Attributes[fieldname + "CanEdit"].Value = "1";
            }
            if (inTask)
            {
                ndTask.Attributes[fieldname + "CanEdit"].Value = "1";
                ndMilestone.Attributes[fieldname + "CanEdit"].Value = "1";
            }
            if (inFolder)
            {
                ndFolder.Attributes[fieldname + "CanEdit"].Value = "1";
            }
            if (inAssignment)
            {
                ndAssignment.Attributes[fieldname + "CanEdit"].Value = "1";
            }

            if (ndIteration != null && inIteration)
            {
                ndIteration.Attributes[fieldname + "CanEdit"].Value = "1";
            }

            switch (oField.Type)
            {
                case SPFieldType.Text:
                    break;
                case SPFieldType.Number:
                    break;
                case SPFieldType.Currency:
                    break;
                case SPFieldType.DateTime:
                    break;
                case SPFieldType.Boolean:
                    break;
                case SPFieldType.Calculated:
                    break;
                case SPFieldType.Choice:
                    break;
                case SPFieldType.Lookup:
                    break;
                case SPFieldType.MultiChoice:
                    break;
                case SPFieldType.Note:
                    break;
                case SPFieldType.URL:
                    break;
                case SPFieldType.User:
                    break;
            }

            XmlNode ndDef = docOut.SelectSingleNode("//Def");
            ndDef.AppendChild(ndSummary);
            ndDef.AppendChild(ndTask);
            ndDef.AppendChild(ndMilestone);
            ndDef.AppendChild(ndAssignment);
            ndDef.AppendChild(ndFolder);
            if (ndIteration != null)
                ndDef.AppendChild(ndIteration);

        }

        private static void processField(ref XmlDocument docOut, SPField oField, string visible, ref XmlNode ndCols, ref XmlNode ndHeader, PlannerProps p, SPWeb web, DataSet dsResources)
        {


            XmlNode ndNew = docOut.CreateNode(XmlNodeType.Element, "C", docOut.NamespaceURI);
            XmlAttribute attr = docOut.CreateAttribute("Name");
            attr.Value = oField.InternalName;
            ndNew.Attributes.Append(attr);

            XmlDocument docF = new XmlDocument();
            docF.LoadXml(oField.SchemaXml);

            string oCanEdit = "1";
            string sWidth = "100";
            string sType = GetFieldType(oField, docF, out oCanEdit);

            if (ReadOnlyField(oField, p))
                oCanEdit = "0";

            string sFilter = "1";
            string sSort = "1";
            string sEditFormat = "";
            string sFormat = getFormat(oField, docF, out sEditFormat, web);

            if (oField.ReadOnlyField)
                oCanEdit = "0";

            if (oCanEdit == "1")
                processIndividualField(ref docOut, oField, docF, p);

            switch (oField.Type)
            {
                case SPFieldType.Text:
                    sWidth = "150";
                    break;
                case SPFieldType.Number:
                    attr = docOut.CreateAttribute("Align");
                    attr.Value = "Right";
                    ndNew.Attributes.Append(attr);
                    break;
                case SPFieldType.Currency:
                    break;
                case SPFieldType.DateTime:

                    break;
                case SPFieldType.Boolean:
                    break;
                case SPFieldType.Calculated:
                    var formula = docF.SelectSingleNode("//Formula").InnerText;
                    if (!formula.Contains("=IF(") && !formula.Contains("YEAR("))
                    {
                        attr = docOut.CreateAttribute("Formula");
                        attr.Value = formula.Substring(1);
                        ndNew.Attributes.Append(attr);
                    }
                    if (oField.Description == "Indicator")
                    {
                        attr = docOut.CreateAttribute("Align");
                        attr.Value = "Center";
                        ndNew.Attributes.Append(attr);
                    }
                    break;
                case SPFieldType.Choice:
                    sWidth = "150";
                    setEnumField(oField, ref ndNew, docF, docOut, web, false, "", dsResources);
                    break;
                case SPFieldType.Lookup:
                    setEnumField(oField, ref ndNew, docF, docOut, web, false, "", dsResources);
                    sWidth = "150";
                    break;
                case SPFieldType.MultiChoice:
                    setEnumField(oField, ref ndNew, docF, docOut, web, false, "", dsResources);
                    sWidth = "150";
                    break;
                case SPFieldType.Note:
                    sWidth = "200";
                    break;
                case SPFieldType.URL:
                    sWidth = "150";
                    break;
                case SPFieldType.User:
                    setEnumField(oField, ref ndNew, docF, docOut, web, false, "", dsResources);
                    sWidth = "150";
                    break;
            }

            if (oField.InternalName == "Title")
                sWidth = "200";

            attr = docOut.CreateAttribute("CanEdit");
            attr.Value = oCanEdit;
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Width");
            attr.Value = sWidth;
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Type");
            attr.Value = sType;
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("CanFilter");
            attr.Value = sFilter;
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("CanSort");
            attr.Value = sSort;
            ndNew.Attributes.Append(attr);

            attr = docOut.CreateAttribute("Visible");
            attr.Value = visible;
            ndNew.Attributes.Append(attr);

            if (sFormat != "")
            {
                attr = docOut.CreateAttribute("Format");
                attr.Value = sFormat;
                ndNew.Attributes.Append(attr);
            }

            if (sEditFormat != "")
            {
                attr = docOut.CreateAttribute("EditFormat");
                attr.Value = sEditFormat;
                ndNew.Attributes.Append(attr);
            }

            //if(oField.InternalName == "DueDate")
            //{
            //    attr = docOut.CreateAttribute("DatesEndLast");
            //    attr.Value = "0";
            //    ndNew.Attributes.Append(attr);

            //}

            /*if(oField.InternalName == "Predecessors")
            {
                attr = docOut.CreateAttribute("Button");
                attr.Value = "Defaults";
                ndNew.Attributes.Append(attr);

                attr = docOut.CreateAttribute("Range");
                attr.Value = "1";
                ndNew.Attributes.Append(attr);

                attr = docOut.CreateAttribute("Defaults");
                attr.Value = "|*RowsColid*VariableDef";
                ndNew.Attributes.Append(attr);
            }*/

            ndCols.AppendChild(ndNew);

            if (oField.InternalName == "Title")
                ndCols = docOut.SelectSingleNode("//Cols");

            attr = docOut.CreateAttribute(oField.InternalName);
            attr.Value = oField.Title;
            ndHeader.Attributes.Append(attr);
        }

        private static SPField getRealField(SPField field)
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

        /*public static string GetFolders(XmlDocument data, SPWeb oWeb)
        {
           

            getSettings(web);
            
            SPQuery query = new SPQuery();
            query.Query = "<Where><And><Eq><FieldRef Name='Project' LookupId='TRUE'/><Value Type='Lookup'>" + data.FirstChild.Attributes["ID"].Value + "</Value></Eq><Eq><FieldRef Name='ContentType'/><Value Type='String'>WEFolder</Value></Eq></And></Where>";
            query.ViewAttributes = "Scope=\"RecursiveAll\"";
            //query.ViewFields = "<FieldRef Name='Title'/><FieldRef Name='ParentFolder'/>";

            SPList oListTaskCenter = web.Lists[sListTaskCenter];

            SPListItemCollection lic = oListTaskCenter.GetItems(query);

            XmlDocument docOut = new XmlDocument();
            docOut.LoadXml("<Grid><Body><B><I id=\"0\" Folder=\"All Folders\"/></B></Body></Grid>");

            foreach(SPListItem li in lic)
            {
                XmlNode ndNew = docOut.CreateNode(XmlNodeType.Element, "I", docOut.NamespaceURI);
                XmlAttribute attr = docOut.CreateAttribute("id");
                attr.Value = li.Folder.UniqueId.ToString();
                ndNew.Attributes.Append(attr);

                attr = docOut.CreateAttribute("Folder");
                attr.Value = li.Title;
                ndNew.Attributes.Append(attr);

                attr = docOut.CreateAttribute("Path");
                attr.Value = li.Folder.Url;
                ndNew.Attributes.Append(attr);

                XmlNode nd = docOut.SelectSingleNode("//I[@id='" + li.Folder.ParentFolder.UniqueId.ToString() + "']");
                if(nd == null)
                {
                    docOut.FirstChild.FirstChild.FirstChild.FirstChild.AppendChild(ndNew);
                }
                else
                {
                    nd.AppendChild(ndNew);
                }
            }

            return docOut.OuterXml;


           

            getSettings(web);

            SPDocumentLibrary lib = (SPDocumentLibrary)web.Lists["Project Schedules"];

            try
            {
                SPFile file = lib.RootFolder.Files[data.FirstChild.Attributes["ID"].Value + "f.xml"];
                StreamReader reader = new StreamReader(file.OpenBinaryStream());
                return reader.ReadToEnd();
            }
            catch
            {
                return "<Grid><Body><B><I Def='Folder' Title='All Folders' id='0'/></B></Body></Grid>";
            }
        }*/

        public static string testFunction(XmlDocument data, SPWeb oWeb)
        {
            try
            {
                return "<Result Status=\"0\"><SPSite>" + oWeb.Site.ID + "</SPSite><SPWeb>" + oWeb.ID + "</SPWeb></Result>";
            }
            catch (Exception ex)
            {
                return "<Result Status=\"1\"><Error ID=\"1001\">Error: " + ex.Message + "</Error></Result>";
            }
        }

        public static PlannerProps getSettings(SPWeb web, string planner)
        {
            PlannerProps p = new PlannerProps();
            Guid lockWeb = EPMLiveCore.CoreFunctions.getLockedWeb(web);
            if (lockWeb == Guid.Empty || lockWeb == web.ID)
            {
                p.sListProjectCenter = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "ProjectCenter");
                p.sListTaskCenter = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "TaskCenter");
                p.sProjectField = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "PCField");
                p.sFieldMappings = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "FieldMappings");
                bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "UseFolders"), out p.bUseFolders);
                int.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "TaskType"), out p.iTaskType);
                //try
                //{
                //    useResourcePool = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveWPUseResPool"));
                //}
                //catch { }
                //sResourcePoolUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, false);
                //sResourceList = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourcePool");
                p.wpFields = new PlannerCore.WorkPlannerProperties(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "Fields"));
                p.StatusFields = PlannerCore.getFieldInfo(web, planner);
                int work = web.RegionalSettings.WorkDays;
                for (byte x = 0; x < 7; x++)
                {
                    p.sWorkDays = ((((work >> x) & 0x01) == 0x01) ? "1" : "0") + "," + p.sWorkDays;
                    //if(!(((work >> x) & 0x01) == 0x01))
                    //    nonwork++;
                }

                p.sWorkDays = p.sWorkDays.Trim(',');

                int lunchstart = 12;
                int lunchend = 13;

                try
                {
                    string sLe = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "LunchStart");
                    if (!string.IsNullOrEmpty(sLe))
                        lunchstart = int.Parse(sLe);
                }
                catch { }
                try
                {
                    string sLe = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "LunchEnd");
                    if (!string.IsNullOrEmpty(sLe))
                        lunchend = int.Parse(sLe);
                }
                catch { }

                p.iWorkHours[0] = web.RegionalSettings.WorkDayStartHour;
                p.iWorkHours[1] = lunchstart;
                p.iWorkHours[2] = lunchend;
                p.iWorkHours[3] = web.RegionalSettings.WorkDayEndHour;

                try
                {
                    SPList oList = web.Lists["Holidays"];
                    p.Holidays = oList.Items.GetDataTable();
                }
                catch { }
                bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "EnableAgile"), out p.bAgile);
                p.sIterationCT = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "AgileIterationField");
                bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "CalcWork"), out p.bCalcWork);
                bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "CalcCost"), out p.bCalcCost);
                bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "EnableLink"), out p.bEnableLinking);
                bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "StartSoon"), out p.bStartSoon);

                #region KanBan Props
                p.KanBanStatusColumn = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "KanBanStatusColumn");
                p.KanBanFilterColumn = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "KanBanFilterColumn");
                p.KanBanTitleColumn = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "KanBanTitleColumn");
                p.KanBanAdditionalColumns = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "KanBanAdditionalColumns");
                p.KanBanItemStatusFields = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "KanBanItemStatusFields");
                #endregion
            }
            else
            {
                SPSite site = web.Site;
                {
                    using (SPWeb w = site.OpenWeb(lockWeb))
                    {
                        p.sListProjectCenter = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePlanner" + planner + "ProjectCenter");
                        p.sListTaskCenter = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePlanner" + planner + "TaskCenter");
                        p.sProjectField = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePlanner" + planner + "PCField");
                        p.sFieldMappings = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePlanner" + planner + "FieldMappings");

                        bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePlanner" + planner + "UseFolders"), out p.bUseFolders);
                        int.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePlanner" + planner + "TaskType"), out p.iTaskType);


                        //try
                        //{
                        //    useResourcePool = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveWPUseResPool"));
                        //}
                        //catch { }
                        //sResourcePoolUrl = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveResourceURL", true, false);
                        //sResourceList = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveResourcePool");
                        p.wpFields = new PlannerCore.WorkPlannerProperties(EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePlanner" + planner + "Fields"));
                        p.StatusFields = PlannerCore.getFieldInfo(w, planner);

                        int work = w.RegionalSettings.WorkDays;
                        for (byte x = 0; x < 7; x++)
                        {
                            p.sWorkDays = ((((work >> x) & 0x01) == 0x01) ? "1" : "0") + "," + p.sWorkDays;
                            //if(!(((work >> x) & 0x01) == 0x01))
                            //    nonwork++;
                        }

                        p.sWorkDays = p.sWorkDays.Trim(',');

                        int lunchstart = 12;
                        int lunchend = 13;

                        try
                        {
                            string sLe = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePlanner" + planner + "LunchStart");
                            if (!string.IsNullOrEmpty(sLe))
                                lunchstart = int.Parse(sLe);
                        }
                        catch { }
                        try
                        {
                            string sLe = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePlanner" + planner + "LunchEnd");
                            if (!string.IsNullOrEmpty(sLe))
                                lunchend = int.Parse(sLe);
                        }
                        catch { }

                        p.iWorkHours[0] = w.RegionalSettings.WorkDayStartHour;
                        p.iWorkHours[1] = lunchstart;
                        p.iWorkHours[2] = lunchend;
                        p.iWorkHours[3] = w.RegionalSettings.WorkDayEndHour;



                        try
                        {
                            SPList oList = w.Lists["Holidays"];
                            p.Holidays = oList.Items.GetDataTable();
                        }
                        catch { };

                        bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePlanner" + planner + "EnableAgile"), out p.bAgile);
                        p.sIterationCT = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePlanner" + planner + "AgileIterationField");

                        bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePlanner" + planner + "CalcWork"), out p.bCalcWork);
                        bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePlanner" + planner + "CalcCost"), out p.bCalcCost);
                        bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePlanner" + planner + "EnableLink"), out p.bEnableLinking);
                        bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePlanner" + planner + "StartSoon"), out p.bStartSoon);
                    }


                }
            }

            for (int i = 0; i < p.wpFields.count(); i++)
            {
                PlannerCore.WorkPlannerProperty wp = p.wpFields.GetByIndex(i);

                if (wp.val == "RollDown")
                    p.rolldowns.Add(wp.field);
                else
                    p.rollups.Add(wp.field);
            }



            return p;
        }

        #region KanBanPlanner

        /// <summary>
        /// Get KanBan Planners
        /// </summary>
        /// <param name="data"></param>
        /// <param name="oWeb"></param>
        /// <returns></returns>
        public static string GetKanBanPlanners(XmlDocument data, SPWeb oWeb)
        {
            //Get values from parameter
            string siteUrl = data.GetElementsByTagName("SiteUrl")[0].InnerText;
            string siteId = data.GetElementsByTagName("SiteID")[0].InnerText;
            string webID = data.GetElementsByTagName("WebID")[0].InnerText;

            StringBuilder jsonPlanners = new StringBuilder();
            jsonPlanners.Append(string.Format("{{\"id\":\"{0}\",\"text\":\"{1}\"}},", "0", "Select"));

            //Using SharePoint Object Model fetching data values
            using (SPSite spSite = new SPSite(siteUrl))
            {
                using (SPWeb spWeb = spSite.OpenWeb(new Guid(webID)))
                {
                    string planners = EPMLiveCore.CoreFunctions.getConfigSetting(spWeb, "EPMLivePlannerPlanners");

                    foreach (string planner in planners.Split(','))
                    {
                        if (!String.IsNullOrEmpty(planner))
                        {
                            string[] sPlanner = planner.Split('|');
                            string kanban = EPMLiveCore.CoreFunctions.getConfigSetting(spWeb, "EPMLivePlanner" + sPlanner[0] + "EnableKanBan");

                            if (!string.IsNullOrEmpty(kanban) && Convert.ToBoolean(kanban))
                            {
                                jsonPlanners.Append(string.Format("{{\"id\":\"{0}\",\"text\":\"{1}\"}},", sPlanner[0], EncodeJsonData(sPlanner[1])));
                            }
                        }
                    }

                    string jsonData = jsonPlanners.ToString();
                    if (jsonData.Length > 1)
                    {
                        jsonData = jsonData.Substring(0, jsonData.Length - 1);
                    }
                    return string.Format("{{ \"kanbanplanners\": [{0}] }}", jsonData);
                }
            }
        }

        public static string GetKanBanFilter1(XmlDocument data, SPWeb oWeb)
        {
            //Get values from parameter...
            string siteUrl = data.GetElementsByTagName("SiteUrl")[0].InnerText;
            string siteId = data.GetElementsByTagName("SiteID")[0].InnerText;
            string webID = data.GetElementsByTagName("WebID")[0].InnerText;
            string kanBanBoardName = data.GetElementsByTagName("KanBanBoardName")[0].InnerText;
            //string projectID = data.GetElementsByTagName("ID")[0].InnerText;

            //Prepare Queries...
            string qryTableName = "SELECT TableName FROM RPTList WHERE RPTListID = '{0}'";
            string qryFilterColumns = "SELECT ColumnName, SharePointType FROM RPTColumn WHERE RPTListId = '{0}' and InternalName = '{1}'";
            string qryFilterColumnValues = "SELECT DISTINCT {0} FROM {1} WHERE WebId='{2}' AND ListId='{3}' ORDER BY {4}";

            StringBuilder jsonFilterColumnValues1 = new StringBuilder();
            string columnName = string.Empty;
            string tableName = string.Empty;
            bool isLookupOrUserField = false;

            WorkPlannerAPI.PlannerProps props = null;
            DataTable dtTableName = new DataTable();
            DataTable dtFilterColumns = new DataTable();
            DataTable dtFilterColumnValues = new DataTable();

            try
            {
                using (SPSite spSite = new SPSite(siteUrl))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(new Guid(webID)))
                    {
                        props = WorkPlannerAPI.getSettings(spWeb, kanBanBoardName);
                        SPList sourceList = spWeb.Lists[props.sListProjectCenter];

                        try
                        {
                            var queryExecutor = new QueryExecutor(spWeb);
                            dtTableName = queryExecutor.ExecuteReportingDBQuery(string.Format(qryTableName, sourceList.ID.ToString()),
                                new Dictionary<string, object>
                                {
                                    {"@WebId", webID}
                                });

                        }
                        catch { }

                        if (dtTableName != null && dtTableName.Rows.Count > 0)
                        {
                            tableName = Convert.ToString(dtTableName.Rows[0]["TableName"]);
                            try
                            {
                                var queryExecutor = new QueryExecutor(spWeb);
                                dtFilterColumns = queryExecutor.ExecuteReportingDBQuery(string.Format(qryFilterColumns, Convert.ToString(sourceList.ID), props.KanBanFilterColumn),
                                    new Dictionary<string, object>
                                {
                                    {"@WebId", webID}
                                });

                            }
                            catch { }

                            if (dtFilterColumns.Rows.Count > 0)
                            {
                                switch (Convert.ToString(dtFilterColumns.Rows[0]["SharePointType"]))
                                {
                                    case "User":
                                    case "Lookup":
                                        {
                                            columnName = "IsNull(" + Convert.ToString(dtFilterColumns.Rows[1]["ColumnName"]) + ",'(Blank)'), IsNull(" + Convert.ToString(dtFilterColumns.Rows[0]["ColumnName"] + ",'')");
                                            isLookupOrUserField = true;
                                        }
                                        break;
                                    case "Choice":
                                        columnName = "IsNull(" + Convert.ToString(dtFilterColumns.Rows[0]["ColumnName"]) + ",'(Blank)')";
                                        break;
                                }

                                try
                                {
                                    qryFilterColumnValues = string.Format(qryFilterColumnValues, columnName, tableName, spWeb.ID.ToString(), sourceList.ID.ToString(), columnName);
                                    var queryExecutor = new QueryExecutor(spWeb);
                                    dtFilterColumnValues = queryExecutor.ExecuteReportingDBQuery(qryFilterColumnValues,
                                        new Dictionary<string, object>
                                {
                                    {"@WebId", webID}
                                });

                                    if (dtFilterColumnValues != null && dtFilterColumnValues.Rows.Count > 0)
                                    {
                                        jsonFilterColumnValues1.Append(string.Format("{{\"id\":\"{0}\",\"text\":\"{1}\"}},", "0", "(All)"));
                                        for (int row = 0; row < dtFilterColumnValues.Rows.Count; row++)
                                        {
                                            if (isLookupOrUserField)
                                                jsonFilterColumnValues1.Append(string.Format("{{\"id\":\"{0}\",\"text\":\"{1}\"}},", EncodeJsonData(Convert.ToString(dtFilterColumnValues.Rows[row][0])), EncodeJsonData(Convert.ToString(dtFilterColumnValues.Rows[row][0]))));
                                            else
                                                jsonFilterColumnValues1.Append(string.Format("{{\"id\":\"{0}\",\"text\":\"{1}\"}},", EncodeJsonData(Convert.ToString(dtFilterColumnValues.Rows[row][0])), EncodeJsonData(Convert.ToString(dtFilterColumnValues.Rows[row][0]))));
                                        }
                                    }
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            //TODO: Display message that List {0} does not configure with Reporting database...
                        }
                    }
                }
            }
            catch { }
            string jsonData = jsonFilterColumnValues1.ToString();
            if (jsonData.Length > 1)
            {
                jsonData = jsonData.Substring(0, jsonData.Length - 1);
            }
            return string.Format("{{ \"kanbanfilter1name\": \"Select {0} :\", \"kanbanfilter1\": [{1}] }}", props.KanBanFilterColumn, jsonData);
        }

        public static string GetKanBanBoard(XmlDocument data, SPWeb oWeb)
        {
            #region Read Parameters from data Xml

            //Get values from parameter
            string siteUrl = data.GetElementsByTagName("SiteUrl")[0].InnerText;
            string siteId = data.GetElementsByTagName("SiteID")[0].InnerText;
            string webID = data.GetElementsByTagName("WebID")[0].InnerText;
            string kanBanBoardName = DecodeJsonData(data.GetElementsByTagName("KanBanBoardName")[0].InnerText);
            string kanBanFilterColumnSelectedValues = DecodeJsonData(data.GetElementsByTagName("KanBanFilter1")[0].InnerText);
            //string projectID = data.GetElementsByTagName("ID")[0].InnerText;

            bool isNullValueIncluded = kanBanFilterColumnSelectedValues.Contains("(Blank)");

            kanBanFilterColumnSelectedValues = kanBanFilterColumnSelectedValues.Replace("0,(Blank),", "");
            #endregion

            #region Variable Declaration

            bool splitterLoaded = false;
            StringBuilder sbItems = new StringBuilder();
            StringBuilder filterRecords = new StringBuilder();

            string tableName = string.Empty;
            string columnName = string.Empty;
            string filterColumnValues = string.Empty;
            string selectedColumns = string.Empty;
            string selectedColumnsDBFormat = string.Empty;
            string displayColumnsForSourceListData = string.Empty;

            string qryGetColumns = "SELECT ColumnName, SharePointType FROM RPTColumn WHERE InternalName IN({0}) AND RPTListId='{1}'";
            string qryFRFData = "SELECT * FROM FRF WHERE SITE_ID = '{0}' AND WEB_ID = '{1}' AND LIST_ID = '{2}' AND F_String = '{3}' ORDER BY ITEM_ID";

            DataTable dtSourceListData = new DataTable();
            DataTable dtColumns = new DataTable();
            DataTable dtFRFData = new DataTable();

            #endregion

            //Using SharePoint Object Model fetching data values
            using (SPSite spSite = new SPSite(siteUrl))
            {
                using (SPWeb spWeb = spSite.OpenWeb(new Guid(webID)))
                {
                    WorkPlannerAPI.PlannerProps props = WorkPlannerAPI.getSettings(spWeb, kanBanBoardName);

                    SPList list = spWeb.Lists[props.sListProjectCenter];

                    if (list != null)
                    {
                        SPField field = list.Fields.GetField(props.KanBanFilterColumn);

                        switch (field.Type)
                        {
                            case SPFieldType.User:
                            case SPFieldType.Lookup:
                                columnName = field.InternalName + "Text";
                                break;
                            default:
                                columnName = field.InternalName;
                                break;
                        }

                        selectedColumns += props.KanBanTitleColumn + ",ID,";
                        if (!string.IsNullOrEmpty(props.KanBanAdditionalColumns))
                            selectedColumns += props.KanBanAdditionalColumns;

                        selectedColumnsDBFormat = "'" + selectedColumns.Replace(",", "','") + "'";

                        try
                        {
                            //Title, Project, AssignedTo, Status => Title, ProjectID, ProjectText, AssignedToID, AssignedToText, Status
                            var queryExecutor = new QueryExecutor(spWeb);
                            dtColumns = queryExecutor.ExecuteReportingDBQuery(string.Format(qryGetColumns, selectedColumnsDBFormat, list.ID.ToString()),
                                new Dictionary<string, object>
                                {
                                    {"@WebId", webID}
                                });

                        }
                        catch { }

                        if (dtColumns != null && dtColumns.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtColumns.Rows.Count; i++)
                            {
                                string colName = Convert.ToString(dtColumns.Rows[i]["ColumnName"]);
                                string colType = Convert.ToString(dtColumns.Rows[i]["SharePointType"]);

                                if ((colType.ToLower().Equals("lookup") || colType.ToLower().Equals("user")) && colName.ToLower().EndsWith("id"))
                                {
                                    continue;
                                }
                                else
                                {
                                    displayColumnsForSourceListData += Convert.ToString(dtColumns.Rows[i]["ColumnName"]);
                                    if (i < dtColumns.Rows.Count - 1)
                                        displayColumnsForSourceListData += ",";
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(kanBanFilterColumnSelectedValues))
                        {
                            filterColumnValues = "'" + kanBanFilterColumnSelectedValues.Replace(",", "','") + "'";
                        }

                        if (!string.IsNullOrEmpty(filterColumnValues))
                        {
                            try
                            {
                                string qryWhereClause = string.Format(" {0} in ({1}) {2}", columnName, filterColumnValues, isNullValueIncluded ? " or " + columnName + " is null " : "");
                                dtSourceListData = EPMLiveCore.ReportingData.GetReportingData(spWeb, list.Title, false, qryWhereClause, props.KanBanStatusColumn);
                            }
                            catch { }

                            if (dtSourceListData != null && dtSourceListData.Rows.Count > 0)
                            {
                                DataColumn fIntDataColumn = new DataColumn("F_INT", typeof(Int32));
                                fIntDataColumn.DefaultValue = 0;
                                dtSourceListData.Columns.Add(fIntDataColumn);
                                //Insert/Update Record to FRF list...
                                using (SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(spWeb.Site.WebApplication.Id)))
                                {
                                    cn.Open();
                                    SqlCommand cmd = new SqlCommand(string.Format(qryFRFData, siteId, webID, list.ID.ToString(), kanBanBoardName), cn);
                                    using (SqlDataAdapter dap = new SqlDataAdapter(cmd))
                                    {
                                        dap.Fill(dtFRFData);
                                    }
                                }

                                if (dtFRFData != null && dtFRFData.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtSourceListData.Rows)
                                    {
                                        DataRow[] fIntDataRow = dtFRFData.Select("ITEM_ID = " + dr["ID"]);
                                        if (fIntDataRow != null && fIntDataRow.Length > 0)
                                        {
                                            dr["F_INT"] = fIntDataRow[0]["F_INT"];
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            return string.Empty;
                        }

                        DataRow[] dtSourceListDataRows = dtSourceListData.Select("", string.Format("{0},{1}", props.KanBanStatusColumn, "F_INT"));

                        if (dtSourceListDataRows != null && dtSourceListDataRows.Length > 0)
                        {
                            //Actual Logic Started...
                            sbItems.Append("<table>");
                            sbItems.Append("<tbody>");
                            sbItems.Append("<tr>");

                            sbItems.Append("<td>");
                            sbItems.Append("<div class='itemContainer'>"); //itemContainer <div> started
                            sbItems.Append("<div class='itemContainerTitle'>Backlog " + list.Title + " Items</div>"); //itemContainerTitle <div> completed
                            sbItems.Append("<div class='sortable-list' data-dragged-status='" + list.Title + "' id='" + list.Title.Replace(" ", "_") + "'>");

                            string selectedStatusColumnValues = EPMLiveCore.CoreFunctions.getConfigSetting(spWeb, "EPMLivePlanner" + kanBanBoardName + "KanBanItemStatusFields");

                            #region Load BackLog Status Items

                            foreach (DataRow row in dtSourceListDataRows)
                            {
                                string statusColumnValue = Convert.ToString(row[props.KanBanStatusColumn]);
                                if (string.IsNullOrEmpty(statusColumnValue) ||
                                    (!selectedStatusColumnValues.Contains(statusColumnValue))) //Add Backlog Items to Left Panel
                                {
                                    sbItems.Append("<div class='sortable-item' data-siteid='" + siteId + "' data-webid='" + webID + "' data-listid='" + list.ID + "' data-itemid='" + Convert.ToString(row["ID"]) + "' data-userid='0' data-itemtitle='" + Convert.ToString(row["Title"]) + "' data-icon='' data-type='50' data-fstring='" + kanBanBoardName + "' data-fdate='' data-fint='" + Convert.ToString(row["F_INT"]) + "' id='" + Convert.ToString(row["ID"]) + "'>"); //sortable-item <div> started
                                    sbItems.Append("<div style='float:right;'><ul style='margin: 0px; width: 20px;'><li class='associateditemscontextmenu'><a data-itemid='" + Convert.ToString(row["ID"]) + "' data-listid='" + list.ID.ToString() + "' data-webid='" + webID + "' data-siteid='" + siteId + "'></a></li></ul></div>");
                                    foreach (string column in displayColumnsForSourceListData.Split(','))
                                    {
                                        if (!string.IsNullOrEmpty(column))
                                        {
                                            sbItems.Append("<div>" + Convert.ToString(row[column]) + "&nbsp;</div>");
                                        }
                                    }
                                    sbItems.Append("</div>"); //sortable-item <div> completed
                                }
                            }

                            sbItems.Append("</div>"); //sortable-list <div> completed
                            sbItems.Append("</div>");//itemContainer <div> Completed
                            sbItems.Append("</td>");

                            #endregion

                            #region Load Stages

                            //Load All Stages - Based on Status Column Selection
                            string statusFieldName = EPMLiveCore.CoreFunctions.getConfigSetting(spWeb, "EPMLivePlanner" + kanBanBoardName + "KanBanStatusColumn");
                            SPFieldChoice choiceField = list.Fields.GetField(statusFieldName) as SPFieldChoice;
                            StringCollection statusValues = choiceField.Choices;

                            if (statusValues.Count > 0)
                            {
                                foreach (string status in statusValues)
                                {
                                    if (selectedStatusColumnValues.Contains(status))
                                    {
                                        sbItems.Append("<td>");
                                        sbItems.Append("<div class='stageContainer'>"); //stageContainer <div> started

                                        //Load Splitter...
                                        if (!splitterLoaded)
                                        {
                                            sbItems.Append("<div id='splitter'><<</div>");
                                            splitterLoaded = true;
                                        }

                                        sbItems.Append("<div class='stageContainerTitle'>" + status + "</div>");
                                        sbItems.Append("<div class='sortable-list' data-dragged-status='" + status + "' id='" + status.Replace(" ", "_") + "'>");

                                        foreach (DataRow row in dtSourceListDataRows)
                                        {
                                            string currentProcessingStatus = Convert.ToString(row[statusFieldName]);
                                            if (currentProcessingStatus.Equals(status, StringComparison.InvariantCultureIgnoreCase))
                                            {
                                                sbItems.Append("<div class='sortable-item' data-siteid='" + siteId + "' data-webid='" + webID + "' data-listid='" + list.ID + "' data-itemid='" + Convert.ToString(row["ID"]) + "' data-userid='0' data-itemtitle='" + Convert.ToString(row["Title"]) + "' data-icon='' data-type='50' data-fstring='" + kanBanBoardName + "' data-fdate='' data-fint='" + Convert.ToString(row["F_INT"]) + "' id='" + Convert.ToString(row["ID"]) + "'>"); //sortable-item <div> started
                                                sbItems.Append("<div style='float:right;'><ul style='margin: 0px; width: 20px;'><li class='associateditemscontextmenu'><a data-itemid='" + Convert.ToString(row["ID"]) + "' data-listid='" + list.ID.ToString() + "' data-webid='" + webID + "' data-siteid='" + siteId + "'></a></li></ul></div>");

                                                foreach (string column in displayColumnsForSourceListData.Split(','))
                                                {
                                                    if (!string.IsNullOrEmpty(column))
                                                    {
                                                        sbItems.Append("<div>" + Convert.ToString(row[column]) + "&nbsp;</div>");
                                                    }
                                                }
                                                sbItems.Append("</div>");//sortable-item <div> Completed
                                            }
                                        }

                                        sbItems.Append("</div>"); //sortable-list <div> completed
                                        sbItems.Append("</div>"); //stageContainer <div> completed
                                        sbItems.Append("</td>");
                                    }
                                }
                            }

                            sbItems.Append("</tr>");
                            sbItems.Append("</tbody>");
                            sbItems.Append("</table>");

                            #endregion
                        }
                    }
                }
            }
            return sbItems.ToString();
        }

        private static string EncodeJsonData(string data)
        {
            return System.Web.HttpUtility.HtmlEncode(data.Replace("\\", "\\\\"));
        }

        private static string DecodeJsonData(string data)
        {
            return System.Web.HttpUtility.HtmlDecode(data.Replace("\\\\", "\\"));
        }

        public static string ReOrderAndSaveItem(XmlDocument data, SPWeb oWeb)
        {
            const Int32 USER_ID = 0;
            const Int32 TYPE = 50;

            //Get values from parameter
            string siteId = data.GetElementsByTagName("data-siteid")[0].InnerText;
            string webId = data.GetElementsByTagName("data-webid")[0].InnerText;
            string listId = data.GetElementsByTagName("data-listid")[0].InnerText;
            string itemId = data.GetElementsByTagName("data-itemid")[0].InnerText;
            string userId = data.GetElementsByTagName("data-userid")[0].InnerText;
            string itemTitle = data.GetElementsByTagName("data-itemtitle")[0].InnerText;
            string icon = data.GetElementsByTagName("data-icon")[0].InnerText;
            string type = data.GetElementsByTagName("data-type")[0].InnerText;
            string fString = data.GetElementsByTagName("data-fstring")[0].InnerText; //Name of the Board
            string fDate = data.GetElementsByTagName("data-fdate")[0].InnerText;
            Int32 fInt = Convert.ToInt32(data.GetElementsByTagName("data-fint")[0].InnerText);
            string draggedStatus = data.GetElementsByTagName("data-dragged-status")[0].InnerText;
            Int32 dataIndexOfItem = Convert.ToInt32(data.GetElementsByTagName("data-index-of-item")[0].InnerText);

            using (SPSite site = new SPSite(new Guid(siteId)))
            {
                using (SPWeb web = site.OpenWeb(new Guid(webId)))
                {
                    //Update status to SharePoint list...
                    WorkPlannerAPI.PlannerProps props = WorkPlannerAPI.getSettings(web, fString);
                    web.AllowUnsafeUpdates = true;
                    SPList list = web.Lists[new Guid(listId)];
                    SPListItem item = list.GetItemById(Convert.ToInt32(itemId));
                    if (item != null)
                    {
                        if (list.Title.Equals(draggedStatus, StringComparison.InvariantCultureIgnoreCase))
                            item[props.KanBanStatusColumn] = string.Empty;
                        else
                            item[props.KanBanStatusColumn] = draggedStatus;
                        try
                        {
                            item.Update();
                        }
                        catch { }
                    }
                    web.AllowUnsafeUpdates = false;

                    //Insert/Update Record to FRF list...
                    using (SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id)))
                    {
                        cn.Open();

                        //Replace userId and Type fields after words...
                        string frfInsertUpdate = @"IF NOT EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteId AND [WEB_ID]=@webId AND [LIST_ID]=@listId AND [ITEM_ID]=@itemId AND [USER_ID]=@userId AND [Type]=@type)
                        BEGIN
	                        INSERT INTO FRF ([SITE_ID],[WEB_ID],[LIST_ID],[ITEM_ID],[USER_ID],[Title],[Icon],[Type],[F_String],[F_Date],[F_Int])
                                    VALUES (@siteId, @webId, @listId, @itemId, @userId, @title, @icon, @type, @fString, @fDate, @dataIndexOfItem)
                        END
                        ELSE 
                        BEGIN
                            UPDATE FRF SET 
                            [F_Int] = [F_Int] + 1 
                            WHERE [SITE_ID]=@siteId AND [WEB_ID]=@webId AND [LIST_ID]=@listId AND [USER_ID]=@userId AND [Type]=@type AND [F_Int] >= @dataIndexOfItem AND [F_Int] <= @fInt 

                            UPDATE FRF SET 
                            [Title] = @title, 
                            [F_Int] = @dataIndexOfItem 
                            WHERE [SITE_ID]=@siteId AND [WEB_ID]=@webId AND [LIST_ID]=@listId AND [ITEM_ID]=@itemId AND [USER_ID]=@userId AND [Type]=@type 
                        END";

                        SqlCommand cmd = new SqlCommand(frfInsertUpdate, cn);
                        cmd.Parameters.AddWithValue("@siteId", siteId);
                        cmd.Parameters.AddWithValue("@webId", webId);
                        cmd.Parameters.AddWithValue("@listId", listId);
                        cmd.Parameters.AddWithValue("@itemId", itemId);
                        cmd.Parameters.AddWithValue("@userId", USER_ID);
                        cmd.Parameters.AddWithValue("@title", itemTitle);
                        cmd.Parameters.AddWithValue("@icon", icon);
                        cmd.Parameters.AddWithValue("@type", TYPE);
                        cmd.Parameters.AddWithValue("@fString", fString);
                        cmd.Parameters.AddWithValue("@fDate", fDate);
                        cmd.Parameters.AddWithValue("@dataIndexOfItem", dataIndexOfItem);
                        cmd.Parameters.AddWithValue("@fInt", fInt);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            Thread.Sleep(2000);
            return string.Empty;
        }

        #endregion
    }
}