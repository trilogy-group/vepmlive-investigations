<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="people.aspx.cs" Inherits="EPMLiveAccountManagement.people" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="Manage Users" EncodeMethod='HtmlEncode'/>
</asp:Content>
<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	<asp:Label ID="lblTitle" runat="server" Text="Manage Accounts"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
<asp:Panel ID="Panel4" runat="server" Visible="true">
    <asp:Label ID="lblDesc" runat="server">
        
    </asp:Label>
</asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">

    <asp:Panel ID="pnl" runat="server">
        <asp:HiddenField ID="hdnAccountId" runat="server" />
        <asp:HiddenField ID="hdnUserId" runat="server" />
    <table width="100%">
        <tr>
            <td>
                <asp:Panel ID="pnlCounter" runat="server">
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                        <td width="100%">
                            <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="red" Font-Bold="true" Font-Size="X-Small"></asp:Label>
                            <asp:Label ID="lblSuccess" runat="server" Visible="false" ForeColor="green" Font-Bold="true" Font-Size="X-Small"></asp:Label>
                        </td>
                            <td align="right">
                                <table style="border:  1px solid #800000" width="400">
                                    <tr>
                                        <td class="ms-toolbar">
                                            <strong>User Usage: <asp:Label ID="lblUserCount" runat="server"></asp:Label> out of <asp:Label ID="lblMaxUsers" runat="server"></asp:Label></strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="ms-toolbar" style="border:  1px solid #c9c9c9">
                                            <table width="<%=strWidth%>%" bgcolor="#<%=strBarColor%>">
                                                <tr>
                                                    <td><img src="images/blank.gif" height="5"/></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="ms-toolbar" align="center">
                                            <img src="images/blank.gif" width="200" height="5" /><br />
                                            <a href="#" onClick="window.open('<%=weburl%>/_layouts/epmlive/adduser.aspx','adduser','height=500,width=700,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes');" style="<%=hideAdd%>"><img src="images/createaccount.gif" border="0" /></a>&nbsp;
                                            <a href="http://www.workengine.com/Applications/SitePages/BuyNow.aspx?account_ref=<%=account_ref %>&quantity=<%=quantity %>&version=<%=version %>&level=<%=level %>" target="_blank"><img src="images/buymore.gif" border="0" /></a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <table class="ms-menutoolbar" cellpadding="0" cellspacing="0" border="0" width="100%" style="height:25px">
                    <tr>
                        <td class="ms-toolbar" nowrap="true">
                            <asp:Panel ID="pnlAddUser" runat="server">
                                <table height="100%" border="0" width="100" cellspacing="0" onmouseover="MMU_EcbTableMouseOverOut(this, true)" hoverActive="ms-splitbuttonhover" hoverInactive="ms-splitbutton" downArrowTitle="Add User">
                                    <tr>
                                        <td valign="middle" class="ms-splitbuttontext">
                                            <a href="#" onClick="window.open('<%=weburl%>/_layouts/epmlive/adduser.aspx<%= isdlg%>','adduser','height=500,width=700,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes');">Create Accounts</a>
                                        </td>
                                    </tr>
                                 </table>
                             </asp:Panel>
                        </td>
                        <td class="ms-toolbar" nowrap="true">
                            <asp:Panel ID="pnlBuild" runat="server">
                                <table height="100%" width="80" border="0" cellspacing="0" onmouseover="MMU_EcbTableMouseOverOut(this, true)" hoverActive="ms-splitbuttonhover" hoverInactive="ms-splitbutton" downArrowTitle="Add User">
                                    <tr>
                                        <td valign="middle" class="ms-splitbuttontext">
                                            <a href = "addmember.aspx<%= isdlg%>">Add Members</a>
                                        </td>
                                    </tr>
                                 </table>
                             </asp:Panel>
                        </td>
                        <td class="ms-toolbar" nowrap="true">
                            <asp:Panel ID="pnlRequests" runat="server" Visible="false" >
                                <table height="100%" width="110" border="0" cellspacing="0" onmouseover="MMU_EcbTableMouseOverOut(this, true)" hoverActive="ms-splitbuttonhover" hoverInactive="ms-splitbutton" downArrowTitle="Add User">
                                    <tr>
                                        <td valign="middle" class="ms-splitbuttontext">
                                            <a href = "userrequests.aspx<%= isdlg%>" target="_top">Account Requests</a>
                                        </td>
                                    </tr>
                                 </table>
                             </asp:Panel>
                        </td>
                        <td class="ms-toolbar" nowrap="true" width="100%">

                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" Width="100%"
                    OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="name" HeaderText="Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top"/>
                        <asp:BoundField DataField="email" HeaderText="E-Mail" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top"/>
                        <asp:BoundField DataField="group" HeaderText="Groups" HeaderStyle-HorizontalAlign="Left" HtmlEncode="false" />
                        <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="top">
                         <ItemTemplate>
                           <asp:LinkButton ID="LinkButton2" 
                             CommandArgument='<%# Eval("username") %>' 
                             CommandName="Edi" runat="server">
                             Edit</asp:LinkButton>
                         </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="top">
                         <ItemTemplate>
                           <asp:LinkButton ID="LinkButton1" 
                             CommandArgument='<%# Eval("uid") %>' 
                             CommandName="Del" runat="server">
                             Delete</asp:LinkButton>
                         </ItemTemplate>
                         </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" cssclass="ms-WPBody"/>
                    <EditRowStyle BackColor="#999999" Font-Size="X-Small" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" Font-Size="X-Small"/>
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Font-Size="X-Small"/>
                    <HeaderStyle BackColor="#c9c9c9" Font-Bold="True" ForeColor="Black" Font-Size="XX-Small"/>
                    <AlternatingRowStyle BackColor="White" cssclass="ms-WPBody"/>
                </asp:GridView>
            </td>
        </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlEdit" runat="server" Visible="false">
    <asp:HiddenField ID="HiddenUsername" runat="server"/>
        <table cellpadding="0" cellspacing="0" width="100%">
	            <tr>
	                <td height="1" class="ms-sectionline" colspan="2"><IMG SRC="/_layouts/images/blank.gif" width="1" height="1" alt=""></td>
                </tr>
			    <tr>
			        <td width="150">
			            <table border="0" cellpadding="5" cellspacing="0" width="100%">
				            <tr>
					            <td class="ms-sectionheader" style="padding-top: 0px;" height="2" valign="top">
					              <H3 class="ms-standardheader">Name:</H3>
					            </td>
				            </tr>
			            </table>
			        </td>
			        <td class="ms-authoringcontrols ms-inputformcontrols" valign="top" align="left" >
			            <table cellpadding="5">
			                <tr>
			                    <td><font size="-1"><asp:Label ID="lblName" runat="server"></asp:Label></font></td>
			                </tr>
			            </table>
			        </td>
			    </tr>
			    <tr>
	                <td height="1" class="ms-sectionline" colspan="2"><IMG SRC="/_layouts/images/blank.gif" width="1" height="1" alt=""></td>
                </tr>
			    <tr>
			        <td width="150">
			            <table border="0" cellpadding="5" cellspacing="0" width="100%">
				            <tr>
					            <td class="ms-sectionheader" style="padding-top: 0px;" height="2" valign="top">
					              <H3 class="ms-standardheader">E-Mail:</H3>
					            </td>
				            </tr>
			            </table>
			        </td>
			        <td class="ms-authoringcontrols ms-inputformcontrols" valign="top" align="left" >
			            <table cellpadding="5">
			                <tr>
			                    <td><font size="-1"><asp:Label ID="lblEmail" runat="server"></asp:Label></font></td>
			                </tr>
			            </table>
			        </td>
			    </tr>
			    <tr>
	                <td height="1" class="ms-sectionline" colspan="2"><IMG SRC="/_layouts/images/blank.gif" width="1" height="1" alt=""></td>
                </tr>
			    <tr>
			        <td width="300" valign="top">
			            <table border="0" cellpadding="5" cellspacing="0" width="100%">
				            <tr>
					            <td class="ms-sectionheader" style="padding-top: 0px;" height="2" valign="top">
					              <H3 class="ms-standardheader">Select Groups:</H3>
					            </td>
				            </tr>
				            <tr>
				                <td class="ms-descriptiontext">
				                    By default, the following security groups are available:<br />
                                    <b>Administrators:</b><br />
                                    <li>Full control of this site</li><br />
                                    <b>Project Managers</b><br />
                                    <li>Ability to create Workspaces</li><br />
                                    <li>Ability to create and edit List items</li><br />
                                    <b>Team Members</b><br />
                                    <li>Ability to create and edit List items</li>
				                </td>
				            </tr>
			            </table>
			        </td>
			        <td class="ms-authoringcontrols ms-inputformcontrols" valign="top" align="left" >
			            <table cellpadding="5">
			                <tr>
			                    <td><font size="-1">
			                        <asp:Panel ID="pnlGroups" runat="server">
			                        </asp:Panel>
			                        </font>
			                    </td>
			                </tr>
			            </table>
			        </td>
			    </tr>
                <tr>
	                <td height="1" class="ms-sectionline" colspan="2"><IMG SRC="/_layouts/images/blank.gif" width="1" height="1" alt=""></td>
                </tr>
        </table>
        <table cellpadding="0" cellspacing="3" width="100%">
	                <colgroup>
		                <col width="99%">
		                <col width="1%">
	                </colgroup>
	                <tr>
		                <td>
			                &nbsp;</td>
		                <td nowrap>
			                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Save"  class="ms-ButtonHeightWidth"/> 
			                <asp:Button ID="Button1" runat="server" OnClick="Button3_Click" Text="Cancel"  class="ms-ButtonHeightWidth"/>
		                </td>
	                </tr>
                </table>
    </asp:Panel>
</asp:Content>
