<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 

<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notificationsadmin.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.notificationsadmin" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <link rel="stylesheet" href="modal/modal.css" type="text/css" /> 
    <script type="text/javascript" src="modal/modal.js"></script>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="Manage Notifications" EncodeMethod='HtmlEncode'/>
</asp:Content>

<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	<asp:Label ID="lblTitle" runat="server" Text="Work Engine Notifications"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">

    <script language="javascript" >


        function alluserchange(val) {
            if (val == null)
                return;
            if (val.checked) {
                document.getElementById("ctl00_PlaceHolderMain_InputFormSection6_InputFormControl10_lstSiteUsers").disabled = "disabled";
                document.getElementById("ctl00_PlaceHolderMain_InputFormSection6_InputFormControl10_lstNotificationUsers").disabled = "disabled";
                document.getElementById("ctl00_PlaceHolderMain_InputFormSection6_InputFormControl10_btnAdd").disabled = "disabled";
                document.getElementById("ctl00_PlaceHolderMain_InputFormSection6_InputFormControl10_btnRemove").disabled = "disabled";
            }
            else {
                document.getElementById("ctl00_PlaceHolderMain_InputFormSection6_InputFormControl10_lstSiteUsers").disabled = "";
                document.getElementById("ctl00_PlaceHolderMain_InputFormSection6_InputFormControl10_lstNotificationUsers").disabled = "";
                document.getElementById("ctl00_PlaceHolderMain_InputFormSection6_InputFormControl10_btnAdd").disabled = "";
                document.getElementById("ctl00_PlaceHolderMain_InputFormSection6_InputFormControl10_btnRemove").disabled = "";
            }
        }

        function getWidth() {
            var winW = 800;
            if (parseInt(navigator.appVersion) > 3) {
                if (navigator.appName == "Netscape") {
                    winW = window.innerWidth;
                    //winH = window.innerHeight;
                }
                if (navigator.appName.indexOf("Microsoft") != -1) {
                    winW = document.body.offsetWidth;
                    //winH = document.body.offsetHeight;
                }
            }
            return winW;
        }
        function getScrollTopPos() {
            var winW = 0;
            if (parseInt(navigator.appVersion) > 3) {
                if (navigator.appName == "Netscape") {
                    winW = window.pageXOffset;
                }
                if (navigator.appName.indexOf("Microsoft") != -1) {
                    winW = document.body.scrollTop;
                }
            }
            return winW;
        }
        function cancelAdd() {
            hm("AddEditList");
        }
        function validateData() {
            // takes out the single quotes (') since the edit menu javascript will not work with it
            document.getElementById("txSection").value = document.getElementById("ctl00$PlaceHolderMain$txtAddSection").value;
            document.getElementById("txList").value = document.getElementById("ctl00$PlaceHolderMain$txtAddList").value;
            document.getElementById("txColumns").value = document.getElementById("ctl00$PlaceHolderMain$txtAddColumn").value;
            document.getElementById("txQuery").value = document.getElementById("ctl00$PlaceHolderMain$txtAddQuery").value;

            document.getElementById("ctl00$PlaceHolderMain$txtAddSection").value = document.getElementById("ctl00$PlaceHolderMain$txtAddSection").value.replace(/'/g, "");
            theForm.submit();

        }
        function addNotificationList() {
        
            sm("AddEditList", 400, 350);

            //document.getElementById("AddEditList").style.top = getScrollTopPos() + 100;
            //document.getElementById("AddEditList").style.left = event.screenX;
            //document.getElementById("AddEditList").style.position = "absolute";
            document.getElementById("txType").value = 'add';
            //document.getElementById("AddEditList").style.display = "";
        }
        function editNotificationList(section, rnum) {
            sm("AddEditList", 400, 350);

            //document.getElementById("AddEditList").style.top = getScrollTopPos() + 100;
            //document.getElementById("AddEditList").style.left = event.screenX;
            //document.getElementById("AddEditList").style.position = "absolute";
            document.getElementById("ctl00$PlaceHolderMain$txtAddSection").value = section;
            document.getElementById("ctl00$PlaceHolderMain$txtAddList").value = document.getElementById("ctl00_PlaceHolderMain_gvNotificationLists_ctl0" + rnum + "_txtListNames").value;
            document.getElementById("ctl00$PlaceHolderMain$txtAddColumn").value = document.getElementById("ctl00_PlaceHolderMain_gvNotificationLists_ctl0" + rnum + "_txtColumns").value;
            document.getElementById("ctl00$PlaceHolderMain$txtAddQuery").value = document.getElementById("ctl00_PlaceHolderMain_gvNotificationLists_ctl0" + rnum + "_txtQuery").value;
            document.getElementById("ctl00_PlaceHolderMain_btnAddEdit").value = 'Save Section';
            document.getElementById("txType").value = 'edit';
            //document.getElementById("AddEditList").style.display = "";
        }
        function delOkCancel(section) {
            var bRet;
            bRet = confirm('Are you sure you would like to delete section ' + section + '?');
            if (bRet == true) {
                window.location = 'notificationsadmin.aspx?delete=' + section;
            }
        }
    </script>
    <asp:HiddenField ID="hdnJobGuid" runat="server" />
    
    <asp:Panel ID="pnlTL" runat="server" Visible="false" Width="100%">
        Notifications are configured at the site collection level.<br /><br />
        <asp:HyperLink Text="Click Here" NavigateUrl="" runat="server" ID="hlAdmin"></asp:HyperLink> to go there now.
    </asp:Panel>
    <asp:Label ID="lblNotEnabled" Visible="False" runat="server" Text="The Timer Service Feature has not been activated on this web application. You must activate the feature in Central Admin before the timer is able to run." Font-Bold="true" ForeColor="red"></asp:Label>
    <asp:Panel ID="pnlMain" runat="server" Visible="true" Width="100%">
        <table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
            <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">General Settings</h3></td></tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
	                <asp:Panel ID="pnlGeneralSettings" runat="server">
	                <wssuc:InputFormSection ID="InputFormSection1" Title="Run time:"
		                Description=""
		                runat="server">
		                <Template_Description>
		                    Choose the run time.<br /><br />
		                </Template_Description>
		                <Template_InputFormControls>
			                <wssuc:InputFormControl ID="InputFormControl1" LabelText="Select Time:" runat="server" width="460">
				                 <Template_Control>
		                            <table border="0" width="460">
		                                <tr>
		                                    <td class="ms-authoringcontrols">
                                                <asp:DropDownList ID="ddlRunTime" runat="server">
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
		                            </table>
				                 </Template_Control>
			                </wssuc:InputFormControl>
			                <wssuc:InputFormControl ID="InputFormControl2" LabelText="Status" runat="server">
				                 <Template_Control>
                                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
				                 </Template_Control>
			                </wssuc:InputFormControl>
			                <wssuc:InputFormControl ID="InputFormControl3" LabelText="Last Run" runat="server">
				                 <Template_Control>
                                    <asp:Label ID="lblLastRun" runat="server"></asp:Label>
				                 </Template_Control>
			                </wssuc:InputFormControl>
			                <wssuc:InputFormControl ID="InputFormControl4" LabelText="Log" runat="server">
			                     <Template_Control>
                                    <a href="viewmessages.aspx?type=3">View Log</a>
			                     </Template_Control>
		                    </wssuc:InputFormControl>
		                </Template_InputFormControls>
	                </wssuc:InputFormSection>

	                <wssuc:InputFormSection ID="InputFormSection2" Title="From Email:"
		                Description=""
		                runat="server">
		                <Template_Description>
		                    Enter the email the system will send from.<br />
		                </Template_Description>
		                <Template_InputFormControls>
			                <wssuc:InputFormControl ID="InputFormControl5" LabelText="Enter Valid Email:" runat="server" width="460">
				                 <Template_Control>
		                            <table border="0" width="460">
		                                <tr>
		                                    <td class="ms-authoringcontrols">
                                                <asp:TextBox ID="txtFromEmail" Width="180" runat="server"></asp:TextBox>
		                                    </td>
		                                </tr>
		                            </table>
				                 </Template_Control>
			                </wssuc:InputFormControl>
		                </Template_InputFormControls>
	                </wssuc:InputFormSection>

	                <wssuc:InputFormSection ID="InputFormSection3" Title="Subject:"
		                Description=""
		                runat="server">
		                <Template_Description>
		                    Enter the subject line for the email.<br />
		                </Template_Description>
		                <Template_InputFormControls>
			                <wssuc:InputFormControl ID="InputFormControl6" LabelText="Enter Email Subject:" runat="server" width="460">
				                 <Template_Control>
		                            <table border="0" width="460">
		                                <tr>
		                                    <td class="ms-authoringcontrols">
                                                <asp:TextBox ID="txtEmailSubject" Width="350" runat="server"></asp:TextBox>
		                                    </td>
		                                </tr>
		                            </table>
				                 </Template_Control>
			                </wssuc:InputFormControl>
		                </Template_InputFormControls>
	                </wssuc:InputFormSection>

	                <wssuc:InputFormSection ID="InputFormSection4" Title="Notes:"
		                Description=""
		                runat="server">
		                <Template_Description>
		                    Enter any notes.<br /><br />
		                </Template_Description>
		                <Template_InputFormControls>
			                <wssuc:InputFormControl ID="InputFormControl7" LabelText="Notes:" runat="server" width="460">
				                 <Template_Control>
		                            <table border="0" width="460">
		                                <tr>
		                                    <td class="ms-authoringcontrols" colspan="2" >
                                               <asp:TextBox ID="txtNotes" width="455" Height="50" TextMode="MultiLine" runat="server"></asp:TextBox>
		                                    </td>
		                                </tr>
		                            </table>
				                 </Template_Control>
			                </wssuc:InputFormControl>
		                </Template_InputFormControls>
	                </wssuc:InputFormSection>
	                </asp:Panel>
                </td>
            </tr>
        </table>
        <table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
            <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">User Settings</h3></td></tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
	                <asp:Panel ID="pnlUserSettings" runat="server">
	                <wssuc:InputFormSection ID="InputFormSection5" Title="Notification Lock:"
		                Description=""
		                runat="server">
		                <Template_Description>
		                    If you want to prevent your team members from controlling their own notifications, check the box to the right.
		                </Template_Description>
		                <Template_InputFormControls>
			                <wssuc:InputFormControl ID="InputFormControl8" LabelText="Lock Notifications:" runat="server" width="460">
				                 <Template_Control>
		                            <table border="0" width="460">
		                                <tr>
		                                    <td class="ms-authoringcontrols" colspan="3" >
		                                    <asp:CheckBox ID="chkLockNotify" runat="server" />
		                                    </td>
		                                </tr>
		                            </table>
				                 </Template_Control>
			                </wssuc:InputFormControl>
		                </Template_InputFormControls>
	                </wssuc:InputFormSection>

	                <wssuc:InputFormSection ID="InputFormSection6" Title="Users:"
		                Description=""
		                runat="server">
		                <Template_Description>
		                    To sign users up for notifications, select the users in the left box and click add.
		                </Template_Description>
		                <Template_InputFormControls>
		                    <wssuc:InputFormControl ID="InputFormControl9" LabelText="Send to all users:" runat="server" width="460">
				                 <Template_Control>
				                    <asp:CheckBox runat="server" ID="chkAllUsers" onclick="javascript:alluserchange(this);" />
				                 </Template_Control>
				            </wssuc:InputFormControl>
			                <wssuc:InputFormControl ID="InputFormControl10" LabelText="Select Users:" runat="server" width="460">
				                 <Template_Control>
		                            <table border="0" width="460">
		                                <tr>
		                                    <td class="ms-authoringcontrols">
		                                        Users in site collection:<br />
		                                        <asp:ListBox runat="server" Rows="10" ID="lstSiteUsers" Width="250" SelectionMode="Multiple">
		                                        </asp:ListBox>
		                                    </td>
		                                    <td align="center">
                                                <asp:Button ID="btnAdd" Text="Add &gt;" runat="server" OnClick="btnAdd_Click"/>
                                                <br /><br />
                                                <asp:Button ID="btnRemove" Text="&lt; Remove" runat="server" OnClick="btnRemove_Click"/>
		                                    </td>
		                                    <td class="ms-authoringcontrols">
		                                        Users signed up for notifications:<br />
		                                        <asp:ListBox runat="server" Rows="10" ID="lstNotificationUsers" Width="250" SelectionMode="Multiple">
		                                        </asp:ListBox>
		                                    </td>
		                                </tr>
		                            </table>
				                 </Template_Control>
			                </wssuc:InputFormControl>
		                </Template_InputFormControls>
	                </wssuc:InputFormSection>
	                </asp:Panel>
                </td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:Panel ID="pnlListSettings" runat="server" Visible="true" Width="100%">
                        <table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
                            <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">List Settings</h3></td></tr>
                        </table>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td valign="top" style="padding-left: 7px;padding-top: 4px;padding-bottom: 4px;" class="ms-descriptiontext">
                                    List settings are used to group information together. 
                                </td>
                            </tr>
                            <tr>
                                <td class="ms-gb">
                                    <SharePoint:SPGridView runat="server"
	                                 ID="gvNotificationLists"
	                                 AutoGenerateColumns="false"
	                                 style="width:100%"
	                                 AllowSorting="True"
	                                 AllowPaging="True"
	                                 PageSize="10"
	                                 OnRowDataBound="gvNotificationLists_RowDataBound">
                                    <Columns>
	                                    <SharePoint:SPMenuField HeaderText="Section Name" TextFields="SectionName" ControlStyle-Width="100%" MenuTemplateId="PropertyNameListMenu" TokenNameAndValueFields="NAME=SectionName,RNUM=RNum" ></SharePoint:SPMenuField>
                                        <asp:TemplateField headertext="List Names" HeaderStyle-HorizontalAlign="center" ControlStyle-Width="150px" >            
                                            <ItemTemplate>                
                                                <asp:TextBox id="txtListNames" TextMode="MultiLine" Wrap="true" Width="150px" Style="overflow:hidden" ReadOnly="true" BackColor="Transparent" BorderStyle="None" BorderWidth="0" runat="server" ></asp:TextBox>                
                                            </ItemTemplate>        
                                        </asp:TemplateField>
                                        <asp:TemplateField headertext="Columns" HeaderStyle-HorizontalAlign="center" ControlStyle-Width="250px" >            
                                            <ItemTemplate>                
                                                <asp:TextBox id="txtColumns" TextMode="MultiLine" Wrap="true" Width="250px" Style="overflow:hidden" ReadOnly="true" BackColor="Transparent" BorderStyle="None" BorderWidth="0" runat="server" ></asp:TextBox>                
                                            </ItemTemplate>        
                                        </asp:TemplateField>
                                        <asp:TemplateField headertext="Query" HeaderStyle-HorizontalAlign="center" ControlStyle-Width="100%" >            
                                            <ItemTemplate>                
                                                <asp:TextBox id="txtQuery" TextMode="MultiLine" Wrap="true" Width="100%" Style="overflow:hidden" ReadOnly="true" BackColor="Transparent" BorderStyle="None" BorderWidth="0" runat="server" ></asp:TextBox>                
                                            </ItemTemplate>        
                                        </asp:TemplateField>
	                                 </Columns>
	                                 <AlternatingRowStyle CssClass="ms-alternating" />
	                                 </SharePoint:SPGridView>
                                </td>
                            </tr>
						     <tr>
								    <td nowrap class="ms-descriptiontext" align="left" style="padding-top:7px;padding-left: 3px;">
								    <img src="/_layouts/images/setrect.gif" alt="">&nbsp;
								    <a href="javascript:void(0);" onclick="addNotificationList();">Add Section</a>
								    </td>
						    </tr>
	                        <wssuc:ButtonSection ID="ButtonSection1" runat="server">
		                        <Template_Buttons>
			                        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
			                            <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="btnTest_Click" Text="Run Notifications Now" id="btnTest" accesskey="" Width="150"/><img border="0" alt="" src="/_layouts/images/blank.gif" width="1px" >
				                        <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="btnSave_Click" Text="Save Notifications" id="btnSave" accesskey="" Width="150"/>
			                        </asp:PlaceHolder>
		                        </Template_Buttons>
	                        </wssuc:ButtonSection>
                            <wssawc:FormDigest ID="FormDigest1" runat="server" />
                        </table>
                        <br />
                        
                        <input type="hidden" name="txType" id="txType" value="" />
                        <input type="hidden" name="txSection" id="txSection" value="" />
                        <input type="hidden" name="txList" id="txList" value="" />
                        <input type="hidden" name="txColumns" id="txColumns" value="" />
                        <input type="hidden" name="txQuery" id="txQuery" value="" />

                        <div id="AddEditList" class="dialog">
                            <input type="hidden" name="ctl00$PlaceHolderMain$hdnId" id="ctl00_PlaceHolderMain_hdnId" />
                            <table border="0" bgcolor="FFFFFF" width="390" cellpadding="5" cellspacing="0">
                                <tr>
                                    <td class="ms-vb2">Section Name:</td>
                                    <td class="ms-vb2"><input type="text" name="ctl00$PlaceHolderMain$txtAddSection" size="38" id="ctl00$PlaceHolderMain$txtAddSection" /></td>
                                </tr>
                                <tr>
                                    <td class="ms-vb2">List Name(s):</td>
                                    <td class="ms-vb2"><textarea id="ctl00$PlaceHolderMain$txtAddList" name="ctl00$PlaceHolderMain$txtAddList" rows="4" cols="30" id="ctl00$PlaceHolderMain$txtAddList" ></textarea></td>
                                </tr>
                                <tr>
                                    <td class="ms-vb2">Columns:</td>
                                    <td class="ms-vb2"><textarea name="ctl00$PlaceHolderMain$txtAddColumn" rows="4" cols="30" id="ctl00$PlaceHolderMain$txtAddColumn" ></textarea></td>
                                </tr>
                                <tr>
                                    <td class="ms-vb2">Query:</td>
                                    <td class="ms-vb2"><textarea name="ctl00$PlaceHolderMain$txtAddQuery" rows="6" cols="30" id="ctl00$PlaceHolderMain$txtAddQuery" ></textarea></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td><input type="submit" name="ctl00$PlaceHolderMain$btnAddEdit" value="Add Section(s)" id="ctl00_PlaceHolderMain_btnAddEdit" onclick="Javascript:validateData();" /> <input type="button" name="ctl00$PlaceHolderMain$btnCancel" value="Cancel" onclick="Javascript:return cancelAdd();" id="ctl00_PlaceHolderMain_btnCancel" /></td>
                                </tr>
                            </table>
                        </div>
	                </asp:Panel>
                </td>
            </tr>
        </table>
   </asp:Panel> 
   <script language="javascript">
       alluserchange(document.getElementById("ctl00_PlaceHolderMain_InputFormSection6_InputFormControl9_chkAllUsers"));
       initmb();
   </script>
</asp:Content>