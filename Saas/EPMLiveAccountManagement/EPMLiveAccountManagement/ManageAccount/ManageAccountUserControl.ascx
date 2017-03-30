<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBar" src="~/_controltemplates/ToolBar.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBarButton" src="~/_controltemplates/ToolBarButton.ascx" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageAccountUserControl.ascx.cs" Inherits="EPMLiveAccountManagement.ManageAccount.ManageAccountUserControl" %>

<script language="javascript">
    function addAccount() {
        function NewItemCallback(dialogResult, returnValue) {
            
        }

        var options = { url: "<%=weburl %>/_layouts/epmlive/addaccount.aspx", width: 400, dialogReturnValueCallback: NewItemCallback };

        SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
    }

    function editPersonal() {
        function NewItemCallback(dialogResult, returnValue) {
            var url = location.href.split('?')[0];
            window.location.href = url + "?account_id=<%=ddlAccount.SelectedValue %>";
        }

        var options = { url: "<%=weburl %>/_layouts/epmlive/editpersonal.aspx", width: 600, dialogReturnValueCallback: NewItemCallback };

        SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
    }
</script>

<wssuc:ToolBar runat="server" ID="tbMain">
    <Template_Buttons>
        <wssuc:ToolBarButton ID="btnNewAccount" runat="server" NavigateUrl="javascript:void(0);" ImageUrl="/_layouts/images/NewContentPageHS.png" Text="Add Account" OnClientClick="javascript:addAccount();"></wssuc:ToolBarButton>
    </Template_Buttons>
    <Template_RightButtons>
        <asp:Label id="lbl1" runat="server">Account: </asp:Label><asp:DropDownList AutoPostBack="true" ID="ddlAccount" runat="server" OnSelectedIndexChanged="ddlAccount_SelectedIndexChanged"></asp:DropDownList>
    </Template_RightButtons>
</wssuc:ToolBar>

<style type="text/css">
    .account
    {
        <%=strAccountStyle%>
    }
</style>

<table width="100%">
    <tr>
        <td width="50%" valign="top">
            <table>
                <tr class="ms-standardheader ms-WPTitle account">
                    <td>
                        <h3>Account Information</h3>
                    </td>
                </tr>
                <tr class="account">
                    <td style="padding-left: 10px">
                        <b>Account Name:</b> <asp:Label ID="lblAccountName" runat="server"></asp:Label><br />
                        <b>Account Number:</b> <asp:Label ID="lblAccountNumber" runat="server"></asp:Label><br />
                        <br />
                    </td>
                </tr>
                <tr class="ms-standardheader ms-WPTitle">
                    <td>
                        <h3>Personal Information</h3>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 10px">
                        <b>Name:</b><br />
                        <asp:Label ID="lblName" runat="server"></asp:Label><br />
                        <b>Address:</b><br />
                        <asp:Label ID="lblAddress" runat="server"></asp:Label><br />
                        <b>Phone:</b><br />
                        <asp:Label ID="lblPhone" runat="server"></asp:Label><br />
                        <b>E-mail:</b><br />
                        <asp:Label ID="lblEmail" runat="server"></asp:Label><br />
                        <br />
                        <a href="javascript:void(0);" onclick="editPersonal();">[Edit]</a>
                    </td>
                </tr>
                <tr class="ms-standardheader ms-WPTitle account">
                    <td>
                        <h3>Sites</h3>
                    </td>
                </tr>
                <tr class="account">
                    <td style="padding-left: 10px">
                        <table style="border:  1px solid #FFFFFF; background-color: #FFFFFF; height:5px" width="400">
                            <tr>
                                <td >
                                    <strong>Disk Usage: <asp:Label ID="lbldiskusage" runat="server"></asp:Label>MB out of <asp:Label ID="lblDiskQuota" runat="server"></asp:Label>MB</strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="ms-toolbar" style="border:  1px solid #c9c9c9">
                                    <table width="<%=strSiteUsageWidth%>%" bgcolor="#000ac0">
                                        <tr>
                                            <td><img src="/_layouts/epmlive/blank.gif" height="5px"/></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table>
                            <%=SiteList %>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
        <td width="50%" align="right" valign="top">
            <table>
                <tr class="ms-standardheader ms-WPTitle account">
                    <td>
                        <h3>Order Information</h3>
                    </td>
                </tr>
                <tr class="account">
                    <td style="padding-left: 10px">
                        <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="False" CellPadding="2" ForeColor="#333333" GridLines="None" CellSpacing="0" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="plimusReferenceNumber" HeaderText="Reference #"  ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="quantity" HeaderText="Quantity" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"/>
                                <asp:BoundField DataField="expiration" HeaderText="Expires"  ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="contractLevel" HeaderText="Level" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"/>
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#FFFFFF" ForeColor="#333333" CssClass="ms-vb2"/>
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"/>
                            <HeaderStyle BackColor="#F3F3F3" ForeColor="#505050" CssClass="ms-vh2-nofilter ms-vh2-gridview"/>
                            <AlternatingRowStyle BackColor="#F7F6F3" ForeColor="#284775" CssClass="ms-vb2"/>
                        </asp:GridView>
                    </td>
                </tr>
                <tr class="ms-standardheader ms-WPTitle account">
                    <td style="height:10px">
                        <h3>User Information</h3>
                    </td>
                </tr>
                <tr class="account">
                    <td style="padding-left: 10px" align="left">
                        <table style="border:  1px solid #FFFFFF; background-color: #FFFFFF;" width="400">
                            <tr>
                                <td align="left">
                                    <strong>User Usage: <asp:Label ID="lblUserCount" runat="server"></asp:Label> out of <asp:Label ID="lblMaxUsers" runat="server"></asp:Label></strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="ms-toolbar" style="border:  1px solid #c9c9c9">
                                    <table width="<%=strUserWidth%>%" bgcolor="#00ba00">
                                        <tr>
                                            <td><img src="/_layouts/epmlive/blank.gif" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <a href="http://www.workengine.com/Applications/SitePages/BuyNow.aspx?account_ref=<%=account_ref %>&quantity=<%=quantity %>&version=2&level=<%=level %>" target="_blank"><img src="/_layouts/epmlive/images/buymore.gif" border="0" /></a>
                        <br />
                        <br />
                        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" CellPadding="2" ForeColor="#333333" GridLines="None" CellSpacing="0">
                            <Columns>
                                <asp:BoundField DataField="name" HeaderText="Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ItemStyle-CssClass="ms-vb2" ItemStyle-Width="200px"/>
                                <asp:BoundField DataField="email" HeaderText="E-Mail" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ItemStyle-CssClass="ms-vb2" ItemStyle-Width="200px"/>
                                <asp:BoundField DataField="username" HeaderText="Username" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ItemStyle-CssClass="ms-vb2" ItemStyle-Width="200px"/>
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#FFFFFF" ForeColor="#333333"/>
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"/>
                            <HeaderStyle BackColor="#F3F3F3" ForeColor="#505050" CssClass="ms-vh2-nofilter ms-vh2-gridview"/>
                            <AlternatingRowStyle BackColor="#F7F6F3" ForeColor="#284775"/>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>




<script language="javascript">
    try {
        document.getElementById("<%=tbMain.ClientID %>").style.height = "15px";
    } catch (e) { }
</script>
