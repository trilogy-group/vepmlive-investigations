<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllSchedules.aspx.cs" Inherits="EPMLiveReportsAdmin.Layouts.EPMLive.AllSchedules"
    DynamicMasterPageFile="~masterurl/default.master" %>

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" Src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" Src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBar" Src="~/_controltemplates/ToolBar.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBarButton" Src="~/_controltemplates/ToolBarButton.ascx" %>
<%@ Register TagPrefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<asp:Content ID="Content4" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Report Manager
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
    runat="server">
    Report Manager
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <script type="text/javascript" language="javascript">
        function resize(url) {
            if (window.showModalDialog) {
                window.showModalDialog(url, 'EPMLIVE - View Log Details', 'dialogWidth:500px;dialogHeight:400px');
            }
            else {
                window.open(url, 'EPMLIVE - View Log Details', 'height=400,width=500,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no ,modal=yes');
            }
        }
    </script>
    <SharePoint:MenuTemplate ID="mtEventMenu" runat="server">
        <SharePoint:MenuItemTemplate ID="MenuItemTemplate1" runat="server" Text="Edit" ImageUrl="/_layouts/images/CDX16.GIF"
            ClientOnClickUsingPostBackEvent="__page,%uid%_" Title="Edit">
        </SharePoint:MenuItemTemplate>
        <SharePoint:MenuItemTemplate ID="MenuItemTemplateDelete" runat="server" Text="Delete"
            ImageUrl="/_layouts/images/CDX16.GIF" ClientOnClickUsingPostBackEvent="__page,%uid%"
            Title="Delete">
        </SharePoint:MenuItemTemplate>
        <SharePoint:MenuItemTemplate ID="MenuItemTemplate3" runat="server" Text="View log"
            ImageUrl="/_layouts/images/CDX16.GIF" 
            Title="View log"
            ClientOnClickScript="resize('/_layouts/epmlive/ViewLogDetail.aspx?uid=%uid%')">
        </SharePoint:MenuItemTemplate>
    </SharePoint:MenuTemplate>
    <table width="100%">
        <wssuc:InputFormSection ID="InputFormSection1" Title="Reporting Cleanup:" Description=""
            runat="server">
            <Template_Description>
                Choose a time when the Reporting Cleanup will take place. This time should be set
                to a time when your system will be idle or close to idle.
            </Template_Description>
            <Template_InputFormControls>
                <wssuc:InputFormControl ID="InputFormControl1" LabelText="Refresh Schedule" runat="server">
                    <Template_Control>
                        <asp:Label ID="lbl1" Text="Select time" runat="server"></asp:Label><br />
                        <br />
                        <asp:DropDownList ID="DropDownListTimes" runat="server">
                            <asp:ListItem Enabled="true" Selected="true" Value="-1" Text="Disabled"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="0" Text="12:00 AM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="1" Text="1:00 AM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="2" Text="2:00 AM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="3" Text="3:00 AM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="4" Text="4:00 AM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="5" Text="5:00 AM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="6" Text="6:00 AM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="7" Text="7:00 AM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="8" Text="8:00 AM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="9" Text="9:00 AM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="10" Text="10:00 AM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="11" Text="11:00 AM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="12" Text="12:00 PM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="13" Text="1:00 PM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="14" Text="2:00 PM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="15" Text="3:00 PM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="16" Text="4:00 PM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="17" Text="5:00 PM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="18" Text="6:00 PM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="19" Text="7:00 PM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="20" Text="8:00 PM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="21" Text="9:00 PM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="22" Text="10:00 PM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="23" Text="11:00 PM"></asp:ListItem>
                        </asp:DropDownList>
                    </Template_Control>
                </wssuc:InputFormControl>
                <wssuc:InputFormControl ID="InputFormControl2" LabelText="Last Run" runat="server">
                    <Template_Control>
                        <asp:Label ID="lblLastRun" runat="server"></asp:Label>
                    </Template_Control>
                </wssuc:InputFormControl>
                <wssuc:InputFormControl ID="InputFormControl3" LabelText="Last Result" runat="server">
                    <Template_Control>
                        <asp:Label ID="lblMessages" runat="server"></asp:Label>
                    </Template_Control>
                </wssuc:InputFormControl>
                <wssuc:InputFormControl ID="InputFormControl4" LabelText="Log" runat="server">
                    <Template_Control>
                        <a href="viewmessages.aspx?type=5">View Log</a>
                    </Template_Control>
                </wssuc:InputFormControl>
            </Template_InputFormControls>
        </wssuc:InputFormSection>
        <br />
        <wssuc:ButtonSection ID="ButtonSection1" runat="server" ShowStandardCancelButton="false">
            <Template_Buttons>
                <input class="ms-ButtonHeightWidth" id="btnSave" accesskey="O" type="submit" value="Save"
                    runat="server" />
                <input class="ms-ButtonHeightWidth" id="btnCancel" accesskey="1" type="submit" value="Cancel"
                    runat="server" />
            </Template_Buttons>
        </wssuc:ButtonSection>
    </table>
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
</asp:Content>
