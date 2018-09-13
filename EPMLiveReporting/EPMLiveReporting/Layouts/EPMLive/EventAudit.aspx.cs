using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPMLiveCore.ReportHelper;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using SystemTrace = System.Diagnostics.Trace;

namespace EPMLiveReportsAdmin.Layouts.EPMLive
{
    public partial class EventAudit : LayoutsPageBase
    {
        private const string EPMLiveReportsAdminLstEvents = "EPMLiveReportsAdmin.LstEvents";
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

        protected void AddEventHandler(string webUrl, string listName)
        {
            SPList spList = null;
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate 
                {
                        var spSite = SPContext.Current.Site;
                    {
                        spList = null;
                        SPWeb spWeb = spSite.OpenWeb(webUrl);
                        spWeb.AllowUnsafeUpdates = true;
                        try
                        {
                            spList = spWeb.Lists[listName];

                            var eventTypes = new List<SPEventReceiverType>
                                {
                                    SPEventReceiverType.ItemAdded,
                                    SPEventReceiverType.ItemUpdated,
                                    SPEventReceiverType.ItemDeleting
                                };

                            AddEventHandler(spList, EPMLiveCore.Properties.Resources.ReportingClassName, eventTypes);

                            if (webUrl.Equals(spSite.RootWeb.Url, StringComparison.InvariantCultureIgnoreCase))
                            {
                                eventTypes = new List<SPEventReceiverType>
                                    {
                                        SPEventReceiverType.FieldAdding,
                                        SPEventReceiverType.ListDeleting,
                                        SPEventReceiverType.FieldAdded,
                                        SPEventReceiverType.FieldUpdated,
                                        SPEventReceiverType.FieldDeleting
                                    };

                                AddEventHandler(spList, EPMLiveReportsAdminLstEvents, eventTypes);
                            }
                            spList.Update();
                        }
                        catch (Exception ex)
                        {
                            SystemTrace.WriteLine(ex.ToString());
                        }
                        spWeb.AllowUnsafeUpdates = false;
                    }
                });
            }
            catch (Exception ex)
            {
                SystemTrace.WriteLine(ex.ToString());
            }
        }

        private void AddEventHandler(SPList spList, string reportingClassName, List<SPEventReceiverType> eventTypes)
        {
            if (spList == null)
            {
                throw new ArgumentNullException(nameof(spList));
            }

            if (eventTypes == null)
            {
                throw new ArgumentNullException(nameof(eventTypes));
            }

            var deletedEvents = GetListEvents(spList,
                EPMLiveCore.Properties.Resources.ReportingAssembly,
                reportingClassName,
                eventTypes);

            foreach (var eventDefinition in deletedEvents)
            {
                eventDefinition.Delete();
            }

            foreach(var eventType in eventTypes)
            {
                spList.EventReceivers.Add(
                    eventType,
                    EPMLiveCore.Properties.Resources.ReportingAssembly,
                    reportingClassName);
            }

            var newEvents = GetListEvents(spList,
                EPMLiveCore.Properties.Resources.ReportingAssembly,
                reportingClassName,
                eventTypes);

            foreach (var eventDefinition in newEvents)
            {
                eventDefinition.SequenceNumber = 11000;
                eventDefinition.Update();
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
            var reportData = new ReportData(_SiteID);

            var itemEventTypes = GetItemEventTypes();
            var fieldEventTypes = GetFieldEventTypes2();
            var eventTypeCaptions = GetEventTypeToCaption();

            SPSecurity.RunWithElevatedPrivileges(delegate
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
                                // List may not always be present. IF NOT PRESENT, error will be caught.
                                spList = spWeb.Lists[_sListName];
                            }
                            catch (Exception ex)
                            {
                                SystemTrace.WriteLine(ex.ToString());
                            }

                            if (spList != null)
                            {
                                AuditWebs(spList, itemEventTypes, fieldEventTypes, eventTypeCaptions, spSite, spWeb);
                            }
                            else
                            {
                                // Report "List Not Present" error
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
            }
            else
            {
                var label = new Label();
                label.Text = "All webs up to date.";
                grdVwResults.Visible = false;
                var masterPage = Master;
                var placeHolder = (ContentPlaceHolder)masterPage.FindControl("ctl00$PlaceHolderMain");
                placeHolder.Controls.Add(label);
            }
        }

        private void AuditWebs(
            SPList spList, 
            Dictionary<SPEventReceiverType, bool> itemEventTypes, 
            Dictionary<SPEventReceiverType, bool> fieldEventTypes, 
            Dictionary<SPEventReceiverType, string> eventTypeCaptions, 
            SPSite spSite, 
            SPWeb spWeb)
        {
            foreach (SPEventReceiverDefinition eventDefinition in spList.EventReceivers)
            {
                UpdateEvents(itemEventTypes, eventDefinition, EPMLiveCore.Properties.Resources.ReportingClassName);

                // Check for top level rootweb. IF TRUE, THEN check for listdeleting and columndeleting events
                if (spWeb.Url.Equals(spSite.RootWeb.Url, StringComparison.InvariantCultureIgnoreCase))
                {
                    UpdateEvents(fieldEventTypes, eventDefinition, EPMLiveReportsAdminLstEvents);
                }
            }

            foreach (var eventType in itemEventTypes.Keys)
            {
                if (!itemEventTypes[eventType])
                {
                    AddAuditRecord(eventTypeCaptions[eventType], _sListName, spWeb.ServerRelativeUrl);
                }
            }

            // Check for top level rootweb. 
            if (spWeb.Url.Equals(spSite.RootWeb.Url, StringComparison.InvariantCultureIgnoreCase))
            {
                foreach (var eventType in fieldEventTypes.Keys)
                {
                    if (!fieldEventTypes[eventType])
                    {
                        AddAuditRecord(eventTypeCaptions[eventType], _sListName, spWeb.ServerRelativeUrl);
                    }
                }
            }
        }

        private static void UpdateEvents(
            Dictionary<SPEventReceiverType, bool> eventTypes, 
            SPEventReceiverDefinition eventDefinition, 
            string className)
        {
            var keys = eventTypes.Keys.ToList();
            for (var i = 0; i < keys.Count; i++)
            {
                var eventType = keys[i];
                eventTypes[eventType] =
                        eventDefinition.Type == eventType &&
                        eventDefinition.Class.Equals(className, StringComparison.InvariantCultureIgnoreCase);}
        }

        private static Dictionary<SPEventReceiverType, bool> GetItemEventTypes()
        {
            return new Dictionary<SPEventReceiverType, bool>
            {
                [SPEventReceiverType.ItemAdded] = false,
                [SPEventReceiverType.ItemUpdated] = false,
                [SPEventReceiverType.ItemDeleting] = false
            };
        }

        private static Dictionary<SPEventReceiverType, bool> GetFieldEventTypes2()
        {
            return new Dictionary<SPEventReceiverType, bool>
            {
                [SPEventReceiverType.ListDeleting] = false,
                [SPEventReceiverType.FieldAdded] = false,
                [SPEventReceiverType.FieldUpdated] = false,
                [SPEventReceiverType.FieldDeleting] = false,
                [SPEventReceiverType.FieldAdding] = false
            };
        }

        private static Dictionary<SPEventReceiverType, string> GetEventTypeToCaption()
        {
            return new Dictionary<SPEventReceiverType, string>
            {
                [SPEventReceiverType.ItemAdded] = "ItemAdded",
                [SPEventReceiverType.ItemUpdated] = "ItemUpdated",
                [SPEventReceiverType.ItemDeleting] = "ItemDeleting",
                [SPEventReceiverType.ListDeleting] = "ListDeleting",
                [SPEventReceiverType.FieldAdded] = "FieldAdded",
                [SPEventReceiverType.FieldUpdated] = "FieldUpdated",
                [SPEventReceiverType.FieldDeleting] = "FieldDeleting",
                [SPEventReceiverType.FieldAdding] = "FieldAdding",
            };
        }

        private void grdVwResults_RowCreated(object sender, GridViewRowEventArgs e)
        {
            var cb_add = new CheckBox();
            var cell = new TableCell();
            HiddenField hdnListName;
            HiddenField hdnWebUrl;
            string sControlId;
            
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

        public override void Dispose()
        {
            if (Controls != null)
            {
                for (var i = Controls.Count - 1; i >= 0; i--)
                {
                    Controls[i]?.Dispose();
                }
            }

            DisposeGridView();
            DisposeContentHolder();

            base.Dispose();
        }

        private void DisposeGridView()
        {
            if (grdVwResults == null)
            {
                return;
            }

            foreach (SPGridViewRow row in grdVwResults.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    foreach (Control control in cell.Controls)
                    {
                        control?.Dispose();
                    }
                }
            }

            grdVwResults.Dispose();
        }

        private void DisposeContentHolder()
        {
            var contenPlaceHolder = (ContentPlaceHolder)Master?.FindControl("ctl00$PlaceHolderMain");
            if (contenPlaceHolder == null)
            {
                return;
            }

            foreach(Control control in contenPlaceHolder.Controls)
            {
                control?.Dispose();
            }

            contenPlaceHolder.Dispose();
        }
    }
}