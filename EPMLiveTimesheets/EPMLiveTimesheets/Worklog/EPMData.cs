using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.SharePoint;

namespace TimeSheets
{
    public abstract class EPMData : IDisposable
    {
        private string _connectionString;
        private string _command;
        private CommandType _commandType = CommandType.Text;
        private SqlConnection _conEPMLive;
        private List<SqlParameter> _params = new List<SqlParameter>();
        private string _sqlError;
        private bool _sqlErrorOccurred;

        protected EPMData()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate(){
                _connectionString = EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id);
            });
        }

        protected EPMData(Guid siteId)
        {
            _connectionString = EPMLiveCore.CoreFunctions.getConnectionString(siteId);
        }

        protected string Command
        {
            get { return _command; }
            set { _command = value; }
        }

        protected CommandType CommandType
        {
            get { return _commandType; }
            set { _commandType = value; }
        }

        protected List<SqlParameter> Params
        {
            get { return _params; }
            set { _params = value; }
        }

        public string SqlError
        {
            get { return _sqlError; }
        }

        public bool SqlErrorOccurred
        {
            get { return _sqlErrorOccurred; }
        }

        protected SqlConnection EPMLiveConnection
        {
            get
            {
                if (_conEPMLive == null)
                {
                    _conEPMLive = new SqlConnection(_connectionString);
                }
                if (_conEPMLive.State != ConnectionState.Open)
                    try
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate
                                                                 {
                                                                     if (_conEPMLive.State == ConnectionState.Closed)
                                                                     {
                                                                         _conEPMLive.Open();
                                                                     }
                                                                 });
                    }
                    catch (Exception ex)
                    {
                        Trace.Write(ex.Message);
                    }
                return _conEPMLive;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            SPSecurity.RunWithElevatedPrivileges(
                () =>
                    {
                        if (_conEPMLive != null && _conEPMLive.State == ConnectionState.Open)
                            _conEPMLive.Close();
                    });
        }

        #endregion

        protected void AddParam(string name, object value)
        {
            _params.Add(new SqlParameter(name, value));
        }

        protected object ExecuteScalar()
        {
            try
            {
                object value;
                using (var command = new SqlCommand {CommandType = _commandType, CommandText = _command, Connection = EPMLiveConnection})
                {
                    command.Parameters.AddRange(_params.ToArray());
                    value = command.ExecuteScalar();
                }
                return value;
            }
            catch (SqlException ex)
            {
                Trace.Write(ex.Message);
                _sqlErrorOccurred = true;
                _sqlError = ex.Message;
                return false;
            }
            finally
            {
                Cleanse();
            }
        }

        protected bool ExecuteNonQuery()
        {
            try
            {
                using (var command = new SqlCommand {CommandType = _commandType, CommandText = (_command), Connection = EPMLiveConnection})
                {
                    command.Parameters.AddRange(_params.ToArray());
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Trace.Write(ex.Message);
                _sqlErrorOccurred = true;
                _sqlError = ex.Message;
                return false;
            }
            finally
            {
                Cleanse();
            }
            return true;
        }

        public DataRow GetRow()
        {
            DataTable table = GetTable();
            return table.Rows.Count == 0 ? null : table.Rows[0];
        }

        public DataTable GetTable()
        {
            return GetTable(false);
        }

        public DataTable GetTable(bool getFullSchema)
        {
            try
            {
                SqlDataAdapter da;
                using (var command = new SqlCommand {CommandType = _commandType, CommandText = _command, Connection = EPMLiveConnection})
                {
                    command.Parameters.AddRange(_params.ToArray());
                    da = new SqlDataAdapter(command);
                }
                var dt = new DataTable();
                if (getFullSchema)
                    da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (SqlException ex)
            {
                Trace.Write(ex.Message);
                _sqlErrorOccurred = true;
                _sqlError = ex.Message;
                return null;
            }
            finally
            {
                Cleanse();
            }
        }

        private void Cleanse()
        {
            _command = null;
            _params.Clear();
            _commandType = CommandType.Text;
        }
    }
}