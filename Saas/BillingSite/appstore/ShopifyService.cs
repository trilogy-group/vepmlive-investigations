using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace BillingSite.appstore
{
    public abstract class ShopifyService : IService
    {
        #region Fields (6) 

        protected readonly string TableName;
        private readonly string _connectionString;
        private readonly WebClient _webClient;
        private bool _disposed;
        private SqlConnection _sqlConnection;
        private IList<string> _tableColumns;

        #endregion Fields 

        #region Constructors (2) 

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopifyService"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="password">The password.</param>
        /// <param name="accountId">The account id.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="connectionString">The connection string.</param>
        protected ShopifyService(string apiKey, string password, string accountId, string tableName,
                                 string connectionString)
        {
            string baseAddress = string.Format("https://{0}:{1}@{2}.myshopify.com/admin/", apiKey, password, accountId);

            _webClient = new WebClient {BaseAddress = baseAddress};
            _webClient.Headers.Add("X-Shopify-Access-Token", password);

            _connectionString = connectionString;
            _tableColumns = null;
            TableName = tableName.Replace("'", "''");
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="ShopifyService"/> is reclaimed by garbage collection.
        /// </summary>
        ~ShopifyService()
        {
            Dispose(false);
        }

        #endregion Constructors 

        #region Properties (2) 

        /// <summary>
        /// Gets the SQL connection.
        /// </summary>
        protected SqlConnection SqlConnection
        {
            get
            {
                if (_sqlConnection != null)
                {
                    if (_sqlConnection.State == ConnectionState.Closed) _sqlConnection.Open();
                }
                else
                {
                    _sqlConnection = new SqlConnection(_connectionString);
                    _sqlConnection.Disposed += SqlConnectionDisposed;
                    _sqlConnection.Open();
                }

                return _sqlConnection;
            }
        }

        /// <summary>
        /// Gets the table columns.
        /// </summary>
        protected IEnumerable<string> TableColumns
        {
            get
            {
                if (_tableColumns == null)
                {
                    _tableColumns = new List<string>();

                    using (SqlConnection)
                    {
                        const string query = "SELECT name FROM sys.columns WHERE object_id = OBJECT_ID(@Table)";
                        using (var sqlCommand = new SqlCommand(query, SqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.Text;
                            sqlCommand.Parameters.AddWithValue("@Table", TableName);

                            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                            while (sqlDataReader.Read())
                            {
                                if(!SystemField(sqlDataReader.GetString(sqlDataReader.GetOrdinal("name"))))
                                    _tableColumns.Add(sqlDataReader.GetString(sqlDataReader.GetOrdinal("name")));
                            }
                        }
                    }
                }

                return _tableColumns.ToArray();
            }
        }

        protected bool SystemField(string field)
        {
            switch (field)
            {
                case "id":
                case "DTADDED":
                    return true;
            }
            return false;
        }

        #endregion Properties 

        #region Methods (3) 

        // Protected Methods (2) 

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _webClient.Dispose();

                if (_sqlConnection != null)
                {
                    if (_sqlConnection.State == ConnectionState.Open)
                    {
                        _sqlConnection.Close();
                    }

                    _sqlConnection.Dispose();
                }
            }

            _disposed = true;
        }

        /// <summary>
        /// Requests the specified URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        protected string Request(Uri uri)
        {
            return _webClient.DownloadString(uri);
        }

        // Private Methods (1) 

        private void SqlConnectionDisposed(object sender, EventArgs e)
        {
            _sqlConnection = null;
        }

        #endregion Methods 

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Implementation of IService

        public abstract string Reterive(string id, IEnumerable<string> fields = null);

        /// <summary>
        /// Saves the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="additionalData">The additional data.</param>
        public virtual void Save(string data, Dictionary<string, string> additionalData)
        {
            var dictionary = new Dictionary<string, string>();

            if (additionalData != null)
            {
                dictionary = additionalData;//;.ToDictionary(d => d.Key, d => d.Value);
            }

            XDocument dataXml = XDocument.Parse(data);

            foreach (string tableColumn in TableColumns)
            {
                if (!dictionary.ContainsKey(tableColumn)) dictionary.Add(tableColumn, string.Empty);

                XElement xElement = dataXml.Descendants(tableColumn).FirstOrDefault();
                if (xElement != null)
                {
                    dictionary[tableColumn] = xElement.Value;
                }
            }

            string query = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", TableName,
                                         string.Join(",", TableColumns.ToArray()),
                                         string.Join(",", TableColumns.Select(c => "@" + c).ToArray()));

            using (SqlConnection)
            {
                using (var sqlCommand = new SqlCommand(query, SqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;

                    foreach (var kvp in dictionary)
                    {
                        sqlCommand.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
                    }

                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        #endregion
    }
}