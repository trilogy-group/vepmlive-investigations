using System;
using System.Collections.Generic;
using System.Web.UI;
using EPMLiveCore.API;
using Microsoft.SharePoint;

namespace EPMLiveWebParts
{
    public class contextualslideout : Page
    {
        #region Fields (1) 

        protected string Data;

        #endregion Fields 

        #region Methods (2) 

        // Protected Methods (1) 

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Data = "Failure";

            string action = Request.Params["action"];
            string slideOutId = Request.Params["slideOutId"];

            if (string.IsNullOrEmpty(action) || string.IsNullOrEmpty(slideOutId)) return;

            if (action.Equals("hide"))
            {
                HideSlideOut(slideOutId);
            }
        }

        // Private Methods (1) 

        /// <summary>
        /// Hides the slide out.
        /// </summary>
        /// <param name="slideOutId"></param>
        private void HideSlideOut(string slideOutId)
        {
            try
            {
                SPSite spSite = SPContext.Current.Site;

                MyPersonalization.SetPersonalizations(
                    new Dictionary<string, string> {{"ContextualSlideOutId", slideOutId}},
                    SPContext.Current.Web.CurrentUser.ID.ToString(), 0, Guid.Empty, Guid.Empty,
                    spSite.ID, spSite.Url);

                Data = "Success";
            }
            catch (Exception e)
            {
                Data = e.Message;
            }
        }

        #endregion Methods 
    }
}