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
            var sqlCommandText = DeleteViewByNameDataQuery;
            var sqlCommand = new SqlCommand(sqlCommandText, dba.Connection, dba.Transaction);
            sqlCommand.Parameters.AddWithValue(ContextParameter, context);
            sqlCommand.Parameters.AddWithValue(NameParameter, viewName);
            sqlCommand.ExecuteNonQuery();
            return true;
        }

        public static string[] GetViewXmlByName(PortfolioEngineCore.DBAccess dba, ViewDataContext context, string viewName)
        {
            var results = new List<string>();
            var sqlCommandText = SelectViewByNameDataQuery;

            var sqlCommand = new SqlCommand(sqlCommandText, dba.Connection, dba.Transaction);
            sqlCommand.Parameters.AddWithValue(ContextParameter, context);
            sqlCommand.Parameters.AddWithValue(NameParameter, viewName);
            var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                string viewDataXml = SqlDb.ReadStringValue(reader[ViewDataColumn]);
                if (!string.IsNullOrWhiteSpace(viewDataXml))
                {
                    results.Add(viewDataXml);
                }
            }

            reader.Close();
            return results.ToArray();
        }

        public static bool SaveViewXmlByName(PortfolioEngineCore.DBAccess dba, ViewDataContext context, string viewName, string viewData)
        {
            var sqlCommandText = UpdateViewByNameDataQuery;
            var sqlCommand = new SqlCommand(sqlCommandText, dba.Connection, dba.Transaction);
            sqlCommand.Parameters.AddWithValue(DataParameter, viewData);
            sqlCommand.Parameters.AddWithValue(ContextParameter, context);
            sqlCommand.Parameters.AddWithValue(NameParameter, viewName);
            int nRowsAffected = sqlCommand.ExecuteNonQuery();

            if (nRowsAffected == 0)
            {
                sqlCommandText = InsertViewDataQuery;
                sqlCommand = new SqlCommand(sqlCommandText, dba.Connection, dba.Transaction);
                sqlCommand.Parameters.AddWithValue(ViewIdParameter, Guid.NewGuid());
                sqlCommand.Parameters.AddWithValue(NameParameter, viewName);
                sqlCommand.Parameters.AddWithValue(ViewResourceParameter, 0);
                sqlCommand.Parameters.AddWithValue(ViewIsDefaultParameter, 0);
                sqlCommand.Parameters.AddWithValue(DataParameter, viewData);
                sqlCommand.Parameters.AddWithValue(ContextParameter, context);
                sqlCommand.ExecuteNonQuery();
            }

            return true;
        }
    }
}