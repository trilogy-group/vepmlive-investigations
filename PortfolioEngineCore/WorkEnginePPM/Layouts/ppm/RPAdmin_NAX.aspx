<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPAdmin_NAX.aspx.cs" Inherits="WorkEnginePPM.RPAdmin_NAX" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script src="tools/jsfunctions.js" type="text/javascript"></script>
    <script src="general.js" type="text/javascript"></script>
    <script src="tools/toolbar.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="tools/toolbar.css" />
    <link id="pageStyles" href="styles/page.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <div style="display: none;">
        <asp:Button ID="btnSave" runat="server" Text="Button" OnClick="btnSave_Click" /></div>
    <asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
    <div id="idToolbarDiv"></div>
    <div>
        <asp:Panel runat="server" ID="pnlMain">
            <table width="100%" cellspacing="0">
                <tr valign="top">
                    <td width="450" class="controlcell">
                        <b>Departments</b><br />
                        Select the lookup to be used in Resource Planning.
                    </td>
                    <td class="controlcell">
                        <asp:DropDownList ID="ddlDepartments" OnChange="ddlChanged('ddlDepartments');" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr valign="top">
                    <td width="450" class="controlcell">
                        <b>Resource Roles</b><br />
                        Select the lookup to be used for Resource Roles.
                    </td>
                    <td class="controlcell">
                        <asp:DropDownList ID="ddlResourceRoles" OnChange="ddlChanged('ddlResourceRoles');" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr valign="top">
                    <td width="450" class="controlcell">
                        <b>Resource Planning Calendar</b><br />
                        Select the period calendar on which the resource plans will be based.
                    </td>
                    <td class="controlcell">
                        <asp:DropDownList ID="ddlCalendar" OnChange="ddlChanged('ddlCalendar');" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr valign="top">
                    <td width="450" class="controlcell">
                        <b>Resource Planning Display Mode</b><br />
                        Select the default data input and display mode to be used for Resource Planning.
                    </td>
                    <td class="controlcell">
                        <asp:DropDownList ID="ddldisplayMode" OnChange="ddlChanged('ddldisplayMode');" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr valign="top">
                    <td width="450" class="controlcell">
                        <b>Resource Planning Operation Mode</b><br />
                        Select the operation mode.
                    </td>
                    <td class="controlcell">
                        <asp:DropDownList ID="ddlOperationMode" OnChange="ddlChanged('ddlOperationMode');" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr valign="top">
                    <td width="450" class="controlcell">
                        <b>Resource Planning Total Hours</b><br />
                        Select the custom field to store Total Hours.
                    </td>
                    <td class="controlcell">
                        <asp:DropDownList ID="ddlTotalHours" OnChange="ddlChanged('ddlTotalHours');" runat="server"></asp:DropDownList>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>

    <script type="text/javascript">
        var toolbarData = {
            parent: "idToolbarDiv",
            style: "display:none;",
            imagePath: "images/",
            items: [
                { type: "button", name: "SAVE", img: "formatmap16x16_2.png", style: "top: -127px; left: -91px;", tooltip: "Save", onclick: "toolbar_event('btnSave');" }
            ]
        };
        var pagechanged = false;
        var selected = {};
        var toolbar = new Toolbar(toolbarData);
        var OnLoad = function (event) {
            toolbar.Render();
            var ddl = document.getElementById('<%=ddlDepartments.ClientID%>');
        selected.department = "";
        if (ddl != null & ddl.selectedIndex >= 0)
            selected.department = ddl[ddl.selectedIndex].value;
        ddl = document.getElementById('<%=ddlCalendar.ClientID%>');
        selected.calendarIndex = -1;
        if (ddl != null & ddl.selectedIndex >= 0)
            selected.calendarIndex = ddl.selectedIndex;
        ddl = document.getElementById('<%=ddlResourceRoles.ClientID%>');
        selected.rolesIndex = -1;
        if (ddl != null & ddl.selectedIndex >= 0)
            selected.rolesIndex = ddl.selectedIndex;
    };
    var OnBeforeUnload = function (event) {
        if (pagechanged == true)
            event.returnValue = "You have unsaved changes.\n";
    };
    function toolbar_event(event) {
        switch (event) {
            case 'btnSave':
                <%= Page.ClientScript.GetPostBackEventReference(btnSave, String.Empty) %>;
                break;
            default:
                alert(event);
                break;
        }
    };
    function ddlChanged(ddlName) {
        switch (ddlName) {
            case "ddlDepartments":
                var ddl = document.getElementById('<%=ddlDepartments.ClientID%>');
                if (ddl != null && ddl.selectedIndex >= 0 && selected.calendarIndex != ddl.selectedIndex) {
                    var sb = new StringBuilder("");
                    sb.appendLine("WARNING!");
                    sb.appendLine("");
                    sb.appendLine("You are about to change the department structure on which resource planning is based");
                    sb.appendLine("It is recommended that this not be changed unless you are certain");
                    sb.appendLine("");
                    sb.appendLine("Press 'Cancel' to stay with the current setting  (recommended)");
                    sb.appendLine("Press 'OK' to save your changes if you are certain");
                    var s = sb.toString();
                    var r = confirm(s);
                    if (r != true) {
                        ddl.selectedIndex = selected.departmentIndex;
                    }
                    else
                        pagechanged = true;
                }
                break;
            case "ddlCalendar":
                var ddl = document.getElementById('<%=ddlCalendar.ClientID%>');
                if (ddl != null && ddl.selectedIndex >= 0 && selected.calendarIndex != ddl.selectedIndex) {
                    var sb = new StringBuilder("");
                    sb.appendLine("WARNING!");
                    sb.appendLine("");
                    sb.appendLine("You are about to change the calendar on which resource planning is based");
                    sb.appendLine("It is recommended that this not be changed unless you are certain");
                    sb.appendLine("");
                    sb.appendLine("Press 'Cancel' to stay with the current setting  (recommended)");
                    sb.appendLine("Press 'OK' to save your changes if you are certain");
                    var s = sb.toString();
                    var r = confirm(s);
                    if (r != true)
                        ddl.selectedIndex = selected.calendarIndex;
                    else
                        pagechanged = true;
                }
                break;
            case "ddlResourceRoles":
                var ddl = document.getElementById('<%=ddlResourceRoles.ClientID%>');
                if (ddl != null && ddl.selectedIndex >= 0 && selected.rolesIndex != ddl.selectedIndex) {
                    var sb = new StringBuilder("");
                    sb.appendLine("WARNING!");
                    sb.appendLine("");
                    sb.appendLine("You are about to change the roles on which resource planning is based");
                    sb.appendLine("It is recommended that this not be changed unless you are certain");
                    sb.appendLine("");
                    sb.appendLine("Press 'Cancel' to stay with the current setting  (recommended)");
                    sb.appendLine("Press 'OK' to save your changes if you are certain");
                    var s = sb.toString();
                    var r = confirm(s);
                    if (r != true)
                        ddl.selectedIndex = selected.rolesIndex;
                    else
                        pagechanged = true;
                }
                break;
            default:
                pagechanged = true;
                break;
        }
    };

    if (document.addEventListener != null) { // e.g. Firefox
        window.addEventListener("load", OnLoad, true);
        window.addEventListener("beforeunload", OnBeforeUnload, true);
    }
    else { // e.g. IE
        window.attachEvent("onload", OnLoad);
        window.attachEvent("onbeforeunload", OnBeforeUnload);
    }
    </script>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Resource Planning Administration
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    Resource Planning Administration
</asp:Content>
