<%@ Assembly Name="Microsoft.SharePoint.IdentityModel, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Assembly Name="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c"%> <%@ Page Language="C#" Inherits="Microsoft.SharePoint.IdentityModel.Pages.FormsSignInPage" MasterPageFile="~/_layouts/15/errorv15_epmlive.master"       %> <%@ Import Namespace="Microsoft.SharePoint.WebControls" %> <%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Import Namespace="Microsoft.SharePoint" %> <%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<asp:Content ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	EPM Live - <SharePoint:EncodedLiteral runat="server"  EncodeMethod="HtmlEncode" Id="ClaimsFormsPageTitle" />
</asp:Content>


<asp:Content ContentPlaceHolderId="PlaceHolderMain" runat="server">
 <div id="SslWarning" style="color:red;display:none">
 <SharePoint:EncodedLiteral runat="server"  EncodeMethod="HtmlEncode" Id="ClaimsFormsPageMessage" />
 </div>
  <script language="javascript" >
	if (document.location.protocol != 'https:')
	{
		var SslWarning = document.getElementById('SslWarning');
		SslWarning.style.display = '';
	}
  </script>

  <script src="placeholder.js" ></script>

 
<div class="mainLogin">
<asp:login id="signInControl" FailureText="<%$Resources:wss,login_pageFailureText%>" runat="server" width="100%">
	<layouttemplate>
		<asp:label id="FailureText" class="ms-error" runat="server"/>

    		<div>
        		<img src="EPMLiveByUpland.png" class="loginImg" />
		</div>
    		<div style="width:100%;">
			<div class="imgDiv unBackground">&nbsp;</div>
			<asp:textbox id="UserName" autocomplete="off" runat="server" class="ms-inputuserfield" placeholder="Username" title="Username" style="margin-top:15px;left:-2px;" />
    			<br>

			<div class="imgDiv pwdBackground" style="margin-top:10px;">&nbsp;</div>		
			<asp:textbox id="password" TextMode="Password" autocomplete="off" runat="server" class="" placeholder="Password" title="Password" style="margin-top:10px;left:-2px;" />         
        		<br>
          		<asp:button id="login" commandname="Login" text="<%$Resources:wss,login_pagetitle%>" runat="server" style="margin-top:10px;font-size:16px;cursor:pointer;" class="flip-button" /> 
	  		<asp:checkbox id="RememberMe" text="<%$SPHtmlEncodedResources:wss,login_pageRememberMe%>" runat="server" />
          		
		</div>
            	<div class="footerSection">
			<div>
				<span style="font-size:.8em;"><a href="resetpassword.aspx">Help!&nbsp;&nbsp;I forgot my username or password.</a></span>
			</div>			
			<div style="padding-top:13px;font-size:.7em;">
				<span><a href="http://support.epmlive.com" target="_blank">Support</a></span>&nbsp;|&nbsp;<span><a href="javascript:void(0)" data-uv-lightbox="classic_widget" data-uv-mode="feedback" data-uv-primary-color="#03488d" data-uv-link-color="#007dbf" data-uv-forum-id="161591">Feedback</a></span>&nbsp;|&nbsp;<span><a href="http://epmlive.com/epm-live-service-agreement" target="_blank">Legal</a></span>&nbsp;|&nbsp;<span><a href="http://epmlive.com/privacy" target="_blank">Privacy</a></span>
			</div>

			
		</div>
	
		
</layouttemplate>
 </asp:login>

</div>


<script>



if ($(".ie8").length != 1) {
   $('input').placeholder();   
}



$('#ctl00_PlaceHolderMain_signInControl_UserName').focus();
$('#ctl00_PlaceHolderMain_signInControl_UserName').css('border','2px solid #3498DB');
$('.unBackground').css('border','2px solid #3498DB');
$('.unBackground').css("background-image","url('user_blue.png')");


$('#ctl00_PlaceHolderMain_signInControl_FailureText').addClass('callout left');


if($('#ctl00_PlaceHolderMain_signInControl_FailureText').text())
{
	var unOffset = $('#ctl00_PlaceHolderMain_signInControl_UserName').offset();
	var offsetLeft = unOffset.left - 320;
        var offsetTop = unOffset.top - 18;
        $('#ctl00_PlaceHolderMain_signInControl_FailureText').css('left',offsetLeft);
        $('#ctl00_PlaceHolderMain_signInControl_FailureText').css('top',offsetTop);
	$('#ctl00_PlaceHolderMain_signInControl_FailureText').show();

	$('#ctl00_PlaceHolderMain_signInControl_UserName').keyup(function () { 
		$('#ctl00_PlaceHolderMain_signInControl_FailureText').hide();
	});
		

	$('#ctl00_PlaceHolderMain_signInControl_password').keyup(function () { 
		$('#ctl00_PlaceHolderMain_signInControl_FailureText').hide();
	});
	
}


$('#ctl00_PlaceHolderMain_signInControl_UserName').focus(function() {
    $(this).css('border','2px solid #3498DB');
    $('.unBackground').css('transition','all 0.4s ease-out 0s');
    $('.unBackground').css('border','2px solid #3498DB');
    $('.unBackground').css("background-image","url('user_blue.png')");
});


$('input[name="ctl00$PlaceHolderMain$signInControl$password"]').focus(function() {
    $('#ctl00_PlaceHolderMain_signInControl_password').css('border','2px solid #3498DB');
    $('.pwdBackground').css('transition','all 0.4s ease-out 0s');
    $('.pwdBackground').css('border','2px solid #3498DB');
    $('.pwdBackground').css("background-image","url('lock_blue.png')");
});


$('#ctl00_PlaceHolderMain_signInControl_UserName').blur(function() {
    $(this).css('border','2px solid #DDDDDD');
    $('.unBackground').css('transition','all 0.4s ease-out 0s');
    $('.unBackground').css('border','2px solid #DDDDDD');
    $('.unBackground').css("background-image","url('user.png')");
});

$('input[name="ctl00$PlaceHolderMain$signInControl$password"]').blur(function() {
    $('#ctl00_PlaceHolderMain_signInControl_password').css('border','2px solid #DDDDDD');
    $('.pwdBackground').css('transition','all 0.4s ease-out 0s');
    $('.pwdBackground').css('border','2px solid #DDDDDD');
    $('.pwdBackground').css("background-image","url('lock.png')");
});

</script>

<!-- UserVoice JavaScript SDK (only needed once on a page) -->
<script>(function(){var uv=document.createElement('script');uv.type='text/javascript';uv.async=true;uv.src='//widget.uservoice.com/uFW21LPmYTawwUX9btPog.js';var s=document.getElementsByTagName('script')[0];s.parentNode.insertBefore(uv,s)})()</script>



</asp:Content>
