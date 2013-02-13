<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveCore.adminconns" MasterPageFile="~/_admin/admin.master"%> 

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	WorkEngine Settings    
</asp:Content>
<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	WorkEngine Settings
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to set your WorkEngine settings for each web application.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
	<asp:Panel ID="pnlAdmin" runat="server">
	
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
	<wssuc:InputFormSection Title="Web Application"
		Description=""
		runat="server">
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="" runat="server" width="100%">
				 <Template_Control>
				    <SharePoint:WebApplicationSelector ID="WebApplicationSelector1" runat="server" AllowChange="true" OnContextChange="WebApplicationSelector1_ContextChange"    />
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>

	</wssuc:InputFormSection>
	
	<wssuc:InputFormSection Title="Reporting Services Configuration"
		Description=""
		runat="server">
		<Template_Description>
		    <b>URL:</b> Enter the URL for your SQL Server Reporting Services.<br />
		    Ex: http://servername/reportserver<br /><br />
		    <b>Default Path:</b> By default the reports are installed on the root of Reporting Services and do not require configuration. If you have installed in a non-default location you will need to 
		    specify that here.<br /><br />
		    <b>Use Integrated Mode:</b> Select this option if your SQL Server Reporting Services uses SharePoint Integrated Mode.<br /><br />
		    <b>Username/Password:</b> If you have multiple WFE's or your SSRS is not installed on your WFE, you will need to specify the web application account credentials here. These credentials will be used to authenticate to SSRS.<br /><br />
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="URL:" runat="server" width="100%">
				 <Template_Control>
				    <asp:TextBox ID="txtReportServer" runat="server" CssClass="ms-input"></asp:TextBox>
				 </Template_Control>
		    </wssuc:InputFormControl>
		    <wssuc:InputFormControl LabelText="Path:" runat="server" width="100%">
				 <Template_Control>
				    <asp:TextBox ID="txtDefaultPath" runat="server" CssClass="ms-input"></asp:TextBox>
				 </Template_Control>
		    </wssuc:InputFormControl>
		    <wssuc:InputFormControl LabelText="Use Integrated Mode:" runat="server" width="100%">
				 <Template_Control>
				    <asp:CheckBox ID="chkIntegrated" runat="server" />
				 </Template_Control>
		    </wssuc:InputFormControl>
		    <wssuc:InputFormControl LabelText="Username:" runat="server" width="100%">
				 <Template_Control>
				    <asp:TextBox ID="txtUsername" runat="server" CssClass="ms-input"></asp:TextBox>
				 </Template_Control>
		    </wssuc:InputFormControl>
            <wssuc:InputFormControl LabelText="Password:" runat="server" width="100%">
				 <Template_Control>
				    <asp:TextBox ID="txtPassword" runat="server" CssClass="ms-input" TextMode=Password></asp:TextBox>
				 </Template_Control>
		    </wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	<wssuc:InputFormSection Title="Workgroup Connection String"
		Description=""
		runat="server">
		<Template_Description>
		    Enter the connection string which you would like to use to connect to the EPMLIVE database.<br /><br />
		    Ex: Server=SERVERNAME;Database=epmlive;Trusted_Connection=True
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Connection String:" runat="server" width="100%">
				 <Template_Control>
				    <asp:TextBox ID="txtConnString" runat="server" Height="100" Width ="390" TextMode="MultiLine" CssClass="ms-input"></asp:TextBox>
				 </Template_Control>
		    </wssuc:InputFormControl>
		    <wssuc:InputFormControl LabelText="Status:" runat="server" width="100%">
				 <Template_Control>
                    <asp:Label ID="lblStatusDyn" runat="server" Text="" Font-Size="X-Small" BorderStyle="None" Width="390px" BackColor="white"></asp:Label>
				 </Template_Control>
		    </wssuc:InputFormControl>
		</Template_InputFormControls>

	</wssuc:InputFormSection>
	</asp:Panel>

	<wssuc:ButtonSection runat="server">
		<Template_Buttons>
			<asp:PlaceHolder ID="PlaceHolder1" runat="server">
				<asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Button1_Click" Text="Save Settings" id="Button1" accesskey="" Width="150"/>
			</asp:PlaceHolder>
		</Template_Buttons>
	</wssuc:ButtonSection>
    </table>

</asp:Content>