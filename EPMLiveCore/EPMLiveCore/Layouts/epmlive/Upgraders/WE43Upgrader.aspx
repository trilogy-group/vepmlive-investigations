<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WE43Upgrader.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.Upgraders.WE43Upgrader" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    
    <style>
    
        .button-green:hover 
{
background: #71BF31;
border: 1px solid #60BA16;
filter: none;
}

.button-green
{
font-weight:bold;
background: #6CC325 1px;
background: -webkit-linear-gradient(top, #9FD870 1px, #98DB62 1px, #6ABD3C 100%);
background: -o-linear-gradient(top, #9FD870 1px, #6CC325 1px, #6ABD3C 100%);
background: -ms-linear-gradient(top, #9FD870 1px, #6CC325 1px, #6ABD3C 100%);
background: -moz-linear-gradient(top, #9FD870 1px, #98DB62 1px, #6ABD3C 100%);
border: 1px solid #6ABD3D;
color: white;
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#9FD870', endColorstr='#6CC325',GradientType=0 );
}

.button 
{
font-size: 18px;
-moz-border-radius: 5px;
-webkit-border-radius: 5px;
-o-border-radius: 5px;
-ms-border-radius: 5px;
-khtml-border-radius: 5px;
display: inline-block;
line-height: 24px;
margin-bottom: 4px;
font-weight: normal;
text-shadow: none;
padding: 8px 10px 1px 10px;
white-space: nowrap;
cursor: pointer;
font-family: arial, sans-serif !important;
text-decoration: none !important;
text-align: center;
}

.button
{
color:#FFFFFF !important;
font-size:16px !important;
padding: 8px 15px;
}

.button-green-disabled
{
opacity:.5;
filter: alpha(opacity=50);
cursor:default;
background: #6CC325 1px;
background: -webkit-linear-gradient(top, #9FD870 1px, #98DB62 1px, #6ABD3C 100%);
background: -o-linear-gradient(top, #9FD870 1px, #6CC325 1px, #6ABD3C 100%);
background: -ms-linear-gradient(top, #9FD870 1px, #6CC325 1px, #6ABD3C 100%);
background: -moz-linear-gradient(top, #9FD870 1px, #98DB62 1px, #6ABD3C 100%);
border: 1px solid #6ABD3D;
color: white;
}


    </style>

    <script language="javascript">
        var installEnabled = false;

        function enableInstall() {

            if (document.getElementById("chkTerms").checked == true) {
                installEnabled = true;
                document.getElementById('installbutton').className = "button button-green";
            }
            else {
                installEnabled = false;
                document.getElementById('installbutton').className = "button button-green-disabled";
            }
        }

        function Install() {

            if (installEnabled) {
                var surl = "Upgrade.aspx?V=4.3.0";

                var options = { url: surl, width: 500, height: 250, showClose: true };

                SP.UI.ModalDialog.showModalDialog(options);

            }

        }
    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

<asp:Label ID="lblError" runat="server"></asp:Label>

<asp:Panel ID="pnlMain" runat="server">
    <div style="padding:20px">
    <%=sText %>
    <br /><br />

    <div class="controls" style="">
	        <label class="checkbox inline">
		        <input type="checkbox" id="chkTerms" value="option1" onclick="javascript:enableInstall()"></input><span class="wizText">I Agree.</span>
            </label>
        </div>

        <div style="padding-top:10px;">
                <a class="button button-green-disabled" href="javascript:void(0);" id="installbutton" onclick="Install();">Upgrade Now</a>
            </div>
    </div>
    </asp:Panel>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
4.3 Upgrader
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
4.3 Upgrader
</asp:Content>
