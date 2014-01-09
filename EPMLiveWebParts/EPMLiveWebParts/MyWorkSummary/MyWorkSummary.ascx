<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyWorkSummary.ascx.cs" Inherits="EPMLiveWebParts.MyWorkSummary.MyWorkSummary" %>
<style type="text/css">
    .mwsPipeSeperator {
        float: left;
        font-size: large;
    }

    .mwsMainDiv {
        float: left;
    }

    .mwsItemDiv {
        float: left;
        padding: 5px;
        margin-right: 5px;
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
            var options = { url: viewSiteContentUrl, showMaximized: true };
            SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
        }
    }
</script>
<div id="mwsLoadDiv" style="display: none;">
    <img src="../_layouts/15/epmlive/images/mywork/loading16.gif" />
</div>
<div id="mwsMainDiv" class="mwsMainDiv" />
