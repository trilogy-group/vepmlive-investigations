using System;
using System.Xml;
using EPMLiveWebParts.Properties;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWebParts.Layouts.epmlive
{
    public partial class MyWork : LayoutsPageBase
    {
        #region Methods (3) 

        // Protected Methods (2) 

        protected override void OnPreLoad(EventArgs e)
        {
            RegisterRibbon();
        }

        protected void Page_Load(object sender, EventArgs e) { }
        
        // Private Methods (1) 

        private void RegisterRibbon()
        {
            var xmlDocument = new XmlDocument();
            SPRibbon spRibbon = SPRibbon.GetCurrent(Page);

            xmlDocument.LoadXml(Resources.MyWorkWebPart_ContextualTab.Replace("{title}", "My Work"));
            spRibbon.RegisterDataExtension(xmlDocument.FirstChild, "Ribbon.Tabs._children");

            xmlDocument.LoadXml(Resources.MyWorkWebPart_ContextualTabTemplate);
            spRibbon.RegisterDataExtension(xmlDocument.FirstChild, "Ribbon.Templates._children");

            spRibbon.Minimized = false;
            spRibbon.CommandUIVisible = true;
        }

        #endregion Methods 
    }
}