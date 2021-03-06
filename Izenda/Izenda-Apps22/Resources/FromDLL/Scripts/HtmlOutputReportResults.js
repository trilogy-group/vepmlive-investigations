/* Copyright (c) 2005-2010 Izenda, L.L.C.

 ____________________________________________________________________
|                                                                   |
|   Izenda .NET Component Library                                   |
|                                                                   |
|   Copyright (c) 2005-2010 Izenda, L.L.C.                          |
|   ALL RIGHTS RESERVED                                             |
|                                                                   |
|   The entire contents of this file is protected by U.S. and       |
|   International Copyright Laws. Unauthorized reproduction,        |
|   reverse-engineering, and distribution of all or any portion of  |
|   the code contained in this file is strictly prohibited and may  |
|   result in severe civil and criminal penalties and will be       |
|   prosecuted to the maximum extent possible under the law.        |
|                                                                   |
|   RESTRICTIONS                                                    |
|                                                                   |
|   THIS SOURCE CODE AND ALL RESULTING INTERMEDIATE FILES           |
|   ARE CONFIDENTIAL AND PROPRIETARY TRADE                          |
|   SECRETS OF DEVELOPER EXPRESS INC. THE REGISTERED DEVELOPER IS   |
|   LICENSED TO DISTRIBUTE THE PRODUCT AND ALL ACCOMPANYING .NET    |
|   CONTROLS AS PART OF AN EXECUTABLE PROGRAM ONLY.                 |
|                                                                   |
|   THE SOURCE CODE CONTAINED WITHIN THIS FILE AND ALL RELATED      |
|   FILES OR ANY PORTION OF ITS CONTENTS SHALL AT NO TIME BE        |
|   COPIED, TRANSFERRED, SOLD, DISTRIBUTED, OR OTHERWISE MADE       |
|   AVAILABLE TO OTHER INDIVIDUALS WITHOUT EXPRESS WRITTEN CONSENT  |
|   AND PERMISSION FROM DEVELOPER EXPRESS INC.                      |
|                                                                   |
|   CONSULT THE END USER LICENSE AGREEMENT(EULA FOR INFORMATION ON  |
|   ADDITIONAL RESTRICTIONS.                                        |
|                                                                   |
|___________________________________________________________________|
*/

//Ajax request for JSON methods-----------------------------------------------------------
/*! JSON v3.3.0 | http://bestiejs.github.io/json3 | Copyright 2012-2014, Kit Cambridge | http://kit.mit-license.org */
(function(n){function K(p,q){function s(a){if(s[a]!==v)return s[a];var c;if("bug-string-char-index"==a)c="a"!="a"[0];else if("json"==a)c=s("json-stringify")&&s("json-parse");else{var e;if("json-stringify"==a){c=q.stringify;var b="function"==typeof c&&r;if(b){(e=function(){return 1}).toJSON=e;try{b="0"===c(0)&&"0"===c(new A)&&'""'==c(new B)&&c(t)===v&&c(v)===v&&c()===v&&"1"===c(e)&&"[1]"==c([e])&&"[null]"==c([v])&&"null"==c(null)&&"[null,null,null]"==c([v,t,null])&&'{"a":[1,true,false,null,"\\u0000\\b\\n\\f\\r\\t"]}'==
c({a:[e,!0,!1,null,"\x00\b\n\f\r\t"]})&&"1"===c(null,e)&&"[\n 1,\n 2\n]"==c([1,2],null,1)&&'"-271821-04-20T00:00:00.000Z"'==c(new D(-864E13))&&'"+275760-09-13T00:00:00.000Z"'==c(new D(864E13))&&'"-000001-01-01T00:00:00.000Z"'==c(new D(-621987552E5))&&'"1969-12-31T23:59:59.999Z"'==c(new D(-1))}catch(f){b=!1}}c=b}if("json-parse"==a){c=q.parse;if("function"==typeof c)try{if(0===c("0")&&!c(!1)){e=c('{"a":[1,true,false,null,"\\u0000\\b\\n\\f\\r\\t"]}');var l=5==e.a.length&&1===e.a[0];if(l){try{l=!c('"\t"')}catch(d){}if(l)try{l=
1!==c("01")}catch(h){}if(l)try{l=1!==c("1.")}catch(m){}}}}catch(X){l=!1}c=l}}return s[a]=!!c}p||(p=n.Object());q||(q=n.Object());var A=p.Number||n.Number,B=p.String||n.String,G=p.Object||n.Object,D=p.Date||n.Date,J=p.SyntaxError||n.SyntaxError,N=p.TypeError||n.TypeError,R=p.Math||n.Math,H=p.JSON||n.JSON;"object"==typeof H&&H&&(q.stringify=H.stringify,q.parse=H.parse);var G=G.prototype,t=G.toString,u,C,v,r=new D(-0xc782b5b800cec);try{r=-109252==r.getUTCFullYear()&&0===r.getUTCMonth()&&1===r.getUTCDate()&&
10==r.getUTCHours()&&37==r.getUTCMinutes()&&6==r.getUTCSeconds()&&708==r.getUTCMilliseconds()}catch(Y){}if(!s("json")){var E=s("bug-string-char-index");if(!r)var w=R.floor,S=[0,31,59,90,120,151,181,212,243,273,304,334],F=function(a,c){return S[c]+365*(a-1970)+w((a-1969+(c=+(1<c)))/4)-w((a-1901+c)/100)+w((a-1601+c)/400)};(u=G.hasOwnProperty)||(u=function(a){var c={},e;(c.__proto__=null,c.__proto__={toString:1},c).toString!=t?u=function(a){var c=this.__proto__;a=a in(this.__proto__=null,this);this.__proto__=
c;return a}:(e=c.constructor,u=function(a){var c=(this.constructor||e).prototype;return a in this&&!(a in c&&this[a]===c[a])});c=null;return u.call(this,a)});var T={"boolean":1,number:1,string:1,undefined:1};C=function(a,c){var e=0,b,f,l;(b=function(){this.valueOf=0}).prototype.valueOf=0;f=new b;for(l in f)u.call(f,l)&&e++;b=f=null;e?C=2==e?function(a,c){var e={},b="[object Function]"==t.call(a),f;for(f in a)b&&"prototype"==f||u.call(e,f)||!(e[f]=1)||!u.call(a,f)||c(f)}:function(a,c){var e="[object Function]"==
t.call(a),b,f;for(b in a)e&&"prototype"==b||!u.call(a,b)||(f="constructor"===b)||c(b);(f||u.call(a,b="constructor"))&&c(b)}:(f="valueOf toString toLocaleString propertyIsEnumerable isPrototypeOf hasOwnProperty constructor".split(" "),C=function(a,c){var e="[object Function]"==t.call(a),b,g;if(g=!e)if(g="function"!=typeof a.constructor)g=typeof a.hasOwnProperty,g="object"==g?!!a.hasOwnProperty:!T[g];g=g?a.hasOwnProperty:u;for(b in a)e&&"prototype"==b||!g.call(a,b)||c(b);for(e=f.length;b=f[--e];g.call(a,
b)&&c(b));});return C(a,c)};if(!s("json-stringify")){var U={92:"\\\\",34:'\\"',8:"\\b",12:"\\f",10:"\\n",13:"\\r",9:"\\t"},x=function(a,c){return("000000"+(c||0)).slice(-a)},O=function(a){for(var c='"',b=0,g=a.length,f=!E||10<g,l=f&&(E?a.split(""):a);b<g;b++){var d=a.charCodeAt(b);switch(d){case 8:case 9:case 10:case 12:case 13:case 34:case 92:c+=U[d];break;default:if(32>d){c+="\\u00"+x(2,d.toString(16));break}c+=f?l[b]:a.charAt(b)}}return c+'"'},L=function(a,c,b,g,f,l,d){var h,m,k,n,p,q,r,s,y;try{h=
c[a]}catch(z){}if("object"==typeof h&&h)if(m=t.call(h),"[object Date]"!=m||u.call(h,"toJSON"))"function"==typeof h.toJSON&&("[object Number]"!=m&&"[object String]"!=m&&"[object Array]"!=m||u.call(h,"toJSON"))&&(h=h.toJSON(a));else if(h>-1/0&&h<1/0){if(F){n=w(h/864E5);for(m=w(n/365.2425)+1970-1;F(m+1,0)<=n;m++);for(k=w((n-F(m,0))/30.42);F(m,k+1)<=n;k++);n=1+n-F(m,k);p=(h%864E5+864E5)%864E5;q=w(p/36E5)%24;r=w(p/6E4)%60;s=w(p/1E3)%60;p%=1E3}else m=h.getUTCFullYear(),k=h.getUTCMonth(),n=h.getUTCDate(),
q=h.getUTCHours(),r=h.getUTCMinutes(),s=h.getUTCSeconds(),p=h.getUTCMilliseconds();h=(0>=m||1E4<=m?(0>m?"-":"+")+x(6,0>m?-m:m):x(4,m))+"-"+x(2,k+1)+"-"+x(2,n)+"T"+x(2,q)+":"+x(2,r)+":"+x(2,s)+"."+x(3,p)+"Z"}else h=null;b&&(h=b.call(c,a,h));if(null===h)return"null";m=t.call(h);if("[object Boolean]"==m)return""+h;if("[object Number]"==m)return h>-1/0&&h<1/0?""+h:"null";if("[object String]"==m)return O(""+h);if("object"==typeof h){for(a=d.length;a--;)if(d[a]===h)throw N();d.push(h);y=[];c=l;l+=f;if("[object Array]"==
m){k=0;for(a=h.length;k<a;k++)m=L(k,h,b,g,f,l,d),y.push(m===v?"null":m);a=y.length?f?"[\n"+l+y.join(",\n"+l)+"\n"+c+"]":"["+y.join(",")+"]":"[]"}else C(g||h,function(a){var c=L(a,h,b,g,f,l,d);c!==v&&y.push(O(a)+":"+(f?" ":"")+c)}),a=y.length?f?"{\n"+l+y.join(",\n"+l)+"\n"+c+"}":"{"+y.join(",")+"}":"{}";d.pop();return a}};q.stringify=function(a,c,b){var g,f,l,d;if("function"==typeof c||"object"==typeof c&&c)if("[object Function]"==(d=t.call(c)))f=c;else if("[object Array]"==d){l={};for(var h=0,m=c.length,
k;h<m;k=c[h++],(d=t.call(k),"[object String]"==d||"[object Number]"==d)&&(l[k]=1));}if(b)if("[object Number]"==(d=t.call(b))){if(0<(b-=b%1))for(g="",10<b&&(b=10);g.length<b;g+=" ");}else"[object String]"==d&&(g=10>=b.length?b:b.slice(0,10));return L("",(k={},k[""]=a,k),f,l,g,"",[])}}if(!s("json-parse")){var V=B.fromCharCode,W={92:"\\",34:'"',47:"/",98:"\b",116:"\t",110:"\n",102:"\f",114:"\r"},b,I,k=function(){b=I=null;throw J();},z=function(){for(var a=I,c=a.length,e,g,f,l,d;b<c;)switch(d=a.charCodeAt(b),
d){case 9:case 10:case 13:case 32:b++;break;case 123:case 125:case 91:case 93:case 58:case 44:return e=E?a.charAt(b):a[b],b++,e;case 34:e="@";for(b++;b<c;)if(d=a.charCodeAt(b),32>d)k();else if(92==d)switch(d=a.charCodeAt(++b),d){case 92:case 34:case 47:case 98:case 116:case 110:case 102:case 114:e+=W[d];b++;break;case 117:g=++b;for(f=b+4;b<f;b++)d=a.charCodeAt(b),48<=d&&57>=d||97<=d&&102>=d||65<=d&&70>=d||k();e+=V("0x"+a.slice(g,b));break;default:k()}else{if(34==d)break;d=a.charCodeAt(b);for(g=b;32<=
d&&92!=d&&34!=d;)d=a.charCodeAt(++b);e+=a.slice(g,b)}if(34==a.charCodeAt(b))return b++,e;k();default:g=b;45==d&&(l=!0,d=a.charCodeAt(++b));if(48<=d&&57>=d){for(48==d&&(d=a.charCodeAt(b+1),48<=d&&57>=d)&&k();b<c&&(d=a.charCodeAt(b),48<=d&&57>=d);b++);if(46==a.charCodeAt(b)){for(f=++b;f<c&&(d=a.charCodeAt(f),48<=d&&57>=d);f++);f==b&&k();b=f}d=a.charCodeAt(b);if(101==d||69==d){d=a.charCodeAt(++b);43!=d&&45!=d||b++;for(f=b;f<c&&(d=a.charCodeAt(f),48<=d&&57>=d);f++);f==b&&k();b=f}return+a.slice(g,b)}l&&
k();if("true"==a.slice(b,b+4))return b+=4,!0;if("false"==a.slice(b,b+5))return b+=5,!1;if("null"==a.slice(b,b+4))return b+=4,null;k()}return"$"},M=function(a){var c,b;"$"==a&&k();if("string"==typeof a){if("@"==(E?a.charAt(0):a[0]))return a.slice(1);if("["==a){for(c=[];;b||(b=!0)){a=z();if("]"==a)break;b&&(","==a?(a=z(),"]"==a&&k()):k());","==a&&k();c.push(M(a))}return c}if("{"==a){for(c={};;b||(b=!0)){a=z();if("}"==a)break;b&&(","==a?(a=z(),"}"==a&&k()):k());","!=a&&"string"==typeof a&&"@"==(E?a.charAt(0):
a[0])&&":"==z()||k();c[a.slice(1)]=M(z())}return c}k()}return a},Q=function(a,b,e){e=P(a,b,e);e===v?delete a[b]:a[b]=e},P=function(a,b,e){var g=a[b],f;if("object"==typeof g&&g)if("[object Array]"==t.call(g))for(f=g.length;f--;)Q(g,f,e);else C(g,function(a){Q(g,a,e)});return e.call(a,b,g)};q.parse=function(a,c){var e,g;b=0;I=""+a;e=M(z());"$"!=z()&&k();b=I=null;return c&&"[object Function]"==t.call(c)?P((g={},g[""]=e,g),"",c):e}}}q.runInContext=K;return q}var J=typeof define==="function"&&define.amd,
A="object"==typeof global&&global;!A||A.global!==A&&A.window!==A||(n=A);if("object"!=typeof exports||!exports||exports.nodeType||J){var N=n.JSON,B=K(n,n.JSON3={noConflict:function(){n.JSON=N;return B}});n.JSON={parse:B.parse,stringify:B.stringify}}else K(n,exports);J&&define(function(){return B})})(this);

function AjaxRequest(url, parameters, callbackSuccess, callbackError, id, dataToKeep) {
  var thisRequestObject;
  if (window.XMLHttpRequest)
    thisRequestObject = new XMLHttpRequest();
  else if (window.ActiveXObject)
    thisRequestObject = new ActiveXObject('Microsoft.XMLHTTP');
  thisRequestObject.requestId = id;
  thisRequestObject.dtk = dataToKeep;
  thisRequestObject.onreadystatechange = ProcessRequest;

  /*thisRequestObject.open('GET', url + '?' + parameters, true);
  thisRequestObject.send();*/
  thisRequestObject.open('POST', url, true);
  thisRequestObject.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
  thisRequestObject.send(parameters);

  function DeserializeJson() {
    var responseText = thisRequestObject.responseText;
    while (responseText.indexOf('"\\/Date(') >= 0) {
      responseText = responseText.replace('"\\/Date(', 'eval(new Date(');
      responseText = responseText.replace(')\\/"', '))');
    }
    if (responseText.charAt(0) != '[' && responseText.charAt(0) != '{')
      responseText = '{' + responseText + '}';
    var isArray = true;
    if (responseText.charAt(0) != '[') {
      responseText = '[' + responseText + ']';
      isArray = false;
    }
    var retObj = eval(responseText);
    if (!isArray)
      return retObj[0];
    return retObj;
  }

  function ProcessRequest() {
    if (thisRequestObject.readyState == 4) {
      if (thisRequestObject.status == 200 && callbackSuccess) {
        var toRet;
        if (thisRequestObject.requestId != 'getrenderedreportset' && thisRequestObject.requestId != 'getcrsreportpartpreview' && thisRequestObject.requestId != 'renderedreportpart')
          toRet = DeserializeJson();
        else
          toRet = thisRequestObject.responseText;
        callbackSuccess(toRet, thisRequestObject.requestId, thisRequestObject.dtk);
      }
      else if (callbackError) {
        callbackError(thisRequestObject);
      }
    }
  }
}
//-------------------------------------------------------------------------------------------

var isNetscape = window.navigator.appName == 'Netscape';
var clientControlId = "";
var reportContentDivId = {};
var formId = {};
var tops = {};
var subReportNames = {};
var allowPaging = {};
var showDataWhenParametersBlank = {};
var HORR_serverDigitSeparator = ".";
var HORR_clientDigitSeparator = ".";
var HORR_UpdateContentInternal_waitingExecut = false;
var HORR_UpdateContentCanceled = false;
var HORR_shortDateFormat = "MM/DD/YYYY";

function urldecode(s) {
  return decodeURIComponent(s).replace(/\+/g, ' ');
}

function HORR_ShowHideFilters(filtersID, buttionId)
{
	var filtersRow = document.getElementById(filtersID);
	var button = null;
	if(buttionId!=null)
		button = document.getElementById(buttionId);
	if(filtersRow.style['display']!='none')
	{
		if(button!=null)
			button.innerHTML = jsResources.ShowFilters;
		filtersRow.style['display']='none';
	}
	else
	{
		if(button!=null)
			button.innerHTML = jsResources.HideFilters;
		filtersRow.style['display']='';
	}
}

function HORR_ForbidSelection()
{
	if(!isNetscape)
		document.onselectstart = document_OnSelectStart;
}

function HORR_SortClear(row)
{
	var cells = row.cells;
	for(var i=0;i<cells.length;i++)
	{
		var cell = cells[i];
		var span = cell.getElementsByTagName("span");
		if(span.length>0)
		{
			span = span[0];
			span.setAttribute("sorted", "None");
			var img = cell.getElementsByTagName("img");
			img = img[1];
			img.style["visibility"] = "hidden";
		}
	}
}

function HORR_GetCell(elem)
{
	while (elem != null && elem.tagName != 'TD')
		elem = elem.parentNode;
	return elem;
}

function HORR_CellOnMouseOver(obj)
{
	var img = obj.getElementsByTagName("img");
	img = img[3];
	img.style["visibility"] = "visible";
}

function HORR_CellOnMouseOut(obj)
{
	var img = obj.getElementsByTagName("img");
	img = img[3];
	img.style["visibility"] = "hidden";
}

function HORR_ClearTableSorting(row)
{
	if (row != null) {
		for (var i =0;i<row.cells.length; i++)
		{
			try{
				var cell = row.cells[i];
				var parent = cell.firstChild;
				var span = parent.firstChild;
				var img = parent.getElementsByTagName("img");
				if (typeof span.setAttribute == "undefined")
					continue;
				span.setAttribute("sorted", "None");
			    try{
			        span.firstChild.setAttribute("sorted", "None");
			    }
			    catch(e){}
				var serverUrlWithDelimiter = responseServer.ResponseServerUrl;
				img[1].src = serverUrlWithDelimiter + "image=1.gif";
				img[1].alt = "Unsorted";
			}catch(e){}
		}
	}
}

function HORR_SortByColumn(span, rowsCount)
{
	var parent = span.parentNode;
	var cell = HORR_GetCell(span);
	var sorted = span.getAttribute("sorted");
	var img = parent.getElementsByTagName("img");
	img = img[1];
	HORR_ClearTableSorting(cell.parentNode);
    
	
    
	var serverUrlWithDelimiter = responseServer.ResponseServerUrl;
	if(sorted == "None")
	{
		HORR_SortClear(EBC_GetRow(span));
		span.setAttribute("sorted", "Asc");
		img.src = serverUrlWithDelimiter + "image=grid-asc.gif";
		img.alt = jsResources.SortedAscending;
		img.style["visibility"] = "visible";
		HORR_Sort("asc", cell, rowsCount);
	}
	else if(sorted=="Desc")
	{
		span.setAttribute("sorted", "Asc");
		img.src = serverUrlWithDelimiter + "image=grid-asc.gif";
		img.alt = jsResources.SortedAscending;
		img.style["visibility"] = "visible";
		HORR_Sort("asc", cell, rowsCount);
	}
	else if(sorted=="Asc")
	{
		span.setAttribute("sorted", "Desc");
		img.src = serverUrlWithDelimiter + "image=grid-desc.gif";
		img.alt = jsResources.SortedDescending;
		img.style["visibility"] = "visible";
		HORR_Sort("desc", cell, rowsCount);
	}
}

function HORR_Sort(order, cell, rowsCount)
{
	var cellIndex = cell.cellIndex;
	var table = cell.parentNode.parentNode;
	var attributes = new Array();
	//attributes.push("bgcolor");
	attributes.push("class");
	if(rowsCount==-1)
		rowsCount = table.rows.length;
	insertionSort(table, cell.parentNode.rowIndex + 1, cell.parentNode.rowIndex + rowsCount, order == "desc", cellIndex, attributes);
}

function HORR_GetInnerText(node)
{
	if(isNetscape)
		return node.textContent;
	else
		return node.innerText;
}

function HORR_OnlyNumbers(str) {
  if (str.substring(0, 1) == "-")
    str = str.substr(1);
  var sepCnt = 0;
  for (var i = 0; i < str.length; i++) {
    var ch = str.charAt(i);
    if (ch == HORR_clientDigitSeparator) {
      sepCnt++;
      if (sepCnt > 1) {
        return false;
      }
      continue;
    }
    if (ch < '0' || ch > '9') {
      return false;
    }
  }
  return true;
}

function sortByFunction(itemA, itemB, reverse)
{
	var a = itemA[0];
	var b = itemB[0];
	if (typeof a == 'string' || typeof b == 'string') {
	    a = a.toString();
	    b = b.toString();
	}

	if (a == b) return (itemA[2] > itemB[2]) ? -1 : 1;
	if (reverse == true)
	    return (a > b) ? -1 : 1;
	else
	    return (a < b) ? -1 : 1;
}

function merge_sort(array, comparison, reverse) {
    if (array.length < 2)
        return array;
    var middle = Math.ceil(array.length / 2);
    return merge(merge_sort(array.slice(0, middle), comparison, reverse),
			merge_sort(array.slice(middle), comparison, reverse),
			comparison, reverse);
}

function merge(left, right, comparison, reverse) {
    var result = new Array();
    while ((left.length > 0) && (right.length > 0)) {
        if (comparison(left[0], right[0], reverse) <= 0)
            result.push(left.shift());
        else
            result.push(right.shift());
    }
    while (left.length > 0)
        result.push(left.shift());
    while (right.length > 0)
        result.push(right.shift());
    return result;
}

function tryParseDate(value, format) {
    var parsedDate = moment(value, format);
    if (!parsedDate.isValid())
        parsedDate = moment(value, HORR_shortDateFormat);
    if (!parsedDate.isValid())
        parsedDate = moment(value);
    return parsedDate;
}

function insertionSort(t, iRowStart, iRowEnd, fReverse, iColumn, leaveAttributes)
{
	var attributes = new Array();
	var iRow = iRowStart;
	if(leaveAttributes)
	{
		for(var i=0;i<leaveAttributes.length;i++)
			attributes[i] = new Array();
		for(iRow = iRowStart; iRow <= iRowEnd ; iRow++)
		{
			for(var i=0;i<leaveAttributes.length;i++)
			{
				var attr = t.rows[iRow].getAttribute(leaveAttributes[i]);
				if(leaveAttributes[i]=="class")   //IE bug workaround
					attr = t.rows[iRow].className;
				
				if(typeof(attr)=="object" && attr!=null)
				{
					attributes[i].push(attr.cssText);
				}
				else
					attributes[i].push(attr);
			}
		}
	}
    // For Dates only
	var dateFormat = HORR_shortDateFormat;
	var sortHandler = jq$(t.rows[0].cells[iColumn]).find('.header-sort-handler');
	if (typeof sortHandler != undefined && sortHandler != null && sortHandler.attr('data-format'))
	    dateFormat = sortHandler.attr('data-format');
    // ---

	var allDates = true;
	var allNumerics = true;
	var arrayToSort = new Array();
	for (var i=iRowStart; i<=iRowEnd;i++)
	{
		var item = new Array();
		var value = "";
		
		if (iColumn!=null)
		{
			if(typeof(t.rows[i].cells[iColumn]) != "undefined")
				value = HORR_GetInnerText(t.rows[i].cells[iColumn]);
		}
		else
			value = HORR_GetInnerText(t.rows[iRowiStart]);

		var valDate = null;
		if (value.length >= 6) {
		    try {
		        var parsedDate = tryParseDate(value, dateFormat);
		        if (parsedDate.isValid())
		            valDate = parsedDate._d;
		    }
			catch (except) { }
		}
		
		var curr = value;
		var minuse = false;
		if (curr.substring(0,1)=="(" && curr.substring(curr.length-1, curr.length) == ")") {
			minuse = true;
			curr = curr.substring(1, curr.length-1);
		}
		if(curr.substring(0, 1)=="$" || 
			curr.substring(0, 1)=="£" || 
			curr.substring(0, 1)=="₤" ||
			curr.substring(0, 1)=="€" ||
			curr.substring(0, 1)=="¥")
			curr = curr.substr(1);
		if (value.substr(value.length - 1, 1) == "%" ||
			value.substr(value.length - 1, 1) == "€")
			curr = curr.substr(0, value.length-1);
			
		var currFormated = curr.replace(/^\s+|\s+$/g, '');
		if (',' != HORR_serverDigitSeparator)
			currFormated = currFormated.replace(/,/g, '');
				
		if ('.' != HORR_serverDigitSeparator)
			currFormated = currFormated.replace(/\./g, '');
				
		currFormated = currFormated.replace(HORR_serverDigitSeparator, HORR_clientDigitSeparator);

		var onlyNumbers = HORR_OnlyNumbers(currFormated);
			
		var currentNum = parseFloat(currFormated);
			
		if (onlyNumbers && !isNaN(currentNum)){
			item[0] = currentNum;
			if (minuse)
				item[0] = -currentNum;
			item[2] = currFormated;
		}
		else if (!isNaN(valDate) && valDate != null && valDate > 0) {
			allNumerics = false;
			item[0] = valDate;
			item[2] = value.toLowerCase();
		} else {			
			if (value) {
				allDates = false;
				allNumerics = false;
			}
			item[0] = value.toLowerCase();
			item[2] = item[0];
		}
		
		item[1] = t.rows[i];
		arrayToSort.push(item);
	}

	var tempArray = [];
	for (var i = 0; i < arrayToSort.length; i++) {
		if (!allDates || !allDates && !allNumerics)
			arrayToSort[i][0] = arrayToSort[i][2];
        arrayToSort[i].push(i);
        tempArray.push(arrayToSort[i]);
    }
    arrayToSort = merge_sort(arrayToSort, sortByFunction, fReverse);
    //fReverse = true;
	//for (var i = 0; i < arrayToSort.length; i++) {
	//    if (arrayToSort[i] != tempArray[i]) {
	//        fReverse = false;
	//        break;
	//    }
	//}

	var table = t.parentNode;
	var pos = /*fReverse ? iRowStart :*/ iRowEnd;
	var dx = /*fReverse  ? 1 :*/ - 1;
	while (arrayToSort.length > 0)
	{
		var item = arrayToSort.pop()[1];
		if ((iRowStart <= pos) && (pos <= iRowEnd))
			t.insertBefore(item, t.rows[pos]);
		pos+=dx;
	}
	
	if(leaveAttributes)
		for(iRow = iRowStart; iRow <= iRowEnd ; iRow++)
		{
			for(var i=0;i<leaveAttributes.length;i++)
			{
				var attr = t.rows[iRow].getAttribute(leaveAttributes[i]);
				if(typeof(attr)=="object" && attr!=null)
					attr.cssText = attributes[i][iRow-iRowStart];
				else
				{
					if(leaveAttributes[i]=="class")
						t.rows[iRow].className = attributes[i][iRow-iRowStart];
					else
						t.rows[iRow].setAttribute(leaveAttributes[i], attributes[i][iRow-iRowStart]);
				}
			}
		}
	
	return;
}

function document_OnSelectStart(evt)
{
	evt = (evt) ? evt : window.event;
	if (evt.srcElement.tagName !="INPUT")
	{
		evt.returnValue = false;
		evt.cancelBubble = true;
	}
}

function HORR_HideIfOpenerPresents(id)
{
	var hide;
	if(isNetscape)
		hide = (history.length == 1);
	else
		hide = window.opener!=null;
	if(hide)
	{
		var control = document.getElementById(id);
		control.style["display"] = "none";
	}
}

/*function HORR_GoClick(id, selectId, formId)
{
	HORR_UpdateContent(id);
	var select = document.getElementById(selectId);
	var url = select.options[select.selectedIndex].getAttribute("RedirectUrl");
	
	if(isNetscape)
	{
		var frame = document.createElement("iframe");
		frame.style.display='none';
		document.body.appendChild(frame);
		frame.src = url;
	}
	else if(url != "")
		window.open(url, "_top");
}*/

function IsVisible(obj)
{	
	while(obj!=null)
	{
		if(obj.style!=null && obj.style.display=="none")
			return false;
		obj = obj.parentNode;
	}
	return true;
}

function HORR_UpdateVisibleContent(id, top)
{
	tops[id] = top;
	var reportContent = document.getElementById(reportContentDivId[id]);
	if(IsVisible(reportContent))
		HORR_UpdateContent(id, null, true);
}

function HORR_UpdateVisibleContent2(id, top, params)
{
	tops[id] = top;
	HORR_UpdateContent(id, null, true, params);
}

function HORR_NotMultilySelect(e)
{
	if(e) ebc_mozillaEvent = e;
	var row = EBC_GetRow(e);
	if (row == null)
		return true;
	var operatorSel = EBC_GetSelectByName(row, 'Operator');
	if(operatorSel==null)
		return true;
	
	return ((operatorSel.value != "Equals_Multiple") && (operatorSel.value != "NotEquals_Multiple") && (operatorSel.value != "..."));
}

function HORR_UpdateContent(id, continueScript, pause, params)
{
    var content = jsResources.Loading + "...<br><image src='" + responseServerWithDelimeter + "image=loading.gif'/>";
	if (!(AdHoc.maxVersion < 6.6))
	{
		//var lastExecTimeHidden = document.getElementById("report_lastExecuteTime");
		//if (lastExecTimeHidden && lastExecTimeHidden.value != undefined && lastExecTimeHidden.value != null && lastExecTimeHidden != "null")
		//	content += "<br/>Estimated time remaining <br/> based on last execution: " + lastExecTimeHidden.value + " seconds.";
	    content += "<br/><input type='button' onclick='javascript:HORR_CancelUpdatingContent();' value='" + jsResources.Cancel + "'></input>"
	}
	ShowDialog(content);
		
	//var func = function() {HORR_UpdateContentInternal(id, continueScript, params)};

	if(pause == null || pause == false)
		HORR_UpdateContentInternal(id, null, params);
	else
	{
		if (!HORR_UpdateContentInternal_waitingExecut)
		{
			HORR_UpdateContentInternal_waitingExecut = true;
			var func = function() {HORR_UpdateContentInternal(id, continueScript, params)};
			setTimeout(func, 100);
		}
	}
}

function HORR_CancelUpdatingContent()
{
	hm();
	try{
		HORR_UpdateContentCanceled = true;
		TabStrip_TogglePrevTab();
	}
	catch(exc){}
}

function HORR_UpdateContentMultiple(ids, top, params)
{
	ShowDialog(jsResources.Loading + "...<br><image src='"+responseServerWithDelimeter+"image=loading.gif'/>");
	
	var func = function() {HORR_UpdateContentMultipleInternal(ids, top, params)};
	setTimeout(func, 100);

}

var callCount;
function HORR_UpdateContentMultipleInternal(ids, top, params)
{
	responseServer.XmlHttpFormSubmit(document.getElementById(formId[ids[0]]));
	callCount = ids.length;
	for(var i=0;i<ids.length;i++)
	{
		tops[ids[i]] = top;
		HORR_UpdateContentInternal(ids[i], null, params, false);		
	}
}

function HORR_UpdateContentInternal(id, continueScript, params, needPostback) {
 HORR_UpdateContentCanceled = false;
  var data = "";
  var textAreas = new Array();
  var filters = document.getElementById('reportViewer_Explorer_Filters');
  if (filters != null && filters.rows != null) {
    var rowsNum = filters.rows.length;
    for (var index = 0; index < rowsNum; index++) {
      var textArea = EBC_GetElementByName(filters.rows[index], "Edit1", "TEXTAREA");
      if (textArea != null) {
        data = data + textArea.value + String.fromCharCode(1);
        textAreas[textAreas.length] = textArea;
      }
    }
  }
  EBC_AnalyzeCopyPaste(data);

	if (textAreas.length > 0)
	{
		for (var cnt = 0; cnt < textAreas.length; cnt++)
			textAreas[cnt].value = ebc_parsedValues[cnt];
	}

	HORR_UpdateContentInternal_waitingExecut = false;
	var reportContent = document.getElementById(reportContentDivId[id]);
	//var ddlTopCount = document.getElementById(ddlTopCountId[id]);
	var subReportName = subReportNames[id];

	var wwidth = jq$(window).width();
	var wheight = jq$(window).height();

	if(needPostback==null)
		needPostback = true;
	var url = responseServer.ResponseServerUrl + 'wsarg0=' + wwidth + '&wsarg1=' + wheight + "&" + "p=htmlreport" + "&" + "reportonly=1" + "&" + "addstyles=0" + "&" + "contentId=" + id 
		+ (subReportName!=null ? "&" + "srn="+subReportName : "") + "&" + "ap=" + (allowPaging[id]==true ? "1" : "0") + 
		"&" + "sdwpb=" + (showDataWhenParametersBlank[id]==true ? "1" : "0") + "&invalidateInCache=1";

	if(tops[id]!=null)
		url = url + "&" + "top=" + tops[id];
		
	url = url + "&" + "ts=" + (new Date()).getTime();

	if(params!=null)
	  url = url + "&" + params;
	responseServer.RequestData(
		url, 
		HORR_UpdateContentInternalCallback,
		true,
		needPostback ? formId[id] : null,
		{
			reportContent:reportContent,
			continueScript:continueScript
		}	
	);
}

function EvalGloballyOld(data) {
  var fixedData = data.trim();
  if (fixedData.substr(0, 4) == '<!--' || 'a' == '-->')
    fixedData = fixedData.substr(4);
  if (fixedData.substr(fixedData.length - 3, 3) == '-->')
    fixedData = fixedData.substr(0, fixedData.length - 3);
  fixedData = fixedData.trim();
	(window.execScript || function (fixedData) {
		window["eval"].call(window, fixedData);
	})(fixedData);
}

function HORR_UpdateContentInternalCallback(url, xmlHttpRequest, arg) {
	if (HORR_UpdateContentCanceled)
		return;

	document.body.style.cursor = 'auto';
	if (callCount != null)
		callCount = callCount - 1;
	if (callCount == null || callCount <= 0) {
		hm();
		callCount = 0;
	}
	ReportScripting.loadReportResponse(xmlHttpRequest.responseText, arg.reportContent);
	if (arg.continueScript != null && arg.continueScript != "")
		eval(arg.continueScript);
	AdHoc.Utility.InitGaugeAnimations(null, null, false);
}

function HORR_Init(id, divId, fId, top, subReportName, ap, refreshInterval, sdwpb, digitSeparator, maxVersion, dateFormat)
{
	AdHoc.maxVersion = maxVersion;
	clientControlId = id;
	reportContentDivId[id] = divId;
	formId[id] = fId;
	tops[id] = top;
	subReportNames[id] = subReportName;
	allowPaging[id] = ap;
	showDataWhenParametersBlank[id] = sdwpb;
	
	HORR_shortDateFormat = dateFormat;
	HORR_serverDigitSeparator = digitSeparator;
	
	if(refreshInterval>0)
		setInterval("HORR_UpdateContentInternal('" + id + "', null, 'checkHash=1', false)", refreshInterval);
}

var fieldSelect = null;
function HORR_AddField(id, obj, deleteFieldSelectId, showFilters)
{
	var field = obj.value;
	fieldSelect = obj;
	if (showFilters)
	{
		var typeGroup = obj.options[obj.selectedIndex].getAttribute("dataTypeGroup");
		var type = obj.options[obj.selectedIndex].getAttribute("dataType");
		var tmpSel = document.createElement('select');
		var tmpDiv = document.createElement('div');
		tmpDiv.appendChild(tmpSel);
		var f = function() {HORR_AddField_Callback(tmpDiv, id, field, deleteFieldSelectId);};
		EBC_LoadData(
			"FunctionList",
			"type=" + type + 
			"&" + "typeGroup=" + typeGroup +
			"&" + "includeBlank=false" + 
			"&" + "includeGroupBy=true",
			tmpSel,
			true,
			f);
	}
	else
	{
		responseServer.ExecuteCommand("addField", "field=" + field, false);		
    var deleteFieldSelect = document.getElementById(deleteFieldSelectId);
		HORR_AfterAddField(id, field, deleteFieldSelectId, deleteFieldSelect.options.length);
	}
}

function HORR_AddField_Callback(tmpDiv, id, field, deleteFieldSelectId) {
  var positionVisibility = "";
  if (AdHoc.maxVersion < 6.6)
    positionVisibility = "display:none;";
	var tmpSel = tmpDiv.firstChild;
	var html = "<table width=\"auto\"><tr><td style=\"text-align:left;\"><b>" + jsResources.PleaseChooseAFunction + "</b></td>";
	html += "<td style=\"" + positionVisibility + "\">&nbsp;&nbsp;&nbsp;&nbsp;</td><td style=\"text-align:left;" + positionVisibility + "\"><b>" + jsResources.PleaseChooseAPosition + ".</b></td></tr>";
	html += "<tr><td style=\"vertical-align:top;text-align:left;\">";
	html += "<table border='0' id='RadioButtonFunctionListTable'>";
	for(var i = 0; i < tmpSel.options.length; i++) {
		var optionValue = tmpSel.options[i].value;
		var optionText = tmpSel.options[i].innerHTML;
		html += "<tr><td><input name='RadioButtonFunctionList' type='radio' " + (optionValue == "GROUP" ? "checked" : "") +
			" value='" + optionValue +
			"' id='RadioButtonFunctionList_" + i +
			"'/>&nbsp;" + optionText +
			"</tr></td>";
	}
	html += "</table></td>";
	html += "<td style=\"" + positionVisibility + "\">&nbsp;&nbsp;&nbsp;&nbsp;</td><td style=\"vertical-align:top;text-align:left;" + positionVisibility + "\">";
  html += "<table border='0' id='RadioButtonPositionListTable'>";
  var fieldsNum = -1;
  var existingFields = new Array();
  if (deleteFieldSelectId != null) {
    var deleteFieldSelect = document.getElementById(deleteFieldSelectId);
    if (deleteFieldSelect != null) {
      for (var index = 0; index < deleteFieldSelect.options.length; index++) {
        if (deleteFieldSelect.options[index].innerHTML != "...") {
          fieldsNum++;
          existingFields[fieldsNum] = deleteFieldSelect.options[index].innerHTML;
        }
      }
    }
  }
  fieldsNum++;
  var optionValue = 0;
  var optionText = "0 - Before <i>" + existingFields[0] + "</i>";
  html += "<tr><td><input name='RadioButtonPositionList' type='radio' value='" + optionValue +
		"' id='RadioButtonPositionList_" + i +
		"'/>&nbsp;" + optionText +
		"</tr></td>";
  for (var i = 1; i <= fieldsNum; i++) {
    var optionValue = i;
    var optionText = i + " - After <i>" + existingFields[i - 1] + "</i>";
    var selected = '';
    if (i == fieldsNum)
      selected = ' checked="checked"';
    html += "<tr><td><input name='RadioButtonPositionList' type='radio'" + selected + " value='" + optionValue +
		"' id='RadioButtonPositionList_" + i +
		"'/>&nbsp;" + optionText +
		"</tr></td>";
  }
  html += "</table></td>";
	html += "</tr><tr><td colspan=\"3\" style=\"text-align:center\">";
	html += "<input type='button' value='OK' onclick=\"HORR_AddField_Close('" + id + "', '" + field + "', '" + deleteFieldSelectId + "')\">";
	html += "</td></tr></table>";
	ShowDialog(html, 'auto', 100);
}


function HORR_AddField_Close(id, field, deleteFieldSelectId)
{
  hm();
  var table = document.getElementById("RadioButtonFunctionListTable");
  var body = table.tBodies[0];
  var rowCount = body.rows.length;
  var func;
  for (var i = 0; i < rowCount; i++) {
    var row = body.rows[i];
    var radioButton = row.childNodes[0].childNodes[0];
    if (radioButton.checked) {
      func = radioButton.attributes["value"].value;
      break;
    }
  }
  table = document.getElementById("RadioButtonPositionListTable");
  body = table.tBodies[0];
  rowCount = body.rows.length;
  var pos = 1000;
  for (var i = 0; i < rowCount; i++) {
    var row = body.rows[i];
    var radioButton = row.childNodes[0].childNodes[0];
    if (radioButton.checked) {
      pos = radioButton.attributes["value"].value;
      break;
    }
  }
	responseServer.ExecuteCommand("addField", "field=" + field + "&" + "function=" + func + "&position=" + pos, false);
	HORR_AfterAddField(id, field, deleteFieldSelectId, pos);
}

function HORR_AfterAddField(id)
{
  HORR_UpdateContent(id, 'RequestAddDelete();', true);
}

function RequestAddDelete() {
  var requestString = 'wscmd=adddeletefieldscontent';
  AjaxRequest('./rs.aspx', requestString, AcceptAddDelete, null, 'adddeletefieldscontent');
}

function AcceptAddDelete(returnObj, id) {
  if (id != 'adddeletefieldscontent' || returnObj == undefined || returnObj == null)
    return;
  if (returnObj.length != 2)
    return;
  var textsList = returnObj[0];
  var valuesList = returnObj[1];
  if (textsList == null || valuesList == null || textsList.length != valuesList.length || textsList.length <= 0)
    return;
  var ftd = jq$('select[id$=FieldsToDelete]');
  if (ftd.length == 0)
    return;
  ftd = ftd[0];
  ftd.options.length = 0;
  var lCnt = 0;
  var addSelStr = '';
  while (lCnt < textsList.length) {
    if (textsList[lCnt] == "###ADD###") {
      addSelStr = valuesList[lCnt];
      lCnt++;
      continue;
    }
    var newOpt = new Option();
    newOpt.text = textsList[lCnt];
    newOpt.value = valuesList[lCnt];
    ftd.options.add(newOpt);
    lCnt++;
  }
  if (addSelStr == '')
    return;
  var fta = jq$('select[name$=FieldsToAdd]');
  if (fta.length == 0)
    return;
  fta = fta[0];
  var p1Ind = fta.outerHTML.indexOf('>');
  var p1 = fta.outerHTML.substr(0, p1Ind + 1);
  var p3Ind = fta.outerHTML.lastIndexOf('<');
  var p3 = fta.outerHTML.substr(p3Ind);
  fta.outerHTML = p1 + addSelStr + p3;
}

function HORR_DeleteField(id, field)
{
	if(field.value!=null)
	{
		field = field.value;
	}
	if(field!="...")
	{
		responseServer.ExecuteCommand("deleteField", "field=" + field, false);
		HORR_UpdateContent(id, 'RequestAddDelete();', true);
	}
}

function HORR_PageChange(id, from, to, count)
{
	HORR_PageChange("", from, to, count);
}

function HORR_PageChange(rn, id, from, to, count)
{
	var param = "rn=" + rn + "&results=" + from + "-" + to;
	if (count != null && count > 0)
		param = param + "&" + "resultCount="+count;
	HORR_UpdateContent(id, "", true, param);
}


// Href tooltips functions
var FADINGTOOLTIP;
var FadingTooltipList = {};
var wnd_height, wnd_width;
var tooltip_height, tooltip_width;
var tooltip_shown=false;
var	transparency = 100;
var timer_id = 1;
			
function DisplayTooltip(tooltip_url)
{
	tooltip_shown = (tooltip_url != "")? true : false;
	
	if (tooltip_shown)
	{
		FADINGTOOLTIP = FadingTooltipList[tooltip_url];
		if (FADINGTOOLTIP==null)
		{
			var obody=document.getElementsByTagName('body')[0];
			var frag=document.createDocumentFragment();
			FADINGTOOLTIP = document.createElement('div');
			FADINGTOOLTIP.style.border = "darkgray 1px outset";
			FADINGTOOLTIP.style.width = "auto";
			FADINGTOOLTIP.style.height = "auto";
			FADINGTOOLTIP.style.color = "black";
			FADINGTOOLTIP.style.backgroundColor = "white";
			FADINGTOOLTIP.style.position = "absolute";
			FADINGTOOLTIP.style.zIndex = 1000;
			frag.appendChild(FADINGTOOLTIP);
			obody.insertBefore(frag,obody.firstChild);
			window.onresize = UpdateWindowSize;
			document.onmousemove = AdjustToolTipPosition;
			
			FADINGTOOLTIP.innerHTML = jsResources.Loading + "...<br><image src='"+responseServerWithDelimeter+"image=loading.gif'/>";
			//EBC_GetData(tooltip_url, null, DisplayTooltip_CallBack, tooltip_url);
			responseServer.RequestData(tooltip_url, DisplayTooltip_CallBack);
		}
		FADINGTOOLTIP.style.display = "";
		FADINGTOOLTIP.style.visibility = "visible";
		FadingTooltipList[tooltip_url] = FADINGTOOLTIP;
	}
	else
	{
		if (FADINGTOOLTIP != null)
		{
			clearTimeout(timer_id);
			FADINGTOOLTIP.style.visibility="hidden";
			FADINGTOOLTIP.style.display = "none";
		}
	}
}

function DisplayTooltip_CallBack(url, xmlHttpRequest)
{
	if (xmlHttpRequest.status==200)
	{	
		var toolTip = FadingTooltipList[url];
		toolTip.innerHTML = xmlHttpRequest.responseText;
		if (toolTip == FADINGTOOLTIP)
			tooltip_height=(FADINGTOOLTIP.style.pixelHeight)? FADINGTOOLTIP.style.pixelHeight : FADINGTOOLTIP.offsetHeight;
		transparency = 0;
		AdHoc.Utility.InitGaugeAnimations(null, null, true);
	}
}

function AdjustToolTipPosition(evt)
{
	evt = (evt) ? evt : window.event;
	if(tooltip_shown)
	{
		var scrollTop = document.documentElement.scrollTop + document.body.scrollTop;
		var scrollLeft = document.documentElement.scrollLeft + document.body.scrollLeft;
		WindowLoading();
		
		var offset_y = evt.clientY + tooltip_height + 15;
		var top = evt.clientY + scrollTop + 15;
		if (offset_y > wnd_height)
		{
			var offset_y2 = evt.clientY - tooltip_height - 15;
			top = evt.clientY - tooltip_height + scrollTop -15;
			if (offset_y2 < 0)
			{
				top = (wnd_height - tooltip_height) / 2 + scrollTop;
			}
		}
		
		var offset_x = evt.clientX + tooltip_width + 15;
		var left = evt.clientX + scrollLeft + 15;
		if (offset_x > wnd_width)
		{
			var dx = offset_x - wnd_width;
			var offset_x2 = evt.clientX - tooltip_width - 15;
			var left2 = evt.clientX - tooltip_width + scrollLeft - 15;
			if (offset_x2 < 0)
			{
				var dx2 = -offset_x2;
				if (dx2 < dx)
					left = left2;
			}
			else
			{
				left = left2;
			}
	}
	if (tooltip_height > 100) {
	  top = scrollTop + evt.clientY - tooltip_height / 3;
	}
	
		FADINGTOOLTIP.style.left =  left + 'px';
		FADINGTOOLTIP.style.top = top + 'px';
	}
}

function WindowLoading()
{
	tooltip_width = (FADINGTOOLTIP.style.pixelWidth) ? FADINGTOOLTIP.style.pixelWidth : FADINGTOOLTIP.offsetWidth;
	tooltip_height=(FADINGTOOLTIP.style.pixelHeight)? FADINGTOOLTIP.style.pixelHeight : FADINGTOOLTIP.offsetHeight;
	UpdateWindowSize();
}
			
function ToolTipFading()
{
	if(transparency <= 100)
	{
		FADINGTOOLTIP.style.filter="alpha(opacity="+transparency+")";
		transparency += 5;
		timer_id = setTimeout('ToolTipFading()', 35);
	}
}

function UpdateWindowSize() 
{
	wnd_height=document.body.clientHeight;
	wnd_width=document.body.clientWidth;
}

var canChangePivot = false;
function HORR_PivotFieldChanged(e, obj, id, pivotFunctionId)
{
	if(e) ebc_mozillaEvent = e;
	var row = EBC_GetRow(obj);
	var field = obj.value;
	if (EBC_IsUserEvent())
		canChangePivot = true;
	EBC_SetFunctions(row, false, false, "GROUP", false, "PivotFunction", true, false, "PivotField");
}

function HORR_PivotFunctionChanged(e, obj, id)
{
	if(e) ebc_mozillaEvent = e;
	if (!EBC_IsUserEvent())
	{
		if (!canChangePivot)
			return;
	}
	canChangePivot = false;
	var row = EBC_GetRow(obj);
	var func = obj.value;
	var columnSel = EBC_GetSelectByName(row, "PivotField");
	var field = columnSel.value;
	responseServer.ExecuteCommand("changePivot", "field=" + field + "&" + "function="+func, true, HORR_PivotFunctionChangedCallback, id);
}

function HORR_PivotFunctionChangedCallback(url, xmlHttpRequest, arg)
{
	HORR_UpdateContent(arg, null, true);
}

function HORR_ShowHideReport(btn)
{
	var table = EBC_GetParentTable(btn);
	var td = EBC_GetColumn(table);
	for (var i=0;i<td.childNodes.length;i++)
	{
		var node = td.childNodes[i];
		if (node.className == "DashPartBody" || node.className == "DashPartBodyNoScroll")
		{
			var hidden = (node.style.visibility == "hidden");
			if (hidden)
			{
				node.style["visibility"] = "visible";
				node.style.display = "";
				
			}
			else
			{
				node.style["visibility"] = "hidden";
				node.style.display = "none";
			}
		}
	}
}

function HORR_ShowHideReportHeaderButtons(row, show)
{
	for (var i=0;i<row.cells.length;i++)
	{
		var cell = row.cells[i];
		for (var j=0;j<cell.childNodes.length;j++)
		{
			var obj = cell.childNodes[j];
			if (obj.tagName == "IMG" || obj.tagName == "A" || obj.tagName == "DIV")
				obj.style.visibility = show ? "visible" : "hidden";
		}
	}
}

function HORR_CloseReport(obj)
{
	var table = EBC_GetParentTable(obj);
	var td = EBC_GetColumn(table);
	td.style.visibility = "hidden";
	td.style.display = "none";
}

function DisplayMapNativeToolTip(region, show)
{
    var image = region.parentNode.parentNode.getElementsByTagName('img')[0];
    if (show)
    	image.setAttribute('title', image.getAttribute('longdesc') != null ? image.getAttribute("longdesc") : '');
    else
        image.setAttribute('title', '');
}