using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using System.Text;
using System.Xml;

namespace EPMLiveWebParts
{
    public partial class checkresgantt : System.Web.UI.Page
    {
        protected string strTemplate;
        protected string strUrl = SPContext.Current.Web.Url;
        protected string strParams;
        private SPList list;
        private SPView view;
        protected string strFunctions;
        protected string dfmt = System.Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
        protected string strWorkplanner;
        protected string strItemId;
        protected string strCallBack;

        protected void Page_Load(object sender, EventArgs e)
        {
            list = SPContext.Current.Web.Lists["Resource Center"];
            view = list.DefaultView;
            loadTemplate();
            strParams = getParam();
            strFunctions = Properties.Resources.txtFileFunctions.Replace("#gridid#","").Replace("initmb();","");
            strCallBack = Request["callback"];
        }

        private string getParam()
        {
            string data = "";
            SPWeb web = SPContext.Current.Web;
            {

                EPMLiveCore.GridGanttSettings gSettings = new EPMLiveCore.GridGanttSettings(list);

                string strRollupLists = "";
                string resources = "";

                strRollupLists = gSettings.RollupLists;

                if (Request["useResPool"] == "true")
                {
                    string[] strResList = Request["resources"].Split(';');

                    Guid lockWeb = EPMLiveCore.CoreFunctions.getLockedWeb(list.ParentWeb);

                    string resURL = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL");

                    if (resURL.ToLower() == web.ServerRelativeUrl.ToLower())
                    {
                        try
                        {
                            SPList resList = web.Lists[EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourcePool")];
                            foreach (string strRes in strResList)
                            {
                                try
                                {
                                    SPListItem li = resList.GetItemById(int.Parse(strRes));
                                    SPFieldUserValue uv = new SPFieldUserValue(web, li["SharePointAccount"].ToString());
                                    SPUser user = web.SiteUsers.GetByID(uv.LookupId);
                                    resources += ";#" + user.Name;
                                }
                                catch { }
                            }
                        }
                        catch { }
                    }
                }
                else
                {
                    string[] strResList = Request["resources"].Split(';');
                    foreach (string strRes in strResList)
                    {
                        try
                        {
                            SPUser user = web.SiteUsers[strRes.Trim()];
                            resources += ";#" + user.Name;
                        }
                        catch { }
                    }
                }
                if(resources.Length > 2)
                    resources = resources.Substring(2);

                data = "Lists/Resource Center/DispForm.aspx\n" + view.Title + "\nStartDate\nDueDate\nPercentComplete\n\n\nTrue\n\n\n" + strRollupLists + "\n" + Page.Request["FilterField1"] + "\n" + Page.Request["FilterValue1"] + "\n\n" + resources;

                strWorkplanner = Request["workplanner"];
                strItemId = Request["itemid"];
            }
            
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(data);

            return Convert.ToBase64String(toEncodeAsBytes);
            
        }

        private void loadTemplate()
        {
            StringBuilder sb = new StringBuilder(Properties.Resources.TextFile1.Replace("\r\n", "\\r\\n").Replace("\"", "`").Replace("#nonworkingdays#", "65"));

            StringBuilder images = new StringBuilder();

            images.Append("HTMLPicture(`red.gif`) = `gBHJJGHA5MIQAEIcx0ACSFQfehzOr3TSbVBVJbTORvcxkMi5LhVXBSJb+fj8fCeUDRLJWeC/Xr0NJsaJMJTiRCEeyhUTTJZJdSORz0NxwayBPz4UakeRoNa3IxAdxxONTOT7d7vcpcLq2Hg1dSVSr0aDPbhvNbxYbBb5zN7zPR8fLlcj8ej0eRtNztWaxapqNDsNBoebMZT1aLQejOZjhQR+d6FQriPp6bRWKTwMZkeSNRzNMJbebHYzvW61ahoMz2TadbhgLjzOx4eKcTbgPJ2ezabLeOhweRfMTsVCme7cbbgOhxcB2ObcLZXbxyNr5czlahkMT1Uajbx1OLvLxgeJ0OrpUahejPZr3UqmauVeCKRTgNxrcByNz0T6feZHEeb4/Dyd6hHGQxBm8NY0GmMQwHmMozm4MownoSBJKwdxzEiRxvDiNpzEmR53l0XBvjgNp5keSBvvAexrmsb8PnqSRKRONhvLcfh5nmkx9noRhHNeLp1E+Tp5mWZJ2joOhzk2S5ujWM5bDkNRZDUMRPiKHR/y7LwATBMMxTHMkyzGEJ8gIAMwIYFkxIQhAAAOZZADoQRBDgOQADkOBBkUQQ4gMJgOAeCICAOOJFjoAYJhwKAKASAQshYGgBkUOIJikNwHCmAQYByLYfisSpBAMIoHBEHQViaMwPi0Lo2gsQgYiWIwSjQDoqBmOYlCAJAFESOQOAoGoPCSDIhjOBYvguAICjkhgHk6MA3h8OYRhaDAAgkCoADoOQIgEKIuC8BAxAyNgyhOBgNG4OACDIHYFjmKBGCyQYQEKSYLgaCRohySATCYA4KhAGBUHSEJxmSSIGkGcRMGAERSCUGwJCCNhcEAAAlmgAARBCNxQDGOBCgOAgokWcQsCgKBQEEQwDA2JQtBUOgkFCUpPh+Ac1h2gIA=`\\r\\n");
            images.Append("HTMLPicture(`green.gif`) = `gBHJJGHA5MIQAEIcxsAB6ZCPJy2NZ9ZKSFBhD53YyMN7EQxKWpoObFRJHWZlNjBQSAZSUKaAJZCQxFGJ/G5kVBvfD7fBFVJdNi4PhsYSDLChMZ5YyNMKlNRxXSCHaWJY6S5LJKJJbyfDzKqdLxNWpqKaBJj1fL2TbEUDleDmbzsb6sZ6wKCZLKvaCyNyUM5fTRhKCWKxSUJfLq8O5kXx8IiaKZeRZYKS3NxeUBkcDtcTzfD0ZziaOYMadYqhN64PzfdjgKSyNTJcDMKS1NpSTZaKydL6vZ6yL6hlC3PhUThdQi2RKaYaeMaoNhYWpwMq4PA5QQ+LagMRiTZkbLpbZiURoYjcY5cT5iJiqMa5ay8JqzNJ4V59LaRLLK2ZrYBBFqahcrWT44FWOw3luPosE4MA1lQOJDlwRg0FsPApFALztjIdJ5HUSxgk3EBNDaVY6iaTwtjeYZCnsfR7DOUrblkNYyFuO5IF8Sw5FaPI4EsNQ0kgMQhjoHR/yRJIASXJkmydJ8oSjKUpyWEJ8gIAMloYFkmoQhAAAOX5ADYQRBDQNQBjUNBBkUQQ0gyCoLAoCIJgYNJFjYBYHAUAQAAIA4CgkLQOkUNJMk2TpPiGMYjBYQYMk0ThPASJQfiSG4nkICpTFiFwvC4NYjhMEo2DUCwABoHowgSGQPg8B4pDOE41DYAYKCqKYgB4MosA0GAui2GwOAGYYIiCEIHh2KgYjEMwfBwAIIGkNAJiyGYajWF4NBIDYWgCAwLkSNgMCIIJxAIZQNAgL5kHoIZoDAKANAoFRWC4MIRBEY4hAYSoDBaABJiERBHBEEYGBAYBYGAKQNBEFZLBoQI4FCIIjCWNgFA6AQEFmcxRCAAAdoCA`\\r\\n");
            images.Append("HTMLPicture(`checkmark.gif`) = `gBHJJGHA5MIPAAMADmIwAcbpcqKYxAdDrdKUZI9Si9JRkVhkRizRzJarNZbTZjveLwSy2SK7Zi+KK0JChWqfYbVY50WJXQauSCDYhBNq+IiSWUSazJVzCV73fL4bLhba2agzXTKXbPcLXQC2Ja1Zq5OK3IiUY5VWbDWrteDtbTpWS8baQV7FV6UXZLVbKWysaZwcjqcyMXJ3Ki5I5oXpFYLSYaUWx8TC5QyIYpAYrcPCmZ5FVDCSJsWZTX7PYDodjpYbTVRgVxLSbIHqLWSEOa0Kj83iNY4+fD6fKsYo5Vi6VC4aalVbBVKxYqOcTnciMWKOUy1TiMXo/f/fAHh8Xj8nl83n9Hp9Xr9nt93v+HxEL5AgB8MNFnjhEKAAHMRACMQRBkGHgRgaHwgAWQhGAUEQQh+FYLEYQYKg8EwUA0ShBgAB4AhkA5GA+BBBiGCQGBKRgABqIIBCMC4bBSCBGBAGIXhgFgdAMFQCgSRgThaIoXAigoOgoTYjA4DYBh2G4JmSQQHAIDASCEaJBBmHoiGwQYMhoZJAgAHaAg==`\\r\\n");
            images.Append("HTMLPicture(`yellow.gif`) = `gBHJJGHA5MIQAEIcxbADzZqKcCPHDxYJvbJzA7yYp4erVTj4cC1eC+Mz5c7FezZUr0aKTdqyJrvXReeTJQL6dbMfDkXr3bqtdy2KrtV5FciZITqVJDd7FR7gRAadi4OTsWBScSQFruYKHcqiKjmTQufToZboUZEdSsLDuWpUdayMjlTAqdisITtWxZejWU7qU46ejXVTvXpody5McyMjxYBtu5FebMST0aCSeLCO7qUo1zkTYR1dapH7uWhTdivJk1QV9T7tWpZebOSLrVRBdq0Kz8eThfz8fOAHL+fLzdy4ME4aMgXOwLDsVZGdSmG+2H71bCldqxJbwXhmerTTj0aSZf7+frtWZT3JReTIQL3cS6dKjGLww/THEsTr8eZxpYShukIExyE6KKvi0f8FwYAEHQfCEIwlCcKQrC0LwxDMNQeEJ8gIAMHIYFkIIQhAAAOYRAC2QRBCyK4BiuLJBkUQQsA2DQShuFoLgmLBFi2AIKgcI4ZhSGoZAKEIAkULBMgQFAhC0HgWAUAAPkqQQNgcBAHh0H4tB6GIAAaAgMkIDRZgMHYOi0KojF2AQPESK4TgeAwICeF4tCUIYCAEA4MCuLYBigZwEisIgmCAKRrAYEABi2K4qAgBIChcGAcCKFYDgYCIKGyLILnYBQbCaKITCcegLDgJBaDKIQAisEhLDQBIZBKYQBASCwDDCBJQhWRJFAcHIjB4Ch4iUKBAAeao0HwDBAiIQQECiRZYDIeBAACAgCgcCwdC0FQ6EQUBSk2G4BxAHaAg`\\r\\n");

            sb = sb.Replace("#Images#", images.ToString());

            SPViewFieldCollection vfc = view.ViewFields;
            StringBuilder columns = new StringBuilder();
            foreach (string field in vfc)
            {
                SPField spfield = list.Fields.GetFieldByInternalName(field);
                switch (spfield.Type)
                {
                    case SPFieldType.Number:
                    case SPFieldType.Currency:
                    case SPFieldType.DateTime:
                    case SPFieldType.Counter:
                        columns.Append("Columns(`" + spfield.Title + "`).Alignment = 2\\r\\n");
                        break;
                    case SPFieldType.Calculated:
                        if (spfield.Description == "Indicator")
                            columns.Append("Columns(`" + spfield.Title + "`).Alignment = 1\\r\\n");
                        else
                            columns.Append("Columns(`" + spfield.Title + "`).Alignment = 2\\r\\n");
                        break;
                    default:
                        columns.Append("Columns(`" + spfield.Title + "`).Alignment = 0\\r\\n");
                        break;
                }
                if (spfield.InternalName == "StartDate")
                    columns.Append("Columns(`" + spfield.Title + "`).Def(18) = 1\\r\\n");
                if (spfield.InternalName == "DueDate")
                    columns.Append("Columns(`" + spfield.Title + "`).Def(18) = 2\\r\\n");
            }

            sb = sb.Replace("#Columns#", columns.ToString());

            strTemplate = sb.ToString();
        }
    }
}