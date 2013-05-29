<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetupListMapping.aspx.cs" Inherits="EPMLiveReportsAdmin.Layouts.EPMLive.SetupListMapping" DynamicMasterPageFile="~masterurl/default.master" %>

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" Src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" Src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register TagPrefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>




<asp:Content ID="Content4" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    EPM Live Reporting
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    Map List to Database
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderPageDescription" runat="server">
    Use this section to set-up a list for database reporting.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <script language="javascript" type="text/javascript">
        function SelectAll() 
        {
            var x = '<%=cblChkAll.ClientID %>';
            var y = '<%= cblFields.ClientID %>';
            var w = document.getElementById(x);
            var z = document.getElementById(y);

            var chkAllTable = z.childNodes[1];
            var fieldTable = w.childNodes[1];
            var allChecked = fieldTable.childNodes[0].childNodes[1].childNodes[0].checked;

            for (var i = 0; i < chkAllTable.childNodes.length - 1; i++) 
            {
                
                var listControl = chkAllTable.childNodes[i].childNodes[1].childNodes[0].childNodes[0];
                
                if (allChecked == true) 
                {
                    listControl.checked = true;
                }
                else if(listControl.disabled == false)
                {
                    listControl.checked = false;
                }
            }

            if (allChecked == false) 
            {
                fieldTable.childNodes[0].childNodes[2].childNodes[0].innerText = "Check All";
            }

            if (allChecked == true) 
            {
                fieldTable.childNodes[0].childNodes[2].childNodes[0].innerHTML = "Uncheck All";
            }


        }
    </script>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3"><tr><td class="ms-viewlsts" colspan="2"><h3 class="ms-standardheader">List Mapping Configuration</h3></td></tr></table></td></tr>
        
        <asp:Panel ID="pnlListSelect" runat="server">
        <wssuc:InputFormSection ID="InputFormSection1" Title="List" Description="" runat="server">
            <template_description>
                Select a list to map to a database table.
            </template_description>
            <template_inputformcontrols>
                <wssuc:InputFormControl ID="InputFormControl1" LabelText="" runat="server" >
                     <Template_Control>
                        <asp:DropDownList ID="ddlLists" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLists_SelectedIndexChanged" CssClass="ms-input" ></asp:DropDownList>
                     </Template_Control>
                </wssuc:InputFormControl>
            </template_inputformcontrols>
        </wssuc:InputFormSection>
        </asp:Panel>
        
        <wssuc:InputFormSection ID="InputFormSection2" Title="Work List" Description="" runat="server">
            <template_description>
                Indicate whether this mapping will participate in resource reporting.
            </template_description>
            <template_inputformcontrols>
                <wssuc:InputFormControl ID="InputFormControl2" LabelText="" runat="server" >
                     <Template_Control>
                        <SharePoint:InputFormCheckBox ID="chkResource" runat="server" Text="Resource List" Width="100px" CssClass="ms-authoringcontrols"></SharePoint:InputFormCheckBox>
                     </Template_Control>
                </wssuc:InputFormControl>
            </template_inputformcontrols>
        </wssuc:InputFormSection>
        
        <wssuc:InputFormSection ID="InputFormSection3" Title="List Fields" Description="" runat="server">
            <template_description>
                <p>Select specific fields to map. </p>
                <p id ="pDescription1" runat="server">If you would like this list to be available for Resource List reporting, you must select all the bolded fields.</p>
                <p id ="pDescription2" runat="server">Certain fields have been locked to maintain this list's compatibility with Resource List reporting. You can unlock these fields on the List Mappings page.</p>
            </template_description>
            <template_inputformcontrols>
                    <wssawc:InputFormCheckBoxList ID="cblChkAll" runat="server" CssClass="ms-authoringcontrols">
                      <asp:ListItem Text="Check All" Value="all" onclick="SelectAll()"></asp:ListItem>
                    </wssawc:InputFormCheckBoxList>
                    <br />
                    <wssawc:InputFormCheckBoxList ID="cblFields" runat="server" CssClass="ms-authoringcontrols" ></wssawc:InputFormCheckBoxList>
            </template_inputformcontrols>
        </wssuc:InputFormSection>
        
        <wssuc:ButtonSection ID="ButtonSection1" runat="server" ShowStandardCancelButton="false">
            <template_buttons>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                    <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Submit_Click" Text="Save Settings" id="Button1" accesskey="" Width="150"/>
                    <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Cancel_Click" Text="Cancel" id="btnCancel" accesskey="" Width="150"/>
                </asp:PlaceHolder>
            </template_buttons>
        </wssuc:ButtonSection>
        
        <wssawc:FormDigest ID="FormDigest1" runat="server" />
        
    </table>

<asp:CheckBoxList ID="cblAutomatic" runat="server" Visible="false"></asp:CheckBoxList>
<asp:CheckBoxList ID="cblResources" runat="server" Visible="false"></asp:CheckBoxList>
</asp:Content>
