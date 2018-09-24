using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using SystemTrace = System.Diagnostics.Trace;

namespace EPMLiveReportsAdmin.Layouts.EPMLive
{
    public partial class EventAudit : LayoutsPageBase
    {
        private const string EPMLiveReportsAdminLstEvents = "EPMLiveReportsAdmin.LstEvents";
        private const string PlaceHolderId = "ctl00$PlaceHolderMain";
        private const string SIDParam = "sid";
        private const string LNameParam = "lname";
        private const string WebId = "Web";
        private const string ListNameColumn = "List Name";
        private const string MessageColumn = "Message";
        private const string ActivateColumn = "Activate";

        private Guid _SiteID;
        private DataTable _dtAuditRecs;
        private string _sListName;


        protected void Page_Init(object sender, EventArgs e)
        {
            save.ServerClick += save_ServerClick;
            AuditLists();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void save_ServerClick(object sender, EventArgs e)
        {
            foreach (SPGridViewRow row in grdVwResults.Rows)
            {
                var checkBock = (CheckBox)row.Cells[3].Controls[1];
                if (checkBock.Checked)
                {
                    var hiddenField = (HiddenField)row.Cells[3].Controls[3];
                    var sListName = hiddenField.Value;

                    hiddenField = (HiddenField)row.Cells[3].Controls[2];
                    var sWebUrl = hiddenField.Value;

                    AddEventHandler(sWebUrl, sListName);
                }
            }
            SPUtility.Redirect("/epmlive/ListMappings.aspx", SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
        }

        private IList<SPEventReceiverDefinition> GetListEvents(
            SPList list,
            string assemblyName,
            string className,
            IList<SPEventReceiverType> types)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            if (types == null)
            {
                throw new ArgumentNullException(nameof(types));
            }
            var events = new List<SPEventReceiverDefinition>();

            try
            {
                events = (from e in list.EventReceivers.OfType<SPEventReceiverDefinition>()
                    where e.Assembly.Equals(assemblyName, StringComparison.CurrentCultureIgnoreCase) &&
                          e.Class.Equals(className, StringComparison.CurrentCultureIgnoreCase) &&
                          types.Contains(e.Type)
                    select e).ToList();
            }
            catch (Exception ex)
            {
                SystemTrace.WriteLine((ex.ToString()));
            }

            return events;
        }

        protected void AuditLists()
        {
            if (Request.QueryString[SIDParam] != null && Request.QueryString[LNameParam] != null)
            {
                _SiteID = new Guid(Request.QueryString[SIDParam]);
                _sListName = Request.QueryString[LNameParam];
                Initialize();
                AuditWebs();
            }
            else
            {
                var label = new Label
                {
                    Text = "Audit not run. No siteId and/or list name provided."
                };
                var masterPage = Master;
                var placeHolder = (ContentPlaceHolder)masterPage.FindControl(PlaceHolderId);
                placeHolder.Controls.Add(label);
            }
        }

        private void grdVwResults_RowCreated(object sender, GridViewRowEventArgs e)
        {
            var cell = new TableCell();

            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                e.Row.ID = $"row{e.Row.RowIndex}";

                // Initialize control_ids for jsFunc
                var checkBox = new CheckBox
                {
                    ID = $"cb_add{e.Row.RowIndex}",
                    Checked = false,
                    Text = ActivateColumn
                };
                checkBox.Font.Name = "verdana";
                checkBox.Font.Size = FontUnit.Point(8);
                checkBox.ForeColor = Color.Black;
                checkBox.TextAlign = TextAlign.Right;
                var literal = new Literal
                {
                    Text = "&nbsp;&nbsp;"
                };
                cell.Controls.Add(literal);

                if (_dtAuditRecs.Rows[e.Row.RowIndex][MessageColumn].ToString()
                    .Equals("list not present.", StringComparison.InvariantCultureIgnoreCase))
                {
                    checkBox.Enabled = false;
                }

                var hdnListName = new HiddenField
                {
                    Value = _dtAuditRecs.Rows[e.Row.RowIndex][ListNameColumn].ToString()
                };

                var hdnWebUrl = new HiddenField
                {
                    Value = _dtAuditRecs.Rows[e.Row.RowIndex][WebId].ToString()
                };

                cell.Controls.Add(checkBox);
                cell.Controls.Add(hdnWebUrl);
                cell.Controls.Add(hdnListName);
                e.Row.Cells.AddAt(3, cell);
            }
            else
            {
                var checkBox = new CheckBox
                {
                    ID = "cb_accept_all",
                    Text = "Activate All",
                    TextAlign = TextAlign.Right
                };
                checkBox.Attributes.Add("onclick", "CheckUnCheckAll(this.checked)");
                var literal = new Literal
                {
                    Text = "&nbsp;"
                };
                e.Row.Cells[3].Controls.Add(literal);
                e.Row.Cells[3].Controls.Add(checkBox);
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            }
        }

        protected void Initialize()
        {
            _dtAuditRecs = new DataTable();
            _dtAuditRecs.Columns.Add(WebId);
            _dtAuditRecs.Columns.Add(ListNameColumn);
            _dtAuditRecs.Columns.Add(MessageColumn);
            _dtAuditRecs.Columns.Add(ActivateColumn);

            var column = new SPBoundField
            {
                HeaderText = "Web url",
                DataField = WebId
            };
            grdVwResults.Columns.Add(column);

            column = new SPBoundField
            {
                HeaderText = ListNameColumn,
                DataField = ListNameColumn
            };
            grdVwResults.Columns.Add(column);

            column = new SPBoundField
            {
                HeaderText = MessageColumn,
                DataField = MessageColumn
            };
            grdVwResults.Columns.Add(column);

            column = new SPBoundField
            {
                HeaderText = ActivateColumn,
                DataField = ActivateColumn
            };
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
            var contenPlaceHolder = (ContentPlaceHolder)Master?.FindControl(PlaceHolderId);
            if (contenPlaceHolder == null)
            {
                return;
            }

            foreach (Control control in contenPlaceHolder.Controls)
            {
                control?.Dispose();
            }

            contenPlaceHolder.Dispose();
        }
    }
}