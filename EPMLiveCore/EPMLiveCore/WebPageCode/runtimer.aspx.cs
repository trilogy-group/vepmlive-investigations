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
using System.ComponentModel;
using System.Threading;

namespace EPMLiveCore
{
    public partial class runtimer : System.Web.UI.Page
    {
        protected string data;

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    string sConn = "";
        //    using (SPSite site = SPContext.Current.Site)
        //    {
        //        CoreFunctions.getConnectionString(site.WebApplication.Id);
        //    }

        //    SPSecurity.RunWithElevatedPrivileges(delegate()
        //    {
        //        try
        //        {
        //            string[] sParams = new string[2] { sConn, Request["siteid"] };

        //            Thread timerThread = new Thread(RunThread);
        //            timerThread.Name = "Timer Thread";
        //            timerThread.Priority = ThreadPriority.Normal;
        //            timerThread.IsBackground = true;
        //            timerThread.Start(sParams); 

        //            data = "Success";
        //        }
        //        catch (Exception ex)
        //        {
        //            data = "Error: " + ex.Message;
        //        }
        //    });
        //}

        //void RunThread(object o)
        //{
        //    string[] sParam = (string[])o;

        //    using (SPSite site = new SPSite(new Guid(sParam[1])))
        //    {
        //        TimerFix tf = new TimerFix();
        //        tf.processSite(site, sParam[0]);
        //    }
        //}

    }
}