using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Presentation;
using Microsoft.SharePoint;
using EPMLiveCore;

namespace EPMLiveCore.API
{
    public class AnalyticsData
    {
        private static string DEFAULT_PAGE_ICON = "icon-file-5";
        private static string DEFAULT_LIST_ICON = "icon-square";


        protected XMLDataManager mgr;

        public AnalyticsData(string xml, AnalyticsType t, AnalyticsAction a)
        {
            mgr = new XMLDataManager(xml);
            Type = t;
            Action = a;
        }

        public AnalyticsType Type { get; set; }

        public AnalyticsAction Action { get; set; }

        public Guid SiteId
        {
            get
            {
                var sid = Guid.Empty;
                var sSiteId = mgr.GetPropVal("SiteId");
                if (!string.IsNullOrEmpty(sSiteId))
                {
                    Guid.TryParse(sSiteId, out sid);
                }

                return sid;
            }
        }

        public Guid WebId
        {
            get
            {
                var wid = Guid.Empty;
                var sWebId = mgr.GetPropVal("WebId");
                if (!string.IsNullOrEmpty(sWebId))
                {
                    Guid.TryParse(sWebId, out wid);
                }

                return wid;
            }
        }

        public Guid ListId
        {
            get
            {
                var lid = Guid.Empty;
                var sListId = mgr.GetPropVal("ListId");
                if (!string.IsNullOrEmpty(sListId))
                {
                    Guid.TryParse(sListId, out lid);
                }

                return lid;
            }
        }

        public string ListViewUrl
        {
            get
            {
                return mgr.GetPropVal("ListViewUrl");
            }
        }

        public bool FileIsNull
        {
            get
            {
                var fileIsNull = true;
                var sFileIsNull = mgr.GetPropVal("FileIsNull");
                if (!string.IsNullOrEmpty(sFileIsNull))
                {
                    bool.TryParse(sFileIsNull, out fileIsNull);
                }

                return fileIsNull;
            }
        }
        public int ItemId
        {
            get
            {
                var id = -1;
                var sItemId = mgr.GetPropVal("ItemId");
                if (!string.IsNullOrEmpty(sItemId))
                {
                    int.TryParse(sItemId, out id);
                }

                return id;
            }
        }

        public int UserId
        {
            get
            {
                var uid = -1;
                var sUserId = mgr.GetPropVal("UserId");
                if (!string.IsNullOrEmpty(sUserId))
                {
                    int.TryParse(sUserId, out uid);
                }

                return uid;
            }
        }

        public string Title
        {
            get
            {
                return mgr.GetPropVal("Title");
            }
        }

        public string Icon
        {
            get
            {
                var sIcon = string.Empty;
                try
                {
                    SPSecurity.RunWithElevatedPrivileges(() =>
                    {
                        using (var s = new SPSite(SiteId))
                        {
                            using (var w = s.OpenWeb(WebId))
                            {
                                var list = w.Lists[ListId];
                                var settings = new GridGanttSettings(list);
                                sIcon = settings.ListIcon;
                            }
                        }
                    });
                }
                catch { }

                if (IsItem && string.IsNullOrEmpty(sIcon))
                {
                    sIcon = DEFAULT_LIST_ICON;
                }

                if (!IsItem)
                {
                    sIcon = DEFAULT_PAGE_ICON;
                }
                
                return sIcon;
            }
        }

        public string FString
        {
            get
            {
                var s = mgr.GetPropVal("FString");
                var sRemove = string.Empty;

                if (!string.IsNullOrEmpty(s))
                {   
                    if (s.ToLower().Contains("source"))
                    {
                        if (s.Contains('?') && s.Contains('&'))
                        {
                            var sa = s.Split('?');
                            var asa = sa[1].Split('&');
                            foreach (var s1 in asa)
                            {
                                if (s1.Split('=')[0].ToString(CultureInfo.InvariantCulture).ToLower() == "source")
                                {
                                    sRemove = s1;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            sRemove = s.Substring(s.IndexOf('?'));
                        }
                    }
                }

                if (!string.IsNullOrEmpty(sRemove))
                {
                    s = s.Replace(sRemove, "");
                }

                return Uri.UnescapeDataString(s);
            }
        }

        public bool IsItem
        {
            get
            {
                bool isItem = false;
                var s = mgr.GetPropVal("IsItem");
                if (!string.IsNullOrEmpty(s))
                {
                    isItem = bool.Parse(s);
                }

                return isItem;
            }
        }

        public bool IsListView
        {
            get
            {
                bool isListView = !string.IsNullOrEmpty(ListViewUrl) && ListId != Guid.Empty;
                return isListView;
            }
        }
    }

    
}
