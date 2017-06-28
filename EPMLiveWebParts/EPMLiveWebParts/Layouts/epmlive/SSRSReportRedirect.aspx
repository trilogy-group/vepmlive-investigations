<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SSRSReportRedirect.aspx.cs" Inherits="EPMLiveWebParts.Layouts.epmlive.SSRSReportRedirect" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <style>
    ul {
        list-style-type: none;
        margin: 0;
        padding: 0;
        overflow: hidden;
        background-color: #333;
    }

    li {
        float: left;
    }

    li a, .dropbtn {
        display: inline-block;
        color: white;
        text-align: center;
        padding: 14px 16px;
        text-decoration: none;
    }

    li a:hover, .dropdown:hover .dropbtn {
        background-color: #4CAF50;
    }

    li.dropdown {
        display: inline-block;
    }

    .dropdown-content {
        display: none;
        position: absolute;
        background-color: #f9f9f9;
        min-width: 160px;
        box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
        z-index: 1;
    }

    .dropdown-content a {
        color: black;
        padding: 12px 16px;
        text-decoration: none;
        display: block;
        text-align: left;
    }

    .dropdown-content a:hover {background-color: #f1f1f1}

    .dropdown:hover .dropdown-content {
        display: block;
    }
    </style>
    <script>
        var linkBuilder = "";

	    function OpenEditor() {
	        window.open(linkBuilder, "_parent");
	    }
	
	    $(window).resize(function() {
		    var topUpper = $('#upper').height() + 5;	
		    $('#ReportFrame').css({ top: topUpper, left: 0, right: 0, bottom: 0, position: 'absolute' });
		    $('#ReportFrame').height($(window).outerHeight() - (topUpper + 10));
	    });

	    $(document).ready(function () {
	        var qString = "?" + window.location.href.split("?")[1];
	        $.ajax({
	            type: "POST",
	            url: "SSRSReportRedirect.aspx/GetRegs" + qString,
	            data: {},
	            contentType: "application/json; charset=utf-8",
	            dataType: 'json',

	            success: function (data) {
	                var objdata = $.parseJSON(data.d);
	                
	                if (objdata != null) {
	                    var addresses = objdata.toString().split("|");
	                    $("#ReportFrame").attr('src', addresses[0]);
	                    linkBuilder = addresses[1];
	                }
	                else {
	                    alert('Error! Could not load report link.');
	                }
	            }	            
	        });
	    });
    </script>
    <div id="upper">
	    <ul>
        <li class="dropdown">
        <a href="javascript:void(0)" class="dropbtn">Actions</a>
        <div class="dropdown-content">
          <a href="javascript:OpenEditor()">Open with Report Builder</a>
        </div>
      </li>
    </ul>
    </div>
    <iframe id="ReportFrame" width="100%" height="100%" src=""></iframe>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Application Page
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
My Application Page
</asp:Content>
