using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text;

namespace EPMLiveAccountManagement.Layouts.epmlive
{
    public partial class ManageAccount : LayoutsPageBase
    {
        StringBuilder sbSub = new StringBuilder();
        StringBuilder sbUser = new StringBuilder();
        StringBuilder sbDisk = new StringBuilder();
        int currentSubLevel = 0;
        
        decimal maxUsers = 0;
        decimal maxStorage = 0;
        string sStorage = "0";
        int currentUsers = 0;
        int inTrial = 0;
        DateTime expiration;

        private string subid = "";
        private int accountref = 0;
        protected string strWidth;
        protected string strDiskWidth = "0";

        protected string contractLevel = "2";

        private string productSKU;
        protected bool isOwner = false;

        private bool lockusers = false;

        protected int billingSystem = 1;

        protected int activationtype = 1;

        protected void Page_Load(object sender, EventArgs e)
        {

            
            SPSite csite = SPContext.Current.Site;
            SPWeb cweb = SPContext.Current.Web;

            //if(!EPMLiveCore.CoreFunctions.DoesCurrentUserHaveFullControl(cweb))
            //    Response.Redirect("AccessDenied.aspx");

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(csite.ID))
                {
                    using(SPWeb web = site.OpenWeb(cweb.ID))
                    {
                        SqlConnection cn = null;
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            cn = new SqlConnection(Settings.getConnectionString());
                            cn.Open();
                        });

                        contractLevel = EPMLiveCore.CoreFunctions.getContractLevel();

                        loadAccount(site, cn);

                        if(activationtype == 1 || activationtype == 2)
                        {
                            switch(contractLevel)
                            {
                                case "2":
                                    productSKU = "SKU-20000000";
                                    break;
                                case "3":
                                    break;
                                case "4":
                                    productSKU = "SKU-40000000";
                                    break;
                            }

                            lblSubscription.Text = sbSub.ToString();

                            //===============Users=======================
                            if(maxUsers == -1)
                            {
                                lblMaxUsers.Text = "Unlimited";
                                strWidth = "0";
                            }
                            else
                            {
                                lblMaxUsers.Text = maxUsers.ToString();
                                float tblWidth = (currentUsers * 100) / (float)maxUsers;

                                strWidth = tblWidth.ToString();
                            }

                            lblUserCount.Text = currentUsers.ToString();



                            //===============Disk=======================
                            float diskusage = (float)site.Usage.Storage / 1024 / 1024;

                            if(maxStorage > 1000)
                            {
                                lblMaxDisk.Text = (maxStorage / 1000) + " GB";
                            }
                            else
                            {
                                lblMaxDisk.Text = maxStorage + " MB";
                            }

                            if(diskusage > 1000)
                            {
                                lblDiskCount.Text = (diskusage / 1000).ToString("#.0") + " GB";
                            }
                            else
                            {
                                lblDiskCount.Text = diskusage.ToString("#.0") + " MB";
                            }

                            float tblWidth1 = (diskusage * 100) / (float)maxStorage;

                            if(tblWidth1 > 100)
                                strDiskWidth = "100";
                            else
                                strDiskWidth = tblWidth1.ToString();

                        }
                        cn.Close();
                    }
                }
            });
        }
           
        private void loadAccount(SPSite site, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("2012SP_GetActivationInfo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@siteid", site.ID);
            cmd.Parameters.AddWithValue("@username", EPMLiveCore.CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName));

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            try
            {
                activationtype = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            catch { }
            string owneruname = "";

            if(activationtype == 3)
            {
                cmd = new SqlCommand("2010SP_GetSiteAccountNums", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@siteid", site.ID);
                cmd.Parameters.AddWithValue("@contractLevel", contractLevel);
                SqlDataReader dr2 = cmd.ExecuteReader();

                if(dr2.Read())
                {
                    owneruname = dr2.GetString(13);
                }
                dr2.Close();
                if(owneruname.ToLower() == EPMLiveCore.CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName).ToLower())
                {
                    isOwner = true;
                }
                return;
            }

            cmd = new SqlCommand("2010SP_GetSiteAccountNums", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@siteid", site.ID);
            cmd.Parameters.AddWithValue("@contractLevel", contractLevel);
            SqlDataReader dr = cmd.ExecuteReader();
            

            if(dr.Read())
            {
                accountref = dr.GetInt32(10);
                
                if(!dr.IsDBNull(0))
                    maxUsers = dr.GetInt32(0);
                
                if(!dr.IsDBNull(15))
                    maxStorage = dr.GetInt32(15);

                currentUsers = dr.GetInt32(1);

                inTrial = dr.GetInt32(4);
                expiration = dr.GetDateTime(9);

                owneruname = dr.GetString(13);

                try
                {
                    lockusers = dr.GetBoolean(16);
                }
                catch { }
            }
            dr.Close();
            if(owneruname.ToLower() == EPMLiveCore.CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName).ToLower())
            {
                isOwner = true;
            }
            

            if(inTrial == 1)
                activationtype = 3;

            cmd = new SqlCommand("SELECT TOP 1 plimusReferenceNumber FROM ORDERS where ACCOUNT_REF=@accountref and contractid='111821378'", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@accountref", accountref);
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                subid = dr.GetString(0);
            }
            dr.Close();

            
        }        
    }
}
