<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="WorkEnginePPM.TestPage" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Reference Control="/_layouts/ppm/RPEditor.ascx" %>
<%@ Reference Control="/_layouts/ppm/EditCosts.ascx" %>
<%@ Reference Control="/_layouts/ppm/ResPlanAnalyzer.ascx" %>
<%@ Reference Control="/_layouts/ppm/Model.ascx" %>
<%@ Reference Control="/_layouts/ppm/CostAnalyzer.ascx" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

<style type="text/css">
    .ms-dialog .ms-bodyareacell {
    padding: 0 !important;
}
</style>
<script src="tools/jsfunctions.js" type="text/javascript"></script>
<script src="general.js" type="text/javascript"></script>

<style type="text/css">
.ms-cui-tabBody {
    border-bottom: 0 !important;
}
/*BODY #s4-workspace {
    height: 100% !important;
}*/
html, body {
    width: 100%;
    height: 100%;
    margin: 0px;
    overflow: hidden;
}
</style>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
	<div id="idselectdiv" runat="server" style="margin-top:5px;margin-bottom:5px;padding-left:3px;padding-right:3px;" visible="false">
		<div style="padding-bottom:3px;">
            <table cellspacing="0">
                <tr>
                    <td>Select a test item&nbsp;:&nbsp;</td>
                    <td style="min-width:300px;">
                        <asp:DropDownList ID="ddlItems" style="min-width:300px;" runat="server"></asp:DropDownList>
                    </td>
                    <td><asp:Button ID="btnGo" OnClick="btnGo_Click" runat="server" Text="Go" /></td>
                    <td><div id="idtestdiv" style="width:100%;"><a id="lblMessage"></a></div></td>
                </tr>
            </table>
		</div>
    </div>
    <asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
    <div id="maindiv"><asp:PlaceHolder runat="server" ID="PlaceHolder1" /></div>
<script type="text/javascript">
    function Page_OnResize() {
        if (typeof (editcosts) != "undefined") {
            var divLayout = document.getElementById("maindiv");
            var xy = jsf_findAbsolutePosition(divLayout);
            var body = document.body;
            editcosts.SetSize(document.documentElement.clientWidth - xy[0] - 25, document.documentElement.clientHeight - xy[1] - 20);
        }
        //if (typeof (rpeditor) != "undefined") {
        //    rpeditor.SetSize(document.documentElement.clientWidth, document.documentElement.clientHeight);
        //}
    };
    if (document.addEventListener != null) { // e.g. Firefox
        //window.addEventListener("load", OnLoad, true);
        //window.addEventListener("beforeunload", OnBeforeUnload, true);
        window.addEventListener("resize", Page_OnResize, true);
    }
    else { // e.g. IE
        //window.attachEvent("onload", OnLoad);
        //window.attachEvent("onbeforeunload", OnBeforeUnload);
        window.attachEvent("onresize", Page_OnResize);
    }
</script>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
<%=pageTitle%>
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
<%=pageTitle%>
</asp:Content>
