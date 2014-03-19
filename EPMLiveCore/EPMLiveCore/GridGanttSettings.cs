using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public class GridGanttSettings
    {
        public string StartDate = "";
        public string DueDate = "";
        public string Progress = "";
        public string WBS = "";
        public string Milestone = "";
        public bool Executive = false;
        public string Information = "";
        public string ItemLink = "";
        public string RibbonBehaviour = "";
        public string RollupLists = "";
        public string RollupSites = "";
        public bool ShowViewToolbar = true;
        public bool HideNewButton = false;
        public bool Performance = false;
        public bool AllowEdit = false;
        public bool EditDefault = false;
        public bool ShowInsert = false;
        public bool DisableNewItemMod = false;
        public bool UseNewMenu = false;
        public string NewMenuName = "";
        public bool UsePopup = false;
        public bool EnableRequests = false;
        public bool EnableAutoCreation = false;
        public string AutoCreationTemplateId = "";
        public string WorkspaceParentSiteLookup = "";
        public bool EnableWorkList = false;
        public bool EnableFancyForms = false;
        public bool SendEmails = false;
        public bool DeleteRequest = false;
        public string RequestList = "";
        public bool UseParent = false;
        public string Lookups = "";
        public bool Search = false;
        public bool LockSearch = false;
        public bool AssociatedItems = false;
        public bool DisplayFormRedirect = false;
        public string ListIcon = "icon-square";


        public string DisplaySettings = "";
        public bool EnableResourcePlan = false;
        public string TotalSettings = "";
        public string AllGeneral = "";

        public bool BuildTeam = false;
        public bool BuildTeamSecurity = false;
        public string BuildTeamPermissions = "";

        public bool EnableContentReporting = false;


        public bool SaveSettings(SPList _list)
        {
            try
            {
                CoreFunctions.setListSetting("GeneralSettings", GetString(), _list);
                CoreFunctions.setListSetting("DisplaySettings", DisplaySettings, _list);
                CoreFunctions.setListSetting("EnableResourcePlan", EnableResourcePlan.ToString(), _list);
                CoreFunctions.setListSetting("TotalSettings", TotalSettings, _list);
                Infrastructure.CacheStore.Current.RemoveCategory("GridSettings");
            }
            catch
            {
                return false;
            }
            return true;
        }

        public GridGanttSettings(SPList list)
        {
            //_list = list;

            string AllGeneral = CoreFunctions.getListSetting("GeneralSettings", list);
            string[] settings = AllGeneral.Split('\n');
            DisplaySettings = CoreFunctions.getListSetting("DisplaySettings", list);
            bool.TryParse(CoreFunctions.getListSetting("EnableResourcePlan", list), out EnableResourcePlan);
            TotalSettings = CoreFunctions.getListSetting("TotalSettings", list);

            try { StartDate = settings[0]; }
            catch { }
            try { DueDate = settings[1]; }
            catch { }
            try { Progress = settings[2]; }
            catch { }
            try { WBS = settings[3]; }
            catch { }
            try { Milestone = settings[4]; }
            catch { }
            try { Executive = (settings[5] == "on" ? true : false); }
            catch { }
            try { Information = settings[6]; }
            catch { }
            try { ItemLink = settings[7]; }
            catch { }
            try { RollupLists = settings[8]; }
            catch { }
            try { RollupSites = settings[9]; }
            catch { }
            try { ShowViewToolbar = bool.Parse(settings[10]); }
            catch { }
            try { HideNewButton = bool.Parse(settings[11]); }
            catch { }
            try { Performance = bool.Parse(settings[12]); }
            catch { }
            try { AllowEdit = bool.Parse(settings[13]); }
            catch { }
            try { EditDefault = bool.Parse(settings[14]); }
            catch { }
            try { ShowInsert = bool.Parse(settings[15]); }
            catch { }
            try { DisableNewItemMod = bool.Parse(settings[16]); }
            catch { }
            try { UseNewMenu = bool.Parse(settings[17]); }
            catch { }
            try { NewMenuName = settings[18]; }
            catch { }
            try { UsePopup = bool.Parse(settings[19]); }
            catch { }
            try { EnableRequests = bool.Parse(settings[20]); }
            catch { }
            try { EnableWorkList = bool.Parse(settings[21]); }
            catch { }
            try { SendEmails = bool.Parse(settings[22]); }
            catch { }
            try { DeleteRequest = bool.Parse(settings[23]); }
            catch { }
            try { RequestList = settings[24]; }
            catch { }
            try { UseParent = bool.Parse(settings[25]); }
            catch { }
            try { Lookups = settings[26]; }
            catch { }
            try { Search = bool.Parse(settings[27]); }
            catch { }
            try { LockSearch = bool.Parse(settings[28]); }
            catch { }
            try { AssociatedItems = bool.Parse(settings[29]); }
            catch { }
            try { DisplayFormRedirect = bool.Parse(settings[30]); }
            catch { }
            try { BuildTeam = bool.Parse(settings[31]); }
            catch { }
            try { BuildTeamSecurity = bool.Parse(settings[32]); }
            catch { }
            try { BuildTeamPermissions = settings[33]; }
            catch { }
            try { EnableContentReporting = bool.Parse(settings[34]); }
            catch { }
            try { EnableAutoCreation = bool.Parse(settings[35]); }
            catch { }
            try { AutoCreationTemplateId = settings[36]; }
            catch { }
            try { WorkspaceParentSiteLookup = settings[37]; }
            catch { }
            try { ListIcon = settings[38]; }
            catch{}
            try { EnableFancyForms = bool.Parse(settings[39]); }
            catch { }
            try { RibbonBehaviour = settings[40]; }
            catch { }

        }

        private string GetString()
        {
            string data = "";
            data += StartDate + "\n";
            data += DueDate + "\n";
            data += Progress + "\n";
            data += WBS + "\n";
            data += Milestone + "\n";
            data += (Executive) ? "on\n" : "\n";
            data += Information + "\n";
            data += ItemLink + "\n";
            data += RollupLists + "\n";
            data += RollupSites + "\n";
            data += ShowViewToolbar.ToString() + "\n";
            data += HideNewButton.ToString() + "\n";
            data += Performance.ToString() + "\n";
            data += AllowEdit.ToString() + "\n";
            data += EditDefault.ToString() + "\n";
            data += ShowInsert + "\n";
            data += DisableNewItemMod + "\n";
            data += UseNewMenu + "\n";
            data += NewMenuName + "\n";
            data += UsePopup + "\n";
            data += EnableRequests + "\n";
            data += EnableWorkList + "\n";
            data += SendEmails + "\n";
            data += DeleteRequest + "\n";
            data += RequestList + "\n";
            data += UseParent + "\n";
            data += Lookups + "\n";
            data += Search + "\n";
            data += LockSearch + "\n";
            data += AssociatedItems + "\n";
            data += DisplayFormRedirect + "\n";
            data += BuildTeam.ToString() + "\n";
            data += BuildTeamSecurity.ToString() + "\n";
            data += BuildTeamPermissions + "\n";
            data += EnableContentReporting.ToString() + "\n";
            data += EnableAutoCreation.ToString() + "\n";
            data += AutoCreationTemplateId + "\n";
            data += WorkspaceParentSiteLookup + "\n";
            data += ListIcon + "\n";
            data += EnableFancyForms + "\n";
            data += RibbonBehaviour + "\n";

            return data;
        }
    }
}
