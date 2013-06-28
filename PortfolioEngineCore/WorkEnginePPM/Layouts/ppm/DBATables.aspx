<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DBATables.aspx.cs" Inherits="WorkEnginePPM.DBATables" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Register src="Tools/DGrid.ascx" tagname="DGridUserControl" tagprefix="dg1" %>
<%@ Reference Control="/_layouts/ppm/tools/DGrid.ascx" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<script src="tools/jsfunctions.js" type="text/javascript"></script>
<script src="general.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="styles/form.css" />
<link rel="stylesheet" type="text/css" href="styles/dialognew.css" />
<link rel="stylesheet" type="text/css" href="tools/toolbar.css" />
<script src="tools/toolbar.js" type="text/javascript"></script>

<style type="text/css">
    .ms-dialog .ms-bodyareacell {
    padding: 0 !important;
}
</style>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
	<div style="margin-top:5px;margin-bottom:5px;padding-left:3px;padding-right:3px;">
        <asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
        <asp:Panel runat="server" ID="pnlMain">
		    <div style="padding-bottom:3px;">
                <table width="100%" cellspacing="0">
                    <tr>
                        <td style="height:1px;" width="150" class="topcell"></td>
                        <td style="height:1px;" class="topcell"></td>
                    </tr>
                    <tr>
                        <td width="150" class="descriptioncell">Table</td>
                        <td class="controlcell">
                            <asp:DropDownList ID="ddlTables" OnSelectedIndexChanged="ddlTables_OnTextChanged" AutoPostBack="true" style="width:300px;" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="150" class="descriptioncell">Sort Column</td>
                        <td class="controlcell">
                            <asp:DropDownList id="ddlColumns" style="width:300px;" runat="server" ></asp:DropDownList>&nbsp;Descending:&nbsp;<asp:CheckBox ID="cbDescending" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="150" class="descriptioncell">Optional Sort Column</td>
                        <td class="controlcell">
                            <asp:DropDownList id="ddlColumns2" style="width:300px;" runat="server" ></asp:DropDownList>&nbsp;Descending:&nbsp;<asp:CheckBox ID="cbDescending2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="150" class="descriptioncell">Rows per Page</td>
                        <td class="controlcell">
                            <asp:TextBox ID="idRowsPerPageCount" style="width:50px;" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150" class="descriptioncell">Page</td>
                        <td class="controlcell">
                            <asp:TextBox ID="idPage" style="width:30px;" runat="server"></asp:TextBox><asp:Label ID="idPageCount" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                            <br /><br /><asp:Button ID="btnPrev" OnClick="btnPrev_Click" runat="server" Text="<" />
                            <asp:Button ID="btnGo" OnClick="btnGo_Click" runat="server" Text="Go" />
                            <asp:Button ID="btnNext" OnClick="btnNext_Click" runat="server" Text=">" />
                        </td>
                    </tr>
                </table>
		    </div>
            <div style="display: block; " >
                <dg1:DGridUserControl id="dgrid1" runat="server" />
            </div>
        </asp:Panel>
    </div>
<script type="text/javascript">
    var dgrid1 = window.<%=dgrid1.UID%>;
    var dgrid1_selectedRow = 0;

    var OnLoad = function (event) {
        OnResize();
    };

    function OnResize(event) {
        var top = dgrid1.GetTop();
        var newHeight = document.documentElement.clientHeight - top - 15;
        dgrid1.SetHeight(newHeight);
        var newWidth = document.documentElement.clientWidth - 9;
        dgrid1.SetWidth(newWidth);
    };

    if (document.addEventListener != null) { // e.g. Firefox
        window.addEventListener("load", OnLoad, true);
        window.addEventListener("resize", OnResize, true);
    }
    else { // e.g. IE
        window.attachEvent("onload", OnLoad);
        window.attachEvent("onresize", OnResize);
    }
</script>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
<%=RPETitle %>
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
<%=RPETitle %>
</asp:Content>
