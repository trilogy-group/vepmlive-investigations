<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="emailmanager.aspx.cs" Inherits="EPMLiveCore.Layouts.EPMLiveCore.emailmanager" DynamicMasterPageFile="~masterurl/default.master"  %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<table>
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
    <asp:HiddenField ID="hdnId" runat="server" />
    <asp:GridView ID="gvEmails" runat="server" OnRowEditing="GridView1_RowEditing" AutoGenerateColumns="false" >
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="emailid"/>
            <asp:BoundField DataField="title" HeaderText="Email Name" />
            <asp:BoundField DataField="subject" HeaderText="Email Subject"/>
            <asp:CommandField HeaderText="Edit" ShowEditButton="True" >
                    <HeaderStyle Width="100px" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                </asp:CommandField>
        </Columns>
    </asp:GridView>

    <asp:Panel ID="pnlEdit" runat="server" Visible="false">

    Subject: <asp:TextBox ID ="txtSubject" runat="server" Columns="100"></asp:TextBox><br />
    Body:<br />
     <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" Rows="30" Columns="100">
    
    </asp:TextBox><br />
    <asp:Button ID="btnSubmit" runat ="server" Text="Save" OnClick="btnSubmit_Click" />&nbsp;
    <asp:Button ID="btnCancel" runat ="server" Text="Cancel" OnClick="btnCancel_Click" />
    <a href="#" onclick="preview()">[Preview]</a>
    <script language="javascript">

        function preview() {
            window.open('preview.aspx', '', config = 'toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, directories=no, status=no');
        }

    </script>

    </asp:Panel>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Email Templates
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
    Email Templates
</asp:Content>
