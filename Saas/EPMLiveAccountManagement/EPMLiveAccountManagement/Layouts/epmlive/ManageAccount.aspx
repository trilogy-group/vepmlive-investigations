<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageAccount.aspx.cs" Inherits="EPMLiveAccountManagement.Layouts.epmlive.ManageAccount" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

<link rel="STYLESHEET" type="text/css" href="dhtml/xtab/dhtmlxtabbar.css">
<script  src="dhtml/xtab/dhtmlxcommon.js"></script>
<script  src="dhtml/xtab/dhtmlxtabbar.js"></script>
<script  src="dhtml/xtab/dhtmlxtabbar_start.js"></script>
<script>
    dhtmlx.skin = "default";

    function upgradecallback() {
        location.href = location.href;
    }
</script>
<style>
    .ms-dialog .ms-bodyareacell
    {
        padding-left: 0px !important;
        padding-right: 0px !important;
    }
    .dhx_tabcontent_zone
    {
        border: 0px !important;
    }
    
</style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    
    <div id="a_tabbar" style="width:100%; height:578px;" >
    </div>
    <%if(isOwner && activationtype != 3)
      { %>
        <div id="a1" name="Account" width="130px" height="100px" align="left" style="padding:10px;display:none;">

            <table>
                <tr>
                    <td valign="top" width="450">
                    
                        <div style="line-height: 20px">
                        <asp:Label ID="lblSubscription" runat="server" Text="product"></asp:Label>
                        <br />

                        <h3>User Usage</h3>

                        <table width="300">
                            <tr>
                                <td class="ms-toolbar">
                                    <strong><asp:Label ID="lblUserCount" runat="server"></asp:Label> out of <asp:Label ID="lblMaxUsers" runat="server"></asp:Label></strong>
                                </td>
                            </tr>
                            <tr>
                                <td style="border:  1px solid #c9c9c9" style="height:5px">
                                    <table width="<%=strWidth%>%" bgcolor="#BFBFBF" style="height:5px">
                                        <tr style="height:5px">
                                            <td style="height:5px">&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <div style="display:none">
                            <h3>Disk Usage</h3>

                            <table width="300">
                                <tr>
                                    <td class="ms-toolbar">
                                        <strong><asp:Label ID="lblDiskCount" runat="server"></asp:Label> out of <asp:Label ID="lblMaxDisk" runat="server"></asp:Label></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border:  1px solid #c9c9c9" style="height:5px">
                                        <table width="<%=strDiskWidth%>%" bgcolor="#BFBFBF" style="height:5px">
                                            <tr style="height:5px">
                                                <td style="height:5px">&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>


                        </div>
                    </td>
                    <%if(billingSystem == 2){ %>
                    <td style="border-left: 1px solid gray; padding-left:15px" valign="top" width="350">
                        
                        <%if(contractLevel == "3")
                          { %>

                        <div style="padding-bottom: 20px"><font style="color:#333333;font-family:Helvetica,arial,sans-serif;font-size:14px;font-weight:bold;">What happens if I upgrade in the middle of a billing cycle?</font></div>
                        
                        <font style="color:#333333;font-family:Helvetica,arial,sans-serif;font-size:14px;">
                        You will be immediately charged the new rate for the remaining days of the current billing cycle.
                        You will also be immediately credited (not to your card but to your account) the old rate for the remaining days of the current billing cycle.
                        Any credits will be applied to your next bill, so keep in mind that your next bill may be less than expected due to the credit.</font>
                        <%}
                          else
                          { %>
                        <div style="padding-bottom: 20px"><font style="color:#333333;font-family:Helvetica,arial,sans-serif;font-size:14px;font-weight:bold;">What happens if I add more users in the middle of the billing cycle?</font></div>
                        <font style="color:#333333;font-family:Helvetica,arial,sans-serif;font-size:14px;">
                        You will be immediately charged the prorated cost of your new users for the remaining days in the current billing cycle.
                        </font> 

                        <%} %>
                        <br />

                        <font style="color:#333333;font-family:Helvetica,arial,sans-serif;font-size:14px;font-weight:bold;line-height:40px;">Need to cancel your account?</font>
                        <br />
                        <font style="color:#333333;font-family:Helvetica,arial,sans-serif;font-size:14px;">
                        Once your account is cancelled, all your sites will be immediately and permanently deleted. 
                        If you have a paying account you won't be charged again after your official cancellation date.
                        </font>

                        <br />
                        <br />
                        <font style="color:#333333;font-family:Helvetica,arial,sans-serif;font-size:14px;font-weight:bold;">We accept:</font>
                        <br />
                        <img src="/_layouts/epmlive/images/visa_64.png" />
                        <img src="/_layouts/epmlive/images/american_express_64.png" />
                        <img src="/_layouts/epmlive/images/discover_64.png" />
                        <img src="/_layouts/epmlive/images/mastercard_64.png" />
                    </td>
                    <%} %>
                </tr>
            
            </table>

            
        </div>
        <%} %>
    <script language="javascript">

        var tabbar = new dhtmlXTabBar("a_tabbar", "top");
        tabbar.setHrefMode("iframes");
        tabbar.setSkinColors("#EDEDED", "#FFFFFF");
        tabbar.setImagePath("dhtml/xtab/imgs/");
        tabbar.enableAutoReSize(true);

        <%if(isOwner){ %>
            
            tabbar.addTab("a1", "Account", "130px");
            tabbar.addTab("a3", "User Accounts", "130px");
        <%}%>

        tabbar.addTab("a4", "Personal Information", "130px");

        <%if(isOwner){ %>
            <% if(activationtype == 3){%>
                tabbar.setContentHref("a1", "v2licensing.aspx?isdlg=1");
            <%}else{ %>
                tabbar.setContent("a1", "a1");
            <%} %>
            tabbar.setContentHref("a3", "manageaccountusers.aspx?isdlg=1");
        <%}%>

        tabbar.setContentHref("a4", "editpersonal.aspx?isdlg=1");

        <%if(isOwner){ %>
            tabbar.setTabActive("a1");
        <%}else{%>
            tabbar.setTabActive("a4");
        <%}%>
    </script>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Manage Account
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
    Manage Account
</asp:Content>
