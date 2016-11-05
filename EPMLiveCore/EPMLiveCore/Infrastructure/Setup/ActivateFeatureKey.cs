using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;

namespace EPMLiveCore.Infrastructure.Setup
{
    public class ActivateFeatureKey
    {
        private string result = null;

        public string Activate(string key)
        {
            try
            {
                FeatureActivationSvc.Service activation = new FeatureActivationSvc.Service();
                if (key == "*")
                {
                    if (insertKey(key))
                        result = "Activation Successful";
                    else
                        result = "Activation Failed:<br>" + result;
                }
                else
                {
                    int ret = activation.ActivateKey(key);
                    switch (ret)
                    {
                        case 0:
                            if (insertKey(key))
                                result = "Activation Successful";
                            else
                                result = "Activation Failed:<br>" + result;
                            break;
                        case 1:
                            result = "Invalid Key";
                            break;
                        case 2:
                            result = "Too many activations";
                            break;
                    };
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        private bool insertKey(string key)
        {
            key = key.Trim();
            bool ret = false;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                if (addKey(key))
                    ret = true;
            });
            return ret;
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
                    result = "Key Already Installed";
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
    }
}
