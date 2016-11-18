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
using System.Data.SqlClient;

namespace AdminSite
{
    public partial class addpubkey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                txtKey.Text = getKey();

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

            cn.Open();

            SqlCommand cmd = new SqlCommand("select * from customers where customer_id='" + Request["customer_id"] + "'", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            string company = "";

            if(dr.Read())
            {
                company = dr["company"].ToString();
            }
            dr.Close();
            if(company != "")
            {
                string key = txtKey.Text.Replace("-", "");
                string code = genCode(company, key);
                string supportdate = "";

                if(Calendar3.SelectedDate != DateTime.MinValue)
                {
                    supportdate = Calendar3.SelectedDate.ToString();
                }


                cmd = new SqlCommand("insert into productkeys (cdkey,activationcount,licensecount,customer_id,actkey,company,premiersupportdate,supportyears) VALUES (@cdkey,0,@licensecount,@customer_id,@actkey,@company,@premiersupportdate,@supportyears)", cn);
                cmd.Parameters.AddWithValue("@cdkey", key.Replace("-", ""));
                cmd.Parameters.AddWithValue("@licensecount", txtActivations.Text);
                cmd.Parameters.AddWithValue("@customer_id", Request["customer_id"]);
                cmd.Parameters.AddWithValue("@actkey", code);
                cmd.Parameters.AddWithValue("@company", company);
                if(supportdate != "")
                    cmd.Parameters.AddWithValue("@premiersupportdate", supportdate);
                else
                    cmd.Parameters.AddWithValue("@premiersupportdate", DBNull.Value);
                cmd.Parameters.AddWithValue("@supportyears", txtSupportYears.Text);
                cmd.ExecuteNonQuery();
            }
            cn.Close();
            Page.RegisterStartupScript("close", "<script language=\"javascript\">parent.location.href='editcustomer.aspx?customer_id=" + Request["customer_id"] + "&tab=2';</script>");
        }

        private string getKey()
        {
            string key = "";
            Random rdm = new Random();
            for(int i = 0; i < 4; i++)
            {
                key += ((char)((short)'A' + rdm.Next(26))).ToString();
            }
            key += "-";
            for(int i = 0; i < 4; i++)
            {
                key += ((char)((short)'A' + rdm.Next(26))).ToString();
            }
            key += "-";
            for(int i = 0; i < 4; i++)
            {
                key += ((char)((short)'A' + rdm.Next(26))).ToString();
            }
            return key;
        }

        private static string genCode(string company, string cdKey)
        {
            string pwd = "H3fd65TR" + company;
            string actCode = "";
            int counter = 0;
            for(int i = 0; i < cdKey.Length; i++)
            {
                if(counter + 1 >= pwd.Length)
                    counter = 0;
                actCode = actCode + (pwd[counter++] ^ cdKey[i]);
            }
            return actCode;
        }
    }
}