using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI;
using System.Reflection;
using System.Web;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;
using System.Collections.Specialized;
using System.Collections;

namespace EPMLiveCore
{
    public class ViewSelectorDelegate : ViewSelectorMenu
    {
        private Dictionary<int, Dictionary<string, bool>> roleProperties = null;
        private Dictionary<int, string> defaultViews = null;
        private List<SPView> views = new List<SPView>();
        private bool featureEnabled = false;

        protected override void OnLoad(EventArgs e)
        {

            if(this.Visible)
            {
                //using (SPSite site = SPContext.Current.Site)
                SPSite site = SPContext.Current.Site;
                {
                    //SPFeature listDisplaySettingFeature = site.Features[new Guid("88E9E47A-BA92-47ab-A253-8AA472CCC76B")];

                    //if ((listDisplaySettingFeature != null) && (listDisplaySettingFeature.Definition.Status == Microsoft.SharePoint.Administration.SPObjectStatus.Online))
                    //{
                    if(View.ParentList.ParentWeb.Properties.ContainsKey(String.Format("ViewPermissions{0}", View.ParentList.ID.ToString())))
                    {
                        featureEnabled = true;
                        roleProperties = new Dictionary<int, Dictionary<string, bool>>();
                        defaultViews = new Dictionary<int, string>();

                        SPWeb web = View.ParentList.ParentWeb;
                        {
                            ViewPermissionUtil.ConvertFromString(ref roleProperties, ref defaultViews, web.Properties[String.Format("ViewPermissions{0}", View.ParentList.ID.ToString())], View.ParentList);
                        }
                    }
                    foreach(SPView view in View.ParentList.Views)
                    {
                        if((!view.Hidden) && (!view.PersonalView))
                            views.Add(view);
                    }
                    //}
                }

                base.OnLoad(e);

                //if(featureEnabled)
                {
                    try
                    {
                        NameValueCollection nv = HttpUtility.ParseQueryString(Page.Request.UrlReferrer.Query);
                        StringBuilder sbUrl = new StringBuilder();

                        foreach(string key in nv.AllKeys)
                        {
                            if(isValidQS(key))
                            {
                                sbUrl.Append("&");
                                sbUrl.Append(key);
                                sbUrl.Append("=");
                                sbUrl.Append(HttpUtility.UrlEncode(nv[key]));
                            }
                        }

                        foreach(Control item in base.MenuTemplateControl.Controls)
                        {
                            try
                            {
                                if((item is MenuItemTemplate) && (View.ParentList.Views[((MenuItemTemplate)item).Text]) != null)

                                    if(featureEnabled)
                                    {
                                        item.Visible = UserCanSeeView(View.ParentList.Views[((MenuItemTemplate)item).Text].Url, roleProperties);
                                    }

                                Microsoft.SharePoint.WebControls.MenuItemTemplate mn = (Microsoft.SharePoint.WebControls.MenuItemTemplate)item;
                                string sDoc = System.IO.Path.GetFileName(mn.ClientOnClickNavigateUrl);

                                if(!sDoc.Contains("ViewEdit.aspx?") && !sDoc.Contains("ViewType.aspx?"))
                                {
                                    if(sbUrl.ToString() != "")
                                    {
                                        //mn.ClientOnClickScript = mn.ClientOnClickScript.Insert(mn.ClientOnClickScript.Length - 3, "?" + sbUrl.ToString().TrimStart('&'));
                                        mn.ClientOnClickNavigateUrl += "?" + sbUrl.ToString().TrimStart('&');
                                    }
                                }
                            }
                            catch { }
                        }
                    }
                    catch { }
                }
            }
            else
                base.OnLoad(e);



        }

        private bool isValidQS(string key)
        {
            switch(key.ToLower())
            {
                case "isdlg":
                    return false;
            }
            return true;
        }

        private bool UserCanSeeView(string viewId, Dictionary<int, Dictionary<string, bool>> roleProperties)
        {
            SPUser user = SPContext.Current.Web.CurrentUser;
            SPGroupCollection userGroups = user.Groups;

            if(userGroups.Count > 0)
            {
                foreach(SPGroup group in userGroups)
                {
                    if(roleProperties.ContainsKey(group.ID))
                    {
                        if((roleProperties[group.ID].ContainsKey(viewId)) && (roleProperties[group.ID][viewId] == true))
                            return true;
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
