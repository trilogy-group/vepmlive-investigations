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
    public partial class versions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

            cn.Open();

            DataSet ds;
            SqlCommand cmdGetSites;
            SqlDataAdapter da;

            if(!IsPostBack)
            {
                cmdGetSites = new SqlCommand("SELECT release_name + ' (' + convert(varchar(15), release_date,101) + ')' as name, product_release_id from product_release order by release_date desc ", cn);
                cmdGetSites.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmdGetSites);
                ds = new DataSet();
                da.Fill(ds);

                ddlRelease.DataSource = ds;
                ddlRelease.DataTextField = "name";
                ddlRelease.DataValueField = "product_release_id";
                ddlRelease.DataBind();
            }


            cmdGetSites = new SqlCommand("select product_name as [Product Name], Version, 'http://www.epmlive.com/downloads/' + Filename as Filename, currentpassword as Password, convert(varchar(15), DateAdd(d, 7, lastpwdchange), 101) as [Next Pwd Changes] from downloadproducts where release_id=@release_id and spversion=@version and application_id is null", cn);
            cmdGetSites.CommandType = CommandType.Text;
            cmdGetSites.Parameters.AddWithValue("@release_id", ddlRelease.SelectedValue);
            cmdGetSites.Parameters.AddWithValue("@version", ddlSp.SelectedValue);

            da = new SqlDataAdapter(cmdGetSites);
            ds = new DataSet();
            da.Fill(ds);

            GridView2.DataSource = ds;
            GridView2.DataBind();

            cmdGetSites = new SqlCommand("select application as [Product Name], Version, 'http://www.epmlive.com/downloads/' + Filename as Filename, currentpassword as Password, [Next Pwd Changes] from vwApplicationProducts where release_id=@release_id and spversion=@version", cn);
            cmdGetSites.CommandType = CommandType.Text;
            cmdGetSites.Parameters.AddWithValue("@release_id", ddlRelease.SelectedValue);
            cmdGetSites.Parameters.AddWithValue("@version", ddlSp.SelectedValue);

            da = new SqlDataAdapter(cmdGetSites);
            ds = new DataSet();
            da.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();


            cmdGetSites = new SqlCommand("select product_name as [Product Name], Version, 'http://www.epmlive.com/downloads/' + Filename as Filename, currentpassword as Password, convert(varchar(15), DateAdd(d, 7, lastpwdchange), 101) as [Next Pwd Changes] from downloadproducts where spversion=0", cn);
            cmdGetSites.CommandType = CommandType.Text;

            da = new SqlDataAdapter(cmdGetSites);
            ds = new DataSet();
            da.Fill(ds);

            GridView3.DataSource = ds;
            GridView3.DataBind();
        }

        private void loadGrid()
        {

        }
    }
}