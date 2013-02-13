<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportResourceStatus.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.ImportResourceStatus" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
	<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/stylesheets/libraries/bootstrap/css/bootstrap.min.css"/>
	<script src="/_layouts/epmlive/javascripts/libraries/bootstrap.min.js" type="text/javascript"></script>
	
	<style type="text/css">
		.hero-unit {
			padding: 30px;
			line-height: 1em;
		}
		
		.hero-unit > p {
			margin: 0;
		}
		
		textarea[readonly] {
			height: 285px;
			cursor: text;
		}
		
		#resourcetable-wrap {
			height: 285px;
			overflow: auto;
		}
		
		th, td {
			font-family: 'Segoe UI', 'Segoe', Tahoma, Helvetica, Arial, sans-serif;
		}
		
		.container-wrap {
			height: 565px;
		}
	</style>
	
	<!--[if IE]>
	<style type="text/css">
		textarea[readonly] {
			height: 250px;
		}
		
		#resourcetable-wrap {
			height: 250px;
		}

		.container-wrap {
			height: 500px;
		}
	</style>
	<![endif]-->

	<script type="text/javascript">
		window.epmLive = window.epmLive || {};
		window.epmLive.jobId = '<%= JobId %>';
	</script>
	
	<script src="/_layouts/epmlive/javascripts/resourceimporter.js<%= Version %>" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server" Visible="False">
	<asp:Label ID="MissingJobIdErrorLabel" runat="server" Text="No Job ID was provided." ForeColor="Red" Visible="False"></asp:Label>
	<asp:Panel ID="Panel" runat="server" Visible="False" CssClass="container-wrap">
		<div id="epmcontainer" class="container">
			<div class="hero-unit">
				<div class="row-fluid">
					<div class="span11">
						<div class="progress progress-striped" data-bind="css: { active: percentage() < 100 }">
						  <div class="bar" data-bind="style:{ width: percentage() + '%' }"></div>
						</div>
					</div>
					<div class="span1" style="font-family: 'Segoe UI', 'Segoe', Tahoma, Helvetica, Arial, sans-serif;" data-bind="text: percentage() + '%'"/>
				</div>
			</div>
			<div class="row-fluid"><p style="font-family: 'Segoe UI', 'Segoe', Tahoma, Helvetica, Arial, sans-serif;" data-bind="text: currentProcess()"/></div>
		</div>
		<div class="accordion" id="status">
		  <div class="accordion-group">
			<div class="accordion-heading">
			  <a class="accordion-toggle" data-toggle="collapse" data-parent="#status" href="#details" style="font-family: 'Segoe UI', 'Segoe', Tahoma, Helvetica, Arial, sans-serif;">
				Import Details
			  </a>
			</div>
			<div id="details" class="accordion-body collapse in">
			  <div class="accordion-inner">
				<div class="row-fluid" id="resourcetable-wrap" style="display: none" data-bind="visible: resources().length > 0">
					<table class="table table-bordered" id="resourcetable">
						<thead>
							<tr>
								<th width="15" style="text-align: center">#</th>
								<th width="200">Name</th>
								<th width="75" style="text-align: center">Status</th>
								<th>Comment</th>
							</tr>
						</thead>
						<tbody data-bind="foreach: resources ">
							<tr>
								<td data-bind="text: $index() + 1"></td>
								<td data-bind="text: Name"></td>
								<td data-bind="style: { color: Processed ? '#67A2C0' : '#CEAF7A' }" style="text-align: center; font-weight:bold;">
									<!-- ko if: Processed -->
										SUCCESS
									<!-- /ko -->
									<!-- ko if: !Processed -->
										FAILED
									<!-- /ko -->
								</td>
								<td data-bind="text: Comment ? (Id ? '[User ID: ' + Id + '] ' : '') + Comment : ''"></td>
							</tr>
						</tbody>
					</table>
				</div>
			  </div>
			</div>
		  </div>
		  <div class="accordion-group">
			<div class="accordion-heading">
			  <a class="accordion-toggle" data-toggle="collapse" data-parent="#status" href="#log" style="font-family: 'Segoe UI', 'Segoe', Tahoma, Helvetica, Arial, sans-serif;">
				Import Log
			  </a>
			</div>
			<div id="log" class="accordion-body collapse">
			  <div class="accordion-inner">
				<div class="row-fluid">
					<textarea id="talog" rows="10" cols="10" data-bind="value: log" class="span12" readonly="readonly"></textarea>
				</div>
			  </div>
			</div>
		  </div>
		</div>
	</asp:Panel>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Importing Resources
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Importing Resources
</asp:Content>