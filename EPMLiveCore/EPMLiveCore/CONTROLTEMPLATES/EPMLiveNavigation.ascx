<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="EPMLiveCore.Infrastructure.Navigation" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EPMLiveNavigation.ascx.cs" Inherits="EPMLiveCore.CONTROLTEMPLATES.EPMLiveNavigation" %>

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
                    <li<%= attr %>><span id="<%= lId %>" class="epm-nav-tlnode <%= node.CssClass %>" title="<%= node.Title %>" data-role="top-nav-node" data-id="<%= node.Id %>"></span></li>
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
                    <li<%= attr %>><span id="<%= lId %>" class="epm-nav-tlnode <%= node.CssClass %>" title="<%= node.Title %>" data-role="top-nav-node"></span></li>
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

               if (Pinned && SelectedTlNode.Equals("epm-nav-top-" + node.Id))
               {
                   attr = @"style=""display:block;""";
               }
        %>
            <div id="epm-nav-sub-<%= node.Id %>" class="epm-nav-sub" data-role="sub-nav-node"<%= attr %>>
                <% if (node.Id.ToLower().Equals("ql"))
                   { %>
                    <SharePoint:SPRememberScroll runat="server" ID="EPMNavScroll" onscroll="javascript:_spRecordScrollPositions(this);" style="overflow: auto;">
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
                    </SharePoint:SPRememberScroll>
                <% }
                   else
                   { %>    
                <% } %>
            </div>       
        <% } %>
    </div>
</div>

<script type="text/javascript">
    (function() {
        window.SP.SOD.notifyScriptLoadedAndExecuteWaitingJobs('EPMLiveNavigation');
    })();
</script>