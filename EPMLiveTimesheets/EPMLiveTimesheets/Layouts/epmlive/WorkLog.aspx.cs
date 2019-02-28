using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace TimeSheets.Layouts.epmlive
{
    public partial class WorkLog : LayoutsPageBase
    {
        private const string TxtHoursPrefix = "txtHours_";
        private bool _disposed;

        private Guid _listId;
        private int _listItemId;
        protected Dictionary<int, TextBox> txtHours = new Dictionary<int, TextBox>();
        int activation;
        private EPMLiveCore.Act act;

        protected override void OnInit(EventArgs e)
        {
            act = new EPMLiveCore.Act(Web);
            activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.Timesheets);

            if (activation != 0)
                return;

            base.OnInit(e);

            _listId = new Guid(Request.QueryString["ListId"]);
            _listItemId = int.Parse(Request.QueryString["ItemId"]);

            ConfigureControls();

            if (!IsPostBack)
            {
                var web = SPContext.Current.Web;
                TSItem.PopulateDDLUsers(ddlUsers, web, web.CurrentUser);
                if (ddlUsers.Items.Count > 1)
                    pnlUsers.Visible = true;
                else
                    pnlUsers.Visible = false;
            }
        }

        protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateForm();
        }

        protected void dtcDate_DateChanged(object sender, EventArgs e)
        {
            PopulateForm();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (activation != 0)
            {
                pnlActivate.Visible = true;
                pnlMain.Visible = false;
                lblActivate.Text = act.translateStatus(activation);
                return;
            }

            if (IsPostBack)
                return;

            PopulateForm();
            dtcDate.SelectedDate = DateTime.Now;
            ddlUsers.SelectedIndex = 0;
        }

        private void PopulateForm()
        {
            var tsItem = new TSItem(_listId, _listItemId, dtcDate.SelectedDate, ddlUsers.SelectedValue, ddlUsers.SelectedItem.Text);

            h2Title.InnerText = tsItem.List.Title + ": " + tsItem.ListItem.Title;

            if (!tsItem.Authorized)
            {
                ErrorMessage("You must be assigned to this item in order to submit hours.");
                return;
            }
            if (!tsItem.IsTSList)
            {
                ErrorMessage("This list is not configured for use with timesheets.");
                return;
            }
            if (!tsItem.IsTSChecked)
            {
                ErrorMessage("This item has not been allowed in timesheets.");
                return;
            }
            if (tsItem.PeriodId == 0)
            {
                ToggleFields(false, "This date does not fall within a valid timesheet period.");
                return;
            }
            if (!tsItem.ValidDay)
            {
                ToggleFields(false, tsItem.Date.DayOfWeek + " is not a valid timesheet day.");
                return;
            }

            //Testing: ToggleFields(true, string.Format("List: {0}, Item: {1}", _listId, _listItemId) );
            ToggleFields(true, "");
            pnlNotes.Visible = tsItem.AllowNotes;
            PopulateExistingHours(tsItem);
            RegisterDynamicScripts(tsItem);
        }

        private void PopulateExistingHours(TSItem tsItem)
        {
            foreach (KeyValuePair<int, TextBox> tb in txtHours)
            {
                tb.Value.Text = tsItem == null || !tsItem.Work.ContainsKey(tb.Key)
                                    ? "0"
                                    : tsItem.Work[tb.Key].ToString();
            }
            if (tsItem != null)
                txtNotes.Text = tsItem.Notes;
        }

        private void ErrorMessage(string message)
        {
            pnlForm.Visible = false;
            pnlError.Visible = true;
            lblError.Text = message;
        }

        private void ToggleFields(bool enabled, string message)
        {
            btnSave.Enabled = enabled;
            btnSaveClose.Enabled = enabled;
            foreach (KeyValuePair<int, TextBox> tb in txtHours)
                tb.Value.Enabled = enabled;
            txtNotes.Enabled = enabled;
            lblDateMessage.Text = message;
            lblStatusMessage.Text = "";
        }

        private HtmlTableRow BuildWorkTypeRow(int id, string label)
        {
            var tr = new HtmlTableRow();
            var td1 = new HtmlTableCell();
            var td2 = new HtmlTableCell();
            var tb = new TextBox { ID = TxtHoursPrefix + id, Width = Unit.Pixel(30) };
            tb.Attributes.Add("onKeyUp", "hoursChanged();");
            tb.Attributes.Add("onKeyPress", "validate(event);");
            tb.Attributes.Add("style", "text-align:right;");
            tb.Attributes.Add("class", "ms-input");
            txtHours.Add(id, tb);
            td1.Controls.Add(new Literal { Text = label + ":&nbsp;" });
            td2.Controls.Add(tb);
            tr.Cells.Add(td1);
            tr.Cells.Add(td2);
            return tr;
        }

        private void ConfigureControls()
        {
            ddlUsers.SelectedIndexChanged += ddlUsers_SelectedIndexChanged;
            ddlUsers.AutoPostBack = true;
            dtcDate.DateChanged += dtcDate_DateChanged;
            dtcDate.AutoPostBack = true;
            dtcDate.OnValueChangeClientScript = "alert('Changed');";

            btnSave.Click += btnSave_Click;
            btnSaveClose.Click += btnSave_Click;
            var workTypes = TSItem.GetWorkTypes(SPContext.Current.Site.ID);
            if (workTypes.Count == 0)
                phHours.Controls.Add(BuildWorkTypeRow(0, "Work"));
            else
                foreach (var workType in workTypes)
                    phHours.Controls.Add(BuildWorkTypeRow(workType.Key, workType.Value));

            phHours.Controls.Add(
                new LiteralControl("<tr height='22px'><td style='padding-right:20px;'>Other work this day:&nbsp;</td><td id='tdOther' style='text-align:right;padding-right:3px;' >&nbsp;</td></tr>"));
            phHours.Controls.Add(
                new LiteralControl("<tr height='22px'><td id='tdTotalLabel' style='padding-right:20px;'>Total:&nbsp;</td><td id='tdTotal' style='font-weight:bold;text-align:right;padding-right:3px;'>&nbsp;</td></tr>"));

            RegisterBaseScript();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var tsItem = new TSItem(_listId, _listItemId, dtcDate.SelectedDate, ddlUsers.SelectedValue, ddlUsers.SelectedItem.Text)
            {
                WorkFromInput = txtHours,
                Notes = txtNotes.Text
            };

            lblStatusMessage.Text = tsItem.Update()
                                  ? string.Format("Work hours saved for {0:d}", dtcDate.SelectedDate) +
                                        (tsItem.WorkNewHoursValid ? "" : "<br/><em>(The hours are invalid and will need to be adjusted before they can be posted).</em>")
                                  : string.Format("Error saving hours for {0:d}", dtcDate.SelectedDate);
            PopulateExistingHours(tsItem);
            RegisterDynamicScripts(tsItem);

            if (((Button)sender).ID == "btnSaveClose")
            {
                RegisterScript("saveclose", "<script language=\"javascript\">window.frameElement.commitPopup();</script>");
            }
        }
        
        public override void Dispose()
        {
            if (!_disposed)
            {
                phHours?.Dispose();
                _disposed = true;
            }

            base.Dispose();
        }
    }
}
