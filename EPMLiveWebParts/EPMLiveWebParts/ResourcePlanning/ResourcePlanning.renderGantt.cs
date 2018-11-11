using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using EPMLiveCore.Helpers;
using EPMLiveWebParts.Properties;
using Microsoft.SharePoint;

namespace EPMLiveWebParts
{
    public partial class ResourcePlanning
    {
        private void renderGantt(HtmlTextWriter output)
        {
            Guard.ArgumentIsNotNull(output, nameof(output));

            var list = SPContext.Current.List;
            var view = SPContext.Current.ViewContext.View;
            toolbar.RenderControl(output);
            double nonWork = 0;

            int work = resWeb.Site.RootWeb.RegionalSettings.WorkDays;

            for (byte x = 0; x < 7; x++)
            {
                if (((work >> x) & 0x01) != 0x01)
                {
                    nonWork += Math.Pow(2, 6 - x);
                }
            }

            var stringBuilder = new StringBuilder(
                Resources.TextFile1.Replace("\r\n", "\\r\\n").Replace("\"", "`").Replace("#nonworkingdays#", nonWork.ToString()));

            var heightBuilder = new StringBuilder();

            foreach (var value in Height)
            {
                var temp = 0;

                if (int.TryParse(value.ToString(), out temp))
                {
                    heightBuilder.Append(value);
                }
            }

            var height = heightBuilder.ToString();
            height = string.IsNullOrWhiteSpace(height)
                ? "450"
                : (int.Parse(height) - 30).ToString();

            var images = new StringBuilder().Append(
                    "HTMLPicture(`red.gif`) = `gBHJJGHA5MIQAEIcx0ACSFQfehzOr3TSbVBVJbTORvcxkMi5LhVXBSJb+fj8fCeUDRLJWeC/Xr0NJsaJMJTiRCEeyhUTTJZJdSORz0NxwayBPz4UakeRoNa3IxAdxxONTOT7d7vcpcLq2Hg1dSVSr0aDPbhvNbxYbBb5zN7zPR8fLlcj8ej0eRtNztWaxapqNDsNBoebMZT1aLQejOZjhQR+d6FQriPp6bRWKTwMZkeSNRzNMJbebHYzvW61ahoMz2TadbhgLjzOx4eKcTbgPJ2ezabLeOhweRfMTsVCme7cbbgOhxcB2ObcLZXbxyNr5czlahkMT1Uajbx1OLvLxgeJ0OrpUahejPZr3UqmauVeCKRTgNxrcByNz0T6feZHEeb4/Dyd6hHGQxBm8NY0GmMQwHmMozm4MownoSBJKwdxzEiRxvDiNpzEmR53l0XBvjgNp5keSBvvAexrmsb8PnqSRKRONhvLcfh5nmkx9noRhHNeLp1E+Tp5mWZJ2joOhzk2S5ujWM5bDkNRZDUMRPiKHR/y7LwATBMMxTHMkyzGEJ8gIAMwIYFkxIQhAAAOZZADoQRBDgOQADkOBBkUQQ4gMJgOAeCICAOOJFjoAYJhwKAKASAQshYGgBkUOIJikNwHCmAQYByLYfisSpBAMIoHBEHQViaMwPi0Lo2gsQgYiWIwSjQDoqBmOYlCAJAFESOQOAoGoPCSDIhjOBYvguAICjkhgHk6MA3h8OYRhaDAAgkCoADoOQIgEKIuC8BAxAyNgyhOBgNG4OACDIHYFjmKBGCyQYQEKSYLgaCRohySATCYA4KhAGBUHSEJxmSSIGkGcRMGAERSCUGwJCCNhcEAAAlmgAARBCNxQDGOBCgOAgokWcQsCgKBQEEQwDA2JQtBUOgkFCUpPh+Ac1h2gIA=`\\r\\n")
               .Append(
                    "HTMLPicture(`green.gif`) = `gBHJJGHA5MIQAEIcxsAB6ZCPJy2NZ9ZKSFBhD53YyMN7EQxKWpoObFRJHWZlNjBQSAZSUKaAJZCQxFGJ/G5kVBvfD7fBFVJdNi4PhsYSDLChMZ5YyNMKlNRxXSCHaWJY6S5LJKJJbyfDzKqdLxNWpqKaBJj1fL2TbEUDleDmbzsb6sZ6wKCZLKvaCyNyUM5fTRhKCWKxSUJfLq8O5kXx8IiaKZeRZYKS3NxeUBkcDtcTzfD0ZziaOYMadYqhN64PzfdjgKSyNTJcDMKS1NpSTZaKydL6vZ6yL6hlC3PhUThdQi2RKaYaeMaoNhYWpwMq4PA5QQ+LagMRiTZkbLpbZiURoYjcY5cT5iJiqMa5ay8JqzNJ4V59LaRLLK2ZrYBBFqahcrWT44FWOw3luPosE4MA1lQOJDlwRg0FsPApFALztjIdJ5HUSxgk3EBNDaVY6iaTwtjeYZCnsfR7DOUrblkNYyFuO5IF8Sw5FaPI4EsNQ0kgMQhjoHR/yRJIASXJkmydJ8oSjKUpyWEJ8gIAMloYFkmoQhAAAOX5ADYQRBDQNQBjUNBBkUQQ0gyCoLAoCIJgYNJFjYBYHAUAQAAIA4CgkLQOkUNJMk2TpPiGMYjBYQYMk0ThPASJQfiSG4nkICpTFiFwvC4NYjhMEo2DUCwABoHowgSGQPg8B4pDOE41DYAYKCqKYgB4MosA0GAui2GwOAGYYIiCEIHh2KgYjEMwfBwAIIGkNAJiyGYajWF4NBIDYWgCAwLkSNgMCIIJxAIZQNAgL5kHoIZoDAKANAoFRWC4MIRBEY4hAYSoDBaABJiERBHBEEYGBAYBYGAKQNBEFZLBoQI4FCIIjCWNgFA6AQEFmcxRCAAAdoCA`\\r\\n")
               .Append(
                    "HTMLPicture(`checkmark.gif`) = `gBHJJGHA5MIPAAMADmIwAcbpcqKYxAdDrdKUZI9Si9JRkVhkRizRzJarNZbTZjveLwSy2SK7Zi+KK0JChWqfYbVY50WJXQauSCDYhBNq+IiSWUSazJVzCV73fL4bLhba2agzXTKXbPcLXQC2Ja1Zq5OK3IiUY5VWbDWrteDtbTpWS8baQV7FV6UXZLVbKWysaZwcjqcyMXJ3Ki5I5oXpFYLSYaUWx8TC5QyIYpAYrcPCmZ5FVDCSJsWZTX7PYDodjpYbTVRgVxLSbIHqLWSEOa0Kj83iNY4+fD6fKsYo5Vi6VC4aalVbBVKxYqOcTnciMWKOUy1TiMXo/f/fAHh8Xj8nl83n9Hp9Xr9nt93v+HxEL5AgB8MNFnjhEKAAHMRACMQRBkGHgRgaHwgAWQhGAUEQQh+FYLEYQYKg8EwUA0ShBgAB4AhkA5GA+BBBiGCQGBKRgABqIIBCMC4bBSCBGBAGIXhgFgdAMFQCgSRgThaIoXAigoOgoTYjA4DYBh2G4JmSQQHAIDASCEaJBBmHoiGwQYMhoZJAgAHaAg==`\\r\\n")
               .Append(
                    "HTMLPicture(`yellow.gif`) = `gBHJJGHA5MIQAEIcxbADzZqKcCPHDxYJvbJzA7yYp4erVTj4cC1eC+Mz5c7FezZUr0aKTdqyJrvXReeTJQL6dbMfDkXr3bqtdy2KrtV5FciZITqVJDd7FR7gRAadi4OTsWBScSQFruYKHcqiKjmTQufToZboUZEdSsLDuWpUdayMjlTAqdisITtWxZejWU7qU46ejXVTvXpody5McyMjxYBtu5FebMST0aCSeLCO7qUo1zkTYR1dapH7uWhTdivJk1QV9T7tWpZebOSLrVRBdq0Kz8eThfz8fOAHL+fLzdy4ME4aMgXOwLDsVZGdSmG+2H71bCldqxJbwXhmerTTj0aSZf7+frtWZT3JReTIQL3cS6dKjGLww/THEsTr8eZxpYShukIExyE6KKvi0f8FwYAEHQfCEIwlCcKQrC0LwxDMNQeEJ8gIAMHIYFkIIQhAAAOYRAC2QRBCyK4BiuLJBkUQQsA2DQShuFoLgmLBFi2AIKgcI4ZhSGoZAKEIAkULBMgQFAhC0HgWAUAAPkqQQNgcBAHh0H4tB6GIAAaAgMkIDRZgMHYOi0KojF2AQPESK4TgeAwICeF4tCUIYCAEA4MCuLYBigZwEisIgmCAKRrAYEABi2K4qAgBIChcGAcCKFYDgYCIKGyLILnYBQbCaKITCcegLDgJBaDKIQAisEhLDQBIZBKYQBASCwDDCBJQhWRJFAcHIjB4Ch4iUKBAAeao0HwDBAiIQQECiRZYDIeBAACAgCgcCwdC0FQ6EQUBSk2G4BxAHaAg`\\r\\n");

            stringBuilder = stringBuilder.Replace("#Images#", images.ToString());

            var columns = ProcessSpFieldInternalName(view, list);
            HtmlTextWriterOutput(output, stringBuilder, columns, height);
        }

        private static StringBuilder ProcessSpFieldInternalName(SPView view, SPList list)
        {
            Guard.ArgumentIsNotNull(list, nameof(list));
            Guard.ArgumentIsNotNull(view, nameof(view));

            var columns = new StringBuilder();
            var viewFieldCollection = view.ViewFields;

            foreach (string field in viewFieldCollection)
            {
                var spField = list.Fields.GetFieldByInternalName(field);

                if (spField.Type == SPFieldType.Number ||
                    spField.Type == SPFieldType.Currency ||
                    spField.Type == SPFieldType.DateTime ||
                    spField.Type == SPFieldType.Counter)
                {
                    columns.Append($"Columns(`{spField.Title}`).Alignment = 2\\r\\n");
                }
                else if (spField.Type == SPFieldType.Calculated)
                {
                    columns.Append(
                        spField.Description == "Indicator"
                            ? $"Columns(`{spField.Title}`).Alignment = 1\\r\\n"
                            : $"Columns(`{spField.Title}`).Alignment = 2\\r\\n");
                }
                else
                {
                    columns.Append($"Columns(`{spField.Title}`).Alignment = 0\\r\\n");
                }

                if (spField.InternalName == "StartDate")
                {
                    columns.Append($"Columns(`{spField.Title}`).Def(18) = 1\\r\\n");
                }

                if (spField.InternalName == "DueDate")
                {
                    columns.Append($"Columns(`{spField.Title}`).Def(18) = 2\\r\\n");
                }
            }

            return columns;
        }

        private void HtmlTextWriterOutput(TextWriter output, StringBuilder stringBuilder, StringBuilder columns, string height)
        {
            Guard.ArgumentIsNotNull(height, nameof(height));
            Guard.ArgumentIsNotNull(columns, nameof(columns));
            Guard.ArgumentIsNotNull(stringBuilder, nameof(stringBuilder));
            Guard.ArgumentIsNotNull(output, nameof(output));

            stringBuilder = stringBuilder.Replace("#Columns#", columns.ToString());
            var outputBuilder =
                new StringBuilder(
                        "<OBJECT CLASSID=\"clsid:5220cb21-c88d-11cf-b347-00aa00a28331\" VIEWASTEXT><PARAM NAME=\"LPKPath\" VALUE=\"/_layouts/epmlive/epmlivegantt.lpk\"></OBJECT>\r\n\r\n")
                   .Append("<script src=\"/_layouts/epmlive/dhtml/xajax/dhtmlxcommon.js\"></script>")
                   .Append($"<script src=\"/_layouts/epmlive/resPlanning.js?guid={Guid.NewGuid()}\"></script>")
                   .Append(
                        "<script type=\"text/javascript\" src=\"/_layouts/epmlive/modal/modal.js\"></script><link rel=\"stylesheet\" href=\"/_layouts/epmlive/modal/modalmain.css\" type=\"text/css\" /> ")
                   .Append(
                        $"<div id=\"noitems{ZoneIndex}{ZoneID}\" style=\"display:none;\" class\"ms-vb\">There are no items to show in this view.</div>")
                   .Append(
                        $"<OBJECT id=G2antt1{ZoneIndex}{ZoneID} style=\'z-index:-1\' classid=clsid:CD481F4D-2D25-4759-803F-752C568F53B7 CODEBASE=\"/_layouts/epmlive/EPMLiveGantt.CAB#version=4,1,1,0\" height={height} width=100%><b>Gantt Control Not Installed.</b></OBJECT>\r\n\r\n")
                   .Append(
                        $"<OBJECT id=Print1{ZoneIndex}{ZoneID} classid=clsid:4DEB0D2B-6EBD-4A22-9835-48AB9CDC8088 CODEBASE=\"/_layouts/epmlive/ExPrintCab.CAB#version=5,1,0,2\"></Object>\r\n")
                   .Append($"<div  width=\"100%\" id=\"loadinggantt{ZoneIndex}{ZoneID}\" align=\"center\">")
                   .Append("<img src=\"_layouts/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/> Loading Items...")
                   .Append("</div>")
                   .Append(Resources.txtFileFunctions.Replace("#gridid#", $"{ZoneIndex}{ZoneID}"))
                   .Append("<SCRIPT LANGUAGE=\"javascript\">\r\n")
                   .Append("var GcurItem;")
                   .Append("document.body.onload = function()\r\n")
                   .Append("{")
                   .Append("if (typeof(_spBodyOnLoadWrapper) != 'undefined') _spBodyOnLoadWrapper()\r\n")
                   .Append($"G2antt1{ZoneIndex}{ZoneID} = document.getElementById(\"G2antt1{ZoneIndex}{ZoneID}\")\r\n")
                   .Append($"G2antt1{ZoneIndex}{ZoneID}.BeginUpdate()\r\n")
                   .Append($"G2antt1{ZoneIndex}{ZoneID}.Appearance = 0;\r\n")
                   .Append($"G2antt1{ZoneIndex}{ZoneID}.MarkSearchColumn = 0;\r\n")
                   .Append(
                        $"G2antt1{ZoneIndex}{ZoneID}.Chart.PaneWidth(0) = document.getElementById(\"G2antt1{ZoneIndex}{ZoneID}\").clientWidth / 3;\r\n")
                   .Append($"G2antt1{ZoneIndex}{ZoneID}.DrawGridLines = 1;\r\n")
                   .Append($"G2antt1{ZoneIndex}{ZoneID}.Chart.DrawGridLines = 1;\r\n")
                   .Append($"G2antt1{ZoneIndex}{ZoneID}.ColumnAutoResize = false;\r\n")
                   .Append($"G2antt1{ZoneIndex}{ZoneID}.Chart.OverviewVisible = 1;\r\n")
                   .Append($"G2antt1{ZoneIndex}{ZoneID}.Chart.OverviewHeight = 24;\r\n")
                   .Append($"G2antt1{ZoneIndex}{ZoneID}.Chart.HistogramVisible = 1;\r\n")
                   .Append($"G2antt1{ZoneIndex}{ZoneID}.Chart.HistogramHeight = {int.Parse(height) / 3.5};\r\n")
                   .Append($"G2antt1{ZoneIndex}{ZoneID}.Chart.HistogramView = 4;\r\n")
                   .Append($"document.getElementById(\"G2antt1{ZoneIndex}{ZoneID}\").style.display=\"none\";")
                   .Append($"G2antt1{ZoneIndex}{ZoneID}.EndUpdate()")
                   .Append("setTimeout(\"loadGanttXml()\",1)")
                   .Append("}\r\n")
                   .Append("function loadGanttXml(){")
                   .Append($"var wp = document.getElementById(\'MSOZoneCell_WebPart{Qualifier}\')")
                   .Append(
                        $"G2antt1{ZoneIndex}{ZoneID}.LoadXML(\"{SPContext.Current.Web.Url}/_layouts/epmlive/getresourceplan.aspx?data={getGanttParams()}&Source={HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString())}\")\r\n")
                   .Append($"G2antt1{ZoneIndex}{ZoneID}.Template = \"{stringBuilder}\";\r\n")
                   .Append($"G2antt1{ZoneIndex}{ZoneID}.Columns(0).Def(0) = 1;")
                   .Append($"G2antt1{ZoneIndex}{ZoneID}.Columns(0).PartialCheck = 1;")
                   .Append($"document.getElementById(\"G2antt1{ZoneIndex}{ZoneID}\").style.display=\"\";")
                   .Append($"document.getElementById(\"loadinggantt{ZoneIndex}{ZoneID}\").style.display=\"none\";")
                   .Append("doSummaryTasks()")
                   .Append("}")
                   .AppendLine("function clickTab(){")
                   .AppendLine($"var wp = document.getElementById(\'MSOZoneCell_WebPart{Qualifier}\')")
                   .AppendLine("fireEvent(wp, 'mouseup')")
                   .AppendLine("setTimeout(\"clickbrowse()\",1000)")
                   .AppendLine("}")
                   .AppendLine("function clickbrowse(){")
                   .AppendLine("var wp2 = document.getElementById('Ribbon.ResourcePlanner-title').firstChild;")
                   .AppendLine("fireEvent(wp2, 'click')")
                   .AppendLine("}")
                   .Append("SP.SOD.executeOrDelayUntilScriptLoaded(clickTab, \"GridViewContextualTabPageComponent.js\")")
                   .Append("</SCRIPT>")
                   .Append($"<SCRIPT FOR=G2antt1{ZoneIndex}{ZoneID} EVENT=AnchorClick(Anchor,Options) LANGUAGE=JScript>")
                   .Append("document.location.href=Anchor")
                   .Append("</SCRIPT>\r\n")
                   .Append($"<SCRIPT FOR=G2antt1{ZoneIndex}{ZoneID} EVENT=Click() LANGUAGE=JScript>")
                   .Append("var c;var h;")
                   .Append($"GcurItem = G2antt1{ZoneIndex}{ZoneID}.ItemFromPoint(-1, -1, c, h)")
                   .Append("RefreshCommandUI()")
                   .Append("</SCRIPT>\r\n")
                   .Append("<script type=\"text/vbscript\">\r\n")
                   .Append($"function printGantt{ZoneIndex}{ZoneID}()\r\n")
                   .Append(
                        $"    document.getElementById(\"Print1{ZoneIndex}{ZoneID}\").PrintExt = document.getElementById(\"G2antt1{ZoneIndex}{ZoneID}\").Object\r\n")
                   .Append($"    document.getElementById(\"Print1{ZoneIndex}{ZoneID}\").Preview\r\n")
                   .Append("end function\r\n</script>")
                   .Append("<div id=\"boxDialog\" class=\"dialog\">")
                   .Append("<table width=\"100%\">")
                   .Append("    <tr>")
                   .Append("      <td align=\"center\" class=\"ms-sectionheader\">")
                   .Append("<img src=\"/_layouts/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/><br />")
                   .Append("<H3 class=\"ms-standardheader\" id=\"txtDialog\">Saving Resource Plan...</h3>")
                   .Append("</td>")
                   .Append("</tr>")
                   .Append("</table>")
                   .Append("</div>")
                   .Append("<div id=\"boxOpenDialog\" class=\"dialog\">")
                   .Append("<table width=\"300\" height=\"250\">")
                   .Append("    <tr>")
                   .Append("      <td align=\"center\" class=\"ms-sectionheader\">")
                   .Append(
                        "<select id=\"slctOpen\" name=\"slctOpen\" size=\"15\" style=\"width: 280px;\" onChange=\"planToOpen = this.value;\"></select>")
                   .Append("</td></tr><tr><td align=\"right\">")
                   .Append($"<input name=\"Button1\" type=\"button\" value=\"Open Plan\" onClick=\"loadPlan(\'{SPContext.Current.Web.Url}\')\"> ")
                   .Append("<input name=\"Button2\" type=\"button\" value=\"Cancel\" onClick=\"hm('boxOpenDialog')\"> ")
                   .Append("</td>")
                   .Append("</tr>")
                   .Append("</table>")
                   .Append("</div>")
                   .Append("<script>")
                   .Append("initmb()")
                   .Append("</script>");

            output.Write(outputBuilder.ToString());
        }
    }
}