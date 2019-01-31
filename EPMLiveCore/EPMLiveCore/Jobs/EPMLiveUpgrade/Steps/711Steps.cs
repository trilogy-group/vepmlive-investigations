using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V711, Order = 1.0, Description = "Updating My Work table")]
    internal class AddUpdateMyWorkColumn : UpgradeStep
    {
        #region Constructors (1) 

        public AddUpdateMyWorkColumn(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }

        #endregion Constructors 



        public override bool Perform()
        {
            Guid webAppId = Web.Site.WebApplication.Id;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    LogMessage("Connecting to the database . . .", 2);
                    string connectionString = CoreFunctions.getReportingConnectionString(Web.Site.WebApplication.Id, Web.Site.ID);
                    if (!CheckColumn())
                    {
                        AddColumn();
                        LogMessage("IsAssignment column added", MessageKind.SUCCESS, 4);
                    }
                    else
                    {
                        LogMessage("IsAssignment column already exists", MessageKind.SKIPPED, 4);
                    }
                    LogMessage("Updating value to the database . . .", 2);
                }
                catch (Exception exception)
                {
                    LogMessage(exception.ToString(), MessageKind.FAILURE, 4);
                }
            });
            return true;
        }

        private void AddColumn()
        {
            using (SPSite eleSite = new SPSite(Web.Url))
            {
                eleSite.AllowUnsafeUpdates = true;
                using (SPWeb eleWeb = eleSite.OpenWeb())
                {
                    eleWeb.AllowUnsafeUpdates = true;
                    SPList list = eleWeb.Lists["My Work"];
                    string id = list.Fields.Add("IsAssignment", SPFieldType.Boolean, false);
                    SPField spfield = (SPField)list.Fields.GetField(id);
                    spfield.Hidden = true;
                    spfield.Update();
                    SPView view = list.DefaultView;
                    view.ViewFields.Add("IsAssignment");
                    view.Update();
                    eleWeb.AllowUnsafeUpdates = false;
                }
                eleSite.AllowUnsafeUpdates = false;
            }

        }


        private bool CheckColumn()
        {
            using (SPWeb mySite = Web.Site.OpenWeb())
            {
                var list = mySite.Lists["My Work"];
                return list.Fields.ContainsField("IsAssignment");
            }
        }



    }
}
