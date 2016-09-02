<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" Src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" Src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register TagPrefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resourcelistupdater.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.ResourceListUpdater" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Content4" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    <SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" Text="EPM Live Resource List Updater" EncodeMethod='HtmlEncode' />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="Resource List Updater"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderPageDescription" runat="server">
    Use this page to Update the EPM Live Resource List 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    <script src="DHTML/xgrid/dhtmlxcommon.js"></script>

    <link rel="stylesheet" href="modal/modal.css" type="text/css" />
    <script type="text/javascript" src="modal/modal.js"></script>



    <div id="dlgAction" class="dialog">
        <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <img src="../images/GEARS_AN.GIF" style="vertical-align: middle;" /><br />
                    <h3 class="ms-standardheader" id="dlgHAction">Starting Timer...</h3>
                </td>
            </tr>

        </table>
    </div>

    <asp:Panel ID="pnlTL" runat="server" Visible="false" Width="100%">
        The Resource List Cleanup Service is configured at the site collection level.<br />
        <br />
        <asp:HyperLink Text="Click Here" NavigateUrl="" runat="server" ID="hlAdmin"></asp:HyperLink>
        to go there now.
    </asp:Panel>
    <asp:Label ID="lblNotEnabled" Visible="False" runat="server" Text="The Timer Service Feature has not been activated on this web application. You must activate the feature in Central Admin before the timer is able to run." Font-Bold="true" ForeColor="red"></asp:Label>
    <asp:Panel ID="pnlMain" runat="server" Visible="true" Width="100%">
        <fieldset>
            <legend>
                <b>Resource List Cleanup </b>
            </legend>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <colgroup>
                    <col style="width: 60%" />
                    <col style="width: 40%" />
                </colgroup>
                <tr>
                    <td>
                        <wssuc:InputFormSection Title="Choose time to run:"
                            Description=""
                            runat="server">
                            <template_description>
		    Choose a time when the EPM Live Timer Service should update your site.
		    This time should be set to a time when your system will be idle or close to idle.
		</template_description>
                            <template_inputformcontrols>
			<wssuc:InputFormControl LabelText="Time" runat="server" width="100%">
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
				    <img src="blank.gif" width="100%" height="1"/>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="Last Run" runat="server" width="100%">
				 <Template_Control>
                    <asp:Label ID="lblLastRun" runat="server"></asp:Label>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="Last Result" runat="server" width="100%">
				 <Template_Control>
                    <asp:Label ID="lblMessages" runat="server"></asp:Label>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="Log" runat="server" width="100%">
				 <Template_Control>
                    <a id="viewLog" runat="server" href="viewmessages.aspx?type=1">View Log</a>
				 </Template_Control>
			</wssuc:InputFormControl>
		</template_inputformcontrols>
                        </wssuc:InputFormSection>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="btnRunNow_Click" Text="Run Timer Now" id="btnRunNow" accesskey="" Width="150"/>
                    </td>
                </tr>
            </table>
        </fieldset>
    </asp:Panel>

    <asp:Panel ID="pnlBtn" runat="server" Visible="true" Width="100%">
        <wssuc:InputFormSection Title="Resource Planner Lists"
            Description=""
            runat="server" Visible="False">
            <template_description>
            Enter the lists for which you would like to collect data.
		</template_description>
            <template_inputformcontrols>
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
		</template_inputformcontrols>
        </wssuc:InputFormSection>
    </asp:Panel>

    <script type="text/javascript">
           
        initmb();
    </script>
</asp:Content>

