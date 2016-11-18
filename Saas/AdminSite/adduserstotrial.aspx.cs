using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace AdminSite
{
    public partial class adduserstotrial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
                cn.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT     dbo.DETAILTYPES.detail_type_id, dbo.DETAILTYPES.detail_name, dbo.ORDERDETAIL.quantity
                                                FROM         dbo.ORDERDETAIL INNER JOIN
                                                dbo.DETAILTYPES ON dbo.ORDERDETAIL.detail_type_id = dbo.DETAILTYPES.detail_type_id WHERE ORDER_ID=@orderid", cn);

                cmd.Parameters.AddWithValue("@orderid", Request["orderid"]);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                GridView1.RowDataBound += new GridViewRowEventHandler(GridView1_RowDataBound);

                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();

                GridView1.Columns[0].Visible = false;

                cn.Close();
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txt = (TextBox)e.Row.FindControl("txtQuantity");
                txt.Text = ((DataRowView)e.Row.DataItem).Row["Quantity"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
            cn.Open();


            foreach(GridViewRow gvr in GridView1.Rows)
            {
                TextBox txt = (TextBox)gvr.FindControl("txtQuantity");

                SqlCommand cmd = new SqlCommand(@"SPUpdateOrderDetail", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orderid", Request["orderid"]);
                cmd.Parameters.AddWithValue("@detailid", gvr.Cells[0].Text);
                cmd.Parameters.AddWithValue("@quantity", txt.Text);
                cmd.Parameters.AddWithValue("@curusername", Helper.GetCurrentUser());
                cmd.ExecuteNonQuery();

            }


            cn.Close();

            Response.Redirect("editaccount.aspx?account_id=" + Request["Account_id"] + "&tab=3");
        }

        
    }
}