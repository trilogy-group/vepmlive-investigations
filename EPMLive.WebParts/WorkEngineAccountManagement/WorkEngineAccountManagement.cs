using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace EPMLiveWebParts.WorkEngineAccountManagement
{
    [ToolboxItemAttribute(false)]
    public class WorkEngineAccountManagement : WebPart
    {
        bool expired = false;
        int max;
        int count;
        Guid accountid;
        string ownerusername;
        string owneremail;
        string ownername;
        int billingtype = 0;
        int accountref;
        int inTrial = 0;
        protected override void CreateChildControls()
        {
        }

        protected override void Render(HtmlTextWriter writer)
        {

            writer.WriteLine(@"
            <script language=""Javascript"">
                function showResDelMessage()
                {               
                    var id = SP.UI.Status.addStatus('Warning', 'Users deleted from this resource pool will be removed from the site collection. You must be a site administrator to perform this action.', true);
                    SP.UI.Status.setStatusPriColor(id, 'red');
                }

                SP.SOD.executeOrDelayUntilScriptLoaded(showResDelMessage, 'SP.js'); 
            </script>
            ");
            
            

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    using(SPSite site = new SPSite(SPContext.Current.Site.ID))
                    {
                        if(site.WebApplication.Features[new Guid("19e6ae14-9e68-44fa-9a08-c1c4514bf12e")] != null)
                        {
                            try
                            {

                                MethodInfo m;

                                Assembly assemblyInstance = Assembly.Load("EPMLiveAccountManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
                                Type thisClass = assemblyInstance.GetType("EPMLiveAccountManagement.Settings", true, true);
                                m = thisClass.GetMethod("getConnectionString");
                                string sConn = (string)m.Invoke(null, new object[] {  });

                                SqlConnection cn = new SqlConnection(sConn);
                                cn.Open();

                                SqlCommand cmd = new SqlCommand("2010SP_GetSiteAccountNums", cn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@siteid", site.ID);
                                cmd.Parameters.AddWithValue("@contractLevel", EPMLiveCore.CoreFunctions.getContractLevel());

                                SqlDataReader dr = cmd.ExecuteReader();
                                bool lockusers = false;
                                if(dr.Read())
                                {
                                    try
                                    {
                                        expired = dr.GetBoolean(6);
                                    }
                                    catch { }
                                    max = dr.GetInt32(0);
                                    count = dr.GetInt32(1);
                                    accountid = dr.GetGuid(2);
                                    ownerusername = dr.GetString(13);
                                    owneremail = dr.GetString(14);
                                    ownername = dr.GetString(5);
                                    billingtype = dr.GetInt32(11);
                                    accountref = dr.GetInt32(10);
                                    inTrial = dr.GetInt32(4);

                                    try
                                    {
                                        lockusers = dr.GetBoolean(16);
                                    }
                                    catch { }
                                }
                                dr.Close();

                                cmd = new SqlCommand("SP_GetExclusions", cn);
                                cmd.CommandType = CommandType.StoredProcedure;

                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                DataSet ds = new DataSet();
                                da.Fill(ds);

                                int billingSystem = 1;

                                cmd = new SqlCommand("SELECT TOP 1 plimusReferenceNumber,billingsystem FROM vwORDERS where ACCOUNT_REF=@accountref and contractlevel=@contractlevel", cn);
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@accountref", accountref);
                                cmd.Parameters.AddWithValue("@contractlevel", EPMLiveCore.CoreFunctions.getContractLevel(site));
                                dr = cmd.ExecuteReader();
                                if(dr.Read())
                                {
                                    if(!dr.IsDBNull(1))
                                        billingSystem = dr.GetInt32(1);
                                }
                                dr.Close();

                                cn.Close();
                                float tblWidth = 0;
                                if(max != 0)
                                    tblWidth = (count * 100) / max;

                                if (tblWidth > 100)
                                    tblWidth = 100;

                                string strBarColor = "FF0000";
                                if ((max - count) <= 1)
                                    strBarColor = "FF0000";
                                else if ((max - count) < 5)
                                    strBarColor = "FFFF00";
                                else
                                    strBarColor = "009900";

                                string strWidth = tblWidth.ToString();


                                //SPQuery query = new SPQuery();
                                //query.Query = "<Where><And><Eq><FieldRef Name='Approved'/><Value Type='Boolean'>1</Value></Eq><Eq><FieldRef Name='CanLogin'/><Value Type='Boolean'>1</Value></Eq></And></Where>";

                                //SPList list = SPContext.Current.Web.Lists.TryGetList("Resources");
                                //int resCount = 0;
                                //if(list != null)
                                //{
                                //    SPListItemCollection lic = list.GetItems(query);
                                //    foreach(SPListItem li in lic)
                                //    {
                                //        try
                                //        {
                                //            SPFieldUserValue uv = new SPFieldUserValue(site.RootWeb, li["SharePointAccount"].ToString());

                                //            DataRow[] drows = ds.Tables[0].Select("username='" + EPMLiveCore.CoreFunctions.GetRealUserName(uv.User.LoginName) + "'");

                                //            if(drows.Length == 0)
                                //                resCount++;
                                //        }
                                //        catch { }
                                //    }
                                //}

                                string url = ((SPContext.Current.Web.ServerRelativeUrl == "/") ? "" : SPContext.Current.Web.ServerRelativeUrl);

                                writer.WriteLine(@"
                                    <script language=""javascript"">
                                        //function purchase()
                                        //{
                                        //    window.open('" + url + @"/_layouts/epmlive/purchase.aspx');
                                        //}
                                        function purchase()
                                        {
                                            SP.UI.ModalDialog.showModalDialog({url: '" + url + @"/_layouts/epmlive/manageaccount.aspx',width: 800,height: 600,dialogReturnValueCallback: SP.UI.ModalDialog.RefreshPage});

                                        }
                                        function purchaseclose()
                                        {
                                            location.href = location.href;
                                        }
                                    </script>
                                    <table cellpadding=""5"" cellspacing=""0"" width=""100%"">
                                        <tr>
                                            <td width=""100%"" valign=""top"">
                                                This Resource Pool is associated with Account Owner <b>" + ownername + @"</b>. Only Site Collection Administrators of this Site Collection have permission to add and delete users from this Resource Pool. However, other users can make requests. <br><br>
                                                Additionally, only resources in this Resource Pool can be added as Site Members to Workspaces created within this Site Collection.

                                            </td>");

                                if(ownerusername.ToLower() == EPMLiveCore.CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName).ToLower() && !lockusers)
                                {
                                    

                                    if(billingSystem == 2 || inTrial == 1)
                                    {
                                        writer.WriteLine(@"<td style=""padding-right:10px;"" valign=""center"">
                                                                    <a href=""#"" onclick=""javascript:purchase();""><img src=""/_layouts/epmlive/images/manageaccount.gif"" border=""0""></a><br>
                                                                    <br>");

                                        //writer.WriteLine(@"                <a href=""" + ((site.ServerRelativeUrl == "/") ? "" : site.ServerRelativeUrl) + @"/_layouts/epmlive/manageaccount.aspx""><img src=""/_layouts/epmlive/images/editaccount.gif"" border=""0""></a>
                                        writer.WriteLine(@" </td>");
                                        billingtype = 0;
                                    }
                                    else
                                    {
                                        writer.WriteLine(@"<td style=""padding-right:10px;"" valign=""center"">
                                                                    <a href=""#"" onclick=""javascript:purchase();""><img src=""/_layouts/epmlive/images/manageaccount.gif"" border=""0""></a><br>
                                                                    <br>");

                                        //writer.WriteLine(@"                <a href=""" + ((site.ServerRelativeUrl == "/") ? "" : site.ServerRelativeUrl) + @"/_layouts/epmlive/manageaccount.aspx""><img src=""/_layouts/epmlive/images/editaccount.gif"" border=""0""></a>
                                        writer.WriteLine(@" </td>");
                                    }
                                }

                                if(billingtype != 2)
                                {


                                    writer.WriteLine(@"<td align=""right"" valign=""top"">
                                                <table width=""400"">
                                                    <tr>
                                                        <td class=""ms-toolbar"">
                                                            <strong>" + count + @" out of " + max + @" accounts have been used<br></strong>
                                                        </td>
                                                    </tr>
                                                    <tr style=""height:5px"">
                                                        <td class=""ms-toolbar"" style=""border:  1px solid #c9c9c9;height:5px"">
                                                            <table width=""" + strWidth + @"%"" bgcolor=""#" + strBarColor + @""" style=""height:5px"">
                                                                <tr>
                                                                    <td style=""font-size:1pt""><img src=""/_layouts/images/blank.gif"" height=""5""/></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    
                                                </table>
                                            </td>");

                                    //<tr>
                                    //                    <td class=""ms-toolbar"" align=""left"">
                                    //                        <font style=""font-size:9px"">This Resource Pool is currently using " + resCount + @" of " + count + @" purchased accounts.  Please keep in mind that other Resource Pools owned by " + ownername + @" may be utilizing purchased accounts as well.  </font>
                                    //                    </td>
                                    //                </tr>
                                }

                                writer.WriteLine(@"</tr>
                                    </table>
                                ");
                            }
                            catch(Exception ex)
                            {
                                writer.Write("Error: " + ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    writer.Write("Error: " + ex.Message);
                }
            });

            
        }
    }
}
