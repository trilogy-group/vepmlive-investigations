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
    public partial class reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedIndex == 0)
            {
                GridView1.Visible = false;
            }
            else
            {
                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

                cn.Open();

                DataSet ds;
                SqlCommand cmdGetSites;
                SqlDataAdapter da;

                cmdGetSites = new SqlCommand("AllAccountInfo", cn);
                cmdGetSites.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter(cmdGetSites);
                ds = new DataSet();
                da.Fill(ds);

                cn.Close();

                GridView1.DataSource = ds.Tables[DropDownList1.SelectedIndex - 1];
                GridView1.DataBind();
                GridView1.Visible = true;

            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

            cn.Open();

            DataSet ds;
            SqlCommand cmdGetSites;
            SqlDataAdapter da;

            cmdGetSites = new SqlCommand("AllAccountInfo", cn);
            cmdGetSites.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter(cmdGetSites);
            ds = new DataSet();
            da.Fill(ds);

            cn.Close();

            gv2.DataSource = ds.Tables[DropDownList1.SelectedIndex - 1];
            gv2.DataBind();
            gv2.Visible = true;

            string strFileName = DropDownList1.SelectedItem.Text + " Export.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=" + strFileName);
            Response.ContentType = "application/excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            gv2.RenderControl(htw);

            Response.Write(sw.ToString());
            Response.End();
        }
    }
}