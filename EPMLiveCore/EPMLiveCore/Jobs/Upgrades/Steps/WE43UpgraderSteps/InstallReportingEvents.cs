using System;
using System.Data;
using System.Linq;
using EPMLiveReportsAdmin;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    [JobStep("WE43Upgrader", 4)]
    public class InstallReportingEvents : Step
    {
        #region Constructors (1) 

        public InstallReportingEvents(SPWeb spWeb, string data, int stepNumber, bool bispfe)
            : base(spWeb, data, stepNumber, bispfe)
        {
        }

        #endregion Constructors 

        #region Overrides of Step

        /// <summary>
        /// Gets the description.
        /// </summary>
        public override string Description
        {
            get { return "Installing Reporting Events"; }
        }

        /// <summary>
        /// Performs this instance.
        /// </summary>
        /// <returns/>
        public override bool Perform()
        {
            try
            {
                DataTable listMappings = new ReportData(SPSite.ID).GetListMappings();

                if (listMappings != null)
                {
                    foreach (DataRow dataRow in listMappings.Rows)
                    {
                        InstallEvents(dataRow["ListName"] as string);
                    }
                }
                else
                {
                    LogMessage("", "Cannot find any list mappings.", 2);
                }
            }
            catch (Exception e)
            {
                LogMessage("", e.Message, 3);
            }

            return true;
        }

        private void InstallEvents(string listName)
        {
            LogMessage("List: " + listName);

            SPList spList = SPWeb.Lists[listName];

            const string assemblyName =
                "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050";
            const string className = "EPMLiveReportsAdmin.LstEvents";

            int count = (from SPEventReceiverDefinition erd in spList.EventReceivers
                         where erd.Assembly.Equals(assemblyName)
                         where erd.Class.Equals(className)
                         where erd.Type == SPEventReceiverType.FieldAdded
                         select erd.Name).Count();

            if (count == 0)
            {
                spList.EventReceivers.Add(SPEventReceiverType.FieldAdded, assemblyName, className);
                spList.Update();

                LogMessage("\t", "Field Added event installed.", 1);
            }
            else
            {
                LogMessage("\t", "Field Added event is already installed.", 2);
            }
        }

        #endregion
    }
}