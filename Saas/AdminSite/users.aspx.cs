using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AdminSite
{
    public partial class users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

            cn.Open();

            DataSet ds;
            SqlCommand cmdGetSites;
            SqlDataAdapter da;

            cmdGetSites = new SqlCommand("SELECT uid, coalesce(firstName,'') + ' ' + coalesce(lastName,'') as name, username, email, company, enabled FROM dbo.USERS WHERE (" + ddlColumn.SelectedValue + " like '%" + txtSearch.Text + "%') AND activated='True' order by " + ddlColumn.SelectedValue, cn);
            cmdGetSites.CommandType = CommandType.Text;

            da = new SqlDataAdapter(cmdGetSites);
            ds = new DataSet();
            da.Fill(ds);

            cn.Close();

            GridView1.DataSource = ds;
            GridView1.DataBind();

            lblResults.Text = "Number of Results: " + ds.Tables[0].Rows.Count;
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "view")
            {
                Response.Redirect("edituser.aspx?uid=" + e.CommandArgument);
            }
        }
    }
}