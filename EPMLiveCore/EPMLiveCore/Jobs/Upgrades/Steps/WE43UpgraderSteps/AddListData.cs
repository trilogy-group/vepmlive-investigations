using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    [JobStep("WE43Upgrader", 30)]

    public class AddListData : Step
    {
        private readonly ListDataResourceProcessor _listDataResourceProcessor;
        private readonly ListDataRolesProcessor _listDataRolesProcessor;
        private readonly ListDataWorkHoursProcessor _listDataWorkHoursProcessor;
        private readonly ListDataHolidaysProcessor _listDataHolidaysProcessor;
        private readonly ListDataDepartmentsProcessor _listDataDepartmentsProcessor;
        private readonly ListDataNonWorkProcessor _listDataNonWorkProcessor;

        public AddListData(SPWeb spWeb, string data, int stepNumber, bool bispfe)
            : base(spWeb, data, stepNumber, bispfe)
        {
            _listDataResourceProcessor = new ListDataResourceProcessor(LogMessage, LogMessage);
            _listDataRolesProcessor = new ListDataRolesProcessor(SPWeb, LogMessage, LogMessage);
            _listDataWorkHoursProcessor = new ListDataWorkHoursProcessor(SPWeb, LogMessage, LogMessage);
            _listDataHolidaysProcessor = new ListDataHolidaysProcessor(SPWeb, LogMessage, LogMessage);
            _listDataDepartmentsProcessor = new ListDataDepartmentsProcessor(SPWeb, LogMessage, LogMessage);
            _listDataNonWorkProcessor = new ListDataNonWorkProcessor(SPWeb, LogMessage, LogMessage);
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
            _listDataResourceProcessor.Process(oResourcePool);
        }

        private void ProcessRoles(SPList oResourcePool)
        {
            _listDataRolesProcessor.Process(oResourcePool, bIsPfe);
        }

        private void ProcessWorkHours(SPList oResourcePool)
        {
            _listDataWorkHoursProcessor.Process(oResourcePool, bIsPfe);
        }

        private void ProcessHolidays(SPList oResourcePool)
        {
            _listDataHolidaysProcessor.Process(oResourcePool, bIsPfe);
        }

        private void ProcessDepartments(SPList oResourcePool)
        {
            _listDataDepartmentsProcessor.Process(oResourcePool, bIsPfe);
        }

        private void ProcessNonWork(SPList oResourcePool)
        {
            _listDataNonWorkProcessor.Process();
        }
    }
}
