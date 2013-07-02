<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListMappings.aspx.cs" Inherits="EPMLiveReportsAdmin.Layouts.EPMLive.ListMappings" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" Src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" Src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBar" Src="~/_controltemplates/ToolBar.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBarButton" Src="~/_controltemplates/ToolBarButton.ascx" %>
<%@ Register TagPrefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ID="Content4" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    EPM Live Reporting
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
    runat="server">
    Mapped Lists
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderPageDescription" runat="server">
    This is a list of currently mapped lists.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PlaceHolderMain" runat="server">

<script type="text/javascript" src="/_layouts/epmlive/DHTML/dhtmlxajax.js"></script>
<link rel="stylesheet" href="/_layouts/epmlive/modal/modalmain.css" type="text/css" />
<script type="text/javascript" src="/_layouts/epmlive/modal/modal.js"></script>
    
<table class="ms-menutoolbar" cellpadding="2" cellspacing="0" border="0" width="100%">
    <tr height="23">
        <td class="ms-toolbar">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td valign="center">
                        <asp:Panel ID="pnlActionsMenu" runat="server">
                        </asp:Panel>
                    </td>
                    <td class="ms-separator">
                        <img src='/_layouts/images/blank.gif' alt=''>
                    </td>
                    <td valign="center">
                        <asp:Panel ID="pnlSettingsMenu" runat="server">
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    </table>
    
    <sharepoint:menutemplate id="mtEventMenu" runat="server">
       <Sharepoint:MenuItemTemplate ID="MenuItemTemplate1" runat="server"
           Text="Cleanup" ImageUrl="images/EPMRefresh.gif"         
           ClientOnClickUsingPostBackEvent = "__page,%NAME%_cleanup"
           >
      </Sharepoint:MenuItemTemplate>
      <Sharepoint:MenuItemTemplate ID="MenuItemTemplate2" runat="server"
           Text="Snapshot"  ImageUrl="images/EPMSnapshot.gif"         
           ClientOnClickPostBackConfirmation="Are you sure you want to manually snapshot this item?"    
           ClientOnClickUsingPostBackEvent = "__page,%NAME%_snapshot"
           >
      </Sharepoint:MenuItemTemplate>     
     <Sharepoint:MenuItemTemplate ID="MenuItemTemplate3" runat="server"
           Text="Event Audit" ImageUrl="images/EPMAudit.gif"         
           ClientOnClickPostBackConfirmation="Are you sure you want to audit this item?"    
           ClientOnClickNavigateUrl="EventAudit.aspx?LName=%NAME%&SID=%SID%"
            >
      </Sharepoint:MenuItemTemplate>     
     <Sharepoint:MenuItemTemplate ID="MenuItemTemplate4" runat="server"
           Text="Status Log" ImageUrl="images/EPMAudit.gif"         
           ClientOnClickNavigateUrl="ReportLog.aspx?ListId=%ID%"
           >
      </Sharepoint:MenuItemTemplate>     
      <Sharepoint:MenuItemTemplate ID="MenuItemTemplate5" runat="server"
           Text="Edit" ImageUrl="images/EPMEdit.gif"         
           ClientOnClickNavigateUrl="SetupListMapping.aspx?ListID=%ID%"
           >
      </Sharepoint:MenuItemTemplate>
     <Sharepoint:MenuItemTemplate ID="MenuItemTemplate6" runat="server"
           Text="Delete" ImageUrl="/_layouts/images/delete.gif"         
           ClientOnClickPostBackConfirmation="Are you sure you want to delete this item?"
           ClientOnClickUsingPostBackEvent="__page,%ID%_delete"
           >
      </Sharepoint:MenuItemTemplate>
  </sharepoint:menutemplate>
    <sharepoint:spgridview id="GridView1" runat="server" autogeneratecolumns="false"
        headerstyle-cssclass="ms-menutoolbar">
        <Columns>
            <Sharepoint:SPMenuField
                  HeaderText="List"
                  TextFields="ListName"
                  MenuTemplateId="mtEventMenu"
                  TokenNameAndValueFields="ID=RPTListId,NAME=ListName,SID=SiteId"
                  />
            <Sharepoint:SPBoundField DataField="RPTListId" HeaderText="ListId" Visible="false" />
            <asp:TemplateField HeaderText="Resource List">
            <ItemTemplate>
                <asp:Label ID="lblResourceList" runat="server" Text='<%# (bool)Eval("ResourceList") ? "Yes":"No" %>' ToolTip='<%# (bool)Eval("ResourceList") ? "Some fields on this mapping have been locked to retain compatibility with the resource reporting module. You can override the lock by selecting Unlock in the list options.":"" %>' />
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
            <ItemTemplate><%# GetIconLink(1) %></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Snapshot">
            <ItemTemplate><%# GetIconLink(2) %></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cleanup">
            <ItemTemplate><%# GetIconLink(3) %></ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </sharepoint:spgridview>
    <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
    
    <asp:Label ID="lblAccountInfo" runat="server" Visible="false">
        
    </asp:Label>

    <div id="dlgWaiting" class="dialog">
    <table width="100%">
        <tr>
            <td align="center" class="ms-sectionheader">
                <img src="/_layouts/images/GEARS_AN.GIF" style="vertical-align: middle;"/><br />
                <H3 class="ms-standardheader">Please wait...</h3>
            </td>
        </tr>
    </table>
    </div>

<script type="text/javascript">

    initmb();

    function submit(action) {
        sm('dlgWaiting', 200, 100);
        dhtmlxAjax.post('Action.aspx', "action=" + action, closeSubmit);
    }

    function closeSubmit(loader) {
        if (loader.xmlDoc.responseText != null) {
            if (loader.xmlDoc.responseText.substring(0, 5) != "Error") {
                //alert('Success');
                window.location.reload();
            }
            else {
                alert(loader.xmlDoc.responseText);
            }
        }
        else {
            alert("Response contains no XML");
        }
        hm('dlgWaiting');
    }

    function VerifyThenSubmit() {
        var options = {
            title: 'Cleanup Confirmation',
            url: 'cleanupwarning.aspx',
            width: 500,
            allowMaximize: false,
            showClose: false,
            autoSize: false,
            dialogReturnValueCallback: verifySubmit
        };

        SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
    }

    function verifySubmit(dialogResult, returnVal) {
        if (dialogResult == 1) {
            submit('CleanupAll');
        }
    }
</script>


</asp:Content>
