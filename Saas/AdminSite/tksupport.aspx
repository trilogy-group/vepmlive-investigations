<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tksupport.aspx.cs" Inherits="AdminSite.tksupport" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style>
        input.button
        {
            background: #605D58;
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
        </asp:Calendar><br />
        Years: <asp:TextBox ID="txtYears" runat="server"></asp:TextBox><br /><br />
        
        <asp:Button ID="btnRemove" runat="server" Text="Remove Support" OnClick="btnRemove_Click" CssClass="button" style="width:150px"/>            
        <asp:Button ID="btnReset" runat="server" Text="Save" OnClick="btnReset_Click" CssClass="button"/>
        <input type="button" value="Cancel" onclick="Javascript:parent.closereset();" class="button"/>
    </div>
    </form>
</body>
</html>

