<script type = "text/javascript" src="_layouts/epmlive/modal/modal.js"></script> <div id = "leftUpperDiv" >< div id="searchloadtest-grid-id" style="">
    <div id = "searchdivtest-grid-id" style="">
    <script language = "javascript" >
    var searchfieldstest-grid-id = {}
    function switchsearchtest-grid-id()
{
    var searcher = document.getElementById('searchtest-grid-id');
    var searchtext = document.getElementById('searchtexttest-grid-id');
    var searchchoice = document.getElementById('searchchoicetest-grid-id');
    var searchtypechoice = document.getElementById('searchtypetest-grid-id');
    var searchfield = searcher.options[searcher.selectedIndex].value;
    var sList = searchfieldstest - grid - id[searchfield];
    if (sList)
    {
        searchtext.style.display = 'none';
        searchchoice.style.display = '';
        searchchoice.options.length = 0;
        searchtypechoice.options[2].selected = true;
        searchtypechoice.disabled = true;
        for (var i = 0; i < sList.length; i++)
        {
            var d = sList[i];
            searchchoice.options.add(new Option(d, d));
            if (d == 'test-search-string')
            {
                searchchoice.options[searchchoice.options.length - 1].selected = true;
            }
        }
    }
    else
    {
        searchtext.style.display = '';
        searchchoice.style.display = 'none';
        searchtypechoice.disabled = false;
    }
}
function unSearchtest-grid-id()
{
    var unsearch = document.getElementById('unsearchtest-grid-id');
    unsearch.style.display = "none";
    var searchtext = document.getElementById('searchtexttest-grid-id');
    searchtext.value = '';
    GridUnSearch('test-grid-id');
}
function doSearchtest-grid-id()
{
    var searcher = document.getElementById('searchtest-grid-id');
    var unsearch = document.getElementById('unsearchtest-grid-id');
    unsearch.style.display = "table-cell";
    var searchchoice = document.getElementById('searchchoicetest-grid-id');
    var searchtext = document.getElementById('searchtexttest-grid-id');
    var searchtypechoice = document.getElementById('searchtypetest-grid-id');
    var searchfield = searcher.options[searcher.selectedIndex].value;
    var searchtype = searchtypechoice.options[searchtypechoice.selectedIndex].value;
    var sList = searchfieldstest - grid - id[searchfield];
    var searchvalue = "";
    if (sList)
    {
        searchvalue = searchchoice.options[searchchoice.selectedIndex].value;
    }
    else
    {
        searchvalue = searchtext.value;
    }

    GridSearch('test-grid-id', searcher.options[searcher.selectedIndex].value, searchvalue, searchtype);

}
function enablesearchertest-grid-id()
{
}
function searchKeyPresstest-grid-id(e)
{
    if (e.keyCode == 13)
    {
        doSearchtest - grid - id();
    }
    return false;
}
    </script>
    <div id = "search" style="width:100%; height:40px;" class="ms-listviewtable"><table><tr><td style = "color: #A3A3A3; font-family: 'Open Sans', Helvetica, Arial, sans-serif; font-size: 14px;" >
      Search: <select id = "searchtest-grid-id" onChange="switchsearchtest-grid-id();" class="form-control">
                    
                </select>&nbsp;&nbsp;<select id = "searchtypetest-grid-id" class="form-control">
                    <option value = "1" selected>Contains</option>
                    <option value = "8" > Begins With</option>
                    <option value = "2" > Equals </ option >
                    < option value="3" >Does Not Equal</option>
                    <option value = "4" > Greater Than</option>
                    <option value = "5" > Greater Than or Equal</option>
                    <option value = "6" > Less Than</option>
                    <option value = "7" > Less Than or Equal</option>
                </select>
    &nbsp;&nbsp;</td><td>
    <div style = "border: 1px solid #CCC;width: 200px;height: 30px;" >
                    < div id="unsearchtest-grid-id" class="" style="padding-left:4px;display: table-cell;min-width: 12px;align:top">
                        <img alt = "Clear Search" src="/_layouts/epmlive/images/unsearch.png" style="padding-bottom:2px" onclick="unSearchtest-grid-id()"/>
                    </div>
                    <div style = "display: table-cell" >
                        < input type="text" id="searchtexttest-grid-id" value="test-search-string" style="border: 0px; width:100%; margin-top:-5px; height:24px; font-family: 'Segoe UI','Segoe',Tahoma,Helvetica,Arial,sans-serif;font-size:13px" onkeypress="searchKeyPresstest-grid-id(event);"/>
                        <select id = "searchchoicetest-grid-id" style="border: 0px; width:100%">
                        </select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </div>
                    <div class="" style="padding-right:2px; padding-left:10px;padding-top:5px;display: table-cell;min-width: 10px;cursor:pointer">
                        <img onclick = "doSearchtest-grid-id()" src="/_layouts/epmlive/images/find_icon.png"/>
                    </div>
                </div>
    </td></tr></table>
    </div>
    <script language = "javascript" > switchsearchtest - grid - id();</script>
    </div>
    </div>
    </div><div id = "rightUpperDiv" >< table id=pagetabletest-grid-id><tr><td><div id = "pagedivtest-grid-id" style="display:none;margin:5px 0 5px 0;"><div id = "PagePrevioustest-grid-id" style="height:18px;width:70px;border:1px solid #CACACA;float:left;padding-left:5px;background-color:#EFEFEF" onClick="javascript:PreviousPagetest-grid-id()"><a href = "javascript:void(0);" style="text-decoration:none;color:#666">&lt; Previous</a></div> <div id = "PageNexttest-grid-id" style="height:18px;width:70px;border:1px solid #CACACA;float:left;margin-left:10px;padding-right:5px;text-align:right;background-color:#EFEFEF" onClick="javascript:NextPagetest-grid-id()"><a style = "text-decoration:none;color:#666" href="javascript:void(0);">Next &gt;</a></div></div></td></tr></table></div><div width = "100%" id="loadinggridtest-grid-id" align="center"></div><div style = "height: 100px;overflow:hidden;" id="gridoutertest-grid-id"><div id = "griddivtest-grid-id" style="width:100%;height:100%">
    </div>
    </div><script language = "javascript" >
    epmdebug = false
    function LoadGridtest-grid-id() { LoadGrid('test-grid-id'); }
SP.SOD.executeOrDelayUntilScriptLoaded(loadMenutest-grid-id, 'EPMLive.js');
    function NextPagetest-grid-id()
{
    if (mygridtest - grid - id.PAGElastItem != 0)
    {
        Grids["GanttGridtest-grid-id"].Data.Data.Url = DataUrltest - grid - id + '&Page=' + mygridtest - grid - id.PAGElastItem;
        Grids["GanttGridtest-grid-id"].Reload();
    }
}
function PreviousPagetest-grid-id()
{
    if (mygridtest - grid - id.PAGEfItemHide != mygridtest - grid - id.PAGEfirstItem)
    {
        Grids["GanttGridtest-grid-id"].Data.Data.Url = DataUrltest - grid - id + '&Page=' + mygridtest - grid - id.PAGEfirstItem;
        Grids["GanttGridtest-grid-id"].Reload();
    }
}
    TGSetEvent("OnReady", "GanttGridtest-grid-id", GridOnReady);
    TGSetEvent("OnLoaded", "GanttGridtest-grid-id", GridOnLoaded);
DataUrltest-grid-id = 'http://fake.url/_layouts/epmlive/getganttitems.aspx?data='
    OnlyGrid = true;
    ArrGantts.push('GanttGridtest-grid-id');
    mygridtest-grid-id = new Object();
mygridtest-grid-id.RibbonBehavior='';
    mygridtest-grid-id.GridHeight=400;
    mygridtest-grid-id.GanttStart='';
    mygridtest-grid-id.DecimalSeparator='.';
    mygridtest-grid-id.GroupSeparator=',';
    mygridtest-grid-id.Searcher='';
    mygridtest-grid-id.Qualifier='';
    mygridtest-grid-id.ForceSearch=true;
    mygridtest-grid-id.loaded = false
    mygridtest-grid-id.CurPage = 1;
    mygridtest-grid-id.Cols = ''
    mygridtest-grid-id.LinkType = ''
    var myDataProcessortest-grid-id = new Object();
mygridtest-grid-id.Params = "";
    mygridtest-grid-id.PageSize = '10';
    mygridtest-grid-id.UseReporting = false;
    curPagetest-grid-id = 0;
    mygridtest-grid-id._epkview = '';
    mygridtest-grid-id._useparent = false;
    mygridtest-grid-id._curPlanner = '';
    mygridtest-grid-id._epkurl = '';
    mygridtest-grid-id._epkcostview = '';
    mygridtest-grid-id.canribbon = true;
    mygridtest-grid-id.addFocusedCommands = function($arr)
{
    return $arr;
}
mygridtest-grid-id.getGlobalCommands = function($arr) { return $arr; }
mygridtest-grid-id.canHandleCommand = function($Grid, commandId)
{
    return false;
}
mygridtest-grid-id.handleCommand = function($Grid, commandId, properites) { if (typeof(properties) != 'undefined') return properties; }
mygridtest-grid-id._webpartid = '';
    mygridtest-grid-id._outlookexport = '';
    mygridtest-grid-id._gridMode = '';
    mygridtest-grid-id._hasTemplateList = false;
    mygridtest-grid-id._newmenumode = 0;
    mygridtest-grid-id._newitemurl = 'test-server-url';
    mygridtest-grid-id._newfolder = false;
    mygridtest-grid-id._newmenu = "<Button Id=\'Ribbon.ListItem.New.NewListItem\' Command=\'NewItem\' CommandValueId=\'NewListItem\' LabelText=\'New Item\' Description=\'Create a New Item\' Image32by32=\'/_layouts/0/images/formatmap32x32.png\' CommandType=\'OptionSelection\' Image32by32Top=\'-160\' Image32by32Left=\'-384\'/>"
    mygridtest-grid-id._modifylist = false;
    mygridtest-grid-id._listperms = false;
    mygridtest-grid-id._shownewmenu = true;
    mygridtest-grid-id._allowedit = false;
    mygridtest-grid-id._listid = '00000000-0000-0000-0000-000000000000';
    mygridtest-grid-id._webid = '00000000-0000-0000-0000-000000000000';
    mygridtest-grid-id._listname = '';
    mygridtest-grid-id._viewid = '00000000-0000-0000-0000-000000000000';
    mygridtest-grid-id._viewurl = 'http://fake.url/http://fake.url';
    mygridtest-grid-id._siteurl = '';
    mygridtest-grid-id._webrelurl = 'test-server-url';
    mygridtest-grid-id._viewname = 'dummy';
    mygridtest-grid-id._basetype = 'GenericList';
    mygridtest-grid-id._templatetype = '0';
    mygridtest-grid-id._newrow = false;
    mygridtest-grid-id._rolluplists = '';
    mygridtest-grid-id._brollups = false;
    mygridtest-grid-id._requestList = false;
    mygridtest-grid-id._usepopup = false;
    mygridtest-grid-id._lookupfield = '';
    mygridtest-grid-id._lookupfieldlist = '';
    mygridtest-grid-id._excell = 'test-server-url\u002f_vti_bin\u002fowssvr.dll?CS=65001\u0026Using=_layouts\u002fquery.iqy\u0026List=\u00257B00000000\u00252D0000\u00252D0000\u00252D0000\u00252D000000000000\u00257D\u0026View=\u00257B00000000\u00252D0000\u00252D0000\u00252D0000\u00252D000000000000\u00257D\u0026RootFolder=http:\u0026CacheControl=1';
    mygridtest-grid-id._gridid = 'test-grid-id';
    mygridtest-grid-id._formmenus = "";
    mygridtest-grid-id.setRowHidden = function(rowid)
{
    var grid = Grids.GanttGridtest - grid - id;
    grid.HideRow(grid.GetRowById(rowid), true, false);
};
mygridtest-grid-id.getTitles = function()
{
    var titles = "";
    try
    {
        var grid = Grids.GanttGridtest - grid - id;
        var sRows = grid.GetSelRows();
        var fRow = grid.FRow;

                                                                            for(var sRow in sRows)
        {
            var row = sRows[sRow];
            if (row.itemid != "" && row.id != "indexOf")
            {
                titles += "," + row.Title;
            }
        }

        //if(fRow)
        //    titles += "," + fRow.Title;

        if (titles != "" && titles[0] == ',')
            titles = titles.substring(1);
        return titles;
    }
    catch (e) { }
};
mygridtest-grid-id.getCheckedItems = function()
{

    var ids = "";
    try
    {
        var grid = Grids.GanttGridtest - grid - id;

        var sRows = grid.GetSelRows();
                                    for(var sRow in sRows)
        {
            var row = sRows[sRow];

            if (row.itemid != "" && row.id != "indexOf" && row.id != "Header")
            {
                ids += "," + row.itemid;
            }
        }

        if (ids != "" && ids[0] == ',')
            ids = ids.substring(1);
        return ids;
    }
    catch (e) { return ""; }
};
mygridtest-grid-id.getCheckedIds = function()
{

    var ids = "";
    try
    {
        var grid = Grids.GanttGridtest - grid - id;

        var sRows = grid.GetSelRows();
                                                                                        for(var sRow in sRows)
        {
            var row = sRows[sRow];

            if (row.itemid != "" && row.id != "indexOf")
            {
                ids += "," + row.webid + "." + row.listid + "." + row.itemid;
            }
        }

        if (ids != "" && ids[0] == ',')
            ids = ids.substring(1);
        return ids;
    }
    catch (e) { return ""; }
};
mygridtest-grid-id.getCheckedRowIds = function()
{
    try
    {
        var grid = Grids.GanttGridtest - grid - id;
        return grid.FRow.id;
    }
    catch (e) { }
};
mygridtest-grid-id.getSelectedRowId = function()
{
    try
    {
        var grid = Grids.GanttGridtest - grid - id;
        if (!grid.FRow)
        {
            var sRows = grid.GetSelRows();
            return sRows[0].id;
        }
        else
            return grid.FRow.id;
    }
    catch (e) { }
};
mygridtest-grid-id.getUserData = function(rowid, key)
{
    try
    {
        var grid = Grids.GanttGridtest - grid - id;
        var row = grid.GetRowById(rowid);
        return grid.GetValue(row, key);
    }
    catch (e) { }
};
mygridtest-grid-id.getRowById = function(rowid)
{
    var grid = Grids.GanttGridtest - grid - id;
    return grid.GetRowById(rowid);
};
mygridtest-grid-id.setRowHidden = function(row, hide)
{
    var grid = Grids.GanttGridtest - grid - id;
    if (hide)
        grid.RemoveRow(row);
};
mygridtest-grid-id.editStop = function() { }
function newItemtest-grid-id()
{

    var wurl = mygridtest - grid - id._newitemurl;

    if (mygridtest - grid - id._newmenumode == '3')
    {
        newAppPopup(mygridtest - grid - id._defaultct);
    }
    else
    {
        if (wurl.indexOf('?') > 0)
            wurl = wurl + '&GetLastID=true';
        else
            wurl = wurl + '?GetLastID=true';

        if (false)
        {
            function NewItemCallback(dialogResult, returnValue)
                                                    {
                                                        if (dialogResult) { GridNewItem('test-grid-id', returnValue); }
                                                    }


            var options = { url: wurl, width: 700, dialogReturnValueCallback: NewItemCallback };

            SP.UI.ModalDialog.showModalDialog(options);
        }
        else
        {
            location.href = wurl;
        }
    }
}
    </script>
    <div id = "dlgSavingtest-grid-id" class="dialog">
        <table width = "100%" >
            < tr >
                < td align="center" class="ms-sectionheader">
                    <img src = "_layouts/images/gears_anv4.gif" style="vertical-align: middle;"/><br />
                    <H3 class="ms-standardheader">Saving Items...</h3>
                </td>
            </tr>
        </table>
    </div> 

    <div id = "dlgRefreshtest-grid-id" class="dialog">
        <table width = "100%" >
            < tr >
                < td align="center" class="ms-sectionheader">
                    <img src = "_layouts/images/gears_anv4.gif" style="vertical-align: middle;"/><br />
                    <H3 class="ms-standardheader">Refreshing Data...</h3>
                </td>
            </tr>
        </table>
    </div> 

    <div id = "dlgErrortest-grid-id" class="dialog">
        <table width = "100%" height="100%" cellpadding="0" cellspacing="3">
            <tr>
                <td class="ms-sectionheader"><H3 class="ms-standardheader">Error: </h3></td>
            </tr>
            <tr height = "100%" >
                < td align="left"valign="top">
                    <div id = "dlgErrorTexttest-grid-id" style="overflow: auto;height=90%;width=100%" class="ms-descriptiontext"></div><br>
                </td>
            </tr>
            <tr>
                <td align = "right" >
                    < input type="button" class="ms-input" value="Close" onClick="hm('dlgErrortest-grid-id');">
                </td>
            </tr>
        </table>
    </div>

    <div id = "editItemtest-grid-id" class="dialog">
        <table width = "100%" height="100%" id="tblEditItem" cellpadding="0" cellspacing="0">
            <tr height = "100%" >
                < td align="center" bgcolor="FFFFFF">
                    <div id = "editItemLoadtest-grid-id" >
                        < img src="_layouts/images/gears_anv4.gif" style="vertical-align: middle;"/>
                    </div>
                    <iframe id = "frmEditFrametest-grid-id" width="100%" height="100%" frameborder="0" src="http://fake.url/_layouts/epmlive/blank.gif">
                        
                    </iframe>
                </td>
            </tr>
        </table>
    </div>

    <div id = "dlgPosting" class="dialog">
        <table width = "100%" >
            < tr >
                < td align="center" class="ms-sectionheader">
                    <img src = "_layouts/images/gears_anv4.gif" style="vertical-align: middle;"/><br />
                    <H3 class="ms-standardheader">Posting Data...</h3>
                </td>
            </tr>
        </table>
    </div> 

    <script>

    var bPageSetuptest-grid-id;
var firstItemtest-grid-id;
    var lastItemtest-grid-id;
    var fItemHidetest-grid-id;

    function setupPagetest-grid-id(records, UseReporting, PageSize)
{

    var pages = Math.ceil(records / PageSize);

    var prev = document.getElementById("PagePrevioustest-grid-id");
    var next = document.getElementById("PageNexttest-grid-id");
    var pagediv = document.getElementById("pagedivtest-grid-id");

    if (UseReporting)
    {
        if (pages > 1)
        {
            if (!bPageSetuptest - grid - id)
            {
                bPageSetuptest - grid - id = true;

                    $("#pagedivtest-grid-id").paginate({
                    count: pages,
                        start: 1,
                        display: 12,
                        border: true,
                        border_color: '#CCCCCC',
                        text_color: '#666666',
                        background_color: '#DDDDDD',    
                        border_hover_color: '#878787',
                        text_hover_color: '#ffffff',
                        background_hover_color: '#9B9B9B', 
                        rotate: false,
                        images: false,
                        mouse: 'press',
                        onChange: ChangePagetest - grid - id
                    });
            }

        }
        else
        {
            pagediv.style.display = "none";
        }
    }
    else
    {
        pagediv.style.display = "inline-block";

        var rec = records.split('|');
        firstItemtest - grid - id = parseInt(rec[2]) * -1;
        lastItemtest - grid - id = rec[1];

        if (rec[0] == "0" || fItemHidetest - grid - id == firstItemtest - grid - id)
        {

            prev.style.background = "#EFEFEF";

            fItemHidetest - grid - id = firstItemtest - grid - id;

        }
        else
        {
            prev.style.background = "#DDDDDD";
        }

        if (rec[3] == "true")
            next.style.background = "#DDDDDD";
        else
        {
            prev.style.background = "#EFEFEF";
            lastItemtest - grid - id = 0;
        }

        if (rec[3] != "true" && rec[0] == "0")
        {
            pagediv.style.display = "none";
        }
    }
}
    </script><script>function maximizeWindow()
{
    try
    {
        var currentDialog = SP.UI.ModalDialog.get_childDialog();
        if (currentDialog != null)
        {
            if (!currentDialog.$S_0){
                currentDialog.$z();
            }
        }
    }
    catch (e) { }
}
    ExecuteOrDelayUntilScriptLoaded(maximizeWindow, 'sp.ui.dialog.js');
    initmb(); function clickTab()
{
    try
    {
        var wp = document.getElementById('MSOZoneCell_WebPart');
        fireEvent(wp, 'mouseup');
        setTimeout("clickbrowse()", 1000);
    }
    catch (e) { }
}
function clickbrowse()
{
    try
    {
        var wp2 = document.getElementById('Ribbon.Read-title').firstChild;
        fireEvent(wp2, 'click');
    }
    catch (e) { }
}
function fireEvent(element,event)
{
    if (document.createEventObject)
    {
        // dispatch for IE
        var evt = document.createEventObject();
        return element.fireEvent('on' +event, evt)
                                    }
    else
    {
        // dispatch for firefox + others
        var evt = document.createEvent("HTMLEvents");
        evt.initEvent(event, true, true); // event type,bubbling,cancelable
        return !element.dispatchEvent(evt);
    }
}
    setTimeout("clickTab()", 100);</script><style>
                                    #MSOZoneCell_WebPartWPQ2{display:none !important;}
                                    .ms-webpartzone-cell {margin: auto !important}
                                    </style>