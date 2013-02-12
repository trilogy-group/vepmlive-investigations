<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListLookupEdit.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.ListLookupEdit" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 



<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">

    <wssuc:InputFormSection Title="Enabled"
		Description=""
		runat="server">
		<Template_Description>
		    Check this box to enable advanced lookup features
		</Template_Description>
        <Template_InputFormControls>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkEnabled" runat="server" Text="Enable Advanced Lookup" AutoPostBack="true"/><br />
                    <b>List:</b> <asp:Label ID="lblList" runat="server"></asp:Label><br />
                    <b>Field:</b> <asp:Label ID="lblField" runat="server"></asp:Label>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>

    <wssuc:InputFormSection Title="Style"
		Description=""
		runat="server">
		<Template_Description>
		    Auto Complete: This option will give you a type ahead style lookup.<br />
            Standard: This option does not change the way the lookup acts.
		</Template_Description>
        <Template_InputFormControls>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:DropDownList ID="ddlStyle" runat="server">
                        <asp:ListItem Text="Auto Complete" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Standard" Value="1"></asp:ListItem>
                    </asp:DropDownList>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>

     <wssuc:InputFormSection Title="Security"
		Description=""
		runat="server">
		<Template_Description>
		    When enabled this field acts as a security field for the current item. When an item is added or updated the security will be modified on the item to reflect the
            security applied to its parent.
		</Template_Description>
        <Template_InputFormControls>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkSecurity" runat="server" /> Enable Security
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>

    <wssuc:InputFormSection Title="Cascading Lookup"
		Description=""
		runat="server">
		<Template_Description>
		    When selected, this field will become a child lookup to the lookup specified.<br /><br />
            Parent Lookup: The field in the current list that this lookup will be the child for.<br /><br />
            Parent Lookup Field: This is the field in the Parent Lookups List which will allow the lookups to communicate.
		</Template_Description>
        <Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Parent Lookup" runat="server">
				 <Template_Control>
                    <asp:DropDownList ID="ddlParentLookup" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlParentLookupField_SelectedIndexChanged"></asp:DropDownList>
				 </Template_Control>
			</wssuc:InputFormControl>
            <wssuc:InputFormControl LabelText="Parent's Lookup Field" runat="server">
				 <Template_Control>
                    <asp:DropDownList ID="ddlParentLookupField" runat="server"></asp:DropDownList>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>

    <wssuc:ButtonSection runat="server">
		<Template_Buttons>
			<asp:PlaceHolder ID="PlaceHolder1" runat="server">
				<asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Button1_Click" Text="Save" id="Button1" accesskey="" Width="150"/>
			</asp:PlaceHolder>
		</Template_Buttons>
	</wssuc:ButtonSection>
    <wssawc:FormDigest ID="FormDigest1" runat="server" />
</table>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Edit Lookup
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Edit Lookup
</asp:Content>
