using System;
using System.Data;
using System.Data.SqlClient;

namespace EPMLiveCore.SocialEngine.Core
{
    internal class TransactionManager : BaseManager
    {
        #region Constructors (1) 

        public TransactionManager(DBConnectionManager dbConnectionManager) : base(dbConnectionManager) { }

        #endregion Constructors 

        #region Methods (3) 

        // Public Methods (3) 

        public void ClearTransaction(Guid transactionId)
        {
            const string SQL = @"DELETE FROM SS_Transactions WHERE Id = @Id";

            using (SqlCommand sqlCommand = GetSqlCommand(SQL))
            {
                sqlCommand.Parameters.AddWithValue("@Id", transactionId);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public Transaction GetTransaction(Guid webId, Guid listId, int itemId)
        {
            const string SQL =
                @"SELECT TOP(1) * FROM SS_Transactions WHERE WebId = @WebId AND ListId = @ListId AND ItemId = @ItemId";

            using (SqlCommand sqlCommand = GetSqlCommand(SQL))
            {
                sqlCommand.Parameters.AddWithValue("@WebId", webId);
                sqlCommand.Parameters.AddWithValue("@ListId", listId);
                sqlCommand.Parameters.AddWithValue("@ItemId", itemId);

                var dt = new DataTable();
                dt.Load(sqlCommand.ExecuteReader());

                if (dt.Rows.Count <= 0) return null;

                EnumerableRowCollection<DataRow> transactions = dt.AsEnumerable();

                foreach (DataRow t in transactions)
                {
                    return
                        new Transaction((Guid) t["Id"], (Guid) t["WebId"], (Guid) t["ListId"], (int) t["ItemId"],
                            (string) t["Component"], (DateTime) t["Time"]);
                }
            }

            return null;
        }

        public Transaction SetTransaction(Guid webId, Guid listId, int itemId, string componentName)
        {
            var transaction = new Transaction(webId, listId, itemId, componentName, DateTime.Now);

            const string SQL =
                @"INSERT INTO SS_Transactions (Id, WebId, ListId, ItemId, Component, Time) VALUES (@Id, @WebId, @ListId, @ItemId, @Component, @Time)";

            using (SqlCommand sqlCommand = GetSqlCommand(SQL))
            {
                sqlCommand.Parameters.AddWithValue("@Id", transaction.Id);
                sqlCommand.Parameters.AddWithValue("@WebId", transaction.WebId);
                sqlCommand.Parameters.AddWithValue("@ListId", transaction.ListId);
                sqlCommand.Parameters.AddWithValue("@ItemId", transaction.ItemId);
                sqlCommand.Parameters.AddWithValue("@Component", transaction.Component);
                sqlCommand.Parameters.AddWithValue("@Time", transaction.Time);

                sqlCommand.ExecuteNonQuery();
            }

            return transaction;
        }

        #endregion Methods 
    }
}