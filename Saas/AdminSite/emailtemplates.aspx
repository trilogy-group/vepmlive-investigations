<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="emailtemplates.aspx.cs" Inherits="AdminSite.emailtemplates" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

<h1>E-Mail Templates</h1>
        <a href="addemail.aspx">New Email</a>
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="681px" OnRowEditing="GridView1_RowEditing" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
            <FooterStyle BackColor="#CCCC99" />
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="email_id"/>
                <asp:BoundField HeaderText="Subject" DataField="subject" />
                <asp:BoundField HeaderText="From" DataField="mailfrom" />
                <asp:CommandField HeaderText="Edit" ShowEditButton="True" >
                    <HeaderStyle Width="100px" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                </asp:CommandField>
            </Columns>
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <br />
        
        <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="false">
            <asp:HiddenField ID="hdnId" runat="server" />
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" text="Save"/>
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" text="Cancel"/><br />
            Subject: <asp:TextBox ID="txtSubject" runat="server" Columns="100"></asp:TextBox><br />
            From E-mail: <asp:TextBox ID="txtMailFrom" runat="server" Columns="100"></asp:TextBox><br />
            From Name: <asp:TextBox ID="txtMailFromName" runat="server" Columns="100"></asp:TextBox><br />
            Body:<br />
            <asp:TextBox ID="text" runat="server" TextMode="multiLine" Rows="30" Columns="100"></asp:TextBox>
            <br /><br />
            <asp:Button ID="btnSubmit2" runat="server" OnClick="btnSubmit_Click" text="Save"/> 
            <asp:Button ID="btnCancel2" runat="server" OnClick="btnCancel_Click" text="Cancel"/><br />
        </asp:Panel>

</asp:Content>
