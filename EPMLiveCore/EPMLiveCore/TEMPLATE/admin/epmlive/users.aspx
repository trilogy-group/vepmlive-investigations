<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveCore.adminusers" MasterPageFile="~/_admin/admin.master"%> 

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	WorkEngine Active Users
</asp:Content>
<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	WorkEngine Active Users
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to manage your WorkCenter Active Users.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">

<script language="javascript" >
    function submitKey()
    {
        var key = document.getElementById("txtKey").value;
        window.open('addkey.aspx?key=' + URLEncode(key),'', config='height=100,width=200, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=no');    
    }
    function URLEncode(plaintext )
{
	// The Javascript escape and unescape functions do not correspond
	// with what browsers actually do...
	var SAFECHARS = "0123456789" +					// Numeric
					"ABCDEFGHIJKLMNOPQRSTUVWXYZ" +	// Alphabetic
					"abcdefghijklmnopqrstuvwxyz" +
					"-_.!~*'()";					// RFC2396 Mark characters
	var HEX = "0123456789ABCDEF";

	var encoded = "";
	for (var i = 0; i < plaintext.length; i++ ) {
		var ch = plaintext.charAt(i);
	    if (ch == " ") {
		    encoded += "+";				// x-www-urlencoded, rather than %20
		} else if (SAFECHARS.indexOf(ch) != -1) {
		    encoded += ch;
		} else {
		    var charCode = ch.charCodeAt(0);
			if (charCode > 255) {
			    alert( "Unicode Character '" 
                        + ch 
                        + "' cannot be encoded using standard URL encoding.\n" +
				          "(URL encoding only supports 8-bit characters.)\n" +
						  "A space (+) will be substituted." );
				encoded += "+";
			} else {
				encoded += "%";
				encoded += HEX.charAt((charCode >> 4) & 0xF);
				encoded += HEX.charAt(charCode & 0xF);
			}
		}
	} // for

	return encoded;
};
</script>

<asp:Label ID="lblError" Visible="false" runat="server" Text="Label"></asp:Label>
Feature: <%=sFeature %>
<br /><br />
<b>Usage: </b><asp:Label ID="lblUsage" runat="server" Text="Label"></asp:Label> / <asp:Label ID="lblMaxUsers" runat="server" Text="Label"></asp:Label>
    <SharePoint:SPGridView runat="server"
	 ID="GvItems"
	 AutoGenerateColumns="false"
	 style="width:200px">
    <Columns>
	    <SharePoint:SPMenuField HeaderText="User" TextFields="username" MenuTemplateId="PropertyNameListMenu" TokenNameAndValueFields="NAME=encusername"  ></SharePoint:SPMenuField>
	 </Columns>
	 <AlternatingRowStyle CssClass="ms-alternating" />
	 </SharePoint:SPGridView>
    <br />
    <asp:Label ID="lblConnError" runat="server" Text="" ForeColor="Red" Visible ="false" ></asp:Label>
</asp:Content>