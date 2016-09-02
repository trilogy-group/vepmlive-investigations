<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OptInUpgrade55.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.Upgraders.OptInUpgrade55" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <asp:Label ID="lblError" runat="server" Text="" Visible="False"></asp:Label>
	<asp:Panel ID="pnlMain" runat="server">
		<div style="padding:20px">
			<div style="width: 600px;margin-bottom: 50px;">
				<div class="upgradeheader">Welcome the EPM Live 5.5 Opt-in Upgrader</div>
				<div class="upgradetext">
					<p>This page will allow you to upgrade this site to EPM Live version 5.5.  By clicking the "I Agree" checkbox below, you are agreeing that this site will be upgraded to version 5.5 of EPM Live and all of its associated functionality. Although EPM Live fully supports upgrades, please understand that your existing business processes may change after the upgrade. We suggest creating a new trial site prior to the upgrade in order to understand the implications of this upgrade.</p>
					<p>Also, please visit our <a href="http://support.epmlive.com" style="color: #438DE8; text-decoration: underline;" target="_blank">Support Community</a> for important upgrade announcements.</p>
				</div>
			</div>

			<div class="controls">
				<p><asp:Label ID="NotRootMessageLabel" runat="server" Text="You are choosing to run the upgrader on a site other than the root site. Are you sure you want to run the upgrader on this site?" Visible="False" ForeColor="Red"></asp:Label></p>
				<label class="checkbox inline">
					<input type="checkbox" id="chkTerms" onclick="javascript: window.allowEpmLiveUpgrade();"/><span>I Agree.</span>
				</label>
			</div>

			<div style="padding-top:10px;">
				<a class="button button-green-disabled" href="javascript:void(0);" id="btnUpgrade" onclick="javascript:window.upgradeEpmLive('5.5.0');">Upgrade Now</a>
			</div>
		</div>
	</asp:Panel>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
5.5 Opt-in upgrader
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
5.5 Opt-in upgrader
</asp:Content>
