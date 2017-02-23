using System;
using System.Data.SqlClient;

namespace AdminSite
{
    public partial class activatekey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

            cn.Open();

            SqlCommand cmd = new SqlCommand("SELECT featurekey from toolkitfeatures where toolkitorderid=@id", cn);
            cmd.Parameters.AddWithValue("@id", Request["key_id"]);
            SqlDataReader dr = cmd.ExecuteReader();

            string key = "";

            if(dr.Read())
            {
                key = dr.GetString(0);
            }
            dr.Close();

            cmd = new SqlCommand("update toolkitfeatures set activationcount=activationcount+1 where toolkitorderid=@id", cn);
            cmd.Parameters.AddWithValue("@id", Request["key_id"]);
            cmd.ExecuteNonQuery();

            pnlMain.Visible = false;
            pnl2.Visible = true;

            lbl2.Text = "*" + key + "*" + computerCode(key, TextBox1.Text.Trim());

            cn.Close();
        }

        public static string computerCode(string code, string computer)
        {
            //string computer = System.Net.Dns.GetHostName();
            string actCode = "";
            int counter = 0;
            for(int i = 0; i < code.Length; i++)
            {
                if(counter + 1 >= computer.Length)
                    counter = 0;
                actCode = actCode + (computer[counter++] ^ code[i]);
            }
            return actCode;
        }
    }
}