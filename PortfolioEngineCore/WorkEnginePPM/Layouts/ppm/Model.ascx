<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Model.ascx.cs" Inherits="WorkEnginePPM.ControlTemplates.WorkEnginePPM.ModelControl" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:ScriptManagerProxy ID="sm1" runat="server">
    <Services>
    </Services>
    

</asp:ScriptManagerProxy>
<link rel="stylesheet" type="text/css" href="Styles/DialogNew.css" />

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xlayout/dhtmlxlayout.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xlayout/skins/dhtmlxlayout_dhx_skyblue.css" />
<script src="/_layouts/epmlive/dhtml/xlayout/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xlayout/dhtmlxlayout.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xlayout/dhtmlxcontainer.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xtab/dhtmlxtabbar.css"/>
<script src="/_layouts/epmlive/dhtml/xtab/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xtab/dhtmlxtabbar.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xtoolbar/skins/dhtmlxtoolbar_dhx_skyblue.css" />
<script src="/_layouts/epmlive/dhtml/xtoolbar/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xtoolbar/dhtmlxtoolbar.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/dhtmlxwindows.css" />
<%--<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/skins/dhtmlxwindows_dhx_epm.css" />--%>
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/skins/dhtmlxwindows_dhx_admin.css" />

<script src="/_layouts/epmlive/dhtml/windows/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxcontainer.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxwindows.js" type="text/javascript"></script>
<script src="/_layouts/ppm/tools/jsfunctions.js" type="text/javascript"></script>

<script src="/_layouts/epmlive/TreeGrid/GridE.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="/_layouts/ppm/Model.ascx.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/ppm/ribbon/ribbon2.css" />
<script src="/_layouts/ppm/ribbon/ribbon2.js" type="text/javascript"></script>

<script src="/_layouts/ppm/model.ascx.js" type="text/javascript"></script>
<script src="/_layouts/ppm/general.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="Styles/bootstrap.min.css" />


<style type="text/css">
    html, body {
        width: 100%;
        height: 100%;
        margin: 0px;
        overflow: hidden;
    }
    .modalContent {
        margin-top: 0px !important;
    }
</style>


<div id="idRibbonDiv"></div>
<div id="idViewTabDiv"></div>
<div id="idBottomRibbonDiv"></div>
<div id="divLoading" style="z-index:998; display:none; padding-right: 20px; padding-left: 20px; vertical-align: middle; border: 1px solid #ebeef2; white-space: nowrap; position: absolute; background-color: rgb(255, 255, 255);">
    <img style="margin: 30px 10px; vertical-align: middle" title="Loading..." alt="Loading..." src="../images/PROGRESS-CIRCLE-24.GIF"/>
    <span style="text-align: center; margin: 30px 10px; white-space: nowrap; color: black; vertical-align: middle; overflow: hidden; font-family:Verdana; font-size:12px; color:#686868;">Loading...</span>
</div>
<div id="divSaving" style="z-index:998; display:none; padding-right: 20px; padding-left: 20px; vertical-align: middle; border: 1px solid #ebeef2; white-space: nowrap; position: absolute; background-color: rgb(255, 255, 255);">
    <img style="margin: 30px 10px; vertical-align: middle" title="Saving..." alt="Saving..." src="../images/PROGRESS-CIRCLE-24.GIF"/>
    <span style="text-align: center; margin: 30px 10px; white-space: nowrap; color: black; vertical-align: middle; overflow: hidden; font-family:Verdana; font-size:12px; color:#686868;">Saving...</span>
</div>
<div id="<%=ClientID%>mainDiv">
<div id="veil" style="display:none;"></div>
<div id="<%=ClientID%>layoutDiv" 
        style="position: relative; width: 100%; height: 650px; top: 0px; left: 0px; display:block"></div>
</div>
<div class="modalContent" id="idSelectPIDiv" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
 		<div id="idSelPIDiv" style="border:2px solid #ccc; width:300px; height: 150px; overflow-y: scroll; overflow-x:hidden;">
		</div>        
		<div class="button-container">
            	<input id="A1" type="button" onclick="javascript: dialogEvent('Select_PI');" class="epmliveButton" value="Display"/>
            	<input type="button" onclick="javascript: dialogEvent('Dont_Select_PI');" class="epmliveButton" value="Cancel"/>
		</div>
	</div>
</div>
<div id="idMVDlgObj" class="modalContent" style="display:none;">
    <br />
    <table width="100%" cellspacing="0">
        <tr>
            <td width="150"  >
                Select the Model :
            </td>
            <td  >
                <select id="idModelList" name="D1" onchange="SelectModel_Change();">
                </select>
            </td>
        </tr>
        <tr><td/><td/></tr>
        <tr>
            <td width="150" >
                Select Version(s) :
            </td>
            <td >
                <select id="idVersionList" multiple name="D2">
                </select>
            </td>
        </tr>
    </table>
    <div class="button-container">
        <input type="button" onclick="javascript: SelectModel_OKOnClick(1);" class="epmliveButton" value="OK"/>
        <input type="button" onclick="javascript: SelectModel_OKOnClick(0);" class="epmliveButton" value="Cancel"/>
    </div>
</div>
<div id="idSortnGroupDlgObj" class="modalContent" style="display:none;" >
        <br />
    <table width="100%" cellspacing="0" >
        <tr>
             <td align="right">Sort By:</td>
             <td  >
                <select id="sng1" name="sng1" onchange="ChangeSortandGroup();">
                </select>
            </td>
            <td>
                <input id="SnGDir1" type="checkbox" name="SnGDir1" onclick="ChangeSortandGroup();" />Decending
            </td>
            <td>
                <input id="SnGGrp1" type="checkbox" name="SnGGrp1" onclick="ChangeSortandGroup();" />Group
            </td>
        </tr>
        <tr> 
             <td align="right">Then By:</td>
             <td  >
                <select id="sng2" name="sng2" onchange="ChangeSortandGroup();">
                </select>
            </td>
            <td>
                <input id="SnGDir2" type="checkbox" name="SnGDir2" onclick="ChangeSortandGroup();" />Decending
            </td>
            <td>
                <input id="SnGGrp2" type="checkbox" name="SnGDir2" onclick="ChangeSortandGroup();" />Group
            </td>
        </tr>
        <tr>
            <td align="right">Then By:</td>
            <td  >
                <select id="sng3" name="sng3" onchange="ChangeSortandGroup();">
                </select>
            </td>
            <td>
                <input id="SnGDir3" type="checkbox" name="SnGDir3" onclick="ChangeSortandGroup();" />Decending
            </td>
            <td>
                <input id="SnGGrp3" type="checkbox" name="SnGGrp3" onclick="ChangeSortandGroup();" />Group
            </td>
        </tr>
        <tr><td /></tr>
     </table>
    <table>
    <tr>
    <td align="right">Show To Level:</td>
        <td>
        <select id="idSelShowToLevel" name="showtolevel" onchange="ChangeSortandGroup();"></select>
        </td>
    </tr>
    </table>
    <table>
    <tr>
    <td align="right">Select which grid to sort:</td>
    <td> <input id="rbDet" type="radio" name="dg" checked onclick="flashSnGUI();" />Details (Top Grid)</td>
    </tr>
    <tr>
    <td></td>
    <td> <input id="rbTot" type="radio" name="dg" onclick="flashSnGUI();" />Totals (Bottom Grid)</td>
    </tr>
    <tr><td /></tr>
    </table>
    
    <div class="threebutton-container">
                <input type="button" onclick="javascript: SelectSnG_OKOnClick(2);" class="epmliveButton" value="Clear"/>
                <input type="button" onclick="javascript: SelectSnG_OKOnClick(1);" class="epmliveButton" value="OK"/>
                <input type="button" onclick="javascript: SelectSnG_OKOnClick(0);" class="epmliveButton" value="Cancel"/>
    </div>
</div>
<div id="idFilterDlgObj" class="modalContent" style="display:none;">
    <br />
    <table id="FilterGridTable" width="100%"  cellspacing="0">
         <tr >
            <td>
               <div id="FilterDiv" style="height:350px;"></div>
             </td>
        </tr>
        <tr><td>   </td></tr>
     </table>
     <div class="button-container">
        <input type="button" onclick="javascript: SelectFilter_OKOnClick(1);" class="epmliveButton" value="OK"/>
        <input type="button" onclick="javascript: SelectFilter_OKOnClick(0);" class="epmliveButton" value="Clear"/>
     </div>
</div>
<div id="idCTCmpDlgObj" class="modalContent" style="display:none;">
    <br />
    <table id="idCTCmpGridTable" width="100%"  cellspacing="0">
         <tr >
            <td>
               <div id="CTCmpDiv" style="height:200px;"></div>
             </td>
        </tr>
        <tr><td>   </td></tr>
     </table>
    <div class="button-container">
        <input type="button" onclick="javascript: SelectCostTypeCmp_OKOnClick(1);" class="epmliveButton" value="OK"/>
        <input type="button" onclick="javascript: SelectCostTypeCmp_OKOnClick(0);" class="epmliveButton" value="Cancel"/>
    </div>
</div>
<div id="idTotalsDlgObj" class="modalContent" style="display:none;">
    <br />
    <table id="TotalsGridTable" width="100%"  cellspacing="0">
         <tr >
            <td>
               <div id="TotalDiv" style="height:300px;"></div>
             </td>
        </tr>
        <tr><td>   </td></tr>
     </table>
     <div class="button-container">
        <input type="button" onclick="javascript: SelectTotals_OKOnClick(1);" class="epmliveButton" value="OK"/>
        <input type="button" onclick="javascript: SelectTotals_OKOnClick(0);" class="epmliveButton" value="Cancel"/>
     </div>
 </div>
<div id="idSaveVersionOrApplyTargetDlgObj" class="modalContent" style="display:none;">
    <br />
    <table id="SVATTable" width="100%"  cellspacing="0">
         <tr>
             <td  >
                <select id="idSaveorApply" name="SoA1" style="width:100%;">
                </select>
           </td>
        </tr>
        <tr><td><br /></td></tr>
     </table>
     <div id="idCopyNameDiv"style="display:none;">
       <table>
           <tr>
               <td>New Name:</td>
               <td><input id="idcopynametext" type="text" style="width:20em;"  /></td>
           </tr>
           <tr >
            <td>New Description:</td>
           <td>
             <input id="idcopydesctext" type="text" style="width:30em;" />
            </td>
         </tr>
       </table>
     <br/>
     </div>
     <div class="button-container">
        <input type="button" onclick="javascript: SelectSaveOrApply_OKOnClick(1);" class="epmliveButton" value="OK"/>
        <input type="button" onclick="javascript: SelectSaveOrApply_OKOnClick(0);" class="epmliveButton" value="Cancel"/>
     </div>
</div>
<div id="idCopyVersionsDlgObj"  class="modalContent" style="display:none; ">
    <br />
    <table id="VersionsTable" width="100%"  cellspacing="0">
         <tr >
           <td align='right' >
               From:
           </td>
           <td  >
                <select id="SelFromVersion" name="Sv1" onchange="SelectVersionChange_Change();">
                </select>
           </td>
           <td align='right' >
               To:
           </td>
           <td  >
                <select id="SelToVersion" name="Sv2" onchange="SelectVersionChange_Change();">
                </select>
           </td>
         </tr>
         <tr><td><br /></td></tr>
         <tr >
            <td align='right' >
               Not in To Version:
            </td>
            <td  >
                <select id="idSelVersTo" multiple name="st1">
                </select>
           </td>
           <td align='right' >
               Both Versions:
           </td>
           <td  >
                <select id="idSelVersBoth" multiple name="sb1">
                </select>
           </td>
         </tr>
       <tr><td>   <br /></td></tr>
     </table>
    <div class="button-container">
        <input type="button" onclick="javascript: SelectCopyVersion_OKOnClick(1);" class="epmliveButton" value="OK"/>
        <input type="button" onclick="javascript: SelectCopyVersion_OKOnClick(0);" class="epmliveButton" value="Cancel"/>
    </div>
</div>
<div id="idPerDispOptsDlgObj" class="modalContent" style="display:none;" >
    <br />
    <table id="idTabPerOpts" cellspacing='0'>
         <tr id="idDispPer">
           <td>
               Display From Period:
           </td>
           <td  >
                <select id="idDispPerFrom" name="DispPerFrom" onchange="SelectPOA_Change();"/>
           </td>
           <td>    </td>
           <td>
               To:
           </td>
           <td  >
                <select id="idDispPerTo" name="DispPerTo" onchange="SelectPOA_Change();"/>
            </td>
         </tr>
         <tr id="idDragOpts" >
           <td>
               Drag From Period:
           </td>
           <td  >
                <select id="idDragPerFrom" name="DragPerFrom" onchange="SelectPOA_Change();">
                </select>
           </td>
           <td>    </td>
           <td>
               To:
           </td>
           <td  >
                <select id="idDragPerTo" name="DragPerTo" onchange="SelectPOA_Change();">
                </select>
           </td>
         </tr>
    </table>
    <br />
    <table id="idTableDispOpts" cellspacing="0">
         <tr>
             <td>
                <input id="idShowQTY" type="checkbox" name="ShowQTY" onclick="SelectPOA_Change();" />Show Quantity
            </td>
            <td>
                <input id="idUseQTY" type="radio" name="ShowWhat" checked  onclick="SelectPOA_Change();" />Show QTY
            </td>
            <td>
                <input id="idUseFTE" type="radio" name="ShowWhat" onclick="SelectPOA_Change();" />Show FTEs
            </td>
         </tr>
         <tr>
             <td>
                <input id="idShowCosts" type="checkbox" name="ShowCosts" onclick="SelectPOA_Change();" />Show Costs
            </td>
         </tr>
         <tr >
             <td>
                <input id="idShowCostDecVals" type="checkbox" name="ShowDecCosts" onclick="SelectPOA_Change();" />Show decimal places in Costs
            </td>
       </tr>
     </table>
     <br />
    <div class="button-container">
        <input type="button" onclick="javascript: SelectPerDisp_OKOnClick(1);" class="epmliveButton" value="OK"/>
        <input type="button" onclick="javascript: SelectPerDisp_OKOnClick(0);" class="epmliveButton" value="Cancel"/>
    </div>
</div>
<div id="idColssDlgObj" class="modalContent" style="display:none;">
    <br />
    <table id="ColsTable" width="100%"  cellspacing="0">
         <tr >
            <td>
               <table id="ColGridTable" width="250px">
                    <tr>
                      <td>
                        <div id="ColsDiv" style="height:300px;"></div>
                      </td>
                   </tr>
               </table>
             </td>
             <td>
                <table id="ColBut" width="150px">
                   <tr>
                      <td>
                        Freeze Column:
                      </td>
                   </tr>
                   <tr>
                      <td>
                        <select id="idSelectFreeze" name="D1" onchange="SelecFreeze_Change();"/>
                      </td>
                    </tr>
                    <tr>
                    <td>
                      <input id="Button10"   type="button" class="btn" value="Up" onclick="MoveRow_Click(0);" style="width:75px;" />
                    </td>
                    </tr>
                  <tr>
                    <td>
                      <input id="Button11"   type="button" class="btn" value="Down" onclick="MoveRow_Click(1);" style="width:75px;" />
                    </td>
                  </tr>
                  <tr><td></td></tr>
                </table>
             </td>
          </tr>
          <tr><td></td></tr>
     </table>
    <div class="button-container">
        <input type="button" onclick="javascript: SelectCols_OKOnClick(1);" class="epmliveButton" value="OK"/>
        <input type="button" onclick="javascript: SelectCols_OKOnClick(0);" class="epmliveButton" value="Cancel"/>
    </div>
</div>
<div id="idSearchDlgObj" class="modalContent" style="display:none;">
    <br />
    <table id="Table1" width="100%"  cellspacing="0">
         <tr >
            <td>
            Search For:
            </td>
           <td>
             <input id="idtxtsearch" type="text" style="width:20em;" />
            </td>
         </tr>
         <tr>
            <td>
            Where:
            </td>                    
            <td>
                <select id="idSearchHow" name="s1"></select>
            </td>
         </tr>
         <tr>
            <td>
            In:
            </td>                    
            <td>
                <select id="idSearchWhere" name="s2" onchange="SelectSearchWhere_Change();" ></select>
            </td>
         </tr>
         <tr><td></td></tr>
         <tr>
           <td></td>
           <td>
            <input id="rbSearchDet" type="radio" name="searchrb" checked  onclick="DoLoadSearchData();"/>Details (Top Grid)
           </td>
         </tr>
         <tr>
           <td></td>
           <td>
            <input id="rbSearchTot" type="radio" name="searchrb" onclick="DoLoadSearchData();"/>Totals (Bottom Grid)
           </td>
        </tr>
     </table>
     <br />
     <div class="button-container">
        <input type="button" onclick="javascript: SelectSearch_OKOnClick(1);" class="epmliveButton" value="OK"/>
        <input type="button" onclick="javascript: SelectSearch_OKOnClick(0);" class="epmliveButton" value="Cancel"/>
    </div>
</div>
<div id="idCreateTragetDlgObj" class="modalContent" style="display:none;">
    <br />
    <table id="idCreTarTab" width="100%"  cellspacing="0">
         <tr >
            <td>
            Target Name:
            </td>
           <td>
             <input id="idTxtNewTargetName" type="text" style="width:20em;" />
            </td>
         </tr>
          <tr >
            <td>
            Target Description:
            </td>
           <td>
             <input id="idTxtNewTargetDesc" type="text" style="width:30em;" />
            </td>
         </tr>
         <tr id="hiddenCreateTargetRow" style="display:none">
            <td>
            Local Target:
            </td>                    
            <td>
               <input id="idChkLocalTarget" type="checkbox" name="idChkLocalTarget" />
            </td>
         </tr>
         <tr><td><br /></td></tr>
     </table>
    <div class="button-container">
        <input type="button" onclick="javascript: CreateTarget_OKOnClick(1);" class="epmliveButton" value="OK"/>
        <input type="button" onclick="javascript: CreateTarget_OKOnClick(0);" class="epmliveButton" value="Cancel"/>
    </div>
</div>
<div id="idEditTargetDlg" class="modalContent" style="display:none;">
   <div id="ribbonbarEdiTarDiv"></div>
   <div id="idEditGridDiv"></div>
 </div>
<div id="idBusyDlgObj" style="display:none;">
    <table id="idTabBusy" width="100%"  cellspacing="0">
      <tr>
       <td>
          <img id="idbusy" src="images/wait.gif" alt='Busy' />
       </td>
       </tr>
     </table>
</div>
<div id="idGroupTargetBy" class="modalContent" style="display:none;">
    <br />
    <table id="idGrpTargetTable" width="100%"  cellspacing="0">
         <tr >
             <td  >
                <select id="idSelectGroup" name="idSelectGroup">
                </select>
           </td>
        </tr>
        <tr><td>  <br /> </td></tr>
     </table>
    <div class="button-container">
        <input type="button" onclick="javascript: SelectGroupTarget_OKOnClick(1);" class="epmliveButton" value="OK"/>
        <input type="button" onclick="javascript: SelectGroupTarget_OKOnClick(0);" class="epmliveButton" value="Cancel"/>
     </div>
</div>
<div class="modalContent" id="idTargetLegendDlgObj" style="display:none;">
    <br />
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div id="idTarLegDiv"></div>
		<div style="float:right;padding-right:5px;margin-top:15px;">
			<div>
                <input type="button" onclick="javascript: TargetLegend_OKOnClick(1);" class="epmliveButton" value="OK"/>
  			</div>
		</div>
	</div>
</div>
<div id="idUserViewsDlgObj" class="modalContent" style="display:none;">
    <br />
    <table width="100%"  cellspacing="0">
         <tr >
             <td>
                 <input id="idUserViewText" type="text" style="width:20em;" />
             </td>
         </tr>
         <tr>
             <td  >
                <select id="idSelectUserView" name="idSelectGroup" onchange="SelectUserView_Change();">
                </select>
           </td>
        </tr>
        <tr><td>  <br /> </td></tr>
     </table>
     <table>
       <tr>
           <td>
            <input id="idrbUserLocal" type="radio" name="userviewrb" checked  />Local View
          </td>
          <td>
            <input id="idrbUserGlobal" type="radio" name="userviewrb"  />Global View
          </td>
        </tr>
        <tr><td></td></tr>
     </table>
     <br />
     <div    style="vertical-align:bottom; text-align:right">
        <table width="100%" cellspacing="2">
           <tr>
            <td>
               <input id="Button27"   type="button" class="epmliveButton" value="Save" onclick="UserView_OnClick(1);" style="width:5em;" />
               <input id="Button29"   type="button" class="epmliveButton" value="Delete" onclick="UserView_OnClick(2);" style="width:5em;" />
               <input id="Button28"   type="button" class="epmliveButton" value="Cancel" onclick="UserView_OnClick(0);" style="width:5em;" />
            </td>
            </tr>
        </table>
    </div>
</div>
<div id="gridDiv_1" style="position: relative; width: 100%;"></div>
<div id="bottomgridDiv_1"></div>
</div>

<div class="modalContent" id="idSaveViewDlg" style="display:none;">
    <br />
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
                    <input type="button" onclick="javascript: dialogEvent('SaveView_OK');" class="epmliveButton" value="OK"/>
                    <input type="button" onclick="javascript: dialogEvent('SaveView_Cancel');" class="epmliveButton" value="Cancel"/>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idRenameViewDlg" style="display:none;">
    <br />
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			View Name:
		</div>
		<div>
			<input id="id_RenameView_Name" type="text" value="view 1" style="width:10em; text-align:left;" />
		</div>
		<div style="width:200px;float:right;">
			<div class="button-container">
                    <input type="button" onclick="javascript: dialogEvent('RenameView_OK');" class="epmliveButton" value="OK"/>
                    <input type="button" onclick="javascript: dialogEvent('RenameView_Cancel');" class="epmliveButton" value="Cancel"/>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idDeleteViewDlg" style="display:none;">
    <br />
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			Are you sure you want to delete this view?
		</div>
		<div>
			<input id="id_DeleteView_Name" type="text" value="view 1" style="width:10em; text-align:left;" />
		</div>
		<div style="width:200px;float:right;">
			<div class="button-container">
                    <input type="button" onclick="javascript: dialogEvent('DeleteView_OK');" class="epmliveButton" value="Delete"/>
                    <input type="button" onclick="javascript: dialogEvent('DeleteView_Cancel');" class="epmliveButton" value="Cancel"/>
 			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idSpreadDlgObj" style="display:none;">
    <br />
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
	    <div>
            <div>
                <table>
                    <tr>
                    <td>Amount&nbsp;:</td>
                    <td class="datacol">
                    <table>
                    <tr>
                    <td><input id="idSpreadAmount" type="text" value="100" style="width:2.5em; text-align:right;" /><label for="idSpreadAmount" id="idSpreadUnits">Hours</label></td>
                    </tr>
                    </table>
                    </td>
                    </tr>
                    <tr>
                    <td valign="top">Action&nbsp;:&nbsp;</td>
                    <td class="datacol">
                    <table>
                    <tr><td><input id="idSpreadCopy" type="radio" name="xaction" checked="checked" class="actionRadio" /><label  for="idSpreadCopy">Copy</label></td></tr>
                    <tr><td><input id="idSpreadSpread" type="radio" name="xaction" class="actionRadio" /><label for="idSpreadSpread">Spread</label></td></tr>
                    </table>
                    </td>
                    </tr>
                </table>
            </div>
            <div>
                <table width="100%">
                <tr>
                <td>Start Period:<br /><select id="idSpreadStartPeriod" name="D1"></select></td>
                <td>Finish Period:<br /><select id="idSpreadFinishPeriod" name="D1"></select></td>
                </tr>
                <tr>
                    <td colspan="2"><input type='checkbox' id="idSpreadClearPeriods" /> Clear other Periods</td>
                </tr>
                </table>
            </div>
        </div>
    </div>
	<div style="width:200px;float:right;">
		<div class="button-container">
                    <input type="button" onclick="javascript: dialogEvent('spreadDlg_Apply');" class="epmliveButton" value="Apply"/>
                    <input type="button" onclick="javascript: dialogEvent('spreadDlg_Close');" class="epmliveButton" value="Close"/>
		</div>
	</div>
</div>
<script type="text/javascript">
    function dialogEvent(action) { model.toolbarOnClick(action); }
    function etdialogEvent(action) { model.ettoolbarOnClick(action); }
    function SelectModel_Change() { model.SelectModel_Change(); }
    function SelectModel_OKOnClick(action) { model.SelectModel_OKOnClick(action); }
    function ChangeSortandGroup() { model.ChangeSortandGroup(); }
    function flashSnGUI() { model.flashSnGUI(); }
    function SelectSnG_OKOnClick(action) { model.SelectSnG_OKOnClick(action); }
    function SelectFilter_OKOnClick(action) { model.SelectFilter_OKOnClick(action); }
    function SelectCostTypeCmp_OKOnClick(action) { model.SelectCostTypeCmp_OKOnClick(action); }
    function SelectTotals_OKOnClick(action) { model.SelectTotals_OKOnClick(action); }
    function SelectSaveOrApply_OKOnClick(action) { model.SelectSaveOrApply_OKOnClick(action); }
    function SelectVersionChange_Change() { model.SelectVersionChange_Change(); }
    function SelectCopyVersion_OKOnClick(action) { model.SelectCopyVersion_OKOnClick(action); }
    function SelectPOA_Change() { model.SelectPOA_Change(); }
    function SelectPerDisp_OKOnClick(action) { model.SelectPerDisp_OKOnClick(action); }
    function SelecFreeze_Change() { model.SelecFreeze_Change(); }
    function MoveRow_Click(action) { model.MoveRow_Click(action); }
    function DoLoadColumnOrderData() { model.DoLoadColumnOrderData(); }
    function SelectCols_OKOnClick(action) { model.SelectCols_OKOnClick(action); }
    function SelectSearchWhere_Change() { model.SelectSearchWhere_Change(); }
    function DoLoadSearchData() { model.DoLoadSearchData(); }
    function SelectSearch_OKOnClick(action) { model.SelectSearch_OKOnClick(action); }
    function CreateTarget_OKOnClick(action) { model.CreateTarget_OKOnClick(action); }
    function SelectGroupTarget_OKOnClick(action) { model.SelectGroupTarget_OKOnClick(action); }
    function TargetLegend_OKOnClick() { model.TargetLegend_OKOnClick(); }
    function SelectUserView_Change() { model.SelectUserView_Change(); }
    function UserView_OnClick(action) { model.UserView_OnClick(action); }



    var params = {};
    params.ClientID = '<%=ClientID%>';
    params.TicketVal = '<%=TicketVal%>';
    params.ModelVal = '<%=ModelVal%>';
    params.VersionsVal = '<%=VersionsVal%>';
    params.ViewIDVal = '<%=ViewIDVal%>';
    params.ViewNameVal = '<%=ViewNameVal%>';
    params.URL = '<%=URL%>';
    params.Webservice = '<%=Webservice%>';
    params.GridStyle = '<%=GridStyle%>';
    params.GridCSS = '<%=GridCSS%>';

    model = new Model('model', params);
</script>
