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
    public partial class changeowner : System.Web.UI.Page
    {
        protected string strLic;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

                cn.Open();

                SqlCommand cmdGetSites = new SqlCommand("SELECT name + '(' + email + ')' as fullname, uid  from vwAccountUsers where account_id='" + Request["account_id"] + "' and deleted is null order by name", cn);
                cmdGetSites.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmdGetSites);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ddlOwner.DataTextField = "fullname";
                ddlOwner.DataValueField = "uid";
                ddlOwner.DataSource = ds;
                ddlOwner.DataBind();

                cn.Close();
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {

            pnlMain.Visible = false;
            pnlMessage.Visible = true;

            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

            cn.Open();

            SqlCommand cmd = new SqlCommand("select owner_id from account where account_id=@account_id", cn);
            cmd.Parameters.AddWithValue("@account_id", Request["account_Id"]);
            SqlDataReader dr = cmd.ExecuteReader();
            Guid owner = Guid.Empty;
            if(dr.Read())
            {
                owner = dr.GetGuid(0);
            }
            dr.Close();
            if(owner != Guid.Empty)
            {
                cmd = new SqlCommand("spmoveaccount", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@account_uid", Request["account_Id"]);
                cmd.Parameters.AddWithValue("@oldowner", owner);
                cmd.Parameters.AddWithValue("@newowner", ddlOwner.SelectedValue);
                dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    switch(dr.GetInt32(0))
                    {
                        case 0:
                            lblMessage.Text = "Successfully changed owner";
                            break;
                        case 1:
                            lblMessage.Text = "Mismatched account id and older owner id";
                            break;
                        case 2:
                            lblMessage.Text = "New owner already has an account";
                            break;
                        case 3:
                            lblMessage.Text = "New owner doesn't exist";
                            break;
                    }
                }
                else
                {
                    lblMessage.Text = "Failed to Execute Move";
                }
                dr.Close();
            }
            else
            {
                lblMessage.Text = "Owner Not Found";
            }


            cn.Close();
            //Page.RegisterStartupScript("close", "<script language=\"javascript\">parent.location.href='editcustomer.aspx?customer_id=" + Request["customer_id"] + "&tab=2';</script>");

        }
    }
}