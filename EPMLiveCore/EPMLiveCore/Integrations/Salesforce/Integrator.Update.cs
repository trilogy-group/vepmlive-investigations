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
        private static void LogUpdateErrors(IntegrationLog log, SaveResult upsertResult, string sfId, string spId)
        {
            if (upsertResult.errors.Any())
            {
                foreach (var error in upsertResult.errors)
                {
                    var fields = string.Empty;

                    if (error.fields != null)
                    {
                        try
                        {
                            fields = $"Fields: {string.Join(",", error.fields)}.";
                        }
                        catch (Exception ex)
                        {
                            Trace.TraceError("Exception Suppressed {0}", ex);
                        }
                    }

                    log.LogMessage(
                        string.Format(
                            "Could not insert / update record with Salesforce ID: {0}, SharePoint ID: {1}. Status code: {2}. Message: {3} {4}",
                            sfId,
                            spId,
                            error.statusCode,
                            error.message,
                            fields),
                        IntegrationLogType.Warning);
                }
            }
        }

        public TransactionTable UpdateItems(WebProperties webProps, DataTable items, IntegrationLog log)
        {
            var transactionTable = new TransactionTable();

            try
            {
                var sfService = GetSfService(webProps);

                if (!sfService.IsSyncEnabled())
                {
                    throw new Exception("All synchronizations are currently disabled.");
                }

                List<string> ids;
                var idMap = BuildIdMap(items, out ids);

                var index = 0;

                foreach (var result in sfService.UpsertItems((string)webProps.Properties["Object"], items))
                {
                    foreach (var pair in result)
                    {
                        var upsertResult = pair.Value;

                        var sfId = upsertResult.id;
                        string spId;

                        try
                        {
                            spId = idMap[sfId];
                        }
                        catch
                        {
                            spId = items.Rows[index]["SPID"].ToString();
                        }

                        if (upsertResult.success)
                        {
                            transactionTable.AddRow(
                                spId,
                                sfId,
                                pair.Key == UpsertKind.INSERT
                                    ? TransactionType.INSERT
                                    : TransactionType.UPDATE);
                        }
                        else
                        {
                            transactionTable.AddRow(spId, sfId, TransactionType.FAILED);
                            LogUpdateErrors(log, upsertResult, sfId, spId);
                        }
                    }

                    index++;
                }
            }
            catch (Exception e)
            {
                log.LogMessage(e.Message, IntegrationLogType.Error);
            }

            return transactionTable;
        }
    }
}