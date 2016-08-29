<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="installfromstore.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.applications.installfromstore" DynamicMasterPageFile="~masterurl/default.master" %>
<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">


<asp:Panel ID="pnlNoApp" runat="server" Visible="false">
    No application has been selected.
</asp:Panel>

<asp:Panel ID="pnlMain" runat="server" Visible="true">

    <script type="text/ecmascript">

        function ShowInstall() {
            var surl = "choosecommunity.aspx?appid=<%=Request["appid"] %>";

	        var options = { url: surl, width: 700, title: "Install Application", dialogReturnValueCallback: InstallAppClose };

	        SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
	    }


	    function InstallAppClose() {

	    }

	    _spBodyOnLoadFunctionNames.push("ShowInstall");

    </script>

    <Sharepoint:ScriptLink ID="ScriptLink1" Name="sp.ui.dialog.js" LoadAfterUI="true" Localizable="false" runat="server"></Sharepoint:ScriptLink>          
    <SharePoint:FormDigest ID="FormDigest1" runat="server" /> 
  
</asp:Panel>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Install Application
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
    Install Application
</asp:Content>
