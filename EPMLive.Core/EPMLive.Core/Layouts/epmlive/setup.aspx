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
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="setup.aspx.cs" Inherits="EPMLiveCore.setup" DynamicMasterPageFile="~masterurl/default.master" %>
<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	WorkEngine Configuration
</asp:Content>
<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	WorkEngine Configuration
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this section to configure the settings for this site.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">

    <asp:Panel ID="pnlMain" runat="server" Visible="true" Width="100%">
        <script language="javascript">
            function addPeriods() {
                window.open('addperiods.aspx', '', config = 'height=400,width=500, toolbar=no, menubar=no, scrollbars=no, resizable=yes,location=no, directories=no, status=yes');
            }
            function addPeriod() {
                window.open('addperiod.aspx', '', config = 'height=270,width=400, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=yes');
            }
            function addOutlineCode() {
                window.open('addcode.aspx', '', config = 'height=150,width=250, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=yes');
            }
            function editOC(id) {
                window.open('editcode.aspx?id=' + id, '', config = 'height=150,width=250, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=yes');
            }
            function synchPeriods() {
                window.open('synchperiods.aspx', '', config = 'height=100,width=200, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=no');
            }
            function showhideperms(val) {
                var permstr = document.getElementById("ctl00_PlaceHolderMain_InputFormSection10");
                if (val == "Same")
                    permstr.style.display = "none";
                else
                    permstr.style.display = "";
            }
        </script>

        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                
                <asp:Panel ID="pnlConfigUrls" runat="server">
                    <tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
                    <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Sub Site Inheritance</h3></td></tr>
                    </table></td></tr>
                    <asp:Panel ID="pnlLockConfig" runat="server">
                        <wssuc:InputFormSection ID="InputFormSection2" Title="Sub Site Inheritance"
	                        Description=""
	                        runat="server">
	                        <Template_Description>
	                            By checking this option, this site and all sub sites will use the configuration specified on this page.
	                        </Template_Description>
	                        <Template_InputFormControls>
		                        <wssuc:InputFormControl ID="InputFormControl2" LabelText="" runat="server">
			                         <Template_Control>
			                            <asp:CheckBox ID="chkLockConfig" runat="server" Text="Lock"/>
			                         </Template_Control>
		                        </wssuc:InputFormControl>
	                        </Template_InputFormControls>
                        </wssuc:InputFormSection>
                    </asp:Panel>
                        <tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
                        <tr><td class="ms-linksectionheader" colspan="2"><h3 class="ms-standardheader">Configuration URLs</h3></td></tr>
                        </table></td></tr>
                    <asp:Panel ID="pnlEnterprise" runat="server" Visible="false">

                        <wssuc:InputFormSection ID="InputFormSection3" Title="Project Server Integration URL"
		                    Description=""
		                    runat="server">
		                    <Template_Description>
		                        Enter the URL for the Project Server site that you are connecting to.<br /><br />
		                        To automatically fill in the current URL use "{Site}". If you would like to point to a sub-site you can also use "{Site}/subsite".
		                    </Template_Description>
		                    <Template_InputFormControls>
			                    <wssuc:InputFormControl ID="InputFormControl3" LabelText="Url:" runat="server">
				                     <Template_Control>
				                        <asp:TextBox runat="server" ID="txtProjectServer" CssClass="ms-long"></asp:TextBox>
				                        <br />
				                        Ex: <%=url %>
				                     </Template_Control>
			                    </wssuc:InputFormControl>
		                    </Template_InputFormControls>
	                    </wssuc:InputFormSection>
	                    </asp:Panel>    

    	                
                        <wssuc:InputFormSection ID="InputFormSection4" Title="Resource Pool URL"
		                    Description=""
		                    runat="server">
		                    <Template_Description>
		                        Enter the URL where your resource pool is located.<br /><br />
		                        To automatically fill in the current URL use "{Site}". If you would like to point to a sub-site you can also use "{Site}/subsite". "{Root}" will point to the top level of your site collection.
		                    </Template_Description>
		                    <Template_InputFormControls>
			                    <wssuc:InputFormControl ID="InputFormControl5" LabelText="Url:" runat="server">
				                     <Template_Control>
				                        <asp:TextBox runat="server" ID="txtResourceURL" CssClass="ms-long"></asp:TextBox>
				                        <br />
				                        Ex: <%=url %>
				                     </Template_Control>
			                    </wssuc:InputFormControl>
		                    </Template_InputFormControls>
	                    </wssuc:InputFormSection>

                        <wssuc:InputFormSection ID="InputFormSectionPE" Title="Use Modified People Editor"
		                    Description=""
		                    runat="server">
		                    <Template_Description>
		                        This option changes the data source for the people pickers in this Site Collection to use the Resource Pool or Build Team.
		                    </Template_Description>
		                    <Template_InputFormControls>
			                    <wssuc:InputFormControl ID="InputFormControlPE" LabelText="Enable People Editor" runat="server">
				                     <Template_Control>
				                        <asp:CheckBox id="chkUsePE" runat="server" />
				                     </Template_Control>
			                    </wssuc:InputFormControl>
		                    </Template_InputFormControls>
	                    </wssuc:InputFormSection>
    	                
	                     
	                    <wssuc:InputFormSection ID="InputFormSection5" Title="Resource Tools Report URL"
		                    Description=""
		                    runat="server">
		                    <Template_Description>
		                        Enter the URL to the SSRS report used for displaying Resource Work vs. Capacity. Leave this setting blank to use the default location.
		                    </Template_Description>
		                    <Template_InputFormControls>
			                    <wssuc:InputFormControl ID="InputFormControl6" LabelText="Url:" runat="server">
				                     <Template_Control>
				                        <asp:TextBox runat="server" ID="txtResToolReportURL" CssClass="ms-long"></asp:TextBox>
				                     </Template_Control>
			                    </wssuc:InputFormControl>
		                    </Template_InputFormControls>
	                    </wssuc:InputFormSection>
	                    
	                    <tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
                        <tr><td class="ms-linksectionheader" colspan="2"><h3 class="ms-standardheader">New Workspace Options</h3></td></tr>
                        </table></td></tr>
                  
                        <wssuc:InputFormSection ID="InputFormSection6" Title="Valid Templates"
		                    Description=""
		                    runat="server">
		                    <Template_Description>
		                        Select which templates you would like users to be able to choose from when creating new projects.
		                    </Template_Description>
		                    <Template_InputFormControls>
			                    <wssuc:InputFormControl ID="InputFormControl7" LabelText="Select Templates" runat="server">
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

                        <wssuc:InputFormSection ID="InputFormSectionGalleryUrl" Title="Template Gallery URL"
		                    Description=""
		                    runat="server">
		                    <Template_Description>
		                        Enter the URL where your Template Gallery is located.<br /><br />
		                    </Template_Description>
		                    <Template_InputFormControls>
			                    <wssuc:InputFormControl ID="InputFormControlGalleryUrl" LabelText="Url:" runat="server">
				                     <Template_Control>
				                        <asp:TextBox runat="server" ID="txtGalleryUrl" CssClass="ms-long"></asp:TextBox>
				                        <br />
				                        Ex: <%=url %>
				                     </Template_Control>
			                    </wssuc:InputFormControl>
		                    </Template_InputFormControls>
	                    </wssuc:InputFormSection>

                        <wssuc:InputFormSection ID="InputFormSectionGalleryLive" Title="Use Live Templates"
		                    Description=""
		                    runat="server">
		                    <Template_Description>
		                        Select this option if you would like to use the live template for creating workspaces. If this option is disabled, the templates must be saved to the solution gallery first.<br /><br />
		                    </Template_Description>
		                    <Template_InputFormControls>
			                    <wssuc:InputFormControl ID="InputFormControlGalleryLive" LabelText="" runat="server">
				                     <Template_Control>
				                        <asp:CheckBox id="chkLiveTemplates" runat="server"></asp:CheckBox> Use Live Templates
				                     </Template_Control>
			                    </wssuc:InputFormControl>
		                    </Template_InputFormControls>
	                    </wssuc:InputFormSection>

                        <wssuc:InputFormSection ID="InputFormSectionCreateOptions" Title="Create From Options"
		                    Description=""
		                    runat="server">
		                    <Template_Description>
		                        Select the options which you would like to allow users to have available for the create site options.
		                    </Template_Description>
		                    <Template_InputFormControls>
			                    <wssuc:InputFormControl ID="InputFormControlCreateOptions" LabelText="Default Option" runat="server">
				                     <Template_Control>
				                        <asp:DropDownList id="ddlDefaultCreate" runat="server">
                                            <asp:ListItem Text="Online" Value="online"></asp:ListItem>
				                            <asp:ListItem Text="Local" Value="local"></asp:ListItem>
				                            <asp:ListItem Text="Existing Workspace" Value="existing"></asp:ListItem>
                                        </asp:DropDownList>
				                     </Template_Control>
			                    </wssuc:InputFormControl>
                                <wssuc:InputFormControl ID="InputFormControlCreateOptions2" LabelText="Available Options" runat="server">
				                     <Template_Control>
				                        <asp:CheckBoxList ID="chkCreateOptions" runat="server">
                                            <asp:ListItem Text="Online" Value="online"></asp:ListItem>
				                            <asp:ListItem Text="Local" Value="local"></asp:ListItem>
				                            <asp:ListItem Text="Existing Workspace" Value="existing"></asp:ListItem>
                                        </asp:CheckBoxList>
				                     </Template_Control>
			                    </wssuc:InputFormControl>
		                    </Template_InputFormControls>
	                    </wssuc:InputFormSection>
    	                
	                    <wssuc:InputFormSection ID="InputFormSection7" Title="Workspace Type"
		                    Description=""
		                    runat="server">
		                    <Template_Description>
		                        Select whether you would like to create a new workspace or use an existing.
		                    </Template_Description>
		                    <Template_InputFormControls>
			                    <wssuc:InputFormControl ID="InputFormControl8" LabelText="" runat="server">
				                     <Template_Control>
				                        <asp:DropDownList ID="ddlWorkspaceType" runat="server">
				                            <asp:ListItem Text="Not Set" Value=""></asp:ListItem>
				                            <asp:ListItem Text="New Workspace" Value="New"></asp:ListItem>
				                            <asp:ListItem Text="Existing Workspace" Value="Existing"></asp:ListItem>
				                        </asp:DropDownList>
				                     </Template_Control>
			                    </wssuc:InputFormControl>
		                    </Template_InputFormControls>
	                    </wssuc:InputFormSection>
    	                
	                    <wssuc:InputFormSection ID="InputFormSection8" Title="Navigation Inheritance"
		                    Description=""
		                    runat="server">
		                    <Template_Description>
		                        Specify whether this site shares the same top link bar as the parent. This setting may also determine the starting element of the breadcrumb. 
		                    </Template_Description>
		                    <Template_InputFormControls>
			                    <wssuc:InputFormControl ID="InputFormControl9" LabelText="" runat="server">
				                     <Template_Control>
				                        <asp:DropDownList ID="ddlNavigation" runat="server">
				                            <asp:ListItem Text="Not Set" Value=""></asp:ListItem>
				                            <asp:ListItem Text="Yes" Value="True"></asp:ListItem>
				                            <asp:ListItem Text="No" Value="False"></asp:ListItem>
				                        </asp:DropDownList>
				                     </Template_Control>
			                    </wssuc:InputFormControl>
		                    </Template_InputFormControls>
	                    </wssuc:InputFormSection>
    	                
	                     <wssuc:InputFormSection ID="InputFormSection9" 
		                Title="<%$Resources:wss,newsbweb_idInputTitleContent%>"
	                    Description="<%$Resources:wss,newsbweb_idInputDescriptionContent%>"
		                runat="server" width="10">
		                <Template_InputFormControls>
		                    <wssuc:InputFormControl ID="InputFormControl10" LabelText="<%$Resources:wss,newsbweb_idInputLabelPermissions%>"
			                    SmallIndent="true"
			                    runat="server">
			                    <Template_Control>
				                    <asp:DropDownList ID="ddlPermissions" runat="server" onChange="">
				                            <asp:ListItem Text="Not Set" Value=""></asp:ListItem>
				                            <asp:ListItem Text="<%$Resources:wss,newsbweb_usesameperm%>" Value="Same"></asp:ListItem>
				                            <asp:ListItem Text="<%$Resources:wss,newsbweb_useuniqueperm%>" Value="Unique"></asp:ListItem>
				                        </asp:DropDownList>
			                    </Template_Control>
		                    </wssuc:InputFormControl>
	                    </Template_InputFormControls>
	                </wssuc:InputFormSection>
	                    <wssuc:InputFormSection ID="InputFormSection10" Title="Custom Permissions" Description="" runat="server">
                            <template_description>
		                        Assign custom groups to sharepoint permissions.<br /><br />
		                        <b>Note: This only applies when the user selects unique permissions.</b>
		                    </template_description>
                            <template_inputformcontrols>
                                <wssuc:InputFormControl ID="InputFormControl11" LabelText="Default Role Assignments" runat="server">
				                     <Template_Control>
				                        <table border="0"  cellspacing="0">       
                                            <tr>
                                                <td class="ms-descriptiontext">Owners: </td>
                                                <td align="right"><asp:DropDownList ID="ddlRoleOwners" runat="Server"><asp:ListItem Text="--Create New Group--" Value=""></asp:ListItem></asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td class="ms-descriptiontext">Members: </td>
                                                <td align="right"><asp:DropDownList ID="ddlRoleMembers" runat="Server"><asp:ListItem Text="--Create New Group--" Value=""></asp:ListItem></asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td class="ms-descriptiontext">Visitors: </td>
                                                <td align="right"><asp:DropDownList ID="ddlRoleVisitors" runat="Server"><asp:ListItem Text="--Create New Group--" Value=""></asp:ListItem></asp:DropDownList></td>
                                            </tr>
                                        </table><Br />
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
		                    </template_inputformcontrols>
                        </wssuc:InputFormSection>
                        <wssuc:InputFormSection ID="InputFormSectionEnableTotango" Title="Enable Usage Tracking"
		                    Description=""
		                    runat="server">
		                    <Template_Description>		                        
		                    </Template_Description>
		                    <Template_InputFormControls>
			                    <wssuc:InputFormControl ID="InputFormControlEnableUsageTracking" LabelText="" runat="server">
				                     <Template_Control>
				                        <asp:CheckBox id="chkEnableUsageTracking" runat="server"></asp:CheckBox> Enable Usage Tracking
				                     </Template_Control>
			                    </wssuc:InputFormControl>
		                    </Template_InputFormControls>
	                    </wssuc:InputFormSection>

	                    <wssuc:ButtonSection ID="ButtonSection1" runat="server">
		                    <Template_Buttons>
			                    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
				                    <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Button1_Click" Text="Save Settings" id="Button1" accesskey="" Width="150"/>
			                    </asp:PlaceHolder>
		                    </Template_Buttons>
	                    </wssuc:ButtonSection>
                    </asp:Panel>
                    
                    
                    
                    <wssawc:FormDigest ID="FormDigest1" runat="server" />
        </table>
        <script language="javascript">
            showhideperms(document.getElementById("ctl00_PlaceHolderMain_InputFormSection9_InputFormControl10_ddlPermissions").value);
        </script>
   </asp:Panel> 
</asp:Content>