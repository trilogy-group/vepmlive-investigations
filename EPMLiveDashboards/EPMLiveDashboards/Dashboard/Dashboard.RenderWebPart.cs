using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Web.UI;

namespace Dashboard
{
    public partial class Dashboard
    {
        // Changing methdos or parameters names are not permitted on EPM
        protected override void RenderWebPart(HtmlTextWriter output)
        {
            switch (activation)
            {
                case 1:
                    output.Write("WebPart feature not activated.");
                    return;
                case 2:
                    output.Write("Too many users activated for this feature.");
                    return;
                case -1:
                    output.Write("Unable to retrieve activation status.");
                    return;
                default:
                    Trace.TraceWarning("Unexpected Value {0}", activation);
                    break;
            }
            try
            {
                EnsureChildControls();

                output.Write(sError);

                output.Write(legendTable());
                output.Write("<br>");

                output.Write(buildFilterTableTop());
                ddl.RenderControl(output);
                output.Write(" Project: ");
                ddlProject.RenderControl(output);
                output.Write(buildFilterTableBottom());

                var result = buildProjectGrid();
                if (result != string.Empty)
                {
                    output.Write("Error: {0}", result);
                }
                else
                {
                    output.Write("<br>");
                    output.Write(buildHeader("Project Summary"));
                    gvPJSummary.RenderControl(output);

                    output.Write("<br>");
                    output.Write("<table border=\"0\" width=\"100%\"><tr><td width=\"50%\" valign=\"top\">");
                    output.Write(buildHeader("Task Summary"));
                    output.Write(buildTaskSummary());

                    output.Write("</td><td width=\"50%\" valign=\"top\">");
                    output.Write(buildHeader("Milestone Summary"));
                    output.Write(buildMSSummary());
                    output.Write("</td></tr>");

                    output.Write("<tr><td width=\"50%\" valign=\"top\">");

                    output.Write(buildHeader("Issue Summary"));
                    output.Write(buildSummaryTable(arrIssues, totalIssues));

                    output.Write("</td><td width=\"50%\" valign=\"top\">");

                    output.Write(buildHeader("Risk Summary"));
                    output.Write(buildSummaryTable(arrRisks, totalRisks));
                    output.Write("</td></tr>");
                    output.Write("</table>");
                }
            }
            catch (Exception ex)
            {
                output.Write("RWP: {0}{1}", ex.Message, ex.StackTrace);
            }

            output.Write(outputData);
        }

        private string buildFilterTableTop()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("<table class=\"ms-menutoolbar\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\">")
                .Append("<tr height=\"23\">")
                .Append("<td class=\"ms-toolbar\" nowrap=\"true\">")
                .AppendFormat("<table border=\"0\" cellpadding=\"3\"><tr><td><b>Filter:</b> {0}: ", strStateField);

            return stringBuilder.ToString();
        }

        private string buildFilterTableBottom()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("</td></tr></table></td>")
                .Append("</tr>")
                .Append("</table>");
            return stringBuilder.ToString();
        }

        private string buildTaskSummary()
        {
            var totalTsk = task_complete + task_current + task_future + task_late;

            if (totalTsk == 0)
            {
                totalTsk = 1;
            }

            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<table border=\"0\" width=\"100%\" cellpadding=\"2\" cellspacing=\"0\">")
                .AppendFormat(
                "<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">In Progress: {0} ( {1}% )</td>",
                task_current,
                task_current * 100 / totalTsk)
                .AppendFormat(
                "<td><table width=\"100%\"><tr><td width=\"{0}%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>",
                task_current * 100 / totalTsk)
                .AppendFormat(
                "<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Late: {0} ( {1}% )</td>",
                task_late,
                task_late * 100 / totalTsk)
                .AppendFormat(
                "<td><table width=\"100%\"><tr><td width=\"{0}%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>",
                task_late * 100 / totalTsk)
                .AppendFormat(
                "<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Not Started: {0} ( {1}% )</td>",
                task_future,
                task_future * 100 / totalTsk)
                .AppendFormat(
                "<td><table width=\"100%\"><tr><td width=\"{0}%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>",
                task_future * 100 / totalTsk)
                .AppendFormat(
                "<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Completed: {0} ( {1}% ) </td>",
                task_complete,
                task_complete * 100 / totalTsk)
                .AppendFormat(
                "<td><table width=\"100%\"><tr><td width=\"{0}%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>",
                task_complete * 100 / totalTsk)
                .Append("</tr></table>");

            return stringBuilder.ToString();
        }

        private string buildSummaryTable(SortedList arr, int totalVals)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<table border=\"0\" width=\"100%\" cellpadding=\"2\" cellspacing=\"0\">");
            if (totalVals == 0)
            {
                totalVals = 1;
            }
            foreach (DictionaryEntry de in arr)
            {
                var val = (int)de.Value;
                stringBuilder.AppendFormat(
                    "<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">{0}: {1} ( {2}% )</td>",
                    de.Key,
                    de.Value,
                    val * 100 / totalVals);
                stringBuilder.AppendFormat(
                    "<td><table width=\"100%\"><tr><td width=\"{0}%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>",
                    val * 100 / totalVals);
            }

            stringBuilder.Append("</tr></table>");

            return stringBuilder.ToString();
        }

        private string buildMSSummary()
        {
            var totalTsk = ms_complete + ms_current + ms_future + ms_late;
            if (totalTsk == 0)
            {
                totalTsk = 1;
            }
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<table border=\"0\" width=\"100%\" cellpadding=\"2\" cellspacing=\"0\">")
                .AppendFormat(
                "<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">In Progress: {0} ( {1}% )</td>",
                ms_current,
                ms_current * 100 / totalTsk)
                .AppendFormat(
                "<td><table width=\"100%\"><tr><td width=\"{0}%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>",
                ms_current * 100 / totalTsk)
                .AppendFormat(
                "<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Late: {0} ( {1}% )</td>",
                ms_late,
                ms_late * 100 / totalTsk)
                .AppendFormat(
                "<td><table width=\"100%\"><tr><td width=\"{0}%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>",
                ms_late * 100 / totalTsk)
                .AppendFormat(
                "<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Not Started: {0} ( {1}% )</td>",
                ms_future,
                ms_future * 100 / totalTsk)
                .AppendFormat(
                "<td><table width=\"100%\"><tr><td width=\"{0}%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>",
                ms_future * 100 / totalTsk)
                .AppendFormat(
                "<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Completed: {0} ( {1}% ) </td>",
                ms_complete,
                ms_complete * 100 / totalTsk)
                .AppendFormat(
                "<td><table width=\"100%\"><tr><td width=\"{0}%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>",
                ms_complete * 100 / totalTsk)
                .Append("</tr></table>");

            return stringBuilder.ToString();
        }

        private string buildHeader(string title)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">")
                .Append("<tr class=\"ms-WPHeader\">")
                .AppendFormat(
                "<td title=\"{0}\" id=\"WebPartTitleWPQ2\" style=\"width:100%;\"><h3 class=\"ms-standardheader ms-WPTitle\"><nobr><span>{0}</span>"
                + "<span id=\"WebPartCaptionWPQ2\"></span></nobr></h3></td>",
                title)
                .Append("</tr>")
                .Append("</table>");

            return stringBuilder.ToString();
        }

        private string legendTable()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(buildHeader("Legend"))
                .Append("<TABLE cellSpacing=0 cellPadding=2 width=\"100%\" border=0>")
                .Append("<TBODY>")
                .Append("<TR>")
                .Append("<TH class=ms-vh width=\"33%\">Schedule Status</TH>")
                .Append("<TH class=ms-vh width=\"33%\">Issue Summary</TH>")
                .Append("<TH class=ms-vh width=\"33%\">Risk Summary</TH></TR>")
                .Append("<TR vAlign=top>")
                .Append(
                "<TD class=ms-vb width=\"33%\"><IMG src=\"/_layouts/images/green.gif\" align=absMiddle> Complete<BR>"
                + "<IMG src=\"/_layouts/images/green.gif\" align=absMiddle> Future Project<BR><IMG src=\"/_layouts/images/green.gif\" align=absMiddle>"
                + " On Schedule<BR><IMG src=\"/_layouts/images/red.gif\" align=absMiddle> Late<BR></TD>")
                .Append(
                "<TD class=ms-vb width=\"33%\"><IMG src=\"/_layouts/images/green.gif\" align=absMiddle> No Active Issues<BR>"
                + "<IMG src=\"/_layouts/images/yellow.gif\" align=absMiddle> At Least 1 Active Issue<BR>"
                + "<IMG src=\"/_layouts/images/red.gif\" align=absMiddle> At Least 1 Active Overdue Issue<BR></TD>")
                .Append(
                "<TD class=ms-vb width=\"33%\"><IMG src=\"/_layouts/images/green.gif\" align=absMiddle> No Active Risks<BR>"
                + "<IMG src=\"/_layouts/images/yellow.gif\" align=absMiddle> At Least 1 Active Risk<BR>"
                + "<IMG src=\"/_layouts/images/red.gif\" align=absMiddle> At Least 1 Active Overdue Risk<BR></TD></TR></TBODY></TABLE>");

            return stringBuilder.ToString();
        }
    }
}