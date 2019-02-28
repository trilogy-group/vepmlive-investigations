using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using EPMLiveCore.Helpers;
using EPMLiveCore.ReportHelper;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public partial class MyWork
    {
        /// <summary>
        ///     Gets the archived webs.
        /// </summary>
        /// <param name="siteId">The site id.</param>
        /// <returns></returns>
        public static List<Guid> GetArchivedWebs(Guid siteId)
        {
            try
            {
                var archivedWebs = new List<Guid>();

                using (var spSite = new SPSite(siteId))
                {
                    using (
                        var sqlConnection =
                            new SqlConnection(CoreFunctions.getConnectionString(spSite.WebApplication.Id)))
                    {
                        const string QueryString =
                            "SELECT WebId FROM dbo.PERSONALIZATIONS WHERE ([Key] = 'webarchived') AND (SiteId = @siteId)";

                        using (var sqlCommand = new SqlCommand(QueryString, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue(AtSiteId, siteId);

                            try
                            {
                                SPSecurity.RunWithElevatedPrivileges(sqlConnection.Open);

                                var sqlDataReader = sqlCommand.ExecuteReader();

                                while (sqlDataReader.Read())
                                {
                                    archivedWebs.Add(new Guid(sqlDataReader[0].ToString()));
                                }
                            }
                            catch (SqlException sqlException)
                            {
                                Trace.WriteLine(sqlException);
                                throw new APIException(2013, sqlException.Message);
                            }
                            finally
                            {
                                sqlConnection.Close();
                            }
                        }
                    }
                }

                return archivedWebs;
            }
            catch (APIException apiException)
            {
                Trace.WriteLine(apiException);
                throw;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new APIException(2012, exception.Message);
            }
        }

        private static string GetExampleDateFormat(SPWeb web, string yearLabel, string monthLabel, string dayLabel)
        {
            Guard.ArgumentIsNotNull(web, nameof(web));

            var format = string.Empty;
            var context = SPContext.GetContext(web);
            var spRegionalSettings = context.Web.CurrentUser.RegionalSettings ?? context.RegionalSettings;
            var dateSeparator = spRegionalSettings.DateSeparator;
            var calendarOrderType = (SPCalendarOrderType)spRegionalSettings.DateFormat;

            switch (calendarOrderType)
            {
                case SPCalendarOrderType.MDY:
                    format = $"{monthLabel}{dateSeparator}{dayLabel}{dateSeparator}{yearLabel}";
                    break;
                case SPCalendarOrderType.DMY:
                    format = $"{dayLabel}{dateSeparator}{monthLabel}{dateSeparator}{yearLabel}";
                    break;
                case SPCalendarOrderType.YMD:
                    format = $"{yearLabel}{dateSeparator}{monthLabel}{dateSeparator}{dayLabel}";
                    break;
                default:
                    Trace.WriteLine($"Unexpected value: {calendarOrderType}");
                    break;
            }

            return format;
        }

        /// <summary>
        ///     Gets the left cols.
        /// </summary>
        /// <param name="myWorkGridView">My work grid view.</param>
        /// <returns></returns>
        private static string GetLeftCols(MyWorkGridView myWorkGridView)
        {
            Guard.ArgumentIsNotNull(myWorkGridView, nameof(myWorkGridView));

            var leftCols = new List<string>();

            foreach (var col in myWorkGridView.LeftCols.Split(CharComma))
            {
                var split = col.Split(CharColon);
                var width = split[1];

                switch (split[0])
                {
                    case Complete:
                        width = CompleteColWidth;
                        break;
                    case CommentCount:
                        width = CommentColWidth;
                        break;
                    case Priority:
                        width = PriorityColWidth;
                        break;
                    default:
                        Trace.WriteLine($"Unexpected value: {split[0]}");
                        break;
                }

                leftCols.Add($"{split[0]}:{width}");
            }

            return string.Join(Comma, leftCols.ToArray());
        }

        /// <summary>
        ///     Gets the query.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static string GetQuery(string data)
        {
            if (!string.IsNullOrWhiteSpace(data))
            {
                var xDocument = XDocument.Parse(data);

                if (xDocument.Descendants().ToList().Exists(e => e.Name.LocalName.Equals(nameof(MyWork))))
                {
                    if (xDocument.Element(nameof(MyWork)).Descendants().ToList().Exists(e => e.Name.LocalName.Equals(QueryText)))
                    {
                        if (
                            xDocument.Element(nameof(MyWork))
                               .Element(QueryText)
                               .Descendants()
                               .ToList()
                               .Exists(
                                    e => e.Name.LocalName.Equals(WhereText)))
                        {
                            return xDocument.Element(nameof(MyWork))
                               .Element(QueryText)
                               .Element(WhereText)
                               .ToString()
                               .Replace(WhereTag, string.Empty)
                               .Replace(SlashWhere, string.Empty)
                               .Replace(WhereSlash, string.Empty)
                               .Replace(WhereSpaceSlash, string.Empty);
                        }
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        ///     Gets the type and format.
        /// </summary>
        /// <param name="fieldTypes">The field types.</param>
        /// <param name="selectedField">The selected field.</param>
        /// <param name="type">The type.</param>
        /// <param name="format">The format.</param>
        private static void GetTypeAndFormat(
            IDictionary<string, SPField> fieldTypes,
            string selectedField,
            out string type,
            out string format)
        {
            Guard.ArgumentIsNotNull(fieldTypes, nameof(fieldTypes));

            type = string.Empty;
            format = string.Empty;

            if (!fieldTypes.ContainsKey(selectedField))
            {
                return;
            }

            var field = fieldTypes[selectedField];

            format = Utils.GetFormat(field);
            type = field.Type.ToString();
        }

        /// <summary>
        ///     Maps the complete field.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="myWorkReportData">My work report data.</param>
        private static void MapCompleteField(SPWeb spWeb, MyWorkReportData myWorkReportData)
        {
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));
            Guard.ArgumentIsNotNull(myWorkReportData, nameof(myWorkReportData));

            using (var spSite = new SPSite(spWeb.Site.ID))
            {
                using (var web = spSite.OpenWeb(CoreFunctions.getLockedWeb(spWeb)))
                {
                    bool added;
                    bool.TryParse(CoreFunctions.getConfigSetting(web, EpmLiveMyWorkCompleteFieldAdded), out added);

                    if (added)
                    {
                        return;
                    }

                    var query =
                        $@"SELECT DISTINCT   dbo.RPTList.RPTListId AS ListId, dbo.RPTColumn.InternalName AS Col 
                                     FROM       dbo.RPTList INNER JOIN dbo.RPTColumn ON dbo.RPTList.RPTListId = dbo.RPTColumn.RPTListId
                                     WHERE      (dbo.RPTList.ListName = N'My Work') AND (dbo.RPTList.SiteId = '{spWeb.Site.ID}')";

                    var table = myWorkReportData.ExecuteSql(query);
                    table.PrimaryKey = new[] { table.Columns[ListId], table.Columns[Col] };

                    var listId = table.Rows[0][ListId];

                    var row = table.Rows.Find(new[] { listId, Complete });

                    if (row == null)
                    {
                        try
                        {
                            var columns = new List<ColumnDef>
                            {
                                new ColumnDef(Complete, Complete, Complete, SPFieldType.Boolean, SqlDbType.Bit)
                            };

                            myWorkReportData.InsertListColumns((Guid)listId, columns);
                            myWorkReportData.AddColumns(LstMyWork, columns);
                        }
                        catch (Exception exception)
                        {
                            Trace.WriteLine(exception);
                            throw new APIException(2014, UnableToMapReportingDatabase);
                        }
                    }

                    CoreFunctions.setConfigSetting(web, EpmLiveMyWorkCompleteFieldAdded, true.ToString());
                }
            }
        }
    }
}