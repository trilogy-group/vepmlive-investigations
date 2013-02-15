<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportLog.aspx.cs" Inherits="EPMLiveReportsAdmin.Layouts.EPMLive.ReportLog" DynamicMasterPageFile="~masterurl/default.master" %>

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" Src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" Src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register TagPrefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBar" Src="~/_controltemplates/ToolBar.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBarButton" Src="~/_controltemplates/ToolBarButton.ascx" %>

<asp:Content ID="Content4" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    EPM Live Reporting
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
    runat="server">
    <asp:Label ID="lblTitle" runat="server">Reporting Log</asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderPageDescription" runat="server">
    This is a list of events that occured during data synchronization between mapped
    lists and the database.
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

        function OnMouseOver(link) {
            link.style.cursor = 'pointer';
            link.style.textDecoration = 'underline';
        }

        function OnMouseOut(link) {
            link.style.textDecoration = 'none';
        }
    </script>

    <wssuc:ToolBar ID="Toolbar" runat="server">
        <Template_Buttons>
            <wssuc:ToolBarButton runat="server" ID="btnClear" Text="Clear" OnClick="btnClear_Click"
                ImageUrl="/_layouts/images/newitem.gif" Padding="2px" AccessKey="V" />
        </Template_Buttons>
    </wssuc:ToolBar>
    <sharepoint:spgridview id="grdErrors" runat="server" autogeneratecolumns="false"
        headerstyle-cssclass="ms-menutoolbar">
        <Columns>
            <Sharepoint:SPBoundField DataField="RPTListId" HeaderText="ListId" Visible="false" />
            <asp:ImageField DataImageUrlFormatString="images/icon{0}.png" DataImageUrlField="Level"></asp:ImageField>
            <asp:BoundField DataField="TimeStamp" HeaderText="Time" />
            <Sharepoint:SPBoundField DataField="ListName" HeaderText="List" />
            <Sharepoint:SPBoundField DataField="ShortMessage" HeaderText="Message" />
            <asp:TemplateField HeaderText="Log Detail">
            <ItemTemplate>
              <span style="color:#003399;" onmouseover="OnMouseOver(this)" onmouseout="OnMouseOut(this)" onclick="resize('ViewLogDetail.aspx?id=<%#Eval("RPTListId")%>&type=<%#Eval("type")%>&ts=<%#Eval("timestamp")%>&sm=<%#Eval("ShortMessage")%>')">View Log</span>
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </sharepoint:spgridview>
</asp:Content>
