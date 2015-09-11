using Microsoft.SharePoint;
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

        public static decimal CalcResourceRate(int resourceId, string pfeConnection)
        {
            if ((!string.IsNullOrEmpty(pfeConnection)) && pfeConnection.StartsWith("provider", StringComparison.InvariantCultureIgnoreCase))
            {
                // Removing "Provider" part from connection string
                pfeConnection = pfeConnection.Substring(pfeConnection.IndexOf(';') + 1);
            }
            SqlCommand oCommand;
            SqlDataReader reader;
            string sCommand = "";
            decimal dRate = 0;
            try
            {
                using (SqlConnection pfeConn = new SqlConnection(pfeConnection))
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        pfeConn.Open();
                    });
                    // read the resource named rate and if necessary cost category
                    int lBC_UID = 0;
                    int lRT_UID = 0;
                    sCommand = "Select RT_UID From EPGP_COST_RATES  Where TB_UID=0 And WRES_ID=@WresId";
                    oCommand = new SqlCommand(sCommand, pfeConn);
                    oCommand.Parameters.AddWithValue("@WresId", resourceId);
                    reader = oCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        lRT_UID = Convert.ToInt32(reader["RT_UID"]);
                    }
                    reader.Close();

                    if (lRT_UID > 0)
                    {
                        sCommand = "Select RT_RATE From EPG_RATE_VALUES Where RT_EFFECTIVE_DATE<=GETDATE() And RT_UID=@RT_UID Order By RT_EFFECTIVE_DATE";
                        oCommand = new SqlCommand(sCommand, pfeConn);
                        oCommand.Parameters.AddWithValue("@RT_UID", lRT_UID);
                        reader = oCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            dRate = (decimal)(Convert.ToDouble(reader["RT_RATE"]));
                        }
                        reader.Close();
                    }
                    else
                    {
                        sCommand = "Select BC_UID From EPGP_COST_XREF  Where WRES_ID=@WresId";
                        oCommand = new SqlCommand(sCommand, pfeConn);
                        oCommand.Parameters.AddWithValue("@WresId", resourceId);
                        reader = oCommand.ExecuteReader();
                        if (reader.Read())
                        {
                            lBC_UID = Convert.ToInt32(reader["BC_UID"]);
                        }
                        reader.Close();
                        if (lBC_UID > 0)
                        {
                            //  Get Resource Planning Calendar which we will use for Category Rates
                            int lFiscal = -99;
                            sCommand = "SELECT ADM_PORT_COMMITMENTS_CB_ID FROM EPG_ADMIN";
                            oCommand = new SqlCommand(sCommand, pfeConn);
                            reader = oCommand.ExecuteReader();
                            {
                                if (reader.Read())
                                {
                                    if (reader["ADM_PORT_COMMITMENTS_CB_ID"].Equals(System.DBNull.Value))
                                        lFiscal = -99;
                                    else
                                        lFiscal = Convert.ToInt32(reader["ADM_PORT_COMMITMENTS_CB_ID"]);
                                }
                                reader.Close();
                            }
                            if (lFiscal >= 0)
                            {
                                // read the rate for the period containing TODAY but also read Period 1 in case calendar starts in the future
                                sCommand = "Select BA_RATE" +
                                            " From EPGP_COST_BREAKDOWN_ATTRIBS a" +
                                            " Join EPG_PERIODS p On p.CB_ID=a.CB_ID And p.PRD_ID=a.BA_PRD_ID" +
                                            " Join EPGP_CATEGORIES c On c.CA_UID=a.BA_BC_UID" +
                                            " Where a.CB_ID=@CBId And BA_BC_UID=@BC_UID" +
                                            " And BA_RATETYPE_UID=0 And ((PRD_START_DATE<=GETDATE() And PRD_FINISH_DATE>GETDATE()) Or PRD_ID=1)" +
                                            "Order by PRD_ID";
                                oCommand = new SqlCommand(sCommand, pfeConn);
                                oCommand.Parameters.AddWithValue("@CBId", lFiscal);
                                oCommand.Parameters.AddWithValue("@BC_UID", lBC_UID);
                                reader = oCommand.ExecuteReader();
                                {
                                    while (reader.Read())
                                    {
                                        dRate = (decimal)(Convert.ToDouble(reader["BA_RATE"]));
                                    }
                                    reader.Close();
                                }
                            }
                        }
                    }
                }
                return dRate;
            }
            catch (Exception ex)
            {
                // do something
                throw ex;
            }
        }
        #endregion Methods
    }
}