using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Reflection;
using Microsoft.SharePoint;
using EPMLiveCore.API;
using PortfolioEngineCore;

namespace WorkEnginePPM
{
    /// <summary>
    /// Summary description for EditCosts
    /// </summary>
    [WebService(Namespace = "PortfolioEngine")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class RPEditor : System.Web.Services.WebService
    {
        internal class RPException : Exception
        {

            public RPException(int exceptionNumber, string message)
                : base(message)
            {
                ExceptionNumber = exceptionNumber;
            }
            public int ExceptionNumber { get; set; }
        }

        private static string basePath;
        private static string ppmId;
        private static string ppmCompany;
        private static string ppmDbConn;
        private static string username;
        private static SecurityLevels securityLevel;
        
        /// <summary>
        /// Gets the costtype ids and names associated with a view
        /// </summary>
        /// <param name="sXML"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string CheckStatus(string sXML)
        {
            return "ping";
        }

        [WebMethod(EnableSession = true)]
        public string Execute(string Function, string Dataxml)
        {
            string sStage;
            if (WebAdmin.AuthenticateUserAndProduct(Context, out sStage) == true)
            {
                try
                {
                    Assembly assemblyInstance = Assembly.GetExecutingAssembly();
                    Type thisClass = assemblyInstance.GetType("WorkEnginePPM.RPEditor", true, true);
                    MethodInfo m = thisClass.GetMethod(Function);
                    object result = m.Invoke(null, new object[] { Context, Dataxml });
                    return result.ToString();
                }
                catch (Exception ex)
                {
                    return HandleError("Execute", 99999, string.Format("Error executing function: {0}; message : {1}", Function, ex.Message));
                }
            }
            return HandleError("Execute", 99999, string.Format("PfE User Authentication Failed. Stage: {0}", sStage));
        }

        [WebMethod(EnableSession = true)]
        public string ExecuteJSON(string Function, string Dataxml)
        {
            string sReply;
            try
            {
                sReply = Execute(Function, Dataxml);
            }
            catch (Exception ex)
            {
                sReply = HandleError("ExecuteJSON", 99999, string.Format("Error executing function: {0}", ex.Message));
            }

            return CStruct.ConvertXMLToJSON(sReply);
        }

        [PublicAPI(true)]
        [Description("General Entry point for Resource Plan Editor")]
        public static string ResourcePlans(HttpContext Context, string sXML)
        {
            string sReply;
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            ResourcePlans rp = new ResourcePlans(sBaseInfo);
            try
            {
                rp.HandleRequest(sXML, out sReply);

                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sXML) == true)
                {
                    string sFunction = xExecute.GetStringAttr("Function");

                    if (sFunction == "SaveResourcePlan")
                    {
                         ProcessAnyNotifications(sBaseInfo);
                    }
               }
            }
            catch (Exception ex)
            {
                sReply = HandleException("ResourcePlans", 99999, ex);
            }
            return sReply;
        }

        [PublicAPI(true)]
        [Description("General Entry point for Admin Functions")]
        public static string AdminFunctions(HttpContext Context, string sXML)
        {
            string sReply;
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            AdminFunctions pec = new AdminFunctions(sBaseInfo);
            try
            {
                if (pec.HandleRequest(sXML, out sReply) != true)
                {
                    sReply = HandleError("AdminFunctions", pec.Status, pec.FormatErrorText());
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("AdminFunctions", 99999, ex);
            }
            return sReply;
        }

        private static string GetFirstItemFromList(ref string sList)
        {
            string s;
            string[] sSeps = { "," };
            string[] sArr = sList.Split(sSeps, 2, StringSplitOptions.None);
            if (sArr.GetLength(0) > 1)
            {
                s = sArr[0];
                sList = sArr[1];
            }
            else
            {
                s = sList;
                sList = "";
            }
            return s;
        }

        private static int GetFirstIDFromList(ref string sList)
        {
            string s = GetFirstItemFromList(ref sList);
            int result;
            if (Int32.TryParse(s, out result))
                return result;
            return 0;
        }

        [PublicAPI(true)]
        [Description("Entry point for General Functions")]
        public static string GeneralFunctions(HttpContext Context, string sXML)
        {
            string sReply = "";
            try
            {
                string sDBConnect = WebAdmin.GetConnectionString(Context);
                DBAccess dba = new DBAccess(sDBConnect);
                if (dba.Open() != StatusEnum.rsSuccess)
                {
                    return HandleError("GeneralFunctions0", (int)dba.Status, dba.FormatErrorText());
                }
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sXML) != true)
                    return HandleError("GeneralFunctions1", (int)dba.Status, dba.FormatErrorText());

                string sFunction = xExecute.GetStringAttr("Function");
                switch (sFunction)
                {
                    case "CreateTicket":
                    {
                        //CStruct xTicket = xExecute.GetSubStruct("CreateTicket");
                        string sGuid = dbaGeneral.CreateTicket(dba, xExecute.GetString("Data"));

                        CStruct xReply = BuildResultXML(sFunction, (int)dba.Status);
                        xReply.CreateStringAttr("Context", xExecute.GetStringAttr("Context"));
                        xReply.CreateStringAttr("Ticket", sGuid);
                        sReply = xReply.XML();
                        break;
                    }
                    case "SynchronizeTeam":
                    {
                        CStruct xSynchronizeTeam = xExecute.GetSubStruct("SynchronizeTeam");
                        string projectids = xSynchronizeTeam.GetStringAttr("Project_UIDs");

                        while (projectids != "")
                        {
                            int projectid = GetFirstIDFromList(ref projectids);
                            string sXMLRequest;
                            if (dbaUsers.ExportPIInfo(dba, projectid.ToString("0"), out sXMLRequest) !=
                                StatusEnum.rsSuccess)
                                return HandleError("GeneralFunctions2", (int) dba.Status, dba.FormatErrorText());

                            XmlNode xNode;
                            if (SendXMLToWorkEngine(dba, "UpdateItems", sXMLRequest, out xNode) != StatusEnum.rsSuccess)
                                return HandleError("GeneralFunctions3", (int) dba.Status, dba.FormatErrorText());

                            if (xNode == null || xNode.OuterXml == "")
                            {
                                dba.Status = (StatusEnum) 99835;
                                dba.StatusText = "No response from WorkEngine WebService";
                                return HandleError("GeneralFunctions4", (int) dba.Status, dba.FormatErrorText());
                            }

                            CStruct xResult = new CStruct();
                            if (xResult.LoadXML(xNode.OuterXml) == false)
                            {
                                dba.Status = (StatusEnum) 99834;
                                dba.StatusText = "Invalid XML response from WorkEngine WebService";
                                return HandleError("GeneralFunctions5", (int) dba.Status, dba.FormatErrorText());
                            }

                            if (xResult.GetIntAttr("Status") != 0)
                            {
                                CStruct xError = xResult.GetSubStruct("Error");
                                if (xError != null)
                                {
                                    string sError = xError.GetStringAttr("ID") + " : " + xError.GetString("");
                                    dba.Status = (StatusEnum) 99833;
                                    dba.StatusText = "Invalid XML response from WorkEngine WebService. Status=" +
                                                     xResult.GetStringAttr("Status") + "; Error=" + sError;
                                    return HandleError("GeneralFunctions6", (int) dba.Status, dba.FormatErrorText());
                                }
                                CStruct xItem = xResult.GetSubStruct("Item");
                                if (xItem != null)
                                {
                                    string sError = xItem.GetStringAttr("Error") + " : " + xItem.GetString("");
                                    dba.Status = (StatusEnum) 99999;
                                    dba.StatusText = "Invalid XML response from WorkEngine WebService. Status=" +
                                                        xResult.GetStringAttr("Status") + "; Error=" + sError;
                                    return HandleError("GeneralFunctions7", (int)dba.Status, dba.FormatErrorText());
                                }
                                dba.Status = (StatusEnum) 99999;
                                dba.StatusText = "XML response from WorkEngine WebService not recognized";
                                return HandleError("GeneralFunctions8", (int)dba.Status, dba.FormatErrorText());
                            }
                        }

                        string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                        projectids = xSynchronizeTeam.GetStringAttr("Project_UIDs");
                        ResourcePlans rp = new ResourcePlans(sBaseInfo);
                        rp.PostCostValues(projectids);

                        CStruct xReply = BuildResultXML(sFunction, (int) dba.Status);
                        sReply = xReply.XML();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("GeneralFunctions9", 99999, ex);
            }
            return sReply;
        }

        private static StatusEnum SendXMLToWorkEngine(DBAccess dba, string sContext, string sXMLRequest, out XmlNode xNode)
        {
            xNode = null;
            try
            {
                Integration weInt = new Integration();
                dba.DBTrace(dba.Status, TraceChannelEnum.WebServices, "RPEditor.SendXMLToWorkEngine", "WE Request", "Context=" + sContext, sXMLRequest);
                xNode = weInt.execute(sContext, sXMLRequest);
                if (xNode != null)
                    dba.DBTrace(dba.Status, TraceChannelEnum.WebServices, "RPEditor.SendXMLToWorkEngine", "WE Reply", "Context=" + sContext, xNode.OuterXml);
            }
            catch (Exception ex)
            {
                dba.Status = (StatusEnum)99830;
                dba.StatusText = ex.Message;
                dba.StackTrace = ex.StackTrace;
                dba.DBTrace(dba.Status, TraceChannelEnum.WebServices, "RPEditor.SendXMLToWorkEngine", "Exception", ex.Message, ex.StackTrace);
            }
            return dba.Status;
        }

        private static void ProcessAnyNotifications(string sBaseInfo)
        {
            string sStage = "";
            try
            {
                string sendtousers = "";

                string siteRoot = SPContext.Current.Web.Url;

                string surl = ""; 
                
                WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn,
                                            out securityLevel);

                PortfolioEngineCore.ResourcePlanNotifications rpn =
                    new PortfolioEngineCore.ResourcePlanNotifications(sBaseInfo);

                string sXML = rpn.GetRPENotifcations();

                if (sXML == "")
                    return;

                CStruct xRoot = new CStruct();
                sStage = "1";
                if (xRoot.LoadXML(sXML) == true)
                {

                    Dictionary<int, RPEN_Project> pilist = new Dictionary<int, RPEN_Project>();
                    Dictionary<int, RPEN_Resource> reslist = new Dictionary<int, RPEN_Resource>();
                    Dictionary<int, RPEN_Delegate> deptdllglist = new Dictionary<int, RPEN_Delegate>();
                    Dictionary<int, RPEN_Delegate> pmdllglist = new Dictionary<int, RPEN_Delegate>();
                    Dictionary<int, RPEN_Depts> deptlist = new Dictionary<int, RPEN_Depts>();
                    Dictionary<Guid, RPEN_CMT> cmtlist = new Dictionary<Guid, RPEN_CMT>();

                    int thisuser = xRoot.GetIntAttr("ThisUser");

                    List<CStruct> rpens = xRoot.GetList("RPEN");
                    List<CStruct> rpenress = xRoot.GetList("RES");
                    List<CStruct> rpenpis = xRoot.GetList("PROJECT");
                    List<CStruct> rpendeptdels = xRoot.GetList("DEPTDEL");
                    List<CStruct> rpenspmdelss = xRoot.GetList("PMDEL");
                    List<CStruct> rpendepts = xRoot.GetList("DEPT");
                    List<CStruct> rpencmts = xRoot.GetList("CMT");

                    RPEN_Resource thisres = null;


                    foreach (CStruct oNode in rpenress)
                    {
                        RPEN_Resource rpenres = new RPEN_Resource();

                        rpenres.id = oNode.GetIntAttr("WRES");
                        rpenres.extid = oNode.GetStringAttr("ResExtID");
                        rpenres.Name = oNode.GetStringAttr("Name");
                        rpenres.NTacct = oNode.GetStringAttr("ResNT");
                        // John - Is this correct. I was going to replace with line below but not sure if that is correct either
                        rpenres.eMail = oNode.GetStringAttr("ResExtID");
                        //rpenres.eMail = oNode.GetStringAttr("WResEmail");

                        reslist.Add(rpenres.id, rpenres);

                        if (rpenres.id == thisuser) 
                            thisres = rpenres;
                    }
                    sStage = "2";

                    foreach (CStruct oNode in rpendepts)
                    {
                        int dept = oNode.GetIntAttr("Dept");
                        int wres = oNode.GetIntAttr("WRES");

                        RPEN_Depts rpedept;


                        if (deptlist.TryGetValue(dept, out rpedept) == false)
                        {
                            rpedept = new RPEN_Depts();
                            rpedept.dept_code = dept;
                            deptlist.Add(dept, rpedept);
                        }

                        RPEN_Resource rpendm;

                        if (rpedept.dept_mgrs.TryGetValue(wres, out rpendm) == false)
                        {
                            if (reslist.TryGetValue(wres, out rpendm))
                                rpedept.dept_mgrs.Add(wres, rpendm);
                        }
                    }

                    sStage = "3";


                    foreach (CStruct oNode in rpendeptdels)
                    {
                        int wres = oNode.GetIntAttr("WRES");
                        int surr = oNode.GetIntAttr("DELG");

                        RPEN_Delegate rpendlg;

                        if (deptdllglist.TryGetValue(wres, out rpendlg) == false)
                        {
                            rpendlg = new RPEN_Delegate();
                            rpendlg.wres_id = wres;
                            reslist.TryGetValue(wres, out rpendlg.wres_res);
                            deptdllglist.Add(wres, rpendlg);
                        }

                        RPEN_Resource rpensurr;

                        if (rpendlg.wres_delg.TryGetValue(surr, out rpensurr) == false)
                        {
                            if (reslist.TryGetValue(surr, out rpensurr))
                                rpendlg.wres_delg.Add(surr, rpensurr);
                        }

                    }
                    sStage = "4";

                    foreach (CStruct oNode in rpenspmdelss)
                    {
                        int wres = oNode.GetIntAttr("WRES");
                        int surr = oNode.GetIntAttr("DELG");

                        RPEN_Delegate rpendlg;

                        if (pmdllglist.TryGetValue(wres, out rpendlg) == false)
                        {
                            rpendlg = new RPEN_Delegate();
                            rpendlg.wres_id = wres;
                            reslist.TryGetValue(wres, out rpendlg.wres_res);
                            pmdllglist.Add(wres, rpendlg);
                        }

                        RPEN_Resource rpensurr;

                        if (rpendlg.wres_delg.TryGetValue(surr, out rpensurr) == false)
                        {
                            if (reslist.TryGetValue(surr, out rpensurr))
                                rpendlg.wres_delg.Add(surr, rpensurr);
                        }

                    }
                    sStage = "5";

                    foreach (CStruct oNode in rpenpis)
                    {
                        RPEN_Project rpenpi = new RPEN_Project();

                        rpenpi.PID = oNode.GetIntAttr("PID");
                        rpenpi.PMid = oNode.GetIntAttr("PM");
                        rpenpi.extid = oNode.GetStringAttr("EXTUID");
                        rpenpi.Name = oNode.GetStringAttr("Name");

                        if (pmdllglist.TryGetValue(rpenpi.PMid, out rpenpi.PMdlg) == false)
                        {
                            rpenpi.PMdlg = new RPEN_Delegate();
                            rpenpi.PMdlg.wres_id = rpenpi.PMid;
                            reslist.TryGetValue(rpenpi.PMid, out rpenpi.PMdlg.wres_res);
                            pmdllglist.Add(rpenpi.PMid, rpenpi.PMdlg);
                        }

                        pilist.Add(rpenpi.PID, rpenpi);
                    }
                    sStage = "6";

                    foreach (CStruct oNode in rpencmts)
                    {
                        RPEN_CMT rpen_cmt = new RPEN_CMT();

                        rpen_cmt.UID = oNode.GetIntAttr("UID");
                        rpen_cmt.Res = oNode.GetIntAttr("WRES");
                        rpen_cmt.pendingres = oNode.GetIntAttr("WRESPend");
                        rpen_cmt.enteredbyres = oNode.GetIntAttr("EnteredBy");
                        rpen_cmt.cmtGuid = oNode.GetGuidAttr("GUID");


                        rpen_cmt.dept = oNode.GetIntAttr("Dept");

                        deptlist.TryGetValue(rpen_cmt.dept, out rpen_cmt.dept_cls);

                        cmtlist.Add(rpen_cmt.cmtGuid, rpen_cmt);
                    }

                    sStage = "7";

                    foreach (CStruct oNode in rpens)
                    {
                        RPEN_NoteEntry rpen = new RPEN_NoteEntry();

                        rpen.UID = oNode.GetIntAttr("UID");
                        rpen.PID = oNode.GetIntAttr("PID");
                        rpen.cmtGuid = oNode.GetGuidAttr("GUID");

                        rpen.resID = oNode.GetIntAttr("WRESID");
                        rpen.title = oNode.GetStringAttr("TITLE");
                        rpen.html = oNode.GetStringAttr("HTML");
                        rpen.context = oNode.GetIntAttr("ECONTEXT");

                        rpen.resName = oNode.GetStringAttr("WResName");
                        rpen.resNTAcctount = oNode.GetStringAttr("WResNT");
                        rpen.resEmail = oNode.GetStringAttr("WResEmail");
                        rpen.resExtUID = oNode.GetStringAttr("WResExtUID");

                        pilist.TryGetValue(rpen.PID, out rpen.project);
                        cmtlist.TryGetValue(rpen.cmtGuid, out rpen.cmt);

                        if (rpen.project != null)
                            rpen.project.notes.Add(rpen);

                        if (rpen.cmt != null)
                            rpen.cmt.notes.Add(rpen);

                    }
                    sStage = "8";

                    string curuser = username;

                    if (thisres != null)
                        curuser = thisres.Name;
                        
                    string rmdata = "";
                    bool bHadPINote;

                    RPEN_CMT ocmt;
                    RPEN_Depts odept;
                    RPEN_Resource otempres;

                    Dictionary<int, RPEN_Resource> rmlist = new Dictionary<int, RPEN_Resource>();
                    foreach (RPEN_Depts xdept in deptlist.Values)
                    {
                        string s_reslist = "";
                        rmdata = "";
                        rmlist = new Dictionary<int, RPEN_Resource>();
 

                        foreach (RPEN_Project opi in pilist.Values)
                        {


                            bHadPINote = false;

                            foreach (RPEN_NoteEntry onote in opi.notes)
                            {
                                ocmt = onote.cmt;
                                odept = ocmt.dept_cls;

                                if (xdept.dept_code == odept.dept_code)
                                {

                                    switch (onote.context)
                                    {
                                        case 11:
                                        case 15:
                                        case 16:
                                        case 17:
                                        case 41:
                                        case 21:
                                        case 32:
                                        case 33:
                                        case 34:
                                        case 42:
                                            if (bHadPINote == false)
                                            {

                                                if (rmdata != "")
                                                    rmdata += "</table>";


                                                rmdata +=
                                                    "<table style='FONT-FAMILY: Segoe UI, Segoe, Helvetica; COLOR: #666666; FONT-SIZE: 14px'>";
                                                rmdata += "<tr>";
                                                rmdata += "<td style='text-decoration:underline;'>" + opi.Name + "</td>";
                                                rmdata += "</tr>";
                                                bHadPINote = true;
                                            }


                                            rmdata += "<tr>";
                                            rmdata += "<td  style='padding-left:20px;'>" + onote.title + "</td>";
                                            rmdata += "</tr>";


                                            int tres = ocmt.Res;

                                            if (tres == 0)
                                                tres = ocmt.pendingres;

                                            if (reslist.TryGetValue(tres, out otempres) == true)
                                            {
                                                //if (otempres.extid != "")
                                                //{
                                                //    if (s_reslist == "")
                                                //        s_reslist = otempres.extid;
                                                //    else
                                                //    {
                                                //        string xtmep = "," + s_reslist + ",";
                                                //        if (xtmep.IndexOf("," + otempres.extid + ",") == -1)
                                                //            s_reslist += "," + otempres.extid;
                                                //    }

                                                //}
                                                // John: Jason/Jeremy wants wresids passed in rather than ext ids - CRL 12/12/12
                                                if (otempres.id != 0)
                                                {
                                                    if (s_reslist == "")
                                                        s_reslist = otempres.id.ToString();
                                                    else
                                                    {
                                                        string xtmep = "," + s_reslist + ",";
                                                        if (xtmep.IndexOf("," + otempres.id.ToString() + ",") == -1)
                                                            s_reslist += "," + otempres.id.ToString();
                                                    }

                                                }

                                            }

                                            break;

                                    }
                                }



                            }
                        }

                        sStage = "9";


                        if (rmdata != "")
                        {
                            rmdata += "</table>";
                            rmlist = new Dictionary<int, RPEN_Resource>();

                            if (xdept != null)
                            {
                                if (xdept.dept_mgrs != null)
                                {

                                    foreach (RPEN_Resource ores in xdept.dept_mgrs.Values)
                                    {
                                        RPEN_Delegate ordel;
                                        if (rmlist.TryGetValue(ores.id, out otempres) == false)
                                        {
                                            rmlist.Add(ores.id, ores); // biuld up list of dept managers   

                                            if (deptdllglist.TryGetValue(ores.id, out ordel) == true)
                                            {
                                                if (ordel.wres_delg != null)
                                                {
                                                    foreach (RPEN_Resource xres in ordel.wres_delg.Values)
                                                    {
                                                        if (rmlist.TryGetValue(xres.id, out otempres) == false)
                                                            rmlist.Add(xres.id, xres);
                                                        // biuld up list of dept managers delegate  
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                            sStage = "10";
                            sendtousers = "";

                            foreach (RPEN_Resource xres in rmlist.Values)
                            {
                                // John: Jason/Jeremy wants wresids passed in rather than ext ids - CRL 12/12/12
                                //if (sendtousers == "")
                                //    sendtousers = xres.extid;
                                //else
                                //{
                                //    sendtousers += "," + xres.extid;
                                //}
                                if (sendtousers == "")
                                    sendtousers = xres.id.ToString();
                                else
                                {
                                    sendtousers += "," + xres.id.ToString();
                                }
                            }


                            s_reslist = rpn.CreateTicket(s_reslist);

                            surl = "/ppm/rpeditor.aspx?dataid=" + s_reslist + "&isresource=1&IsDlg=0";

                            sStage = "11";

                            QueueItemMessage(12, "", "RM Message", curuser, rmdata, sendtousers, siteRoot,
                                                surl);

                          
                        }
                    }

                    foreach (RPEN_Project opi in pilist.Values)
                    {
                        string pmdata = "";

 
                        Dictionary<int, RPEN_Resource> pmlist = new Dictionary<int, RPEN_Resource>();



                        string s_pilist = "";

                        
                        
                        foreach (RPEN_NoteEntry onote in opi.notes)
                        {
                            ocmt = onote.cmt;
                            odept = ocmt.dept_cls;

                            switch (onote.context)
                            {
                                case 12:
                                case 13:
                                case 14:
                                case 22:
                                case 23:
                                case 24:
                                case 31:
                                case 43:
                                    if (pmdata == "")
                                    {
                                        pmdata = "<table style='FONT-FAMILY: Segoe UI, Segoe, Helvetica; COLOR: #666666; FONT-SIZE: 14px'>";
                                        pmdata += "<tr>";
                                        pmdata += "<td style='text-decoration:underline;'>" + opi.Name + "</td>";
                                        pmdata += "</tr>";


                                        otempres = opi.PMdlg.wres_res;

                                        if (otempres != null)
                                            pmlist.Add(otempres.id, otempres);

                                        foreach (RPEN_Resource xtempres in opi.PMdlg.wres_delg.Values)
                                        {
                                            pmlist.Add(xtempres.id, xtempres);
                                        }

                                    }

                                    pmdata += "<tr>";
                                    pmdata += "<td  style='padding-left:20px;'>" +  onote.title + "</td>";
                                    pmdata += "</tr>";

                                    break;


        
                            }
                        }

                        sStage = "12";

                        sendtousers = "";

                        sStage = "121";
                        if (pmdata != "")
                        {
                            pmdata += "</table>";
                            foreach (RPEN_Resource xres in pmlist.Values)
                            {
                                // John: Jason/Jeremy wants wresids passed in rather than ext ids - CRL 12/12/12
                                //if (sendtousers == "")
                                //    sendtousers = xres.extid;
                                //else
                                //{
                                //    sendtousers += "," + xres.extid;
                                //}
                                if (sendtousers == "")
                                    sendtousers = xres.id.ToString();
                                else
                                {
                                    sendtousers += "," + xres.id.ToString();
                                }
                            }


                            s_pilist = rpn.CreateTicket(opi.extid);
                            surl = "/ppm/rpeditor.aspx?dataid=" + s_pilist + "&isresource=0&IsDlg=0";
                            
                            //if (opi.extid != "")
                            //{
                            //    string[] extids = opi.extid.Split('.');

                            //    if (extids.Length >= 3)
                            //    {
                            //        surl = "/epmlive/workplanner.aspx?listid=" + extids[1];
                            //    }
                            //}
                            sStage = "13";
                            QueueItemMessage(13, opi.extid, "PM Message", curuser, pmdata, sendtousers, siteRoot, surl);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new RPException(0, "ProcessAnyNotifications:" + sStage + ":" + ex.Message);
            }
        }

        private static string QueueItemMessage(int templateID, string project_extuid, string title, string curuser, string sbdy, string sendto, string surl, string editorurl)
        {
            try
            { 

                CStruct xRoot = new CStruct();
                xRoot.Initialize("QueueItem");

                xRoot.CreateIntAttr("TemplateID", templateID);

                if (project_extuid != "")
                {
                    string[] extids = project_extuid.Split('.');

                    if (extids.Length >= 3)
                    {
                        xRoot.CreateStringAttr("ListID", extids[1]);
                        xRoot.CreateStringAttr("ItemID", extids[2]);
                        xRoot.CreateStringAttr("WebID", extids[0]);
                    }
                }

                // these used to be createbooleanattrs but that places a value of 0 or 1 in the xml and epmlive uses bool.Parse on the value which 
                //  requires a string value of true or false to correctly parse 

                xRoot.CreateStringAttr("HideFromUser", "True");
                xRoot.CreateStringAttr("DoNotEmail", "False");
                xRoot.CreateStringAttr("UnMarkRead", "False");
                xRoot.CreateStringAttr("ForceNewEntry", "True");
                xRoot.CreateStringAttr("NewUsers", sendto);
                xRoot.CreateStringAttr("ExternalColumn", "EXTID");


               
                CStruct xParams = xRoot.CreateSubStruct("Params");
                CStruct xParam = xParams.CreateSubStruct("Param");
                xParam.CreateStringAttr("Name","Title");
                xParam.GetXMLNode().InnerText  = title;

                xParam = xParams.CreateSubStruct("Param");
                xParam.CreateStringAttr("Name", "EditorUser_Name");
                xParam.GetXMLNode().InnerText = curuser;

                xParam = xParams.CreateSubStruct("Param");
                xParam.CreateStringAttr("Name", "CommitmentBody");
                xParam.GetXMLNode().InnerText = sbdy;

                // John: Jason says that "SiteUrl" is already used and that you should use a different tag name here and in your templates. CRL
                xParam = xParams.CreateSubStruct("Param");
                xParam.CreateStringAttr("Name", "SiteUrl");
                xParam.GetXMLNode().InnerText = surl;


                // append the editor component

                xParam = xParams.CreateSubStruct("Param");
                xParam.CreateStringAttr("Name", "EditorUrl");
                xParam.GetXMLNode().InnerText = editorurl;
               

                
                using (SPWeb oWeb = SPContext.Current.Web)
                {
                    try
                    {
                        return APIEmail.QueueItemMessageXml(xRoot.XML(), oWeb);
                    }

                    catch (Exception ex)
                    {
                        string errmsg = ex.Message;
                        string errsource = ex.Source;
                        string errstack = ex.StackTrace;

                        return "";
                    }
                    
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private static CStruct BuildResultXML(string sFunction, int nStatus = 0, string sStatus = "")
        {
            CStruct xResult = new CStruct();
            xResult.Initialize("Result");
            xResult.CreateStringAttr("Function", sFunction);
            xResult.CreateIntAttr("Status", nStatus);
            if (sStatus != "")
                xResult.CreateStringAttr("Message", sStatus);
            return xResult;
        }

        private static string HandleError(string sFunction, int nStatus, string sError)
        {
            CStruct xResult = BuildResultXML(sFunction, nStatus);
            CStruct xGrid = xResult.CreateSubStruct("Grid");
            CStruct xIO = xGrid.CreateSubStruct("IO");
            xIO.CreateIntAttr("Result", 0);
            xIO.CreateStringAttr("Message", sError);
            CStruct xError = xResult.CreateSubStruct("Error");
            //xError.Value = sError;
            xError.CreateIntAttr("ID", nStatus);
            xError.CreateStringAttr("Value", sError);
            CStruct xCfg = xGrid.CreateSubStruct("Cfg");
            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            CStruct xBody = xGrid.CreateSubStruct("Body");
            return xResult.XML();
        }

        private static string HandleException(string sFunction, int nStatus, Exception ex)
        {
            return HandleError(sFunction, nStatus, "Exception in RPEditor.asmx : '" + ex.Message.ToString() + "'");
        }

        #region Nested type: PublicAPI

        public class PublicAPI : Attribute
        {
            // positional parameters
            public PublicAPI(bool isPublic)
            {
                IsPublic = isPublic;
            }

            // property for named parameter
            public bool IsPublic { get; set; }
        }

        #endregion
    }
}

