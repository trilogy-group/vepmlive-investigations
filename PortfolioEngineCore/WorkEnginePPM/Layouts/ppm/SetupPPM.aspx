<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetupPPM.aspx.cs" Inherits="WorkEnginePPM.Layouts.ppm.SetupPPM" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label><br /><br />
    <asp:Panel ID="pnlSuccess" runat="server" Visible="false">
        
        <h3>Your PortfolioEngine site has been successfully configured. You can now manage your lists.</h3>
        <a href="managelists.aspx">[Manage Lists Now]</a><br /><br /><br />

        <b>Log:</b><br />
        <asp:Label ID="lblSuccess" runat="server"></asp:Label><br /><br />
    </asp:Panel>
    <asp:Panel ID="pnlMain" runat="server">
    
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <wssuc:InputFormSection Title="Base Path"
		        Description=""
		        runat="server">
		        <Template_Description>
		           Enter the basepath for your PortfolioEngine site if you are unsure what to put, leave it as is.
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="" runat="server">
				         <Template_Control>
                            <asp:TextBox id="txtBasePath" runat="server"></asp:TextBox>
				         </Template_Control>
			        </wssuc:InputFormControl>
		        </Template_InputFormControls>
	        </wssuc:InputFormSection>

            <wssuc:InputFormSection Title="Registration Information"
		        Description=""
		        runat="server">
		        <Template_Description>
		           Enter the registration information for your site.
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="Product Key" runat="server">
				         <Template_Control>
                            <asp:TextBox id="txtPID" runat="server"></asp:TextBox>
				         </Template_Control>
			        </wssuc:InputFormControl>
                    <wssuc:InputFormControl LabelText="Company" runat="server">
				         <Template_Control>
                            <asp:TextBox id="txtCompany" runat="server"></asp:TextBox>
				         </Template_Control>
			        </wssuc:InputFormControl>
		        </Template_InputFormControls>
	        </wssuc:InputFormSection>

            <wssuc:InputFormSection Title="Database Information"
		        Description=""
		        runat="server">
		        <Template_Description>
		           Enter the database information for your site.
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="Database Server" runat="server">
				         <Template_Control>
                            <asp:TextBox id="txtDBServer" runat="server"></asp:TextBox>
				         </Template_Control>
			        </wssuc:InputFormControl>
                    <wssuc:InputFormControl LabelText="Database" runat="server">
				         <Template_Control>
                            <asp:TextBox id="txtDB" runat="server"></asp:TextBox>
				         </Template_Control>
			        </wssuc:InputFormControl>
                    <wssuc:InputFormControl LabelText="Database Username" runat="server">
				         <Template_Control>
                            <asp:TextBox id="txtUsername" runat="server"></asp:TextBox>
				         </Template_Control>
			        </wssuc:InputFormControl>
                    <wssuc:InputFormControl LabelText="Database Password" runat="server">
				         <Template_Control>
                            <asp:TextBox id="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
				         </Template_Control>
			        </wssuc:InputFormControl>
		        </Template_InputFormControls>
	        </wssuc:InputFormSection>
            <wssuc:ButtonSection runat="server">
		    <Template_Buttons>
			    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
				    <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Button1_Click" Text="Setup Site" id="Button1" accesskey="" Width="150"/>
			    </asp:PlaceHolder>
		    </Template_Buttons>
	        </wssuc:ButtonSection>
            <wssawc:FormDigest ID="FormDigest1" runat="server" />

        </table>
        
    </asp:Panel>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">

Setup PortfolioEngine

</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >

Setup PortfolioEngine

</asp:Content>
