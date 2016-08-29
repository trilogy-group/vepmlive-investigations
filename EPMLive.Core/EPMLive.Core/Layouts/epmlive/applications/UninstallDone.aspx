<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UninstallDone.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.applications.UninstallDone" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <link href="Applications.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">

    var installEnabled = false;

    function enableInstall(id) {

        if (document.getElementById(id).checked == true) {
            installEnabled = true;
            document.getElementById('installbutton').className = "btn btn-success btn-large";
        }
        else {
            installEnabled = false;
            document.getElementById('installbutton').className = "btn btn-success btn-large disabled";
        }
    }

    function Install() {

        if(installEnabled)
            location.href = "UnInstall.aspx?AppId=<%=Request["AppId"]%>&isdlg=1";

    }

    function ReCheck() {

        location.href = "UninstallCheck.aspx?AppId=<%=Request["AppId"]%>&isdlg=1";

    }
    function expand()
    {
        var div = document.getElementById('detaildiv');

        if(div.style.display == "none")
           div.style.display = "";
        else
            div.style.display = "none"; 
    }
</script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

<div style="height:15px;"></div>
 
<h3>Uninstallation Results: <strong style="color:#376594;"><%=ApplicationName %></strong></h3>

<HR style="COLOR: #cccccc">
<%=sbOutput.ToString()%>

<div style="padding-top:10px;">
    <a class="btn btn-success btn-large" href="#" id="A1" onclick="window.frameElement.commitPopup();">Close</a>
</div>
<br />
    <a href="#" onclick="Javascript:expand()">Show Details</a><br />
    <div id="detaildiv" style="display:none">
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="GridView1_RowDataBound" CellPadding="6">
        <Columns>
            <asp:BoundField DataField="Status" HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top" HtmlEncode="false" ItemStyle-Width="80" ItemStyle-Wrap="false" ItemStyle-CssClass="itemtd"/>
            <asp:BoundField DataField="Message" HeaderText="Feature" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top" HtmlEncode="false" ItemStyle-Wrap="false"/>
            <asp:BoundField DataField="Detail" HeaderText="Message" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top" HtmlEncode="false" ItemStyle-Width="100%"/>
        </Columns>
        <RowStyle BackColor="White" Font-Names="Helvetica Neue, Helvetica, Arial, sans-serif" Font-Size="13px" BorderStyle="None" ForeColor="#333333" CssClass="itemidborder" />
        <HeaderStyle Font-Bold="True" ForeColor="#333333" HorizontalAlign="Left" Font-Size="13px"  CssClass="itemidborder" Font-Names="Helvetica Neue, Helvetica, Arial, sans-serif"/>
    </asp:GridView>
    </div>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Application Uninstall Complete
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Application Uninstall Complete
</asp:Content>
