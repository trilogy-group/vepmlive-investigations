<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.Integration.Manage" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script language="javascript">
        function EditFields(list)
        {
            var options = { url: "EditFields.aspx?LIST=" + list, width: 500, showClose: true };

            SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
        }
    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    <SharePoint:SPGridView runat="server"
	    ID="gvIntegrations" AllowGrouping ="true"
         GroupField="ListName" AllowGroupCollapse="true" DisplayGroupFieldName="false"
	    AutoGenerateColumns="false"
	    Width="400px"
	    AllowSorting="True"
	    AllowPaging="False" OnRowDataBound="gvIntegrations_RowDataBound"  GridLines="None"  >
        <Columns>
	        <SharePoint:SPMenuField HeaderText="Integration Name" TextFields="Title" MenuTemplateId="IntegrationMenu" TokenNameAndValueFields="INTLISTID=INT_LIST_ID,LISTID=LIST_ID" ></SharePoint:SPMenuField>
            <SharePoint:SPBoundField HeaderText ="Description" DataField="Description"></SharePoint:SPBoundField>
            <SharePoint:SPBoundField HeaderText ="Active" DataField="Active"></SharePoint:SPBoundField>
	    </Columns>
	    <AlternatingRowStyle CssClass="ms-alternating" />
	</SharePoint:SPGridView><br /><br />

    <a href="Add.aspx" style="text-decoration: none;">Add New App</a>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Upland Integrations
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Upland Integrations
</asp:Content>
