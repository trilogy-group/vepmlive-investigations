<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="queuejobs.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.queuejobs" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <style type="text/css">
        .allJobs {
            font-weight: bold;
            color: #000000;
            padding-right: 5px;
            cursor: pointer;
        }

        #jobqueuedetailslog-wrap {
            height: 100%;
            overflow: auto;
        }


        .row-fluid {
            width: 100%;
            *zoom: 1;
        }

        table#jobqueuedetailslog {            
            background-color: transparent;
            border-collapse: collapse;
            border-spacing: 0;
            width: 100%;
            margin-bottom: 20px;
        }
        
        table#jobqueuedetailslog th,
        table#jobqueuedetailslog td {
            padding: 6px;
            line-height: 20px;
            text-align: left;
            vertical-align: top;
            border-top: 1px solid #dddddd;
        }

        table#jobqueuedetailslog th {
            font-weight: bold;
        }

        table#jobqueuedetailslog  thead th {
            vertical-align: bottom;
        }

        .table-bordered {
            border: 1px solid #dddddd;
            border-collapse: separate;
            *border-collapse: collapse;
            border-left: 0;
            -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            border-radius: 4px;
        }

            .table-bordered th,
            .table-bordered td {
                border-left: 1px solid #dddddd;
            }
    </style>

    <script type="text/javascript">

        var timerjobuid;

        function getParameterByName(name) {
            var match = RegExp('[?&]' + name + '=([^&]*)').exec(window.location.search);
            return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
        }

        $(function () {
            $('#jobqueuedetailslog td:nth-child(2),#jobqueuedetailslog th:nth-child(2)').hide()
            timerjobuid = getParameterByName('jobid');
            if (timerjobuid) {
                filterLogByJobId(timerjobuid);
                //$("#lnkshowallJobs").show();
            }
        });

        var filterLogByJobId = function (jobid) {
            if (jobid) {                
                $("#jobqueuedetailslog tbody tr").hide();

                $("#jobqueuedetailslog tbody tr").each(function () {
                    if ($(this).find("td:eq(1)").text().indexOf(timerjobuid) >= 0) {
                        $(this).show();
                    }
                });
            }
        };

    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">    
    <asp:PlaceHolder ID="queuejobsPlaceHolder" runat="server" />
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    <SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" Text="Work Queue" EncodeMethod='HtmlEncode' />
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="Work Queue"></asp:Label>
</asp:Content>
