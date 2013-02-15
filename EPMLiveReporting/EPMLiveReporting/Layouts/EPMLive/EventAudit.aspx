<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventAudit.aspx.cs" Inherits="EPMLiveReportsAdmin.Layouts.EPMLive.EventAudit"
    DynamicMasterPageFile="~masterurl/default.master" %>

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" Src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" Src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBar" Src="~/_controltemplates/ToolBar.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBarButton" Src="~/_controltemplates/ToolBarButton.ascx" %>
<%@ Register TagPrefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<asp:Content ID="Content4" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    EPM Live - Reporting Eventhandler Audit
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
    runat="server">
    EPM Live - Reporting Eventhandler Audit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderPageDescription" runat="server">
    Use this page to identify which site and list does not have the reporting event
    handlers present.
    <script type="text/javascript" language="javascript">
        function CheckUnCheckAll(value) {
            var sSuffix = "cb_add";
            ''
            var tblUpdatedTasks = document.getElementById('ctl00_PlaceHolderMain_grdVwResults');
            var sCheckBoxId;
            var iTaskCount = tblUpdatedTasks.rows.length - 1;
            var iTaskCounter = 0;
            var cb;

            while (iTaskCounter < iTaskCount) {
                sCheckBoxId = "ctl00_PlaceHolderMain_grdVwResults_row" + iTaskCounter.toString() + "_" + sSuffix + iTaskCounter.toString();
                cb = document.getElementById(sCheckBoxId);
                if (value == true && cb.disabled == false) {
                    cb.checked = true;
                }
                else {
                    cb.checked = false;
                }
                iTaskCounter++;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <SharePoint:SPGridView ID="grdVwResults" runat="server" AutoGenerateColumns="false"
        HeaderStyle-CssClass="ms-menutoolbar" Width="70%">
    </SharePoint:SPGridView>
    <wssuc:ButtonSection runat="server" ID="buttons">
        <Template_Buttons>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                <input class="ms-ButtonHeightWidth" id="save" accesskey="O" type="submit" value="Save"
                    runat="server" /></asp:PlaceHolder>
        </Template_Buttons>
    </wssuc:ButtonSection>
</asp:Content>
