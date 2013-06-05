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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newapp.aspx.cs" Inherits="EPMLiveCore.newapp" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	New <%=strName %>
</asp:Content>
<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	New <%=strName %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
<asp:Panel ID="Panel4" runat="server" Visible="true">
    Use this page to create a new <%=strName %>. Select an option below to continue.
</asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
<asp:Panel ID="Panel2" runat="server" Visible="false">
    <font color="red"><asp:Label ID="label1" runat="server"></asp:Label></font>
</asp:Panel>

<script language="javascript">

</script>
    <link rel="STYLESHEET" type="text/css" href="dhtml/xgrid/dhtmlxgrid.css"/>
    <link rel="STYLESHEET" type="text/css" href="dhtml/xgrid/dhtmlxgrid_skins.css"/>

    <script>        _css_prefix = "DHTML/xgrid/"; _js_prefix = "DHTML/xgrid/"; </script>

    <script src="DHTML/xgrid/dhtmlxcommon.js"></script>
    <script src="DHTML/xgrid/dhtmlxgrid.js"></script>
    <script src="DHTML/xgrid/dhtmlxgridcell.js"></script>
    <script src="DHTML/xtreegrid/dhtmlxtreegrid.js"></script>
    <script src="newapp.js"></script>

    <style>.menuTable{background-color:#ffffff;}.contextMenuover, .contextMenudown{background-color:#9ac2e5;}.contextMenuover td{color:#000000;} </style>



<asp:HiddenField ID="link" runat="server"/>
<asp:HiddenField ID="site" runat="server"/>
<input type="hidden" name="hdnSelectedWorkspace" id="hdnSelectedWorkspace" />
<input type="hidden" name="hdnWorkspaceType" id="hdnWorkspaceType"/>
<input type="hidden" name="baseurl" value="<%=this.URL%>" id="baseurl"/>

<TABLE border="0" cellspacing="0" cellpadding="0" class="ms-propertysheet">

<wssuc:InputFormSection Title="Name"
		runat="server" width="10" id="inpName">
		<Template_Description>

        
        
		</Template_Description>
		<Template_InputFormControls>
		    <wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
		           <img src="/_layouts/images/blank.gif" width="600" height="1" />
<wssawc:InputFormTextBox Title="Title" class="ms-input" ID="txtTitle" Columns="67" Runat="server" MaxLength=255 />
		            <asp:Panel ID="pnlTitle" runat=server Visible =false><font color="red">Please enter a Title.</font></asp:Panel>
		            
				
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
    <wssuc:InputFormSection Title="Workspace Type"
		runat="server" width="10">
		<Template_Description>
		    Select whether you would like to create a new workspace or use an existing
		</Template_Description>
		<Template_InputFormControls>
		    <wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
		           

				<input type="radio" name="rdoWorkspace" value="New" onclick="javascript:newWorkspace();" <%=wsTypeNew %>/> New Workspace<br />
                <input type="radio" name="rdoWorkspace" value="Existing" onclick="javascript:existingWorkspace('<%=listName%>');" <%=wsTypeExisting %>/> Existing Workspace<br />

				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	<wssuc:InputFormSection Title="Select Template"
		runat="server" width="10">
		<Template_Description>
		    Start with one of our pre-built templates, customize it to fit your needs and save it as a template for future use.
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
	<wssuc:InputFormSection Title="Enter Workspace URL"
		Description="Type a title and url for your new site. The title will be displayed on each page in the site."
		runat="server" width="10">
		<Template_InputFormControls>
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
							    <asp:RadioButton ID="rdoInherit" runat="server" GroupName="perms" />
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
	
	<wssuc:InputFormSection Title="Select Workspace"
		Description=""
		runat="server" width="10">
		<Template_Description>
		                <div  width="600" id="loadinggrid" align="center">
    	        <img src="../images/GEARS_AN.GIF" style="vertical-align: middle;"/> Loading Workspaces...
            </div>
		</Template_Description>
		<Template_InputFormControls>
		    <wssuc:InputFormControl LabelText="" runat="server">
                <Template_Control>
                    <div id="grid" style="width:600;height:300;display:none;" ></div>
                </Template_Control>
            </wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
    <wssuc:ButtonSection runat="server" ShowStandardCancelButton="false">
		<Template_Buttons>
			<asp:PlaceHolder ID="PlaceHolder1" runat="server">
				<asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="BtnOK_Click" Text="Create Project" id="btnOK" accesskey="" Width="150" OnClientClick="if(!checkUrl()){return;};"/>
                 <input type=button value="Cancel" onClick="history.go(-1)" class="ms-ButtonHeightWidth">
			</asp:PlaceHolder>
		</Template_Buttons>
	</wssuc:ButtonSection>
</table>

<script language="javascript">
    mygrid = new dhtmlXGridObject('grid');

    mygrid.setImagePath("dhtml/xgrid/imgs/");
    mygrid.setSkin("modern");

    mygrid.setImageSize(1, 1);
    mygrid.attachEvent("onXLE", clearLoader);
    mygrid.attachEvent("onRowSelect", mygridChange);
    mygrid.enableAutoHeigth(true);
    mygrid.init();

    newWorkspace();
</script>
</asp:Content>

