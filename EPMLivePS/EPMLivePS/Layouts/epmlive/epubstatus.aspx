<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="epubstatus.aspx.cs" Inherits="EPMLiveEnterprise.Layouts.epmlive.epubstatus" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	WorkEngine for Project Server Publisher Status
</asp:Content>
<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	WorkEngine for Project Server Publisher Status
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to view the status on projects published using WorkEngine Publisher.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
    
    <script type="text/javascript" src="modal/modal.js"></script>
    <script type="text/javascript" src="dhtml/xajax/dhtmlxcommon.js"></script>
    <link rel="stylesheet" href="modal/modalmain.css" type="text/css" />
    
    
    <SharePoint:SPGridView runat="server"
	 ID="GvItems"
	 AutoGenerateColumns="false"
	 width="100%"
	 AllowSorting="True"
	 OnRowDataBound="GvItems_RowDataBound" >
    <Columns>
	    <SharePoint:SPMenuField HeaderText="Project" TextFields="projectname" MenuTemplateId="PropertyNameListMenu" TokenNameAndValueFields="NAME=projectguid"></SharePoint:SPMenuField>
	    <SharePoint:SPBoundField DataField="status" HeaderText="Status"></SharePoint:SPBoundField>
	    <SharePoint:SPBoundField DataField="laststatusdate" HeaderText="Status Date"></SharePoint:SPBoundField>
	    <asp:BoundField DataField="weburl" HeaderText="Site Url" HtmlEncode="false"></asp:BoundField>
	 </Columns>
	 <AlternatingRowStyle CssClass="ms-alternating" />
	 </SharePoint:SPGridView>
	 
	<div id="dlgLinking" class="dialog">
        <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <img src="../images/GEARS_AN.GIF" style="vertical-align: middle;"/><br />
                    <H3 class="ms-standardheader">Linking Workspace...</h3>
                </td>
            </tr>
        </table>
    </div> 
	 
	 <script language="javascript">

	     function linkResponse(loader) {
	         if (loader.xmlDoc.responseText != null) {
	             if (loader.xmlDoc.responseText.substring(0, 5) != "Error") {
	                 location.href = 'epubstatus.aspx';
	             }
	             else {
	                 alert(loader.xmlDoc.responseText);
	             }
	         }
	         else
	             alert("Response contains no XML");

	         hm('dlgLinking');
	     }

	     function linkworkspace(projectid) {
	         var url = prompt('Enter Workspace URL', '');

	         if (url != null && url != "") {
	             sm('dlgLinking', 200, 100);

	             dhtmlxAjax.post("eaction.aspx", "action=link&projectid=" + projectid + "&url=" + url, linkResponse);
	         }
	     }
	     initmb();
	 </script>
</asp:Content>