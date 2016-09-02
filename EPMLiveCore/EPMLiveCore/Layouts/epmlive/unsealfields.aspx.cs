using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public partial class unsealfields : LayoutsPageBase
    {

        protected string output;

        protected void Page_Load(object sender, EventArgs e)
        {

            SPWeb web = SPContext.Current.Web;
            {
                if (web.CurrentUser.IsSiteAdmin)
                {
                    SPList list = web.Lists[new Guid(Request["List"])];
                    web.AllowUnsafeUpdates = true;
                    foreach (SPField f in list.Fields)
                    {
                        if (f.Reorderable && f.InternalName != "Title")
                        {
                            try
                            {
                                f.Sealed = false;
                                f.AllowDeletion = true;
                                f.Update();
                                output += f.Title + ": Unsealed<br>";
                            }
                            catch (Exception ex)
                            {
                                output += f.Title + ": Not Unsealed (" + ex.Message + ")<br>";
                            }
                        }

                    }
                    list.Update();
                }
            }

        }
    }
}