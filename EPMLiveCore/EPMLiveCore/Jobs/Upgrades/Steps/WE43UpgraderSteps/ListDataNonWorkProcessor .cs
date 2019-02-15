using System;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    internal class ListDataNonWorkProcessor : StepProcessor
    {
        private readonly SPWeb _spWeb;

        internal ListDataNonWorkProcessor(
            SPWeb spWeb,
            Action<string> logMessage,
            Action<string, string, int> logMessageFormat)
            : base(logMessage, logMessageFormat)
        {
            if (spWeb == null)
            {
                throw new ArgumentNullException(nameof(spWeb));
            }
            _spWeb = spWeb;
        }

        internal void Process()
        {
            LogMessage("Processing Non Work");

            var oNonWork = _spWeb.Lists.TryGetList("Non Work");
            var oTimeOff = _spWeb.Lists.TryGetList("Time Off");

            if (oNonWork == null)
            {
                LogMessage(string.Empty, "Non Work list missing", 3);
            }
            else if (oTimeOff == null)
            {
                LogMessage(string.Empty, "Time Off list missing", 3);
            }
            else
            {
                var table = oNonWork.Items.GetDataTable();
                try
                {
                    var field = oTimeOff.Fields.GetFieldByInternalName("TimeOffType");
                    if (field.Type == SPFieldType.Choice)
                    {

                        var fieldChoice = (SPFieldChoice)field;

                        foreach (var choice in fieldChoice.Choices)
                        {
                            try
                            {
                                var rows = table.Select($"Title=\'{choice}\'");
                                if (rows.Length == 0)
                                {
                                    var item = oNonWork.Items.Add();
                                    item["Title"] = choice;
                                    item.Update();
                                    LogMessage($"\t{choice}");
                                }
                            }
                            catch (Exception ex)
                            {
                                LogMessage(string.Empty, $"{choice}: {ex.Message}", 3);
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    LogMessage(string.Empty, exception.Message, 3);
                }
            }
        }
    }
}
