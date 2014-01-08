<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyWorkSummary.ascx.cs" Inherits="EPMLiveWebParts.MyWorkSummary.MyWorkSummary" %>

<style type="text/css">
    .pipeSeperator {
        float: left;
        font-size: large;
    }

    .listMainDiv {
        float: left;
        padding: 5px;
        margin-right: 5px;
    }
</style>


<script type="text/javascript">

    $(function () {
        fillMyWorkSummaryData();
    });

    function fillMyWorkSummaryData() {
        if (dataXml != '') {

            $("#<%=myWorkSummaryItemsDiv.ClientID%>").hide();
            $('#divMyWorkSummaryLoad').show();

            EPMLiveCore.WorkEngineAPI.Execute("GetWorkItemsByWorkType", dataXml, function (response) {
                var divHTML = response.toString().replace("<Result Status=\"0\">", "").replace("</Result>", "");
                $("#<%=myWorkSummaryItemsDiv.ClientID%>").html("");
                $("#<%=myWorkSummaryItemsDiv.ClientID%>").html(divHTML);

                $('#divMyWorkSummaryLoad').hide();
                $("#<%=myWorkSummaryItemsDiv.ClientID%>").show();

            });
        }
    }

    function displayMyWorkItemsByFilter() {
        alert("This functionality is under development, sorry for inconvenience.");
    }

</script>

<div id="divMyWorkSummaryLoad" style="align-content: center">
    <img src="../_layouts/15/epmlive/images/mywork/loading16.gif" />
</div>
<div id="myWorkSummaryItemsDiv" runat="server" style="float: left;" />

