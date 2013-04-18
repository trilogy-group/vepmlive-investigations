<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveCore.adminfeatures" MasterPageFile="~/_admin/admin.master"%> 

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	WorkEngine Features
</asp:Content>
<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	WorkEngine Features
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to manage your WorkEngine Feature Keys.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">

<script language="javascript" >

    function managelic(feature) {

        var wurl = "users.aspx?feature=" + feature;

        var options = { url: wurl, width: 400, showClose: true, dialogReturnValueCallback: function (dialogResult) { SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.RefreshPage', dialogResult) } };

        SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);

    }

    function managelicv2(feature) {

        var wurl = "usersv2.aspx?feature=" + feature;

        var options = { url: wurl, width: 400, showClose: true, dialogReturnValueCallback: function (dialogResult) { SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.RefreshPage', dialogResult) } };

        SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);

    }

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
<style>
	.ms-viewheadertr
	{
	    height:20px !important; 
	    background-color: #f2f2f2 !important;
	}
    .ms-vh2-gridview
    {
        height:20px !important; 
	    background-color: #f2f2f2 !important;
    }

</style>

<table border="0" cellpadding="0" cellspacing="0" width="100%">

<tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
<tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Activated Keys</h3></td></tr>
</table></td></tr>

<tr>
    <td colspan="2">
    
        <SharePoint:SPGridView runat="server"
	     ID="GvItems"
	     AutoGenerateColumns="false"
	     width="100%">
        <Columns>
	        <SharePoint:SPMenuField HeaderText="Key" TextFields="feature" MenuTemplateId="PropertyNameListMenu" TokenNameAndValueFields="NAME=feature" ></SharePoint:SPMenuField>
	        <SharePoint:SPBoundField DataField="dtcreated" HeaderText="Date Created"></SharePoint:SPBoundField>
	        <SharePoint:SPBoundField DataField="expiration" HeaderText="Expiration Date"></SharePoint:SPBoundField>
	     </Columns>
	     <AlternatingRowStyle CssClass="ms-alternating" />
	     </SharePoint:SPGridView>
        <br /><br />
    </td>
</tr>
<tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
<tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Licenses</h3></td></tr>
</table></td></tr>
<tr>
    <td colspan="2">
        <table>
            <tr>
                <td style="width:400px">
                    <SharePoint:SPGridView runat="server"
	                 ID="gvFeatures"
	                 AutoGenerateColumns="false"
	                   RowStyle-Wrap="false"   >
                    <Columns>
	                    <SharePoint:SPMenuField HeaderText="License" TextFields="feature" MenuTemplateId="PropertyNameListMenu2" TokenNameAndValueFields="NAME=featureid" ></SharePoint:SPMenuField>
                        <SharePoint:SPBoundField DataField="quantity" HeaderText="Quantity"></SharePoint:SPBoundField>
	                    <SharePoint:SPBoundField DataField="active" HeaderText="Active"></SharePoint:SPBoundField>
	                 </Columns>
	                 <AlternatingRowStyle CssClass="ms-alternating" />
	                 </SharePoint:SPGridView>
                     <br /><br />
                </td>
             </tr>
         </table>
    </td>
</tr>
<tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
<tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Add Key</h3></td></tr>
</table></td></tr>
<tr>
    <td colspan="2"><br />
        Key: <input type="text" class="ms-input" id="txtKey" size="70"><br />
        <input type="button" value="Activate" class="ms-ButtonHeightWidth" Onclick="Javascript:submitKey();"/><br /><br>
        <b>Farm Guid:</b>
        <br />
        <asp:Label ID="lblFarmId" runat="server"></asp:Label>
        <br /><br />
        <asp:Label ID="lblWarning" runat="server"></asp:Label>
    </td>
</tr>
</table>

    
</asp:Content>