<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" Src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" Src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register TagPrefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adsyncadmin.aspx.cs" Inherits="EPMLiveCore.adsyncadmin" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Content4" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    WorkEngine Active Directory Sync
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
    runat="server">
    Active Directory Synchronization Administration
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderPageDescription" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    <script type="text/ecmascript" language="javascript">

        function AddOption(index) {
            var options = document.getElementById('ctl00_PlaceHolderMain_ctl04_ctl00_lb_options');
            var selections = document.getElementById('ctl00_PlaceHolderMain_ctl04_ctl00_lb_selections');
            var option = document.createElement('option');

            try {
                option.text = options.options[index].text;
                option.value = options.options[index].value;
                options.remove(index);
                selections.add(option, option.value);
                options.selectedIndex = 0;
            }
            catch (e) {

            }
        }

        function RemoveOption(index) {
            var options = document.getElementById('ctl00_PlaceHolderMain_ctl04_ctl00_lb_options');
            var selections = document.getElementById('ctl00_PlaceHolderMain_ctl04_ctl00_lb_selections');
            var option = document.createElement('option');

            try {
                option.text = selections.options[index].text;
                option.value = selections.options[index].value;
                selections.remove(index);
                options.add(option, option.value);
                selections.selectedIndex = 0;
            }
            catch (e) {

            }
        }

        function SaveSelections() {
            var selections = document.getElementById('ctl00_PlaceHolderMain_ctl04_ctl00_lb_selections');
            var hdn = document.getElementById("ctl00_PlaceHolderMain_ctl04_ctl00_selections");
            var i = 0;
            hdn.value = "";
            while (i < selections.length) {
                var option = option = selections.options[i];
                var value = option.text + "|";
                hdn.value = hdn.value + value;
                i++;
            }
        }

        function SelectedIndexChanged(index) {
            var headerLabel = document.getElementById('ctl00_PlaceHolderMain_ctl00_FrequencyOptions_LiteralLabelText');
            var ddlDays = document.getElementById('ctl00_PlaceHolderMain_ctl00_FrequencyOptions_DropDownListDays');
            var cblDayOfWeek = document.getElementById('divDayOfWeek');
            var divDays = document.getElementById('ddlDays');

            if (index == 1) {
                headerLabel.innerHTML = "Day of Month";
                ddlDays.style.visibility = "visible";
                cblDayOfWeek.style.visibility = "hidden";
            }
            else {
                headerLabel.innerHTML = "Day(s) of Week";
                cblDayOfWeek.style.visibility = "visible";
                ddlDays.style.visibility = "hidden";
            }
        }    
    </script>

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="2">
                <table class="ms-toolbar" width="100%" cellpadding="3" style="height:10px">
                    <tr>
                        <td class="ms-linksectionheader" colspan="2">
                            <h3 class="ms-standardheader">
                                <asp:Label ID="Label3" runat="server" Text="DOMAIN: "></asp:Label><asp:Label ID="lbl_domain"
                                    runat="server"></asp:Label></h3>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <asp:Panel ID="pnlListSelect" runat="server">
            <wssuc:InputFormSection Title="Groups to synchronize" Description="" runat="server">
                <template_description>
                Select which Active Directory groups to synchronize with the Resource Pool.
            </template_description>
                <template_inputformcontrols>
                <wssuc:InputFormControl LabelText="" runat="server" >                    
                     <Template_Control>                     
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Active Directory Groups" CssClass="ms-authoringcontrols"></asp:Label><br />
                                    <asp:ListBox id="lb_options" runat="server" Width="200" Height="200">
                                     <asp:ListItem Text="Option1" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="Option2" Value="2"></asp:ListItem>
                                     <asp:ListItem Text="Option3" Value="3"></asp:ListItem>
                                     <asp:ListItem Text="Option4" Value="4"></asp:ListItem>
                                     <asp:ListItem Text="Option5" Value="5"></asp:ListItem>
                                     <asp:ListItem Text="Option6" Value="6"></asp:ListItem>
                                    </asp:ListBox>
                                </td>
                                <td width="50">
                                    <button id="btnAdd" onclick="AddOption(document.getElementById('ctl00_PlaceHolderMain_ctl04_ctl00_lb_options').selectedIndex);return false;"> > </button><br /><br />
                                    <button id="btnRemove" onclick="RemoveOption(document.getElementById('ctl00_PlaceHolderMain_ctl04_ctl00_lb_selections').selectedIndex);return false;"> < </button><br />
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Groups to Sync with Resource Pool" CssClass="ms-authoringcontrols"></asp:Label><br />
                                    <asp:ListBox id="lb_selections" runat="server" Width="200" Height="200"></asp:ListBox>
                                    <asp:HiddenField ID="selections" runat="server" />
                                </td>
                            </tr>                            
                        </table>
                     </Template_Control>
                </wssuc:InputFormControl>
            </template_inputformcontrols>
            </wssuc:InputFormSection>
        </asp:Panel>
        <wssuc:InputFormSection Title="Field Mappings" Description="" runat="server" Id="inputsection_fieldMapping">
            <template_description>
                Select which Active Directory field to map the corresponding Resource Pool field to.
            </template_description>
            <template_inputformcontrols>
                <wssuc:InputFormControl  runat="server" >
                     <Template_Control>
                        <asp:Table runat="server" ID="tbl_fieldMappings">
                            
                        </asp:Table>
                     </Template_Control>
                </wssuc:InputFormControl>
            </template_inputformcontrols>
        </wssuc:InputFormSection>
        <wssuc:InputFormSection Title="Schedule Type" Description="" runat="server">
            <template_description>
		    Choose how often you would like to synchronize your Resource Pool.
		    <br />
		    <br />
		    <br /><br />
		</template_description>
            <template_inputformcontrols>
        <wssuc:InputFormControl runat="server" LabelText="Schedule Type">
				 <Template_Control>
                    <asp:DropDownList ID="DropDownListScheduleType" runat="server" onchange="SelectedIndexChanged(this.selectedIndex)">
                    <asp:ListItem Enabled ="true" Selected ="true" Value ="2" Text ="Daily"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="3" Text ="Monthly"></asp:ListItem>               
                    </asp:DropDownList>
				    <br />
				 </Template_Control>
			</wssuc:InputFormControl>
            
			<wssuc:InputFormControl LabelText="Time" runat="server">
				 <Template_Control>
                    <asp:DropDownList ID="DropDownListTime" runat="server">
                    <asp:ListItem Enabled ="true" Selected ="true" Value ="" Text ="Disabled"></asp:ListItem>
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
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="0" Text ="12:00 AM"></asp:ListItem>
                    </asp:DropDownList>
				    <br />
				 </Template_Control>
			</wssuc:InputFormControl>
			
			<wssuc:InputFormControl LabelText="Last Run" runat="server">
				 <Template_Control>
                    <asp:Label ID="lblLastRun" runat="server"></asp:Label>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="Last Result" runat="server">
				 <Template_Control>
                    <asp:Label ID="lblMessages" runat="server"></asp:Label>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="Log" runat="server">
				 <Template_Control>
                    <a href="viewmessages.aspx?type=8">View Log</a>
				 </Template_Control>
			</wssuc:InputFormControl>
						
			<wssuc:InputFormControl ID="FrequencyOptions" runat="server">
				 <Template_Control>
				 <asp:DropDownList ID="DropDownListDays" runat="server" style="visibility:hidden;">
				    <asp:ListItem Enabled ="true" Selected ="false" Value ="1" Text ="1"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="2" Text ="2"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="3" Text ="3"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="4" Text ="4"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="5" Text ="5"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="6" Text ="6"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="7" Text ="7"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="8" Text ="8"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="9" Text ="9"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="10" Text ="10"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="11" Text ="11"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="12" Text ="12"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="13" Text ="13"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="14" Text ="14"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="15" Text ="15"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="16" Text ="16"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="17" Text ="17"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="18" Text ="18"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="19" Text ="19"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="20" Text ="20"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="21" Text ="21"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="22" Text ="22"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="23" Text ="23"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="24" Text ="24"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="25" Text ="25"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="26" Text ="26"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="27" Text ="27"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="28" Text ="28"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="29" Text ="29"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="30" Text ="30"></asp:ListItem>
                    <asp:ListItem Enabled ="true" Selected ="false" Value ="31" Text ="31"></asp:ListItem>                    
				    </asp:DropDownList>
				 <div id="divDayOfWeek">
				    <asp:CheckBoxList ID="CheckBoxList_days" runat="server" CssClass="ms-vb2">
				        <asp:ListItem Text="Monday" Value="1"></asp:ListItem>
				        <asp:ListItem Text="Tuesday" Value="2"></asp:ListItem>
				        <asp:ListItem Text="Wednesday" Value="3"></asp:ListItem>
				        <asp:ListItem Text="Thursday" Value="4"></asp:ListItem>
				        <asp:ListItem Text="Friday" Value="5"></asp:ListItem>
				        <asp:ListItem Text="Saturday" Value="6"></asp:ListItem>
				        <asp:ListItem Text="Sunday" Value="7"></asp:ListItem>				    
				    </asp:CheckBoxList>
				  </div>
				 </Template_Control>
			</wssuc:InputFormControl>
			</template_inputformcontrols>
        </wssuc:InputFormSection>
        <wssuc:InputFormSection Title="Entity Exclusions" Description="" runat="server">
            <template_description>
		     In this section list entities to be excluded from the Resource Pool synchronization process. List multiple exclusions by a semi-colon (i.e. john smith;jane doe).
		    </template_description>
            <template_inputformcontrols>
            <wssuc:InputFormControl runat="server" LabelText="Entity Exclusions">
				 <Template_Control>
                   <textarea id="txtArea_entityExclusions" runat="server" rows="5" width="200"></textarea>
				 </Template_Control>
			</wssuc:InputFormControl>
			</template_inputformcontrols>
        </wssuc:InputFormSection>
        <wssuc:InputFormSection Title="Delete Resource Pool Members" Description=""
            runat="server">
            <template_description>
		      To "Delete" members from the Resource Pool who are not found in any of the Active Directory groups selected
		      for synchronization check this box. Otherwise they will be disabled in the Resource Pool.
		      </template_description>
            <template_inputformcontrols>
            <wssuc:InputFormControl runat="server" LabelText="Delete Members">
				 <Template_Control>
                  <asp:CheckBox ID="cbDelete" runat="server"></asp:CheckBox>
				 </Template_Control>
			</wssuc:InputFormControl>
			</template_inputformcontrols>
        </wssuc:InputFormSection>
        <wssuc:ButtonSection runat="server">
            <template_buttons>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                    <asp:Button ID="btnRunManually" runat="server" Text="Run Now" OnClick="btnRunManually_Click" CssClass="ms-ButtonHeightWidth" style="width:150px;/>&nbsp;<asp:Button UseSubmitBehavior="false" runat="server" OnClick="Submit_Click" OnClientClick="SaveSelections()" class="ms-ButtonHeightWidth" Text="Save Settings" id="Button1" accesskey="" Width="150"/>
                                       
                </asp:PlaceHolder>
            </template_buttons>
        </wssuc:ButtonSection>
        <wssawc:FormDigest ID="FormDigest1" runat="server" />
    </table>
</asp:Content>

