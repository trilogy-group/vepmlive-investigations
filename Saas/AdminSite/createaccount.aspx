<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="createaccount.aspx.cs" Inherits="AdminSite.createaccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
<h3>Create Account</h3>
    <asp:Panel ID="pnlProcess" runat="server" Visible="false">
        <asp:Label id="lblProcess" runat="server"></asp:Label>
    </asp:Panel>
   
    <asp:Panel ID="pnlInfo" runat="Server" Visible="False">
        <b>Verify the information and Submit.</b>
        <asp:HiddenField ID="hdnAccountId" runat="server" />
        <table border="0" cellpadding="1" cellspacing="2" style="margin: 10px">
            <tr>
                <td width="100" bgcolor="#c9c9c9">First Name:</td>
                <td><asp:Label ID="lblFirstName" runat="server" /></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Last Name:</td>
                <td><asp:Label ID="lblLastName" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">E-Mail:</td>
                <td><asp:Label ID="lblEmail" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Company:</td>
                <td><asp:Label ID="lblCompany" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Department:</td>
                <td><asp:Label ID="lblDepartment" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Title:</td>
                <td><asp:Label ID="lblTitle" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Phone:</td>
                <td><asp:Label ID="lblPhone" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Address1:</td>
                <td><asp:Label ID="lblAddress1" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Address2:</td>
                <td><asp:Label ID="lblAddress2" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">City:</td>
                <td><asp:Label ID="lblCity" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">State:</td>
                <td><asp:Label ID="lblState" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Zip:</td>
                <td><asp:Label ID="lblZip" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Country:</td>
                <td><asp:Label ID="lblCountry" runat="server"></asp:Label></td>
            </tr>
<tr>
                <td width="100" bgcolor="#c9c9c9">Requested Version:</td>
                <td>
<asp:DropDownList ID="ddlVersion" runat="server" CssClass="input textnopad">
                <asp:ListItem value="2007">WorkEngine 2007</asp:ListItem>
                <asp:ListItem Value="2010" Selected="True">WorkEngine 2010</asp:ListItem>
            </asp:DropDownList>
		</td>
            </tr>
            <tr>
                <td colspan="2"><br /><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="searchbutton"/> 
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="searchbutton"/> </td>
            </tr>
        </table>
    </asp:Panel>
   
    <asp:Panel ID="pnlSearch" runat="server">
        Search For CRM Account: 
        <asp:TextBox ID="txtSearch" runat="server" class="searchfield"></asp:TextBox> 
        <asp:Button ID="Button1" runat="server" Text="Search" class="searchbutton" OnClick="Button1_Click" />
        <br /><br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" OnRowCommand="GridView1_RowCommand">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Name" >
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="contact" HeaderText="Primary Contact" >
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="View">
                    <ItemTemplate>
                       <asp:LinkButton ID="LinkButton1" 
                         CommandArgument='<%# Eval("account_id") %>'  Enabled='<%# Eval("enabled") %>'
                         CommandName="use" runat="server">
                         <%# Eval("use") %></asp:LinkButton>
                     </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
    
</asp:Content>
