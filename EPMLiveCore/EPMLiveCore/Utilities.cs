using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace EPMLiveCore
{
    public static class Utilities
    {
        #region Methods (2) 

        // Public Methods (4) 

        /// <summary>
        /// Composes the caml query.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="op">The op.</param>
        /// <param name="whereClause">The where clause.</param>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public static string ComposeCamlQuery(IList<string> parameters, string op, string whereClause, string query)
        {
            return parameters.Count == 1
                       ? string.Format(whereClause, string.Format(query, parameters[0]))
                       : ComposeCamlQuery(parameters.Skip(1).ToList(), op,
                                          string.Format(whereClause,
                                                        string.Format("<{0}>{1}{{0}}</{0}>", op,
                                                                      string.Format(query, parameters[0]))), query);
        }

        /// <summary>
        /// Decodes the grid data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string DecodeGridData(string data)
        {
            string decodedData = HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(data));

            if (decodedData == null)
            {
                throw new Exception("Unable to decode the grid data.");
            }

            return decodedData;
        }

        /// <summary>
        /// Get reporting database connection string
        /// </summary>
        /// <param name="epmliveConnection">EPMLive Connection string</param>
        /// <param name="siteId">Site id</param>
        /// <param name="webAppId">WebApplication id</param>
        /// <returns>Connection string</returns>
        public static string GetReportingDbConnectionString(string epmliveConnection, Guid siteId, Guid webAppId)
        {
            string conStr = string.Empty;
            SqlConnection conn = null;
            try
            {
                using (conn = new SqlConnection(epmliveConnection))
                {
                    Microsoft.SharePoint.SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        conn.Open();
                    });
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select * from RPTDATABASES where SiteId = '" + siteId + "' and WebApplicationId = '" + webAppId + "'";
                        cmd.Connection = conn;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var useSA = (bool)reader["SAccount"];                                
                                if (useSA)
                                {
                                    conStr = "Data Source=" + reader["DatabaseServer"].ToString() + " ;Initial Catalog=" +
                                             reader["DatabaseName"].ToString() + ";User Id=" + reader["UserName"].ToString() +
                                             ";Password=" + Decrypt(reader["Password"].ToString()) + ";";
                                }
                                else
                                {
                                    conStr = "Data Source=" + reader["DatabaseServer"].ToString() + ";Initial Catalog=" +
                                             reader["DatabaseName"].ToString() + ";Integrated Security=SSPI;";
                                }
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
            return conStr;
        }

        /// <summary>
        /// Get PFE database connection string
        /// </summary>
        /// <param name="basepath">base path</param>
        /// <returns>Connection string</returns>
        public static string GetPFEDBConnectionString(string basepath)
        {
            string connectionString = string.Empty;
            try
            {
                RegistryKey key = GetRegistryKey(basepath);

                if (key != null)
                {
                    var value = key.GetValue("ConnectionString");
                    connectionString = (value != null ? value.ToString() : string.Empty);
                }
            }
            catch
            { }
            return connectionString; 
        }

        /// <summary>
        ///     Decrpyts string value using key.
        /// </summary>
        /// <param name="base64Text"></param>
        /// <returns></returns>
        private static string Decrypt(string base64Text)
        {
            try
            {
                var Buffer = new byte[0];
                string Key = "EPMLIVE";
                var DES = new TripleDESCryptoServiceProvider();
                var hashMD5 = new MD5CryptoServiceProvider();
                DES.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Key));
                DES.Mode = CipherMode.ECB;
                ICryptoTransform DESDecrypt = DES.CreateDecryptor();
                Buffer = Convert.FromBase64String(base64Text);

                string DecTripleDES =
                    ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
                return DecTripleDES;
            }
            catch
            {
                return base64Text;
            }
        }

        /// <summary>
        /// Gets epmlive registry key for PFE DB connection string
        /// </summary>
        /// <param name="basepath"></param>
        /// <returns></returns>
        private static RegistryKey GetRegistryKey(string basepath)
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

        #endregion Methods 
    }
}