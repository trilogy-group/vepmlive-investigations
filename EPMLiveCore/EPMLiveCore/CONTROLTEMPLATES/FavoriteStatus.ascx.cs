using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;

namespace EPMLiveCore.CONTROLTEMPLATES
{
    public partial class FavoriteStatus : UserControl
    {
        //protected string defaultFavTitle = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    // list view
            //    if (SPContext.Current.ViewContext.View != null 
            //        && SPContext.Current.List != null 
            //        && SPContext.Current.Item == null)
            //    {
            //        defaultFavTitle = SPContext.Current.List.Title + " - " +
            //                          SPContext.Current.ViewContext.View.Title;
            //    }
            //    // item
            //    else if (SPContext.Current.ViewContext.View == null 
            //        && SPContext.Current.List != null 
            //        && SPContext.Current.Item != null
            //        && SPContext.Current.File == null)
            //    {
            //        defaultFavTitle = SPContext.Current.ListItemDisplayName;
            //    }
            //    // page 
            //    else
            //    {
            //        defaultFavTitle = Path.GetFileName(Request.FilePath);
            //    }
            //}
            //catch
            //{
            //}
        }
    }
}
