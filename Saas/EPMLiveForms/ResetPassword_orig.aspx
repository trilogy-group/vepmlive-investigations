<%@ Assembly Name="Microsoft.SharePoint.IdentityModel, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Assembly Name="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c"%>
<%@ Page Language="C#" Inherits="changepwd" CodeFile="contact.aspx.cs" MasterPageFile="~/_layouts/simple.master"       %>
<%@ Import Namespace="Microsoft.SharePoint.WebControls" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Import Namespace="Microsoft.SharePoint" %> <%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
Reset
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderPageTitleInTitleArea" runat="server">
	
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderSiteName" runat="server"/>
<asp:Content ContentPlaceHolderId="PlaceHolderMain" runat="server">



<script runat="server">
  protected void btnSubmit_Click(object sender, EventArgs e)
  {
	lblBadEmail.Visible = false;
        lblEmailNotFound.Visible = false;
        if(txtResetEmail.Text.Trim() != "")
        {
            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
               + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
               + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
               + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
               + @"[a-zA-Z]{2,}))$";
            if (Regex.Matches(txtResetEmail.Text, patternStrict).Count > 0)
            {
                accounts.Service accts = new accounts.Service();
		accts.Credentials = new System.Net.NetworkCredential("adaccessuser", "lkf@$farFA", "epm");

                int ret = accts.resetPassword(txtResetEmail.Text);
                if (ret == 0)
                {
                    pnlResetPassword.Visible = false;
                    pnlResetPasswordDone.Visible = true;
                }
                else if(ret==1)
                {
                    lblEmailNotFound.Visible = true;
                }
            }
            else
            {
                lblBadEmail.Visible = true;
            }
            
            
        }
        else
        {
            lblBadEmail.Visible = true;
        }
  }
</script>



 <div id="SslWarning" style="color:red;display:none">
 <SharePoint:EncodedLiteral runat="server"  EncodeMethod="HtmlEncode" Id="ClaimsFormsPageMessage" />
 </div>
  <script language="javascript" >
	//if (document.location.protocol != 'https:')
	//{
	//	var SslWarning = document.getElementById('SslWarning');
	//	SslWarning.style.display = '';
	//}



  </script>
<style>

.tb7 {
	width: 221px;
	background: transparent url('bg.jpg') no-repeat;
	color : #747862;
	height:20px;
	border:0;
	padding:4px 8px;
	margin-bottom:0px;
}

.tb10 {
	background-image:url(form_bg.jpg);
	background-repeat:repeat-x;
	border:1px solid #d1c7ac;
	width: 230px;
	color:#333333;
	padding:3px;
	margin-right:4px;
	margin-bottom:8px;
	font-family:tahoma, arial, sans-serif;
	height:24px;
}

.t1 {

	height:10px;
	font-size: 15px;
	


}

input{
    font-size: 16pt;
}


</style>




<script type="text/javascript" src="hint-textbox.js"></script>


	<layouttemplate>
		
		<table width="250" border="0">
		<tr>
			<td colspan="2"><img src='epmlive-logo.png' /></td>

		</tr>
		<tr><td height="20"></td></tr>
		</table>		


		<asp:label id="FailureText" class="ms-error" runat="server"/></br>
		

		
		<table width="300" border="0">
		<tr><td class="t1">Enter your email address below and we'll reset your password and send it to you in an email. </td></tr>
		
		</table></br>

<asp:Panel ID="pnlResetPassword" runat="server">

		<table width="300" border="0">
		<tr>
			<td width="100%" align="right"><asp:textbox id="txtResetEmail" autocomplete="off" runat="server" class="tb10" width="100%" title="Username" /></td>
			<td width="20%"></td>
		</tr>
		<tr>
			<td colspan="2"> 
                                                            <asp:Label runat="server" id="lblBadEmail" ForeColor="red" Text="<br />That is not a valid E-Mail address." Visible="false"></asp:Label>
                                                                       <asp:Label runat="server" ID="lblEmailNotFound" ForeColor="red" Text="<br />That E-Mail address was not found in our system." Visible="false"></asp:Label>                                            
</td>
		</tr>
		<tr>
			
			<td align="right" width="40"><asp:imagebutton id="login2" onclick="btnSubmit_Click" commandname="" src="btn_reset.png" text="<%$Resources:wss,login_pagetitle%>" runat="server" /></td>
			<td width="20%"></td>
		</tr>
		<!--<tr><td nowrap="nowrap" class="t1"><SharePoint:EncodedLiteral runat="server" text="<%$Resources:wss,login_pagePassword%>" EncodeMethod='HtmlEncode'/></td></tr>
		<tr>
			
			<td width=100%"><asp:textbox id="password" TextMode="Password" autocomplete="off" runat="server" class="tb10" width="80%" /></td>
		</tr>-->
		</table>
</asp:Panel>
<asp:Panel ID="pnlResetPasswordDone" runat="server" Visible="false">
                                                    <font class="text">
                                                        Your password has been reset<br /><br />
                                                        An Email has been sent with your new password.
                                                    </font>
                                                </asp:Panel>

		<!--<table width="250" border="0">
		<tr>
			
			<td width="70%"></td>
			<td align="right" width="40"><asp:imagebutton id="PasswordReset" commandname="" src="btn_sign-in.png" text="<%$Resources:wss,login_pagetitle%>" runat="server" /></td>

		</tr>
		<tr>
			<td colspan="2"><asp:checkbox id="RememberMe" text="<%$SPHtmlEncodedResources:wss,login_pageRememberMe%>" runat="server" /></td>
		</tr>
		
		</table>-->
		<!--<table border="0">
		<tr><td height="30" colspan="0"><a href="DefaultCust.aspx">Back to Sign-in Page</a></td></tr>
		</table>-->
		
	</layouttemplate>


</asp:Content>
