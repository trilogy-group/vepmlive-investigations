using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    internal class ListDataHolidaysProcessor : StepProcessor
    {
        private readonly SPWeb _spWeb;

        internal ListDataHolidaysProcessor(
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

            LogMessage("Processing Holidays");

            var oHolidays = _spWeb.Lists.TryGetList("Holidays");
            var oHolidaySchedules = _spWeb.Lists.TryGetList("Holiday Schedules");

            if (oHolidays == null)
            {
                LogMessage(string.Empty, "Holidays list missing", 3);
            }
            else if (oHolidaySchedules == null)
            {
                LogMessage(string.Empty, "Holiday Schedules list missing", 3);
            }
            else
            {
                if (isPfe)
                {
                    LogMessage("\tReading Holidays from PfE");

                    try
                    {
                        var item = oHolidaySchedules.Items.Add();
                        item["Title"] = "TEMPScheduleDELETEME";
                        item.Update();

                        var error = false;
                        var iCounter = 0;

                        while (!error && iCounter < 5)
                        {
                            try
                            {
                                item.Delete();
                                Thread.Sleep(1000);
                            }
                            catch
                            {
                                error = true;
                            }
                            finally
                            {
                                iCounter++;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogMessage(string.Empty, ex.Message, 3);
                    }
                }
                else
                {
                    LogMessage("\tAdding Holiday Schedule");

                    SPFieldLookupValue lookupValue = null;

                    try
                    {
                        if (oHolidaySchedules.Items.Count == 0)
                        {
                            var item = oHolidaySchedules.Items.Add();
                            item["Title"] = "US Holidays";
                            item.Update();

                            lookupValue = new SPFieldLookupValue(item.ID, item.Title);
                        }
                        else
                        {
                            var listItem = oHolidaySchedules.Items[0];
                            lookupValue = new SPFieldLookupValue(listItem.ID, listItem.Title);
                        }
                    }
                    catch (Exception exception)
                    {
                        LogMessage(string.Empty, $"Error: {exception.Message}", 3);
                    }

                    SPField oHsField = null;
                    try
                    {
                        oHsField = oHolidays.Fields.GetFieldByInternalName("HolidaySchedule");
                    }
                    catch(Exception exception)
                    {
                        Trace.TraceError(exception.ToString());
                    }

                    if (lookupValue != null && oHsField != null)
                    {
                        LogMessage("\tAdding Holidays To Schedule");

                        foreach (SPListItem listItem in oHolidays.Items)
                        {
                            if (listItem[oHsField.Id] == null)
                            {
                                LogMessage($"\t\t{listItem.Title}");
                                listItem[oHsField.Id] = lookupValue;
                                listItem.Update();
                            }
                            else
                            {
                                LogMessage("\t", listItem.Title, 2);
                            }
                        }
                    }
                }
            }
        }
    }
}
