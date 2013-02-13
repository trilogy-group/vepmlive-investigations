var context_grid=null;

function CheckBoxSelectRow(checkbox) {
    if (checkbox.checked) {
        var nd = checkbox;
        if (!_isKHTML)
            nd = nd.parentNode;

        nd = nd.parentNode.parentNode.parentNode.parentNode;

        var grid = nd.grid;

        var items = grid.getCheckedRowIds().split(',');

        if (items.length == 1 && items[0] != "") {

            var row = grid.getRowById(items[0]);

            grid.selectRow(row);

            RefreshCommandUI();

            try {
                if (row._locked) {
                    var wp2 = document.getElementById('Ribbon.ListItem-title');
                    if (wp2)
                        fireEvent(wp2.firstChild, 'click');
                }
            } catch (e) { }
        }
    }
}

function clearLoader(id) {
    RefreshCommandUI();
    document.getElementById(id.entBox.id).style.display = "";
    document.getElementById("loading" + id.entBox.id).style.display = "none"; 
}
function printGrid(id)
{
    var mygrid = dhtmlXGridObject('grid' + id);
    mygrid.printView();
}
function onShowMenu(id,index,grid){
    //arr = cell_id.split("_");
    var viewMenus = grid.getUserData(id,"viewMenus");

    alert(id);
    alert(viewMenus);

    if(viewMenus==null)
        viewMenus = "1,1,0,1,0,1,0,0,0,0,0";
    context_grid = grid;
    //grid._ctmndx.menu.hideButtons("view,edit,perms,delete,versions,alerts,approve,divVersions,workflows,project,createworkspace");
    if(viewMenus == "")
        return false;
        
    var arrViewMenus = viewMenus.split(',');    

    if(arrViewMenus[0] == "1")
        grid._ctmndx.showItem("view");
    else
        grid._ctmndx.hideItem("view");
        
    if(arrViewMenus[1] == "1")
        grid._ctmndx.showItem("edit");
    else
        grid._ctmndx.hideItem("edit");
        
    if(arrViewMenus[2] == "1")
        grid._ctmndx.showItem("perms");
    else
        grid._ctmndx.hideItem("perms");
        
    if(arrViewMenus[3] == "1")
        grid._ctmndx.showItem("delete");
    else
        grid._ctmndx.hideItem("delete");
        
    
    if(arrViewMenus[4] == "1" || arrViewMenus[7] == "1")
        grid._ctmndx.showItem("divVersions");
    else
        grid._ctmndx.hideItem("divVersions");
        
    if(arrViewMenus[4] == "1")
        grid._ctmndx.showItem("versions");
    else
        grid._ctmndx.hideItem("versions");
        
    if(arrViewMenus[5] == "1")
        grid._ctmndx.showItem("alerts");
    else
        grid._ctmndx.hideItem("alerts");
        
    if(arrViewMenus[6] == "1")
        grid._ctmndx.showItem("approve");
    else
        grid._ctmndx.hideItem("approve");
        
    if(arrViewMenus[7] == "1")
        grid._ctmndx.showItem("workflows");
    else
        grid._ctmndx.hideItem("workflows");
        
    if(arrViewMenus[8] == "1")
        grid._ctmndx.showItem("project");
    else
        grid._ctmndx.hideItem("project");
        
    if(arrViewMenus[9] == "1")
        grid._ctmndx.showItem("createworkspace");
    else
        grid._ctmndx.hideItem("createworkspace");

    alert('done');

    return true;
} 

function getParentGrid(grid)
{
    try
    {
    if(grid.className.indexOf("gridbox") > -1)
        return grid.id;
    else
        return getParentGrid(grid.parentElement);
    }catch(e){return null};
}

function postDelete(url)
{
        document.forms.aspnetForm.action=url;
        document.forms.aspnetForm.submit();
}
function onButtonClick(menuitemId,grid_Id,grid)
{
    var rowIdFull = grid_Id.split("_")[0];
    var weburl = context_grid.getUserData(rowIdFull,"SiteUrl");
    var listId = context_grid.getUserData(rowIdFull,"listid");
    var editurl = context_grid.getUserData(rowIdFull,"editurl");
    var viewurl = context_grid.getUserData(rowIdFull,"viewurl");
    var itemId = context_grid.getUserData(rowIdFull,"itemid");
    var webId = context_grid.getUserData(rowIdFull,"webid");
    var rowId = rowIdFull.split('.')[1];
    switch(menuitemId)
    {
        case "edit":
            var url = "";
            if(editurl == null)
                url = weburl + "/_layouts/epmlive/gridaction.aspx?action=edit&webid=" + webId+ "&ListId=" + listId + "&ID=" + itemId + "&Source=" + document.location.href;
            else
                url = editurl + "?ListId=" + listId + "&ID=" + itemId + "&Mode=2&Source=" + document.location.href;
            document.location.href=url;
            break;
        case "perms":
            var url = weburl + "/_layouts/User.aspx?obj={" + listId + "}," + itemId + ",LISTITEM&List={" + listId + "}&Source=" + document.location.href;
            document.location.href=url;
            break;
        case "view":
            var url;
            if(viewurl == null)
                url = weburl + "/_layouts/epmlive/gridaction.aspx?action=view&webid=" + webId+ "&ListId=" + listId + "&ID=" + itemId + "&Source=" + document.location.href;
            else
                url = viewurl + "?ListId=" + listId + "&ID=" + itemId + "&Mode=1&Source=" + document.location.href;
            document.location.href=url;
            break;
        case "delete":
            if(confirm('Are you sure you want to send this item to the Recycle Bin?')){
                var url;
                if(viewurl == null)
                {
                    url = weburl + "/_layouts/epmlive/gridaction.aspx?action=delete&webid=" + webId+ "&ListId=" + listId + "&ID=" + itemId + "&NextUsing=" + document.location.href;
                    document.location.href=url;
                }
                else
                {
                    
                        postDelete(weburl + '/_vti_bin/owssvr.dll?CS=65001&Cmd=Delete&List={' + listId + '}&ID=' + itemId + '&NextUsing=' + document.location.href); 
                    
                }
            };
            break;
        case "alerts":
            var url;
            if(viewurl == null)
                url = weburl + "/_layouts/epmlive/gridaction.aspx?action=alerts&webid=" + webId+ "&ListId=" + listId + "&ID=" + itemId + "&Source=" + document.location.href;
            else
                url = weburl + "/_layouts/SubNew.aspx?List={" + listId + "}&ID=" + itemId + "&Source=" + document.location.href;
                
            document.location.href=url;
            break;
        case "versions":
            var url = weburl + "/_layouts/Versions.aspx?list={" + listId + "}&ID=" + itemId + "&Source=" + document.location.href;
            document.location.href=url;
            break;
        case "approve":
            var url = weburl + "/_layouts/approve.aspx?list={" + listId + "}&ID=" + itemId + "&Source=" + document.location.href;
            document.location.href=url;
            break;
        case "workflows":
            var url = weburl + "/_layouts/Workflow.aspx?list={" + listId + "}&ID=" + itemId + "&Source=" + document.location.href;
            document.location.href=url;
            break;
    };
}