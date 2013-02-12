<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 

<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="timersettings.aspx.cs" Inherits="EPMLiveCore.timersettings" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="EPM Live Timer Settings" EncodeMethod='HtmlEncode'/>
</asp:Content>
<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	<asp:Label ID="lblTitle" runat="server" Text="EPM Live Timer Settings"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to control the EPM Live Timer Service settings
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
                <H3 class="ms-standardheader" id="dlgHAction">Starting Timer...</h3>
            </td>
        </tr>
        
    </table>
</div> 

<asp:Panel ID="pnlTL" runat="server" Visible="false" Width="100%">
        The Timer Service is configured at the site collection level.<br /><br />
        <asp:HyperLink Text="Click Here" NavigateUrl="" runat="server" ID="hlAdmin"></asp:HyperLink> to go there now.
    </asp:Panel>
    <asp:Label ID="lblNotEnabled" Visible="False" runat="server" Text="The Timer Service Feature has not been activated on this web application. You must activate the feature in Central Admin before the timer is able to run." Font-Bold="true" ForeColor="red"></asp:Label>
    <asp:Panel ID="pnlMain" runat="server" Visible="true" Width="100%">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
    <wssuc:InputFormSection Title="Choose time to run:"
		Description=""
		runat="server">
		<Template_Description>
		    Choose a time when the EPM Live Timer Service should update your site.
		    This time should be set to a time when your system will be idle or close to idle.
		    <br />
		    <br />
		    <br /><br />
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Time" runat="server">
				 <Template_Control>
                    <asp:DropDownList ID="FixTimes" runat="server">
                    <asp:ListItem Enabled ="true" Selected ="true" Value ="-1" Text ="Disabled"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="0" Text ="12:00 AM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="1" Text ="1:00 AM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="2" Text ="2:00 AM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="3" Text ="3:00 AM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="4" Text ="4:00 AM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="5" Text ="5:00 AM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="6" Text ="6:00 AM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="7" Text ="7:00 AM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="8" Text ="8:00 AM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="9" Text ="9:00 AM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="10" Text ="10:00 AM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="11" Text ="11:00 AM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="12" Text ="12:00 PM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="13" Text ="1:00 PM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="14" Text ="2:00 PM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="15" Text ="3:00 PM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="16" Text ="4:00 PM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="17" Text ="5:00 PM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="18" Text ="6:00 PM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="19" Text ="7:00 PM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="20" Text ="8:00 PM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="21" Text ="9:00 PM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="22" Text ="10:00 PM"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="23" Text ="11:00 PM"></asp:ListItem>
                    </asp:DropDownList>
				    <br />
				    <img src="blank.gif" width="400" height="1"/>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="Last Run" runat="server">
				 <Template_Control>
                    <asp:Label ID="lblLastRun" runat="server"></asp:Label>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="Last Result" runat="server">
				 <Template_Control>
                    <asp:Label ID="lblMessages" runat="server"></asp:Label>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="Log" runat="server">
				 <Template_Control>
                    <a href="viewmessages.aspx?type=2">View Log</a>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	
	<asp:Panel ID="pnlAdmin" runat="server">
	<wssuc:InputFormSection Title="List Field Recalculation "
		Description=""
		runat="server">
		<Template_Description>
		    This feature will recalculate SharePoint List formulas that use the function "Today" for all Lists specified in this section. 
            <br /><br />
            This feature will also calculate the custom field type "Total Rollup" for all Lists specified in this section. 
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Enter list(s) separated by a line break:" runat="server" width="100%">
				 <Template_Control>
				            <asp:TextBox ID="Lists" runat="server" Height="100" Width ="200" TextMode="MultiLine"></asp:TextBox>	                        

                            <asp:Panel ID="pnlSaveResults" runat="server" Visible="false">
                                Save results:
                                <br />
                                <asp:Label ID="lblPropertyEPMLiveFixLists" runat="server" Text="Label">Property: EPMLiveFixLists</asp:Label>
                                <br />
                                <asp:TextBox ID="txtPropertyEPMLiveFixListsValue" runat="server" Height="100" Width ="400" TextMode="MultiLine"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Label ID="lblPropertyEPMLiveFixTime" runat="server" Text="Label">Property: EPMLiveFixTime</asp:Label>
                                <br />
                                <asp:Label ID="lblPropertyEPMLiveFixTimeValue" runat="server" Text="Label"></asp:Label>

                            </asp:Panel>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	</asp:Panel>

<wssuc:InputFormSection Title="Resource Planner Lists"
		Description=""
		runat="server">
		<Template_Description>
            Enter the lists for which you would like to collect data.
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Enter list(s) separated by a line break:" runat="server" width="100%">
				 <Template_Control>
				            <asp:TextBox ID="txtResPlannerLists" runat="server" Height="100" Width ="200" TextMode="MultiLine"></asp:TextBox>	                        
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="Last Run" runat="server">
				 <Template_Control>
                    <asp:Label ID="lblLastResRun" runat="server"></asp:Label>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="Last Result" runat="server">
				 <Template_Control>
                    <asp:Label ID="lblLastResResult" runat="server"></asp:Label>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="View Log" runat="server">
				 <Template_Control>
                    <a href="viewmessages.aspx?type=1">View Log</a>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	
	<wssuc:ButtonSection runat="server">
		<Template_Buttons>
			<asp:PlaceHolder ID="PlaceHolder1" runat="server">
			<asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="btnRunNow_Click" Text="Run Timer Now" id="btnRunNow" accesskey="" Width="150"/><img border="0" alt="" src="/_layouts/images/blank.gif" width="5px" ><asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Button1_Click" Text="Save Settings" id="Button1" accesskey="" Width="150"/>
			</asp:PlaceHolder>
		</Template_Buttons>
	</wssuc:ButtonSection>   
    </table> 
	</asp:Panel>
	
	
	<script language="javascript">

	    //        function runTimer()
	    //        {
	    //            sm('dlgAction',200,100);
	    //            var url = '<%=siteUrl%>';
	    //            dhtmlxAjax.post(url + "/_layouts/epmlive/runtimer.aspx","siteid=<%=siteid %>",closeDone);
	    //        }

	    //        function closeDone(loader)
	    //        {
	    //            if(loader.xmlDoc.responseText!=null)
	    //            {
	    //                if(loader.xmlDoc.responseText.substring(0,5) != "Error")
	    //                {
	    //                    var strPeriod = loader.xmlDoc.responseText;
	    //                    newURL = "<%=siteUrl%>/_layouts/epmlive/timersettings.aspx";

	    //                    window.location.href = newURL;
	    //                    hm('dlgAction');
	    //                }
	    //                else
	    //                {
	    //                    alert(loader.xmlDoc.responseText);
	    //                    hm('dlgAction');
	    //                }
	    //            }
	    //            else
	    //            {
	    //                alert("Response contains no XML");
	    //                hm('dlgAction');
	    //            }
	    //        }

	    initmb();
    </script>
</asp:Content>