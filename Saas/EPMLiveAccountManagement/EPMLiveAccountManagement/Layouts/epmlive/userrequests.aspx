<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userrequests.aspx.cs" Inherits="EPMLiveAccountManagement.Layouts.epmlive.userrequests" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="Account Requests" EncodeMethod='HtmlEncode'/>
</asp:Content>
<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	Account Requests
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to accept user accounts requests
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
        <div class="ms-listdescription">
    	 <table class="ms-descriptiontext" cellspacing="0" border="0">
		<tr>
			<td colspan="2" width="100%">
				<span id="ctl00_PlaceHolderMain_LabelGroupDescription"><asp:Label ID="lblRequest" Text="Accept or Reject each user request and then click the Process button." runat="server"></asp:Label></span>
			</td>
		</tr>
	 </table>
        </div>
        <asp:Panel ID="Panel2" runat="server" Height="50px" Width="100%">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="None" Width="100%" BorderStyle=Solid borderwidth=1px> 
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlProcess" runat="server">
                                <asp:ListItem Text="Pending" Selected></asp:ListItem>
                                <asp:ListItem Text="Accept"></asp:ListItem>
                                <asp:ListItem Text="Reject"></asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="firstName" HeaderText="First Name">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="lastName" HeaderText="Last Name">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="email" HeaderText="E-Mail" >
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="username" HeaderText="username" />
                </Columns>
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="XX-Small"/>
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black"  Font-Size="X-Small"/>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775"  Font-Size="XX-Small"/>
            </asp:GridView>
        <asp:Panel ID="Panel1" runat="server" Height="22px" HorizontalAlign="Right" Width="100%">
            &nbsp;<asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="Process"/>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cancel"/></asp:Panel>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Height="50px" HorizontalAlign="Left" Width="100%" Visible="false">
            <asp:Label ID="Label1" runat="server" Font-Size="X-Small" Text="Label"></asp:Label>
            <asp:Panel ID="Panel4" runat="server" Height="2px" HorizontalAlign="Right" Width="100%">
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Done"/></asp:Panel>
        </asp:Panel>
</asp:Content>
