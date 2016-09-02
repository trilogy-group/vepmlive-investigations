using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;

namespace EPMLiveCore
{
    public class TotalsRollupProperties : UserControl, IFieldEditor
    {
        protected TextBox txtQuery;
        protected DropDownList ddlList;
        protected DropDownList ddlType;
        protected DropDownList ddlColumn;
        protected DropDownList ddlLookup;
        protected DropDownList ddlDecimals;
        protected DropDownList ddlOutput;
        private string list = "";
        private string query = "";
        private string aggtype = "";
        private string column = "";
        private string lookup = "";
        private string decimals = "";
        private string outputtype = "";

        public void InitializeWithField(SPField field)
        {
            TotalsRollupField myField = field as TotalsRollupField;

            if (myField != null)
            {
                this.list = myField.ListName + "";
                this.query = myField.ListQuery + "";
                this.aggtype = myField.AggType + "";
                this.column = myField.AggColumn + "";
                this.lookup = myField.LookupColumn + "";
                this.decimals = myField.Decimals + "";
                this.outputtype = myField.OutputType + "";
            }
        }

        public void OnSaveChange(SPField field, bool isNew)
        {
            TotalsRollupField myField = field as TotalsRollupField;
            if (isNew)
            {
                myField.UpdateListName(ddlList.SelectedItem.Text);
                myField.UpdateListQuery(txtQuery.Text);
                myField.UpdateAggType(ddlType.SelectedValue);
                myField.UpdateAggColumn(ddlColumn.SelectedValue);
                myField.UpdateLookupColumn(ddlLookup.SelectedValue);
                myField.UpdateDecimals(ddlDecimals.SelectedValue);
                myField.UpdateOutputType(ddlOutput.SelectedValue);
            }
            else
            {
                myField.ListName = ddlList.SelectedItem.Text;
                myField.ListQuery = txtQuery.Text;
                myField.AggType = ddlType.SelectedValue;
                myField.AggColumn = ddlColumn.SelectedValue;
                myField.LookupColumn = ddlLookup.SelectedValue;
                myField.Decimals = ddlDecimals.SelectedValue;
                myField.OutputType = ddlOutput.SelectedValue;
            }
        }

        public bool DisplayAsNewSection
        {
            get
            {
                return true;
            }
        }

        protected override void CreateChildControls()
        {

            base.CreateChildControls();

            if (!IsPostBack)
            {
                SPWeb web = SPContext.Current.Web;
                {
                    foreach (SPList slist in web.Lists)
                    {
                        if (!slist.Hidden)
                        {
                            ddlList.Items.Add(slist.Title);
                        }
                    }
                    ddlList.SelectedValue = list;

                    if (ddlList.SelectedValue != "")
                    {
                        SPList slist = web.Lists[ddlList.SelectedValue];
                        ddlColumn.Items.Add(new ListItem("-- Select Column --", ""));
                        ddlLookup.Items.Add(new ListItem("-- Select Column --", ""));
                        foreach (SPField f in slist.Fields)
                        {
                            if(!f.Hidden)
                            {
                                if(f.Type == SPFieldType.Number || f.Type == SPFieldType.Currency || f.TypeAsString == "TotalRollup")
                                {
                                    ddlColumn.Items.Add(new ListItem(f.Title, f.InternalName));
                                }
                                else if(f.Type == SPFieldType.Lookup || f.TypeAsString == "CascadingLookupField")
                                {
                                    ddlLookup.Items.Add(new ListItem(f.Title, f.InternalName));
                                }
                                else if (f.Type == SPFieldType.Calculated)
                                {
                                    string resulttype = "";
                                    XmlDocument fieldXml = new XmlDocument();
                                    fieldXml.LoadXml(f.SchemaXml);
                                    try
                                    {
                                        resulttype = fieldXml.ChildNodes[0].Attributes["ResultType"].Value;
                                    }
                                    catch { }
                                    if (resulttype == "Currency" || resulttype == "Number")
                                    {
                                        ddlColumn.Items.Add(new ListItem(f.Title, f.InternalName));
                                    }
                                }
                            }
                        }
                    }
                    if (ddlColumn.Items.FindByValue(column) != null)
                        ddlColumn.SelectedValue = column;

                    if (ddlLookup.Items.FindByValue(lookup) != null)
                        ddlLookup.SelectedValue = lookup;

                }

                ddlType.Attributes.Add("onchange", "hideCols(this)");

                ddlType.SelectedValue = aggtype;
                txtQuery.Text = query;
                ddlDecimals.SelectedValue = decimals;

                ddlOutput.SelectedValue = outputtype;
            }
        }

        protected void ddlList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            {
                SPList slist = web.Lists[ddlList.SelectedValue];
                ddlColumn.Items.Clear();
                ddlColumn.Items.Add(new ListItem("-- Select Column --", ""));
                ddlLookup.Items.Clear();
                ddlLookup.Items.Add(new ListItem("-- Select Column --", "")); 
                foreach (SPField f in slist.Fields)
                {
                    if (!f.Hidden)
                    {
                        if(f.Type == SPFieldType.Number || f.Type == SPFieldType.Currency || f.TypeAsString == "TotalRollup")
                        {
                            ddlColumn.Items.Add(new ListItem(f.Title, f.InternalName));
                        }
                        else if(f.Type == SPFieldType.Lookup || f.TypeAsString == "CascadingLookupField")
                        {
                            ddlLookup.Items.Add(new ListItem(f.Title, f.InternalName));
                        }
                        else if (f.Type == SPFieldType.Calculated)
                        {
                            string resulttype = "";
                            XmlDocument fieldXml = new XmlDocument();
                            fieldXml.LoadXml(f.SchemaXml);
                            try
                            {
                                resulttype = fieldXml.ChildNodes[0].Attributes["ResultType"].Value;
                            }
                            catch { }
                            if (resulttype == "Currency" || resulttype == "Number")
                            {
                                ddlColumn.Items.Add(new ListItem(f.Title, f.InternalName));
                            }
                        }
                    }
                }
                if (ddlColumn.Items.FindByValue(column) != null)
                    ddlColumn.SelectedValue = column;
                if (ddlLookup.Items.FindByValue(lookup) != null)
                    ddlLookup.SelectedValue = lookup;

            }
        }
    }
}
