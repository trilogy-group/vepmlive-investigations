<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SPResourceFieldMapping.aspx.cs" Inherits="WorkEnginePPM.SPResourceFieldMapping" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
	<link id="pageStyles" href="styles/page.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <table width="100%">
        <tr id="idWorkspaceArea">
	        <td style="width:100%; vertical-align:top;">
            <div>
                <asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                <asp:Panel runat="server" ID="pnlMain">
                    <table width="100%" cellspacing="0">
                        <!--<tr>
                            <td width="450" class="controlcell">
                                <b>Connected URL</b><br />
                            </td>
                            <td class="controlcell">
                        
                                <asp:Label ID="lblUrl" runat="server"></asp:Label>
                        
                            </td>
                        </tr>-->
                        <tr>
                            <td width="450" class="controlcell">
                                <b>Resource Pool URL</b><br />
                            </td>
                            <td class="controlcell">
                        
                                <asp:Label ID="lblResPoolUrl" runat="server"></asp:Label>
                        
                            </td>
                        </tr>
                        <tr valign="top">
                            <td width="450" class="controlcell">
                                <b>SharePoint Field Mapping</b><br />
                                Select the fields that will be mapped from PortfolioEngine Resources to the SharePoint Resource Pool.
                            </td>
                            <td class="controlcell">
                        
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    EnableModelValidation="True" Width="400px" BackColor="White" 
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="1" 
                                    ForeColor="Black" GridLines="Horizontal" 
                                    onrowdatabound="GridView1_RowDataBound" >
                                    <Columns>
                                        <asp:BoundField DataField="epkField" HeaderText="PortfolioEngine Field"  HeaderStyle-HorizontalAlign="Left"/>
                                        <asp:TemplateField HeaderText="SharePoint Field" ItemStyle-Width="200" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlSPField" runat="server">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="epkFieldId"/>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                    <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="#000000" HorizontalAlign="Left" />
                                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                        
                                <br />
                        
                            </td>
                        </tr>
                        <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" 
                                onclick="btnSave_Click"/>&nbsp;
                        </td>
                    </tr>
                    </table>
                </asp:Panel>
                <!--<asp:Panel runat="server" ID="pnlNoUrl">
                    The Integration URL has not been set. <a href="SPIntegration.aspx">Click here</a> to set.
                </asp:Panel>-->
            </div>
            </td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Resource Field Mapping
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Resource Field Mapping
</asp:Content>
