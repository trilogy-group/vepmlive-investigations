using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using System.Text.RegularExpressions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Threading;

namespace EPMLiveCore
{
    public partial class removesolutions : System.Web.UI.Page
    {
        protected string output;

        protected void Page_Load(object sender, EventArgs e)
        {

            Server.ScriptTimeout = 300;
            
            try
            {
                SPWebApplication webapp = SPWebService.ContentService.WebApplications[new Guid(Request["WEBAPP"])];

                System.Collections.ObjectModel.Collection<SPWebApplication> apps = new System.Collections.ObjectModel.Collection<SPWebApplication>();
                apps.Add(webapp);

                SPFarm farm = SPFarm.Local;

                Remove(new Guid("55aca119-d7c7-494a-b5a7-c3ade07d06eb"), farm, apps);
                Remove(new Guid("98e5c373-e1a0-45ce-8124-30c203cd8003"), farm, apps);
                Remove(new Guid("1858d521-0375-4a61-9281-f5210854bc12"), farm, apps);
                Remove(new Guid("160f5e32-b93f-4682-95bc-6db38233535a"), farm, apps);
                Remove(new Guid("5a3fe24c-2dc5-4a1c-aec1-6ce942825ceb"), farm, apps);
            }
            catch(Exception ex) { output = "Failed: " + ex.Message; return; }
            output = "Success";
        }

        private bool Remove(Guid Solution, SPFarm farm, System.Collections.ObjectModel.Collection<SPWebApplication> apps)
        {
            SPSolution sol = farm.Solutions[Solution];
            SPContext.Current.Web.AllowUnsafeUpdates = true;
            SPContext.Current.Site.AllowUnsafeUpdates = true;

            sol.Retract(DateTime.Now, apps);
            DateTime dtStart = DateTime.Now;

            while(sol.JobExists)
            {
                Thread.Sleep(5000);
                if(dtStart.AddMinutes(2) <= DateTime.Now)
                {
                    return false;
                }
            }

            return true;
        }
    }
}