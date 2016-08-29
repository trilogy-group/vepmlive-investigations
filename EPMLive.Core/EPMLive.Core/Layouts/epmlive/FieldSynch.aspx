<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveCore.FieldSynchPage" MasterPageFile="~/_layouts/application.master" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ID="Content1" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="lt1" runat="server" text="List Synchronization" EncodeMethod='HtmlEncode'/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageTitleInTitleArea" runat="server">
	<SharePoint:FormattedStringWithListType ID="FormattedStringWithListType1" runat="server"
		String="List Synchronization:" LowerCase="false" />
    <asp:Label ID="lblListName" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="PlaceHolderMain" runat="server">   
         <asp:Panel ID="pnlResults" runat="server" Visible="false">
            <font class="ms-vb2">
                <asp:Label ID="lblResult" runat="server"></asp:Label>
            </font>
        </asp:Panel>
    <table >
    <tr>
        <td valign="top" align="left" >
        <SharePoint:SPGridView runat="server"
	     ID="GvFields"
	     AutoGenerateColumns="false"
	     style="width:200px"
	     AllowSorting="True"
	     AllowPaging="True"
	     DataKeyNames="InternalName"
	     PageSize="100" OnRowDataBound="GvFields_RowDataBound">
        <Columns>
            <SharePoint:SPBoundField DataField="DisplayName" HeaderText="Display Name" HeaderStyle-Font-Bold="true" AccessibleHeaderText="Display Name" ControlStyle-Width="150" ></SharePoint:SPBoundField>
            <SharePoint:SPBoundField DataField="InternalName" HeaderText="Internal Name" HeaderStyle-Font-Bold="true" ControlStyle-Width="150" ></SharePoint:SPBoundField>
            <asp:TemplateField headertext="Synchronize" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="center" >            
                <ItemTemplate>                
                    <asp:CheckBox id="chkSync" runat="server"></asp:CheckBox>                
                </ItemTemplate>        
            </asp:TemplateField>
            <asp:TemplateField headertext="Seal" HeaderStyle-Font-Bold="true">            
                <ItemTemplate>                
                    <asp:CheckBox id="chkSeal" runat="server"></asp:CheckBox>                
                </ItemTemplate>        
            </asp:TemplateField>
	     </Columns>
	     <AlternatingRowStyle CssClass="ms-alternating" />
	     </SharePoint:SPGridView>
        </td>
    </tr>
    </table>
    <br />
	 <br />
    <b>Enter sub site list name if different.</b>&nbsp;&nbsp;<asp:TextBox ID="txtToList" runat="server"></asp:TextBox>
	 <br />
	 <br />
     <asp:CheckBox id="chkCreateNewList" runat="server"></asp:CheckBox>&nbsp;&nbsp;Create new list if not exist.       
    <br />
	 <br />
    <div style="float:left;margin-top:10px;">
        <asp:Button ID="btnSynchronize" runat="server" Text="Synchronize" OnClick="btnSynchronize_Click" CssClass="ms-ButtonHeightWidth" />
        <asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="ms-ButtonHeightWidth" />
    </div> 
    <br />
    
</asp:Content>
