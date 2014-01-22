<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyWorkSummary.ascx.cs" Inherits="EPMLiveWebParts.MyWorkSummary.MyWorkSummary" %>
<style type="text/css">
    #mwsMainDiv {
        width: 95%;
        margin: 10px auto;
        padding: 5px;
        position: relative;
        display: inline-block;
        text-shadow: 0 1px 0 #fff;
    }

        #mwsMainDiv .row {
            margin: 0;
            padding: 0;
        }

        #mwsMainDiv .mwsItemDiv {
            float: left;
            color: #777777;
            margin-right: 20px;
            cursor: pointer;
            opacity:1;
        }

            #mwsMainDiv .mwsItemDiv:hover {
                opacity: 0.5;
            }

        #mwsMainDiv .icon-wrapper {
            float: left;
        }

            #mwsMainDiv .icon-wrapper .icon {
                font-size: 23px;
                text-align: center;
                line-height: 23px;
            }

                #mwsMainDiv .icon-wrapper .icon .fa {
                    display: block;
                }

            #mwsMainDiv .icon-wrapper .text {
                font-size: 16px;
                text-align: center;
                line-height: 20px;
                color: #999999;
            }

        #mwsMainDiv .mwsItemDiv .count {
            font-size: 35px;
            line-height: 43px;
            padding-left: 5px;
            position: relative;
            display: inline-block;
        }
</style>


<script type="text/javascript">

    $(function () {
        MyWorkSummaryClient.fillWebPartData();
    });

    MyWorkSummaryClient = {
        dataXml: '<%=dataXml%>',
        fillWebPartData: function () {
            if (this.dataXml != '') {

                $("#mwsMainDiv").hide();
                $("#mwsLoadDiv").show();

                EPMLiveCore.WorkEngineAPI.Execute("GetMyWorkSummary", this.dataXml, function (response) {
                    var divHTML = response.toString().replace("<Result Status=\"0\">", "").replace("</Result>", "");
                    $("#mwsMainDiv").html("");
                    $("#mwsMainDiv").html(divHTML);

                    $("#mwsLoadDiv").hide();
                    $("#mwsMainDiv").show();
                });
            }
        },
        openMyWorkPage: function (siteUrl, listid) {
            var viewSiteContentUrl = siteUrl + "/_layouts/epmlive/mywork.aspx?listid=" + listid;
            location.href = viewSiteContentUrl;
        }
    }
</script>
<div id="mwsLoadDiv" style="display: none;">
    <img src="../_layouts/15/epmlive/images/mywork/loading16.gif" />
</div>
<div id="mwsMainDiv" />
