<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="addkey.aspx.cs" Inherits="AdminSite.addkey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <table>
        <tr>
            <td bgcolor="#c9c9c9" style="width: 100px">Key Type:</td>
            <td>
                <asp:DropDownList runat="Server" AutoPostBack="false" ID="ddlVersion">
                    <asp:ListItem Text="Version 1 (Old Feature Based)" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Version 2 (New Feaure Based)" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Version 3 (Role Based)" Value="3" Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td bgcolor="#c9c9c9" style="width: 150px">Company:</td>
            <td><asp:TextBox ID="txtCompany" runat="Server" Width="299px"/></td>
        </tr>
        <tr>
            <td bgcolor="#c9c9c9" style="width: 100px">Activations (Default 1):</td>
            <td><asp:TextBox ID="txtActivations" runat="Server" Width="39px" Text="1"/></td>
        </tr>
        <tr id="trLicenses">
            <td bgcolor="#c9c9c9" style="width: 150px">Licenses:</td>
            <td>
                <asp:GridView ID="gvLicenses" runat="server" AutoGenerateColumns="False" 
                    EnableModelValidation="True" Width="285px">
                    <Columns>
                        <asp:BoundField DataField="feature_id" HeaderText="id" />
                        <asp:BoundField DataField="feature_name" HeaderText="Feature" />
                        <asp:TemplateField HeaderText="Users">
                            <ItemTemplate>
                                <asp:TextBox ID="txtUserCount" runat="server" Width="37px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr id="trFeatures2">
            <td bgcolor="#c9c9c9" style="width: 150px">Features:</td>
            <td>
                
                <asp:GridView ID="gvFeatures" runat="server" AutoGenerateColumns="False" 
                    EnableModelValidation="True" Width="285px">
                    <Columns>
                        <asp:BoundField DataField="feature_id" HeaderText="id" />
                        <asp:BoundField DataField="feature_name" HeaderText="Feature" />
                        <asp:TemplateField HeaderText="Users">
                            <ItemTemplate>
                                <asp:TextBox ID="txtUserCount" runat="server" Width="37px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                
            </td>
        </tr>
        <tr id="trFeatures">
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
        </tr>
        <tr id="trUsers">
            <td bgcolor="#c9c9c9" style="width: 100px">Users:</td>
            <td><asp:TextBox ID="txtUsers" runat="Server" Width="39px" Text="1"/></td>
        </tr>
        <tr id="trServers">
            <td bgcolor="#c9c9c9" style="width: 100px">Servers:</td>
            <td><asp:TextBox ID="txtServers" runat="Server" Width="39px" Text="1"/></td>
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
                <td bgcolor="#c9c9c9" style="width: 100px">Support Years (Default 1):</td>
                <td><asp:TextBox ID="txtSupportYears" runat="Server" Width="39px" Text="0"/></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    </td>
                <td><asp:Button ID="btnAdd" runat="server" Text="Add Key" onclick="btnAdd_Click" CssClass="searchbutton" /></td>
            </tr>
    </table>
    <script language="javascript">
        function ChangeVersion()
        {
            var ddl = document.getElementById("<%=ddlVersion.ClientID %>");
            var val = ddl.options[ddl.selectedIndex].value;

            if (val == 1) {
                document.getElementById("trFeatures").style.display = "";
                document.getElementById("trUsers").style.display = "";
                document.getElementById("trServers").style.display = "";
                document.getElementById("trFeatures2").style.display = "none";
                document.getElementById("trLicenses").style.display = "none";
            } else if (val == 2) {
                document.getElementById("trFeatures").style.display = "none";
                document.getElementById("trUsers").style.display = "none";
                document.getElementById("trServers").style.display = "none";
                document.getElementById("trFeatures2").style.display = "";
                document.getElementById("trLicenses").style.display = "none";
            } else if (val == 3) {
                document.getElementById("trFeatures").style.display = "none";
                document.getElementById("trUsers").style.display = "none";
                document.getElementById("trServers").style.display = "none";
                document.getElementById("trFeatures2").style.display = "none";
                document.getElementById("trLicenses").style.display = "";
            }
        }
        ChangeVersion();
    </script>
</asp:Content>
