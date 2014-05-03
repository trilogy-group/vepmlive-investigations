using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using EPMLiveCore;
using EPMLiveCore.API;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveReportsAdmin.API
{
    internal class DataManager : BaseManager
    {
        #region Constructors (1) 

        /// <summary>
        ///     Initializes a new instance of the <see cref="DataManager" /> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public DataManager(SPWeb spWeb)
            : base(spWeb) { }

        #endregion Constructors 

        #region Methods (9) 

        // Public Methods (3) 

        /// <summary>
        ///     Gets my work data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <exception cref="APIException"></exception>
        /// <returns></returns>
        public string GetMyWorkData(string data)
        {
            try
            {
                var dataElement = new XElement("Data");

                IList<int> resourcePoolIds;
                IList<string> badResourcePoolIds;
                bool returnAll;
                DateTime startDate;
                DateTime dueDate;

                ParseMyWorkDataResourceData(data, out resourcePoolIds, out badResourcePoolIds, out returnAll,
                    out startDate, out dueDate);

                Dictionary<int, string> mappedResources = MapResourcePoolIdToSPUser(resourcePoolIds,
                    ref badResourcePoolIds, returnAll);

                var resourceIdDict = new Dictionary<int, int>();

                var spUsers = new List<SPFieldUserValue>();

                foreach (var mappedResource in mappedResources)
                {
                    var spFieldUserValue = new SPFieldUserValue(Web, mappedResource.Value);

                    spUsers.Add(spFieldUserValue);
                    resourceIdDict.Add(spFieldUserValue.LookupId, mappedResource.Key);
                }

                if (spUsers.Any())
                {
                    DateTime dateTime = DateTime.Now;

                    if (startDate == DateTime.MinValue) startDate = dateTime.AddDays(-7);
                    if (dueDate == DateTime.MaxValue) dueDate = dateTime.AddDays(30);

                    DataTable dataTable = GetMyWorkDataForResources(spUsers, ParseMyWorkReportingScope(data), startDate,
                        dueDate);

                    BuildMyWorkDataResponse(dataTable, resourceIdDict, ref dataElement);
                }

                foreach (string badResourcePoolId in badResourcePoolIds)
                {
                    AddBadResourceError(badResourcePoolId, ref dataElement);
                }

                string sDate = SPUtility.CreateISO8601DateTimeFromSystemDateTime(startDate);
                string dDate = SPUtility.CreateISO8601DateTimeFromSystemDateTime(dueDate);

                return new XElement("GetMyWorkData", new XElement("Params",
                    new XElement("DateRange",
                        new XAttribute("StartDate", sDate),
                        new XAttribute("DueDate", dDate))),
                    dataElement).ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new APIException((int) Errors.GetMyWorkData, exception.GetBaseException().Message);
            }
        }

        /// <summary>
        ///     Gets my work fields.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public string GetMyWorkFields(string data)
        {
            try
            {
                var dataElement = new XElement("Data");

                List<string> fields;

                using (var myWorkReportData = new MyWorkReportData(Web.Site.ID))
                {
                    fields = myWorkReportData.GetFields();
                }

                foreach (string field in fields)
                {
                    dataElement.Add(new XElement("Field", new XAttribute("Name", field)));
                }

                return new XElement("GetMyWorkFields", new XElement("Params"), dataElement).ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new APIException((int) Errors.GetMyWorkFields, exception.GetBaseException().Message);
            }
        }

        /// <summary>
        ///     Refreshes all.
        /// </summary>
        /// <returns></returns>
        public string RefreshAll()
        {
            try
            {
                using (var epmData = new EPMData(Web.Site.ID))
                {
                    epmData.DeleteWork(Guid.Empty, -1);

                    epmData.Command =
                        "select timerjobuid from timerjobs where siteguid=@siteguid and listguid is null and jobtype=5";
                    epmData.AddParam("@siteguid", Web.Site.ID);

                    object result = epmData.ExecuteScalar(epmData.GetEPMLiveConnection);

                    Guid timerJobId = Guid.Empty;

                    if (result != null)
                    {
                        timerJobId = (Guid) result;
                    }
                    else
                    {
                        timerJobId = Guid.NewGuid();

                        epmData.Command =
                            "INSERT INTO TIMERJOBS (siteguid, jobtype, jobname, scheduletype, webguid, timerjobuid) VALUES (@siteguid, 5, 'Reporting Refresh All', 2, @webguid, @timerjobuid)";
                        epmData.AddParam("@siteguid", Web.Site.ID);
                        epmData.AddParam("@webguid", Web.ID);
                        epmData.AddParam("@timerjobuid", timerJobId);

                        epmData.ExecuteNonQuery(epmData.GetEPMLiveConnection);
                    }

                    if (timerJobId != Guid.Empty) CoreFunctions.enqueue(timerJobId, 0, Web.Site);
                }

                return "<RefreshAll><Data/></RefreshAll>";
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new APIException((int) Errors.RefreshAll, exception.GetBaseException().Message);
            }
        }

        // Private Methods (6) 

        /// <summary>
        ///     Adds the bad resource error.
        /// </summary>
        /// <param name="badResourcePoolId">The bad resource pool id.</param>
        /// <param name="dataElement">The data element.</param>
        private static void AddBadResourceError(string badResourcePoolId, ref XElement dataElement)
        {
            dataElement.Add(new XElement("Resource", new XAttribute("Id", badResourcePoolId),
                new XElement("Result", new XAttribute("Status", 1),
                    new XCData(
                        string.Format(
                            "{0} is not a valid Resource Pool Resource ID.",
                            badResourcePoolId)))));
        }

        /// <summary>
        ///     Builds my work data response.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="resourceIdDict">The resource id dict.</param>
        /// <param name="dataElement">The data element.</param>
        private void BuildMyWorkDataResponse(DataTable dataTable, Dictionary<int, int> resourceIdDict,
            ref XElement dataElement)
        {
            DataColumnCollection dataColumnCollection = dataTable.Columns;

            foreach (var keyValuePair in resourceIdDict)
            {
                var resourceDataElement = new XElement("Data");

                foreach (DataRow dataRow in dataTable.Select(string.Format("AssignedToId = {0}", keyValuePair.Key)))
                {
                    var itemElement = new XElement("Item", new XAttribute("Id", dataRow["ItemId"]),
                        new XAttribute("ListId", dataRow["ListId"]),
                        new XAttribute("WebId", dataRow["WebId"]),
                        new XAttribute("SiteId", dataRow["SiteId"]),
                        new XAttribute("WebUrl", dataRow["WebUrl"]));

                    foreach (DataColumn dataColumn in dataColumnCollection)
                    {
                        object value = dataRow[dataColumn];
                        string stringValue = value.ToString();

                        Type dataType = dataColumn.DataType;

                        if (dataType == typeof (DateTime) && value != DBNull.Value)
                        {
                            stringValue = SPUtility.CreateISO8601DateTimeFromSystemDateTime((DateTime) value);
                        }

                        itemElement.Add(new XElement("Field", new XAttribute("Name", dataColumn.ColumnName),
                            new XAttribute("Type", dataType), new XCData(stringValue)));
                    }

                    resourceDataElement.Add(itemElement);
                }

                dataElement.Add(new XElement("Resource", new XAttribute("Id", keyValuePair.Value),
                    new XElement("Result", new XAttribute("Status", 0)), resourceDataElement));
            }
        }

        /// <summary>
        ///     Gets my work data for resources.
        /// </summary>
        /// <param name="resources">The resources.</param>
        /// <param name="reportingScope">The reporting scope.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="dueDate">The due date.</param>
        /// <returns></returns>
        private DataTable GetMyWorkDataForResources(IEnumerable<SPFieldUserValue> resources,
            ReportingScope reportingScope,
            DateTime startDate, DateTime dueDate)
        {
            DataTable dataTable;

            using (var myWorkReportData = new MyWorkReportData(Web.Site.ID))
            {
                dataTable =
                    myWorkReportData.GetData(new Dictionary<string, IEnumerable<object>>
                    {
                        {"AssignedToId", from r in resources select (object) r.LookupId},
                        {"StartDate", new[] {(object) startDate}},
                        {"DueDate", new[] {(object) dueDate}},
                    }, reportingScope, Web);
            }

            return dataTable;
        }

        /// <summary>
        ///     Maps the resource pool id to SP user id.
        /// </summary>
        /// <param name="resourcePoolIds">The resource pool ids.</param>
        /// <param name="badResourcePoolIds">The bad resource pool ids.</param>
        /// <param name="returnAll">if set to <c>true</c> [return all].</param>
        /// <returns></returns>
        private Dictionary<int, string> MapResourcePoolIdToSPUser(IEnumerable<int> resourcePoolIds,
            ref IList<string> badResourcePoolIds, bool returnAll)
        {
            var resourceIdDictionary = new Dictionary<int, string>();

            DataTable resourcePool = APITeam.GetResourcePool(@"<GetResources><Columns></Columns></GetResources>", Web);

            if (!returnAll)
            {
                foreach (int resourcePoolId in resourcePoolIds)
                {
                    DataRow dataRow = resourcePool.Select(string.Format("ID = '{0}'", resourcePoolId)).FirstOrDefault();

                    if (dataRow == null)
                    {
                        badResourcePoolIds.Add(resourcePoolId.ToString(CultureInfo.InvariantCulture));
                        continue;
                    }

                    if (!resourceIdDictionary.ContainsKey(resourcePoolId))
                    {
                        resourceIdDictionary.Add(resourcePoolId, (string) dataRow["SPAccountInfo"]);
                    }
                }
            }
            else
            {
                foreach (DataRow dataRow in resourcePool.Rows)
                {
                    int resourcePoolId = int.Parse(dataRow["ID"].ToString());

                    if (!resourceIdDictionary.ContainsKey(resourcePoolId))
                    {
                        resourceIdDictionary.Add(resourcePoolId, (string) dataRow["SPAccountInfo"]);
                    }
                }
            }

            return resourceIdDictionary;
        }

        /// <summary>
        ///     Parses my work data resource data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="resourcePoolIds">The resource pool ids.</param>
        /// <param name="badResourcePoolIds">The bad resource pool ids.</param>
        /// <param name="returnAll">if set to <c>true</c> [return all].</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="dueDate">The due date.</param>
        private void ParseMyWorkDataResourceData(string data, out IList<int> resourcePoolIds,
            out IList<string> badResourcePoolIds, out bool returnAll,
            out DateTime startDate, out DateTime dueDate)
        {
            returnAll = false;

            resourcePoolIds = new List<int>();
            badResourcePoolIds = new List<string>();

            startDate = new DateTime(1800, 1, 1);
            dueDate = new DateTime(9999, 12, 31);

            XDocument requestDocument = XDocument.Parse(data);

            if (requestDocument.Root == null)
            {
                throw new APIException((int) Errors.ParseMyWorkDataNoRootElement,
                    "Cannot find the root element: GetMyWorkReportingData");
            }

            XElement paramsElement = requestDocument.Root.Element("Params");

            if (paramsElement == null)
            {
                throw new APIException((int) Errors.ParseMyWorkDataNoParamsElement,
                    @"Cannot find the GetMyWorkReportingData\Params element");
            }

            XElement resourcesElement = paramsElement.Element("Resources");

            if (resourcesElement == null)
            {
                throw new APIException((int) Errors.ParseMyWorkDataNoResourcesElement,
                    @"Cannot find the GetMyWorkReportingData\Params\Resources element");
            }

            XElement dateRangeAttribute = paramsElement.Element("DateRange");
            if (dateRangeAttribute != null)
            {
                DateTime date;

                XAttribute startDateAttribute = dateRangeAttribute.Attribute("StartDate");
                if (startDateAttribute != null && DateTime.TryParse(startDateAttribute.Value, out date))
                    startDate = date;

                XAttribute dueDateAttribute = dateRangeAttribute.Attribute("DueDate");
                if (dueDateAttribute != null && DateTime.TryParse(dueDateAttribute.Value, out date)) dueDate = date;

                startDate = startDate.Date;
                dueDate = dueDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            }

            if (resourcesElement.Value.Equals("ALL"))
            {
                returnAll = true;
                return;
            }

            foreach (string resourcePoolId in resourcesElement.Value.Split(','))
            {
                int id;

                if (int.TryParse(resourcePoolId, out id)) resourcePoolIds.Add(id);
                else badResourcePoolIds.Add(resourcePoolId);
            }
        }

        /// <summary>
        ///     Parses my work reporting scope.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private ReportingScope ParseMyWorkReportingScope(string data)
        {
            XDocument requestDocument = XDocument.Parse(data);

            XElement scopeElement = requestDocument.Root.Element("Params").Element("Scope");

            if (scopeElement != null)
            {
                string scope = scopeElement.Value;

                if (!Enum.IsDefined(typeof (ReportingScope), scope))
                {
                    throw new APIException((int) Errors.InvalidReportingScope,
                        string.Format(
                            "{0} is not a valid Reporting Scope. Valid scopes are: Site, Web and Recursive",
                            scope));
                }

                return (ReportingScope) Enum.Parse(typeof (ReportingScope), scope);
            }

            return ReportingScope.Recursive;
        }

        #endregion Methods 
    }
}