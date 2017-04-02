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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addaccount.aspx.cs" Inherits="EPMLiveAccountManagement.addaccount" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Add Account</title>
    <link rel="stylesheet" type="text/css" href="/_layouts/1033/styles/Themable/corev4.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="ms-decriptiontext" style="padding:10px"> 
            This process will create a new account under your name. This will allow you to manage a separate set of users and site collections. You will need to purchase users before you can start using the account.<br/><br/>
            Enter Account Name:<br />
            <asp:TextBox runat="server" ID="txtAccount"></asp:TextBox><br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Add Account" CssClass="ms-ButtonHeightWidth"/>

            <asp:Panel ID="pnlClose" runat=server Visible="false">
                <script language="javascript">
                    window.parent.location.href = window.parent.location.href + "?account_id=<%=newid.ToString() %>";
                </script>
            </asp:Panel>

            <asp:Panel ID="pnlClose2" runat=server Visible="false">
                <script language="javascript">
                    parent.location.reload(); 
                </script>
            </asp:Panel>
    </div> 
    </form>
</body>
</html>
