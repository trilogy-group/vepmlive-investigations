<%@ Control Language="C#" AutoEventWireup="false" Inherits="EPMLiveCore.CascadingLookupFieldSettings,EPM Live Core,Version=1.0.0.0,Culture=neutral,PublicKeyToken=9f4da00116c38ec5" %>
<%@ Register TagPrefix="WSSUserControl" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="WSSUserControl" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Import Namespace="Microsoft.SharePoint" %>

<WSSUserControl:InputFormSection runat="server" id="MySections" Title="Cascading Lookup Settings">
    <Template_InputFormControls>
        <WSSUserControl:InputFormControl runat="server" LabelText="">
            <Template_Control>
                <table class="ms-vb" cellpadding="1" cellspacing="1" border="0">
                    <tr>
                        <td style="white-space:nowrap; padding:4px 0px 0px 0px" valign="top"><asp:Label runat="server" ID="lblUrl" Text="Site Url : " /></td>
                        <td style="white-space:nowrap">
                            <table class="ms-vb" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td><asp:TextBox runat="server" ID="txtUrl" CssClass="ms-radiotext" Width="350px" /></td>
                                </tr>
                                <tr>
                                    <td style="padding-bottom:9px;">
                                        <table class="ms-vb" border="0">
                                            <tr>
                                                <td>Static Url :</td>
                                                <td>Enter Full Url (i.e. http://server/site)</td>
                                            </tr>
                                            <tr>
                                                <td>Relative Url :</td>
                                                <td>Enter Keyword (Current, Top, Parent, Parent.Parent)</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:Button runat="server" ID="btnLoad" Text="Load Lists" CssClass="ms-ButtonHeightWidth" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="white-space:nowrap"><asp:Label runat="server" ID="lblList" Text="List Name : "  /></td>
                        <td><asp:DropDownList runat="server" ID="ddlList" CssClass="ms-radiotext" Width="175px" /></td>
                    </tr>
                    <tr>
                        <td style="white-space:nowrap"><asp:Label runat="server" ID="lblField" Text="Field Name : "  /></td>
                        <td><asp:DropDownList runat="server" ID="ddlField" CssClass="ms-radiotext" Width="175px" /></td>
                    </tr>
                    <tr>
                        <td style="white-space:nowrap"></td>
                        <td><asp:CheckBox runat="server" ID="chkDefineNone" CssClass="ms-radiotext" Text="Define [Select One...]" /></td>
                    </tr>
                    <tr>
                        <td style="white-space:nowrap"></td>
                        <td style="white-space:nowrap"><asp:CheckBox runat="server" ID="chkFilterCriteria" CssClass="ms-radiotext" Text="Define Filter Criteria" /></td>
                    </tr>
                    <tr>
                        <td style="white-space:nowrap"><asp:Label runat="server" ID="lblParentField" Text="Parent Field Name : "  /></td>
                        <td><asp:DropDownList runat="server" ID="ddlParentField" CssClass="ms-radiotext" Width="175px" /></td>
                    </tr>
                    <tr>
                        <td style="white-space:nowrap"><asp:Label runat="server" ID="lblFilterValueField" Text="Filter Value Field Name : "  /></td>
                        <td><asp:DropDownList runat="server" ID="ddlFilterValueField" CssClass="ms-radiotext" Width="175px" /></td>
                    </tr>
                    <tr>
                        <td colspan="2"><asp:Label runat="server" ID="lblError" CssClass="ms-alerttext" /></td>
                    </tr>
                </table>
            </Template_Control>
        </WSSUserControl:InputFormControl>
    </Template_InputFormControls>
</WSSUserControl:InputFormSection>