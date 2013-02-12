<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Register TagPrefix="WSSUserControl" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="WSSUserControl" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DaysHoursBreakdownFieldSettings.ascx.cs" Inherits="EPMLiveCore.DaysHoursBreakdownFieldSettings" %>

<WSSUserControl:InputFormSection runat="server" id="DaysHoursBreakdownSettingsSection" Title="Days Hours Breakdown Settings">
    <Template_InputFormControls>
        <WSSUserControl:InputFormControl runat="server">
            <Template_Control>
                <b>List Settings:</b><br/>
                <table class="ms-vb" cellpadding="2.5" cellspacing="2.5" border="0">
                    <tr>
                        <td style="white-space:nowrap">
                            Resource Pool list:
                        </td>
                        <td>
                            <asp:DropDownList ID="ResourcePoolDropDownList" runat="server" CssClass="ms-radiotext"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="white-space:nowrap">
                            Work Hours list:
                        </td>
                        <td>
                            <asp:DropDownList ID="WorkHoursDropDownList" runat="server" CssClass="ms-radiotext"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="white-space:nowrap">
                            Holidays list:
                        </td>
                        <td>
                            <asp:DropDownList ID="HolidaysDropDownList" runat="server" CssClass="ms-radiotext" OnSelectedIndexChanged="HolidaysDropDownListSelectionIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <br/><hr/><br/>
                <b>Field Settings:</b><br/>
                <table class="ms-vb" cellpadding="2.5" cellspacing="2.5" border="0">
                    <tr>
                        <td style="white-space:nowrap">
                            Start date field:
                        </td>
                        <td>
                            <asp:DropDownList ID="StartDateFieldDropDownList" runat="server" CssClass="ms-radiotext" AutoPostBack="True"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="white-space:nowrap">
                            Finish date field:
                        </td>
                        <td>
                            <asp:DropDownList ID="FinishDateFieldDropDownList" runat="server" CssClass="ms-radiotext" AutoPostBack="True"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="white-space:nowrap">
                            Hours field:
                        </td>
                        <td>
                            <asp:DropDownList ID="HoursDropDownList" runat="server" CssClass="ms-radiotext"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="white-space:nowrap">
                            Holiday Schedules field:
                        </td>
                        <td>
                            <asp:UpdatePanel ID="DaysHoursBreakdownSettingsHSUpdatePanel" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="HolidaySchedulesDropDownList" runat="server" CssClass="ms-radiotext"></asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="HolidaysDropDownList" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
                <table class="ms-vb" cellpadding="1" cellspacing="1" border="0">
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="DaysHoursBreakdownSettingsUpdatePanel" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Label ID="ErrorLabel" runat="server" CssClass="ms-alerttext" Visible="False"></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="StartDateFieldDropDownList" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="FinishDateFieldDropDownList" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </Template_Control>
        </WSSUserControl:InputFormControl>
    </Template_InputFormControls>
</WSSUserControl:InputFormSection>