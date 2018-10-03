using System;
using System.Diagnostics;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    internal class ListDataResourceProcessor: StepProcessor
    {
        internal ListDataResourceProcessor(
            Action<string> logMessage,
            Action<string, string, int> logMessageFormat)
            : base(logMessage, logMessageFormat) {}

        internal void Process(SPList resourcePool)
        {
            if (resourcePool == null)
            {
                throw new ArgumentNullException(nameof(resourcePool));
            }

            SPField mapId = null;

            try
            {
                mapId = resourcePool.Fields.GetFieldByInternalName("MAPID");
            }
            catch(Exception exception)
            {
                Trace.TraceError(exception.ToString());
            }

            if (mapId == null)
            {
                return;
            }

            LogMessage("Processing Resource Pool MAPID");

            foreach (SPListItem spListItem in resourcePool.Items)
            {
                var item = resourcePool.GetItemById(spListItem.ID);

                try
                {
                    if (!string.IsNullOrWhiteSpace(item["MAPID"]?.ToString()))
                    {
                        item["EXTID"] = item["MAPID"];
                    }
                    item.Update();

                }
                catch (Exception ex)
                {
                    LogMessage("\t", $"({item.Title}): {ex.Message}", 3);
                }
            }
        }
    }
}
