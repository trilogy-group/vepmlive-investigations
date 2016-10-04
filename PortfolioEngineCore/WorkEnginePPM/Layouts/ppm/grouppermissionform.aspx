<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grouppermissionform.aspx.cs" Inherits="WorkEnginePPM.Layouts.ppm2.grouppermissionform" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

<link rel="stylesheet" type="text/css" href="styles/form.css"/>
<script type="text/javascript" src="/_layouts/epmlive/TreeGrid/GridE.js"></script>
<script src="general.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="Styles/Dialog.css" />
<style type="text/css">
.ms-dialog .ms-bodyareacell {
    padding-left: 0 !important;
    padding-right: 0 !important;
}
.ms-cui-tabBody {
    border-bottom: 1px solid #898D92 !important;
}
</style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<asp:HiddenField ID="idGridLayout" runat="server" />
<asp:HiddenField ID="idGridData" runat="server" />
<div>
    <div style="display: none;">
        <asp:HiddenField ID="hiddenData" runat="server"></asp:HiddenField>
    </div>
    <asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
    <asp:Panel ID="pnlMain" runat="server" Visible="true">
    <table width="100%" cellspacing="0">
        <tr>
            <td style="height:1px;" width="250" class="topcell"></td>
            <td style="height:1px;" class="topcell"></td>
        </tr>
        <tr style="display:none;">
            <td width="250" class="descriptioncell">
                Field Id
            </td>
            <td class="controlcell">
                <asp:TextBox ID="txtId" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="250" class="descriptioncell">
                Group Name
            </td>
            <td class="controlcell">
                <asp:TextBox ID="txtName" runat="server" CssClass="input" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="250" class="descriptioncell">
                Group Description
            </td>
            <td class="controlcell">
                <asp:TextBox ID="txtDesc" runat="server" CssClass="input" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
             <td width="250" class="descriptioncell">
                Permissions
            </td>
       <td style="width:100%; vertical-align:top;">
            <div id="gridlayoutDiv" style="width: 100%; ">
                <treegrid debug='0' sync='1' layout_tag='<%=idGridLayout.ClientID%>' data_tag='<%=idGridData.ClientID%>' ></treegrid>
            </div>
        </td>
        </tr>
                  
    </table>
    </asp:Panel>
	<div style="float:right;">
		<div class="button-container" style="float:none;">
		    <asp:Button id="btnOK" text="OK" onclientclick="javascript:dialogEvent('btnOK');" onclick="btnOK_Click" class="button-new green" style="width:75px;" runat="server" />
		    <asp:Button id="btnDelete" text="Delete" onclientclick="javascript:dialogEvent('btnDelete');" onclick="btnDelete_Click" class="button-new green" style="width:75px;" runat="server" />
		    <asp:Button id="btnCancel" text="Cancel" onclientclick="javascript:dialogEvent('btnCancel');" class="button-new silver" style="width:75px;" runat="server" />
		</div>
	</div>
</div>
<script type="text/javascript">
    function onFormLoad() {
        Grids.OnAfterValueChanged = GridsOnAfterValueChanged;
        HandleButtons();
    }
    function dialogEvent(action) {
        switch (action) {
            case "btnOK":
                //__doPostBack('<%= btnOK.UniqueID %>', '');
                var groupname = document.getElementById("<%= txtName.ClientID %>").value;
                var groupdesc = document.getElementById("<%= txtDesc.ClientID %>").value;
                var groupid = document.getElementById("<%= txtId.ClientID %>").value;

                var s = '<PageInfo page="grouppermission" name="' + groupname + '" desc="' + groupdesc + '" id="' + groupid +'" >';
                s = s + Grids[0].GetXmlData("Data,AllCols") + '</PageInfo>';
                var sRequest = '<PageRequest function="Permissions" context="Save"><![CDATA[' + s + ']]></PageRequest>';
                var jsonString = SendPageRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.Reply != null) {
                    var error = json.Reply.Error;
                    if (error != null && error != "") {
                        alert(error);
                        return;
                    }
                }
                //Grids[0].AcceptChanges();
                //window.setTimeout("HandleButtons()", 100);

                window.setTimeout("SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, '');", 100);
                break;
            case "btnDelete":
                __doPostBack('<%= btnDelete.UniqueID %>', '');
                window.setTimeout("SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, '');", 100);
                break;
            case "btnCancel":
                window.setTimeout("SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, '');", 100);
                break;
        }
    }
    function SendPageRequest(sXML) {
        var sReplyXML = "";
        var sURL = "";
        try {
            sURL = "./PageRequest.ashx";
            var oXMLHttp = new XMLHttpRequest();
            oXMLHttp.open("POST", sURL, false);
            oXMLHttp.setRequestHeader("Content-Type", "text/xml; charset=utf-8");
            oXMLHttp.send(sXML);
            sReplyXML = oXMLHttp.responseText;
            if (oXMLHttp.status != 200) {
                alert("SendPageRequest : Invalid status reply.\n\nstatus=" + oXMLHttp.status.toString() + " : " + oXMLHttp.statusText + ";\n\nPlease report this to your System Administrator");
                alert("SendPageRequest : Extra Info.\n\nURL=" + sURL + ";\n\nresponseText=" + sReplyXML + ";\n\nPlease report this to your System Administrator");
            }
            else if (sReplyXML.length == 0) {
                alert("SendPageRequest : Invalid (zero length) reply from server.\n\nURL=" + sURL + ";\n\nstatus=" + oXMLHttp.status.toString() + " : " + oXMLHttp.statusText + ";\n\nPlease report this to your System Administrator");
            }
            else if (sReplyXML.substr(0, 16) == "Server Request Error" || sReplyXML.substr(4, 9) == "<!DOCTYPE") {
                sReplyXML = "<Reply><HRESULT>0</HRESULT><Error>Server Request Error</Error><STATUS>8</STATUS></Reply>";
            }
        }
        catch (e) {
            alert("SendPageRequest : Exception. \nType=" + e.name + "; \nMessage=" + e.Message + ";\nURL=" + sURL + ";\n\nPlease report this to your System Administrator");
            alert("SendPageRequest : status=" + oXMLHttp.status.toString() + " : " + oXMLHttp.statusText + ";\n\nPlease report this to your System Administrator");
        }
        return sReplyXML;
    }

   //if (document.addEventListener != null) window.addEventListener('load', onFormLoad, true); else window.attachEvent('onload', onFormLoad); 
</script>
<script type="text/javascript">
    function OnCostTypeSavedOK() {
        alert("OnCostTypeSavedOK");
        //var popup1 = window.parent.$find('btnShowModalPopup');
        //var btnOK = window.parent.document.getElementById(popup1.get_OkControlID());
        //btnOK.click();
    }
    function OnCostTypeClose() {
        alert("OnCostTypeClose");
        //var popup1 = window.parent.$find('btnShowModalPopup');
        //var btnClose = window.parent.document.getElementById(popup1.get_CancelControlID());
        //btnClose.click();
    }

</script>    
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
<%=DialogTitle %>
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
<%=DialogTitle%>
</asp:Content>

