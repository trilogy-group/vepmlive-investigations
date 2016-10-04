<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlannerAdmin.aspx.cs" Inherits="EPMLiveWorkPlanner.Layouts.epmlive.PlannerAdmin" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <script language="javascript">
        function DeletePlanner(id) {
            if (confirm('Are you sure you want to delete that planner?')) {
                location.href= 'planneradmin.aspx?delete=' + id;
            }
            
        }
    </script>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <asp:Panel ID="pnlAdmin" runat="server" Visible="false" Width="100%">
        Planner configuration is being configured at another site.<br /><br />
        <asp:HyperLink Text="Click Here" NavigateUrl="" runat="server" ID="hlAdmin"></asp:HyperLink> to go there now.
    </asp:Panel>

    <asp:Panel id="pnlMain" runat="server">
        <SharePoint:SPGridView runat="server"
	     ID="gvPlans"
	     AutoGenerateColumns="false"
	     width="600"
	     AllowSorting="True"
	     AllowPaging="True"
	     PageSize="100">
        <Columns>
	        <SharePoint:SPMenuField HeaderText="Plan Name" TextFields="planname" MenuTemplateId="PropertyNameListMenu" TokenNameAndValueFields="NAME=planinternalname" ></SharePoint:SPMenuField>
	        <SharePoint:SPBoundField DataField="projectlist" HeaderText="Source List"></SharePoint:SPBoundField>
	        <SharePoint:SPBoundField DataField="tasklist" HeaderText="Task List"></SharePoint:SPBoundField>
	     </Columns>
	     <AlternatingRowStyle CssClass="ms-alternating" />
	     </SharePoint:SPGridView>
         <br />
        <TABLE width="100%">
            <TBODY>
                <TR>
                    <TD style="PADDING-BOTTOM: 3px" class=ms-addnew><SPAN style="POSITION: relative; WIDTH: 10px; DISPLAY: inline-block; HEIGHT: 10px; OVERFLOW: hidden" class=s4-clust><IMG style="POSITION: absolute; TOP: -128px !important; LEFT: 0px !important" alt="" src="/_layouts/images/fgimg.png"></SPAN>&nbsp; <A id=idHomePageNewItem class=ms-addnew href="editplanner.aspx">Add New Planner</A> </TD>
                </TR>
                <TR>
                    <TD style="PADDING-BOTTOM: 3px" class=ms-addnew><A id=A1 class=ms-addnew href="<%=settingsurl %>">Back To Settings</A> </TD>
                </TR>
            </TBODY>
        </TABLE>
     </asp:Panel>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Planner Administration
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Planner Administration
</asp:Content>
