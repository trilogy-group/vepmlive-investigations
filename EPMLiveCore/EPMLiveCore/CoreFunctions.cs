using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.Win32;
using System.IO;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;

using System.Xml;

using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;

using System.DirectoryServices;
using System.Text.RegularExpressions;

namespace EPMLiveCore
{

    public enum EPMLiveFeatureList { GridGantt, ResourcePlanner, WorkPlanner, Charting };

    public class UserLevels
    {
        private Dictionary<int, UserLevel> levels = new Dictionary<int, UserLevel>();

        public UserLevels()
        {
            levels.Add(0, GetUserLevel("No Access", 0, new int[] { }));
            levels.Add(1, GetUserLevel("Team Members", 1, new int[] { 0, 3, 4, 8 }));
            levels.Add(2, GetUserLevel("Project Manager", 2, new int[] { 0, 1, 2, 3, 4, 5, 6, 8, 9 }));
            levels.Add(3, GetUserLevel("Full User", 3, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }));

        }

        public UserLevel GetById(int id)
        {
            return levels[id];
        }

        public int Count()
        {
            return levels.Count;
        }

        public IEnumerator<KeyValuePair<int, UserLevel>> GetEnumerator()
        {
            return levels.GetEnumerator();
        }

        private UserLevel GetUserLevel(string name, int id, int[] levels)
        {
            UserLevel l = new UserLevel();
            l.name = name;
            l.id = id;
            l.levels = levels;
            return l;
        }
    }

    public class UserLevel
    {
        public string name;
        public int id;
        public int[] levels;
    }

    public class ResourceStrings
    {
        private Hashtable hshResources = new Hashtable();
        private bool validLanguage = false;
        private string strError = "";
        public ResourceStrings(EPMLiveFeatureList feature, string lcid)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                Assembly assm = Assembly.GetExecutingAssembly();
                Stream stream = assm.GetManifestResourceStream("EPMLiveCore.LanguageFiles." + feature.ToString() + lcid + ".xml");
                if (stream == null)
                {
                    stream = assm.GetManifestResourceStream("EPMLiveCore.LanguageFiles." + feature.ToString() + "1033.xml");
                }
                StreamReader sr = new StreamReader(stream);
                doc.LoadXml(sr.ReadToEnd());
                foreach (XmlNode nd in doc.SelectNodes("/strings/string"))
                {
                    hshResources.Add(nd.Attributes["id"].Value, nd.InnerText);
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
        }

        public string getLCName()
        {
            try
            {

            }
            catch { }
            return "Unknown Language";
        }

        public string lastError
        {
            get
            {
                return strError;
            }
        }

        public bool isValidLanguage
        {
            get
            {
                return validLanguage;
            }
        }

        public string getSetting(string resourceName)
        {
            try
            {
                return hshResources[resourceName].ToString();
            }
            catch
            {

            }
            return "";
        }
    }

    public enum QueueType { ResPlan = 1, TimeFix, Notifications, AdminListSynch, ReportingCleanup, ReportingSettings, AdminTemplateSynch, ReportingSnapshot }

    public class PlannerDefinition
    {
        public string title;
        public string image;
        public bool enabled;
        public string command;
        public string description;
        public int displaytype;
        public string commandPrefix;
    }

    public class CoreFunctions
    {
        static string saltValue = "f53fNDH@";
        static string hashAlgorithm = "SHA1";
        static int passwordIterations = 2;
        static string initVector = "77B2c3D4e1F3g7R1";
        static int keySize = 256;

        private static PlannerDefinition CreatePlannerDef(string title, string image, bool enabled, string command, string description, int displaytype, string commandPrefix)
        {
            PlannerDefinition def = new PlannerDefinition();

            def.title = title;
            def.image = image;
            def.enabled = enabled;
            def.command = command;
            def.description = description;
            def.displaytype = displaytype;
            def.commandPrefix = commandPrefix;

            return def;
        }

        public static SPEventReceiverType iGetListEventType(string type)
        {
            switch (type)
            {
                case "ItemAdding":
                    return SPEventReceiverType.ItemAdding;
                case "ItemUpdating":
                    return SPEventReceiverType.ItemUpdating;
                case "ItemDeleting":
                    return SPEventReceiverType.ItemDeleting;
                case "ItemCheckingIn":
                    return SPEventReceiverType.ItemCheckingIn;
                case "ItemCheckingOut":
                    return SPEventReceiverType.ItemCheckingOut;
                case "ItemUncheckingOut":
                    return SPEventReceiverType.ItemUncheckingOut;
                case "ItemAttachmentDeleting":
                    return SPEventReceiverType.ItemAttachmentDeleting;
                case "ItemFileMoving":
                    return SPEventReceiverType.ItemFileMoving;
                case "FieldAdding":
                    return SPEventReceiverType.FieldAdding;
                case "FieldUpdating":
                    return SPEventReceiverType.FieldUpdating;
                case "FieldDeleting":
                    return SPEventReceiverType.FieldDeleting;
                case "ListAdding":
                    return SPEventReceiverType.ListAdding;
                case "ListDeleting":
                    return SPEventReceiverType.ListDeleting;
                case "SiteDeleting":
                    return SPEventReceiverType.SiteDeleting;
                case "WebDeleting":
                    return SPEventReceiverType.WebDeleting;
                case "WebMoving":
                    return SPEventReceiverType.WebMoving;
                case "WebAdding":
                    return SPEventReceiverType.WebAdding;
                case "WorkflowStarting":
                    return SPEventReceiverType.WorkflowStarting;
                case "ItemAdded":
                    return SPEventReceiverType.ItemAdded;
                case "ItemUpdated":
                    return SPEventReceiverType.ItemUpdated;
                case "ItemDeleted":
                    return SPEventReceiverType.ItemDeleted;
                case "ItemCheckedIn":
                    return SPEventReceiverType.ItemCheckedIn;
                case "ItemCheckedOut":
                    return SPEventReceiverType.ItemCheckedOut;
                case "ItemUncheckedOut":
                    return SPEventReceiverType.ItemUncheckedOut;
                case "ItemAttachmentAdded":
                    return SPEventReceiverType.ItemAttachmentAdded;
                case "ItemAttachmentDeleted":
                    return SPEventReceiverType.ItemAttachmentDeleted;
                case "ItemFileMoved":
                    return SPEventReceiverType.ItemFileMoved;
                case "ItemFileConverted":
                    return SPEventReceiverType.ItemFileConverted;
                case "FieldAdded":
                    return SPEventReceiverType.FieldAdded;
                case "FieldUpdated":
                    return SPEventReceiverType.FieldUpdated;
                case "FieldDeleted":
                    return SPEventReceiverType.FieldDeleted;
                case "ListAdded":
                    return SPEventReceiverType.ListAdded;
                case "ListDeleted":
                    return SPEventReceiverType.ListDeleted;
                case "SiteDeleted":
                    return SPEventReceiverType.SiteDeleted;
                case "WebDeleted":
                    return SPEventReceiverType.WebDeleted;
                case "WebMoved":
                    return SPEventReceiverType.WebMoved;
                case "WebProvisioned":
                    return SPEventReceiverType.WebProvisioned;
                case "WorkflowStarted":
                    return SPEventReceiverType.WorkflowStarted;
                case "WorkflowPostponed":
                    return SPEventReceiverType.WorkflowPostponed;
                case "WorkflowCompleted":
                    return SPEventReceiverType.WorkflowCompleted;
                case "EmailReceived":
                    return SPEventReceiverType.EmailReceived;
                case "ContextEvent":
                    return SPEventReceiverType.ContextEvent;
                default:
                    return SPEventReceiverType.InvalidReceiver;
            }
        }

        private static Dictionary<string, PlannerDefinition> iGetPlannerList(SPWeb lweb, SPWeb web, SPListItem li)
        {
            Dictionary<string, PlannerDefinition> pList = new Dictionary<string, PlannerDefinition>();

            try
            {
                if (li == null)
                {
                    string planners = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLivePlannerPlanners");

                    bool bDisableProject = false;
                    bool bDisablePlan = false;

                    bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveDisablePublishing"), out bDisableProject);
                    bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveDisablePlanners"), out bDisablePlan);

                    bool foundpj = false;

                    foreach (string planner in planners.Split(','))
                    {
                        if (!String.IsNullOrEmpty(planner))
                        {

                            string[] sPlanner = planner.Split('|');
                            string tc = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLivePlanner" + sPlanner[0] + "TaskCenter");
                            string pc = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLivePlanner" + sPlanner[0] + "ProjectCenter");
                            string desc = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLivePlanner" + sPlanner[0] + "Description");

                            bool canProject = false;
                            bool canOnline = false;

                            if (EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLivePlanner" + sPlanner[0] + "EnableOnline") == "")
                                canOnline = true;
                            else
                                bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLivePlanner" + sPlanner[0] + "EnableOnline"), out canOnline);

                            if (!canOnline)
                                bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLivePlanner" + sPlanner[0] + "EnableKanban"), out canOnline);

                            bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLivePlanner" + sPlanner[0] + "EnableProject"), out canProject);

                            if ((!bDisablePlan && canOnline) || (!bDisableProject && canProject))
                            {
                                if (canProject)
                                    foundpj = true;

                                SPList oPC = web.Lists.TryGetList(pc);
                                SPList oTC = web.Lists.TryGetList(tc);

                                if (oPC != null && oTC != null)
                                {
                                    pList.Add(sPlanner[0], CreatePlannerDef(sPlanner[1], "/_layouts/epmlive/images/planner16.png", true, oTC.Title, desc, 1, oPC.Title));
                                }
                            }
                        }
                    }

                    if (!foundpj)
                    {
                        if (lweb.Lists.TryGetList("Planner Templates") == null)
                        {
                            pList.Add("MPP", CreatePlannerDef("Microsoft Office Project", "/_layouts/epmlive/images/planner16.png", true, "Task Center", "", 1, "Project Center"));
                        }
                    }

                    if (!bDisablePlan)
                    {
                        if (web.Site.Features[new Guid("91f0c887-2db2-44b2-b15c-47c69809c767")] != null)
                        {
                            bool enableWP = false;
                            string spc = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveWPProjectCenter");
                            string stc = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveWPTaskCenter");
                            try
                            {
                                enableWP = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveWPEnable"));
                            }
                            catch { }
                            SPList oPC = web.Lists.TryGetList(spc);
                            SPList oTC = web.Lists.TryGetList(stc);
                            if (enableWP && oPC != null && oTC != null)
                            {
                                pList.Add("WorkEngineWorkPlanner", CreatePlannerDef("Work Planner", "/_layouts/epmlive/images/planner16.png", true, oTC.Title, "WorkEngine Work Planner", 3, oPC.Title));
                            }
                        }
                        //================Old Agile planner===============
                        {
                            bool enableAgile = false;
                            string spca = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveAgileProjectCenter");
                            string stca = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveAgileTaskCenter");
                            try
                            {
                                enableAgile = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveAgileEnable"));
                            }
                            catch { }

                            SPList oPC = web.Lists.TryGetList(spca);
                            SPList oTC = web.Lists.TryGetList(stca);
                            if (enableAgile && oPC != null && oTC != null)
                            {
                                pList.Add("WorkEngineAgilePlanner", CreatePlannerDef("Agile Planner", "/_layouts/epmlive/images/planner16.png", true, oTC.Title, "WorkEngine Agile Planner", 3, oPC.Title));
                            }
                        }
                    }

                    bool disableProject = false;
                    bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveDisablePublishing"), out disableProject);

                    if (!disableProject)
                    {
                        string pubPC = EPMLiveCore.CoreFunctions.getLockConfigSetting(web, "epmlivepub-pc", false);
                        string pubTC = EPMLiveCore.CoreFunctions.getLockConfigSetting(web, "epmlivepub-tc", false);
                        bool foundmpp = false;
                        SPList oPC = web.Lists.TryGetList(pubPC);
                        SPList oTC = web.Lists.TryGetList(pubTC);
                        if (oPC != null && oTC != null)
                        {
                            try
                            {
                                SPDocumentLibrary lib = (SPDocumentLibrary)web.Lists["Project Schedules"];
                                if (lib != null)
                                {
                                    if (lib.ContentTypesEnabled)
                                    {
                                        foreach (SPContentType ct in lib.ContentTypes)
                                        {
                                            string template = ct.DocumentTemplateUrl;
                                            if (template.Substring(template.Length - 3, 3) == "mpp")
                                            {
                                                foundmpp = true;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        string template = lib.DocumentTemplateUrl;
                                        if (template.Substring(template.Length - 3, 3) == "mpp")
                                        {
                                            foundmpp = true;
                                        }
                                    }
                                }
                            }
                            catch { }
                            if (foundmpp)
                            {
                                pList.Add("EditInMicrosoftProject", CreatePlannerDef("Microsoft Project", "/_layouts/images/Project2007LogoSmall.gif", true, oTC.Title, "Edit Schedule in Microsoft Office Project", 2, oPC.Title));
                            }
                        }
                    }
                }
                else
                {


                    SPList list = li.ParentList;

                    string planners = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLivePlannerPlanners");

                    bool bDisableProject = false;
                    bool bDisablePlan = false;

                    bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveDisablePublishing"), out bDisableProject);
                    bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveDisablePlanners"), out bDisablePlan);

                    bool foundpj = false;

                    foreach (string planner in planners.Split(','))
                    {
                        if (!String.IsNullOrEmpty(planner))
                        {

                            string[] sPlanner = planner.Split('|');

                            bool canProject = false;
                            bool canOnline = false;

                            bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + sPlanner[0] + "EnableOnline"), out canOnline);
                            bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + sPlanner[0] + "EnableProject"), out canProject);

                            if ((!bDisablePlan && canOnline) || (!bDisableProject && canProject))
                            {
                                string tc = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLivePlanner" + sPlanner[0] + "TaskCenter");
                                string pc = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLivePlanner" + sPlanner[0] + "ProjectCenter");
                                string desc = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLivePlanner" + sPlanner[0] + "Description");

                                SPList oPC = web.Lists.TryGetList(pc);
                                SPList oTC = web.Lists.TryGetList(tc);

                                if (oPC != null && oTC != null)
                                {
                                    foundpj = true;
                                    if (list.Title == oPC.Title)
                                    {
                                        pList.Add(sPlanner[0], CreatePlannerDef(sPlanner[1], "/_layouts/epmlive/images/planner16.png", true, "ListEPMLivePlanner", desc, 1, "planner:"));
                                    }
                                    else if (list.Title == oTC.Title)
                                    {
                                        pList.Add(sPlanner[0], CreatePlannerDef(sPlanner[1], "/_layouts/epmlive/images/planner16.png", true, "ListEPMLiveTaskPlanner", desc, 1, "taskplanner:"));
                                    }
                                }
                            }
                        }
                    }

                    if (!foundpj && li.ParentList.Title == "Project Center")
                    {
                        if (lweb.Lists.TryGetList("Planner Templates") == null)
                        {
                            pList.Add("MPP", CreatePlannerDef("Microsoft Office Project", "/_layouts/epmlive/images/planner16.png", true, "ListEPMLivePlanner", "", 1, "planner:"));
                        }
                    }

                    if (!bDisablePlan)
                    {
                        //================Old Work planner===============
                        if (web.Site.Features[new Guid("91f0c887-2db2-44b2-b15c-47c69809c767")] != null)
                        {
                            bool enableWP = false;
                            string spc = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveWPProjectCenter");
                            string stc = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveWPTaskCenter");
                            try
                            {
                                enableWP = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveWPEnable"));
                            }
                            catch { }

                            if (enableWP && web.Lists.TryGetList(spc) != null && web.Lists.TryGetList(stc) != null && String.Equals(spc, list.Title, StringComparison.InvariantCultureIgnoreCase))
                            {
                                pList.Add("WorkEngineWorkPlanner", CreatePlannerDef("Work Planner", "/_layouts/images/epmlivelogosmall.gif", true, "PlannerWP", "WorkEngine Work Planner", 3, ""));
                            }
                        }
                        //================Old Agile planner===============
                        bool enableAgile = false;
                        string spca = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveAgileProjectCenter");
                        string stca = EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveAgileTaskCenter");
                        try
                        {
                            enableAgile = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveAgileEnable"));
                        }
                        catch { }

                        if (enableAgile && web.Lists.TryGetList(spca) != null && web.Lists.TryGetList(stca) != null && String.Equals(spca, list.Title, StringComparison.InvariantCultureIgnoreCase))
                        {
                            pList.Add("WorkEngineAgilePlanner", CreatePlannerDef("Agile Planner", "/_layouts/images/epmlivelogosmall.gif", true, "PlannerAgile", "WorkEngine Agile Planner", 3, ""));
                        }
                    }

                    //======================Project Pro=====================

                    bool disableProject = false;
                    bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveDisablePublishing"), out disableProject);

                    if (!disableProject)
                    {
                        string pubPC = EPMLiveCore.CoreFunctions.getLockConfigSetting(web, "epmlivepub-pc", false);
                        if (String.Equals(pubPC, list.Title, StringComparison.InvariantCultureIgnoreCase))
                        {
                            string pubTC = EPMLiveCore.CoreFunctions.getLockConfigSetting(web, "epmlivepub-tc", false);
                            bool foundmpp = false;

                            try
                            {
                                SPDocumentLibrary lib = (SPDocumentLibrary)web.Lists["Project Schedules"];
                                if (lib != null)
                                {
                                    if (lib.ContentTypesEnabled)
                                    {
                                        foreach (SPContentType ct in lib.ContentTypes)
                                        {
                                            string template = ct.DocumentTemplateUrl;
                                            if (template.Substring(template.Length - 3, 3) == "mpp")
                                            {
                                                foundmpp = true;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        string template = lib.DocumentTemplateUrl;
                                        if (template.Substring(template.Length - 3, 3) == "mpp")
                                        {
                                            foundmpp = true;
                                        }
                                    }
                                }
                            }
                            catch { }
                            if (foundmpp)
                            {
                                if (web.Features[new Guid("ebc3f0dc-533c-4c72-8773-2aaf3eac1055")] == null)
                                {
                                    pList.Add("EditInMicrosoftProject", CreatePlannerDef("Microsoft Project", "/_layouts/images/Project2007LogoSmall.gif", true, "EditInProject", "Edit Schedule in Microsoft Office Project", 2, ""));
                                }
                                else
                                {
                                    pList.Add("EditInMicrosoftProject", CreatePlannerDef("Microsoft Project", "/_layouts/images/Project2007LogoSmall.gif", true, "EditInPSProject", "Edit Schedule in Microsoft Office Project", 2, ""));
                                }
                            }
                        }
                    }
                }

            }
            catch { }
            return pList;
        }

        public static Dictionary<string, PlannerDefinition> GetPlannerList(SPWeb inweb, SPListItem li)
        {
            Dictionary<string, PlannerDefinition> pList = new Dictionary<string, PlannerDefinition>();



            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(inweb.Site.ID))
                {
                    if (site.Features[new Guid("e6df7606-1541-4bf1-a810-e8e9b11819e3")] != null)
                    {
                        using (SPWeb web = site.OpenWeb(inweb.ID))
                        {
                            Guid ulWeb = EPMLiveCore.CoreFunctions.getLockedWeb(web);
                            if (ulWeb == web.ID)
                                pList = iGetPlannerList(web, web, li);
                            else
                            {
                                using (SPWeb lweb = site.OpenWeb(ulWeb))
                                {
                                    pList = iGetPlannerList(lweb, web, li);
                                }
                            }
                        }
                    }
                }
            });
            return pList;
        }

        public static string GetJustUsername(string username)
        {
            try
            {
                string[] s = username.Split('|');
                return s[s.Length - 1];
            }
            catch { return username; }
        }

        public static string GetCleanUserName(string username)
        {
            try
            {
                string pref = CoreFunctions.getPrefix();
                if (pref != "")
                {
                    username = username.Replace(pref, "").Replace(getMainDomain() + "\\", "");
                }
                else
                {
                    username = username.Replace(getMainDomain() + "\\", "");
                }
            }
            catch { }
            return username;
        }

        public static string GetRealUserName(string username)
        {
            try
            {
                username = username.Replace(CoreFunctions.getPrefix(), "");
                if (!username.Contains("\\"))
                    username = getMainDomain() + "\\" + username;
            }
            catch { }
            return username;
        }

        public static string GetUserNameWithDomain(string username)
        {
            try
            {
                username = GetJustUsername(username);

                if (!username.Contains("\\"))
                    username = getMainDomain() + "\\" + username;
            }
            catch { }
            return username;
        }

        public static string GetSafeGroupTitle(string sRawGrpName)
        {
            var safeGroupTitle = string.Empty;
            Regex rgx = new Regex("[^a-zA-Z 0-9]");
            safeGroupTitle = rgx.Replace(sRawGrpName, "");

            return safeGroupTitle;
        }

        public static string getMainDomain()
        {
            string s = "epm";
            try
            {
                s = System.Configuration.ConfigurationManager.AppSettings["domain"].ToString();
            }
            catch { }
            return s;
        }


        public static string getMainDomain(SPSite site)
        {
            string s = "epm";
            try
            {
                s = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/", site.WebApplication.Name).AppSettings.Settings["domain"].Value;
            }
            catch { }
            return s;
        }


        public static string getContractLevel()
        {
            string s = "2";
            try
            {
                s = System.Configuration.ConfigurationManager.AppSettings["contractLevel"].ToString();
            }
            catch { }
            return s;
        }

        public static string getPrefix()
        {
            string s = "";
            try
            {
                s = System.Configuration.ConfigurationManager.AppSettings["prefix"].ToString();
            }
            catch { }
            return s;
        }

        public static string GetCleanUserName(string username, SPSite site)
        {
            try
            {
                string pref = CoreFunctions.getPrefix(site);
                if (pref != "")
                {
                    username = username.Replace(pref, "").Replace(getMainDomain() + "\\", "");
                }
                else
                {
                    username = username.Replace(getMainDomain() + "\\", "");
                }
            }
            catch { }
            return username;
        }

        public static string getContractLevel(SPSite site)
        {
            string s = "2";
            try
            {
                s = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/", site.WebApplication.Name).AppSettings.Settings["contractlevel"].Value;
            }
            catch { }
            return s;
        }

        public static string GetRealUserName(string username, SPSite site)
        {
            try
            {
                username = username.Replace(CoreFunctions.getPrefix(site), "");
                if (!username.Contains("\\"))
                    username = getMainDomain(site) + "\\" + username;
            }
            catch { }
            return username;
        }

        public static string getPrefix(SPSite site)
        {
            string s = "";
            try
            {
                s = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/", site.WebApplication.Name).AppSettings.Settings["Prefix"].Value;
            }
            catch { }
            return s;

        }

        private static string getDomain()
        {
            string domain = System.DirectoryServices.ActiveDirectory.Domain.GetComputerDomain().ToString();
            string retVal = string.Empty;
            if (domain.Contains("."))
            {
                string[] DCvals = domain.Split(".".ToCharArray()[0]);
                foreach (string val in DCvals)
                {
                    retVal = retVal + "DC=" + val + ",";
                }
                retVal = retVal.Remove(retVal.LastIndexOf(","));
            }

            return retVal;
        }

        public static DirectoryEntry getUserFromAD(string username)
        {
            DirectoryEntry deUser = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                if (username.IndexOf("\\") > 0)
                    username = username.Substring(username.IndexOf("\\") + 1);

                DirectoryEntry de = new DirectoryEntry();
                de.Path = "LDAP://" + getDomain();
                de.AuthenticationType = AuthenticationTypes.Secure;

                DirectorySearcher deSearch = new DirectorySearcher();

                deSearch.SearchRoot = de;
                deSearch.Filter = "(&(objectClass=user) (cn=" + username + "))";

                SearchResultCollection results = deSearch.FindAll();

                if (results.Count > 0)
                {
                    SearchResult sr = results[0];
                    deUser = sr.GetDirectoryEntry();
                }
            });

            return deUser;
        }

        public static string GetScheduleStatusField(SPListItem ListItem)
        {
            string ss = "";
            string status = "";
            int yellow = 0;
            int red = 30;

            try
            {
                try
                {
                    status = ListItem["Status"].ToString();
                }
                catch { }

                if (status != "Completed")
                {

                    SPField oField = null;
                    try
                    {
                        oField = ListItem.ParentList.Fields.GetFieldByInternalName("DueDate");
                    }
                    catch { }
                    if (oField != null)
                    {
                        ss = "green.gif";
                        DateTime duedate = DateTime.Parse(ListItem[oField.Id].ToString());
                        DateTime today = DateTime.Now;
                        today = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);
                        duedate = new DateTime(duedate.Year, duedate.Month, duedate.Day, 0, 0, 0);

                        TimeSpan ts = today - duedate;

                        if (ts.TotalDays > red)
                        {
                            ss = "red.gif";
                        }
                        else if (ts.TotalDays > yellow)
                        {
                            ss = "yellow.gif";
                        }
                    }
                    else
                    {
                        ss = ListItem["ScheduleStatus"].ToString();
                        ss = ss.Substring(ss.IndexOf(";#") + 2);
                    }
                }
                else
                {
                    ss = "checkmark.gif";
                }

            }
            catch { }

            return ss;
        }

        public static string GetDaysOverdueField(SPListItem ListItem)
        {
            string daysoverdue = "0";
            string status = "";
            try
            {
                try
                {
                    status = ListItem["Status"].ToString();
                }
                catch { }

                if (status != "Completed")
                {
                    DateTime duedate = DateTime.Parse(ListItem["DueDate"].ToString());
                    DateTime today = DateTime.Now;
                    today = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);
                    duedate = new DateTime(duedate.Year, duedate.Month, duedate.Day, 0, 0, 0);

                    TimeSpan ts = today - duedate;

                    if (ts.TotalDays > 0)
                    {
                        daysoverdue = ts.TotalDays.ToString();
                    }
                }
            }
            catch
            {

            }
            return daysoverdue;
        }

        public static string GetDueField(SPListItem ListItem)
        {
            string status = "";
            DateTime duedate = DateTime.MinValue;
            string due = "";
            try
            {
                try
                {
                    status = ListItem["Status"].ToString();
                }
                catch { }
                try
                {
                    duedate = DateTime.Parse(ListItem["DueDate"].ToString());
                }
                catch
                {
                }
                DateTime today = DateTime.Now;
                today = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);
                duedate = new DateTime(duedate.Year, duedate.Month, duedate.Day, 0, 0, 0);


                TimeSpan ts = duedate - today;
                TimeSpan tsnw = duedate - today.AddDays((double)today.DayOfWeek);

                System.Globalization.CalendarWeekRule weekRule = System.Globalization.CalendarWeekRule.FirstDay;
                DayOfWeek firstWeekDay = DayOfWeek.Sunday;
                System.Globalization.Calendar calendar = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar;

                int currentWeek = calendar.GetWeekOfYear(DateTime.Now, weekRule, firstWeekDay);
                int dueWeek = calendar.GetWeekOfYear(duedate, weekRule, firstWeekDay);

                if (status == "Completed")
                    due = "Completed";
                else if (duedate == DateTime.MinValue)
                    due = "No Due Date";
                else if (duedate < today)
                    due = "(1) Overdue";
                else if (duedate == today)
                    due = "(2) Due Today";
                else if (ts.TotalDays == 1)
                    due = "(3) Due Tomorrow";
                else if (today.Year == duedate.Year && currentWeek == dueWeek)
                    due = "(4) Due This Week";
                else if (tsnw.TotalDays <= 14)
                    due = "(5) Due Next Week";
                else if (today.Year == duedate.Year && today.Month == duedate.Month)
                    due = "(6) Due This Month";
                else
                    due = "(7) Future";

            }
            catch
            {
                due = "No Due Date";
            }

            return due;
        }

        public static string getUserString(string usernames, SPWeb web, string sPrefix)
        {
            string[] users = usernames.Split(',');

            string sUsernameString = "";

            foreach (string username in users)
            {
                if (username != "")
                {
                    SPUser oUser = null;
                    try
                    {
                        oUser = web.SiteUsers[sPrefix + username];
                    }
                    catch { }
                    if (oUser == null && username != "")
                    {
                        DirectoryEntry de = getUserFromAD(username);
                        if (de != null)
                        {
                            string email = "";
                            try
                            {
                                email = de.Properties["mail"].Value.ToString();
                            }
                            catch { }

                            web.SiteUsers.Add(sPrefix + username, email, de.Properties["displayName"].Value.ToString(), "");
                            oUser = web.SiteUsers[sPrefix + username];
                        }
                    }

                    sUsernameString += ";#" + oUser.ID + ";#" + oUser.Name;
                }
            }

            if (sUsernameString.Length > 1)
                sUsernameString = sUsernameString.Substring(2);

            return sUsernameString;
        }

        public static bool DoesCurrentUserHaveFullControl(SPWeb web)
        {
            bool has = false;
            if (web.AllRolesForCurrentUser.Contains(web.RoleDefinitions["Full Control"]) || web.CurrentUser.IsSiteAdmin)
            {
                has = true;
            }
            return has;
        }

        public static bool CurrentUserIsInRole(SPWeb web, string role)
        {
            bool isInRole = false;
            if (web.AllRolesForCurrentUser.Contains(web.RoleDefinitions[role]))
            {
                isInRole = true;
            }
            return isInRole;
        }

        public static bool UserIsInRole(SPWeb web, string loginName, string role)
        {
            bool isInRole = false;
            SPPrincipal uPrin = web.Users[loginName];
            SPRoleAssignmentCollection collRoleAssignments = web.RoleAssignments;

            List<SPRoleAssignment> collUra = (from a in collRoleAssignments.OfType<SPRoleAssignment>()
                                              where a.Member.Equals(uPrin) && a.RoleDefinitionBindings.Contains(web.RoleDefinitions[role])
                                              select a).ToList<SPRoleAssignment>();

            isInRole = (collUra.Count > 0) ? true : false;

            return isInRole;
        }

        public static List<SPEventReceiverDefinition> GetListEvents(SPList list, string assemblyName, string className, List<SPEventReceiverType> types)
        {
            List<SPEventReceiverDefinition> evts = new List<SPEventReceiverDefinition>();

            try
            {
                evts = (from e in list.EventReceivers.OfType<SPEventReceiverDefinition>()
                        where e.Assembly.Equals(assemblyName, StringComparison.CurrentCultureIgnoreCase) &&
                              e.Class.Equals(className, StringComparison.CurrentCultureIgnoreCase) &&
                              types.Contains(e.Type)
                        select e).ToList<SPEventReceiverDefinition>();
            }
            catch
            {

            }

            return evts;
        }

        public static List<SPEventReceiverDefinition> GetWebEvents(SPWeb web, string assemblyName, string className, List<SPEventReceiverType> types)
        {
            List<SPEventReceiverDefinition> evts = new List<SPEventReceiverDefinition>();

            try
            {
                evts = (from e in web.EventReceivers.OfType<SPEventReceiverDefinition>()
                        where e.Assembly.Equals(assemblyName, StringComparison.CurrentCultureIgnoreCase) &&
                              e.Class.Equals(className, StringComparison.CurrentCultureIgnoreCase) &&
                              types.Contains(e.Type)
                        select e).ToList<SPEventReceiverDefinition>();
            }
            catch
            {

            }

            return evts;
        }

        public static SPField getRealField(SPField field)
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

        public static DataTable getSiteItems(SPWeb web, SPView view, string spquery, string filterfield, string usewbs, string rlist, string[] arrGroupFields)
        {
            DataTable dt = null;
            string lists = "";
            SqlConnection cn = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                //using (SPSite s = SPContext.Current.Site)
                {
                    string dbCon = web.Site.ContentDatabase.DatabaseConnectionString;
                    cn = new SqlConnection(dbCon);
                    cn.Open();
                }
            });

            if (cn.State == ConnectionState.Open)
            {

                try
                {
                    string siteurl = web.ServerRelativeUrl.Substring(1);

                    ArrayList arr = new ArrayList();
                    string dqFields = "";
                    foreach (string field in view.ViewFields)
                    {
                        SPField f = getRealField(view.ParentList.Fields.GetFieldByInternalName(field));
                        arr.Add(f.InternalName.ToLower());
                        dqFields += "<FieldRef Name='" + f.InternalName + "' Nullable='TRUE'/>";
                    }
                    foreach (string groupby in arrGroupFields)
                    {
                        if (!arr.Contains(groupby.ToLower()))
                        {
                            arr.Add(groupby.ToLower());
                            dqFields += "<FieldRef Name='" + groupby + "' Nullable='TRUE'/>";
                        }
                    }

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml("<Where>" + spquery + "</Where>");
                    XmlNode nl = doc.FirstChild.SelectSingleNode("//OrderBy");
                    if (nl != null)
                    {
                        foreach (XmlNode nd in nl.ChildNodes)
                        {
                            string fname = nd.Attributes["Name"].Value;
                            if (!arr.Contains(fname.ToLower()))
                            {
                                arr.Add(fname.ToLower());
                                dqFields += "<FieldRef Name='" + fname + "' Nullable='TRUE'/>";
                            }
                        }
                    }

                    if (!arr.Contains("title") && view.ParentList.Fields.ContainsField("Title"))
                    {
                        dqFields += "<FieldRef Name='Title' Nullable='TRUE'/>";
                    }
                    if (!arr.Contains("created"))
                    {
                        dqFields += "<FieldRef Name='Created'/>";
                    }
                    if (!arr.Contains("_moderationstatus"))
                    {
                        dqFields += "<FieldRef Name='_ModerationStatus' Nullable='TRUE'/>";
                    }
                    if (filterfield != null && filterfield != "")
                    {
                        if (!arr.Contains(filterfield.ToLower()))
                        {
                            dqFields += "<FieldRef Name='" + filterfield + "' Nullable='TRUE'/>";
                        }
                    }
                    if (usewbs != null && usewbs != "")
                    {
                        if (!arr.Contains(usewbs.ToLower()))
                        {
                            dqFields += "<FieldRef Name='" + usewbs + "' Nullable='TRUE'/>";
                        }
                    }
                    if (!arr.Contains("list"))
                    {
                        dqFields += "<FieldRef Name='List' Nullable='TRUE'/>";
                    }
                    if (!arr.Contains("commentcount"))
                    {
                        dqFields += "<FieldRef Name='CommentCount' Nullable='TRUE'/>";
                    }
                    if (!arr.Contains("commenters"))
                    {
                        dqFields += "<FieldRef Name='Commenters' Nullable='TRUE'/>";
                    }
                    if (!arr.Contains("commentersread"))
                    {
                        dqFields += "<FieldRef Name='CommentersRead' Nullable='TRUE'/>";
                    }
                    if (!arr.Contains("assignedto"))
                    {
                        dqFields += "<FieldRef Name='AssignedTo' Nullable='TRUE'/>";
                    }
                    if (!arr.Contains("author"))
                    {
                        dqFields += "<FieldRef Name='Author' Nullable='TRUE'/>";
                    }
                    if (!arr.Contains("childitem"))
                    {
                        dqFields += "<FieldRef Name='ChildItem' Nullable='TRUE'/>";
                    }
                    if (!arr.Contains("parentitem"))
                    {
                        dqFields += "<FieldRef Name='ParentItem' Nullable='TRUE'/>";
                    }
                    if (!arr.Contains("workspaceurl"))
                    {
                        dqFields += "<FieldRef Name='WorkspaceUrl' Nullable='TRUE'/>";
                    }
                    try
                    {
                        lists = "";
                        string query = "";
                        if (rlist != "")
                        {
                            if (siteurl == "")
                                query = "SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     webs.siteid='" + web.Site.ID + "' AND (dbo.AllLists.tp_Title like '" + rlist.Replace("'", "''") + "')";
                            else
                                query = "SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     (dbo.Webs.FullUrl LIKE '" + siteurl + "/%' OR dbo.Webs.FullUrl = '" + siteurl + "') AND (dbo.AllLists.tp_Title like '" + rlist.Replace("'", "''") + "')";

                            SqlCommand cmd = new SqlCommand(query, cn);
                            //cmd.Parameters.AddWithValue("@rlist", rlist);
                            SqlDataReader dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                lists += "<List ID='" + dr.GetGuid(0).ToString() + "'/>";
                            }
                            dr.Close();
                        }
                        else
                        {
                            lists = "<List ID='" + view.ParentList.ID + "'/>";
                        }


                        if (lists != "")
                        {
                            SPSiteDataQuery dq = new SPSiteDataQuery();
                            dq.Lists = "<Lists MaxListLimit='0'>" + lists + "</Lists>";
                            dq.Query = spquery;
                            dq.QueryThrottleMode = SPQueryThrottleOption.Override;
                            if (rlist != "")
                                dq.Webs = "<Webs Scope='Recursive'/>";

                            dq.ViewFields = dqFields;
                            try
                            {
                                SPSecurity.RunWithElevatedPrivileges(delegate()
                                {
                                    dt = web.GetSiteData(dq);
                                });
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Error getting site data: " + ex.Message + "<br>This may be caused by column data type mismatches throughout your site collection. Check the Field Audit page in General Settings.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error getting site data lists: " + ex.Message);
                    }

                    cn.Close();
                }
                catch { }
                cn.Close();
            }

            return dt;
        }



        public static string getItemXml(SPListItem li, Hashtable hshFields, SPItemEventDataCollection properties, SPWeb web)
        {
            SPList list = li.ParentList;

            string xml = "<Item ItemId=\"" + list.ParentWeb.ID + "." + list.ID + "." + li.ID + "\">";
            string title = li.Title;
            try
            {
                if (properties["Title"] != null)
                    title = properties["Title"].ToString();
            }
            catch { }

            xml += "<Title><![CDATA[" + title + "]]></Title>";

            foreach (DictionaryEntry field in hshFields)
            {
                string spfield = field.Value.ToString();
                string epkfield = field.Key.ToString();
                SPField oField = null;
                try
                {
                    oField = list.Fields.GetFieldByInternalName(spfield);
                }
                catch { }

                if (oField != null)
                {
                    try
                    {
                        string val = "";
                        try
                        {
                            val = oField.GetFieldValue(li[oField.Id].ToString()).ToString();
                        }
                        catch { }
                        if (oField.Type == SPFieldType.DateTime)
                        {
                            try
                            {
                                if (properties[spfield] != null)
                                {
                                    if (properties[spfield].ToString() != "")
                                    {

                                        try
                                        {
                                            val = DateTime.Parse(properties[spfield].ToString()).ToUniversalTime().ToString("s");
                                        }
                                        catch
                                        {
                                            val = DateTime.ParseExact(properties[spfield].ToString(), "yyyy-M-dTH:m:sZ", new System.Globalization.CultureInfo(1033).DateTimeFormat).ToUniversalTime().ToString("s");
                                        }
                                    }
                                    else
                                        val = "";
                                }
                                else
                                    val = DateTime.Parse(val).ToUniversalTime().ToString("s");
                            }
                            catch { }
                        }
                        else if (oField.Type == SPFieldType.User)
                        {
                            try
                            {
                                SPUser user = web.AllUsers.GetByID(int.Parse(properties[spfield].ToString()));
                                val = user.LoginName;
                            }
                            catch { }
                        }
                        else if (oField.Type == SPFieldType.Number || oField.Type == SPFieldType.Currency)
                        {
                            try
                            {
                                if (properties[spfield] != null)
                                    val = properties[spfield].ToString();
                            }
                            catch { }
                        }
                        else if (oField.Type == SPFieldType.Boolean)
                        {
                            try
                            {
                                if (properties[spfield] != null)
                                    val = properties[spfield].ToString();
                            }
                            catch { }

                            if (val == "True")
                                val = "1";
                            else
                                val = "0";
                        }
                        else if (oField.Type == SPFieldType.Calculated)
                        {
                            val = oField.GetFieldValueAsText(val);
                        }
                        else
                        {
                            try
                            {
                                if (properties[spfield] != null)
                                    val = oField.GetFieldValue(properties[spfield].ToString()).ToString();
                            }
                            catch { }
                        }
                        xml += "<Field Name=\"" + epkfield + "\"><![CDATA[" + val + "]]></Field>";
                    }
                    catch { }
                }
            }

            xml += "</Item>";

            return xml;
        }

        private static string getMenuFromAssembly(string assembly, string aclass)
        {
            AssemblyName asm = new AssemblyName(assembly);
            Assembly u = Assembly.Load(asm);
            Type t = u.GetType(aclass);

            if (t != null)
            {
                MethodInfo m = t.GetMethod("GetMenu");
                if (m != null)
                {
                    //if (parameters.Length >= 1)
                    //{
                    //    //object[] myparam = new object[1];
                    //    //myparam[0] = parameters;
                    //    return (string)m.Invoke(null, null);
                    //}
                    //else
                    return (string)m.Invoke(null, null);
                }
            }
            Exception ex = new Exception("method/class not found");
            throw ex;
        }

        public static string getFarmSetting(string setting)
        {
            string cn = "";
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    SPFarm farm = SPFarm.Local;
                    cn = farm.Properties[setting].ToString();
                }
                catch { }
            });
            if (cn == "")
            {
                switch (setting.ToLower())
                {
                    case "pollinginterval":
                        cn = "10";
                        break;
                    case "queuethreads":
                        cn = "5";
                        break;
                    case "workenginestore":
                        cn = "https://store.workengine.com/";
                        break;
                    case "notificationinterval":
                        cn = "5";
                        break;
                };
            }
            return cn;
        }

        public static string setFarmSetting(string setting, string value)
        {
            string cn = "";
            try
            {
                SPFarm farm = SPFarm.Local;

                if (farm.Properties.ContainsKey(setting))
                    farm.Properties[setting] = value;
                else if (value.Length > 0)
                    farm.Properties.Add(setting, value);
                farm.Update();
            }
            catch { }
            return cn;
        }

        public static string getWebAppSetting(Guid gWebApp, string setting)
        {
            string cn = "";
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    SPWebApplication webapp = SPWebService.ContentService.WebApplications[gWebApp];
                    cn = webapp.Properties[setting].ToString();
                }
                catch { }
                if (cn == "")
                {
                    try
                    {
                        cn = System.Configuration.ConfigurationManager.AppSettings[setting];
                        if (cn != "")
                            setWebAppSetting(gWebApp, setting, cn);

                    }
                    catch { }
                }
            });
            return cn;
        }

        public static void setWebAppSetting(Guid gWebApp, string setting, string value)
        {
            try
            {
                SPWebApplication webapp = SPWebService.ContentService.WebApplications[gWebApp];
                if (webapp.Properties.ContainsKey(setting))
                    webapp.Properties[setting] = value;
                else if (value.Length > 0)
                    webapp.Properties.Add(setting, value);
                webapp.Update();
            }
            catch { }
        }

        public static string getConnectionString(Guid gWebApp)
        {
            string cn = "";
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    SPWebApplication webapp = SPWebService.ContentService.WebApplications[gWebApp];
                    cn = webapp.Properties["epmlivecn"].ToString();
                }
                catch { }
                if (cn == "")
                {
                    try
                    {
                        string sError = "";
                        cn = System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ConnectionString;
                        if (cn != "")
                            setConnectionString(gWebApp, cn, out sError);

                    }
                    catch { }
                }
            });
            return cn;
        }

        public static string getReportingConnectionString(Guid gWebApp, Guid siteId)
        {
            string cn = "";
            string dbServer = string.Empty;
            string dbName = string.Empty;
            string userName = string.Empty;
            string pw = string.Empty;
            bool isSAAcct = false;

            using (SqlConnection con = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(gWebApp)))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM RPTDatabases WHERE SiteId = @siteId";
                cmd.Parameters.AddWithValue("@siteId", siteId);
                cmd.Connection = con;
                DataTable dt = GetTable(cmd);
                con.Close();
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    isSAAcct = bool.Parse(dr["SAccount"].ToString());
                    dbServer = dr["DatabaseServer"].ToString();
                    dbName = dr["DatabaseName"].ToString();
                    userName = dr["Username"].ToString();
                    pw = dr["Password"].ToString();
                }
            }

            if (!isSAAcct)
                cn = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI", dbServer, dbName).Replace("'", "");
            else
                cn = string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};", dbServer, dbName, userName, Decrypt(pw)).Replace("'", "");

            return cn;
        }

        static private DataTable GetTable(SqlCommand cmd)
        {
            SqlDataAdapter da;
            var dt = new DataTable();
            try
            {
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

            return dt;
        }

        /// <summary>
        /// Decrpyts string value using key.
        /// </summary>
        /// <param name="base64Text"></param>
        /// <returns></returns>
        static public string Decrypt(string base64Text)
        {
            try
            {
                byte[] Buffer = new byte[0];
                string Key = "EPMLIVE";
                System.Security.Cryptography.TripleDESCryptoServiceProvider DES = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
                System.Security.Cryptography.MD5CryptoServiceProvider hashMD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(Key));
                DES.Mode = System.Security.Cryptography.CipherMode.ECB;
                System.Security.Cryptography.ICryptoTransform DESDecrypt = DES.CreateDecryptor();
                Buffer = Convert.FromBase64String(base64Text);

                string DecTripleDES = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
                return DecTripleDES;
            }
            catch (Exception ex)
            {
                return base64Text;
            }
        }

        public static bool setConnectionString(Guid gWebApp, string cn, out string sError)
        {
            sError = "";
            try
            {
                SPWebApplication webapp = SPWebService.ContentService.WebApplications[gWebApp];
                if (webapp.Properties.ContainsKey("epmlivecn"))
                    webapp.Properties["epmlivecn"] = cn;
                else if (cn.Length > 0)
                    webapp.Properties.Add("epmlivecn", cn);
                webapp.Update();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                return false;
            }
            return true;
        }

        public static void setListSetting(string setting, string val, SPList list)
        {
            SPField f = null;
            try
            {
                f = list.Fields.GetFieldByInternalName("EPMLiveListConfig");
            }
            catch { }
            if (f == null)
            {
                if (list.DoesUserHavePermissions(SPBasePermissions.ManageLists))
                {
                    try
                    {
                        list.ParentWeb.AllowUnsafeUpdates = true;
                        f = new SPField(list.Fields, "EPMLiveConfigField", "EPMLiveListConfig");
                        f.Hidden = true;
                        list.Fields.Add(f);
                        f.Update();
                        list.Update();
                    }
                    catch { }
                }
            }

            try
            {
                list.ParentWeb.AllowUnsafeUpdates = true;
                EPMLiveConfigField realfield = f as EPMLiveConfigField;
                switch (setting)
                {
                    case "TotalSettings":
                        realfield.TotalSettings = val;
                        break;
                    case "GeneralSettings":
                        realfield.GeneralSettings = val;
                        break;
                    case "DisplaySettings":
                        realfield.DisplaySettings = val;
                        break;
                    case "EnableResourcePlan":
                        realfield.EnableResourcePlan = val;
                        break;
                    default:
                        break;
                }
                realfield.Update();
                list.Update();
            }
            catch { }

        }

        public static string getListSetting(string setting, SPList list)
        {
            if (list == null)
                return "";

            SPField f = null;
            try
            {
                f = list.Fields.GetFieldByInternalName("EPMLiveListConfig");
            }
            catch { }
            if (f == null)
            {
                //if (list.DoesUserHavePermissions(SPBasePermissions.ManageLists))
                //{
                //    try
                //    {
                //        list.ParentWeb.AllowUnsafeUpdates = true;
                //        f = new SPField(list.Fields, "EPMLiveConfigField", "EPMLiveListConfig");
                //        f.Hidden = true;
                //        list.Fields.Add(f);
                //        f.Update();
                //        list.Update();
                //    }
                //    catch { }
                //}
                try
                {
                    switch (setting)
                    {
                        case "TotalSettings":
                            return getConfigSetting(list.ParentWeb, "epmlivelisttotals-" + System.IO.Path.GetDirectoryName(list.DefaultView.Url));
                        case "GeneralSettings":
                            return getConfigSetting(list.ParentWeb, System.IO.Path.GetDirectoryName(list.DefaultView.Url) + "-GridSettings");
                        case "DisplaySettings":
                            return getConfigSetting(list.ParentWeb, String.Format("DisplaySetting{0}", System.IO.Path.GetDirectoryName(list.DefaultView.Url)));
                        case "EnableResourcePlan":
                            return getConfigSetting(list.ParentWeb, System.IO.Path.GetDirectoryName(list.DefaultView.Url) + "-EnableResPlan");
                        default:
                            return "";
                    };
                }
                catch { }

            }
            else
            {
                try
                {
                    EPMLiveConfigField realfield = f as EPMLiveConfigField;
                    string val = "";
                    switch (setting)
                    {
                        case "TotalSettings":
                            val = realfield.TotalSettings;
                            break;
                        case "GeneralSettings":
                            val = realfield.GeneralSettings;
                            break;
                        case "DisplaySettings":
                            val = realfield.DisplaySettings;
                            break;
                        case "EnableResourcePlan":
                            val = realfield.EnableResourcePlan;
                            break;
                    }
                    if (val == "")
                    {
                        switch (setting)
                        {
                            case "TotalSettings":
                                return getConfigSetting(list.ParentWeb, "epmlivelisttotals-" + System.IO.Path.GetDirectoryName(list.DefaultView.Url));
                            case "GeneralSettings":
                                return getConfigSetting(list.ParentWeb, System.IO.Path.GetDirectoryName(list.DefaultView.Url) + "-GridSettings");
                            case "DisplaySettings":
                                return getConfigSetting(list.ParentWeb, String.Format("DisplaySetting{0}", System.IO.Path.GetDirectoryName(list.DefaultView.Url)));
                            case "EnableResourcePlan":
                                return getConfigSetting(list.ParentWeb, System.IO.Path.GetDirectoryName(list.DefaultView.Url) + "-EnableResPlan");
                            default:
                                return "";
                        };
                    }
                    else
                        return val;
                }
                catch { }
            }
            return "";
        }


        public static string createSite(string title, string url, string template, string user, bool unique, bool toplink, SPWeb mySite)
        {
            try
            {
                string sUrl = "";
                //string user = HttpContext.Current.User.Identity.Name.ToString();
                //
                {
                    SPWeb web = mySite.Webs.Add(url, title, "", 1033, template, unique, false);

                    // create a title usable for group names
                    string safeTitle = title.Replace("\"", "")
                                            .Replace("/", "")
                                            .Replace("\\", "")
                                            .Replace("[", "")
                                            .Replace("]", "")
                                            .Replace(":", "")
                                            .Replace("|", "")
                                            .Replace("<", "")
                                            .Replace(">", "")
                                            .Replace("+", "")
                                            .Replace("=", "")
                                            .Replace(";", "")
                                            .Replace(",", "")
                                            .Replace("?", "")
                                            .Replace("*", "")
                                            .Replace("'", "")
                                            .Replace("@", "");

                    if (web.Navigation.TopNavigationBar != null)
                    {
                        web.Navigation.TopNavigationBar.Navigation.UseShared = toplink;
                    }

                    web.AllowUnsafeUpdates = true;

                    web.Update();

                    API.Applications.GenerateQuickLaunchFromApp(web);

                    if (unique)
                    {
                        string aowner = "";
                        string amember = "";
                        string avisitor = "";
                        string strEPMLiveGroupsPermAssignments = "";
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            SPWeb w = SPContext.Current.Web;
                            {
                                Guid lockweb = CoreFunctions.getLockedWeb(w);
                                if (lockweb != Guid.Empty)
                                {
                                    using (SPWeb lweb = w.Site.OpenWeb(lockweb))
                                    {
                                        aowner = CoreFunctions.getConfigSetting(lweb, "EPMLiveNewProjectRoleOwners");
                                        amember = CoreFunctions.getConfigSetting(lweb, "EPMLiveNewProjectRoleMembers");
                                        avisitor = CoreFunctions.getConfigSetting(lweb, "EPMLiveNewProjectRoleVisitors");
                                        strEPMLiveGroupsPermAssignments = CoreFunctions.getConfigSetting(lweb, "EPMLiveGroupsPermAssignments");
                                    }
                                }
                            }
                        });
                        SPUser owner = web.AllUsers[user];

                        web.Update();
                        SPMember newOwner = null;
                        //=========Owner Group========================
                        SPRole roll = web.Roles["Full Control"];
                        if (aowner != "")
                        {
                            try
                            {
                                web.AssociatedOwnerGroup = web.SiteGroups.GetByID(int.Parse(aowner));
                                roll.AddGroup(web.SiteGroups.GetByID(int.Parse(aowner)));
                                newOwner = web.SiteGroups.GetByID(int.Parse(aowner));
                            }
                            catch { }
                        }
                        else
                        {
                            string finalGroupName = string.Empty;
                            try
                            {
                                if (newOwner == null)
                                    newOwner = owner;

                                finalGroupName = AddGroup(web, safeTitle, "Administrators", newOwner, owner, "");
                            }
                            catch (Exception) { }
                            web.Update();
                            web.AssociatedOwnerGroup = GetSiteGroup(web, finalGroupName);
                            roll.AddGroup(web.SiteGroups[finalGroupName]);
                            newOwner = web.SiteGroups[finalGroupName];
                        }
                        if (newOwner == null)
                            newOwner = owner;
                        //=========Member Group========================
                        if (amember != "")
                        {
                            try
                            {
                                web.AssociatedMemberGroup = web.SiteGroups.GetByID(int.Parse(amember));
                                roll = web.Roles["Contribute"];
                                roll.AddGroup(web.SiteGroups.GetByID(int.Parse(amember)));
                            }
                            catch { }
                        }
                        else
                        {
                            string finalGroupName = string.Empty;
                            try
                            {
                                finalGroupName = AddGroup(web, safeTitle, "Members", newOwner, owner, "");
                            }
                            catch (Exception) { }
                            web.Update();
                            web.AssociatedMemberGroup = GetSiteGroup(web, finalGroupName);
                            roll = web.Roles["Contribute"];
                            roll.AddGroup(web.SiteGroups[finalGroupName]);
                        }
                        //=========Visitor Group========================
                        if (avisitor != "")
                        {
                            try
                            {
                                web.AssociatedVisitorGroup = web.SiteGroups.GetByID(int.Parse(avisitor));
                                roll = web.Roles["Read"];
                                roll.AddGroup(web.SiteGroups.GetByID(int.Parse(avisitor)));
                            }
                            catch { }
                        }
                        else
                        {
                            string finalGroupName = string.Empty;
                            try
                            {
                                finalGroupName = AddGroup(web, safeTitle, "Visitors", newOwner, owner, "");
                            }
                            catch (Exception) { }
                            web.Update();
                            web.AssociatedVisitorGroup = GetSiteGroup(web, finalGroupName);
                            roll = web.Roles["Read"];
                            roll.AddGroup(web.SiteGroups[finalGroupName]);
                        }

                        web.Update();

                        if (strEPMLiveGroupsPermAssignments.Length > 1)
                        {

                            string[] strOuter = strEPMLiveGroupsPermAssignments.Split(new string[] { "|~|" }, StringSplitOptions.None);
                            foreach (string strInner in strOuter)
                            {
                                string[] strInnerMost = strInner.Split('~');
                                SPGroup spGroup = web.SiteGroups.GetByID(Convert.ToInt32(strInnerMost[0]));

                                //Persist groups & permissions to the database
                                if (spGroup != null)
                                {
                                    SPRoleAssignment spRA = new SPRoleAssignment(spGroup);
                                    spRA.RoleDefinitionBindings.Add(web.RoleDefinitions.GetById(Convert.ToInt32(strInnerMost[1])));
                                    web.RoleAssignments.Add(spRA);
                                }

                            }
                        }

                        web.Update();

                    }
                    sUrl = web.Url;
                    web.Close();
                }

                return "0:" + sUrl;
            }
            catch (Exception ex) { return ex.Message.ToString(); }
        }

        public static string createSite(string title, string description, string url, string template, string user, bool unique, bool toplink,
            SPWeb parentWeb, out Guid createdWebId, out string createdWebUrl, out string createdWebServerRelativeUrl, out string createdWebTitle)
        {
            createdWebId = Guid.Empty;
            createdWebUrl = string.Empty;
            createdWebTitle = string.Empty;
            createdWebServerRelativeUrl = string.Empty;
            try
            {
                var sUrl = "";

                Regex rgx = new Regex("[^a-zA-Z 0-9]");
                title = rgx.Replace(title, "");

                var finalTitle = title;
                var exists = WebExistsUnderParentWeb(parentWeb, finalTitle);

                var prefix = title;
                var suffix = 1;

                while (exists)
                {
                    finalTitle = prefix + suffix++;
                    exists = WebExistsUnderParentWeb(parentWeb, finalTitle);
                }

                // In EPM 5.5, we decided to make all workspaces 
                // unique. "OPEN" workspaces are different
                // in that they have a owner (the workspace creator)
                // and a "Everyone" group with contribute permission

                //Change entire workspace permission logic for Jira item # EPML-4553: Open workspace not inhering permissions
                var web = parentWeb.Webs.Add(finalTitle, finalTitle, description, 1033, template, unique, false);

                createdWebId = web.ID;
                createdWebUrl = web.Url;
                createdWebServerRelativeUrl = web.ServerRelativeUrl;
                createdWebTitle = web.Title;

                if (web.Navigation.TopNavigationBar != null)
                {
                    web.Navigation.TopNavigationBar.Navigation.UseShared = toplink;
                }

                web.AllowUnsafeUpdates = true;

                web.Update();

                API.Applications.GenerateQuickLaunchFromApp(web);

                string strEPMLiveGroupsPermAssignments = "";
                if (unique)
                {
                    SPSecurity.RunWithElevatedPrivileges(() =>
                    {
                        using (SPSite s = new SPSite(web.Url))
                        {
                            using (SPWeb w = s.OpenWeb())
                            {
                                Dictionary<string, SPRoleType> groups = Security.AddBasicSecurityToWorkspace(w, w.Title,
                                    w.AllUsers[user]);
                                strEPMLiveGroupsPermAssignments = CoreFunctions.getConfigSetting(w,
                                    "EPMLiveGroupsPermAssignments");
                                List<SPEventReceiverDefinition> evts = null;
                                List<Guid> listsToBeMapped = new List<Guid>();
                                Dictionary<String, String> listIconsToBeSet = new Dictionary<string, string>();
                                string EPMLiveReportingAssembly =
                                    "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050";

                                MethodInfo m = null;
                                Assembly assemblyInstance = null;
                                Type thisClass = null;
                                object apiClass = null;
                                string listIcon = string.Empty;

                                foreach (SPList l in w.Lists)
                                {
                                    string sClass = "EPMLiveReportsAdmin.ListEvents";

                                    evts = CoreFunctions.GetListEvents(l,
                                        EPMLiveReportingAssembly,
                                        sClass,
                                        new List<SPEventReceiverType>
                                        {
                                            SPEventReceiverType.ItemAdded,
                                            SPEventReceiverType.ItemUpdated,
                                            SPEventReceiverType.ItemDeleting
                                        });

                                    if (evts.Count > 0 &&
                                        !listsToBeMapped.Contains(l.ID))
                                    {
                                        listsToBeMapped.Add(l.ID);

                                        try
                                        {
                                            //Set List Icon
                                            var gSettings = new GridGanttSettings(l);
                                            listIcon = gSettings.ListIcon;
                                            listIconsToBeSet.Add(l.ID.ToString(), listIcon);
                                        }
                                        catch { }

                                        continue;
                                    }
                                }

                                if (listsToBeMapped.Count > 0)
                                {
                                    try
                                    {
                                        assemblyInstance = Assembly.Load(EPMLiveReportingAssembly);
                                        thisClass = assemblyInstance.GetType("EPMLiveReportsAdmin.EPMData", true, true);
                                        m = thisClass.GetMethod("SetListIcon", BindingFlags.Public | BindingFlags.Instance);
                                        apiClass = Activator.CreateInstance(thisClass, new object[] { true, s.ID, w.ID });

                                        if (m != null &&
                                            assemblyInstance != null &&
                                            thisClass != null &&
                                            apiClass != null)
                                        {
                                            m.Invoke(apiClass, new object[] { listIconsToBeSet });
                                        }
                                    }
                                    catch { }
                                }

                                // use reflection to map list
                                try
                                {
                                    assemblyInstance = Assembly.Load(EPMLiveReportingAssembly);
                                    thisClass = assemblyInstance.GetType("EPMLiveReportsAdmin.EPMData", true, true);
                                    m = thisClass.GetMethod("MapLists", BindingFlags.Public | BindingFlags.Instance);
                                    apiClass = Activator.CreateInstance(thisClass, new object[] { true, s.ID, w.ID });
                                }
                                catch { }

                                if (m != null &&
                                    assemblyInstance != null &&
                                    thisClass != null &&
                                    apiClass != null)
                                {
                                    m.Invoke(apiClass, new object[] { listsToBeMapped, w.ID });
                                }
                            }
                        }
                    });


                    if (strEPMLiveGroupsPermAssignments.Length > 1)
                    {

                        string[] strOuter = strEPMLiveGroupsPermAssignments.Split(new string[] { "|~|" },
                            StringSplitOptions.None);
                        foreach (string strInner in strOuter)
                        {
                            string[] strInnerMost = strInner.Split('~');
                            SPGroup spGroup = web.SiteGroups.GetByID(Convert.ToInt32(strInnerMost[0]));

                            //Persist groups & permissions to the database
                            if (spGroup != null)
                            {
                                SPRoleAssignment spRA = new SPRoleAssignment(spGroup);
                                spRA.RoleDefinitionBindings.Add(
                                    web.RoleDefinitions.GetById(Convert.ToInt32(strInnerMost[1])));
                                web.RoleAssignments.Add(spRA);
                            }
                        }
                    }
                    web.Update();
                }
                else
                {
                    var ownerByCreation = web.AllUsers[user];

                    SPSecurity.RunWithElevatedPrivileges(delegate
                    {
                        using (var es = new SPSite(web.Url))
                        {
                            using (var ew = es.OpenWeb())
                            {
                                ew.AllowUnsafeUpdates = true;
                                //EPML-4553: Open workspace not inhering permissions
                                ew.ResetRoleInheritance();
                                ew.Update();
                            }
                        }
                    });
                }
                sUrl = web.Url;
                web.Close();
                return "0:" + sUrl;
            }
            catch (Exception ex) { return "1:" + ex.Message.ToString(); }
        }

        public static bool WebExistsUnderParentWeb(SPWeb parentWeb, string webName)
        {
            bool exists = false;
            try
            {
                exists = parentWeb.Webs[webName].Exists;
            }
            catch
            {

            }
            return exists;
        }

        public static string CreateSiteFromItem(string title, string description, string url, string template, string user, bool unique, bool toplink,
            SPWeb parentWeb, SPWeb itemWeb, Guid listId, int itemId, out Guid createdSiteId, out string createdWebUrl, out string createdWebRelativeUrl, out string createdWebTitle)
        {
            createdSiteId = Guid.Empty;
            createdWebUrl = string.Empty;
            createdWebRelativeUrl = string.Empty;
            createdWebTitle = string.Empty;
            try
            {
                var sUrl = "";
                var finalTitle = title;
                var exists = WebExistsUnderParentWeb(parentWeb, finalTitle);

                var prefix = title;
                var suffix = 1;

                while (exists)
                {
                    finalTitle = prefix + suffix++;
                    exists = WebExistsUnderParentWeb(parentWeb, finalTitle);
                }

                // In EPM 5.5, we decided to make all workspaces 
                // unique. "OPEN" workspaces are different
                // in that they have a owner (the workspace creator)
                // and a "Everyone" group with contribute permission

                var web = parentWeb.Webs.Add(finalTitle, finalTitle, description, 1033, template, unique, false);

                createdSiteId = web.ID;
                createdWebUrl = web.Url;
                createdWebRelativeUrl = web.ServerRelativeUrl;
                createdWebTitle = web.Title;

                if (web.Navigation.TopNavigationBar != null)
                {
                    web.Navigation.TopNavigationBar.Navigation.UseShared = toplink;
                }

                web.AllowUnsafeUpdates = true;

                web.Update();

                API.Applications.GenerateQuickLaunchFromApp(web);

                #region Modify Unique Workspace

                if (unique)
                {
                    var iowner = 0;
                    var imember = 0;
                    var ivisitor = 0;

                    var owners = new List<int>();
                    var members = new List<int>();
                    var visitors = new List<int>();
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        using (var es = new SPSite(itemWeb.Site.ID))
                        {
                            using (var ew = es.OpenWeb(itemWeb.ID))
                            {
                                var itemList = ew.Lists[listId];
                                var item = itemList.GetItemById(itemId);
                                var raColl = item.RoleAssignments;

                                var safeGroupTitle = GetSafeGroupTitle(finalTitle);

                                // find owner
                                iowner = (from SPRoleAssignment owner in raColl
                                          where owner.Member.Name.Contains(safeGroupTitle + " Owner")
                                          select owner.Member.ID).FirstOrDefault<int>();
                                owners = (from SPRoleAssignment owner in raColl
                                          where
                                              owner.RoleDefinitionBindings.Contains(
                                                  ew.RoleDefinitions.GetByType(SPRoleType.Administrator))
                                          select owner.Member.ID).ToList<int>();

                                // find member
                                imember = (from SPRoleAssignment owner in raColl
                                           where owner.Member.Name.Contains(safeGroupTitle + " Member")
                                           select owner.Member.ID).FirstOrDefault<int>();
                                members = (from SPRoleAssignment owner in raColl
                                           where
                                               owner.RoleDefinitionBindings.Contains(
                                                   ew.RoleDefinitions.GetByType(SPRoleType.Contributor))
                                           select owner.Member.ID).ToList<int>();

                                // find visitor
                                ivisitor = (from SPRoleAssignment owner in raColl
                                            where owner.Member.Name.Contains(safeGroupTitle + " Visitor")
                                            select owner.Member.ID).FirstOrDefault<int>();
                                visitors = (from SPRoleAssignment owner in raColl
                                            where
                                                owner.RoleDefinitionBindings.Contains(
                                                    ew.RoleDefinitions.GetByType(SPRoleType.Reader))
                                            select owner.Member.ID).ToList<int>();
                            }
                        }
                    });
                    var ownerByCreation = web.AllUsers[user];

                    web.Update();
                    SPMember newOwner = null;
                    //=========Owner Group========================
                    SPRole roll = web.Roles["Full Control"];
                    if (iowner != 0)
                    {
                        try
                        {
                            web.AssociatedOwnerGroup = web.SiteGroups.GetByID(iowner);
                            roll.AddGroup(web.SiteGroups.GetByID(iowner));
                            newOwner = web.SiteGroups.GetByID(iowner);
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        string finalGroupName = string.Empty;
                        try
                        {
                            newOwner = ownerByCreation;
                            finalGroupName = AddGroup(web, title, "Administrators", newOwner, ownerByCreation, "");
                        }
                        catch (Exception)
                        {
                        }
                        web.Update();
                        web.AssociatedOwnerGroup = GetSiteGroup(web, finalGroupName);
                        roll.AddGroup(web.SiteGroups[finalGroupName]);
                        newOwner = web.SiteGroups[finalGroupName];
                    }
                    if (newOwner == null)
                        newOwner = ownerByCreation;

                    if (owners.Any())
                    {
                        foreach (int id in owners)
                        {
                            roll.AddGroup(web.SiteGroups.GetByID(id));
                        }
                        web.Update();
                    }
                    //=========Member Group========================
                    if (imember != 0)
                    {
                        try
                        {
                            web.AssociatedMemberGroup = web.SiteGroups.GetByID(imember);
                            roll = web.Roles["Contribute"];
                            roll.AddGroup(web.SiteGroups.GetByID(imember));
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        string finalGroupName = string.Empty;
                        try
                        {
                            finalGroupName = AddGroup(web, title, "Members", newOwner, ownerByCreation, "");
                        }
                        catch (Exception)
                        {
                        }
                        web.Update();
                        web.AssociatedMemberGroup = GetSiteGroup(web, finalGroupName);
                        roll = web.Roles["Contribute"];
                        roll.AddGroup(web.SiteGroups[finalGroupName]);
                    }

                    if (members.Any())
                    {
                        foreach (var id in members)
                        {
                            roll.AddGroup(web.SiteGroups.GetByID(id));
                        }
                        web.Update();
                    }
                    //=========Visitor Group========================
                    if (ivisitor != 0)
                    {
                        try
                        {
                            web.AssociatedVisitorGroup = web.SiteGroups.GetByID(ivisitor);
                            roll = web.Roles["Read"];
                            roll.AddGroup(web.SiteGroups.GetByID(ivisitor));
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        string finalGroupName = string.Empty;
                        try
                        {
                            finalGroupName = AddGroup(web, title, "Visitors", newOwner, ownerByCreation, "");
                        }
                        catch (Exception)
                        {
                        }
                        web.Update();
                        web.AssociatedVisitorGroup = GetSiteGroup(web, finalGroupName);
                        roll = web.Roles["Read"];
                        roll.AddGroup(web.SiteGroups[finalGroupName]);
                    }

                    if (visitors.Any())
                    {
                        foreach (int id in visitors)
                        {
                            roll.AddGroup(web.SiteGroups.GetByID(id));
                        }
                    }
                    web.Update();
                }
                #endregion

                #region Modify Open Workspace
                else
                {
                    try
                    {
                        web.AllowUnsafeUpdates = true;
                        //EPML-4553 : Open workspace not inhering permissions
                        web.ResetRoleInheritance();
                        web.Update();
                    }
                    catch { }
                }
                #endregion

                sUrl = web.Url;
                web.Close();

                return "0:" + sUrl;
            }
            catch (Exception ex) { return "1:" + ex.Message.ToString(); }
        }

        public static string AddGroup(SPWeb web, string safeSiteTitle, string roleName, SPMember owner, SPUser defaultUser, string groupDescription)
        {
            string finalGroupName = string.Empty;
            SPGroup testGrp = null;
            try
            {
                testGrp = web.SiteGroups[safeSiteTitle + " " + roleName];
            }
            catch { }
            if (testGrp != null)
            {
                for (int grpIndex = 1; grpIndex < 101; grpIndex++)
                {
                    try
                    {
                        testGrp = web.SiteGroups[safeSiteTitle + " " + roleName + " " + grpIndex.ToString()];
                    }
                    catch
                    {
                        testGrp = null;
                    }
                    if (testGrp == null)
                    {
                        web.SiteGroups.Add(safeSiteTitle + " " + roleName + " " + grpIndex, owner, defaultUser, groupDescription);
                        finalGroupName = safeSiteTitle + " " + roleName + " " + grpIndex;
                        break;
                    }
                }
            }
            else
            {
                web.SiteGroups.Add(safeSiteTitle + " " + roleName + " ", owner, defaultUser, groupDescription);
                finalGroupName = safeSiteTitle + " " + roleName;
            }

            return finalGroupName;
        }

        //public static string EnsureEveryoneGroup(SPWeb web)
        //{   
        //    SPGroup testGrp = null;
        //    try
        //    {
        //        testGrp = web.SiteGroups["Everyone"];
        //    }
        //    catch { }

        //    if (testGrp == null)
        //    {
        //        web.Site.RootWeb.SiteGroups.Add("Everyone", web.SiteAdministrators[0], web.SiteAdministrators[0], "");
        //        web.Site.RootWeb.SiteGroups["Everyone"].AddUser(web.Site.RootWeb.AllUsers["c:0(.s|true"]);
        //    }

        //    return "Everyone";
        //}

        public static SPGroup GetSiteGroup(SPWeb web, string name)
        {
            return web.SiteGroups.Cast<SPGroup>().FirstOrDefault(@group => String.Equals(@group.Name, name, StringComparison.CurrentCultureIgnoreCase));
        }

        public static void setConfigSetting(SPWeb web, string setting, string value)
        {
            if (value == "")
            {
                if (web.Properties.ContainsKey(setting))
                    web.Properties[setting] = null;
            }
            else
            {

                if (web.Properties.ContainsKey(setting))
                    web.Properties[setting] = value;
                else if (value.Length > 0)
                    web.Properties.Add(setting, value);
            }
            web.Properties.Update();
            //SPList list = null;
            //try
            //{
            //    list = web.Lists["EPMLiveConfig"];
            //}
            //catch { }

            //if (list == null)
            //{
            //    Guid lGuid = web.Lists.Add("EPMLiveConfig", "", SPListTemplateType.GenericList);
            //    list = web.Lists[lGuid];
            //    list.Hidden = true;
            //    list.Fields.Add("Value", SPFieldType.Text, true);
            //    list.Update();
            //}

            //if (list != null)
            //{
            //    SPQuery query = new SPQuery();
            //    query.Query = "<Where><Eq><FieldRef Name='Title'/><Value Type='Text'>" + setting + "</Value></Eq></Where>";

            //    try
            //    {
            //        SPListItemCollection liCol = list.GetItems(query);
            //        if (liCol.Count <= 0)
            //        {
            //            SPListItem li = list.Items.Add();
            //            li["Title"] = setting;
            //            li["Value"] = value;
            //            li.Update();
            //        }
            //        else
            //        {
            //            SPListItem li = liCol[0];
            //            li["Value"] = value;
            //            li.Update();
            //        }
            //    }
            //    catch
            //    {

            //    }
            //}
        }

        private static Guid iGetLockedWeb(SPWeb web)
        {
            if (web == null)
                return Guid.Empty;

            Guid lweb = iGetLockedWeb(web.ParentWeb);

            if (lweb == Guid.Empty)
                if (getConfigSetting(web, "EPMLiveLockConfig") == "True")
                    return web.ID;

            return lweb;

        }

        public static Guid getLockedWeb(SPWeb web)
        {
            Guid lWeb = iGetLockedWeb(web);
            if (lWeb == Guid.Empty)
                lWeb = web.Site.RootWeb.ID;
            return lWeb;
        }

        public static string getConfigSetting(SPWeb web, string setting, bool translateUrl, bool isRelative)
        {
            string val = iGetConfigSetting(web, setting, translateUrl, isRelative);

            if (val == "")
            {
                switch (setting)
                {
                    case "EPMLiveClients":
                        return "E6824613-A011-42e5-AB7E-0A747B3D4DCD";
                    case "EPMLiveTSTimesheetHours":
                        return "Number15";
                    case "EPMLiveTSFlag":
                        return "Flag15";
                    case "EPMLiveTSAllowUnassigned":
                        return "True";
                    case "EPMLiveDaySettings":
                        return "false|0|24|true|0|24|true|0|24|true|0|24|true|0|24|true|0|24|false|0|24";
                    case "EPMLiveTSUseCurrent":
                        return "True";
                    case "EPMLiveTSHoursField":
                        return "TimesheetHours";

                    case "EPMLiveWPProjectCenter":
                        return "Project Center";
                    case "EPMLiveWPTaskCenter":
                        return "Task Center";
                    case "EPMLiveWPEnable":
                        return "True";
                    case "EPMLiveWPUseResPool":
                        return "True";

                    case "EPMLiveAgileProjectCenter":
                        return "Project Center";
                    case "EPMLiveAgileTaskCenter":
                        return "Task Center";
                    case "EPMLiveAgileUseResPool":
                        return "True";

                    case "EPMLiveResourcePool":
                        return "Resources";

                    case "epmlivepub-useres":
                        return "True";

                    case "ReportsAuthMode":
                        return "Windows";

                    case "EPMLivePlannerPublisherProjectCenter":
                        return "Project Center";
                    case "EPMLivePlannerPublisherTaskCenter":
                        return "Task Center";

                    case "EPMLivePublisherProjectCenter":
                    case "epmlivepub-pc":
                        return "Project Center";
                    case "EPMLivePublisherTaskCenter":
                    case "epmlivepub-tcp":
                        return "Task Center";
                    case "epmlivepub-tcpcf":
                        return "Project";

                    case "EPMLivePSWebAppProjectCenter":
                        return "Project Center";
                    case "EPMLivePSWebAppTaskCenter":
                        return "Task Center";
                    case "EPMLivePSWebAppEnable":
                        return "True";

                    case "EPMLiveUseLiveTemplates":
                        return "True";

                    case "EPMLivePlannerParentChild":
                        return "Portfolio Item,Project Item";

                    case "EPMLiveCPSyncIgnore":
                        return "Start,Finish,Duration,BaselineDuration,PercentComplete,BaselineStart,BaselineFinish,ActualStart,ActualFinish,ActualDuration,Work,ActualWork,RemainingWork,BaselineWork,TimesheetHours,Cost,ActualCost,RemainingCost,BaselineCost,WorkspaceUrl,ProjectUpdate";
                };
            }

            return val;
        }

        public static string getConfigSetting(SPWeb web, string setting)
        {
            return getConfigSetting(web, setting, true, true);

        }

        public static string getLockConfigSetting(SPWeb web, string setting, bool isRelative)
        {
            Guid lockWeb = getLockedWeb(web);
            string val = "";
            if (lockWeb != Guid.Empty && lockWeb != web.ID)
            {
                using (SPSite site = web.Site)
                {
                    using (SPWeb w = site.OpenWeb(lockWeb))
                    {
                        val = getConfigSetting(w, setting, true, isRelative);
                    }
                }
            }
            else
            {
                val = getConfigSetting(web, setting, true, isRelative);
            }
            return val;
        }

        private static string iGetConfigSetting(SPWeb web, string setting, bool translateUrl, bool isRelative)
        {
            string prop = "";
            if (setting.ToLower().Contains("url") || setting.ToLower() == "EPMLiveUseResourcePool")
            {
                Guid lockWeb = getLockedWeb(web);
                if (lockWeb != Guid.Empty)
                {
                    Guid siteId = web.Site.ID;
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        using (SPSite site = new SPSite(siteId))
                        {
                            SPWeb rweb = site.OpenWeb(lockWeb);
                            if (rweb.Properties.ContainsKey(setting))
                                prop = rweb.Properties[setting];

                            if (translateUrl)
                            {
                                prop = translateVariables(prop, isRelative, rweb, site);
                            }

                            rweb.Close();
                        }
                    });
                }
                else
                {
                    if (web.Properties.ContainsKey(setting))
                    {
                        prop = web.Properties[setting];
                        if (translateUrl)
                        {
                            prop = translateVariables(prop, isRelative, web, web.Site);
                        }
                    }
                }
            }
            else
                if (web.Properties.ContainsKey(setting))
                    prop = web.Properties[setting];

            return prop;

        }

        private static string translateVariables(string prop, bool isRelative, SPWeb web, SPSite site)
        {
            if (isRelative)
            {
                prop = prop.Replace("{Site}", web.ServerRelativeUrl);
                prop = prop.Replace("{Root}", site.RootWeb.ServerRelativeUrl);
            }
            else
            {
                prop = prop.Replace("{Site}", web.Url);
                prop = prop.Replace("{Root}", site.RootWeb.Url);
            }

            return prop;
        }

        //public static string translateStatus(int status)
        //{
        //    switch (status)
        //    {
        //        case 1:
        //            return "This feature has not been activated.";
        //        case 2:
        //            return "Too many users activated for this feature.";
        //        case 3:
        //            return "Server not licensed.";
        //        case -1:
        //            return "Unable to retrieve activation status.";
        //        default:
        //            return "General license failure.";
        //    };
        //}

        //public static int getFeatureLicenseStatus(int checkFeatureId)
        //{
        //    int ret = -1;
        //    int licCount = 0;
        //    string user = GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName);

        //    SPSecurity.RunWithElevatedPrivileges(delegate()
        //    {
        //        try
        //        {
        //            bool found = false;
        //            bool badservers = false;
        //            licCount = getLicenseCount(checkFeatureId, out found, out badservers);
        //            if (badservers)
        //            {
        //                ret = 3;
        //            }
        //            else
        //            {
        //                if (!found)
        //                {
        //                    ret = 1;
        //                }
        //                else
        //                {
        //                    int curUserCount = getUserCount(checkFeatureId, user, licCount);
        //                    if (curUserCount == -1)
        //                        ret = -1;
        //                    else if (curUserCount <= licCount || licCount == -1)
        //                        ret = 0;
        //                    else
        //                        ret = 2;
        //                }
        //            }
        //        }
        //        catch
        //        {
        //            ret = -1;
        //        }

        //    });
        //    return ret;
        //}

        //public static ArrayList getFeatureUsers(int featureId)
        //{
        //    UserManager _chrono = null;

        //    SPSecurity.RunWithElevatedPrivileges(delegate()
        //    {
        //        SPFarm farm = SPFarm.Local;

        //        _chrono = farm.GetChild<UserManager>("UserManager" + featureId);
        //        if (_chrono == null)
        //        {
        //            SPWeb web = SPContext.Current.Web;
        //            web.AllowUnsafeUpdates = true;
        //            SPSite site = web.Site;
        //            site.AllowUnsafeUpdates = true;
        //            SPWebApplication app = site.WebApplication;
        //            farm = app.Farm;
        //            _chrono = new UserManager("UserManager" + featureId, farm, Guid.NewGuid());
        //            _chrono.Update();
        //            //farm.Update();
        //        }
        //    });

        //    if(_chrono != null)
        //        return _chrono.UserList;

        //    return new ArrayList();
        //}

        private static int getLicenseCount(int checkFeatureId, out bool foundFeature, out bool badservers)
        {
            badservers = false;
            string keys = "";
            int count = 0;
            int totalServerCount = 0;
            bool hasServerKey = false;
            foundFeature = false;
            bool unlimited = false;
            try
            {
                keys = SPFarm.Local.Properties["EPMLiveKeys"].ToString();
            }
            catch { }

            if (keys == "")
            {
                try
                {
                    keys = SPFarm.Local.Properties["EPMLiveKeys"].ToString();
                }
                catch { }
            }
            if (keys != "")
            {
                string[] arrKeys = keys.Split('\t');
                for (int i = 0; i < arrKeys.Length; i = i + 2)
                {
                    if (arrKeys[i] != "")
                    {
                        string val = arrKeys[i];
                        string s = arrKeys[i + 1];
                        if (farmEncode(val) == s)
                        {
                            string feature = Decrypt(val, "jLHKJH5416FL>1dcv3#I");
                            string[] features = feature.Split('\n');
                            string expiration = features[4];
                            string serverCount = "";
                            try
                            {
                                serverCount = features[5];
                                totalServerCount += int.Parse(serverCount);
                                hasServerKey = true;
                            }
                            catch { }

                            string[] featureNames = features[1].Split(',');
                            foreach (string featureName in featureNames)
                            {
                                int featureId = int.Parse(featureName);
                                int userCount = int.Parse(features[2]);
                                if (checkFeatureId == featureId)
                                {

                                    bool goodFeatureExp = false;
                                    if (expiration == "NA")
                                    {
                                        goodFeatureExp = true;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            System.Globalization.CultureInfo eng = new System.Globalization.CultureInfo(1033);
                                            DateTime dtEng = DateTime.Parse(expiration, eng);
                                            if (new DateTime(dtEng.Year, dtEng.Month, dtEng.Day) > DateTime.Now)
                                            {
                                                goodFeatureExp = true;
                                            }
                                        }
                                        catch { }
                                    }
                                    if (goodFeatureExp)
                                    {
                                        foundFeature = true;
                                        if (userCount == 0)
                                        {
                                            unlimited = true;
                                        }
                                        else
                                        {
                                            count += userCount;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (unlimited && hasServerKey)
                {
                    unlimited = checkServerCount(totalServerCount, out badservers);
                }
            }
            if (unlimited)
                return -1;
            else
                return count;
        }

        private static bool checkServerCount(int serverCount, out bool badservers)
        {
            badservers = false;
            int farmservercount = 0;
            SPServerCollection servers = SPFarm.Local.Servers;

            foreach (SPServer server in servers)
                if (server.Role == SPServerRole.WebFrontEnd || server.Role == SPServerRole.Application)
                    farmservercount++;

            try
            {
                if (farmservercount > serverCount)
                {
                    string epmliveservers = "";
                    try
                    {
                        epmliveservers = SPFarm.Local.Properties["EPMLiveServers"].ToString();
                    }
                    catch { }
                    if (epmliveservers != "")
                    {
                        string[] arrservs = epmliveservers.Split(',');
                        if (arrservs.Length > serverCount)
                        {
                            badservers = true;
                            return false;
                        }
                        foreach (string serv in arrservs)
                        {
                            if (serv.ToLower() == System.Net.Dns.GetHostName().ToLower())
                            {
                                return true;
                            }
                        }
                        badservers = true;
                        return false;
                    }
                    else
                    {
                        badservers = true;
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            catch { }
            badservers = false;
            return false;
        }

        public static string farmEncode(string code)
        {
            string computer = SPFarm.Local.Id.ToString();
            string actCode = "";
            int counter = 0;
            for (int i = 0; i < code.Length; i++)
            {
                if (counter + 1 >= computer.Length)
                    counter = 0;
                actCode = actCode + (computer[counter++] ^ code[i]);
            }
            return actCode;
        }

        public static string getFeatureLicenseUserCount(int checkFeatureId)
        {
            //string user = System.Web.HttpContext.Current.User.Identity.Name;
            //string user = SPContext.Current.Web.CurrentUser.LoginName;
            int licCount = 0;
            bool badservers = false;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    bool found = false;
                    licCount = getLicenseCount(checkFeatureId, out found, out badservers);
                }
                catch
                {
                    licCount = 0;
                }

            });
            if (licCount == -1)
                return "Unlimited";
            else
                return licCount.ToString();
        }

        public static ArrayList getFeatureUsers(int featureId)
        {
            UserManager _chrono = null;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    SPFarm farm = SPFarm.Local;

                    _chrono = farm.GetChild<UserManager>("UserManager" + featureId);
                    if (_chrono == null)
                    {
                        SPWeb web = SPContext.Current.Web;
                        web.AllowUnsafeUpdates = true;
                        SPSite site = web.Site;
                        site.AllowUnsafeUpdates = true;
                        SPWebApplication app = site.WebApplication;
                        farm = app.Farm;
                        _chrono = new UserManager("UserManager" + featureId, farm, Guid.NewGuid());
                        _chrono.Update();
                        farm.Update();
                    }
                }
                catch { }
            });

            if (_chrono != null)
            {
                ArrayList arr = _chrono.UserList; ;
                if (arr.Count == 1 && arr[0].ToString() == "")
                    arr = new ArrayList();
                return arr;
            }

            return new ArrayList();
        }

        private static int getUserCount(int checkFeatureId, string username, int totalAvailableUserCount)
        {
            int uCount = -1;
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    try
                    {
                        ArrayList arr = getFeatureUsers(checkFeatureId);

                        if (arr.Contains(username))
                        {
                            uCount = arr.Count;
                        }
                        else
                        {
                            if (arr[0].ToString() == "")
                            {
                                uCount = 0;
                            }
                            else
                            {
                                uCount = arr.Count;
                            }

                            if (uCount < totalAvailableUserCount || totalAvailableUserCount == -1)
                            {
                                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                                {
                                    using (SPWeb web = site.OpenWeb())
                                    {
                                        web.AllowUnsafeUpdates = true;
                                        site.AllowUnsafeUpdates = true;
                                        //SPWebApplication app = site.WebApplication;
                                        //SPFarm farm = app.Farm;
                                        //UserManager _chrono = app.GetChild<UserManager>("UserManager" + checkFeatureId);
                                        //if (_chrono == null)
                                        //{
                                        //    _chrono = new UserManager("UserManager" + checkFeatureId, farm, Guid.NewGuid());
                                        //    _chrono.Update();
                                        //}

                                        //arr.Add(username);

                                        //_chrono.UserList = arr; 
                                        //_chrono.Update();
                                        //site.Update();
                                        //uCount = arr.Count;

                                        string userlist = "";
                                        try
                                        {
                                            userlist = site.RootWeb.Properties["workengineusers" + checkFeatureId].ToString();
                                        }
                                        catch { }
                                        ArrayList aUserList = new ArrayList(userlist.Split(','));

                                        if (aUserList.Contains(username))
                                        {
                                            uCount = uCount + aUserList.Count;
                                        }
                                        else
                                        {
                                            if (uCount < totalAvailableUserCount || totalAvailableUserCount == -1)
                                            {
                                                bool running = false;
                                                foreach (SPJobDefinition job in site.WebApplication.JobDefinitions)
                                                {
                                                    if (job.Name == "WorkEngineActivation")
                                                    {
                                                        running = true;
                                                        break;
                                                    }
                                                }
                                                if (running)
                                                {
                                                    userlist += "," + username;
                                                    userlist = userlist.Trim(',');
                                                    site.RootWeb.Properties["workengineusers" + checkFeatureId] = userlist;
                                                    site.RootWeb.AllowUnsafeUpdates = true;
                                                    site.RootWeb.Properties.Update();
                                                }
                                                else
                                                    uCount = totalAvailableUserCount + 1;
                                            }
                                            else
                                                uCount = totalAvailableUserCount + 1;
                                        }
                                    }
                                }
                            }
                            else
                                uCount = totalAvailableUserCount + 1;
                        }
                        //string sConn = "";
                        //sConn = CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id);

                        //SqlConnection cn = new SqlConnection(sConn);
                        //cn.Open();

                        //SqlCommand cmd = new SqlCommand("select count(featureuserid) from featureusers where username like @username and featureid=@featureid", cn);
                        //cmd.CommandType = CommandType.Text;
                        //cmd.Parameters.AddWithValue("@featureid", checkFeatureId);
                        //cmd.Parameters.AddWithValue("@username", username);

                        //SqlDataReader dr = cmd.ExecuteReader();
                        //int myCount = 0;
                        //int curCount = 0;
                        //if (dr.Read())
                        //{
                        //    myCount = dr.GetInt32(0);
                        //}
                        //dr.Close();

                        //cmd = new SqlCommand("select count(featureuserid) from featureusers where featureid=@featureid", cn);
                        //cmd.CommandType = CommandType.Text;
                        //cmd.Parameters.AddWithValue("@featureid", checkFeatureId);

                        //dr = cmd.ExecuteReader();
                        //if (dr.Read())
                        //{
                        //    curCount = dr.GetInt32(0);
                        //}
                        //dr.Close();

                        //if (myCount >= 1 && curCount <= totalAvailableUserCount)
                        //{
                        //    uCount = curCount;
                        //}
                        //else if (curCount < totalAvailableUserCount)
                        //{
                        //    cmd = new SqlCommand("INSERT INTO featureusers (featureid,username) VALUES (@featureid,@username)", cn);
                        //    cmd.CommandType = CommandType.Text;
                        //    cmd.Parameters.AddWithValue("@featureid", checkFeatureId);
                        //    cmd.Parameters.AddWithValue("@username", username);
                        //    cmd.ExecuteNonQuery();
                        //    uCount = curCount + 1;
                        //}
                        //else
                        //{
                        //    uCount = totalAvailableUserCount + 1;
                        //}

                        //cn.Close();
                    }
                    catch { uCount = -1; }
                });
            }
            catch { }
            return uCount;
        }

        public static string computerCode(string code)
        {
            string computer = System.Net.Dns.GetHostName();
            string actCode = "";
            int counter = 0;
            for (int i = 0; i < code.Length; i++)
            {
                if (counter + 1 >= computer.Length)
                    counter = 0;
                actCode = actCode + (computer[counter++] ^ code[i]);
            }
            return actCode;
        }

        public static string Encrypt(string plainText, string passPhrase)
        {

            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

                byte[] keyBytes = password.GetBytes(keySize / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();

                symmetricKey.Mode = CipherMode.CBC;

                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
                                                                 keyBytes,
                                                                 initVectorBytes);
                MemoryStream memoryStream = new MemoryStream();

                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                             encryptor,
                                                             CryptoStreamMode.Write);

                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

                cryptoStream.FlushFinalBlock();

                byte[] cipherTextBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                string cipherText = Convert.ToBase64String(cipherTextBytes);
                return cipherText;
            }
            catch { return ""; }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes("77B2c3D4e1F3g7R1");
                byte[] saltValueBytes = Encoding.ASCII.GetBytes("f53fNDH@");
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

                PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                                passPhrase,
                                                                saltValueBytes,
                                                                "SHA1",
                                                                2);

                byte[] keyBytes = password.GetBytes(256 / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                                                                 keyBytes,
                                                                 initVectorBytes);

                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                              decryptor,
                                                              CryptoStreamMode.Read);

                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                           0,
                                                           plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();

                string plainText = Encoding.UTF8.GetString(plainTextBytes,
                                                           0,
                                                           decryptedByteCount);
                return plainText;
            }
            catch { return ""; }
        }

        public static void deleteKey(string key)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPWeb web = SPContext.Current.Web;
                {
                    web.AllowUnsafeUpdates = true;
                    SPSite site = web.Site;
                    SPFarm farm = site.WebApplication.Farm;

                    string newkeys = "";
                    try
                    {
                        string[] keys = farm.Properties["EPMLiveKeys"].ToString().Split('\t');

                        for (int i = 0; i < keys.Length; i = i + 2)
                        {
                            if (keys[i] != key)
                            {
                                newkeys += "\t" + keys[i] + "\t" + keys[i + 1];
                            }
                        }

                        if (newkeys.Length > 1)
                            newkeys = newkeys.Substring(1);

                        farm.Properties["EPMLiveKeys"] = newkeys;
                        farm.Update();
                    }
                    catch { }
                }
            });
        }

        //private static void doDelete(string key,SPIisSettings iis)
        //{
        //    try
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        doc.Load(iis.Path + "\\bin\\EPMLive.lic");
        //        foreach (XmlNode nd in doc.FirstChild.ChildNodes)
        //        {
        //            try
        //            {
        //                string val = nd.Attributes["value"].Value;
        //                if (val.Trim() == key.Trim())
        //                {
        //                    doc.FirstChild.RemoveChild(nd);
        //                }
        //            }
        //            catch { }
        //        }
        //        StreamWriter sw = new StreamWriter(iis.Path + "\\bin\\EPMLive.lic", false);
        //        sw.Write(doc.OuterXml);
        //        sw.Close();
        //    }
        //    catch { }
        //}

        //public static ArrayList getActivatedFeatures()
        //{
        //    ArrayList arrFeatures = new ArrayList();

        //    SPSecurity.RunWithElevatedPrivileges(delegate()
        //    {
        //        try
        //        {
        //            string keys = "";
        //            try
        //            {
        //                keys = SPFarm.Local.Properties["EPMLiveKeys"].ToString();
        //            }
        //            catch { }

        //            if (keys == "")
        //            {
        //                try
        //                {
        //                    keys = SPFarm.Local.Properties["EPMLiveKeys"].ToString();
        //                }
        //                catch { }
        //            }
        //            if (keys != "")
        //            {
        //                string[] arrKeys = keys.Split('\t');
        //                for (int i = 0; i < arrKeys.Length; i = i + 2)
        //                {
        //                    if (arrKeys[i] != "")
        //                    {
        //                        string val = arrKeys[i];
        //                        string s = arrKeys[i + 1];
        //                        if (farmEncode(val) == s)
        //                        {
        //                            string feature = Decrypt(val, "jLHKJH5416FL>1dcv3#I");
        //                            string[] features = feature.Split('\n');
        //                            string expiration = features[4];

        //                            string[] featureNames = features[1].Split(',');
        //                            foreach (string featureName in featureNames)
        //                            {
        //                                int featureId = int.Parse(featureName);

        //                                bool goodFeatureExp = false;
        //                                if (expiration == "NA")
        //                                {
        //                                    goodFeatureExp = true;
        //                                }
        //                                else
        //                                {
        //                                    try
        //                                    {
        //                                        System.Globalization.CultureInfo eng = new System.Globalization.CultureInfo(1033);
        //                                        DateTime dtEng = DateTime.Parse(expiration, eng);
        //                                        if (new DateTime(dtEng.Year, dtEng.Month, dtEng.Day) > DateTime.Now)
        //                                        {
        //                                            goodFeatureExp = true;
        //                                        }
        //                                    }
        //                                    catch { }
        //                                }
        //                                if (goodFeatureExp && !arrFeatures.Contains(featureId))
        //                                    arrFeatures.Add(featureId);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        catch
        //        {

        //        }
        //    });

        //    return arrFeatures;
        //}

        internal static System.Net.NetworkCredential GetStoreCreds()
        {
            return new System.Net.NetworkCredential("Solution1", @"J@(Djkhldk2", "EPM");
        }

        public static string getFeatureName(string featureid)
        {
            switch (featureid)
            {
                case "0":
                    return "WebPart Base";
                case "1":
                    return "Work Planner";
                case "2":
                    return "Resource Planner";
                case "3":
                    return "Timesheets";
                case "4":
                    return "Enterprise Base";
                case "5":
                    return "Reporting";
                case "6":
                    return "Agile Planner";
                case "7":
                    return "PortfolioEngine Core";
                case "8":
                    return "MyWork WebPart";
                case "9":
                    return "Communities and Applications";
                default:
                    return "Unknown Feature";
            };
        }

        public static string[] featureList()
        {
            ArrayList list = new ArrayList();
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    string keys = "";
                    try
                    {
                        keys = SPFarm.Local.Properties["EPMLiveKeys"].ToString();
                    }
                    catch { }

                    if (keys == "")
                    {
                        try
                        {
                            keys = SPFarm.Local.Properties["EPMLiveKeys"].ToString();
                        }
                        catch { }
                    }
                    if (keys != "")
                    {
                        string[] arrKeys = keys.Split('\t');
                        for (int i = 0; i < arrKeys.Length; i = i + 2)
                        {
                            if (arrKeys[i] != "")
                            {
                                string val = arrKeys[i];
                                string s = arrKeys[i + 1];
                                if (farmEncode(val) == s)
                                {
                                    if (!list.Contains(val))
                                        list.Add(val);
                                }
                            }
                        }
                    }



                    //foreach (XmlNode nd in doc.FirstChild.ChildNodes)
                    //{
                    //    try
                    //    {
                    //        string val = nd.Attributes["value"].Value;
                    //        string s = nd.InnerText;
                    //        if (EPMLiveCore.CoreFunctions.computerCode(val) == s)
                    //        {
                    //            if(!list.Contains(val))
                    //                list.Add(val);
                    //        }
                    //    }
                    //    catch { }
                    //}
                }
                catch
                {

                }
            });
            return (string[])list.ToArray(typeof(string));
        }

        public static void enqueue(Guid timerjobuid, int defaultstatus)
        {
            SPSite site = SPContext.Current.Site;
            {
                enqueue(timerjobuid, defaultstatus, site);
            }
        }

        public static void enqueue(Guid timerjobuid, int defaultstatus, SPSite site)
        {
            using (SPWeb web = site.OpenWeb())
            {
                int userid = web.CurrentUser.ID;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SqlConnection cn = new SqlConnection(getConnectionString(site.WebApplication.Id));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("select status from queue where timerjobuid=@timerjobuid", cn);
                    cmd.Parameters.AddWithValue("@timerjobuid", timerjobuid);
                    SqlDataReader dr = cmd.ExecuteReader();

                    int status = 2;

                    if (dr.Read())
                    {
                        status = dr.GetInt32(0);
                    }

                    dr.Close();

                    if (status == 2)
                    {
                        cmd = new SqlCommand("DELETE FROM QUEUE where timerjobuid = @timerjobuid ", cn);
                        cmd.Parameters.AddWithValue("@timerjobuid", timerjobuid);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("DELETE FROM EPMLIVE_LOG where timerjobuid = @timerjobuid ", cn);
                        cmd.Parameters.AddWithValue("@timerjobuid", timerjobuid);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("INSERT INTO QUEUE (timerjobuid, status, percentcomplete, userid) VALUES (@timerjobuid, @status, 0, @userid) ", cn);
                        cmd.Parameters.AddWithValue("@timerjobuid", timerjobuid);
                        cmd.Parameters.AddWithValue("@status", defaultstatus);
                        cmd.Parameters.AddWithValue("@userid", userid);
                        cmd.ExecuteNonQuery();
                    }

                    cn.Close();
                });
            }
        }

        /// <summary>
        /// Gets executing assembly version number without private number.
        /// ie. 4.2.2 rather than 4.2.2.9xxxxxxxx
        /// </summary>
        /// <returns>A string that represents executing assembly version without private number</returns>
        public static string GetAssemblyVersion()
        {
            string result = string.Empty;
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                result = string.Join(".", new string[] { fvi.ProductMajorPart.ToString(), fvi.ProductMinorPart.ToString(), fvi.ProductBuildPart.ToString() });
            }
            catch { }

            return result;
        }

        public static string GetFullAssemblyVersion()
        {
            string result = string.Empty;
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                result = string.Join(".", new string[] { fvi.ProductMajorPart.ToString(), fvi.ProductMinorPart.ToString(), fvi.ProductBuildPart.ToString(), fvi.ProductPrivatePart.ToString() });
            }
            catch { }

            return result;
        }

        /// <summary>
        /// Ensures the no duplicates for Resource Events.
        /// </summary>
        /// <param name="properties">The properties.</param>
        public static void EnsureNoDuplicates(SPItemEventProperties properties, Boolean isAdd, Boolean isOnline)
        {
            bool isGeneric;

            try
            {
                isGeneric = bool.Parse(properties.AfterProperties["Generic"].ToString());
            }
            catch
            {
                try
                {
                    isGeneric = bool.Parse(properties.ListItem["Generic"].ToString());
                }
                catch
                {
                    isGeneric = false;
                }
            }

            if (isGeneric) return;

            string sharePointAccount;

            string spAccountProperty = "SharePointAccount";
            if (isOnline)
            {
                spAccountProperty = "Email";
            }

            try
            {
                sharePointAccount = properties.AfterProperties[spAccountProperty].ToString();
            }
            catch
            {
                try
                {
                    sharePointAccount = properties.ListItem[spAccountProperty].ToString();
                }
                catch
                {
                    sharePointAccount = string.Empty;
                }
            }

            if (string.IsNullOrEmpty(sharePointAccount))
            {
                throw new Exception("Please provide a valid SharePoint Account.");
            }

            SPUser u;
            SPListItemCollection spListItemCollection = GetResourceWithDuplicateEmail(properties, isAdd, isOnline, sharePointAccount, out u);

            if (spListItemCollection == null) return;
            if (spListItemCollection.Count <= 0) return;

            SPListItem spListItem = spListItemCollection[0];

            throw new Exception(string.Format("This SharePoint Account ({0}) is currently associated with {1}",
                                              u.LoginName, spListItem["Title"]));
        }

        private static SPListItemCollection GetResourceWithDuplicateEmail(SPItemEventProperties properties, Boolean isAdd, Boolean isOnline, string sharePointAccount, out SPUser u)
        {
            SPFieldUserValue uv;
            SPListItemCollection itemCollection = null;
            string query = string.Empty;
            const string viewFields = @"<FieldRef Name='Title' Nullable='TRUE'/>";

            if (isOnline)
            {
                try
                {
                    SPQuery userQuery = new SPQuery();
                    userQuery.Query = string.Format("<Where><Eq><FieldRef Name=\"EMail\" /><Value Type=\"Text\">{0}</Value></Eq></Where>", sharePointAccount);
                    // Retrieves user based on the email id.
                    SPListItemCollection items = properties.Web.SiteUserInfoList.GetItems(userQuery);
                    if (items != null && items.Count > 0)
                    {
                        try
                        {
                            u = properties.Web.SiteUsers.GetByID(items[0].ID);
                        }
                        catch (Exception)
                        {
                            throw new Exception(sharePointAccount + " is not a valid SharePoint account.");
                        }
                        if (u != null)
                        {
                            if (isAdd)
                            {
                                query = string.Format(@"<Where><Eq><FieldRef Name='Email'/><Value Type='Text'>{0}</Value></Eq></Where>", u.Email);
                            }
                            else
                            {
                                query = string.Format(@"<Where><And><Eq><FieldRef Name='Email'/><Value Type='Text'>{0}</Value></Eq><Neq><FieldRef Name='ID'/><Value Type='Counter'>{1}</Value></Neq></And></Where>", u.Email, properties.ListItem.ID);
                            }
                        }
                    }
                    else
                    {
                        throw new Exception(sharePointAccount + " is not a valid SharePoint account.");
                    }
                }
                catch (Exception)
                {
                    throw new Exception(sharePointAccount + " is not a valid SharePoint account.");
                }
            }
            else
            {
                try
                {
                    uv = new SPFieldUserValue(properties.Web, sharePointAccount);
                }
                catch
                {
                    throw new Exception(sharePointAccount + " is not a valid SharePoint account.");
                }

                u = uv.User ?? properties.Web.EnsureUser(uv.LookupValue);

                if (isAdd)
                {
                    query = string.Format(@"<Where><Eq><FieldRef Name='SharePointAccount' LookupId='TRUE'/><Value Type='Integer'>{0}</Value></Eq></Where>", u.ID);
                }
                else
                {
                    query = string.Format(@"<Where><And><Eq><FieldRef Name='SharePointAccount' LookupId='TRUE'/><Value Type='Integer'>{0}</Value></Eq><Neq><FieldRef Name='ID'/><Value Type='Counter'>{1}</Value></Neq></And></Where>", u.ID, properties.ListItem.ID);
                }
            }

            try
            {
                itemCollection = properties.List.GetItems(new SPQuery { Query = query, ViewFields = viewFields });
            }
            catch { }
            return itemCollection;
        }

        //public static string GetTempDirectory(SPWeb web)
        //{

        //    try
        //    {
        //        return System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/", web.Site.WebApplication.Name).AppSettings.Settings["EPMLIVETEMPDIR"].Value;
        //    }
        //    catch { return "C:\\Program Files (x86)\\EPM Live\\Work Engine Server 2010\\Timer\\TEMP"; }
        //}

        public static string ScheduleReportingRefreshJob(SPWeb spWeb)
        {
            Assembly assemblyInstance =
                Assembly.Load("EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050");
            Type thisClass = assemblyInstance.GetType("EPMLiveReportsAdmin.ReportingAPI", true, true);
            MethodInfo m = thisClass.GetMethod("RefreshAll", BindingFlags.Public | BindingFlags.Instance);
            object apiClass = Activator.CreateInstance(thisClass);
            return (string)m.Invoke(apiClass, new object[] { null, spWeb });
        }
    }
}
