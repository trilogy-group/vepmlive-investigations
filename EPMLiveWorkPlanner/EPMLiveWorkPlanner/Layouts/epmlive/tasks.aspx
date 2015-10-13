<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBar" src="~/_controltemplates/Toolbar.ascx" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tasks.aspx.cs" Inherits="EPMLiveWorkPlanner.tasks" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content id="PlaceHolderNavSpacerD" ContentPlaceHolderID="PlaceHolderNavSpacer" runat="server">
    
</asp:Content>
<asp:Content id="Content6" ContentPlaceHolderID="PlaceHolderLeftNavBar" runat="server">
    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	Project Work Plan : <%=projectName.Replace("%20"," ")%>
</asp:Content>
<asp:Content ID="ccc" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

<script type="text/javascript" src="modal/modal.js"></script>
    <link rel="STYLESHEET" type="text/css" href="dhtml/xgrid/dhtmlxgrid.css"/>
    <link rel="STYLESHEET" type="text/css" href="dhtml/xgrid/dhtmlxgrid_skins.css"/>
    <link rel="STYLESHEET" type="text/css" href="dhtml/calendar/dhtmlxcalendar.css"/>
	
	<script>	    _css_prefix = "DHTML/xgrid/"; _js_prefix = "DHTML/xgrid/"; </script>
	


    <script src="DHTML/xgrid/dhtmlxcommon.js"></script>
    <script src="DHTML/xgrid/dhtmlxgrid.js"></script>
    <script src="DHTML/xgrid/dhtmlxgridcell.js"></script>
    <script src="DHTML/xtreegrid/dhtmlxtreegrid.js"></script>
    
    <script src="DHTML/xtreegrid/ext/dhtmlxtreegrid_filter.js"></script>

    <script src="DHTML/xgrid/ext/dhtmlxgrid_post.js"></script>
    <script src="DHTML/xgrid/ext/dhtmlxgrid_nxml.js"></script>
    <script src="DHTML/xgrid/ext/dhtmlxgrid_filter.js"></script>
    <script src="DHTML/xgrid/ext/dhtmlxgrid_math.js"></script>
    <script src="DHTML/xgrid/ext/dhtmlxgrid_srnd.js"></script>
    <script src="DHTML/xgrid/ext/dhtmlxgrid_drag.js"></script>
    
    <script src="DHTML/xgrid/excells/dhtmlxgrid_excell_calendar.js"></script>
    <script src="DHTML/xgrid/excells/dhtmlxgrid_excell_combo.js"></script>
    <script src="DHTML/xgrid/excells/dhtmlxgrid_excell_dhxcalendar.js"></script>
    <script src="DHTML/xcombo/dhtmlxcombo.js"></script>
    <script src="DHTML/calendar/dhtmlxcalendar.js"></script>
    <script src="DHTML/xdataproc/dhtmlxdataprocessor.js"></script>
    
	
    <script src="epmliveworkplan.js?rnd=<%=Guid.NewGuid()%>"></script>

    <style>
	.menuTable{
		background-color:#ffffff;
	}
	.contextMenuover, .contextMenudown{
		background-color:#9ac2e5;
	}
	.contextMenuover td{
		color:#000000;
	}
	div.gridbox table.obj tr.rowselected td.cellselected, div.gridbox table.obj td.cellselected
	{
	    background-color:#327CC0;
	}
	.transparent
    {
       filter:alpha(opacity=60); 
       -moz-opacity: 0.6; 
       opacity: 0.6; 
       z-index: 1;
    }
    TABLE.ms-toolbar
    {
        height: 10px;
    }
    
    html, body{
      height:100%;
    }
	</style>
	
	<style type="text/css" media="screen">
     div.gridbox table.obj td {
      padding-top:2px;
      padding-bottom:2px;
     }
     .ms-usereditor { width:200px; }
     .ms-formareaframe
     {
        padding: 0px;
     }
     .ms-bodyareacell
     {
         padding: 0px !important;
     }
     .ms-dialog
     {
         padding: 0px !important;
     }
   
    </style>
<%if(showPlanner){ %>
	<script language="javascript">

	    

	    window.onbeforeunload = leavePage;
	    
	</script>
<%}%>
    <link rel="stylesheet" href="modal/modal.css" type="text/css" /> 

</asp:Content>
<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	Project Work Plan : <%=projectName.Replace("%20"," ")%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">

<asp:Panel ID="pnlProjectServer" runat="server" width="100%" Height="100%" Visible="false">
    Your project has been published with Project Server and cannot be edited in Work Planner.
</asp:Panel>

<asp:Panel ID="pnlMain" runat="server" width="100%" Height="100%">


    <div id="peoplegrid" style="display:none; border: 1px solid #808080; padding: 3px; background-color: #F9F9F9; width=200px;">
    <div id="peoplecheck" style="overflow: auto; width: 200px; height: 100px;  background-color: #FFFFFF; border: 1px solid #808080; margin-top:2px; padding:3px;" class="ms-descriptiontext">
    </div>
    <table border="0" width="100%"><tr><td>
    <a onclick="javascript:viewChecks();"><img id="peoplecheckimg" src="../images/TPMAX1.GIF" border="0"></a><br>
    </td><td align="right">
    <font class="ms-descriptiontext"><a onclick="javascript:mygrid.editStop();">Close</a></font>
    </td></tr></table>
    <div id="divPe" style="display:none;">
    <SharePoint:PeopleEditor ID="userpickerm" runat="server" MultiSelect="true" />
    </div>
    </div>
    
    <div id="peoplesingle" style="display:none; border: 1px solid #808080; padding: 3px; background-color: #F9F9F9; width=200px;">
    <div id="peoplechecksingle" style="width: 200px; height: 100px;  background-color: #FFFFFF; border: 1px solid #808080; margin-top:2px; padding:0px;" class="ms-descriptiontext">
    <select size="6" onclick="changeUser(this);" id="peoplecheckselect"  style="width:100%;height:100%"><option>test</option></select>
    </div>
    
    <table border="0" width="200"><tr><td>
    <a onclick="javascript:viewDropDown();"><img id="peoplechecksingleimg" src="../images/TPMAX1.GIF" border="0"></a><br>
    </td><td align="right">
    <font class="ms-descriptiontext"><a onclick="javascript:mygrid.editStop();">Close</a></font>
    </td></tr></table>

    <div id="divPes" style="display:none;">
    <SharePoint:PeopleEditor ID="userpickers" runat="server" MultiSelect="false" />
    </div>
    </div>


    <div id="multichoice" style="display:none; border: 1px solid #808080; padding: 3px; background-color: #F9F9F9; width:200px;height:175px">
    <div id="multichoiceinner" style="overflow: auto;width: 195px; height: 155px;  background-color: #FFFFFF; border: 1px solid #808080; margin-top:2px; padding:0px;" class="ms-descriptiontext">
    test
    </div>
    <table border="0" width="200">
        <tr>
            <td align="right">
                <font class="ms-descriptiontext"><a onclick="javascript:mygrid.editStop();">Close</a></font>
            </td>
        </tr>
    </table>
    </div>

            <table class="ms-menutoolbar" cellpadding="2" cellspacing="0" border="0" width="100%" style="height:10px">
            <tr height="23">
            <td class="ms-toolbar" >
		        <table cellpadding="0" cellspacing="0" border="0">
		            <tr>
		                <td valign="center">
		                    <asp:Panel ID="pnlFileToolbar" runat="server"></asp:Panel>
		                </td>
		                <td class=ms-separator><img src='/_layouts/images/blank.gif' alt=''></td>
		                <td valign="center">
		                    <asp:Panel ID="pnlEditToolbar" runat="server"></asp:Panel>
		                </td>
				        <td class=ms-separator><img src='/_layouts/images/blank.gif' alt=''></td>
				        <td valign="center">
		                    <asp:Panel ID="pnlResourceToolbar" runat="server"></asp:Panel>
		                </td>
				        <td class=ms-separator><img src='/_layouts/images/blank.gif' alt=''></td>
				        <td>
				            <select style="z-index: 1000;" name="outlinelevel" id="outlinelevel" onchange="Javascript:doOutlineLevel();">
				                <option value="">Show All Levels</option>
				            </select>
				        </td>
                        <td class=ms-separator><img src='/_layouts/images/blank.gif' alt=''></td>
				        <td class="ms-toolbar">
                            <table border="0" cellpadding="0" cellspacing="0"><tr><td class="ms-toolbar" style="height:100%" valign="center" nowrap><div class="ms-buttoninactivehover" onmouseover="this.className='ms-buttonactivehover'" onmouseout="this.className='ms-buttoninactivehover'" onclick="javascript:saveData();">
                            <a id="fA"><img src="../images/saveitem.gif" border="0" align="absmiddle" > Save</a>
                            </div></td></tr></table>
				        </td>
				        <td class=ms-separator><img src='/_layouts/images/blank.gif' alt=''></td>
				        <td class="ms-toolbar">
                            <table border="0" cellpadding="0" cellspacing="0"><tr><td class="ms-toolbar" style="height:100%" valign="center" nowrap><div class="ms-buttoninactivehover" onmouseover="this.className='ms-buttonactivehover'" onmouseout="this.className='ms-buttoninactivehover'" onclick="javascript:location.reload();">
                            <a id="A1"><img src="../images/refresh.gif" border="0" align="absmiddle" > Refresh Work Plan</a>
                            </div></td></tr></table>
				        </td>
				        <%if(hasFilters){ %>
				        <td class=ms-separator><img src='/_layouts/images/blank.gif' alt=''></td>
				        <td class="ms-toolbar">
                            <table border="0" cellpadding="0" cellspacing="0"><tr><td class="ms-toolbar" style="height:100%" valign="center" nowrap><div class="ms-buttoninactivehover" onmouseover="this.className='ms-buttonactivehover'" onmouseout="this.className='ms-buttoninactivehover'" onclick="location.href='<%=sUrl %>&source=<%=System.Web.HttpUtility.UrlEncode(pcURL) %>'">
                            <a id="A2"><img src="images/disablefilter.gif" border="0" align="absmiddle" > Disable Filters</a>
                            </div></td></tr></table>
				        </td>
				        <%} %>
		            </tr>
		        </table>
		    </td>
            <td class="ms-toolbar" nowrap="true" align="right">

            <table border=0 cellpadding=0 cellspacing=0 style='margin-right: 4px'>
                <tr>
                    <td nowrap class="ms-listheaderlabel">View:&nbsp;</td>
                    <td nowrap="nowrap" class="ms-viewselector">
                        <select name="" onchange="Javascript:location.href='tasks.aspx?view=' + this.value + '&ID=<%=Request["ID"]%>&Source=<%=Request["Source"]%>&isDlg=1';">
                            <%=viewList%>
                        </select>
                    </td>
                </tr>
            </table>

            </td>
            </tr>
            </table>
            
            <asp:Panel ID="pnlToolbar" runat="server"></asp:Panel>
            
            <div id="products_grid" style="width:100%;height:200px"></div>

            <div id="editItem" class="dialog">
                <table width="100%" height="100%" id="tblEditItem" cellpadding="0" cellspacing="0">
                    <tr height="100%">
                        <td align="center" bgcolor="FFFFFF">
                            <div id="editItemLoad">
                                <img src="../images/GEARS_AN.GIF" style="vertical-align: middle;"/>
                            </div>
                            <iframe id="frmEditFrame" width="100%" height="100%" frameborder="0" src="<%=SiteUrl%>">
                                
                            </iframe>
                        </td>
                    </tr>
                </table>
            </div>

            <script>
                columnCalculations = ["",<%=columnCalculations%>];
                var URL = "gettasks.aspx?ID=<%=Request["ID"]%>&view=<%=currentViewGuid%>";
                var dpURL = "updatetask.aspx?project=<%=projectName%>&view=<%=currentViewGuid%>&projectId=<%=Request["ID"]%>";
                var listId = "<%=listId%>";
                var siteUrl = "<%=SiteUrl%>";
                var lastBaseline = "<%=lastBaseline%>";
                var listView = "<%=currentViewGuid%>";

                var webId = "<%=webId %>";
                var siteId = "<%=siteId %>";
                projectEditUrl = "<%=projectEditUrl%>";
                pcURL = "<%=pcURL%>";
                nonwork = <%=nonwork %>;
                workdays = <%=workdays %>;
                hasFilters = <%=hasFilters.ToString().ToLower() %>;
                
                defaultValues = ["",<%=defaultValues%>];
                minValues = ["",<%=minValues%>];
                maxValues = ["",<%=maxValues%>];
                var useResPool = <%=useResourcePool%>;
                
	            autoCalc = <%=autoCalc%>;
	            curProj= <%=Request["ID"]%>;
                mygrid = new dhtmlXGridObject('products_grid'); 
                mygrid.setImagePath("dhtml/xgrid/imgs/");

                mygrid.setSkin("modern");
                mygrid.setImageSize(1,1);
                mygrid.setDateFormat("<%=strDateFormat %>");
                mygrid.attachEvent("onXLE",loadPredecessorIds);
                mygrid.attachEvent("onXLE",clearLoader);
                mygrid.attachEvent("onXLE",initWBS);
                mygrid.enableMultiselect(true);
                
                mygrid.attachEvent("onEditCell",doOnCellEdit);
                
                mygrid.attachEvent("onKeyPress",doOnKeyPress);
                
                <%if(!hasFilters){ %>
                    mygrid.attachEvent("onDrop",dragDrop);
                    mygrid.enableDragAndDrop(true);
                    mygrid.setDragBehavior("complex");
                    //mygrid.enableMercyDrag(true);
                <%} %>

			    mygrid.enableMultiline(true);
			    mygrid.enableEditEvents(true, true, true);
    			
    			mygrid.enableEditTabOnly(true);
    			
                mygrid.init();
                
	            myDataProcessor = new dataProcessor(dpURL);
                myDataProcessor.setUpdateMode("off", true);
                myDataProcessor.defineAction("error100",myErrorHandler);
                myDataProcessor.defineAction("error500",error500);
                myDataProcessor.defineAction("alldatareturned", alldatareturned);
                
                myDataProcessor.setTransactionMode("POST",true);
                
                
                myDataProcessor.setOnAfterUpdate(function(id,action,newid){
                
                    //if(action != "delete")
                    //    mygrid.setUserData(newid,"SharePointId",newid);
                    if(action != "error100" && action != "delete")
                        mygrid.cells(newid,0).setValue("");
                    
                    //alert(myDataProcessor.getSyncState());
                    if(myDataProcessor.getSyncState())
                    {
                        myDataProcessor.updatedRows = new Array(0);
                        //document.getElementById("saving").style.display = "none";
                        hm('dlgSaving');
                        if(closeplan)
                        {
                            window.close();
                        }
                        else
                        {
                            window.location.reload();
                        }
                    }
                });
                
                myDataProcessor.init(mygrid);
                    
                function viewChecks()
                {
                    var pp = document.getElementById('divPe');
                    var ppi = document.getElementById('peoplecheckimg');
                    if(pp.style.display == "none"){
                        pp.style.display = "";
                        ppi.src = "../images/TPMIN1.GIF";
                    }
                    else{
                        pp.style.display = "none";
                        ppi.src = "../images/TPMAX1.GIF";
                    }
                }
                
                function viewDropDown()
                {
                    var pp = document.getElementById('divPes');
                    var ppi = document.getElementById('peoplechecksingleimg');
                    if(pp.style.display == "none"){
                        pp.style.display = "";
                        ppi.src = "../images/TPMIN1.GIF";
                    }
                    else{
                        pp.style.display = "none";
                        ppi.src = "../images/TPMAX1.GIF";
                    }
                }
               
               function myErrorHandler(obj){
                      var id = obj.getAttribute("sid");
                      mygrid.cells(id,0).setValue("<a href=\"javascript:viewError('" + id + "');\"><img src='/_layouts/images/EXCLAIM.GIF' border='0'></a>");
                      mygrid.setUserData(id,"lastError",obj.firstChild.data);
                      return true;
                }

                function alldatareturned(obj){
                     setRowValues(obj.firstChild);
                }

                function error500(obj){
                      alert(obj.firstChild.data);
                      myDataProcessor.stopOnError = true; 
                      hm('dlgSaving');
                      return false;
                }
                
                function viewError(id){
                    document.getElementById('dlgErrorText').innerText=mygrid.getUserData(id,"lastError");
                    sm('dlgError',250,130);
                }
               
               //var Client = {   
               //viewportWidth: function() {     return self.innerWidth || (document.documentElement.clientWidth || document.body.clientWidth);   },   viewportHeight: function() {     return self.innerHeight || (document.documentElement.clientHeight || document.body.clientHeight);   },      viewportSize: function() {     return { width: this.viewportWidth(), height: this.viewportHeight() };   } }; 

               //document.getElementById("editItem").style.top =  150;
               //document.getElementById("editItem").style.left = getPageSize()[0] / 2 - 350;
               //document.getElementById("editItem").style.position = "absolute";
               
            </script>
            
            
            
            <div id="dlgError" class="dialog">
                <table width="100%" height="100%" cellpadding="0" cellspacing="3">
		            <tr>
			            <td class="ms-sectionheader"><H3 class="ms-standardheader">Error: </h3></td>
		            </tr>
                    <tr height="100%">
                        <td align="left"valign="top">
                            <div id="dlgErrorText" style="overflow: auto;height=90%;width=100%" class="ms-descriptiontext"></div><br>
                        </td>
                    </tr>
                    <tr>
			            <td align="right">
				            <input type="button" class="ms-input" value="Close" onClick="hm('dlgError');">
			            </td>
		            </tr>
                </table>
            </div>
            
            <div id="dlgAutoCalc" class="dialog">
                <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <img src="./images/loader-epmlive.GIF" style="vertical-align: middle;width:50px;"/>
                    <div style="line-height:40px;font-family:'Open Sans Regular';color:#666666;font-size:14px;" id="dlgNormalText">Switching auto-calculate...</div>
                </td>
            </tr>   
        </table>
            </div> 
            
            <div id="dlgSaving" class="dialog">
                <table width="100%">
                    <tr>
                        <td align="center" class="ms-sectionheader">
                            <img src="./images/loader-epmlive.GIF" style="vertical-align: middle;width:50px;"/>
                            <div style="line-height:40px;font-family:'Open Sans Regular';color:#666666;font-size:14px;" id="dlgNormalText">Saving Work Plan...</div>
                        </td>
                    </tr>   
                </table>
            </div> 
            
            <div id="dlgOpening" class="dialog">
                <table width="100%">
                    <tr>
                        <td align="center" class="ms-sectionheader">
                            <img src="./images/loader-epmlive.GIF" style="vertical-align: middle;width:50px;"/>
                            <div style="line-height:40px;font-family:'Open Sans Regular';color:#666666;font-size:14px;" id="dlgNormalText">Opening Task...</div>
                        </td>
                    </tr>   
                </table>
            </div> 
            
            <div id="dlgCalculating" class="dialog">
                <table width="100%">
                    <tr>
                        <td align="center" class="ms-sectionheader">
                            <img src="./images/loader-epmlive.GIF" style="vertical-align: middle;width:50px;"/>
                            <div style="line-height:40px;font-family:'Open Sans Regular';color:#666666;font-size:14px;" id="dlgNormalText">Calculating Work Plan...</div>
                        </td>
                    </tr>   
                </table>
            </div> 
            
            <div id="dlgBaseline" class="dialog">
                <table width="100%">
                    <tr>
                        <td align="center" class="ms-sectionheader">
                            <img src="./images/loader-epmlive.GIF" style="vertical-align: middle;width:50px;"/>
                            <div style="line-height:40px;font-family:'Open Sans Regular';color:#666666;font-size:14px;" id="dlgNormalText">Saving Baseline...</div>
                        </td>
                    </tr>   
                </table>
            </div> 
            
            <div id="dlgTasks" class="dialog">
                <table width="100%">
                    <tr>
                        <td align="center" class="ms-sectionheader">
                            <img src="./images/loader-epmlive.GIF" style="vertical-align: middle;width:50px;"/>
                            <div style="line-height:40px;font-family:'Open Sans Regular';color:#666666;font-size:14px;" id="dlgNormalText">Loading Tasks...</div>
                        </td>
                    </tr>   
                </table>
            </div> 
            <script>
                initmb();
                sm('dlgTasks',200,100);
                
//                var padd = document.getElementById("onetidYPadding");
//                padd.style.display = "none";
//                
//                padd.parentNode.parentNode.parentNode.style.height="100%";
                
                _spBodyOnLoadFunctionNames.push("loadX");
                
                function loadX()
                {
                    document.getElementById("products_grid").style.height = (document.getElementById('ctl00_PlaceHolderMain_pnlMain').offsetHeight - 55) + "px";
                    <%if(disableFilters){ %>
                        mygrid.loadXML(URL + "&disablefilters=true");
                    <%}else{%>
                        mygrid.loadXML(URL);
                    <%} %>

                    setHeight();
                }
                
                function setHeight()
                {
                    document.getElementById("products_grid").style.height = (getHeight() - 60) + "px";
                    //mygrid.enableAutoHeight(true,getHeight()-60,true);
                }
                //document.body.style.overflow = "auto";
                
                window.onresize = setHeight; 

                

                function getHeight()
                {
                    var scnHei;
                    if (self.innerHeight) // all except Explorer
	                {
		                //scnWid = self.innerWidth;
		                scnHei = self.innerHeight;
	                }
	                else if (document.documentElement && document.documentElement.clientHeight)
	                {
		                //scnWid = document.documentElement.clientWidth;
		                scnHei = document.documentElement.clientHeight;
	                }
	                else if (document.body) // other Explorers
	                {
		                //scnWid = document.body.clientWidth;
		                scnHei = document.body.clientHeight;
	                }
                    return scnHei;
                }

            </script> 
            </asp:Panel>
            <asp:Panel ID="pnlExpire" runat="server" Visible ="False">
                <asp:Label ID="lblExpire" runat="server"></asp:Label>
            </asp:Panel>
</asp:Content>