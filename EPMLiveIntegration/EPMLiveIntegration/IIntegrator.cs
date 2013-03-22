using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace EPMLiveIntegration
{
    public interface IIntegrator
    {
        TransactionTable UpdateItems(WebProperties WebProps, DataTable Items, IntegrationLog Log);

        TransactionTable DeleteItems(WebProperties WebProps, DataTable Items, IntegrationLog Log);

        List<ColumnProperty> GetColumns(WebProperties WebProps, IntegrationLog Log, string ListName);

        DataTable PullData(WebProperties WebProps, IntegrationLog log, DataTable Items, DateTime LastSynchDate);

        DataTable GetItem(WebProperties WebProps, IntegrationLog log, string ItemID, DataTable Items);

        Dictionary<String,String> GetDropDownValues(WebProperties WebProps, IntegrationLog log, string Property, string ParentPropertyValue);

        bool TestConnection(WebProperties WebProps, IntegrationLog Log, out string Message);

        bool InstallIntegration(WebProperties WebProps, IntegrationLog Log, out string Message, string IntegrationKey, string APIUrl);

        bool RemoveIntegration(WebProperties WebProps, IntegrationLog Log, out string Message, string IntegrationKey);
    }

}