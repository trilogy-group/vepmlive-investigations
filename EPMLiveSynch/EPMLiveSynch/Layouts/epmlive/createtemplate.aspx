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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createtemplate.aspx.cs" Inherits="EPMLiveSynch.Layouts.epmlive.createtemplate" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="Create Template" EncodeMethod='HtmlEncode'/>
</asp:Content>

<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	<asp:Label ID="lblTitle" runat="server" Text="Create Template"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
<asp:Panel ID="Panel4" runat="server" Visible="true">
    Use this page to create a template.
</asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
<asp:Panel ID="Panel2" runat="server" Visible="false">
    <font color="red"><asp:Label ID="label1" runat="server"></asp:Label></font>
</asp:Panel>

	<SCRIPT language='javascript' src='/_layouts/datepicker.js'></SCRIPT><SCRIPT language='javascript'>	                                                                         var g_strDateTimeControlIDs = new Array();</SCRIPT>
	<script>	    var MSOWebPartPageFormName = 'aspnetForm';</script><script type="text/JavaScript" language="JavaScript">
<!--
	                                                                var L_Menu_BaseUrl = "/sites/test1";
	                                                                var L_Menu_LCID = "1033";
	                                                                var L_Menu_SiteTheme = "";
//-->
</script>

<TABLE border="0" cellspacing="0" cellpadding="0" class="ms-propertysheet">
<asp:HiddenField ID="link" runat="server"/>
<asp:HiddenField ID="site" runat="server"/>
<input type="hidden" name="hdnSelectedWorkspace" id="hdnSelectedWorkspace" />
	<wssuc:InputFormSection Title="Enter Template Information"
		Description="Type a name & url for your new template."
		runat="server" width="10">
		<Template_InputFormControls>
		    <asp:Panel ID="pnlHideTitle" runat="Server">
			<wssuc:InputFormControl LabelText="Title" runat="server">
				 <Template_Control>
		            <wssawc:InputFormTextBox Title="Name" class="ms-input" ID="txtTitle" Columns="67" Runat="server" MaxLength=255 />
		            <asp:Panel ID="pnlTitle" runat=server Visible =false><font color="red">Please enter a Title.</font></asp:Panel>
				 </Template_Control>
			</wssuc:InputFormControl>
			</asp:Panel>
			<img src="/_layouts/images/blank.gif" width="600" height="1" />
			<wssuc:InputFormControl LabelText="URL" runat="server"> 
				 <Template_Control>
		    <asp:TextBox Title="URL" class="ms-input" ID="txtURL" Columns="40" Runat="server" MaxLength=255 />
		    <asp:Panel ID="pnlURL" runat=server Visible =false><font color="red">Please enter a URL.</font></asp:Panel>
		    <asp:Panel ID="pnlURLBad" runat=server Visible =false><font color="red">URL must contain only letters and numbers.</font></asp:Panel>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	<wssuc:InputFormSection Title="Select Template"
		runat="server" width="10">
		<Template_Description>
		</Template_Description>
		<Template_InputFormControls>
		    <wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
		            <asp:DropDownList id="DdlTemplate" runat="server">
				</asp:DropDownList>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
    <wssuc:InputFormSection Title="Select Site & URL"
		Description=""
		runat="server" width="10">
		<Template_Description>
		                Select the site that you would like the template to be created under.
		</Template_Description>
		<Template_InputFormControls>
		    <wssuc:InputFormControl LabelText="" runat="server">
                <Template_Control>
                    <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.css"/>
                    <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid_skins.css"/>
                    <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxcommon.js"></script>
                    <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.js"></script>
                    <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxgridcell.js"></script>
                    <script src="/_layouts/epmlive/DHTML/xtreegrid/dhtmlxtreegrid.js"></script>
                    <% string sSiteUrl = SPContext.Current.Web.Url; %>
                    <input type="hidden" name="SiteURL" id="SiteURL" value="<% Response.Write(sSiteUrl); %>" />
                    <script>                        _css_prefix = "/_layouts/epmlive/DHTML/xgrid/"; _js_prefix = "/_layouts/epmlive/DHTML/xgrid/"; </script>
                    <div id="grid" style="width:600;height:300;display:none;" ></div>
                    <div id="loadinggrid" width="600" align="center">
    	                <img src="../images/GEARS_AN.GIF" style="vertical-align: middle;"/> Loading Workspaces...
                    </div>
                    <script language="javascript">

                        var sSiteURL = document.getElementById("SiteURL").value;
                        mygrid = new dhtmlXGridObject('grid');
                        mygrid.setImagePath('dhtml/xgrid/imgs/');
                        mygrid.setSkin('modern');
                        mygrid.setImageSize(1, 1);
                        mygrid.attachEvent('onXLE', clearLoader);
                        mygrid.attachEvent('onRowSelect', mygridChange);
                        mygrid.enableAutoHeigth(true);
                        mygrid.init();
                        mygrid.loadXML(sSiteURL + '/_layouts/epmlive/getworkspacexml.aspx');

                        function clearLoader(id) {
                            document.getElementById("grid").style.display = "";
                            document.getElementById("loadinggrid").style.display = "none";
                        }

                        function mygridChange(id) {
                            document.getElementById("hdnSelectedWorkspace").value = id;
                        }

                        function checkWorkspace() {
                            if (document.getElementById("hdnSelectedWorkspace").value == "") {
                                alert('You must select a workspace');
                                return false;
                            }
                            else
                                return true;
                        }

                        function checkTitle() {
                            if (document.getElementById("<%=txtTitle.ClientID%>").value == "") {
                                alert('You must enter a title.');
                                document.getElementById("<%=txtTitle.ClientID%>").focus();
                                return false;
                            }
                            else
                                return true;
                        }

                        function checkURL() {
                            if (document.getElementById("<%=txtURL.ClientID%>").value == "") {
                                alert('You must enter a url.');
                                document.getElementById("<%=txtURL.ClientID%>").focus();
                                return false;
                            }
                            else
                                return true;
                        }

                        function validateForm() {
                            if (!checkTitle() | !checkURL() | !checkWorkspace()) {
                                return false;
                            }
                            else {
                                return true;
                            }
                        }
                        
                    </script>
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
    <wssuc:ButtonSection runat="server">
		<Template_Buttons>
			<asp:PlaceHolder ID="PlaceHolder1" runat="server">
                <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="BtnOK_Click" Text="Create Template" id="btnOK" accesskey="" Width="150" OnClientClick="if(!validateForm()){return;};"/>
			</asp:PlaceHolder>
		</Template_Buttons>
	</wssuc:ButtonSection>
</table>

</asp:Content>

