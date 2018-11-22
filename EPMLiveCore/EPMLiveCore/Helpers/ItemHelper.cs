using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

namespace EPMLiveCore.Helpers
{
    public static class ItemHelper
    {
        public static void SetCloseAndBackButtons(ListFormWebPart listFormWebPart)
        {
            if (listFormWebPart == null)
            {
                throw new ArgumentNullException(nameof(listFormWebPart));
            }

            var closeButton = new Button
            {
                Text = "Close",
                CssClass = "ms-ButtonHeightWidth",
                OnClientClick = "closePage();"
            };

            var closeButton2 = new Button
            {
                Text = "Close",
                CssClass = "ms-ButtonHeightWidth",
                OnClientClick = "closePage();"
            };

            listFormWebPart.Controls[0]
                .FindControl("toolBarTbltop")
                .FindControl("RightRptControls")
                .Controls.AddAt(4, closeButton);

            listFormWebPart.Controls[0]
                .FindControl("toolBarTbl")
                .FindControl("RightRptControls")
                .Controls.AddAt(2, closeButton2);

            var backButton = (GoBackButton)listFormWebPart.Controls[0]
                .FindControl("toolBarTbltop")
                .FindControl("RightRptControls")
                .FindControl("ctl02");
            backButton.Visible = false;

            backButton = (GoBackButton)listFormWebPart.Controls[0]
                .FindControl("toolBarTbl")
                .FindControl("RightRptControls")
                .FindControl("ctl01");
            backButton.Visible = false;
        }
    }
}
