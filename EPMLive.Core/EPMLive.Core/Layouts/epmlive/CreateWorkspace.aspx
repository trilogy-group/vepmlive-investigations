<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveCore.CreateWorkspace" MasterPageFile="~/_layouts/application.master"%> 

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="Create Workspace" EncodeMethod='HtmlEncode'/>
</asp:Content>

<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	<asp:Label ID="lblTitle" runat="server" Text="Create Workspace"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
<asp:Panel ID="Panel4" runat="server" Visible="true">
    Use this page to create a workspace for your project.
</asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
<asp:Panel ID="Panel2" runat="server" Visible="false">
    <font color="red"><asp:Label ID="label1" runat="server"></asp:Label></font>
</asp:Panel>
<asp:Panel ID="Panel1" runat="server" Visible="true">
	</SCRIPT><SCRIPT language='javascript' src='/_layouts/datepicker.js'></SCRIPT><SCRIPT language='javascript'>var g_strDateTimeControlIDs = new Array();</SCRIPT>
	<script> var MSOWebPartPageFormName = 'aspnetForm';</script><script type="text/JavaScript" language="JavaScript">
<!--
var L_Menu_BaseUrl="/sites/test1";
var L_Menu_LCID="1033";
var L_Menu_SiteTheme="";
//-->
</script>

<!--
var EntityEditor_UseContentEditableControl = true;// -->
</script>
<TABLE border="0" cellspacing="0" cellpadding="0" class="ms-propertysheet">
<asp:HiddenField ID="link" runat="server"/>
<asp:HiddenField ID="site" runat="server"/>

<asp:Panel ID="pnlWorkspace" runat="server">
<asp:Panel ID="pnlHideTemplate" runat="Server">
	<wssuc:InputFormSection Title="Select Template"
		runat="server" width="10">
		<Template_Description>
		    Start with one of our pre-built templates, customize it to fit your needs and save it as a template for future use.  To find out more about each template <a href="http://www.epmlive.com/workspacehelp/templates.htm" target="_blank">click here</a>.
		</Template_Description>
		<Template_InputFormControls>
		    <wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
		            <asp:DropDownList
				id="DdlGroup"
				runat="server">

				</asp:DropDownList>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	</asp:Panel>
	<wssuc:InputFormSection Title="Enter Workspace Information"
		Description="Type a title and url for your new site. The title will be displayed on each page in the site."
		runat="server" width="10">
		<Template_InputFormControls>
		    <asp:Panel ID="pnlHideTitle" runat="Server">
			<wssuc:InputFormControl LabelText="Title" runat="server">
				 <Template_Control>
		            <wssawc:InputFormTextBox Title="Title" class="ms-input" ID="txtTitle" Columns="67" Runat="server" MaxLength=255 />
		            <asp:Panel ID="pnlTitle" runat=server Visible =false><font color="red">Please enter a Title.</font></asp:Panel>
		            
				 </Template_Control>
			</wssuc:InputFormControl>
			</asp:Panel>
			<img src="/_layouts/images/blank.gif" width="600" height="1" />
			<wssuc:InputFormControl LabelText="URL" runat="server"> 
			
				 <Template_Control>
		    <%=this.baseURL%><asp:TextBox Title="URL" class="ms-input" ID="txtURL" Columns="40" Runat="server" MaxLength=255 />
		    <asp:Panel ID="pnlURL" runat=server Visible =false><font color="red">Please enter a URL.</font></asp:Panel>
		    <asp:Panel ID="pnlURLBad" runat=server Visible =false><font color="red">URL must contain only letters and numbers.</font></asp:Panel>
		    <asp:Panel ID="pnlNotExist" runat=server Visible =false><font color="red">That site does not exist.</font></asp:Panel>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	
</asp:Panel>
<!------------------------------------->
<wssuc:InputFormSection Title="Navigation Inheritance"
		Description="Specify whether this site shares the same top link bar as the parent. This setting may also determine the starting element of the breadcrumb."
		runat="server" width="10">
		<Template_InputFormControls>
            <img src="/_layouts/images/blank.gif" width="600" height="1" />
			<wssuc:InputFormControl LabelText="" runat="server"> 
			    <Template_LabelText>
			        <img src="/_layouts/images/topnav.gif" align="left" /> Use the top link bar from the parent site? 
			    </Template_LabelText>
				 <Template_Control>
		               <asp:RadioButton ID="rdoTopLinkYes" runat="server" Text="Yes" Checked="true" GroupName="TopLink"/>
		               <asp:RadioButton ID="rdoTopLinkNo" runat="server" Text="No" GroupName="TopLink"/>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	
	<wssuc:InputFormSection 
		Title="<%$Resources:wss,newsbweb_idInputTitleContent%>"
	    Description="<%$Resources:wss,newsbweb_idInputDescriptionContent%>"
		runat="server" width="10">
		<Template_InputFormControls>
		    <wssuc:InputFormControl LabelText="<%$Resources:wss,newsbweb_idInputLabelPermissions%>"
			    SmallIndent="true"
			    runat="server">
			    <Template_Control>
				    <TABLE border="0" width="100%" cellspacing="0" cellpadding="0">
					    <TR>
						    <TD valign="top" width="1px">
							    <asp:RadioButton ID="rdoInherrit" runat="server" GroupName="perms" />
						    </TD>
						    <TD width="1px"><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></TD>
						    <TD nowrap class="ms-authoringcontrols">
							    <SharePoint:EncodedLiteral ID="EncodedLiteral2" runat="server" text="<%$Resources:wss,newsbweb_usesameperm%>" EncodeMethod='HtmlEncode'/></TD>
					    </TR>
					    <TR>
						    <TD valign="top" width="1px">
							    <asp:RadioButton ID="rdoUnique" runat="server" GroupName="perms" Checked="true" />
						    </TD>
						    <TD width="1px"><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></TD>
						    <TD nowrap class="ms-authoringcontrols">
							    <SharePoint:EncodedLiteral ID="EncodedLiteral3" runat="server" text="<%$Resources:wss,newsbweb_useuniqueperm%>" EncodeMethod='HtmlEncode'/>
						    </TD>
					    </TR>
				    </TABLE>
			    </Template_Control>
		    </wssuc:InputFormControl>
	    </Template_InputFormControls>
	</wssuc:InputFormSection>
    <wssuc:ButtonSection runat="server">
		<Template_Buttons>
			<asp:PlaceHolder ID="PlaceHolder1" runat="server">
				<asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="BtnOK_Click" Text="Create Workspace" id="btnOK" accesskey="" Width="150"/>
			</asp:PlaceHolder>
		</Template_Buttons>
	</wssuc:ButtonSection>
</table>
</asp:Panel>
</asp:Content>

