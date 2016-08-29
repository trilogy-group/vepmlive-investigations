<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="workplannerconfig.aspx.cs" Inherits="EPMLiveWorkPlanner.workplannerconfig" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ID="ccc" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script language="javascript">
        function getWidth() {
            var winW = 640;
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
        function cancelAdd() {
            document.getElementById("Field").style.display = "none";
        }
        function addField() {
            document.getElementById("Field").style.top = 225;
            document.getElementById("Field").style.left = getWidth() / 2 - 125;
            document.getElementById("Field").style.position = "absolute";
            document.getElementById("Field").style.display = "";

            document.getElementById("ctl00_PlaceHolderMain_hdnId").value = "";
            document.getElementById("ctl00_PlaceHolderMain_ddlAddCalculation").value = "";
            document.getElementById("ctl00_PlaceHolderMain_txtAddField").value = "";
            document.getElementById("ctl00_PlaceHolderMain_btnAdd").value = "Add Field";

        }
        function editField(field, calc, id) {
            document.getElementById("Field").style.top = 225;
            document.getElementById("Field").style.left = getWidth() / 2 - 125;
            document.getElementById("Field").style.position = "absolute";
            document.getElementById("Field").style.display = "";

            document.getElementById("ctl00_PlaceHolderMain_hdnId").value = id;
            document.getElementById("ctl00_PlaceHolderMain_ddlAddCalculation").value = calc;
            document.getElementById("ctl00_PlaceHolderMain_txtAddField").value = field;
            document.getElementById("ctl00_PlaceHolderMain_btnAdd").value = "Save Field";
        }
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	Work Planner Settings
</asp:Content>
<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	Work Planner Settings
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to manage how Summary Task fields get calculated when Auto Calculation is turned on in your Work Plan.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
    <asp:Panel ID="pnlAdmin" runat="server" Visible="false" Width="100%">
        Work Planner configuration is being configured at another site.<br /><br />
        <asp:HyperLink Text="Click Here" NavigateUrl="" runat="server" ID="hlAdmin"></asp:HyperLink> to go there now.
    </asp:Panel>
    <asp:Panel ID="pnlFeature" runat="server" Visible="false" Width="100%">
        The work planner configuration list appears to be missing. You may not have the feature activated. Would you like to activate the feature now?
        <br /><br />
        <asp:LinkButton runat="server" ID="lnkButton" OnClick="lnkButton_Click" Text="Activate Now"></asp:LinkButton>
    </asp:Panel>
    <asp:Panel id="pnlMain" runat="server">
        <table class="ms-toolbar" width="100%" cellpadding="3" style="height:10px">
                <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Summary Rollup Field Calculations</h3></td></tr>
        </table>
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" GridLines="None" CellPadding="0" CellSpacing="0">
            <Columns>
                <asp:BoundField DataField="field" HeaderText="Field" HeaderStyle-CssClass="ms-vh2-nofilter" ItemStyle-CssClass="ms-vb2"/>
                <asp:BoundField DataField="calc" HeaderText="Calculation Type" HeaderStyle-CssClass="ms-vh2-nofilter" ItemStyle-CssClass="ms-vb2"/>
                <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="top" HeaderStyle-CssClass="ms-vh2-nofilter" ItemStyle-CssClass="ms-vb2">
                     <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" Text="Edit"></asp:HyperLink>
                     </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="top" HeaderStyle-CssClass="ms-vh2-nofilter" ItemStyle-CssClass="ms-vb2">
                     <ItemTemplate>
                       <asp:LinkButton ID="LinkButton1" 
                         CommandArgument='<%# Eval("item_id") %>' 
                         CommandName="Del" runat="server">
                         Delete</asp:LinkButton>
                     </ItemTemplate>
                     </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="ms-vb2"/>
            <AlternatingRowStyle CssClass="ms-alternating"/>
        </asp:GridView>
        <br />
        
        <table cellpadding="0" cellspacing="0" style="padding-left: 5px" >
			 <tr>
					<td valign=top style="padding-top:5px;" class="ms-descriptiontext" >
					<img src="/_layouts/images/setrect.gif" alt="">&nbsp;
					</td>
					<td nowrap class="ms-descriptiontext" style="padding-top:7px;padding-left: 3px;">
					<a href="Javascript:void(0);" onclick="Javascript:addField();">Add Field</a>
					</td>
			</tr>
		</table>
		<br />

        <div id="Field" style="display:none;">
            <asp:HiddenField ID="hdnId" runat="server" />
            <table border="0" bgcolor="FFFFFF" style="border: solid 1px black " width="250" cellpadding="5" cellspacing="0">
                <tr>
                    <td class="ms-vb2">Field:</td>
                    <td class="ms-vb2"><asp:TextBox ID="txtAddField" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="ms-vb2">Calculation:</td>
                    <td class="ms-vb2">
                        <asp:DropDownList ID="ddlAddCalculation" runat="server">
                            <asp:ListItem Value="Avg" Text="Average"></asp:ListItem>    
                            <asp:ListItem Value="Sum" Text="Sum"></asp:ListItem>    
                            <asp:ListItem Value="Min" Text="Minimum"></asp:ListItem>    
                            <asp:ListItem Value="Max" Text="Maximum"></asp:ListItem>    
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnAdd" runat="server" Text="Add Field" OnClick="btnAdd_Click"></asp:Button> <asp:Button ID="Button1" runat="server" Text="Cancel" OnClientClick="Javascript:cancelAdd()"></asp:Button></td>
                </tr>
            </table>
        </div>

        <table class="ms-toolbar" width="100%" cellpadding="3" style="height:10px">
            <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Additional Settings</h3></td></tr>
        </table>
        <table cellpadding="0" cellspacing="0" width="100%">
                <wssuc:InputFormSection Title="Enable Work Planner"
	                Description=""
	                runat="server">
	                <Template_Description>
	                    Use this option to turn on/off the Work Planner feature.
	                </Template_Description>
	                <Template_InputFormControls>
		                <wssuc:InputFormControl LabelText="" runat="server">
			                 <Template_Control>
			                    <asp:CheckBox ID="chkEnableWP" runat="server" />
			                 </Template_Control>
		                </wssuc:InputFormControl>
	                </Template_InputFormControls>
                </wssuc:InputFormSection>
                
                <wssuc:InputFormSection Title="Enable Resource Pool"
	                Description=""
	                runat="server">
	                <Template_Description>
	                    Use this option to enable/disable the use of the resource pool with work planner.
	                </Template_Description>
	                <Template_InputFormControls>
		                <wssuc:InputFormControl LabelText="" runat="server">
			                 <Template_Control>
			                    <asp:CheckBox ID="chkWPResPool" runat="server" />
			                 </Template_Control>
		                </wssuc:InputFormControl>
	                </Template_InputFormControls>
                </wssuc:InputFormSection>
                
                <wssuc:InputFormSection Title="% Complete Calculation"
                    Description=""
                    runat="server">
                    <Template_Description>
                        Enter the field you would like to use as the % complete calculation field. This
                        field will calculate the weighted % complete for summary tasks.
                    </Template_Description>
                    <Template_InputFormControls>
                        <wssuc:InputFormControl LabelText="Select Calculation Type" runat="server">
                             <Template_Control>
        	                    <asp:TextBox ID="txtPercentComplete" runat="server"></asp:TextBox>
                             </Template_Control>
                        </wssuc:InputFormControl>
                    </Template_InputFormControls>
                </wssuc:InputFormSection>
                    
                <wssuc:InputFormSection Title="Project Center List"
	                Description=""
	                runat="server">
	                <Template_Description>
	                    Use this page to specify the Project Center List.
	                </Template_Description>
	                <Template_InputFormControls>
		                <wssuc:InputFormControl LabelText="" runat="server">
			                 <Template_Control>
			                    <asp:DropDownList ID="ddlProjectCenter" runat="Server">
			                    
			                    </asp:DropDownList>
			                 </Template_Control>
		                </wssuc:InputFormControl>
	                </Template_InputFormControls>
                </wssuc:InputFormSection>
                
                <wssuc:InputFormSection Title="Task Center List"
	                Description=""
	                runat="server">
	                <Template_Description>
	                    Use this page to specify the Task Center List.
	                </Template_Description>
	                <Template_InputFormControls>
		                <wssuc:InputFormControl LabelText="" runat="server">
			                 <Template_Control>
			                    <asp:DropDownList ID="ddlTaskCenter" runat="Server">
			                    
			                    </asp:DropDownList>
			                 </Template_Control>
		                </wssuc:InputFormControl>
	                </Template_InputFormControls>
                </wssuc:InputFormSection>
        </table>
        
        <wssuc:ButtonSection runat="server">
            <Template_Buttons>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server">
	                <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Button1_Click" Text="Save Settings" id="Button2" accesskey="" Width="150"/>
                </asp:PlaceHolder>
            </Template_Buttons>
        </wssuc:ButtonSection>
    </asp:Panel>
</asp:Content>
