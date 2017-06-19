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

<script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+'://platform.twitter.com/widgets.js';fjs.parentNode.insertBefore(js,fjs);}}(document,'script','twitter-wjs');</script>
 
<div class="loginContainer">
<div class="imgWrap"><img src="https://secure.aadcdn.microsoftonline-p.com/~Live.SiteContent.MSOID.Customization/~17.0.12/~/~/~/~/AADLogin/Office365/default/illustration.jpg" style="width:100%" id="bgimg" /></div>
<div class="loginMain">
<div class="loginMain-container">
<div><img src="epmlive-logo.png" style="margin-bottom:30px;" /></div>
	
<asp:login id="signInControl" FailureText="<%$Resources:wss,login_pageFailureText%>" runat="server" width="100%">
	<layouttemplate>
		<asp:label id="FailureText" class="ms-error" runat="server"/>
		<table width="100%" id="loginTable">
		<tr>
			<!--<td nowrap="nowrap" style="font-size:16px;padding-right:10px;"><SharePoint:EncodedLiteral runat="server" text="<%$Resources:wss,login_pageUserName%>" EncodeMethod='HtmlEncode'/></td>-->
			<td width="100%" style="text-align:left;">
				
				<asp:textbox id="UserName" autocomplete="off" runat="server" class="ms-inputuserfield jq_watermark" placeholder="Username" style="margin-bottom:5px;" title="Username" />
			</td>
		</tr>
		<tr>
			<!--<td nowrap="nowrap" style="font-size:16px;padding-right:10px;"><SharePoint:EncodedLiteral runat="server" text="<%$Resources:wss,login_pagePassword%>" EncodeMethod='HtmlEncode'/></td>-->
			<td width="100%" style="text-align:left;">
				
				<asp:textbox id="password" TextMode="Password" autocomplete="off" runat="server" class="ms-inputuserfield jq_watermark" placeholder="Password" title="Password" />
			</td>
		</tr>
		<tr>
			<td colspan="2" align="left"><asp:button id="login" commandname="Login" text="<%$Resources:wss,login_pagetitle%>" runat="server" style="margin-top:10px;font-size:16px;cursor:pointer;" class="loginButton" /></td>
		</tr>
		<tr>
			<td colspan="2" style="text-align:left;padding-top:20px;"><asp:checkbox id="RememberMe" text="<%$SPHtmlEncodedResources:wss,login_pageRememberMe%>" runat="server" /></td>
		</tr>
                <tr><td style="height:30px;">&nbsp;</td></tr>
		<tr>
			<td style="text-align:left;" class="footerLinks">
				<span><a href="http://support.epmlive.com" target="_blank">Support</a></span>&nbsp;|&nbsp;<span><a href="http://support.epmlive.com" target="_blank">Feedback</a></span>&nbsp;|&nbsp;<span><a href="http://support.epmlive.com" target="_blank">Legal</a></span>&nbsp;|&nbsp;<span><a href="http://support.epmlive.com" target="_blank">Privacy</a></span>			
			</td>
		</tr>
		<tr><td style="height:30px;">&nbsp;</td></tr>
		
		</table>
	</layouttemplate>
 </asp:login>


	
</div>

</div>


</div>



<script>




(function($){
  var pr = 0, bgWidth = true, bgResize;

  bgResize = function(){
    var wr = $(window).width() / $(window).height();

    if(wr > pr && !bgWidth) {
      $('#bgimg').css('width', '100%').css('height', '');
      bgWidth = true;
    } else if(wr < pr && bgWidth) {
      $('#bgimg').css('height', '100%').css('width', '');
      bgWidth = false;
    }
  };

  $(document).ready(function() {
    var img = $('#bgimg');
    if(img.height()) {
      pr = $('#bgimg').width() / $('#bgimg').height();
      bgResize();
    } else {
      img.load(function(){
        pr = $('#bgimg').width() / $('#bgimg').height();
        bgResize();
      });
    }

    $(window).resize(bgResize);
    //prettyPrint();
  });
})(jQuery);


</script>

<script>

$(document).ready(function() {
      if (navigator.userAgent.match(/MSIE 7.0/i) ){
		// do nothing
      }
	else
	{
$('#loginTable').append("<tr class='twitterRow'><td><a class='twitter-timeline' href='https://twitter.com/epmliveproduct' data-widget-id='261551360271581184'>Tweets by @epmliveproduct</a></td></tr>");


	}
   });

$(document).ready(function()
{
	$("#ctl00_PlaceHolderMain_signInControl_UserName").focus();
});
</script>


</asp:Content>
