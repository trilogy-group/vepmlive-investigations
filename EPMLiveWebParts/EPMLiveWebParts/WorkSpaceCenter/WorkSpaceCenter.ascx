<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WorkSpaceCenter.ascx.cs" Inherits="EPMLiveWebParts.WorkSpaceCenter.WorkSpaceCenter" %>
<script type="text/javascript" src="../_layouts/15/epmlive/TreeGrid/GridE.js"></script>
<style type="text/css">
      #EPMWorkspaceCenterGrid {
        margin: 10px auto;
        padding: 5px;
        position: relative;
        display: inline-block;
    }
    #DDLView {
       text-align:right;
       padding-right:7px;
    }


</style>
<script type="text/javascript">
    function changeView() {
        $("#myWorkSpace_Search").val('');
        var source = Grids[0].Source;
        source.Data.url = '<%= WebUrl %>/_vti_bin/WorkEngine.asmx';
        source.Data.Function = 'Execute';
        source.Data.Param.Function = 'GetWorkspaceCenterGridData';
        source.Data.Param.Dataxml = $("#<%=ddWorkspaceCenterView.ClientID%>").val();
        Grids["gridWorkSpaceCenter"].Reload(source, null, false);
    }

    $(document).ready(function () {
        $("#myWorkSpace_Search").keyup(function (e) {
            var query = $(this).val();
            var count = GetGrids();
            var grid = Grids["gridWorkSpaceCenter"];
            if (query.length > 0) {
                grid.ChangeFilter('WorkSpace', query.toLowerCase(), 11, 0, 1, null);
            }
            else {
                grid.ChangeFilter('WorkSpace', query.toLowerCase(), 12, 0, 1, null);
            }
            grid.Update();
            grid.Render();
        });
    });
    function createNewWorkspace() {
        var createNewWorkspaceUrl = "<%= WebUrl %>/_layouts/epmlive/QueueCreateWorkspace.aspx";
        var options = {
            url: createNewWorkspaceUrl, width: 1000, height: 600, title: 'Create', dialogReturnValueCallback: function (dialogResult, returnValue) {
                if (dialogResult === 1) {
                    toastr.options = {
                        'private closeButton': false,
                        'debug': false,
                        'positionClass': 'toast-top-right',
                        'onclick': null,
                        'showDuration': '300',
                        'hideDuration': '1000',
                        'timeOut': '5000',
                        'extendedTimeOut': '1000',
                        'showEasing': 'swing',
                        'hideEasing': 'linear',
                        'showMethod': 'fadeIn',
                        'hideMethod': 'fadeOut'
                    }
                    toastr.info('Your workspace is being created - we will notify you when it is ready.');
                }
            }
        };
        SP.UI.ModalDialog.showModalDialog(options);
    }
</script>
<div id="EPMWorkspaceCenter" style="width: 100%;">
    <div id="btnNew">
          <a href="javascript:createNewWorkspace();" class="ms-core-menu-root ms-textXLarge">
              <img title="Add new" alt="" src="/_layouts/epmlive/images/newitem5.png"/>
              new item
          </a>
    </div>
    <div id="DDLView">
        <input type="text" id="myWorkSpace_Search" class="ms-cui-tb mwg-watermark" style="width: 100px;">
        <asp:Label ID="lblView" Text="View :" runat="server"></asp:Label>
        <asp:DropDownList ID="ddWorkspaceCenterView" runat="server" onchange="changeView()">
            <asp:ListItem Text="All Items" Value="AllItems" Selected="True"></asp:ListItem>
            <asp:ListItem Text="My Workspace" Value="MyWorkspace"></asp:ListItem>
            <asp:ListItem Text="My Favorite" Value="MyFavorite"></asp:ListItem>
        </asp:DropDownList>

    </div>
    <div id="EPMWorkspaceCenterGrid" style="width: 100%; height: 400px;">
        <SharePoint:ScriptBlock ID="workspaceCenterScriptBlock1" runat="server">
            $(function () {
                var loadWorkspaceCenterGrid = function () {
                    window.TreeGrid('<treegrid data_url="<%= WebUrl %>/_vti_bin/WorkEngine.asmx" data_timeout="0" data_method="Soap" data_function="Execute" data_namespace="workengine.com" data_param_function="GetWorkspaceCenterGridData" data_param_dataxml="AllItems" layout_url="<%= WebUrl %>/_vti_bin/WorkEngine.asmx" layout_timeout="0" layout_method="Soap" layout_function="Execute" layout_namespace="workengine.com" layout_param_function="WorkSpaceCenterLayout" suppressmessage="3" <%= DebugTag %>></treegrid>', 'EPMWorkspaceCenterGrid');
                };
                ExecuteOrDelayUntilScriptLoaded(loadWorkspaceCenterGrid, 'EPMLive.js');
            });
          
        </SharePoint:ScriptBlock>
    </div>
</div>
