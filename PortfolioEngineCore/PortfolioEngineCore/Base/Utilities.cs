using System;
using System.Data;
using System.Data.SqlClient;

using Microsoft.Win32;
using System.Diagnostics;

namespace PortfolioEngineCore
{
    public static class Utilities
    {
        private const string PASS_PHRASE = "MnjkafjhkAS&*^#@";

        #region Methods (6) 

        // Public Methods (6) 

        /// <summary>
        /// Gets the base message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public static string GetBaseMessage(this Exception exception)
        {
            return exception.GetBaseException().Message;
        }

        /// <summary>
        /// Gets the byte safely.
        /// </summary>
        /// <param name="sqlDataReader">The SQL data reader.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public static byte? GetByteSafely(this SqlDataReader sqlDataReader, string fieldName)
        {
            int ordinal = sqlDataReader.GetOrdinal(fieldName);

            return !sqlDataReader.IsDBNull(ordinal) ? (byte?) sqlDataReader.GetByte(ordinal) : null;
        }

        /// <summary>
        /// Gets the date time safely.
        /// </summary>
        /// <param name="sqlDataReader">The SQL data reader.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public static DateTime? GetDateTimeSafely(this SqlDataReader sqlDataReader, string fieldName)
        {
            int ordinal = sqlDataReader.GetOrdinal(fieldName);

            return !sqlDataReader.IsDBNull(ordinal) ? (DateTime?) sqlDataReader.GetDateTime(ordinal) : null;
        }

        /// <summary>
        /// Gets the decimal safely.
        /// </summary>
        /// <param name="sqlDataReader">The SQL data reader.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public static decimal? GetDecimalSafely(this SqlDataReader sqlDataReader, string fieldName)
        {
            int ordinal = sqlDataReader.GetOrdinal(fieldName);

            return !sqlDataReader.IsDBNull(ordinal) ? (decimal?) sqlDataReader.GetDecimal(ordinal) : null;
        }

        /// <summary>
        /// Gets the int32 safely.
        /// </summary>
        /// <param name="sqlDataReader">The SQL data reader.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public static int? GetInt32Safely(this SqlDataReader sqlDataReader, string fieldName)
        {
            int ordinal = sqlDataReader.GetOrdinal(fieldName);

            return !sqlDataReader.IsDBNull(ordinal) ? (int?) sqlDataReader.GetInt32(ordinal) : null;
        }

        /// <summary>
        /// Gets the string safely.
        /// </summary>
        /// <param name="sqlDataReader">The SQL data reader.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public static string GetStringSafely(this SqlDataReader sqlDataReader, string fieldName)
        {
            int ordinal = sqlDataReader.GetOrdinal(fieldName);

            return !sqlDataReader.IsDBNull(ordinal) ? sqlDataReader.GetString(ordinal) : null;
        }


        public static int ResolveNTNameintoWResID( SqlConnection sqlConnection, string ntname)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
                sqlConnection.Open();


                string resName = ntname.Trim();

                if (resName == "")
                    return 0;

                string sCommand = "SELECT WRES_ID FROM EPG_RESOURCES Where ( { fn UCASE(WRES_NT_ACCOUNT) } = '" + resName.ToUpper() + "')";
                int resId = 0;
                SqlCommand oCommand = new SqlCommand(sCommand, sqlConnection);

                SqlDataReader reader = null;
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    resId = DBAccess.ReadIntValue(reader["WRES_ID"]);
                }
                reader.Close();
                reader = null;
                return resId;
            }
            catch
            {
                return 0;
            }



        }

        //EPML-4761: Store PFE SQL ConnectionString encrypted
        public static RegistryKey GetRegistryKey(string basepath)
        {
            RegistryKey key;

            try
            {
                string registryKeyPath1 = @"Software\Wow6432Node\EPMLive\PortfolioEngine\" + basepath;
                string registryKeyPath2 = @"Software\EPMLive\PortfolioEngine\" + basepath;

                key = Registry.LocalMachine.OpenSubKey(registryKeyPath1, false);

                if (key == null)
                {
                    key = Registry.LocalMachine.OpenSubKey(registryKeyPath2, false);
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("EPMLive Core: ", ex.Message, EventLogEntryType.Error);
                key = null;
            }
            return key;
        }

        //Method would check if the connection string is encyrpted or not
        //if encryted: decrypt it, else return as is
        public static string GetConnectionString(string basepath)
        {
            string connectionString = string.Empty;

            try
            {
                //ROLLBACK: changes for PFE connection string encryption
                //RegistryKey key = GetRegistryKey(basepath);

                //if (key != null)
                //{
                //    var encrypted = key.GetValue("encrypted");
                //    var value = key.GetValue("ConnectionString");
                //    connectionString = (value != null ? value.ToString() : string.Empty);

                //    //check to see if encrypted property exists, if it does means connection string is encrypted
                //    if (encrypted != null)
                //    {
                //        //decrypt the connection string
                //        connectionString = PortfolioEngineCore.PFEEncrypt.Decrypt(connectionString, PASS_PHRASE);
                //    }

                //}
                RegistryKey key = GetRegistryKey(basepath);

                if (key != null)
                {
                    var value = key.GetValue("ConnectionString");
                    connectionString = (value != null ? value.ToString() : string.Empty);
                }
                //END ROLLBACK: changes for PFE connection string encryption
            }
            catch (Exception ex)
            {
                connectionString = string.Empty;
                //TODO: Log error 
            }
            return connectionString;
        }
        //End EPML-4761

        #endregion Methods
    }
}