<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register src="Tools/TGrid.ascx" tagname="TGridUserControl" tagprefix="tg1" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostCostValues_NAX.aspx.cs" Inherits="WorkEnginePPM.PostCostValues_NAX" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<script src="tools/jsfunctions.js" type="text/javascript"></script>
<script src="general.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="styles/form.css" />
<link rel="stylesheet" type="text/css" href="styles/dialognew.css" />
<link rel="stylesheet" type="text/css" href="tools/toolbar.css" />
<script src="tools/toolbar.js" type="text/javascript"></script>
<style type="text/css">
.ms-cui-tabBody {
    border-bottom: 0 !important;
}
BODY #s4-workspace {
    height: 100% !important;
}
html, body {
    width: 100%;
    height: 100%;
    margin: 0px;
    overflow: hidden;
}
</style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<div style="display: block;" >
    <asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
	<div style="margin-top:5px;margin-bottom:5px;padding-left:3px;padding-right:3px;">
		<div style="padding-bottom:3px;">
            <table width="100%" cellspacing="0">
                <tr>
                    <td style="height:1px;" width="250" class="topcell"></td>
                    <td style="height:1px;" class="topcell"></td>
                </tr>
                <tr>
                    <td width="250" class="descriptioncell">
                        Select a Cost Type
                    </td>
                    <td class="controlcell">
                        <asp:DropDownList ID="ddlCostTypes" OnChange="HandleEvent('ddlCostTypes_OnChange');" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="250" class="descriptioncell">Select Available Calendar</td>
                    <td class="controlcell">
                        <select id="idCalendar" style="width:206px;" >
                        </select>
                    </td>
                </tr>
                <tr>
                    <td width="250" class="descriptioncell"></td>
                    <td class="controlcell">
			            <input id="btnPost" type="button" class="epmliveButton" value="Post" onclick="HandleEvent('btnPost_onclick');"/>
                   </td>
                </tr>
            </table>
		</div>
    </div>
</div>
<script type="text/javascript">
    var OnLoad = function (event) {
        OnResize();
    };

    var OnResize = function (event) {
    };
    function HandleEvent(eventName)
    {
        switch (eventName) {
            case "ddlCostTypes_OnChange":
                var idCT = document.getElementById('<%=ddlCostTypes.ClientID%>');
                var sId = idCT.options[idCT.selectedIndex].value;
                if (sId != null && sId != "0") {
                    var sRequest = '<request function="PostCostValuesRequest" context="ReadCalendarsForCostType"><data><![CDATA[' + sId + ']]></data></request>';
                    var jsonString = SendRequest(sRequest);
                    var json = JSON_ConvertString(jsonString);
                    if (json.reply != null) {
                        if (jsf_alertError(json.reply.error) == true)
                            return false;
                        var idCalendar = document.getElementById('idCalendar');
                        idCalendar.options.length = 0;
                        var item = json.reply.calendars.item;
                        idCalendar.options[idCalendar.options.length] = new Option("", "-1");
                        for (var i = 0; i < item.length; i++) {
                            idCalendar.options[idCalendar.options.length] = new Option(item[i].name, item[i].id);
                        }
                    }
                }
                break;
            case "btnPost_onclick":
                var idCT = document.getElementById('<%=ddlCostTypes.ClientID%>');
                var sCTId = idCT.options[idCT.selectedIndex].value;
                var idCalendar = document.getElementById('idCalendar');
                var sCBId = idCalendar.options[idCalendar.selectedIndex].value;
                if (sCTId != null && sCTId != "0" && sCBId != null && sCBId != "-1") {
                    var sb = new StringBuilder();
                    sb.append('<request function="PostCostValuesRequest" context="PostCostValues">');
                    sb.append('<data');
                    sb.append(' CT_ID="' + sCTId + '"');
                    sb.append(' CB_ID="' + sCBId + '"');
                    sb.append('/>');
                    sb.append('</request>');
                    var sRequest = sb.toString();
                    var jsonString = SendRequest(sRequest);
                    var json = JSON_ConvertString(jsonString);
                    if (json.reply != null) {
                        if (jsf_alertError(json.reply.error) == true)
                            return false;
                    }
                    alert("Post to Job Queue Complete");
                }
                break;
        }
    };
    
    function SendRequest(sXML) {
         sURL = "./PostCostValues.ashx";
         return jsf_sendRequest(sURL, sXML);
    };
//    function BuildSaveCostCategoryInfo() {
//        var idMC = document.getElementById('<xxx%=ddlMajorCategoryLookups.ClientID%>');
//        var sMCValue = "";
//        if (idMC.selectedIndex > -1)
//            sMCValue = idMC.options[idMC.selectedIndex].value;
//        var idMCItem = document.getElementById('idMajorCategoryItem');
//        var sMCItemValue = "";
//        if (idMCItem.selectedIndex > -1)
//            sMCItemValue = idMCItem.options[idMCItem.selectedIndex].value;
//        var sb = new StringBuilder("");
//        sb.append('<data');
//        sb.append(' majorcategoryid="' + sMCValue + '"');
//        sb.append(' majorcategorydefault="' + sMCItemValue + '"');
//        sb.append('>');
//        //if ((tgrid1.grid.HasChanges() & (1 << 0)) != 0) {
//            sb.append('<![CDATA[' + tgrid1.GetXmlData() + ']]>');
//        //}
//        sb.append('</data>');
//        return sb.toString();
//    };

    if (document.addEventListener != null) { // e.g. Firefox
        window.addEventListener("load", OnLoad, true);
        window.addEventListener("resize", OnResize, true);
    }
    else { // e.g. IE
        window.attachEvent("onload", OnLoad);
        window.attachEvent("onresize", OnResize);
    }
</script>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Post Cost Values
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Post Cost Values
</asp:Content>
