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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="precheck.aspx.cs" Inherits="EPMLiveCore.precheck" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	Application Installation PreCheck
</asp:Content>

<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	Application Installation PreCheck
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    
</asp:Content>

<asp:Content ContentPlaceHolderID="PlaceHolderAdditionalPageHead" ID="Content5" runat="server">

    <link href="Applications.css" rel="stylesheet" type="text/css" />

    <script src="../DHTML/xgrid/dhtmlxcommon.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">


    <script language="javascript">

        dhtmlxAjax.post("proxy.aspx", "Action=StartPreCheck&AppID=<%=Request["AppId"]%>&CommId=<%=Request["CommId"] %>", StartPreCheckClose);

        function StartPreCheckClose(loader) 
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
                case "PreCheck Failed":
                case "PreCheck Successful":
                    document.getElementById("spnPercent").innerHTML = "100";
                    document.getElementById("pBar").style.width = "100%";
                    document.getElementById("divDone").style.display = "";
                    location.href = "PreCheckDone.aspx?AppId=<%=Request["AppId"]%>&CommId=<%=Request["CommId"]%>&isdlg=1";
                    break;
                default:
                    document.getElementById("spnPercent").innerHTML = oResponse.Percent;
                    document.getElementById("pBar").style.width = oResponse.Percent + "%";
                    setTimeout("CheckStatus()", 2000);
                    break;      
            };
        }

        try {
            $('body', window.parent.document).scrollTop(0);
        } catch (e) {
        }
    </script>

    <div style="width:100%; text-align:center; height:200px">
        <%=ApplicationName %><br /><br />

        PreCheck Running (<span id="spnPercent">0</span>%)<br /><br />

        <div class="progress" style="width:300px; margin-left: auto; margin-right: auto;">  
            <div class="bar" id="pBar" style="width: 0%;">
            </div>
        </div>
        <br />
        <div id="divError" class="alert alert-error" style="width: 400px; display:none; margin-left: auto; margin-right: auto;">
            <strong>Error: </strong> <span id="spnError"></span>
        </div>

        <div id="divDone" class="alert alert-info" style="width: 400px; display:none; margin-left: auto; margin-right: auto;">
            <strong>Success: </strong>The Install Check is complete, processing results.
        </div>
    </div>
</asp:Content>
