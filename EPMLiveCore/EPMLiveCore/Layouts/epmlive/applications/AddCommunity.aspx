<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCommunity.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.applications.AddCommunity" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <link href="Applications.css" rel="stylesheet" type="text/css" />

    <script language="javascript">
        function Close() {
            SP.SOD.execute('SP.UI.dialog.js', 'SP.UI.ModalDialog.commonModalDialogClose', 0, ''); 
        }
    </script>

    <link rel="stylesheet" type="text/css" href="/_layouts/epmlive/stylesheets/buttons.css" />

    <style type="text/css">

    .wizHeader
    {
    font-family:Segoe UI Light,Verdana;
    font-size:24px;
    padding-left:5px;
    margin-top:0px;
    padding-top:5px;
    margin-bottom:15px;
    font-weight:normal;

    }


    .wizText
    {
    margin-top:0px;
    padding-top:0px;
    padding-left:5px;
    font-family:Segoe UI Light,Verdana;
    font-size:16px;

    }

    </style>


</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    <asp:Panel ID="pnlMain" runat="server">

    <h1 class="wizHeader">Add Community</h1>
    <p class="wizText">
    To create a new community for your site, enter the title of the new community.
    </p>
    <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
    <span class="wizText">Enter Community Name:</span> <asp:TextBox ID="txtName" runat="server"></asp:TextBox> 
        <SharePoint:InputFormRequiredFieldValidator ID="reqValCommName" runat="server" ControlToValidate="txtName" ErrorMessage="Please enter a community name."></SharePoint:InputFormRequiredFieldValidator>
        <br />
    <hr style="margin-top:15px;">
    <div style="width:100%;text-align:right;">
    <asp:Button ID="btnAdd" Text="Add" runat="server" OnClick="btnAdd_Click" class="btn" style="height:28px;width:65px;" />
    <input type="button" value="Cancel" onclick="Close();" class="btn" style="height:28px;width:65px" />
    </div>
    </asp:Panel>

    <asp:Panel ID="pnlDone" runat="server" Visible="false">
        <script language="javascript">
            window.frameElement.commitPopup('<%=CommId %>');
        </script>
    </asp:Panel>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Add Community
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Add Community
</asp:Content>
