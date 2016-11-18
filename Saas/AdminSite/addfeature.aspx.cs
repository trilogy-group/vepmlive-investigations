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
    public partial class addfeature : System.Web.UI.Page
    {
        private string saltValue = "f53fNDH@";
        private string hashAlgorithm = "SHA1";
        private int passwordIterations = 2;
        private string initVector = "77B2c3D4e1F3g7R1";
        private int keySize = 256;


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Calendar1.SelectionMode = CalendarSelectionMode.Day;
                Calendar1.SelectedDate = DateTime.Now;

                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

                cn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM FEATURES", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                CheckBoxList1.DataSource = ds;
                CheckBoxList1.DataValueField = "FEATURE_ID";
                CheckBoxList1.DataTextField = "FEATURE_NAME";
                CheckBoxList1.DataBind();

                cn.Close();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string exp = "NA";
            string users = "0";
            if(this.CheckBox1.Checked)
                exp = Calendar2.SelectedDate.ToShortDateString();
            if(txtUsers.Text != "")
                users = txtUsers.Text;

            string features = "";
            foreach(ListItem lst in CheckBoxList1.Items)
            {
                if(lst.Selected)
                    features += "," + lst.Value;
            }
            if(features.Length > 1)
                features = features.Substring(1);

            string key = txtCompany.Text + "\n" + features + "\n" + users + "\n" + Calendar1.SelectedDate.ToShortDateString() + "\n" + exp + "\n" + txtServers.Text;

            key = Encrypt(key, "jLHKJH5416FL>1dcv3#I");

            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

            cn.Open();

            string supportdate = "";

            if(Calendar3.SelectedDate != DateTime.MinValue)
            {
                supportdate = Calendar3.SelectedDate.ToString();
            }

            SqlCommand cmd = new SqlCommand("insert into toolkitfeatures (customer_id,featurekey,licenseqty,supportdate,supportyears) VALUES (@customer_id,@featurekey,@licenseqty,@supportdate,@supportyears)", cn);
            cmd.Parameters.AddWithValue("@customer_id", Request["customer_id"]);
            cmd.Parameters.AddWithValue("@featurekey", key);
            cmd.Parameters.AddWithValue("@licenseqty", txtActivations.Text);
            if(supportdate != "")
                cmd.Parameters.AddWithValue("@supportdate", supportdate);
            else
                cmd.Parameters.AddWithValue("@supportdate", DBNull.Value);
            cmd.Parameters.AddWithValue("@supportyears", txtSupportYears.Text);
            cmd.ExecuteNonQuery();

            cn.Close();
            Page.RegisterStartupScript("close", "<script language=\"javascript\">parent.location.href='editcustomer.aspx?customer_id=" + Request["customer_id"] + "&tab=3';</script>");
        }


        public string Encrypt(string plainText, string passPhrase)
        {
            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

                byte[] keyBytes = password.GetBytes(keySize / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();

                symmetricKey.Mode = CipherMode.CBC;

                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
                                                                 keyBytes,
                                                                 initVectorBytes);
                MemoryStream memoryStream = new MemoryStream();

                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                             encryptor,
                                                             CryptoStreamMode.Write);

                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

                cryptoStream.FlushFinalBlock();

                byte[] cipherTextBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                string cipherText = Convert.ToBase64String(cipherTextBytes);
                return cipherText;
            }
            catch { return "ERROR"; }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("editcustomer.aspx?customer_id=" + Request["customer_id"]);
        }
    }
}