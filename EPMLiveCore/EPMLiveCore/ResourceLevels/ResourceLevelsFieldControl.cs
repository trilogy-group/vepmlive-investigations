using System;
using System.Runtime.InteropServices;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace EPMLiveCore
{
    class ResourceLevelsFieldControl : Microsoft.SharePoint.WebControls.BaseFieldControl
    {
        //CheckBoxList chkPerms;
        RadioButtonList ddlLevels;
        private bool bIsOnline = false;

        protected override string DefaultTemplateName
        {
            get { return "ResourceLevelsFieldControl"; }
        }

        public override object Value
        {
            get
            {
                //string values = "";

                //foreach(ListItem i in this.ddlLevels.Items)
                //{
                //    if(i.Selected)
                //        values += "," + i.Value;
                //}

                return this.ddlLevels.SelectedValue;
            }
            set
            {
                base.Value = value;
            }
        }

        protected override void CreateChildControls()
        {
            if(Field == null) return;
                base.CreateChildControls();

            if(ControlMode == SPControlMode.Display)
                return;

            ddlLevels = (RadioButtonList)this.TemplateContainer.FindControl("ddlLevels");

            string username = "";

            try
            {
                
                SPFieldUserValue uv = new SPFieldUserValue(Web, ListItem["SharePointAccount"].ToString());
                if(uv.User.LoginName != "")
                {
                    username = CoreFunctions.GetRealUserName(uv.User.LoginName, Web.Site);
                }
            }
            catch { }

            if(username != "" || ControlMode == SPControlMode.New)
            {
                Act act = new Act(Web);
                bIsOnline = act.IsOnline;

                if(!bIsOnline || (bIsOnline && (Web.CurrentUser.IsSiteAdmin || CoreFunctions.GetRealUserName(Web.CurrentUser.LoginName, Web.Site).ToLower() == act.OwnerUsername.ToLower())))
                {
                    int actType = 0;

                    ArrayList Levels = act.GetLevelsFromSite(out actType, username);

                    if(actType > 2)
                    {
                        foreach(ActLevel Level in Levels)
                        {
                            
                            ListItem li = new ListItem(GetLevelName(Level, act), Level.id.ToString());
                            
                            try
                            {
                                if(Level.isUserInLevel)
                                    li.Selected = true;
                            }
                            catch { }

                            if(Level.availableactivations <= 0 && Level.id != 0 && !Level.isUserInLevel)
                                li.Enabled = false;

                            ddlLevels.Items.Add(li);
                        }

                        if (ControlMode == SPControlMode.New)
                        {
                            foreach (ListItem li in ddlLevels.Items)
                            {
                                if (li.Value.ToString() == "1" && li.Enabled)
                                {
                                    li.Selected = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private string GetLevelName(ActLevel Level, Act act)
        {
            if(bIsOnline)
            {
                if(Level.availableactivations < 1 && !Level.isUserInLevel && (act.OwnerUsername == CoreFunctions.GetRealUserName(Web.CurrentUser.LoginName, Web.Site)))
                {
                    string url = Web.ServerRelativeUrl;
                    if(url == "/") url = "";
                    return Level.name + " <a style=\"\" href=\"javascript:void(0);\" onclick=\"var options={url: '" + url + "/_layouts/epmlive/manageaccount.aspx',width: 800,height: 600}; SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);\"><img src=\"/_layouts/epmlive/images/purchaseaccounts.png\" border=\"0\"></a>";
                }

            }
            else
            {



            }

            return Level.name;
        }


        public override void UpdateFieldValueInItem()
        {
            this.EnsureChildControls();

            try
            {
                //string values = "";

                //foreach(ListItem i in this.chkPerms.Items)
                //{
                //    if(i.Selected)
                //    {

                //        values += "," + i.Value;
                //    }
                //}

                //this.Value = values.Trim(',');
                this.Value = this.ddlLevels.SelectedValue;
                this.ItemFieldValue = this.Value;
            }
            catch
            {
                ;
            }
        }


    }
}
