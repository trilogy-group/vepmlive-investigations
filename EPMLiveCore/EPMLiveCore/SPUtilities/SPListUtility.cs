using EPMLiveCore.Infrastructure.Logging;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;

namespace EPMLiveCore.SPUtilities
{
    public static class SPListUtility
    {
        private const string _epmLiveReportingAssemblyFullName = "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050";
        private const string _epmLiveReportingListEventsClassName = "EPMLiveReportsAdmin.ListEvents";

        public static void MapListsReporting(SPWeb spWeb, Func<SPList, bool> checkIfListMappingRequiredFunc = null)
        {
            MapLists(
                spWeb, 
                _epmLiveReportingAssemblyFullName, 
                _epmLiveReportingListEventsClassName, 
                checkIfListMappingRequiredFunc
            );
        }

        public static void MapLists(
            SPWeb spWeb, 
            string assemblyName, 
            string className, 
            Func<SPList, bool> checkIfListMappingRequiredFunc = null)
        {
            var listsToBeMapped = new HashSet<Guid>();
            var listIconsToBeSet = new Dictionary<string, string>();

            foreach (SPList spList in spWeb.Lists)
            {
                if (!listsToBeMapped.Contains(spList.ID) 
                    && (checkIfListMappingRequiredFunc == null || checkIfListMappingRequiredFunc(spList))
                )
                {
                    var events = CoreFunctions.GetListEvents(
                        spList,
                        assemblyName,
                        className,
                        new[] {
                            SPEventReceiverType.ItemAdded,
                            SPEventReceiverType.ItemUpdated,
                            SPEventReceiverType.ItemDeleting
                        });

                    if (events.Count > 0)
                    {
                        listsToBeMapped.Add(spList.ID);

                        var listIcon = GetListIcon(spList);
                        if (listIcon != null)
                        {
                            listIconsToBeSet.Add(spList.ID.ToString(), listIcon);
                        }

                        continue;
                    }
                }
            }

            SetListsIcons(spWeb, listIconsToBeSet);

            // use reflection to map list
            MapLists(spWeb, listsToBeMapped);
        }

        private static string GetListIcon(SPList spList)
        {
            try
            {
                //Set List Icon
                var gSettings = new GridGanttSettings(spList);
                return gSettings.ListIcon;
            }
            catch (Exception ex)
            {
                LoggingService.WriteTrace(
                    Area.EPMLiveCore,
                    Categories.EPMLiveCore.Event,
                    TraceSeverity.Verbose,
                    ex.ToString()
                );
            }

            return null;
        }

        private static void SetListsIcons(SPWeb spWeb, Dictionary<string, string> listIconsToBeSet)
        {
            if (listIconsToBeSet.Count > 0)
            {
                try
                {
                    var epmData = new ReportHelper.EPMData(true, spWeb.Site.ID, spWeb.ID);
                    epmData.SetListIcon(listIconsToBeSet);
                }
                catch (Exception ex)
                {
                    LoggingService.WriteTrace(
                        Area.EPMLiveCore,
                        Categories.EPMLiveCore.Event,
                        TraceSeverity.Verbose,
                        ex.ToString()
                    );
                }
            }
        }

        private static void MapLists(SPWeb spWeb, HashSet<Guid> listsToBeMapped)
        {
            try
            {
                var epmData = new ReportHelper.EPMData(true, spWeb.Site.ID, spWeb.ID);
                epmData.MapLists(listsToBeMapped, spWeb.ID);
            }
            catch (Exception ex)
            {
                LoggingService.WriteTrace(
                    Area.EPMLiveCore,
                    Categories.EPMLiveCore.Event,
                    TraceSeverity.Verbose,
                    ex.ToString()
                );
            }
        }
    }
}
