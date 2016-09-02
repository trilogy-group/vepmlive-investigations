<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
             Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventAudit.aspx.cs" Inherits="EPMLiveReportsAdmin.Layouts.EPMLive.EventAudit"
         DynamicMasterPageFile="~masterurl/default.master" %>

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="~/_controltemplates/ButtonSection.ascx" %>
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
            '';
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
                } else {
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