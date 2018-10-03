using System;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    internal class ListDataWorkHoursProcessor : StepProcessor
    {
        private readonly SPWeb _spWeb;

        internal ListDataWorkHoursProcessor(
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

        internal void Process(SPList resourcePool, bool isPfe)
        {
            if (resourcePool == null)
            {
                throw new ArgumentNullException(nameof(resourcePool));
            }

            LogMessage("Processing Work Hours");

            var workHours = _spWeb.Lists.TryGetList("Work Hours");

            if (workHours != null)
            {
                if (isPfe)
                {
                    LogMessage("\tReading Work Hours from PfE");

                    try
                    {
                        var listItem = workHours.Items.Add();
                        listItem["Title"] = "TEMPWORKDELETEME";
                        listItem["Monday"] = 8;
                        listItem["Tuesday"] = 8;
                        listItem["Wednesday"] = 8;
                        listItem["Thursday"] = 8;
                        listItem["Friday"] = 8;
                        listItem["Saturday"] = 0;
                        listItem["Sunday"] = 0;
                        listItem.Update();
                        listItem.Delete();
                    }
                    catch (Exception exception)
                    {
                        LogMessage(string.Empty, $"Error: {exception.Message}", 3);
                    }
                }
                else
                {
                    if (workHours.Items.Count == 0)
                    {
                        LogMessage("\tAdding default work hours");

                        try
                        {
                            var listItem = workHours.Items.Add();
                            listItem["Title"] = "US Work Hours";
                            listItem["Monday"] = 8;
                            listItem["Tuesday"] = 8;
                            listItem["Wednesday"] = 8;
                            listItem["Thursday"] = 8;
                            listItem["Friday"] = 8;
                            listItem.Update();
                        }
                        catch (Exception exception)
                        {
                            LogMessage(string.Empty, $"Error: {exception.Message}", 3);
                        }
                    }
                }
            }
            else
            {
                LogMessage(string.Empty, "WorkHours list missing", 3);
            }
        }
    }
}
