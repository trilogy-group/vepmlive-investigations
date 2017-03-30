using System;
using System.Data.SqlClient;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveAccountManagement
{
    public partial class addaccount : LayoutsPageBase
    {

        protected Guid newid;

        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection cn = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn = new SqlConnection(Settings.getConnectionString());
                cn.Open();
            });


            string username = EPMLiveCore.CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName);
            Guid uid = Guid.Empty;
            newid  = Guid.NewGuid();

            try
            {
                username = username.Split('|')[1];
            }catch{};

            //username = "epm\\jhughes";

            string email = "";

            SqlCommand cmd = new SqlCommand("SELECT UID,email from USERS where username like @username", cn);
            cmd.Parameters.AddWithValue("@username", username);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                uid = dr.GetGuid(0);
                email = dr.GetString(1);
            }

            dr.Close();

            if(uid != Guid.Empty)
            {
                int maxusers = 1;
                int monthsfree = 1;

                if(email.Contains("@epmlive.com") || email.Contains("@lmrsolutions.com"))
                {
                    maxusers = 10;
                }


                cmd = new SqlCommand("INSERT INTO ACCOUNT (account_id, owner_id,maxusers,accountdescription,creator_id,diskquota,version,monthsfree) VALUES (@newid, @owner_id,@maxusers,@desc,@owner_id,500,1,@monthsfree)", cn);
                cmd.Parameters.AddWithValue("@owner_id", uid);
                cmd.Parameters.AddWithValue("@newid", newid);
                cmd.Parameters.AddWithValue("@desc", txtAccount.Text);
                cmd.Parameters.AddWithValue("@maxusers", maxusers);
                cmd.Parameters.AddWithValue("@monthsfree", monthsfree);

                cmd.ExecuteNonQuery();


                cmd = new SqlCommand("INSERT INTO ACCOUNT_USERS (account_id, user_id) VALUES (@newid, @owner_id)", cn);
                cmd.Parameters.AddWithValue("@owner_id", uid);
                cmd.Parameters.AddWithValue("@newid", newid);
                cmd.ExecuteNonQuery();

                if(!String.IsNullOrEmpty(Request["src"]))
                {
                    if(Request["src"] == "newsite")
                        pnlClose2.Visible = true;
                }
                else
                    pnlClose.Visible = true;
            }
            cn.Close();
        }

    }
}