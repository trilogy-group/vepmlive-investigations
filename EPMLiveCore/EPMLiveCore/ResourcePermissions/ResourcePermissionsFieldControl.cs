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
    class ResourcePermissionsFieldControl : Microsoft.SharePoint.WebControls.BaseFieldControl
    {
        CheckBoxList chkPerms;

        protected override string DefaultTemplateName
        {
            get { return "ResourcePermissionsFieldControl"; }
        }

        public override object Value
        {
            get
            {
                string values = "";

                foreach(ListItem i in this.chkPerms.Items)
                {
                    if(i.Selected)
                        values += "," + i.Value;
                }

                return values.Trim(',');
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
            if(ControlMode == SPControlMode.Display) return;


            DataTable dt = new DataTable();
            dt.Columns.Add("groupname");
            dt.Columns.Add("groupid");

            SPWeb web = SPContext.Current.Web;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite eSite = new SPSite(web.Site.ID))
                {
                    using(SPWeb eWeb = eSite.OpenWeb(web.ID))
                    {
                        foreach(SPGroup group in web.Groups)
                        {
                            SPGroup eGroup = eWeb.Groups[group.Name];

                            SPRoleCollection c = eGroup.Roles;

                            bool canUse = false;

                            foreach(SPRole role in c)
                            {
                                if(role.PermissionMask != (SPRights)134287360)
                                {
                                    canUse = true;
                                    break;
                                }
                            }

                            if(group.CanCurrentUserEditMembership && canUse)
                            {
                                dt.Rows.Add(new string[] { group.Name, group.ID.ToString() });
                            }

                        }
                    }
                }
            });

            ArrayList currentValues = new ArrayList();

            try
            {
                SPFieldUserValue uv = new SPFieldUserValue(this.Web, this.ListItem["SharePointAccount"].ToString());
                foreach(SPGroup g in uv.User.Groups)
                {
                    currentValues.Add(g.ID.ToString());
                }
            }
            catch { }

            chkPerms = (CheckBoxList)this.TemplateContainer.FindControl("chkPerms");

            chkPerms.DataTextField = "groupname";
            chkPerms.DataValueField = "groupid";
            chkPerms.DataSource = dt;
            chkPerms.DataBind();


            foreach(ListItem i in chkPerms.Items)
            {
                if(currentValues.Contains(i.Value.ToString()))
                {
                    i.Selected = true;
                }
            }
            
        }

        public override void UpdateFieldValueInItem()
        {
            this.EnsureChildControls();

            try
            {
                string values = "";

                foreach(ListItem i in this.chkPerms.Items)
                {
                    if(i.Selected)
                    {

                        values += "," + i.Value;
                    }
                }

                this.Value = values.Trim(',');
                this.ItemFieldValue = this.Value;
            }
            catch
            {
                ;
            }
        }


    }
}
