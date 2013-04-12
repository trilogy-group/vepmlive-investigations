<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upgrade.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.Upgraders.Upgrade" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <link href="/_layouts/epmlive/applications/Applications.css" rel="stylesheet" type="text/css" />

    <script src="../DHTML/xgrid/dhtmlxcommon.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

<asp:Label ID="lblError" runat="server"></asp:Label>

<asp:Panel ID="pnlMain" runat="server">

        <script language="javascript">

        dhtmlxAjax.post("proxy.aspx", "Action=Start&V=<%=Request["V"]%>", StartClose);

        var jobuid = "";

        function StartClose(loader) 
        {

            var oResponse = eval("({" + loader.xmlDoc.responseText.trim() + "})");

            if(oResponse.Status == "Success")
            {
                jobuid = oResponse.jobuid;
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
            dhtmlxAjax.post("proxy.aspx", "Action=CheckStatus&V=<%=Request["V"]%>&jobuid=" + jobuid, CheckStatusClose);
        }

        function CheckStatusClose(loader) 
        {

            var oResponse = eval("({" + loader.xmlDoc.responseText.trim() + "})");
            
            switch(oResponse.Status)
            {
                case "Error":
                    document.getElementById("divError").style.display = "";
                    document.getElementById("spnError").innerHTML = oResponse.Message;
                    break;
                case "2":
                    document.getElementById("spnPercent").innerHTML = "100";
                    document.getElementById("pBar").style.width = "100%";
                    document.getElementById("divDone").style.display = "";
                    parent.location.href = "UpgradeDone.aspx?V=<%=Request["V"]%>";
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
        <h3>Installing Update. Please Wait.</h3>

        Progress: <span id="spnPercent">0</span>%<br /><br />

        <div class="progress" style="width:300px; margin-left: auto; margin-right: auto;">  
            <div class="bar" id="pBar" style="width: 0%;">
            </div>
        </div>
        <br />
        <div id="divError" class="alert alert-error" style="width: 400px; display:none; margin-left: auto; margin-right: auto;">
            <strong>Error: </strong> <span id="spnError"></span>
        </div>

        <div id="divDone" class="alert alert-info" style="width: 400px; display:none; margin-left: auto; margin-right: auto;">
            <strong>Upgrade Complete: </strong>The Upgrade is complete, processing results.
        </div>
    </div>
</asp:Panel>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Upgrade
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Upgrade
</asp:Content>
