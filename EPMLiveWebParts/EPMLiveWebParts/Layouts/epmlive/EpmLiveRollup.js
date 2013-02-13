function clearLoader(id) {
    RefreshCommandUI();
    document.getElementById(id.entBox.id).style.display = "";
    document.getElementById("loading" + id.entBox.id).style.display = "none";
}
function changeView(viewname,id)
{
    try
    {
    document.getElementById(id).style.display = "none";
    document.getElementById("loading" + id).style.display = "";
    mygrid.post("_layouts/epmlive/getitems.aspx","data=" + SendData + "&view=" + viewname);
    }catch(e){alert(e);}
}