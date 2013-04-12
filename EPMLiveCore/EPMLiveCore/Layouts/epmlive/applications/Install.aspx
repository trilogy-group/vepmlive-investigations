<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Install.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.applications.Install" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ContentPlaceHolderID="PlaceHolderAdditionalPageHead" ID="Content5" runat="server">

    <link href="Applications.css" rel="stylesheet" type="text/css" />
    <script src="../DHTML/xgrid/dhtmlxcommon.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">


    <script language="javascript">

        dhtmlxAjax.post("proxy.aspx", "Action=StartInstall&AppID=<%=Request["AppId"]%>&CommId=<%=Request["CommId"]%>", StartInstallClose);

        function StartInstallClose(loader) 
        {
            var oResponse = eval("({" + loader.xmlDoc.responseText.trim() + "})");

            if(oResponse.Status == "Success")
            {
                setTimeout("CheckStatus()", 2000);   
            }
            else
            {
                document.getElementById("divError").style.display = "";
                document.getElementById("spnError").innerHTML = oResponse.Message;
            }
        }

        function CheckStatus()
        {
            dhtmlxAjax.post("proxy.aspx", "Action=CheckStatus&AppID=<%=Request["AppId"]%>", CheckStatusClose);
        }

        function CheckStatusClose(loader) 
        {
            var oResponse = eval("({" + loader.xmlDoc.responseText.trim() + "})");

            switch(oResponse.Status)
            {
                case "Install Failed":
                case "Installed":
                    document.getElementById("spnPercent").innerHTML = "100";
                    document.getElementById("pBar").style.width = "100%";
                    document.getElementById("divDone").style.display = "";
                    location.href = "InstallDone.aspx?AppId=<%=Request["AppId"]%>&CommId=<%=Request["CommId"]%>&isdlg=1";
                    break;
                default:
                    document.getElementById("spnPercent").innerHTML = oResponse.Percent;
                    document.getElementById("pBar").style.width = oResponse.Percent + "%";
                    setTimeout("CheckStatus()", 2000);
                    break;      
            };
        }
    </script>

    <div style="width:100%; text-align:center; height:100%">
        <%=ApplicationName %><br /><br />

        Installing (<span id="spnPercent">0</span>%)<br /><br />

        <div class="progress" style="width:300px; margin-left: auto; margin-right: auto;">  
            <div class="bar" id="pBar" style="width: 0%;">
            </div>
        </div>
        <br />
        <div id="divError" class="alert alert-error" style="width: 400px; display:none; margin-left: auto; margin-right: auto;">
            <strong>Error: </strong> <span id="spnError"></span>
        </div>

        <div id="divDone" class="alert alert-info" style="width: 400px; display:none; margin-left: auto; margin-right: auto;">
            <strong>Success: </strong>Installation is complete, processing results.
        </div>
    </div>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Application Installation
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Application Installation
</asp:Content>
