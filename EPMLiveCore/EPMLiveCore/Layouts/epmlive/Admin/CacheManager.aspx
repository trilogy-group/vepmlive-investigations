<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CacheManager.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.Admin.CacheManager" DynamicMasterPageFile="~masterurl/default.master" %>

<%@ Register Assembly="Telerik.Web.UI, Version=2013.1.220.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <style type="text/css">
        .alert-info {
            background-color: #D9EDF7;
            border-color: #BCE8F1;
            color: #3A87AD;
        }

        .alert-danger {
            background-color: #F2DEDE;
            border-color: #EED3D7;
            color: #B94A48;
        }

        .alert {
            border: 1px solid transparent;
            -ms-border-radius: 4px 4px 4px 4px;
            border-radius: 4px 4px 4px 4px;
            margin-bottom: 20px;
            padding: 15px;
        }

        .ButtonColumn {
            float: right;
            margin-right: 25px;
        }

        .rgHeader.ButtonColumnHeader { width: 75px; }

        .rgGroupHeader table td { border: medium none !important; }

        .rgGroupHeader p { padding: 0 !important; }

        .rgGroupHeader input { float: right; }
    </style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <asp:Panel ID="ErrorPanel" Visible="False" runat="server">
        <div class="alert alert-danger">
            <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
        </div>
    </asp:Panel>
    <asp:Panel ID="MainPanel" runat="server">
        <div class="alert alert-info">
            <div><strong>Server: </strong> <asp:Literal ID="ServerName" runat="server"></asp:Literal></div>
            <div><strong>Memory Allocation: </strong><asp:Literal ID="MemoryAllocation" runat="server"></asp:Literal></div>
        </div>
        <telerik:RadAjaxManager ID="RadAjaxManager" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="CacheGrid">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="CacheGrid"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadGrid ID="CacheGrid" runat=server 
                         AutoGenerateColumns="False" EnableViewState="False"
                         OnNeedDataSource="CacheGrid_OnNeedDataSource" OnDeleteCommand="CacheGrid_OnDeleteCommand" 
                         OnItemCreated="CacheGrid_OnItemCreated" OnItemDataBound="CacheGrid_OnItemDataBound">
            <MasterTableView Width="100%" Summary="Current Cache">
                <GroupByExpressions>
                    <telerik:GridGroupByExpression>
                        <SelectFields>
                            <telerik:GridGroupByField FieldAlias="Category" FieldName="Category"></telerik:GridGroupByField>
                        </SelectFields>
                        <GroupByFields>
                            <telerik:GridGroupByField FieldName="Category" SortOrder="Ascending"></telerik:GridGroupByField>
                        </GroupByFields>
                    </telerik:GridGroupByExpression>
                </GroupByExpressions>
                <Columns> 
                    <telerik:GridBoundColumn DataField="Key" HeaderText="Key" HeaderStyle-Width="25%" Resizable="True" /> 
                    <telerik:GridBoundColumn DataField="Value" HeaderText="Value" HeaderStyle-Width="25%" Resizable="True" /> 
                    <telerik:GridBoundColumn DataField="Size" HeaderText="Size (Bytes)" Resizable="True" /> 
                    <telerik:GridBoundColumn DataField="Category" HeaderText="Category" Resizable="True" Visible="False" /> 
                    <telerik:GridBoundColumn DataField="CreatedAt" HeaderText="Created At" HeaderStyle-Width="135px" Resizable="True" /> 
                    <telerik:GridBoundColumn DataField="LastReadAt" HeaderText="Last Read At" HeaderStyle-Width="135px" Resizable="True" /> 
                    <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="Delete" Text="Delete" UniqueName="DeleteColumn" Resizable="False">
                        <HeaderStyle CssClass="rgHeader ButtonColumnHeader"></HeaderStyle>
                        <ItemStyle CssClass="ButtonColumn" />
                    </telerik:GridButtonColumn>
                </Columns> 
            </MasterTableView>
            <ClientSettings ReorderColumnsOnClient="True" AllowDragToGroup="True" AllowColumnsReorder="True">
                <Selecting AllowRowSelect="True"></Selecting>
                <Resizing AllowRowResize="True" AllowColumnResize="True" EnableRealTimeResize="True" ResizeGridOnColumnResize="False"></Resizing>
            </ClientSettings>
        </telerik:RadGrid>
    </asp:Panel>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Cache Manager
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
    Cache Manager
</asp:Content>