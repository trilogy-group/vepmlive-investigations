using System;
using System.Data;
using System.Threading;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    [JobStep("WE43Upgrader", 30)]

    public class AddListData : Step
    {
        public AddListData(SPWeb spWeb, string data, int stepNumber, bool bispfe)
            : base(spWeb, data, stepNumber, bispfe)
        {
        }

        public override string Description
        {
            get { return "Updating List Data"; }
        }

        public override bool Perform()
        {
            LogMessage("Loading Resource Pool List");

            SPList oResourcePool = SPWeb.Lists.TryGetList("Resources");

            if(oResourcePool == null)
            {
                LogMessage("", "Resources list missing", 3);
            }
            else
            {
                ProcessResources(oResourcePool);
                ProcessRoles(oResourcePool);
                ProcessWorkHours(oResourcePool);
                ProcessHolidays(oResourcePool);
                ProcessDepartments(oResourcePool);
                ProcessNonWork(oResourcePool);
            }

            return true;
        }

        private void ProcessResources(SPList oResourcePool)
        {
            new ListDataResourceProcessor(LogMessage, LogMessage).Process(oResourcePool);
        }

        private void ProcessRoles(SPList oResourcePool)
        {
            new ListDataRolesProcessor(SPWeb, LogMessage, LogMessage).Process(oResourcePool, bIsPfe);
        }

        private void ProcessWorkHours(SPList oResourcePool)
        {
            new ListDataWorkHoursProcessor(SPWeb, LogMessage, LogMessage).Process(oResourcePool, bIsPfe);
        }

        private void ProcessHolidays(SPList oResourcePool)
        {
            new ListDataHolidaysProcessor(SPWeb, LogMessage, LogMessage).Process(oResourcePool, bIsPfe);
        }

        private void ProcessDepartments(SPList oResourcePool)
        {
            new ListDataDepartmentsProcessor(SPWeb, LogMessage, LogMessage).Process(oResourcePool, bIsPfe);
        }

        private void ProcessNonWork(SPList oResourcePool)
        {
            new ListDataNonWorkProcessor(SPWeb, LogMessage, LogMessage).Process();
        }
    }
}
