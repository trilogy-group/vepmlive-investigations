using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    using Microsoft.SharePoint.Utilities;
    using System.Data;

    public partial class sitepermissions
    {
        private void fillData(SPSite site)
        {
            var web = SPContext.Current.Web;

            var canUserEditAGroup = false;

            foreach (SPGroup group in web.Groups)
            {
                if (group.CanCurrentUserEditMembership)
                {
                    canUserEditAGroup = true;
                }
            }

            if (canUserEditAGroup)
            {
                fillSubData(web);
            }
            else
            {
                SPUtility.Redirect("accessdenied.aspx", 
                    SPRedirectFlags.RelativeToLayoutsPage, 
                    HttpContext.Current);
            }
        }

        private void fillSubData(SPWeb web)
        {
            lblDesc.Text =
                "The Site Members list below displays users that have access to this Workspace.  "
                + "You can edit their permissions or remove them from this site by using the links below.";

            var dataSet = new DataSet();
            var dataTable = dataSet.Tables.Add();
            dataTable.Columns.Add("name");
            dataTable.Columns.Add("email");
            dataTable.Columns.Add("group");
            dataTable.Columns.Add("username");
            dataTable.Columns.Add("uid");

            var userTable = new Hashtable();

            foreach (SPUser user in web.AllUsers)
            {
                if (user.IsSiteAdmin)
                {
                    userTable.Add(user.ID, user.Name + "\n" + user.Email + "\n" + user.LoginName + "\nSite Collection Administrator");
                }
            }

            foreach (SPGroup group in web.Groups)
            {
                if (!@group.CanCurrentUserViewMembership)
                {
                    continue;
                }

                foreach (SPUser user in @group.Users)
                {
                    if (userTable.Contains(user.ID))
                    {
                        var val = userTable[user.ID].ToString();
                        userTable[user.ID] = val + "<br>" + @group.Name;
                    }
                    else
                    {
                        userTable.Add(user.ID, user.Name + "\n" + user.Email + "\n" + user.LoginName + "\n" + @group.Name);
                    }
                }
            }

            foreach (DictionaryEntry userEntry in userTable)
            {
                var values = userEntry.Value.ToString().Split('\n');
                dataSet.Tables[0].Rows.Add(values[0], values[1], values[3], values[2], values[2]);
            }

            var dataView = dataSet.Tables[0].DefaultView;
            dataView.Sort = "name";

            GridView1.DataSource = dataView.Table;
            GridView1.DataBind();
        }

        public override void Dispose()
        {
            DisposePanelGroupsChilds();
            base.Dispose();
        }

        private void DisposePanelGroupsChilds()
        {
            if (pnlGroups == null)
            {
                return;
            }

            foreach (Control control in pnlGroups.Controls)
            {
                control?.Dispose();
            }
        }
    }
}
