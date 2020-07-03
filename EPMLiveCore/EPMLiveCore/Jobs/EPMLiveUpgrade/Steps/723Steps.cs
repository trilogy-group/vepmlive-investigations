using System;
using Microsoft.SharePoint;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using System.Data.SqlClient;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V723, Order = 1.0, Description = "Reset last approved timestamp")]
    internal class ResetEPKTSLastTSApprove : UpgradeStep
    {
        private SPWeb _spWeb;

        #region Constructors
        public ResetEPKTSLastTSApprove(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        #endregion Constructors

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            bool result = false;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    EPMLiveCore.CoreFunctions.setConfigSetting(_spWeb, "EPKTSLastTSApprove", "");
                    LogMessage("EPKTSLastTSApprove reset", MessageKind.SUCCESS, 1);
                    result = true;
                }
                catch (Exception exception)
                {
                    LogMessage(exception.ToString(), MessageKind.FAILURE, 4);
                }
            });
            return result;
        }

        #endregion
    }
}
