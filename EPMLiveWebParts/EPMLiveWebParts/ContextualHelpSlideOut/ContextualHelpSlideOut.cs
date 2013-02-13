using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;
using EPMLiveCore;
using EPMLiveWebParts.CONTROLTEMPLATES.EPMLiveWebParts;
using Microsoft.SharePoint;
using WebPart = Microsoft.SharePoint.WebPartPages.WebPart;

namespace EPMLiveWebParts
{
    [XmlRoot(Namespace = "ContextualHelpSlideOut")]
    public class ContextualHelpSlideOut : WebPart
    {
        #region Fields (3) 

        private string _contentLocation;
        private int _slideOutOffset;
        private string _slideOutTitle;

        #endregion Fields 

        #region Properties (4) 

        /// <summary>
        /// Gets or sets the type of border that frames a Web Parts control.
        /// </summary>
        /// <returns>
        /// One of the <see cref="T:System.Web.UI.WebControls.WebParts.PartChromeType"/> values. The default is <see cref="F:System.Web.UI.WebControls.WebParts.PartChromeType.Default"/>.
        ///   </returns>
        ///   
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// The value is not one of the <see cref="T:System.Web.UI.WebControls.WebParts.PartChromeType"/> values.
        ///   </exception>
        public override PartChromeType ChromeType
        {
            get { return PartChromeType.None; }
            set { base.ChromeType = value; }
        }

        [WebBrowsable(true)]
        [WebDisplayName("Content Location")]
        [Personalizable(PersonalizationScope.Shared)]
        [Category("Slide Out Settings")]
        [DefaultValue("")]
        public string ContentLocation
        {
            get { return _contentLocation; }
            set { _contentLocation = value; }
        }

        [WebBrowsable(true)]
        [WebDisplayName("Slide Out Offset")]
        [Personalizable(PersonalizationScope.Shared)]
        [Category("Slide Out Settings")]
        [DefaultValue(75)]
        public int SlideOutOffSet
        {
            get { return _slideOutOffset == 0 ? 75 : _slideOutOffset; }
            set { _slideOutOffset = value; }
        }

        [WebBrowsable(true)]
        [WebDisplayName("Title")]
        [Personalizable(PersonalizationScope.Shared)]
        [Category("Slide Out Settings")]
        [DefaultValue("Getting Started")]
        public string SlideOutTitle
        {
            get { return string.IsNullOrEmpty(_slideOutTitle) ? "Getting Started" : _slideOutTitle; }
            set { _slideOutTitle = value; }
        }

        #endregion Properties 

        #region Methods (1) 

        // Protected Methods (1) 

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls()
        {
            bool slideoutDisabled;
            if (!bool.TryParse(
                CoreFunctions.getConfigSetting(SPContext.Current.Web, "EPMLiveDisableContextualSlideouts"),
                out slideoutDisabled))
            {
                slideoutDisabled = false;
            }

            if (!slideoutDisabled)
            {
                var control =
                    (ContextualHelpSlideOutControl)
                    Page.LoadControl(@"~/_CONTROLTEMPLATES/ContextualHelpSlideOutControl.ascx");

                control.SlideOutTitle = SlideOutTitle;
                control.ContentLocation = _contentLocation;
                control.SlideOutOffset = SlideOutOffSet;

                Controls.Add(control);
            }

            base.CreateChildControls();
        }

        #endregion Methods 
    }
}