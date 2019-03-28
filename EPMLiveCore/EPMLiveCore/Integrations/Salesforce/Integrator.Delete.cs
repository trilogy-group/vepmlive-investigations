using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using EPMLiveCore.SalesforcePartnerService;
using EPMLiveIntegration;

namespace EPMLiveCore.Integrations.Salesforce
{
    public partial class Integrator
    {
        private static void LogDeletingErrors(IntegrationLog log, DeleteResult deleteResult, string sfId, string spId)
        {
            foreach (var error in deleteResult.errors)
            {
                log.LogMessage(
                    string.Format(
                        "Could not delete record with Salesforce ID: {0}, SharePoint ID: {1}. Status code: {2}. Message: {3}. Fields: {4}",
                        sfId,
                        spId,
                        error.statusCode,
                        error.message,
                        string.Join(",", error.fields)),
                    IntegrationLogType.Warning);
            }
        }

        public TransactionTable DeleteItems(WebProperties webProps, DataTable items, IntegrationLog log)
        {
            var transactionTable = new TransactionTable();

            try
            {
                if (!bool.Parse((string)webProps.Properties["AllowDeleteInt"]))
                {
                    throw new Exception("Salesforce delete is not allowed.");
                }

                var sfService = GetSfService(webProps);

                if (!sfService.IsSyncEnabled())
                {
                    throw new Exception("All synchronizations are currently disabled.");
                }

                List<string> ids;
                var idMap = BuildIdMap(items, out ids);

                var index = 0;

                foreach (var deleteResult in sfService.DeleteObjectItemsById(ids.ToArray()))
                {
                    var sfId = deleteResult.id;
                    string spId;

                    try
                    {
                        spId = idMap[sfId];
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                        spId = items.Rows[index]["SPID"].ToString();
                    }

                    if (deleteResult.success)
                    {
                        transactionTable.AddRow(spId, sfId, TransactionType.DELETE);
                    }
                    else
                    {
                        transactionTable.AddRow(spId, sfId, TransactionType.FAILED);
                        LogDeletingErrors(log, deleteResult, sfId, spId);
                    }

                    index++;
                }
            }
            catch (Exception e)
            {
                log.LogMessage(e.ToString(), IntegrationLogType.Error);
            }

            return transactionTable;
        }
    }
}