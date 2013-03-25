<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Optimizer.ascx.cs" Inherits="WorkEnginePPM.ControlTemplates.WorkEnginePPM.OptimizerControl" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
	Namespace="System.Web.UI" TagPrefix="asp" %>
<style type="text/css">
 
 
   
.style1
{
height: 20px;
}

.dhtmlx_wins_title 
{
top:-1px;
left:-1px;
}

div.dhtmlx_window_active 
{
box-shadow: 0 4px 23px 5px rgba(0, 0, 0, 0.2), 0 2px 6px rgba(0, 0, 0, 0.15);
}

.dhtmlx_wins_body_outer {
	border: none !important;
}

.dhtmlx_wins_body_inner {
margin-top:5px !important;
margin-left:10px !important;
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
-ms-filter:progid:DXImageTransform.Microsoft.Alpha(Opacity=50);
filter: alpha(opacity=50);					
cursor:default;
background: #6CC325 1px;
background: -webkit-linear-gradient(top, #9FD870 1px, #98DB62 1px, #6ABD3C 100%);
background: -o-linear-gradient(top, #9FD870 1px, #6CC325 1px, #6ABD3C 100%);
background: -ms-linear-gradient(top, #9FD870 1px, #6CC325 1px, #6ABD3C 100%);
background: -moz-linear-gradient(top, #9FD870 1px, #98DB62 1px, #6ABD3C 100%);
border: 1px solid #6ABD3D;
color: white;
color: #FFFFFF !important;
}

.disabledGreen:hover
{
opacity:.5;
-ms-filter:progid:DXImageTransform.Microsoft.Alpha(Opacity=50);
filter: alpha(opacity=50);					
cursor:default;
background: #6CC325 1px;
background: -webkit-linear-gradient(top, #9FD870 1px, #98DB62 1px, #6ABD3C 100%);
background: -o-linear-gradient(top, #9FD870 1px, #6CC325 1px, #6ABD3C 100%);
background: -ms-linear-gradient(top, #9FD870 1px, #6CC325 1px, #6ABD3C 100%);
background: -moz-linear-gradient(top, #9FD870 1px, #98DB62 1px, #6ABD3C 100%);
border: 1px solid #6ABD3D;
color: white;
color: #FFFFFF !important;
}

.disabledSilver
{
opacity:.5;
-ms-filter:progid:DXImageTransform.Microsoft.Alpha(Opacity=50);
filter: alpha(opacity=50);					
cursor:default;
background: #EAEAEA;
background: whiteSmoke 1px;
background: -webkit-linear-gradient(top, white 1px, #FFFFFF 1px, #F0F0F0 100%);
background: -o-linear-gradient(top, white 1px,#FFFFFF 1px, #F0F0F0 100%);
background: -ms-linear-gradient(top, white 1px, #FFFFFF 1px, #F0F0F0 100%);
background: -moz-linear-gradient(top, white 1px, #FFFFFF 1px, #F0F0F0 100%);
border: 1px solid gainsboro;
color: #535353 !important;

}

.disabledSilver:hover
{
opacity:.5;
-ms-filter:progid:DXImageTransform.Microsoft.Alpha(Opacity=50);
filter: alpha(opacity=50);
cursor:default;
background: #EAEAEA;
background: whiteSmoke 1px;
background: -webkit-linear-gradient(top, white 1px, #FFFFFF 1px, #F0F0F0 100%);
background: -o-linear-gradient(top, white 1px,#FFFFFF 1px, #F0F0F0 100%);
background: -ms-linear-gradient(top, white 1px, #FFFFFF 1px, #F0F0F0 100%);
background: -moz-linear-gradient(top, white 1px, #FFFFFF 1px, #F0F0F0 100%);
border: 1px solid gainsboro;
color: #535353 !important;
}

div.dhtmlx_window_active 
{
border:1px solid #CCCCCC;
}


.modalContent
{
font-family:Verdana;
font-size:12px;
padding-bottom:5px;
width:100%;
height: 100%;
padding-left:5px;
padding-right:5px;
color:#535353;
}



</style>


<!--[if gt IE 8]>

<style type="text/css">

.button-new 
{
border-radius: 0px;
}


</style>

<![endif]-->

<asp:ScriptManagerProxy ID="sm1" runat="server">
	<Services>
	</Services>
</asp:ScriptManagerProxy>

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xlayout/dhtmlxlayout.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xlayout/skins/dhtmlxlayout_dhx_skyblue.css" />
<script src="/_layouts/epmlive/dhtml/xlayout/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xlayout/dhtmlxlayout.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xlayout/dhtmlxcontainer.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xtab/dhtmlxtabbar.css"/>
<script src="/_layouts/epmlive/dhtml/xtab/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xtab/dhtmlxtabbar.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xtoolbar/skins/dhtmlxlayout_dhx_skyblue.css" />
<script src="/_layouts/epmlive/dhtml/xtoolbar/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xtoolbar/dhtmlxtoolbar.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/dhtmlxwindows.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/skins/dhtmlxwindows_dhx_epm.css" />
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxcontainer.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxwindows.js" type="text/javascript"></script>

<script src="/_layouts/epmlive/TreeGrid/GridE.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/ppm/ribbon/ribbon2.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/ppm/styles/jqueryui.css" />

<script src="/_layouts/ppm/ribbon/ribbon2.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/ppm/Optimizer.ascx.css" />
<script src="/_layouts/ppm/Optimizer.ascx.js?ver=<%=FileVersion%>" type="text/javascript"></script>
<script src="/_layouts/ppm/general.js" type="text/javascript"></script>
<script src="/_layouts/ppm/Optimizer.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="Styles/bootstrap.min.css" />
<div id="idViewTabDiv"></div>
<div id="idOptimizerTabDiv"></div>
<div id="<%=ClientID%>mainDiv">
	<div id="veil" style="display:none;"></div>
	<div id="<%=ClientID%>layoutDiv" style="position: relative; width: 100%; height: 650px; top: 0px; left: 0px; display:block"></div>
</div>
<div class="modalContent" id="idSaveViewDlg" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			View Name:
		</div>
		<div>
			<input id="id_SaveView_Name" type="text" value="view 1" style="width:10em; text-align:left;margin-bottom:13px;" />
		</div>
		<div>
			<input id="id_SaveView_Default" type="checkbox" />&nbsp;&nbsp;<font style="vertical-align:middle">Default View</font>
		</div>
		<div>
			<input id="id_SaveView_Personal" type="checkbox" />&nbsp;&nbsp;<font style="vertical-align:middle">Personal View</font>
		</div>
		<div style="width:200px;float:right;">
			<div class="button-container">
					<a href="javascript:dialogEvent('SaveView_OK');" class="button-new green" style="width:75px;">OK</a>
					<a href="javascript:dialogEvent('SaveView_Cancel');" class="button-new silver" style="width:75px;">Cancel</a>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idRenameViewDlg" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			View Name:
		</div>
		<div>
			<input id="id_RenameView_Name" type="text" value="view 1" style="width:10em; text-align:left;" />
		</div>
		<div style="width:200px;float:right;">
			<div class="button-container">
					<a href="javascript:dialogEvent('RenameView_OK');" class="button-new green" style="width:75px;">OK</a>
					<a href="javascript:dialogEvent('RenameView_Cancel');" class="button-new silver" style="width:75px;">Cancel</a>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idDeleteViewDlg" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			Are you sure you want to delete this view?
		</div>
		<div>
			<input id="id_DeleteView_Name" type="text" value="view 1" style="width:10em; text-align:left;" />
		</div>
		<div style="width:200px;float:right;">
			<div class="button-container">
					<a href="javascript:dialogEvent('DeleteView_OK');" class="button-new green" style="width:75px;">Delete</a>
					<a href="javascript:dialogEvent('DeleteView_Cancel');" class="button-new silver" style="width:75px;">Cancel</a>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idSaveStrat" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			Strategy Name:
		</div>
		<div>
			<input id="idSaveStratName" type="text" value="Strategy 1" style="width:10em; text-align:left;margin-bottom:13px;" />
		</div>
		<div  style="display:none;">
			<input id="idStratDefault" type="checkbox" />&nbsp;&nbsp;<font style="vertical-align:middle">Default Strategy</font>
		</div>
		<div>
			<input id="idStratPer" type="checkbox" />&nbsp;&nbsp;<font style="vertical-align:middle">Personal Strategy</font>
		</div>
		<div style="width:200px;float:right;">
			<div class="button-container">
					<a href="javascript:OptimizerEvent('SaveStratagy_OK');" class="button-new green" style="width:75px;">OK</a>
					<a href="javascript:OptimizerEvent('SaveStratagy_Cancel');" class="button-new silver" style="width:75px;">Cancel</a>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idRenameStratDlg" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			Strategy Name:
		</div>
		<div>
			<input id="idRenameStrat" type="text" value="Strategy 1" style="width:10em; text-align:left;" />
		</div>
		<div style="width:200px;float:right;">
			<div class="button-container">
					<a href="javascript:OptimizerEvent('RenameStratagy_OK');" class="button-new green" style="width:75px;">OK</a>
					<a href="javascript:OptimizerEvent('RenameStratagy_Cancel');" class="button-new silver" style="width:75px;">Cancel</a>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idEditRangeDlg" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div>
			<input id="idFromRange" type="text"  onkeyup='extractNumber(this,2,true, null);' onkeypress='return blockNonNumbers(this, event, true, true);' value="" style="width:10em; text-align:left;" /> : <input id="idToRange" type="text"  onkeyup='extractNumber(this,2,true, null);' onkeypress='return blockNonNumbers(this, event, true, true);' value="" style="width:10em; text-align:left;" />
		</div>
		<div style="width:200px;float:right;">
			<div class="button-container">
					<a href="javascript:OptimizerEvent('EditRange_OK');" class="button-new green" style="width:75px;">OK</a>
					<a href="javascript:OptimizerEvent('EditRange_Cancel');" class="button-new silver" style="width:75px;">Cancel</a>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idDeleteStratagy" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			Are you sure you want to delete this Strategy?
		</div>
		<div>
			<input id="idDelStrat" type="text" value="view 1" style="width:10em; text-align:left;" />
		</div>
		<div style="width:200px;float:right;">
			<div class="button-container">
					<a href="javascript:OptimizerEvent('DeleteStratagy_OK');" class="button-new green" style="width:75px;">Delete</a>
					<a href="javascript:OptimizerEvent('DeleteStratagy_Cancel');" class="button-new silver" style="width:75px;">Cancel</a>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idOptDlg" style="display:none;"></div>
<div id="gridDiv_1" style="width:100%;height:100%;overflow:auto;"></div>
<div id="gridDiv_Totals" style="width:100%;overflow:auto;"></div>
<div id="toolbarDataObjectDiv">
</div>
<div id="divLoading" style="z-index:998; display:none; padding-right: 20px; padding-left: 20px; vertical-align: middle; border: 1px solid #ebeef2; white-space: nowrap; position: absolute; background-color: rgb(255, 255, 255);">
	<img style="margin: 30px 10px; vertical-align: middle" title="Loading..." alt="Loading..." src="../images/PROGRESS-CIRCLE-24.GIF"/>
	<span style="text-align: center; margin: 30px 10px; white-space: nowrap; color: black; vertical-align: middle; overflow: hidden; font-family:Verdana; font-size:12px; color:#686868;">Loading...</span>
</div>
<div id="divSaving" style="z-index:998; display:none; padding-right: 20px; padding-left: 20px; vertical-align: middle; border: 1px solid #ebeef2; white-space: nowrap; position: absolute; background-color: rgb(255, 255, 255);">
	<img style="margin: 30px 10px; vertical-align: middle" title="Saving..." alt="Saving..." src="../images/PROGRESS-CIRCLE-24.GIF"/>
	<span style="text-align: center; margin: 30px 10px; white-space: nowrap; color: black; vertical-align: middle; overflow: hidden; font-family:Verdana; font-size:12px; color:#686868;">Saving...</span>
</div>
<script type="text/javascript">
    function dialogEvent(action) { optimizerco.externalEvent(action); }
    function deferCallbackAction(deferaction) { optimizerco.deferExternalEvent(deferaction); }
    function OptimizerEvent(action) { optimizerco.OptimizerEvent(action); }
	
	var params = {};
	params.ClientID = '<%=ClientID%>';
	params.URL = '<%=URL%>';
	params.TicketVal = '<%=TicketVal%>';
	params.Webservice = '<%=Webservice%>';
	params.RPEMode = '<%=RPEMode%>';
	optimizerco = new Optimizer('optimizerwp', params);

</script>
