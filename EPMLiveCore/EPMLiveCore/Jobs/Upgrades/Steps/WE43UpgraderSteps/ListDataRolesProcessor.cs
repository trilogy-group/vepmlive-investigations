using System;
using System.Data;
using System.Diagnostics;
using System.Threading;
using Microsoft.SharePoint;
using Exception = System.Exception;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    internal class ListDataRolesProcessor : StepProcessor
    {
        private readonly SPWeb _spWeb;

        internal ListDataRolesProcessor(
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

            LogMessage("Processing Roles");

            var roles = _spWeb.Lists.TryGetList("Roles");
            if (roles != null)
            {
                if (isPfe)
                {
                    LogMessage("\tReading Roles from PfE");

                    try
                    {
                        var listItem = roles.Items.Add();
                        listItem["Title"] = "TEMPROLEDELETEME";
                        listItem.Update();

                        var error = false;
                        var iCounter = 0;

                        while (!error && iCounter < 5)
                        {
                            try
                            {
                                listItem.Delete();
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
                        var spListItemCollection = roles.Items;
                        foreach (SPListItem spListItem in spListItemCollection)
                        {
                            if (spListItem["Title"].Equals("TEMPROLEDELETEME"))
                            {
                                itemToDeleteId = spListItem.ID;
                            }
                        }

                        if (itemToDeleteId != 0)
                        {
                            var spListItem = roles.GetItemById(itemToDeleteId);
                            spListItem.Delete();
                        }
                    }
                    catch (Exception ex)
                    {
                        LogMessage(string.Empty, $"Error: {ex.Message}", 3);
                    }
                }
                else
                {
                    LogMessage("\tReading Roles from Resource Pool");

                    SPField field = null;
                    try
                    {
                        field = resourcePool.Fields.GetFieldByInternalName("Role");
                    }
                    catch (Exception exception)
                    {
                        Trace.TraceError(exception.ToString());
                    }

                    if (field != null)
                    {
                        if (field.Type == SPFieldType.Lookup)
                        {
                            LogMessage(string.Empty, "Roles Field already upgraded", 2);
                        }
                        else if (field.Type == SPFieldType.Choice)
                        {
                            try
                            {
                                var table = roles.Items.GetDataTable();

                                var fieldChoice = (SPFieldChoice)field;
                                foreach (var choice in fieldChoice.Choices)
                                {
                                    var rows = (table == null ? new DataRow[0] : table.Select($"Title=\'{choice}\'"));

                                    if (rows.Length <= 0)
                                    {
                                        LogMessage($"\tAdd: {choice}");
                                        var item = roles.Items.Add();
                                        item["Title"] = choice;
                                        item.Update();
                                    }
                                    else
                                    {
                                        LogMessage("\t", $"Add: {choice}", 2);
                                    }
                                }
                            }
                            catch (Exception exception)
                            {
                                LogMessage(string.Empty, $"Error: {exception.Message}", 3);
                            }
                        }
                        else
                        {
                            LogMessage(string.Empty, "Roles Field not a choice field", 2);
                        }
                    }
                    else
                    {
                        LogMessage(string.Empty, "Roles Field missing from resource pool", 3);
                    }
                }
            }
            else
            {
                LogMessage(string.Empty, "Roles list missing", 3);
            }
        }
    }
}
