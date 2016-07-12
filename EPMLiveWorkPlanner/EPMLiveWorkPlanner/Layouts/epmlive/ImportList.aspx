<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportList.aspx.cs" Inherits="EPMLiveWorkPlanner.Layouts.epmlive.ImportList" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

        <link rel="stylesheet" href="modal/modal.css" type="text/css" /> 
<script type="text/javascript" src="modal/modal.js"></script>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    <asp:Panel ID="pnlList" runat="server">
        Select List: <asp:DropDownList ID="ddlList" runat="server"></asp:DropDownList><br /><br />
        <asp:Button ID="Button1" runat="server" Text="Next >" OnClick="btnList_Click"  />
    </asp:Panel>

    <asp:Panel ID="pnlCols" runat="server" Visible="false">
        
        Select WBS Column: <asp:DropDownList ID="ddlWBS" runat="server"><asp:ListItem Text="--Select Column--" Value=""></asp:ListItem></asp:DropDownList><br /><br />
        <asp:GridView ID="gvColumns" runat="server" OnRowDataBound="gvColumns_RowDataBound" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="List Field" DataField="ListField" />
                <asp:BoundField HeaderText="List Field" DataField="ListFieldTitle" ItemStyle-Width="200px" />
                <asp:TemplateField HeaderText="Planner Field">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlPlannerField" runat="server"><asp:ListItem Text="--Select Column--" Value=""></asp:ListItem></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br /><br />
        <asp:CheckBox ID="chkLinkedItems" runat="server" Checked ="true"/> Process list items linked to this planner item only.<br /><br />
        <asp:Button ID="btnImport" runat="server" Text="Import Now" OnClick="btnFinish_Click"  OnClientClick="sm('dlgImport', 300, 50);" />

        <div id="dlgImport" class="dialog">
            <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <img src="./images/loader-epmlive.GIF" style="vertical-align: middle;width:50px;"/>
                    <div style="line-height:40px;font-family:'Open Sans Regular';color:#666666;font-size:14px;" id="dlgNormalText">Import Starting...</div>
                </td>
            </tr>   
        </table>
        </div> 

        <script language="javascript">
            initmb();
        </script>

    </asp:Panel>


</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
List Import
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
List Import
</asp:Content>
