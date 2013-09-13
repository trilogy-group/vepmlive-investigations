using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using EPMLiveCore;

namespace EPMLiveCore.API
{
    public class AnalyticsData
    {
        protected XMLDataManager mgr;

        public AnalyticsData(string xml)
        {
            mgr = new XMLDataManager(xml);
        }

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
                return mgr.GetPropVal("IconClass");
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
                                if (s1[0].ToString().ToLower() == "source")
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
                return ItemId != -1;
            }
        }

        public bool IsNonItem
        {
            get
            {
                return ItemId == -1;
            }
        }

        public int Type
        {
            get
            {
                var type = -1;
                var sType = mgr.GetPropVal("Type");
                if (!string.IsNullOrEmpty(sType))
                {
                    int.TryParse(sType, out type);
                }

                return type;
            }
        }


    }

    public class DataFactory
    {
        private AnalyticsData data;

        public DataFactory(string xml)
        {
            data = new AnalyticsData(xml);
        }

        
    }
}
