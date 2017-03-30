<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newsitecollection.aspx.cs" Inherits="EPMLiveAccountManagement.newsitecollection" DynamicMasterPageFile="~masterurl/default.master" %>
<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="Create New Site" EncodeMethod='HtmlEncode'/>
</asp:Content>

<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	<asp:Label ID="lblTitle" runat="server" Text="Create New Application"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
<asp:Panel ID="pnlTemp" runat="server" Visible="true">
    Use this page to create a new Application for your organization.
</asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">

<script type="text/javascript" src="modal/modal.js"></script>
<link rel="stylesheet" href="modal/modal.css" type="text/css" />
<script src="DHTML/xgrid/dhtmlxcommon.js"></script>

<script language="javascript">
    function createSite() {
        sm("dlgCreating", 180, 50);
        var siteurl = document.getElementById('<%=txtURL.ClientID %>').value;
        var sitetitle = document.getElementById('<%=txtTitle.ClientID %>').value;
        var template = document.getElementById('<%=ddlSolution.ClientID %>').value;
        var description = document.getElementById('<%=txtDescription.ClientID %>').value;
        var accountid = document.getElementById('<%=ddlAccount.ClientID %>').value;

        var postData = "siteurl=" + siteurl + "&sitetitle=" + sitetitle + "&template=" + template + "&description=" + description + "&account=" + accountid;

        dhtmlxAjax.post("createsite.aspx", postData, createSiteCallback);
    }
    function createSiteCallback(loader) {
        var retVal = loader.xmlDoc.responseText.trim();

        hm("dlgCreating");

        if (retVal == "Success") {
            sm("dlgRedirect", 180, 50);
            var siteurl = document.getElementById('<%=txtURL.ClientID %>').value;
            document.location.href = '<%=baseSiteUrl%>' + siteurl;
        }
        else {
            alert(retVal);
        }

    }

    function addAccount() {
        function NewItemCallback(dialogResult, returnValue) {

        }

        var options = { url: "<%=weburl %>/_layouts/epmlive/addaccount.aspx?src=newsite", width: 400, dialogReturnValueCallback: NewItemCallback };

        SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
    }
</script>

<div id="dlgCreating" class="dialog">
    <table width="100%">
        <tr>
            <td align="center" class="ms-sectionheader">
                <H3 class="ms-standardheader"><img src="../images/GEARS_ANv4.GIF" style="vertical-align: middle;"/> Creating Site...</h3>
            </td>
        </tr>     
    </table>
</div> 

<div id="dlgRedirect" class="dialog">
    <table width="100%">
        <tr>
            <td align="center" class="ms-sectionheader">
                <H3 class="ms-standardheader"><img src="../images/GEARS_ANv4.GIF" style="vertical-align: middle;"/> Redirecting to new Site...</h3>
            </td>
        </tr>     
    </table>
</div> 

<table>
<asp:Panel ID="pnlCreate" runat="server">

    <wssuc:InputFormSection Title="Select Account"
		Description="Select the account you would like to associate this site with"
		runat="server" width="10">
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Account" runat="server">
				 <Template_Control>
		            <asp:DropDownList ID="ddlAccount" runat="server" ></asp:DropDownList><br />
                    <a href="#" onclick="addAccount();" style="font-size: 9px">[Create New Account]</a>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>

    <wssuc:InputFormSection Title="Enter Title"
		Description="Please provide a title for your application"
		runat="server" width="10">
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Title" runat="server">
				 <Template_Control>
		            <wssawc:InputFormTextBox Title="Title" class="ms-input" ID="txtTitle" Columns="67" Runat="server" MaxLength=255 />
		            <asp:Panel ID="pnlTitle" runat=server Visible =false><font color="red"></font></asp:Panel>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	<wssuc:InputFormSection Title="Enter URL"
		Description="Please provide a url for your application"
		runat="server" width="10">
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="URL" runat="server">
				 <Template_Control>
		            <%=baseSiteUrl%><wssawc:InputFormTextBox Title="Title" class="ms-input" ID="txtURL" Columns="30" Runat="server" MaxLength=255 />
		            <asp:Panel ID="pnlURL" runat=server Visible =false><font color="red"></font></asp:Panel>
		            <asp:Panel ID="pnlURLBad" runat=server Visible =false><font color="red">URL may contain only letters and numbers.</font></asp:Panel>
		            <asp:Panel ID="pnlExists" runat=server Visible =false><font color="red">That site URL is already taken, please choose another.</font></asp:Panel>
		            <img src="/_layouts/images/blank.gif" width="400" height="1" />
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>

    <wssuc:InputFormSection Title="Enter Description"
		Description="Please provide a description for your application"
		runat="server" width="10">
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Description" runat="server">
				 <Template_Control>
		            <wssawc:InputFormTextBox Title="Title" class="ms-input" ID="txtDescription" TextMode="MultiLine" Columns="67" Rows="3" Runat="server" />
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>

	<wssuc:InputFormSection Title="Select Language"
		Description="Please select the language for your site."
		runat="server" width="10" visible="false">
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Language" runat="server">
				 <Template_Control>
		            <asp:DropDownList ID="ddlLanguage" runat="server">
                        <asp:ListItem Text="Czech" Value="1029"></asp:ListItem>
                        <asp:ListItem Text="Danish" Value="1030"></asp:ListItem>
                        <asp:ListItem Text="Dutch" Value="1043"></asp:ListItem>
                        <asp:ListItem Text="English" Value="1033" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Finnish" Value="1035"></asp:ListItem>
                        <asp:ListItem Text="French" Value="1036"></asp:ListItem>
                        <asp:ListItem Text="German" Value="1031"></asp:ListItem>
                        <asp:ListItem Text="Greek" Value="1032"></asp:ListItem>
                        <asp:ListItem Text="Italian" Value="1040"></asp:ListItem>
                        <asp:ListItem Text="Portuguese" Value="2070"></asp:ListItem>
                        <asp:ListItem Text="Portuguese - Brazilian" Value="1046"></asp:ListItem>
                        <asp:ListItem Text="Russian" Value="1049"></asp:ListItem>
                        <asp:ListItem Text="Spanish" Value="3082"></asp:ListItem>
                        <asp:ListItem Text="Swedish" Value="1053"></asp:ListItem>
                        <asp:ListItem Text="Turkish" Value="1055"></asp:ListItem>
				    </asp:DropDownList>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	<wssuc:InputFormSection Title="Select an Application"
		Description="Please select an Application Type from the dropdown list"
		runat="server" width="10" visible="true">
		<Template_Description>
		    
		</Template_Description>

		<Template_InputFormControls>
			<Template_Control>
                    <asp:DropDownList ID="ddlSolution" runat="server" >
		</asp:DropDownList>
            </Template_Control>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	<wssuc:InputFormSection Title="Select Template"
		Description=""
		runat="server" width="100%" visible="false">
		<Template_Description>
		    <asp:Label ID="lblDesc" runat="server"></asp:Label><br /><br />
		    <center>
			<asp:Image ID="imgDesc" runat="server"/>
			</center>
		</Template_Description>
		<Template_InputFormControls>
		    <wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:ListBox ID="lbxTemplate" runat="server" Width="200" Height="100" OnSelectedIndexChanged="lbxTemplate_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
				</asp:DropDownList>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	<wssuc:ButtonSection runat="server">
		<Template_Buttons>
			<asp:PlaceHolder ID="PlaceHolder1" runat="server">
				<input type="button" class="ms-ButtonHeightWidth" onclick="createSite()" value="Create Application"/>
			</asp:PlaceHolder>
		</Template_Buttons>
	</wssuc:ButtonSection>
    <wssawc:FormDigest ID="FormDigest1" runat="server" />
</asp:Panel>
</table>
<asp:Panel ID="pnlSiteCreated" runat="server" Visible="False">
    Your application has been created successfully.<br /><br />
    <asp:HyperLink ID="hlCreated" runat="server"></asp:HyperLink>
</asp:Panel>
<script>
initmb();
</script>



</asp:Content>