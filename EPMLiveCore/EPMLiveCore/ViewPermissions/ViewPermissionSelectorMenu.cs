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

namespace EPMLiveCore
{
    public class ViewPermissionSelectorMenu : ViewSelectorMenu
    {
        private Dictionary<int, Dictionary<string, bool>> roleProperties = null;
        private Dictionary<int, string> defaultViews = null;
        private List<SPView> views = new List<SPView>();
        private bool featureEnabled = false;

        protected override void OnLoad(EventArgs e)
        {
            if (this.Visible)
            {
                //using (SPSite site = SPContext.Current.Site)
                SPSite site = SPContext.Current.Site;
                {
                    //SPFeature listDisplaySettingFeature = site.Features[new Guid("88E9E47A-BA92-47ab-A253-8AA472CCC76B")];

                    //if ((listDisplaySettingFeature != null) && (listDisplaySettingFeature.Definition.Status == Microsoft.SharePoint.Administration.SPObjectStatus.Online))
                    //{
                    if (View.ParentList.ParentWeb.Properties.ContainsKey(String.Format("ViewPermissions{0}", View.ParentList.ID.ToString())))
                    {
                        featureEnabled = true;
                        roleProperties = new Dictionary<int, Dictionary<string, bool>>();
                        defaultViews = new Dictionary<int, string>();

                        SPWeb web = View.ParentList.ParentWeb;
                        {
                            ViewPermissionUtil.ConvertFromString(ref roleProperties, ref defaultViews, web.Properties[String.Format("ViewPermissions{0}", View.ParentList.ID.ToString())], View.ParentList);

                            if (!UserCanSeeView(base.RenderContext.ViewContext.View.Url, roleProperties))
                                SPUtility.Redirect(GoToDefaultView(defaultViews).ServerRelativeUrl, SPRedirectFlags.Default, HttpContext.Current, "redirect=true");
                            else
                            {
                                if (!ComeFromView())
                                    SPUtility.Redirect(GoToDefaultView(defaultViews).ServerRelativeUrl, SPRedirectFlags.Default, HttpContext.Current, "redirect=true");
                            }
                        }
                    }
                    foreach (SPView view in View.ParentList.Views)
                    {
                        if ((!view.Hidden) && (!view.PersonalView))
                            views.Add(view);
                    }
                    //}
                }

                base.OnLoad(e);
            }
            else
                base.OnLoad(e);
        }

       

        protected override void Render(System.Web.UI.HtmlTextWriter output)
        {
            if (this.Visible)
            {
                if (featureEnabled)
                {
                    foreach (Control item in base.MenuTemplateControl.Controls)
                    {
                        try
                        {
                            if((item is MenuItemTemplate) && (View.ParentList.Views[((MenuItemTemplate)item).Text]) != null)
                            
                            //if(featureEnabled)
                            {
                                    item.Visible = UserCanSeeView(View.ParentList.Views[((MenuItemTemplate)item).Text].Url, roleProperties);
                            }

                            
                        }
                        catch{ }
                    }
                }

                base.Render(output);
            }
            else
                base.Render(output);

        }

        private bool UserCanSeeView(string viewId, Dictionary<int, Dictionary<string, bool>> roleProperties)
        {
            SPUser user = SPContext.Current.Web.CurrentUser;
            SPGroupCollection userGroups = user.Groups;

            if (userGroups.Count > 0)
            {
                foreach (SPGroup group in userGroups)
                {
                    if (roleProperties.ContainsKey(group.ID))
                    {
                        if ((roleProperties[group.ID].ContainsKey(viewId)) && (roleProperties[group.ID][viewId] == true))
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

        private SPView GoToDefaultView(Dictionary<int, string> defaultViews)
        {
                SPUser user = SPContext.Current.Web.CurrentUser;
                SPGroupCollection userGroups = user.Groups;

                if (userGroups.Count > 0)
                {
                    foreach (SPGroup group in userGroups)
                    {
                        if (defaultViews.ContainsKey(group.ID))
                        {
                            foreach (SPView view in views)
                            {
                                if (view.Url == defaultViews[group.ID])
                                    return view;
                            }
                            //if (View.ParentList.Views[defaultViews[group.ID]] != null)
                            //    return View.ParentList.Views[defaultViews[group.ID]];
                        }
                    }

                    return View.ParentList.DefaultView;
                }
                else
                    return View.ParentList.DefaultView;
        }

        private bool ComeFromView()
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["redirect"]))
                return true;
            else
            {
                string urlReferer = HttpContext.Current.Request.CurrentExecutionFilePath.ToLower(); ;
                foreach (SPView view in View.ParentList.Views)
                {
                    if (view.ServerRelativeUrl.ToLower().Equals(urlReferer))
                        return true;
                }

                return false;
            }
        }
    }
}
