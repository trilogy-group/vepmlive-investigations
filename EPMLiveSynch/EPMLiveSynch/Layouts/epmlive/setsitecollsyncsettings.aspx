<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="setsitecollsyncsettings.aspx.cs" Inherits="EPMLiveSynch.Layouts.epmlive.setsitecollsyncsettings" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="Edit Site Collection Sync Settings" EncodeMethod='HtmlEncode'/>
</asp:Content>

<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	<asp:Label ID="lblTitle" runat="server" Text="Template Synchronization"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
<META HTTP-EQUIV="CACHE-CONTROL" CONTENT="NO-CACHE">
<% Response.CacheControl = "no-cache"; %>
<% Response.Expires = -1; %>

    <script language="javascript" >
        var tmpltgrid;
        function URLEncode(plaintext) {
            // The Javascript escape and unescape functions do not correspond
            // with what browsers actually do...
            var SAFECHARS = "0123456789" + 				// Numeric
					        "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + // Alphabetic
					        "abcdefghijklmnopqrstuvwxyz" +
					        "-_.!~*'()"; 				// RFC2396 Mark characters
            var HEX = "0123456789ABCDEF";

            var encoded = "";
            for (var i = 0; i < plaintext.length; i++) {
                var ch = plaintext.charAt(i);
                if (ch == " ") {
                    encoded += "+"; 			// x-www-urlencoded, rather than %20
                } else if (SAFECHARS.indexOf(ch) != -1) {
                    encoded += ch;
                } else {
                    var charCode = ch.charCodeAt(0);
                    if (charCode > 255) {
                        alert("Unicode Character '"
                                + ch
                                + "' cannot be encoded using standard URL encoding.\n" +
				                  "(URL encoding only supports 8-bit characters.)\n" +
						          "A space (+) will be substituted.");
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

        function newWin(url) {
            window.open(url, '', config = 'height=500,width=800, toolbar=no, menubar=no, scrollbars=no, resizable=yes,location=no, directories=no, status=yes');
        }
        function getWidth() {
            var winW = 800;
            if (parseInt(navigator.appVersion) > 3) {
                if (navigator.appName == "Netscape") {
                    winW = window.innerWidth;
                    //winH = window.innerHeight;
                }
                if (navigator.appName.indexOf("Microsoft") != -1) {
                    winW = document.body.offsetWidth;
                    //winH = document.body.offsetHeight;
                }
            }
            return winW;
        }
        function getScrollTopPos() {
            var winW = 0;
            if (parseInt(navigator.appVersion) > 3) {
                if (navigator.appName == "Netscape") {
                    winW = window.pageXOffset;
                }
                if (navigator.appName.indexOf("Microsoft") != -1) {
                    winW = document.body.scrollTop;
                }
            }
            return winW;
        }
        function getWidth() {
            var winW = 800;
            if (parseInt(navigator.appVersion) > 3) {
                if (navigator.appName == "Netscape") {
                    winW = window.innerWidth;
                }
                if (navigator.appName.indexOf("Microsoft") != -1) {
                    winW = document.body.offsetWidth;
                }
            }
            return winW;
        }
        function getHeight() {
            var winH = 600;
            if (parseInt(navigator.appVersion) > 3) {
                if (navigator.appName == "Netscape") {
                    winH = window.innerHeight;
                }
                if (navigator.appName.indexOf("Microsoft") != -1) {
                    winH = document.body.offsetHeight;
                }
            }
            return winH;
        }
        function getScrollTopPos() {
            var winW = 0;
            if (parseInt(navigator.appVersion) > 3) {
                if (navigator.appName == "Netscape") {
                    winW = window.pageXOffset;
                }
                if (navigator.appName.indexOf("Microsoft") != -1) {
                    winW = document.body.scrollTop;
                }
            }
            return winW;
        }

        function noteChange(sSiteID, sChangeType, sCtlID, sCtlVal) {
            var sChangedItems = document.getElementById("hdnChangedSettings").value;
            var arrChangedItems = sChangedItems.split("`");
            var bReplaced = 0;
            for (i = 0; i < arrChangedItems.length; i++) {
                var sItem = arrChangedItems[i];
                if (sItem.indexOf(sSiteID + "," + sChangeType) == 0) {
                    document.getElementById("hdnChangedSettings").value = sChangedItems.replace(sItem, sSiteID + "," + sChangeType + "," + sCtlVal);
                    bReplaced = 1;
                }
                sItem = "";
            }

            if (bReplaced == 0) {
                document.getElementById("hdnChangedSettings").value += sSiteID + "," + sChangeType + "," + sCtlVal + "`";
            }
        }

    </script>
    <link rel="stylesheet" href="/_layouts/epmlive/modal/modal.css" type="text/css" />
    <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.css"/>
    <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid_skins.css"/>
    <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxcommon.js"></script>
    <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.js"></script>
    <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxgridcell.js"></script>
    <script src="/_layouts/epmlive/DHTML/xtreegrid/dhtmlxtreegrid.js"></script>
    <script type="text/javascript" src="/_layouts/epmlive/modal/modal.js"></script>
    <script src="/_layouts/epmlive/DHTML/dhtmlxajax.js"></script>
    <asp:Panel ID="Panel1" runat="server" Visible="true" Width="100%">
        <div id="SitesGrid" style="" >
            <table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
                <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Site Collection Sync Settings</h3></td></tr>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" width="650px">
                <tr>
                    <td class="ms-gb">
                        <SharePoint:SPGridView runat="server"
                         ID="gvSites"
                         AutoGenerateColumns="false"
                         style="width:100%"
                         OnRowDataBound="gvSites_RowDataBound">
                        <Columns>
                            <SharePoint:SPBoundField DataField="Site" HeaderText="Sites" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="left" AccessibleHeaderText="Sites" ControlStyle-Width="300" ></SharePoint:SPBoundField>
                            <asp:TemplateField headertext="Allow Sync" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" ControlStyle-Width="50px" >       
                                <ItemTemplate>                
                                    <asp:CheckBox id="chkAllowSync" Wrap="true" Width="50px" Style="overflow:hidden" ReadOnly="true" BackColor="Transparent" BorderStyle="None" BorderWidth="0" runat="server" ></asp:CheckBox>                
                                </ItemTemplate>        
                            </asp:TemplateField>

                            <SharePoint:SPBoundField DataField="SiteID" ControlStyle-Width="0" Visible="false" ></SharePoint:SPBoundField>
                         </Columns>
                         <AlternatingRowStyle CssClass="ms-alternating" />
                         </SharePoint:SPGridView>
                         <input type="hidden" name="hdnChangedSettings" id="hdnChangedSettings" />
                    </td>
                </tr>
                <wssuc:ButtonSection runat="server">
                    <Template_Buttons>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
	                        <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="btnSave_Click" Text="Save Settings" id="btnSave" accesskey="" Width="150"/>
                        </asp:PlaceHolder>
                    </Template_Buttons>
                </wssuc:ButtonSection>
                <wssawc:FormDigest ID="FormDigest1" runat="server" />
            </table>
        </div>
      
   </asp:Panel> 
</asp:Content>