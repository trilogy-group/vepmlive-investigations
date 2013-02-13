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
using Microsoft.Win32;
using Microsoft.SharePoint.Administration;
using System.Xml;
using System.IO;

namespace EPMLiveCore
{
    public partial class adminaddkey : System.Web.UI.Page
    {
        protected Label lblResult;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //string[] features = EPMLiveCore.CoreFunctions.featureList();
            //foreach (string feature in features)
            //{
            //    if (feature == Request["key"])
            //    {
            //        lblResult.Text = "Key Already Installed";
            //        return;
            //    }
            //}

            FeatureActivationSvc.Service activation = new FeatureActivationSvc.Service();
            string key = Request["key"];
            if (key[0] == '*')
            {
                if (insertKey(key))
                    lblResult.Text = "Activation Successful";
                else
                    lblResult.Text = "Activation Failed:<br>" + lblResult.Text;
            }
            else
            {
                int ret = activation.ActivateKey(key);
                switch (ret)
                {
                    case 0:
                        if (insertKey(key))
                            lblResult.Text = "Activation Successful";
                        else
                            lblResult.Text = "Activation Failed:<br>" + lblResult.Text;
                        break;
                    case 1:
                        lblResult.Text = "Invalid Key";
                        break;
                    case 2:
                        lblResult.Text = "Too many activations";
                        break;
                };
            }
        }

        private bool addKey(string inkey)
        {
            string key = "";
            string code = "";
            bool special = false;
            if (inkey[0] == '*')
            {
                string[] skey = inkey.Split('*');
                key = skey[1];
                code = skey[2];
                special = true;
            }
            else
                key = inkey.Trim(); ;

            string currentKeys = "";
            string[] features = EPMLiveCore.CoreFunctions.featureList();
            bool found = false;
            foreach (string feature in features)
            {
                if (feature == key)
                {
                    found = true;
                    lblResult.Text = "Key Already Installed";
                    return false;
                }
            }


            
            if (!found)
            {
                if (special)
                {
                    SPWeb web = SPContext.Current.Web;
                    {
                        web.AllowUnsafeUpdates = true;
                        SPSite site = web.Site;
                        site.AllowUnsafeUpdates = true;
                        SPFarm farm = site.WebApplication.Farm;
                        try
                        {
                            currentKeys = SPFarm.Local.Properties["EPMLiveKeys"].ToString();
                        }
                        catch { }
                        if (currentKeys == "")
                            farm.Properties["EPMLiveKeys"] = key + "\t" + code;
                        else
                            farm.Properties["EPMLiveKeys"] = currentKeys + "\t" + key + "\t" + code;
                        farm.Update();
                    }
                }
                else
                {
                    SPWeb web = SPContext.Current.Web;
                    {
                        web.AllowUnsafeUpdates = true;
                        SPSite site = web.Site;
                        site.AllowUnsafeUpdates = true;
                        SPFarm farm = site.WebApplication.Farm;
                        code = CoreFunctions.farmEncode(key);
                        try
                        {
                            currentKeys = SPFarm.Local.Properties["EPMLiveKeys"].ToString();
                        }
                        catch { }
                        if (currentKeys == "")
                            farm.Properties["EPMLiveKeys"] = key + "\t" + code;
                        else
                            farm.Properties["EPMLiveKeys"] = currentKeys + "\t" + key + "\t" + code;
                        farm.Update();
                    }
                }
            }
            return true;
        }

        private bool insertKey(string key)
        {
            key = key.Trim();
            bool ret = false;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                if (addKey(key))
                    ret = true;

                //try
                //{
                //    foreach (SPWebApplication app in SPWebService.ContentService.WebApplications)
                //    {
                //        SPIisSettings iis = app.IisSettings[SPUrlZone.Default];

                //        addKey(key);
                //    }
                //    foreach (SPWebApplication app in SPWebService.AdministrationService.WebApplications)
                //    {
                //        SPIisSettings iis = app.IisSettings[SPUrlZone.Default];

                        
                //    }
                //    ret = true;
                //}
                //catch(Exception exception)
                //{
                //    lblResult.Text = exception.Message;
                //}
            });
            return ret;
        }
    }
}