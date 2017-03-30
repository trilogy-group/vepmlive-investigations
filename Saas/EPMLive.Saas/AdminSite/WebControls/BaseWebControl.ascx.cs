using System;
using System.Web;

namespace AdminSite.WebControls
{
    public partial class BaseWebControl : System.Web.UI.UserControl
    {
        protected static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected string CurrentUserName => HttpContext.Current.User.Identity.Name;

        protected virtual string CheckIfDeletable(string name, string url, Func<bool> condition)
        {
            return condition()
                ? $"| <a OnClick=\"return confirm('Are you sure you want to Delete:{name} ?'); \") href ='{url}'>Delete</a>"
                : "";
        }

        protected string ActiveToYesNo(bool active)
        {
            return active ? "Yes" : "No";
        }
    }
}