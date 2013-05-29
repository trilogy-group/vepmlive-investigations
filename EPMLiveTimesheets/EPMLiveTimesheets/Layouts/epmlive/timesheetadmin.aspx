<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="timesheetadmin.aspx.cs" Inherits="TimeSheets.timesheetadmin" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="EPM Live Timesheet Settings" EncodeMethod='HtmlEncode'/>
</asp:Content>
<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	<asp:Label ID="lblTitle" runat="server" Text="EPM Live Timesheet Settings"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to control the EPM Live timesheet settings
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">

<asp:Panel ID="pnlActivation" runat="server" Visible="false" Width="100%">
    You have not purchased or activated the Timesheet feature. Please contact sales to purchase licenses.
    <br><br><b>Sales:</b><br>
    E: <a href="mailto:sales@epmlive.com">sales@epmlive.com</a><br>
    P: 866-391-3700
</asp:Panel>
<asp:Panel ID="pnlTs" runat="server" Visible="true" Width="100%">
    
    <link rel="stylesheet" href="modal/modal.css" type="text/css" /> 
    <script type="text/javascript" src="modal/modal.js"></script>

    <link rel="STYLESHEET" type="text/css" href="dhtml/xgrid/dhtmlxgrid.css"/>
    <link rel="STYLESHEET" type="text/css" href="dhtml/xgrid/dhtmlxgrid_skins.css"/>
    <link rel="STYLESHEET" type="text/css" href="dhtml/calendar/dhtmlxcalendar.css"/>
    <link rel="STYLESHEET" type="text/css" href="dhtml/xmenu/dhtmlxmenu.css">
	<link rel="STYLESHEET" type="text/css" href="dhtml/xmenu/context.css">
	<script type="text/javascript" language="javascript" src="/_layouts/1033/form.js"></script>
	<script>	    _css_prefix = "DHTML/xgrid/"; _js_prefix = "DHTML/xgrid/"; </script>
	
    <script src="DHTML/xgrid/dhtmlxcommon.js"></script>
    <script src="DHTML/xgrid/dhtmlxgrid.js"></script>
    <script src="DHTML/xgrid/dhtmlxgridcell.js"></script>
    
    <script src="DHTML/xgrid/ext/dhtmlxgrid_splt.js"></script>
    <script src="DHTML/xgrid/ext/dhtmlxgrid_nxml.js"></script>
    <script src="DHTML/xgrid/ext/dhtmlxgrid_drag.js"></script>
    <script src="DHTML/xgrid/ext/dhtmlxgrid_keymap_access.js"></script>
    
    <script src="DHTML/xgrid/excells/dhtmlxgrid_excell_cntr.js"></script>
    <script src="DHTML/xgrid/excells/dhtmlxgrid_excell_clist.js"></script>
	<script src="DHTML/xgrid/excells/dhtmlxgrid_excell_acheck.js"></script>
	<script src="DHTML/xgrid/excells/dhtmlxgrid_excell_calendar.js"></script>	
    <script src="DHTML/xgrid/excells/dhtmlxgrid_excell_dhxcalendar.js"></script

    <script src="DHTML/calendar/dhtmlxcalendar.js"></script>

    <script src="DHTML/xtreegrid/dhtmlxtreegrid.js"></script>    
    
    <script src="DHTML/xdataproc/dhtmlxdataprocessor.js"></script>
    
    <script language="JavaScript" src="dhtml/xmenu/dhtmlxprotobar.js"></script>
	<script language="JavaScript" src="dhtml/xmenu/dhtmlxmenubar.js"></script>
	<script language="JavaScript" src="dhtml/xmenu/dhtmlxmenubar_cp.js"></script>

<div id="dlgAddPeriod" class="dialog">
            <table width="100%">
                <tr>
                    <td class="ms-sectionheader">
                        Start Date:
                    </td>
                    <td class="ms-sectionheader">
                        <SharePoint:DateTimeControl ID="dtSpStart" runat="server" DateOnly="true" ></SharePoint:DateTimeControl>
                    </td>
                </tr>
                <tr>
                    <td class="ms-sectionheader">
                        End Date:
                    </td>
                    <td class="ms-sectionheader">
                        <SharePoint:DateTimeControl ID="dtSpEnd" runat="server" DateOnly="true" ></SharePoint:DateTimeControl>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input type="button" class="ms-input" value="Add Period" onclick="doAddPeriod();" /> 
                        <input type="button" class="ms-input" value="Cancel" onclick="hm('dlgAddPeriod');" />
                    </td>
                </tr>
            </table>
        </div> 
        
        <div id="dlgAddType" class="dialog">
            <table width="100%">
                <tr>
                    <td class="ms-sectionheader">
                        Work Type Name:
                    </td>
                    <td class="ms-sectionheader">
                        <input type="text" id="txtAddType" name="txtAddType"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input type="button" class="ms-input" value="Add Work Type" onclick="doAddType();" /> 
                        <input type="button" class="ms-input" value="Cancel" onclick="hm('dlgAddType');" />
                    </td>
                </tr>
            </table>
        </div> 
	 
<asp:Panel ID="pnlTL" runat="server" Visible="false" Width="100%">
        The timesheets must be configured at the site collection level.<br /><br />
        <asp:HyperLink Text="Click Here" NavigateUrl="" runat="server" ID="hlAdmin"></asp:HyperLink> to go there now.
    </asp:Panel>
    <asp:Panel ID="pnlMain" runat="server" Visible="true" Width="100%">
        <table class="ms-toolbar" width="100%" cellpadding="3" style="height:10px">
            <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">List Settings</h3></td></tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
	        <wssuc:InputFormSection Title="Timesheet Lists"
		        Description=""
		        runat="server">
		        <Template_Description>
		            Enter the lists that timesheet tasks will be read from. Enter each list on a new line.<br /><Br />
		            Ex:<Br />
		            Issues<br />
		            Risks<br />
		            Task Center<br />
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="Lists:" runat="server">
				         <Template_Control>
                            <asp:TextBox ID="txtLists" runat="server" TextMode="MultiLine" Height="100" Width="200"></asp:TextBox>
                            <br />
                            <asp:LinkButton Text="Refresh" runat="server" ID="lnkRefresh" OnClick="lnkRefresh_Click"></asp:LinkButton>
				         </Template_Control>
			        </wssuc:InputFormControl>
		        </Template_InputFormControls>
	        </wssuc:InputFormSection>
	         <wssuc:InputFormSection Title="List Cube Data"
		        Description=""
		        runat="server">
		        <Template_Description>
		            Select the fields for each list that you would like to store for cube reporting.
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="List:" runat="server">
				         <Template_Control>
                            <asp:DropDownList ID="ddlFieldLists" runat="server" CssClass="ms-input">
                                <asp:ListItem Text="Resource" Value="Resource Center"></asp:ListItem>
                                
                            </asp:DropDownList>
				         </Template_Control>
			        </wssuc:InputFormControl>
			        <wssuc:InputFormControl LabelText="" runat="server">
                         <Template_Control>
                            <table cellpadding="5">
                                <tr>
                                    <td class="ms-authoringcontrols">
                                        Available Fields:<br />
                                        <asp:ListBox runat="server" ID="ddlListAvailableFields" SelectionMode="Multiple" Rows="10" Width="200" CssClass="ms-input"></asp:ListBox>
                                    </td>
                                    <td>
                                        <input type="button" value=" &gt; " onclick="addField();" /><br /><br />
                                        <input type="button" value=" &lt; " onclick="removeField();"/>
                                    </td>
                                    <td class="ms-authoringcontrols">
                                        Selected Fields:<br />
                                        <asp:ListBox runat="server" ID="ddlListSelectedFields" SelectionMode="Multiple" Rows="10" Width="200" CssClass="ms-input"></asp:ListBox>
                                    </td>
                                </tr>
                            </table>
                            <font size="-2">Note: For best performance, select no more than 10 fields.</font>
                         </Template_Control>
                    </wssuc:InputFormControl>
		        </Template_InputFormControls>
	        </wssuc:InputFormSection>
            <wssuc:InputFormSection Title="Timesheet Fields"
		        Description=""
		        runat="server">
		        <Template_Description>
		            The fields selected here will allow users to fill out data for each individual timesheet item.
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="" runat="server">
                         <Template_Control>
                         <asp:HiddenField ID="hdnTSFields" runat="server"></asp:HiddenField>
                            <table cellpadding="5">
                                <tr>
                                    <td class="ms-authoringcontrols">
                                        Available Fields:<br />
                                        <asp:ListBox runat="server" ID="ddlTSFieldsA" SelectionMode="Multiple" Rows="10" Width="200" CssClass="ms-input"></asp:ListBox>
                                    </td>
                                    <td>
                                        <input type="button" value=" &gt; " onclick="addTSField();" /><br /><br />
                                        <input type="button" value=" &lt; " onclick="removeTSField();"/>
                                    </td>
                                    <td class="ms-authoringcontrols">
                                        Selected Fields:<br />
                                        <asp:ListBox runat="server" ID="ddlTSFieldsS" SelectionMode="Multiple" Rows="10" Width="200" CssClass="ms-input"></asp:ListBox>
                                    </td>
                                </tr>
                            </table>
                            <font size="-2">Note: For best performance, select no more than 10 fields.</font>
                         </Template_Control>
                    </wssuc:InputFormControl>
		        </Template_InputFormControls>
	        </wssuc:InputFormSection>
	        <wssuc:InputFormSection Title="Select Non-Work List"
		        Description=""
		        runat="server">
		        <Template_Description>
		            Select the list that will be used as the Non-Work list.
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="Select a List" runat="server">
				         <Template_Control>
                            <asp:DropDownList ID="ddlNonWork" runat="server" CssClass="ms-input"/>
				         </Template_Control>
			        </wssuc:InputFormControl>
		        </Template_InputFormControls>
	        </wssuc:InputFormSection>
	         <tr>
            <td colspan="2">
                <table class="ms-toolbar" width="100%" cellpadding="3" style="height:10px">
                    <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Additional Settings</h3></td></tr>
                </table>        
            </td>
        </tr>
	        <wssuc:InputFormSection Title="Allow Unassigned Work in Timesheet"
		        Description=""
		        runat="server">
		        <Template_Description>
		            Select this option to allow users to add work to their timesheets for which they are not assigned.
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="Allow" runat="server">
				         <Template_Control>
                            <asp:CheckBox runat="server" ID="chkAllowUnassigned" />
				         </Template_Control>
			        </wssuc:InputFormControl>
		        </Template_InputFormControls>
	        </wssuc:InputFormSection>
       
	        <wssuc:InputFormSection Title="Day Definition"
		        Description=""
		        runat="server">
		        <Template_Description>
		            Use this section to determine which days to show on the timesheet and the min/max values for each day.
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="" runat="server">
				         <Template_Control>
                            <table width="300">
                                <tr>
                                    <td class="ms-authoringcontrols"><b>Day</b></td>
                                    <td class="ms-authoringcontrols" align ="center"><b>Open</b></td>
                                    <td class="ms-authoringcontrols" align ="center"><b>Min</b></td>
                                    <td class="ms-authoringcontrols" align ="center"><b>Max</b></td>
                                </tr>
                                <tr>
                                    <td class="ms-authoringcontrols">Sunday</td>
                                    <td align ="center"><asp:CheckBox ID="chkSunday" runat="server"  CssClass="ms-input"/></td>
                                    <td align ="center"><asp:TextBox ID="txtSundayMin" runat="Server" Width="50" CssClass="ms-input"/></td>
                                    <td align ="center"><asp:TextBox ID="txtSundayMax" runat="Server" Width="50" CssClass="ms-input"/></td>
                                </tr>
                                <tr>
                                    <td class="ms-authoringcontrols">Monday</td>
                                    <td align ="center"><asp:CheckBox ID="chkMonday" runat="server"  CssClass="ms-input"/></td>
                                    <td align ="center"><asp:TextBox ID="txtMondayMin" runat="Server" Width="50" CssClass="ms-input"/></td>
                                    <td align ="center"><asp:TextBox ID="txtMondayMax" runat="Server" Width="50" CssClass="ms-input"/></td>
                                </tr>
                                <tr>
                                    <td class="ms-authoringcontrols">Tuesday</td>
                                    <td align ="center"><asp:CheckBox ID="chkTuesday" runat="server"  CssClass="ms-input"/></td>
                                    <td align ="center"><asp:TextBox ID="txtTuesdayMin" runat="Server" Width="50" CssClass="ms-input"/></td>
                                    <td align ="center"><asp:TextBox ID="txtTuesdayMax" runat="Server" Width="50" CssClass="ms-input"/></td>
                                </tr>
                                <tr>
                                    <td class="ms-authoringcontrols">Wednesday</td>
                                    <td align ="center"><asp:CheckBox ID="chkWednesday" runat="server"  CssClass="ms-input"/></td>
                                    <td align ="center"><asp:TextBox ID="txtWednesdayMin" runat="Server" Width="50" CssClass="ms-input"/></td>
                                    <td align ="center"><asp:TextBox ID="txtWednesdayMax" runat="Server" Width="50" CssClass="ms-input"/></td>
                                </tr>
                                <tr>
                                    <td class="ms-authoringcontrols">Thursday</td>
                                    <td align ="center"><asp:CheckBox ID="chkThursday" runat="server"  CssClass="ms-input"/></td>
                                    <td align ="center"><asp:TextBox ID="txtThursdayMin" runat="Server" Width="50" CssClass="ms-input"/></td>
                                    <td align ="center"><asp:TextBox ID="txtThursdayMax" runat="Server" Width="50" CssClass="ms-input"/></td>
                                </tr>
                                <tr>
                                    <td class="ms-authoringcontrols">Friday</td>
                                    <td align ="center"><asp:CheckBox ID="chkFriday" runat="server"  CssClass="ms-input"/></td>
                                    <td align ="center"><asp:TextBox ID="txtFridayMin" runat="Server" Width="50" CssClass="ms-input"/></td>
                                    <td align ="center"><asp:TextBox ID="txtFridayMax" runat="Server" Width="50" CssClass="ms-input"/></td>
                                </tr>
                                <tr>
                                    <td class="ms-authoringcontrols">Saturday</td>
                                    <td align ="center"><asp:CheckBox ID="chkSaturday" runat="server"  CssClass="ms-input"/></td>
                                    <td align ="center"><asp:TextBox ID="txtSaturdayMin" runat="Server" Width="50" CssClass="ms-input"/></td>
                                    <td align ="center"><asp:TextBox ID="txtSaturdayMax" runat="Server" Width="50" CssClass="ms-input"/></td>
                                </tr>
                            </table>
				         </Template_Control>
			        </wssuc:InputFormControl>
		        </Template_InputFormControls>
	        </wssuc:InputFormSection>
	        <wssuc:InputFormSection Title="Allow Notes Per Day"
		        Description=""
		        runat="server">
		        <Template_Description>
		            Allows users to enter notes for each day per each item.
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="Allow Notes:" runat="server">
				         <Template_Control>
                            <asp:CheckBox runat="server" ID="chkAllowNotes" />
				         </Template_Control>
			        </wssuc:InputFormControl>
		        </Template_InputFormControls>
	        </wssuc:InputFormSection>
	        <wssuc:InputFormSection Title="Publisher Mapping"
		        Description=""
		        runat="server">
		        <Template_Description>
		            Use the section to determine which fields in Microsoft Project map to the Timesheet information.<br /><Br />
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="Timesheet Hours Field" runat="server">
				         <Template_Control>
                            <asp:DropDownList ID="ddlTimesheetHours" runat="server" EnableViewState="true">
                                <asp:ListItem Text="Do Not Map" Value=""></asp:ListItem>
                                <asp:ListItem Text="Number1" Value="Number1"></asp:ListItem>
                                <asp:ListItem Text="Number2" Value="Number2"></asp:ListItem>
                                <asp:ListItem Text="Number3" Value="Number3"></asp:ListItem>
                                <asp:ListItem Text="Number4" Value="Number4"></asp:ListItem>
                                <asp:ListItem Text="Number5" Value="Number5"></asp:ListItem>
                                <asp:ListItem Text="Number6" Value="Number6"></asp:ListItem>
                                <asp:ListItem Text="Number7" Value="Number7"></asp:ListItem>
                                <asp:ListItem Text="Number8" Value="Number8"></asp:ListItem>
                                <asp:ListItem Text="Number9" Value="Number9"></asp:ListItem>
                                <asp:ListItem Text="Number10" Value="Number10"></asp:ListItem>
                                <asp:ListItem Text="Number11" Value="Number11"></asp:ListItem>
                                <asp:ListItem Text="Number12" Value="Number12"></asp:ListItem>
                                <asp:ListItem Text="Number13" Value="Number13"></asp:ListItem>
                                <asp:ListItem Text="Number14" Value="Number14"></asp:ListItem>
                                <asp:ListItem Text="Number15" Value="Number15"></asp:ListItem>
                                <asp:ListItem Text="Number16" Value="Number16"></asp:ListItem>
                                <asp:ListItem Text="Number17" Value="Number17"></asp:ListItem>
                                <asp:ListItem Text="Number18" Value="Number18"></asp:ListItem>
                                <asp:ListItem Text="Number19" Value="Number19"></asp:ListItem>
                                <asp:ListItem Text="Number20" Value="Number20"></asp:ListItem>
                            </asp:DropDownList>
				         </Template_Control>
			        </wssuc:InputFormControl>
			            <wssuc:InputFormControl LabelText="Timesheet Field" runat="server">
				         <Template_Control>
                            <asp:DropDownList ID="ddlFlagField" runat="server" EnableViewState="true">
                                <asp:ListItem Text="Do Not Map" Value=""></asp:ListItem>
                                <asp:ListItem Text="Flag1" Value="Flag1"></asp:ListItem>
                                <asp:ListItem Text="Flag2" Value="Flag2"></asp:ListItem>
                                <asp:ListItem Text="Flag3" Value="Flag3"></asp:ListItem>
                                <asp:ListItem Text="Flag4" Value="Flag4"></asp:ListItem>
                                <asp:ListItem Text="Flag5" Value="Flag5"></asp:ListItem>
                                <asp:ListItem Text="Flag6" Value="Flag6"></asp:ListItem>
                                <asp:ListItem Text="Flag7" Value="Flag7"></asp:ListItem>
                                <asp:ListItem Text="Flag8" Value="Flag8"></asp:ListItem>
                                <asp:ListItem Text="Flag9" Value="Flag9"></asp:ListItem>
                                <asp:ListItem Text="Flag10" Value="Flag10"></asp:ListItem>
                                <asp:ListItem Text="Flag11" Value="Flag11"></asp:ListItem>
                                <asp:ListItem Text="Flag12" Value="Flag12"></asp:ListItem>
                                <asp:ListItem Text="Flag13" Value="Flag13"></asp:ListItem>
                                <asp:ListItem Text="Flag14" Value="Flag14"></asp:ListItem>
                                <asp:ListItem Text="Flag15" Value="Flag15"></asp:ListItem>
                                <asp:ListItem Text="Flag16" Value="Flag16"></asp:ListItem>
                                <asp:ListItem Text="Flag17" Value="Flag17"></asp:ListItem>
                                <asp:ListItem Text="Flag18" Value="Flag18"></asp:ListItem>
                                <asp:ListItem Text="Flag19" Value="Flag19"></asp:ListItem>
                                <asp:ListItem Text="Flag20" Value="Flag20"></asp:ListItem>
                            </asp:DropDownList>
				         </Template_Control>
			        </wssuc:InputFormControl>
		        </Template_InputFormControls>
	        </wssuc:InputFormSection>
	        
            <wssuc:InputFormSection Title="Allow Stop Watch"
		        Description=""
		        runat="server">
		        <Template_Description>
		            Enabling this option will give the users the ability to have a stop watch timer for timesheet rows.
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="Allow Stop Watch:" runat="server">
				         <Template_Control>
                            <asp:CheckBox runat="server" ID="chkAllowStopWatch" />
				         </Template_Control>
			        </wssuc:InputFormControl>
		        </Template_InputFormControls>

	        </wssuc:InputFormSection>
	        <wssuc:InputFormSection Title="Disable Timesheet Approvals"
		        Description=""
		        runat="server">
		        <Template_Description>
		            Use this to turn off timesheet approvals. When approvals are turned off, a submitted timesheet will immediately become approved and the hours will be sent back into the item.
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="Disable Approvals:" runat="server">
				         <Template_Control>
                            <asp:CheckBox runat="server" ID="chkDisableApprovals" />
				         </Template_Control>
			        </wssuc:InputFormControl>
		        </Template_InputFormControls>
	        </wssuc:InputFormSection>

            <wssuc:InputFormSection Title="Show Live Timesheet Hours"
		        Description=""
		        runat="server">
		        <Template_Description>
		            Select this option if you would like the timesheet hours field populate with live timesheet hours instead of approved timesheet hours.
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="Show Live Hours:" runat="server">
				         <Template_Control>
                            <asp:CheckBox runat="server" ID="chkShowLiveHours" />
				         </Template_Control>
			        </wssuc:InputFormControl>
		        </Template_InputFormControls>
	        </wssuc:InputFormSection>
	        
	        <wssuc:InputFormSection Title="Always Use Current List Data in Views"
		        Description=""
		        runat="server">
		        <Template_Description>
		            When checked the data displayed in timesheet views will always show the current data for the list item. When unchecked the data will show the data for the specified time period.<br /><br />
		            <b>Note: for fields to show up in the views, they must be specified in the cube fields above.</b>
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="Show Current Data:" runat="server">
				         <Template_Control>
                            <asp:CheckBox runat="server" ID="chkCurrentData" />
				         </Template_Control>
			        </wssuc:InputFormControl>
		        </Template_InputFormControls>
	        </wssuc:InputFormSection>
	        
	        <wssuc:ButtonSection runat="server">
		        <Template_Buttons>
			        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
				        <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Button1_Click" Text="Save Settings" id="Button1" accesskey="" Width="150"/>
			        </asp:PlaceHolder>
		        </Template_Buttons>
	        </wssuc:ButtonSection>    
	        <tr><td colspan="2">
	            <table class="ms-toolbar" width="100%" cellpadding="3" style="height:10px">
                    <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Timesheet Work Types</h3></td></tr>
                </table>
	        </td></tr>
	        <tr><td colspan="2">
	           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                    OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" GridLines="None" CellPadding="0" CellSpacing="0">
                        <Columns>
                            <asp:BoundField DataField="tstype_id" HeaderText="ID" HeaderStyle-CssClass="ms-vh2-nofilter" ItemStyle-CssClass="ms-vb2"/>
                            <asp:BoundField DataField="tstype_name" HeaderText="Name" HeaderStyle-CssClass="ms-vh2-nofilter" ItemStyle-CssClass="ms-vb2"/>
                            <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="top" HeaderStyle-CssClass="ms-vh2-nofilter" ItemStyle-CssClass="ms-vb2">
                                 <ItemTemplate>
                                   <asp:LinkButton ID="LinkButton2" 
                                     CommandArgument='<%# Eval("tstype_id") %>' 
                                     CommandName="Edi" runat="server">
                                     Edit</asp:LinkButton>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="top" HeaderStyle-CssClass="ms-vh2-nofilter" ItemStyle-CssClass="ms-vb2">
                                 <ItemTemplate>
                                   <asp:LinkButton ID="LinkButton1" 
                                     CommandArgument='<%# Eval("tstype_id") %>' 
                                     CommandName="Del" runat="server">
                                     Delete</asp:LinkButton>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="ms-vb2"/>
                        <AlternatingRowStyle CssClass="ms-alternating"/>
                    </asp:GridView>
	        </td></tr>
	        <tr>
	            <td colspan="2">
	                <table cellpadding=0 cellspacing=0 style="padding-left: 5px" >
			            <tr>
					            <td valign=top style="padding-top:5px;" class="ms-descriptiontext" >
					            <a name="addtype"></a><img src="/_layouts/images/setrect.gif" alt="">&nbsp;
					            </td>
					            <td nowrap class=ms-descriptiontext style="padding-top:7px;padding-left: 3px;">
					            <a href="Javascript:void(0);" onclick="Javascript:addType();">Add Type</a>
					            </td>
			            </tr>
		            </table>
		            <br />
	            </td>
	        </tr>
	        <tr><td colspan="2">
	            <table class="ms-toolbar" width="100%" cellpadding="3" style="height:10px">
                    <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Periods</h3></td></tr>
                </table>
	        </td></tr>
	        <tr>
	            <td colspan="2">
	                <div id="tsgrid" style="width:100%" style="display:none;"></div>
	                 <div  width="100%" id="loadingtsgrid" align="center">
                     <img src="/_layouts/images/gears_anv4.gif" style="vertical-align: middle;"/> Loading Periods...
                     </div>
	            </td>
	        </tr>
	        <tr>
	            <td colspan="2">
	                <table cellpadding=0 cellspacing=0 style="padding-left: 5px" >
			            <tr>
					            <td valign=top style="padding-top:5px;" class="ms-descriptiontext" >
					            <a name="addperiod"></a><img src="/_layouts/images/setrect.gif" alt="">&nbsp;
					            </td>
					            <td nowrap class=ms-descriptiontext style="padding-top:7px;padding-left: 3px;">
					            <a href="Javascript:void(0);" onclick="Javascript:addPeriod();">Add Period</a>
					            </td>
			            </tr>
		            </table>
		            <br />
	            </td>
	        </tr>
	        
	    </table>
	    
	    <div id="dlgAction" class="dialog">
            <table width="100%">
                <tr>
                    <td align="center" class="ms-sectionheader">
                        <img src="../images/gears_anv4.gif" style="vertical-align: middle;"/><br />
                        <H3 class="ms-standardheader" id="dlgHAction">Saving...</h3>
                    </td>
                </tr>
                
            </table>
        </div> 
        
        
        
        <div id="dlgEditType" class="dialog">
            <table width="100%">
                <tr>
                    <td class="ms-sectionheader">
                        Work Type Name:
                    </td>
                    <td class="ms-sectionheader">
                        <input type="text" id="txtEditType" name="txtEditType"/>
                        <input type="hidden" id="hdnEditType" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input type="button" class="ms-input" value="Save Work Type" onclick="doEditType();" /> 
                        <input type="button" class="ms-input" value="Cancel" onclick="hm('dlgEditType');" />
                    </td>
                </tr>
            </table>
        </div> 
        
        <%=inputData%>
        
        <%=lstData%>
        
	    <script>


	        mygrid = new dhtmlXGridObject('tsgrid');
	        mygrid.setImagePath("dhtml/xgrid/imgs/");

	        mygrid.setSkin("modern");
	        mygrid.enableAutoHeigth(true, "350");
	        mygrid.setImageSize(1, 1);
	        mygrid.setDateFormat("%m/%d/%Y");
	        mygrid.attachEvent("onXLE", clearLoader);

	        mygrid.enableEditTabOnly(true);

	        mygrid.init();
	        mygrid.loadXML("gettsperiods.aspx");

	        function switchList() {
	            var lst = document.getElementById("<%=ddlFieldLists.ClientID%>").value;
	            var allFields = document.getElementById("lst" + lst.replace(/ /g, "_")).value.split(',');
	            var sFields = document.getElementById("input" + lst.replace(/ /g, "_")).value.split(',');

	            var availFields = document.getElementById("<%=ddlListAvailableFields.ClientID %>");
	            var selectedFields = document.getElementById("<%=ddlListSelectedFields.ClientID %>");

	            availFields.options.length = 0;
	            selectedFields.options.length = 0;

	            for (var i = 0; i < allFields.length; i++) {
	                var fInfo = allFields[i].split('|');
	                var found = false;
	                for (var j = 0; j < sFields.length; j++) {
	                    if (sFields[j] == fInfo[0]) {
	                        var elOptNew = document.createElement('option');
	                        elOptNew.text = fInfo[1];
	                        elOptNew.value = fInfo[0];

	                        try {
	                            selectedFields.add(elOptNew, null);
	                        }
	                        catch (ex) {
	                            selectedFields.add(elOptNew);
	                        }
	                        found = true;
	                        break;
	                    }

	                }
	                if (!found) {
	                    var elOptNew = document.createElement('option');
	                    elOptNew.text = fInfo[1];
	                    elOptNew.value = fInfo[0];

	                    try {
	                        availFields.add(elOptNew, null);
	                    }
	                    catch (ex) {
	                        availFields.add(elOptNew);
	                    }
	                }
	                //alert(allFields[i]);
	            }

	            //                    for(var i = 0;i<sFields.length;i++)
	            //                    {
	            //                        if(sFields[i] != "")
	            //                        {
	            //                            var fInfo = sFields[i].split('|');
	            //                            selectedFields.add(new Option(fInfo[1],fInfo[0]));
	            //                        }
	            //                    }
	        }

	        function removeField() {
	            var tList = document.getElementById("<%=ddlListAvailableFields.ClientID %>");
	            var sList = document.getElementById("<%=ddlListSelectedFields.ClientID %>");

	            var lst = document.getElementById("<%=ddlFieldLists.ClientID%>").value;
	            var sFields = "";
	            var arrSelected = new Array();
	            var count = 0;

	            for (var i = 0; i < sList.length; i++) {
	                if (sList.options[i].selected) {
	                    var elOptNew = document.createElement('option');
	                    elOptNew.text = sList.options[i].text;
	                    elOptNew.value = sList.options[i].value;

	                    try {
	                        tList.add(elOptNew, null);
	                    }
	                    catch (ex) {
	                        tList.add(elOptNew);
	                    }

	                    //tList.add(new Option(sList.options[i].text, sList.options[i].value));
	                    arrSelected[count++] = sList.options[i].value;
	                }
	            }
	            for (i = 0; i < sList.length; i++) {
	                for (x = 0; x < arrSelected.length; x++) {
	                    if (sList.options[i].value == arrSelected[x])
	                        sList.options[i] = null;
	                }
	            }
	            for (var i = 0; i < sList.length; i++) {
	                if (sFields == "")
	                    sFields = sList.options[i].value;
	                else
	                    sFields = sFields + "," + sList.options[i].value;
	            }

	            document.getElementById("input" + lst.replace(/ /g, "_")).value = sFields;
	        }

	        function addField() {
	            var sList = document.getElementById("<%=ddlListAvailableFields.ClientID %>");
	            var tList = document.getElementById("<%=ddlListSelectedFields.ClientID %>");

	            var lst = document.getElementById("<%=ddlFieldLists.ClientID%>").value;
	            var sFields = document.getElementById("input" + lst.replace(/ /g, "_")).value;

	            var arrSelected = new Array();
	            var count = 0;

	            for (var i = 0; i < sList.length; i++) {
	                if (sList.options[i].selected) {
	                    var elOptNew = document.createElement('option');
	                    elOptNew.text = sList.options[i].text;
	                    elOptNew.value = sList.options[i].value;

	                    try {
	                        tList.add(elOptNew, null);
	                    }
	                    catch (ex) {
	                        tList.add(elOptNew);
	                    }

	                    //tList.add(new Option(sList.options[i].text, sList.options[i].value));
	                    arrSelected[count++] = sList.options[i].value;

	                    if (sFields == "")
	                        sFields = sList.options[i].value;
	                    else
	                        sFields = sFields + "," + sList.options[i].value;
	                }
	            }
	            for (i = 0; i < sList.length; i++) {
	                for (x = 0; x < arrSelected.length; x++) {
	                    if (sList.options[i].value == arrSelected[x])
	                        sList.options[i] = null;
	                }
	            }

	            document.getElementById("input" + lst.replace(/ /g, "_")).value = sFields;
	        }

	        function addTSField() {
	            var sList = document.getElementById("<%=ddlTSFieldsA.ClientID %>");
	            var tList = document.getElementById("<%=ddlTSFieldsS.ClientID %>");


	            MoveTSField(sList, tList);
	        }

	        function removeTSField() {
	            var sList = document.getElementById("<%=ddlTSFieldsS.ClientID %>");
	            var tList = document.getElementById("<%=ddlTSFieldsA.ClientID %>");


	            MoveTSField(sList, tList);
	        }

	        function MoveTSField(sList, tList) {
	            var arrSelected = new Array();
	            var count = 0;

	            var hdnTSFields = document.getElementById("<%=hdnTSFields.ClientID %>");
	            var SelectedList = document.getElementById("<%=ddlTSFieldsS.ClientID %>");

	            for (var i = 0; i < sList.length; i++) {
	                if (sList.options[i].selected) {
	                    var elOptNew = document.createElement('option');
	                    elOptNew.text = sList.options[i].text;
	                    elOptNew.value = sList.options[i].value;

	                    try {
	                        tList.add(elOptNew, null);
	                    }
	                    catch (ex) {
	                        tList.add(elOptNew);
	                    }

	                    //tList.add(new Option(sList.options[i].text, sList.options[i].value));
	                    arrSelected[count++] = sList.options[i].value;

	                    
	                }
	            }
	            for (i = 0; i < sList.length; i++) {
	                for (x = 0; x < arrSelected.length; x++) {
	                    if (sList.options[i].value == arrSelected[x])
	                        sList.options[i] = null;
	                }
	            }

	            var sFields = "";

	            for (var i = 0; i < SelectedList.length; i++) {
	                if (sFields == "")
	                    sFields = SelectedList.options[i].value;
	                else
	                    sFields = sFields + "," + SelectedList.options[i].value;
	            }

	            hdnTSFields.value = sFields;
	        }

	        _spBodyOnLoadFunctionNames.push("switchList");
	        //switchList(); 


	        function clearLoader(id) {

	            document.getElementById("tsgrid").style.display = "";
	            document.getElementById("loadingtsgrid").style.display = "none";
	        }
	        function closePeriod(period_id) {
	            if (confirm('Are you sure you want to close that period? Users will no longer be able to add time.')) {
	                sm('dlgAction', 200, 100);
	                var url = '<%=siteUrl%>';
	                document.getElementById("dlgHAction").innerText = "Closing Period...";
	                dhtmlxAjax.post(url + "/_layouts/epmlive/dotsaction.aspx", "action=closePeriod&period=" + period_id, closeDone);
	            }
	        }
	        function openPeriod(period_id) {
	            sm('dlgAction', 200, 100);
	            var url = '<%=siteUrl%>';
	            document.getElementById("dlgHAction").innerText = "Opening Period...";
	            dhtmlxAjax.post(url + "/_layouts/epmlive/dotsaction.aspx", "action=openPeriod&period=" + period_id, openDone);
	        }
	        function deletePeriod(period_id) {
	            if (confirm('Are you sure you want to delete that period? All data for that period will be lost!')) {
	                sm('dlgAction', 200, 100);
	                var url = '<%=siteUrl%>';
	                document.getElementById("dlgHAction").innerText = "Deleting Period...";
	                dhtmlxAjax.post(url + "/_layouts/epmlive/dotsaction.aspx", "action=deletePeriod&period=" + period_id, closeAdd);
	            }
	        }
	        function closeDone(loader) {
	            if (loader.xmlDoc.responseText != null) {
	                if (loader.xmlDoc.responseText.substring(0, 5) != "Error") {
	                    var strPeriod = loader.xmlDoc.responseText.trim();
	                    mygrid.cells(strPeriod, 4).setValue("<a href=\"javascript:void(0);\" onclick=\"javascript:openPeriod('" + strPeriod + "');\">open</a>");
	                    mygrid.cells(strPeriod, 3).setValue("");
	                    mygrid.cells(strPeriod, 2).setValue("Closed");
	                    hm('dlgAction');
	                }
	                else {
	                    alert(loader.xmlDoc.responseText);
	                    hm('dlgAction');
	                }
	            }
	            else {
	                alert("Response contains no XML");
	                hm('dlgAction');
	            }
	        }

	        function openDone(loader) {
	            if (loader.xmlDoc.responseText != null) {
	                if (loader.xmlDoc.responseText.substring(0, 5) != "Error") {
	                    var strPeriod = loader.xmlDoc.responseText.trim();
	                    mygrid.cells(strPeriod, 4).setValue("<a href=\"javascript:void(0);\" onclick=\"javascript:closePeriod('" + strPeriod + "');\">close</a>");
	                    mygrid.cells(strPeriod, 3).setValue("");
	                    mygrid.cells(strPeriod, 2).setValue("Open");
	                    hm('dlgAction');
	                }
	                else {
	                    alert(loader.xmlDoc.responseText);
	                    hm('dlgAction');
	                }
	            }
	            else {
	                alert("Response contains no XML");
	                hm('dlgAction');
	            }
	        }

	        function closeAdd(loader) {
	            if (loader.xmlDoc.responseText != null) {
	                if (loader.xmlDoc.responseText.substring(0, 5) != "Error") {
	                    var strPeriod = loader.xmlDoc.responseText;
	                    newURL = "<%=siteUrl%>/_layouts/epmlive/timesheetadmin.aspx";

	                    window.location.href = newURL + "?rnd=" + guid() + "#addperiod";

	                }
	                else {
	                    alert(loader.xmlDoc.responseText);
	                    hm('dlgAction');
	                }
	            }
	            else {
	                alert("Response contains no XML");
	                hm('dlgAction');
	            }
	        }

	        function addPeriod() {
	            sm('dlgAddPeriod', 300, 100);
	        }
	        function addType() {
	            sm('dlgAddType', 300, 80);
	        }
	        function editType(id, name) {
	            document.getElementById('hdnEditType').value = id;
	            document.getElementById('txtEditType').value = name;
	            sm('dlgEditType', 300, 80);
	        }
	        function guid() {
	            return (S4() + S4() + "-" + S4() + "-" + S4() + "-" + S4() + "-" + S4() + S4() + S4());
	        }
	        function S4() {
	            return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
	        }
	        function doAddPeriod() {
	            var dateStart = new Date(document.getElementById('<%=dtSpStart.ClientID%>_dtSpStartDate').value);
	            var dtStart = document.getElementById('<%=dtSpStart.ClientID%>_dtSpStartDate').value;
	            var dateEnd = new Date(document.getElementById('<%=dtSpEnd.ClientID%>_dtSpEndDate').value);
	            var dtEnd = document.getElementById('<%=dtSpEnd.ClientID%>_dtSpEndDate').value;
	            if (dateEnd < dateStart) {
	                alert('The end date must not be before the start date');
	            }
	            else {
	                hm('dlgAddPeriod');
	                sm('dlgAction', 200, 100);
	                var url = '<%=siteUrl%>';
	                document.getElementById("dlgHAction").innerText = "Adding Period...";
	                dhtmlxAjax.post(url + "/_layouts/epmlive/dotsaction.aspx", "action=addPeriod&start=" + dtStart + "&end=" + dtEnd, closeAdd);
	            }
	        }
	        function doAddType() {

	            var typename = document.getElementById('txtAddType').value;

	            hm('dlgAddType');
	            sm('dlgAction', 200, 100);
	            var url = '<%=siteUrl%>';
	            document.getElementById("dlgHAction").innerText = "Adding Work Type...";
	            dhtmlxAjax.post(url + "/_layouts/epmlive/dotsaction.aspx", "action=addType&typename=" + typename, closeAddType);
	        }

	        function doEditType() {

	            var typename = document.getElementById('txtEditType').value;
	            var typeid = document.getElementById('hdnEditType').value;

	            hm('dlgEditType');
	            sm('dlgAction', 200, 100);
	            var url = '<%=siteUrl%>';
	            document.getElementById("dlgHAction").innerText = "Saving Work Type...";
	            dhtmlxAjax.post(url + "/_layouts/epmlive/dotsaction.aspx", "action=editType&typename=" + typename + "&typeid=" + typeid, closeAddType);
	        }

	        function closeAddType(loader) {
	            if (loader.xmlDoc.responseText != null) {
	                if (loader.xmlDoc.responseText.substring(0, 5) != "Error") {
	                    var strPeriod = loader.xmlDoc.responseText;
	                    newURL = "<%=siteUrl%>/_layouts/epmlive/timesheetadmin.aspx";

	                    window.location.href = newURL + "?rnd=" + guid() + "#addtype";

	                }
	                else {
	                    alert(loader.xmlDoc.responseText);
	                    hm('dlgAction');
	                }
	            }
	            else {
	                alert("Response contains no XML");
	                hm('dlgAction');
	            }
	        }

	        initmb();
            </script>
	    </asp:Panel>
	</asp:Panel>
</asp:Content>