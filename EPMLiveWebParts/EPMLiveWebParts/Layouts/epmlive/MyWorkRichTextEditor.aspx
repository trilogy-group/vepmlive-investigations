<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyWorkRichTextEditor.aspx.cs" Inherits="EPMLiveCore.MyWorkRichTextEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="dhtml/xeditor/skins/dhtmlxeditor_dhx_skyblue.css">
    <link rel="stylesheet" type="text/css" href="dhtml/xtoolbar/skins/dhtmlxtoolbar_dhx_skyblue.css">
    <script src="<%=SiteUrl%>/_layouts/epmlive/dhtml/xeditor/dhtmlxcommon.js"></script>
    <script src="<%=SiteUrl%>/_layouts/epmlive/dhtml/xeditor/dhtmlxeditor.js"></script>
    <script src="<%=SiteUrl%>/_layouts/epmlive/dhtml/xeditor/ext/dhtmlxeditor_ext.js"></script>
    <script src="<%=SiteUrl%>/_layouts/epmlive/dhtml/xtoolbar/dhtmlxtoolbar.js"></script>
</head>
<body>
    <form id="theForm" runat="server">
    <div id="content" style="display:none;"><%=HttpUtility.HtmlDecode(RichTextValue)%></div>
    <div id="editorObj" style="width: 580px; height: 343px; border: #909090 1px solid;"></div>
    <div style="width:580px;text-align:right;margin-top:10px;"><asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="window.parent.SP.UI.ModalDialog.commonModalDialogClose(1, escape(editor.getContent()))" UseSubmitBehavior="False" />&nbsp;&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="window.parent.SP.UI.ModalDialog.commonModalDialogClose(0, 0)" UseSubmitBehavior="False" /></div>
    <script type="text/javascript">
        var editor;
        dhtmlx.image_path = "<%=SiteUrl%>/_layouts/epmlive/dhtml/xeditor/imgs/";
        window.onload = function ()
        {
            editor = new dhtmlXEditor("editorObj");
            editor.setContent(document.getElementById("content").innerHTML);
        }
    </script>
    </form>
</body>
</html>
