<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Properties.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.Integration.Properties" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    

    <%=PageHead %>

    <table width="100%">
        <tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
        <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Standard Properties</h3></td></tr>
        </table></td></tr>

        <wssuc:InputFormSection ID="InputFormSection2" Title="Integration Key"
	        Description=""
	        runat="server">
	        <Template_Description>
	            This key will be used when sending data into the EPM Live integration from an external source.
	        </Template_Description>
	        <Template_InputFormControls>
		        <wssuc:InputFormControl ID="InputFormControl2" LabelText="" runat="server">
			            <Template_Control>
			                <asp:Label ID="lblKey" runat="server"></asp:Label>
			            </Template_Control>
		        </wssuc:InputFormControl>
	        </Template_InputFormControls>
        </wssuc:InputFormSection>

        <wssuc:InputFormSection ID="InputFormSection3" Title="Integration Paths"
	        Description=""
	        runat="server">
	        <Template_Description>
	            Specify how you would like data to flow.<br /><br />
                Live Outgoing - This will send data out to the integrated item on save of a SharePoint item<br />
                Live Incoming - This will allow an external integrated item to send data into SharePoint<br />
                Timed Outgoing* - This will send data out the integrated items on a timed basis<br />
                Timed Incoming* - This will bring data in from the integrated items on a timed basis<br /><br />
                * If both Timed Outgoing and Timed Incoming are selected, the latest data will use the date modified as the key to determine the correct data.
	        </Template_Description>
	        <Template_InputFormControls>
		        <wssuc:InputFormControl ID="InputFormControl3" LabelText="" runat="server">
			            <Template_Control>
			                <asp:CheckBox ID="chkLout" runat="server" Text="Live Outgoing" />
			            </Template_Control>
		        </wssuc:InputFormControl>
                <wssuc:InputFormControl ID="InputFormControl4" LabelText="" runat="server">
			            <Template_Control>
			                <asp:CheckBox ID="chkLin" runat="server" Text="Live Incoming" />
			            </Template_Control>
		        </wssuc:InputFormControl>
                <wssuc:InputFormControl ID="InputFormControl5" LabelText="" runat="server">
			            <Template_Control>
			                <asp:CheckBox ID="chkTout" runat="server" Text="Timed Outgoing" />
			            </Template_Control>
		        </wssuc:InputFormControl>
                <wssuc:InputFormControl ID="InputFormControl6" LabelText="" runat="server">
			            <Template_Control>
			                <asp:CheckBox ID="chkTin" runat="server" Text="Timed Incoming" />
			            </Template_Control>
		        </wssuc:InputFormControl>
	        </Template_InputFormControls>
        </wssuc:InputFormSection>

        <wssuc:InputFormSection ID="InputFormSectionDelete" Title="Deletion"
	        Description=""
	        runat="server">
	        <Template_Description>
	            Use these settings do decide whether the integration can delete items from your list or from the integration source.
	        </Template_Description>
	        <Template_InputFormControls>
		        <wssuc:InputFormControl ID="InputFormControlDelete1" LabelText="" runat="server">
			            <Template_Control>
			                <asp:CheckBox ID="chkDeleteList" runat="server" Text="Allow Deletion from List" />
			            </Template_Control>
		        </wssuc:InputFormControl>
                <wssuc:InputFormControl ID="InputFormControlDelete2" LabelText="" runat="server">
			            <Template_Control>
			                <asp:CheckBox ID="chkDeleteInt" runat="server" Text="Allow Deletion from Integration Source" />
			            </Template_Control>
		        </wssuc:InputFormControl>
	        </Template_InputFormControls>
        </wssuc:InputFormSection>


        <tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
        <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Custom Properties</h3></td></tr>
        </table></td></tr>
    </table>
    <asp:Panel ID="lblMain" runat="server">
        <table width="100%">
            <wssuc:ButtonSection ID="ButtonSection1" runat="server">
		        <Template_Buttons>
			        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
				        <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Button1_Click" Text="Save Settings" id="Button1" accesskey="" Width="150"/>
			        </asp:PlaceHolder>
		        </Template_Buttons>
	        </wssuc:ButtonSection>
        </table>
        <asp:Label ID="lblError" runat="server" Color="red"></asp:Label>
    </asp:Panel>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Integration Properties
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Integration Properties
</asp:Content>
