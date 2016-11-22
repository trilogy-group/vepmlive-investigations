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
    public partial class activepartners : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fillGrid();
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "view")
            {
                pnlView.Visible = true;
                GridView1.Visible = false;

                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

                cn.Open();

                DataSet ds;
                SqlCommand cmdGetSites;
                SqlDataAdapter da;

                cmdGetSites = new SqlCommand("SELECT * from partners where partner_id=@partner_id", cn);
                cmdGetSites.Parameters.AddWithValue("@partner_id", e.CommandArgument);
                cmdGetSites.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmdGetSites);
                ds = new DataSet();
                da.Fill(ds);



                lblAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
                lblCity.Text = ds.Tables[0].Rows[0]["city"].ToString();
                lblCompany.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
                lblCountry.Text = ds.Tables[0].Rows[0]["country"].ToString();
                lblDescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
                lblEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();
                lblFirst.Text = ds.Tables[0].Rows[0]["firstname"].ToString();
                lblLast.Text = ds.Tables[0].Rows[0]["lastname"].ToString();
                lblState.Text = ds.Tables[0].Rows[0]["state"].ToString();
                lblServices.Text = ds.Tables[0].Rows[0]["services"].ToString();
                lblUrl.Text = ds.Tables[0].Rows[0]["companyurl"].ToString();
                lblZip.Text = ds.Tables[0].Rows[0]["zip"].ToString();

                string type = "";
                if(ds.Tables[0].Rows[0]["reseller"].ToString() == "True")
                    type = "-Reseller<br>";
                if(ds.Tables[0].Rows[0]["solution"].ToString() == "True")
                    type = type + "-Solution Provider<br>";
                if(ds.Tables[0].Rows[0]["product"].ToString() == "True")
                    type = type + "-3rd Party Product<br>";

                if(type.Length > 0)
                    type = type.Substring(0, type.Length - 4);

                lblType.Text = type;

                accountsSvc.Service accts = new accountsSvc.Service();
                accts.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["username"].ToString(), System.Configuration.ConfigurationManager.AppSettings["password"].ToString(), System.Configuration.ConfigurationManager.AppSettings["domain"].ToString());
                accountsSvc.LookUpList[] list = accts.findUser(ds.Tables[0].Rows[0]["email"].ToString());
                if(list.Length > 0)
                {
                    lblAccount.Text = "Yes";
                    hdnUserId.Value = list[0].uid;

                    SqlCommand cmd = new SqlCommand("SELECT fullurl,title from vwUserSites where username like @username", cn);
                    cmd.Parameters.AddWithValue("@username", System.Configuration.ConfigurationManager.AppSettings["domain"].ToString() + "\\" + list[0].uid);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        hdnSiteUrl.Value = dr.GetString(0);
                        hdnSiteName.Value = dr.GetString(1);
                    }

                    dr.Close();
                }
                else
                    lblAccount.Text = "No";

                hdnPartnerId.Value = e.CommandArgument.ToString();



                cn.Close();
            }
        }

        private void fillGrid()
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

            cn.Open();

            DataSet ds;
            SqlCommand cmdGetSites;
            SqlDataAdapter da;

            cmdGetSites = new SqlCommand("SELECT firstName, lastName, companyname, partner_id from partners where active=1", cn);
            cmdGetSites.CommandType = CommandType.Text;

            da = new SqlDataAdapter(cmdGetSites);
            ds = new DataSet();
            da.Fill(ds);

            cn.Close();

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        private string getKey()
        {
            string key = "";
            Random rdm = new Random();
            for(int i = 0; i < 4; i++)
            {
                key = key + ((char)((short)'A' + rdm.Next(26))).ToString();
            }
            key = key + "-";
            for(int i = 0; i < 4; i++)
            {
                key = key + ((char)((short)'A' + rdm.Next(26))).ToString();
            }
            key = key + "-";
            for(int i = 0; i < 4; i++)
            {
                key = key + ((char)((short)'A' + rdm.Next(26))).ToString();
            }
            return key;
        }

        private string genCode(string company, string cdKey)
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("partnerrequests.aspx");
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}