<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.Integration.Manage" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <link href="Manage.css" rel="stylesheet" type="text/css" />
    <script language="javascript">
        function EditFields(list) {
            var options = { url: "EditFields.aspx?LIST=" + list, width: 500, showClose: true };

            SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
        }
    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    <SharePoint:SPGridView runat="server"
	    ID="gvIntegrations" AllowGrouping ="true"
         GroupField="ListName" AllowGroupCollapse="true" DisplayGroupFieldName="false"
	    AutoGenerateColumns="false"
	    Width="400px"
	    AllowSorting="True"
	    AllowPaging="False" OnRowDataBound="gvIntegrations_RowDataBound"  GridLines="None"  >
        <Columns>
	        <SharePoint:SPMenuField HeaderText="Integration Name" TextFields="Title" MenuTemplateId="IntegrationMenu" TokenNameAndValueFields="INTLISTID=INT_LIST_ID,LISTID=LIST_ID" ></SharePoint:SPMenuField>
            <SharePoint:SPBoundField HeaderText ="Description" DataField="Description"></SharePoint:SPBoundField>
            <SharePoint:SPBoundField HeaderText ="Active" DataField="Active"></SharePoint:SPBoundField>
	    </Columns>
	    <AlternatingRowStyle CssClass="ms-alternating" />
	</SharePoint:SPGridView><br /><br />

    <a class="btn btn-success" style="text-decoration:none;" href="Add.aspx">Add New App</a>
    
    <style>
        #s4-ribbonrow, #s4-workspace {
            margin-left: 0 !important;
            overflow-x: hidden;
        }

        .epm-nav-pinned {
            margin-left: 0 !important;
            padding-left: 230px !important;
        }

        .epm-nav-unpinned {
            margin-left: 0 !important;
            padding-left: 50px !important;
        }
    </style>

<script>

    $("#ctl00_PlaceHolderMain_gvIntegrations").addClass("table");

    $(".ms-vb").attr("width", "5%");

    $(".ms-gb:first").find("td").css("padding-top", "0px");


    $("img[alt*='Expand/Collapse']").attr("src", "/_layouts/15/epmlive/images/collapse.png");
    $("img[alt*='Expand/Collapse']").css("position", "relative");
    $("img[alt*='Expand/Collapse']").css("top", "2px");


    $(".ms-core-menu-arrow").replaceWith("<span class='icon-arrow-down-15' style='padding-left:10px;font-size:14px;position:relative;top:1px;'></span>");
    $("img[alt='Open Menu']").replaceWith("<span class='icon-pencil' style='padding-left:5px;font-size:10px;position:relative;top:-2px;'></span>");



    $(".ms-gb").find("a").click(function () {
        if ($(this).parent().parent().parent().parent().parent().parent().attr("isexp") == "true") {
            $(this).find("img").attr("src", "/_layouts/15/epmlive/images/collapse.png");
        }
        else {
            $(this).find("img").attr("src", "/_layouts/15/epmlive/images/expand.png");
        }
    });


    $(".ms-unselectedtitle").click(function () {
        $(".ms-core-menu-box").css("left", "0px");
    });

</script>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Upland Integrations
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Upland Integrations
</asp:Content>
