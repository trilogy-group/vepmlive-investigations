<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="oldsignups.aspx.cs" Inherits="AdminSite.oldsignups" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
<asp:Label runat="server" ID="lblStatus" Font-Bold="true"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Width="100%" OnRowCommand="GridView1_RowCommand" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
        <FooterStyle BackColor="#CCCC99" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="dtrequested" HeaderText="Date Requested" >
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="name" HeaderText="Name" >
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="company" HeaderText="Company" >
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="requestedVersion" HeaderText="Version" >
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:TemplateField>
             <ItemTemplate>
               <asp:LinkButton ID="LinkButton2" 
                 CommandArgument='<%# Eval("signup_id") %>' 
                 CommandName="vw" runat="server">
                 Edit/View</asp:LinkButton>
             </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
             </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Panel ID="pnlView" runat="server" Visible="false">
        <table border="0" cellpadding="1" cellspacing="2">
            <tr>
                <td width="100" bgcolor="#c9c9c9">First Name:</td>
                <td><asp:TextBox ID="lblFirstName" runat="server" /></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Last Name:</td>
                <td><asp:TextBox ID="lblLastName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">E-Mail:</td>
                <td><asp:TextBox ID="lblEmail" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Company:</td>
                <td><asp:TextBox ID="lblCompany" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Department:</td>
                <td><asp:TextBox ID="lblDepartment" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Title:</td>
                <td><asp:TextBox ID="lblTitle" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Phone:</td>
                <td><asp:TextBox ID="lblPhone" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Address1:</td>
                <td><asp:TextBox ID="lblAddress1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Address2:</td>
                <td><asp:TextBox ID="lblAddress2" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">City:</td>
                <td><asp:TextBox ID="lblCity" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">State:</td>
                <td><asp:TextBox ID="lblState" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Zip:</td>
                <td><asp:TextBox ID="lblZip" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Country:</td>
                <td><asp:TextBox ID="lblCountry" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Region:</td>
                <td><asp:TextBox ID="lblRegion" runat="server"></asp:TextBox></td>
            </tr>
	    <tr>
                <td width="100" bgcolor="#c9c9c9">Partner:</td>
                <td><asp:TextBox ID="lblPartner" runat="server"></asp:TextBox></td>
            </tr>
	    <tr>
                <td width="100" bgcolor="#c9c9c9">Partner Id:</td>
                <td><asp:TextBox ID="lblPartnerId" runat="server"></asp:TextBox> <a href="http://www.workengine.com/partners/Lists/Partners/PartnerIds.aspx" target="_blank">[Find an ID]</a></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Promo Code:</td>
                <td><asp:TextBox ID="txtCode" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Event Code:</td>
                <td><asp:Label ID="lblEventCode" runat="server"></asp:Label></td>
            </tr>
		<tr>
                <td width="100" bgcolor="#c9c9c9">Interested In:</td>
                <td><asp:Label ID="lblApplication" runat="server"></asp:Label></td>
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
        </table>
        <asp:HiddenField ID="hdnsignupid" runat="server" />
        <br /><br />
        <asp:Button ID="btnProcess" runat="server" Text="Complete" OnClick="btnProcess_Click" CssClass="searchbutton"/> 
        <asp:Button ID="btnCancel" runat="server" Text="Delete" OnClick="btnCancel_Click" CssClass="searchbutton"/> 
        <asp:Button ID="btnGoBack" runat="server" Text="Go Back" OnClick="btnGoBack_Click" CssClass="searchbutton"/> 
    </asp:Panel>
</asp:Content>
