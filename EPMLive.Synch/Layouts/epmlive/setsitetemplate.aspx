<%@ Assembly Name="EPMLiveSynch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveSynch.SetSiteTemplatePage" MasterPageFile="~/_layouts/application.master"%> 

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="Set Site Template" EncodeMethod='HtmlEncode'/>
</asp:Content>

<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	<asp:Label ID="lblTitle" runat="server" Text="Set Site Template"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
<asp:Panel ID="Panel4" runat="server" Visible="true">
    Use this page to set which template is associated with this site.
</asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
<asp:Panel ID="Panel2" runat="server" Visible="false">
    <font color="red"><asp:Label ID="label1" runat="server"></asp:Label></font>
</asp:Panel>

	<SCRIPT language='javascript' src='/_layouts/datepicker.js'></SCRIPT><SCRIPT language='javascript'>var g_strDateTimeControlIDs = new Array();</SCRIPT>
	<script> var MSOWebPartPageFormName = 'aspnetForm';</script><script type="text/JavaScript" language="JavaScript">
    <!--
    var L_Menu_BaseUrl="/sites/test1";
    var L_Menu_LCID="1033";
    var L_Menu_SiteTheme="";
    //-->
    </script>

<TABLE border="0" cellspacing="0" cellpadding="0" class="ms-propertysheet">
	<wssuc:InputFormSection Title="Selected Template"
		Description="This is the template that is associated with this site."
		runat="server" width="10">
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="" runat="server">
				 <Template_Control>
                    <asp:Label ID="lblSelectedTemplate" BackColor="White" Width="600" Height="20" style="vertical-align:middle;font-weight:bold;" runat="server" Text="-- This website is not based on a template. --"></asp:Label>
				 </Template_Control>
			</wssuc:InputFormControl>
			<img src="/_layouts/images/blank.gif" width="600" height="1" />
		</Template_InputFormControls>
	</wssuc:InputFormSection>
    <wssuc:InputFormSection Title="Select Template"
		Description=""
		runat="server" width="10">
		<Template_Description>
		 The grid on the right displays all the templates available for association with this site.               
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
                        <input type="hidden" name="selectedWebID" value="" />
                        <input type="hidden" name="TemplateSelected" value="false" />
                        <input type="hidden" name="SiteURL" value="<% Response.Write(sSiteUrl); %>" />
                        <script>_css_prefix="/_layouts/epmlive/DHTML/xgrid/"; _js_prefix="/_layouts/epmlive/DHTML/xgrid/"; </script>
                        <div id="grid" style="width:600;height:300;display:none;" ></div>
                        <div id="loadinggrid" width="600" align="center">
                        <img src="/_layouts/images/GEARS_AN.GIF" style="vertical-align: middle;"/> Loading Items...
                        </div>
                        <script>
                            var sSiteURL = document.getElementById("SiteURL").value;
                            mygrid = new dhtmlXGridObject('grid');
                            mygrid.setImagePath('/_layouts/epmlive/DHTML/xgrid/imgs/');
                            mygrid.setSkin('modern');
                            mygrid.setImageSize(16,16);
                            mygrid.attachEvent('onXLE',clearLoader);
                            mygrid.attachEvent('onRowSelect',setSelectedRowId);
                            mygrid.enableAutoHeigth(true);
                            mygrid.init();
                            mygrid.loadXML(sSiteURL + '/_layouts/epmlive/gettemplatesxml.aspx?ttype=tmpltcolonly');

                            function clearLoader(id)
                            { 
                                document.getElementById("grid").style.display = "";
                                document.getElementById("loadinggrid").style.display = "none";
                            }
                            function setSelectedRowId(id)
                            {
                                if (id.substring(0,3) == '---')
                                {
                                   document.getElementById("selectedWebID").value = '';
                                   alert('Please choose a site that is a template');
                                }
                                else
                                {
                                   document.getElementById("selectedWebID").value = id;
                                   document.getElementById("TemplateSelected").value = 'true';
                                }
                            }
                            function setSelectedTemplate()
                            {
                                if (document.getElementById("selectedWebID").value == '')
                                {
                                    alert('Please select a template site.');
                                }
                                else
                                {
                                    var url = document.getElementById("SiteURL").value + '/_layouts/epmlive/templates.aspx';
                                    var sParams = "?TrnxType=set&TemplateID=" + document.getElementById("selectedWebID").value;
                                    window.location = url + sParams;
                                }        
                            }
                            function clearSelectedTemplate()
                            {
                                var url = document.getElementById("SiteURL").value + '/_layouts/epmlive/templates.aspx';
                                var sParams = "?TrnxType=clear";
                                window.location = url + sParams;
                            }
                       </script>
                </Template_Control>
            </wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>

    <wssuc:ButtonSection runat="server">
		<Template_Buttons>
			<asp:PlaceHolder ID="PlaceHolder1" runat="server">
                <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" Text=" Remove Association " id="btnClear" accesskey="" Width="250" OnClientClick="Javascript:return clearSelectedTemplate();"/>
                <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" Text=" Set Association " id="Button1" accesskey="" Width="250" OnClientClick="Javascript:return setSelectedTemplate();"/>
			</asp:PlaceHolder>
		</Template_Buttons>
	</wssuc:ButtonSection>
</table>

</asp:Content>

