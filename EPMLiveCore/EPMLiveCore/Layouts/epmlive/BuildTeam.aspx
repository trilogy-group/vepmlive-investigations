<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuildTeam.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.BuildTeam" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script type="text/javascript" src="TreeGrid/GridE.js"> </script>
    <script type="text/javascript" src="BuildTeam.js"> </script>
    <script type="text/javascript" src="DHTML/xgrid/dhtmlxcommon.js"></script>
    <script type="text/javascript" src="dhtml/xlayout/dhtmlxlayout.js"></script>
    <script type="text/javascript" src="dhtml/xlayout/dhtmlxcontainer.js"></script>

    <link rel="stylesheet" type="text/css" href="stylesheets/buildteam.css" />

    <!--[if IE]>
    <link rel="stylesheet" type="text/css" href="stylesheets/buildteamIE.css" />
    <![endif]-->

    <link rel="stylesheet" type="text/css" href="stylesheets/buttons.css" />
    <link rel="stylesheet" type="text/css" href="dhtml/xlayout/dhtmlxlayout.css" />
    <link rel="stylesheet" type="text/css" href="dhtml/xlayout/skins/dhtmlxlayout_dhx_skyblue.css" />

    <style type="text/css">
        .GSEditReadOnly {
            background-color: #FFFFFF !important;
        }

        .GSColorReadOnly {
            background-color: #FFFFFF !important;
        }

        .GSColorHoveredCellReadOnly {
            background-color: #FFFFFF !important;
        }

        #s4-ribbonrow {
            height: 140px !important;
        }


        a, .ms-link:visited {
            color: #555555;
            text-decoration: none;
        }
    </style>

    <link rel="stylesheet" href="modal/modal.css" type="text/css" />
    <script type="text/javascript" src="modal/modal.js"></script>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    <table style="width: 100%; height: 100%" id="parentId">
        <tr>
            <td width="50%" valign="top" id="tdTeam">
                <div class="gridHeader">Current Team</div>
                <div class="toolbar">
                    <ul>
                        <li>
                            <a href="javascript:void(0);" onclick="AddTeamColumns(this)" data-toggle="tooltip" data-placement="bottom" data-delay="100" title="Select Columns"><span class="icon-table"></span></a>
                        </li>
                        <li>
                            <a href="javascript:void(0);" onclick="TeamFilters(this)" data-toggle="tooltip" data-placement="bottom" data-delay="100" title="Show/Hide Filters"><span class="icon-filter-2"></span></a>
                        </li>
                        <li>
                            <a href="javascript:void(0);" onclick="TeamGroups(this)" data-toggle="tooltip" data-placement="bottom" data-delay="100" title="Show/Hide Grouping"><span class="icon-indent-increase-2"></span></a>
                        </li>
                    </ul>
                </div>
                <div id="divTeam">
                    Loading...
                </div>
            </td>
            <%=sResPool%>
        </tr>
    </table>

    <script language="javascript">


        function ShowDisable()
        {
            var box = SP.UI.Status.addStatus('Build Team:', 'Build team is currently disabled. The list below is of all the resources in the resource pool.', true);
            SP.UI.Status.setStatusPriColor(box, 'blue');
        }

        function getTop(obj) {
            var posY = obj.offsetTop;

            while (obj.offsetParent) {
                posY = posY + obj.offsetParent.offsetTop;
                if (obj == document.getElementsByTagName('body')[0]) { break }
                else { obj = obj.offsetParent; }
            }

            return posY;
        }



        var canAddResource = <%=bCanAddResource %>;
        var newResUrl = "<%=sNewResUrl %>";
        var bCanEditTeam = <%=bCanEditTeam %>;
        var bCanAccessResourcePool = <%=bCanAccessResourcePool %>;
        var sUserInfoList = "<%=sUserInfoList %>";
        var sDefaultGroup = "<%=sDefaultGroup %>";
        var sListId = "<%=Request["listid"] %>";
        var sItemId = "<%=Request["id"] %>";
        var scrollTimeout;

        function Close()
        {
            <%=sClose %>
        }

        function getWidth() {
            var scnWid;
            if (self.innerHeight) // all except Explorer
            {
                scnWid = self.innerWidth;
                //scnHei = self.innerHeight;
            }
            else if (document.documentElement && document.documentElement.clientHeight) {
                scnWid = document.documentElement.clientWidth;
                //scnHei = document.documentElement.clientHeight;
            }
            else if (document.body) // other Explorers
            {
                scnWid = document.body.clientWidth;
                //scnHei = document.body.clientHeight;
            }
            return scnWid;
        }

        function resizewindow()
        {
            
        }

        var addEvent = function(elem, type, eventHandle) 
        {     
            if (elem == null || elem == undefined) 
                return;     
                
            if ( elem.addEventListener ) 
            {        
                elem.addEventListener( type, eventHandle, false );
            }
            else if ( elem.attachEvent )
            {         
                elem.attachEvent( "on" + type, eventHandle );     
            }
            else 
            {        
                elem["on"+type]=eventHandle;     
            } 
        }; 

        addEvent(window, "resize", resizewindow);
        

        function doLoad()
        {

            setHeight();

            //setTimeout("sm('dlgLoading', 130, 50);", 100);
           
            setTimeout("loadGrids()", 1000);
            
        }

        function loadGrids()
        {
	        <%=sResGrid%>

            TreeGrid(   { 
                Layout:{ Url:"../../_vti_bin/WorkEngine.asmx", Method:"Soap",Function:"Execute",Namespace:"workengine.com",Param:{Function:"GetTeamGridLayout",Dataxml:"<%=sLayoutParam %>" } } ,
                Data:{ Url:"../../_vti_bin/WorkEngine.asmx", Method:"Soap",Function:"Execute",Namespace:"workengine.com",Param:{Function:"GetTeamGridData",Dataxml:"<%=sLayoutParam %>" } }, 
                Debug:"",SuppressMessage:"3"
            }, 
	        "divTeam" );
        }


        if (window.addEventListener)
            window.addEventListener('resize', setHeight, false);
        else if (window.attachEvent)
            window.attachEvent('onresize', setHeight);

        var renderCount = 0;
        var updatedGridCount = 0;


        function gridsloaded()
        {
            try {
                CheckAddRemoveButtons();
            } catch (e) { }
            try {
                //ShowPool();
                if(!bCanEditTeam)
                {
                    Grids.TeamGrid.HideCol("Permissions");
                }
            } catch (e) { }
            hm("dlgLoading");
            RefreshCommandUI();
        }


        Grids.OnRenderFinish = function (grid) {
            renderCount++;

            if (renderCount == Grids.length) {
                setTimeout("gridsloaded()", 200);

                //$(".GMHeadLeft").find("th:nth-child(2)" ).css("width","25px");
                //$(".GMBodyLeft").find("th:nth-child(2)" ).css("width","25px");
            }
            else if (renderCount > Grids.length)
            {
                try {
                    RemoveResources();
                } catch (e) { }
                try {
                    CheckAddRemoveButtons();
                } catch (e) { }
            }
            else
            {
                var pct = renderCount/Grids.length*100;
                document.getElementById("tdPctFull").style.display = "";
                document.getElementById("tdPctFull").style.width = parseInt(pct) + "%";
            }
        }

        Grids.OnCreateGroup = function(grid, group, col, val) 
        {
            if(val == "")
                grid.SetValue(group, "Title", "No " + col, 1, 0);
        }

        Grids.OnGetHtmlValue = function(grid, row, col, val)    
        {
            if(row.Kind == "Data" && row.Def.Name != "Group")
            {
                if(col == "Title")
                {
                    return "<a href=\"Javascript:ShowUserPopup('" + grid.GetValue(row, "SPAccountInfo") + "');\">" + val + "</a>";
                }
                if(col == "Permissions")
                {
                    if(val == "" && row.Generic != "Yes")
                        return "--Select Permissions--";
                }
            }
        }

        Grids.OnFocus = function (grid, row, col, orow, ocol, pagepos) {
            try {
                CheckAddRemoveButtons();
            } catch (e) { }

            grid.SelectAllRows(false);

            grid.SelectRow(row, true);

            RefreshCommandUI();
        }

        Grids.OnSelect = function(grid, row, deselect)        
        {
            try {
                setTimeout("CheckAddRemoveButtons()", 200);
            } catch (e) { }
        }
        

        Grids.OnCanEdit = function(grid, row, col, mode)
        {
            if(col == "Permissions")
            {
                if(row.Generic == "Yes")
                    return 0;
                else
                    return mode;
            }
            return mode;
        }
    
        Grids.OnAfterValueChanged = function(grid, row, col, val)
        {
            if(col == "Permissions")
            {
                isDirty = true;
                EnableDisableSaveButton();
                gridsloaded();
                return true;
            }
            return true;
        }

        Grids.OnUpdated = function()
        {
            updatedGridCount++;
            // Ensure all grids are updated
            if (updatedGridCount == Grids.length) {
                // Hides resource rows from ResourceGrid which are part of current team.
                // This enables filter works properly in case of filter saved in cookies.
                try {
                    RemoveResources();
                } catch (e) { }
            }
        }
        Grids.OnScroll = function (grid) {            
            try
            {                
                if (scrollTimeout) {                    
                    clearTimeout(scrollTimeout);
                    scrollTimeout = null;
                }
                scrollTimeout = setTimeout(scrollHandler(grid), 500);
            }
            catch(e)
            {
                alert(e);
                clearTimeout(scrollTimeout);
            }
        }        

        scrollHandler = function (grid) {
            grid.UpdateHeights(2);            
        };

    </script>

    <div id="dlgLoading" class="dialog">
        <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <h3 class="ms-standardheader">Loading Team...</h3>
                    <br />
                    <table style="border: 1px solid black; width: 100px; height: 10px" cellspacing="1">
                        <tr style="height: 5px;">
                            <td id="tdPctFull" style="background-color: green; display: none;">
                                <img src="blank.gif" width="1" height="1" /></td>
                            <td>
                                <img src="blank.gif" width="1" height="1" /></td>
                        </tr>
                    </table>
                </td>
            </tr>

        </table>
    </div>
    <div id="dlgNormal" class="dialog">
        <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">

                    <img src="./images/loader-epmlive.gif" style="width: 50px;" />
                </td>
            </tr>

        </table>
    </div>

    <script>
        initmb();

        //_spBodyOnLoadFunctionNames.push("doLoad");
        ExecuteOrDelayUntilScriptLoaded(doLoad, 'sp.ui.dialog.js');

        <%=sDisable %>

        document.getElementsByTagName("html")[0].className = "ms-dialog";
    </script>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Edit Team
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    Edit Team
</asp:Content>
