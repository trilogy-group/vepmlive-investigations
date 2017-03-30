using System;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;

namespace AdminSite
{
    public partial class addkey : System.Web.UI.Page
    {
        private string saltValue = "f53fNDH@";
        private string hashAlgorithm = "SHA1";
        private int passwordIterations = 2;
        private string initVector = "77B2c3D4e1F3g7R1";
        private int keySize = 256;
        protected int iVersion = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            iVersion = int.Parse(ddlVersion.SelectedValue);

            if(!IsPostBack)
            {
                ddlVersion.Attributes.Add("onchange", "ChangeVersion()");

                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

                cn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM FEATURES", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                gvFeatures.DataSource = ds;
                gvFeatures.DataBind();

                cn.Close();

                DataTable dt = new DataTable();
                dt.Columns.Add("FEATURE_ID");
                dt.Columns.Add("FEATURE_NAME");

                dt.Rows.Add(new string[] { "1", "Team Member" });
                dt.Rows.Add(new string[] { "2", "Project Manager" });
                dt.Rows.Add(new string[] { "3", "Full User" });

                gvLicenses.DataSource = dt;
                gvLicenses.DataBind();

                Calendar1.SelectedDate = DateTime.Now;
            }

            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            iVersion = int.Parse(ddlVersion.SelectedValue);

            if(iVersion == 1)
            {
                GenerateKeyV1();

                Response.Redirect("editcustomer.aspx?customer_id=" + Request["customer_id"]);
            }
            else if(iVersion == 2)
            {
                GenerateKeyV2();

                Response.Redirect("editcustomer.aspx?customer_id=" + Request["customer_id"]);
            }
            else if(iVersion == 3)
            {
                GenerateKeyV3();

                Response.Redirect("editcustomer.aspx?customer_id=" + Request["customer_id"]);
            }
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

        private void GenerateKeyV1()
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

            SaveKey(key);
        }

        private void GenerateKeyV2()
        {
            string exp = "NA";

            if(this.CheckBox1.Checked)
                exp = Calendar2.SelectedDate.ToString("s");

            string featureids = "";

            foreach(GridViewRow gvr in gvFeatures.Rows)
            {
                TextBox txt = (TextBox)gvr.FindControl("txtUserCount");
                if(txt.Text != "")
                {
                    try
                    {
                        int.Parse(txt.Text);

                        featureids += "," + gvr.Cells[0].Text + ":" + txt.Text;
                    }
                    catch { }
                }
            }

            string key = "*2\n" + Calendar1.SelectedDate.ToString("s") + "\n" + txtCompany.Text + "\n" + featureids.Trim(',') + "\n" + exp;

            SaveKey(key);
        }

        private void GenerateKeyV3()
        {
            string exp = "NA";

            if(this.CheckBox1.Checked)
                exp = Calendar2.SelectedDate.ToString("s");

            string featureids = "";

            foreach(GridViewRow gvr in gvLicenses.Rows)
            {
                TextBox txt = (TextBox)gvr.FindControl("txtUserCount");
                if(txt.Text != "")
                {
                    try
                    {
                        int.Parse(txt.Text);

                        featureids += "," + gvr.Cells[0].Text + ":" + txt.Text;
                    }
                    catch { }
                }
            }

            string key = "*3\n" + Calendar1.SelectedDate.ToString("s") + "\n" + txtCompany.Text + "\n" + featureids.Trim(',') + "\n" + exp;

            SaveKey(key);
        }

        private void SaveKey(string key)
        {
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
        }
    }
}