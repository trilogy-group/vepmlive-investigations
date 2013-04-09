<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportResources.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.ImportResources" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
	<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/applications/applications.css"/>
	<script src="/_layouts/epmlive/javascripts/libraries/bootstrap.min.js" type="text/javascript"></script>
	
	<style type="text/css">
		body {
			padding-top: 40px;
			padding-bottom: 40px;
		}
	  
		div.fileinputs {
			position: relative;
		}

		div.fakefile {
			position: absolute;
			top: 0;
			left: 0;
			z-index: 1;
		}

		input {
			cursor: pointer;
			_cursor: hand;
			-webkit-border-radius: 0;
			-moz-border-radius: 0;
			border-radius: 0;
		}

		input[type="file"] {
			position: relative;
			text-align: right;
			-moz-opacity:0;
			filter:alpha(opacity: 0);
			opacity: 0;
			z-index: 2;
		}

		.form-import {
			max-width: 600px;
			padding: 30px;
			background-color: #fff;
			border: 1px solid #e5e5e5;
			margin: 0 auto;
			-webkit-border-radius: 5px;
			-moz-border-radius: 5px;
			border-radius: 5px;
			-webkit-box-shadow: 0 1px 2px rgba(0,0,0,.05);
			-moz-box-shadow: 0 1px 2px rgba(0,0,0,.05);
			box-shadow: 0 1px 2px rgba(0,0,0,.05);
		}
	  
		.form-import .form-import-heading {
			margin-bottom: 15px;
			font-family: "Segoe UI Light", "Segoe UI", "Segoe", Tahoma, Helvetica, Arial, sans-serif;
		}
		
		.form-actions {
			margin: 0;
			padding-top: 20px;
			padding-bottom: 20px;
		}
		
		.fileinput {
			height: 32px;
			width: 295px;
		}
		
		.help-inline {
			padding-left: 0;
			margin-bottom: 0;
		}
		
		.help-inline > span {
			font-family: "Segoe UI", "Segoe", Tahoma, Helvetica, Arial, sans-serif;
		}
		
		.container {
			width: 730px;
			margin-bottom: 50px;
		}

        .ms-core-overlay {
            overflow: hidden !important;
        }
	</style>
	
	<!--[if IE]>
	<style type="text/css">
		.fileinput {
			height: 40px;
			width: 315px;
		}
	</style>
	<![endif]-->

	<script type="text/javascript">
		$(function () {
			$('.fileinput').change(function () {
				$('.epmliveinput').val($(this).val().split('\\').pop());
			});
		});
	</script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
	<asp:Panel runat="server" ID="MainPanel">
		<div class="container">
			<div class="form-import">
				<h3 class="form-import-heading">Please upload the Resources spreadsheet</h3>
				<div class="control-group">
				  <div class="controls">
					<div class="fileinputs">
						<asp:FileUpload ID="FileUpload" CssClass="fileinput" runat="server" />
						<div class="fakefile">
							<input type="text" />
							<input type="button" value="Upload" />
						</div>
					</div>
					<span class="help-inline">
						<asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="CustomValidator" ControlToValidate="FileUpload" Display="Dynamic"></asp:CustomValidator>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="Please upload the Resources spreadsheet." ControlToValidate="FileUpload" Display="Dynamic"></asp:RequiredFieldValidator>
					</span>
				  </div>
				</div>
				<div class="form-actions">
					<asp:Button ID="ImportButton" runat="server" Text="Import" OnClick="ImportButtonOnClick" />
					<input type="button" value="Cancel" style="margin-left: 5px;" onclick="parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.cancel); return false;"/>
				</div>
			</div>
		</div>
	</asp:Panel>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Import Resources
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Import Resources
</asp:Content>
