<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Register src="Tools/Table.ascx" tagname="TableUserControl" tagprefix="t1" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grouppermissions_NAX.aspx.cs" Inherits="WorkEnginePPM.Layouts.ppm.grouppermissions_NAX" DynamicMasterPageFile="~masterurl/default.master" %>



<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<script src="general.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="ribbon/ribbon2.css" />
<script src="ribbon/ribbon2.js" type="text/javascript"></script>
<style type="text/css">
.ms-cui-tabBody {
    border-bottom: 0 !important;
}
</style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
<div id="idEditorTabDiv"></div>
<t1:TableUserControl id="table1" runat="server" />

<script type="text/javascript">

    var editorTabData = 
    {
        parent: "idEditorTabDiv",
        style: "display:none;",
        imagePath: "images/",
        showstate: "false",
        sections: [
        {
            name: "Actions",
            tooltip: "Actions",
            columns: [
                {
                    items: [
                        { type: "bigbutton", name: "Add", img: "plus.png", tooltip: "Add", onclick: "dialogEvent('btnAdd');" }
                    ]
                },
                {
                    items: [
                        { type: "bigbutton", id: "btnModify", name: "Modify", img: "delete32.png", tooltip: "Modify", onclick: "dialogEvent('btnModify');", disabled: true }
                    ]
                },
                {
                    items: [
                        { type: "bigbutton", id: "btnDelete", name: "Delete", img: "delete32.png", tooltip: "Delete", onclick: "dialogEvent('btnDelete');", disabled: true }
                    ]
                }
            ]
        }
        ]
    };

    var editorTab = new Ribbon(editorTabData);
    editorTab.Render();

    var OnLoad = function (event) {
    };

    var OnResize = function (event) {
        var obj = document.getElementById("idTableDiv");
        var xy = findAbsolutePosition(obj);
        document.getElementById("idTableDiv").style.height = (document.documentElement.clientHeight - xy[1] - 5) + "px";
    };

    function dialogEvent(action) {
        var sRowId = "";
        var sMode = "";
        switch (action) {
            case "btnAdd":
                sMode = "Add";
                sRowId = 0;
                break;
            case "btnModify":
                sMode = "Modify";
                sRowId = table1.GetSelectedRowId();
                break;
            case "btnDelete":
                sMode = "Delete";
                sRowId = table1.GetSelectedRowId();
                break;
        }
        var options = { url: "grouppermissionform.aspx?id=" + sRowId + "&mode=" + sMode, showMaximized: false, allowMaximize: false, showClose: false, dialogReturnValueCallback: NewItemCallback };
        SP.UI.ModalDialog.showModalDialog(options);
    }
    function NewItemCallback(dialogResult, returnValue) {
        if (dialogResult) {
            window.location.href = window.location.href;
        }
    };

    function table1_row_event(sControlId, sEvent, sRowId) {
        table1.RowEvent(sControlId, sEvent, sRowId);
        switch (sEvent) {
            case "onclick":
                if (editorTab != null) {
                    editorTab.enableItem("btnModify");
                    editorTab.enableItem("btnDelete");
                }
                break;
        }
    };
    findAbsolutePosition = function (obj) {
        var curleftx = 0;
        var curtopy = 0;
        if (obj.offsetParent) {
            do {
                curleftx += obj.offsetLeft;
                curtopy += obj.offsetTop;
            } while (obj = obj.offsetParent);
        }
        return [curleftx, curtopy];
    };

    if (document.addEventListener != null) { // e.g. Firefox
        window.addEventListener("load", OnLoad, true);
        window.addEventListener("resize", OnResize, true);
        //window.addEventListener("beforeunload", beforeUnloadDelegate, true);
        //window.addEventListener("unload", unloadDelegate, true);
    }
    else { // e.g. IE
        window.attachEvent("onload", OnLoad);
        window.attachEvent("onresize", OnResize);
        //window.attachEvent("onbeforeunload", beforeUnloadDelegate);
        //window.attachEvent("onunload", unloadDelegate);
    }
</script>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Group Permissions
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Group Permissions
</asp:Content>
