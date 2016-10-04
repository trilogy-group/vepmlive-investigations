<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getpsproject.aspx.cs" Inherits="EPMLiveEnterprise.getpsproject" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	Edit In Project
</asp:Content>
<asp:Content ID="Content2" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	Edit In Project
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to view the log on projects published using WorkEngine Publisher.
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderId="PlaceHolderMain" runat="server">

<asp:Panel ID="pnlOpenProject" runat="server" Visible="false">
<br />
<br />
<b>Opening Project...</b>
<br />
<br />
    <script language="javascript">

        function openProject() {

            var ActiveXTaskLauncher;

            try {
                ActiveXTaskLauncher = new ActiveXObject("TaskLaunch.TaskLauncher");
            }
            catch (e1) {
                try {
                    ActiveXTaskLauncher = new ActiveXObject("Pjwcutil.ProjOpenFile4");
                }
                catch (e2) {
                    if (showErrorMessages) {
                        WCAlert(errorMessageHashTable['IsMSProjectAvailable'], okExclamation);
                    }
                    ActiveXTaskLauncher = null;
                }
            }

            var ProjectData = ['<%=projectName%>'];

            ActiveXTaskLauncher.BasePath = "";
            ActiveXTaskLauncher.ServerURL = "<%=pwaUrl %>";
            ActiveXTaskLauncher.IsNTRes = window.g_fIsNTLogon != null ? 1 : window.g_fIsNTLogon;
            ActiveXTaskLauncher.ResName = window.g_sUserName != null ? "" : window.g_sUserName;
            ActiveXTaskLauncher.IsOffline = 0;

            var ret = ActiveXTaskLauncher.ProjOpenFile("<>\\<%=projectName%>", ProjectData.length, false);

            if (ret < 0) {
                DisplayOpenProjectError(ret);
            }

            SP.UI.ModalDialog.commonModalDialogClose();
        }

        setTimeout("openProject()", 100);

        function DisplayOpenProjectError(nErr) {
            var const_nPJWEB_E_INCORRECT_PROJECT_PROFILE = (0x8c040030 - 0x100000000);
            var const_nPJWEB_E_UNSUPPORTED_VERSION = (0x8C040043 - 0x100000000);
            var const_nPJWEB_E_UNREGISTERED_SITE = (0x8C04004A - 0x100000000);


            switch (nErr) {
                case const_nPJWEB_E_INCORRECT_PROJECT_PROFILE:
                case const_nPJWEB_E_UNSUPPORTED_VERSION:
                case const_nPJWEB_E_UNREGISTERED_SITE:
                    WCAlert("Your Project Professional is not configured properly", 48);
                    break;

                default:
                    // silently fail
                    break;
            }
        }
    </script>
</asp:Panel>
<asp:Panel ID="pnlNewProject" runat="server" Visible="false">
    The selected project does not exist in Project Server. Please select a template to create a project.<br /><br />
    <b>Choose a Template:</b><br />
    <asp:ListBox cssclass="ms-input" ID="ListBox1" runat="server" Height="110px" Width="240px" SelectionMode="Multiple"></asp:ListBox><br />
    <asp:Button OnClientClick="Javascript:this.disabled=true;" UseSubmitBehavior="false" cssclass="ms-input" ID="Button1" runat="server" Text="Create Project" OnClick="Button1_Click" />
    <input class="ms-input" type="button" value="Cancel" onclick="SP.UI.ModalDialog.commonModalDialogClose();" />

    
</asp:Panel>

<asp:Label ID="lblError" runat="server" Visible=false ForeColor="Red"></asp:Label>

</asp:Content>
