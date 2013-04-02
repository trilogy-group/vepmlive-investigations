<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoteEditor.aspx.cs" Inherits="EPMLiveWorkPlanner.Layouts.EPMLiveWorkPlanner.NoteEditor" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<link rel="stylesheet" type="text/css" href="dhtml/xeditor/skins/dhtmlxeditor_dhx_skyblue.css">
<link rel="stylesheet" type="text/css" href="dhtml/xToolbar/skins/dhtmlxtoolbar_dhx_skyblue.css">
    <script src="dhtml/xlayout/dhtmlxcommon.js"></script> 

    <script src="dhtml/xeditor/dhtmlxeditor.js"></script>
    <script src="dhtml/xeditor/ext/dhtmlxeditor_ext.js"></script>
    <script src="dhtml/xToolbar/dhtmlxtoolbar.js"></script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <div id="editorObj" style="width: 590px; height: 350px; border: #909090 1px solid;"></div>
    <br />
    <input type="button" value="Save" onclick="save();" class="ms-ButtonHeightWidth" />&nbsp;
    <input type="button" value="Cancel" onclick="parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.cancel, 'Cancel clicked'); return false;" class="ms-
ButtonHeightWidth" />

    <script language="javascript">

        function save() {
            parent.SetRichTextHtml(editor.getContent());
            parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
        }

        function load() {
            dhtmlx.image_path = "dhtml/xeditor/imgs/";
            editor = new dhtmlXEditor("editorObj");
            editor.init();

            editor.setContent(parent.Grids.WorkPlannerGrid.GetValue(parent.Grids.WorkPlannerGrid.FRow, "Notes"));
        }

        _spBodyOnLoadFunctionNames.push("load");
    </script>
</asp:Content>
<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Application Page
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
My Application Page
</asp:Content>
