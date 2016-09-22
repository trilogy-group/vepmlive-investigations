<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tlwizard.aspx.cs" Inherits="EPMLiveWebParts.Layouts.epmlive.tlwizard" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/stylesheets/buttons.css" />

<style>
    .wizHeader {
        font-family: Segoe UI Light,Verdana;
        font-size: 24px;
        padding-left: 5px;
        margin-top: 0px;
        padding-top: 5px;
        margin-bottom: 15px;
        font-weight: normal;
    }


    .wizText {
        margin-top: 0px;
        padding-top: 0px;
        padding-left: 5px;
        font-family: Segoe UI Light,Verdana;
        font-size: 16px;
    }
</style>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<script language="javascript">
    function disableButtons(btn) {
        var parent = btn.parentNode;
        var elem = parent.childNodes;
        for (var i = 0; i < elem.length; i++) {
            if (elem[i].type) {
                elem[i].disabled = 'disabled';
            }
        }
    }

    var tag = parent.document.getElementsByTagName('object');

    for (var i = tag.length - 1; i >= 0; i--)
        tag[i].style.display = 'none';
</script>


    <asp:HiddenField ID="hdnStep" Value="1" runat="server"/>
    <asp:Panel ID="pnlMessage" runat="server" Visible ="false">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="wizText">
                    <asp:Label ID="lblInvalidURL" runat="server" ForeColor="Red">There was an issue configuring Reporting Services. This may be due to an invalid URL in the Central Administration setup<br />
                        for EPM Live. The wizard will finish now but this Setup Wizard will need to be run again once the connection is resolved in<br />Central Administration.
                    </asp:Label>
                </td>
            </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnl1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" heigh="300" width="100%">
            <tr>
                <td>
                    <h2 class="wizHeader">Welcome to EPM Live.</h2>
		    <p class="wizText">                    
			Let's take care of a few things before you get started. Click 'Next' to get started.
                    </p>
                </td>
            </tr>
            <tr>
                <td style="border-top: 1px solid #c9c9c9; background-color:#FEFEFE; padding-top:15px;text-align:right;padding-right:5px;">
                    <asp:Button ID="btnNext1" Text="Next" OnClick="btnNext_Click" runat="server" CssClass="btn" style="border-radius:5px;"/>
                    <asp:Button ID="bntCancel1" Text="Cancel" OnClick="btnCancel_Click" runat="server" Visible="false" CssClass="btn"/>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnl2" runat="server" Visible="false">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <h3 class="wizHeader">Step 1: Reporting Setup</h3>
                    <asp:Label ID="lblReporting" runat="server" ForeColor="Red" Visible="false">You are not running SSRS in SharePoint Integrated Mode, this step will be skipped.<br /></asp:Label>
                    <asp:Label ID="lblNoReporting" runat="server" ForeColor="Red" Visible="false">Your site has not been setup for Reporting, this step will be skipped.<br /></asp:Label>
                    
                    <p class="wizText">                
				Please enter the following information. This information will be used to create a Data Source for this Site Collection's SQL Server Reporting Services Reports. 
		    </p>
		   
                    <asp:HiddenField ID="hdnReportPassword" runat='server' />
                    <asp:HiddenField ID="hdnSaveReportPassword" runat='server' />
                    <table>
                        <tr>
                            <td class="wizText">Server: </td>
                            <td><asp:TextBox ID="txtReportServer" runat="server" Enabled="false" CssClass="ms-input"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="wizText">Database: </td>
                            <td><asp:TextBox ID="txtReportDatabase" runat="server" Enabled="false" CssClass="ms-input"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="wizText">Username: </td>
                            <td><asp:TextBox ID="txtReportUsername" runat="server" CssClass="ms-input"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="wizText">Password: </td>
                            <td><asp:TextBox TextMode="Password" ID="txtReportPassword" runat="server" CssClass="ms-input"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><asp:CheckBox ID="chkWindows" Text="Use as Windows Credentials" runat="server" /></td>
                        </tr>
                    </table>
                    <asp:Label ID="lblReportingError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                    <br /><br />
                </td>
            </tr>
            <tr>
                <td style="border-top: 1px solid #c9c9c9; background-color:#FEFEFE; padding-top:15px;text-align:right;padding-right:5px;">
                    <asp:Button ID="btnBack2" Text="Back" OnClick="btnBack_Click" runat="server" CssClass="btn"/> 
                    <asp:Button ID="btnNext2" Text="Next" OnClick="btnNext_Click" runat="server" CssClass="btn"/> 
                    <asp:Button ID="btnSkip2" Text="Skip" OnClick="btnSkip_Click" runat="server" CssClass="btn"/> 
                    <asp:Button ID="btnCancel2" Text="Cancel" OnClick="btnCancel_Click" runat="server" CssClass="btn" Visible="false"/>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnl3" runat="server" Visible="false">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <h3 class="wizHeader">Step 2: Services Setup</h3>

                    <table>
                        <tr>
                            <td><p style="margin-top:0px;padding-top:0px;padding-left:5px;font-family:Segoe UI Light,Verdana;font-size:16px;margin-bottom:0px;">Notifications Service Run Time:</p></td>
                            <td style="text-align:right;padding-right:15px;">
                                <asp:DropDownList ID="ddlNotificationRunTime" runat="server">
                                <asp:ListItem Enabled ="true" Selected ="true" Value ="-1" Text ="Disabled"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="0" Text ="12:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="1" Text ="1:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="2" Text ="2:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="3" Text ="3:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="4" Text ="4:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="5" Text ="5:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="6" Text ="6:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="7" Text ="7:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="8" Text ="8:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="9" Text ="9:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="10" Text ="10:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="11" Text ="11:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="12" Text ="12:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="13" Text ="1:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="14" Text ="2:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="15" Text ="3:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="16" Text ="4:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="17" Text ="5:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="18" Text ="6:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="19" Text ="7:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="20" Text ="8:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="21" Text ="9:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="22" Text ="10:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="23" Text ="11:00 PM"></asp:ListItem>               
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
				<p class="wizText">
				This service will run daily at the time you specify and send email notifications based on the settings configured within the Notification Settings section of Site Settings.
				</p></td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td><p style="margin-top:0px;padding-top:0px;padding-left:5px;font-family:Segoe UI Light,Verdana;font-size:16px;margin-bottom:0px;">Reporting Refresh Run Time:</p></td>
                            <td style="text-align:right;padding-right:15px;">
                                <asp:DropDownList ID="ddlReportingRefresh" runat="server">
                                <asp:ListItem Enabled ="true" Selected ="true" Value ="-1" Text ="Disabled"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="0" Text ="12:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="1" Text ="1:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="2" Text ="2:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="3" Text ="3:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="4" Text ="4:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="5" Text ="5:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="6" Text ="6:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="7" Text ="7:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="8" Text ="8:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="9" Text ="9:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="10" Text ="10:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="11" Text ="11:00 AM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="12" Text ="12:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="13" Text ="1:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="14" Text ="2:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="15" Text ="3:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="16" Text ="4:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="17" Text ="5:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="18" Text ="6:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="19" Text ="7:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="20" Text ="8:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="21" Text ="9:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="22" Text ="10:00 PM"></asp:ListItem>
                                <asp:ListItem Enabled ="true" Selected ="false" Value ="23" Text ="11:00 PM"></asp:ListItem>               
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
				<p class="wizText">
				This service will run daily at the time you specify and refresh your reporting data. This includes timesheets, portfolio aggregation, security, and old data clean out.
				</p></td>
                        </tr>
                    </table>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="border-top: 1px solid #c9c9c9; background-color:#FEFEFE; padding-top:15px;padding-right:5px;text-align:right">
                    <asp:Button ID="Button1" Text="Back" OnClick="btnBack_Click" runat="server" CssClass="btn"/> 
                    <asp:Button ID="Button2" Text="Next" OnClick="btnNext_Click" runat="server" CssClass="btn"/> 
                    <asp:Button ID="Button3" Text="Cancel" OnClick="btnCancel_Click" runat="server" CssClass="btn" Visible="false"/>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlDone" runat="server" Visible="false">
        <link rel="stylesheet" href="modal/modal.css" type="text/css" /> 
        <script type="text/javascript" src="modal/modal.js"></script>

        <div id="dlgLoading" class="dialog">
            <table width="100%">
                <tr>
                    <td align="center" class="ms-sectionheader">
                        <img src="../images/GEARS_ANv4.GIF" style="vertical-align: middle;"/><br />
                        <H3 class="ms-standardheader" id="dlgNormalText">Setting Up Site...</h3>
                    </td>
                </tr>
                    
            </table>
        </div> 

        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="padding-bottom:17px;">
                    <h2 class="wizHeader">The setup wizard is complete.</h2>
                    <p class="wizText">
                    Click the Finish button to complete the setup wizard and then be directed to your Home page.
                    </p>
                </td>
            </tr>
            <tr>
                <td style="border-top: 1px solid #c9c9c9; background-color:#FEFEFE; padding-top:15px;padding-right:5px;text-align:right;">
                    <asp:Button ID="btnBack3" Text="Back" OnClick="btnBack_Click" runat="server" CssClass="btn"/> 
                    <asp:Button ID="btnFinish" Text="Finish" OnClick="btnNext_Click" runat="server" CssClass="btn" OnClientClick="showprocessing(); return true;"/> 
                    <asp:Button ID="btnCancel3" Text="Cancel" OnClick="btnCancel_Click" runat="server" CssClass="btn" Visible="false"/>
                </td>
            </tr>
        </table>

        <script>
            initmb();

            function showprocessing() {
                sm("dlgLoading", 130, 50);
            }
        </script>
    </asp:Panel>
    <asp:Panel ID="pnlProcessing" runat="server" Visible="false">
        Redirecting to configuration steps...
    </asp:Panel>




</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
EPM Live Setup Wizard
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
EPM Live Setup Wizard
</asp:Content>
