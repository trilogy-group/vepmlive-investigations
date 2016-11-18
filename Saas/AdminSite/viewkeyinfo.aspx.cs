using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace AdminSite
{
    public partial class viewkeyinfo : System.Web.UI.Page
    {
        private string saltValue = "f53fNDH@";
        private string hashAlgorithm = "SHA1";
        private int passwordIterations = 2;
        private string initVector = "77B2c3D4e1F3g7R1";
        private int keySize = 256;
        protected string disp = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

            cn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM FEATURES", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cn.Close();

            string data = Decrypt(Request["featurekey"], "jLHKJH5416FL>1dcv3#I");
            if(data == "")
            {

            }
            else
            {
                string[] sData = data.Split('\n');

                if(sData[0] == "*2")
                {
                    lblVersion.Text = "V2 (User Based)";

                    lblPurchase.Text = sData[1];
                    lblCompany.Text = sData[2];
                    lblExpiration.Text = sData[4];

                    string[] features = sData[3].Split(',');
                    foreach(string feature in features)
                    {
                        string[] featureinfo = feature.Split(':');

                        DataRow[] dr = ds.Tables[0].Select("FEATURE_ID='" + featureinfo[0] + "'");
                        if(dr.Length > 0)
                        {
                            lblFeatures.Text += dr[0]["Feature_name"].ToString() + ": " + featureinfo[1] + "<br>";
                        }
                    }

                    disp = "none";
                }
                else if(sData[0] == "*3")
                {
                    lblVersion.Text = "V3 (Role Based)";
                    lblPurchase.Text = sData[1];
                    lblCompany.Text = sData[2];
                    lblExpiration.Text = sData[4];

                    string[] features = sData[3].Split(',');
                    foreach(string feature in features)
                    {
                        string []featureinfo = feature.Split(':');

                        if(featureinfo[0] == "1")
                            lblFeatures.Text += "Team Member";
                        else if(featureinfo[0] == "2")
                            lblFeatures.Text += "Project Manager";
                        else if(featureinfo[0] == "3")
                            lblFeatures.Text += "Full User";

                        lblFeatures.Text += ": " + featureinfo[1] + "<br>";
                    }

                    disp = "none";
                }
                else
                {
                    lblVersion.Text = "V1 (Old User Based)";

                    lblCompany.Text = sData[0];

                    string[] featureNames = sData[1].Split(',');
                    foreach(string featureName in featureNames)
                    {
                        string featureRealName = "";
                        /*switch (featureName)
                        {
                            case "0":
                                featureRealName = "Toolkit Base";
                                break;
                            case "1":
                                featureRealName = "Work Planner";
                                break;
                            case "2":
                                featureRealName = "Resource Planner";
                                break;
                            case "3":
                                featureRealName = "Timesheets";
                                break;
                            case "4":
                                featureRealName = "Enterprise Base";
                                break;
                            case "5":
                                featureRealName = "Reporting";
                                break;
                            case "6":
                                featureRealName = "Agile Planner";
                                break;
                            case "7":
                                featureRealName = "PortfolioEngine Core";
                                break;
                        };*/
                        DataRow[] dr = ds.Tables[0].Select("FEATURE_ID=" + featureName);
                        if(dr.Length > 0)
                            lblFeatures.Text += dr[0]["Feature_name"].ToString() + "<br>";
                    }

                    if(sData[2] == "0")
                        lblUsers.Text = "Unlimited";
                    else
                        lblUsers.Text = sData[2];


                    lblPurchase.Text = sData[3];
                    if(sData[4] == "NA")
                    {
                        lblExpiration.Text = "NA";
                    }
                    else
                    {
                        lblExpiration.Text = sData[4];
                    }
                    try
                    {
                        lblServers.Text = sData[5];
                    }
                    catch { }
                }
            }
        }

        public string Decrypt(string cipherText, string passPhrase)
        {
            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

                PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                                passPhrase,
                                                                saltValueBytes,
                                                                hashAlgorithm,
                                                                passwordIterations);

                byte[] keyBytes = password.GetBytes(keySize / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                                                                 keyBytes,
                                                                 initVectorBytes);

                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                              decryptor,
                                                              CryptoStreamMode.Read);

                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                           0,
                                                           plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();

                string plainText = Encoding.UTF8.GetString(plainTextBytes,
                                                           0,
                                                           decryptedByteCount);
                return plainText;
            }
            catch(Exception exception) { return exception.Message; }
        }
    }
}