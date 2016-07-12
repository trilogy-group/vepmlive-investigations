<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Buttonbar.ascx.cs" Inherits="WorkEnginePPM.ControlTemplates.WorkEnginePPM.Buttonbar" %>

<link id="buttonbarStyles" href="buttonbar.css" type="text/css" rel="stylesheet" />

<div><asp:placeholder runat="server" id="idButtonBarBody" /></div>

<asp:HiddenField ID="idPersistButtonBar" runat="server" />

<script type="text/javascript">
    function bb_SetButtonState(sButtonId, bDisabled) {
        //alert("bb_SetButtonState");
        if (this.document.getElementById) {
            var thisButton = this.document.getElementById(sButtonId);
            thisButton.disabled = bDisabled;
        }
    }

    function bb_PrepareForPostBack() {
        var buttonBar = document.getElementById("idButtonBar");
        var persistTreeTable = document.getElementById(this.clientID + "_" + "idPersistButtonBar");
        //var s = treeTable.outerHTML.toString();
        var s = getOuterHTML(buttonBar);
        persistTreeTable.value = encodeString(s);
    }


    function getOuterHTML(object) {
        // this is for firefox compatibility
        var element;
        if (!object) return null;
        element = document.createElement("div");
        element.appendChild(object.cloneNode(true));
        return element.innerHTML;
    }
</script>

