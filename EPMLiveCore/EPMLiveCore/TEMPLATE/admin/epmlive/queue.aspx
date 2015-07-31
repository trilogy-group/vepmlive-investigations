<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveCore.adminqueue" MasterPageFile="~/_admin/admin.master"%> 

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	WorkEngine Queue
</asp:Content>
<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	WorkEngine Queue
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to manage your WorkEngine Queue.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">


<table border="0" cellpadding="0" cellspacing="0" width="100%">

<tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
<tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Queue Settings</h3></td></tr>
</table></td></tr>

<tr>
    <td colspan="2"><font size="-2">Note: After making these changes you must restart the EPM Live Timer Service on each server.<br /></font></td>
</tr>
<wssuc:InputFormSection Title="Polling Interval"
    Description=""
    runat="server">
    <Template_Description>
        This specifies how often the queue attempts to retrieve items awaiting the queue.
    </Template_Description>
    <Template_InputFormControls>
        <wssuc:InputFormControl LabelText="Interval (Seconds)" runat="server">
             <Template_Control>
                <asp:TextBox ID="txtInterval" runat="server" ></asp:TextBox>
             </Template_Control>
        </wssuc:InputFormControl>
    </Template_InputFormControls>
</wssuc:InputFormSection>
<wssuc:InputFormSection Title="Thread Count"
    Description=""
    runat="server">
    <Template_Description>
        This specifies the number of concurrent threads the queueing system will run.
    </Template_Description>
    <Template_InputFormControls>
        <wssuc:InputFormControl LabelText="Threads" runat="server">
             <Template_Control>
                <asp:TextBox ID="txtThreads" runat="server" ></asp:TextBox>
             </Template_Control>
        </wssuc:InputFormControl>
    </Template_InputFormControls>
</wssuc:InputFormSection>

<wssuc:InputFormSection Title="Security Thread Count"
    Description=""
    runat="server">
    <Template_Description>
        This specifies the number of concurrent security threads the queueing system will run.
    </Template_Description>
    <Template_InputFormControls>
        <wssuc:InputFormControl LabelText="Security Threads" runat="server">
             <Template_Control>
                <asp:TextBox ID="txtSecurityThreads" runat="server" ></asp:TextBox>
             </Template_Control>
        </wssuc:InputFormControl>
    </Template_InputFormControls>
</wssuc:InputFormSection>

<wssuc:ButtonSection runat="server">
    <Template_Buttons>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
            <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Button1_Click" Text="Save" id="Button1" accesskey="" Width="150"/>
        </asp:PlaceHolder>
    </Template_Buttons>
</wssuc:ButtonSection>



<tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
<tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Current Queue Status</h3></td></tr>
</table></td></tr>

	<wssuc:InputFormSection Title="Web Application"
		Description=""
		runat="server">
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="" runat="server" width="100%">
				 <Template_Control>
				    <SharePoint:WebApplicationSelector ID="WebApplicationSelector1" runat="server" AllowChange="true" OnContextChange="WebApplicationSelector1_ContextChange"    />
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>

	</wssuc:InputFormSection>
</table>

<b>Queue Length: </b><asp:Label ID="lblLength" runat="server" Text=""></asp:Label><br /><br />

<b>Average Queue Wait: </b><asp:Label ID="lblWait" runat="server" Text=""></asp:Label><br />
<b>Maximum Queue Wait: </b><asp:Label ID="lblMaxQueue" runat="server" Text=""></asp:Label><br />
<b>Average Job Time: </b><asp:Label ID="lblJobTime" runat="server" Text=""></asp:Label><br />
<b>Maximum Job Time: </b><asp:Label ID="lblMaxJob" runat="server" Text=""></asp:Label><br /><br />

<b>Total Jobs Last 24 hours: </b><asp:Label ID="lblTotalJobs" runat="server" Text=""></asp:Label><br />

    <SharePoint:SPGridView runat="server"
	 ID="GvItems"
	 AutoGenerateColumns="false"
	 style="width:600px" OnRowDataBound="GvItems_RowDataBound">
    <Columns>
	    <SharePoint:SPMenuField HeaderText="Job Name" TextFields="jobname" MenuTemplateId="PropertyNameListMenu" TokenNameAndValueFields="NAME=timerjobuid,SITE=siteguid"  ></SharePoint:SPMenuField>
	    <SharePoint:SPBoundField HeaderText="Status" DataField="status"></SharePoint:SPBoundField>
	    <SharePoint:SPBoundField HeaderText="Run Length (s)" DataField="runtime"></SharePoint:SPBoundField>
	    <SharePoint:SPBoundField HeaderText="Finished" DataField="dtfinished"></SharePoint:SPBoundField>
	 </Columns>
	 <AlternatingRowStyle CssClass="ms-alternating" />
	 </SharePoint:SPGridView>
    <br />
</asp:Content>