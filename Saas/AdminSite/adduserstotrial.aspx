<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="adduserstotrial.aspx.cs" Inherits="AdminSite.adduserstotrial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="detail_type_id" HeaderText="License Type" />
            <asp:BoundField DataField="detail_name" HeaderText="License Type" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server" Width="37px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    
    <br />

    
    <asp:Button ID="Button1" runat="server" Text="Save" onclick="Button1_Click" CssClass="searchbutton"/>

</asp:Content>
