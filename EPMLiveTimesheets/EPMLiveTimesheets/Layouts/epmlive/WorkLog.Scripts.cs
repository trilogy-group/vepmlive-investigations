using System.Web.UI.WebControls;

namespace TimeSheets.Layouts.epmlive
{
    using System.Text;

    public partial class WorkLog
    {
        private void RegisterDynamicScripts(TSItem tsItem)
        {
            var workAllocated = tsItem.WorkAllocated.ToString();

            var javascriptVariables = new StringBuilder();
            var i = 0;
            foreach (var hourId in txtHours)
            {
                javascriptVariables.Append($"tb[{i++}] = document.getElementById('{hourId.Value.ClientID}');");
            }

            var blankAnchor = "<img src='_layouts/epmlive/blank.gif' height='1' width='1'>";
            var tableHead = "<table border='1' width='240' cellpadding='0' cellspacing='0' class='statustable'><tr class='noborder'>";
            var yableBody = $@"</tr></table></td><td id='tdTotal'>"" + workRunningTotal + ""/{workAllocated} hours";
            var scriptFormat = @"<script type=text/javascript>

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

                   </script>";

            var script = string.Format(
                scriptFormat,
                javascriptVariables,
                blankAnchor, 
                tableHead, 
                yableBody, 
                tsItem.WorkDoneListItem, 
                workAllocated, 
                tsItem.Min, 
                tsItem.Max, 
                tsItem.WorkDoneUser);

            RegisterScript("TSInput", script);
        }

        private void RegisterBaseScript()
        {
            const string message = "You have not saved your changes. Are you sure you want to change the user?";
            ddlUsers.Attributes["onchange"] =
                $"if (dirty && !confirm('{message.Replace("'", "\'")}')) {{ resetDDLIndex(); return false; }}; dirty = false;";
            var dtcTextBox = dtcDate.Controls[0] as TextBox;
            var scriptFormat = @"<script type='text/javascript'>
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
            ";
            var script = string.Format(scriptFormat, ddlUsers.ClientID, dtcTextBox.ClientID);
            RegisterScript("TSBase", script);
        }

        private void RegisterScript(string name, string script)
        {
            var workLogType = GetType();
            var clientScript = Page.ClientScript;
            if (!clientScript.IsStartupScriptRegistered(workLogType, name))
            {
                clientScript.RegisterStartupScript(workLogType, name, script);
            }
        }
    }
}
