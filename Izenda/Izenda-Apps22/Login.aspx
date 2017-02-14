<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<%@ Import Namespace ="System.Data.SqlClient"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" Runat="Server">
    <style>
        #whiteHeader, #blueHeader {
            display:none !important;
        }

        body {
            background-color: #f6f6f6 !important;
        }
        .imgDiv
{
    border: 2px solid #DDDDDD;
    display: inline-block;
    float: left;
    height: 50px;
    left: 32px;
    margin-top: 15px;
    position: relative;
    width: 60px;
    border-right:none !important;
    border-radius: 6px 0px 0px 6px !important;
    background-color:#F0F0F0;
}
.pwdBackground
{
    background-image:url('images/lock.png');
    background-repeat:no-repeat;
    background-position: 20px 11px;
}
.unBackground
{
    background-image:url('images/user.png');
    background-repeat:no-repeat;
    background-position: 17px 14px;
 
}
input[type="text"], input[type="email"], input[type="password"] {
    border: 2px solid #DDDDDD;
    border-radius: 0px 6px 6px 0px;
    font-size: 25px;
    font-weight: 300;
    height: 45px;
    line-height: normal;
    outline: medium none;
    overflow: hidden;
    padding-top:3px;
    padding-bottom:2px;
    padding-left:8px;
    transition: all 0.4s ease-out 0s;
    font-family:Source Sans Pro;
    width: 66%;
    position:relative;
}
.flip-button {
	border: 1px solid transparent !important;
	border-bottom: 1px solid transparent !important;
	display: block !important;
	/*line-height: 1.00 !important;*/
	overflow: hidden !important;
	text-decoration: none !important;
	width: 84% !important;
	cursor:pointer !important;
	margin: 0 auto !important;
	background: #3bc492 !important;
	border-radius: 6px !important;
	color: #fff !important;
	font-size:1.5em !important;
	font-family:Source Sans Pro !important;
	text-align: center !important;
	font-weight: 400 !important;
	position: relative !important;
	top: 0 !important;
	padding-bottom:10px !important;
	padding-top:10px !important;
	margin-bottom:10px !important;
        margin-top:10px !important;
}

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder" Runat="Server">
<div class="page" style="text-align: center;">


	<form id="form1" runat="server" style="text-align: center;">
        <table align="center" style="padding-top:80px">

            <tr>
                <td>


        <div style="background-color: #ffffff;width:400px;height:415px;text-align: center;border: #dddddd 2px solid; display:table;">
		<table style="width: 100%; height: 100%;">
			<tr>
				<td align=center>
                    <div style="padding-top: 10px">
                        <img src="images/uplandlogo.gif"/>
                    </div>
                    
                    <DIV style="WIDTH: 100%">
                        <DIV style="BACKGROUND-IMAGE: url(images/user.png); BORDER-BOTTOM: #dddddd 2px solid; BORDER-LEFT: #dddddd 2px solid; BORDER-TOP: #dddddd 2px solid; BORDER-RIGHT: #dddddd 2px solid; transition: all 0.4s ease-out 0s;" class="imgDiv unBackground">&nbsp;</DIV>
                        
                        <asp:TextBox ID="userNameTextbox" runat="server" CssClass="ms-inputuserfield"></asp:TextBox>
                        
                        <BR>
                        <DIV style="MARGIN-TOP: 10px" class="imgDiv pwdBackground">&nbsp;</DIV>
                        <input id="userPassword" runat="server" type="password" CssClass="ms-inputuserfield"/>
                        
                        
                        
                        <BR>
                        
                        <asp:Button ID="Button1" runat="server" Text="Login" Width="110px" OnClick="Button1_Click" CssClass="flip-button" />

                        

                        </DIV>

			<asp:CustomValidator ID="loginValidator" runat="server" ErrorMessage="Login failed. Please check your user name and password and try again."></asp:CustomValidator></td>
			</tr>
		</table>
        </div>
                    
                </td>

            </tr>
        </table>
		<script runat="server">
  
        
		bool AuthenticateUser(string userName, string password, out bool isAdmin)
		{
            isAdmin = false;


            if (HttpContext.Current.Session["LoginType"].ToString() == "1")
            {

                NameValueCollection nvc = new NameValueCollection();
                nvc.Add("connectionStringName", "adcon");
                nvc.Add("attributeMapUsername", "sAMAccountName");
                System.Web.Security.ActiveDirectoryMembershipProvider ap = new ActiveDirectoryMembershipProvider();
                ap.Initialize("Izenda", nvc);
                if (ap.ValidateUser(userName, password))
                {
                    bool validuser = false;
                    SqlConnection cn = new SqlConnection(HttpContext.Current.Session["ConnectionString"].ToString());
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT     dbo.RPTGROUPUSER.GROUPID
                                        FROM         dbo.LSTUserInformationList INNER JOIN
                                        dbo.RPTGROUPUSER ON dbo.LSTUserInformationList.ItemId = dbo.RPTGROUPUSER.USERID
                                        where name=@userid", cn);
                    cmd.Parameters.AddWithValue("@userid", HttpContext.Current.Session["Domain"].ToString() + userName);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                        validuser = true;
                    dr.Close();
                    cn.Close();

                    Response.Write(HttpContext.Current.Session["Domain"].ToString() + userName);

                    if (validuser)
                        return true;
                    else
                        loginValidator.Text = "You do not have access to that site.";
                    return false;

                }
                else
                {
                    loginValidator.Text = "Invalid Username or Password";
                    return false;
                }
            }
            else
            {
                loginValidator.Text = "Invlaid Login Type";
            }
            return false;
            //return false;
            
			//isAdmin = false;
			
			//if (userName.ToLower() == "admin" || userName.ToLower() =="administrator")
			///	isAdmin = true;
			
			//return true;
		}

			void Button1_Click(object sender, EventArgs args)
			{
				loginValidator.IsValid = true;
				bool isAdmin;
                
				if (AuthenticateUser(userNameTextbox.Text, userPassword.Value, out isAdmin))
				{
					HttpContext.Current.Session["UserName"] = userNameTextbox.Text;
					if (isAdmin)
						HttpContext.Current.Session["Role"] = "Administrator";
					else
						HttpContext.Current.Session["Role"] = "RegularUser";

                    Izenda.AdHoc.AdHocSettings.AdHocConfig.PostLogin(); 
                    
					FormsAuthentication.RedirectFromLoginPage(userNameTextbox.Text, false);
					return;
				}
				loginValidator.IsValid = false;
			}
		</script>

		<div style="text-align: center;">
			&nbsp;</div>
	</form>


</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TrackerPlaceHolder" Runat="Server">
</asp:Content>

