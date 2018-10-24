using System;
using System.Data;
using EPMLiveCore.Helpers;
using EPMLiveCore.Properties;

namespace EPMLiveCore.ReportHelper
{
    public partial class ReportData
    {
        public bool InsertLog(Guid listId, string listName, string shortMessage, string longMessage, int type)
        {
            Guard.ArgumentIsNotNull(longMessage, nameof(longMessage));
            Guard.ArgumentIsNotNull(shortMessage, nameof(shortMessage));
            Guard.ArgumentIsNotNull(listName, nameof(listName));
            return _DAO.LogStatus(listId.ToString(), listName, shortMessage, longMessage, type, 1, string.Empty);
        }

        public DataTable GetLog(Guid listId, int minimumLevel)
        {
            _DAO.Command =
                $"select * from [{Resources.ReportingLogTable.Replace(SingleQuote, string.Empty)}] where [Type] >= @Level and [RPTListId] = @RPTListId order by TimeStamp desc ";
            _DAO.AddParam("@RPTListId", listId);
            _DAO.AddParam("@Level", minimumLevel);
            return _DAO.GetTable(_DAO.GetClientReportingConnection);
        }

        public int GetMaximumLogLevel(Guid listId)
        {
            _DAO.Command = $"select * from [{Resources.ReportingListSummaryView.Replace(SingleQuote, string.Empty)}] where [RPTListId] = @RPTListId ";
            _DAO.AddParam("@RPTListId", listId);
            return (int)_DAO.ExecuteScalar(_DAO.GetClientReportingConnection);
        }

        public bool DeleteLog(Guid listId)
        {
            _DAO.Command = $"delete from [{Resources.ReportingLogTable.Replace(SingleQuote, string.Empty)}] where [RPTListId] = @RPTListId ";
            _DAO.AddParam("@RPTListId", listId);
            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public bool DeleteLog(Guid listId, int logType)
        {
            _DAO.Command =
                $"delete from [{Resources.ReportingLogTable.Replace(SingleQuote, string.Empty)}] where [RPTListId] = @RPTListId and [Type] = @LogType";
            _DAO.AddParam("@RPTListId", listId);
            _DAO.AddParam("@LogType", logType);

            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public bool LogStatus(string rptListId, string sListName, string sShortMsg, string sLongMsg, int iLevel, int iType)
        {
            Guard.ArgumentIsNotNull(sLongMsg, nameof(sLongMsg));
            Guard.ArgumentIsNotNull(sShortMsg, nameof(sShortMsg));
            Guard.ArgumentIsNotNull(sListName, nameof(sListName));
            Guard.ArgumentIsNotNull(rptListId, nameof(rptListId));
            return _DAO.LogStatus(rptListId, sListName, sShortMsg, sLongMsg, iLevel, iType, string.Empty);
        }

        public bool LogStatus(Guid rptListId, string sListName, string sShortMsg, string sLongMsg, int iLevel, int iType)
        {
            Guard.ArgumentIsNotNull(sLongMsg, nameof(sLongMsg));
            Guard.ArgumentIsNotNull(sShortMsg, nameof(sShortMsg));
            Guard.ArgumentIsNotNull(sListName, nameof(sListName));
            return _DAO.LogStatus(rptListId.ToString(), sListName, sShortMsg, sLongMsg, iLevel, iType, string.Empty);
        }

        public bool LogStatus(string rptListId, string sListName, string sShortMsg, string sLongMsg, int iLevel, int iType, string timerjobguid)
        {
            Guard.ArgumentIsNotNull(timerjobguid, nameof(timerjobguid));
            Guard.ArgumentIsNotNull(sLongMsg, nameof(sLongMsg));
            Guard.ArgumentIsNotNull(sShortMsg, nameof(sShortMsg));
            Guard.ArgumentIsNotNull(sListName, nameof(sListName));
            Guard.ArgumentIsNotNull(rptListId, nameof(rptListId));
            return _DAO.LogStatus(rptListId, sListName, sShortMsg, sLongMsg, iLevel, iType, timerjobguid);
        }

        public DataTable GetStatusLog()
        {
            return _DAO.GetStatusLog();
        }
    }
}