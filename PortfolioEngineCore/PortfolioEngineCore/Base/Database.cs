using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace PortfolioEngineCore
{
    internal class Database : AllCore
    {
        public string sCN = "";

        public Database(Debugger debug)
            : base(debug)
        {

        }

        public SqlConnection OpenDatabase(string basepath, string cnString)
        {
            SqlConnection cn = null; 

            if(!string.IsNullOrEmpty(basepath))
            {
                debug.AddMessage("Database: Using Basepath");

                cnString = getstring(basepath);
            }
            else
            {
                debug.AddMessage("Database: Using CN");
            }

            
            try
            {
                debug.AddMessage("Database: Building Connection String");

                var dbConnectionStringBuilder = new DbConnectionStringBuilder {ConnectionString = cnString};

                dbConnectionStringBuilder.Remove("Provider");

                sCN = cnString;

                cn = new SqlConnection(dbConnectionStringBuilder.ConnectionString);

                debug.AddMessage("Database: Opening");

                cn.Open();
                cn.Close();
            }
            catch(Exception ex)
            {
                throw new PFEException((int) PFEError.DBCantOpenDB, "Unable to open database: " + ex.Message);
            }

            return cn;
        }

        //EPML-4761: Store PFE SQL ConnectionString encrypted
        private string getstring(string basepath)
        {
            string sCN = string.Empty;
            try
            {
                sCN = Utilities.GetConnectionString(basepath);
                //RegistryKey key = Utilities.GetRegistryKey(basepath);
                //if (key != null)
                //{
                //    var value = key.GetValue("ConnectionString");
                //    sCN = (value != null ? value.ToString() : string.Empty);
                //}
            }
            catch (Exception ex)
            {
                //throw ex;
                throw new PFEException((int)PFEError.DBCantLoadConnectionString, "Could not load Connection String from registry: " + ex.Message);
            }
            return sCN;
        }
        //END EPML-4761
    }
}
