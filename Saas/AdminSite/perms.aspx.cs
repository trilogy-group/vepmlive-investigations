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
    public partial class perms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void fillGrid()
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
            cn.Open();

            SqlCommand cmdUserPerms = new SqlCommand("spUserPerms", cn);
            cmdUserPerms.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter daUserPerms = new SqlDataAdapter(cmdUserPerms);
            DataSet dsUserPerms = new DataSet();
            daUserPerms.Fill(dsUserPerms);

            GridView1.DataSource = dsUserPerms.Tables[0];
            GridView1.DataBind();

            cn.Close();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            lblUsername.Text = GridView1.Rows[e.NewEditIndex].Cells[1].Text;

            string permText = "";

            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
            cn.Open();

            SqlCommand cmdUserInfo = new SqlCommand("select uid from [users] where username=@username", cn);
            cmdUserInfo.CommandType = CommandType.Text;
            cmdUserInfo.Parameters.AddWithValue("@username", lblUsername.Text);

            SqlDataReader dReader = cmdUserInfo.ExecuteReader();

            if(dReader.Read())
                hdnUserId.Value = dReader.GetGuid(0).ToString();

            dReader.Close();

            SqlCommand cmdPerms = new SqlCommand("select * from PERMISSION order by [name]", cn);
            cmdPerms.CommandType = CommandType.Text;

            SqlDataAdapter daPerms = new SqlDataAdapter(cmdPerms);
            DataSet dsPerms = new DataSet();
            daPerms.Fill(dsPerms);

            foreach(DataRow dr in dsPerms.Tables[0].Rows)
            {
                SqlCommand cmdPermsUser = new SqlCommand("select * from vwPermissionIdByUsername where username=@username and permission_id=@permid", cn);
                cmdPermsUser.CommandType = CommandType.Text;
                cmdPermsUser.Parameters.AddWithValue("@username", lblUsername.Text);
                cmdPermsUser.Parameters.AddWithValue("@permid", dr["permission_id"].ToString());
                dReader = cmdPermsUser.ExecuteReader();
                string isChecked = "";
                if(dReader.Read())
                    isChecked = " checked ";
                permText = permText + "<input type=\"checkbox\" name=\"perms\" value=\"" + dr["permission_id"].ToString() + "\"" + isChecked + "> " + dr["name"].ToString() + "<br>";
                dReader.Close();
            }

            cn.Close();

            lblEditPerms.Text = permText;

            pnlEdit.Visible = true;
            pnlMain.Visible = false;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            string permList = Request["perms"];

            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
            cn.Open();

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM USER_PERMISSION where user_id=@username", cn);
            cmdDelete.CommandType = CommandType.Text;
            cmdDelete.Parameters.AddWithValue("@username", hdnUserId.Value);
            cmdDelete.ExecuteNonQuery();

            string[] perms = permList.Split(',');
            SqlCommand cmdInsert = null;
            foreach(string perm in perms)
            {
                cmdInsert = new SqlCommand("INSERT INTO USER_PERMISSION (user_id,permission_id) VALUES (@username,@permid)", cn);
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.Parameters.AddWithValue("@username", hdnUserId.Value);
                cmdInsert.Parameters.AddWithValue("@permid", perm);
                cmdInsert.ExecuteNonQuery();
            }

            cn.Close();

            pnlEdit.Visible = false;
            pnlMain.Visible = true;
            fillGrid();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlEdit.Visible = false;
            pnlMain.Visible = true;
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
            cn.Open();

            SqlCommand cmdDelete = new SqlCommand("SP_DeleteUser", cn);
            cmdDelete.CommandType = CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("@username", GridView1.Rows[e.RowIndex].Cells[1].Text);
            cmdDelete.ExecuteNonQuery();

            cn.Close();

            fillGrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if(e.Row.Cells[1].Text.ToUpper() == HttpContext.Current.User.Identity.Name.ToUpper())
            //e.Row.Cells[0].Text = " ";
        }
    }
}