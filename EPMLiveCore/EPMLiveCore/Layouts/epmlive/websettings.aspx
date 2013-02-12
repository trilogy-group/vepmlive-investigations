<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="websettings.aspx.cs" Inherits="EPMLiveCore.websettings" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
            
                <wssuc:InputFormSection Title="Master Page Configuration"
	                Description=""
	                runat="server">
	                <Template_Description>
	                    Choose the master page to use on this site.
	                </Template_Description>
	                <Template_InputFormControls>
		                <wssuc:InputFormControl LabelText="" runat="server">
			                 <Template_Control>
			                    <asp:DropDownList ID="ddlMasterPages" runat="server">
			                    </asp:DropDownList>
			                 </Template_Control>
		                </wssuc:InputFormControl>
	                </Template_InputFormControls>
                </wssuc:InputFormSection>
                
                <wssuc:InputFormSection Title="Disable Microsoft Project"
	                Description=""
	                runat="server">
	                <Template_Description>
	                    Check this box to prevent users from publishing to this site.
	                </Template_Description>
	                <Template_InputFormControls>
		                <wssuc:InputFormControl LabelText="" runat="server">
			                 <Template_Control>
			                    <asp:CheckBox ID="chkDisablePublishing" runat="server" Text="Disable Publishing"/>
			                 </Template_Control>
		                </wssuc:InputFormControl>
	                </Template_InputFormControls>
                </wssuc:InputFormSection>
                
                 <wssuc:InputFormSection Title="Disable Planners"
	                Description=""
	                runat="server">
	                <Template_Description>
	                    This will prevent any planners from being used on this site.
	                </Template_Description>
	                <Template_InputFormControls>
		                <wssuc:InputFormControl LabelText="" runat="server">
			                 <Template_Control>
			                    <asp:CheckBox ID="chkDisablePlanners" runat="server" Text="Disable Planners"/>
			                 </Template_Control>
		                </wssuc:InputFormControl>
	                </Template_InputFormControls>
                </wssuc:InputFormSection>

                <wssuc:InputFormSection Title="Disable Contextual Slideouts"
	                Description=""
	                runat="server">
	                <Template_Description>
	                    This will prevent any contextual slideouts from being used on this site.
	                </Template_Description>
	                <Template_InputFormControls>
		                <wssuc:InputFormControl LabelText="" runat="server">
			                 <Template_Control>
			                    <asp:CheckBox ID="chkDisableContextualSlideouts" runat="server" Text="Disable Contextual Slideouts"/>
			                 </Template_Control>
		                </wssuc:InputFormControl>
	                </Template_InputFormControls>
                </wssuc:InputFormSection>
                
                <asp:Panel ID="pnlResources" runat="server" Visible="false">
                    <wssuc:InputFormSection Title="Resources List"
	                    Description=""
	                    runat="server">
	                    <Template_Description>
	                        Use this page to specify the Resource Pool List.
	                    </Template_Description>
	                    <Template_InputFormControls>
		                    <wssuc:InputFormControl LabelText="" runat="server">
			                     <Template_Control>
			                        <asp:DropDownList ID="ddlResources" runat="Server">
    			                    
			                        </asp:DropDownList>
			                     </Template_Control>
		                    </wssuc:InputFormControl>
	                    </Template_InputFormControls>
                    </wssuc:InputFormSection>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlAllowSynch">
                     <wssuc:InputFormSection Title="Allow Enterprise Field Synchronization"
	                    Description=""
	                    runat="server">
	                    <Template_Description>
	                        Check this box to allow Fields in this site to be managed by the Enterprise Field Synchronization utility.
	                    </Template_Description>
	                    <Template_InputFormControls>
		                    <wssuc:InputFormControl LabelText="" runat="server">
			                     <Template_Control>
			                        <asp:CheckBox ID="chkAllowSynch" runat="server" Text="Allow Synchronization"/>
			                     </Template_Control>
		                    </wssuc:InputFormControl>
	                    </Template_InputFormControls>
                    </wssuc:InputFormSection>
                    <wssuc:InputFormSection Title="Select Template" Visible="false"
		            Description=""
		            runat="server" width="10">
		            <Template_Description>
            		    Each EPM Live site has the ability to be associated with a template so that changes can be made in the template and then pushed down to associated sites in order to keep fields, views, and settings consistent. 
                        <br /><Br />
                        This site's template association is shown on the right.  To change the template association, remove the existing association and then select a new template from the list of templates displayed in the grid.

		            </Template_Description>
		            <Template_InputFormControls>
		                <Template_InputFormControls>
			                <wssuc:InputFormControl LabelText="Current Template Association" runat="server">
				                 <Template_Control>
                                    <asp:Label ID="lblSelectedTemplate" Height="20" style="vertical-align:middle;font-weight:bold;" runat="server" Text="-- This site does not have a template association --"></asp:Label>
                                    <a href="javascript:clearSelectedTemplate()">[Remove Association]</a>
				                 </Template_Control>
			                </wssuc:InputFormControl>
			                <img src="/_layouts/images/blank.gif" width="600" height="1" />
		                </Template_InputFormControls>
		                <wssuc:InputFormControl LabelText="New Template Association" runat="server">
                            <Template_Control>
                                <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.css"/>
                                <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid_skins.css"/>
                                <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxcommon.js"></script>
                                <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.js"></script>
                                <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxgridcell.js"></script>
                                <script src="/_layouts/epmlive/DHTML/xtreegrid/dhtmlxtreegrid.js"></script>
                                    <input type="hidden" name="selectedWebID" value="" />
                                    <input type="hidden" name="TemplateSelected" value="false" />
                                    <script>                                        _css_prefix = "/_layouts/epmlive/DHTML/xgrid/"; _js_prefix = "/_layouts/epmlive/DHTML/xgrid/"; </script>
                                    <div id="grid" style="width:600;height:300;display:none;" ></div>
                                    <div id="loadinggrid" width="600" align="center">
                                    <img src="/_layouts/images/GEARS_AN.GIF" style="vertical-align: middle;"/> Loading Items...
                                    </div>
                                    <script>
                                        var sSiteURL = "<%=strSiteUrl %>";
                                        mygrid = new dhtmlXGridObject('grid');
                                        mygrid.setImagePath('/_layouts/epmlive/DHTML/xgrid/imgs/');
                                        mygrid.setSkin('modern');
                                        mygrid.setImageSize(16, 16);
                                        mygrid.attachEvent('onXLE', clearLoader);
                                        mygrid.attachEvent('onRowSelect', setSelectedRowId);
                                        mygrid.enableAutoHeigth(true);
                                        mygrid.init();
                                        mygrid.loadXML(sSiteURL + '/_layouts/epmlive/gettemplatesxml.aspx?ttype=tmpltcolonly');

                                        function clearLoader(id) {
                                            document.getElementById("grid").style.display = "";
                                            document.getElementById("loadinggrid").style.display = "none";
                                            mygrid.selectRowById('<%=strCurrentTemplate%>');
                                        }
                                        function setSelectedRowId(id) {
                                            if (id.substring(0, 3) == '---') {
                                                document.getElementById("selectedWebID").value = '';
                                                alert('Please choose a site that is a template');
                                                document.getElementById("TemplateSelected").value = 'false';
                                                mygrid.clearSelection();
                                            }
                                            else {
                                                document.getElementById("selectedWebID").value = id;
                                                document.getElementById("TemplateSelected").value = 'true';
                                            }
                                        }
                                        function clearSelectedTemplate() {
                                            document.getElementById("selectedWebID").value = "";
                                            document.getElementById("TemplateSelected").value = 'true';
                                            mygrid.clearSelection();
                                        }
                                   </script>
                            </Template_Control>
                        </wssuc:InputFormControl>
		            </Template_InputFormControls>
	            </wssuc:InputFormSection>
                    
                </asp:Panel>

                <wssuc:InputFormSection Title="Archive This Site"
	                Description=""
	                runat="server">
	                <Template_Description>
	                    Check this box to archive this site. All data in this site will not show up in grids.
	                </Template_Description>
	                <Template_InputFormControls>
		                <wssuc:InputFormControl LabelText="" runat="server">
			                 <Template_Control>
			                    <asp:CheckBox ID="chkArchive" runat="server" Text="Archive"/>
			                 </Template_Control>
		                </wssuc:InputFormControl>
	                </Template_InputFormControls>
                </wssuc:InputFormSection>

                 <wssuc:InputFormSection Title="Disable masterpage components"
	                Description=""
	                runat="server">
	                <Template_Description>
	                    Check box to disable components.
	                </Template_Description>
	                <Template_InputFormControls>
		                <wssuc:InputFormControl ID="InputFormControl1" LabelText="" runat="server">
			                 <Template_Control>
			                    <asp:CheckBox ID="cbDisableMyWorkspaces" runat="server" Text="Disable My Workspaces"/><br /><br />
                                <asp:CheckBox ID="cbDisableCommonActions" runat="server" Text="Disable Common Actions"/><br /><br />
                                <asp:CheckBox ID="cbDisableCreateNew" runat="server" Text="Disable Create New"/>
			                 </Template_Control>
		                </wssuc:InputFormControl>
	                </Template_InputFormControls>
                </wssuc:InputFormSection>

                <wssuc:InputFormSection Title="Template Version"
                    Description=""
                    runat="server">
                    <Template_Description>
                        
                    </Template_Description>
                    <Template_InputFormControls>
	                    <wssuc:InputFormControl LabelText="Version" runat="server">
		                     <Template_Control>
		                        <asp:Label ID="txtVersion" runat="server" Text="Unknown"/>
		                     </Template_Control>
	                    </wssuc:InputFormControl>
                    </Template_InputFormControls>
                </wssuc:InputFormSection>
                
                <wssuc:InputFormSection Title="General Information"
	                Description=""
	                runat="server">
	                <Template_Description>
	                </Template_Description>
	                <Template_InputFormControls>
		                <wssuc:InputFormControl LabelText="Site Id" runat="server">
			                 <Template_Control>
			                    <asp:Label id="lblSiteId" runat="server"></asp:Label>
			                 </Template_Control>
		                </wssuc:InputFormControl>
                        <wssuc:InputFormControl LabelText="Web Id" runat="server">
			                 <Template_Control>
			                    <asp:Label id="lblWebId" runat="server"></asp:Label>
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
        </table>
   </asp:Panel> 
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Web Settings
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Web Settings
</asp:Content>
