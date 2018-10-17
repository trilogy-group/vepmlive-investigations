using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Xml.Linq;
using EPMLiveCore.Helpers;
using EPMLiveCore.Properties;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public partial class MyWork
    {
        /// <summary>
        ///     Gets the working on.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        private static DataTable GetWorkingOn(SPWeb spWeb)
        {
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));

            const string SqlQuery = @"SELECT dbo.TagOrders.ItemId, dbo.TagOrders.ListId, dbo.Tags.SiteId
                                        FROM dbo.TagOrders INNER JOIN dbo.Tags ON dbo.TagOrders.TagId = dbo.Tags.TagId
                                        WHERE (dbo.Tags.Name = N'WorkingOn') AND (dbo.Tags.ResourceId = @ResourceId) AND (dbo.Tags.SiteId = @SiteId)";

            var queryExecutor = new QueryExecutor(spWeb);

            return queryExecutor.ExecuteEpmLiveQuery(
                SqlQuery,
                new Dictionary<string, object>
                {
                    { AtResourceId, spWeb.CurrentUser.ID },
                    { AtSiteIdText, spWeb.Site.ID }
                });
        }

        /// <summary>
        ///     Gets the working on.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static DataTable GetWorkingOn(string data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the working on grid data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetWorkingOnGridData(string data)
        {
            try
            {
                var bElement = new XElement(BField);
                var dataTable = GetWorkingOn(data);

                if (dataTable.Rows.Count > 0)
                {
                    var fieldTypes = Utils.GetFieldTypes();

                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        var iElement = new XElement(IText);

                        foreach (DataColumn dataColumn in dataTable.Columns)
                        {
                            var field = dataColumn.ColumnName;

                            var value = dataRow[field] == null || dataRow[field] == DBNull.Value
                                ? string.Empty
                                : dataRow[field].ToString();

                            value = GetGridSafeValue(BuildFieldElement(fieldTypes, value, field));

                            if (field.Equals(DueDateField) && !string.IsNullOrWhiteSpace(value))
                            {
                                iElement.Add(new XAttribute(DueDayField, Convert.ToDateTime(value).ToFriendlyDate()));
                            }

                            iElement.Add(new XAttribute(field, value ?? string.Empty));
                        }

                        bElement.Add(iElement);
                    }
                }

                return new XElement(GridText, new XElement(Body, bElement)).ToString();
            }
            catch (APIException apiException)
            {
                Trace.WriteLine(apiException);
                throw;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new APIException(2076, exception.Message);
            }
        }

        /// <summary>
        ///     Gets the working on grid layout.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetWorkingOnGridLayout(string data)
        {
            try
            {
                data = HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(data));

                var result = XDocument.Parse(Resources.WorkingOnGridLayout);
                var grid = result.Element(GridText);
                var cfgElement = new XElement(Cfg);

                cfgElement.Add(new XAttribute(Id, XDocument.Parse(data).Root.Element(ParamsText).Element(GridId).Value));
                cfgElement.Add(
                    new XAttribute(
                        Css,
                        $"{SPContext.Current.Web.Url}/_layouts/epmlive/treegrid/workingon/grid.css"));

                grid.Add(cfgElement);

                return result.ToString();
            }
            catch (APIException apiException)
            {
                Trace.WriteLine(apiException);
                throw;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new APIException(2075, exception.Message);
            }
        }
    }
}