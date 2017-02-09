using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminSite.WebControls
{
    public partial class BaseWebControl : System.Web.UI.UserControl
    {
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