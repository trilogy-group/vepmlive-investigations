<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllSchedules.aspx.cs" Inherits="EPMLiveReportsAdmin.Layouts.EPMLive.AllSchedules"
         DynamicMasterPageFile="~masterurl/default.master" %>

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" Src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" Src="~/_controltemplates/InputFormSection.ascx" %>
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
            } else {
                window.open(url, 'EPMLIVE - View Log Details', 'height=400,width=500,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no ,modal=yes');
            }
        }
    </script>
    <table width="100%">
        <wssuc:InputFormSection ID="InputFormSection1" Title="Reporting Refresh:" Description=""
                                runat="server">
            <Template_Description>
                Choose a time when the Reporting Refresh will take place. This time should be set
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
        <wssuc:ButtonSection ID="ButtonSection1" runat="server">
            <Template_Buttons>
                <asp:Button UseSubmitBehavior="false" class="ms-ButtonHeightWidth" runat="server" ID="btnRunNow" Text="Run Now" OnClick="RunRefreshNow" />
                <asp:Button UseSubmitBehavior="false" class="ms-ButtonHeightWidth" runat="server" ID="btnSave" Text="Save" OnClick="SaveSchedule" />
            </Template_Buttons>
        </wssuc:ButtonSection>
    </table>
    <%--<table class="ms-toolbar" width="100%" cellpadding="3">
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
    </table>--%>
</asp:Content>