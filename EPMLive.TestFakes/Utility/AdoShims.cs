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

        public IList<SqlConnection> ConnectionsDisposed { get; private set; }
        public IList<SqlCommand> CommandsCreated { get; private set; }
        public IList<SqlCommand> CommandsDisposed { get; private set; }
        public IDictionary<SqlCommand, SqlDataReader> DataReadersCreated { get; private set; }
        public IDictionary<SqlCommand, SqlDataReader> DataReadersDisposed { get; private set; }
        public IDictionary<SqlCommand, SqlDataAdapter> DataAdaptersCreated { get; private set; }
        public IDictionary<SqlCommand, SqlDataAdapter> DataAdaptersDisposed { get; private set; }

        private AdoShims()
        {
            ConnectionShim = new ShimSqlConnection();

            ConnectionsDisposed = new List<SqlConnection>();
            CommandsCreated = new List<SqlCommand>();
            CommandsDisposed = new List<SqlCommand>();
            DataReadersCreated = new Dictionary<SqlCommand, SqlDataReader>();
            DataReadersDisposed = new Dictionary<SqlCommand, SqlDataReader>();
            DataAdaptersCreated = new Dictionary<SqlCommand, SqlDataAdapter>();
            DataAdaptersDisposed = new Dictionary<SqlCommand, SqlDataAdapter>();
        }

        public static AdoShims ShimAdoNetCalls()
        {
            var result = new AdoShims();
            result.InitializeStaticShims();

            return result;
        }

        private void InitializeStaticShims()
        {
            ShimEPMData.ConstructorGuid = (instance, siteId) => { };
            ShimCoreFunctions.getConfigSettingSPWebString = (web, name) => string.Empty;

            ShimSqlConnection.AllInstances.Open = instance => { };

            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                var result = new ShimSqlDataReader();

                DataReadersCreated.Add(instance, result.Instance);
                return result;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance => 1;
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) =>
            {
                instance.CommandText = commandText;
                instance.Connection = connection;
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
                if (instance is SqlConnection)
                {
                    ConnectionsDisposed.Add((instance as SqlConnection));
                }
                if (instance is SqlCommand)
                {
                    CommandsDisposed.Add((instance as SqlCommand));
                }
                if (instance is SqlDataAdapter)
                {
                    DataAdaptersDisposed.Add(
                        DataAdaptersCreated.Single(pred => pred.Value == instance as SqlDataAdapter));
                }
            };
        }
    }
}
