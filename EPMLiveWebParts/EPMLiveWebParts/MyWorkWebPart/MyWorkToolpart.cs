using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using EPMLiveCore;
using EPMLiveCore.API;
using EPMLiveWebParts.Properties;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebPartPages;

namespace EPMLiveWebParts
{
    [ToolboxData("<{0}:CustomToolPart runat=server></{0}:CustomToolPart>")]
    public class MyWorkToolpart : ToolPart
    {
        #region Fields (1) 

        private readonly SPWeb _web = SPContext.Current.Web;

        #endregion Fields 

        #region Constructors (1) 

        public MyWorkToolpart()
        {
            UseDefaultStyles = true;
            AllowMinimize = true;
            Title = "My Work Properties";
        }

        #endregion Constructors 

        #region Methods (2) 

        // Public Methods (1) 

        /// <summary>
        ///     Called when the user clicks the OK or the Apply button in the tool pane.
        /// </summary>
        public override void ApplyChanges()
        {
            var myWorkWebPart = (MyWorkWebPart) ParentToolPane.SelectedWebPart;

            string uniqueId = UniqueID.Md5();

            string useCentralizedSettings = Page.Request.Form[string.Format(@"cbUseCentralizedSettings_{0}", uniqueId)];
            string performanceMode = Page.Request.Form[string.Format(@"cbPerformanceMode_{0}", uniqueId)];
            string showToolbar = Page.Request.Form[string.Format(@"cbShowToolbar_{0}", uniqueId)];
            string daysAgoEnabled = Page.Request.Form[string.Format(@"cbDaysAgo_{0}", uniqueId)];
            string daysAfterEnabled = Page.Request.Form[string.Format(@"cbDaysAfter_{0}", uniqueId)];
            string newItemIndicatorEnabled = Page.Request.Form[string.Format(@"cbNewItemIndicator_{0}", uniqueId)];
            string daysAgo = Page.Request.Form[string.Format(@"tbDaysAgo_{0}", uniqueId)];
            string daysAfter = Page.Request.Form[string.Format(@"tbDaysAfter_{0}", uniqueId)];
            string newItemIndicator = Page.Request.Form[string.Format(@"tbNewItemIndicator_{0}", uniqueId)];
            string hideNewButton = Page.Request.Form[string.Format(@"cbHideNewButton_{0}", uniqueId)];
            string allowEditToggle = Page.Request.Form[string.Format(@"cbAllowEditToggle_{0}", uniqueId)];
            string defaultToEditMode = Page.Request.Form[string.Format(@"cbDefaultToEditMode_{0}", uniqueId)];
            string selectedLists = Page.Request.Form[string.Format(@"tbLists_{0}", uniqueId)];
            string myWorkSelectedLists = Page.Request.Form[string.Format(@"selectedMyWorkLists_{0}", uniqueId)];
            string selectedFields = Page.Request.Form[string.Format(@"selectedFields_{0}", uniqueId)];
            string crossSiteUrls = Page.Request.Form[string.Format(@"tbCrossSiteUrls_{0}", uniqueId)];
            string defaultGlobalView = Page.Request.Form[string.Format(@"defaultGlobalViews_{0}", uniqueId)];

            myWorkWebPart.UseCentralizedSettings = !string.IsNullOrEmpty(useCentralizedSettings) &&
                                                   useCentralizedSettings.Equals("on");
            myWorkWebPart.PerformanceMode = !string.IsNullOrEmpty(performanceMode) && performanceMode.Equals("on");
            myWorkWebPart.ShowToolbar = !string.IsNullOrEmpty(showToolbar) && showToolbar.Equals("on");

            string daysAgoValue = string.Empty;
            string daysAfterValue = string.Empty;

            if (!string.IsNullOrEmpty(daysAgo))
            {
                string text = daysAgo.Trim();
                int days;
                if (int.TryParse(text, out days))
                {
                    if (days > 0) daysAgoValue = text;
                }
            }

            if (!string.IsNullOrEmpty(daysAfter))
            {
                string text = daysAfter.Trim();
                int days;
                if (int.TryParse(text, out days))
                {
                    if (days > 0) daysAfterValue = text;
                }
            }

            string dayFilters =
                string.Format("{0}|{1}|{2}|{3}", !string.IsNullOrEmpty(daysAgoEnabled) && daysAgoEnabled.Equals("on"),
                              daysAgoValue, !string.IsNullOrEmpty(daysAfterEnabled) && daysAfterEnabled.Equals("on"),
                              daysAfterValue).ToLower();

            myWorkWebPart.DueDayFilter = dayFilters;

            string daysIndicator = string.Empty;

            if (!string.IsNullOrEmpty(newItemIndicator))
            {
                string text = newItemIndicator.Trim();
                int days;
                if (int.TryParse(text, out days))
                {
                    if (days > 0) daysIndicator = text;
                }
            }

            myWorkWebPart.NewItemIndicator =
                string.Format("{0}|{1}",
                              !string.IsNullOrEmpty(newItemIndicatorEnabled) && newItemIndicatorEnabled.Equals("on"),
                              daysIndicator).ToLower();

            myWorkWebPart.HideNewButton = !string.IsNullOrEmpty(hideNewButton) && hideNewButton.Equals("on");
            myWorkWebPart.AllowEditToggle = !string.IsNullOrEmpty(allowEditToggle) && allowEditToggle.Equals("on");
            myWorkWebPart.DefaultToEditMode = !string.IsNullOrEmpty(defaultToEditMode) && defaultToEditMode.Equals("on");

            myWorkWebPart.MyWorkSelectedLists = myWorkSelectedLists.Split(',');

            myWorkWebPart.SelectedLists = selectedLists.Replace("\r\n", ",").Split(',')
                                                       .Select(list => SPEncode.HtmlEncode(list.Trim()))
                                                       .ToList()
                                                       .Distinct()
                                                       .Where(list => !myWorkWebPart.MyWorkSelectedLists.Contains(list))
                                                       .ToArray();

            myWorkWebPart.SelectedFields = selectedFields.Split(',');

            myWorkWebPart.CrossSiteUrls =
                crossSiteUrls.Replace("\r\n", "|").Split('|').Select(site => SPEncode.HtmlEncode(site.Trim())).ToList().
                              Distinct().ToArray();

            myWorkWebPart.DefaultGlobalView = defaultGlobalView;
        }

        // Protected Methods (1) 

        /// <summary>
        ///     Sends the tool part content to the specified HtmlTextWriter object, which writes the content to be rendered on the client.
        /// </summary>
        /// <param name="output">The HtmlTextWriter object that receives the tool part content.</param>
        protected override void RenderToolPart(HtmlTextWriter output)
        {
            var myWorkWebPart = (MyWorkWebPart) ParentToolPane.SelectedWebPart;

            string myWorkWebPartHtmlCode = Resources.MyWorkToolPart.Replace("_ID__", UniqueID.Md5());

            #region Get Settings

            string selectedLists = string.Empty;

            if (myWorkWebPart.SelectedLists != null)
            {
                IOrderedEnumerable<string> selLists = (myWorkWebPart.SelectedLists.Where(
                    selectedList => !string.IsNullOrEmpty(selectedList))
                                                                    .Select(
                                                                        selectedList =>
                                                                        string.Format(@"'{0}'", selectedList))).ToList()
                                                                                                               .OrderBy(
                                                                                                                   l =>
                                                                                                                   l);

                selectedLists = string.Join(",", selLists.ToArray());
            }

            string selectedFields = string.Empty;

            if (myWorkWebPart.SelectedFields != null)
            {
                IOrderedEnumerable<string> selFields = (myWorkWebPart.SelectedFields.Where(
                    selectedField => !string.IsNullOrEmpty(selectedField))
                                                                     .Select(
                                                                         selectedField =>
                                                                         string.Format(
                                                                             @"{{InternalName:'{0}',PrettyName:'{1}'}}",
                                                                             selectedField,
                                                                             selectedField.ToPrettierName()))).ToList().
                                                                                                               OrderBy(
                                                                                                                   f =>
                                                                                                                   f);

                selectedFields = string.Join(",", selFields.ToArray());
            }

            List<myworksettings.MWList> myWorkLists = myworksettings.GetMyWorkListsFromDb(_web,
                                                                                          MyWork.GetArchivedWebs(
                                                                                              _web.Site.ID));

            var includedMWLists = new List<string>();
            List<myworksettings.MWList> excludedMWLists = myWorkLists.ToList();

            if (myWorkWebPart.MyWorkSelectedLists.Count() > 0)
            {
                foreach (
                    myworksettings.MWList myWorkList in
                        myWorkLists.Where(myWorkList => myWorkWebPart.MyWorkSelectedLists.Contains(myWorkList.Name)))
                {
                    includedMWLists.Add(string.Format(@"{{Id:'{0}',Name:'{1}'}}", myWorkList.Id, myWorkList.Name));
                    excludedMWLists.Remove(myWorkList);
                }
            }
            else
            {
                includedMWLists = excludedMWLists.Select(excludedMWList => string.Format(@"{{Id:'{0}',Name:'{1}'}}",
                                                                                         excludedMWList.Id,
                                                                                         excludedMWList.Name)).ToList();

                excludedMWLists = new List<myworksettings.MWList>();
            }

            string includedMyWorkLists = string.Join(",", includedMWLists.ToArray());

            IEnumerable<string> excludedLists =
                excludedMWLists.Select(
                    excludedMWList =>
                    string.Format(@"{{Id:'{0}',Name:'{1}'}}", excludedMWList.Id,
                                  SPHttpUtility.HtmlEncode(excludedMWList.Name)));
            string excludedMyWorkLists = string.Join(",", excludedLists.ToArray());

            string crossSiteUrls = string.Empty;

            if (myWorkWebPart.CrossSiteUrls != null)
            {
                IOrderedEnumerable<string> crossSites = myWorkWebPart.CrossSiteUrls.Where(
                    crossSiteUrl => !string.IsNullOrEmpty(crossSiteUrl))
                                                                     .Select(
                                                                         crossSiteUrl =>
                                                                         string.Format(@"'{0}'", crossSiteUrl))
                                                                     .OrderBy(s => s);
                crossSiteUrls = string.Join(",", crossSites.ToArray());
            }

            var defaultGlobalViews = new List<string>();

            bool defaultViewFound = false;

            List<MyWorkGridView> myWorkGridViews =
                MyWork.GetGlobalViews(Utils.GetConfigWeb()).OrderBy(v => v.Name).ToList();

            foreach (MyWorkGridView myWorkGridView in myWorkGridViews)
            {
                bool defaultView = myWorkWebPart.DefaultGlobalView.Equals(myWorkGridView.Id);
                if (defaultView) defaultViewFound = true;

                defaultGlobalViews.Add(string.Format(@"{{Id:'{0}',Name:'{1}',Default:{2}}}", myWorkGridView.Id,
                                                     myWorkGridView.Name, defaultView.Lc()));
            }

            defaultGlobalViews.Insert(0,
                                      string.Format(@"{{Id:'',Name:'Do Not Set View',Default:{0}}}",
                                                    (!defaultViewFound).Lc()));

            string objDefaultGlobalViews = string.Join(",", defaultGlobalViews.ToArray());

            bool agoFilterEnabled = false;
            int agoFilterDays = 0;
            bool afterFilterEnabled = false;
            int afterFilterDays = 0;

            bool indicatorActive = true;
            int indicatorDays = 2;

            if (!string.IsNullOrEmpty(myWorkWebPart.DueDayFilter))
            {
                string[] filters = myWorkWebPart.DueDayFilter.Split('|');

                bool.TryParse(filters[0], out agoFilterEnabled);
                int.TryParse(filters[1], out agoFilterDays);
                bool.TryParse(filters[2], out afterFilterEnabled);
                int.TryParse(filters[3], out afterFilterDays);
            }

            if (!string.IsNullOrEmpty(myWorkWebPart.NewItemIndicator))
            {
                string[] settings = myWorkWebPart.NewItemIndicator.Split('|');

                bool.TryParse(settings[0], out indicatorActive);
                int.TryParse(settings[1], out indicatorDays);
            }

            string myWorkObjString =
                string.Format(
                    @"useCentralizedSettings:{0}, selectedLists:[{1}], selectedFields:[{2}], crossSiteUrls:[{3}], performanceMode:{4}, hideNewButton:{5}, allowEditToggle:{6}, defaultToEditMode:{7}, defaultGlobalViews:[{8}], includedMyWorkLists:[{9}], excludedMyWorkLists:[{10}], daysAgoEnabled:{11}, daysAfterEnabled:{12}, newItemIndicatorEnabled:{13}, daysAgo:'{14}', daysAfter:'{15}', newItemIndicator:'{16}', showToolbar:{17}",
                    myWorkWebPart.UseCentralizedSettings.Lc(), selectedLists, selectedFields, crossSiteUrls,
                    myWorkWebPart.PerformanceMode.Lc(), myWorkWebPart.HideNewButton.Lc(),
                    myWorkWebPart.AllowEditToggle.Lc(), myWorkWebPart.DefaultToEditMode.Lc(), objDefaultGlobalViews,
                    includedMyWorkLists, excludedMyWorkLists, agoFilterEnabled.Lc(),
                    afterFilterEnabled.Lc(), indicatorActive.Lc(),
                    agoFilterDays, afterFilterDays, indicatorDays, myWorkWebPart.ShowToolbar.Lc());

            myWorkWebPartHtmlCode = myWorkWebPartHtmlCode.Replace("objMyWork__VAL__", myWorkObjString);

            #endregion

            #region Get All Lists and Fields

            var listsAndFields = new Dictionary<string, List<string>>();
            foreach (SPList list in _web.Lists)
            {
                try
                {
                    listsAndFields.Add(list.Title,
                                   (list.Fields.Cast<SPField>()
                                        .Where(spField => !spField.Hidden && spField.Reorderable)
                                        .Select(spField => spField.InternalName)).ToList());
                }
                catch { }
            }

            string allListsAndFieldsString =
                string.Format(@"{0}",
                              string.Join(",", listsAndFields.Select(listAndFields =>
                                                                     string.Format(@"{{List:'{0}',Fields:[{1}]}}",
                                                                                   listAndFields.Key,
                                                                                   string.Join(",",
                                                                                               listAndFields.Value.
                                                                                                             Select(
                                                                                                                 field
                                                                                                                 =>
                                                                                                                 string
                                                                                                                     .Format
                                                                                                                     (
                                                                                                                         @"{{InternalName:'{0}',PrettyName:'{1}'}}",
                                                                                                                         field,
                                                                                                                         field
                                                                                                                             .
                                                                                                                             ToPrettierName
                                                                                                                             ()))
                                                                                                            .
                                                                                                             ToArray())))
                                                             .ToArray()));

            myWorkWebPartHtmlCode = myWorkWebPartHtmlCode.Replace("allListsAndFields__VAL__", allListsAndFieldsString);

            #endregion

            #region Get Field Lists

            var fieldLists = new Dictionary<string, List<string>>();

            foreach (var listAndFields in listsAndFields)
            {
                foreach (string field in listAndFields.Value)
                {
                    if (!fieldLists.ContainsKey(field)) fieldLists.Add(field, new List<string>());
                    fieldLists[field].Add(listAndFields.Key);
                }
            }

            List<string> fields = fieldLists.Select(fieldList => string.Format(@"{0}:[{1}]", fieldList.Key,
                                                                               string.Join(",",
                                                                                           fieldList.Value.Select(
                                                                                               list =>
                                                                                               string.Format(@"'{0}'",
                                                                                                             list)).
                                                                                                     ToArray())))
                                            .ToList();

            string fieldListsString = string.Join(",", fields.ToArray());

            myWorkWebPartHtmlCode = myWorkWebPartHtmlCode.Replace("fieldLists__VAL__", fieldListsString);

            string listWebsString = string.Join(",", (from myWorkList in myWorkLists
                                                      let webs =
                                                          myWorkList.Webs.Select(web => string.Format(@"'{0}'", web))
                                                      select
                                                          string.Format(@"{0}:[{1}]", myWorkList.Id,
                                                                        string.Join(",", webs.ToArray()))).ToArray());

            myWorkWebPartHtmlCode = myWorkWebPartHtmlCode.Replace("listWebs__VAL__", listWebsString);

            #endregion

            output.Write(myWorkWebPartHtmlCode);
        }

        #endregion Methods 
    }
}