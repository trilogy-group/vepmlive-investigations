<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Import Namespace="Microsoft.SharePoint" %>

<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 

<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createsite.aspx.cs" Inherits="EPMLiveCore.Layouts.EPMLiveCore.createsite" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script type="text/javascript">
// <![CDATA[
        function ULS9xi() { var o = new Object; o.ULSTeamName = "Microsoft SharePoint Foundation"; o.ULSFileName = "createsite.aspx"; return o; }
        
        function SiteNameOptionChanged() {
            ULS9xi: ;
            SetSiteNameCtlsState(true);
            constructUrl();
        }
        function SetSiteNameCtlsState(bSilent) {
            ULS9xi: ;
            var i = (document.getElementById("<%= DdlWildcardInclusion.ClientID %>")).selectedIndex;
            var bUseWildcardInclusion = false;
            var inclusionList = (document.getElementById("<%= DdlWildcardInclusion.ClientID %>")).options;
            if (i >= 0 && inclusionList.length > i) {
                bUseWildcardInclusion = inclusionList[i].value.substring(0, 1) == "0";
            }
            (document.getElementById("<%= TxtSiteName.ClientID %>")).disabled = !bUseWildcardInclusion;
            (document.getElementById("<%= TxtSiteName.ClientID %>")).style.display = bUseWildcardInclusion ? "inline" : "none";
            if (!bUseWildcardInclusion)
                (document.getElementById("<%= TxtSiteName.ClientID %>")).Text = "";
            STSValidatorEnable("<%= ReqValSiteName.ClientID %>", bUseWildcardInclusion, bSilent);
            STSValidatorEnable("<%= CusValSiteName.ClientID %>", bUseWildcardInclusion, bSilent);
        }
        function constructUrl() {
            ULS9xi: ;
            var strVsUrl = (document.getElementById("<%= HidVirtualServerUrl.ClientID %>")).value;
            document.getElementById("SpanConstructedUrl").innerHTML = STSHtmlEncode(strVsUrl);
        }
        function _spBodyOnLoad() {
            ULS9xi: ;
            SetSiteNameCtlsState(true);

            constructUrl();
        }
        function _spFormOnSubmit() {
            ULS9xi: ;
            (document.getElementById("<%= BtnCreateSite.ClientID %>")).disabled = true;
            (document.getElementById("<%= BtnCreateSiteTop.ClientID %>")).disabled = true;
        }

        function toggleSAccount(show) {
            if (show) {
                document.getElementById('<%=trNew3.ClientID %>').style.display = 'block';
                document.getElementById('<%=trNew4.ClientID %>').style.display = 'block';
            }
            else {
                document.getElementById('<%=trNew3.ClientID %>').style.display = 'none';
                document.getElementById('<%=trNew4.ClientID %>').style.display = 'none';
            }
        }
// ]]>
</script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    <table border="0" cellspacing="0" cellpadding="0" class="ms-propertysheet" width="100%">
	<wssuc:ButtonSection runat="server" TopButtons="true" BottomSpacing="5" ShowSectionLine="false" ShowStandardCancelButton="false">
		<Template_Buttons>
			<asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="BtnCreateSite_Click" Text="<%$Resources:wss,multipages_okbutton_text%>" id="BtnCreateSiteTop" accesskey="<%$Resources:wss,okbutton_accesskey%>" Enabled="false"/>
			<asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="BtnCancel_Click" Text="<%$Resources:wss,multipages_cancelbutton_text%>" id="BtnCancelTop" accesskey="<%$Resources:wss,cancelbutton_accesskey%>" CausesValidation="false"/>
		</Template_Buttons>
	</wssuc:ButtonSection>
    <tr>
    <td colspan="2">
        <asp:Label ID="lblSiteError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    </td>
    </tr>
	<wssuc:InputFormSection Title="<%$Resources:spadmin, multipages_webapplication_title%>" runat="server" id="idWebApplicationSelectorSection">
		<Template_Description>
		   <SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="<%$Resources:spadmin, multipages_webapplication_desc%>" EncodeMethod='HtmlEncodeAllowSimpleTextFormatting'/>
		   <br /><br />
		   <SharePoint:EncodedLiteral ID="EncodedLiteral2" runat="server" text="<%$Resources:spadmin, createsite_webapp_desc1%>" EncodeMethod='HtmlEncodeAllowSimpleTextFormatting'/>
			<a id="LinkCreateWebApplication" href="#" onclick="javascript:GoToPageRelative('extendvs.aspx');return false;"><SharePoint:EncodedLiteral ID="EncodedLiteral3" runat="server" text="<%$Resources:spadmin, createsite_webapp_desc2%>" EncodeMethod='HtmlEncodeAllowSimpleTextFormatting'/></a>
		  <SharePoint:EncodedLiteral ID="EncodedLiteral4" runat="server" text="<%$Resources:spadmin, createsite_webapp_desc3%>" EncodeMethod='HtmlEncodeAllowSimpleTextFormatting'/>
	   </Template_Description>
		<Template_InputFormControls>
			<tr><td>
			<SharePoint:WebApplicationSelector id="webAppSelector" runat="server"
				OnContextChange="Selector_ContextChange" AllowAdministrationWebApplication="false" AllowChange="true"/>
			</td></tr>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	<wssuc:InputFormSection runat="server"
		Title="<%$Resources:spadmin, createsite_idInputTitleTitleDesc%>"
		Description="<%$Resources:spadmin, createsite_idInputDescriptionTitleDesc%>"
		id="idTitleDescSection">
		<Template_InputFormControls>
			<wssuc:InputFormControl runat="server"
				LabelText="<%$Resources:spadmin, createsite_idInputLabelTitle%>">
				<Template_Control>
					<wssawc:InputFormTextBox title="<%$Resources:spadmin, createsite_TxtCreateSiteTitle_title%>" class="ms-input" ID="TxtCreateSiteTitle" Columns="35" Runat="server" MaxLength=255 />
					<wssawc:InputFormRequiredFieldValidator
						ID="ReqValTxtCreateSiteTitle"
						ControlToValidate="TxtCreateSiteTitle"
						ErrorMessage="<%$Resources:spadmin, createsite_titlerequired%>"
						Runat="server"/>
				</Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl runat="server"
				LabelText="<%$Resources:spadmin, multipages_description%>">
				<Template_Control>
					<wssawc:InputFormTextBox title="<%$Resources:spadmin, createsite_TxtCreateSiteDescription_title%>" class="ms-input" ID="TxtCreateSiteDescription" Runat="server" TextMode="MultiLine" Columns="40" Rows="3"/>
				</Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	<wssuc:InputFormSection Title="<%$Resources:spadmin, createsite_siteadr_title%>" runat="server">
		<Template_Description>
			<SharePoint:EncodedLiteral ID="EncodedLiteral5" runat="server" text="<%$Resources:spadmin, createsite_siteadr_desc1%>" EncodeMethod='HtmlEncodeAllowSimpleTextFormatting'/>
			<br /><br />
			<SharePoint:EncodedLiteral ID="EncodedLiteral6" runat="server" text="<%$Resources:spadmin, createsite_siteadr_desc2%>" EncodeMethod='HtmlEncodeAllowSimpleTextFormatting'/>
			<asp:HyperLink id="LinkManagePrefix" runat="server" NavigateUrl="#" text="<%$SPHtmlEncodedResources:spadmin, createsite_siteadr_desc3%>"/>
			<SharePoint:EncodedLiteral ID="EncodedLiteral7" runat="server" text="<%$Resources:spadmin, createsite_siteadr_desc4%>" EncodeMethod='HtmlEncodeAllowSimpleTextFormatting'/>
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl runat="server" LabelText="<%$Resources:spadmin, createsite_idUrl%>">
				<Template_Control>
				<table dir="ltr" border="0" width="100%" cellspacing="0" cellpadding="0" class="authoringcontrols">
					<tr>
						<td class="ms-descriptiontext" nowrap="nowrap">
							<input type="hidden" id="HidVirtualServerUrl" runat="server"/>
							<b id="SpanConstructedUrl"></b>
						</td>
						<td>
							<asp:DropDownList id="DdlWildcardInclusion" runat="server" onchange="SiteNameOptionChanged()"
								Title="<%$Resources:spadmin, createsite_siteprefix_title%>" />
						</td>
						<td width="100%">
							<wssawc:InputFormTextBox title="<%$Resources:spadmin, createsite_sitename%>" class="ms-input" ID="TxtSiteName" Columns="18" Runat="server" MaxLength=128 />
						</td>
					</tr>
					<tr>
						<td class="ms-descriptiontext" nowrap="nowrap" colspan="3">
							<wssawc:InputFormRequiredFieldValidator ID="ReqValSiteName" ControlToValidate="TxtSiteName"
								ErrorMessage="<%$Resources:spadmin, createsite_missingurl%>" Runat="server"/>
							<wssawc:UrlNameValidator
								ID="CusValSiteName"
								ControlToValidate="TxtSiteName"
								runat="server"/>
						</td>
					</tr>
				</table>
				</Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>

    <wssuc:InputFormSection Title="Select a Solution"
		Description="Please select a Solution Type from the dropdown list"
		runat="server" width="10" visible="true">
		<Template_Description>
		    
		</Template_Description>

		<Template_InputFormControls>
			<Template_Control>
                    <asp:DropDownList ID="ddlSolution" runat="server" >
		</asp:DropDownList>
            </Template_Control>
		</Template_InputFormControls>
	</wssuc:InputFormSection>

	<wssuc:InputFormSection
		Title="<%$Resources:spadmin, createsite_idWebAdminHeader%>"
		Description= "<%$Resources:spadmin, Site_idWebAdminDescription%>"
		runat="server"
		id="idPrimaryAdministratorSection">
		<Template_InputFormControls>
				<wssuc:InputFormControl LabelText="<%$Resources:spadmin, createsite_idOwnerLogin%>"
					runat="server">
					<Template_Control>
						<wssawc:PeopleEditor
						  AllowEmpty=false
						  SingleLine=true
						  ValidatorEnabled="true"
						  MultiSelect=false
						  id="PickerOwner"
						  runat="server"
						  SelectionSet="User"
						  />
					</Template_Control>
				</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	
    <wssuc:InputFormSection Title="Reporting Database" Description="" runat="server">
        
            <template_description>
                If you would like to use the WorkEngine reporting solution with your site, enter the information here.
            </template_description>
            <template_inputformcontrols>
                
                <wssuc:InputFormControl LabelText="Database Server" runat="server">
                     <Template_Control>
                        <table>
                        <tr id="trSelect" runat="server">
                            <td class="ms-authoringcontrols" colspan="2">
                                Existing <asp:RadioButton ID ="btnExisting" runat="server" GroupName="group1" />
                                New      <asp:RadioButton ID ="btnNew" runat="server" GroupName="group1" Checked="true" />
                            </td>
                        </tr>
                        <tr id="trNew1" runat="server">
                            <td class="ms-authoringcontrols">Server</td>
                            <td class="ms-authoringcontrols"><asp:TextBox runat="server" ID="txtDatabaseServer" Width="120px"></asp:TextBox></td>
                        </tr>                  
                        <tr id="trNew2" runat="server">
                            <td class="ms-authoringcontrols">Database Name</td>
                            <td class="ms-authoringcontrols"><asp:TextBox runat="server" ID="txtDatabaseName" Width="120px"></asp:TextBox></td>
                        </tr>
                         <tr id="tr1" runat="server">
                            <td class="ms-authoringcontrols">Use SQL Account</td>
                            <td class="ms-authoringcontrols" width="200"><asp:CheckBox runat="server" ID="sacccount" onclick="toggleSAccount(this.checked)" /></td>
                        </tr>
                         <tr id="trNew3" runat="server" style="display:none;">
                            <td class="ms-authoringcontrols">User Name</td>
                            <td class="ms-authoringcontrols"><asp:TextBox runat="server" ID="username" Width="120px"></asp:TextBox></td>
                        </tr>
                         <tr id="trNew4" runat="server" style="display:none;">
                            <td class="ms-authoringcontrols">Password</td>
                            <td class="ms-authoringcontrols"><asp:TextBox runat="server" ID="password" TextMode="Password" Width="120px"></asp:TextBox></td>
                        </tr>
                        <tr><td class="ms-authoringcontrols" colspan="2">
                            <asp:Label ID="lblErrorDatabase" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                        </td></tr>
                        </table>
                     </Template_Control>
                </wssuc:InputFormControl>                         
            </template_inputformcontrols>
        </wssuc:InputFormSection>

	<SharePoint:DelegateControl runat="server" Id="DelctlCreateSiteCollectionPanel" ControlId="CreateSiteCollectionPanel1" Scope="Farm" />
	<wssuc:ButtonSection runat="server" ShowStandardCancelButton="false">
		<Template_Buttons>
			<asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="BtnCreateSite_Click" Text="<%$Resources:wss,multipages_okbutton_text%>" id="BtnCreateSite" accesskey="<%$Resources:wss,okbutton_accesskey%>" Enabled="false"/>
			<asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="BtnCancel_Click" Text="<%$Resources:wss,multipages_cancelbutton_text%>" id="BtnCancel" accesskey="<%$Resources:wss,cancelbutton_accesskey%>" CausesValidation="false"/>
		</Template_Buttons>
	</wssuc:ButtonSection>
   </table>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Create WorkEngine Site
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Create WorkEngine Site
</asp:Content>
