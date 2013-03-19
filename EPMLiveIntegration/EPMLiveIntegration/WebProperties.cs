using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EPMLiveIntegration
{
    public class SiteProperties
    {
        public Guid ID;
        public string URL;
        public string Title;
    }

    public class WebProperties
    {
        public WebProperties()
        {
            Site = new SiteProperties();
        }

        public SiteProperties Site;
        public Guid ID;
        public string URL;
        public string FullURL;
        public string Title;
        public Hashtable Properties;
        public Guid IntegrationId;
    }

}