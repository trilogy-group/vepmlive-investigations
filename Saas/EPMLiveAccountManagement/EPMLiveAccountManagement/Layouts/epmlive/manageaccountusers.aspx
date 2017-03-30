<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageaccountusers.aspx.cs" Inherits="EPMLiveAccountManagement.Layouts.epmlive.manageaccountusers" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <script language="javascript">
        function DeleteUser(uid) {
            if (confirm('Are you sure you want to delete that user? Once you delete a user they will remain in your resource pool, however the user will not be able to login to any sites that you own.')) {
                location.href = "manageaccountdeleteuser.aspx?uid=" + uid;
            }
        }
    </script>

    <style>
        .ms-vh2-nofilter .ms-vh2-gridview
        {
            height: 14px !important;
        }
    </style>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    <SharePoint:SPGridView runat="server"
	         ID="GvItems"
	         AutoGenerateColumns="false"
	         style="width:100%">
            <Columns>
	            <SharePoint:SPMenuField HeaderText="User" TextFields="name" MenuTemplateId="PropertyNameListMenu" TokenNameAndValueFields="UID=uid"  ></SharePoint:SPMenuField>
                <SharePoint:SPBoundField HeaderText="Email" DataField="email"></SharePoint:SPBoundField>
                <SharePoint:SPBoundField HeaderText="Username" DataField="username"></SharePoint:SPBoundField>
	         </Columns>
	         <AlternatingRowStyle CssClass="ms-alternating" />
	         </SharePoint:SPGridView>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Application Page
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
My Application Page
</asp:Content>
