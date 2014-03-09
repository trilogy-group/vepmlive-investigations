<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllSnapshots.aspx.cs" Inherits="EPMLiveReportsAdmin.Layouts.EPMLive.AllSnapshots" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Content4" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    EPM Live - Snapshot Manager
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
             runat="server">
    EPM Live - Snapshot Manager
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <sharepoint:menutemplate id="mtEventMenu" runat="server">
        <Sharepoint:MenuItemTemplate 
            ID="MenuItemTemplate1" 
            runat="server"
            Text="Edit"           
            ImageUrl="/_layouts/images/CDX16.GIF"         
            ClientOnClickUsingPostBackEvent = "__page,%uid%"
            Title="Edit">
        </Sharepoint:MenuItemTemplate>     
    </sharepoint:menutemplate>
    
    <table class="ms-toolbar" width="100%" cellpadding="3">
        <tr>
            <td class="ms-viewlsts" colspan="2">
                <h3 class="ms-standardheader">
                    Schedules</h3>
            </td>
        </tr>
    </table>
    <SharePoint:SPGridView ID="grdVwSchedules" runat="server" AutoGenerateColumns="false"
                           HeaderStyle-CssClass="ms-alternatingstrong" Width="70%">
        <Columns>
            <SharePoint:SPMenuField HeaderText="Schedule Name" TextFields="Schedule Name" HeaderStyle-Font-Size="Smaller"
                                    MenuTemplateId="mtEventMenu" ToolTipFields="Schedule Name" TokenNameAndValueFields="uid=timerjobuid" />
        </Columns>
    </SharePoint:SPGridView>
    <table>
        <tr>
            <td class="ms-propertysheet">
                <img alt="" src="/_layouts/images/rect.gif" />
                <img width="8" height="1" alt="" src="/_layouts/images/blank.gif" />
                <a runat="server" id="lnk_createSchedule">Create New Schedule</a>
            </td>
        </tr>
    </table>


    <table class="ms-toolbar" width="100%" cellpadding="3">
        <tr>
            <td class="ms-viewlsts" colspan="2">
                <h3 class="ms-standardheader">
                    All Snapshots</h3>
            </td>
        </tr>
    </table>
    <sharepoint:spgridview id="grdVwSnapshots" runat="server" autogeneratecolumns="false"
                           headerstyle-cssclass="ms-alternatingstrong" width="70%">
        <Columns>
            <Sharepoint:SPMenuField                        
                HeaderText="Report Title"
                TextFields="Report Title"
                HeaderStyle-Font-Size="Smaller"
                HeaderStyle-ForeColor = "Black"
                MenuTemplateId="mtEventMenu"
                ToolTipFields="Report Title"
                TokenNameAndValueFields="uid=periodid"                                
                />
        </Columns>
    </sharepoint:spgridview>
</asp:Content>