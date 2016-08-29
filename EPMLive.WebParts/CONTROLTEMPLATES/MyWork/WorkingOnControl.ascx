<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WorkingOnControl.ascx.cs" Inherits="EPMLiveWebParts.CONTROLTEMPLATES.MyWork.WorkingOnControl" %>

<div id="EPMWorkingOn" style="display: none;">
    <div id="EPMWorkingOnGrid" style="width: 100%; height: 100%;">
        <script type="text/javascript">
            $(function () {
                (function () {
                    var load = function () {
                        window.TreeGrid('<treegrid Data_Url="<%= WebUrl %>/_vti_bin/WorkEngine.asmx" Data_Timeout="0" Data_Method="Soap" Data_Function="Execute" Data_Namespace="workengine.com" Data_Param_Function="GetWorkingOnGridData" Data_Param_Dataxml="" Layout_Url="<%= WebUrl %>/_vti_bin/WorkEngine.asmx" Layout_Timeout="0" Layout_Method="Soap" Layout_Function="Execute" Layout_Namespace="workengine.com" Layout_Param_Function="GetWorkingOnGridLayout" Layout_Param_Dataxml="<%= LayoutDataXml %>" SuppressMessage="3" <%= DebugTag %>></treegrid>', 'EPMWorkingOnGrid');
                    };

                    ExecuteOrDelayUntilScriptLoaded(load, 'EPMLive.js');
                })();
            });
        </script>
    </div>
</div>