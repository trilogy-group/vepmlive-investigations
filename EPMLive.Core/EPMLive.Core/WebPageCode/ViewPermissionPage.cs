using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using EPMLiveCore.Infrastructure;

namespace EPMLiveCore
{
    public class ViewPermissionPage : LayoutsPageBase
    {
        private string pageRender;
        private SPList currentList;
        private List<SPGroup> groups = new List<SPGroup>();
        private List<SPView> views = new List<SPView>();
        private Dictionary<int, Dictionary<string, bool>> roleProperties = null;
        private Dictionary<int, string> defaultViews = null;
        private List<int> hiddenFields = new List<int>();
        private StringBuilder computeFieldsScript = new StringBuilder();
        
        private List<string> viewsNotInAnyGroup = new List<string>();
        private int[] groupIds = null;
        private StringBuilder checkPermissionScript = new StringBuilder();
        
        protected Button OK = new Button();
        protected Button Cancel = new Button();

        protected override void OnLoad(EventArgs e)
        {
            this.Title = "View Permission Settings";
            checkPermissionScript.AppendLine("var viewUrls = new Array;");
            foreach (SPView view in this.CurrentList.Views)
            {
                if ((!view.Hidden) && (!view.PersonalView))
                {
                    views.Add(view);
                    // Populate list view urls in script for client side validation on save
                    checkPermissionScript.Append("viewUrls.push('" + view.Url + "');");                    
                }
            }
            
            if (this.CurrentList.ParentWeb.Properties.ContainsKey(String.Format("ViewPermissions{0}", this.CurrentList.ID.ToString())))
            {
                roleProperties = new Dictionary<int, Dictionary<string, bool>>();
                defaultViews = new Dictionary<int, string>();
                ViewPermissionUtil.ConvertFromStringForPage(ref roleProperties, ref defaultViews, this.CurrentList.ParentWeb.Properties[String.Format("ViewPermissions{0}", this.CurrentList.ID.ToString())], this.CurrentList);
                // Grab collection of view which are not part of any group
                GetViewsNotInAnyGroup();
            }
            else
            {
                roleProperties = new Dictionary<int, Dictionary<string, bool>>();
                defaultViews = new Dictionary<int, string>();

                // Retrieve groups from current list
                foreach(SPGroup group in this.CurrentList.ParentWeb.Groups)
                {
                    SPRoleCollection c = group.Roles;

                    bool canUse = false;

                    foreach(SPRole role in c)
                    {
                        if(role.PermissionMask != (SPRights)134287360)
                        {
                            canUse = true;
                            break;
                        }
                    }

                    if(canUse)
                        groups.Add(group);
                }

                // Retrieve views from current list


                foreach (SPGroup group in groups)
                {
                    roleProperties.Add(group.ID, new Dictionary<string, bool>());
                    defaultViews.Add(group.ID, this.CurrentList.DefaultView.Url);
                    foreach (SPView view in views)
                        roleProperties[group.ID].Add(view.Url, true);
                }
            }            

            pageRender = this.PrepareRenderPage();
            // Populate permission group ids in script for client side validation on save
            groupIds = new int[roleProperties.Keys.Count];
            roleProperties.Keys.CopyTo(groupIds, 0);
            checkPermissionScript.AppendLine("var grpIds = new Array;");
            foreach (int id in groupIds)
            {
                checkPermissionScript.Append("grpIds.push('"+id+"');");
            }

            RegisterScript();

            this.Cancel.PostBackUrl = SPContext.Current.Web.Url + "/_layouts/listedit.aspx?List=" + this.CurrentList.ID.ToString();
            
        }

        protected string RenderPage()
        {
            return pageRender;
        }

        protected SPList CurrentList
        {
            get
            {
                if (currentList == null)
                    currentList = SPContext.Current.Web.Lists[new Guid(Request.QueryString["List"])];

                return currentList;
            }
        }

        private string PrepareRenderPage()
        {
            StringBuilder result = new StringBuilder();

            // Main table
            result.Append("<table style=\"width:100%\" cellpadding=\"0\" cellspacing=\"0\">");

            foreach (int groupId in roleProperties.Keys)
            {
                result.Append("<tr><td colspan=\"2\" class=\"ms-sectionline\" style=\"height:1px;\" ></td></tr>");
                result.Append(string.Format("<tr><td valign=\"top\" class=\"ms-sectionheader\" style=\"width:200px;padding-right:15px;\">{0}</td>", this.CurrentList.ParentWeb.Groups.GetByID(groupId).Name));
                result.Append(string.Format("<td class=\"ms-authoringcontrols\">{0}</td></tr><tr><td></td><td class=\"ms-authoringcontrols\" style=\"height:10px;\"></td></tr>", RenderOptions(groupId)));
            }

            // Close the main table
            result.Append("</table>");

            result.Append("<script language=\"javascript\" type=\"text/javascript\">");
            result.Append("ComputeFields();");
            result.Append("</script>");

            return result.ToString();
        }

        private string RenderOptions(int groupId)
        {
            StringBuilder result = new StringBuilder();

            // Default View
            result.Append("<table style=\"width: 100%\">");
            result.Append("<tr><td style=\"width: 100px;\"  class=\"ms-authoringcontrols\">");
            result.Append("Default view : ");
            result.Append("</td><td class=\"ms-authoringcontrols\">");
            result.Append(RenderDefaultView(groupId));
            result.Append("</td></tr>");
            result.Append("</table>");

            // Available views
            result.Append("<table style=\"width: 100%\">");
            result.Append("<tr><td style=\"width: 100px;vertical-align:top;\" class=\"ms-authoringcontrols\">");
            result.Append("Available views : ");
            result.Append("</td><td class=\"ms-authoringcontrols\">");
            result.Append(RenderAvailableViews(groupId));
            result.Append("</td></tr>");
            result.Append("</table>");

            return result.ToString();
        }

        private string RenderDefaultView(int groupId)
        {
            StringBuilder result = new StringBuilder();
            List<string> availableViews = new List<string>();
            string defaultView = defaultViews[groupId];

            // Retrieve authorized views from current list for the group
            foreach (string viewId in roleProperties[groupId].Keys)
            {
                if (roleProperties[groupId][viewId])
                    availableViews.Add(viewId);
            }

            result.Append(String.Format("<select id=\"Option{0}\" runat=\"server\" style=\"width: 150px;\" onchange=\"javascript:ComputeHidden('{0}');\">", groupId));
            foreach (string viewId in availableViews)
            {
                foreach (SPView view in views)
                {
                    if (view.Url == viewId)
                    {
                        //if (this.CurrentList.Views[viewId] != null)
                        //{
                        string viewName = view.Title;
                        result.Append(String.Format("<option {0}value=\"{1}\">{2}</option>", viewId.Equals(defaultView) ? "selected=\"selected\" " : "", viewId, viewName));
                        //}
                    }
                }
            }

            result.Append("</select>");
            result.Append("</td></tr>");

            return result.ToString();
        }

        private string RenderAvailableViews(int groupId)
        {
            StringBuilder result = new StringBuilder();

            result.Append(string.Format("<div id=\"Div{0}\">", groupId));
            // Retrieve views from the current list
            foreach (SPView view in this.CurrentList.Views)
            {
                if ((!view.Hidden) && (!view.PersonalView))
                {
                    if (((roleProperties[groupId].ContainsKey(view.Url)) && (roleProperties[groupId][view.Url] == true)) || viewsNotInAnyGroup.Contains(view.Url))
                        result.Append(string.Format("<input id=\"Chk{0}{1}\" title=\"{2}\" type=\"checkbox\" value=\"{1}\" onclick=\"javascript:OptionChange('{0}','chk{0}{1}');\" checked=\"checked\"/> {2}<br/>", groupId, view.Url, view.Title));
                    else
                        result.Append(string.Format("<input id=\"Chk{0}{1}\" title=\"{2}\" type=\"checkbox\" value=\"{1}\" onclick=\"javascript:OptionChange('{0}','chk{0}{1}');\" /> {2}<br/>", groupId, view.Url, view.Title));
                }
            }

            result.Append("</div>");
            result.Append("</td></tr>");
            UpdateGlobalScript(groupId);

            return result.ToString();
        }

        private void UpdateGlobalScript(int groupId)
        {
            if (!hiddenFields.Contains(groupId))
            {
                hiddenFields.Add(groupId);
                computeFieldsScript.Append(String.Format("ComputeHidden(\"{0}\");", groupId));
            }

            this.ClientScript.RegisterHiddenField(String.Format("Hidden{0}", groupId), "");
        }

        protected void ClearAll(object sender, EventArgs e)
        {
            if (this.CurrentList.ParentWeb.Properties.ContainsKey(String.Format("ViewPermissions{0}", this.CurrentList.ID.ToString())))
                this.CurrentList.ParentWeb.Properties[String.Format("ViewPermissions{0}", this.CurrentList.ID.ToString())] = null;

            this.CurrentList.ParentWeb.Properties.Update();

            CacheStore.Current.RemoveSafely(SPContext.Current.Web.Url, new CacheStoreCategory(SPContext.Current.Web).Navigation);

            Microsoft.SharePoint.Utilities.SPUtility.Redirect("listedit.aspx?List=" + this.CurrentList.ID.ToString(), Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
        }

        protected void SaveCustomPermission(object sender, EventArgs e)
        {
            string valueGlobal = string.Empty;

            foreach (int groupId in hiddenFields)
            {
                string value = HttpContext.Current.Request.Params[string.Format("Hidden{0}", groupId)];
                if (value.Length > 0)
                    valueGlobal += string.Format("{0}|", value.Substring(0, value.Length - 1));
                else
                    valueGlobal += string.Format("{0}|", value.Substring(0, value.Length));
            }

            valueGlobal = valueGlobal.Substring(0, valueGlobal.Length - 1);

            if (!this.CurrentList.ParentWeb.Properties.ContainsKey(String.Format("ViewPermissions{0}", this.CurrentList.ID.ToString())))
                this.CurrentList.ParentWeb.Properties.Add(String.Format("ViewPermissions{0}", this.CurrentList.ID.ToString()), valueGlobal);
            else
                this.CurrentList.ParentWeb.Properties[String.Format("ViewPermissions{0}", this.CurrentList.ID.ToString())] = valueGlobal;

            this.CurrentList.ParentWeb.Properties.Update();

            CacheStore.Current.RemoveSafely(SPContext.Current.Web.Url, new CacheStoreCategory(SPContext.Current.Web).Navigation);

            Microsoft.SharePoint.Utilities.SPUtility.Redirect("listedit.aspx?List=" + this.CurrentList.ID.ToString(), Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
        }

        private void RegisterScript()
        {
            computeFieldsScript.Insert(0, "function ComputeFields(){");
            computeFieldsScript.Append("}");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ComputeFields", computeFieldsScript.ToString(), true);

            string OptionChangeScript = @"function OptionChange(id,sender)
                                    {
                                        if(CountChecked(id) == 0)
                                            document.getElementById(sender).checked = true;
                                        else
                                            OptionBind(id);
                                    }";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "OptionChange", OptionChangeScript, true);

            string CountCheckedScript = @"function CountChecked(id) 
                                        {
                                            var result = 0;
                                            var panel = document.getElementById('Div' + id);
                                            
                                            for(index=0;index < panel.childNodes.length;index++) 
                                            {
                                                var ctrl = panel.childNodes.item(index);
                                                if((ctrl.name != null) && (ctrl.checked))
                                                    result++;
                                            }
                                            
                                            return result;
                                        }";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CountChecked", CountCheckedScript, true);

            string OptionBindScript = @"function OptionBind(id)
                                        {
                                            var selectCtrl = document.getElementById('Option' + id);
                                            var panel = document.getElementById('Div' + id);
                                            var i = 0;
                                            var lenght = CountChecked(id);
                                            
                                            selectCtrl.options.length = lenght;                                           

                                            for(index=0;index < panel.childNodes.length;index++) 
                                            {
                                                var ctrl = panel.childNodes.item(index);
                                                if((ctrl.name != null) && (ctrl.checked))
                                                {
                                                    selectCtrl.options[i].value = ctrl.value;
                                                    selectCtrl.options[i].text = ctrl.title;
                                                    i++;
                                                }
                                            }
                                            
                                            selectCtrl.selectedIndex = 0;
                                            ComputeHidden(id);
                                        }";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "OptionBind", OptionBindScript, true);

            string ComputeHiddenScript = @"function ComputeHidden(id)
                                        {
                                            var selectCtrl = document.getElementById('Option' + id);
                                            var panel = document.getElementById('Div' + id);
                                            var hidden = document.getElementById('Hidden' + id);
                                            var groupId = id;
                                            var defaultView = selectCtrl.options[selectCtrl.selectedIndex].value
                                            var views = '';

                                            for(index=0;index < panel.childNodes.length;index++) 
                                            {
                                                var ctrl = panel.childNodes.item(index);
                                                if((ctrl.name != null) && (ctrl.checked))
                                                {
                                                    views = views + ctrl.value + ';'
                                                }
                                            }

                                            hidden.value = groupId + '#' + defaultView + '#' + views;
                                        }";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ComputeHidden", ComputeHiddenScript, true);
            
            checkPermissionScript.AppendLine(@"function CheckPermission()
                                    {            
                                        for(var i = 0; i < viewUrls.length; i++)
                                        {
                                            var isViewExist = false;
                                            var url = viewUrls[i];
                                            for(index = 0; index < grpIds.length; index++)
                                            {
                                                var hidden = document.getElementById('Hidden' + grpIds[index]);
                                                if(hidden.value.indexOf(url) != -1)
                                                {
                                                    isViewExist = true;
                                                    break;
                                                }                                                
                                            }
                                            if(isViewExist == false)
                                            {
                                                alert('Each view must be associated with at least one permissions group.');
                                                return false;
                                            }
                                        }
                                        return true;
                                    }");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CheckPermission", checkPermissionScript.ToString(), true);
        }

        private void GetViewsNotInAnyGroup()
        {
            string[] groups = this.CurrentList.ParentWeb.Properties[String.Format("ViewPermissions{0}", this.CurrentList.ID.ToString())].Split("|".ToCharArray());

            foreach (SPView currentView in views)
            {
                bool isViewExist = false;
                string viewUrl = currentView.Url;
                foreach (string grp in groups)
                {
                    if (grp.Contains(viewUrl))
                    {
                        isViewExist = true;
                        break;
                    }
                }
                if (!isViewExist)
                {
                    viewsNotInAnyGroup.Add(viewUrl);
                }
            }
        }
    }
}
