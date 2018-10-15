using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using EPMLiveCore;
using EPMLiveCore.API.Integration;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SystemDiagnostics = System.Diagnostics;

namespace EPMLiveIntegrationService
{
    public partial class GoToControl : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var control = Request["Control"];
            var id = Request["ID"];
            var integrationId = Request["IntegrationId"];
            var url = string.Empty;

            if (string.IsNullOrWhiteSpace(control))
            {
                lblMessage.Text = "Control Not Specified";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(integrationId))
                {
                    lblMessage.Text = "Integration Id Not Specified";
                }
                else
                {
                    try
                    {
                        var farm = SPFarm.Local;
                        var service = farm.Services.GetValue<SPWebService>(string.Empty);

                        foreach (var webapp in service.WebApplications)
                        {
                            if (webapp.Name == ConfigurationManager.AppSettings["WebApplication"])
                            {
                                using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(webapp.Id)))
                                {
                                    sqlConnection.Open();
                                    Guid listId;
                                    Guid siteId;
                                    Guid webId;
                                    Guid internalListUId;
                                    PopulateIds(sqlConnection, integrationId, out listId, out siteId, out webId, out internalListUId);
                                    if (webId != Guid.Empty)
                                    {
                                        url = control.StartsWith("epmlive-", StringComparison.OrdinalIgnoreCase)
                                            ? GetUrlFromEpmSite(siteId, webId, id, integrationId, control)
                                            : GetUrlFromSourceToDestinationColumns(sqlConnection, integrationId, control, siteId, webId, id, listId, internalListUId);
                                    }
                                    else
                                    {
                                        lblMessage.Text = "Invalid Integration";
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        SystemDiagnostics.Trace.TraceError("Exception suppressed {0}", ex);
                        lblMessage.Text = "Configuration Error: " + ex.Message;
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(url))
            {
                Response.Redirect(url);
            }
        }

        private static void PopulateIds(
            SqlConnection sqlConnection,
            string integrationId,
            out Guid listId,
            out Guid siteId,
            out Guid webId,
            out Guid internalListUId)
        {
            using (var sqlCommand = new SqlCommand("SELECT INT_LIST_ID,SITE_ID, WEB_ID, LIST_ID from INT_LISTS where INT_LIST_ID=@intlistid", sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@intlistid", integrationId);

                listId = Guid.Empty;
                siteId = Guid.Empty;
                webId = Guid.Empty;
                internalListUId = Guid.Empty;

                using (var dataReader = sqlCommand.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        internalListUId = dataReader.GetGuid(0);
                        siteId = dataReader.GetGuid(1);
                        webId = dataReader.GetGuid(2);
                        listId = dataReader.GetGuid(3);
                    }
                }
            }
        }

        private static string GetUrlFromEpmSite(
            Guid siteId,
            Guid webId,
            string id,
            string integrationId,
            string control)
        {
            var url = string.Empty;
            var controlEpmLess = control.Substring(8);

            SPSecurity.RunWithElevatedPrivileges(
                delegate
                {
                    using (var site = new SPSite(siteId))
                    {
                        using (var web = site.OpenWeb(webId))
                        {
                            url = string.Format(
                                "{0}/_layouts/epmlive/integration/opencontrol.aspx?control={1}&id={2}&intid={3}",
                                web.Url,
                                controlEpmLess,
                                id,
                                integrationId);
                        }
                    }
                });
            return url;
        }

        private string GetUrlFromSourceToDestinationColumns(
            SqlConnection sqlConnection,
            string integrationId,
            string control,
            Guid siteId,
            Guid webId,
            string id,
            Guid listId,
            Guid internalListUId)
        {
            var url = string.Empty;
            var sqlCommand = new SqlCommand(
                @"SELECT     INT_LISTS_1.INT_COLID, dbo.INT_LISTS.LIST_ID, dbo.INT_LISTS.INT_COLID AS Expr1, dbo.INT_LISTS.SITE_ID, dbo.INT_LISTS.WEB_ID, 
                                                                      INT_LISTS_1.INT_LIST_ID
                                                                        FROM         dbo.INT_CONTROLS INNER JOIN
                                                                      dbo.INT_LISTS AS INT_LISTS_1 ON dbo.INT_CONTROLS.INT_LIST_ID = INT_LISTS_1.INT_LIST_ID RIGHT OUTER JOIN
                                                                      dbo.INT_LISTS ON INT_LISTS_1.LIST_ID = dbo.INT_LISTS.LIST_ID WHERE     (dbo.INT_LISTS.INT_LIST_ID = @integrationid) and Control=@control",
                sqlConnection);
            sqlCommand.Parameters.AddWithValue("@integrationid", integrationId);
            sqlCommand.Parameters.AddWithValue("@control", control);

            var destinationColumnId = 0;
            var sourceColumnId = 0;
            using (var dataReader = sqlCommand.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        destinationColumnId = dataReader.GetInt32(0);
                    }

                    sourceColumnId = dataReader.GetInt32(2);

                    SPSecurity.RunWithElevatedPrivileges(
                        delegate
                        {
                            var core = new IntegrationCore(siteId, webId);
                            var itemId = string.Empty;
                            if (!string.IsNullOrWhiteSpace(id))
                            {
                                using (var site = new SPSite(siteId))
                                {
                                    using (var web = site.OpenWeb(webId))
                                    {
                                        var list = web.Lists[listId];

                                        try
                                        {
                                            var query = new SPQuery
                                            {
                                                Query = string.Format(
                                                    "<Where><Eq><FieldRef Name='INTUID{0}'/><Value Type='Text'>{1}</Value></Eq></Where>",
                                                    sourceColumnId,
                                                    id)
                                            };

                                            var listItemCollection = list.GetItems(query);

                                            if (listItemCollection.Count > 0)
                                            {
                                                itemId = listItemCollection[0]["INTUID" + destinationColumnId]
                                                    .ToString();
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            System.Diagnostics.Trace.TraceError("Exception suppressed {0}", ex);
                                        }
                                    }
                                }

                                if (itemId != string.Empty)
                                {
                                    url = core.GetControlURL(internalListUId, listId, control, itemId);
                                }
                                else
                                {
                                    lblMessage.Text = "Couldn't find matching ID";
                                }
                            }
                            else
                            {
                                url = core.GetControlURL(internalListUId, listId, control, string.Empty);
                            }
                        });
                }
                else
                {
                    lblMessage.Text = "Invalid Control";
                }
            }
            return url;
        }
    }
}