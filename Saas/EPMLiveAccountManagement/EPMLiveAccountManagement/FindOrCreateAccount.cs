using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.SharePoint;

namespace EPMLiveAccountManagement
{
    public static class FindOrCreateAccount
    {
        public static bool sendEmail(int number, string email, string []emailparams)
        {
            emailservice.Service eService = new emailservice.Service();
            if(ConfigurationManager.AppSettings["emailUrl"] != null)
                eService.Url = ConfigurationManager.AppSettings["emailUrl"];
            eService.Credentials = new System.Net.NetworkCredential("adaccessuser", "lkf@$farFA", "epm");
            bool ret = eService.sendEmail(number, "FD5BF59E-31ED-41e7-A25C-6E2B01DD6C1C", email, emailparams);

            return ret;
        }

        public static string FindUserName(string email)
        {
            string uname = "";

            ServicePointManager.ServerCertificateValidationCallback += delegate(object sender, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) { return true; };

            accounts.Service accts = new accounts.Service();

            if(ConfigurationManager.AppSettings["acctsUrl"] != null)
                accts.Url = ConfigurationManager.AppSettings["acctsUrl"];
            accts.Credentials = new System.Net.NetworkCredential("adaccessuser", "lkf@$farFA", "epm");

            accounts.LookUpList[] List = accts.findUser(email);

            if(List != null && List.Length > 0)
            {
                uname = List[0].uid;
            }

            return uname;

        }

        public static string CreateAccount(string firstname, string lastname, string email, Guid siteuid, bool silent)
        {
            string user = "";
            string error = "";
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += delegate(object sender, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) { return true; };

                accounts.Service accts = new accounts.Service();

                if(ConfigurationManager.AppSettings["acctsUrl"] != null)
                    accts.Url = ConfigurationManager.AppSettings["acctsUrl"];
                accts.Credentials = new System.Net.NetworkCredential("adaccessuser", "lkf@$farFA", "epm");

                accounts.LookUpList[] List = accts.findUser(email);

                string accountid = "";

                SqlConnection cn = null;

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    cn = new SqlConnection(Settings.getConnectionString());
                    cn.Open();
                });

                SqlCommand cmd = new SqlCommand("2010SP_GetSiteAccountNums", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@siteid", siteuid);
                cmd.Parameters.AddWithValue("@contractLevel", Settings.getContractLevel());
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    accountid = dr.GetGuid(2).ToString();
                }
                dr.Close();

                if(List != null && List.Length > 0)
                {
                    error = "1:Account Exists";
                }
                else
                {
                    if(silent)
                        user = accts.createAccountSilent(email, firstname, lastname, out error);
                    else
                        user = accts.createAccount(email, firstname, lastname, out error);
                    if(error == "0")
                        error = "";
                }

                
                cn.Close();
            }
            catch(Exception ex)
            {
                error = "1:" + ex.Message;
            }

            if(error == "")
                return "0:" + user;
            else
                return error;
        }
    }
}
