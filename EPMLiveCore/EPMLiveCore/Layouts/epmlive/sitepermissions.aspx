<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sitepermissions.aspx.cs" Inherits="EPMLiveCore.sitepermissions" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="Manage Site Permissions" EncodeMethod='HtmlEncode'/>
</asp:Content>
<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	<asp:Label ID="lblTitle" runat="server" Text="Add Resource"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
<asp:Panel ID="Panel4" runat="server" Visible="true">
    <asp:Label ID="lblDesc" runat="server">
        
    </asp:Label>
</asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">

<style>
    .header
    {
	    text-align:left;
	    line-height:14pt;
	    font-family:"Segoe UI", Tahoma, Verdana, Arial, Sans-Serif;
	    letter-spacing:0.03em;
	    color:#FFFFFF;
	    font-size:10pt;
	    font-weight: normal;
 
    }
.row
{
	text-align:left;
	line-height:14pt;
	font-family:"Segoe UI", Tahoma, Verdana, Arial, Sans-Serif;
	letter-spacing:0.03em;
	color:#43515B;
	background:fff;
	font-size:10pt;
	font-weight: normal;
 
}
 
.row a
{
	text-align:left;
	line-height:14pt;
	font-family:"Segoe UI", Tahoma, Verdana, Arial, Sans-Serif;
	letter-spacing:0.03em;
	color:#0072D3;
	text-decoration: none;
	background:fff;
	font-size:10pt;
	font-weight: normal;
 
}
.alter
{
	text-align:left;
	line-height:14pt;
	font-family:"Segoe UI", Tahoma, Verdana, Arial, Sans-Serif;
	letter-spacing:0.03em;
	color:#43515B;
	background:#F4F5F6;
	font-size:10pt;
	font-weight: normal;
 
}
 
.alter a
{
	text-align:left;
	line-height:14pt;
	font-family:"Segoe UI", Tahoma, Verdana, Arial, Sans-Serif;
	letter-spacing:0.03em;
	color:#0072D3;
	text-decoration: none;
	background:#F4F5F6;
	font-size:10pt;
	font-weight: normal;
 
}

</style>
    <asp:Panel ID="pnl" runat="server">
        <asp:HiddenField ID="hdnAccountId" runat="server" />
        <asp:HiddenField ID="hdnUserId" runat="server" />
    <table width="100%" cellpadding="0" cellspacing="0">
        
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" height="40px" bgcolor="#F0F3F7">
                    <tr>
                        <td valign="middle">
                            <a href = "AddUsers.aspx">Add Users</a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" Width="100%" HeaderStyle-Font-Bold="false"
                    OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" HeaderStyle-CssClass="header" HeaderStyle-BackColor="#93A1AA">
                    <Columns>
			<asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="top" ItemStyle-Width="50">
                         <ItemTemplate>
                           <img src="/_layouts/images/o14_person_placeholder_42.png" height="42px"/>
                         </ItemTemplate>
                         </asp:TemplateField>

                        <asp:BoundField DataField="name" HeaderText="Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top"/>
                        <asp:BoundField DataField="email" HeaderText="E-Mail" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top"/>
                        <asp:BoundField DataField="group" HeaderText="Groups" HeaderStyle-HorizontalAlign="Left" HtmlEncode="false" />
                        <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="top">
                         <ItemTemplate>
                           <asp:LinkButton ID="LinkButton2" 
                             CommandArgument='<%# Eval("username") %>' 
                             CommandName="Edi" runat="server">
                             View/Edit</asp:LinkButton>
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
                    <RowStyle cssclass="row"/>
                    <AlternatingRowStyle cssclass="alter"/>
                </asp:GridView>

<table cellspacing="0" cellpadding="0" border="0" id="" width="100%">
			<tr height="5" bgcolor="#93A1AA"><td colspan="6"></td></tr>
			</table>

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
					              <H3 class="ms-standardheader">Username:</H3>
					            </td>
				            </tr>
			            </table>
			        </td>
			        <td class="ms-authoringcontrols ms-inputformcontrols" valign="top" align="left" >
			            <table cellpadding="5">
			                <tr>
			                    <td><font size="-1"><asp:Label ID="lblUsername" runat="server"></asp:Label></font></td>
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