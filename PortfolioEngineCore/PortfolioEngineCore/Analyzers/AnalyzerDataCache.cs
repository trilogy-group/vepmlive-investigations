using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;


namespace PortfolioEngineCore
{
     
    public class AnalyzerDataCache : PFEBase
    {
        private readonly SqlConnection _sqlConnection;

         public AnalyzerDataCache(string basepath, string username, string pid, string company, string dbcnstring, SecurityLevels secLevel, bool bDebug = false)
            : base(basepath, username, pid, company, dbcnstring, secLevel, bDebug)
        {
            debug.AddMessage("Loading ModelSupport Class");
            _sqlConnection = _PFECN;
            _userWResID = Utilities.ResolveNTNameintoWResID(_sqlConnection, username);
        }

         public AnalyzerDataCache(string sBaseInfo)
            : base(sBaseInfo)
        {
            debug.AddMessage("Loading CostAnalyzerData Class");
            _sqlConnection = _PFECN;
        }

    
        public bool SaveStashEntry(string sKey, string sData)
        {

            try
            {
                DateTime dtNow = DateTime.Now;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                string sCommand = "DELETE FROM EPG_DATASTASH WHERE DATASTASH_TIMESTAMP <= @stime OR DATASTASH_KEY = '" + sKey + "'";
                SqlCommand cmd = new SqlCommand(sCommand, _sqlConnection);
                cmd.Parameters.AddWithValue("@stime", dtNow.AddDays(-7));
                int nRowsAffected = cmd.ExecuteNonQuery();

                sCommand = "INSERT INTO EPG_DATASTASH (DATASTASH_KEY, DATASTASH_DATA, DATASTASH_TIMESTAMP) " +
                           "VALUES(@skey,@sdata,@stime)";

                cmd = new SqlCommand(sCommand, _sqlConnection);

                cmd.Parameters.AddWithValue("@skey", sKey);
                cmd.Parameters.AddWithValue("@sdata", sData);
                cmd.Parameters.AddWithValue("@stime", dtNow);
                nRowsAffected = cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public string GetStashEntry(string sKey)
        {
            try
            {
                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();


                string sCommand = "SELECT DATASTASH_DATA FROM EPG_DATASTASH WHERE DATASTASH_KEY = '" + sKey + "'";
                SqlCommand cmd = new SqlCommand(sCommand, _sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                sCommand = "";
                if (reader.Read())
                {
                    sCommand = DBAccess.ReadStringValue(reader["DATASTASH_DATA"]);
                }
                reader.Close();
                return sCommand;

            }

            catch (Exception ex)
            {
                return "";
            }


        }
    }
}
