using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V631, Order = 1.0, Description = "Create Index")]
    internal class CreateIndex : UpgradeStep
    {
        private SPWeb _spWeb;
        private const string const_subKey = "SOFTWARE\\Wow6432Node\\EPMLive\\PortfolioEngine\\";
        public CreateIndex(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }
        public override bool Perform()
        {
            try
            {
                using (SPWeb mySite = Web.Site.OpenWeb())
                {
                    string basePath = CoreFunctions.getConfigSetting(mySite, "epkbasepath");
                    if (!string.IsNullOrEmpty(basePath))
                    {
                        RegistryKey rk = Registry.LocalMachine.OpenSubKey(const_subKey + basePath);
                        if (rk != null)
                        {
                            if (rk.GetValue("QMActive", "no").ToString().ToLower() == "yes")
                            {
                                var dbConnectionStringBuilder = new DbConnectionStringBuilder { ConnectionString = rk.GetValue("ConnectionString", string.Empty).ToString().Trim() };
                                dbConnectionStringBuilder.Remove("Provider");
                                string connection = dbConnectionStringBuilder.ToString();
                                if (!string.IsNullOrEmpty(connection))
                                {
                                    using (SqlConnection pfecn = new SqlConnection(connection))
                                    {
                                        pfecn.Open();
                                        var definition = pfecn.IndexDefinition("I_COST_BREAKDOWN_ATTRIBS_CB_ID_BA_BC_UID_BA_PRD_ID_BA_RATETYPE_UID_BA_CODE_UID");
                                        if (definition == null)
                                        {
                                           
                                            pfecn.ExecuteNonQuery(@"Create Index I_COST_BREAKDOWN_ATTRIBS_CB_ID_BA_BC_UID_BA_PRD_ID_BA_RATETYPE_UID_BA_CODE_UID
                                                                    ON EPGP_COST_BREAKDOWN_ATTRIBS(CB_ID,BA_BC_UID,BA_PRD_ID,BA_RATETYPE_UID,BA_CODE_UID)");
                                            LogMessage("I_COST_BREAKDOWN_ATTRIBS_CB_ID_BA_BC_UID_BA_PRD_ID_BA_RATETYPE_UID_BA_CODE_UID index has been created.", MessageKind.SUCCESS, 4);
                                        }
                                        else
                                        {
                                            LogMessage("I_COST_BREAKDOWN_ATTRIBS_CB_ID_BA_BC_UID_BA_PRD_ID_BA_RATETYPE_UID_BA_CODE_UID index already exists.", MessageKind.SKIPPED, 4);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                string message = exception.InnerException != null
                      ? exception.InnerException.Message
                      : exception.Message;

                LogMessage(message, MessageKind.FAILURE, 4);
            }
            return false;
        }
    }
}
