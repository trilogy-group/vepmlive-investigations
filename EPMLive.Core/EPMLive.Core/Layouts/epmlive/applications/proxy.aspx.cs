using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;

namespace EPMLiveCore.Layouts.epmlive.applications
{
    public partial class proxy : System.Web.UI.Page
    {
        protected string data;

        protected void Page_Load(object sender, EventArgs e)
        {

            switch(Request["Action"])
            {
                case "StartPreCheck":
                    StartPreCheck();
                    break;
                case "StartInstall":
                    StartInstall();
                    break;
                case "CheckStatus":
                    CheckStatus();
                    break;
                case "CheckUStatus":
                    CheckUStatus();
                    break;
                case "StartUninstallCheck":
                    StartUninstallCheck();
                    break;
                case "StartUninstall":
                    StartUninstall();
                    break;
                case "DeleteApp":
                    DeleteApp();
                    break;
                default: 
                    outputData("Error", "Invalid Proxy Command", "0");
                    break;
            };

        }

        private void DeleteApp()
        {
            try
            {
                API.Applications.DeleteCommunity(int.Parse(Request["ID"]), SPContext.Current.Web);

                outputData("Success", "", "0");
            }
            catch(Exception ex)
            {
                outputData("Error", ex.Message, "0");
            }
        }

        private void CheckStatus()
        {
            XmlNode ndStatus = API.Applications.CheckApplicationStatus(Request["AppId"], SPContext.Current.Web);

            outputData(ndStatus.SelectSingleNode("Status").InnerText, ndStatus.SelectSingleNode("Message").InnerText, ndStatus.SelectSingleNode("PercentComplete").InnerText);
        }

        private void CheckUStatus()
        {
            XmlNode ndStatus = API.Applications.CheckUninstallStatus(Request["jobuid"], SPContext.Current.Web);

            outputData(ndStatus.SelectSingleNode("Status").InnerText, ndStatus.SelectSingleNode("Message").InnerText, ndStatus.SelectSingleNode("PercentComplete").InnerText);
        }

        private void StartPreCheck()
        {
            try
            {
                Guid jobid = API.Applications.QueueInstallAndConfigureApplication(Request["AppID"], true, SPContext.Current.Web, Request["CommId"]);
                outputData("Success", jobid.ToString(), "0");
            }
            catch(Exception ex)
            {
                if(ex.Message == "PreCheck in Progress.")
                {
                    outputData("Success", "", "0");
                }
                else
                {
                    outputData("Error", ex.Message, "0");
                }
            }
        }

        private void StartUninstallCheck()
        {
            try
            {
                Guid jobid = API.Applications.QueueUninstallApplication(Request["AppID"], true, SPContext.Current.Web);
                outputData("Success", jobid.ToString(), "0");
            }
            catch(Exception ex)
            {
                outputData("Error", ex.Message, "0");
            }
        }

        private void StartUninstall()
        {
            try
            {
                Guid jobid = API.Applications.QueueUninstallApplication(Request["AppID"], false, SPContext.Current.Web);
                outputData("Success", jobid.ToString(), "0");
            }
            catch(Exception ex)
            {
                outputData("Error", ex.Message, "0");
            }
        }

        private void StartInstall()
        {
            try
            {
                Guid jobid = API.Applications.QueueInstallAndConfigureApplication(Request["AppID"], false, SPContext.Current.Web, Request["CommId"]);
                outputData("Success", jobid.ToString(), "0");
            }
            catch(Exception ex)
            {
                if(ex.Message == "Application install in progress.")
                {
                    outputData("Success", "", "0");
                }
                else
                {
                    outputData("Error", ex.Message, "0");
                }
            }
        }


        private void outputData(string status, string message, string percent)
        {
            data = "Status: \"" + status + "\", Message: \"" + message + "\", Percent: \"" + percent + "\"";
        }
    }
}
