using System;
using System.Data;
using System.Diagnostics;
using System.Threading;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    internal class ListDataDepartmentsProcessor : StepProcessor
    {
        private readonly SPWeb _spWeb;

        internal ListDataDepartmentsProcessor(
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

            LogMessage("Processing Departments");

            var departments = _spWeb.Lists.TryGetList("Departments");

            if (departments != null)
            {
                if (isPfe)
                {
                    LogMessage("\tReading Departments from PfE");

                    try
                    {
                        var resourcePoolItem = resourcePool.Items[0];

                        var lookupValue = new SPFieldLookupValue(resourcePoolItem.ID, resourcePoolItem.Title);

                        var item = departments.Items.Add();
                        item["Title"] = "TEMPDEPTDELETEME";
                        item["Managers"] = lookupValue;
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

                        var itemToDeleteId = 0;

                        var spListItemCollection = departments.Items;
                        foreach (SPListItem spListItem in spListItemCollection)
                        {
                            if (spListItem["Title"].Equals("TEMPDEPTDELETEME"))
                            {
                                itemToDeleteId = spListItem.ID;
                            }
                        }

                        if (itemToDeleteId != 0)
                        {
                            var spListItem = departments.GetItemById(itemToDeleteId);
                            spListItem.Delete();
                        }
                    }
                    catch (Exception exception)
                    {
                        LogMessage(string.Empty, $"Error: {exception.Message}", 3);
                    }
                }
                else
                {
                    LogMessage("\tReading Departments from Resource Pool");

                    SPField field = null;
                    try
                    {
                        field = resourcePool.Fields.GetFieldByInternalName("Department");
                    }
                    catch(Exception exception)
                    {
                        Trace.TraceError(exception.ToString());
                    }

                    if (field != null)
                    {
                        if (field.Type == SPFieldType.Lookup)
                        {
                            LogMessage(string.Empty, "Departments Field already upgraded", 2);
                        }
                        else if (field.Type == SPFieldType.Choice)
                        {
                            try
                            {
                                var table = departments.Items.GetDataTable();

                                var fieldChoice = (SPFieldChoice)field;
                                foreach (var choice in fieldChoice.Choices)
                                {
                                    var rows = (table == null ? new DataRow[0] : table.Select($"Title=\'{choice}\'"));

                                    if (rows.Length <= 0)
                                    {
                                        LogMessage($"\tAdd: {choice}");
                                        var item = departments.Items.Add();
                                        item["Title"] = choice;
                                        item.Update();
                                    }
                                    else
                                    {
                                        LogMessage("\t", $"Add: {choice}", 2);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                LogMessage(string.Empty, $"Error: {ex.Message}", 3);
                            }
                        }
                        else
                        {
                            LogMessage(string.Empty, "Departments Field not a choice field", 2);
                        }
                    }
                    else
                    {
                        LogMessage(string.Empty, "Department Field missing from resource pool", 3);
                    }
                }
            }
            else
            {
                LogMessage(string.Empty, "Departments list missing", 3);
            }
        }
    }
}
