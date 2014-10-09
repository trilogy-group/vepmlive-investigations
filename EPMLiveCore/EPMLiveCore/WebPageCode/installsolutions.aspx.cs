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
using System.Globalization;

namespace EPMLiveCore
{
    public partial class InstallSolutions : System.Web.UI.Page
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

                Install(new Guid("55aca119-d7c7-494a-b5a7-c3ade07d06eb"), farm, apps); // Core
                Install(new Guid("98e5c373-e1a0-45ce-8124-30c203cd8003"), farm, apps); // WebParts
                Install(new Guid("1858d521-0375-4a61-9281-f5210854bc12"), farm, apps); // Timesheets
                Install(new Guid("8f916fa9-1c2d-4416-8036-4a272256e23d"), farm, apps); // Dashboards
                Install(new Guid("5a3fe24c-2dc5-4a1c-aec1-6ce942825ceb"), farm, apps); // PFE
                // Install(new Guid("823cf7cc-3c12-47a3-9f0a-6b69c391b915"), farm, apps); // Reporting
            }
            catch(Exception ex) { output = "Failed: " + ex.Message; return; }
            output = "Success";
        }

        private bool Install(Guid Solution, SPFarm farm, System.Collections.ObjectModel.Collection<SPWebApplication> apps)
        {
            SPSolution sol = farm.Solutions[Solution];
            SPContext.Current.Web.AllowUnsafeUpdates = true;
            
            SPContext.Current.Site.AllowUnsafeUpdates = true;

            EnsureLanguagePack(sol, 0U).DeployLocal(true, apps, true, SPCompatibilityRange.AllVersions);
            //sol.Deploy(DateTime.Now, true, apps, true);
            
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

        private static SPSolutionLanguagePack EnsureLanguagePack(SPSolution spSolution, uint lcid)
        {
            SPSolutionLanguagePack languagePack = spSolution.GetLanguagePack(lcid);
            if (!(languagePack == null))
            {
                return languagePack;
            }

            if ((int)lcid == 0)
            {
                throw new SPException(SPResource.GetString("SolutionLangNeutralNotFound", new object[0]));
            }

            throw new SPException(SPResource.GetString("SolutionLangPackNotFound", new object[]
                {
                    lcid.ToString(NumberFormatInfo.InvariantInfo)
                }));
        }
    }
}