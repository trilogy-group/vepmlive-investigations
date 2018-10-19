using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public partial class MyWork
    {
        /// <summary>
        ///     Gets the settings.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="selectedFields">The selected fields.</param>
        /// <param name="selectedLists">The selected lists.</param>
        /// <param name="siteUrls">The site urls.</param>
        /// <param name="performanceMode">
        ///     if set to <c>true</c> [performance mode].
        /// </param>
        /// <param name="noListsSelected">
        ///     if set to <c>true</c> [no lists selected].
        /// </param>
        private static void GetSettings(string data)
        {
            try
            {
                var fieldsSupplied = false;
                var myWorkListsSupplied = false;
                var listsSupplied = false;
                var siteUrlsSupplied = false;
                var performanceModeSupplied = false;

                AddRangeSelectedList(
                    data,
                    ref listsSupplied,
                    ref myWorkListsSupplied,
                    ref fieldsSupplied,
                    ref siteUrlsSupplied,
                    ref performanceModeSupplied);

                GetConfigSettings(
                    listsSupplied,
                    myWorkListsSupplied,
                    fieldsSupplied,
                    siteUrlsSupplied,
                    performanceModeSupplied);

                GetMyWorkParams.SelectedLists.RemoveAll(string.IsNullOrWhiteSpace);
                GetMyWorkParams.NoListsSelected = GetMyWorkParams.SelectedLists.Count == 0;
                GetMyWorkParams.SelectedFields.RemoveAll(string.IsNullOrWhiteSpace);

                ProcessFieldValues(GetMyWorkParams.SelectedFields);
            }
            catch (APIException apiException)
            {
                Trace.WriteLine(apiException);
                throw;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new APIException(2007, exception.Message);
            }
        }

        private static void AddRangeSelectedList(
            string data,
            ref bool listsSupplied,
            ref bool myWorkListsSupplied,
            ref bool fieldsSupplied,
            ref bool siteUrlsSupplied,
            ref bool performanceModeSupplied)
        {
            Action<List<XElement>, XDocument, string, List<string>, Action> addRangeSelectedList = (descendants, xDocument, elementName, listsSelected, setFlag) =>
            {
                if (descendants.Exists(
                    e => e.Name.LocalName.Equals(ListsText)))
                {
                    listsSelected.AddRange(
                        xDocument.Element(nameof(MyWork))
                           .Element(elementName)
                           .Value.Split(CharComma)
                           .Where(field => !string.IsNullOrWhiteSpace(field)));
                    setFlag();
                }
            };

            if (!string.IsNullOrWhiteSpace(data))
            {
                var xDocument = XDocument.Parse(data);
                var descendants = xDocument.Element(nameof(MyWork))
                   .Descendants()
                   .ToList();

                if (xDocument.Descendants().ToList().Exists(e => e.Name.LocalName.Equals(nameof(MyWork))))
                {
                    var tempListsSupplied = listsSupplied;
                    var tempMyWorkListsSupplied = myWorkListsSupplied;
                    var tempFieldsSupplied = fieldsSupplied;

                    addRangeSelectedList(descendants, xDocument, ListsText, GetMyWorkParams.SelectedLists, () => tempListsSupplied = true);
                    addRangeSelectedList(descendants, xDocument, MyWorkLists, GetMyWorkParams.SelectedLists, () => tempMyWorkListsSupplied = true);
                    addRangeSelectedList(descendants, xDocument, Fields, GetMyWorkParams.SelectedFields, () => tempFieldsSupplied = true);

                    listsSupplied = tempListsSupplied;
                    myWorkListsSupplied = tempMyWorkListsSupplied;
                    fieldsSupplied = tempFieldsSupplied;

                    if (descendants.Exists(
                        e => e.Name.LocalName.Equals(CrossSiteUrls)))
                    {
                        if (!string.IsNullOrWhiteSpace(xDocument.Element(nameof(MyWork)).Element(CrossSiteUrls).Value))
                        {
                            GetMyWorkParams.SiteUrls.AddRange(
                                xDocument.Element(nameof(MyWork))
                                   .Element(CrossSiteUrls)
                                   .Value.Split(
                                        CharComma)
                                   .Where(crossSite => !string.IsNullOrWhiteSpace(crossSite)));

                            siteUrlsSupplied = true;
                        }
                    }

                    if (xDocument.Element(nameof(MyWork))
                       .Descendants()
                       .ToList()
                       .Exists(
                            e => e.Name.LocalName.Equals(PerformanceMode)))
                    {
                        GetMyWorkParams.PerformanceMode = xDocument.Element(nameof(MyWork)).Element(PerformanceMode).Value.Equals(On);
                        performanceModeSupplied = true;
                    }
                }
            }
        }

        private static void ProcessFieldValues(List<string> selectedFields)
        {
            Guard.ArgumentIsNotNull(selectedFields, nameof(selectedFields));

            var fieldsToRemove = new[] {WorkTypeField, ListIdField, WebIdField, SiteIdField, SiteUrlField};

            foreach (var field in fieldsToRemove)
            {
                selectedFields.RemoveAll(f => f.ToLower().Equals(field.ToLower()));
            }

            var fixedFields = new[]
            {
                CompletedField, CommentCountField, PriorityField, FlagField, TitleField,
                DueDateField,
                CreatedField, CreatedByField, ModifiedField, ModifiedByField,
                CommentersField,
                CommentersReadField
            };

            foreach (var field in fixedFields.Where(field => !selectedFields.Exists(f => f.Equals(field))))
            {
                selectedFields.Add(field);
            }
        }

        private static void GetConfigSettings(
            bool listsSupplied,
            bool myWorkListsSupplied,
            bool fieldsSupplied,
            bool siteUrlsSupplied,
            bool performanceModeSupplied)
        {
            var theWeb = SPContext.Current.Web;
            var lockedWeb = CoreFunctions.getLockedWeb(theWeb);

            using (var configWeb = Utils.GetConfigWeb(theWeb, lockedWeb))
            {
                if (!listsSupplied)
                {
                    GetMyWorkParams.SelectedLists.AddRange(
                        CoreFunctions.getConfigSetting(configWeb, GeneralSettingsSelectedLists)
                           .Split(CharComma));
                }

                if (!myWorkListsSupplied)
                {
                    GetMyWorkParams.SelectedLists.AddRange(
                        CoreFunctions.getConfigSetting(configWeb, GeneralSettingsSelectedMyWorkLists)
                           .Split(CharComma));
                }

                if (!fieldsSupplied)
                {
                    GetMyWorkParams.SelectedFields.AddRange(
                        CoreFunctions.getConfigSetting(configWeb, GeneralSettingsSelectedFields).Split(CharComma).Distinct());
                }

                if (!siteUrlsSupplied)
                {
                    var siteUrls = CoreFunctions.getConfigSetting(configWeb, GeneralSettingsCrossSiteUrls);

                    if (!string.IsNullOrWhiteSpace(siteUrls))
                    {
                        GetMyWorkParams.SiteUrls.AddRange(siteUrls.Split(CharVerticalBar));
                    }
                    else
                    {
                        GetMyWorkParams.SiteUrls.Add(SPContext.Current.Web.Url);
                    }
                }

                if (!performanceModeSupplied)
                {
                    GetMyWorkParams.PerformanceMode = CoreFunctions.getConfigSetting(configWeb, GeneralSettingsPerformanceMode)
                       .Equals(On);
                }
            }
        }
    }
}