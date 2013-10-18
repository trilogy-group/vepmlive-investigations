<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="EPMLiveCore.Infrastructure.Navigation" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Assembly="Telerik.Web.UI, Version=2013.1.220.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EPMLiveNavigation.ascx.cs" Inherits="EPMLiveCore.CONTROLTEMPLATES.EPMLiveNavigation" %>

<!--[if lte IE 7]><script src="/_layouts/15/epmlive/javascripts/icomoon-ie7.min.js"> </script><![endif]-->

<sharepoint:StyleBlock runat="server">
    .epm-nav-unpinned { margin-left: 50px !important; }

    .epm-nav-pinned { margin-left: 230px !important; }

    .ms-dialog .epm-nav-pinned, .ms-dialog .epm-nav-unpinned { margin-left: auto !important; }
</sharepoint:StyleBlock>

<% if (Pinned)
   {
%>
    <Sharepoint:StyleBlock runat="server">
        #s4-ribbonrow,
        #s4-workspace {
        margin-left: 230px;
        }

        .ms-dialog .epm-nav-pinned,
        .ms-dialog #s4-ribbonrow,
        .ms-dialog #s4-workspace {
        margin-left: 0;
        }
    </Sharepoint:StyleBlock>
<%
   }
   else
   { %>
    <Sharepoint:StyleBlock runat="server">
        #s4-ribbonrow,
        #s4-workspace {
        margin-left: 50px;
        }
        
        .ms-dialog .epm-nav-unpinned,
        .ms-dialog #s4-ribbonrow,
        .ms-dialog #s4-workspace {
        margin-left: 0;
        }
    </Sharepoint:StyleBlock>
<% } %>

<div id="epm-nav">
    <div id="epm-nav-top">
        <ul>
            <% foreach (NavNode node in TopNodes.Where(node => node.Visible))
               {
                   if (node.Separator)
                   {
            %>
                    <li class="epm-nav-tl-sep"></li>
                <%
                   }
                   else
                   {
                       var lId = "epm-nav-top-" + node.Id;
                       var classes = new List<string>();

                       if (SelectedTlNode.Equals(lId))
                       {
                           classes.Add("epm-nav-node-selected");
                           if (Pinned) classes.Add("epm-nav-node-opened");
                       }

                       var attr = SelectedTlNode.Equals(lId) ? string.Format(@" class=""{0}""", string.Join(" ", classes.ToArray())) : string.Empty;
                %>
                    <li<%= attr %>><span id="<%= lId %>" class="epm-nav-tlnode <%= node.CssClass %>" title="<%= node.Title %>" data-role="top-nav-node" data-id="<%= node.Id %>" data-linkprovider="<%= node.LinkProvider %>"></span></li>
            <%
                   }
               }
            %>
        </ul>
        <ul class="bottom">
            <% foreach (NavNode node in BottomNodes.Where(node => node.Visible))
               {
                   if (node.Separator)
                   {
            %>
                    <li class="epm-nav-tl-sep"></li>
                <%
                   }
                   else
                   {
                       var lId = "epm-nav-top-" + node.Id;
                       var classes = new List<string>();

                       if (SelectedTlNode.Equals(lId))
                       {
                           classes.Add("epm-nav-node-selected");
                           if (Pinned) classes.Add("epm-nav-node-opened");
                       }

                       var attr = SelectedTlNode.Equals(lId) ? string.Format(@" class=""{0}""", string.Join(" ", classes.ToArray())) : string.Empty;
                %>
                    <li<%= attr %>><span id="<%= lId %>" class="epm-nav-tlnode <%= node.CssClass %>" title="<%= node.Title %>" data-role="top-nav-node" data-id="<%= node.Id %>" data-linkprovider="<%= node.LinkProvider %>"></span></li>
            <%
                   }
               }
            %>
        </ul>
    </div>
    <div id="epm-nav-sub"<%= Pinned ? @" style=""display:block;""" : string.Empty %>>
        <span id="epm-nav-pin" class="fui-ext-pin <%= Pinned ? "epm-nav-pin-pinned" : "epm-nav-pin-unpinned" %>"></span>
        <% foreach (NavNode node in AllNodes.Where(node => node.Visible && !node.Separator))
           {
               var attr = string.Empty;

               var currentNode = "epm-nav-top-" + node.Id;
               if (Pinned && SelectedTlNode.Equals(currentNode))
               {
                   attr = @" style=""display:block;""";
               }
        %>
            <div id="epm-nav-sub-<%= node.Id %>" class="epm-nav-sub" data-role="sub-nav-node"<%= attr %>>
                <% if (node.Id.ToLower().Equals("ql"))
                   { %>
                    <div class="epm-nav-sub-header">Navigation</div>
                    <div class="epm-nav-sub-header-bottom"></div>
                    <div class="epm-nav-home"><span class="fui-home"></span><a class="epm-nav-node" href="<%= WebUrl %>">Home</a></div>

                    <SharePoint:SPTreeView
                        ID="EPMLiveNav"
                        runat="server"
                        ShowLines="False"
                        DataSourceId="QuickLaunchSiteMap"
                        CssClass="epm-nav-sub-menu" 
                        NodeStyle-CssClass="epm-nav-node"
                        SelectedNodeStyle-CssClass="epm-nav-node-selected"
                        HoverNodeStyle-CssClass="epm-nav-node-hover"
                        ParentNodeStyle-CssClass="epm-nav-node-parent" 
                        RootNodeStyle-CssClass="epm-nav-node-root"
                        SkipLinkText=""
                        ExpandImageUrl="/_layouts/15/epmlive/images/navigation/expand.png"
                        ExpandImageUrlRtl="/_layouts/15/images/tvclosedrtl.png?rev=23"
                        CollapseImageUrl="/_layouts/15/epmlive/images/navigation/collapse.png"
                        CollapseImageUrlRtl="/_layouts/15/images/tvopenrtl.png?rev=23"
                        NoExpandImageUrl="/_layouts/15/images/tvblank.gif?rev=23" 
                        UseInternalDataBindings="False" 
                        AutoExpandSelectedNode="False" 
                        EnableTheming="False" 
                        EnableViewState="False" 
                        PopulateNodesFromClient="False" 
                        ExpandDepth="0" 
                        ClientIDMode="Static" 
                        OnPreRender="OnTreeViewPreRender" />
                <% }
                   else if (node.Id.ToLower().Equals("workspaces"))
                   { %>
                    <div id="EPMNavWorkspacesTree">
                        <input placeholder="Search..." type="text" id="EPMNavWSTSearch"/>
                        <telerik:RadTreeView ID="WorkspacesNavTree" ShowLineImages="False" runat="server" EnableTheming="False" EnableViewState="False" />
                    </div>
                <% } %> 
            </div>       
        <% } %>
        <div id="epm-nav-sub-bottom-ph">&nbsp;</div>
    </div>
</div>

<SharePoint:ScriptBlock runat="server">
    (function() {
        window.epmLiveNavigation = {
            currentWebId: '<%= WebId %>',
            currentWebUrl: '<%= WebUrl %>',
            currentUserId: <%= UserId %>,
            staticProvider: '<%= StaticProviderLinks %>',
            selectedNode: '<%= SelectedNode %>',
            workspaceTree: function() {
                return window.$find('<%= WorkspacesNavTree.ClientID %>');
            }
        };

        window.SP.SOD.notifyScriptLoadedAndExecuteWaitingJobs('EPMLiveNavigation');
    })();
</SharePoint:ScriptBlock>