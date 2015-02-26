<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enterprisefields.aspx.cs" Inherits="EPMLiveEnterprise.Layouts.epmlive.enterprisefields" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	WorkEngine for Project Server Field Synchronization
</asp:Content>
<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	WorkEngine for Project Server Field Synchronization
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to select which Project Server Fields will be published to the Task Center and Project Center in each project workspace.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
<script src="DHTML/xgrid/dhtmlxcommon.js"></script>
<script src="DHTML/dhtmlxajax.js"></script>
<link rel="stylesheet" href="modal/modal.css" type="text/css" /> 
<script type="text/javascript" src="modal/modal.js"></script>

<div id="dlgAction" class="dialog">
    <table width="100%">
        <tr>
            <td align="center" class="ms-sectionheader">
                <img src="../images/GEARS_AN.GIF" style="vertical-align: middle;"/><br />
                <H3 class="ms-standardheader" id="dlgHAction">Starting Synch...</h3>
            </td>
        </tr>
        
    </table>
</div> 
<style>
.cell {border-left: solid 1px #9C9C9C; border-right: solid 1px #9C9C9C; border-bottom: solid 1px #9C9C9C}

</style>
 <table border="0" cellpadding="0" cellspacing="0" width="100%">

    <tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
    <tr><td class="ms-linksectionheader" colspan="2"><h3 class="ms-standardheader">Synchronization Log</h3></td></tr>
    </table></td></tr>
    
    <wssuc:InputFormSection Title="Synchronization Results"
		Description=""
		runat="server">
		<Template_Description>
		    
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Last Synchronization Time" runat="server">
				 <Template_Control>
				    <asp:Label ID="lblLastSyncTime" runat="server" />
				    <br />
				    <img src="blank.gif" width="400" height="1"/>
				 </Template_Control>
			</wssuc:InputFormControl>

			<wssuc:InputFormControl LabelText="Last Synchronization Results" runat="server">
				 <Template_Control>
				    <asp:Label ID="lblLastSyncResults" runat="server" />
				    <br />
				    <img src="blank.gif" width="400" height="1"/>
				 </Template_Control>
			</wssuc:InputFormControl>

            <wssuc:InputFormControl LabelText="Synchronization Log" runat="server">
				 <Template_Control>
                    <a href="esynchlog.aspx">View Log</a>
                    <br />
                    <img src="blank.gif" width="400" height="1"/>
				 </Template_Control>
			</wssuc:InputFormControl>
			
			<wssuc:InputFormControl LabelText="Synchronize Now" runat="server" id="inpSynch">
				 <Template_Control>
                    <a href="javascript:runSynch()">Synchronize</a>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
		
	</wssuc:InputFormSection>
    
    <tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
    <tr><td class="ms-linksectionheader" colspan="2"><h3 class="ms-standardheader">Enterprise Fields</h3></td></tr>
    </table></td></tr>
    
    <tr>
        <td colspan="2">
            <table  cellpadding="10">
                <tr>
                    <td valign="top" colspan="2">
                    <font class="ms-sectionheader" style="font-size: X-SMall">Project Center Fields<br /><br />
                    <table border="0" cellpadding="0" cellspacing="0" width="300">
                            <tr>
                                <td bgcolor="" width="100%">
                                    <table class="ms-toolbar" width="100%" cellpadding="3">
                                        <tr><td class="ms-sectionheader">Field Name</td></tr>
                                    </table>
                                </td>
                                <td class="ms-sectionheader">
                                    <table class="ms-toolbar" width="100%" cellpadding="3">
                                        <tr><td class="ms-sectionheader">Delete</td></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" bgcolor="#F8F8F8" class="ms-sectionheader" style="border-left: solid 1px #9C9C9C; border-right: solid 1px #9C9C9C; border-bottom: solid 1px #9C9C9C; padding:3px">
                                    <font class="ms-descriptiontext">Custom Fields</font> <a href="#" class="ms-" onclick="window.open('<%=serverUrl %>/_layouts/15/epmlive/addfield.aspx?type=2&pj=1','addfield','height=250,width=250,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes');">[Add Field]</a>
                                </td>
                            </tr>
                            <%=pjcustomFields %>
                            <tr>
                                <td colspan="3" bgcolor="#F8F8F8" class="ms-sectionheader" style="border-left: solid 1px #9C9C9C; border-right: solid 1px #9C9C9C; border-bottom: solid 1px #9C9C9C; padding:3px">
                                    <font class="ms-descriptiontext">Task Enterprise Fields</font> <a href="#" class="ms-" onclick="window.open('<%=serverUrl %>/_layouts/15/epmlive/addfield.aspx?type=3&pj=1','addfield','height=250,width=250,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes');">[Add Field]</a>
                                </td>
                            </tr>
                            <%=pjenterpriseFields %>
                            <tr>
                                <td colspan="3" bgcolor="#F8F8F8" class="ms-sectionheader" style="border-left: solid 1px #9C9C9C; border-right: solid 1px #9C9C9C; border-bottom: solid 1px #9C9C9C; padding:3px">
                                    <font class="ms-descriptiontext">Project Enterprise Fields</font> <a href="#" class="ms-" onclick="window.open('<%=serverUrl %>/_layouts/15/epmlive/addfield.aspx?type=4&pj=1','addfield','height=250,width=250,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes');">[Add Field]</a>
                                </td>
                            </tr>
                            <%=pjpjenterpriseFields %>
                        </table>  
                    </td>
                    <td valign="top">
                        <font class="ms-sectionheader" style="font-size: X-SMall">Task Center Fields<br /><br />
                        <table border="0" cellpadding="0" cellspacing="0" width="300">
                           
                            <tr>
                                <td bgcolor="" width="100%">
                                    <table class="ms-toolbar" width="100%" cellpadding="3">
                                        <tr><td class="ms-sectionheader">Field Name</td></tr>
                                    </table>
                                </td>
                                <td class="ms-sectionheader">
                                    <table class="ms-toolbar" width="100%" cellpadding="3">
                                        <tr><td class="ms-sectionheader">Delete</td></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" bgcolor="#F8F8F8" class="ms-sectionheader" style="border-left: solid 1px #9C9C9C; border-right: solid 1px #9C9C9C; border-bottom: solid 1px #9C9C9C; padding:3px">
                                    <font class="ms-descriptiontext">Custom Fields</font> <a href="#" class="ms-" onclick="window.open('<%=serverUrl %>/_layouts/15/epmlive/addfield.aspx?type=2','addfield','height=250,width=300,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes');">[Add Field]</a>
                                </td>
                            </tr>
                            <%=customFields %>
                            <tr>
                                <td colspan="3" bgcolor="#F8F8F8" class="ms-sectionheader" style="border-left: solid 1px #9C9C9C; border-right: solid 1px #9C9C9C; border-bottom: solid 1px #9C9C9C; padding:3px">
                                    <font class="ms-descriptiontext">Task Enterprise Fields</font> <a href="#" class="ms-" onclick="window.open('<%=serverUrl %>/_layouts/15/epmlive/addfield.aspx?type=3','addfield','height=250,width=300,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes');">[Add Field]</a>
                                </td>
                            </tr>
                            <%=enterpriseFields %>
                        </table>    
                    </td>
                </tr>        
            </table>
        </td>
        
        
    </tr>
    <tr>
        <td colspan="2" align="right" style="padding=3px"><asp:Button class="ms-ButtonHeightWidth" ID="Button2" runat="server" Text="Done" OnClick="Button1_Click" /></td>
    </tr>
</table>

<script language="javascript">

    function runSynch() {
        sm('dlgAction', 200, 100);
        dhtmlxAjax.post("<%=serverUrl%>/_layouts/15/epmlive/runenterprisesynch.aspx", "", closeDone);
    }

    function closeDone(loader) {
        if (loader.xmlDoc.responseText != null) {
            if (loader.xmlDoc.responseText.substring(0, 5) != "Error") {
                var strPeriod = loader.xmlDoc.responseText;
                newURL = "<%=serverUrl%>/_layouts/15/epmlive/enterprisefields.aspx";

                window.location.href = newURL;
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

    initmb();
    </script>
    
</asp:Content>