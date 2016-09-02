<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveCore.addperiods"%>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Add Periods</title>
    <link rel="stylesheet" type="text/css" href="/_layouts/1033/styles/core.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label runat="server" ID="lblError" ForeColor="red" Visible="false"></asp:Label>
    <asp:Panel runat="server" ID="pnlData">
    <br />
        <table>
            <tr>
                <td class="ms-sectionheader">Period Type:</td>
                <td style="width: 223px">
                    <asp:DropDownList ID="ddlPeriodType" runat="server" OnSelectedIndexChanged="ddlPeriodType_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="Months" Value="Months"></asp:ListItem>
                        <asp:ListItem Text="Weeks" Value="Weeks"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td valign="top" class="ms-sectionheader">Start Date:</td>
                <td style="width: 223px">
                <SharePoint:DateTimeControl ID="calStart" runat="server" DateOnly="True" >
                    <asp:TextBox ID="calStart2Date" runat="server" CssClass="ms-input" MaxLength="45"></asp:TextBox>
                </SharePoint:DateTimeControl>
                </td>
            </tr>
            <tr>
                <td class="ms-sectionheader">Number of <%=periodType %>:</td>
                <td style="width: 223px"><asp:TextBox runat="server" ID="txtNumber" Width="40"></asp:TextBox></td>
            </tr>
            <tr style="display: <%=display %>;">
                <td class="ms-sectionheader">Start Weeks On #:</td>
                <td style="width: 223px"><asp:TextBox runat="server" ID="txtStartWeek" Width="40" Text="1"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td style="width: 223px"><asp:Button ID="btnSubmit" runat="server" Text="Preview Periods" OnClick="btnSubmit_Click" /></td>
            </tr>
        </table> 
        </asp:Panel>
        <asp:Panel ID="pnlGrid" runat="server" Visible="false">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%">
                <Columns>
                         <asp:TemplateField HeaderText="Name" ItemStyle-VerticalAlign="top" ItemStyle-Font-Size="XX-Small">
                         <ItemTemplate>
                         <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("name") %>' Width="100px"></asp:TextBox>
                         </ItemTemplate>
                         </asp:TemplateField>
                         
                         <asp:TemplateField HeaderText="Start" ItemStyle-VerticalAlign="top" ItemStyle-Font-Size="XX-Small">
                         <ItemTemplate>
                         <asp:TextBox ID="txtStart" runat="server" Text='<%# Eval("start") %>' Width="100px"></asp:TextBox>
                         </ItemTemplate>
                         </asp:TemplateField>
                         
                         <asp:TemplateField HeaderText="End" ItemStyle-VerticalAlign="top" ItemStyle-Font-Size="XX-Small">
                         <ItemTemplate>
                         <asp:TextBox ID="txtEnd" runat="server" Text='<%# Eval("finish") %>' Width="100px"></asp:TextBox>
                         </ItemTemplate>
                         </asp:TemplateField>
                         
                         <asp:TemplateField HeaderText="Capacity" ItemStyle-VerticalAlign="top" ItemStyle-Font-Size="XX-Small">
                         <ItemTemplate>
                         <asp:TextBox ID="txtCapacity" runat="server" Text='<%# Eval("capacity") %>' Width="50px"></asp:TextBox>
                         </ItemTemplate>
                         </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" Font-Size="XX-Small" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#d3d3d3" Font-Bold="True" ForeColor="#FFFFFF" HorizontalAlign="Left" Font-Size="XX-Small" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White"  Font-Size="XX-Small"/>
            </asp:GridView><br />
            <asp:Button ID="btnSubmit2" runat="server" Text="Generate Periods" OnClick="btnSubmit2_Click" />
        </asp:Panel>
    </div>
    </form>
</body>
</html>
