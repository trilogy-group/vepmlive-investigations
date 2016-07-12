<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="templates.aspx.cs" Inherits="EPMLiveSynch.Layouts.epmlive.templates" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="Manage Site Templates" EncodeMethod='HtmlEncode'/>
</asp:Content>

<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	<asp:Label ID="lblTitle" runat="server" Text="Admin Synchronization"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">

<asp:Panel ID="pnlAct" runat="server" Visible ="False">
    <asp:Label ID="lblAct" runat ="Server"></asp:Label>
</asp:Panel>
<asp:Panel ID="pnlMain" runat="server">

<META HTTP-EQUIV="CACHE-CONTROL" CONTENT="NO-CACHE">
<% Response.CacheControl = "no-cache"; %>
<% Response.Expires = -1; %>

    <script language="javascript" >
        var tmpltgrid;
        function URLEncode(plaintext) {
            // The Javascript escape and unescape functions do not correspond
            // with what browsers actually do...
            var SAFECHARS = "0123456789" + 				// Numeric
					        "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + // Alphabetic
					        "abcdefghijklmnopqrstuvwxyz" +
					        "-_.!~*'()"; 				// RFC2396 Mark characters
            var HEX = "0123456789ABCDEF";

            var encoded = "";
            for (var i = 0; i < plaintext.length; i++) {
                var ch = plaintext.charAt(i);
                if (ch == " ") {
                    encoded += "+"; 			// x-www-urlencoded, rather than %20
                } else if (SAFECHARS.indexOf(ch) != -1) {
                    encoded += ch;
                } else {
                    var charCode = ch.charCodeAt(0);
                    if (charCode > 255) {
                        alert("Unicode Character '"
                                + ch
                                + "' cannot be encoded using standard URL encoding.\n" +
				                  "(URL encoding only supports 8-bit characters.)\n" +
						          "A space (+) will be substituted.");
                        encoded += "+";
                    } else {
                        encoded += "%";
                        encoded += HEX.charAt((charCode >> 4) & 0xF);
                        encoded += HEX.charAt(charCode & 0xF);
                    }
                }
            } // for

            return encoded;
        };

        function newWin(url) {
            window.open(url, '', config = 'height=500,width=800, toolbar=no, menubar=no, scrollbars=no, resizable=yes,location=no, directories=no, status=yes');
        }
        function getWidth() {
            var winW = 800;
            if (parseInt(navigator.appVersion) > 3) {
                if (navigator.appName == "Netscape") {
                    winW = window.innerWidth;
                    //winH = window.innerHeight;
                }
                if (navigator.appName.indexOf("Microsoft") != -1) {
                    winW = document.body.offsetWidth;
                    //winH = document.body.offsetHeight;
                }
            }
            return winW;
        }
        function getScrollTopPos() {
            var winW = 0;
            if (parseInt(navigator.appVersion) > 3) {
                if (navigator.appName == "Netscape") {
                    winW = window.pageXOffset;
                }
                if (navigator.appName.indexOf("Microsoft") != -1) {
                    winW = document.body.scrollTop;
                }
            }
            return winW;
        }
        function cancelAdd() {
            document.getElementById("AddNewTemplate").style.display = "none";
        }
        function syncList(listname, list) {
            var bRet;
            bRet = confirm('Are you sure you want to synchronize the ' + listname + ' list to all the subsites now?');
            if (bRet == true) {
                sm('dlgSynchronizing', 200, 100);
                var sSiteURL = document.getElementById("SiteURL").value + '/_layouts/epmlive/synch.aspx?type=list&listorurl=' + list;
                //alert(sSiteURL)
                var loader = dhtmlxAjax.post(sSiteURL, "", outputSyncResults);
            }
        }
        function outputSyncResults(loader) {
            if (loader.xmlDoc.responseText != '') {
                if (loader.xmlDoc.responseText.trim() != "Success") {
                    alert("Could not start the synchronization.");
                }
                else {
                    alert("Synchronization started. Reload page to view status.");
                }
            }
            else {
                alert("There was no response from the synch process.");
            }
            hm('dlgSynchronizing');
            window.location = 'templates.aspx';

        }
        function delList(list) {
            var bRet;
            bRet = confirm('Are you sure you want to remove the ' + list + ' list from the field synchronization? (This will not delete the list)');
            if (bRet == true) {
                window.location = 'templates.aspx?TrnxType=delete&List=' + list;
            }
        }
        function delTemplate(template) {
            var bRet;
            bRet = confirm('Are you sure you want to remove the ' + template + ' template from the enterprise synchronization? (This will not delete the template website)');
            if (bRet == true) {
                window.location = 'templates.aspx?TrnxType=delete&Template=' + template;
            }
        }
        function showRenameTemplateForm(tmpltname, url) {
            document.getElementById("selectedWebURL").value = url;
            sm('frmRenameTemplate', 250, 100);
            document.getElementById("txtTemplateName").value = tmpltname;
        }
        function renameTemplate() {
            var newname = document.getElementById("txtTemplateName").value;
            var url = document.getElementById("selectedWebURL").value + '/_layouts/epmlive/renametemplate.aspx?newname=' + newname;
            sm('dlgRenaming', 200, 100);
            var loader = dhtmlxAjax.post(url, "", outputResponse);
            window.location = 'templates.aspx';
        }
        function showSaveTemplateForm(url) {
            document.getElementById("selectedWebURL").value = url;
            sm('frmSaveTemplate', 220, 80);
        }
        function saveTemplate(yesno, url) {
            sm('dlgSaving', 200, 100);
            var url = document.getElementById("selectedWebURL").value + '/_layouts/epmlive/savetemplate.aspx?savecontent=' + yesno;
            var loader = dhtmlxAjax.post(url, "", outputResponse);
        }
        function syncTemplate(url) {
            window.location = url + '/_layouts/epmlive/templatesettings.aspx';
            //var bRet; 
            //bRet = confirm('Are you sure you want to synchronize this template to all sites based on it now?');
            //if (bRet == true)
            //{
            //sm('dlgSynchronizing',200,100);
            //var sSiteURL = document.getElementById("SiteURL").value + "/_layouts/epmlive/synch.aspx";
            //var loader = dhtmlxAjax.post(sSiteURL,"type=template&url=" + url,outputSyncResults);
            //}
        }
        function showAddListForm() {
            sm('frmAddExistingList', 350, 100);
        }
        function addList() {
            var url = document.getElementById("SiteURL").value + '/_layouts/epmlive/templates.aspx';
            var sParams = "?TrnxType=add&List=" + document.getElementById("ctl00_PlaceHolderMain_ddlLists").value;
            //var loader = dhtmlxAjax.post(url,sParams,outputResponse);
            window.location = url + sParams;
        }
        function createNewList() {
            var sSiteURL = document.getElementById("SiteURL").value;
            window.location = sSiteURL + '/_layouts/create.aspx?source=' + sSiteURL + '/_layouts/epmlive/templates.aspx';
        }
        function cancelAddList() {
            hm('frmAddExistingList');
        }
        function cancelRenameTemplate() {
            hm('frmRenameTemplate');
        }
        function cancelSaveTemplate() {
            hm('frmSaveTemplate');
        }
        function addNewTemplate() {
            var sSiteURL = document.getElementById("SiteURL").value;
            window.location = sSiteURL + '/_layouts/epmlive/createtemplate.aspx?source=' + sSiteURL + '/_layouts/epmlive/templates.aspx';
        }
        function addExistingTemplate() {
            var url = document.getElementById("SiteURL").value + '/_layouts/epmlive/templates.aspx';
            var sParams = "?TrnxType=add&TemplateID=" + document.getElementById("selectedWebID").value;
            //var loader = dhtmlxAjax.post(url,sParams,outputResponse);
            location.href = url + sParams;
        }
        function showAddExistingTemplateForm() {
            document.getElementById("grdTemplates").style.top = 0;
            document.getElementById("grdTemplates").style.left = 0;
            document.getElementById("grdTemplates").style.position = "absolute";
            document.getElementById("tblGrdTemplates").style.width = getWidth() * .985;
            document.getElementById("tblGrdTemplatesTop").style.height = (getHeight() - 315) / 2;
            document.getElementById("tblGrdTemplatesTop").style.width = getWidth() * .985;
            document.getElementById("tblGrdTemplatesBottom").style.height = (getHeight() - 315) / 2;
            document.getElementById("tblGrdTemplatesBottom").style.width = getWidth() * .985;
            tmpltgrid.loadXML(sSiteURL + '/_layouts/epmlive/gettemplatesxml.aspx?ttype=non');
        }
        function cancelAddExistingTemplate() {
            document.getElementById("grdTemplates").style.display = "none";
        }
        function outputResponse(loader) {
            if (loader.xmlDoc.responseText != '') {
                if (loader.xmlDoc.responseText.indexOf("Success") < 1) {
                    alert(loader.xmlDoc.responseText);
                }
            }
            else
                alert("There was no response from the save template process.");

            hm('dlgSaving');
            location.reload(true);
        }
        function getWidth() {
            var winW = 800;
            if (parseInt(navigator.appVersion) > 3) {
                if (navigator.appName == "Netscape") {
                    winW = window.innerWidth;
                }
                if (navigator.appName.indexOf("Microsoft") != -1) {
                    winW = document.body.offsetWidth;
                }
            }
            return winW;
        }
        function getHeight() {
            var winH = 600;
            if (parseInt(navigator.appVersion) > 3) {
                if (navigator.appName == "Netscape") {
                    winH = window.innerHeight;
                }
                if (navigator.appName.indexOf("Microsoft") != -1) {
                    winH = document.body.offsetHeight;
                }
            }
            return winH;
        }
        function getScrollTopPos() {
            var winW = 0;
            if (parseInt(navigator.appVersion) > 3) {
                if (navigator.appName == "Netscape") {
                    winW = window.pageXOffset;
                }
                if (navigator.appName.indexOf("Microsoft") != -1) {
                    winW = document.body.scrollTop;
                }
            }
            return winW;
        }
        function cancelAdd() {
            document.getElementById("AddEditList").style.display = "none";
        }
        function validateData() {
            // takes out the single quotes (') since the edit menu javascript will not work with it
            document.getElementById("ctl00$PlaceHolderMain$txtAddSection").value = document.getElementById("ctl00$PlaceHolderMain$txtAddSection").value.replace(/'/g, "");
        }

    </script>
    <link rel="stylesheet" href="/_layouts/epmlive/modal/modal.css" type="text/css" />
    <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.css"/>
    <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid_skins.css"/>
    <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxcommon.js"></script>
    <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.js"></script>
    <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxgridcell.js"></script>
    <script src="/_layouts/epmlive/DHTML/xtreegrid/dhtmlxtreegrid.js"></script>
    <script type="text/javascript" src="/_layouts/epmlive/modal/modal.js"></script>
    <script src="/_layouts/epmlive/DHTML/dhtmlxajax.js"></script>
    <asp:Panel ID="Panel1" runat="server" Visible="true" Width="100%">
        <table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
            <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">List Synchronization</h3></td></tr>
        </table>
        <SharePoint:SPGridView runat="server"
	     ID="gvLists"
	     AutoGenerateColumns="false"
	     DataKeyNames="ListName"
	     OnRowDataBound="gvLists_RowDataBound" width="600">
        <Columns>
            <SharePoint:SPBoundField DataField="ListName" HeaderText="List Name" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="left" AccessibleHeaderText="List Name" ItemStyle-Width="120" ></SharePoint:SPBoundField>
            <SharePoint:SPBoundField DataField="EditLink" HeaderText="Edit List" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="center" AccessibleHeaderText="Edit" ItemStyle-Width="50"></SharePoint:SPBoundField>
            <SharePoint:SPBoundField DataField="SyncOptions" HeaderText="Sync Options" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="center" AccessibleHeaderText="Sync Options" ItemStyle-Width="80" ></SharePoint:SPBoundField>
            <SharePoint:SPBoundField DataField="DeleteLink" HeaderText="Remove" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="center" AccessibleHeaderText="Remove" ItemStyle-Width="50" ></SharePoint:SPBoundField>
            <SharePoint:SPBoundField DataField="SyncLink" HeaderText="Synchronize" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="center" AccessibleHeaderText="Synchronize" ItemStyle-Width="50" ></SharePoint:SPBoundField>
            <SharePoint:SPBoundField DataField="LastSync" HeaderText="Last Sync" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="left" AccessibleHeaderText="Last Sync" ItemStyle-Width="120" ></SharePoint:SPBoundField>
            <SharePoint:SPBoundField DataField="Status" HeaderText="Status" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="left" AccessibleHeaderText="Status" ItemStyle-Width="50" ></SharePoint:SPBoundField>
            <SharePoint:SPBoundField DataField="Results" HeaderText="Sync Results" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="left" AccessibleHeaderText="Sync Results" ItemStyle-Width="350" ItemStyle-Wrap="false" ></SharePoint:SPBoundField>
	     </Columns>
	     <AlternatingRowStyle CssClass="ms-alternating" />
	     </SharePoint:SPGridView>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
		     <tr>
			    <td nowrap class="ms-descriptiontext" align="left" style="padding-top:7px;padding-left: 3px;">
			    <img src="/_layouts/images/setrect.gif" alt="" />&nbsp;
			    <a href="#" onclick="showAddListForm();">Add Existing List</a>
			    </td>
		    </tr>
		     <tr>
			    <td nowrap class="ms-descriptiontext" align="left" style="padding-top:7px;padding-left: 3px;">
			    <img src="/_layouts/images/setrect.gif" alt="" />&nbsp;
			    <a href="#" onclick="createNewList();">Create New List</a>
			    </td>
		    </tr>
		    <tr>
			    <td nowrap class="ms-descriptiontext" align="left" style="padding-top:7px;padding-left: 3px;">
			    <img src="/_layouts/images/setrect.gif" alt="" />&nbsp;
			    <a href="setsitecollsyncsettings.aspx" onclick="">Choose Sites For Synchronization</a>
			    </td>
		    </tr>
		     <tr>
			    <td nowrap class="ms-descriptiontext" align="left" style="padding-top:7px;padding-left: 3px;">
			    &nbsp;
			    </td>
		    </tr>
        </table>
        <input type="hidden" name="SiteURL" id ="SiteURL" value="<% Response.Write(sSiteUrl); %>" />
        <asp:Panel id="pnlTemplates" runat="server">
        <table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
            <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Site Templates</h3></td></tr>
        </table>
        <div id="TemplateList" style="">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        
                        <% string sServerRelativeUrl = SPContext.Current.Web.ServerRelativeUrl; %>
                        <input type="hidden" name="ServerRelativeUrl" id="ServerRelativeUrl" value="<% Response.Write(sServerRelativeUrl); %>" />
                        <script>                            _css_prefix = "/_layouts/epmlive/DHTML/xgrid/"; _js_prefix = "/_layouts/epmlive/DHTML/xgrid/"; </script>
                        <div id="grid" style="width:100%;display:none;height:300px;" ></div>
                        <div id="loadinggrid" style="width:100%;" width="100%" align="center">
                        <img src="/_layouts/images/GEARS_AN.GIF" style="vertical-align: middle;"/> Loading Items...
                        </div>
                        <input type="hidden" id="MaxListSyncDate" name="MaxListSyncDate" value="<% Response.Write(sMaxListSyncDate); %>" />
                        <script>
                            var sSiteURL = document.getElementById("SiteURL").value;
                            mygrid = new dhtmlXGridObject('grid');
                            mygrid.setImagePath('/_layouts/epmlive/DHTML/xgrid/imgs/');
                            mygrid.setSkin('modern');
                            mygrid.setImageSize(16, 16);
                            mygrid.attachEvent('onXLE', clearLoader);
                            //mygrid.enableAutoHeigth(true);
                            mygrid.init();
                            var sMaxListSyncDate = document.getElementById("MaxListSyncDate").value;
                            mygrid.loadXML(sSiteURL + '/_layouts/epmlive/gettemplatesxml.aspx?maxlistsyncdate=' + sMaxListSyncDate);

                            function clearLoader(id) {
                                document.getElementById("grid").style.display = "";
                                document.getElementById("loadinggrid").style.display = "none";
                                
                            }
                        </script>
                    </td>
                </tr>
			     <tr>
				    <td nowrap class="ms-descriptiontext" align="left" style="padding-top:7px;padding-left: 3px;">
				    <img src="/_layouts/images/setrect.gif" alt="" />&nbsp;
				    <a href="#" onclick="showAddExistingTemplateForm();">Add Existing Template</a>
				    </td>
			    </tr>
			     <tr>
				    <td nowrap class="ms-descriptiontext" align="left" style="padding-top:7px;padding-left: 3px;">
				    <img src="/_layouts/images/setrect.gif" alt="" />&nbsp;
				    <a href="#" onclick="addNewTemplate();">Add New Template</a>
				    </td>
			    </tr>
			     <!---<tr>
				    <td nowrap class="ms-descriptiontext" align="left" style="padding-top:7px;padding-left: 3px;">
				    <img src="/_layouts/images/setrect.gif" alt="" />&nbsp;
				    <a href="<% Response.Write(sSiteUrl); %>/_layouts/epmlive/setsitecollsyncsettings.aspx" >Edit Site Collection Sync Settings</a>
				    </td>--->
			    </tr>
            </table>
        </div> 
        </asp:Panel>
        <br />
        <div id="dlgRenaming" class="dialog">
            <table width="100%">
                <tr>
                    <td align="center" class="ms-sectionheader">
                        <img src="../images/GEARS_AN.GIF" style="vertical-align: middle;"/><br />
                        <H3 class="ms-standardheader">Renaming template...</h3>
                    </td>
                </tr>
                
            </table>
        </div>
        <div id="dlgSaving" class="dialog">
            <table width="100%">
                <tr>
                    <td align="center" class="ms-sectionheader">
                        <img src="../images/GEARS_AN.GIF" style="vertical-align: middle;"/><br />
                        <H3 class="ms-standardheader">Saving template...</h3>
                    </td>
                </tr>
                
            </table>
        </div>
        <div id="dlgSynchronizing" class="dialog">
            <table width="100%">
                <tr>
                    <td align="center" class="ms-sectionheader">
                        <img src="../images/GEARS_AN.GIF" style="vertical-align: middle;"/><br />
                        <H3 class="ms-standardheader">Starting Synchronization...</h3>
                    </td>
                </tr>
                
            </table>
        </div>
        <div id="frmAddExistingList" class="dialog" style="display:none;" >
            <table border="0" bgcolor="FFFFFF" width="350" cellspacing="0">
                <tr>
                    <td class="ms-vb2">Choose list:</td>
                    <td class="ms-vb2">
                        <asp:DropDownList ID="ddlLists" runat="server"></asp:DropDownList>  
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td><input type="submit" name="ctl00$PlaceHolderMain$btnAddExistingList" value="Add List" onclick="Javascript:return addList();" id="ctl00_PlaceHolderMain_btnAddExistingList" /> 
                    <input type="button" name="ctl00$PlaceHolderMain$btnCancel" value="Cancel" onclick="Javascript:return cancelAddList();" id="ctl00_PlaceHolderMain_btnCancel" /></td>
                </tr>
            </table>
        </div>
        <div id="divGrdTemplateLoading"  class="dialog ms-descriptiontext" width="100%" align="center">
            <img src="/_layouts/images/GEARS_AN.GIF" style="vertical-align: middle;"/> Loading Sites...
        </div>
        <div id="grdTemplates" style="display:none;vertical-align:middle;width:100%;height:100%;" >
            <table id="tblGrdTemplatesTop" style="background-color:Black;filter:alpha(Opacity=50);width:100%;" border="0" width="600" cellspacing="0">
                <tr>
                    <td >&nbsp;</td>
                </tr>
            </table>
            <table id="tblGrdTemplates" border="0" style="width:400px;height:300px;" cellspacing="0" style="background-color:Transparent;border-top-color:Black;border-left-color:Black;border-right-color:Black">
                <tr>
                    <td width="40%" height="300" style="background-color:Black;filter:alpha(Opacity=50);">&nbsp;</td>
                    <td width="400" height="300" style="background-color:White;" valign="top" align="center" >
                        <input type="hidden" id="selectedWebID" name="selectedWebID" value="" />
                        <script>                            _css_prefix = "/_layouts/epmlive/DHTML/xgrid/"; _js_prefix = "/_layouts/epmlive/DHTML/xgrid/"; </script>
                        <div id="grdExistingTemplates" style="width:300px;height:300px;" ></div>
                        <script>
                            var sSiteURL = document.getElementById("SiteURL").value;
                            tmpltgrid = new dhtmlXGridObject('grdExistingTemplates');
                            tmpltgrid.setImagePath('/_layouts/epmlive/DHTML/xgrid/imgs/');
                            tmpltgrid.setSkin('modern');
                            tmpltgrid.setImageSize(16, 16);
                            tmpltgrid.attachEvent('onXLE', clearTmpltLoader);
                            tmpltgrid.attachEvent('onRowSelect', setSelectedRowId);
                            tmpltgrid.init();

                            function clearTmpltLoader(id) {
                                hm('divGrdTemplateLoading');
                                document.getElementById("grdTemplates").style.display = "";
                            }
                            function setSelectedRowId(id) {
                                document.getElementById("selectedWebID").value = id;
                            }
                        </script>
                        <input type="button" class="ms-input" name="ctl00$PlaceHolderMain$btnAddExistingTemplate" value="Add Template" onclick="Javascript:return addExistingTemplate();" id="ctl00_PlaceHolderMain_btnAddExistingTemplate" /> 
                        <input type="button" class="ms-input" name="ctl00$PlaceHolderMain$btnCancelAddExistingTemplate" value="Cancel" onclick="Javascript:return cancelAddExistingTemplate();" id="ctl00_PlaceHolderMain_btnCancelAddExistingTemplate" />
                    </td>
                    <td width="40%" height="300" style="background-color:Black;filter:alpha(Opacity=50);">&nbsp;</td>
                </tr>
            </table>
            <table id="tblGrdTemplatesBottom" style="background-color:Black;filter:alpha(Opacity=50);width:100%;" border="0" width="600" cellspacing="0">
                <tr>
                    <td >&nbsp;</td>
                </tr>
            </table>
        </div>
        <div id="frmSaveTemplate" class="dialog" style="display:none;" >
            <input type="hidden" id="selectedWebURL" name="selectedWebURL" value="" />
            <table border="0" bgcolor="FFFFFF" width="200" cellspacing="0" >
                <tr>
                    <td class="ms-vb2" colspan="3" align="center" >Do you want to save this template with content?</td>
                </tr>
                <tr>
                    <td class="ms-vb2" align="center" ><input type="button" class="ms-input" name="ctl00$PlaceHolderMain$btnSaveTemplateYes" value="&nbsp;&nbsp;&nbsp;Yes&nbsp;&nbsp;&nbsp;" onclick="Javascript:return saveTemplate('yes');" id="ctl00_PlaceHolderMain_btnSaveTemplateYes" /></td>
                    <td class="ms-vb2" align="center" ><input type="button" class="ms-input" name="ctl00$PlaceHolderMain$btnSaveTemplateNo" value="&nbsp;&nbsp;&nbsp;&nbsp;No&nbsp;&nbsp;&nbsp;&nbsp;" onclick="Javascript:return saveTemplate('no');" id="ctl00_PlaceHolderMain_btnSaveTemplateNo" /></td>
                    <td class="ms-vb2" align="center" ><input type="button" class="ms-input" name="ctl00$PlaceHolderMain$btnCancelSaveTemplate" value="Cancel" onclick="Javascript:return cancelSaveTemplate();" id="ctl00_PlaceHolderMain_btnCancelSaveTemplate" /></td>
                </tr>
            </table>
        </div>
        <div id="frmRenameTemplate" class="dialog" style="display:none;" >
            <table border="0" bgcolor="FFFFFF" width="250" cellspacing="0" >
                <tr>
                    <td class="ms-vb2" colspan="2" align="center" >Enter new name:&nbsp;&nbsp;&nbsp;<input type="text" class="ms-input" name="ctl00$PlaceHolderMain$txtTemplateName" value="" id="txtTemplateName" /></td>
                </tr>
                <tr>
                    <td class="ms-vb2" align="center" ><input type="button" class="ms-input" name="ctl00$PlaceHolderMain$btnRenameTemplate" value="&nbsp;&nbsp;&nbsp;Rename&nbsp;&nbsp;&nbsp;" onclick="Javascript:return renameTemplate();" id="btnRenameTemplate" /></td>
                    <td class="ms-vb2" align="center" ><input type="button" class="ms-input" name="ctl00$PlaceHolderMain$btnCancelRenameTemplate" value="Cancel" onclick="Javascript:return cancelRenameTemplate();" id="btnCancelRenameTemplate" /></td>
                </tr>
            </table>
        </div>

<script>
    initmb();
</script>
      
   </asp:Panel> 
   
   </asp:Panel>
   
</asp:Content>