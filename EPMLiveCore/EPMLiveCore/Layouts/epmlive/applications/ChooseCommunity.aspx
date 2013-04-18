<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChooseCommunity.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.applications.ChooseCommunity" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <link href="Applications.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/_layouts/epmlive/stylesheets/buttons.css" />

    <script language="javascript">

        var bNavOnly = <%=bNavOnly %>;

        function AddCommunity() {

            var options = { url: "AddCommunity.aspx", width: 500, showClose: true, dialogReturnValueCallback: onAddCommunity };

            SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);

        }
        
        function onAddCommunity(dialogResult, returnValue) {

            location.href = "ChooseCommunity.aspx?CommId=" + returnValue + "&AppId=<%=Request["appid"]%>&isdlg=1";
        
        }

        function Install() {
        
            document.getElementById('installbutton2').className = "btn btn-success btn-large disabled";

            if(bNavOnly)
            {
                var ddl = document.getElementById("<%=ddlCommunity.ClientID %>");
                var val = ddl.options[ddl.selectedIndex].value; 

                location.href = "installnav.aspx?AppId=<%=Request["appid"]%>&CommId=" + val + "&isdlg=1";
            }
            else
            {
                var ddl = document.getElementById("<%=ddlCommunity.ClientID %>");
                var val = ddl.options[ddl.selectedIndex].value; 

                location.href = "precheck.aspx?AppId=<%=Request["appid"]%>&CommId=" + val + "&isdlg=1";
            }
        }

    </script>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

   <h1 class="wizHeader">Select Community</h1>
   <asp:Panel ID="pnlInstalled" runat="server" Visible="false">
   <div class="alert alert-success"><h4 class="alert-heading">This application is already installed and will be added to your community.</h4></div>
   </asp:Panel>
   <span class="wizText">Select the Community you would like to install this application on or <a href="#" onclick="Javascript:AddCommunity()">Add Community</a>:</span><br /><br />
   <asp:DropDownList ID="ddlCommunity" runat="server" style="margin-left:5px;">
   
   </asp:DropDownList>
   <br />

   <div style="padding-top:10px;margin-left:5px;">
        <a class="btn btn-success btn-large" href="#" id="installbutton2" onclick="Install();" style="color:#FFFFFF !important;">Next</a>
    </div>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Choose Community
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Choose Community
</asp:Content>

