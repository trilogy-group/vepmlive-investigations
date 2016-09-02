<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Properties.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.Integration.Properties" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <script language="javascript">
        function ChangeTimed() {

            var ddl = document.getElementById("<%=ddlTimed.ClientID%>");
            var val = ddl.value;

            if (val != "") {
                document.getElementById("<%=InputFormControl332.ClientID %>_tablerow1").style.display = "";
                document.getElementById("<%=InputFormControl332.ClientID %>_tablerow2").style.display = "";
                document.getElementById("<%=InputFormControl332.ClientID %>_tablerow3").style.display = "";
                document.getElementById("<%=InputFormControl332.ClientID %>_tablerow5").style.display = "";
                document.getElementById("<%=InputFormControl333.ClientID %>_tablerow1").style.display = "";
                document.getElementById("<%=InputFormControl333.ClientID %>_tablerow2").style.display = "";
                document.getElementById("<%=InputFormControl333.ClientID %>_tablerow3").style.display = "";
                document.getElementById("<%=InputFormControl333.ClientID %>_tablerow5").style.display = "";
            }
            else {
                document.getElementById("<%=InputFormControl332.ClientID %>_tablerow1").style.display = "none";
                document.getElementById("<%=InputFormControl332.ClientID %>_tablerow2").style.display = "none";
                document.getElementById("<%=InputFormControl332.ClientID %>_tablerow3").style.display = "none";
                document.getElementById("<%=InputFormControl332.ClientID %>_tablerow5").style.display = "none";
                document.getElementById("<%=InputFormControl333.ClientID %>_tablerow1").style.display = "none";
                document.getElementById("<%=InputFormControl333.ClientID %>_tablerow2").style.display = "none";
                document.getElementById("<%=InputFormControl333.ClientID %>_tablerow3").style.display = "none";
                document.getElementById("<%=InputFormControl333.ClientID %>_tablerow5").style.display = "none";
            }
        }

        function ChangeSchedule() {
            var ddl = document.getElementById("<%=ddlScheduleType.ClientID%>");
            var val = ddl.value;

            if (val == "1") {
                document.getElementById("scheduleMonth").style.display = "none";
                document.getElementById("scheduleDaily").style.display = "none";
                document.getElementById("<%=InputFormControl333.ClientID %>_tablerow1").style.display = "none";
            }
            else if (val == "2") {
                document.getElementById("scheduleMonth").style.display = "none";
                document.getElementById("scheduleDaily").style.display = "";
                document.getElementById("<%=InputFormControl333.ClientID %>_tablerow1").style.display = "";
            }
            else if (val == "3") {
                document.getElementById("scheduleMonth").style.display = "";
                document.getElementById("scheduleDaily").style.display = "none";
                document.getElementById("<%=InputFormControl333.ClientID %>_tablerow1").style.display = "";
            }
        }
    </script>
    

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    

    <%=PageHead %>

    <table width="100%">
        <tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
        <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Standard Properties</h3></td></tr>
        </table></td></tr>

        <wssuc:InputFormSection ID="InputFormSection2" Title="Integration Keys"
	        Description=""
	        runat="server">
	        <Template_Description>
	            This key will be used when sending data into the EPM Live integration from an external source.
	        </Template_Description>
	        <Template_InputFormControls>
		        <wssuc:InputFormControl ID="InputFormControl2" LabelText="Integration Key" runat="server">
			            <Template_Control>
			                <asp:Label ID="lblKey" runat="server"></asp:Label>
			            </Template_Control>
		        </wssuc:InputFormControl>
                <wssuc:InputFormControl ID="InputFormControl22" LabelText="Integration ID" runat="server">
			            <Template_Control>
			                <asp:Label ID="lblID" runat="server"></asp:Label>
			            </Template_Control>
		        </wssuc:InputFormControl>
                <wssuc:InputFormControl ID="InputFormControl222" LabelText="Integration URL" runat="server">
			            <Template_Control>
			                <asp:Label ID="lblURL" runat="server"></asp:Label>
			            </Template_Control>
		        </wssuc:InputFormControl>
	        </Template_InputFormControls>
        </wssuc:InputFormSection>

        <wssuc:InputFormSection ID="InputFormSection3" Title="Live Integration"
	        Description=""
	        runat="server">
	        <Template_Description>
	            Specify how you would like data to flow.<br /><br />
                Live Outgoing - This will send data out to the integrated item on save of a SharePoint item<br />
                Live Incoming - This will allow an external integrated item to send data into SharePoint<br />

	        </Template_Description>
	        <Template_InputFormControls>
		        <wssuc:InputFormControl ID="InputFormControl3" LabelText="" runat="server">
			            <Template_Control>
			                <asp:CheckBox ID="chkLout" runat="server" Text="Live Outgoing" />
			            </Template_Control>
		        </wssuc:InputFormControl>
                <wssuc:InputFormControl ID="InputFormControl4" LabelText="" runat="server">
			            <Template_Control>
			                <asp:CheckBox ID="chkLin" runat="server" Text="Live Incoming" />
			            </Template_Control>
		        </wssuc:InputFormControl>
	        </Template_InputFormControls>
        </wssuc:InputFormSection>

        <wssuc:InputFormSection ID="InputFormSection33" Title="Timed Integrations"
	        Description=""
	        runat="server">
	        <Template_Description>
	            Enable this option to allow data synchronization at timed intervals.<br /><br />
                Timed Outgoing - This will send data out the integrated items on a timed basis<br />
                Timed Incoming - This will bring data in from the integrated items on a timed basis<br /><br />
	        </Template_Description>
	        <Template_InputFormControls>
		        <wssuc:InputFormControl ID="InputFormControl331" LabelText="Timed Direction" runat="server">
			        <Template_Control>
			            <asp:DropDownList ID="ddlTimed" runat="server">
                            <asp:ListItem Text="Disabled" Value=""></asp:ListItem>
                            <asp:ListItem Text="Outgoing" Value="out"></asp:ListItem>
                            <asp:ListItem Text="Incoming" Value="in"></asp:ListItem>
                        </asp:DropDownList>
			        </Template_Control>
		        </wssuc:InputFormControl>
                <wssuc:InputFormControl ID="InputFormControl332" LabelText="Schedule Type" runat="server">
                    <Template_Control>
                        <asp:DropDownList ID="ddlScheduleType" runat="server">
                            <asp:ListItem Text="Monthly" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Daily" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Hourly" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </Template_Control>
                </wssuc:InputFormControl>
                <wssuc:InputFormControl ID="InputFormControl333" LabelText="Schedule" runat="server">
                    <Template_Control>

                        <div id="scheduleMonth">
                            Day Of Month: <asp:DropDownList ID="ddlDayOfMonth" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div id="scheduleDaily">
                            Hour: <asp:DropDownList ID="ddlHour" runat="server">

                                </asp:DropDownList>
                                <br /><br />
                            Day Of Week: <asp:CheckBoxList ID="chkDayOfWeek" runat="server" RepeatLayout="Table">
                                <asp:ListItem Text="Sunday" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Monday" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Tuesday" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Wednesday" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Thursday" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Friday" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Saturday" Value="6"></asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                        
                    </Template_Control>
                </wssuc:InputFormControl>
	        </Template_InputFormControls>
        </wssuc:InputFormSection>

        <wssuc:InputFormSection ID="InputFormSectionDelete" Title="Deletion"
	        Description=""
	        runat="server">
	        <Template_Description>
	            Use these settings do decide whether the integration can delete items from your list or from the integration source.
	        </Template_Description>
	        <Template_InputFormControls>
		        <wssuc:InputFormControl ID="InputFormControlDelete1" LabelText="" runat="server">
			            <Template_Control>
			                <asp:CheckBox ID="chkDeleteList" runat="server" Text="Allow Deletion from List" />
			            </Template_Control>
		        </wssuc:InputFormControl>
                <wssuc:InputFormControl ID="InputFormControlDelete2" LabelText="" runat="server">
			            <Template_Control>
			                <asp:CheckBox ID="chkDeleteInt" runat="server" Text="Allow Deletion from Integration Source" />
			            </Template_Control>
		        </wssuc:InputFormControl>
	        </Template_InputFormControls>
        </wssuc:InputFormSection>

        <wssuc:InputFormSection ID="InputFormSectionAdd" Title="Addition"
	        Description=""
	        runat="server">
	        <Template_Description>
	            Use these settings do decide whether the integration can add items to your list or to the integration source.
	        </Template_Description>
	        <Template_InputFormControls>
		        <wssuc:InputFormControl ID="InputFormControlAdd1" LabelText="" runat="server">
			            <Template_Control>
			                <asp:CheckBox ID="chkAddList" runat="server" Text="Allow Adding to List" />
			            </Template_Control>
		        </wssuc:InputFormControl>
                <wssuc:InputFormControl ID="InputFormControlAdd2" LabelText="" runat="server">
			            <Template_Control>
			                <asp:CheckBox ID="chkAddInt" runat="server" Text="Allow Adding to Integration Source" />
			            </Template_Control>
		        </wssuc:InputFormControl>
	        </Template_InputFormControls>
        </wssuc:InputFormSection>


        <tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
        <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Custom Properties</h3></td></tr>
        </table></td></tr>
    </table>
    <asp:Panel ID="lblMain" runat="server">
        <table width="100%">
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


    <script language="javascript">
        ChangeTimed();
        ChangeSchedule();
    </script>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Integration Properties
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Integration Properties
</asp:Content>
