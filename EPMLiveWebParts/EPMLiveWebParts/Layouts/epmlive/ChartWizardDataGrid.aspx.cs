using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml.Linq;
using EPMLiveWebParts.Properties;
using System.Web;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace EPMLiveWebParts.Layouts.epmlive
{
    public partial class ChartWizardDataGrid : LayoutsPageBase
    {
        protected string _CSSUrl = (SPContext.Current.Web.ServerRelativeUrl == "/") ? "" : (SPContext.Current.Web.ServerRelativeUrl) + @"/_layouts/epmlive/styles/ChartWizard/ChartWizardStyle.css";
        public string WebPartId { get; set; }
        protected string DataXml
        {
            get
            {
                return GetGridParam(XDocument.Parse(Resources.ResourceGrid_DataXml))
                    .Replace(Environment.NewLine, string.Empty).Replace(@"\t", string.Empty);
            }
        }

        /// <summary>
        ///     Gets the layout XML.
        /// </summary>
        protected string LayoutXml
        {
            get
            {
                XDocument xDocument = XDocument.Parse(Resources.ResourceGrid_LayoutXml);
                if (xDocument.Root != null) xDocument.Root.Add(new XElement("Id", WebPartId));

                return GetGridParam(xDocument).Replace(Environment.NewLine, string.Empty).Replace(@"\t", string.Empty);
            }
        }

        protected string WebUrl;

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            RegisterScripts();
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            string webPartId = UniqueID.Md5();
            WebPartId = webPartId;
        }

        protected void Page_Load(object sender, EventArgs e)
        {   
            WebUrl = SPContext.Current.Web.Url;
        }

        private void RegisterScripts()
        {
            ScriptLink.Register(Page, "/_layouts/epmlive/treegrid/GridE.js", false);
        }

        private static string GetGridParam(XDocument dataXml)
        {
            return HttpUtility.HtmlEncode(HttpUtility.HtmlEncode(dataXml.ToString()));
        }
    }

    public static class ExtensionMethods
    {

        /// <summary>
        /// Generates MD5 hash for the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string Md5(this string value)
        {
            byte[] data = Encoding.ASCII.GetBytes(value);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(data);

            return hashData.Aggregate(string.Empty, (current, b) => current + b.ToString("X2")).ToUpper();
        }
    }
}
