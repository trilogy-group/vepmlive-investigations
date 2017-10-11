<%@ Assembly Name="Microsoft.SharePoint.IdentityModel, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Assembly Name="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c"%> 
<%@ Import Namespace="Microsoft.SharePoint.WebControls" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" Inherits="changepwd" CodeFile="contact.aspx.cs" MasterPageFile="errorv15_epmlive.master"       %>
<asp:Content ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	EPM Live - Reset Password
</asp:Content>


<asp:Content ContentPlaceHolderId="PlaceHolderMain" runat="server">
 <div id="SslWarning" style="color:red;display:none">
 <SharePoint:EncodedLiteral runat="server"  EncodeMethod="HtmlEncode" Id="ClaimsFormsPageMessage" />
 </div>

<script src="placeholder.js" ></script>
<script src="./Bootstrap/js/bootstrap.min.js" ></script>
<link href='./Bootstrap/css/bootstrap.min.css' rel='stylesheet' type='text/css'>

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
  
 
<div class="mainLoginReset">

	
		<div>
        		<img src="EPMLiveByUpland.png" class="loginImg" />
		</div>
    		<div style="width:100%;">
			<asp:Panel ID="pnlResetPassword" runat="server">
			<div class="imgDiv resetBackground">&nbsp;</div>
			<asp:textbox id="txtResetEmail" autocomplete="off" runat="server" class="tb10" name="Email Address" title="Email Address" placeholder="Email Address" style="margin-top:15px;left:-2px;" />
			        
        		<br>
          		<asp:button id="login2" onclick="btnSubmit_Click" runat="server" style="margin-top:10px;font-size:16px;cursor:pointer;" class="flip-button" name="Email Address" text="Reset Password" /> 
          		</asp:panel>
		</div>
            	<div class="footerSection">
			
		</div>
		<div class="alert" id="alertError">
			<asp:Label runat="server" id="lblBadEmail" Text="This is not a valid address." Visible="false"></asp:Label>
			<asp:Label runat="server" ID="lblEmailNotFound" Text="This address was not found in our system." Visible="false"></asp:Label>
		</div>
		<asp:Panel ID="pnlResetPasswordDone" runat="server" Visible="false">
                <div class="alert alert-success">
                        <strong>Success!</strong>&nbsp;&nbsp;Your password has been reset.&nbsp;&nbsp;An email has been sent containing your new password.
                </div>
		</asp:Panel>


</div>






<script>


if ($(".ie8").length != 1) {
   $('input').placeholder();   
}


$('#ctl00_PlaceHolderMain_txtResetEmail').focus();
$('#ctl00_PlaceHolderMain_txtResetEmail').css('border','2px solid #3498DB');
$('.resetBackground').css('border','2px solid #3498DB');
$('.resetBackground').css("background-image","url('mail_blue.png')");




// if there are no alerts
if($('#ctl00_PlaceHolderMain_lblBadEmail').length == 0 && $('#ctl00_PlaceHolderMain_lblEmailNotFound').length == 0 && $('#ctl00_PlaceHolderMain_pnlResetPasswordDone').length == 0)
{
	$('.alert').hide();
}
else
{

if($('#ctl00_PlaceHolderMain_pnlResetPasswordDone').length != 0)
{
	$('#alertError').hide();
}

$('#ctl00_PlaceHolderMain_txtResetEmail').keyup(function () { 
	$('.alert').hide();
});
		
}



//$('#ctl00_PlaceHolderMain_signInControl_FailureText').addClass('callout left');


//if($('#ctl00_PlaceHolderMain_signInControl_FailureText').text())
//{
//	var unOffset = $('#ctl00_PlaceHolderMain_signInControl_UserName').offset();
//	var offsetLeft = unOffset.left - 320;
//        var offsetTop = unOffset.top - 18;
//        $('#ctl00_PlaceHolderMain_signInControl_FailureText').css('left',offsetLeft);
//        $('#ctl00_PlaceHolderMain_signInControl_FailureText').css('top',offsetTop);
//	$('#ctl00_PlaceHolderMain_signInControl_FailureText').show();

//	$('#ctl00_PlaceHolderMain_signInControl_UserName').keyup(function () { 
//		$('#ctl00_PlaceHolderMain_signInControl_FailureText').hide();
//	});
		

//	$('#ctl00_PlaceHolderMain_signInControl_password').keyup(function () { 
//		$('#ctl00_PlaceHolderMain_signInControl_FailureText').hide();
//	});
	
//}


$('#ctl00_PlaceHolderMain_txtResetEmail').focus(function() {
    $(this).css('border','2px solid #3498DB');
    $('.resetBackground').css('transition','all 0.4s ease-out 0s');
    $('.resetBackground').css('border','2px solid #3498DB');
    $('.resetackground').css("background-image","url('mail_blue.png')");
});



$('#ctl00_PlaceHolderMain_txtResetEmail').blur(function() {
    $(this).css('border','2px solid #DDDDDD');
    $('.resetBackground').css('transition','all 0.4s ease-out 0s');
    $('.resetBackground').css('border','2px solid #DDDDDD');
    $('.resetBackground').css("background-image","url('mail.png')");
});



</script>





</asp:Content>
