using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPMLiveReportsAdmin.Properties;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using Image = System.Web.UI.WebControls.Image;
using EPMLiveCore.ReportHelper;

namespace EPMLiveReportsAdmin.Layouts.EPMLive
{
    public partial class EventAudit : LayoutsPageBase
    {
        //protected SPGridView grdVwResults;
        //protected HtmlInputButton save;

        private Guid _SiteID;
        private DataTable _dtAuditRecs;
        private string _sListName;


        protected void Page_Init(object sender, EventArgs e)
        {
            save.ServerClick += save_ServerClick;
            AuditLists();
        }

        protected void Page_Load(object sender, EventArgs e) { }

        private void save_ServerClick(object sender, EventArgs e)
        {
            foreach (SPGridViewRow row in grdVwResults.Rows)
            {
                var cb1 = (CheckBox) row.Cells[3].Controls[1];
                if (cb1.Checked)
                {
                    HiddenField hdn;
                    hdn = (HiddenField) row.Cells[3].Controls[3];
                    string sListName = hdn.Value;

                    hdn = (HiddenField) row.Cells[3].Controls[2];
                    string sWebUrl = hdn.Value;

                    AddEventHandler(sWebUrl, sListName);
                }
            }
            SPUtility.Redirect("/epmlive/ListMappings.aspx", SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
        }

        protected void AddEventHandler(string sWebUrl, string sListName)
        {
            SPList spList = null;
            try
            {
                SPSecurity.RunWithElevatedPrivileges(
                    delegate
                    {
                        SPSite spSite = SPContext.Current.Site;
                        {
                            spList = null;
                            SPWeb spWeb = spSite.OpenWeb(sWebUrl);
                            spWeb.AllowUnsafeUpdates = true;
                            try
                            {
                                spList = spWeb.Lists[sListName];

                                // remove event first to avoid duplicates
                                List<SPEventReceiverDefinition> evts = GetListEvents(spList,
                                    EPMLiveCore.Properties.Resources.ReportingAssembly,
                                    EPMLiveCore.Properties.Resources.ReportingClassName,
                                    new List<SPEventReceiverType>
                                    {
                                        SPEventReceiverType.ItemAdded,
                                        SPEventReceiverType.ItemUpdated,
                                        SPEventReceiverType.ItemDeleting
                                    });

                                foreach (SPEventReceiverDefinition e in evts)
                                {
                                    e.Delete();
                                }

                                spList.EventReceivers.Add(SPEventReceiverType.ItemAdded, EPMLiveCore.Properties.Resources.ReportingAssembly,
                                    EPMLiveCore.Properties.Resources.ReportingClassName);
                                spList.EventReceivers.Add(SPEventReceiverType.ItemUpdated, EPMLiveCore.Properties.Resources.ReportingAssembly,
                                    EPMLiveCore.Properties.Resources.ReportingClassName);
                                spList.EventReceivers.Add(SPEventReceiverType.ItemDeleting, EPMLiveCore.Properties.Resources.ReportingAssembly,
                                    EPMLiveCore.Properties.Resources.ReportingClassName);


                                List<SPEventReceiverDefinition> newEvts = GetListEvents(spList,
                                    EPMLiveCore.Properties.Resources.ReportingAssembly,
                                    EPMLiveCore.Properties.Resources.ReportingClassName,
                                    new List<SPEventReceiverType>
                                    {
                                        SPEventReceiverType.ItemAdded,
                                        SPEventReceiverType.ItemUpdated,
                                        SPEventReceiverType.ItemDeleting
                                    });

                                foreach (SPEventReceiverDefinition e in newEvts)
                                {
                                    e.SequenceNumber = 11000;
                                    e.Update();
                                }
                                //check to see if it is the rootweb. IF TRUE, THEN add listdeleting and columndeleting event handlers.
                                if (sWebUrl.ToLower() == spSite.RootWeb.Url.ToLower())
                                {
                                    List<SPEventReceiverDefinition> delEvts = GetListEvents(spList,
                                        EPMLiveCore.Properties.Resources.ReportingAssembly,
                                        "EPMLiveReportsAdmin.LstEvents",
                                        new List<SPEventReceiverType>
                                        {
                                            SPEventReceiverType.FieldAdding,
                                            SPEventReceiverType.ListDeleting,
                                            SPEventReceiverType.FieldAdded,
                                            SPEventReceiverType.FieldUpdated,
                                            SPEventReceiverType.FieldDeleting
                                        });

                                    foreach (SPEventReceiverDefinition e in delEvts)
                                    {
                                        e.Delete();
                                    }

                                    spList.EventReceivers.Add(SPEventReceiverType.FieldAdding, EPMLiveCore.Properties.Resources.ReportingAssembly,
                                      "EPMLiveReportsAdmin.LstEvents");
                                    spList.EventReceivers.Add(SPEventReceiverType.ListDeleting, EPMLiveCore.Properties.Resources.ReportingAssembly,
                                        "EPMLiveReportsAdmin.LstEvents");
                                    spList.EventReceivers.Add(SPEventReceiverType.FieldAdded, EPMLiveCore.Properties.Resources.ReportingAssembly,
                                        "EPMLiveReportsAdmin.LstEvents");
                                    spList.EventReceivers.Add(SPEventReceiverType.FieldUpdated, EPMLiveCore.Properties.Resources.ReportingAssembly,
                                        "EPMLiveReportsAdmin.LstEvents");
                                    spList.EventReceivers.Add(SPEventReceiverType.FieldDeleting, EPMLiveCore.Properties.Resources.ReportingAssembly,
                                        "EPMLiveReportsAdmin.LstEvents");

                                    List<SPEventReceiverDefinition> newEvts2 = GetListEvents(spList,
                                        EPMLiveCore.Properties.Resources.ReportingAssembly,
                                        "EPMLiveReportsAdmin.LstEvents",
                                        new List<SPEventReceiverType>
                                        {
                                            SPEventReceiverType.FieldAdding,
                                            SPEventReceiverType.ListDeleting,
                                            SPEventReceiverType.FieldAdded,
                                            SPEventReceiverType.FieldUpdated,
                                            SPEventReceiverType.FieldDeleting,
                                        });

                                    foreach (SPEventReceiverDefinition e in newEvts2)
                                    {
                                        e.SequenceNumber = 11000;
                                        e.Update();
                                    }
                                }
                                spList.Update();
                            }
                            catch (Exception ex) { }
                            spWeb.AllowUnsafeUpdates = false;
                        }
                    });
            }
            catch (Exception ex)
            {
                //Add logging here....
            }
        }

        private List<SPEventReceiverDefinition> GetListEvents(SPList list, string assemblyName, string className,
            List<SPEventReceiverType> types)
        {
            var evts = new List<SPEventReceiverDefinition>();

            try
            {
                evts = (from e in list.EventReceivers.OfType<SPEventReceiverDefinition>()
                        where e.Assembly.Equals(assemblyName, StringComparison.CurrentCultureIgnoreCase) &&
                              e.Class.Equals(className, StringComparison.CurrentCultureIgnoreCase) &&
                              types.Contains(e.Type)
                        select e).ToList<SPEventReceiverDefinition>();
            }
            catch { }

            return evts;
        }

        protected void AuditLists()
        {
            if (Request.QueryString["sid"] != null && Request.QueryString["lname"] != null)
            {
                _SiteID = new Guid(Request.QueryString["sid"]);
                _sListName = Request.QueryString["lname"];
                Initialize();
                AuditWebs();
            }
            else
            {
                var lbl = new Label();
                lbl.Text = "Audit not run. No siteId and/or list name provided.";
                MasterPage mp = Master;
                var cph = (ContentPlaceHolder) mp.FindControl("ctl00$PlaceHolderMain");
                cph.Controls.Add(lbl);
            }
        }

        protected void AuditWebs()
        {
            SPList spList = null;
            var DAO = new ReportData(_SiteID);
            bool blnAddEvent = false;
            bool blnUpdateEvent = false;
            bool blnDeleteEvent = false;
            bool blnListDeleteEvent = false;
            bool blnColumnDeleteEvent = false;
            bool blnColumnAddEvent = false;
            bool blnColumnUpdateEvent = false;
            bool blnColumnAddingEvent = false;

            SPSecurity.RunWithElevatedPrivileges(
                delegate
                {
                    using (var spSite = new SPSite(_SiteID))
                    {
                        foreach (SPWeb spWeb in spSite.AllWebs)
                        {
                            using (spWeb)
                            {
                                spWeb.AllowUnsafeUpdates = true;
                                spList = null;
                                try
                                {
                                    //List may not always be present. IF NOT PRESENT, error will be caught.
                                    spList = spWeb.Lists[_sListName];
                                }
                                catch (Exception ex) { }

                                if (spList != null)
                                {
                                    //Reset flags
                                    blnAddEvent = false;
                                    blnDeleteEvent = false;
                                    blnUpdateEvent = false;
                                    blnListDeleteEvent = false;
                                    blnColumnDeleteEvent = false;
                                    blnColumnAddEvent = false;
                                    blnColumnUpdateEvent = false;
                                    blnColumnAddingEvent = false;

                                    foreach (SPEventReceiverDefinition spEventDef in spList.EventReceivers)
                                    {
                                        if (spEventDef.Type == SPEventReceiverType.ItemAdded &&
                                            spEventDef.Class.ToLower() == EPMLiveCore.Properties.Resources.ReportingClassName.ToLower())
                                        {
                                            blnAddEvent = true;
                                        }

                                        if (spEventDef.Type == SPEventReceiverType.ItemUpdated &&
                                            spEventDef.Class.ToLower() == EPMLiveCore.Properties.Resources.ReportingClassName.ToLower())
                                        {
                                            blnUpdateEvent = true;
                                        }

                                        if (spEventDef.Type == SPEventReceiverType.ItemDeleting &&
                                            spEventDef.Class.ToLower() == EPMLiveCore.Properties.Resources.ReportingClassName.ToLower())
                                        {
                                            blnDeleteEvent = true;
                                        }

                                        //Check for top level rootweb. IF TRUE, THEN check for listdeleting and columndeleting events
                                        if (spWeb.Url.ToLower() == spSite.RootWeb.Url.ToLower())
                                        {
                                            if (spEventDef.Type == SPEventReceiverType.ListDeleting &&
                                                spEventDef.Class.ToLower() == "EPMLiveReportsAdmin.LstEvents".ToLower())
                                            {
                                                blnListDeleteEvent = true;
                                            }

                                            if (spEventDef.Type == SPEventReceiverType.FieldAdded &&
                                                spEventDef.Class.ToLower() == "EPMLiveReportsAdmin.LstEvents".ToLower())
                                            {
                                                blnColumnAddEvent = true;
                                            }

                                            if (spEventDef.Type == SPEventReceiverType.FieldUpdated &&
                                                spEventDef.Class.ToLower() == "EPMLiveReportsAdmin.LstEvents".ToLower())
                                            {
                                                blnColumnUpdateEvent = true;
                                            }

                                            if (spEventDef.Type == SPEventReceiverType.FieldDeleting &&
                                                spEventDef.Class.ToLower() == "EPMLiveReportsAdmin.LstEvents".ToLower())
                                            {
                                                blnColumnDeleteEvent = true;
                                            }
                                            if (spEventDef.Type == SPEventReceiverType.FieldAdding &&
                                              spEventDef.Class.ToLower() == "EPMLiveReportsAdmin.LstEvents".ToLower())
                                            {
                                                blnColumnAddingEvent = true;
                                            }
                                        }
                                    }

                                    if (!blnAddEvent)
                                    {
                                        AddAuditRecord("ItemAdded", _sListName, spWeb.ServerRelativeUrl);
                                    }

                                    if (!blnUpdateEvent)
                                    {
                                        AddAuditRecord("ItemUpdated", _sListName, spWeb.ServerRelativeUrl);
                                    }

                                    if (!blnDeleteEvent)
                                    {
                                        AddAuditRecord("ItemDeleting", _sListName, spWeb.ServerRelativeUrl);
                                    }

                                    //Check for top level rootweb. 
                                    if (spWeb.Url.ToLower() == spSite.RootWeb.Url.ToLower())
                                    {
                                        if (!blnListDeleteEvent)
                                        {
                                            AddAuditRecord("ListDeleting", _sListName, spWeb.ServerRelativeUrl);
                                        }

                                        if (!blnColumnAddEvent)
                                        {
                                            AddAuditRecord("FieldAdded", _sListName, spWeb.ServerRelativeUrl);
                                        }

                                        if (!blnColumnUpdateEvent)
                                        {
                                            AddAuditRecord("FieldUpdated", _sListName, spWeb.ServerRelativeUrl);
                                        }

                                        if (!blnColumnDeleteEvent)
                                        {
                                            AddAuditRecord("FieldDeleting", _sListName, spWeb.ServerRelativeUrl);
                                        }
                                        if (!blnColumnAddingEvent)
                                        {
                                            AddAuditRecord("FieldAdding", _sListName, spWeb.ServerRelativeUrl);
                                        }
                                    }
                                }
                                else
                                {
                                    //Report "List Not Present" error
                                    AddAuditRecord("List Not Present.", _sListName, spWeb.ServerRelativeUrl);
                                }
                                spWeb.AllowUnsafeUpdates = false;
                            }
                        }
                    }
                });

            if (_dtAuditRecs.Rows.Count > 0)
            {
                grdVwResults.ID = "grdVwResults";
                grdVwResults.RowCreated += grdVwResults_RowCreated;
                grdVwResults.DataSource = _dtAuditRecs;
                grdVwResults.AutoGenerateColumns = false;
                grdVwResults.DataBind();

                //MasterPage mp = Master;
                //ContentPlaceHolder cph = (ContentPlaceHolder)mp.FindControl("ctl00$PlaceHolderMain");
                //cph.Controls.Add(grdVwResults); 
            }
            else
            {
                var lbl = new Label();
                lbl.Text = "All webs up to date.";
                grdVwResults.Visible = false;
                MasterPage mp = Master;
                var cph = (ContentPlaceHolder) mp.FindControl("ctl00$PlaceHolderMain");
                cph.Controls.Add(lbl);
            }
        }

        private void grdVwResults_RowCreated(object sender, GridViewRowEventArgs e)
        {
            var cb_add = new CheckBox();
            var cell = new TableCell();
            HiddenField hdnListName;
            HiddenField hdnWebUrl;
            string sControlId;
            var img = new Image();

            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                cb_add = new CheckBox();
                e.Row.ID = "row" + e.Row.RowIndex;

                //Initialize control_ids for jsFunc
                cb_add.ID = "cb_add" + e.Row.RowIndex;
                cb_add.Checked = false;

                sControlId = "grdVwResults_" + e.Row.ID + "_" + cb_add.ID;
                cb_add.Text = "Activate";
                cb_add.Font.Name = "verdana";
                cb_add.Font.Size = FontUnit.Point(8);
                cb_add.ForeColor = Color.Black;
                cb_add.TextAlign = TextAlign.Right;
                var lit = new Literal();
                lit.Text = "&nbsp;&nbsp;";
                cell.Controls.Add(lit);

                if (_dtAuditRecs.Rows[e.Row.RowIndex]["Message"].ToString().ToLower() == "list not present.")
                {
                    cb_add.Enabled = false;
                }

                hdnListName = new HiddenField();
                hdnListName.Value = _dtAuditRecs.Rows[e.Row.RowIndex]["List Name"].ToString();

                hdnWebUrl = new HiddenField();
                hdnWebUrl.Value = _dtAuditRecs.Rows[e.Row.RowIndex]["Web"].ToString();

                cell.Controls.Add(cb_add);
                cell.Controls.Add(hdnWebUrl);
                cell.Controls.Add(hdnListName);
                e.Row.Cells.AddAt(3, cell);
            }
            else
            {
                cb_add.Attributes.Add("onclick", "CheckUnCheckAll(this.checked)");
                cb_add.ID = "cb_accept_all";
                cb_add.Text = "Activate All";
                cb_add.TextAlign = TextAlign.Right;
                var lit = new Literal();
                lit.Text = "&nbsp;";
                e.Row.Cells[3].Controls.Add(lit);
                e.Row.Cells[3].Controls.Add(cb_add);
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            }
        }

        protected void AddAuditRecord(string sMessage, string sListName, string sWebUrl)
        {
            DataRow row = _dtAuditRecs.NewRow();
            row["Web"] = sWebUrl;
            row["List Name"] = sListName;
            row["Message"] = sMessage;
            _dtAuditRecs.Rows.Add(row);
        }

        protected void Initialize()
        {
            _dtAuditRecs = new DataTable();
            _dtAuditRecs.Columns.Add("Web");
            _dtAuditRecs.Columns.Add("List Name");
            _dtAuditRecs.Columns.Add("Message");
            _dtAuditRecs.Columns.Add("Activate");


            //grdVwResults = new SPGridView();
            var column = new SPBoundField();
            column.HeaderText = "Web url";
            column.DataField = "Web";
            grdVwResults.Columns.Add(column);

            column = new SPBoundField();
            column.HeaderText = "List Name";
            column.DataField = "List Name";
            grdVwResults.Columns.Add(column);

            column = new SPBoundField();
            column.HeaderText = "Message";
            column.DataField = "Message";
            grdVwResults.Columns.Add(column);

            column = new SPBoundField();
            column.HeaderText = "Activate";
            column.DataField = "Activate";
            grdVwResults.Columns.Add(column);
        }
    }
}