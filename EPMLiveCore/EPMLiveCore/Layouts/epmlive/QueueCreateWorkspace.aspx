<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueueCreateWorkspace.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.QueueCreateWorkspace" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:content id="PageHead" contentplaceholderid="PlaceHolderAdditionalPageHead" runat="server">

</asp:content>

<asp:content id="Main" contentplaceholderid="PlaceHolderMain" runat="server">
    <link href="/_layouts/epmlive/stylesheets/QueueCreateWorkspace.css" rel="stylesheet">
    <link href="/_layouts/epmlive/stylesheets/libraries/epmlive/buttons.css" rel="stylesheet">     
  
    <script type="text/javascript" src="QueueCreateWorkspace.js"></script>
    <script type="text/javascript" src="/_layouts/epmlive/javascripts/libraries/slimScroll.js"></script>

    <%--JS variables--%>
    <script type="text/javascript">
        var isStandAlone = '<%=_isStandAlone%>';
        var compLvls = '<%=_compLevels%>';
        var workEngineSvcUrl = '<%=_workEngineSvcUrl%>';
        var workspaceTitle = '<%=_workspaceTitle%>';
        var workspaceDescription = '';
        var listGuid = '<%=_lstGuid%>';
        var listName = '<%=_listName%>';
        var itemId = '<%=_itemId%>';
        var creatorId = '<%=_currentUserId%>';
        var createFromLiveTemps = '<%=_createFromLiveTemp%>';
        var showIsInProgressMsg = '<%=_showInProgress%>';
        var createDefault = '<%=_defaultCreateNewOpt%>';
        var onlineAvail = '<%=_isCreateFromOnlineAvail.ToString().ToLower()%>';
        var localAvail = '<%=_isCreateFromLocalAvail.ToString().ToLower()%>';
        var uniquePerm = '<%=_uniquePermission %>';
    </script>
    <div id="OuterContainer">
        <div class="modal-body">
            <div id="divProgress" style="height:200px;width:300px;display:none;">
                <p>
                    Workspace is being created, please wait.
                </p>
            </div>
            <%--top section--%>
	        <div class="divTopSection" style="display:none;">    
	            <label style="font-family:Open Sans Regular;font-size:15px;padding-right:10px;">
                    What is the title of this Workspace?
	            </label>  
	            <input type="textbox" id="tbWsName" name="tbWsName" class="titleInput" data-bind="value: workspaceTitle, valueUpdate: 'afterkeydown', event: { keydown: PreventNonAlphaNumeric }" />
	            <br><br>
                <label style="font-family:Open Sans Regular;font-size:15px;padding-right:10px;">
                    What is the description of this Workspace?
	            </label>  
	            <input type="textbox" id="tbWsDescription" name="tbWsDescription" class="titleInput" data-bind="value: workspaceDescription, valueUpdate: 'afterkeydown', event: { keydown: PreventNonAlphaNumeric }" />
	            <br><br>
	            <label style="font-family:Open Sans Regular;font-size:15px;">
                    Permissions
	            </label> 
	            <br/>
                <input id="permsPrivate" name="rPermGrp" type="radio" value="true" data-bind="checked: uniquePermission"/> <span>Private - Invite only</span>
                <br/>
                <input id="permsOpen" name="rPermGrp" type="radio" value="false" data-bind="checked: uniquePermission" /> <span>Open - Accessible and open to anyone who has permission to the parent site</span> 
            </div>
            <%--bottom section--%>
	        <div class="divBottomSection" >
		        <div class="toggle" data-bind="visible: onlineAvail() === 'true' && localAvail() === 'true'">
                    <span style="float:left;padding-left:8px;" class="toggleButton slider-selected" id="online" data-bind="click: function (data, event) { toggle(data, event); }">ONLINE</span>
                    <span style="float:right;padding-right:12px;" class="toggleButton" id="local" data-bind="click: function (data, event) { toggle(data, event); }">LOCAL</span>
                    <div class="slider">&nbsp;
                    </div>
                </div>
                
	            <div id="templateContainer">
	                <div id="onlineTemplates">
	                    <%--<div class="workspace-loading"  id="marketLoading" >
                            <div class="loading-message">Loading Workspaces...</div>
                        </div>--%>
	                    <div class="divNoOnlineTempMsg" data-bind="fadeVisible: (marketApps().length === 0) && !marketAppsLoading()">
                            <div style="text-align: center">There are no online templates available</div>
                        </div>
                        <div  data-bind="fadeVisible: (marketApps().length > 0)">
		                    <ol data-bind="foreach: marketApps">
			                    <li class="template" data-bind="click: $root.gotoTemplate">
			                        <img class="template-preview" data-bind="attr: { src: $data.ImageUrl['#cdata'] }"/>
				                    <div class="template-meta">
					                    <div class="template-name">
                                            <span data-bind="text: $data.Title['#cdata']"></span>
					                    </div>
					                    <div class="template-description">
                                            <span data-bind="text: $data.Description['#cdata']"></span>
					                    </div>
				                    </div>
                                    <input type="hidden" id="templateTitle" name="templateTitle" data-bind="attr: { value: $data.Title['#cdata'] }"/>
                                    <input type="hidden" id="templateType" name="templateType" data-bind="attr: { value: $data.TemplateType['#cdata'] }"/>
                                    <input type="hidden" id="templateDescription" name="templateDescription" data-bind="attr: { value: $data.Description['#cdata'] }"/>
                                    <input type="hidden" id="templateMoreInfo" name="templateMoreInfo"/>
                                    <input type="hidden" id="templateSalesInfo" name="templateSalesInfo" data-bind="attr: { value: $data.SalesInfo['#cdata'] }"/>
                                    <input type="hidden" id="templateImageUrl" name="templateImageUrl"/>
                                    <input type="hidden" id="templateLevels" name="templateLevels" data-bind="attr: { value: $data.Levels['#cdata'] }"/>
                                    <input type="hidden" id="templateOnlineFolder" name="templateOnlineFolder" data-bind="attr: { value: $data.Title['#cdata'] }"/>
			                    </li>
		                    </ol>
                        </div>
	                </div>
	                <div id="localTemplates">
	                    <%--<div class="workspace-loading" id="localLoading" >
                            <div class="loading-message">Loading Workspaces...</div>
                        </div>--%>
	                    <div class="divNoLocalTempMsg" data-bind="fadeVisible: (downloadedApps().length === 0) && !downloadedAppsLoading()">
                            <div style="text-align: center">There are no local templates available</div>
                        </div>
                        <div  data-bind="fadeVisible: (downloadedApps().length > 0)">
		                    <ol data-bind="foreach: downloadedApps">
			                    <li class="template" data-bind="click: $root.gotoTemplate">
			                        <img class="template-preview" data-bind="attr: { src: $data.ImageUrl['#cdata'] }"/>
				                    <div class="template-meta">
					                    <div class="template-name" >
                                             <span data-bind="text: $data.Title['#cdata']"></span>
					                    </div>
					                    <div class="template-description" >
                                            <span data-bind="text: $data.Description['#cdata']"></span>
					                    </div>
				                    </div>
                                    <input type="hidden" id="localTemplateId" name="localTemplateId" data-bind="attr: { value: $data['@Id'] }"/>
                                    <input type="hidden" id="localTemplateTitle" name="localTemplateTitle" data-bind="attr: { value: $data.Title['#cdata'] }"/>
                                    <input type="hidden" id="localTemplateType" name="localTemplateType" data-bind="attr: { value: $data.TemplateType['#cdata'] }"/>
                                    <input type="hidden" id="localTemplateDescription" name="localTemplateDescription" data-bind="attr: { value: $data.Description['#cdata'] }"/>
                                    <input type="hidden" id="localTemplateMoreInfo" name="localTemplateMoreInfo"/>
                                    <input type="hidden" id="localTemplateSalesInfo" name="localTemplateSalesInfo" data-bind="attr: { value: $data.SalesInfo['#cdata'] }"/>
                                    <input type="hidden" id="localTemplateImageUrl" name="localTemplateImageUrl"/>
                                    <input type="hidden" id="localTemplateLevels" name="localTemplateLevels" data-bind="attr: { value: $data.Levels['#cdata'] }"/>
			                    </li>
		                    </ol>
                        </div>
	                </div>
	            </div>
            </div>
        </div>
        <div class="modal-footer" >
            <button type="button" class="epmliveButton" style="float:right;" data-bind="click: createWorkspace">Create Workspace</button>
            <button type="button" class="epmliveButton" style="float:right;" data-dismiss="modal" data-bind="click: cancelCreation">Cancel</button>
            
        </div>
    </div>
    
</asp:content>

<asp:content id="PageTitle" contentplaceholderid="PlaceHolderPageTitle" runat="server">
Create Workspace
</asp:content>

<asp:content id="PageTitleInTitleArea" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
Create Workspace
</asp:content>
