using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using System.Collections;
using System.Xml;
using System.Data;
using System.Collections.Generic;
using EPMLiveIntegration;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace EPMLiveCore.Layouts.epmlive.Integration
{
    public partial class Columns : LayoutsPageBase
    {
        protected string PageHead;
        protected Guid intlistid = Guid.Empty;
        protected Guid moduleid = Guid.Empty;
        API.Integration.IntegrationCore intcore;
        API.Integration.IntegrationAdmin intadmin;

        ArrayList ArrControls = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    intlistid = new Guid(Request["intlistid"]);
                }
                catch { }

                intcore = new API.Integration.IntegrationCore(Web.Site.ID, Web.ID);
                intadmin = new API.Integration.IntegrationAdmin(intcore, intlistid, moduleid);

                bool bWizard = false;

                try
                {
                    if(Request["wizard"] == "1")
                        bWizard = true;
                }catch{}

            

                PageHead = intadmin.GetIntegrationHeader();

                Hashtable hshProps = new Hashtable();
                if(intlistid != Guid.Empty)
                    hshProps = intcore.GetProperties(intlistid);

                SPList list = Web.Lists[intadmin.ListId];

                List<ColumnProperty> ColumnList = intcore.GetColumns(hshProps, intadmin.ModuleID, intlistid, list);

                DropDownList ddlColsTemp = new DropDownList();

                foreach(ColumnProperty Column in ColumnList)
                {
                    ListItem li1 = new ListItem(Column.DiplayName, Column.ColumnName);
                    ddlIDColumn.Items.Add(li1);

                    ListItem li2 = new ListItem(Column.DiplayName, Column.ColumnName);
                    ddlSPColumn.Items.Add(li2);

                    ListItem li3 = new ListItem(Column.DiplayName, Column.ColumnName);
                    ddlSecMatch.Items.Add(li3);
                    
                    ListItem li4 = new ListItem(Column.DiplayName, Column.ColumnName);
                    ddlIntegrationMatch.Items.Add(li4);
                }


                SPList List = Web.Lists[new Guid(Request["List"])];


                pnlColumns.Controls.Add(new LiteralControl("<table>"));
                pnlColumns.Controls.Add(new LiteralControl("<tr><td><b>SharePoint Column</b></td><td><b>Integration Column</b></td></tr>"));

                SortedList sl = new SortedList();
                foreach(SPField field in List.Fields)
                {
                    if(field.Reorderable)
                    {
                        if(!sl.Contains(field.Title))
                        {
                            sl.Add(field.Title, field.InternalName);
                        }
                    }
                }

                Hashtable hshParams = new Hashtable();
                hshParams.Add("intlistid", intlistid);

                DataSet ds = intcore.GetDataSet("SELECT * FROM INT_COLUMNS WHERE INT_LIST_ID=@intlistid", hshParams);
                DataTable dtColumns = ds.Tables[0];

                foreach(DictionaryEntry de in sl)
                {
                    DropDownList ddl = new DropDownList();
                    ddl.ID = de.Value.ToString();
                    ddl.Items.Add (new ListItem("--Select Column--", ""));


                    ListItem li3 = new ListItem(de.Key.ToString(), de.Value.ToString());
                    ddlSharePointMatch.Items.Add(li3);

                    string curCol = "";

                    if(!IsPostBack)
                    {
                        DataRow []drCol = dtColumns.Select("SharePointColumn='" + de.Value.ToString() + "'");
                        if(drCol.Length > 0)
                            curCol = drCol[0]["IntegrationColumn"].ToString();
                    }

                    foreach(ColumnProperty Column in ColumnList)
                    {
                        ListItem li2 = new ListItem(Column.DiplayName, Column.ColumnName);
                        if(!IsPostBack)
                            if(bWizard && Column.DefaultListColumn == de.Value.ToString())
                                li2.Selected = true;
                            else if(curCol == Column.ColumnName)
                                li2.Selected = true;

                        ddl.Items.Add(li2);
                    }

                    ArrControls.Add(ddl);

                    pnlColumns.Controls.Add(new LiteralControl("<tr><td>" + de.Key.ToString() + "</td><td>"));
                    
                    pnlColumns.Controls.Add(ddl);

                    pnlColumns.Controls.Add(new LiteralControl("</td></tr>"));
                }

                pnlColumns.Controls.Add(new LiteralControl("</table>"));

                if(!IsPostBack)
                {
                    if(bWizard)
                    {
                        foreach(ColumnProperty Column in ColumnList)
                        {
                            ListItem li2 = new ListItem(Column.DiplayName, Column.ColumnName);
                            if(Column.DefaultListColumn == "INTUID")
                                ddlIDColumn.SelectedValue = Column.ColumnName;
                            if(Column.DefaultListColumn == "SPID")
                                ddlSPColumn.SelectedValue = Column.ColumnName;
                            if(Column.DefaultListColumn == "SECMATCH")
                                ddlSecMatch.SelectedValue = Column.ColumnName;
                        }
                    }
                    else
                    {
                        try
                        {
                            ddlIDColumn.SelectedValue = hshProps["IDColumn"].ToString();
                        }
                        catch { }

                        try
                        {
                            ddlSPColumn.SelectedValue = hshProps["SPColumn"].ToString();
                        }
                        catch { }

                        try
                        {
                            ddlSecMatch.SelectedValue = hshProps["SecMatch"].ToString();
                        }
                        catch { }

                        try
                        {
                            string[] match = hshProps["ItemMatch"].ToString().Split('|');
                            ddlSharePointMatch.SelectedValue = match[0];
                            ddlIntegrationMatch.SelectedValue = match[1];
                        }
                        catch { }
                    }
                }
            

                if(bWizard)
                {
                    Button1.Text = "Finish";
                    Button1.OnClientClick = "Install();";
                }
                else
                {
                    Button1.OnClientClick = "DisableButtons();";
                }
            });
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool success = true;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                 Hashtable hshProps = new Hashtable();
                 hshProps.Add("IDColumn", ddlIDColumn.SelectedValue);
                 hshProps.Add("SPColumn", ddlSPColumn.SelectedValue);
                 if(ddlSharePointMatch.SelectedValue == "")
                     hshProps.Add("ItemMatch", "");
                 else
                     hshProps.Add("ItemMatch", ddlSharePointMatch.SelectedValue + "|" + ddlIntegrationMatch.SelectedValue);

                 hshProps.Add("SecMatch", ddlSecMatch.SelectedValue);

                 intcore.SaveProperties(intlistid, hshProps);

                 hshProps = new Hashtable();
                 hshProps.Add("intlistid", intlistid);
                 intcore.ExecuteQuery("Delete from INT_COLUMNS where INT_LIST_ID=@intlistid", hshProps, false);

                 foreach(DropDownList ddl in ArrControls)
                 {
                     if(ddl.SelectedValue != "")
                     {
                         hshProps = new Hashtable();
                         hshProps.Add("intlistid", intlistid);
                         hshProps.Add("SharePointColumn", ddl.ID);
                         hshProps.Add("IntegrationColumn", ddl.SelectedValue);

                         intcore.ExecuteQuery("INSERT INTO INT_COLUMNS (INT_LIST_ID, SharePointColumn, IntegrationColumn) VALUES (@intlistid, @SharePointColumn, @IntegrationColumn)", hshProps, false);
                     }
                 }

                 

                 if(Request["wizard"] == "1")
                 {
                     hshProps = new Hashtable();
                     hshProps.Add("intlistid", intlistid);

                     string message = "";


                     if(intcore.InstallIntegration(intlistid, new Guid(Request["List"]), out message))
                     {
                         intcore.ExecuteQuery("UPDATE INT_LISTS set active=1 where INT_LIST_ID=@intlistid", hshProps, true);
                     }
                     else
                     {
                         success = false;
                         lblError.Text = message + "<br>";
                         lblError.Visible = true;
                     }
                 }

                 intcore.CloseConnection(true);
            });
            if(success)
                SPUtility.Redirect("epmlive/integration/integrationlist.aspx?LIST=" + Request["List"], SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current);
        }
    }
}
