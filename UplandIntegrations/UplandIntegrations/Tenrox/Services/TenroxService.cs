using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security;
using System.ServiceModel;
using EPMLiveIntegration;
using UplandIntegrations.Tenrox.Infrastructure;
using UplandIntegrations.TenroxAuthService;
using UplandIntegrations.TenroxDataService;
using UplandIntegrations.TenroxProjectService;
using UserToken = UplandIntegrations.TenroxAuthService.UserToken;

namespace UplandIntegrations.Tenrox.Services
{
    internal class TenroxService
    {
        #region Fields (3) 

        private readonly HttpBindingBase _binding;
        private readonly string _svcUrl;
        private readonly UserToken _token;

        #endregion Fields 

        #region Constructors (1) 

        public TenroxService(string orgUrl, string orgName, string username, SecureString password)
        {
            ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };

            try
            {
                _svcUrl = string.Format(@"{0}{1}twebservice/", orgUrl, orgUrl.EndsWith("/") ? string.Empty : "/");

                BasicHttpSecurityMode mode = orgUrl.StartsWith("https", StringComparison.InvariantCultureIgnoreCase)
                    ? BasicHttpSecurityMode.Transport
                    : BasicHttpSecurityMode.None;

                if (mode == BasicHttpSecurityMode.Transport)
                {
                    _binding = new BasicHttpsBinding(BasicHttpsSecurityMode.Transport)
                    {
                        MaxBufferSize = int.MaxValue,
                        MaxReceivedMessageSize = int.MaxValue
                    };
                }
                else
                {
                    _binding = new BasicHttpBinding(mode)
                    {
                        MaxBufferSize = int.MaxValue,
                        MaxReceivedMessageSize = int.MaxValue
                    };
                }

                var authEndpoint = new EndpointAddress(_svcUrl + "logonas.svc");
                using (var authService = new LogonAsClient(_binding, authEndpoint))
                {
                    _token = authService.Authenticate(orgName, username, password.ToUnsecureString(), null, true);
                }
            }
            catch (Exception exception)
            {
                Exception ex = exception;

                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

                throw ex;
            }
        }

        #endregion Constructors 

        #region Methods (10) 

        // Public Methods (4) 

        public IEnumerable<TenroxTransactionResult> DeleteItems(string objectName, int[] itemIds, Guid integrationId)
        {
            return GetManager(objectName).DeleteItems(itemIds, integrationId);
        }

        public List<ColumnProperty> GetObjectFields(string objectName)
        {
            return GetManager(objectName).GetColumns();
        }

        public void GetObjectItemsById(string objectName, string itemId, DataTable items)
        {
            List<string> columns = (from DataColumn column in items.Columns select column.ColumnName).ToList();

            IObjectManager objectManager = GetManager(objectName);
            foreach (TenroxObject txObject in objectManager.GetItems(GetIds(itemId).ToArray()))
            {
                object item = txObject.Item;
                if (item == null) continue;

                DataRow row = items.NewRow();

                foreach (string column in columns)
                {
                    try
                    {
                        object value;

                        switch (column)
                        {
                            case "SPID":
                                value = GetValue(item, "Id");
                                break;
                            case "ID":
                                value = GetValue(item, "UniqueId");
                                break;
                            default:
                                value = GetValue(item, column);
                                break;
                        }

                        row[column] = value;
                    }
                    catch { }
                }

                PopulateUserFields(objectName, txObject, row, objectManager);
                GetTimesheetHours(objectName, itemId, columns, row);

                items.Rows.Add(row);
            }
        }

        public IEnumerable<TenroxTransactionResult> UpsertItems(string objectName, DataTable items, Guid integrationId)
        {
            return GetManager(objectName).UpsertItems(items, integrationId);
        }

        // Private Methods (6) 

        private static IEnumerable<int> GetIds(string itemId)
        {
            foreach (string id in itemId.Split(','))
            {
                int i;
                if (int.TryParse(id, out i))
                {
                    yield return i;
                }
            }
        }

        private IObjectManager GetManager(string objectName)
        {
            return ObjectManagerFactory.GetManager(objectName, _binding, _svcUrl, _token);
        }

        private void GetTimesheetHours(string objectName, string itemId, List<string> columns, DataRow row)
        {
            try
            {
                if (!objectName.Trim().ToLower().Equals("task")) return;
                if (!columns.Contains("TimesheetHours") && !columns.Contains("TimesheetBillableHours")) return;

                using (var client = new ExecuteStoredProcedureClient(_binding,
                    new EndpointAddress(_svcUrl + "/sdk/executestoredprocedure.svc")))
                {
                    var token =
                        (TenroxDataService.UserToken)
                            TranslateToken(_token, typeof (TenroxDataService.UserToken));

                    DataTable dataTable = client.RunStoredProcedure(token, "TIMEQBYTASKFORUPDTS", null);

                    EnumerableRowCollection<DataRow> rows = dataTable.AsEnumerable();

                    decimal tsHours = -1;
                    decimal tsBillableHours = -1;

                    foreach (
                        DataRow dataRow in from r in rows where r["TASKUID"].ToString().Equals(itemId) select r)
                    {
                        decimal tsTime;
                        if (decimal.TryParse(dataRow["TOTALTIME"].ToString(), out tsTime))
                        {
                            if (tsHours == -1) tsHours = 0;
                            tsHours += tsTime;
                        }

                        decimal tsBillableTime;
                        if (decimal.TryParse(dataRow["BILLABLETIME"].ToString(), out tsBillableTime))
                        {
                            if (tsBillableHours == -1) tsBillableHours = 0;
                            tsBillableHours += tsBillableTime;
                        }
                    }

                    if (tsHours > -1)
                    {
                        row["TimesheetHours"] = tsHours;
                    }

                    if (tsBillableHours > -1)
                    {
                        row["TimesheetBillableHours"] = tsBillableHours;
                    }
                }
            }
            catch { }
        }

        private static object GetValue(object item, string property)
        {
            return item.GetType().GetProperty(property).GetValue(item);
        }

        private static void PopulateUserFields(string objectName, TenroxObject txObject, DataRow row,
            IObjectManager objectManager)
        {
            try
            {
                if (!objectName.Trim().ToLower().Equals("project")) return;

                int managerId = ((Project) txObject.Item).ManagerId;

                if (managerId == 0)
                {
                    row["ManagerId"] = string.Empty;
                }
                else
                {
                    row["ManagerId"] = objectManager.TranslateIdToUserEmail(managerId);
                }
            }
            catch { }
        }

        private object TranslateToken(UserToken token, Type tokenType)
        {
            object newToken = Activator.CreateInstance(tokenType);

            foreach (PropertyInfo property in typeof (UserToken).GetProperties())
            {
                try
                {
                    newToken.GetType().GetProperty(property.Name).SetValue(newToken, property.GetValue(token));
                }
                catch { }
            }

            foreach (FieldInfo field in typeof (UserToken).GetFields())
            {
                try
                {
                    newToken.GetType().GetField(field.Name).SetValue(newToken, field.GetValue(token));
                }
                catch { }
            }

            return newToken;
        }

        #endregion Methods 

        public void GetObjectItemsByDate(string objectName, DateTime lastSynchDate, DataTable items)
        {
            if (!objectName.ToLower().Equals("project")) return;

            List<string> columns = (from DataColumn column in items.Columns select column.ColumnName).ToList();

            IObjectManager objectManager = GetManager(objectName);
            foreach (TenroxObject txObject in objectManager.GetItemsByDate(lastSynchDate))
            {
                object item = txObject.Item;
                if (item == null) continue;

                DataRow row = items.NewRow();

                foreach (string column in columns)
                {
                    try
                    {
                        object value;

                        switch (column)
                        {
                            case "SPID":
                                value = GetValue(item, "Id");
                                break;
                            case "ID":
                                value = GetValue(item, "UniqueId");
                                break;
                            default:
                                value = GetValue(item, column);
                                break;
                        }

                        row[column] = value;
                    }
                    catch { }
                }

                PopulateUserFields(objectName, txObject, row, objectManager);
                GetTimesheetHours(objectName, txObject.ItemId.ToString(CultureInfo.InvariantCulture), columns, row);

                items.Rows.Add(row);
            }
        }
    }
}