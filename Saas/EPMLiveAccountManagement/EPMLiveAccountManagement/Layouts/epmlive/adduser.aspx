<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adduser.aspx.cs" Inherits="EPMLiveAccountManagement.adduser" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Add User</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

<table align="center">
    <tr style="display:<%=hideCount%>">
        <td>
            <table style="border:  1px solid #800000" align="right">
                <tr>
                    <td class="ms-toolbar">
                        <strong>User Usage: <asp:Label ID="lblUserCount" runat="server"></asp:Label> out of <asp:Label ID="lblMaxUsers" runat="server"></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td class="ms-toolbar" style="border:  1px solid #c9c9c9">
                        <table width="<%=strWidth%>%" bgcolor="#<%=strBarColor%>">
                            <tr>
                                <td><img src="images/blank.gif" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="ms-toolbar" align="center">
                        <img src="images/blank.gif" width="200" height="5" /><br />
                        <a href="http://www.workengine.com/Applications/SitePages/BuyNow.aspx?account_ref=<%=account_ref %>&quantity=<%=quantity %>&version=<%=version %>&level=<%=level %>" target="_blank"><img src="images/buymore.gif" border="0" /></a>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
             <asp:HiddenField ID="hdnStep" runat="server" Value="1" />
            <table style="border:  1px solid #303030" align="center" cellpadding="0" cellspacing="0" width="600">
                <tr>
                    <td bgcolor="#D6E8FF">
                        <table>
                            <tr>
                                <td class="ms-WPBody">
                                    <asp:Label Text="To add new user accounts, enter a list of email addresses separated by semicolons." ID="lblDesc" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center" bgcolor="#D6E8FF" class="ms-WPBody">
                        <br />
                        <font class="UserGeneric"><asp:Label ID="lblEmailsNotification" runat="server"></asp:Label></font><br />
                        <asp:TextBox style="border:  1px solid #000000" ID="txtEmails" runat="server" Rows="10" Columns="50" TextMode="multiLine"></asp:TextBox>
                        <asp:Label ID="lblEmailInvalid" runat="server" Text="<br><br>Please enter 1 or more valid E-mail addresses" Font-Bold="true" ForeColor="red" Visible="false"></asp:Label>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="None" Width="98%" BorderStyle=Solid borderwidth=1px Visible="false"> 
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="First Name" HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("first") %>' BorderStyle="Solid" BorderWidth="1" Font-Size="X-Small"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Last Name" HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("last") %>' BorderStyle="Solid" BorderWidth="1" Font-Size="X-Small"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="email" HeaderText="E-Mail"  HeaderStyle-HorizontalAlign="left"/>
                                <asp:BoundField DataField="username" HeaderText="username"  HeaderStyle-HorizontalAlign="left"/>
                            </Columns>
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="X-Small"/>
                            <EditRowStyle BackColor="#999999" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#90B9F1" Font-Bold="True" ForeColor="Black"  Font-Size="X-Small"/>
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775"  Font-Size="X-Small"/>
                        </asp:GridView><br />
                        <asp:Label ID="lblEmailsError" runat="server" Visible="false" Forecolor="red" Text="You have entered too many E-mail addresses. You must purchase more users to continue."></asp:Label>
                        <asp:Label ID="lblGridError" runat="server" Visible="false" Text="Please fill in all first and last name values." Forecolor="red"></asp:Label>
                        <asp:Panel ID="pnlResults" Visible="false" runat="server">
                            <table cellpadding="3" cellspacing="0" bgcolor="#FFFFFF" width="95%" style="border:  1px solid #000000" height="100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblResults" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center" bgcolor="#90B9F1" style="border-top-style: solid; border-width: 1px">
                        <table>
                            <tr>
                                <td><asp:Button ID="btnBack" runat="server" Text="&lt; Back" Visible="false" OnClick="btnBack_Click"/></td>
                                <td><asp:Button ID="btnNext" runat="server" Text="Next &gt;" OnClick="btnNext_Click"/></td>
                                <td><asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="javascript:window.close();"/></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<style>
    .ms-globalbreadcrumb {display:none;}
    .ms-globalTitleArea {display:none;}
    .ms-bannerContainer  {display:none;}
</style>
  </div>
    </form>
</body>
</html>
