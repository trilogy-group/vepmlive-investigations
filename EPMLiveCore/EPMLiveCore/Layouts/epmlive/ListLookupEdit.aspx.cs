using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Collections;
using System.Collections.Generic;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class ListLookupEdit : LayoutsPageBase
    {
        private void PopulateLookupFields(SPList list)
        {
            ddlParentLookup.Items.Add(new System.Web.UI.WebControls.ListItem("--Select List--", ""));

            foreach(SPField field in list.Fields)
            {
                if(field.Type == SPFieldType.Lookup && !field.Hidden && field.Reorderable)
                {
                    SPFieldLookup lookup = (SPFieldLookup)field;
                    if(lookup.LookupList != "")
                    {

                        ddlParentLookup.Items.Add(new System.Web.UI.WebControls.ListItem(lookup.Title, lookup.InternalName));

                    }
                }
            }

        }

        private void PopulateLookupFieldsFields()
        {
            ddlParentLookupField.Items.Clear();

            ddlParentLookupField.Items.Add(new System.Web.UI.WebControls.ListItem("--Select List--", ""));

            if(ddlParentLookup.SelectedValue != "")
            {

                SPList list = Web.Lists[new Guid(Request["List"])];
                SPFieldLookup oCurField = (SPFieldLookup)list.Fields.GetFieldByInternalName(Request["field"]);
                SPFieldLookup oLookupField = (SPFieldLookup)list.Fields.GetFieldByInternalName(ddlParentLookup.SelectedValue);

                SPList oParentList = Web.Lists[new Guid(oCurField.LookupList)];

                foreach(SPField field in oParentList.Fields)
                {
                    if(field.Type == SPFieldType.Lookup && !field.Hidden && field.Reorderable)
                    {
                        SPFieldLookup lookup = (SPFieldLookup)field;
                        if(lookup.LookupList.ToLower() == oLookupField.LookupList.ToLower())
                        {

                            ddlParentLookupField.Items.Add(new System.Web.UI.WebControls.ListItem(lookup.Title, lookup.InternalName));

                        }
                    }
                }
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                SPList list = Web.Lists[new Guid(Request["List"])];

                lblList.Text = list.Title;
                SPField oField = list.Fields.GetFieldByInternalName(Request["field"]);
                lblField.Text = oField.Title;

                PopulateLookupFields(list);
                

                GridGanttSettings gSettings = new GridGanttSettings(list);
                string[] LookupArray = gSettings.Lookups.Split('|');

                Hashtable hshLookups = new Hashtable();
                foreach(string sLookup in LookupArray)
                {
                    if(sLookup != "")
                    {
                        string[] sLookupInfo = sLookup.Split('^');
                        hshLookups.Add(sLookupInfo[0], sLookupInfo);
                    }
                }

                if(hshLookups.Contains(Request["field"]))
                {
                    chkEnabled.Checked = true;
                    ddlParentLookup.Enabled = true;
                    ddlParentLookupField.Enabled = true;
                    ddlStyle.Enabled = true;
                    chkSecurity.Enabled = true;

                    string[] sLookupInfo = (string[])hshLookups[Request["field"]];
                    try
                    {
                        ddlStyle.SelectedValue = sLookupInfo[1];
                    }
                    catch { }
                    try
                    {
                        chkSecurity.Checked = bool.Parse(sLookupInfo[4]);
                    }
                    catch { }
                    try
                    {
                        ddlParentLookup.SelectedValue = sLookupInfo[2];
                    }
                    catch { }


                    PopulateLookupFieldsFields();
                    try
                    {
                        ddlParentLookupField.SelectedValue = sLookupInfo[3];
                    }
                    catch { }
                }
                else
                {
                    chkEnabled.Checked = false;
                    ddlParentLookup.Enabled = false;
                    ddlParentLookupField.Enabled = false;
                    ddlStyle.Enabled = false;
                    chkSecurity.Enabled = false;

                }
            }
            else
            {
                if(chkEnabled.Checked)
                {
                    ddlParentLookup.Enabled = true;
                    ddlParentLookupField.Enabled = true;
                    ddlStyle.Enabled = true;
                    chkSecurity.Enabled = true;
                }
                else
                {
                    ddlParentLookup.Enabled = false;
                    ddlParentLookupField.Enabled = false;
                    ddlStyle.Enabled = false;
                    chkSecurity.Enabled = false;
                }
            }

        }

        

        protected void ddlParentLookupField_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateLookupFieldsFields();
        }
        public override string PageToRedirectOnCancel
        {
            get
            {
                return ((Web.ServerRelativeUrl == "/") ? "" : Web.ServerRelativeUrl) + "/_layouts/epmlive/ListLookupConfig.aspx?List=" + Request["List"];
            }
        }
        

        protected void Button1_Click(object sender, EventArgs e)
        {

            SPList list = Web.Lists[new Guid(Request["List"])];

            GridGanttSettings gSettings = new GridGanttSettings(list);
            string[] LookupArray = gSettings.Lookups.Split('|');

            string output = "";

            foreach(string sLookup in LookupArray)
            {
                if(sLookup != "")
                {
                    string[] sLookupInfo = sLookup.Split('^');

                    if(sLookupInfo[0] != Request["field"])
                    {
                        output += "|" + sLookup;
                    }
                }
            }

            if(chkEnabled.Checked)
            {
                output += "|" + Request["field"] + "^" + ddlStyle.SelectedValue + "^" + ddlParentLookup.SelectedValue + "^" + ddlParentLookupField.SelectedValue + "^" + chkSecurity.Checked.ToString().ToLower();
            }

            gSettings.Lookups = output.Trim('|');
            gSettings.SaveSettings(list);
            
            string lookups = gSettings.Lookups;
            EnhancedLookupConfigValuesHelper x = new EnhancedLookupConfigValuesHelper(lookups);
            List<string> lsSecFields = x.GetSecuredFields();
            if(lsSecFields.Count > 0)
            {
                string assemblyName = "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
                string className = "EPMLiveCore.ItemSecurityEventReceiver";

                List<SPEventReceiverDefinition> evts = CoreFunctions.GetListEvents(list,
                                                                     assemblyName,
                                                                     className,
                                                                     new List<SPEventReceiverType> { SPEventReceiverType.ItemAdded,
                                                                                                     SPEventReceiverType.ItemUpdated,
                                                                                                     SPEventReceiverType.ItemDeleting});
                foreach(SPEventReceiverDefinition evt in evts)
                {
                    evt.Delete();
                }

                list.EventReceivers.Add(SPEventReceiverType.ItemAdded, assemblyName, className);
                list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, assemblyName, className);
                list.EventReceivers.Add(SPEventReceiverType.ItemDeleting, assemblyName, className);
                list.Update();
            }
            else if(!gSettings.BuildTeamSecurity)
            {
                string assemblyName = "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
                string className = "EPMLiveCore.ItemSecurityEventReceiver";

                List<SPEventReceiverDefinition> evts = CoreFunctions.GetListEvents(list,
                                                                        assemblyName,
                                                                        className,
                                                                        new List<SPEventReceiverType> { SPEventReceiverType.ItemAdded,
                                                                                                        SPEventReceiverType.ItemUpdated,
                                                                                                        SPEventReceiverType.ItemDeleting});
                foreach(SPEventReceiverDefinition evt in evts)
                {
                    evt.Delete();
                }

                list.Update();
            }
            Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/ListLookupConfig.aspx?List=" + Request["List"], Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current);

        }
    }
}
