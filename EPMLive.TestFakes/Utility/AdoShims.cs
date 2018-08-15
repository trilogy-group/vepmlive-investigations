using System;
using System.Collections.Generic;
using System.ComponentModel.Fakes;
using System.Data.Common.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportHelper.Fakes;

namespace EPMLive.TestFakes.Utility
{
    public class AdoShims
    {
        public ShimSqlConnection ConnectionShim { get; private set; }

        public IList<SqlConnection> ConnectionsCreated { get; private set; }
        public IList<SqlConnection> ConnectionsOpened { get; private set; }
        public IList<SqlConnection> ConnectionsClosed { get; private set; }
        public IList<SqlConnection> ConnectionsDisposed { get; private set; }
        public IList<SqlCommand> CommandsCreated { get; private set; }
        public IList<SqlCommand> CommandsExecuted { get; private set; }
        public IList<SqlCommand> CommandsDisposed { get; private set; }
        public IDictionary<SqlCommand, SqlDataReader> DataReadersCreated { get; private set; }
        public IDictionary<SqlCommand, SqlDataReader> DataReadersDisposed { get; private set; }
        public IDictionary<SqlCommand, SqlDataAdapter> DataAdaptersCreated { get; private set; }
        public IDictionary<SqlCommand, SqlDataAdapter> DataAdaptersDisposed { get; private set; }

        private IDictionary<SqlConnection, string> _sqlConnectionStringsByConnection;

        private AdoShims()
        {
            ConnectionShim = new ShimSqlConnection();

            ConnectionsCreated = new List<SqlConnection>();
            ConnectionsOpened = new List<SqlConnection>();
            ConnectionsClosed = new List<SqlConnection>();
            ConnectionsDisposed = new List<SqlConnection>();
            CommandsCreated = new List<SqlCommand>();
            CommandsExecuted = new List<SqlCommand>();
            CommandsDisposed = new List<SqlCommand>();
            DataReadersCreated = new Dictionary<SqlCommand, SqlDataReader>();
            DataReadersDisposed = new Dictionary<SqlCommand, SqlDataReader>();
            DataAdaptersCreated = new Dictionary<SqlCommand, SqlDataAdapter>();
            DataAdaptersDisposed = new Dictionary<SqlCommand, SqlDataAdapter>();

            _sqlConnectionStringsByConnection = new Dictionary<SqlConnection, string>();
        }

        public static AdoShims ShimAdoNetCalls()
        {
            var result = new AdoShims();
            result.InitializeStaticShims();

            return result;
        }

        public bool IsConnectionManagedCorrectly(string connectionString)
        {
            return IsConnectionCreated(connectionString)
                && IsConnectionOpened(connectionString)
                && IsConnectionDisposed(connectionString);
        }

        public bool IsConnectionCreated(string connectionString)
        {
            return ConnectionsCreated.Any(pred => pred.ConnectionString == connectionString);
        }

        public bool IsConnectionOpened(string connectionString)
        {
            return ConnectionsOpened.Any(pred => pred.ConnectionString == connectionString);
        }

        public bool IsConnectionDisposed(string connectionString)
        {
            return ConnectionsDisposed.Any(pred => pred.ConnectionString == connectionString);
        }

        public bool IsCommandCreated(string commandText)
        {
            return CommandsCreated.Any(pred => pred.CommandText == commandText);
        }

        public bool IsCommandExecuted(string commandText)
        {
            return CommandsExecuted.Any(pred => pred.CommandText == commandText);
        }

        public bool IsCommandDisposed(string commandText)
        {
            return CommandsDisposed.Any(pred => pred.CommandText == commandText);
        }

        public bool IsDataReaderCreatedForCommand(string commandText)
        {
            return DataReadersCreated.Any(pred => pred.Key.CommandText == commandText);
        }

        public bool IsDataReaderDisposedForCommand(string commandText)
        {
            return DataReadersDisposed.Any(pred => pred.Key.CommandText == commandText);
        }

        private void InitializeStaticShims()
        {
            ShimEPMData.ConstructorGuid = (instance, siteId) => { };
            ShimCoreFunctions.getConfigSettingSPWebString = (web, name) => string.Empty;

            ShimSqlConnection.Constructor = instance =>
            {
                ConnectionsCreated.Add(instance);
                _sqlConnectionStringsByConnection.Add(instance, string.Empty);
            };
            ShimSqlConnection.ConstructorString = (instance, connectionString) =>
            {
                ConnectionsCreated.Add(instance);
                _sqlConnectionStringsByConnection.Add(instance, connectionString);
            };
            ShimSqlConnection.ConstructorStringSqlCredential = (instance, connectionString, sqlCredential) =>
            {
                ConnectionsCreated.Add(instance);
                _sqlConnectionStringsByConnection.Add(instance, connectionString);
            };
            ShimSqlConnection.AllInstances.ConnectionStringGet = instance =>
            {
                return _sqlConnectionStringsByConnection.ContainsKey(instance)
                    ? _sqlConnectionStringsByConnection[instance]
                    : null;
            };
            ShimSqlConnection.AllInstances.Open = instance =>
            {
                ConnectionsOpened.Add(instance);
            };
            ShimSqlConnection.AllInstances.Close = instance =>
            {
                ConnectionsClosed.Add(instance);
            };
            ShimSqlConnection.AllInstances.StateGet = instance => System.Data.ConnectionState.Open;

            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                instance.CommandText = commandText;
                instance.Connection = connection;
                CommandsCreated.Add(instance);
            };
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                var result = new ShimSqlDataReader();

                DataReadersCreated.Add(instance, result.Instance);
                CommandsExecuted.Add(instance);
                return result;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                CommandsExecuted.Add(instance);
                return 1;
            };
            ShimSqlCommand.AllInstances.ExecuteScalar = instance =>
            {
                CommandsExecuted.Add(instance);
                return 1;
            };
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                instance.CommandText = commandText;
                instance.Connection = connection;
                CommandsCreated.Add(instance);
            };
            ShimSqlCommand.ConstructorString = (instance, commandText) =>
            {
                instance.CommandText = commandText;
                CommandsCreated.Add(instance);
            };

            ShimDbDataReader.AllInstances.Dispose = instance =>
            {
                if (instance is SqlDataReader)
                {
                    DataReadersDisposed.Add(DataReadersCreated.Single(pred => pred.Value == instance as SqlDataReader));
                }
            };

            ShimSqlDataAdapter.ConstructorSqlCommand = (instance, command) =>
            {
                instance.SelectCommand = command;
                DataAdaptersCreated.Add(command, instance);
            };
            ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
            {
                dataSet.Tables.Add();
                return 1;
            };

            ShimComponent.AllInstances.Dispose = instance =>
            {
                var sqlConnection = instance as SqlConnection;
                if (sqlConnection != null)
                {
                    ConnectionsDisposed.Add(sqlConnection);
                }

                var sqlCommand = instance as SqlCommand;
                if (sqlCommand != null)
                {
                    CommandsDisposed.Add(sqlCommand);
                }

                var sqlDataAdatpter = instance as SqlDataAdapter;
                if (sqlDataAdatpter != null)
                {
                    DataAdaptersDisposed.Add(DataAdaptersCreated.Single(pred => pred.Value == sqlDataAdatpter));
                }
            };
        }
    }
}
