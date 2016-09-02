var mygrid;
function newWorkspace()
{
    document.getElementById("ctl00_PlaceHolderMain_ctl01").style.display ="";
    document.getElementById("ctl00_PlaceHolderMain_ctl01_tablerow1").style.display ="";
    
    document.getElementById("ctl00_PlaceHolderMain_ctl02").style.display ="";
    document.getElementById("ctl00_PlaceHolderMain_ctl02_tablerow1").style.display ="";
    
    document.getElementById("ctl00_PlaceHolderMain_ctl04").style.display ="";
    document.getElementById("ctl00_PlaceHolderMain_ctl04_tablerow1").style.display ="";
    
    document.getElementById("ctl00_PlaceHolderMain_ctl03").style.display ="";
    document.getElementById("ctl00_PlaceHolderMain_ctl03_tablerow1").style.display ="";
    
    document.getElementById("ctl00_PlaceHolderMain_ctl05").style.display ="none";
    document.getElementById("ctl00_PlaceHolderMain_ctl05_tablerow1").style.display ="none";
    //document.getElementById("divNew").style.display="";
    //document.getElementById("divExisting").style.display="none";
    document.getElementById("hdnWorkspaceType").value = "New";
}


function existingWorkspace(listname)
{
    document.getElementById("ctl00_PlaceHolderMain_ctl01").style.display ="none";
    document.getElementById("ctl00_PlaceHolderMain_ctl01_tablerow1").style.display ="none";
    
    document.getElementById("ctl00_PlaceHolderMain_ctl02").style.display ="none";
    document.getElementById("ctl00_PlaceHolderMain_ctl02_tablerow1").style.display ="none";
    
    document.getElementById("ctl00_PlaceHolderMain_ctl03").style.display ="none";
    document.getElementById("ctl00_PlaceHolderMain_ctl03_tablerow1").style.display ="none";
    
    document.getElementById("ctl00_PlaceHolderMain_ctl04").style.display ="none";
    document.getElementById("ctl00_PlaceHolderMain_ctl04_tablerow1").style.display ="none";
    
    document.getElementById("ctl00_PlaceHolderMain_ctl05").style.display ="";
    document.getElementById("ctl00_PlaceHolderMain_ctl05_tablerow1").style.display ="";
    //document.getElementById("divNew").style.display="none";
    //document.getElementById("divExisting").style.display="";
    
    document.getElementById("hdnWorkspaceType").value = "Existing";
    
    mygrid.loadXML("getworkspacexml.aspx?List=" + listname);
    
}

function clearLoader(id)
{
    document.getElementById("grid").style.display = "";
    document.getElementById("loadinggrid").style.display = "none";
}
function checkUrl()
{
    
    if(document.getElementById("ctl00_PlaceHolderMain_inpName_ctl00_txtTitle").value == "")
    {
        alert('You must enter a project name');
        return false;
    }
    
    var hdnWorkspaceType = document.getElementById("hdnWorkspaceType");
    if(hdnWorkspaceType.value == "Existing")
    {
        if(mygrid.getUserData(mygrid.getSelectedRowId(),"CanPublish") == "Yes")
        {
            if(document.getElementById("hdnSelectedWorkspace").value == "")
            {    
                alert('You must select a workspace');
                return false;
            }
            else
                return true;
        }
        else
        {
            alert('You cannot create a project on the selected workspace');
                return false;
        }
    }
    else
    {
        if(document.getElementById("ctl00_PlaceHolderMain_ctl02_ctl00_txtURL").value == "")
        {
            alert('You must enter a url');
            return false;
        }
        var url = document.getElementById("ctl00_PlaceHolderMain_ctl02_ctl00_txtURL").value;
        document.getElementById("ctl00_PlaceHolderMain_ctl06_RptControls_btnOK").disabled = true;
        var bUrl = checkURLInUse(url);
        document.getElementById("ctl00_PlaceHolderMain_ctl06_RptControls_btnOK").disabled = false;
        
        if(bUrl)
        {
            return true;
        }
        else
            alert('That URL is already in use.');
        
    }
    return false;
}
function mygridChange(id)
{
    document.getElementById("hdnSelectedWorkspace").value=mygrid.getUserData(id,"webid");
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

function checkURLInUse(url)
{

    var req = newRequest();
    
    if(req != null)
    {
        req.open("POST", "checkurl.aspx", false);
        req.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');

        var encoded = "";
        encoded = "URL=" + url;
        req.send(encoded);
        
        if (req.status != 200)
        {
            alert("There was a communications error: " + req.responseText);
            return;
        } 
        else
        {
            var text = req.responseText.trim();
            if(text == "1")
                return true;
        }
    }
    req = null;
    return false;
}
