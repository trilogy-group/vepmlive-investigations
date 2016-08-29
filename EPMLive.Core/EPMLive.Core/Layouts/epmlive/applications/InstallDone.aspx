<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstallDone.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.applications.InstallDone" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<link href="Applications.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/stylesheets/buttons.css" />

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
        if (installEnabled)
            location.href = "Install.aspx?AppId=<%=Request["AppId"]%>&isdlg=1";

    }

    function ReCheck() {

        location.href = "PreCheck.aspx?AppId=<%=Request["AppId"]%>&isdlg=1";

    }

    function expand()
    {
        var div = document.getElementById('detaildiv');

        if(div.style.display == "none")
           div.style.display = "";
        else
            div.style.display = "none"; 
    }

    function GoToStore() {
        parent.location.href = "http://market.epmlive.com/?Source=<%=sFullWebUrl %>";
    }

    function GoToApp() {
        parent.location.href = "../ChangeApp.aspx?appid=<%=newAppId %>";
    }
    
    try {
        $('body', window.parent.document).scrollTop(0);
    } catch (e) {
    }

</script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

<div style="height:10px;"></div>
<h3 class="wizHeader">Installation Results: <span style="color:#376594;"><%=ApplicationName %></span></h3>

<HR style="COLOR: #cccccc">
<%=sbOutput.ToString()%>
<br />
<a class="btn btn-success btn-large" href="javascript:void(0);" id="installbutton2" onclick="GoToApp();" style="color:#FFFFFF !important;">Close</a>&nbsp;
    <a class="btn btn-success btn-large" href="javascript:void(0);" id="A1" onclick="GoToStore();" style="color:#FFFFFF !important;">Install Another App</a>
<br /><br />
    <a href="#" onclick="Javascript:expand()">Show Details</a><br /><br />
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
Application Installation
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Application Installation
</asp:Content>
