var context_grid=null;

function clearLoader(id)
{

    document.getElementById(id.entBox.id).style.display = "";
    document.getElementById("loading" + id.entBox.id).style.display = "none";
}
function printGrid(id)
{
    //var mygrid = dhtmlXGridObject('grid' + id);
    //mygrid.printView();
}
function myErrorHandler(obj){
    alert("Error occured.\n"+obj.firstChild.nodeValue);
    myDataProcessor.stopOnError = true;
    hm('dlgSaving');
    return false;
}
function S4() {
   return (((1+Math.random())*0x10000)|0).toString(16).substring(1);
}
function guid() {
   return (S4()+S4()+"-"+S4()+"-"+S4()+"-"+S4()+"-"+S4()+S4()+S4());
}


