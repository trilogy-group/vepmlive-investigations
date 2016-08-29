<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyWorkSummary.ascx.cs" Inherits="EPMLiveWebParts.MyWorkSummary.MyWorkSummary" %>

<style type="text/css">
    #mwsMainDiv {
        width: 100%;
        margin: 10px auto;
        padding: 5px;
        position: relative;
        display: inline-block;
        font-family: "Open Sans";
        font-weight: 400;
        color: #555;
    }

        #mwsMainDiv section {
            display: table;
            position: relative;
            margin-bottom: 7px;
        }

            #mwsMainDiv section .icon {
                float: left;
                display: inline;
                font-size: 24px;
                color: #aaa;
                width: 20px;
            }

            #mwsMainDiv section .text {
                display: inline;
                float: left;
                color: #999;
                font-size: 17px;
                padding-left: 10px;
                white-space: nowrap;
                overflow: hidden;
                text-overflow: ellipsis;
                width: 140px;
            }

            #mwsMainDiv section .count {
                display: inline;
                float: left;
                padding-left: 9px;
                font-size: 17px;
                width: 30px;
                text-align: center;
                padding-right: 9px;
                background-color: #E5E5E5;
                border-radius: 10px;
                color: #888;
            }

    section:hover {
        cursor: pointer;
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

                var siteUrl = $(this.dataXml).find("SiteUrl").text();
                EPMLiveCore.WorkEngineAPI.set_path(siteUrl + '/_vti_bin/WorkEngine.asmx');
                EPMLiveCore.WorkEngineAPI.Execute("GetMyWorkSummary", this.dataXml, function (response) {
                    var divHTML = response.toString().replace("<Result Status=\"0\">", "").replace("</Result>", "");
                    $("#mwsMainDiv").html("");
                    $("#mwsMainDiv").html(divHTML);

                    $("#mwsLoadDiv").hide();
                    $("#mwsMainDiv").show();

                    $("section")
.mouseover(function () {
    $(this).find('.icon').css('color', '#999');
    $(this).find('.text').css('color', '#888');
    $(this).find('.count').css('background-color', '#0090CA');
    $(this).find('.count').css('color', '#ffffff');
})
.mouseout(function () {
    $(this).find('.icon').css('color', '#aaa');
    $(this).find('.text').css('color', '#999');
    $(this).find('.count').css('color', '#888');
    $(this).find('.count').css('background-color', '#e5e5e5');

});
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
