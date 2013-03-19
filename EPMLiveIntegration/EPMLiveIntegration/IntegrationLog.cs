using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace EPMLiveIntegration
{
    public enum IntegrationLogType { Information = 1, Warning, Error };

    public class IntegrationLog
    {
        private SqlConnection _cn;
        private Guid _intlogid;
        private Guid _listid;
        private string _title;

        public IntegrationLog(SqlConnection CN, Guid intlogid, Guid listid, string title)
        {
            _cn = CN;
            _intlogid = intlogid;
            _listid = listid;
            _title = title;
        }

        public void LogMessage(string log, IntegrationLogType level)
        {
            if (_cn.State == System.Data.ConnectionState.Closed)
                _cn.Open();

            SqlCommand cmdError = new SqlCommand("INSERT INTO INT_LOG (INT_LIST_ID, LIST_ID, LOGTYPE, LOGTEXT) VALUES (@intlistid, @listid, @level, @text)", _cn);
            cmdError.Parameters.AddWithValue("@intlistid", _intlogid);
            cmdError.Parameters.AddWithValue("@listid", _listid);
            cmdError.Parameters.AddWithValue("@level", (int)level);
            cmdError.Parameters.AddWithValue("@text", _title + ": " + log);
            cmdError.ExecuteNonQuery();

            _cn.Close();
        }
    }
}
