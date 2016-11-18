<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addpubkey.aspx.cs" Inherits="AdminSite.addpubkey" %>


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
                <td bgcolor="#c9c9c9" style="width: 100px">Key:</td>
                <td><asp:TextBox ID="txtKey" runat="Server" Width="150px" Text="1"/></td>
            </tr>
            <tr>
                <td bgcolor="#c9c9c9" style="width: 100px">Activations:</td>
                <td><asp:TextBox ID="txtActivations" runat="Server" Width="39px" Text="1"/></td>
            </tr>
            <tr>
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
                <td bgcolor="#c9c9c9" style="width: 100px"># of Support Years:</td>
                <td><asp:TextBox ID="txtSupportYears" runat="Server" Width="39px" Text="0"/></td>
            </tr>
            <tr>
                <td bgcolor="#c9c9c9" style="width: 100px">
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Add Key" OnClick="Button1_Click" CssClass="button"/>
                    <input type="button" value="Cancel" onclick="Javascript:parent.closeadd();" class="button"/>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
