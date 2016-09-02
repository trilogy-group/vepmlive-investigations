<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveCore.tpsetup" MasterPageFile="~/_layouts/application.master"%> 

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	Time-Phased Setup
</asp:Content>
<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	Time-Phased Setup
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to manage your Time-Phased Settings.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">

    <asp:Panel ID="pnlAdmin" runat="server" Visible="false" Width="100%">
        Time-Phased data is being configured at another site.<br /><br />
        <asp:HyperLink Text="Click Here" NavigateUrl="" runat="server" ID="hlAdmin"></asp:HyperLink> to go there now.
    </asp:Panel>
    <asp:Panel ID="pnlFeature" runat="server" Visible="false" Width="100%">
        One or more lists appears to be missing. You may not have the feature activated. Would you like to activate the feature now?
        <br /><br />
        <asp:LinkButton runat="server" ID="lnkButton" OnClick="lnkButton_Click" Text="Activate Now"></asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="pnlMain" runat="server" Visible="true" Width="100%">
        <script language="javascript">
            function addPeriods()
            {
                    window.open('addperiods.aspx','', config='height=400,width=500, toolbar=no, menubar=no, scrollbars=no, resizable=yes,location=no, directories=no, status=yes');    
            }
            function addPeriod()
            {
                    window.open('addperiod.aspx','', config='height=270,width=400, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=yes');    
            }
            function addOutlineCode()
            {
                    window.open('addcode.aspx','', config='height=150,width=250, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=yes');    
            }
            function editOC(id)
            {
                    window.open('editcode.aspx?id=' + id,'', config='height=150,width=250, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=yes');    
            }
            function synchPeriods()
            {
                    window.open('synchperiods.aspx','', config='height=100,width=200, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=no');    
            }
        </script>
        <table class="ms-toolbar" width="100%" cellpadding="3">
            <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Value Types</h3></td></tr>
        </table>
        <table border="0">
            <tr>
                <td>
                    <font class="ms-sectionheader" style="font-size: XX-SMall">Available</font><br />
                    <asp:ListBox ID="lstAvailable" runat="server" Width="200" Height="100"></asp:ListBox>
                </td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text=" Add &gt; " OnClick="btnAdd_Click" CssClass="ms-buttonheightwidth"/><br /><br />
                    <asp:Button ID="btnDelete" runat="server" Text=" Remove &lt; " OnClick="btnDelete_Click" CssClass="ms-buttonheightwidth"/>
                </td>
                <td>
                    <font class="ms-sectionheader" style="font-size: XX-SMall">Currently Being Used</font><br />
                    <asp:ListBox ID="lstUsed" runat="server" Width="200" Height="100"></asp:ListBox>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table class="ms-toolbar" width="100%" cellpadding="3">
            <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Outline Codes</h3></td></tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td valign="top" style="padding-left: 7px;padding-top: 4px;padding-bottom: 4px;" class="ms-descriptiontext">
                    Outline codes are used to group information together in a Time-Phased report.
                </td>
            </tr>
            <tr>
                <td class="ms-gb">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                    OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" GridLines="None" CellPadding="0" CellSpacing="0">
                        <Columns>
                            <asp:BoundField DataField="type" HeaderText="Type" HeaderStyle-CssClass="ms-vh2-nofilter" ItemStyle-CssClass="ms-vb2"/>
                            <asp:BoundField DataField="field" HeaderText="Field Name" HeaderStyle-CssClass="ms-vh2-nofilter" ItemStyle-CssClass="ms-vb2"/>
                            <asp:BoundField DataField="disp" HeaderText="Display Name" HeaderStyle-CssClass="ms-vh2-nofilter" ItemStyle-CssClass="ms-vb2"/>
                            <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="top" HeaderStyle-CssClass="ms-vh2-nofilter" ItemStyle-CssClass="ms-vb2">
                                 <ItemTemplate>
                                   <asp:LinkButton ID="LinkButton2" 
                                     CommandArgument='<%# Eval("item_id") %>' 
                                     CommandName="Edi" runat="server">
                                     Edit</asp:LinkButton>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="top" HeaderStyle-CssClass="ms-vh2-nofilter" ItemStyle-CssClass="ms-vb2">
                                 <ItemTemplate>
                                   <asp:LinkButton ID="LinkButton1" 
                                     CommandArgument='<%# Eval("item_id") %>' 
                                     CommandName="Del" runat="server">
                                     Delete</asp:LinkButton>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="ms-vb2"/>
                        <AlternatingRowStyle CssClass="ms-alternating"/>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding=0 cellspacing=0 style="padding-left: 5px" >
						 <tr>
								<td valign=top style="padding-top:5px;" class="ms-descriptiontext" >
								<img src="/_layouts/images/setrect.gif" alt="">&nbsp;
								</td>
								<td nowrap class=ms-descriptiontext style="padding-top:7px;padding-left: 3px;">
								<a href="#" onclick="Javascript:addOutlineCode();">Add Outline Code</a>
								</td>
						</tr>
					</table>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table class="ms-toolbar" width="100%" cellpadding="3">
            <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Periods</h3></td></tr>
        </table>
         <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td valign=top style="padding-left: 7px;padding-top: 4px;padding-bottom: 4px;" class=ms-descriptiontext>
                    Periods are used to report time-phased data.
                </td>
            </tr>
            <tr>
                <td class="ms-gb">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%"
                        OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound" GridLines="None">
                            <Columns>
                                <asp:BoundField DataField="name" HeaderText="Period Name" HeaderStyle-CssClass="ms-vh2-nofilter" ItemStyle-CssClass="ms-vb2"/>
                                <asp:BoundField DataField="start" HeaderText="Start Date" HeaderStyle-CssClass="ms-vh2-nofilter" ItemStyle-CssClass="ms-vb2"/>
                                <asp:BoundField DataField="end" HeaderText="End Date" HeaderStyle-CssClass="ms-vh2-nofilter" ItemStyle-CssClass="ms-vb2"/>
                                <asp:BoundField DataField="capacity" HeaderText="Capacity" HeaderStyle-CssClass="ms-vh2-nofilter" ItemStyle-CssClass="ms-vb2"/>
                                     <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="top" HeaderStyle-CssClass="ms-vh2-nofilter" ItemStyle-CssClass="ms-vb2">
                                     <ItemTemplate>
                                       <asp:LinkButton ID="LinkButton1" 
                                         CommandArgument='<%# Eval("item_id") %>' 
                                         CommandName="Del" runat="server">
                                         Delete</asp:LinkButton>
                                     </ItemTemplate>
                                     </asp:TemplateField>
                            </Columns>
                        <RowStyle CssClass="ms-vb2"/>
                        <AlternatingRowStyle CssClass="ms-alternating"/>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" style="padding-left: 5px" >
						 <tr>
								<td valign="top" style="padding-top:5px;" class="ms-descriptiontext" >
								<img src="/_layouts/images/setrect.gif" alt="">&nbsp;
								</td>
								<td nowrap class="ms-descriptiontext" style="padding-top:7px;padding-left: 3px;">
								<a href="#" onclick="Javascript:addPeriod();">Add Period</a>
								</td>
						</tr>
						<tr>
								<td valign="top" style="padding-top:5px;" class="ms-descriptiontext" >
								<img src="/_layouts/images/setrect.gif" alt="">&nbsp;
								</td>
								<td nowrap class="ms-descriptiontext" style="padding-top:7px;padding-left: 3px;">
								<a href="#" onclick="Javascript:addPeriods();">Add Bulk Periods</a>
								</td>
						</tr>
						<tr>
								<td valign="top" style="padding-top:5px;" class="ms-descriptiontext" >
								<img src="/_layouts/images/setrect.gif" alt="">&nbsp;
								</td>
								<td nowrap class="ms-descriptiontext" style="padding-top:7px;padding-left: 3px;">
								<a href="#" onclick="javascript:synchPeriods();">Synchronize Periods</a>
								</td>
						</tr>
					</table>
                </td>
            </tr>
        </table>
   </asp:Panel> 
</asp:Content>