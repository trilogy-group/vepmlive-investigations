<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" Namespace="Microsoft.SharePoint.WebControls" Tagprefix="SharePoint" %>
<%@ Register Src="~/_controltemplates/InputFormControl.ascx" TagName="InputFormControl" TagPrefix="wssuc" %>
<%@ Register src="~/_controltemplates/InputFormSection.ascx" TagName="InputFormSection" TagPrefix="wssuc" %>
<%@ Register src="~/_controltemplates/ButtonSection.ascx" TagName="ButtonSection" TagPrefix="wssuc" %>
<%@ Page AutoEventWireup="true" CodeBehind="myworksettings.aspx.cs" DynamicMasterPageFile="~masterurl/default.master" Inherits="EPMLiveCore.myworksettings" Language="C#" %>
<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <style type="text/css">
        .duefilter {
            margin: 3px 5px;
            margin-right: 0;
        }
    </style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <asp:Panel ID="pnlAdmin" runat="server" Visible="false" Width="100%"> My Work settings are being configured at another site.<br />
        <br />
        <asp:HyperLink Text="Click Here" NavigateUrl="" runat="server" ID="hlAdmin"></asp:HyperLink>
        to go there now. </asp:Panel>
    <asp:Panel ID="pnlMyWorkList" runat="server" Visible="false" Width="100%">Could not find the "My Work" list at the config level. It is a required list for "My Work WebPart" to function properly.</asp:Panel>
    <asp:Panel ID="pnlMain" runat="server" Visible="true" Width="100%">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <asp:Panel ID="pnlMyWorkSettings" runat="server">
                <tr>
                    <td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height: 20px">
                                        <tr>
                                            <td class="ms-linksectionheader" colspan="2"><h3 class="ms-standardheader">Work Settings</h3></td>
                                        </tr>
                                    </table></td>
                </tr>
                <wssuc:InputFormSection ID="ifsAllWorkListSettings" Title="List Settings" runat="server">
                    <Template_Description>Select which Lists will be included in the My Work results.  All Lists based off the EPM Live Work List Definition are available for inclusion/exclusion.</Template_Description>
                    <Template_InputFormControls>
          
                        <wssuc:InputFormControl ID="ifcAMyWorkLists" LabelText="My Work lists" runat="server">
                            <Template_Control>
                                <table width="460">
                                    <tr>
                                        <td class="ms-authoringcontrols">Included Lists:<br />
                                            <asp:ListBox ID="lstIncludedMyWorkLists" Rows="15" runat="server" SelectionMode="Multiple" Width="180" onchange="showListDetails(this)"> </asp:ListBox></td>
                                        <td align="center"><asp:Button ID="btnExcludeList" runat="server" Text="Exclude &gt;" OnClick="btnExcludeList_OnClick" />
                                            <br />
                                            <br />
                                            <asp:Button ID="btnIncludeList" runat="server" Text="&lt; Include" OnClick="btnIncludeList_OnClick" /></td>
                                        <td class="ms-authoringcontrols">Excluded Lists:<br />
                                            <asp:ListBox ID="lstExcludedMyWorkLists" Rows="15" runat="server" SelectionMode="Multiple" Width="180" onchange="showListDetails(this)"> </asp:ListBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3"><div id="listWorkspaceMsg">&nbsp;</div>
                                            <div id="listWorkspaces">&nbsp;</div></td>
                                    </tr>
                                </table>
                            </Template_Control>
                        </wssuc:InputFormControl>
            
                    </Template_InputFormControls>
                </wssuc:InputFormSection>
                <wssuc:InputFormSection ID="ifsAdditionalListSettings" Title="Additional List Settings"
                                        runat="server">
                    <Template_Description>Please enter the List names of any additional Lists to be included in the My Work results.</Template_Description>
                    <Template_InputFormControls>
                        <wssuc:InputFormControl ID="ifcAllWorkLists" LabelText="Add additional lists" runat="server">
                            <Template_Control>
                                <asp:TextBox ID="tbSelectedLists" runat="server" width="450" Rows="5" Wrap="False" TextMode="MultiLine"></asp:TextBox>
                                <br />
                                <br />
                                <asp:LinkButton ID="btnRefreshFields" OnClick="btnRefreshField_OnClick" runat="server">[Refresh Fields]</asp:LinkButton>
                            </Template_Control>
                        </wssuc:InputFormControl>
                    </Template_InputFormControls></wssuc:InputFormSection>
                <wssuc:InputFormSection ID="ifsAllWorkFieldSettings" Title="Field Settings"
                                        runat="server">
                    <Template_Description>The Fields displayed are all available fields based on the Lists included/excluded above.  Select which fields will be available for users to add/remove from their My Work views.</Template_Description>
                    <Template_InputFormControls>
                        <wssuc:InputFormControl ID="ifcAllWorkFields" LabelText="Select Fields" runat="server">
                            <Template_Control>
                                <table width="460">
                                    <tr>
                                        <td class="ms-authoringcontrols">Available Fields:<br />
                                            <asp:ListBox ID="lstAllFields" Rows="15" runat="server" SelectionMode="Multiple" Width="180" onchange="showFieldDetails(this)"> </asp:ListBox></td>
                                        <td align="center"><asp:Button ID="btnAddField" runat="server" Text="Add &gt;" OnClick="btnAddField_OnClick" />
                                            <br />
                                            <br />
                                            <asp:Button ID="btnRemoveField" runat="server" Text="&lt; Remove" OnClick="btnRemoveField_OnClick" /></td>
                                        <td class="ms-authoringcontrols"> Selected Fields:<br />
                                            <asp:ListBox ID="lstSelectedFields" Rows="15" runat="server" SelectionMode="Multiple" Width="180" onchange="showFieldDetails(this)"> </asp:ListBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3"><div id="internalFieldName">&nbsp;</div>
                                            <div id="fieldInLists">&nbsp;</div></td>
                                    </tr>
                                </table>
                            </Template_Control>
                        </wssuc:InputFormControl>
                    </Template_InputFormControls>
                </wssuc:InputFormSection>
                <wssuc:InputFormSection ID="ifsCrossSiteSetting" Title="Cross Site Settings"
                                        runat="server">
                    <Template_Description>Please specify the cross site URL(s) from where you would like to get "My Work" items.</Template_Description>
                    <Template_InputFormControls>
                        <wssuc:InputFormControl ID="ifcCrossSiteSetting" LabelText="Cross Site URL(s)" runat="server">
                            <Template_Control>
                                <asp:TextBox ID="tbCrossSiteUrls" runat="server" Columns="0" Rows="5" Width="450" Wrap="False" TextMode="MultiLine"></asp:TextBox>
                            </Template_Control>
                        </wssuc:InputFormControl>
                    </Template_InputFormControls>
                </wssuc:InputFormSection>
                <wssuc:InputFormSection ID="ifsPerformanceSetting" Title="Performance Settings"
                                        runat="server">
                    <Template_Description>Enabling performance mode will result into a much faster grid loading experience.</Template_Description>
                    <Template_InputFormControls>
                        <wssuc:InputFormControl ID="ifcPerformanceSetting" LabelText="Performance mode" runat="server">
                            <Template_Control>
                                <asp:CheckBox ID="cbPerformanceMode" runat="server" Text="On / Off" Checked="True" />
                            </Template_Control>
                        </wssuc:InputFormControl>
                    </Template_InputFormControls>
                </wssuc:InputFormSection>
                <wssuc:InputFormSection ID="InputFormSection5" Title="Enterprise Fields:"
                                        runat="server">
                    <Template_Description>
                        Add or edit the enterprise fields.<br />
                    </Template_Description>
                    <Template_InputFormControls>
                        <wssuc:InputFormControl ID="InputFormControl11" LabelText="" runat="server">
                            <Template_Control>
                                <table border="0" cellpadding="0" cellspacing="0" width="600">
                                    <tr>
                                        <td class="ms-gb">
                                            <SharePoint:SPGridView runat="server"
                                                                   ID="GvFields"
                                                                   AutoGenerateColumns="false"
                                                                   style="width: 600"
                                                                   AllowSorting="True"
                                                                   AllowPaging="True"
                                                                   DataKeyNames="DisplayName"
                                                                   PageSize="100" OnRowDataBound="GvFields_RowDataBound">
                                                <Columns>
                                                    <SharePoint:SPBoundField DataField="DisplayName" HeaderText="Column (click to edit)" HeaderStyle-Font-Bold="false" AccessibleHeaderText="Display Name" ControlStyle-Width="250" ></SharePoint:SPBoundField>
                                                    <SharePoint:SPBoundField DataField="FieldType" HeaderText="Type" HeaderStyle-Font-Bold="false" ControlStyle-Width="450" ></SharePoint:SPBoundField>
                                                </Columns>
                                                <AlternatingRowStyle CssClass="ms-alternating" />
                                            </SharePoint:SPGridView>
                                        </td>
                                    </tr>
                                </table>
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td nowrap class="ms-descriptiontext" align="left" style="padding-top: 7px; padding-left: 3px;">
                                            <img src="/_layouts/images/setrect.gif" alt="" />&nbsp;
                                            <a href="<%
                                                         Response.Write(SPContext.Current.Web.Url +
                                                                        "/_layouts/fldNew.aspx?source=" +
                                                                        HttpUtility.UrlEncode(
                                                                            HttpContext.Current.Request.
                                                                                RawUrl) + "&List=" +
                                                                        SPContext.Current.Web.Lists["My Work"].ID);
%>">Create column</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td nowrap class="ms-descriptiontext" align="left" style="padding-top: 7px; padding-left: 3px;">
                                            <img src="/_layouts/images/setrect.gif" alt="" />&nbsp;
                                            <a href="<%
                                                         Response.Write(SPContext.Current.Web.Url +
                                                                        "/_layouts/formEdt.aspx?source=" +
                                                                        HttpUtility.UrlEncode(
                                                                            HttpContext.Current.Request.RawUrl) +
                                                                        "&List=" +
                                                                        SPContext.Current.Web.Lists["My Work"].ID);
            %>">Reorder columns</a>
                                        </td>
                                    </tr>
                                </table>
                            </Template_Control>
                        </wssuc:InputFormControl>
                    </Template_InputFormControls>
                </wssuc:InputFormSection>
                <tr>
                    <td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height: 20px">
                                        <tr>
                                            <td class="ms-linksectionheader" colspan="2"><h3 class="ms-standardheader">My Work Grid Settings</h3></td>
                                        </tr>
                                    </table></td>
                </tr>
                <wssuc:InputFormSection ID="ifsMyWorkGridFilterSetting" Title="Filter Settings"
                                        runat="server">
                    <Template_Description>Turn on filters to limit the data retrieved by the grid based on Due Date.</Template_Description>
                    <Template_InputFormControls>
                        <wssuc:InputFormControl ID="ifcMyWorkGridFilterSetting" LabelText="" runat="server">
                            <Template_Control>
                                <div><asp:CheckBox ID="cbDaysAgo" runat="server" Text="Only show work that was due within" onclick="toggleDueDayFilter('ago',this.checked);" /><asp:TextBox runat="server" ID="tbDaysAgo" Width="25" CssClass="duefilter" onchange="this.value = this.value <= 0 ? '' : this.value; updateDayFilterValue('ago', this.value);"/> days ago.</div>
                                <div><asp:CheckBox ID="cbDaysAfter" runat="server" Text="Only show work that is due within" onclick="toggleDueDayFilter('after',this.checked);" /><asp:TextBox runat="server" ID="tbDaysAfter" Width="25" CssClass="duefilter" onchange="this.value = this.value <= 0 ? '' : this.value; updateDayFilterValue('after', this.value);"/> days in the future.</div>
                                <asp:HiddenField runat="server" ID="hfDaysAgo"/><asp:HiddenField runat="server" ID="hfDaysAfter"/>
                            </Template_Control>
                        </wssuc:InputFormControl>
                    </Template_InputFormControls>
                </wssuc:InputFormSection>
                <wssuc:InputFormSection ID="ifsMyWorkGridIndicatorSetting" Title="New Item Icon Setting"
                                        runat="server">
                    <Template_Description>Select the number of days an item is considered “new” in the grid.  A “new” icon will be displayed next to all items considered new based on this setting.</Template_Description>
                    <Template_InputFormControls>
                        <wssuc:InputFormControl ID="ifcMyWorkGridIndicatorSetting" LabelText="" runat="server">
                            <Template_Control>
                                <div><asp:CheckBox ID="cbNewItemIndicator" runat="server" Text="Mark item as new if it was created within" onclick="toggleNewItemIndicator(this.checked);" /><asp:TextBox runat="server" ID="tbNewItemIndicator" Width="25" CssClass="duefilter" onchange="this.value = this.value <= 0 ? '' : this.value; updateNewItemIndicatorValue(this.value);"/> days.</div>
                                <asp:HiddenField runat="server" ID="hfNewItemIndicator"/>
                            </Template_Control>
                        </wssuc:InputFormControl>
                    </Template_InputFormControls>
                </wssuc:InputFormSection>
                <wssuc:ButtonSection ID="ButtonSection" runat="server">
                    <Template_Buttons>
                        <asp:PlaceHolder ID="PlaceHolder" runat="server">
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_OnClick" CssClass="ms-ButtonHeightWidth" />
                            <%--&nbsp;<asp:Button ID="btnReset"
                        runat="server" Text="Reset" OnClick="btnReset_OnClick" CssClass="ms-ButtonHeightWidth" />--%>
                        </asp:PlaceHolder>
                    </Template_Buttons>
                </wssuc:ButtonSection>
            </asp:Panel>
        </table>
        <asp:HiddenField ID="hfFieldLists" runat="server" />
        <asp:HiddenField ID="hfListWorkspaces" runat="server" />
    </asp:Panel>
    <script type="text/javascript">

        var daysAgoId = '<%= tbDaysAgo.ClientID %>';
        var daysAfterId = '<%= tbDaysAfter.ClientID %>';
        var newItemIndicatorId = '<%= tbNewItemIndicator.ClientID %>';
        var hfDaysAgoId = '<%= hfDaysAgo.ClientID %>';
        var hfDaysAfterId = '<%= hfDaysAfter.ClientID %>';
        var hfNewItemIndicatorId = '<%= hfNewItemIndicator.ClientID %>';

        function toggleDueDayFilter(action, value) {
            var element = document.getElementById(daysAgoId);
            
            if (action === 'after') {
                element = document.getElementById(daysAfterId);
            }

            element.disabled = !value;
        }
        
        function updateDayFilterValue(action, value) {
            if (action === 'ago') {
                document.getElementById(hfDaysAgoId).value = value;
            } else {
                document.getElementById(hfDaysAfterId).value = value;
            }
        }
        
        function toggleNewItemIndicator(value) {
            document.getElementById(newItemIndicatorId).disabled = !value;
        }
        
        function updateNewItemIndicatorValue(value) {
            document.getElementById(hfNewItemIndicatorId).value = value;
        }

        function showFieldDetails(listBox) {
            var fieldLists = {<%=FieldLists%>};
            var count = 0;

            for (var i = 0; i < listBox.options.length; i++)
            {
                if (listBox.options[i].selected) count++;

                if (count > 1) break;
            }

            var internalFieldNameDiv = document.getElementById('internalFieldName');
            var fieldInListsDiv = document.getElementById('fieldInLists');

            if (count == 1)
            {
                var field = listBox.options[listBox.options.selectedIndex].value;

                internalFieldNameDiv.innerHTML = 'Internal name: ' + field;
                var fieldInLists = 'In the following lists: ';

                for (var i = 0; i < fieldLists[field].length; i++)
                {
                    fieldInLists += ' ' + fieldLists[field][i] + ',';
                }

                fieldInListsDiv.innerHTML = fieldInLists.substring(0, fieldInLists.length - 1);
            }
            else
            {
                internalFieldNameDiv.innerHTML = '&nbsp;';
                fieldInListsDiv.innerHTML = '&nbsp;';
            }
        }

        function showListDetails(listBox)
        {
            return true;

            var listWorkspaces = { <%=ListWorkspaces%> };
            var count = 0;

            for (var i = 0; i < listBox.options.length; i++)
            {
                if (listBox.options[i].selected) count++;

                if (count > 1) break;
            }

            var msgDiv = document.getElementById('listWorkspaceMsg');
            var workspacesDiv = document.getElementById('listWorkspaces');

            if (count == 1)
            {
                var list = listBox.options[listBox.options.selectedIndex].value;

                msgDiv.innerHTML = 'In the following workspaces:';
                workspacesDiv.innerHTML = '';

                for (var i = 0; i < listWorkspaces[list].length; i++)
                {
                    workspacesDiv.innerHTML += listWorkspaces[list][i] + '<br/>';
                }
            }
            else
            {
                msgDiv.innerHTML = '&nbsp;';
                workspacesDiv.innerHTML = '&nbsp;';
            }
        }

        function newWin(url) {
            window.open(url, '', config = 'height=400,width=700, toolbar=no, menubar=no, scrollbars=no, resizable=yes,location=no, directories=no, status=yes');
        }

        function pageRedir(url) {
            window.location = url;
        }
    </script>
</asp:Content>
<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server"> Work Settings </asp:Content>
<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" > Work Settings </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server"> Use this section to configure the settings for this site. </asp:Content>