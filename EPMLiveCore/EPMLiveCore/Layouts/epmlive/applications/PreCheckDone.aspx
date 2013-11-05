<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreCheckDone.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.applications.PreCheckDone" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <link href="Applications.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/_layouts/epmlive/stylesheets/buttons.css" />

<script type="text/javascript">

    var installEnabled = false;

    function enableInstall() {

        if (document.getElementById("chkWarnings").checked == true && document.getElementById("chkTerms").checked == true) {
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
            location.href = "Install.aspx?AppId=<%=Request["AppId"]%>&CommId=<%=Request["CommId"]%>&isdlg=1";

    }

    function ReCheck() {
        location.href = "PreCheck.aspx?AppId=<%=Request["AppId"]%>&CommId=<%=Request["CommId"]%>&isdlg=1";

    }

    function BackToCommunity() {
        location.href = "<%=sWebUrl%>";

    }

    function expand()
    {
        var div = document.getElementById('detaildiv');

        if(div.style.display == "none")
           div.style.display = "";
        else
            div.style.display = "none"; 
    }

    function Terms()
    {
        var surl = "terms.aspx?isdlg=1";

        var options = { url: surl, width: 400, showClose: true};

        SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
    }

    try {
        $('body', window.parent.document).scrollTop(0);
    } catch (e) {
    }
</script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
        <div style="height:250px">
<div style="height:10px;"></div>
 
<h3 class="wizHeader">Installation Check Results: <span style="color:#376594;"><%=ApplicationName %></span></h3>

<HR style="COLOR: #cccccc">
<%=sbOutput.ToString()%>
<br />
<%if(maxError < 10){ %>

<div class="controls" style="">
	        <label class="checkbox inline">
		        <input type="checkbox" id="chkTerms" value="option1" onclick="javascript:enableInstall()"></input><span class="wizText">Accept <a href="#" onclick="Terms();">Terms & Conditions</a>.</span>
            </label>
        </div>

        <%if(maxError < 5){ %>
            <input type="checkbox" id="chkWarnings" value="option1" checked="checked" style="display:none;">
            <div style="padding-top:10px;">
                <a class="btn btn-success btn-large disabled" href="#" id="installbutton" onclick="Install();" style="color:#FFFFFF !important;">Install Application</a>
            </div>
        <%}else{ %>
        <div class="controls" style="">
	        <label class="checkbox inline">
		        <input type="checkbox" id="chkWarnings" value="option1" onclick="javascript:enableInstall()"></input><strong>Accept warnings and install application.</strong>
            </label>
        </div>

            <div style="padding-top:10px;">
                <a class="btn btn-success btn-large" href="javascript:void(0);" id="checkbutton" onclick="ReCheck();">Re-Run Install Check</a>
                &nbsp;&nbsp;
                <a class="btn btn-success btn-large disabled" href="javascript:void(0);" id="installbutton" onclick="Install();">Install Application</a>
            </div>

        <%} %>
    <%}else{ %>
        <div style="padding-top:10px;">
            <a class="btn btn-success btn-large" href="javascript:void(0);" id="A1" onclick="ReCheck();">Re-Run Install Check</a>
            &nbsp;&nbsp;
            <a class="btn btn-success btn-large disabled" href="javascript:void(0);" id="A2" onclick="BackToCommunity();">Return to Community</a>
        </div>
    <%} %>
    <br />
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
        </div>
    
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Application PreCheck Complete
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Application PreCheck Complete
</asp:Content>
