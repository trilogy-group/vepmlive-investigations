<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.Integration.Add" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <link href="Add.css" rel="stylesheet" type="text/css" />

    <script language="javascript">

        function AddIntegration(module) {
            location.href = 'Connection.aspx?List=<%=Request["LIST"] %>&wizard=1&Module=' + module + "&ret=<%=Request["ret"]%>";
        }
    </script>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

<table align="left" id="integrations-table">
    <tr>
        <td>
            
            <%=Integrations %>
            <br />
            <TABLE width="100%">
            <TBODY>
                <TR>
                    <%if(Request["ret"] == "Manage"){ %>
                    <TD style="PADDING-BOTTOM: 3px;text-align:right;" class=ms-addnew><A id=A2 class=ms-addnew href="manage.aspx">Cancel</A> </TD>
                    <%}else{ %>
                    <TD style="PADDING-BOTTOM: 3px;text-align:right;" class=ms-addnew><A id=A1 class=ms-addnew href="integrationlist.aspx?LIST=<%=Request["LIST"] %>">Cancel</A> </TD>
                    <%} %>
                </TR>
            </TBODY>
        </TABLE>
        </td>
    </tr>
</table>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Add Integration
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Add Integration
</asp:Content>
