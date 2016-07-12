<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportExcelFinish.aspx.cs" Inherits="EPMLiveWorkPlanner.Layouts.epmlive.ImportExcelFinish" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<script src="dhtml/xlayout/dhtmlxcommon.js"></script> 
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    Importing Tasks. Please do not close this window until complete.

    <br /><br /><span id="spnPct">0</span>% Complete.<br /><br />
    <input type="button" value="Close" id="close" onclick="window.frameElement.commitPopup();" disabled="true"></button>

    <script language="javascript">
        function CheckStatus() {
            dhtmlxAjax.post("WorkPlannerAction.aspx", "Action=GetImportStatus&jobuid=<%=Request["jobuid"] %>", CheckStatusClose);
        }

        function CheckStatusClose(loader) {

            if (loader.xmlDoc.responseText != null) {
                var xmlDoc = loader.xmlDoc.responseText.trim();
                if (xmlDoc == "Unknown") {
                    alert("Status could not be determined");
                }
                else {
                    var data = xmlDoc.split('|');
                    document.getElementById("spnPct").innerHTML = data[1];
                    if(data[0] == "2")
                    {
                        if(data[2] != "No Errors")
                        {
                            alert("Errors: " + data[3]);
                        }

                        document.getElementById("close").disabled = false;
                    }
                    else
                        setTimeout("CheckStatus()", 2000);
                }

            }
            else
                alert("Response contains no XML");


        }

        CheckStatus();
    </script>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Excel Import
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Excel Import
</asp:Content>
