<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SSRSNativeReportViewer.aspx.cs" Inherits="EPMLiveWebParts.Layouts.epmlive.SSRSNativeReportViewer" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:content id="PageHead" contentplaceholderid="PlaceHolderAdditionalPageHead" runat="server">

</asp:content>

<asp:content id="Main" contentplaceholderid="PlaceHolderMain" runat="server">
    <%--<link href="styles/NativeReportViewer/nativeviewer.css" rel="stylesheet" />--%>
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

            li a:visited {
                color: white;
            }

        .dropdown-content a:visited {
            color: black;
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

                .dropdown-content a:hover {
                    background-color: #f1f1f1;
                }

        .dropdown:hover .dropdown-content {
            display: block;
        }

        #SubscriptionsTable {
            /*font-family: arial, sans-serif;*/
            border-collapse: collapse;
            width: 100%;
        }

        #SubscriptionsTable td, th {
            border: 1px solid #dddddd;
            text-align: left;
            padding: 8px;
        }

        #SubscriptionsTable tr:nth-child(even) {
            background-color: #dddddd;
        }

        #AddSubscriptionForm span{
            font-size: 11px;
            color: darkgray;
        }
    </style>
    <%--<script src="javascripts/nativeviewer.js"></script>--%>
    <script>
        var linkBuilder = "";

        $(window).resize(function () {
            var topUpper = $('#upper').height() + 5;
            $('#ReportFrame').css({ top: topUpper, left: 0, right: 0, bottom: 0, position: 'absolute' });
            $('#ReportFrame').height($(window).outerHeight() - (topUpper + 10));
        });

        $(document).ready(function () {
            var qString = "?" + window.location.href.split("?")[1];
            $.ajax({
                type: "POST",
                url: "SSRSNativeReportViewer.aspx/GetRegs" + qString,
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

        function OpenEditor() {
            window.open(linkBuilder, "_parent");
        }

        function HandleCheckClick(lineID) {
            alert(lineID);
        }

        var subscriptionsList;

        function OpenSubscriptions() {
            $("#ViewerDiv").fadeOut("slow", function () {
                $("#LoadingDiv").fadeIn();
                var qString = "?" + window.location.href.split("?")[1];

                $.ajax({
                    type: "POST",
                    url: "SSRSNativeReportViewer.aspx/GetSubscriptions" + qString,
                    data: {},
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',

                    success: function (data) {

                        $("SubscribeManagerDiv").find("tr:gt(0)").remove();                        
                        $("#SubscribeManagerDiv").css("visibility", "visible");                        
                        $("#SubscribeManagerDiv").fadeIn();
                        $("#SubscriptionsTable").show();
                        $("#LoadingDiv").fadeOut();

                        var objdata = $.parseJSON(data.d);
                        subscriptionsList = objdata.Table;

                        if (objdata != null) {
                            for (i = 0; i < objdata.Table.length; i++) {
                                if (objdata.Table[i] != null) {
                                    $("#SubscriptionsTable").append('<tr>' +
                                        '<td><input type="checkbox" onclick="HandleCheckClick(' + i + ');"></td>' +
                                        '<td>' + objdata.Table[i][0] + '</td>' +
                                        '<td>' + objdata.Table[i][1] + '</td>' +
                                        '<td>' + objdata.Table[i][2] + '</td>' +
                                        '<td>' + objdata.Table[i][3] + '</td>' +
                                        '<td>' + objdata.Table[i][4] + '</td>' +
                                        '</tr>');
                                }
                            }
                        }
                    },
                    error: function (XHR, errStatus, errorThrown) {
                        $("#LoadingDiv").fadeOut();
                        var err = JSON.parse(XHR.responseText);
                        alert("Error. " + err.Message);
                    }
                });
            });
        }

        function BackToViewer() {
            $("#SubscribeManagerDiv").fadeOut("slow", function () {
                $("#AddSubscriptionForm").css("visibility", "hidden");
                $("#ViewerDiv").fadeIn();
            });
        }

        function RedirectAddSubscription() {
            $("#SubscriptionsTable").fadeOut("slow", function () {

                $("#AddSubscriptionForm").css("visibility", "visible");
                $("#AddSubscriptionForm").fadeIn();

                //ReportParameters
                var qString = "?" + window.location.href.split("?")[1];

                $.ajax({
                    type: "POST",
                    url: "SSRSNativeReportViewer.aspx/GetReportParameters" + qString,
                    data: {},
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',

                    success: function (data) {

                        //$("SubscribeManagerDiv").find("tr:gt(0)").remove();
                        //$("#SubscribeManagerDiv").css("visibility", "visible");
                        //$("#SubscribeManagerDiv").fadeIn();
                        //$("#SubscriptionsTable").show();
                        //$("#LoadingDiv").fadeOut();

                        var objdata = $.parseJSON(data.d);
                        $("#SubscriptionsTable").append(objdata);
                    },
                    error: function (XHR, errStatus, errorThrown) {
                        //$("#LoadingDiv").fadeOut();
                        var err = JSON.parse(XHR.responseText);
                        alert("Error. " + err.Message);
                    }
                });
            });
        }
    </script>

    <div id="ViewerDiv">
        <div id="upper">
	        <ul>
                <li class="dropdown">
                <a href="javascript:void(0)" class="dropbtn">Actions</a>
                <div class="dropdown-content">
                  <a href="javascript:OpenEditor()">Open with Report Builder</a>
                  <a href="javascript:OpenSubscriptions()">Subscriptions</a>
                </div>
              </li>
            </ul>
        </div>
        <iframe id="ReportFrame" width="100%" height="100%" src=""></iframe>
    </div>
    <div id="SubscribeManagerDiv" style="visibility:hidden">    
        <div id="upperSubscription">
	        <ul>
                <li><a href="javascript:RedirectAddSubscription()">Add Subscription</a></li>
                <li><a href="javascript:void(0)">Add Data-Driven Subscription</a></li>
                <li><a href="javascript:void(0)">Enable</a></li>
                <li><a href="javascript:void(0)">Disable</a></li>
                <li><a href="javascript:void(0)">Delete</a></li>
                <li style="float:right;background-color:#4CAF50"><a href="javascript:BackToViewer()">Back</a></li>
            </ul>
        </div>
        <div id="LoadingDiv">Loading Subscriptions...</div>
        <table id="SubscriptionsTable">
            <tr>
                <th><input type="checkbox" id="cbCheckAll"></th>
                <th>Type</th>
                <th>Delivery Extension</th>
                <th>Description</th>
                <th>Event</th>
                <th>Last Run</th>
            </tr>
        </table>
        <table id="AddSubscriptionForm" style="width:100%; visibility:hidden">
            <tr><td colspan="2"><p>Use this page to edit the delivery options for a subscription.</p></td></tr>
            <tr>
                <td><p>Description<br /><span>Specify a description for this subscription.</span></p></td>
                <td><input type="text" id="Description" name="Description"></td>
            </tr>
            <tr>
                <td><p>Delivery Extension *</p></td>
                <td>
                    <select>
                      <option value="choose">Choose a method of delivery</option>
                      <option value="windowsshare">Windows File Share</option>
                        <option value="email">Email</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td><p>File Name *</p></td>
                <td><input type="text" id="FileName" name="FileName" required></td>
            </tr>
            <tr>
                <td><p>Path *</p></td>
                <td><input type="text" id="Path" name="Path" required></td>
            </tr>
            <tr>
                <td><p>Render Format *</p></td>
                <td>
                    <select>
                        <option value="pdf">PDF</option>
                        <option value="word">Word</option>
                        <option value="excel">Excel</option>
                        <option value="excel">PowerPoint</option>
                        <option value="tiff">TIFF file</option>
                        <option value="mhtml">MHTML (web archive)</option>
                        <option value="csv">CSV (comma delimited)</option>
                        <option value="datafeed">Data Feed</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                   <p>File Extension<br /><span>Add a file extension when the file is created.</span></p>
                </td>
                <td>
                    <select>
                        <option value="yes">YES</option>
                        <option value="no">NO</option>                        
                    </select>
                </td>
            </tr>
            <tr>
                <td><p>Overwrite options *</p></td>
                <td>
                    <input type="radio" name="overwriteoptions" value="overwrite">Overwrite an existing file with a newer version<br/>
                    <input type="radio" name="overwriteoptions" value="donotoverwrite">Do not overwrite the file if a previous version exists<br/>
                    <input type="radio" name="overwriteoptions" value="increment">Increment file names as newer versions are added
                </td>
            </tr>
            <tr><td colspan="2"><input type="submit" value="Save"><input type="submit" value="Cancel"></td></tr>
        </table>
        <div id="ReportParameters"></div>
    </div>    

</asp:content>

<asp:content id="PageTitle" contentplaceholderid="PlaceHolderPageTitle" runat="server">
Application Page
</asp:content>

<asp:content id="PageTitleInTitleArea" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
My Application Page
</asp:content>
