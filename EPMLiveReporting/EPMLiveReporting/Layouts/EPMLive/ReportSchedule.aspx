<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
             Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportSchedule.aspx.cs"
         Inherits="EPMLiveReportsAdmin.Layouts.EPMLive.ReportSchedule" DynamicMasterPageFile="~masterurl/default.master" %>

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" Src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" Src="~/_controltemplates/InputFormSection.ascx" %>
<asp:Content ID="Content4" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    <SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" Text="Report Schedule"
                               EncodeMethod='HtmlEncode' />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
             runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="Report Schedule"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderPageDescription" runat="server">
    Use this page to control the Schedule settings
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <table width="100%">
        <wssuc:InputFormSection ID="InputFormSection1" Title="Schedule Description" Description=""
                                runat="server">
            <Template_Description>
                Brief description of the types of reports that will be ran (i.e. "Earned Value Reports").
                <br />
                <br />
                <br />
                <br />
            </Template_Description>
            <Template_InputFormControls>
                <wssuc:InputFormControl ID="InputFormControl1" LabelText="Schedule Title" runat="server">
                    <Template_Control>
                        <asp:TextBox ID="txtScheduleTitle" BackColor="White" Width="300" runat="server" CssClass="ms-authoringcontrols"></asp:TextBox>
                        <br />
                    </Template_Control>
                </wssuc:InputFormControl>
            </Template_InputFormControls>
        </wssuc:InputFormSection>    
        <wssuc:InputFormSection ID="InputFormSection2" Title="Schedule Type" Description=""
                                runat="server">
            <Template_Description>
                Choose how often you would like a Snapshot taken.
                <br />
                <br />
                <br />
                <br />
            </Template_Description>
            <Template_InputFormControls>
                <wssuc:InputFormControl ID="InputFormControl2" runat="server" LabelText="Schedule Type">
                    <Template_Control>
                        <asp:DropDownList ID="DropDownListScheduleType" runat="server" AutoPostBack="true">
                            <asp:ListItem Enabled="true" Selected="true" Value="2" Text="Daily"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="3" Text="Monthly"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                    </Template_Control>
                </wssuc:InputFormControl>
                <wssuc:InputFormControl ID="InputFormControl3" LabelText="Time" runat="server">
                    <Template_Control>
                        <asp:DropDownList ID="DropDownListSnapshotTime" runat="server">
                            <asp:ListItem Enabled="true" Selected="true" Value="" Text="Disabled"></asp:ListItem>
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
                            <asp:ListItem Enabled="true" Selected="false" Value="0" Text="12:00 AM"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                    </Template_Control>
                </wssuc:InputFormControl>
                <wssuc:InputFormControl ID="FrequencyOptions" runat="server">
                    <Template_Control>
                        <asp:CheckBoxList ID="CheckBoxList_days" runat="server" CssClass="ms-vb2">
                            <asp:ListItem Text="Monday" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Tuesday" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Wednesday" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Thursday" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Friday" Value="5"></asp:ListItem>
                            <asp:ListItem Text="Saturday" Value="6"></asp:ListItem>
                            <asp:ListItem Text="Sunday" Value="7"></asp:ListItem>
                        </asp:CheckBoxList>
                        <asp:DropDownList ID="DropDownListDays" runat="server" Visible="false">
                            <asp:ListItem Enabled="true" Selected="false" Value="1" Text="1"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="2" Text="2"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="3" Text="3"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="4" Text="4"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="5" Text="5"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="6" Text="6"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="7" Text="7"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="8" Text="8"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="9" Text="9"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="10" Text="10"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="11" Text="11"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="12" Text="12"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="13" Text="13"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="14" Text="14"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="15" Text="15"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="16" Text="16"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="17" Text="17"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="18" Text="18"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="19" Text="19"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="20" Text="20"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="21" Text="21"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="22" Text="22"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="23" Text="23"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="24" Text="24"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="25" Text="25"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="26" Text="26"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="27" Text="27"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="28" Text="28"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="29" Text="29"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="30" Text="30"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="false" Value="31" Text="31"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                    </Template_Control>
                </wssuc:InputFormControl>
            </Template_InputFormControls>
        </wssuc:InputFormSection>
        <wssuc:InputFormSection ID="InputFormSection3" Title="List Selection" Description=""
                                runat="server">
            <Template_Description>
                Choose which lists you would like a Snapshot taken on.
                <br />
                <br />
                <br />
                <br />
            </Template_Description>
            <Template_InputFormControls>
                <wssuc:InputFormControl ID="InputFormControl4" LabelText="Select lists" runat="server">
                    <Template_Control>
                        <asp:ListBox ID="ListBoxLists" runat="server" SelectionMode="Multiple"></asp:ListBox>
                        <br />
                        <asp:Label ID="lblErrorSite" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                    </Template_Control>
                </wssuc:InputFormControl>
            </Template_InputFormControls>
        </wssuc:InputFormSection>
        <wssuc:ButtonSection ID="ButtonSection1" runat="server">
            <Template_Buttons>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                    <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth"
                                OnClick="Button1_Click" Text="Save Settings" ID="Button1" AccessKey="" Width="150" />
                </asp:PlaceHolder>
            </Template_Buttons>
        </wssuc:ButtonSection>
    </table>
</asp:Content>