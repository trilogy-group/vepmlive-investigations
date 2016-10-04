<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editfields.aspx.cs" Inherits="EPMLiveSynch.Layouts.editfields" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ID="Content1" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="lt1" runat="server" text="Sync Options" EncodeMethod='HtmlEncode'/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageTitleInTitleArea" runat="server">
	<SharePoint:FormattedStringWithListType ID="FormattedStringWithListType1" runat="server"
		String="Sync Options:" LowerCase="false" />
    <asp:Label ID="lblListName" runat="server" Text="Label"></asp:Label>&nbsp;List
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="PlaceHolderMain" runat="server">  
<script >
    function pageRedir(url) {
        if (document.getElementById('IsDirty').value == 'true') {
            var bRet;
            bRet = confirm('You have made changes to the settings.  Clicking on this link before clicking the Done button will take you to a new page and your changes will not be saved. Are you sure you want to navigate away from this page?');
            if (bRet == true) {
                window.location = url;
            }

        }
        else {
            window.location = url;
        }
    }
    function newWin(url) {
        window.open(url, '', config = 'height=400,width=700, toolbar=no, menubar=no, scrollbars=no, resizable=yes,location=no, directories=no, status=yes');
    }
    function isDirty() {
        document.getElementById('IsDirty').value = 'true';
    }
    function showHideSyncSettingsPanel() {
        toggle('pnlDescNavSettings');
        toggle('pnlVersioningSettings');
        toggle('pnlAdvancedSettings');
        //toggle('pnlEditableFieldsSettings');
        toggle('pnlTotalSettings');
        toggle('pnlGeneralSettings');
        toggle('pnlPermissionsAndManagementSettings');
    }
    function toggle(id) {
        var state = document.getElementById(id).style.display;
        if (state == 'block') {
            document.getElementById(id).style.display = 'none';
        }
        else {
            document.getElementById(id).style.display = 'block';
        }
    }
</script>
        <table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
            <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">General Settings</h3></td></tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
	                <asp:Panel ID="pnlGeneralSettings" runat="server">
	                <wssuc:InputFormSection ID="InputFormSection1" Title="List Creation:"
		                Description=""
		                runat="server">
		                <Template_Description>
		                    Select this property to create this List in sub sites if the List does not already exist.  The List name used to create the List is specified in the next section.<br />
		                </Template_Description>
		                <Template_InputFormControls>
			                <wssuc:InputFormControl ID="InputFormControl1" LabelText="List Creation:" runat="server" width="460">
				                 <Template_Control>
		                            <table border="0" width="460">
		                                <tr>
		                                    <td class="ms-authoringcontrols">
                                                <asp:CheckBox id="chkCreateNewList" runat="server" AutoPostBack="false" ></asp:CheckBox>
		                                    </td>
		                                </tr>
		                            </table>
				                 </Template_Control>
			                </wssuc:InputFormControl>
		                </Template_InputFormControls>
	                </wssuc:InputFormSection>
	                <wssuc:InputFormSection ID="InputFormSection2" Title="List Name:"
		                Description=""
		                runat="server">
		                <Template_Description>
		                    This <% Response.Write(this.CurrentList.Title); %> List will be synchronized with all Lists that have the same name as shown on the right.  By default (recommended), the List name on the right has the same name as the List you are currently configuring; however, you may want to specify an alternate name to synchronize with this List.  If you want to specify an alternate name, please check the box to the right and specify an alternate name in the textbox.<br />
		                </Template_Description>
		                <Template_InputFormControls>
			                <wssuc:InputFormControl ID="InputFormControl2" LabelText="Enter List Name:" runat="server" width="460">
				                 <Template_Control>
		                            <table border="0" width="460">
		                                <tr>
		                                    <td class="ms-authoringcontrols">
                                                <asp:TextBox ID="txtToList" runat="server"></asp:TextBox>
		                                    </td>
		                                </tr>
		                            </table>
				                 </Template_Control>
			                </wssuc:InputFormControl>
		                </Template_InputFormControls>
	                </wssuc:InputFormSection>
	                <wssuc:InputFormSection ID="InputFormSection3" Title="List Settings:"
		                Description=""
		                runat="server">
		                <Template_Description>
		                    Check to allow synching of list settings.  &nbsp;&nbsp;&nbsp;<a href="javascript:showHideSyncSettingsPanel();" >Show/Hide Settings</a><br />
		                </Template_Description>
		                <Template_InputFormControls>
			                <wssuc:InputFormControl ID="InputFormControl3" LabelText="" runat="server" width="460">
				                 <Template_Control>
		                            <div id="pnlDescNavSettings" style="display:none;">
                                        <asp:CheckBox ID="chkSyncDescriptionAndNavSettings" Checked="true" runat="server"></asp:CheckBox>
                        			    <a href="javascript:newWin('<% Response.Write(SPContext.Current.Web.Url + "/_layouts/ListGeneralSettings.aspx?List=" + Request.QueryString["List"].ToString()); %>')" >View Description & Navigation Settings</a>
			                        </div>
				                 </Template_Control>
			                </wssuc:InputFormControl>
			                <wssuc:InputFormControl ID="InputFormControl4" LabelText="" runat="server" width="460">
				                 <Template_Control>
		                            <div id="pnlVersioningSettings" style="display:none;">
                                        <asp:CheckBox ID="chkSyncVersioningSettings" Checked="true" runat="server"></asp:CheckBox>
                        			    <a href="javascript:newWin('<% Response.Write(SPContext.Current.Web.Url + "/_layouts/LstSetng.aspx?List=" + Request.QueryString["List"].ToString()); %>')" >Versioning Settings</a>
			                        </div>
				                 </Template_Control>
			                </wssuc:InputFormControl>
			                <wssuc:InputFormControl ID="InputFormControl5" LabelText="" runat="server" width="460">
				                 <Template_Control>
		                            <div id="pnlAdvancedSettings" style="display:none;">
                                        <asp:CheckBox ID="chkSyncAdvancedSettings" Checked="true" runat="server"></asp:CheckBox>
                        			    <a href="javascript:newWin('<% Response.Write(SPContext.Current.Web.Url + "/_layouts/advsetng.aspx?List=" + Request.QueryString["List"].ToString()); %>')" >Advanced Settings</a>
			                        </div>
				                 </Template_Control>
			                </wssuc:InputFormControl>
			                <wssuc:InputFormControl ID="InputFormControl6" LabelText="" runat="server" width="460" visible="false">
				                 <Template_Control>
		                            <div id="pnlEditableFieldsSettings" style="display:none;">
                                        <asp:CheckBox ID="chkEditableFieldsSettings" Checked="true" runat="server"></asp:CheckBox>
                        			    <a href="javascript:newWin('<% Response.Write(SPContext.Current.Web.Url + "/_layouts/epmlive/EditableFields.aspx?List=" + Request.QueryString["List"].ToString()); %>')" >Editable Fields</a>
				                 </Template_Control>
			                </wssuc:InputFormControl>
			                <wssuc:InputFormControl ID="InputFormControl7" LabelText="" runat="server" width="460">
				                 <Template_Control>
		                            <div id="pnlTotalSettings" style="display:none;">
                                        <asp:CheckBox ID="chkSyncTotalSettings" Checked="true" runat="server"></asp:CheckBox>
                        			    <a href="javascript:newWin('<% Response.Write(SPContext.Current.Web.Url + "/_layouts/epmlive/totalfields.aspx?List=" + Request.QueryString["List"].ToString()); %>')" >Total Settings</a>
			                        </div>
				                 </Template_Control>
			                </wssuc:InputFormControl>
			                <wssuc:InputFormControl ID="InputFormControl8" LabelText="" runat="server" width="460">
				                 <Template_Control>
		                            <div id="pnlGeneralSettings" style="display:none;">
                                        <asp:CheckBox ID="chkSyncGeneralSettings" Checked="true" runat="server"></asp:CheckBox>
                        			    <a href="javascript:newWin('<% Response.Write(SPContext.Current.Web.Url + "/_layouts/epmlive/gridganttsettings.aspx?List=" + Request.QueryString["List"].ToString()); %>')" >General Settings</a>
			                        </div>
				                 </Template_Control>
			                </wssuc:InputFormControl>
			                <wssuc:InputFormControl ID="InputFormControl9" LabelText="" runat="server" width="460">
				                 <Template_Control>
		                            <div id="pnlPermissionsAndManagementSettings" style="display:none;">
                                        <asp:CheckBox ID="chkSyncPermissionsAndMgmtSettings" Checked="true" runat="server"></asp:CheckBox>
                        			    <a href="javascript:newWin('<% Response.Write(SPContext.Current.Web.Url + "/_layouts/listedit.aspx?List=" + Request.QueryString["List"].ToString()); %>')" >View Permission Settings</a>
			                        </div>
				                 </Template_Control>
			                </wssuc:InputFormControl>
		                </Template_InputFormControls>
	                </wssuc:InputFormSection>
	                <wssuc:InputFormSection ID="InputFormSection4" Title="List Views:"
		                Description=""
		                runat="server">
		                <Template_Description>
		                    Select the views on the right that you want synched.<br />
		                </Template_Description>
		                <Template_InputFormControls>
		                    <wssuc:InputFormControl ID="InputFormControl10" LabelText="" runat="server">
                                <Template_Control>
                                    <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.css"/>
                                    <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid_skins.css"/>
                                    <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxcommon.js"></script>
                                    <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.js"></script>
                                    <script src="/_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_filter.js"></script>
                                    <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxgridcell.js"></script>
                                    <script src="/_layouts/epmlive/DHTML/xtreegrid/dhtmlxtreegrid.js"></script>
                                    <script type="text/javascript" src="modal/modal.js"></script>
                                    <script src="DHTML/dhtmlxajax.js"></script>
                                        <% string sSiteUrl = SPContext.Current.Web.Url; %>
                                        <% string sListId = Request.QueryString["List"]; %>
                                        <input type="hidden" id="SiteURL" name="SiteURL" value="<% Response.Write(sSiteUrl); %>" />
                                        <input type="hidden" id="ListId" name="ListId" value="<% Response.Write(sListId); %>" />
                                        <input type="hidden" id="EPMLiveSynchedViews" name="EPMLiveSynchedViews" value="" />
                                        <input type="hidden" id="IsDirty" name="IsDirty" value="false" />
                                        <script>                                            _css_prefix = "/_layouts/epmlive/DHTML/xgrid/"; _js_prefix = "/_layouts/epmlive/DHTML/xgrid/"; </script>
                                        <div id="grid" style="width:600;height:300;display:none;" ></div>
                                        <div id="loadinggrid" width="600" align="center">
                                        <img src="/_layouts/images/GEARS_AN.GIF" style="vertical-align: middle;"/> Loading Items...
                                        </div>
                                        <script>
                                            var sSiteURL = document.getElementById("SiteURL").value;
                                            mygrid = new dhtmlXGridObject('grid');
                                            mygrid.setImagePath('/_layouts/epmlive/DHTML/xgrid/imgs/');
                                            mygrid.setSkin('modern');
                                            mygrid.setImageSize(16, 16);
                                            mygrid.setColAlign("left,center")
                                            mygrid.attachEvent('onXLE', clearLoader);
                                            mygrid.enableAutoHeigth(true);
                                            mygrid.enableTreeCellEdit(false);
                                            mygrid.init();
                                            mygrid.loadXML(sSiteURL + '/_layouts/epmlive/getlistviewsxml.aspx?ListId=' + document.getElementById("ListId").value);

                                            mygrid.attachEvent("onCheck", doOnCheck);

                                            function uncheckparent(rowId) {
                                                try {
                                                    var parent = mygrid.getParentId(rowId);
                                                    if (parent != '0') {
                                                        mygrid.cells(parent, 0).setValue(0);
                                                        uncheckparent(parent);
                                                    }
                                                }
                                                catch (e) {
                                                    alert(e);
                                                }
                                            }

                                            function doOnCheck(rowId, cellInd, state) {
                                                isDirty();
                                                try {
                                                    var rows = mygrid.getAllSubItems(rowId);
                                                    var arrRows = rows.split(',');
                                                    var curVal = mygrid.cells(rowId, 0).getValue();
                                                    if (arrRows != '') {
                                                        for (var i = 0; i < arrRows.length; i++) {
                                                            mygrid.cells(arrRows[i], 0).setValue(curVal);
                                                        }
                                                    }
                                                    if (curVal == '0') {
                                                        uncheckparent(rowId);
                                                    }
                                                }
                                                catch (e) {
                                                    alert(e);
                                                }
                                            }

                                            function clearLoader(id) {
                                                document.getElementById("grid").style.display = "";
                                                document.getElementById("loadinggrid").style.display = "none";
                                            }

                                            function getCheckedItems() {
                                                document.getElementById("EPMLiveSynchedViews").value = mygrid.getCheckedRows(0);
                                            }
                                       </script>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
		                                     <tr>
			                                    <td nowrap class="ms-descriptiontext" align="left" style="padding-top:7px;padding-left: 3px;">
			                                    <img src="/_layouts/images/setrect.gif" alt="" />&nbsp;
			                                    <a href="<% Response.Write(SPContext.Current.Web.Url + "/_layouts/ViewType.aspx?source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.RawUrl.ToString()) + "&List=" + Request.QueryString["List"].ToString()); %>" >Create view</a>
			                                    </td>
		                                    </tr>
	                                        <tr>
	                                            <td class="ms-authoringcontrols">
                                                    <asp:CheckBox ID="chkSyncViewGroupBySettings" runat="server"></asp:CheckBox>
                            			            Sync View Group By Settings
	                                            </td>
	                                        </tr>
                                        </table>
                                </Template_Control>
                            </wssuc:InputFormControl>
		                </Template_InputFormControls>
	                </wssuc:InputFormSection>
	                <wssuc:InputFormSection ID="InputFormSection5" Title="Enterprise Fields:"
		                Description=""
		                runat="server">
		                <Template_Description>
		                    Add or edit the enterprise fields.<br />
		                </Template_Description>
		                <Template_InputFormControls>
		                    <wssuc:InputFormControl ID="InputFormControl11" LabelText="" runat="server">
                                <Template_Control>
                                <table border="0" cellpadding="0" cellspacing="0" width="600">
                                    <tr>
                                        <td class="ms-gb">
                                        <SharePoint:SPGridView runat="server"
                                         ID="GvFields"
                                         AutoGenerateColumns="false"
                                         style="width:600"
                                         AllowSorting="True"
                                         AllowPaging="True"
                                         DataKeyNames="DisplayName"
                                         PageSize="100" OnRowDataBound="GvFields_RowDataBound">
                                        <Columns>
                                            <SharePoint:SPBoundField DataField="DisplayName" HeaderText="Column (click to edit)" HeaderStyle-Font-Bold="false" AccessibleHeaderText="Display Name" ControlStyle-Width="250" ></SharePoint:SPBoundField>
                                            <SharePoint:SPBoundField DataField="FieldType" HeaderText="Type" HeaderStyle-Font-Bold="false" ControlStyle-Width="450" ></SharePoint:SPBoundField>
                                         </Columns>
                                         <AlternatingRowStyle CssClass="ms-alternating" />
                                         </SharePoint:SPGridView>
                                         </td>
                                     </tr>
                                 </table>
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
		                             <tr>
			                            <td nowrap class="ms-descriptiontext" align="left" style="padding-top:7px;padding-left: 3px;">
			                            <img src="/_layouts/images/setrect.gif" alt="" />&nbsp;
			                            <a href="<% Response.Write(SPContext.Current.Web.Url + "/_layouts/fldNew.aspx?source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.RawUrl.ToString()) + "&List=" + Request.QueryString["List"].ToString()); %>" >Create column</a>
			                            </td>
		                            </tr>
		                             <tr>
			                            <td nowrap class="ms-descriptiontext" align="left" style="padding-top:7px;padding-left: 3px;">
			                            <img src="/_layouts/images/setrect.gif" alt="" />&nbsp;
			                            <a href="javascript:newWin('<% Response.Write(SPContext.Current.Web.Url + "/_layouts/formEdt.aspx?source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.RawUrl.ToString()) + "&List=" + Request.QueryString["List"].ToString()); %>')" >Reorder columns</a>
			                            </td>
		                            </tr>
                                </table>
                                </Template_Control>
                            </wssuc:InputFormControl>
		                </Template_InputFormControls>
	                </wssuc:InputFormSection>
	                </asp:Panel>
                </td>
            </tr>
        </table>
         <asp:Panel ID="pnlFields" runat="server" Visible="true" Width="100%">
          </asp:Panel> 
    <script>
        initmb();
    </script>
    <wssuc:ButtonSection ID="ButtonSection1" runat="server">
        <Template_Buttons>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
            <asp:Button ID="btnDone" runat="server" OnClientClick="return getCheckedItems();" Text="Save" OnClick="btnDone_Click" CssClass="ms-ButtonHeightWidth" />
            </asp:PlaceHolder>
        </Template_Buttons>
    </wssuc:ButtonSection>
</asp:Content>
