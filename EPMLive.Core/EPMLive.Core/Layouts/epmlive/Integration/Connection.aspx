<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Connection.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.Integration.Connection" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <link rel="stylesheet" href="../modal/modal.css" type="text/css" /> 
    <script type="text/javascript" src="../modal/modal.js"></script>

    <script language="javascript">
        function CheckConnection() {
            DisableButtons();
            sm("dlgConnect", 150, 50);
        }
        function Install() {
            DisableButtons();
            sm("dlgInstall", 150, 50);
            
        }

        function DisableButtons() {
            document.getElementById("<%=Button1.ClientID %>").disabled = true;
            if(document.getElementById("<%=Button2.ClientID %>"))
                document.getElementById("<%=Button2.ClientID %>").disabled = true;
        }
    </script>
    
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    

    <%=PageHead %>


    <asp:Panel ID="lblMain" runat="server">
        <table width="100%">
            <wssuc:InputFormSection ID="InputFormSection4" Title="Re-install Integration"
	            Description=""
	            runat="server">
	            <Template_Description>
	                Click this button to re-install the integration on the remote system.
	            </Template_Description>
	            <Template_InputFormControls>
		            <wssuc:InputFormControl ID="InputFormControl4" LabelText="" runat="server">
			                <Template_Control>
			                    <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Button2_Click" Text="Re-Install" id="Button2" accesskey="" Width="150"/>
                                <br />
                                <asp:Label id="lblInstallError" runat="server" ForeColor="red"></asp:Label>
			                </Template_Control>
		            </wssuc:InputFormControl>
	            </Template_InputFormControls>
            </wssuc:InputFormSection>

            <wssuc:ButtonSection ID="ButtonSection1" runat="server">
		        <Template_Buttons>
			        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
				        <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Button1_Click" Text="Save Settings" id="Button1" accesskey="" Width="150"/>
			        </asp:PlaceHolder>
		        </Template_Buttons>
	        </wssuc:ButtonSection>
        </table>
        <asp:Label ID="lblError" runat="server" Color="red"></asp:Label>
    </asp:Panel>

    <div id="dlgConnect" class="dialog">
        <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <img src="../../images/GEARS_ANv4.GIF" style="vertical-align: middle;"/><br />
                    <H3 class="ms-standardheader" id="dlgNormalText">Checking Connection...</h3>
                </td>
            </tr>
                    
        </table>
    </div> 


    <div id="dlgInstall" class="dialog">
        <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <img src="../../images/GEARS_ANv4.GIF" style="vertical-align: middle;"/><br />
                    <H3 class="ms-standardheader" id="H1">Installing Integration...</h3>
                </td>
            </tr>
                    
        </table>
    </div> 

    <script language="javascript">
        initmb();
    </script>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Integration Connection
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Integration Connection
</asp:Content>
