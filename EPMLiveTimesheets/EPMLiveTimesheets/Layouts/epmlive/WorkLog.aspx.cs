using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;

namespace TimeSheets.Layouts.epmlive
{
    public partial class WorkLog : LayoutsPageBase
    {
        private const string TxtHoursPrefix = "txtHours_";

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

        private void RegisterDynamicScripts(TSItem tsItem)
        {
            //var workDoneTSItem = tsItem.WorkDoneTSItem.ToString();
            //var workDoneListItem = tsItem.WorkDoneListItem.ToString();
            var workAllocated = tsItem.WorkAllocated.ToString();

            var jsvars = "";
            int i = 0;
            foreach (var tb in txtHours)
            {
                jsvars += string.Format("tb[{0}] = document.getElementById('{1}');", i++, tb.Value.ClientID);
            }
            var blank = "<img src='_layouts/epmlive/blank.gif' height='1' width='1'>";
            var pre = "<table border='1' width='240' cellpadding='0' cellspacing='0' class='statustable'><tr class='noborder'>";
            //Testing: var post = string.Format(@"</tr></table></td><td id='tdTotal'>"" + workRunningTotal + ""/{0} hours, ListItemTotal: {1}, User Daily: {2}", workAllocated, workDoneListItem, tsItem.WorkDoneUser);
            var post = string.Format(@"</tr></table></td><td id='tdTotal'>"" + workRunningTotal + ""/{0} hours", workAllocated);
            var js = string.Format(@"<script type=text/javascript>

            var min;
            var max;
            var tdTotalLabel;
            var workExisting;
            var workUserDayTotal;

            init();

            function init() {{
                //window.onbeforeunload=leavePage
                min = {6};
                max = {7};
                tdTotalLabel = document.getElementById('tdTotalLabel');
                tdTotalLabel.innerHTML = 'Total (must be between ' + min + '-' + max + ')&nbsp;';
                calculateExisting();
                var tdOther = document.getElementById('tdOther');
                tdOther.innerHTML = workUserDayTotal;
                hoursChanged();
                dirty = false;
            }}
            
            function getWorkNew()
            {{
                var tb = new Array();
                {0}
                var workNew = 0;
                for(i=0; i < tb.length; i++)
                {{
                    workNew += Number(tb[i].value)
                }}
                return workNew;
            }}

            function calculateExisting()
            {{
                var workNew = getWorkNew();
                if(workNew == undefined)
                {{
                    workExisting = 0;
                    workUserDayTotal = 0;
                }}                
                else
                {{
                    workExisting = {4} - workNew;
                    workUserDayTotal = {8} - workNew;
                }}
            }}

            function hoursChanged() {{
                var workNew = getWorkNew();
                if(workNew == undefined)
                    return;
                setpctchart(workNew);
                dirty = true;
            }}

            function setpctchart(workNew) {{
                var workRunningTotal = workNew + workExisting;
                var workUserRunningTotal = workNew + workUserDayTotal;
                var pct = Math.round( workRunningTotal / {5} * 100 );
                if (pct > 100)
                    sTable = ""{2}<td class='noborder' background='/_layouts/epmlive/images/tsstatusred.gif'>{1}</td>{3}"";
                else if (pct == 100)
                    sTable = ""{2}<td class='noborder' background='/_layouts/epmlive/images/tsstatus.gif'>{1}</td>{3}"";
                else if (pct == 0)
                    sTable = ""{2}<td class='noborder'>{1}</td>{3}"";
                else
                    sTable = ""{2}<td class='noborder' background='/_layouts/epmlive/images/tsstatus.gif' width='"" + pct + ""%'>{1}</td><td class='noborder'>{1}</td>{3}"";
                var tdChart = document.getElementById('tdChart');
                tdChart.innerHTML = sTable;
                var tdTotal = document.getElementById('tdTotal');
                tdTotal.innerHTML = workUserRunningTotal;
                if(workUserRunningTotal > max || workUserRunningTotal < min)
                {{
                    tdTotal.className = 'totalHoursException';
                }}
                else
                {{
                    tdTotal.className = '';
                }}
            }}

            function validate(evt) {{
                var theEvent = evt || window.event; 
                var key = theEvent.keyCode || theEvent.which; 
                key = String.fromCharCode( key ); 
                var regex = /[0-9]|\./; 
                if( !regex.test(key) ) {{
                    theEvent.returnValue = false; 
                    if (theEvent.preventDefault) theEvent.preventDefault(); 
                }}
            }}

                   </script>",
                      jsvars, blank, pre, post, tsItem.WorkDoneListItem, workAllocated, tsItem.Min, tsItem.Max, tsItem.WorkDoneUser);

            RegisterScript("TSInput", js);
        }

        private void RegisterBaseScript()
        {
            var message = "You have not saved your changes. Are you sure you want to change the user?";
            ddlUsers.Attributes["onchange"] = string.Format("if (dirty && !confirm('{0}')) {{ resetDDLIndex(); return false; }}; dirty = false;",
                message.Replace("'", "\'"));
            message = "You have not saved your changes. Are you sure you want to change the date?";
            var dtcTextbox = dtcDate.Controls[0] as TextBox;
            //dtcTextbox.Attributes["onchange"] = string.Format("if (dirty && !confirm('{0}')) {{ resetDTCValue(); return false; }}; dirty = false;", 
            //    message.Replace("'", "\'"));
            //dtcDate.OnValueChangeClientScript = string.Format("if (dirty && !confirm('{0}')) {{ resetDTCValue(); return false; }}; dirty = false;", 
            //    message.Replace("'", "\'"));

            var js = string.Format(@"<script type='text/javascript'>
            try
            {{
            var dirty = false;
            var savedDDLID = document.getElementById('{0}').value;
            var savedDate = document.getElementById('{1}').value;
            
            function resetDDLIndex() {{
               document.getElementById('{0}').value = savedDDLID;
            }}

            function resetDTCValue() {{
               document.getElementById('{1}').value = savedDate;
            }}

            function leavePage(e)
            {{
                if(dirty)
                {{
                    if(!e) e = window.event; 
                    //e.cancelBubble = true;
                    e.returnValue = 'You have unsaved changes.'; //This is displayed on the dialog 
                    //if (e.stopPropagation) {{  
                    //    e.stopPropagation();  
                    //    e.preventDefault(); 
                    //    }}
                }}
            }}
            }}catch(e){{}}
            </script> 
            ", ddlUsers.ClientID, dtcTextbox.ClientID);
            RegisterScript("TSBase", js);
        }

        private void RegisterScript(string name, string js)
        {
            var cstype = GetType();
            var cs = Page.ClientScript;
            if (!cs.IsStartupScriptRegistered(cstype, name))
            {
                cs.RegisterStartupScript(cstype, name, js);
            }
        }
    }
}
