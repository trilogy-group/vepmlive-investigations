using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using Microsoft.SharePoint;

namespace EPMLiveWebParts.CONTROLTEMPLATES.MyWork
{
    public partial class WorkingOnControl : UserControl
    {
        #region Fields (3) 

        private string _debugTag;
        private string _layoutDataXml;
        private string _webUrl;

        #endregion Fields 

        #region Properties (4) 

        protected string DebugTag
        {
            get { return _debugTag; }
        }

        public string GridId { get; set; }

        protected string LayoutDataXml
        {
            get { return _layoutDataXml; }
        }

        protected string WebUrl
        {
            get { return _webUrl; }
        }

        #endregion Properties 

        #region Methods (2) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb spWeb = SPContext.Current.Web;

            _webUrl = spWeb.Url;

            string epmDebug = Page.Request.Params["epmdebug"];
            if (!string.IsNullOrEmpty(epmDebug))
            {
                var keywords = new[] {"Error", "Problem", "Info", "Check", "IOError", "IO", "Cookie", "Page"};
                var info = new List<string> {"Error", "Problem"};

                foreach (string keyword in epmDebug.Split(',').Select(k => k.ToLower()))
                {
                    string kw = keyword;
                    info.AddRange(keyword.Equals("all") ? keywords : keywords.Where(k => kw.Equals(k.ToLower())));
                }

                _debugTag = string.Format(@"debug=""{0}""", string.Join(",", info.Distinct().ToArray()));
            }

            _layoutDataXml = GenerateLayoutDataXml();
        }

        // Private Methods (1) 

        private string GenerateLayoutDataXml()
        {
            string xml = new XElement("WorkingOn", new XElement("Params", new XElement("GridId", GridId))).ToString();
            return HttpUtility.HtmlEncode(HttpUtility.HtmlEncode(xml)).Replace(Environment.NewLine, string.Empty);
        }

        #endregion Methods 
    }
}