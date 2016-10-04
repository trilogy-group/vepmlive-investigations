<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="econfig.aspx.cs" Inherits="EPMLiveEnterprise.Layouts.epmlive.econfig" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    

    <asp:Label ID="lblError" runat="server" ForeColor="red"></asp:Label>
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
    <tr><td class="ms-linksectionheader" colspan="2"><h3 class="ms-standardheader">Field Settings</h3></td></tr>
    </table></td></tr>
                        
    <wssuc:InputFormSection Title="Delete Task Center Fields On Synchronize"
		Description=""
		runat="server">
		<Template_Description>
		    When checked, this will cause the publishing process to delete any fields that have not been selected in the
		    "Enterprise Field Synchronization" screen.
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Check to Lock Synchronization" runat="server">
				 <Template_Control>
				    <asp:CheckBox ID="chkLockSynch" runat="server" />
				    <br />
				    <img src="blank.gif" width="400" height="1"/>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	
    <wssuc:InputFormSection Title="Assigned To Field"
		Description=""
		runat="server">
		<Template_Description>
		    This is an Enterprise field that will be used to assign tasks to a user in the event that a project manager
		    uses the publishing type "Task Based without Assignments".<br /><br />
		    You may use the following fields:<br /><br />
		    <b>Text:</b><br />
		    The field must contain the users e-mail address.<br />
		    <br />
		    <b>Text Lookup:</b><br />
		    In the lookup table you specify a users e-mail address in the description column of the table.
		    <br /><br />
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Select an Enterprise Field" runat="server">
				 <Template_Control>
				    <asp:DropDownList ID="ddlAssignedToField" runat="server" />
				    <br />
				    <img src="blank.gif" width="400" height="1"/>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	
	<wssuc:InputFormSection Title="Timesheet Fields"
		Description=""
		runat="server">
		<Template_Description>
		    Use this section to specify which fields are used with the EPM Live Timesheets.
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Select a Timesheet Field" runat="server">
				 <Template_Control>
				    <asp:DropDownList ID="ddlTimesheet" runat="server" />
				    <br />
				    <img src="blank.gif" width="400" height="1"/>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="Select a Timesheet Hours Field" runat="server">
				 <Template_Control>
				    <asp:DropDownList ID="ddlTimesheetHours" runat="server" />
				    <br />
				    <img src="blank.gif" width="400" height="1"/>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	
	<tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
    <tr><td class="ms-linksectionheader" colspan="2"><h3 class="ms-standardheader">Workspace Options</h3></td></tr>
    </table></td></tr>
                        
	<wssuc:InputFormSection Title="Force Creation Of Project Workspaces"
		Description=""
		runat="server">
		<Template_Description>
		    When checked, this will not allow a user to skip the process of creating a Project Workspace.
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Check to Force:" runat="server">
				 <Template_Control>
				    <asp:CheckBox ID="chkForceWS" runat="server" />
				    <br />
				    <img src="blank.gif" width="400" height="1"/>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	<wssuc:InputFormSection Title="Valid Templates"
		Description=""
		runat="server">
		<Template_Description>
		    Select which templates you would like users to be able to choose from when creating sites.
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Select Templates" runat="server">
				 <Template_Control>
				    <table border="0" width="460">
                        <tr>
                            <td class="ms-authoringcontrols">
                                Available Templates:<br />
                                <asp:ListBox runat="server" Rows="10" ID="lstAllTemplates" Width="180" SelectionMode="Multiple">
                                </asp:ListBox>
                            </td>
                            <td align="center">
                                <asp:Button ID="btnAdd" Text="Add &gt;" runat="server" OnClick="btnAdd_Click"/>
                                <br /><br />
                                <asp:Button ID="btnRemove" Text="&lt; Remove" runat="server" OnClick="btnRemove_Click"/>
                            </td>
                            <td class="ms-authoringcontrols">
                                Selected Templates:<br />
                                <asp:ListBox runat="server" Rows="10" ID="lstSelectedTemplates" Width="180" SelectionMode="Multiple">
                                </asp:ListBox>
                            </td>
                        </tr>
                    </table>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	
	<tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
    <tr><td class="ms-linksectionheader" colspan="2"><h3 class="ms-standardheader">Cross Site Settings</h3></td></tr>
    </table></td></tr>
    
	<wssuc:InputFormSection Title="Allow Cross Site Publishing"
		Description=""
		runat="server">
		<Template_Description>
		    By checking this box you are allowing users to publish their projects to sites outside the Project Server Site Collection.
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Check to Allow:" runat="server">
				 <Template_Control>
				    <asp:CheckBox ID="chkCrossSite" runat="server" />
				    <br />
				    <img src="blank.gif" width="400" height="1"/>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	
	<wssuc:InputFormSection Title="Cross Site URLs"
		Description=""
		runat="server">
		<Template_Description>
		    Enter a list of site urls that you would like to use with this instance of Microsoft Office Project Server.
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Enter URLs:" runat="server">
				 <Template_Control>
				    <asp:TextBox ID="txtUrls" runat="server" CssClass="ms-long" TextMode="MultiLine" Rows="5" Columns="30" />
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>

	<wssuc:InputFormSection Title="Default Publish URL"
		Description=""
		runat="server">
		<Template_Description>
		    Use this box to override the project server workspace provisioning setting when using EPM Live Publisher.
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Enter URL:" runat="server">
				 <Template_Control>
				    <asp:TextBox ID="txtDefaultURL" runat="server" CssClass="ms-long" />
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	<tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
    <tr><td class="ms-linksectionheader" colspan="2"><h3 class="ms-standardheader">Resource Pool</h3></td></tr>
    </table></td></tr>
    
    <wssuc:InputFormSection Title="Resource Pool Synchronization"
		Description=""
		runat="server">
		<Template_Description>
		    The resource pool setup as a live synch. Each time a resource is added, updated, or deleted the resource will get synchronized with the connected sites. However, if you want to 
		    synchronize the entire resource pool, you can do that here.
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
				    <asp:LinkButton ID="lnkSynchResources" OnClick="lnkSynchResources_Click" runat="server">Synchronize Now</asp:LinkButton>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
    
	<tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
    <tr><td class="ms-linksectionheader" colspan="2"><h3 class="ms-standardheader">Event Handlers</h3></td></tr>
    </table></td></tr>
    
	<wssuc:InputFormSection Title="Event Handler Status"
		Description=""
		runat="server">
		<Template_Description>
		    This section displays the status of the EPM Live Server-side Event Handlers.
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Project Published Event:" runat="server">
				 <Template_Control>
				    <asp:Label ID="lblProjectPublished" runat="server" />
				    <img src="blank.gif" width="400" height="1"/>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="Statusing Applied Event:" runat="server">
				 <Template_Control>
				    <asp:Label ID="lblStatusingApplied" runat="server" />
				    <img src="blank.gif" width="400" height="1"/>
				 </Template_Control>
			</wssuc:InputFormControl>
			
			<wssuc:InputFormControl LabelText="Resource Created Event:" runat="server">
				 <Template_Control>
				    <asp:Label ID="lblResCreated" runat="server" />
				    <img src="blank.gif" width="400" height="1"/>
				 </Template_Control>
			</wssuc:InputFormControl>
			
			<wssuc:InputFormControl LabelText="Resource Updated Event:" runat="server">
				 <Template_Control>
				    <asp:Label ID="lblResUpdated" runat="server" />
				    <img src="blank.gif" width="400" height="1"/>
				 </Template_Control>
			</wssuc:InputFormControl>
			
			<wssuc:InputFormControl LabelText="Resource Deleted Event:" runat="server">
				 <Template_Control>
				    <asp:Label ID="lblResDeleted" runat="server" />
				    <img src="blank.gif" width="400" height="1"/>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="Re-Install Event Receivers:" runat="server">
				 <Template_Control>
				    <asp:LinkButton ID="lnkReactivate" OnClick="lnkReactivate_Click" runat="server">Re-Install Now</asp:LinkButton>
			    </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	
	
    <wssuc:ButtonSection runat="server">
		<Template_Buttons>
			<asp:PlaceHolder ID="PlaceHolder1" runat="server">
				<asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Button1_Click" Text="Save Configuration" id="Button1" accesskey="" Width="150"/>
			</asp:PlaceHolder>
		</Template_Buttons>
	</wssuc:ButtonSection>
	</table>
    <wssawc:FormDigest ID="FormDigest1" runat="server" />
    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	WorkEngine for Project Server Configuration
</asp:Content>
<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	WorkEngine for Project Server Configuration
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to configure the options that will be used with WorkEngine for Project Server
</asp:Content>