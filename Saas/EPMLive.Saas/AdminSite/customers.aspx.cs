using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AdminSite
{
    public partial class customers : System.Web.UI.Page
    {
        protected string sQuery;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text != "")
            {
                GridView1.Visible = true;
                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

                cn.Open();

                DataSet ds;
                SqlCommand cmdGetSites;
                SqlDataAdapter da;

                cmdGetSites = new SqlCommand("SELECT customer_id, coalesce(lastName,'') + ', ' + coalesce(firstName,'')  as name, email, company from customers WHERE (" + ddlColumn.SelectedValue + " like '%" + txtSearch.Text + "%') order by " + ddlColumn.SelectedValue, cn);
                cmdGetSites.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmdGetSites);
                ds = new DataSet();
                da.Fill(ds);

                cn.Close();

                GridView1.DataSource = ds;
                GridView1.DataBind();

                lblResults.Text = "Number of Results: " + ds.Tables[0].Rows.Count;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "view")
            {
                Response.Redirect("editcustomer.aspx?customer_id=" + e.CommandArgument);
            }
        }
    }
}