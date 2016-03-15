using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using Microsoft.SharePoint;

namespace WorkEnginePPM.Core.DataSync
{
    public class DepartmentManager : BaseManager
    {
        #region Constructors (1)

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentManager"/> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public DepartmentManager(SPWeb spWeb)
            : base(spWeb)
        {
            ResourceDictionary = new Dictionary<int, string>();
        }

        #endregion Constructors

        #region Properties (1)

        private Dictionary<int, string> ResourceDictionary { get; set; }
        private List<SPListItem> ResourcesListItems { get; set; }

        #endregion Properties

        #region Methods (7)

        // Public Methods (4) 

        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="extId">The ext id.</param>
        /// <returns></returns>
        public bool Delete(int id, string extId)
        {
            var requestDocument = new XDocument();

            requestDocument.Add(new XElement("DeleteDepartments", new XElement("Params"),
                                             new XElement("Data",
                                                          new XElement("Department",
                                                                       new XAttribute("Id", extId ?? string.Empty),
                                                                       new XAttribute("ExtId", id),
                                                                       new XAttribute("DataId", Guid.NewGuid())))));

            using (var portfolioEngineAPI = new PortfolioEngineAPI(Web))
            {
                XDocument responseDocument =
                    XDocument.Parse(portfolioEngineAPI.Execute("DeleteDepartments", requestDocument.ToString()));

                XElement responseRootElement = responseDocument.Root;

                ValidateResponse(responseRootElement);
            }

            return true;
        }

        /// <summary>
        /// Gets all from PFE.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllFromPFE()
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Title", typeof(string));
            dataTable.Columns.Add("Managers", typeof(object));
            dataTable.Columns.Add("Executives", typeof(object));
            dataTable.Columns.Add("ExtId", typeof(string));
            dataTable.Columns.Add("Parent", typeof(string));

            XDocument responseXml;

            using (var portfolioEngineAPI = new PortfolioEngineAPI(Web))
            {
                responseXml = XDocument.Parse(portfolioEngineAPI.Execute("GetDepartments", string.Empty));
            }

            if (!responseXml.Root.Element("Result").Attribute("Status").Value.Equals("0")) return dataTable;

            var dictionary = new Dictionary<int, string>();

            foreach (XElement xElement in responseXml.Root.Descendants("Department"))
            {
                int id;
                int.TryParse(xElement.Attribute("ExtId").Value, out id);

                string extId = xElement.Attribute("Id").Value;
                int level = Convert.ToInt32(xElement.Attribute("Level").Value);
                string title = xElement.Attribute("Title").Value;

                if (dictionary.ContainsKey(level)) dictionary[level] = extId;
                else dictionary.Add(level, extId);

                var managersAttr = xElement.Attribute("Managers");
                object managers = GetResourceLookupFromExtId(managersAttr != null ? managersAttr.Value : "-1", true);

                XAttribute executivesAttr = xElement.Attribute("Executives");
                object executives = GetResourceLookupFromExtId(executivesAttr != null ? executivesAttr.Value : "-1",
                                                               false);

                dataTable.Rows.Add(id, title, managers, executives, extId,
                                   level == 1 ? (object)(-1) : dictionary[level - 1]);
            }

            return dataTable;
        }

        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <param name="spListItemCollection">The sp list item collection.</param>
        /// <returns></returns>
        public DataTable GetDataTable(SPListItemCollection spListItemCollection)
        {
            var dataTable = new DataTable("Departments");

            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Title", typeof(string));
            dataTable.Columns.Add("Managers", typeof(object));
            dataTable.Columns.Add("Executives", typeof(object));
            dataTable.Columns.Add("ExtId", typeof(string));
            dataTable.Columns.Add("UniqueId", typeof(Guid));
            dataTable.Columns.Add("ParentId", typeof(int));

            foreach (SPListItem spListItem in spListItemCollection)
            {
                dataTable.Rows.Add(spListItem.ID, (string)spListItem["Title"],
                                   new SPFieldLookupValueCollection((spListItem["Managers"] ?? string.Empty).ToString()),
                                   new SPFieldLookupValueCollection(
                                       (spListItem["Executives"] ?? string.Empty).ToString()),
                                   (string)spListItem["EXTID"], spListItem.UniqueId,
                                   new SPFieldLookupValue((spListItem["RBS"] ?? string.Empty).ToString()).LookupId);
            }

            return dataTable;
        }

        /// <summary>
        /// Synchronizes the specified data table.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public DataTable Synchronize(DataTable dataTable)
        {
            var requestDocument = new XDocument();
            requestDocument.Add(new XElement("UpdateDepartments", new XElement("Params"), new XElement("Data")));

            XElement dataElement = requestDocument.Root.Element("Data");

            SPQuery query = new SPQuery();
            query.Query = string.Empty;
            query.ViewFields = "<FieldRef Name='ID'/><FieldRef Name='Title'/><FieldRef Name='EXTID'/>";
            ResourcesListItems = Web.Lists["Resources"].GetItems(query).Cast<SPListItem>().ToList();

            BuildRequest(0, dataTable, ref dataElement);

            using (var portfolioEngineAPI = new PortfolioEngineAPI(Web))
            {
                XDocument responseDocument =
                    XDocument.Parse(portfolioEngineAPI.Execute("UpdateDepartments", requestDocument.ToString()));

                XElement responseRootElement = responseDocument.Root;

                ValidateResponse(responseRootElement);

                XElement responseDataElement = responseRootElement.Element("Data");

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    XElement departmentElement = (from d in responseDataElement.Descendants()
                                                  where
                                                      d.Attribute("DataId").Value.Equals(dataRow["UniqueId"].ToString())
                                                  select d).FirstOrDefault();

                    if (departmentElement != null)
                    {
                        XElement resElement = departmentElement.Element("Result");
                        if (resElement != null)
                        {
                            XAttribute statusEle = resElement.Attribute("Status");
                            if (statusEle != null && statusEle.Value.Equals("1"))
                            {
                                throw new Exception(resElement.Value);
                            }
                        }

                        dataRow["ExtId"] = departmentElement.Attribute("Id").Value;
                    }
                }
            }

            return dataTable;
        }

        // check if department associate with any Resource then restrict the delete opration
        public bool PerformDepartmentDeleteCheck(SPItemEventProperties properties, out string Errmsg)
        {
            bool IsDeptDel = true;
            Errmsg = string.Empty;
            try
            {
                if (properties.List.Fields.ContainsFieldWithStaticName("DisplayName") && properties.List.Fields.ContainsFieldWithStaticName("RBS"))
                {
                    SPWeb web = properties.Web;
                    SPQuery query = new SPQuery();
                    query.Query = "<Where><Eq><FieldRef Name='Department' LookupId='TRUE'/><Value Type='Lookup'>" + properties.ListItemId + "</Value></Eq></Where>";

                    SPList lstResourceList = web.Lists.TryGetList("Resources");
                    if (lstResourceList != null)
                    {
                        SPListItemCollection spResourcesListItems = lstResourceList.GetItems(query);

                        if (spResourcesListItems.Count > 0)                        
                            IsDeptDel = false;
                    }

                }
            }
            catch (Exception ex)
            {
                IsDeptDel = false;
                Errmsg = ex.Message;
            }            
            return IsDeptDel;
        }

        // Private Methods (3) 

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="parentId">The parent id.</param>
        /// <param name="dataTable">The data table.</param>
        /// <param name="dataElement">The data element.</param>
        private void BuildRequest(int parentId, DataTable dataTable, ref XElement dataElement)
        {
            foreach (DataRow dataRow in dataTable.Select(string.Format("ParentId = {0}", parentId)))
            {
                XElement parentElement = (from e in dataElement.Descendants()
                                          let idAttribute = e.Attribute("Id")
                                          where
                                              idAttribute != null &&
                                              idAttribute.Value.Equals(dataRow["ParentId"].ToString())
                                          select e).FirstOrDefault();

                var managers = new List<string>();
                var executives = new List<string>();

                object managerCollection = dataRow["Managers"];

                if (managerCollection != DBNull.Value)
                {
                    foreach (string resourcePoolId in ((SPFieldLookupValueCollection)managerCollection)
                        .Select(GetResourcePoolId).Where(resourcePoolId => !string.IsNullOrEmpty(resourcePoolId))
                        .Where(resourcePoolId => !managers.Contains(resourcePoolId)))
                    {
                        managers.Add(resourcePoolId);
                    }
                }

                object executiveCollection = dataRow["Executives"];

                if (executiveCollection != DBNull.Value)
                {
                    foreach (string resourcePoolId in ((SPFieldLookupValueCollection)executiveCollection)
                        .Select(GetResourcePoolId).Where(resourcePoolId => !string.IsNullOrEmpty(resourcePoolId))
                        .Where(resourcePoolId => !executives.Contains(resourcePoolId)))
                    {
                        executives.Add(resourcePoolId);
                    }
                }

                object departmentId = dataRow["Id"];

                var departmentElement = new XElement("Department", new XAttribute("Id", dataRow["EXTID"]),
                                                     new XAttribute("Title", dataRow["Title"]),
                                                     new XAttribute("Managers", string.Join(",", managers.ToArray())),
                                                     new XAttribute("Executives", string.Join(",", executives.ToArray())),
                                                     new XAttribute("ExtId", departmentId),
                                                     new XAttribute("DataId", dataRow["UniqueId"]));

                if (parentElement == null) dataElement.Add(departmentElement);
                else parentElement.Add(departmentElement);

                if (!string.IsNullOrEmpty(departmentId.ToString()))
                    BuildRequest((int)departmentId, dataTable, ref departmentElement);
            }
        }

        /// <summary>
        /// Gets the resource lookup from ext id.
        /// </summary>
        /// <param name="resources">The resources.</param>
        /// <param name="isManager">if set to <c>true</c> [is manager].</param>
        /// <returns></returns>
        private object GetResourceLookupFromExtId(string resources, bool isManager)
        {
            if (!isManager && resources.Equals("-1")) return null;

            if (string.IsNullOrEmpty(resources)) return null;

            SPUser currentUser = Web.CurrentUser;

            string[] resourceExtIds = resources.Split(',');

            SPList spList = Web.Lists["Resources"];

            SPListItemCollection spListItemCollection = spList.Items;

            var spFieldLookupValues = new Dictionary<string, SPFieldLookupValue>();

            foreach (string resourceExtId in resourceExtIds)
            {
                foreach (SPListItem spListItem in spListItemCollection.Cast<SPListItem>()
                    .Where(spListItem => (spListItem["EXTID"] ?? "-2").Equals(resourceExtId)))
                {
                    spFieldLookupValues.Add(spListItem["EXTID"].ToString(),
                                            new SPFieldLookupValue(spListItem.ID, spListItem.Title));
                    if (isManager)
                    {
                        return spFieldLookupValues.First().Value;
                    }

                    break;
                }
            }

            if (spFieldLookupValues.Count >= 1)
            {
                var spFieldLookupValueCollection = new SPFieldLookupValueCollection();
                spFieldLookupValueCollection.AddRange(
                    spFieldLookupValues.Select(spFieldLookupValue => spFieldLookupValue.Value));

                if (isManager) return spFieldLookupValueCollection.First();

                return spFieldLookupValueCollection;
            }

            return null;
        }

        /// <summary>
        /// Gets the resource pool id.
        /// </summary>
        /// <param name="spFieldLookupValue">The sp field lookup value.</param>
        /// <returns></returns>
        private string GetResourcePoolId(SPFieldLookupValue spFieldLookupValue)
        {
            int lookupId = spFieldLookupValue.LookupId;

            if (lookupId == 0) return string.Empty;

            if (!ResourceDictionary.ContainsKey(lookupId))
            {
                SPListItem resource = (from rc in ResourcesListItems
                                       where rc["ID"].Equals(lookupId)
                                       select rc).FirstOrDefault();
                if (resource != null)
                {
                    object extId = resource["EXTID"];

                    if (extId == null || string.IsNullOrEmpty(extId.ToString()))
                    {
                        throw new Exception(string.Format("EXTID is not set for the Resource. ID: {0}, Name: {1}",
                                                          lookupId, resource["Title"]));
                    }

                    ResourceDictionary.Add(lookupId, extId.ToString());
                }
            }

            return ResourceDictionary[lookupId];
        }



        #endregion Methods
    }
}