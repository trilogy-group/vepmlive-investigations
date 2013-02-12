using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.SPFields;
using Microsoft.SharePoint;

namespace EPMLiveCore.API.ResourceManagement
{
    internal class ResourceManager : BaseManager
    {
        #region Fields (4) 

        private const string CannotFindResourceErrorMessage =
            "Cannot find resource with ID {0} in the Resource Pool or the SharePointAccount is not properly set for the resource in the Resource Pool.";

        private const string TimeOffJoins =
            @"<Join Type=""LEFT"" ListAlias=""Category""><!--List Name: NonWork--><Eq><FieldRef Name=""TimeOffType"" RefType=""ID"" /><FieldRef List=""Category"" Name=""ID"" /></Eq></Join>";

        private const string TimeOffProjectedFields =
            @"<Field Name=""CategoryTitle"" Type=""Lookup"" List=""Category"" ShowField=""Title"" /><Field Name=""CategoryExtId"" Type=""Lookup"" List=""Category"" ShowField=""EXTID"" />";

        private const string TimeOffViewFields =
            @"<FieldRef Name=""ID"" /><FieldRef Name=""Title"" /><FieldRef Name=""StartDate"" /><FieldRef Name=""DueDate"" /><FieldRef Name=""Work"" /><FieldRef Name=""WorkDetail"" /><FieldRef Name=""AssignedTo"" LookupId=""TRUE"" /><FieldRef Name=""CategoryTitle"" /><FieldRef Name=""TimeOffType"" LookupId=""TRUE"" /><FieldRef Name=""CategoryExtId"" />";

        #endregion Fields 

        #region Enums (1) 

        internal enum Errors
        {
            GetTimeOff = 16000,
            GetResourceIdsRootEleNotFound,
            GetResourceIdsParamsEleNotFound,
            GetResourceIdsResourcesEleNotFound,
            GetTimeOffWorkDetailFieldNotFound,
            GetTimeOffData,
            GetTimeOffDataResourcePoolList
        }

        #endregion Enums 

        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceManager"/> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public ResourceManager(SPWeb spWeb)
            : base(spWeb)
        {
        }

        #endregion Constructors 

        #region Methods (3) 

        // Public Methods (1) 

        /// <summary>
        /// Gets the time off.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public string GetTimeOff(string data)
        {
            try
            {
                var getTimeOffElement = new XElement("GetResourceTimeOff");

                IList<int> resourceIds = GetResourceIds(data);

                DataTable timeOffDataTable;
                DataTable resourceDataTable;

                GetTimeOffData(resourceIds, out resourceDataTable, out timeOffDataTable);

                if (timeOffDataTable == null || resourceDataTable == null) return getTimeOffElement.ToString();

                Dictionary<int, bool> resourceProcessed = resourceIds.ToDictionary(resourceId => resourceId,
                                                                                   resourceId => false);

                var timeOffData = (from timeOff in timeOffDataTable.AsEnumerable()
                                   join resource in resourceDataTable.AsEnumerable() on
                                       timeOff["AssignedTo"] equals
                                       resource["SharePointAccount"]
                                   where resourceIds.Contains(Convert.ToInt32(timeOff["AssignedTo"]))
                                   select new
                                              {
                                                  Id = timeOff["ID"],
                                                  Title = timeOff["Title"],
                                                  StartDate = timeOff["StartDate"],
                                                  FinishDate = timeOff["DueDate"],
                                                  Hours = timeOff["Work"],
                                                  WorkDetail = timeOff["WorkDetail"],
                                                  Category = timeOff["CategoryTitle"],
                                                  CategoryId = !string.IsNullOrEmpty(timeOff["TimeOffType"].ToString()) 
                                                    ? Convert.ToInt32(timeOff["TimeOffType"]) : 0,
                                                  CategoryExtId = !string.IsNullOrEmpty(timeOff["CategoryExtId"].ToString()) 
                                                    ? Convert.ToInt32(timeOff["CategoryExtId"]) : 0,
                                                  ResourcePoolId = !string.IsNullOrEmpty(resource["ID"].ToString()) 
                                                    ? Convert.ToInt32(resource["ID"]) : 0,
                                                  ResourceId = !string.IsNullOrEmpty(timeOff["AssignedTo"].ToString())
                                                    ? Convert.ToInt32(timeOff["AssignedTo"]) : 0,
                                                  ResourceExtId = !string.IsNullOrEmpty(resource["EXTID"].ToString())
                                                    ? Convert.ToInt32(resource["EXTID"]) : 0
                                              }).AsQueryable();

                foreach (int resId in resourceIds)
                {
                    int resourceId = resId;
                    var resourceElement = new XElement("Resource");

                    int resourceExtId = 0;
                    int resourcePoolId = 0;

                    try
                    {
                        foreach (var category in from t in timeOffData
                                                 where t.ResourceId == resourceId
                                                 select new
                                                 {
                                                     t.ResourceExtId,
                                                     t.ResourcePoolId,
                                                     t.CategoryId,
                                                     t.CategoryExtId,
                                                     Title = t.Category
                                                 })
                        {
                            resourcePoolId = category.ResourcePoolId;
                            resourceExtId = category.ResourceExtId;

                            int categoryId = category.CategoryId;

                            var categoryElement = new XElement("Category");

                            try
                            {
                                foreach (var timeOff in from t in timeOffData
                                                        where (t.ResourceId == resourceId && t.CategoryId == categoryId)
                                                        select new
                                                        {
                                                            t.Id,
                                                            t.Title,
                                                            t.StartDate,
                                                            t.FinishDate,
                                                            t.Hours,
                                                            t.WorkDetail,
                                                            t.Category,
                                                            t.CategoryExtId,
                                                            t.ResourceExtId
                                                        })
                                {
                                    var timeOffElement = new XElement("TimeOff");

                                    decimal totalHours = 0;

                                    try
                                    {
                                        string[] workDetails = ((string)timeOff.WorkDetail).Split(',');

                                        int index = 0;
                                        for (var dateTime = (DateTime)timeOff.StartDate;
                                             dateTime <= (DateTime)timeOff.FinishDate;
                                             dateTime = dateTime.AddDays(1))
                                        {
                                            decimal hours;

                                            try
                                            {
                                                hours = Convert.ToDecimal(workDetails[index]);
                                                totalHours += hours;
                                            }
                                            catch (Exception)
                                            {
                                                throw new Exception(string.Format("Cannot find hours for {0}",
                                                                                  dateTime.ToString("M/d/yyyy")));
                                            }

                                            timeOffElement.Add(new XElement("Item", new XAttribute("Date", dateTime),
                                                                            new XAttribute("Hours", hours)));

                                            index++;
                                        }
                                    }
                                    catch (Exception exception)
                                    {
                                        timeOffElement.Add(new XElement("Result", new XAttribute("Status", 1),
                                                                        exception.Message));
                                    }
                                    finally
                                    {
                                        timeOffElement.Add(new XAttribute("Id", timeOff.Id),
                                                           new XAttribute("Title", timeOff.Title),
                                                           new XAttribute("StartDate", timeOff.StartDate),
                                                           new XAttribute("FinishDate", timeOff.FinishDate),
                                                           new XAttribute("Hours", totalHours));

                                        categoryElement.Add(timeOffElement);
                                    }
                                }
                            }
                            catch (Exception exception)
                            {
                                categoryElement.Add(new XElement("Result", new XAttribute("Status", 1),
                                                                 exception.Message));
                            }
                            finally
                            {
                                categoryElement.Add(new XAttribute("Id", categoryId),
                                                    new XAttribute("Title", category.Title),
                                                    new XAttribute("ExtId", category.CategoryExtId));

                                resourceElement.Add(categoryElement);

                                resourceProcessed[resourceId] = true;
                            }
                        }

                        resourceElement.Add(new XElement("Result", new XAttribute("Status", 0)));
                    }
                    catch (Exception exception)
                    {
                        resourceElement.Add(new XElement("Result", new XAttribute("Status", 1), exception.Message));
                    }
                    finally
                    {
                        if (resourceProcessed[resourceId])
                        {
                            resourceElement.Add(new XAttribute("Id", resourcePoolId), new XAttribute("ExtId", resourceExtId),
                                                new XAttribute("DataId", resourcePoolId));

                            getTimeOffElement.Add(resourceElement);
                        }
                    }
                }

                foreach (var processedInfo in resourceProcessed.Where(processedInfo => !processedInfo.Value))
                {
                    getTimeOffElement.Add(new XElement("Resource", new XAttribute("Id", processedInfo.Key),
                                                       new XElement("Result", new XAttribute("Status", 1),
                                                                    string.Format(CannotFindResourceErrorMessage,
                                                                                  processedInfo.Key))));
                }

                return getTimeOffElement.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.GetTimeOff, e.Message);
            }
        }

        // Private Methods (2) 

        /// <summary>
        /// Gets the resource ids.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private IList<int> GetResourceIds(string data)
        {
            var ids = new List<int>();

            XDocument xDocument = XDocument.Parse(data);

            if (xDocument.Root == null)
            {
                throw new APIException((int) Errors.GetResourceIdsRootEleNotFound, "Cannot find the GetTimeOff element.");
            }

            XElement paramsElement = xDocument.Root.Element("Params");

            if (paramsElement == null)
            {
                throw new APIException((int) Errors.GetResourceIdsParamsEleNotFound,
                                       @"Cannot find the GetTimeOff\Params element.");
            }

            XElement resourcesElement = paramsElement.Element("Resources");

            if (resourcesElement == null)
            {
                throw new APIException((int) Errors.GetResourceIdsResourcesEleNotFound,
                                       @"Cannot find the GetTimeOff\Params\Resources element.");
            }

            foreach (string value in resourcesElement.Value.Split(','))
            {
                int id;
                if (int.TryParse(value, out id))
                {
                    ids.Add(id);
                }
            }

            return ids.Distinct().ToArray();
        }

        /// <summary>
        /// Gets the time off data.
        /// </summary>
        /// <param name="resourceIds">The resource ids.</param>
        /// <param name="resourceDataTable">The resource data table.</param>
        /// <param name="timeOffDataTable">The time off data table.</param>
        private void GetTimeOffData(IList<int> resourceIds, out DataTable resourceDataTable,
                                    out DataTable timeOffDataTable)
        {
            try
            {
                resourceDataTable = null;
                timeOffDataTable = null;

                if (resourceIds.Count == 0) return;

                var timeOffQuery = new SPQuery
                                       {
                                           ViewFields = TimeOffViewFields,
                                           ProjectedFields = TimeOffProjectedFields,
                                           Joins = TimeOffJoins,
                                           Query = Utilities.ComposeCamlQuery(
                                               resourceIds.Select(
                                                   resourceId => resourceId.ToString(CultureInfo.InvariantCulture)).
                                                   ToArray(), "Or",
                                               "<Where>{0}</Where>",
                                               @"<Eq><FieldRef Name=""AssignedTo"" LookupId=""TRUE"" /><Value Type=""Int"">{0}</Value></Eq>")
                                       };

                SPList timeOffList = Web.Lists["Time Off"];

                SPListItemCollection timeOffItemCollection = timeOffList.GetItems(timeOffQuery);

                if (timeOffItemCollection.Count == 0) return;

                var resourcePoolQuery = new SPQuery
                                            {
                                                ViewFields =
                                                    @"<FieldRef Name=""SharePointAccount"" LookupId=""TRUE"" /><FieldRef Name=""EXTID"" />",
                                                Query =
                                                    Utilities.ComposeCamlQuery(
                                                        resourceIds.Select(
                                                            resourceId =>
                                                            resourceId.ToString(CultureInfo.InvariantCulture))
                                                            .ToArray(), "Or", "<Where>{0}</Where>",
                                                        @"<Eq><FieldRef Name=""SharePointAccount"" LookupId=""TRUE"" /><Value Type=""Int"">{0}</Value></Eq>")
                                            };

                var dhbField = timeOffList.Fields.GetFieldByInternalName("WorkDetail") as DaysHoursBreakdownField;

                if (dhbField == null) return;

                var fieldInfo = dhbField.GetType().GetField("_resourcePoolList", BindingFlags.NonPublic | BindingFlags.Instance);

                if (fieldInfo == null)
                {
                    throw new APIException((int) Errors.GetTimeOffDataResourcePoolList,
                                           "Unable to retrieve the Resource Pool list.");
                }

                var resourcePoolList = (string) fieldInfo.GetValue(dhbField);

                SPListItemCollection resourcePoolItemCollection =
                    Web.Lists[resourcePoolList].GetItems(resourcePoolQuery);

                if (resourcePoolItemCollection.Count == 0) return;

                // DO NOT REMOVE THE FOLLOWING TWO LINES OR THE LIFE WILL JUST GET MISERABLE!!!

                int totalFields = timeOffItemCollection.Fields.Count;
                int fieldCount = resourcePoolItemCollection.Fields.Count;

                // DO NOT REMOVE THE TWO LINES ABOVE OR THE LIFE WILL JUST GET MISERABLE!!!

                timeOffDataTable = timeOffItemCollection.GetDataTable();
                resourceDataTable = resourcePoolItemCollection.GetDataTable();
            }
            catch (Exception exception)
            {
                throw new APIException((int) Errors.GetTimeOffData, exception.GetBaseException().Message);
            }
        }

        #endregion Methods 
    }
}
