<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 

<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="publishersettings.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.publishersettings" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	EPM Live Publisher Settings
</asp:Content>
<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	EPM Live Publisher Settings
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to manage your EPM Live Project Publisher settings.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
    <asp:Panel ID="pnlAdmin" runat="server" Visible="false" Width="100%">
        Publisher settings are being configured at another site.<br /><br />
        <asp:HyperLink Text="Click Here" NavigateUrl="" runat="server" ID="hlAdmin"></asp:HyperLink> to go there now.
    </asp:Panel>
    <asp:Panel ID="pnlMain" runat="server" Visible="true" Width="100%">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>                
                    <wssuc:InputFormSection Title="Lock Project Publisher"
		                Description=""
		                runat="server">
		                <Template_Description>
		                    When publishing, this option will force the Project Publisher to use the settings defined on this page.
		                </Template_Description>
		                <Template_InputFormControls>
			                <wssuc:InputFormControl LabelText="" runat="server">
				                 <Template_Control>
                                    <asp:CheckBox ID="chkLockPublisher" runat="server" Text="Lock"/>
				                 </Template_Control>
			                </wssuc:InputFormControl>
		                </Template_InputFormControls>
	                </wssuc:InputFormSection>

                    <wssuc:InputFormSection Title="Publishing Type"
		                Description=""
		                runat="server">
		                <Template_Description>
		                    Select the Publishing Type that will be used.
		                </Template_Description>
		                <Template_InputFormControls>
			                <wssuc:InputFormControl LabelText="" runat="server">
				                 <Template_Control>
				                    <asp:DropDownList ID="ddlPubType" runat="server">
				                        <asp:ListItem Text="Not Set" Value=""></asp:ListItem>
				                        <asp:ListItem Text="Assignment Based" Value="1"></asp:ListItem>
				                        <asp:ListItem Text="Task Based" Value="2"></asp:ListItem>
				                        <asp:ListItem Text="Task Based w/o Assignment (Project Server Only)" Value="3"></asp:ListItem>
				                    </asp:DropDownList>
				                 </Template_Control>
			                </wssuc:InputFormControl>
		                </Template_InputFormControls>
	                </wssuc:InputFormSection>

	                <wssuc:InputFormSection Title="Publishing Options"
		                Description=""
		                runat="server">
		                <Template_Description>
		                    
		                </Template_Description>
		                <Template_InputFormControls>
			                <wssuc:InputFormControl LabelText="Publish Summary Tasks" runat="server">
				                 <Template_Control>
				                    <asp:DropDownList ID="ddlSummary" runat="server">
				                        <asp:ListItem Text="Not Set" Value=""></asp:ListItem>
				                        <asp:ListItem Text="Yes" Value="True"></asp:ListItem>
				                        <asp:ListItem Text="No" Value="False"></asp:ListItem>
				                    </asp:DropDownList>
				                 </Template_Control>
			                </wssuc:InputFormControl>
			                <wssuc:InputFormControl LabelText="Publish Time-Phased Data" runat="server">
				                 <Template_Control>
				                    <asp:DropDownList ID="ddlTimePhased" runat="server">
				                        <asp:ListItem Text="Not Set" Value=""></asp:ListItem>
				                        <asp:ListItem Text="Yes" Value="True"></asp:ListItem>
				                        <asp:ListItem Text="No" Value="False"></asp:ListItem>
				                    </asp:DropDownList>
				                 </Template_Control>
			                </wssuc:InputFormControl>
		                </Template_InputFormControls>
	                </wssuc:InputFormSection>
	                
	                <wssuc:InputFormSection Title="Field Settings"
		                Description=""
		                runat="server">
		                <Template_Description>
		                    These field settings are used to control the Project fields that are used to interact with SharePoint.
		                    <br /><br />
		                    The Publish Status Field is used to store the date/time the task was last published in order to determine if a task has been updated.
		                    <br /><br />
		                    The Resource Link Field is used to store the link for the resource from the Resource Pool in SharePoint.
		                </Template_Description>
		                <Template_InputFormControls>
			                <wssuc:InputFormControl LabelText="Publish Status Field" runat="server">
				                 <Template_Control>
				                    <asp:DropDownList ID="ddlPubStatus" runat="server">
				                        <asp:ListItem Text="Not Set" Value=""></asp:ListItem>
				                        <asp:ListItem Text="Text1" Value="Text1"></asp:ListItem>
				                        <asp:ListItem Text="Text2" Value="Text2"></asp:ListItem>
				                        <asp:ListItem Text="Text3" Value="Text3"></asp:ListItem>
				                        <asp:ListItem Text="Text4" Value="Text4"></asp:ListItem>
				                        <asp:ListItem Text="Text5" Value="Text5"></asp:ListItem>
				                        <asp:ListItem Text="Text6" Value="Text6"></asp:ListItem>
				                        <asp:ListItem Text="Text7" Value="Text7"></asp:ListItem>
				                        <asp:ListItem Text="Text8" Value="Text8"></asp:ListItem>
				                        <asp:ListItem Text="Text9" Value="Text9"></asp:ListItem>
				                        <asp:ListItem Text="Text10" Value="Text10"></asp:ListItem>
				                        <asp:ListItem Text="Text11" Value="Text11"></asp:ListItem>
				                        <asp:ListItem Text="Text12" Value="Text12"></asp:ListItem>
				                        <asp:ListItem Text="Text13" Value="Text13"></asp:ListItem>
				                        <asp:ListItem Text="Text14" Value="Text14"></asp:ListItem>
				                        <asp:ListItem Text="Text15" Value="Text15"></asp:ListItem>
				                        <asp:ListItem Text="Text16" Value="Text16"></asp:ListItem>
				                        <asp:ListItem Text="Text17" Value="Text17"></asp:ListItem>
				                        <asp:ListItem Text="Text18" Value="Text18"></asp:ListItem>
				                        <asp:ListItem Text="Text19" Value="Text19"></asp:ListItem>
				                        <asp:ListItem Text="Text20" Value="Text20"></asp:ListItem>
				                        <asp:ListItem Text="Text21" Value="Text21"></asp:ListItem>
				                        <asp:ListItem Text="Text22" Value="Text22"></asp:ListItem>
				                        <asp:ListItem Text="Text23" Value="Text23"></asp:ListItem>
				                        <asp:ListItem Text="Text24" Value="Text24"></asp:ListItem>
				                        <asp:ListItem Text="Text25" Value="Text25"></asp:ListItem>
				                        <asp:ListItem Text="Text26" Value="Text26"></asp:ListItem>
				                        <asp:ListItem Text="Text27" Value="Text27"></asp:ListItem>
				                        <asp:ListItem Text="Text28" Value="Text28"></asp:ListItem>
				                        <asp:ListItem Text="Text29" Value="Text29"></asp:ListItem>
				                        <asp:ListItem Text="Text30" Value="Text30"></asp:ListItem>
				                    </asp:DropDownList>
				                 </Template_Control>
			                </wssuc:InputFormControl>
			                <wssuc:InputFormControl LabelText="Resource Link Field" runat="server">
				                 <Template_Control>
				                    <asp:DropDownList ID="ddlResourceLink" runat="server">
				                        <asp:ListItem Text="Not Set" Value=""></asp:ListItem>
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
		                </Template_InputFormControls>
	                </wssuc:InputFormSection>
	                <wssuc:InputFormSection Title="Synch Fields on Open"
		                Description=""
		                runat="server">
		                <Template_Description>
		                    Use this option to force publisher to synchronize choice fields on open of a project.
		                </Template_Description>
		                <Template_InputFormControls>
			                <wssuc:InputFormControl LabelText="" runat="server">
				                 <Template_Control>
                                    <asp:DropDownList ID="ddlSynchFields" runat="server">
				                        <asp:ListItem Text="Not Set" Value=""></asp:ListItem>
				                        <asp:ListItem Text="Yes" Value="True"></asp:ListItem>
				                        <asp:ListItem Text="No" Value="False"></asp:ListItem>
				                    </asp:DropDownList>
				                 </Template_Control>
			                </wssuc:InputFormControl>
		                </Template_InputFormControls>
	                </wssuc:InputFormSection>
	                <wssuc:InputFormSection Title="Use Resource Pool"
		                Description=""
		                runat="server" Visible="false">
		                <Template_Description>
		                    Use this option to use the EPM Live resource pool with project publisher
		                </Template_Description>
		                <Template_InputFormControls>
			                <wssuc:InputFormControl LabelText="Use Resource Pool" runat="server">
				                 <Template_Control>
                                    <asp:CheckBox ID="chkUseRes" runat="server" />
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
                    <wssawc:FormDigest ID="FormDigest1" runat="server" />
                    
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>