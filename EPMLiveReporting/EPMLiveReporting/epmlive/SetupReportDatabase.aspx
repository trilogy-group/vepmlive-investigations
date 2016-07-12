<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" Src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" Src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetupReportDatabase.aspx.cs" Inherits="EPMLiveReportsAdmin.Layouts.EPMLive.SetupReportDatabase" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Content4" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    EPM Live Reporting
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"    runat="server">
    Map Site to Database
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderPageDescription" runat="server">
    Use this section to set-up reporting for this site.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <script type="text/javascript">
        function toggleSAccount(show) {
            if (show) {
                document.getElementById('<%= trNew3.ClientID %>').style.display = 'block';
                document.getElementById('<%= trNew4.ClientID %>').style.display = 'block';
            } else {
                document.getElementById('<%= trNew3.ClientID %>').style.display = 'none';
                document.getElementById('<%= trNew4.ClientID %>').style.display = 'none';
            }
        }
    </script>

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3"><tr><td class="ms-viewlsts" colspan="2"><h3 class="ms-standardheader">Mapping Configuration</h3></td></tr></table></td></tr>
        
        
        <wssuc:InputFormSection Title="Site Collection" Description="" runat="server">
        
            <template_description>
                Select a site collection to map to a database table.
            </template_description>
            <template_inputformcontrols>
                <wssuc:InputFormControl LabelText="" runat="server" >
                    <Template_Control>
                        <SharePoint:SiteAdministrationSelector runat="server" ID="SiteAdministrationSelector1" CssClass="ms-viewselector" AllowAdministrationWebApplication="false" NoSelectionText="Select Site Collection" AllowChange="true" /> 
                        <asp:Label ID="lblErrorSite" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                    </Template_Control>
                </wssuc:InputFormControl>
            </template_inputformcontrols>
        </wssuc:InputFormSection>
        
        <wssuc:InputFormSection Title="Database Server" Description="" runat="server">
        
            <template_description>
                Enter the server and name of a database on which to create a new report database.
            </template_description>
            <template_inputformcontrols>
                
                <wssuc:InputFormControl LabelText="Database Server" runat="server">
                    <Template_Control>
                        <table>
                            <tr id="trSelect" runat="server"><td class="ms-authoringcontrols" colspan="2">
                                                                 Existing <input type="radio" name="group1" runat="server" id="btnExisting" /> 
                                                                 New      <input type="radio" name="group1" runat="server" id="btnNew" /> 
                                                             </td></tr>
                        
                            <tr id="trNew1" runat="server">
                                <td class="ms-authoringcontrols">Server</td>
                                <td class="ms-authoringcontrols"><asp:TextBox runat="server" ID="txtDatabaseServer" Width="120px"></asp:TextBox></td>
                            </tr>
                        
                                               
                            <tr id="trNew2" runat="server">
                                <td class="ms-authoringcontrols">Database Name</td>
                                <td class="ms-authoringcontrols"><asp:TextBox runat="server" ID="txtDatabaseName" Width="120px"></asp:TextBox></td>
                            </tr>
                            <tr id="tr1" runat="server">
                                <td class="ms-authoringcontrols">Use SQL Account</td>
                                <td class="ms-authoringcontrols" width="200"><asp:CheckBox runat="server" ID="sacccount" onclick="toggleSAccount(this.checked)" /></td>
                            </tr>
                            <tr id="trNew3" runat="server" style="display: none;">
                                <td class="ms-authoringcontrols">User Name</td>
                                <td class="ms-authoringcontrols"><asp:TextBox runat="server" ID="username" Width="120px"></asp:TextBox></td>
                            </tr>
                            <tr id="trNew4" runat="server" style="display: none;">
                                <td class="ms-authoringcontrols">Password</td>
                                <td class="ms-authoringcontrols"><asp:TextBox runat="server" ID="password" TextMode="Password" Width="120px"></asp:TextBox></td>
                            </tr>
                            <tr><td class="ms-authoringcontrols" colspan="2">
                                    <asp:Label ID="lblErrorDatabase" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                </td></tr>
                        </table>
                    </Template_Control>
                </wssuc:InputFormControl>                         
            </template_inputformcontrols>
        </wssuc:InputFormSection>
        
        <wssuc:ButtonSection runat="server">
            <template_buttons>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                    <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="btnSubmit_Click" Text="Create Database" id="btnSubmit" accesskey="" Width="150"/>
                </asp:PlaceHolder>
            </template_buttons>
        </wssuc:ButtonSection>
        
        <SharePoint:FormDigest ID="FormDigest1" runat="server" />

        <asp:TextBox runat="server" ID="txtMessage" CssClass="ms-long" TextMode="MultiLine"
                     Rows="10" Visible="false"></asp:TextBox>
        
    </table>

</asp:Content>