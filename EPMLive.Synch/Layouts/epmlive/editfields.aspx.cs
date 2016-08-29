using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections;


namespace EPMLiveSynch.Layouts
{
    public partial class editfields : LayoutsPageBase
    {
        private SPList currentList;
        protected SPGridView GvFields;
        protected Button btnDone = new Button();
        private string sListGuid = "";
        private string sDVurl = "";
        protected CheckBox chkCreateNewList;
        protected TextBox txtToList;
        protected CheckBox chkSyncDescriptionAndNavSettings;
        protected CheckBox chkSyncVersioningSettings;
        protected CheckBox chkSyncAdvancedSettings;
        protected CheckBox chkSyncPermissionsAndMgmtSettings;
        protected CheckBox chkSyncGeneralSettings;
        protected CheckBox chkSyncTotalSettings;
        protected CheckBox chkEditableFieldsSettings;
        protected CheckBox chkSyncViewGroupBySettings;

        protected override void OnLoad(EventArgs e)
        {
            this.Title = "Sync Options";
            lblListName.Text = this.CurrentList.Title;

            chkCreateNewList.InputAttributes["onclick"] = "return isDirty();";
            chkSyncDescriptionAndNavSettings.InputAttributes["onclick"] = "return isDirty();";
            chkSyncVersioningSettings.InputAttributes["onclick"] = "return isDirty();";
            chkSyncAdvancedSettings.InputAttributes["onclick"] = "return isDirty();";
            chkSyncPermissionsAndMgmtSettings.InputAttributes["onclick"] = "return isDirty();";
            chkSyncGeneralSettings.InputAttributes["onclick"] = "return isDirty();";
            chkSyncTotalSettings.InputAttributes["onclick"] = "return isDirty();";
            chkEditableFieldsSettings.InputAttributes["onclick"] = "return isDirty();";
            chkSyncViewGroupBySettings.InputAttributes["onclick"] = "return isDirty();";

            if (!Page.IsPostBack)
            {
                sListGuid = Request.QueryString["List"];
                using (SPWeb web = SPContext.Current.Web)
                {

                    sDVurl = System.IO.Path.GetDirectoryName(this.CurrentList.DefaultView.ServerRelativeUrl);

                    try
                    {
                        chkCreateNewList.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveSyncCreateNew-" + sDVurl));
                    }
                    catch { }
                    try
                    {
                        chkSyncDescriptionAndNavSettings.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveSyncDescriptionAndNavSettings-" + sDVurl));
                    }
                    catch { }
                    try
                    {
                        chkSyncVersioningSettings.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveSyncVersioningSettings-" + sDVurl));
                    }
                    catch { }
                    try
                    {
                        chkSyncAdvancedSettings.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveSyncAdvancedSettings-" + sDVurl));
                    }
                    catch { }
                    try
                    {
                        chkSyncPermissionsAndMgmtSettings.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveSyncPermissionsAndMgmtSettings-" + sDVurl));
                    }
                    catch { }
                    try
                    {
                        chkSyncGeneralSettings.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveSyncGeneralSettings-" + sDVurl));
                    }
                    catch { }
                    try
                    {
                        chkSyncTotalSettings.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveSyncTotalSettings-" + sDVurl));
                    }
                    catch { }
                    try
                    {
                        chkEditableFieldsSettings.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveSyncEditableFieldsSettings-" + sDVurl));
                    }
                    catch { }
                    try
                    {
                        chkSyncViewGroupBySettings.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveSyncAltListName-" + sDVurl));
                    }
                    catch { }

                    txtToList.Text = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveSyncAltListName-" + sDVurl);
                    if (txtToList.Text == "")
                        txtToList.Text = lblListName.Text;

                }
                ListFields();
            }
            else
            {
            }
        }

        protected void GvFields_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string sFieldDisplayName = DataBinder.Eval(e.Row.DataItem, "DisplayName").ToString();
                string sFieldInternalName = DataBinder.Eval(e.Row.DataItem, "InternalName").ToString();
                string sFieldType = DataBinder.Eval(e.Row.DataItem, "FieldType").ToString();
                string sLink = "<a href=\"#\" onclick=\"pageRedir('" + SPContext.Current.Web.Url + "/_layouts/FldEdit.aspx?source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.RawUrl.ToString()) + "&List=" + sListGuid + "&Field=" + System.Web.HttpUtility.HtmlDecode(sFieldInternalName) + "')\" >" + sFieldDisplayName + "</a>";
                e.Row.Cells[0].Text = System.Web.HttpUtility.HtmlDecode(sLink);
                e.Row.Cells[1].Text = System.Web.HttpUtility.HtmlDecode(sFieldType);
            }

        }

        private void ListFields()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DisplayName");
            dt.Columns.Add("FieldType");
            dt.Columns.Add("InternalName");

            int cntFields = 0;

            foreach (SPField fld in this.CurrentList.Fields)
            {
                if (!fld.Sealed && (!fld.ReadOnlyField || fld.Type == SPFieldType.Calculated) && fld.Type != SPFieldType.Attachments && fld.InternalName != "Order" && fld.Type != SPFieldType.File && fld.InternalName != "MetaInfo")
                {
                    dt.Rows.Add(new string[] { fld.Title, fld.TypeShortDescription, fld.InternalName });
                }

                cntFields++;
            }

            dt.DefaultView.Sort = "DisplayName ASC";

            //if (cntFields > 0) GvFields.PageSize = cntFields;
            GvFields.DataSource = dt;
            GvFields.DataBind();

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

        protected void btnDone_Click(object sender, EventArgs e)
        {
            string sEPMLiveSynchedViews = Page.Request["EPMLiveSynchedViews"].ToString();
            string sListGuid = Request.QueryString["List"];

            using (SPWeb web = SPContext.Current.Web)
            {
                if (web.CurrentUser.IsSiteAdmin)
                {
                    sDVurl = System.IO.Path.GetDirectoryName(this.CurrentList.DefaultView.ServerRelativeUrl);
                    string sListName;
                    string sCurrentListTitle = CurrentList.Title;
                    if (txtToList.Text.Trim() == "")
                    {
                        sListName = sCurrentListTitle;
                    }
                    else
                    {
                        sListName = txtToList.Text;
                    }

                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveSynchedViews-" + sListGuid, sEPMLiveSynchedViews);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveSyncAltListName-" + sDVurl, sListName);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveSyncCreateNew-" + sDVurl, chkCreateNewList.Checked.ToString());
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveSyncDescriptionAndNavSettings-" + sDVurl, chkSyncDescriptionAndNavSettings.Checked.ToString());
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveSyncVersioningSettings-" + sDVurl, chkSyncVersioningSettings.Checked.ToString());
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveSyncAdvancedSettings-" + sDVurl, chkSyncAdvancedSettings.Checked.ToString());
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveSyncPermissionsAndMgmtSettings-" + sDVurl, chkSyncPermissionsAndMgmtSettings.Checked.ToString());
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveSyncGeneralSettings-" + sDVurl, chkSyncGeneralSettings.Checked.ToString());
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveSyncTotalSettings-" + sDVurl, chkSyncTotalSettings.Checked.ToString());
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveSyncEditableFieldsSettings-" + sDVurl, chkEditableFieldsSettings.Checked.ToString());
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveSyncViewGroupBySettings-" + sDVurl, chkSyncViewGroupBySettings.Checked.ToString());


                }
            }
            Response.Redirect(SPContext.Current.Web.Url + "/_layouts/epmlive/templates.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Response.Redirect(SPContext.Current.Web.ServerRelativeUrl + "/_layouts/epmlive/templates.aspx");
        }


        //private void setSyncShowInNewSetting()
        //{
        //    try
        //    {
        //        SPSecurity.RunWithElevatedPrivileges(delegate()
        //        {

        //            using (SPWeb currWeb = SPContext.Current.Web)
        //            {
        //                if (currWeb.Properties.ContainsKey("EPMLiveSyncShowInNewProperty-" + sDVurl))
        //                {
        //                    // property exists already -> update it
        //                    currWeb.Properties["EPMLiveSyncShowInNewProperty-" + sDVurl] = chkShowInNew.Checked.ToString();
        //                }
        //                else
        //                {
        //                    // property doesn't exist -> add it if there is value to set
        //                    currWeb.Properties.Add("EPMLiveSyncShowInNewProperty-" + sDVurl, chkShowInNew.Checked.ToString());
        //                }

        //                currWeb.Properties.Update();
        //            }
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //private void setSyncShowInEditSetting()
        //{
        //    try
        //    {
        //        SPSecurity.RunWithElevatedPrivileges(delegate()
        //        {

        //            using (SPWeb currWeb = SPContext.Current.Web)
        //            {
        //                if (currWeb.Properties.ContainsKey("EPMLiveSyncShowInEditProperty-" + sDVurl))
        //                {
        //                    // property exists already -> update it
        //                    currWeb.Properties["EPMLiveSyncShowInEditProperty-" + sDVurl] = chkShowInNew.Checked.ToString();
        //                }
        //                else
        //                {
        //                    // property doesn't exist -> add it if there is value to set
        //                    currWeb.Properties.Add("EPMLiveSyncShowInEditProperty-" + sDVurl, chkShowInNew.Checked.ToString());
        //                }

        //                currWeb.Properties.Update();
        //            }
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //private void setSyncHiddenSetting()
        //{
        //    try
        //    {
        //        SPSecurity.RunWithElevatedPrivileges(delegate()
        //        {

        //            using (SPWeb currWeb = SPContext.Current.Web)
        //            {
        //                if (currWeb.Properties.ContainsKey("EPMLiveSyncHiddenProperty-" + sDVurl))
        //                {
        //                    // property exists already -> update it
        //                    currWeb.Properties["EPMLiveSyncHiddenProperty-" + sDVurl] = chkShowInNew.Checked.ToString();
        //                }
        //                else
        //                {
        //                    // property doesn't exist -> add it if there is value to set
        //                    currWeb.Properties.Add("EPMLiveSyncHiddenProperty-" + sDVurl, chkShowInNew.Checked.ToString());
        //                }

        //                currWeb.Properties.Update();
        //            }
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}
    }
}
