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
using System.Text.RegularExpressions;

namespace EPMLiveCore
{
    public partial class setPCfield : System.Web.UI.Page
    {
        protected string output;

        protected void Page_Load(object sender, EventArgs e)
        {

            SPWeb web = SPContext.Current.Web;
            web.AllowUnsafeUpdates = true;

            try
            {
                SPList list = web.Lists[CoreFunctions.getConfigSetting(web, "EPMLiveWPProjectCenter")];

                if (!list.Fields.ContainsField(Request["Field"]))
                {
                    list.Fields.Add(Request["Field"], SPFieldType.Text, false);
                    list.Fields[Request["Field"]].Hidden = true;
                    list.Update();
                }

                SPListItem li = list.Items.GetItemById(int.Parse(Request["ID"]));

                li[Request["Field"]] = Request["Value"];

                li.SystemUpdate();

                output = "Success";
            }
            catch(Exception ex) {
                output = "Failed: " + ex.Message;
            }

            //web.Close();
        }
    }
}