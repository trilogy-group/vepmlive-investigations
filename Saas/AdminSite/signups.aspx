<%@Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="signups.aspx.cs" Inherits="AdminSite.signups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

<asp:Panel ID="pnlMain" runat="server">

    <table width="100%" style="height:100%">
        <tr>
            <td>
                <h4>Product</h4>
                Choose Product: 
                <asp:DropDownList ID="dllProduct" runat="server">
                    <asp:ListItem Text="ProjectEngine" Value="3"></asp:ListItem>
                    <asp:ListItem Text="WorkEngine" Value="2"></asp:ListItem>
                    <asp:ListItem Text="PortfolioEngine" Value="4"></asp:ListItem>
                    <asp:ListItem Text="EPM Live (Latest Licensing)" Value="5"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><hr style="color: Gray"></td>
        </tr>
        <tr>
            <td>
                <h4>Filter</h4>
                Filter By: 
                <asp:DropDownList ID="ddlFilterBy" runat="server">
                    <asp:ListItem Text="First Name" Value="FirstName"></asp:ListItem>
                    <asp:ListItem Text="Last Name" Value="LastName"></asp:ListItem>
                    <asp:ListItem Text="Company" Value="Company"></asp:ListItem>
                </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Filter For:
                <asp:TextBox ID="txtFilterFor" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox runat="server" ID="chkComplete" /> Show Complete Items&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSubmit" runat="server" Text="Search" 
                    onclick="btnSubmit_Click"/>
            </td>
        </tr>
        <tr>
            <td><hr style="color: Gray"></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblResults" runat="server"></asp:Label><br /><br />
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
                        <asp:BoundField DataField="processed" HeaderText="Process" >
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
            </td>
        </tr>
    </table>


    </asp:Panel>

    <asp:Panel id="pnlProcess" runat="server" Visible="false">
    
        <table border="0">
            <tr>
                <td>First Name:</td>
                <td><asp:Label ID="lblFirstName" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Last Name:</td>
                <td><asp:Label ID="lblLastName" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Country:</td>
                <td><asp:Label ID="lblCountry" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>State:</td>
                <td><asp:Label ID="lblState" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Email:</td>
                <td><asp:Label ID="lblEmail" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Company:</td>
                <td><asp:Label ID="lblCompany" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Phone:</td>
                <td><asp:Label ID="lblPhone" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Version:</td>
                <td><asp:Label ID="lblVersion" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Process:</td>
                <td><asp:Label ID="lblProcess" runat="server"></asp:Label></td>
            </tr>
        </table>

    </asp:Panel>

    

</asp:Content>
