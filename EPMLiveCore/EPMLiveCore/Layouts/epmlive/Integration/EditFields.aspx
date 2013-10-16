<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditFields.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.Integration.EditFields" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script language="Javascript">
        function pageRedir(url) {
            window.location = url;
        }
    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <SharePoint:SPGridView runat="server"
                        ID="GvFields"
                        AutoGenerateColumns="false"
                        style="width: 600"
                        AllowSorting="True"
                        AllowPaging="True"
                        DataKeyNames="DisplayName"
                        PageSize="100" OnRowDataBound="GvFields_RowDataBound">
    <Columns>
        <SharePoint:SPBoundField DataField="DisplayName" HeaderText="Column (click to edit)" HeaderStyle-Font-Bold="false" AccessibleHeaderText="Display Name" ControlStyle-Width="250" ></SharePoint:SPBoundField>
        <SharePoint:SPBoundField DataField="FieldType" HeaderText="Type" HeaderStyle-Font-Bold="false" ControlStyle-Width="450" ></SharePoint:SPBoundField>
    </Columns>
    <AlternatingRowStyle CssClass="ms-alternating" />
</SharePoint:SPGridView><br /><br />

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td nowrap class="ms-descriptiontext" align="left" style="padding-top: 7px; padding-left: 3px;">
                                            <img src="/_layouts/images/setrect.gif" alt="" />&nbsp;
                                            <a href="<%
                                                         Response.Write(SPContext.Current.Web.Url +
                                                                        "/_layouts/fldNew.aspx?source=" +
                                                                        HttpUtility.UrlEncode(
                                                                            HttpContext.Current.Request.
                                                                                RawUrl) + "&List=" +
                                                                        Request["List"]);
%>">Create column</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td nowrap class="ms-descriptiontext" align="left" style="padding-top: 7px; padding-left: 3px;">
                                            <img src="/_layouts/images/setrect.gif" alt="" />&nbsp;
                                            <a href="<%
                                                         Response.Write(SPContext.Current.Web.Url +
                                                                        "/_layouts/formEdt.aspx?source=" +
                                                                        HttpUtility.UrlEncode(
                                                                            HttpContext.Current.Request.RawUrl) +
                                                                        "&List=" +
                                                                        Request["List"]);
            %>">Reorder columns</a>
                                        </td>
                                    </tr>
                                </table>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Edit Fields
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Edit Fields
</asp:Content>
