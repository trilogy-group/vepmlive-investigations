<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addfeature.aspx.cs" Inherits="AdminSite.addfeature" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
        <style>
            input.button
            { background: #605D58; 
              border: 0px; 
              padding: 1px;
              color: #FFF;
              width: 64px;
              cursor: pointer;
            }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="1" cellspacing="2">
            <tr>
                <td bgcolor="#c9c9c9" style="width: 150px">Company:</td>
                <td><asp:TextBox ID="txtCompany" runat="Server" Width="299px"/></td>
                <td bgcolor="#c9c9c9" style="width: 100px">Activations (Default 1):</td>
                <td><asp:TextBox ID="txtActivations" runat="Server" Width="39px" Text="1"/></td>
            </tr>
            <tr>
                <td bgcolor="#c9c9c9" style="width: 150px">Features:</td>
                <td>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                        <asp:ListItem Value="0">Toolkit Base (WebParts)</asp:ListItem>
                        <asp:ListItem Value="1">Workplanner</asp:ListItem>
                        <asp:ListItem Value="2">Resource Planner</asp:ListItem>
                        <asp:ListItem Value="3">Timesheets</asp:ListItem>
                        <asp:ListItem Value="4">Enterprise Base</asp:ListItem>
                        <asp:ListItem Value="5">Reporting</asp:ListItem>
                        <asp:ListItem Value="6">Agile Planner</asp:ListItem>
                        <asp:ListItem Value="7">PortfolioEngine Core</asp:ListItem>
                        <asp:ListItem Value="8">MyWork WebPart</asp:ListItem>
                    </asp:CheckBoxList></td>
                <td bgcolor="#c9c9c9" style="width: 100px">Support Date (Start):</td>
                <td>
                    <asp:Calendar ID="Calendar3" runat="server" BackColor="White" BorderColor="#999999"
                        CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                        ForeColor="Black" Height="180px" Width="200px">
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td bgcolor="#c9c9c9" style="width: 150px">User Count (0 for unlimited):</td>
                <td><asp:TextBox ID="txtUsers" runat="Server" Width="39px"/></td>
                <td bgcolor="#c9c9c9" style="width: 100px">Support Years (Default 1):</td>
                <td><asp:TextBox ID="txtSupportYears" runat="Server" Width="39px" Text="0"/></td>
            </tr>
	<tr>
                <td bgcolor="#c9c9c9" style="width: 150px">Server Count (Needed when doing unlimited users):</td>
                <td><asp:TextBox ID="txtServers" runat="Server" Width="39px"/></td>
                <td bgcolor="#c9c9c9" style="width: 100px"></td>
                <td></td>
            </tr>
            <tr>
                <td bgcolor="#c9c9c9" style="width: 150px">Purchase Date:</td>
                <td>
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999"
                        CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                        ForeColor="Black" Height="180px" Width="200px">
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td bgcolor="#c9c9c9" style="width: 100px; height: 201px">Expiration Date:</td>
                <td style="height: 201px">
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Has Expiration Date" /><br />
                    <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999"
                        CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                        ForeColor="Black" Height="180px" Width="200px">
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td bgcolor="#c9c9c9" style="width: 100px">
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Save Key" OnClick="Button1_Click" CssClass="button" />
                    <input type="button" value="Cancel" onclick="Javascript:parent.closeaddfeature();" class="button"/>
                    
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
