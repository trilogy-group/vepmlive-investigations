using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V567, Order = 1.0, Description = "Adding Resource Pool events")]
    internal class AddResourcePoolEvents : UpgradeStep
    {
        public AddResourcePoolEvents(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }

        public override bool Perform()
        {
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    using (var workEngineAPI = new WorkEngineAPI())
                    {
                        var log = System.Web.HttpUtility.HtmlEncode(workEngineAPI.Execute("AddRemoveFeatureEvents",
                            @"<AddRemoveFeatureEvents><Data><Feature Name=""PFEResourceManagement"" Operation=""ADD""/></Data></AddRemoveFeatureEvents>"));

                        LogMessage(log, 2);
                        LogMessage("Resource Pool Events processed", MessageKind.SUCCESS, 4);
                    }
                }
                catch (Exception exception)
                {
                    string message = exception.InnerException != null
                        ? exception.InnerException.Message
                        : exception.Message;

                    LogMessage(message, MessageKind.FAILURE, 4);
                }
            });

            return true;
        }
    }
}
