using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;
using System.Collections;
using System.Xml;
using System.Web.UI.WebControls;

namespace EPMLiveCore
{
    public class WEPeopleQuery : SimpleQueryControl
    {
        private DataTable dtUsers;
        private Guid CurrentWeb;
        public WEPeopleQuery(Guid _CurrentWeb)
        {
            CurrentWeb = _CurrentWeb;
            Load += WEPeopleQuery_Load;
        }


        void WEPeopleQuery_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                EnsureChildControls();
                
                ArrayList columnDisplayNames = ((TableResultControl)this.mDialogControl.ResultControl).ColumnDisplayNames;
                ArrayList columnNames = ((TableResultControl)this.mDialogControl.ResultControl).ColumnNames;

                for(int i = 0;i<columnDisplayNames.Count;i++)
                {
                     mColumnList.Items.Add(new System.Web.UI.WebControls.ListItem(columnDisplayNames[i].ToString(), columnNames[i].ToString()));
                }

                mColumnList.SelectedValue = "Title";
            }
        }

        protected override int IssueQuery(string search, string groupName, int pageIndex, int pageSize)
        {
            dtUsers = new DataTable();
            dtUsers.Columns.Add("ID");
            dtUsers.Columns.Add("SPAccountInfo");
            dtUsers.Columns.Add("Username");
            dtUsers.Columns.Add("PrincipalType");
            dtUsers.Columns.Add("SharePointAccount");
            dtUsers.Columns.Add("Title");
            
            if(!dtUsers.Columns.Contains(mColumnList.SelectedValue))
                dtUsers.Columns.Add(mColumnList.SelectedValue);

            ArrayList columnNames = ((TableResultControl)this.mDialogControl.ResultControl).ColumnNames;
            ArrayList columnDisplayNames = ((TableResultControl)this.mDialogControl.ResultControl).ColumnDisplayNames;
            ArrayList columnWidths = ((TableResultControl)this.mDialogControl.ResultControl).ColumnWidths;

            columnDisplayNames.Clear();
            columnNames.Clear();
            columnWidths.Clear();

            columnDisplayNames.Add("Resource Name");
            columnNames.Add("Title");
            columnWidths.Add("180px");

            //columnDisplayNames.Add(mColumnList.SelectedItem.Text);
            //columnNames.Add(mColumnList.SelectedValue);
            //columnWidths.Add("180px");

            XmlDocument docTeam = new XmlDocument();
            docTeam.LoadXml(WorkEngineAPI.GetTeam("<Filter Column='" + groupName + "' Value='" + search.Replace("'", "''") + "' WebId='" + CurrentWeb.ToString() + "'/>", SPContext.Current.Web));

            foreach(XmlNode ndTeam in docTeam.FirstChild.SelectNodes("//Team/Member"))
            {
                ArrayList item = new ArrayList();

                foreach(DataColumn dc in dtUsers.Columns)
                {
                    XmlAttribute attr = ndTeam.Attributes[dc.ColumnName];
                    if(attr != null)
                        item.Add(attr.Value);
                    else
                        item.Add("");
                }

                dtUsers.Rows.Add(item.ToArray());
            }

            PickerDialog.Results = dtUsers;
            PickerDialog.ResultControl.PageSize = dtUsers.Rows.Count;

            

            return dtUsers.Rows.Count;

        }

        public override PickerEntity GetEntity(DataRow dr)
        {
            PickerEntity entity = new PickerEntity();
            entity.DisplayText = "" + dr["SharePointAccount"];
            entity.Key = "" + dr["Username"];
            entity.Description = "" + dr["SharePointAccount"];
            entity.IsResolved = true;
            
            SPFieldLookupValue lv = new SPFieldLookupValue(dr["SPAccountInfo"].ToString());
            if(dr["PrincipalType"].ToString() == "SharePointGroup")
            {
                entity.EntityData.Add("SPGroupID", lv.LookupId.ToString());
            }
            else
            {
                entity.EntityData.Add("SPUserID", lv.LookupId.ToString());
            }
            entity.EntityData.Add("AccountName", lv.LookupValue);
            entity.EntityData.Add("PrincipalType", dr["PrincipalType"].ToString());
            return entity;
        }

    }

    
}
