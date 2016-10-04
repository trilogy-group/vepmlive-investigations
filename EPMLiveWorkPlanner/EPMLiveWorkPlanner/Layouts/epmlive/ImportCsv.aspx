<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportCsv.aspx.cs" Inherits="EPMLiveWorkPlanner.Layouts.epmlive.ImportCsv" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <link rel="stylesheet" href="modal/modal.css" type="text/css" /> 
<script type="text/javascript" src="modal/modal.js"></script>

<script src="dhtml/xlayout/dhtmlxcommon.js"></script> 

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">


<asp:HiddenField ID="hdnFilename" runat="server" />

    <asp:Panel ID="pnlUpload" runat="server">
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        Select a file you would like to upload:<br />
        <asp:FileUpload ID="FileUpload1" runat="server" Width="400px"  /><br /><br />

        Seperator: 
        
        <asp:DropDownList ID="ddlSep" runat="server">
            <asp:ListItem Text="Comma" Value="CSV"></asp:ListItem>
            <asp:ListItem Text="Tab" Value="TSV"></asp:ListItem>
        </asp:DropDownList>

        <br /><br />

        <asp:Button ID="btnUpload" runat="server" Text="Upload File" OnClick="btnUpload_Click" OnClientClick="sm('dlgUploading', 150, 50);" />

        <div id="dlgUploading" class="dialog">
            <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <img src="./images/loader-epmlive.GIF" style="vertical-align: middle;width:50px;"/>
                    <div style="line-height:40px;font-family:'Open Sans Regular';color:#666666;font-size:14px;" id="dlgNormalText">Uploading File...</div>
                </td>
            </tr>   
        </table>
        </div> 
        <script language="javascript">
            initmb();
        </script>
    </asp:Panel>

    <asp:Panel ID="pnlColumns" runat="server" Visible="false">
        <script language="javascript">
            function CheckEXTID() {
                var uidDDL = document.getElementById("<%=ddlUID.ClientID %>");
                var uidVal = uidDDL.options[uidDDL.selectedIndex].value;
                var dupcheck = document.getElementById("<%=chkNoDuplicates.ClientID %>");

                if (uidVal == "") {
                    dupcheck.checked = false;
                    dupcheck.disabled = true;
                }
                else {
                    dupcheck.disabled = false;
                }
            }
        </script>
        Select Unique ID Column: <asp:DropDownList ID="ddlUID" runat="server"><asp:ListItem Text="--Select Column--" Value=""></asp:ListItem></asp:DropDownList><br /><br />
        Select WBS Column: <asp:DropDownList ID="ddlWBS" runat="server"><asp:ListItem Text="--Select Column--" Value=""></asp:ListItem></asp:DropDownList><br /><br />
        <asp:GridView ID="gvColumns" runat="server" OnRowDataBound="gvColumns_RowDataBound" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Import Field" DataField="ImportField" ItemStyle-Width="200px" />
                <asp:TemplateField HeaderText="Planner Field">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlPlannerField" runat="server"><asp:ListItem Text="--Select Column--" Value=""></asp:ListItem></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br /><br />
        <asp:CheckBox ID="chkNoDuplicates" runat="server" /> Do not process duplicates<br /><br />
        <asp:Button ID="btnImport" runat="server" Text="Import Now" OnClick="btnFinish_Click"  OnClientClick="sm('dlgImport', 300, 50);" />

        <div id="dlgImport" class="dialog">
            <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <img src="./images/loader-epmlive.GIF" style="vertical-align: middle;width:50px;"/>
                    <div style="line-height:40px;font-family:'Open Sans Regular';color:#666666;font-size:14px;" id="dlgNormalText">Starting Import...</div>
                </td>
            </tr>   
        </table>
        </div> 

        <script language="javascript">
            CheckEXTID();
            initmb();
        </script>
    </asp:Panel>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Excel Import
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
    Excel Import
</asp:Content>
