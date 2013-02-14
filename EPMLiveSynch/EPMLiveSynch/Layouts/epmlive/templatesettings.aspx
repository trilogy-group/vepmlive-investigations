<%@ Assembly Name="EPMLiveSynch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveSynch.TemplateSettingsPage" MasterPageFile="~/_layouts/application.master"%> 

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="Manage Template Settings" EncodeMethod='HtmlEncode'/>
</asp:Content>

<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	<asp:Label ID="lblTitle" runat="server" Text="EPM Live Template Settings"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
    <script language="javascript" >
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

        function getWidth()
        {
            var winW = 800;
            if (parseInt(navigator.appVersion)>3) {
             if (navigator.appName=="Netscape") {
              winW = window.innerWidth;
              //winH = window.innerHeight;
             }
             if (navigator.appName.indexOf("Microsoft")!=-1) {
              winW = document.body.offsetWidth;
              //winH = document.body.offsetHeight;
             }
            }
            return winW;
        }
        function getScrollTopPos()
        {
            var winW = 0;
            if (parseInt(navigator.appVersion)>3) {
             if (navigator.appName=="Netscape") {
              winW = window.pageXOffset;
             }
             if (navigator.appName.indexOf("Microsoft")!=-1) {
              winW = document.body.scrollTop;
             }
            }
            return winW;
        }

    </script>
    <link rel="stylesheet" href="modal/modal.css" type="text/css" />
    <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.css"/>
    <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid_skins.css"/>
    <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxcommon.js"></script>
    <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.js"></script>
    <script src="/_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_filter.js"></script>
    <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxgridcell.js"></script>
    <script src="/_layouts/epmlive/DHTML/xtreegrid/dhtmlxtreegrid.js"></script>
    <script type="text/javascript" src="modal/modal.js"></script>
    <script src="DHTML/dhtmlxajax.js"></script>
    <asp:Panel ID="Panel1" runat="server" Visible="true" Width="100%">
        <table class="ms-toolbar" width="100%" cellpadding="3">
            <tr><td class="ms-linksectionheader"><h3 class="ms-standardheader">Templates</h3></td></tr>
        </table>
        <div id="TemplateList" style="">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <% string sSiteUrl = SPContext.Current.Web.Url; %>
                        <input type="hidden" name="SiteURL" value="<% Response.Write(sSiteUrl); %>" />
                        <script>_css_prefix="/_layouts/epmlive/DHTML/xgrid/"; _js_prefix="/_layouts/epmlive/DHTML/xgrid/"; </script>
                        <div id="grid" style="width:100%;display:none;" ></div>
                        <div id="loadinggrid" width="100%" align="center">
                        <img src="/_layouts/images/GEARS_AN.GIF" style="vertical-align: middle;"/> Loading Items...
                        </div>
                        <script>
                            var sSiteURL = document.getElementById("SiteURL").value;
                            mygrid = new dhtmlXGridObject('grid');
                            mygrid.setImagePath('/_layouts/epmlive/DHTML/xgrid/imgs/');
                            mygrid.setSkin('modern');
                            mygrid.setImageSize(16,16);
                            mygrid.setColAlign("left,center")
                            mygrid.attachEvent('onXLE',clearLoader);
                            mygrid.enableAutoHeigth(true);
                            mygrid.enableTreeCellEdit(false);
                            mygrid.init();
                            mygrid.loadXML(sSiteURL + '/_layouts/epmlive/gettemplatesettingsxml.aspx');
                            
                            mygrid.attachEvent("onCheck", doOnCheck);

                            function uncheckparent(rowId)
                            {
                                  try{
                                        var parent = mygrid.getParentId(rowId);
                                        if(parent != '0')
                                        {
                                              mygrid.cells(parent,0).setValue(0);
                                              uncheckparent(parent);
                                        }
                                  }
                                  catch(e)
                                  {
                                        alert(e);
                                  }
                            }

                            function doOnCheck(rowId,cellInd,state)
                            {
                                  try
                                  {
                                        var rows = mygrid.getAllSubItems(rowId);
                                        var arrRows = rows.split(',');
                                        var curVal = mygrid.cells(rowId,0).getValue();
                                        if(arrRows != '')
                                        {
                                              for(var i = 0;i < arrRows.length;i++)
                                              {
                                                    mygrid.cells(arrRows[i],0).setValue(curVal);
                                              }
                                        }
                                        if(curVal == '0')
                                        {
                                              uncheckparent(rowId);
                                        }
                                  }
                                  catch(e)
                                  {
                                        alert(e);
                                  }
                            }

                            function clearLoader(id)
                            { 
                                document.getElementById("grid").style.display = "";
                                document.getElementById("loadinggrid").style.display = "none";
                            }
                            
                            function checkRootRow()
                            {
                                //var rootRow = mygrid.selectRowById(rootRowId,false,false,false);
                                var rootRowId = document.getElementById("RootRowId").value;
                                var curVal = mygrid.cells(rootRowId,0).getValue();
                            }
                            function getCheckedItems()
                            {
                                bRet = confirm('Are you sure you want to synchronize this template to all sites associated with it now?');
                                if (bRet == true)
                                {
	                                sm('dlgSynchronizing',200,100);
                                    var rootRowId = document.getElementById("RootRowId").value;
                                    var curVal = mygrid.cells(rootRowId,0).getValue();

                                    var arrRows = mygrid.getCheckedRows(0).split(',');
                                    var EPMLiveTemplateSyncSettings = "";
                                    var sList = "";
                                    for(var i = 0;i < arrRows.length;i++)
                                    {
                                        try
                                        {
                                            if (arrRows[i].indexOf("-") > 0)
                                            {
                                                var arrItem = arrRows[i].split('-');
                                                sList = arrItem[0];
                                                if (sList.indexOf("/") < 0)
                                                {
                                                    var sSyncItemKey = mygrid.getUserData(arrRows[i],"key");
                                                    if (EPMLiveTemplateSyncSettings.indexOf("LIST:" + sList) > 0)
                                                    {
                                                        EPMLiveTemplateSyncSettings += sSyncItemKey;
                                                    }
                                                    else
                                                    {
                                                        EPMLiveTemplateSyncSettings += "<br>LIST:" + sList + sSyncItemKey;
                                                    }
                                                }
                                            }
                                        }
                                        catch(e) { }
                                    }
                                    document.getElementById("EPMLiveTemplateSyncSettings").value = EPMLiveTemplateSyncSettings;

                                    //document.getElementById("ctl00$PlaceHolderMain$btnSync").disabled = true;
                                    document.getElementById("ctl00$PlaceHolderMain$btnCancel").disabled = true;
                                }
                                return bRet;
                           }
                        </script>
                    </td>
                </tr>
			     <tr>
				    <td nowrap class="ms-descriptiontext" align="left" style="padding-top:7px;padding-left: 3px;">
				    </td>
			    </tr>
            </table>
        </div> 
        <div id="dlgSynchronizing" class="dialog">
            <table width="100%">
                <tr>
                    <td align="center" class="ms-sectionheader">
                        <img src="../images/GEARS_AN.GIF" style="vertical-align: middle;"/><br />
                        <H3 class="ms-standardheader">Synchronizing...</h3>
                    </td>
                </tr>
                
            </table>
        </div>
    <script>
       initmb();
    </script>
   </asp:Panel> 
    <div style="float:left;margin-top:10px;">
        <input type=hidden name="EPMLiveTemplateSyncSettings" value="" />
        <% string sRootRowId = SPContext.Current.Web.ServerRelativeUrl + "/Lists"; %>
        <input type="hidden" name="RootRowId" value="<% Response.Write(sRootRowId); %>" />
        <asp:Button ID="btnSync" runat="server" OnClientClick="return getCheckedItems();" Text="Synchronize" OnClick="btnSync_Click" CssClass="ms-ButtonHeightWidth" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="ms-ButtonHeightWidth" />
    </div>    
</asp:Content>