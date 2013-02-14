function deleteTimesheets()
{
    if(confirm('Are you sure you want to delete those timesheet(s)?'))
    {
        var ids = mygrid.getCheckedRows(0).split(',');

        var timesheets = "";

        for(var i = 0;i<ids.length;i++)
        {
	        if(ids[i] != "")
	        {
		        timesheets += "," + mygrid.getUserData(ids[i],"tsuid");
	        }
        }
        if(timesheets.length > 0)
	        timesheets = timesheets.substring(1);
        else
	        return;
        	
        sm('dlgProcessing',200,100);
        dhtmlxAjax.post(weburl + "/_layouts/epmlive/dotsaction.aspx","action=deleteTS&ts_uids=" + timesheets,closeApprove);
	}
}

function closeApprove(loader)
{
	if(loader.xmlDoc.responseText!=null)
    {
        if(loader.xmlDoc.responseText.substring(0,5) != "Error")
        {
            var strPeriod = loader.xmlDoc.responseText;

            window.location.href = window.location.href;            
        }
        else
        {
            alert(loader.xmlDoc.responseText.replace(/<br>/g,"\r\n"));
            hm('dlgProcessing');
        }
    }
    else
    {
        alert("Response contains no XML");
        hm('dlgProcessing');
    }
}
//=========================tsnotes========================
function eXcell_tsnotes(cell){                                    //excell name is defined here
    if (cell){                                                     //default pattern, just copy it
        this.cell = cell;
        this.grid = this.cell.parentNode.grid;
        if(!this.grid._grid_notes)
        {
			var z=document.getElementById("tsnotesgrid");
			z.onclick=function(e){ (e||event).cancelBubble=true; }
			
			if (_isIE) { 
				z.style.position="absolute"
				z.style.top="0px"
			}
			document.body.insertBefore(z,document.body.firstChild);
 
			this.grid._grid_notes = z;
		}
    }
    this.setValue=function(val){
		this.cell._notes = val;
		if(val != "")
			this.setCValue("<img src='/_layouts/images/ICDISC.GIF'>");
		else
			this.setCValue("&nbsp;");
			
    }
    this.getValue=function(){
		return this.cell._notes;
    }
    this.edit=function(){
			
		document.getElementById("tsnotes").value = this.getValue();

		var arPos = this.grid.getPosition(this.cell);

		if(arPos[0] + 200 > document.body.clientWidth)
			this.grid._grid_notes.style.left=document.body.clientWidth - 210;
		else
			this.grid._grid_notes.style.left=arPos[0];
		
		if((arPos[1] + 100) > (document.body.clientHeight + document.body.scrollTop))
			this.grid._grid_notes.style.top=document.body.clientHeight + document.body.scrollTop - 105;
		else
			this.grid._grid_notes.style.top=arPos[1];

		this.grid._grid_notes.style.display="";
    }
    this.detach=function(){
		
		var oldValue = this.getValue();
		
        this.setValue(document.getElementById("tsnotes").value); 

		this.grid._grid_notes.style.display="none";

        return oldValue != this.getValue();
		
    }
}
eXcell_tsnotes.prototype = new eXcell;


//=========================timeeditor========================
function eXcell_timeeditor(cell){                                    //excell name is defined here
    if (cell){                                                     //default pattern, just copy it

        this.cell = cell;
        this.grid = this.cell.parentNode.grid;
        if(!this.grid._grid_mc)
        {
			var z=document.getElementById("timeeditorgrid");

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
		
		if(val.split('|')[0] != "")
		{
			var strVals = val.split('|');
			var hours = 0;

			for(var i = 0;i<strVals.length;i+=2)
			{
				if(strVals[i] == "N")
				{
					this.cell._notes = strVals[i+1];
				}
				else
				{
					hours += parseFloat(strVals[i + 1]);
				}
			}
		}
        this.setCValue(hours);
        
        this.cell._value = hours;
        this.cell._values = val;
    }
    this.getCValue=function()
    {
		return 4;
    }
    this.getValue=function(){
		return this.cell._value;
    }
    this.edit=function(){

		val=this.cell._values;

		document.getElementById("timeeditor-N").value = "";
		
		if(val.split('|')[0] != "")
		{
			var strVals = val.split('|');
			
			for(var i = 0;i<strVals.length;i+=2)
			{
				var inp = document.getElementById("timeeditor-" + strVals[i]);
				if(inp != null)
					inp.value = strVals[i + 1];
			}
		}
		
		//Position
		var arPos = this.grid.getPosition(this.cell);

		if(arPos[0] + 200 > document.body.clientWidth)
			this.grid._grid_mc.style.left=document.body.clientWidth - 210;
		else
			this.grid._grid_mc.style.left=arPos[0];
		
		if((arPos[1] + 100) > (document.body.clientHeight + document.body.scrollTop))
			this.grid._grid_mc.style.top=document.body.clientHeight + document.body.scrollTop - 105;
		else
			this.grid._grid_mc.style.top=arPos[1];
			
		this.grid._grid_mc.style.display="";
    }
    this.detach=function(){
		
		this.grid._grid_mc.style.display="none";
		
		val=this.cell._values;
		
		var newValues = "";
		
		var newValue = 0;
		
		if(val.split('|')[0] != "")
		{
			var strVals = val.split('|');
			
			for(var i = 0;i<strVals.length;i+=2)
			{
				var inp = document.getElementById("timeeditor-" + strVals[i]);
				if(inp != null)
				{
					if((parseFloat(inp.value) == "NaN" || inp.value == "") && strVals[i] != "N")
						newValues += "|" + strVals[i] + "|0";
					else
						newValues += "|" + strVals[i] + "|" + inp.value;
				}
			}
			
			if(newValues.length > 1)
				newValues = newValues.substring(1);
		}
		
		var oldValue = this.getValue();

        this.setValue(newValues); 

        return oldValue != this.getValue();
		
    }
}
eXcell_timeeditor.prototype = new eXcell;