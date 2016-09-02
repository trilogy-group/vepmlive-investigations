<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewts.aspx.cs" Inherits="TimeSheets.viewts" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="View Period Timesheets" EncodeMethod='HtmlEncode'/>
</asp:Content>
<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	<asp:Label ID="lblTitle" runat="server" Text="View Timesheets for Period: "></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to view the timesheets for a period
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">

<asp:Panel ID="pnlActivation" runat="server" Visible="false" Width="100%">
    You have not purchased or activated the Timesheet feature. Please contact sales to purchase licenses.
    <br><br><b>Sales:</b><br>
    E: <a href="mailto:sales@epmlive.com">sales@epmlive.com</a><br>
    P: 866-391-3700
</asp:Panel>
<asp:Panel ID="pnlTs" runat="server" Visible="true" Width="100%">
    <div id="timeeditorgrid" style="display:none; border: 1px solid #808080; padding: 3px; background-color: #F9F9F9; width:200px;height:160px; Z-Index:99;">
            <div id="timeeditor" style="width: 100%; height: 100%;  background-color: #FFFFFF; border: 1px solid #808080; padding:5px;" class="ms-descriptiontext">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <%=sTimeEditor %>               
                </table>
        </div>
        <table border="0" width="100%">
            <tr>
                <td align="right">
                    <font class="ms-descriptiontext"><a href="Javascript:void(0);" onclick="javascript:mygrid.editStop();">Close</a></font>
                </td>
            </tr>
        </table>
    </div>
            <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid.css"/>
            <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid_skins.css"/>
            <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/dhtml/calendar/dhtmlxcalendar.css"/>

            <script>                _css_prefix = "/_layouts/epmlive/DHTML/xgrid/"; _js_prefix = "/_layouts/epmlive/DHTML/xgrid/"; </script>
            <link rel="stylesheet" href="/_layouts/epmlive/modal/modalmain.css" type="text/css" /> 
            <script type="text/javascript" src="/_layouts/epmlive/modal/modal.js"></script>
            <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxcommon.js"></script>
            <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.js"></script>
            <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxgridcell.js"></script>
            <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid_post.js"></script>

            <script src="/_layouts/epmlive/DHTML/xtreegrid/dhtmlxtreegrid.js"></script>
            <script src="/_layouts/epmlive/DHTML/xtreegrid/ext/dhtmlxtreegrid_filter.js"></script>

            <script src="/_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_nxml.js"></script>
            <script src="/_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_filter.js"></script>
            <script src="/_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_math.js"></script>
            <script src="/_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_srnd.js"></script>

            <script src="/_layouts/epmlive/DHTML/xcombo/dhtmlxcombo.js"></script>


            <script language="JavaScript" src="/_layouts/epmlive/dhtml/xmenu/dhtmlxprotobar.js"></script>
            <script language="JavaScript" src="/_layouts/epmlive/dhtml/xmenu/dhtmlxmenubar.js"></script>
            <script language="JavaScript" src="/_layouts/epmlive/dhtml/xmenu/dhtmlxmenubar_cp.js"></script>

            <script src="/_layouts/epmlive/viewts.js"></script>
            
            <div id="tsnotesgrid" style="display:none; border: 1px solid #808080; padding: 3px; background-color: #F9F9F9; width:200px;height:100px">
                <textarea id="tsnotes" cols="30" rows="6" class="ms-input" disabled="true"></textarea>
                <table border="0" width="200">
                    <tr>
                        <td align="right">
                            <font class="ms-descriptiontext"><a href="javascript:mygrid.editStop();">Close</a></font>
                        </td>
                    </tr>
                </table>
            </div>

            <div id="dlgProcessing" class="dialog"><table width="100%"><tr><td align="center" class="ms-sectionheader"><img src="/_layouts/images/gears_anv4.gif" style="vertical-align: middle;"/><br /><H3 class="ms-standardheader">Processing Timesheets...</h3></td></tr></table></div>
            	    
		    <asp:Panel ID="pnlActionsToolbar" runat="server"></asp:Panel>
            <div id="grid" style="width:100%;display:none;" ></div>

            <div  width="100%" id="loadinggrid" align="center">
                <img src="/_layouts/images/gears_anv4.gif" style="vertical-align: middle;"/> Loading Resources...
            </div>
            
            <script language="javascript">
                var weburl = "<%=weburl %>";
                mygrid = new dhtmlXGridObject('grid');
                mygrid.setImagePath("/_layouts/epmlive/dhtml/xgrid/imgs/");
                mygrid.setSkin("timesheet");
                mygrid.enableAutoHeigth(true);
                mygrid.setImageSize(1, 1);
                mygrid.enableTreeCellEdit(false);
                mygrid.enableEditEvents(true, false, false);
                mygrid.setDateFormat("%m/%d/%Y");
                mygrid.enableSmartXMLParsing(false);
                mygrid.attachEvent("onXLE", clearLoader);
                mygrid.init();

                function clearLoader(id) {
                    document.getElementById("grid").style.display = "";
                    document.getElementById("loadinggrid").style.display = "none";
                }

                initmb();

                mygrid.loadXML("<%=loadUrl %>");
                //output.Write("mygrid.loadXML(\"" + resWeb.Url + "/_layouts/epmlive/gettsapprovals.aspx?view=" + reslist.DefaultView.Title.Replace(" ", "%20") + "&period=" + intPeriod.ToString() + "&gridname=" + sFullGridId + "&source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "\");");
                
            </script>
</asp:Panel>
    
</asp:Content>