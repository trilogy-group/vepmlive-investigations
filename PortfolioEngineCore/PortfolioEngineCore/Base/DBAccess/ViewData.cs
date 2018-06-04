using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PortfolioEngineCore.Base.DBAccess
{
    public static class ViewData
    {
        private const string InsertViewDataQuery = "INSERT INTO EPG_VIEWS (VIEW_GUID,VIEW_NAME,WRES_ID,VIEW_DEFAULT,VIEW_DATA,VIEW_CONTEXT) VALUES(@guid,@name,@wres,@def,@data,@context)";
        private const string SelectViewByNameDataQuery = "SELECT VIEW_DATA FROM EPG_VIEWS WHERE VIEW_CONTEXT = @context AND VIEW_NAME = @name";
        private const string UpdateViewByNameDataQuery = "UPDATE EPG_VIEWS SET VIEW_DATA = @data WHERE VIEW_CONTEXT = @context AND VIEW_NAME = @name";
        private const string DeleteViewByNameDataQuery = "DELETE FROM EPG_VIEWS WHERE VIEW_CONTEXT = @context AND VIEW_NAME = @name";
        private const string ContextParameter = "@context";
        private const string DataParameter = "@data";
        private const string NameParameter = "@name";
        private const string ViewIdParameter = "@guid";
        private const string ViewIsDefaultParameter = "@def";
        private const string ViewResourceParameter = "@wres";
        private const string ViewDataColumn = "VIEW_DATA";

        public static bool DeleteViewByName(PortfolioEngineCore.DBAccess dba, ViewDataContext context, string viewName)
        {
            using (var sqlCommand = new SqlCommand(DeleteViewByNameDataQuery, dba.Connection, dba.Transaction))
            {
                sqlCommand.Parameters.AddWithValue(ContextParameter, context);
                sqlCommand.Parameters.AddWithValue(NameParameter, viewName);
                sqlCommand.ExecuteNonQuery();
            }

            return true;
        }

        public static string[] GetViewXmlByName(PortfolioEngineCore.DBAccess dba, ViewDataContext context, string viewName)
        {
            var results = new List<string>();
            using (var sqlCommand = new SqlCommand(SelectViewByNameDataQuery, dba.Connection, dba.Transaction))
            {
                sqlCommand.Parameters.AddWithValue(ContextParameter, context);
                sqlCommand.Parameters.AddWithValue(NameParameter, viewName);
                var reader = sqlCommand.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        var viewDataXml = SqlDb.ReadStringValue(reader[ViewDataColumn]);
                        if (!string.IsNullOrWhiteSpace(viewDataXml))
                        {
                            results.Add(viewDataXml);
                        }
                    }
                }
                finally
                {
                    reader.Close();
                }
            }

            return results.ToArray();
        }

        public static bool SaveViewXmlByName(PortfolioEngineCore.DBAccess dba, ViewDataContext context, string viewName, string viewData)
        {
            using (var sqlCommandUpdate = new SqlCommand(UpdateViewByNameDataQuery, dba.Connection, dba.Transaction))
            {
                sqlCommandUpdate.Parameters.AddWithValue(DataParameter, viewData);
                sqlCommandUpdate.Parameters.AddWithValue(ContextParameter, context);
                sqlCommandUpdate.Parameters.AddWithValue(NameParameter, viewName);
                var rowsAffected = sqlCommandUpdate.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return true;
                }

                using (var sqlCommandInsert = new SqlCommand(InsertViewDataQuery, dba.Connection, dba.Transaction))
                {
                    sqlCommandInsert.Parameters.AddWithValue(ViewIdParameter, Guid.NewGuid());
                    sqlCommandInsert.Parameters.AddWithValue(NameParameter, viewName);
                    sqlCommandInsert.Parameters.AddWithValue(ViewResourceParameter, 0);
                    sqlCommandInsert.Parameters.AddWithValue(ViewIsDefaultParameter, 0);
                    sqlCommandInsert.Parameters.AddWithValue(DataParameter, viewData);
                    sqlCommandInsert.Parameters.AddWithValue(ContextParameter, context);
                    sqlCommandInsert.ExecuteNonQuery();
                }
            }

            return true;
        }
    }
}