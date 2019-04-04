using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;

namespace EPMLiveIntegration
{
    public enum IntegrationLogType { Information = 1, Event = 2, Warning=10, Error=20};

    public class IntegrationLog
    {
        private SqlConnection _cn;
        private Guid _intlogid;
        private Guid _listid;
        private string _title;
        public bool LocalLog = false;

        public IntegrationLog(SqlConnection CN, Guid intlogid, Guid listid, string title)
        {
            _cn = CN;
            _intlogid = intlogid;
            _listid = listid;
            _title = title;
        }

        public void LogMessage(string log, IntegrationLogType level)
        {
            if (LocalLog)
            {
                using (var streamWriter = new StreamWriter("log.txt", true))
                {
                    streamWriter.WriteLine("{0}\t{1}\t{2}", DateTime.Now, level, log);
                }
            }
            else
            {
                if (_cn.State == System.Data.ConnectionState.Closed)
                    _cn.Open();

                using (var cmdError = new SqlCommand("INSERT INTO INT_LOG (INT_LIST_ID, LIST_ID, LOGTYPE, LOGTEXT) VALUES (@intlistid, @listid, @level, @text)", _cn))
                {
                    cmdError.Parameters.AddWithValue("@intlistid", _intlogid);
                    cmdError.Parameters.AddWithValue("@listid", _listid);
                    cmdError.Parameters.AddWithValue("@level", (int)level);
                    cmdError.Parameters.AddWithValue("@text", $"{_title}: {log}");
                    cmdError.ExecuteNonQuery();
                }

                _cn.Close();
            }
        }
    }
}
