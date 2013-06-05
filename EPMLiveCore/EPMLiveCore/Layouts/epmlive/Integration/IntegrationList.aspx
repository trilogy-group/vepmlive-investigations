<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IntegrationList.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.Integration.IntegrationList" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <script language="javascript">
        function DeleteIntegration(id) {
            if (confirm('Are you sure you want to delete that integration?')) {
                location.href = 'delete.aspx?intlistid=' + id + "&List=<%=Request["List"] %>";
            }
        }
    </script>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    <SharePoint:SPGridView runat="server"
	    ID="gvPlans"
	    AutoGenerateColumns="false"
	    width="600"
	    AllowSorting="True"
	    AllowPaging="False">
        <Columns>
	        <SharePoint:SPMenuField HeaderText="Integration Name" TextFields="intname" MenuTemplateId="PropertyNameListMenu" TokenNameAndValueFields="INTLISTID=intlistid" ></SharePoint:SPMenuField>
	        <SharePoint:SPBoundField DataField="priority" HeaderText="Priority"></SharePoint:SPBoundField>
            <SharePoint:SPBoundField DataField="active" HeaderText="Active"></SharePoint:SPBoundField>
	    </Columns>
	    <AlternatingRowStyle CssClass="ms-alternating" />
	</SharePoint:SPGridView>

    <br />
        <TABLE width="100%">
            <TBODY>
                <TR>
                    <TD style="PADDING-BOTTOM: 3px" class=ms-addnew><SPAN style="POSITION: relative; WIDTH: 10px; DISPLAY: inline-block; HEIGHT: 10px; OVERFLOW: hidden" class=s4-clust><IMG style="POSITION: absolute; TOP: -128px !important; LEFT: 0px !important" alt="" src="/_layouts/images/fgimg.png"></SPAN>&nbsp; <A id=idHomePageNewItem class=ms-addnew href="add.aspx?List=<%=Request["List"] %>">Add New Integration</A> </TD>
                </TR>
            </TBODY>
        </TABLE>
     </asp:Panel>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Integration Lists
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Integration Lists
</asp:Content>
