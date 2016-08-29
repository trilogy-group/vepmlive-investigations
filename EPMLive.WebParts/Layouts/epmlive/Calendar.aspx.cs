using System;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWebParts.Layouts.epmlive
{
    public partial class Calendar : LayoutsPageBase
    {
        #region Methods (1) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e)
        {
            string dt = Request.QueryString["datetime"];

            if (!string.IsNullOrEmpty(dt))
            {
                DateTime dateTime;
                if (DateTime.TryParse(dt, out dateTime)) DateTimeControl.SelectedDate = dateTime;
            }

            string dtOnly = Request.QueryString["dateonly"];
            if (string.IsNullOrEmpty(dtOnly)) return;

            bool dateOnly;
            if (bool.TryParse(dtOnly, out dateOnly)) DateTimeControl.DateOnly = dateOnly;
        }

        #endregion Methods 
    }
}