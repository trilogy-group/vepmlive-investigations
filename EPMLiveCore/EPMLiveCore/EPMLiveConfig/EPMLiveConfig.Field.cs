using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Security;

using System.Collections.Generic;

namespace EPMLiveCore
{
    [Guid("9B0F8552-38E0-473f-AF6C-F8E69CBFDAF3")]
    public class EPMLiveConfigField : SPFieldText
    {

        private static Dictionary<int, string> updatedGeneralSettings = new Dictionary<int, string>();
        private static Dictionary<int, string> updatedTotalSettings = new Dictionary<int, string>();
        private static Dictionary<int, string> updatedEnableResourcePlan = new Dictionary<int, string>();
        private static Dictionary<int, string> updatedDisplaySettings = new Dictionary<int, string>();
        
        private string generalSettings;
        private string totalSettings;
        private string enableResourcePlan;
        private string displaySettings;

        private int contextId;

        public EPMLiveConfigField(SPFieldCollection fields, string fieldName)
            : base(fields, fieldName)
        {
            
            Init();
        }
        
        public EPMLiveConfigField(SPFieldCollection fields, string typeName, string displayName)
            : base(fields, typeName, displayName)
        {
            Init();
        }

        private void Init()
        {
            try
            {
                ContextId = SPContext.Current.GetHashCode();
            }
            catch { ContextId = 1; }
            GeneralSettings = GetCustomProperty("GeneralSettings") + "";
            TotalSettings = GetCustomProperty("TotalSettings") + "";
            EnableResourcePlan = GetCustomProperty("EnableResourcePlan") + "";
            DisplaySettings = GetCustomProperty("DisplaySettings") + "";
        }

        public string GeneralSettings
        {

            get
            {
                return updatedGeneralSettings.ContainsKey(ContextId) ? updatedGeneralSettings[ContextId] : generalSettings;
            }
            set
            {
                this.generalSettings = value;
            }

        }

        public string TotalSettings
        {

            get
            {
                return updatedTotalSettings.ContainsKey(ContextId) ? updatedTotalSettings[ContextId] : totalSettings;
            }
            set
            {
                this.totalSettings = value;
            }

        }

        public string EnableResourcePlan
        {

            get
            {
                return updatedEnableResourcePlan.ContainsKey(ContextId) ? updatedEnableResourcePlan[ContextId] : enableResourcePlan;
            }
            set
            {
                this.enableResourcePlan = value;
            }

        }

        public string DisplaySettings
        {

            get
            {
                return updatedDisplaySettings.ContainsKey(ContextId) ? updatedDisplaySettings[ContextId] : displaySettings;
            }
            set
            {
                this.displaySettings = value;
            }

        }

        public void UpdateGeneralSettings(string value)
        {
            updatedGeneralSettings[ContextId] = value;
        }

        public void UpdateTotalSettings(string value)
        {
            updatedTotalSettings[ContextId] = value;
        }

        public void UpdateEnableResourcePlan(string value)
        {
            updatedEnableResourcePlan[ContextId] = value;
        }

        public void UpdateDisplaySettings(string value)
        {
            updatedDisplaySettings[ContextId] = value;
        }

        public int ContextId
        {
            get
            {
                return contextId;
            }
            set
            {
                contextId = value;
            }
        }

        public override void Update()
        {

            this.SetCustomProperty("GeneralSettings", this.GeneralSettings);
            this.SetCustomProperty("TotalSettings", this.TotalSettings);
            this.SetCustomProperty("EnableResourcePlan", this.EnableResourcePlan);
            this.SetCustomProperty("DisplaySettings", this.DisplaySettings);

            base.Update();

            if (updatedGeneralSettings.ContainsKey(ContextId))
                updatedGeneralSettings.Remove(ContextId);

            if (updatedTotalSettings.ContainsKey(ContextId))
                updatedTotalSettings.Remove(ContextId);

            if (updatedEnableResourcePlan.ContainsKey(ContextId))
                updatedEnableResourcePlan.Remove(ContextId);

            if (updatedDisplaySettings.ContainsKey(ContextId))
                updatedDisplaySettings.Remove(ContextId);
        }

        public override BaseFieldControl FieldRenderingControl
        {
            [SharePointPermission(SecurityAction.LinkDemand, ObjectModel = true)]
            get
            {
                BaseFieldControl fieldControl = new EPMLiveConfigFieldControl();
                fieldControl.FieldName = this.InternalName;

                return fieldControl;
            }
        }

        public override void OnAdded(SPAddFieldOptions op)
        {
            this.Hidden = true;
            base.OnAdded(op);
            Update();

        }
    }
}
