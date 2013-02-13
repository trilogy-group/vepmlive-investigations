using System;
using System.Web.UI;

namespace EPMLiveCore
{
    public partial class MyWorkRichTextEditor : Page
    {
        #region Fields (3) 

        protected string RichTextValue;
        protected string SiteUrl;

        #endregion Fields 

        #region Methods (1) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e)
        {
            RichTextValue = Request.QueryString["RichTextValue"] ?? string.Empty;
            SiteUrl = Request.QueryString["SiteUrl"] ?? string.Empty;
        }

        #endregion Methods 
    }
}