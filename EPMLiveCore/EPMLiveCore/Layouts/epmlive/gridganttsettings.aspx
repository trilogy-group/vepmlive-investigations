<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 


<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gridganttsettings.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.gridganttsettings" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	General Settings: <%=strListName %>
</asp:Content>
<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	General Settings: <%=strListName %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">Use this page to determine the Grid/Gantt field settings for this List.  These settings are only relevant when using this List in conjunction with EPM Live Web Parts such as the Grid Web Part.</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">

<SharePoint:StyleBlock runat="server">
    .icon-button {
        line-height:50px;
        border:1px solid #CCCCCC;
        float:left;
        height:50px;
        width:50px;
        text-align:center;
        border-radius:5px;
        background: -moz-linear-gradient(bottom, #cccccc, #fafafa);
        background-image: -ms-linear-gradient(bottom, #cccccc,#fafafa);
        background-image: -webkit-linear-gradient(bottom, #cccccc,#fafafa);
        background-image: linear-gradient(to top, #cccccc,#fafafa);
        
    }
    .icon-button-text {
        float: right; 
        position: relative; 
        margin-top: 15px; 
        left: -20px;
    }

</SharePoint:StyleBlock>

<SharePoint:ScriptBlock runat="server">

    function CheckTimesheet() {

        var chk = document.getElementById("<%=chkTimesheet.ClientID%>");

        if (!chk.checked) {
            if (confirm("Are you sure you want to turn this feature off? The timesheet and timesheet hours fields will be removed from this list.")) {
                
            }
            else {
                chk.checked = true;
            }
        }
    }
    
    function OpenIconSelect() {

        var options = {
            url: epmLive.currentSiteUrl + "/_layouts/epmlive/iconpicker.aspx",
            width: 800,
            height: 600,
            dialogReturnValueCallback: function(dialogResult, returnValue) {
                if (dialogResult === 1) {
                    if ($('#<%=spnListIcon.ClientID%>').length > 0 && !$('#<%=spnListIcon.ClientID%>').hasClass(returnValue)) {
                        $('#<%=spnListIcon.ClientID%>').removeClass();
                        $('#<%=spnListIcon.ClientID%>').addClass(returnValue);
                        $('#<%=hdnListIcon.ClientID%>').val(returnValue);
                    }
                }
            }
        };

        SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
        return false;
    }


    
</SharePoint:ScriptBlock>

<SharePoint:ScriptBlock runat="server">
    var listid = "<%=strListId%>";
    var reportActionUrl = "<%=strReportActionUrl%>";
    var cbEnableReport = "<%=cbEnableReporting.ClientID%>";
    var cbEnableWSCreation = "<%=chkEnableRequests.ClientID%>";
    var ddlAutoCreateTemplateId = "<%=ddlAutoCreateTemplate.ClientID%>";
    var cbAutoCreateId = "<%=chkAutoCreate.ClientID%>";
</script>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <wssuc:InputFormSection Title="Field Settings"
		Description=""
		runat="server">
		<Template_Description>
		    Select the fields that will be used to configure the Gantt for this List.
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Start Date" runat="server">
				 <Template_Control>
                    <asp:DropDownList ID="ddlStartDate" runat="server"></asp:DropDownList>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="Due Date" runat="server">
				 <Template_Control>
                    <asp:DropDownList ID="ddlDueDate" runat="server"></asp:DropDownList>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="Progress Bar" runat="server">
				 <Template_Control>
                    <asp:DropDownList ID="ddlProgressBar" runat="server"></asp:DropDownList>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="Milestone" runat="server">
				 <Template_Control>
                    <asp:DropDownList ID="ddlMilestone" runat="server"></asp:DropDownList>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="Right Information" runat="server">
				 <Template_Control>
                    <asp:DropDownList ID="ddlInformation" runat="server"></asp:DropDownList>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="WBS" runat="server">
				 <Template_Control>
                    <asp:DropDownList ID="ddlWBS" runat="server"></asp:DropDownList>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	
	
	<wssuc:InputFormSection Title="Roll-Up Settings"
		Description=""
		runat="server">
		<Template_Description>
		    Enter the Lists and Sites that will be used as the roll-up sources for this List.
		    <br /><br />
            Rollup Lists:  Enter the List names that will be used as the roll-up List data sources for this List.  Each List name must be separated by a line break.<br /><br />
            Rollup Sites:  Enter the Site URLs that will be used as the roll-up site data sources for this List.  Each Site URL must be separated by a line break.

		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Rollup List(s)" runat="server">
				 <Template_Control>
                    <asp:TextBox ID="txtRollupLists" runat="server" TextMode="MultiLine" Rows="5" Columns="30"></asp:TextBox>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="Rollup Site(s)" runat="server">
				 <Template_Control>
                    <asp:TextBox ID="txtRollupSites" runat="server" TextMode="MultiLine" Rows="5" Columns="30"></asp:TextBox>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkExecutive" runat="server" Text="Executive View" />
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>

    <wssuc:InputFormSection Title="Build Team"
		Description=""
		runat="server">
		<Template_Description>
		    
            Enable Team: When enabled, this will allow users to build the team on items in the list.<br /><br />
            Enable Team Security: When enabled, this will allow for unique permissions on list items and their child items.<br /><br />
            Additional Permissions: When an item is saved and unique permissions are applied, these groups will be added to the item in addition to the standard groups.

		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkEnableTeam" runat="server" Text="Enable Team" />
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkEnableTeamSecurity" runat="server" Text="Enable Team Security" /><br /><br />
				 </Template_Control>
			</wssuc:InputFormControl>
            <wssuc:InputFormControl ID="InputFormControl12" LabelText="Additional Permissions" runat="server">
				    <Template_Control>           
                    <SharePoint:SPGridView runat="server" ID="GvGroupsPermissions" AutoGenerateColumns="false" width="100%">
                        <Columns>
                            <SharePoint:SPBoundField DataField="GroupsText" HeaderText="Groups" HeaderStyle-CssClass="ms-vh2-nofilter ms-descriptiontext" HeaderStyle-Font-Bold="true" ItemStyle-CssClass="ms-descriptiontext" ></SharePoint:SPBoundField>
                            <SharePoint:SPBoundField DataField="PermissionsText" HeaderText="Permissions" HeaderStyle-CssClass="ms-vh2-nofilter ms-descriptiontext" HeaderStyle-Font-Bold="true" ItemStyle-CssClass="ms-descriptiontext"></SharePoint:SPBoundField>
                            <SharePoint:SPBoundField DataField="GroupsID" Visible="false"></SharePoint:SPBoundField>
                            <SharePoint:SPBoundField DataField="PermissionsID" Visible="false"></SharePoint:SPBoundField>
                            <asp:TemplateField HeaderStyle-CssClass="ms-vh2-nofilter ms-descriptiontext">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkGrpPermDelete" runat="server" Font-Underline="true" ForeColor="#5899EC" Text="Delete" OnClick="lnkGrpPermDelete_OnClick" CommandArgument='<%#Eval("GroupsID") + ";" + Eval("PermissionsID")%>' ></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <AlternatingRowStyle BackColor="#ededed" CssClass="ms-descriptiontext" />
                        <RowStyle BackColor="white" CssClass="ms-descriptiontext" />
                    </SharePoint:SPGridView><Br />
				    </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl ID="InputFormControl13" LabelText="Add Additional Permissions" runat="server">
				    <Template_Control>
                    <table border="0"  cellspacing="0">        
                        <tr>
                            <td> <asp:Label ID="lblGroups1" runat="Server" Text="Groups:" CssClass="ms-descriptiontext"></asp:Label></td>
                            <td align="left"><asp:DropDownList ID="ddlGroups" runat="Server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td> <asp:Label ID="lblPermissions1" runat="Server" Text="Permissions:" CssClass="ms-descriptiontext"></asp:Label></td>
                            <td align="left"><asp:DropDownList ID="ddlSPPermissions" runat="Server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td align="left">
                            <asp:Button ID="btnGrpPermAdd" runat="server"  Text="Add" CssClass="ms-ButtonHeightWidth" OnClick="btnGrpPermAdd_OnClick"></asp:Button>

                            </td>
                        </tr>
                    </table><Br />
				    </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>

	</wssuc:InputFormSection>
	
	<wssuc:InputFormSection Title="Additional Settings"
		Description=""
		runat="server">
		<Template_Description>
		    Select the additional settings for this List.<br /><br />
            Item Link Type:  The Item Link Type will determine how the "Title" field is displayed in the views of this List. <br />
            <ul>
            <li>Use View Settings - This option will display the Title field as is specified in the View settings.  For example, if the Project Name column is used in a view, no hyperlink will be displayed in the Grid.  This option will also disable the right-click edit functionality within the Grid.   If the Project Name (linked to item) column is used instead, the title will render as a hyperlink in the Grid and when clicked, will link to the View Item page.  Finally, if the Project Name (linked to item with edit menu) column is used, the title will render as a hyperlink in the Grid and when clicked, will link to the Edit Item page.<br /><br /></li>
            <li>Go To Workspace - This option will display the Title field as a hyperlink in the Grid and when clicked, will link to the associated Workspace site of the item that was clicked.  This option can only be used in the Project Center List.<br /><br /></li>
            <li>Edit Work Plan - This option will display the Title field as a hyperlink in the Grid and when clicked, will link to the associated Work Plan of the item that was clicked.  This option can only be used in the Project Center List.<br /><br /></li>
            <li>Task Center - This option will display the Title field as a hyperlink in the Grid and when clicked, will link to the associated Task Center of the item that was clicked and only display the associated tasks.  This option can only be used in the Project Center List.<br /><br /></li>
            </ul>
            Show View Toolbar:  This checkbox determines whether or not the menu toolbar will be visible.<br /><br />
            Use Pop-up Editor: Use this feature to edit items in a pop-up instead of navigating away from the current page.<br /><br />
            
            Use Parent: When enabled this option will use the parent item when working with the ribbon and the context menus.<br /><br />
            Force Search: When enabled this option will make the users search for something prior to displaying the grid. This can increase performance if a list and/or view has many items.<br /><br />
            Persistent Search: When this is turned on the search functionality will apply to all views during your session in a list.<br /><br />
            Associated Items: When enabled, the ribbon will contain a link to associated lists.<br /><br />
            New Form Redirect: When enabled, users will be redirected to the display form when they submit a new item.<br /><br />
		</Template_Description>
		<Template_InputFormControls>
		    <wssuc:InputFormControl LabelText="Item Link Type" runat="server">
				 <Template_Control>
                    <asp:DropDownList ID="ddlItemLink" runat="server">
                        <asp:ListItem Text="Use View Settings" Value=""></asp:ListItem>
                        <asp:ListItem Text="Go To Workspace" Value="workspace"></asp:ListItem>
                    </asp:DropDownList>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkShowViewToolbar" runat="server" Text="Show View Toolbar" />
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkUsePopup" runat="server" Text="Use Pop-up Editor" />
				 </Template_Control>
			</wssuc:InputFormControl>
            <wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkUseParent" runat="server" Text="Use Parent" />
				 </Template_Control>
			</wssuc:InputFormControl>
            <wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkSearch" runat="server" Text="Force Search" />
				 </Template_Control>
			</wssuc:InputFormControl>
            <wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkLockSearch" runat="server" Text="Persistent Search" />
				 </Template_Control>
			</wssuc:InputFormControl>
            <wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkAssociatedItems" runat="server" Text="Associated Items" />
				 </Template_Control>
			</wssuc:InputFormControl>
            <wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkDisplayRedirect" runat="server" Text="New Form Redirect" />
				 </Template_Control>
			</wssuc:InputFormControl>
            
		</Template_InputFormControls>
	</wssuc:InputFormSection>

    <wssuc:InputFormSection Title="Item Workspaces"
		Description=""
		runat="server">
		<Template_Description>
		    Use this feature to allow workspaces to be created from the context menu of a list item.<br /><br />
            Enable Workspace Creation: Use this feature to allow workspaces to be created from the context menu of a list item.<br /><br />
            Do No Delete Item: Select this option to keep the request item in the list once the workspace has been created.<br /><br />
            Item List: Enter the name of the list you would like to use in the new workspace.<br /><br />
            
		</Template_Description>
		<Template_InputFormControls>

            <wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkEnableRequests" runat="server" Text="Enable Workspace Creation" />
				 </Template_Control>
			</wssuc:InputFormControl>

            <wssuc:InputFormControl LabelText="" runat="server" visible="False">
				 <Template_Control>
                    <asp:CheckBox ID="chkDeleteRequest" runat="server" Text="Do Not Delete Items" />
				 </Template_Control>
			</wssuc:InputFormControl>

            <wssuc:InputFormControl LabelText="Item List" runat="server" visible="False">
				 <Template_Control>
                    <asp:TextBox ID="txtRequestList" runat="server" />
				 </Template_Control>
			</wssuc:InputFormControl>

            <wssuc:InputFormControl ID="ifcAutoCreate" runat="server" LabelText="Auto Create">
				 <Template_Control>
                    <asp:CheckBox ID="chkAutoCreate" runat="server" />
				 </Template_Control>
			</wssuc:InputFormControl>

            <wssuc:InputFormControl ID="ifcAutoCreateTemplate" runat="server" LabelText="Select Template">
				 <Template_Control>
                    <asp:DropDownList ID="ddlAutoCreateTemplate" runat="Server" ></asp:DropDownList>
				 </Template_Control>
			</wssuc:InputFormControl>

            <wssuc:InputFormControl ID="ifcParentSiteLookup" runat="server" LabelText="Parent Site Template">
				 <Template_Control>
                    <asp:DropDownList ID="ddlParentSiteLookup" runat="Server" ></asp:DropDownList>
				 </Template_Control>
			</wssuc:InputFormControl>
            

        </Template_InputFormControls>
	</wssuc:InputFormSection>


	<wssuc:InputFormSection Title="Enable Performance Capability"
		Description=""
		runat="server">
		<Template_Description>
		    When this property is set, the Grid will use a more efficient method
            of gathering data.  Although the method is more efficient, 
            it requires that all rollup Lists of a certain type have identical fields.
            
            <br />
            If this property is set and certain data is not rolling up or no data is rolling up at all, 
            please contact support or visit the <a href="http://kb.epmlive.com" target="_blank">Knowledge Base</a>.
            <br /><br />
            To view a field audit report <a href="fieldaudit.aspx?List=<%=Request["List"] %>" target="_blank" >click here</a>.<br /><br />
            Enable Content DB: This option will make the grid use the EPM Live content database which will greatly improve rollup performance.
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkPerformance" runat="server" Text="Enable Performance" />
				 </Template_Control>
			</wssuc:InputFormControl>
            <wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkContentReporting" runat="server" Text="Enable Content DB" />
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	
	<wssuc:InputFormSection Title="New Item Settings"
		Description=""
		runat="server">
		<Template_Description>
		    This section allows you to modify how the new button works.<br /><br />
            Use Enhanced New Menu: This will allow users to create a new item on a new or existing workspace.<br /><br />
            Hide New Button:  This checkbox determines whether or not users will be able to create new items from this List.  <br /><br />
            Disable New Button Modifications: This checkbox will disable the grid view from modifying the "New" button when rollup lists have been defined.<br /><br />
		    Also enter the name you would like to be displayed for a new item.<br />(Ex: for "New Project" enter "Project" in the box)
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Use Enhanced New Menu" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkUseNewMenu" runat="server" Text="" />
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="Name for New Item" runat="server">
				 <Template_Control>
                    <asp:TextBox ID="txtNewMenuName" runat="server"/><br /><br />
				 </Template_Control>
			</wssuc:InputFormControl>
            <wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkHideNewButton" runat="server" Text="Hide New Button" />
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkDisableNewRollup" runat="server" Text="Disable New Button Modifications" />
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	
	<wssuc:InputFormSection Title="Editable Grid Settings"
		Description=""
		runat="server">
		<Template_Description>
		    Allow Edit Toggle will allow users to toggle between grid edit mode and regular grid view mode.
            <br /><br />
            Default To Edit Mode will default all views to grid edit mode.
            <br /><br />
            Show Insert Row will allow users to enter new items directly into the grid.
             
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkAllowEdit" runat="server" Text="Allow Edit Toggle" />
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkEditDefault" runat="server" Text="Default To Edit Mode" />
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkShowInsert" runat="server" Text="Show Insert Row" />
				 </Template_Control>
			</wssuc:InputFormControl>
            
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	
    <wssuc:InputFormSection Title="Email Notifications"
		Description=""
		runat="server" ID="SectionEmail" Visible="false">
		<Template_Description>
		    Check this box to enable email notifications when an item is assigned to someone.
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkEmails" runat="server" Text="Enable Notifications" />
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>

	<wssuc:InputFormSection Title="Enable Resource Tools"
		Description=""
		runat="server">
		<Template_Description>
		    When checked, this will allow users to find resources for a list item and check that the resource isn't overbooked.
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkResTools" runat="server" Text="Use Resource Tools" />
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>


    <wssuc:InputFormSection Title="Enable Timesheets"
		Description=""
		runat="server">
		<Template_Description>
		    When checked, this list will be anabled for timesheet usage. 2 fields will be added to your list and the list will be added to the timesheet configuration.
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkTimesheet" runat="server" Text="Enable Timesheets"  />
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	
    <wssuc:InputFormSection Title="Enable Work List Features"
		Description=""
		runat="server">
		<Template_Description>
		    By enabling the Work List Features, several components will be added to this List in order for better integration with the EPMLive system.  The following components will be added:
            <br />
            <ul>    
                <li>EPMLive Grid/Gantt to all views</li>
                <li>Event Handlers to handle "Complete" Logic</li>
                <li>Complete, % Complete, and Status fields will be added (if they do not already exist)</li>
            </ul>            
            By turning off this feature, only the Event Handlers will be removed, Grid/Gantt Web Parts and fields will remain.
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="chkWorkListFeat" runat="server" Text="Enable Work List Features" />
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
    
    <wssuc:InputFormSection Title="Select Icon"
		Description=""
		runat="server">
		<Template_Description>
		    Select icon
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
				     <div class="icon-button">
				         <span class="box1" style="">
				             <asp:Label id="spnListIcon" runat="server" style="cursor:pointer;font-size:18px;" onclick="OpenIconSelect();return false;" ></asp:Label>
                             <asp:HiddenField runat="server" ID="hdnListIcon"/>
	                    </span>
				     </div>
                     <div class="icon-button-text">Click the button to select an icon for this List.</div>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>

    <wssuc:InputFormSection ID="ifsEnableReporting" Title="Enable Reporting"
		Description=""
		runat="server"
        Visible="false">
		<Template_Description>
		    By enabling reporting, this list will be mapped to reporting database.
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:CheckBox ID="cbEnableReporting" runat="server" Text="Enable Reporting" />
				 </Template_Control>
			</wssuc:InputFormControl>
            <wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:Button ID="btnAddEvt" runat="server" Text="Add Reporting Events" OnClick="AddReportEvent" />
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>

	<wssuc:ButtonSection runat="server">
		<Template_Buttons>
			<asp:PlaceHolder ID="PlaceHolder1" runat="server">
				<asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Button1_Click" Text="Save" id="Button1" accesskey="" Width="150"/>
			</asp:PlaceHolder>
		</Template_Buttons>
	</wssuc:ButtonSection>
    <wssawc:FormDigest ID="FormDigest1" runat="server" />
    </table>
</asp:Content>
