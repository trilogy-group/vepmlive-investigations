<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkPlanner.aspx.cs" Inherits="EPMLiveWorkPlanner.Layouts.epmlive.WorkPlanner" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">



<script src="workenginestatusing.js"></script> 

<link rel="stylesheet" type="text/css" href="dhtml/xlayout/dhtmlxlayout.css"> 
<link rel="stylesheet" type="text/css" href="dhtml/xlayout/skins/dhtmlxlayout_dhx_skyblue.css"> 
<link rel="stylesheet" type="text/css" href="dhtml/xlayout/skins/dhtmlxlayout_dhx_black.css"> 
<link rel="stylesheet" type="text/css" href="dhtml/xlayout/skins/dhtmlxlayout_dhx_blue.css"> 
<link rel="STYLESHEET" type="text/css" href="dhtml/xtab/dhtmlxtabbar.css">
<link rel="stylesheet" type="text/css" href="dhtml/xToolbar/skins/dhtmlxtoolbar_dhx_skyblue.css">

<script src="dhtml/xlayout/dhtmlxcommon.js"></script> 
<script src="dhtml/xlayout/dhtmlxlayout.js"></script> 
<script src="dhtml/xlayout/dhtmlxcontainer.js"></script> 
<script src="dhtml/xtab/dhtmlxtabbar.js"></script>

<script src="dhtml/xToolbar/dhtmlxtoolbar.js"></script>

<script src="workplanner.js?v=<%= EPMLiveVersion %>"></script> 
<%if(bAgile){ %>
    <script src="WorkPlannerAgile.js" type="text/javascript"></script>
    <%} %>
<script src="TreeGrid/GridE.js"> </script>

<link href="WorkPlanner.css" rel="stylesheet" type="text/css" />

<link rel="stylesheet" href="modal/modal.css" type="text/css" /> 
<script type="text/javascript" src="modal/modal.js"></script>

<style>
    html, body {
        width: 100%;
        height: 100% !important;
        margin: 0px;
        overflow: hidden;
    }
    #s4-leftpanel
    {
        display: none !important;
    }
    .s4-ca
    {
        margin-left:0px
    }
    .GSTestRow
    {
        height:20px;
        background-color: #dfe3e8;
        padding:2px;
        border-bottom: #b1b5ba 1px solid;
    }
    
    .newclassinput
    {
           padding: 2px 5px;
            background-color: rgba(255, 255, 255, 0.85);
            border: 1px solid #FFFFFF;
            color: #9C9C9C;
            font-family:"Segoe UI","Segoe",Tahoma,Helvetica,Arial,sans-serif;
            font-size:13px;
            vertical-align: middle;
            outline: none;
    }
    
    #mbox{background-color:transparent; padding:0px !important;}


    #sideNavBox {
        display: none;
    }
    
    .ms-fullscreenmode #contentBox
    {
        margin-left: 0;
    }
    .erroroncell {
        background-color: #EEBDBD !important;
    }

    .detailsdivinfo{
        overflow-y:auto !important;
        width:100% !important;
        height:100% !important;
        background-color:white !important;
    }

    #pageStatusBar[class], .ms-status-msg {
        margin-top: 5px !important;
        margin-bottom: 0 !important;
        padding: 5px 7px !important;
        font-size: 12px !important;
    }

    #contentBox {
        margin-left: 10px !important;
        margin-right: 10px !important; 
    }

    #contentRow {
        padding-top: 0 !important;
    }

    #we-planner-publish-status {
        color: #888;
        font-size: 10px;
        padding-bottom: 2px;
    }
</style>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

<asp:Panel ID="pnlAct" runat="server" Visible="false">
    <asp:Label ID="lblAct" runat="server"></asp:Label>
</asp:Panel>

<asp:Panel ID="pnlMSProject" runat="server" Visible="false">
    <script language="javascript">
        location.href = "getproject.aspx?listid=<%=sProjectListId%>&id=<%=sItemID %>&Source=<%=sSource%>";
        //location.href = "<%=sSource%>";
    </script>
</asp:Panel>

<asp:Panel ID="pnlOldPlanner" runat="server" Visible="false">
    
    <a href="#" onclick="javascript:openwin();" id="htmlOpenWin"></a>

    <script language="javascript">
        /*function doOpen() {
        alert('d');
        var hre = document.getElementById("htmlOpenWin");
        fireEvent(hre, "click");
        }

        function openwin() {
        alert('d1');
        window.open("<%=OldUrl%>.aspx?id=<%=sItemID %>&isdlg=1", '', config = 'height=' + screen.height + ', width=' + screen.width + 'top=0, left=0, toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, directories=no, status=yes');
        location.href = "<%=sSource%>";
        }

        function fireEvent(element, event) {
            if (document.createEventObject) {
                // dispatch for IE
                var evt = document.createEventObject();
                return element.fireEvent('on' + event, evt);
            } else {
                // dispatch for firefox + others
                var evt = document.createEvent("HTMLEvents");
                evt.initEvent(event, true, true); // event type,bubbling,cancelable
                return !element.dispatchEvent(evt);
            }
        }

        _spBodyOnLoadFunctionNames.push("doOpen");*/

        location.href = "<%=OldUrl%>.aspx?id=<%=sItemID %>&Source=<%=sSource%>&isdlg=1";
    </script>
</asp:Panel>

<asp:Panel ID="pnlProject" runat="server" Visible="false">

    <script language="javascript">

        function loadProject()
        {
            var surl = "<%=sWebUrl %>/_layouts/epmlive/openmpp.aspx?Planner=<%=sPlannerID%>&ProjectName=<%=sProjectName%>&listid=<%=sProjectListId%>&isdlg=1&Source=<%=System.Web.HttpUtility.UrlEncode(Request["Source"]) %>";

            var options = { url: surl, width: 350, height: 120, title: "Open project" };

            SP.UI.ModalDialog.showModalDialog(options);
        }

        _spBodyOnLoadFunctionNames.push("loadProject");
    </script>
</asp:Panel>

<asp:Panel ID="pnlProjectSchedule" runat="server" Visible="false">

    <div id="div2" style="width:200;padding:10px;display:none;">

        <b>You are missing the Project Schedules document library.</b><br /><br />

        <input type="button" value="OK" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, ''); return false;" class="ms-ButtonHeightWidth" style="width:100px" target="_self" />
    
    </div>

    <script>

        var canShowDetails = false;
        var d = document.getElementById("div2");
        d.style.display = "";

        function showPlannerPop() {

            var options = { html: d, width: 350, height: 120, title: "Missing Library", dialogReturnValueCallback: showPlannerPopClose };

            SP.UI.ModalDialog.showModalDialog(options);
        }

        function showPlannerPopClose(dialogResult, returnValue) {
            if (dialogResult == SP.UI.DialogResult.OK) {
                location.href = "<%=sSource %>";
            }
            else {
                showPlannerPop();
            }
        }

        _spBodyOnLoadFunctionNames.push("showPlannerPop");
    </script>
</asp:Panel>

<asp:Panel ID="pnlPerms" runat="server" Visible="false">

    <div id="div1" style="width:200;padding:10px;display:none;">
        
        <b>Access Denied:<br /></b>
        <asp:Label ID="lblPerms" runat="server" Text="Either you are not the author of the project or you are not assigned as a Project Manager for this project."></asp:Label>
        <br /><br />

        <input type="button" value="OK" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, ''); return false;" class="ms-ButtonHeightWidth" style="width:100px" target="_self" />
    
    </div>

    <script>

        var canShowDetails = false;
        var d = document.getElementById("div1");
        d.style.display = "";

        function showPlannerPop() {

            var options = { html: d, width: 350, height: 120, title: "Access Denied", dialogReturnValueCallback: showPlannerPopClose };

            SP.UI.ModalDialog.showModalDialog(options);
        }

        function showPlannerPopClose(dialogResult, returnValue) {
            if (dialogResult == SP.UI.DialogResult.OK) {
                location.href = "<%=sSource %>";
            }
            else {
                showPlannerPop();
            }
        }

        _spBodyOnLoadFunctionNames.push("showPlannerPop");
    </script>
</asp:Panel>

<asp:Panel ID="pnlParentChild" runat="server" Visible="false">
    <div id="div3" style="width:200;padding:10px">
        
        <table>
        
            <wssuc:InputFormSection Title="Select Item"
	            Description=""
	            runat="server" Visible="true" id="sectionItem2">
	            <Template_Description>
	                Select the item you want to plan with.
	            </Template_Description>
	            <Template_InputFormControls>
		            <wssuc:InputFormControl LabelText="" runat="server">
			                <Template_Control>
			                <asp:DropDownList id="ddlChildParent" runat="server"></asp:DropDownList>
			                </Template_Control>
		            </wssuc:InputFormControl>
	            </Template_InputFormControls>
            </wssuc:InputFormSection>
        
            <tr>
                <td class=ms-sectionline height=2 colSpan=2><IMG alt="" src="/_layouts/images/blank.gif" width=1 height=1></td>
            </tr>

            <tr>
                <td align="right" colspan="2">
                    <input type="button" value="Go" onclick="DoPlanner();" class="ms-ButtonHeightWidth" style="width:100px"/>
                    <input type="button" value="Cancel" onclick="Close();" class="ms-ButtonHeightWidth" style="width:100px"/>
                </td>
            </tr>
        </table>

        
    </div>

    <script language="javascript">
        var sSource = "<%=sSource %>";

        function DoPlanner() {

            var val = document.getElementById("<%=ddlChildParent.ClientID %>").value.split('.');

            var url = "gridaction.aspx?action=gotoplannerpc&webid=" + val[0] + "&ID=" + val[2] + "&listid=" + val[1];

            if (sSource != "")
                url += "&source=" + sSource;

            location.href = url;

        }

        function showPlannerPop() {
                
            var options = { html: document.getElementById("div3"), width: 400, title: "Select Item", dialogReturnValueCallback: showPlannerPopClose };

            SP.UI.ModalDialog.showModalDialog(options);
        }

        function showPlannerPopClose(dialogResult, returnValue) {


            if (dialogResult == SP.UI.DialogResult.OK) {

                DoPlanner();

            }
            else {
                showPlannerPop();
            }
        }

        _spBodyOnLoadFunctionNames.push("showPlannerPop");
    </script>
</asp:Panel>


<asp:Panel ID="pnlPopup" runat="server" Visible="false">

    

    <script>
    
        var sSource = "<%=sSource %>";

        function showPlannerPop() {


            var surl =  "<%=sWebUrl %>/_layouts/epmlive/workplannerwizard.aspx?dodialog=<%=Request["IsDlg"]%>&Planner=<%=sPlannerID %>&ID=<%=sItemID %>&PType=<%=sProjectType %>&listid=<%=sProjectListId %>&tasklistid=<%=sTaskListId%>&Source=<%=System.Web.HttpUtility.UrlEncode(Request["Source"]) %>";

            var options = { url: surl, width: 450, title: "Select Planner", dialogReturnValueCallback: showPlannerPopClose };

            SP.UI.ModalDialog.showModalDialog(options);
        }

        function showPlannerPopClose(dialogResult, returnValue) {

            location.href = sSource;
           
        }

        _spBodyOnLoadFunctionNames.push("showPlannerPop");
    </script>

</asp:Panel>

<asp:Panel ID="pnlMain" runat="server">

    <%=timerString %>

<script language="javascript">

    window.onbeforeunload = LeavePage;
	    
</script>

    <div id="parentId" style="position:absolute; width:100%; height:100%;"></div>

    <div id="folderDiv" style="width:100%;height:100%;display:none;">
        <div style="width:100%;height:24px;border-bottom: 1px solid black;">
            <div class="wetoolbar">
                <ul>
                    <li><a href="#" onclick="Javascript:NewFolder();"><img src="images/newfolder16.gif" border="0"/></a></li>
                    <li><a href="#" onclick="Javascript:EditFolder();"><img src="images/editfolder16.gif" border="0"/></a></li>
                    <li><a href="#" onclick="Javascript:DeleteFolder();"><img src="images/deletefolder16.gif" border="0"/></a></li>
                </ul>
            </div>
        </div>
        <div style="width:100%;height:100%">
            <!--<treegrid 
            Data_Url="../../_vti_bin/WorkPlanner.asmx" Data_Method="Soap" Data_Function="Execute" Data_Namespace="workengine.com" Data_Param_Functionname="GetTasks" Data_Param_Dataxml="<%=sPlannerDataParam %>"
            Layout_Url="../../_vti_bin/WorkPlanner.asmx" Layout_Method="Soap" Layout_Function="Execute" Layout_Namespace="workengine.com" Layout_Param_Functionname="GetFolderLayout" Layout_Param_Dataxml="<%=sPlannerLayoutParam %>"
            Upload_Url="SaveWorkPlanner.aspx" Upload_Type="Body" Upload_Format="Internal" Upload_Data="TGData" Upload_Flags="Accepted,AllCols,NoIO" Upload_Param_Dataxml="<%=sPlannerDataParam %>"
            Debug=""></treegrid>-->
        </div>
    </div>

    <div id="workplannerDiv" style="width:100%;height:100%">
        <!--<treegrid 
        Layout_Url="../../_vti_bin/WorkPlanner.asmx" Layout_Method="Soap" Layout_Function="Execute" Layout_Namespace="workengine.com" Layout_Param_Functionname="GetLayout" Layout_Param_Dataxml="<%=sPlannerLayoutParam %>"
        Upload_Url="SaveWorkPlanner.aspx" Upload_Type="Body" Upload_Format="Internal" Upload_Data="TGData" Upload_Flags="Accepted,AllCols,NoIO" Upload_Param_Dataxml="<%=sPlannerDataParam %>"
        Data_Url="../../_vti_bin/WorkPlanner.asmx" Data_Method="Soap" Data_Function="Execute" Data_Namespace="workengine.com" Data_Param_Functionname="GetTasks" Data_Param_Dataxml="<%=sPlannerDataParam %>"
        Debug=""
        Export_Url="PlannerExcelExport.aspx"
        >
        </treegrid>-->
    </div>


    
    <div id="agileDiv" style="width:100%;height:100%;display:none"></div>

    <div id="allocDiv" style="width:100%;height:100%;display:none"></div>

    <div id="detailDivMain" style="width:100%;height:100%">
        <div id="detailDivTab" style="width:100%;height:100%">
        </div>
    </div>

    <div id="detailDiv" class="detailsdivinfo">
        <div id="detailTree" style="width:100%;height:100%;background-color:White">
            <!--<treegrid 
            Data_Url="BlankTable.xml"
            Layout_Url="../../_vti_bin/WorkPlanner.asmx" Layout_Method="Soap" Layout_Function="Execute" Layout_Namespace="workengine.com" Layout_Param_Functionname="GetDetailLayout" Layout_Param_Dataxml="<%=sPlannerLayoutParam %>"
            >
            </treegrid>-->
        </div>
        <div id="detailMulti" style="width:100%;height:100%;display:none;background-color:White">
            Multiple tasks are selected
        </div>
    </div>

    <div id="assignmentsDiv" class="detailsdivinfo" style="display:none">
        <div id="assignmentsDivInner" style="width:100%;height:100%">
            <div style="width:100%;height:22px">
                <div class="wetoolbar">
                    <div style="float:left">
                        Task Type: <select name="slcttasktype" id="slcttasktype" onchange="ChangeTaskType(this);">
                            <option value="0">Shared</option>
                            <option value="1">Individual</option>
                        </select>
                    </div>
                    <div style="float:right">
                        <ul>
                            <li><a href="#" onclick="Javascript:AddResource();" ><img src="images/addresource.gif" border="0" alt="Assign New Resource"/></a></li>
                            <li><a href="#" onclick="Javascript:DeleteResource();"><img src="images/deleteresource.gif" border="0" alt="Delete Resource"/></a></li>
                        </ul>
                    </div>
                    <div style="clear: both;"></div>
                </div>
            </div>
            <div id="assignmentsDivTree" style="width:100%;height:100%">
                <!--<treegrid 
                Data_Url="BlankTable.xml"
                Layout_Url="../../_vti_bin/WorkPlanner.asmx" Layout_Method="Soap" Layout_Function="Execute" Layout_Namespace="workengine.com" Layout_Param_Functionname="GetAssignmentLayout" Layout_Param_Dataxml="<%=sPlannerLayoutParam %>"
                >
                </treegrid>-->
            </div>
        </div>
        <div id="assignmentsDivInnerMulti" style="width:100%;height:100%;display:none;background-color:White">
            Multiple tasks are selected
        </div>
    </div>

    <div id="linksDiv" class="detailsdivinfo" style="display:none">
        <div id="linksDivInner" style="width:100%;height:100%">
            <div style="width:100%;height:24px">
                <div class="wetoolbar">
                    <ul>
                        <%--<li><a href="#" onclick="Javascript:AddNewLink();"><img src="images/newlink.gif" border="0"/></a></li>--%>
                        <li><a href="#" onclick="Javascript:DeleteNewLink();"><img src="images/deletelink.gif" border="0"/></a></li>
                    </ul>
                </div>
            </div>
            <div id="linksDivTree" style="width:100%;height:100%">
                <!--<treegrid 
                Data_Url="BlankTable.xml"
                Layout_Url="../../_vti_bin/WorkPlanner.asmx" Layout_Method="Soap" Layout_Function="Execute" Layout_Namespace="workengine.com" Layout_Param_Functionname="GetLinksLayout" Layout_Param_Dataxml="<%=sPlannerLayoutParam %>"
                >
            </treegrid>--><br />
           </div>
       </div>
       <div id="linksDivInnerMulti" style="width:100%;height:100%;display:none;background-color:White">
            Multiple tasks are selected
        </div>
    </div>

    <div id="notesDiv" class="detailsdivinfo" style="display:none">
        <div id="notesDivInner2" style="width:100%;height:100%">
            <a href="#" onclick="Javascript:ShowNotes();" >[Edit Notes]</a><br><br />
            <div id="noteDivInner" style="width:100%;height:100%;background-color:White">
            
            </div>
        </div>
        <div id="notesDivInnerMulti" style="width:100%;height:100%;display:none;background-color:White">
            Multiple tasks are selected
        </div>
    </div>

    <div id="projectMainDiv" class="detailsdivinfo">
        <div id="projectDiv" style="width:100%;height:100%;background-color:White">

        <!--<treegrid 
        Data_Url="../../_vti_bin/WorkPlanner.asmx" Data_Method="Soap" Data_Function="Execute" Data_Namespace="workengine.com" Data_Param_Functionname="GetProjectInfo" Data_Param_Dataxml="<%=sPlannerDataParam %>"
        >
        </treegrid>-->

        </div>
    </div>

    <div id="viewNameDiv" style="display:none;width:200;padding:10px">

        View Name:<br />
        <input type="text" class="ms-input" name="viewname" id="viewname" onkeydown="CancelBubbling(this, event);" onkeypress="CancelBubbling(this, event);" /><br /><br />
        <input type="checkbox" name="chkViewDefault" id="chkViewDefault" /> Default View <br /><br />
        <input type="button" value="OK" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, document.getElementById('viewname').value + '|' + document.getElementById('chkViewDefault').checked); return false;" class="ms-ButtonHeightWidth" style="width:100px" target="_self" /> &nbsp;

       <input type="button" value="Cancel" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel, 'Cancel clicked'); return false;" class="ms-ButtonHeightWidth" style="width:100px" target="_self" />  
    
    </div>

    <div id="addResourceDiv" style="display:none;width:200;padding:10px">
        Select Resource:<br /><select class="ms-input" name="newresourceslct" id="newresourceslct" size="10" style="width:280px" multiple="multiple"></select><br /><br /><input type="button" value="OK" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, document.getElementById('newresourceslct')); return false;" class="ms-ButtonHeightWidth" style="width:100px" target="_self" /><input type="button" value="Cancel" onclick="    SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel, 'Cancel clicked'); return false;" class="ms-ButtonHeightWidth" style="width:100px" target="_self" />  
    </div>

    <div id="saveTemplateDiv" style="display:none;width:200;padding:10px">
        Template Name: <input type="text" id="txtTemplate" onkeydown="CancelBubbling(this, event);" onkeypress="CancelBubbling(this, event);"/><br /><br />
        Template Descripton: <br />
        <textarea cols="20" rows="3" id="txtTDescription" onkeydown="CancelBubbling(this, event);" onkeypress="CancelBubbling(this, event);"></textarea><br /><br />
        
        <input type="button" value="OK" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, document.getElementById('txtTemplate').value + '`' + document.getElementById('txtTDescription').value); return false;" class="ms-ButtonHeightWidth" style="width:100px" target="_self" /> &nbsp;<input type="button" value="Cancel" onclick="    SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel, 'Cancel clicked'); return false;" class="ms-ButtonHeightWidth" style="width:100px" target="_self" />
    </div>

    <div id="divExternalLinkAccept" style="display:none;width:580px;padding:10px">
        <div style="padding: 10px">
            The following external tasks have been either updated or added. Select any tasks you would like to reject and click ok to continue.
        </div>
        <div id="divExternalLinkAcceptTree" style="width:580px;height:350px">
            
        </div>
        <div style="padding: 10px;text-align:right">
            <input type="button" class="ms-ButtonHeightWidth" value="OK" onclick="AcceptExternal();SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, '');"/>
        </div>
    </div>

    <div id="addlinkdiv" style="display:none;width:200;padding:10px">

        Link Type:
        <select name="slctAddLinkType" id="slctAddLinkType">
            <option value="FS">FS (Finish-to-Start)</option>
            <option value="FF">FF (Finish-to-Finish)</option>
            <option value="SS">SS (Start-to-Start)</option>
            <option value="SF">SF (Start-to-Finish)</option>
        </select><br /><br />

        Lag Time (Days): <input type="text" class="ms-input" name="txtAddLinkLag" id="txtAddLinkLag" onkeydown="CancelBubbling(this, event);" onkeypress="CancelBubbling(this, event);"/>
        <br /><br />
        <input type="button" value="Add Link" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, document.getElementById('slctAddLinkType').value + '|' + document.getElementById('txtAddLinkLag').value); return false;" class="ms-ButtonHeightWidth" style="width:100px" target="_self" /> &nbsp;
        <input type="button" value="Cancel" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel, 'Cancel clicked'); return false;" class="ms-ButtonHeightWidth" style="width:100px" target="_self" />  
    
    </div>

    <div id="addLinkTableDiv" style="display:none;width:100%;height:100%">
        <div id="addLinkTableDivTree" style="width:280px;height:380px;float:left;padding:10px;">
            <!--<treegrid 
            Data_Url="BlankTable.xml"
            Layout_Url="../../_vti_bin/WorkPlanner.asmx" Layout_Method="Soap" Layout_Function="Execute" Layout_Namespace="workengine.com" Layout_Param_Functionname="GetAddLinksLayout" Layout_Param_Dataxml="<%=sPlannerLayoutParam %>"
            >
            </treegrid>-->
       </div>
       <div style="width:220px;height:200px;padding:0px;float:right;padding:10px" >
            <br />
            Link Type:<br />
            <select name="slctAddNewLinkType" id="slctAddNewLinkType">
                <option value="FS">FS (Finish-to-Start)</option>
                <option value="FF">FF (Finish-to-Finish)</option>
                <option value="SS">SS (Start-to-Start)</option>
                <option value="SF">SF (Start-to-Finish)</option>
            </select><br /><br />

            Lag Time (Days): <br />
            <input type="text" class="ms-input" name="txtAddNewLinkLag" id="txtAddNewLinkLag"/>
            <br /><br />
            <input type="button" value="Add Link" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, document.getElementById('slctAddNewLinkType').value + '|' + document.getElementById('txtAddNewLinkLag').value); return false;" class="ms-ButtonHeightWidth" style="width:100px" target="_self" /> &nbsp;
            <input type="button" value="Cancel" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel, 'Cancel clicked'); return false;" class="ms-ButtonHeightWidth" style="width:100px" target="_self" />  
        </div>
    </div>
    

    <script language="javascript">    

        bAgile = <%=bAgile.ToString().ToLower() %>;

        var parentDiv = document.getElementById("parentId");

        var dhxLayout;

        var detailLayout;

        var dhxTabbar;

        var bUseFolders = false;//<%=bUseFolders.ToString().ToLower() %>;

        var sWebUrl = "<%=sWebUrl %>";

        var viewObject = {
        <%=sViewObject %>
        }; 

        var oChoiceFields = {
        <%=sChoiceFields %>
        };

        var oDefaults = {
        <%=sDefaults %>
        };

        var oTaskUserFields = [<%=sTaskUserFields %>];

        var oProjectUserFields = [<%=sProjectUserFields %>];

        var oBaselineFields = {
        <%=sBaselineFields %>
        };

        var oRollUp = {
        <%=sRollUp %>
        };

        var oRollDown = {
        <%=sRollDown %>
        };


        var editor;

        var oAttachedLists = [<%=sAttachedLists %>];
        var oAttachedDocLibs = [<%=sAttachedDocLibs %>];

        var bSummaryRollup = <%=sSummaryRollup%>;

        var sSource = "<%=sSource %>";

        var sPlannerID = "<%=sPlannerID%>";
        var sItemID = <%=sItemID%>;
        var sProjectName = "<%=sProjectName.Replace("\"","\\\"")%>";

        var iDefaultTaskType = <%=iTaskType %>;

        var curTree = 0;
        var tdPctFull;
        var tdPctEmpty;

        var sUpdates = "";

        var EPKCost = <%=EPKCost %>;
        var EPKResPlan = <%=EPKResPlan %>;

        var sWebId = "<%=sWebId %>";
        var sProjectListId = "<%=sProjectListId %>";
        var sTaskListId = "<%=sTaskListId %>";

        var oShowAssignments = false;

        var oldVal;
     
        var oldWork;

        var bNewRowHasChanged = false;
        var bNewRowEnter = false;

        var sBaselineDate = "<%=sBaselineDate %>";

        var MouseDownGrid = "";

        var bLoading = true;
        var bRendering = true;
        var disabledTab = false;

        var CanLinkExternal = <%=CanLinkExternal %>;

    oLinkedTasks = [ <%=sLinkedTasks %>];

        bCalcCost = <%=bCalcCost.ToString().ToLower() %>;
        bCalcWork = <%=bCalcWork.ToString().ToLower() %>;

        oResourceList = { <%=sResourceList %> };

        iWorkHours = <%=iWorkHours.ToString() %>
    
        try
        {
            document.getElementById('expandIcon').parentNode.style.display = 'none';
        }catch(e){}
        function doOnLoad() {    
            //========================
            folderCell = "a";
            plannerCell = "b";
            //allocCell = "c";

        <% if(bAgile){%>
            dhxLayout = new dhtmlXLayoutObject("parentId", "4H", "dhx_blue"); 
            agileCell = "c";
            detailsCell = "d";
        <%}else{%>
        
            dhxLayout = new dhtmlXLayoutObject("parentId", "3W", "dhx_blue"); 
            agileCell = "";
            detailsCell = "c";

            //dhxLayout = new dhtmlXLayoutObject("parentId", "3W", "dhx_blue"); 
            //detailsCell = "c";
        <%} %>

            dhxLayout.cells(folderCell).attachObject("folderDiv");
            dhxLayout.cells(folderCell).setText("Folders");
            dhxLayout.cells(folderCell).setWidth(250);

            dhxLayout.cells(plannerCell).setText("");
            dhxLayout.cells(plannerCell).attachObject("workplannerDiv");
            dhxLayout.cells(plannerCell).hideHeader();

            dhxLayout.cells(detailsCell).setText("Details");
            dhxLayout.cells(detailsCell).attachObject("detailDivMain");
            dhxLayout.cells(detailsCell).setWidth(300);
            dhxLayout.cells(detailsCell).fixSize(true, false);

        <% if(bAgile){%>
            dhxLayout.cells(agileCell).attachObject("agileDiv");
            dhxLayout.cells(agileCell).setText("Backlog");
            
        <%} %>
            
            //dhxLayout.cells(allocCell).attachObject("allocDiv");
            //dhxLayout.cells(allocCell).setText("Resource Allocation");

        <%if(!bUseFolders){ %>
            //dhxLayout.cells("a").collapse();
            var cell = dhxLayout.cells(folderCell);
            cell.collapse();
            cell.style.display = "none";
            <%}else{ %>
            
        <%} %>
            dhxTabbar = new dhtmlXTabBar("detailDivTab", "top");

            dhxTabbar.setImagePath("dhtml/xtab/imgs/");
            dhxTabbar.setSkin("dhx_skyblue");

            dhxTabbar.addTab("t1", "<span class='task-detail-icons icon-pencil-5'></span>", "30px");
            dhxTabbar.setContent("t1", "detailDiv");
            dhxTabbar.disableTab("t1");

            document.getElementById("assignmentsDiv").style.display="";

            dhxTabbar.addTab("t2", "<span class='task-detail-icons icon-users-4'></span>", "30px");
            dhxTabbar.setContent("t2", "assignmentsDiv");
            dhxTabbar.disableTab("t2");
            document.getElementById("linksDiv").style.display="";

            dhxTabbar.addTab("t3", "<span class='task-detail-icons icon-link-2'></span>", "30px");
            dhxTabbar.setContent("t3", "linksDiv");
            dhxTabbar.disableTab("t3");
            document.getElementById("notesDiv").style.display="";

            dhxTabbar.addTab("t5", "<span class='task-detail-icons icon-file-2'></span>", "30px");
            dhxTabbar.setContent("t5", "notesDiv");
            dhxTabbar.disableTab("t5");
            dhxTabbar.addTab("t4", "<span class='task-detail-icons icon-notebook'></span>", "30px");
            dhxTabbar.setContent("t4", "projectMainDiv");

            dhxTabbar.setTabActive("t4");
            disabledTab = true;
            setHeight();

            try{
                document.getElementById("agileDiv").style.display="";
            
            }catch(e){}

            //if(!bAgile)
            //    document.getElementById("allocDiv").style.display="";

            sm("dlgSplash", 450, 300);
        
            bLoading = false;

            document.getElementById("divExternalLinkAccept").style.display="";

            if(iDefaultTaskType == 0)
            {
                document.getElementById("slcttasktype").selectedIndex = "0";
            }
            else
            {
                document.getElementById("slcttasktype").selectedIndex = "1";
            }
        

            setTimeout("CreateTrees()", 100);
        

        
        }
        ExecuteOrDelayUntilScriptLoaded(UnpinNav, 'EPMLive.Navigation.js');
        function UnpinNav()
        {
            window.epmLiveNavigation.unpin();

        }

        function CreateTrees()
        {
            <%--TreeGrid( { Data:{ Url:"../../_vti_bin/WorkPlanner.asmx", Method:"Soap",Function:"Execute",Namespace:"workengine.com",Param:{Functionname:"GetAllocationLayout",Dataxml:"<%=sPlannerDataParam %>" } }, SuppressMessage:2, Debug:""}, "allocDiv" ); --%>
        
        CreateBasicTree("GetAddLinksLayout","addLinkTableDivTree");
        CreateBasicTree("GetDetailLayout","detailTree");
        CreateBasicTree("GetAssignmentLayout","assignmentsDivTree");
        CreateBasicTree("GetLinksLayout","linksDivTree");
        CreateBasicTree("GetExternalLinkLayout","divExternalLinkAcceptTree");

        TreeGrid( { Data:{ Url:"../../_vti_bin/WorkPlanner.asmx", Method:"Soap",Function:"Execute",Namespace:"workengine.com",Param:{Functionname:"GetProjectInfo",Dataxml:"<%=sPlannerDataParam %>" } }, SuppressMessage:1, Debug:"" }, "projectDiv" ); 


        TreeGrid(   { 
            Layout:{ Url:"../../_vti_bin/WorkPlanner.asmx", Method:"Soap",Function:"Execute",Namespace:"workengine.com",Param:{Functionname:"GetLayout",Dataxml:"<%=sPlannerLayoutParam %>" } } ,
            Upload:{ Url:"SaveWorkPlanner.aspx", Type:"Body",Format:"Internal",Data:"TGData",Flags:"Accepted,AllCols,NoIO,Defaults",Param:{Dataxml:"<%=sPlannerDataParam %>"} } ,
            Data:{ Url:"../../_vti_bin/WorkPlanner.asmx", Method:"Soap",Function:"Execute",Namespace:"workengine.com",Param:{Functionname:"GetTasks",Dataxml:"<%=sPlannerDataParam %>" } }, 
            Debug:"Error",Export:{Url:"PlannerExcelExport.aspx"}, SuppressMessage:1
        }, 
            "workplannerDiv" );

        <%=agileDiv %>

        
    }

        function CreateBasicTree(functionname, div)
        {
            TreeGrid( { Data:{ Url:"BlankTable.xml" }, Layout:{Url: "../../_vti_bin/WorkPlanner.asmx",Method:"Soap",Function:"Execute",Namespace:"workengine.com",Param:{Functionname:functionname,Dataxml:"<%=sPlannerLayoutParam %>" } }, SuppressMessage:1 }, div ); 
        }

        _spBodyOnLoadFunctionNames.push("doOnLoad");



        function setHeight(a, b, c) {
            //dhxLayout.cells("b").setHeight((getHeight() - getTop(document.getElementById("parentId"))));
            document.getElementById("parentId").style.height = (getHeight() - getTop(document.getElementById("parentId")) - 20) + "px";

            document.getElementById("parentId").style.width = (getWidth() - 85) + "px";
        
            dhxLayout.setSizes();

            if(bLoading)
            {
                if(bAgile)
                {
                    var gHeight = (getHeight() - getTop(document.getElementById("parentId")) - 20) / 3;

                    dhxLayout.cells("b").setHeight(gHeight);
                    //dhxLayout.cells("c").setHeight(gHeight);
                }
                else
                {
                    var gHeight = (getHeight() - getTop(document.getElementById("parentId")) - 20) / 2;

                    dhxLayout.cells("b").setHeight(gHeight);
                    //dhxLayout.cells("c").setHeight(gHeight);
                }

                dhxLayout.setSizes();

                var divCover = document.getElementById("divCover");
                divCover.style.left = 0;
                divCover.style.top = 0;
                divCover.style.width = (getWidth() - 20) + "px";
                divCover.style.height = (getHeight() - getTop(document.getElementById("parentId")) - 20) + "px";
            }
        }

    

        function getHeight() {
            var scnHei;
            if (self.innerHeight) // all except Explorer
            {
                //scnWid = self.innerWidth;
                scnHei = self.innerHeight;
            }
            else if (document.documentElement && document.documentElement.clientHeight) {
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

        function getWidth() {
            var scnWid;
            if (self.innerHeight) // all except Explorer
            {
                scnWid = self.innerWidth;
                //scnHei = self.innerHeight;
            }
            else if (document.documentElement && document.documentElement.clientHeight) {
                scnWid = document.documentElement.clientWidth;
                //scnHei = document.documentElement.clientHeight;
            }
            else if (document.body) // other Explorers
            {
                scnWid = document.body.clientWidth;
                //scnHei = document.body.clientHeight;
            }
            return scnWid;
        }

        if (window.addEventListener)
            window.addEventListener('resize', setHeight, false);
        else if (window.attachEvent)
            window.attachEvent('onresize', setHeight);

        Grids.OnTestConstraints = function(grid, row, col, type, change, d1, d2)  
        {   
            if(type == "main" && d1 != null && d2 != null)
            {
                if(d1 < grid.Cols["G"].GanttBase)
                {
                    if(confirm("You are trying to set the Task Start Date earlier than the Project Start Date. Would you like to modify the Project Start Date"))
                    {
                        MoveProject();
                    }
                }
            }
 
            return change;
        }

        Grids.OnAutoFillFinish = function (grid, r1, c1, r2, c2, rdir, cdir) {
        
            if(c1 == c2 && (c1 == "AssignedTo" || c1 == "StartDate" || c1 == "DueDate"))
            {
                grid.ActionCalcOff();
                var row = r1;
        
                row = grid.GetNext(row);

                while(row && row.id != r2.id)
                {
                    if(row.Def.Name == "Task")
                        SetTaskAssignments(row);

                    if(rdir == 0)
                        row = grid.GetNext(row);
                    else
                        row = grid.GetPrev(row);                
                }

                SetTaskAssignments(r2);

                grid.ActionCalcOn();
            }
        }

        Grids.OnLoaded = function(G){ 
            G.Lang.Format.DecimalSeparator='<%=DecimalSeparator %>';
        G.Lang.Format.GroupSeparator='<%=GroupSeparator %>';
        G.Lang.Format.InputDecimalSeparators='<%=DecimalSeparator %>';
        G.Lang.Format.InputGroupSeparators='<%=GroupSeparator %>';
    }

    Grids.OnMouseDown = function(grid, row, col, x, y, event)
    {
        if(grid)
            MouseDownGrid = grid.id;
    }

    Grids.OnCanDrop = function(grid, row, togrid, torow, type, copy) 
    {
        if(torow.id == 0)
            return 0;

        return type;
    }

    Grids.OnScroll = function(grid, hpos1, vpos, oldhpos1, oldvpos, hpos0, oldhpos0, hpos2, oldhpos2)
    {
        if(grid.id == "WorkPlannerGrid" && grid.id==MouseDownGrid)
        {
            var left = grid.GetScrollLeft(2);
            //Grids.AllocationGrid.SetScrollLeft(left, 2);

            
        }
        else if(grid.id == "AllocationGrid" && grid.id==MouseDownGrid)
        {
            var left = grid.GetScrollLeft(2);
            Grids.WorkPlannerGrid.SetScrollLeft(left, 2);
        }
    }
    
    Grids.OnGanttChanged = function(grid, row, col, item, new1, new2, old1, old2, action) 
    {
    
        if(grid.id == "WorkPlannerGrid")
        {
            DoAssignmentRollDown(grid, row, 0, "StartDate");
            DoAssignmentRollDown(grid, row, 0, "DueDate");
            DoAssignmentRollDown(grid, row, 0, "Duration");
            if(row.Def && row.Def.Name == "Iteration")
            {
                RollDown(row, "StartDate");
                RollDown(row, "DueDate");
                RollDown(row, "Duration");
            }

            CalculateAssignmentCosts(grid, row);
        }
    }

    Grids.OnCorrectDependencies = function(grid, A, R, error )
    {
    
        var g = grid;

        setTimeout("RollupSummaryField('DueDate')", 1000);
    }


    Grids.OnAfterSave = function (grid, result, autoupdate) {
        HideTDialog();
        CheckUpdates();
        RefreshCommandUI();
    }

    Grids.OnColumnsChanged = function(grid, cols, count)
    {
        var lastCol = grid.GetLastCol("1");
        
        for(var col in cols)
        {
            if(cols[col])
            {
                grid.MoveCol(col, 1, true, 0);
            }
        }
        //MoveCol               (string col, string tocol, bool right, bool noshow = 0) or (string col, int sec, bool last, bool noshow = 0) 
    } 

    Grids.OnGetColor = function(grid, row, col, r, g, b, edit)  
    {
        return GetColor(grid, row, col, r, g, b, edit);
    }

    Grids.OnGetClass = function(grid, row, col, classname)
    {
        return GetCssClass(grid, row, col, "erroroncell");
    }
    
    Grids.OnTip = function(grid, row, col, tip, cleintx, clienty, x, y)
    {
        return GetToolTip(grid, row, col, tip, 5, 5, 5, 5)
    }
    
    Grids.OnRenderFinish = function (grid) {
    
        curTree++;
        var pct = curTree/Grids.length*100;

        document.getElementById("tdPctFull").style.display = "";
        document.getElementById("tdPctFull").style.width = parseInt(pct) + "%";

        if(curTree <= Grids.length)
            SetSplashText("Loading " + curTree + " of " + Grids.length);

        if(curTree == Grids.length)
        {

            var WGrid = Grids.WorkPlannerGrid;

            var AGrid = Grids.AgileGrid;

            CheckPublishStatus();
            CheckUpdates();

            WGrid.Actions.OnClickSort='SortAscOne OR SortDescOne'; 
            WGrid.Actions.OnClickSortUp='SortAscOne'; 
            WGrid.Actions.OnClickSortDown='SortDescOne'; 
            WGrid.Actions.OnShiftClickSort='SortAscAppend OR SortDescAppend'; 
            WGrid.Actions.OnShiftClickSortUp='SortAscAppend'; 
            WGrid.Actions.OnShiftClickSortDown='SortDescAppend';

            //CopyAllSummaryFields();

            WGrid.SetAttribute(WGrid.GetRowById("0"), "Title", "HtmlPrefix", "", 1, 0)

            SetSplashText("Initializing Gantt...");
            setTimeout("InitGantt()", 100);

        }
    }
    
    Grids.OnZoom = function(grid, zoom, FirstDate, LastDate) 
    {
        if(grid.id == "WorkPlannerGrid" && !bRendering)
        {

            //var N = Grids.AllocationGrid;
            //N.ZoomTo(FirstDate,LastDate,grid.Cols.G.Width);
            //setTimeout(function(){N.SetScrollLeft(grid.GetScrollLeft(2),2);},100);

        }
    }


    Grids.OnEnterEdit = function(grid, row, col)
    {
        if(grid.id == "WorkPlannerGrid" )
        {
            if(row.id == "NewTask")
            {
                var newrow = DoNewRow();
                    
                //hideNonFolders(newrow);

                grid.SetScrollTop(99999);

            }
            else
            {
                EnterButton(grid);
            }
        }

        if(grid.id == "AgileGrid" )
        {
            if(row.id == "NewTask")
            {
                var newrow = DoNewRowA(true);
                    
                //hideNonFolders(newrow);
                
                grid.SetScrollTop(99999);

            }
            else
            {
                EnterButtonA(grid);
            }
        }
    }

    Grids.OnKeyDown = function(grid, key, event, name, prefix)         
    {
        if(grid.id == "WorkPlannerGrid")
        {
            if(key == 13)
            {
                EnterButton(grid);
                return true;
            }
            if(key == 45)
            {
                NewTask(false, false, true);
                return true;
            }
            if(key == 46)
            {
                DeleteTasks();
                return true;
            }
        }
    }

    Grids.OnSelect = function(grid, row, deselect)
    {
        if(disabledTab == true)
        {
            dhxTabbar.enableTab("t1");
            dhxTabbar.enableTab("t2");
            dhxTabbar.enableTab("t3");
            dhxTabbar.enableTab("t5");
            dhxTabbar.enableTab("t1");
            disabledTab = false;
        }
        if(deselect && grid.FRow && grid.FRow.id == row.id)
        {
            return false;
        }
        selRows = grid.GetSelRows();
        if(selRows.length > 0)
        {
            if(deselect == 0 && selRows.length >= 1)
            {
                hideDetails("Multiple Tasks Are Selected.");
            }
            else if(deselect == 1 && selRows.length == 2)
            {
                //grid.Focus(row);
                showDetails();
            }
        }
        else
        {
            var cId = null;
            try
            {
                cId = grid.FRow.id;
            }catch(e){}
            if(row.id != cId)
                grid.Focus(row);
            showDetails();
        }

        RefreshCommandUI();
    }

    Grids.OnFocus = function (grid, row, col, orow, ocol, pagepos) {

        Grids.WorkPlannerDetail.MainTag.style.display = "";
        
        if (grid.id == "WorkPlannerGrid" || grid.id == "AgileGrid") {
            
            if(row.id == "NewTask" && grid.GetValue(row, "Title") == "New Item")
            {
                grid.SetValue(row, "Title", "", 1, 0);
            }

            if(orow != null && orow.id == "NewTask")
            {
                if(bNewRowHasChanged && (orow.id != row.id))
                {
                    DoNewRow(grid.id == "AgileGrid");
                }
                else if(grid.GetValue(orow, "Title") == "")
                {
                    grid.SetValue(orow, "Title", "New Item", 1, 0);
                }
            }

            var dGrid = Grids.WorkPlannerDetail;

            for (var col in grid.Cols) {
                var C = grid.Cols[col];

                try {
                    dGrid.SetValue(dGrid.GetRowById(C.Name), "V", grid.GetValue(row, C.Name), 1);
                    dGrid.SetAttribute(C.Name, "V", "CanEdit", grid.GetAttribute(orow, C, "CanEdit"), true, false);
                } catch (e) { }
            }
            
            if(bAgile)
            {
                Grids.AgileGrid.SelectAllRows(false);
                Grids.WorkPlannerGrid.SelectAllRows(false);
                //Grids.AgileGrid.ActionClearSelection();
                //Grids.WorkPlannerGrid.ActionClearSelection();
            }
            else
            {
                //grid.SelectAllRows(false);
                grid.ActionClearSelection();
            }
            grid.SelectRow(row, true);

            SetDepsGrid(grid, row);
            
            PopulateResourceTable(row, true);

            document.getElementById("noteDivInner").innerHTML = grid.GetValue(row, "Notes");

            RefreshCommandUI();

        }
        if(row.id == "0" || row.id == "NewTask")
        {
            hideDetails(" ");
        }
        if(grid.id == "WorkPlannerAssignments")
        {
            RefreshCommandUI();
        }
    }

    Grids.OnCtrlS = function()
    {
        SaveWorkPlan();
    }

    
    Grids.OnRowMove = function(grid, row, oldparent, oldnext)         
    {
        if (grid.id == "WorkPlannerGrid") 
        {
            if (row.Visible && row.parentNode.Def.Name == "Task") {
                //grid.ChangeDef(grid.GetRowById(row.parentNode, "Summary", 1, 0);
                grid.ChangeDef(row.parentNode, "Summary", 1, 0);
                grid.SetValue(row.parentNode, "Summary", 1, 1, 0);
                grid.Expand(row.parentNode);
                grid.RefreshRow(row.parentNode);
            }

            if (grid.HasChildren(oldparent) == 0 && oldparent.id != "BacklogRow" && oldparent.Def.Name != "Iteration")  {  
                //grid.ChangeDef(grid.GetRowById(oldparent.id), "Task", 1, 0);
                grid.ChangeDef(oldparent, "Task", 1, 0);
                grid.SetValue(oldparent, "Summary", 0, 1, 0);
            }

            setWBSAndTaskID(grid.GetRowById("0"));

            if(bAgile)
            {
                AgileGridMove(grid, row);
            }

            RefreshCommandUI();
        }
    }
    
    Grids.OnRowDelete = function(grid, row, type)
    {
        if (grid.id == "WorkPlannerGrid") 
        {            
            try
            {
                setWBSAndTaskID(grid.GetRowById("0"));
            }catch(e){}
        }
    }
    
    Grids.OnValueChanged = function(grid, row, col, val)          
    {
    
        if(grid.id == "ProjectInfo")
            oldVal = Grids.WorkPlannerGrid.GetValue(Grids.WorkPlannerGrid.GetRowById("0"), col);

        if (grid.id == "WorkPlannerDetail") 
        {
            oldVal = grid.GetValue(row, col);

            if(col == "Work")
                oldWork = grid.GetValue(row, col);
        }

        if (grid.id == "WorkPlannerGrid") 
        {
            oldVal = grid.GetValue(row, col);

            if(col == "Work")
                oldWork = grid.GetValue(row, col);
        }

        return val;
    }
    
    Grids.OnAfterValueChanged = function (grid, row, col, val)
    {

        //=============================Project Info=====================
        if(grid.id == "ProjectInfo")
        {
            var col = row.id;
            if (col == "Start")
                col = "StartDate";
            if (col == "Finish")
                col = "DueDate";

            var o = oRollDown[row.id];

            if (o != null)
                Grids.WorkPlannerGrid.SetValue(Grids.WorkPlannerGrid.GetRowById("0"), col, val, 1);

            RollDown(Grids.WorkPlannerGrid.GetRowById("0"), col);

            //CopySummaryField(col);
        }
        //=============================WorkPlannerAssignments=====================
        if (grid.id == "WorkPlannerAssignments") 
        {
            var selRow = Grids.WorkPlannerGrid.GetRowById(row.id);

            Grids.WorkPlannerGrid.SetValue(selRow, col, val, 1);

            try{
                if(col == "Work" && selRow.parentNode.TaskType == "Individual")
                {
                    RollupAssignments(selRow.parentNode, col, "SUM");
                }
                CalculateAssignmentCosts(Grids.WorkPlannerGrid, Grids.WorkPlannerGrid.FRow);
            }catch(e){}
        }
        //=============================WorkPlannerDetail=====================
        if (grid.id == "WorkPlannerDetail") 
        {

            if(row.id == "Duration")
            {

                Grids.WorkPlannerGrid.CheckGantt(Grids.WorkPlannerGrid.FRow, "Duration", val);
                Grids.WorkPlannerGrid.CorrectDependencies(Grids.WorkPlannerGrid.FRow, "G");
                
                grid.SetValue(grid.GetRowById("DueDate"), "V", Grids.WorkPlannerGrid.GetValue(Grids.WorkPlannerGrid.FRow, "DueDate"), 1, 0);

            }
            else if(row.id == "DueDate")
            {
                RollupSummaryField("Duration");
                DoAssignmentRollDown(grid, Grids.WorkPlannerGrid.FRow, 0, "Duration");

                Grids.WorkPlannerGrid.SetValue(Grids.WorkPlannerGrid.FRow, "Duration", Grids.WorkPlannerGrid.DiffGanttDate(Grids.WorkPlannerGrid.FRow.StartDate, Grids.WorkPlannerGrid.FRow.DueDate, "d", null, null), 1, 0);
                grid.SetValue(grid.GetRowById("Duration"), "V", Grids.WorkPlannerGrid.GetValue(Grids.WorkPlannerGrid.FRow, "Duration"), 1, 0);

                SetPlannerFieldValue(Grids.WorkPlannerGrid.FRow, row.id, val, true);
            }
            else
                SetPlannerFieldValue(Grids.WorkPlannerGrid.FRow, row.id, val, true);
            
            return;

            

            if(row.id == "Duration")
            {
                Grids.WorkPlannerGrid.CheckGantt(Grids.WorkPlannerGrid.FRow, "Duration", val);
                Grids.WorkPlannerGrid.CorrectDependencies(Grids.WorkPlannerGrid.FRow, "G");
                grid.SetValue(grid.GetRowById("DueDate"), "V", Grids.WorkPlannerGrid.GetValue(Grids.WorkPlannerGrid.FRow, "DueDate"), 1, 0);
            }

            Grids.WorkPlannerGrid.SetValue(Grids.WorkPlannerGrid.FRow, row.id, val, 1);

            RollupSummaryField(row.id);

            DoAssignmentRollDown(Grids.WorkPlannerGrid, Grids.WorkPlannerGrid.FRow, 0, row.id);

            if(row.id == "AssignedTo")
            {
                SetTaskAssignments(Grids.WorkPlannerGrid.FRow);
                PopulateResourceTable(Grids.WorkPlannerGrid.FRow);
            }
            else if(row.id == "Duration")
            {
                RollupSummaryField("DueDate");
                DoAssignmentRollDown(grid, Grids.WorkPlannerGrid.FRow, 0, "DueDate");
                //CopySummaryField("DueDate");
                CheckMilestone(Grids.WorkPlannerGrid.FRow.id);
            }
            else if(row.id == "DueDate")
            {
                RollupSummaryField("Duration");
                DoAssignmentRollDown(grid, Grids.WorkPlannerGrid.FRow, 0, "Duration");

                Grids.WorkPlannerGrid.SetValue(Grids.WorkPlannerGrid.FRow, "Duration", Grids.WorkPlannerGrid.DiffGanttDate(Grids.WorkPlannerGrid.FRow.StartDate, Grids.WorkPlannerGrid.FRow.DueDate, "d", null, null), 1, 0);
                grid.SetValue(grid.GetRowById("Duration"), "V", Grids.WorkPlannerGrid.GetValue(Grids.WorkPlannerGrid.FRow, "Duration"), 1, 0);
            }
            else if(row.id == "StartDate")
            {
                RollupSummaryField("DueDate");
                DoAssignmentRollDown(grid, Grids.WorkPlannerGrid.FRow, 0, "DueDate");
            }
            else if(row.id == "Work")
            {
                CopyRemainingWork(Grids.WorkPlannerGrid, Grids.WorkPlannerGrid.FRow);
                CalculateAssignmentCosts(Grids.WorkPlannerGrid, Grids.WorkPlannerGrid.FRow);
            }
            else if(col == "Status")
                WEStatusCalculateStatus(Grids.WorkPlannerGrid, Grids.WorkPlannerGrid.FRow, val);
            else if(col == "PercentComplete")
                WEStatusCalculatePercentComplete(Grids.WorkPlannerGrid, Grids.WorkPlannerGrid.FRow, val);
            else if(col == "Complete")
                WEStatusCalculateComplete(Grids.WorkPlannerGrid, Grids.WorkPlannerGrid.FRow, val);
            else if(Grids.WorkPlannerGrid.FRow.Def.Name == "Folder")
                RollDown(Grids.WorkPlannerGrid.FRow, row.id);

            //CopySummaryField(row.id);

        }
        //=============================WorkPlannerGrid=====================
        if (grid.id == "AgileGrid") 
        {
            SetPlannerFieldValue(row, col, val);


            RefreshCommandUI();
        }
        //=============================WorkPlannerGrid=====================
        if (grid.id == "WorkPlannerGrid") 
        {

            SetPlannerFieldValue(row, col, val);

            if(col == "Work" || col == "ActualWork"){
                try {
                    CalculateWorkPercentSpent(grid, row);
                } catch (e) { }
            }

            //CopySummaryField(col);

            //grid.DoFilter();

            RefreshCommandUI();
        }
        //=============================WorkPlannerLinks=====================
        if (grid.id == "WorkPlannerLinks")
        {
            UpdateDependencies(grid);
        }
    }  
        
    
    Grids.OnRowFilter = function(grid, row, show)
    {

        if (row.Def.Name == "Assignment" && grid.id == "WorkPlannerGrid" && show)
            return HideShowAssignment(grid, row);
        
        return show;
    }
    
    Grids.OnGetExportValue = function(grid, row, col, str)                 
    {
        var val = getHTML(grid, row, col, grid.GetValue(row, col));
        if(val)
            return str + val;
    }

    Grids.OnGetHtmlValue = function(grid, row, col, val)
    {
        return getHTML(grid, row, col, val);
    } 
    
    Grids.OnAfterSectionResize = function(grid, section)  
    {
        //ResizeGantt(Grids.WorkPlannerGrid, Grids.AllocationGrid);
    }
    
    var viewNameDiv = document.getElementById("viewNameDiv");
    var addResourceDiv = document.getElementById("addResourceDiv");
    var addlinkdiv = document.getElementById("addlinkdiv");
    var addLinkTableDiv = document.getElementById("addLinkTableDiv");
    var spEditorDiv = document.getElementById("spEditor");

    </script>
    
    <div id="dlgNormal" class="dialog">
        <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <img src="./images/loader-epmlive.GIF" style="vertical-align: middle;width:50px;"/>
                    <div style="line-height:40px;font-family:'Open Sans Regular';color:#666666;font-size:14px;" id="dlgNormalText">Saving Work Plan...</div>
                </td>
            </tr>   
        </table>
    </div> 

    <div id="dlgSavingView" class="dialog">
        <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <img src="./images/loader-epmlive.GIF" style="vertical-align: middle;width:50px;"/>
                    <div style="line-height:40px;font-family:'Open Sans Regular';color:#666666;font-size:14px;" id="dlgNormalText">Saving View...</div>
                </td>
            </tr>   
        </table>
    </div> 

    <div id="divPublish" class="dialog">
        <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <img src="./images/loader-epmlive.GIF" style="vertical-align: middle;width:50px;"/>
                    <div style="line-height:40px;font-family:'Open Sans Regular';color:#666666;font-size:14px;" id="dlgNormalText">Starting Publish...</div>
                </td>
            </tr>   
        </table>
    </div> 

    <div id="dlgDeletingView" class="dialog">
        <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <img src="./images/loader-epmlive.GIF" style="vertical-align: middle;width:50px;"/>
                    <div style="line-height:40px;font-family:'Open Sans Regular';color:#666666;font-size:14px;" id="dlgNormalText">Deleting View...</div>
                </td>
            </tr>   
        </table>
    </div> 

    <div id="dlgResource" class="dialog">
        <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <img src="./images/loader-epmlive.GIF" style="vertical-align: middle;width:50px;"/>
                    <div style="line-height:40px;font-family:'Open Sans Regular';color:#666666;font-size:14px;" id="dlgNormalText">Refreshing Resources...</div>
                </td>
            </tr>   
        </table>
    </div> 

    <div id="dlgLoading" class="dialog">
        <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <H3 class="ms-standardheader">Loading Grids...</h3><br />
                    <table style="border: 1px solid black; width:100px; height:10px" cellspacing="1">
                        <tr style="height:5px;">
                            <td id="tdPctFull" style="background-color: green; display:none;"><img src="blank.gif" width="1" height="1" /></td>
                            <td><img src="blank.gif" width="1" height="1" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
                    
        </table>
    </div> 

    <div id="dlgSplash" class="dialog">


<img src="/_layouts/epmlive/images/plannersplash.png"/>
<div style="position:absolute;top:45px;left:195px;font-family:Segoe UI Light,Verdana;font-size:32px;color:#FFFFFF;width:230px;">
                <%=sPlannerName %>
</div>
<div style="position:absolute;top:180px;left:50px;display:inline;font-family:Segoe UI Light,Verdana;font-size:18px;color:#FFFFFF;width:370px;">
Name:&nbsp;&nbsp;<%=sProjectName %></div>
<div style="position:absolute;left:0px;width:430px;text-align:right;font-family:Segoe UI Light,Verdana;font-size:12px;color:#FFFFFF;top:275px;" id="divSplashInfo">Loading...</div>

</div>
        


    <div id="divCover" style="background-color: white; position: absolute; z-index: 99">

    </div>

    <script>
        initmb();
        <%if(Request["isdlg"] == "1"){%>
        document.getElementsByTagName("html")[0].className = "ms-dialog";
        <%}%>
    </script>


</asp:Panel>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
<%=sPlannerName %>: <%=sProjectName %>
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
<%=sPlannerName %>: <%=sProjectName %>
</asp:Content>
