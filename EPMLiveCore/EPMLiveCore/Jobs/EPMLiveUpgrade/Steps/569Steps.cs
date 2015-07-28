using EPMLiveCore.API.SPAdmin;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Infrastructure;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V569, Order = 1.0, Description = "Updates for TFS Integration")]
    internal class UpdateTfsCustomProps : UpgradeStep
    {
        public UpdateTfsCustomProps(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }
        public override bool Perform()
        {
            return true;
        }
    }

    [UpgradeStep(Version = EPMLiveVersion.V569, Order = 2.0, Description = "Updates for Custom Project Field")]
    internal class UpdateCustomProjectField : UpgradeStep
    {
        public UpdateCustomProjectField(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }
        public override bool Perform()
        {
            return true;
        }
    }

    [UpgradeStep(Version = EPMLiveVersion.V569, Order = 3.0, Description = "Updates for Zendesk Widget Integration")]
    internal class UpdateZendeskWidgetIntegration : UpgradeStep
    {
        private SPWeb _spWeb;
        public UpdateZendeskWidgetIntegration(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
        {
            _spWeb = spWeb;
        }
        public override bool Perform()
        {
            //Check if WalkMeID property is available 
            var walkMeId = CoreFunctions.getConfigSetting(_spWeb, "EPMLiveWalkMeId");
            if (walkMeId != null)
            {
                //Add new setting for ZendeskIntegration
                CoreFunctions.setConfigSetting(_spWeb, "SupportIntegration", "True");
                //Remove EPMLiveWalkMeId from config settings 
                _spWeb.Properties.Remove("EPMLiveWalkMeId");
                _spWeb.Properties.Update();
            }
            else
            {
                CoreFunctions.setConfigSetting(_spWeb, "SupportIntegration", "False");                
            }

            return true;
        }
    }
}
