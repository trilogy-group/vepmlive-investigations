using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Threading;
using System.Xml.Linq;
using EPMLiveIntegration;
using Microsoft.SharePoint.Client;

namespace EPMLiveCore.Integrations.Office365.Infrastructure
{
    internal class O365Service
    {
        #region Fields (7) 

        private const string INCOMING_LIST = "EPMLiveIntIncoming";
        private const string INT_LIST = "EPMLiveIntegrations";
        private readonly AESCryptographyService _cryptographyService;
        private readonly SecureString _password;
        private readonly string _siteUrl;
        private readonly Dictionary<int, string> _userEmails;
        private readonly string _username;

        #endregion Fields 

        #region Constructors (1) 

        internal O365Service(string username, SecureString password, string siteUrl)
        {
            _username = username;
            _password = password;
            _siteUrl = siteUrl;
            _userEmails = new Dictionary<int, string>();
            _cryptographyService = new AESCryptographyService();
        }

        #endregion Constructors 

        #region Methods (19) 

        // Public Methods (9) 

        public IEnumerable<O365Result> DeleteListItemsById(string[] itemIds, string listName)
        {
            var results = new List<O365Result>();

            using (ClientContext clientContext = GetClientContext())
            {
                List list = clientContext.Web.Lists.GetByTitle(listName);
                clientContext.Load(list);
                clientContext.ExecuteQuery();

                foreach (int itemId in itemIds.Select(id => Convert.ToInt32(id)))
                {
                    try
                    {
                        ListItem item = list.GetItemById(itemId);
                        clientContext.Load(item);
                        clientContext.ExecuteQuery();

                        item.DeleteObject();
                        clientContext.ExecuteQuery();

                        results.Add(new O365Result(itemId, TransactionType.DELETE));
                    }
                    catch (Exception e)
                    {
                        results.Add(new O365Result(itemId, TransactionType.DELETE, false, e.Message));
                    }
                }
            }

            return results;
        }

        public bool EnsureEPMLiveAppInstalled()
        {
            try
            {
                using (ClientContext clientContext = GetClientContext())
                {
                    List list = clientContext.Web.Lists.GetByTitle(INT_LIST);
                    clientContext.Load(list);
                    clientContext.ExecuteQuery();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Dictionary<string, string> GetIntegratableLists()
        {
            var dictionary = new SortedDictionary<string, string>();

            using (ClientContext clientContext = GetClientContext())
            {
                clientContext.Load(clientContext.Web.Lists);
                clientContext.ExecuteQuery();

                List<List> listCollection = clientContext.Web.Lists.ToList();

                foreach (List list in listCollection.Where(list => !list.Hidden))
                {
                    dictionary.Add(list.Title, list.Title);
                }
            }

            return dictionary.OrderBy(l => l.Value).ToDictionary(l => l.Key, l => l.Value);
        }

        public IEnumerable<Field> GetListFields(string listName)
        {
            var fields = new List<Field>();

            using (ClientContext clientContext = GetClientContext())
            {
                List list = clientContext.Web.Lists.GetByTitle(listName);
                clientContext.Load(list, l => l.Fields);
                clientContext.ExecuteQuery();

                List<Field> listFields = list.Fields.ToList();
                fields.AddRange(listFields.Where(field => !field.Hidden && !field.Group.Equals("_Hidden")));
            }

            return fields;
        }

        public void GetListItems(string listName, DataTable items, DateTime lastSynchDate)
        {
            string lastSynchDateTime =
                DateTime.SpecifyKind(lastSynchDate.ToUniversalTime(), DateTimeKind.Utc)
                        .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffK");

            using (ClientContext clientContext = GetClientContext())
            {
                List list = clientContext.Web.Lists.GetByTitle(listName);
                clientContext.Load(list);
                clientContext.Load(list.Fields);
                clientContext.ExecuteQuery();

                IEnumerable<string> cols =
                    (from DataColumn c in items.Columns select @"<FieldRef Name='" + c.ColumnName + "' />");

                var query = new CamlQuery
                    {
                        ViewXml = string.Format(@"
                            <ViewFields>
                                {0}
                            </ViewFields>
                            <Where>
                                <Or>
                                    <Gt>
                                        <FieldRef Name='Created' />
                                        <Value Type='DateTime' IncludeTimeValue='TRUE'>{1}</Value>
                                    </Gt>
                                    <Gt>
                                        <FieldRef Name='Modified' />
                                        <Value Type='DateTime' IncludeTimeValue='TRUE'>{1}</Value>
                                    </Gt>
                                </Or>
                            </Where>
                        ", string.Join(Environment.NewLine, cols), lastSynchDateTime)
                    };

                ListItemCollection itemCollection = list.GetItems(query);
                clientContext.ExecuteQuery();

                FillItemsTable(items, itemCollection, list.Fields);
            }
        }

        public void GetListItemsById(string listName, string itemIds, DataTable items)
        {
            IEnumerable<int> idlist = itemIds.Split(',').Select(id => Convert.ToInt32(id)).Distinct();
            var listItems = new List<ListItem>();
            List list = null;

            using (ClientContext clientContext = GetClientContext())
            {
                list = clientContext.Web.Lists.GetByTitle(listName);
                clientContext.Load(list);
                clientContext.Load(list.Fields);
                clientContext.ExecuteQuery();

                listItems.AddRange(idlist.Select(list.GetItemById));
                foreach (ListItem listItem in listItems)
                {
                    clientContext.Load(listItem);
                }
                clientContext.ExecuteQuery();
            }

            FillItemsTable(items, listItems, list.Fields);
        }

        public void InstallIntegration(Guid integrationId, string integrationKey, string apiUrl, string webTitle,
                                       string webUrl, ArrayList enabledFeatures, string listName, bool allowIncoming,
                                       bool allowOutgoing, bool allowDeletion)
        {
            using (ClientContext clientContext = GetClientContext())
            {
                List list = clientContext.Web.Lists.GetByTitle(INT_LIST);
                ListItem listItem = list.AddItem(new ListItemCreationInformation());

                listItem["O365List"] = listName;
                listItem["AllowIncoming"] = allowIncoming;
                listItem["AllowOutgoing"] = allowOutgoing;
                listItem["AllowDeletion"] = allowDeletion;
                listItem["Active"] = true;
                listItem["IntID"] = integrationId.ToString();
                listItem["ControlButtons"] = GetControlButtons(enabledFeatures);
                listItem["APIEndpoint"] = apiUrl;
                listItem["IntKey"] = integrationKey;
                listItem["EPMWeb"] = webTitle;
                listItem["EPMWebUrl"] = webUrl;

                listItem.Update();
                clientContext.ExecuteQuery();
            }
        }

        public void UninstallIntegration(string integrationKey, Guid integrationId)
        {
            using (ClientContext clientContext = GetClientContext())
            {
                List list = clientContext.Web.Lists.GetByTitle(INT_LIST);
                clientContext.Load(list);

                ListItemCollection listItemCollection = list.GetItems(new CamlQuery());
                clientContext.Load(listItemCollection);

                clientContext.ExecuteQuery();

                string intKey = _cryptographyService.Encrypt(integrationKey);
                string intId = _cryptographyService.Encrypt(integrationId.ToString());

                foreach (ListItem listItem in listItemCollection.ToList()
                                                                .Where(
                                                                    i =>
                                                                    ((string) i["IntKey"]).Equals(intKey) &&
                                                                    ((string) i["IntID"]).Equals(intId)))
                {
                    listItem.DeleteObject();
                    clientContext.ExecuteQuery();
                    break;
                }
            }
        }

        public IEnumerable<O365Result> UpsertItems(string listName, Guid integrationId, DataTable items)
        {
            var o365Results = new List<O365Result>();

            IEnumerable<string> columns = from DataColumn dataColumn in items.Columns select dataColumn.ColumnName;
            IEnumerable<string> fields = columns as string[] ?? columns.ToArray();

            if (fields.Any())
            {
                foreach (DataRow dataRow in items.Rows)
                {
                    int itemId = 0;
                    TransactionType transactionType;

                    GetIdAndTranType(dataRow, out transactionType, ref itemId);

                    try
                    {
                        var fieldsElement = new XElement("Fields");

                        foreach (string field in fields)
                        {
                            string value = string.Empty;

                            object val = dataRow[field];
                            if (val != null && val != DBNull.Value)
                            {
                                value = val.ToString();
                            }

                            fieldsElement.Add(new XElement("Field", new XAttribute("Name", field), new XCData(value)));
                        }

                        using (ClientContext clientContext = GetClientContext())
                        {
                            List list = clientContext.Web.Lists.GetByTitle(INCOMING_LIST);

                            ListItem listItem = list.AddItem(new ListItemCreationInformation());

                            listItem["IntID"] = integrationId;
                            listItem["Title"] = listName;
                            listItem["Data"] = fieldsElement.ToString();

                            listItem.Update();
                            clientContext.ExecuteQuery();

                            itemId = GetItemId(listItem, clientContext);
                        }

                        o365Results.Add(new O365Result(itemId, transactionType));
                    }
                    catch (Exception e)
                    {
                        o365Results.Add(new O365Result(itemId, transactionType, false, e.Message));
                    }
                }
            }

            return o365Results;
        }

        // Private Methods (10) 

        private void FillItemsTable(DataTable items, IEnumerable<ListItem> resultItems, IEnumerable<Field> listFields)
        {
            var userFields = new List<string>();
            var multiUserFields = new List<string>();
            var lookupFields = new List<string>();
            var multLookupFields = new List<string>();

            foreach (Field field in listFields)
            {
                string internalName = field.InternalName;

                switch (field.FieldTypeKind)
                {
                    case FieldType.User:
                        var userField = (FieldUser) field;

                        if (userField.AllowMultipleValues)
                        {
                            multiUserFields.Add(internalName);
                        }
                        else
                        {
                            userFields.Add(internalName);
                        }

                        break;
                    case FieldType.Lookup:
                        {
                            var lookupField = (FieldLookup) field;

                            if (lookupField.AllowMultipleValues)
                            {
                                multLookupFields.Add(internalName);
                            }
                            else
                            {
                                lookupFields.Add(internalName);
                            }
                        }

                        break;
                }
            }

            foreach (ListItem listItem in resultItems)
            {
                DataRow dataRow = items.NewRow();

                foreach (string columnName in from DataColumn dataColumn in items.Columns select dataColumn.ColumnName)
                {
                    dataRow[columnName] = GetFieldValue(listItem, columnName, userFields, multiUserFields, lookupFields,
                                                        multLookupFields);
                }

                items.Rows.Add(dataRow);
            }
        }

        private void FillListFields(DataTable items, List<string> fields)
        {
            foreach (string col in items.Columns.Cast<DataColumn>()
                                        .Select(c => c.ColumnName)
                                        .Where(c => !c.ToLower().Equals("id") && !fields.Contains(c)))
            {
                fields.Add(col);
            }
        }

        private ClientContext GetClientContext()
        {
            return GetClientContext(_siteUrl);
        }

        private ClientContext GetClientContext(string siteUrl)
        {
            int tries = 0;

            while (true)
            {
                Debug.WriteLine("*** O365 Adapter: Connecting to: {0}. Try #{1}.", siteUrl, tries + 1);

                try
                {
                    return TryGetClientContext(siteUrl);
                }
                catch (Exception e)
                {
                    if (!e.Message.Contains("The remote name could not be resolved"))
                    {
                        throw;
                    }

                    if (++tries == 5)
                    {
                        throw;
                    }

                    Thread.Sleep(5000);
                }
            }
        }

        private static string GetControlButtons(ArrayList enabledFeatures)
        {
            var ribbonButtons = new List<string>();

            foreach (string feature in enabledFeatures)
            {
                switch (feature.ToLower())
                {
                    case "workplan":
                        ribbonButtons.Add("WorkPlan");
                        break;
                    case "comments":
                        ribbonButtons.Add("Comments");
                        break;
                    case "associated":
                        ribbonButtons.Add("Associated");
                        break;
                    case "costplan":
                        ribbonButtons.Add("CostPlan");
                        break;
                    case "resplan":
                        ribbonButtons.Add("ResPlan");
                        break;
                    case "team":
                        ribbonButtons.Add("Team");
                        break;
                }
            }

            return string.Join(",", ribbonButtons.ToArray());
        }

        private object GetFieldValue(ListItem listItem, string columnName, List<string> userFields,
                                     List<string> multiUserFields,
                                     List<string> lookupFields, List<string> multLookupFields)
        {
            object value = listItem.FieldValues[columnName];

            if (userFields.Contains(columnName))
            {
                value = GetUserValue((FieldUserValue) value);
            }
            else if (multiUserFields.Contains(columnName))
            {
                value = string.Join(",", (from v in (object[]) value select GetUserValue((FieldUserValue) v)).ToArray());
            }
            else if (lookupFields.Contains(columnName))
            {
                value = ((FieldLookupValue) value).LookupId;
            }
            else if (multLookupFields.Contains(columnName))
            {
                value = string.Join(",", (from v in (object[]) value select ((FieldLookupValue) v).LookupId).ToArray());
            }

            return value;
        }

        private static void GetIdAndTranType(DataRow dataRow, out TransactionType transactionType, ref int itemId)
        {
            object o365Id = dataRow["ID"];
            if (o365Id == null || o365Id == DBNull.Value || string.IsNullOrEmpty(o365Id.ToString()))
            {
                transactionType = TransactionType.INSERT;
            }
            else
            {
                itemId = Convert.ToInt32(o365Id);
                transactionType = TransactionType.UPDATE;
            }
        }

        private static int GetItemId(ListItem listItem, ClientContext clientContext)
        {
            int itemId = 0;
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            bool processed = false;
            while (!processed)
            {
                if (stopwatch.Elapsed.Minutes >= 3)
                {
                    listItem.DeleteObject();
                    clientContext.ExecuteQuery();

                    stopwatch.Stop();
                    throw new Exception("Transection process timed out.");
                }

                clientContext.Load(listItem);
                clientContext.ExecuteQuery();

                bool.TryParse((listItem["Processed"] ?? string.Empty).ToString(), out processed);

                if (processed)
                {
                    bool success;
                    bool.TryParse((listItem["Success"] ?? string.Empty).ToString(), out success);

                    if (success)
                    {
                        string itmId = (listItem["ItemID"] ?? string.Empty).ToString();
                        if (!string.IsNullOrEmpty(itmId))
                        {
                            itemId = Convert.ToInt32(itmId);

                            listItem.DeleteObject();
                            clientContext.ExecuteQuery();
                        }
                    }
                    else
                    {
                        throw new Exception((listItem["Error"] ?? string.Empty).ToString());
                    }
                }

                Thread.Sleep(1000);
            }

            return itemId;
        }

        private string GetUserValue(FieldUserValue user)
        {
            if (_userEmails.ContainsKey(user.LookupId)) return _userEmails[user.LookupId];

            string email = string.Empty;

            using (ClientContext clientContext = GetClientContext())
            {
                List list = clientContext.Web.Lists.GetByTitle("User Information List");
                clientContext.Load(list);
                clientContext.ExecuteQuery();

                if (list != null && list.ItemCount > 0)
                {
                    var query = new CamlQuery
                        {
                            ViewXml =
                                @"<View><Query><Where><Eq><FieldRef Name='ID' /><Value Type='Counter'>" + user.LookupId +
                                "</Value></Eq></Where></Query><ViewFields><FieldRef Name='EMail' /></ViewFields></View>"
                        };

                    ListItemCollection listItems = list.GetItems(query);
                    clientContext.Load(listItems);
                    clientContext.ExecuteQuery();

                    if (listItems.Any())
                    {
                        email = (listItems.First()["EMail"] ?? string.Empty).ToString();
                        _userEmails.Add(user.LookupId, email);
                    }
                }
            }

            return email;
        }

        private ClientContext TryGetClientContext(string siteUrl)
        {
            return new ClientContext(siteUrl)
                {
                    Credentials = new SharePointOnlineCredentials(_username, _password),
                    RequestTimeout = 300000
                };
        }

        #endregion Methods 
    }
}