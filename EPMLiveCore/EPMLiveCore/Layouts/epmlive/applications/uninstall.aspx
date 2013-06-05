<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uninstall.aspx.cs" Inherits="EPMLiveCore.uninstall" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	Application Uninstallation
</asp:Content>

<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	Application Uninstallation
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    
</asp:Content>

<asp:Content ContentPlaceHolderID="PlaceHolderAdditionalPageHead" ID="Content5" runat="server">

    <link href="Applications.css" rel="stylesheet" type="text/css" />

    <script src="../DHTML/xgrid/dhtmlxcommon.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">


    <script language="javascript">

        dhtmlxAjax.post("proxy.aspx", "Action=StartUninstall&AppID=<%=Request["AppId"]%>", StartUninstallCheckClose);

        var jobuid;

        function StartUninstallCheckClose(loader) 
        {
            var oResponse = eval("({" + loader.xmlDoc.responseText.trim() + "})");

            if(oResponse.Status == "Success")
            {
                jobuid = oResponse.Message;

                setTimeout("CheckUStatus()", 2000);
            }
            else
            {
                document.getElementById("divError").style.display = "";
                document.getElementById("spnError").innerHTML = oResponse.Message;
            }
        }

        function CheckUStatus()
        {
            dhtmlxAjax.post("proxy.aspx", "Action=CheckUStatus&jobuid=" + jobuid, CheckStatusClose);
        }

        function CheckStatusClose(loader) 
        {
            var oResponse = eval("({" + loader.xmlDoc.responseText.trim() + "})");

            switch(oResponse.Status)
            {
                case "2":
                    document.getElementById("spnPercent").innerHTML = "100";
                    document.getElementById("pBar").style.width = "100%";
                    document.getElementById("divDone").style.display = "";
                    location.href = "UninstallDone.aspx?appid=<%=extapp%>&jobuid=" + jobuid + "&isdlg=1";
                    break;
                default:
                    document.getElementById("spnPercent").innerHTML = oResponse.Percent;
                    document.getElementById("pBar").style.width = oResponse.Percent + "%";
                    setTimeout("CheckUStatus()", 2000);
                    break;      
            };
        }
    </script>

    <div style="width:100%; text-align:center; height:100%">
        <%=ApplicationName %><br /><br />

        Uninstalling (<span id="spnPercent">0</span>%)<br /><br />

        <div class="progress" style="width:300px; margin-left: auto; margin-right: auto;">  
            <div class="bar" id="pBar" style="width: 0%;">
            </div>
        </div>
        <br />
        <div id="divError" class="alert alert-error" style="width: 400px; display:none; margin-left: auto; margin-right: auto;">
            <strong>Error: </strong> <span id="spnError"></span>
        </div>

        <div id="divDone" class="alert alert-info" style="width: 400px; display:none; margin-left: auto; margin-right: auto;">
            <strong>Success: </strong>The Uninstall is complete, processing results.
        </div>
    </div>
</asp:Content>
