var curProj;
var autoCalc;
var maxLevel;
var gridLoading = true;
var columnCalculations;
var durationCalc = false;
var AdurationCalc = false;
var defaultValues;
var minValues;
var maxValues;
var savingPlan = false;
var closeplan = false;
var pcURL;
var arrColumnLookups;
var nonwork;
var workdays;
var hasFilters;
var projectEditUrl;

function doOnKeyPress(key, control, shift)
{

    switch(key)
    {
        case 45:
            mygrid.editStop();
            setTimeout("addRow()", 1);
            return false;
        case 46:
            //mygrid.editStop();
            //setTimeout("deleteRow()", 1);
            //return false;
        case 83:
            if(control)
                saveData();
            break;
    };
    
    return true;
}
 
function showGantt (view, project)
{
    window.open('showgantt.aspx?view=' + view + '&Project=' + project,'mywin','toolbar=0,resizable=1');
}

function hideEdit()
{
    hm('dlgEditItem');
    document.getElementById("editItem").style.display = "none";
}

function editProject(id, listid)
{
    var weburl = projectEditUrl + "?ID=" + id;
    var w = pageWidth() - 100;

    function gridactioncallback (dialogResult, returnValue) { }

    var options = { url: weburl, width: w, dialogReturnValueCallback: gridactioncallback };

    SP.UI.ModalDialog.showModalDialog(options);
}


function onShowMenu(id,index,grid)
{
    if(id != "_SummaryTask_")
        return true;
}


function onButtonClick(menuitemId,grid_Id)
{
    var rowId = grid_Id.split("_")[0];
    
    
    switch(menuitemId)
    {
        case "delete":
            if(hFilters(true))
                return;
            if(confirm('Are you sure you want to delete that task?'))
                doDeleteRows(rowId.split(","));
            break;
        case "edit":
            var url = "edititem.aspx?ListId=" + listId + "&ID=" + rowId + "&Mode=2&Source=" + siteUrl;
            var w = pageWidth() - 100;
            var h = pageHeight() - 100;
            sm('editItem',w,h);
            document.getElementById("frmEditFrame").src=url;
            break;
        case "perms":
            var url = "../User.aspx?obj={" + listId + "}," + rowId + ",LISTITEM&List={" + listId + "}&Source=" + document.location.href;
            document.location.href=url;
            break;
        case "view":
           var url = "edititem.aspx?ListId=" + listId + "&ID=" + rowId + "&Mode=1&Source=" + siteUrl;
           var w = pageWidth() - 100;
            var h = pageHeight() - 100;
           sm('editItem',w,h);
            //document.getElementById("editItem").style.display="";
            //document.getElementById("editItemLoad").style.display="";
            //document.getElementById("frmEditFrame").style.display="none";
            document.getElementById("frmEditFrame").src=url;
            break;
        case "alerts":
            var url = "../SubNew.aspx?LISTITEM&List={" + listId + "}&ID=" + rowId + "&Source=" + document.location.href;
            document.location.href=url;
            break;
        case "versions":
            var url = "../Versions.aspx?list={" + listId + "}&ID=" + rowId + "&Source=" + document.location.href;
            document.location.href=url;
            break;
        case "approve":
            var url = "../approve.aspx?list={" + listId + "}&ID=" + rowId + "&Source=" + document.location.href;
            document.location.href=url;
            break;
        case "workflows":
            var url = "../Workflow.aspx?list={" + listId + "}&ID=" + rowId + "&Source=" + document.location.href;
            document.location.href=url;
            break;
    };
}
                
function getWidth()
{
    var winW = 640;
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

function checkMin(rowId,cellIndex,value)
{
    if(gridLoading)
        return true;
    
    if(minValues[cellIndex] != "")
    {
        var val = parseFloat(value);
        var min = parseFloat(minValues[cellIndex]);
        if(val < min)
        {
            alert('You must enter a value greater than ' + min);
            return false;
        }
    }
    return true;
}

function checkMax(rowId,cellIndex,value)
{
    if(gridLoading)
        return true;
    
    if(maxValues[cellIndex] != "")
    {
        var val = parseFloat(value);
        var max = parseFloat(maxValues[cellIndex]);
        if(val > max)
        {
            alert('You must enter a value less than ' + max);
            
            return false;
        }
    }
    return true;
}

function calcRollups(rowId,type,cellIndex)
{
    var calc = columnCalculations[cellIndex];
    switch(calc)
    {
        case "Min":
            setMin(rowId,type, cellIndex);
            break;
        case "Max":
            setMax(rowId,type, cellIndex);
            break;
        case "Sum":
            setSum(rowId,type, cellIndex);
            break;
        case "Avg":
            setAvg(rowId,type, cellIndex);
            break;
    };
}

function doOnCellEdit(stage,rowId,cellIndex,newValue,oldValue) 
{
    if(stage != 2)
        return true;
 
    
   
    if(String(newValue) == "NaN")
    {
        mygrid.cells(rowId,cellIndex).setValue(oldValue);
        return;
    }
    
    if(!checkMin(rowId,cellIndex,newValue))
    {
        mygrid.cells(rowId,cellIndex).setValue(oldValue);
        return;
    }

    if(!checkMax(rowId,cellIndex,newValue))
    {
        mygrid.cells(rowId,cellIndex).setValue(oldValue);
        return;
    }
    
    if(hFilters(false))
        return true;
    
    if(mygrid.getColumnId(cellIndex) == "Duration")
        mygrid.setUserData(rowId, "Duration", newValue);
    
    if(mygrid.getColumnId(cellIndex).replace("_x0020_","") == "ActualDuration")
        mygrid.setUserData(rowId, "ActualDuration", newValue);
    
    if(!gridLoading && autoCalc)
    {
        gridLoading = true;
        
        var type = mygrid.getColType(cellIndex);
        
        var fieldNeeded = false;
        
        for(var k = 0;k<columnCalculations.length;k++)
        {
            if(columnCalculations[k] == mygrid.getColumnId(cellIndex))
                fieldNeeded = true;
        }
        
        if(fieldNeeded)
        {
            mygrid.setUserData(rowId, mygrid.getColumnId(cellIndex), newValue);
            for(var k = 0;k<columnCalculations.length;k++)
            {
                if(columnCalculations[k] == mygrid.getColumnId(cellIndex))
                    setPercent(rowId, k);
            }
        }
        if(durationCalc)
        {

            if(mygrid.getColumnId(cellIndex) == "Duration")
            {
                calcFinishDate(rowId, false);
            }
            if(mygrid.getColumnId(cellIndex) == "StartDate")
            {
                calcFinishDate(rowId, false);
            }
            if(mygrid.getColumnId(cellIndex) == "DueDate")
            {
                calcDuration(rowId, false);
            }
        }
        
        if(AdurationCalc)
        {
            if(mygrid.getColumnId(cellIndex) == "Actual_x0020_Start" || mygrid.getColumnId(cellIndex) == "Actual_x0020_Duration")
            {
                calcFinishDate(rowId, true);
            }
            if(mygrid.getColumnId(cellIndex) == "Actual_x0020_Finish")
            {
                calcDuration(rowId, true);
            }
        }
        
        if(mygrid.getColumnId(cellIndex) == "PercentComplete")
        {
            setPercent(rowId,cellIndex);
        }
        else
            calcRollups(rowId,type,cellIndex);
        
        if(durationCalc)
        {
            calcParentDuration(rowId);
        }
        gridLoading = false;
        
    }
        
    return true;
    
}

function setPercent(rowId, cellIndex)
{

    if(columnCalculations[cellIndex] == "")
        return;

    //setup variables
    var totalVal = 0;
    var totalPercent = 0;
    
    var parentId = mygrid.getParentId(rowId);
    if(parentId == 0)
        return;
    var subItems = mygrid.getSubItems(parentId).split(",");

    //get Total Value
    for(var i = 0;i<subItems.length;i++)
    {
        var val = parseFloat(mygrid.getUserData(subItems[i],columnCalculations[cellIndex]));
        if(String(val) != "NaN")
            totalVal += val;
    }
    
    for(var i = 0;i<subItems.length;i++)
    {
        var val = parseFloat(mygrid.getUserData(subItems[i],columnCalculations[cellIndex]));
        var pct = parseFloat(mygrid.cells(subItems[i],cellIndex).getValue());
        var pctDone = val / totalVal * pct;
        
        if(String(pctDone) != "NaN")
            totalPercent += pctDone;
    }

    
    var changed = true;

    if(parseInt(mygrid.cells(parentId,cellIndex).getValue()) == parseInt(totalPercent))
        changed = false;

    mygrid.cells(parentId,cellIndex).setValue(totalPercent);
    
    if(changed)
        myDataProcessor.setUpdated(parentId,true);
            
    //if(parentId != 0)
    setPercent(parentId, cellIndex)

}

function calcParentDuration(rowId)
{
    var parentId = mygrid.getParentId(rowId);
    if(parentId == 0)
        return;
        
    var startCol = null;
    var finishCol = null;
    var durCol = null;

    for(var i = 0;i<mygrid.getColumnsNum();i++)
    {
        if(mygrid.getColumnId(i) == "StartDate")
            startCol = i;
        if(mygrid.getColumnId(i) == "DueDate")
            finishCol = i;
        if(mygrid.getColumnId(i) == "Duration")
            durCol = i;
    }
    
    var start = new Date(mygrid.cells(parentId,startCol).getDate());
    var finish = new Date(mygrid.cells(parentId,finishCol).getDate());

    var duration = 0;

    while (start < finish) {
        if (workdays[start.getDay()] == 1)
            duration++;

        start.setDate(start.getDate() + 1);
    }


    /*while(workdays[finish.getDay()] == 0)
    {
        finish.setDate(finish.getDate() - 1); 
    }
    
    var realFinish = new Date(finish);
    
    var duration = (finish - start) / (1000 * 60 * 60 * 24);
    
    while(start.getDay() != finish.getDay())
    {
        finish.setDate(finish.getDate() + 1);
        duration++;
    }
 
    var weeks = Math.floor(parseFloat(duration / 7));
    
    duration = (realFinish - start) / (1000 * 60 * 60 * 24);
    
    duration -= weeks * nonwork;
    
    duration++;
        */
    //var weeks = Math.floor(parseFloat(duration / 7));
    
    //duration -= weeks * 2;
    
    //var extra = duration - (weeks * 7);
    
    //if(extra >= 6 - start.getDay())
    //    duration -= 2;
        
    //duration++;
        
    if(durCol != null)
        mygrid.cells(parentId,durCol).setValue(duration);
        
    mygrid.setUserData(parentId,"Duration",duration)
    
    calcParentDuration(parentId);
}

function calcDuration(rowId, actual)
{
    var startCol = null;
    var finishCol = null;
    var durCol = null;

    if(actual)
    {
        for(var i = 0;i<mygrid.getColumnsNum();i++)
        {
            if(mygrid.getColumnId(i) == "Actual_x0020_Start")
                startCol = i;
            if(mygrid.getColumnId(i) == "Actual_x0020_Finish")
                finishCol = i;
            if(mygrid.getColumnId(i) == "Actual_x0020_Duration")
                durCol = i;
                
            if(mygrid.getColumnId(i) == "ActualStart")
                startCol = i;
            if(mygrid.getColumnId(i) == "ActualFinish")
                finishCol = i;
            if(mygrid.getColumnId(i) == "ActualDuration")
                durCol = i;
        }
    }
    else
    {
        for(var i = 0;i<mygrid.getColumnsNum();i++)
        {
            if(mygrid.getColumnId(i) == "StartDate")
                startCol = i;
            if(mygrid.getColumnId(i) == "DueDate")
                finishCol = i;
            if(mygrid.getColumnId(i) == "Duration")
                durCol = i;
        }
    }

    var start = new Date(mygrid.cells(rowId,startCol).getDate());
    var finish = new Date(mygrid.cells(rowId,finishCol).getDate());

    var duration = 0;

    while (start <= finish) {
        if (workdays[start.getDay()] == 1)
            duration++;

        start.setDate(start.getDate() + 1);
    }

    /*while(workdays[finish.getDay()] == 0)
    {
        finish.setDate(finish.getDate() - 1); 
    }
    
    var realFinish = new Date(finish);
    
    var duration = (finish - start) / (1000 * 60 * 60 * 24);
    
    while(start.getDay() != finish.getDay())
    {
        finish.setDate(finish.getDate() + 1);
        duration++;
    }
 
    var weeks = Math.floor(parseFloat(duration / 7));
    
    duration = (realFinish - start) / (1000 * 60 * 60 * 24);
    
    duration -= weeks * nonwork;
    
    duration++;*/
//    var extra = duration - (weeks * 7);

//    if(extra >= 6 - start.getDay() && duration > 5)
//        duration -= 2;
        
    if(durCol != null)
        mygrid.cells(rowId,durCol).setValue(duration);
        
    mygrid.setUserData(rowId,"Duration",duration);
    
    calcRollups(rowId,"edno",durCol);
}

function calcFinishDate(rowId, actual)
{
    var startCol = null;
    var finishCol = null;
    var durCol = null;

    if(actual)
    {
        for(var i = 0;i<mygrid.getColumnsNum();i++)
        {
            if(mygrid.getColumnId(i).Replace("_x0020_","") == "ActualStart")
                startCol = i;
            if(mygrid.getColumnId(i).Replace("_x0020_","") == "ActualFinish")
                finishCol = i;
            if(mygrid.getColumnId(i).Replace("_x0020_","") == "ActualDuration")
                durCol = i;
        }
    }
    else
    {
        for(var i = 0;i<mygrid.getColumnsNum();i++)
        {
            if(mygrid.getColumnId(i) == "StartDate")
                startCol = i;
            if(mygrid.getColumnId(i) == "DueDate")
                finishCol = i;
            if(mygrid.getColumnId(i) == "Duration")
                durCol = i;
        }
    }
 
    var start = new Date(mygrid.cells(rowId,startCol).getDate());
    //var duration = parseFloat(mygrid.cells(rowId,durCol).getValue());
    var duration = parseFloat(mygrid.getUserData(rowId,"Duration"));


    if(mygrid.cells(rowId,startCol).cell.innerHTML == "&nbsp;")
        return;
    //var weeks = parseInt(duration / 5);
    //duration += weeks * 2;
    //var extra = duration - (weeks * 7);
    //if(extra >= 6 - start.getDay())
    //    duration += 2;
    //start.setDate(start.getDate() + duration);

    //var weeks = getWeeks(start, );
//    duration += weeks * nonwork;

    //alert(duration);

    while (duration > 1 || workdays[start.getDay()] != 1) {

        if (workdays[start.getDay()] == 1)
            duration--;
           
        start.setDate(start.getDate() + 1);
    }



    /*if(duration != 1 && duration != 0)
    {
        //Move start date to valid date
        while(workdays[start.getDay()] == 0)
        {
            start.setDate(start.getDate() + 1);
        }

        alert("Valid Start: " + start);
            
        if(weeks > 0)
        {
            duration += Math.floor(parseFloat(duration / (7 - nonwork))) * nonwork;
            
            if(duration >= 1)
                duration--;
                
            start.setDate(start.getDate() + duration);
        
            for(i = 0;i < 7;i++)
            {
                if(workdays[start.getDay()] == 0)
                    start.setDate(start.getDate() + 1);
                else
                    break;
            }
            
        }
        else
        {
            
            duration--;
            
            while( duration > 0 || workdays[start.getDay()] == 0)
            {
                if(workdays[start.getDay()] == 1)
                    duration--;
                   
                start.setDate(start.getDate() + 1);
            }
            
        }
    }
    
        */
    //var extra = duration - (weeks * 7);
    
    //if(extra >= 6 - start.getDay())
    //    duration += 2;

    

    if(String(start) != "NaN")
        mygrid.cells(rowId,finishCol).setValue(start);

    calcRollups(rowId,"dhxCalendarA",finishCol);

    //setMax(rowId,"dhxCalendar",finishCol);
}

function getWeeks(start, duration) 
{
    var i = 0;

    while(start.getDay() != finish.getDay())
        start.setDate(start.getDate() + 1);

    var diff = new Date();
    
    diff.setTime(Math.abs(start.getTime() - finish.getTime()));

    timediff = diff.getTime();

    return Math.floor(timediff / (1000 * 60 * 60 * 24 * 7));

}

function setAvg(rowId, type, cellIndex)
{
    if(type == "edn" || type == "price")
    {    
        var sum = 0;
        var counter = 0;
        var parentId = mygrid.getParentId(rowId);
        if(parentId == 0)
            return;
        var subItems = mygrid.getSubItems(parentId).split(",");

        for(var i = 0;i<subItems.length;i++)
        {
            var val = parseFloat(mygrid.cells(subItems[i],cellIndex).getValue());
            if(String(val) != "NaN")
                sum += val;
            counter++;
        }
        
        var changed = true;

        if(counter > 0)
            sum = sum / counter;

        if(parseFloat(mygrid.cells(parentId,cellIndex).getValue()) == parseFloat(sum))
            changed = false;

        mygrid.cells(parentId,cellIndex).setValue(sum);

        if(changed)
            myDataProcessor.setUpdated(parentId,true);
                
        if(parentId != 0)
            setAvg(parentId,type,cellIndex);
    }
}

function setSum(rowId, type, cellIndex)
{
    if(type == "edn" || type == "price")
    {    
        var sum = 0;
        
        var parentId = mygrid.getParentId(rowId);
        if(parentId == 0)
            return;
        var subItems = mygrid.getSubItems(parentId).split(",");

        for(var i = 0;i<subItems.length;i++)
        {
            var val = parseFloat(mygrid.cells(subItems[i],cellIndex).getValue());
            if(String(val) != "NaN")
                sum += val;
        }
        
        var changed = true;

       if(parseFloat(mygrid.cells(parentId,cellIndex).getValue()) == parseFloat(sum))
            changed = false;
        
        mygrid.cells(parentId,cellIndex).setValue(sum);
        
        if(changed)
            myDataProcessor.setUpdated(parentId,true);
                
        if(parentId != 0)
            setSum(parentId,type,cellIndex);
    }
}

function setMin(rowId, type, cellIndex)
{
    var max = "";
    var parentId = mygrid.getParentId(rowId);
    if(parentId == 0)
        return;
    var subItems = mygrid.getSubItems(parentId).split(",");

    for(var i = 0;i<subItems.length;i++)
    {
        var val = mygrid.cells(subItems[i],cellIndex).getValue();
        switch(type)
        {
            case "dhxCalendarA":
                if(new Date(val) < new Date(max) || (new Date(max)) == "NaN")
                    max = val;
                break;
            case "price":
            case "edn":
                if(parseFloat(val) < parseFloat(max) || String(parseFloat(max)) == "NaN")
                    max = val;
                break;
        };
    }
    
    if(max != "NaN")
    {
        var changed = true;
        switch(type)
        {
            case "dhxCalendarA":
                if(String(new Date(mygrid.cells(parentId,cellIndex).getValue())) == String(new Date(max)))
                    changed = false;
                break;
            case "price":
            case "edn":
               if(parseFloat(mygrid.cells(parentId,cellIndex).getValue()) == parseFloat(max))
                    changed = false;
                break;
        };
        
        
        
        mygrid.cells(parentId,cellIndex).setValue(max);
        
        if(changed)
            myDataProcessor.setUpdated(parentId,true);
                
        if(parentId != 0)
            setMin(parentId,type,cellIndex);
    }
    
}

function setMax(rowId, type, cellIndex)
{
    var max = "";
    var parentId = mygrid.getParentId(rowId);
    if(parentId == 0)
            return;
    var subItems = mygrid.getSubItems(parentId).split(",");

    for(var i = 0;i<subItems.length;i++)
    {
        var val = mygrid.cells(subItems[i],cellIndex).getValue();
        switch(type)
        {
            case "dhxCalendarA":
                if(new Date(val) > new Date(max) || (new Date(max)) == "NaN")
                    max = val;
                break;
            case "price":
            case "edn":
                if(parseFloat(val) > parseFloat(max) || String(parseFloat(max)) == "NaN")
                    max = val;
                break;
        };
    }
    
    if(max != "NaN")
    {
        var changed = true;
        switch(type)
        {
            case "dhxCalendarA":
                if(String(new Date(mygrid.cells(parentId,cellIndex).getValue())) == String(new Date(max)))
                    changed = false;
                break;
            case "price":
            case "edn":
               if(parseFloat(mygrid.cells(parentId,cellIndex).getValue()) == parseFloat(max))
                    changed = false;
                break;
        };
        
        mygrid.cells(parentId,cellIndex).setValue(max);
        
        if(changed)
            myDataProcessor.setUpdated(parentId,true);
                
        if(parentId != 0)
            setMax(parentId,type,cellIndex);
    }
    
}

function doOutlineLevel()
{
    var cbo = document.getElementById("outlinelevel");
    var index = cbo.selectedIndex;
    
    for(var i = 0;i<mygrid.getRowsNum();i++)
    {
        var rowid = mygrid.getRowId(i);
        if(index == 0)
        {
            if(mygrid.hasChildren(rowid) > 0)
                mygrid.openItem(rowid);
        }
        else
        {
            if(mygrid.getLevel(rowid) >= index)
            {
                mygrid.closeItem(rowid);
            }
            else
            {
                if(mygrid.hasChildren(rowid) > 0)
                    mygrid.openItem(rowid);
            }
        }
    }
}

function buildLevels()
{

    maxLevel = 0;
    for(var i = 0;i<mygrid.getRowsNum();i++)
    {
        if(maxLevel < mygrid.getLevel(mygrid.getRowId(i)))
                maxLevel = mygrid.getLevel(mygrid.getRowId(i));
    }
    maxLevel++;
    
    var cbo = document.getElementById("outlinelevel");
    
    for(var i = 1;i<cbo.options.length;i++)
        cbo.options.remove(i);
        
    for(var i = 1;i<maxLevel;i++)
    {
        cbo.options[i] = new Option("Show Level " + i, i);
    }
    
    
}

function dragDrop()
{
    if(hFilters(true))
        return;
        
    setWBS("_SummaryTask_","");
    settaskorder(null);
}

function doDeleteRows(rowIds)
{

    if(hFilters(true))
        return;
    
    for(var i = 0;i<rowIds.length;i++)
    {
        if(rowIds[i] != "_SummaryTask_")
        {
            mygrid.deleteRow(rowIds[i]);
            if(mygrid.hasChildren(rowIds[i]) > 0)
            {
                var child = mygrid.getSubItems(rowIds[i]).split(",");
                doDeleteRows(child);
            }
        }
    }
}

function deleteRow()
{

    var mult = 1;
    
    var rowIds = mygrid.getSelectedRowId().split(",");
    
    if(rowIds.length > 1) 
        mult = 2;
    else if(mygrid.hasChildren(rowIds[0]) > 0)
        mult = 3;
        
    if(mult == 1)
    {
        if(confirm('Are you sure you want to delete that task?'))
           doDeleteRows(rowIds);
    }
    else if(mult == 2)
    {
        if(confirm('Are you sure you want to delete those tasks?'))
            doDeleteRows(rowIds);
    }
    else if(mult == "3")
    {
        if(confirm('Are you sure you want to delete that task and all subtasks?'))
            doDeleteRows(rowIds);
    }
    
    settaskorder(null);
    setWBS("_SummaryTask_","");
}

function exportGrid()
{
    mygrid.gridToClipboard();
    alert('The grid has been exported to your clipboard. You may now paste it into Excel');
}

function hFilters(notify)
{

    if(hasFilters)
    {
        if(notify)
            alert('There are currently filters applied to this view. You must disable them before modifying items.');
            
        return true;
    }
    else
        return false;
}

function addRow()
{
    if(hFilters(true))
        return;
    {
        var taskColIndex = mygrid.getColIndexById("Title");
        if(taskColIndex == null)
        {
            taskColIndex = mygrid.getColIndexById("LinkTitle");
        }

        var ind = getCurRowIndex();
        
        if(ind == 0 || ind == -1)
        {
            
            var newId = mygrid.getUID();
            
            if(mygrid.hasChildren("_SummaryTask_"))
            {
                var child = mygrid.getSubItems("_SummaryTask_").split(",");
                mygrid.addRowAfter(newId,defaultValues,child[child.length-1]);
            }
            else
            {
                mygrid.addRow(newId,defaultValues,null,"_SummaryTask_","",false);
                mygrid.openItem("_SummaryTask_");
            }

            
            setWBS("_SummaryTask_", "");
            settaskorder(null);
            //setWBS(child[child.length-1], newId);
            //settaskorder(null);
            if(taskColIndex != null)
            {
                //mygrid.cells(newId,taskColIndex).setValue("[Enter Task Name]");
                //mygrid.selectCell(mygrid.getRowIndex(newId), taskColIndex);
                //mygrid.editCell();
                
                mygrid.selectCell(mygrid.getRowIndex(newId), taskColIndex, false, false, true, true);
            }
        }
        else
        {

            var rowId = mygrid.getSelectedRowId();
            var parentId = mygrid.getParentId(rowId);
            //var wbs = "";
            var newId = mygrid.getUID();
            if(mygrid.hasChildren(mygrid.getSelectedId()) > 0)
            {
                var child = mygrid.getSubItems(mygrid.getSelectedId()).split(",");
                mygrid.addRowBefore(newId,defaultValues,child[0]);
                //wbs = mygrid.getUserData(mygrid.getSelectedId(),"wbs") + ".0";
                //setWBS(mygrid.getSelectedId(), mygrid.getUserData(mygrid.getSelectedId(),"wbs"));
            }
            else
            {

                mygrid.addRowAfter(newId,defaultValues,mygrid.getSelectedId());
                //wbs = mygrid.getUserData(mygrid.getSelectedId(),"wbs");
                //setWBSFromSibling(mygrid.getSelectedId(), newId);
            }
        
            setWBS("_SummaryTask_", "");
            settaskorder(null);
            if(taskColIndex != null)
            {
                //mygrid.cells(rowId,taskColIndex).setValue("[Enter Task Name]");
                //setTimeout("mygrid.selectCell(" + mygrid.getRowIndex(newId) + ", " + taskColIndex + ", false, false, true, true)", 100);
                mygrid.selectCell(mygrid.getRowIndex(newId), taskColIndex, false, false, true, true);
            }
        }
    }
}

function clearLoader()
{
    
    //document.getElementById("loading").style.display = "none";
    hm('dlgTasks');
    buildLevels();
    
    var counter = 0;
    for(var i = 0;i<mygrid.getColumnsNum();i++)
    {
        if(mygrid.getColumnId(i) == "StartDate" || mygrid.getColumnId(i) == "DueDate" || mygrid.getColumnId(i) == "Duration")
            counter++;
    }

    if(counter >= 2)
        durationCalc = true;
        
    counter = 0;
    for(var i = 0;i<mygrid.getColumnsNum();i++)
    {
        if(mygrid.getColumnId(i) == "Actual_x0020_Start" || mygrid.getColumnId(i) == "Actual_x0020_Finish" || mygrid.getColumnId(i) == "Actual_x0020_Duration")
            counter++;
    }

    if(counter >= 2)
        AdurationCalc = true;
    
    gridLoading = false;
    savingPlan = false;
}

function loadPredecessorIds()
{
    for(var j = 0;j<mygrid.getRowsNum();j++)
    {
        var rowid = mygrid.getRowId(j);
        var predIndexes = mygrid.getUserData(rowid,"Predecessors");
        
        if(predIndexes != null && predIndexes != "")
        {
            var predIndexArray = predIndexes.split(",");
            
            for(var i = 0;i<predIndexArray.length;i++)
            {
                predIndexArray[i] = mygrid.getRowId(predIndexArray[i]);   
            }

            mygrid.setUserData(rowid,"PredecessorsIds",predIndexArray);
        } 
        
    }
}

function setPredecessorIndexes(deleting)
{
    var ColIndex = mygrid.getColIndexById("Predecessors");

    for(var j = 0;j<mygrid.getRowsNum();j++)
    {
        var rowid = mygrid.getRowId(j);
        
        var predIds = mygrid.getUserData(rowid,"PredecessorsIds");
        var predecessors = String(mygrid.getUserData(rowid,"Predecessors"));
        
        if(predIds != null && predIds != "")
        {
            
            var predIdArray = String(predIds).split(",");
            
            var newPreds = "";
            for(var i = 0;i<predIdArray.length;i++)
            {
                if(predIdArray[i] != deleting)
                    newPreds += "," + mygrid.getUserData(predIdArray[i],"taskorder");
            }
            
            if(newPreds.length > 1)
                newPreds = newPreds.substring(1);

            if(newPreds != predecessors)
            {
                mygrid.setUserData(rowid,"Predecessors", newPreds);

                if(String(ColIndex) != "undefined")
                {
                    mygrid.cells(rowid,ColIndex).setValue(newPreds);
                }
                
                var predIndexArray = newPreds.split(",");
            
                for(var i = 0;i<predIndexArray.length;i++)
                {
                    predIndexArray[i] = mygrid.getRowId(predIndexArray[i]);   
                }
                
                mygrid.setUserData(rowid,"PredecessorsIds",predIndexArray);
            }
        }
    }
}

function settaskorder(deleting)
{
    var toColIndex = mygrid.getColIndexById("taskorder");
    var ColIndex = mygrid.getColIndexById("Predecessors");
    
    var taskorder = 1;
    
    for(var i = 1;i<mygrid.getRowsNum();i++)
    {
        rowid = mygrid.getRowId(i);
        
        if(mygrid.getUserData(rowid,"!nativeeditor_status") != "deleted")
        {
        
            var changed = true;
            if(mygrid.getUserData(rowid,"taskorder") == taskorder)
                changed = false;
            mygrid.setUserData(rowid,"taskorder",taskorder);

            if(toColIndex != null)
            {
                mygrid.cells(rowid,toColIndex).setValue(taskorder);
            }
            if(changed)
                myDataProcessor.setUpdated(rowid,true);
            taskorder++;            
        }
    }
    
    setPredecessorIndexes(deleting);
    buildLevels();
}

/*function setWBS(parentId, row, startwbs)
{

    var tasks = mygrid.getSubItems(parentId).split(",");
    var wbsColIndex = mygrid.getColIndexById("WBS");
    var parentWBS = mygrid.getUserData(parentId,"wbs");
    
    for(var i=0;i<tasks.length;i++)
    {
        if(mygrid.getRowIndex(tasks[i]) >= row)
        {
            if(mygrid.getUserData(tasks[i],"!nativeeditor_status") != "deleted")
            {
                
                
                if(parentWBS != "")
                {
                    newwbs = parentWBS + "." + startwbs;
                }
                else
                {
                    newwbs = startwbs;
                }
                {
                    var changed = true;
                    if(mygrid.getUserData(tasks[i],"wbs") == newwbs)
                        changed = false;
                    mygrid.setUserData(tasks[i],"wbs",newwbs);
                    if(wbsColIndex != "undefined")
                    {
                        mygrid.cells(tasks[i],wbsColIndex).setValue(newwbs);
                    }
                    if(changed)
                        myDataProcessor.setUpdated(tasks[i],true);
                    if(mygrid.hasChildren(tasks[i]) > 0)
                    {
                        mygrid.openItem(tasks[i]);
                        setWBS(tasks[i], row, 1)
                    }
                }
                startwbs++;
            }
        }
    }
    
}*/

function setWBSFromSibling(sid, id)
{
    var swbs = mygrid.getUserData(sid,"wbs").toString().split(".");
    var parentWbs = mygrid.getUserData(mygrid.getParentId(sid),"wbs");
    if(parentWbs != null)
        parentWbs = parentWbs.toString();
    else
        parentWbs = "";
        
    var iwbs = swbs[swbs.length-1];
    iwbs++;
    var newWBS = iwbs;
    if(parentWbs != "")
        newWBS = parentWbs + "." + newWBS;
        
    setWBSVal(id,newWBS); 
}

function setWBSVal(id, wbs)
{
    var wbsColIndex = mygrid.getColIndexById("WBS");
    var changed = true;
    if(mygrid.getUserData(id,"wbs") == wbs)
        changed = false;
    mygrid.setUserData(id,"wbs",wbs);
    if(wbsColIndex != null)
    {
        mygrid.cells(id,wbsColIndex).setValue(wbs);
    }
    
    if(changed)
        myDataProcessor.setUpdated(id,true);
}

function setWBS(parentId, parentwbs)
{

    var tasks = mygrid.getSubItems(parentId).split(",");
    
    var wbs = 1;
        
    for(var i=0;i<tasks.length;i++)
    {
        if(tasks[i] != "")
        {
            if(mygrid.getUserData(tasks[i],"!nativeeditor_status") != "deleted")
            {
                if(parentwbs != null && parentwbs != "")
                {
                    newwbs = parentwbs + "." + wbs;
                }
                else
                {
                    newwbs = wbs;
                }
                {

                    setWBSVal(tasks[i],newwbs);

                    if(mygrid.hasChildren(tasks[i]) > 0)
                    {
                        mygrid.setRowTextBold(tasks[i]);
                        //if(autoCalc)
                        //    mygrid.lockRow(tasks[i], true);
                        mygrid.openItem(tasks[i]);
                        setWBS(tasks[i], newwbs)
                    }
                    else
                    {
                        mygrid.lockRow(tasks[i], false);
                        mygrid.setRowTextNormal(tasks[i]);
                    }
                }
                wbs++;
            }
        }
    }
}

function initWBS() {
    settaskorder(null);
    setWBS("_SummaryTask_", "");
}

function getCurRowIndex()
{
    return mygrid.getRowIndex(mygrid.getSelectedRowId());
}

function getMySibling(rowId)
{
    var rowIndex = mygrid.getRowIndex(rowId);
    var parentId = mygrid.getParentId(rowId);
    
    for(var i = rowIndex - 1;i>=0;i--)
    {
        var rId = mygrid.getRowId(i);
        if(mygrid.getParentId(rId) == parentId)
            if(mygrid.getUserData(rId,"!nativeeditor_status") != "deleted")
                return rId;
    }
}

function indent()
{

    if(hFilters(true))
        return;

    mygrid.editStop();
    var curRowId = mygrid.getSelectedRowId();
    var parent = getMySibling(curRowId);
    gridLoading = true;
    mygrid.dragContext = {};
    mygrid.moveRowTo(curRowId, parent, "move", "child");
    mygrid.openItem(parent);
    setWBS("_SummaryTask_", "");
    mygrid.forEachCell(curRowId, function (cell, i) {
        calcRollups(curRowId, mygrid.getColType(i), i);
    });
    gridLoading = false;
    
}

function outdent()
{
    if(hFilters(true))
        return;

    mygrid.editStop();
    gridloading = true;
    var curRowId = mygrid.getSelectedRowId();
    mygrid.dragContext = {};
    var newRowId = mygrid.moveRowTo(curRowId, mygrid.getParentId(curRowId), "move", "sibling");
    setWBS("_SummaryTask_", "");
    settaskorder(null);
    if (autoCalc) {
        mygrid.forEachCell(curRowId, function (cell, i) {
            calcRollups(curRowId, mygrid.getColType(i), i);
        });
    }
    gridloading = false;
    
}

function moveup()
{
    
    if(hFilters(true))
        return;
        
    gridLoading = true;

    var rowIds = String(mygrid.getSelectedRowId()).split(",");
    
    for(var i = 0;i<rowIds.length;i++)
        mygrid.moveRowUp(rowIds[i]);

    settaskorder(null);
    setWBS("_SummaryTask_", "");

    gridLoading = false;

}

function movedown()
{

    if(hFilters(true))
        return;
        
    gridLoading = true;
    
    var rowIds = String(mygrid.getSelectedRowId()).split(",");
    
    for(var i = rowIds.length-1;i>=0;i--)
        mygrid.moveRowDown(rowIds[i]);
   
    settaskorder(null);
    setWBS("_SummaryTask_", "");
    
    gridLoading = false;
}

function autocalcres(loader)
{

    if(loader.xmlDoc.responseText!=null)
	{
		var xmlDoc = loader.xmlDoc.responseText.trim();
		
		if(xmlDoc == "Success")
		{
		    if(autoCalc)
		    {
                document.getElementById('zz25_AutoCalculate').setAttribute("iconSrc","/_layouts/images/checkon.gif");
            }
            else
            {
                document.getElementById('zz25_AutoCalculate').setAttribute("iconSrc","");
            }
        }   
        else
            alert("Failed");    
	}
	else
		alert("Response contains no XML");
		
    hm('dlgAutoCalc');
}

function autocalc(cell)
{
    sm('dlgAutoCalc',200,100);
    autoCalc = !autoCalc;
    dhtmlxAjax.post("setPCfield.aspx", "Field=AutoCalculate&Value=" + autoCalc + "&ID=" + curProj,autocalcres);
}

function newRequest()
{
  var req = false;
  // For Safari, Firefox, and other non-MS browsers
  if (window.XMLHttpRequest) {
    try {
      req = new XMLHttpRequest();
    } catch (e) {
      req = false;
    } 
  } else if (window.ActiveXObject) {
    // For Internet Explorer on Windows
    try {
      req = new ActiveXObject("Msxml2.XMLHTTP");
    } catch (e) {
      try {
        req = new ActiveXObject("Microsoft.XMLHTTP");
      } catch (e) {
        req = false;
      }
    }
  }
  return req;
}

function unlink()
{

    if(hFilters(true))
        return;
        
    var rowIds = mygrid.getSelectedRowId().split(",");
    var ColIndex = mygrid.getColIndexById("Predecessors");

    for(var i = 0;i<rowIds.length;i++)
    {
        var Predecessors = mygrid.getUserData(rowIds[i],"Predecessors")

        if(Predecessors != "")
        {
            mygrid.setUserData(rowIds[i],"Predecessors","");
                            
            if(ColIndex != null)
            {
                mygrid.cells(rowIds[i],ColIndex).setValue("");
            }
            
            myDataProcessor.setUpdated(rowIds[i],true);
        }
    }
}

function link()
{

    if(hFilters(true))
        return;
        
    var rowIds = mygrid.getSelectedRowId().split(",");
    if(rowIds.length > 1)
    {
        var ColIndex = mygrid.getColIndexById("Predecessors");
        
        var linker = rowIds[0];
        
        var linkerIndex = mygrid.getUserData(linker,"taskorder");
        
        var linkerPredecessors = "";
        try
        {
            linkerPredecessors = mygrid.getUserData(linker,"Predecessors").split(",");
        }catch(ex){}

        for(var i = 1;i<rowIds.length;i++)
        {
            var curPredecessors = mygrid.getUserData(rowIds[i],"Predecessors");
            var curPredecessorsIds = mygrid.getUserData(rowIds[i],"PredecessorsIds");

            var hasPred = false;
            if(curPredecessors != null)
            {
                var predList = curPredecessors.split(",");
                for(var j = 0;j<predList.length;j++)
                {
                    if(linkerIndex == predList[j])
                    {
                        hasPred = true;
                    }
                }
            }
            else
                curPredecessors = "";



            if(!hasPred)
            { 
                hasPred = false;
                var linkedIndex = mygrid.getUserData(rowIds[i],"taskorder");
                
                for(var j = 0;j<linkerPredecessors.length;j++)
                {
                    if(linkedIndex == linkerPredecessors[j])
                    {
                        hasPred = true;
                    }
                }
                
                
        
                if(!hasPred)
                {
                    if(curPredecessors != "")
                        curPredecessors += "," + linkerIndex;
                    else
                        curPredecessors = linkerIndex;
                        
                    if(curPredecessorsIds != null && curPredecessorsIds != "")
                        curPredecessorsIds += "," + linker;
                    else
                        curPredecessorsIds = linker;              

                    mygrid.setUserData(rowIds[i],"Predecessors",curPredecessors);
                    mygrid.setUserData(rowIds[i],"PredecessorsIds",curPredecessorsIds);
                    
                    if(ColIndex != null)
                    {
                        mygrid.cells(rowIds[i],ColIndex).setValue(curPredecessors);
                    }

                    myDataProcessor.setUpdated(rowIds[i],true);
                }
            }
            linker = rowIds[i];
            linkerIndex = mygrid.getUserData(linker,"taskorder");
        }        
    }
}

function saveData()
{
    //myDataProcessor.setUpdated("_SummaryTask_",false);
    mygrid.editStop();
    savingPlan = true;
    sm('dlgSaving',200,100);
    if(myDataProcessor.updatedRows.length > 0)
    {
        myDataProcessor.sendData();
    //    document.getElementById("saving").style.display = "";
    }
    else
        hm('dlgSaving');
}

function saveDataClose()
{
    mygrid.editStop();
    if(myDataProcessor.updatedRows.length > 0)
    {
        savingPlan = true;
        closeplan = true;
        sm('dlgSaving',200,100);
        myDataProcessor.sendData();
        //document.getElementById("saving").style.display = "";
    }
    else
    {
        setTimeout("closePage()", 1);
    }
}
function closePage()
{
    window.close();
}

function runSaveBaselineRes(loader)
{

    if(loader.xmlDoc.responseText!=null)
	{
		var xmlDoc = loader.xmlDoc.responseText.trim();
		if(xmlDoc == "Success")
		{

        }   
        else
        {
            alert("Failed to Save Baseline");
        }
        
	}
	else
		alert("Response contains no XML");
		
    hm('dlgBaseline');
}

   
function runSaveBaseline()
{
    dhtmlxAjax.post("updatetask.aspx", "savebaseline=1&projectId=" + curProj + "&view=" + listView,runSaveBaselineRes);
}

function runCalcRes(loader)
{
    if(loader.xmlDoc.responseText!=null)
	{
		var xmlDoc = loader.xmlDoc.responseText.trim();
		if(xmlDoc == "Success")
		{
            document.location.href = document.location.href;
        }   
        else
        {
            alert("Failed to Calculate");
        }
        
	}
	else
		alert("Response contains no XML");
		
    hm('dlgCalculating');
}

function runCalc()
{

    dhtmlxAjax.post("updatetask.aspx", "calc=1&projectId=" + curProj + "&view=" + listView,runCalcRes);

}

function viewItem()
{

    var rowIdFull = mygrid.getSelectedRowId();
    if (rowIdFull && rowIdFull != "_SummaryTask_") {
        var wurl = "gridaction.aspx?action=view&ListId=" + listId + "&ID=" + rowIdFull + "&siteid=" + siteId + "&webid=" + webId + "&rowid=" + rowIdFull;

        function myCallback(dialogResult, returnValue) {

        }

        var options = { url: wurl, width: 700, dialogReturnValueCallback: myCallback };

        SP.UI.ModalDialog.showModalDialog(options);
    }
}

function editItem() {

    var rowIdFull = mygrid.getSelectedRowId();
    if (rowIdFull && rowIdFull != "_SummaryTask_")
    {
        var wurl = "gridaction.aspx?action=edit&ListId=" + listId + "&ID=" + rowIdFull + "&siteid=" + siteId + "&webid=" + webId + "&rowid=" + rowIdFull;

        function myCallback(dialogResult, returnValue) {
            if(dialogResult == 1) {
                var curRowId = mygrid.getSelectedRowId();
			    //getSingleItem(siteId,webId,listId,curRowId,curRowId);
		    }
        }

        var options = { url: wurl, width: 700, dialogReturnValueCallback: myCallback };

        SP.UI.ModalDialog.showModalDialog(options);
    }
}

function saveBaseline()
{
    mygrid.editStop();
    
    var saveb = true;
    
    if(lastBaseline != "")
    {
        saveb = false;
        if(confirm('The baseline was last saved on ' + lastBaseline + ', would you like to overwrite?'))
        {
            saveb = true;
        }
    }
    
    if(saveb)
    {
        savingPlan = true;

        if(myDataProcessor.updatedRows.length > 0)
        {
            myDataProcessor.serverProcessor = dpURL + "&savebaseline=1";
            myDataProcessor.sendData();
            sm('dlgBaseline',200,100);
        }
        else
        {
            sm('dlgBaseline',200,100);
            setTimeout("runSaveBaseline()", 1);
        }
    }
}

function calc()
{
    mygrid.editStop();
    savingPlan = true;
    sm('dlgCalculating',200,100);
    if(myDataProcessor.updatedRows.length > 0)
    {
        myDataProcessor.serverProcessor = dpURL + "&calc=1";
        myDataProcessor.sendData();
    }
    else
    {
        setTimeout("runCalc()", 1);
    }
    
    /*var preAutoCalc = autoCalc;

    autoCalc = true;

    for(var i = 0;i<mygrid.getRowsNum();i++)
    {
        var rowid = mygrid.getRowId(i);
        mygrid.openItem(rowid);
        if(mygrid.hasChildren(rowid) == 0)
        {
            if(durationCalc)
            {
                calcFinishDate(rowid, false);
            }
            if(AdurationCalc)
            {
                calcFinishDate(rowid, true);
            }
            for(var j = 0;j<mygrid.getColumnsNum();j++)
            {
                if(mygrid.getColumnId(j) == "PercentComplete")
                {
                    setPercent(rowid,j);
                }
                else
                {
                    var type = mygrid.getColType(j);
                    
                    calcRollups(rowid,type,j);
                }
            }
            if(durationCalc)
            {
                calcParentDuration(rowid);
            }
        }
        //cellChanged(rowid,2,"");
    }
    
    autoCalc = preAutoCalc;
    */
}

function leavePage(e)
{

    if(myDataProcessor.updatedRows.length > 0 && !savingPlan)
    {
        if(!e) e = window.event;
	    //e.cancelBubble is supported by IE - this will kill the bubbling process.
	    //e.cancelBubble = true;
	    e.returnValue = 'Your workplan has unsaved changes.'; //This is displayed on the dialog

	    //e.stopPropagation works in Firefox.
	    if (e.stopPropagation) {
		    e.stopPropagation();
		    e.preventDefault();
	    }
    }
}

function getNextSibling(startBrother){
  endBrother=startBrother.nextSibling;
  while(endBrother.nodeType!=1){
    endBrother = endBrother.nextSibling;
  }
  return endBrother;
} 

var singleItemUrl;


//======================Multi User=====================

function eXcell_usereditorm(cell){                                    //excell name is defined here
    if (cell){                                                     //default pattern, just copy it
        this.cell = cell;
        this.grid = this.cell.parentNode.grid;
        if(!this.grid._grid_pe)
        {
			var z=document.getElementById("peoplegrid");
			z.onclick=function(e){ (e||event).cancelBubble=true; }
			
			if (_isIE) { 
				z.style.position="absolute"
				z.style.top="0px"
			}
			document.body.insertBefore(z,document.body.firstChild);

			
 
			this.grid._grid_pe = z;
		}
    }
    this.setValue=function(val){

		var strVal = "&nbsp;";
		var strVals = val.split('\t')[0].split('\n');
		for(var i = 1;i<strVals.length;i=i+2)
		{
			strVal += "; " + strVals[i];
		}
		if(strVal != "&nbsp;")
			strVal = strVal.substring(7);
			
        this.setCValue(strVal);   
        
        this.cell._displayValue = strVal;
        this.cell._users = val.split('\t')[0];                                   
        
    }
    this.getValue=function(){
       return this.cell._users; // get value
    }
    this.edit=function(){
    
		this.val=this.getValue();
    
		document.getElementById("ctl00_PlaceHolderMain_userpickerm_downlevelTextBox").value = "";
		document.getElementById("ctl00_PlaceHolderMain_userpickerm_upLevelDiv").innerHTML = "";
		copyUplevelToHidden('ctl00_PlaceHolderMain_userpickerm');
		updateControlValue('ctl00_PlaceHolderMain_userpickerm');
		var arg=getUplevel('ctl00_PlaceHolderMain_userpickerm');
		var ctx='ctl00_PlaceHolderMain_userpickerm';
		EntityEditorSetWaitCursor(ctx);
		WebForm_DoCallback('ctl00$PlaceHolderMain$userpickerm',arg,EntityEditorHandleCheckNameResult,ctx,EntityEditorHandleCheckNameError,true);
		
        var pp = document.getElementById("divPe");
        var ppi = document.getElementById("peoplecheckimg");
        //pp.style.display = "none";
        ppi.src = "../images/TPMAX1.GIF";
        
            
		var strVal = "";
		var strAllUserChecks = "";
		var strVals = this.cell._users.split('\n');
		var strAllUsers = arrColumnLookups[this.cell.cellIndex].split('\n');
		var strUserNames = '\t';
		
		for(var i = 0;i<strVals.length;i=i+2)
		{
			strUserNames += strVals[i].toLowerCase() + '\t';
			strVal += "; " + strVals[i];
		}
		if(strVal.length > 1)
			strVal = strVal.substring(1);
			
		for(var i = 0;i<strAllUsers.length;i++)
		{
			var isChecked = "";
			var userInfo = strAllUsers[i].split(';#');
			
			if(strUserNames.indexOf('\t' + userInfo[0].toLowerCase() + '\t') > -1)
				isChecked = "checked";
				
			strAllUserChecks += "<br><input type=\"checkbox\" name=\"chkUsers\" value=\"" + userInfo[0] + "\" " + isChecked + ">" + userInfo[1];
		}
		if(strAllUserChecks.length > 1)
			strAllUserChecks = strAllUserChecks.substring(4);
			
		document.getElementById("peoplecheck").innerHTML = strAllUserChecks;
	
		var arPos = this.grid.getPosition(this.cell);

		if(arPos[0] + 200 > document.body.clientWidth)
			this.grid._grid_pe.style.left=document.body.clientWidth - 210;
		else
			this.grid._grid_pe.style.left=arPos[0];
		
		if((arPos[1] + 100) > (document.body.clientHeight + document.body.scrollTop))
			this.grid._grid_pe.style.top=document.body.clientHeight + document.body.scrollTop - 105;
		else
			this.grid._grid_pe.style.top=arPos[1];

		this.grid._grid_pe.style.display="";
		this.grid._grid_pe.style.position="absolute";
		this.grid._grid_pe.style.zIndex=99;
    }
    this.detach=function(){
		this.grid._grid_pe.style.display="none";
		
		var strUsers = "";

		var divChecks = document.getElementById("peoplecheck");
		var divChildChecks = divChecks.firstChild;
		while(divChildChecks != null)
		{
			if(divChildChecks.nodeName == "INPUT")
			{
				if(divChildChecks.checked)
				{
					strUsers += '\n' + divChildChecks.value;
					strUsers += '\n' + divChildChecks.nextSibling.nodeValue;
				}
			}
			divChildChecks = divChildChecks.nextSibling;
		}

		for(var i = 1;i<document.getElementById("ctl00_PlaceHolderMain_userpickerm_upLevelDiv").childNodes.length;i=i+2)
		{
			if(document.getElementById("ctl00_PlaceHolderMain_userpickerm_upLevelDiv").childNodes[i].firstChild != null)
			{
				strUsers += '\n' + document.getElementById("ctl00_PlaceHolderMain_userpickerm_upLevelDiv").childNodes[i].title;
				strUsers += '\n' + document.getElementById("ctl00_PlaceHolderMain_userpickerm_upLevelDiv").childNodes[i].firstChild.nextSibling.innerText;
			}
		}
		if(strUsers.length > 1)
			strUsers = strUsers.substring(1);
		
		var oldValue = this.getValue();
			
        this.setValue(strUsers); 

        return oldValue != this.getValue();
    }
}
eXcell_usereditorm.prototype = new eXcell;

//================================User Single=================

function eXcell_usereditor(cell){                                    //excell name is defined here
    if (cell){
        this.cell = cell;
        this.grid = this.cell.parentNode.grid;
        if(!this.grid._grid_pes)
        {
			var z=document.getElementById("peoplesingle");
			z.onclick=function(e){ (e||event).cancelBubble=true; }
			
			if (_isIE) { 
				z.style.position="absolute"
				z.style.top="0px"
			}
			document.body.insertBefore(z,document.body.firstChild);

			
 
			this.grid._grid_pes = z;
		}
    }
    this.setValue=function(val){

		var strVal = "&nbsp;";
		var strVals = val.split('\t')[0].split('\n');
		for(var i = 1;i<strVals.length;i=i+2)
		{
			strVal += "; " + strVals[i];
		}
		if(strVal != "&nbsp;")
			strVal = strVal.substring(7);
			
        this.setCValue(strVal);   
        
        this.cell._displayValue = strVal;
        this.cell._users = val;
    }
    this.getValue=function(){
		
       return this.cell._users; // get value
    }
    this.edit=function(){
		this.val=this.getValue();
        var pp = document.getElementById("divPes");
        var ppi = document.getElementById("peoplechecksingleimg");
        //
        ppi.src = "../images/TPMAX1.GIF";

		var strVal = "";
		var strAllUserChecks = "";
		var strVals = this.cell._users.split('\n');
		var strAllUsers = arrColumnLookups[this.cell.cellIndex].split('\n');
		var strUserNames = '\t';

		for(var i = 0;i<strVals.length;i=i+2)
		{
			strUserNames += strVals[i].toLowerCase() + '\t';
			strVal += "; " + strVals[i];
		}
		if(strVal.length > 1)
			strVal = strVal.substring(1);

		var slct = document.getElementById("peoplecheckselect");
		slct.options.length=0;
		
		var oSelected = -1;
		var oCounter = 0;
		for(var i = 0;i<strAllUsers.length;i++)
		{
			var isChecked = false;
			var userInfo = strAllUsers[i].split(';#');
			
			if(strUserNames.indexOf('\t' + userInfo[0].toLowerCase() + '\t') > -1)
				oSelected = oCounter;

			slct.add(new Option(userInfo[1], userInfo[0]));
            oCounter++;
		}
		
		slct.selectedIndex = oSelected;
		
		document.getElementById("ctl00_PlaceHolderMain_userpickers_downlevelTextBox").value = "";
		document.getElementById("ctl00_PlaceHolderMain_userpickers_upLevelDiv").innerHTML = "";
		/*
		if(document.getElementById("#pesid#_upLevelDiv").firstChild == null)
		{
			var oTN=document.createTextNode("");
			document.getElementById("#pesid#_upLevelDiv").appendChild(oTN);
		}

		document.getElementById("#pesid#_upLevelDiv").firstChild.nodeValue = strVal;
		*/

		copyUplevelToHidden('ctl00_PlaceHolderMain_userpickers');
		updateControlValue('ctl00_PlaceHolderMain_userpickers');
		var arg=getUplevel('ctl00_PlaceHolderMain_userpickers');
		var ctx='ctl00_PlaceHolderMain_userpickers';
		
		EntityEditorSetWaitCursor(ctx);
		WebForm_DoCallback('ctl00$PlaceHolderMain$userpickers',arg,EntityEditorHandleCheckNameResult,ctx,EntityEditorHandleCheckNameError,true);
		
		
		var arPos = this.grid.getPosition(this.cell);

		if(arPos[0] + 200 > document.body.clientWidth)
			this.grid._grid_pes.style.left=document.body.clientWidth - 210;
		else
			this.grid._grid_pes.style.left=arPos[0];
		
		if((arPos[1] + 100) > (document.body.clientHeight + document.body.scrollTop))
			this.grid._grid_pes.style.top=document.body.clientHeight + document.body.scrollTop - 105;
		else
			this.grid._grid_pes.style.top=arPos[1];

		this.grid._grid_pes.style.display="";
		this.grid._grid_pes.style.position="absolute";
		this.grid._grid_pes.style.zIndex=99;
		//pp.style.display = "none";
    }
    this.detach=function(){
		this.grid._grid_pes.style.display="none";
		
		var strUsers = "";

		for(var i = 0;i<document.getElementById("ctl00_PlaceHolderMain_userpickers_upLevelDiv").childNodes.length;i=i+2)
		{
			if(document.getElementById("ctl00_PlaceHolderMain_userpickers_upLevelDiv").childNodes[i].firstChild != null)
			{
				strUsers += '\n' + document.getElementById("ctl00_PlaceHolderMain_userpickers_upLevelDiv").childNodes[i].title;
				strUsers += '\n' + document.getElementById("ctl00_PlaceHolderMain_userpickers_upLevelDiv").childNodes[i].firstChild.nextSibling.innerText;
			}
		}

		if(strUsers == "")
		{
			var chkVal = document.getElementById("peoplecheckselect");
			if(chkVal.selectedIndex > -1)
			{
				strUsers += '\n' + chkVal.options[chkVal.selectedIndex].value;
				strUsers += '\n' + chkVal.options[chkVal.selectedIndex].text;
			}
		}
		
		if(strUsers.length > 1)
			strUsers = strUsers.substring(1);
		
		var oldValue = this.getValue();
			
        this.setValue(strUsers); 

        return oldValue != this.getValue();
    }
}
eXcell_usereditor.prototype = new eXcell;




//=========================multichoice========================
function eXcell_mchoice(cell){                                    //excell name is defined here
    if (cell){                                                     //default pattern, just copy it
        this.cell = cell;
        this.grid = this.cell.parentNode.grid;
        if(!this.grid._grid_mc)
        {
			var z=document.getElementById("multichoice");
			z.onclick=function(e){ (e||event).cancelBubble=true; }
			
			if (_isIE) { 
				z.style.position="absolute"
				z.style.top="0px"
			}
			document.body.insertBefore(z,document.body.firstChild);
 
			this.grid._grid_mc = z;
		}
    }
    this.setValue=function(val){

		var strVal = "&nbsp;";
		
		if(val.split('\t')[0] != "")
		{
			var strVals = val.split('\t')[0].split('\n');

			for(var i = 0;i<strVals.length;i++)
			{
				var valInfo = strVals[i].split(';#');
				strVal += ", " + valInfo[1];
			}
			if(strVal != "&nbsp;")
				strVal = strVal.substring(7);
		}
        this.setCValue(strVal);
        
        this.cell._displayValue = strVal;
        this.cell._values = val;
    }
    this.getValue=function(){

		return this.cell._values;
    }
    this.edit=function(){
		this.val=this.getValue();
		var strAllValueChecks = "";
		var strVals = this.cell._values.split('\n');
		var strAllValues = arrColumnLookups[this.cell.cellIndex].split('\n');
		var strValues = '\t';
		
		for(var i = 0;i<strVals.length;i++)
		{
			var valInfo = strVals[i].split(';#');		
			strValues += valInfo[0].toLowerCase() + '\t';
		}

		for(var i = 0;i<strAllValues.length;i++)
		{
			var isChecked = "";
			var valInfo = strAllValues[i].split(';#');
			
			if(strValues.indexOf('\t' + valInfo[0].toLowerCase() + '\t') > -1)
				isChecked = "checked";

			strAllValueChecks += "<br><input type=\"checkbox\" name=\"chkValues\" value=\"" + valInfo[0] + "\" " + isChecked + ">" + valInfo[1];
		}
		if(strAllValueChecks.length > 1)
			strAllValueChecks = strAllValueChecks.substring(4);
			
		document.getElementById("multichoiceinner").innerHTML = strAllValueChecks;

		var arPos = this.grid.getPosition(this.cell);

//		if(arPos[0] + 200 > document.body.clientWidth)
//			this.grid._grid_mc.style.left=document.body.clientWidth - 210;
//		else
//			this.grid._grid_mc.style.left=arPos[0];
//		
//		if((arPos[1] + 100) > (document.body.clientHeight + document.body.scrollTop))
//			this.grid._grid_mc.style.top=document.body.clientHeight + document.body.scrollTop - 105;
//		else
//			=arPos[1];
//			
        var top;
        var left;
                    
		if(arPos[0] + this.cell.offsetWidth + 180 > document.body.clientWidth)
			left = arPos[0] - 185;
		else
			left=arPos[0];
		
		if((arPos[1] + 170) > (document.body.clientHeight + document.body.scrollTop))
			top=document.body.clientHeight + document.body.scrollTop - 180;
		else
			top=arPos[1];
			
		this.grid._grid_mc.style.top = top;
		this.grid._grid_mc.style.left = left;

		this.grid._grid_mc.style.display="";
		
		this.grid._grid_mc.style.position="absolute";
		this.grid._grid_mc.style.zIndex=99;
    }
    this.detach=function(){
		
		this.grid._grid_mc.style.display="none";
		
		var child = document.getElementById("multichoiceinner").firstChild;
		var val1 = "";

		while(child != null)
		{
			if(child.nodeName == "INPUT")
			{
				if(child.checked)
				{
					val1 += '\n' + child.value + ";#" + child.nextSibling.nodeValue;
				}
			}
			child = child.nextSibling;
		}

		if(val1.length > 1)
			val1 = val1.substring(1);
					
		var oldValue = this.getValue();
		
		this.cell._values = val1;
			
        this.setValue(val1); 

        return oldValue != this.getValue();
		
    }
}
eXcell_mchoice.prototype = new eXcell;
//=========================Calendar===========================


eXcell_dhxCalendarA.prototype.edit = function(){
	
                    var top;
                    var left;
                    
                    var arPos = this.grid.getPosition(this.cell);

					if(arPos[0] + this.cell.offsetWidth + 180 > document.body.clientWidth)
						left = arPos[0] - 185;
					else
						left=arPos[0] + this.cell.offsetWidth;
					
					if((arPos[1] + 170) > (document.body.clientHeight + document.body.scrollTop))
						top=document.body.clientHeight + document.body.scrollTop - 180;
					else
						top=arPos[1];
                    
                    this.grid._grid_calendarA.setPosition(top,left);
                    
	                    this.grid._grid_calendarA.show();
	                    this.grid._grid_calendarA._last_operation_calendar=false;
					//var arPos = this.grid.getPosition(this.cell);
                    //var pval=this._date2str2(this.cell.val||new Date());
                    //window._grid_calendar.render(arPos[0],arPos[1]+this.cell.offsetHeight,this,pval);
                    this.cell._cediton=true;
                    this.val=this.cell.val;
                    this._val=this.cell.innerHTML;
                   // alert(this.cell.val);
				   	this.grid._grid_calendarA.setDateFormat((this.grid._dtmask||"%d/%m/%Y"));
                    this.grid._grid_calendarA.setDate(this.val);
                    this.grid._grid_calendarA.draw();
                    

					this.cell.atag=((!this.grid.multiLine)&&(_isKHTML||_isMacOS||_isFF))?"INPUT":"TEXTAREA";
					
					this.obj = document.createElement(this.cell.atag);
					this.obj.style.height = (this.cell.offsetHeight-(_isIE?4:2))+"px";
                    this.obj.className="dhx_combo_edit";
				   	this.obj.wrap = "soft";
					this.obj.style.textAlign = this.cell.align;
					this.obj.onclick = function(e){(e||event).cancelBubble = true}
					this.obj.onmousedown = function(e){(e||event).cancelBubble = true}
					this.obj.value = this.getValue();
					this.cell.innerHTML = "";
					this.cell.appendChild(this.obj);
				  	if (_isFF) {
						this.obj.style.overflow="visible";
						if ((this.grid.multiLine)&&(this.obj.offsetHeight>=18)&&(this.obj.offsetHeight<40)){
							this.obj.style.height="36px";
							this.obj.style.overflow="scroll";
						}
					}
                    this.obj.onselectstart=function(e){  if (!e) e=event; e.cancelBubble=true; return true;  };
					this.obj.focus()
  					this.obj.focus()
				                    
				}
//============================================================
function changeUser(chkVal)
{

	document.getElementById("ctl00_PlaceHolderMain_userpickers_downlevelTextBox").value = "";
	document.getElementById("ctl00_PlaceHolderMain_userpickers_upLevelDiv").innerHTML = "";
		
	if(document.getElementById("ctl00_PlaceHolderMain_userpickers_upLevelDiv").firstChild == null)
	{
		var oTN=document.createTextNode("");
		document.getElementById("ctl00_PlaceHolderMain_userpickers_upLevelDiv").appendChild(oTN);
	}

	document.getElementById("ctl00_PlaceHolderMain_userpickers_upLevelDiv").firstChild.nodeValue = "";
	//chkVal.options[chkVal.selectedIndex].value;
}

//=============================================================

function getSingleItem(siteid,webid,listid,itemid,rowid)
{
	//sm('dlgRefresh',200,100);

	dhtmlxAjax.post(singleItemUrl, "edit=true&siteid=" + siteid + "&webid=" + webid + "&listid=" + listid + "&itemid=" + itemid + "&rowid=" + rowid,getSingleItemResponse);
}

function getSingleItemResponse(loader)
{
	if(loader.xmlDoc.responseText!=null)
	{
		var xmlDoc = loader.xmlDoc.responseXML;
		var rowXml = xmlDoc.childNodes[1];
		setRowValues(rowXml);
		//hm('dlgRefresh');
	}
	else
		alert("Response contains no XML");
}

function setRowValues(rowsXml)
{
	for(var i = 0;i<rowsXml.childNodes.length;i++)
	{
		setRowValue(rowsXml.childNodes[i])
	}
}

function setRowValue(rowXml)
{
	var rowId = rowXml.getAttribute("id")

	var cellCounter = 0;

	for(var i = 0;i<rowXml.childNodes.length;i++)
	{
	    if(rowXml.childNodes[i].nodeName == "userdata")
		{
			mygrid.setUserData(rowId,rowXml.childNodes[i].getAttribute("name"),rowXml.childNodes[i].text);
		}
		if(rowXml.childNodes[i].nodeName == "cell")
		{
			var cellval = "";
			var celltype = "";
			try
			{
				celltype = rowXml.childNodes[i].getAttribute("type");
			}catch(e){}
			
			if(rowXml.childNodes[i].childNodes.length > 0)
			{
				cellval = rowXml.childNodes[i].firstChild.nodeValue;
			}
			if(celltype == "combo")
				mygrid.cells(rowId,cellCounter).setValue(rowXml.childNodes[i]);	
			else
				mygrid.cells(rowId,cellCounter).setValue(cellval);	
			cellCounter++;
		}
	}
	
}


dhtmlXGridObject.prototype.registerLookup=function(col,vals){

    if(arrColumnLookups == null)
        arrColumnLookups = new Array(mygrid.getColumnsNum());
		
    arrColumnLookups[col] = vals;
};

function getXY(oNode, pNode){
		if (!pNode)
			var pNode = document.body

		var oCurrentNode = oNode;
		var iLeft = 0;
		var iTop = 0;

		while ((oCurrentNode)&&(oCurrentNode != pNode)){ //.tagName!="BODY"){
			iLeft+=oCurrentNode.offsetLeft-oCurrentNode.scrollLeft;
			iTop+=oCurrentNode.offsetTop-oCurrentNode.scrollTop;
			oCurrentNode=oCurrentNode.offsetParent; //isIE()?:oCurrentNode.parentNode;
		}

		if (pNode == document.body){
			if (_isIE){
				if (document.documentElement.scrollTop)
					iTop+=document.documentElement.scrollTop;

				if (document.documentElement.scrollLeft)
					iLeft+=document.documentElement.scrollLeft;
			} else if (!_isFF){
				iLeft+=document.body.offsetLeft;
				iTop+=document.body.offsetTop;
			}
		}
		return new Array(iLeft, iTop);
	}
	
	
function saveresgantt(rowid,start,end)
{
    for(var i = 1;i<mygrid.getColumnsNum();i++)
    {
        if(mygrid.getColumnId(i) == "StartDate")
        {
            mygrid.cells(rowid,i).setValue(start);
        }
        if(mygrid.getColumnId(i) == "DueDate")
        {
            var oldEnd = mygrid.cells(rowid,i).getValue();
            mygrid.cells(rowid,i).setValue(end);
            doOnCellEdit(2,rowid,i,end,oldEnd);
        }
    }
    
    myDataProcessor.setUpdated(rowid,true);
}
	
function showresgantt(url, listid)
{
    mygrid.editStop();
	var start = "";
	var end = "";
	var work = ""
	var title = "";
	var resources = "";
	var tresources = "";
	var rowId = mygrid.getSelectedId();
	if(rowId == null)
	{
	    alert("No Row Selected");
	    return;
	}
	for(var i = 1;i<mygrid.getColumnsNum();i++)
    {
        if(mygrid.getColumnId(i) == "StartDate")
            start = mygrid.cells(rowId,i).getValue();
        if(mygrid.getColumnId(i) == "DueDate")
            end = mygrid.cells(rowId,i).getValue();
        if(mygrid.getColumnId(i) == "Work")
            work = mygrid.cells(rowId,i).getValue();
        if(useResPool)
        {
            if(mygrid.getColumnId(i) == "ResourceNames")
            {
                tresources = mygrid.cells(rowId,i).getValue().split('\n');
                
                for(var j = 0;j<tresources.length;j++)
	            {
	                if(tresources[j] != "")
	                {
		                resources += ";" + tresources[j].split(';#')[0];
		            }
	            }
	            if(resources.length > 1)
	                resources = resources.substring(1);
	        }
        }
        else
        {
            if(mygrid.getColumnId(i) == "AssignedTo")
            {
                tresources = mygrid.cells(rowId,i).getValue().split('\n');
                for(var j = 0;j<tresources.length;j=j+2)
	            {
	                if(tresources[j] != "")
		                resources += ";" + tresources[j];
	            }
	            if(resources.length > 1)
	                resources = resources.substring(1);
	        }
        }
        
        if(mygrid.getColumnId(i) == "Title")
            title = mygrid.cells(rowId,i).getValue();
    }

	if(start == "")
	{
		alert('You must specify a Start Date');
		return;
	}
	if(end == "")
	{
		alert('You must specify a Due Date');
		return;
	}
	if(work == "")
	{
		alert('You must specify Work');
		return;
	}
	if(resources == "")
	{
		alert('You must specify 1 or more resources');
		return;
	}
	
	window.open(url + "?showgantt=1&startdate=" + start + "&enddate=" + end + "&work=" + work + "&resources=" + resources + "&title=" + title + "&listid=" + listid + "&itemid=" + rowId + "&workplanner=1&useResPool=" + useResPool,'', config='height=400,width=800, toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, directories=no, status=yes');
}