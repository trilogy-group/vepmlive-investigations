function ToggleSPGridViewProject(link, fECB)
{
	var hdrCell=fECB ? link.parentNode.parentNode.parentNode.parentNode.parentNode : link.parentNode;
	if (hdrCell==null)
	{
		return;
	}
	var hdrRow=hdrCell.parentNode;
	if (hdrRow==null)
	{
		return;
	}
	var img=link.childNodes[0];
	if (img==null)
	{
		return;
	}
	var isExp=false;
	var value=hdrRow.getAttribute("isexp");
	if ((value==null) || ((value !=null) && (value.toLowerCase()=="true")))
	{
		isExp=true;
	}
	isExp=!isExp;
	hdrRow.setAttribute("isexp", (isExp ? "true" : "false"));
	img.src=(isExp ? "/_layouts/images/minus.gif" : "/_layouts/images/plus.gif");
	var dataRow=((hdrRow.nextSibling !=null && hdrRow.nextSibling.nodeName=="#text") ? hdrRow.nextSibling.nextSibling : hdrRow.nextSibling);
	while (dataRow !=null)
	{
		if(dataRow.getAttribute("isSite") != null)
			break;
		value=dataRow.getAttribute("ishdr");
		if ((value !=null) && (value.toLowerCase()=="true"))
		{
			break;
		}
		var value2=dataRow.getAttribute("ishdr2");
		if(value2 != null || isExp == false)
		{
			dataRow.style.display=(isExp ? "" : "none");
			if(value2 != null)
			{
				dataRow.setAttribute("isexp", "false");
				dataRow.childNodes[2].childNodes[0].childNodes[0].src="/_layouts/images/plus.gif";
			}
		}
		dataRow=((dataRow.nextSibling !=null && dataRow.nextSibling.nodeName=="#text") ? dataRow.nextSibling.nextSibling : dataRow.nextSibling);
		
	}
}

function ToggleSPGridViewGroup2(link, fECB)
{
	var hdrCell=fECB ? link.parentNode.parentNode.parentNode.parentNode.parentNode : link.parentNode;
	if (hdrCell==null)
	{
		return;
	}
	var hdrRow=hdrCell.parentNode;
	if (hdrRow==null)
	{
		return;
	}
	var img=link.childNodes[0];
	if (img==null)
	{
		return;
	}
	var isExp=false;
	var value=hdrRow.getAttribute("isexp");
	if ((value==null) || ((value !=null) && (value.toLowerCase()=="true")))
	{
		isExp=true;
	}
	isExp=!isExp;
	hdrRow.setAttribute("isexp", (isExp ? "true" : "false"));
	img.src=(isExp ? "/_layouts/images/minus.gif" : "/_layouts/images/plus.gif");
	var dataRow=((hdrRow.nextSibling !=null && hdrRow.nextSibling.nodeName=="#text") ? hdrRow.nextSibling.nextSibling : hdrRow.nextSibling);
	while (dataRow !=null)
	{
		if(dataRow.getAttribute("isSite") != null)
			break;
		value=dataRow.getAttribute("ishdr2");
		if ((value !=null) && (value.toLowerCase()=="true"))
		{
			break;
		}
		value=dataRow.getAttribute("ishdr");
		if ((value !=null) && (value.toLowerCase()=="true"))
		{
			break;
		}
		dataRow.style.display=(isExp ? "" : "none");
		dataRow=((dataRow.nextSibling !=null && dataRow.nextSibling.nodeName=="#text") ? dataRow.nextSibling.nextSibling : dataRow.nextSibling);
	}
}