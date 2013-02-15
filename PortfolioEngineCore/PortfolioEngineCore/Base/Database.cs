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

        private string getstring(string basepath)
        {
            string sCN = "";
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", false).OpenSubKey("EPMLive", false).OpenSubKey("PortfolioEngine", false).OpenSubKey(basepath);
                sCN = key.GetValue("ConnectionString").ToString();
            }
            catch
            {
                try
                {
                    RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", false).OpenSubKey("Wow6432Node", false).OpenSubKey("EPMLive", false).OpenSubKey("PortfolioEngine", false).OpenSubKey(basepath);
                    sCN = key.GetValue("ConnectionString").ToString();
                }
                catch
                {
                    throw new PFEException((int) PFEError.DBCantLoadConnectionString, "Could not load Connection String from registry");
                }
            }
            return sCN;

        }
    }
}
