<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prioritization.aspx.cs" Inherits="WorkEnginePPM.Prioritization" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Register src="Tools/ButtonBar.ascx" tagname="ButtonBarUserControl" tagprefix="bb1" %>


<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<script type="text/javascript" src="/_layouts/epmlive/TreeGrid/GridE.js"></script>
<script type="text/javascript" src="/_layouts/ppm/general.js"></script>
<link type="text/css" rel="stylesheet" href="Tools/ButtonBar.css" />
<link type="text/css" rel="stylesheet" href="/_layouts/epmlive/bootstrap/css/bootstrap.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/dhtmlxwindows.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/skins/dhtmlxwindows_dhx_epm.css" />
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxcontainer.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxwindows.js" type="text/javascript"></script>
<style type="text/css">



.dhtmlx_wins_body_outer {
    border: none !important;
}

select
{
font-family:Verdana;
font-size:12px;
color:#535353;
}

input
{
font-family:Verdana;
font-size:12px;
color:#535353;
}

.button-container 
{
overflow: hidden;
width:205px;
float:right;
margin-top:17px;
}

.button-container-3
{
overflow: hidden;
width:305px;
float:right;
margin-top:17px;
}

.button-containerVert
{
overflow: hidden;
}

.button-new.save 
{
float: left;
}

.button-new.cancel 
{
float: right;
}

.button-new 
{
font-size: 12px;
-moz-border-radius: 5px;
-webkit-border-radius: 5px;
-o-border-radius: 5px;
-ms-border-radius: 5px;
-khtml-border-radius: 5px;
border-radius: 5px;
display: inline-block;
line-height: 24px;
margin-bottom: 4px;
font-weight: normal;
text-shadow: none;
padding: 1px 10px 1px 10px;
white-space: nowrap;
cursor: pointer;
font-family: arial, sans-serif;
text-decoration:none !important;
text-align:center;

}

.button-new.green 
{
/*background: #6ABD3D;*/
background: #6CC325 1px;
background: -webkit-linear-gradient(top, #9FD870 1px, #98DB62 1px, #6ABD3C 100%);
background: -o-linear-gradient(top, #9FD870 1px, #6CC325 1px, #6ABD3C 100%);
background: -ms-linear-gradient(top, #9FD870 1px, #6CC325 1px, #6ABD3C 100%);
background: -moz-linear-gradient(top, #9FD870 1px, #98DB62 1px, #6ABD3C 100%);
border: 1px solid #6ABD3D;
color: white;
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#9FD870', endColorstr='#6CC325',GradientType=0 );
}

.button-new.silver 
{
background: #EAEAEA;
background: whiteSmoke 1px;
background: -webkit-linear-gradient(top, white 1px, #FFFFFF 1px, #F0F0F0 100%);
background: -o-linear-gradient(top, white 1px,#FFFFFF 1px, #F0F0F0 100%);
background: -ms-linear-gradient(top, white 1px, #FFFFFF 1px, #F0F0F0 100%);
background: -moz-linear-gradient(top, white 1px, #FFFFFF 1px, #F0F0F0 100%);
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#FFFFFF', endColorstr='#F0F0F0',GradientType=0 );
border: 1px solid gainsboro;
color: #535353;
}

.button-new.green:hover
{
background: #71BF31;
border: 1px solid #60BA16;
filter: none;
}

.button-new.silver:hover
{
background: #F0F0F0;
border: 1px solid #D8D8D8;
filter: none;
}

.disabledGreen
{
opacity:.5;
filter:alpha(opacity=50); /* For IE8 and earlier */
cursor:default;
background: #6CC325 1px;
background: -webkit-linear-gradient(top, #9FD870 1px, #98DB62 1px, #6ABD3C 100%);
background: -o-linear-gradient(top, #9FD870 1px, #6CC325 1px, #6ABD3C 100%);
background: -ms-linear-gradient(top, #9FD870 1px, #6CC325 1px, #6ABD3C 100%);
background: -moz-linear-gradient(top, #9FD870 1px, #98DB62 1px, #6ABD3C 100%);
border: 1px solid #6ABD3D;
color: white;
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#9FD870', endColorstr='#6CC325',GradientType=0 );
}

.disabledGreen:hover
{
opacity:.5;
filter:alpha(opacity=50); /* For IE8 and earlier */
cursor:default;
background: #6CC325 1px;
background: -webkit-linear-gradient(top, #9FD870 1px, #98DB62 1px, #6ABD3C 100%);
background: -o-linear-gradient(top, #9FD870 1px, #6CC325 1px, #6ABD3C 100%);
background: -ms-linear-gradient(top, #9FD870 1px, #6CC325 1px, #6ABD3C 100%);
background: -moz-linear-gradient(top, #9FD870 1px, #98DB62 1px, #6ABD3C 100%);
border: 1px solid #6ABD3D;
color: white;
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#9FD870', endColorstr='#6CC325',GradientType=0 );
}

.disabledSilver
{
opacity:.5;
filter:alpha(opacity=50); /* For IE8 and earlier */
cursor:default;
background: #EAEAEA;
background: whiteSmoke 1px;
background: -webkit-linear-gradient(top, white 1px, #FFFFFF 1px, #F0F0F0 100%);
background: -o-linear-gradient(top, white 1px,#FFFFFF 1px, #F0F0F0 100%);
background: -ms-linear-gradient(top, white 1px, #FFFFFF 1px, #F0F0F0 100%);
background: -moz-linear-gradient(top, white 1px, #FFFFFF 1px, #F0F0F0 100%);
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#FFFFFF', endColorstr='#F0F0F0',GradientType=0 );
border: 1px solid gainsboro;
color: #535353;

}

.disabledSilver:hover
{
opacity:.5;
filter:alpha(opacity=50); /* For IE8 and earlier */
cursor:default;
background: #EAEAEA;
background: whiteSmoke 1px;
background: -webkit-linear-gradient(top, white 1px, #FFFFFF 1px, #F0F0F0 100%);
background: -o-linear-gradient(top, white 1px,#FFFFFF 1px, #F0F0F0 100%);
background: -ms-linear-gradient(top, white 1px, #FFFFFF 1px, #F0F0F0 100%);
background: -moz-linear-gradient(top, white 1px, #FFFFFF 1px, #F0F0F0 100%);
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#FFFFFF', endColorstr='#F0F0F0',GradientType=0 );
border: 1px solid gainsboro;
color: #535353;
}

div.dhtmlx_window_active 
{
border:1px solid #CCCCCC;
}




.dhtmlx_wins_title {
    font-family: "Segoe UI Semilight", "Segoe UI", Segoe, Tahoma, Helvetica, Arial, sans-serif !important;
    font-size: 1.46em !important;
    font-weight: normal !important;
    color: #444 !important;
    background: white !important;
}


.modalContent
{
color: #444 !important;
font-family: "Segoe UI Semilight", "Segoe UI", Segoe, Tahoma, Helvetica, Arial, sans-serif !important;
font-size: 1em !important;
font-weight: normal !important;
padding-bottom:5px;
width:100%;
height: 100%;
padding-left:5px;
padding-right:5px;
border: none !important;
}




.modal-backdrop {
position: fixed;
top: 0;
right: 0;
bottom: 0;
left: 0;
z-index: 1040;
background-color: #CCC;
}

.modal-header h3 
{
font-family: 'Segoe UI Semilight', 'Segoe UI', Segoe, Tahoma, Helvetica, Arial, sans-serif !important;
font-size: 1.46em !important;
color: #444 !important;
font-weight: normal !important;
}

.modal-backdrop, .modal-backdrop.fade.in 
{
opacity: 0.5;
}

.modal 
{
outline:none !important;
border-radius: 0px !important;
top:60% !important;
}

.modal-body
{
font-family: 'Segoe UI Semilight', 'Segoe UI', Segoe, Tahoma, Helvetica, Arial, sans-serif !important;
font-size: 1em !important;
color: #444 !important;
font-weight: normal !important;
}

.modal-footer
{
background-color:#ffffff !important;
border:none !important;
}

.epmliveButton
{
    min-width: 6em;
    padding: 4px 10px;
    border: 1px solid #ABABAB;
    background-color: #FDFDFD;
    background-color: #FDFDFD;
    margin-left: 10px;
    font-family: "Segoe UI","Segoe",Tahoma,Helvetica,Arial,sans-serif;
    font-size: 11px;
    color: #444;
    height:30px;
    width:75px !important;
}

.epmliveButton:hover
{
border-color: #92C0E0;
background-color: #E6F2FA;
    cursor:pointer;
}

.epmliveButton:active
{
border-color: #2A8DD4;
background-color: #92C0E0;
    cursor:pointer;
}

</style>
<script type="text/javascript">
    DisplayDialog = function (left, top, width, height, title, idWindow, idAttachObj, bModal, bResize) {
        var wins = thiswins;
        if (wins != null) {
            var dlg = wins.createWindow(idWindow, left, top, width, height);
            if (dlg != null) {
                dlg.clearIcon();
                if (bResize == false) {
                    dlg.denyResize();
                    dlg.button("minmax1").hide();
                } else {
                    dlg.allowResize();
                    dlg.button("minmax1").show();
                }
                dlg.button("park").hide();
                dlg.button("close").show();
                dlg.setModal(bModal);
                dlg.center();
                dlg.setText(title);
                dlg.attachEvent("onClose", function (win) { dlg_OnCloseDelegate(idWindow); return true; });
                if (idAttachObj != null)
                    dlg.attachObject(idAttachObj);
                dlg.allowMove();

            }
            return dlg;
        }
        return null;
    };
    dhxWins_CloseDialog = function (idWindow) {
        var dlg = thiswins.window(idWindow);
        if (dlg != null) {
            dlg.setModal(false);
            dlg.hide();
            dlg.detachObject();
        }
    };
    function showModal() {
        //var mymodal = document.getElementById("myModal");
        //mymodal.style.display = "none";
        //mymodal.modal('hide');
        $('#myModal').modal();
    }
    function hideModal() {
        //var mymodal = document.getElementById("myModal");
        //mymodal.style.display = "none";
        //mymodal.modal('hide');
        $('#myModal').hide();
    }
    function hideModal2() {
        dhxWins_CloseDialog("winPostDlg");
    }
    function editcomp() {
        var sRowId;
        var sMode = "";
        sMode = "Update";
        sRowId = 1;

        var weburl = "Pri_ComponentsForm.aspx?id=" + sRowId + "&mode=" + sMode;

        var options = { url: weburl, width: 800, height: 600, showClose: false, dialogReturnValueCallback: mycallback };

        SP.UI.ModalDialog.showModalDialog(options);
        var mymodal = document.getElementById("myModal");
        mymodal.style.display = "block";
        mymodal.modal('show');
        $("#myModal").modal();
        showModal();
    }
//    function hideModal() {
//        var mymodal = document.getElementById("myModal");
//        //mymodal.style.display = "none";
//        mymodal.modal('hide');
//        //$('#myModal').modal('hide');
//    }
    function mycallback (dialogResult, returnValue)
    {
        //alert("mycallback");
    }

    function editform() {
        //alert("js Edit");
        var sRowId;
        var sMode = "";
        sMode = "Update";
        sRowId = 1;

        var weburl = "Pri_FormulasForm.aspx?id=" + sRowId + "&mode=" + sMode;

        var options = { url: weburl, width: 800, height: 600, showClose: false, dialogReturnValueCallback: mycallback };
        DisplayDialog(20, 30, 250, 150, "Modal header", "winPostDlg", "idMyModalDlg", true, false);
        //this.dhxWins_CloseDialog("winPostDlg");

        //SP.UI.ModalDialog.showModalDialog(options);
    }

    function onFormLoad() {
        Grids.OnAfterValueChanged = GridsOnAfterValueChanged;
        HandleButtons();
    }

    function GridsOnAfterValueChanged(grid, row, col, val) {
        window.setTimeout("HandleButtons()", 100);
    }

    function HandleButtons() {
        var bDirty = false;
        var grid = Grids[0];
        if (grid != null) {
            if ((grid.HasChanges() & (1 << 0)) != 0) {
                bDirty = true;
            }
        }

        if (bDirty)
            bb_SetButtonState("btnSave", false);
        else
            bb_SetButtonState("btnSave", true);

    }

    function buttonbar1_event(sControlId, sEvent, sButtonId) {
        //alert(sControlId + sEvent + sButtonId);
        switch (sButtonId) {
        case "btnSave":
            var s = Grids[0].GetXmlData("Data,AllCols");
            var sRequest = '<PageRequest function="Prioritization" context="Save"><![CDATA[' + s + ']]></PageRequest>';
            var jsonString = SendPageRequest(sRequest);
            var json = JSON_ConvertString(jsonString);
            if (json.Reply != null) {
                var error = json.Reply.Error;
                if (error != null && error != "") {
                    alert(error);
                    return;
                }
            }
            Grids[0].AcceptChanges();
            window.setTimeout("HandleButtons()", 100);
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
  

    if (document.addEventListener != null) window.addEventListener('load', onFormLoad, true); else window.attachEvent('onload', onFormLoad);
</script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<div class="modal" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display:none;">
  <div class="modal-header">
    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
    <h3 id="myModalLabel">Modal header</h3>
  </div>
  <div class="modal-body">
    <p>Here is the body...</p>
  </div>
  <div class="modal-footer">
    <input type="button" class="epmliveButton" value="OK" onclick="hideModal();"></input>
    <input type="button" class="epmliveButton" value="Cancel" onclick="hideModal();"></input>
  </div>
</div>
<div class="modalContent" id="idMyModalDlg" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
            <p>Here is the body...</p>
		</div>
		<div style="float:right;">
			<div class="button-container" >
                <input type="button" class="epmliveButton" value="OK" onclick="hideModal2();"></input>
                <input type="button" class="epmliveButton" value="Cancel" onclick="hideModal2();"></input>
			</div>
		</div>
	</div>
</div>
<asp:HiddenField ID="hiddenData" runat="server"></asp:HiddenField>
<asp:HiddenField ID="idGridLayout" runat="server" />
<asp:HiddenField ID="idGridData" runat="server" />
<bb1:ButtonBarUserControl id="buttonbar1" runat="server" />
<table width="100%">
    <tr id="idWorkspaceArea">
        <td style="width:100%; vertical-align:top;">
            <table width="100%">
                <tr>
                    <td style="width:100%; vertical-align:top;">
                    <div>
                        <asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                        <p class="descriptioncell">Choose the Business Factors, choose the Prioritization Scenario(s), and then set the weights</p>
                        <asp:Panel ID="pnlMain" runat="server" Visible="true">
                            <table width="100%" cellspacing="0">
                                
                                <tr>
                                    <td class="descriptioncell"> <b>Business Factors:</b></td>
                                </tr>                               
                                <tr>
                                    <td style="height:1px;" width="250" class="topcell"></td>
                                    <td style="height:1px;" class="topcell"></td>
                                </tr>
                                <tr>
                                    <td class="controlcell">                                       
                                        <asp:ListBox ID="lstComponents" runat="server" SelectionMode="Multiple" Height="120" Width="160" ></asp:ListBox>
                                        &nbsp&nbsp
                                        <input style="vertical-align:top" type="button" id="Button1" value="Edit" onclick="javascript:editcomp()" />
                                    </td>
                                </tr>
                                <tr style="height:30px">
                                    <td  class="descriptioncell" style="vertical-align:bottom">  <b>Prioritization Scenario(s):</b></td>
                                </tr>
                                <tr>
                                    <td class="controlcell">                                      
                                        <asp:ListBox ID="lstFormulas" runat="server" SelectionMode="Multiple" Height="120" Width="160"></asp:ListBox>
                                        &nbsp&nbsp
                                        <input style="vertical-align:top" type="button" id="Button2" value="Edit" onclick="javascript:editform()" />
                                    </td>
                                </tr>
                                <tr style="height:30px">
                                    <td  class="descriptioncell" style="vertical-align:bottom">  <b>Weights for each Scenario:</b></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    </td>
                </tr>
                <tr>
                    <td style="width:100%; vertical-align:top;">
                        <div id="gridlayoutDiv" style="width: 100%; ">
                            <treegrid debug='0' sync='1' layout_tag='<%=idGridLayout.ClientID%>' data_tag='<%=idGridData.ClientID%>' ></treegrid>
                       </div>
                    </td>
                 </tr>
            </table>
        </td>
    </tr>
</table>
<script type="text/javascript">
    function initializeMyJS() {
        $.getMyScript = function (url, callback, cache) {
            $.ajax({
                type: 'GET',
                url: url,
                success: callback,
                dataType: 'script',
                cache: cache
            });
        };
        $.getMyScript('/_layouts/epmlive/bootstrap/js/bootstrap.js', function () {}, true);
    }

    var thiswins = new dhtmlXWindows();
    thiswins.setImagePath("../epmlive/dhtml/windows/imgs/");
    thiswins.setSkin("dhx_web");
    ExecuteOrDelayUntilScriptLoaded(initializeMyJS, 'jquery.min.js');
</script></asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Prioritization
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Prioritization
</asp:Content>
