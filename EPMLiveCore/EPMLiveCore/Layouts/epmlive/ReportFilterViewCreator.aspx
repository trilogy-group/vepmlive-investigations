<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportFilterViewCreator.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.ReportFilterViewCreator" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Report Filter View Creator
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Report Filter View Creator
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<script type="text/javascript">
    $(function () {
        $("#<%= LayoutListBox.ClientID %>").attr("onchange", "DoTemplateOptionChange()");
    });
    
    function DoTemplateOptionChange()
    {
        var layoutListBox = $("#<%= LayoutListBox.ClientID %>");
        $("#LayoutImage").attr("src", "images/ReportFilterViewCreator/" + layoutListBox.val() + "Layout.gif");
        $("#LayoutImage").attr("alt", layoutListBox.find('option:selected').text());
    }

    function FormIsValid() {
        var viewNameTextBox = $("#<%= ViewNameTextBox.ClientID %>");

        if (viewNameTextBox.val().trim().length < 1)
        {
            window.alert("You must specify a non-blank value for View Name.");
            viewNameTextBox.focus();
            return false;
        }

        return true;
    }
</script>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <wssuc:InputFormSection Title="Name"
		Description=""
		runat="server">
		<Template_Description>
		    Type the name for your view.
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="View Name:" runat="server">
				 <Template_Control>
                    <asp:TextBox runat="server" ID="ViewNameTextBox" />.aspx
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	
    <wssuc:InputFormSection Title="Layout"
		Description=""
		runat="server">
		<Template_Description>
		    Select a layout template to arrange Web Parts in zones on the page. Multiple Web Parts can be added to each zone. Specific zones allow Web Parts to be stacked in a horizontal or vertical direction, which is illustrated by differently colored Web Parts. If you do not add a Web Part to a zone, the zone collapses (unless it has a fixed width) and the other zones expand to fill unused space when you browse the Web Part Page. 
            <br/><br/>
            <img id="LayoutImage" src="images/ReportFilterViewCreator/HeaderFooter3ColumnLayout.gif" />
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Choose a Layout Template:" runat="server">
				 <Template_Control>
                    <asp:ListBox runat="server" ID="LayoutListBox" Rows="5"  >
                        <asp:ListItem Value="HeaderFooter3Column" Selected="true">Header, Footer, 3 Columns</asp:ListItem>
                        <asp:ListItem Value="FullPageVertical">Full Page,Vertical</asp:ListItem>
                        <asp:ListItem Value="HeaderLeftColumnBody">Header, Left Column, Body</asp:ListItem>
                        <asp:ListItem Value="HeaderRightColumnBody">Header, Right Column, Body</asp:ListItem>
                    </asp:ListBox>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
    
	<wssuc:ButtonSection runat="server">
		<Template_Buttons>
			<asp:PlaceHolder ID="CreateViewButtonPlaceHolder" runat="server">
                <asp:Button runat="server" ID="CreateViewButton" Text="Create" CssClass="ms-ButtonHeightWidth" OnClientClick="return FormIsValid();" />
			</asp:PlaceHolder>
		</Template_Buttons>
	</wssuc:ButtonSection>
    <wssawc:FormDigest ID="FormDigest1" runat="server" />
    </table>

</asp:Content>


