function StringBuilder(value) {

    StringBuilder.prototype.append = function (value) {
        if (value) {
            this.strings.push(value);
        }
    }

    StringBuilder.prototype.appendLine = function (value) {
        this.strings.push(value + "\n");
    }

    StringBuilder.prototype.clear = function () {
        this.strings.length = 1;
    }

    StringBuilder.prototype.toString = function () {
        return this.strings.join("");
    }

    this.strings = new Array("");
    this.append(value);
}

var XMLValue = function (value) {
    // Convert & to &amp;  and < to &lt; and  > to &gt;
    var s = value;
    s = s.replace("&", "&amp;");
    s = s.replace("<", "&lt;");
    s = s.replace(">", "&gt;");
    return s;
}


var MakeDelegate = function (target, method) {
    if (method == null) {
        throw ("Method not found");
    }

    return function () {
        return method.apply(target, arguments);
    }
}

function Guid(value) {

    var S4 = function () {
        return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
    }

    Guid.prototype.newGuid = function () {
        this.value = (S4() + S4() + "-" + S4() + "-" + S4() + "-" + S4() + "-" + S4() + S4() + S4());
        return this.value;
    }

    Guid.prototype.isGuid = function () {
        return /^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$/.test(this.value);
    }

    this.value = value;
}


JSON_ConvertString = function (jsonString) {
    // this doesn't work. Get syntax error at runtime. don't know why
    //if (JSON && JSON.parse) {
    //    jsonObject = JSON.parse(jsonString);
    //}
    //else {
    return eval('(' + jsonString + ')');
    //jsonObject = jsonObject.Reply;
    //}
}

JSON_ValidateServerResult = function (jsonObject) {
    try {

        if (jsonObject.Result.Status == 0)
            return true;

        alert("Server Error Reported : " + jsonObject.Result.Context + " - " + jsonObject.Result.Error.ID.toString() + ":" + jsonObject.Result.Error.Value);
        return false;

    }
    catch (e) {
        alert("JSON_ValidateServerResult exception : " + e.toString());
        return false;
    }
}


JSON_GetArray = function (json, item) {
    var jarr = [];
    if (json != null && json[item] != null) {
        if (json[item].length != null) {
            for (var i = 0; i < json[item].length; i++) {
                jarr.push(json[item][i]);
            }
        }
        else
            jarr.push(json[item]);
    }
    return jarr;
}

function QueryParameters() {
    this.params = new Array("");
    var query = window.location.search.substring(1);
    var parms = query.split('&');
    for (var i = 0; i < parms.length; i++) {
        var pos = parms[i].indexOf('=');
        if (pos > 0) {
            var key = parms[i].substring(0, pos);
            var val = parms[i].substring(pos + 1);
            this.params[key] = val;
        }
    }
}

function GetLookup(sURL, id) {
    //var s = "<Request><EPKGet><PortAdmin><LookupRequest><LookupID>" + id.toString() + "</LookupID></LookupRequest></PortAdmin></EPKGet></Request>";
    var s = "<Request><EPKGet><LookupList><FieldListID>" + id.toString() + "</FieldListID></LookupList></EPKGet></Request>";
    return WebServiceXMLRequest(sURL, "EPKRequest", s);
}

function WebServiceXMLRequest(sURL, sContext, sXML) {
    var sReplyXML = "";
    try {
        var jsonParams = {};
        jsonParams['sContext'] = sContext;
        jsonParams['sRequest'] = sXML;
        sURL += "/XMLRequest";

        //var oXMLHttp = new ActiveXObject("Microsoft.XMLHTTP");
        //alert(sURL);
        //alert(sXML);
        var oXMLHttp = new XMLHttpRequest();
        oXMLHttp.open("POST", sURL, false);
        oXMLHttp.setRequestHeader("Content-Type", "application/json; charset=utf-8");
        // need to add ScriptManager to page/control to use JavaScriptSerializer
        oXMLHttp.send(Sys.Serialization.JavaScriptSerializer.serialize(jsonParams));
        var jso = eval('(' + oXMLHttp.responseText + ')');
        sReplyXML = jso.d;
        //alert(sReplyXML);
        if (oXMLHttp.status != 200) {
            alert("WebServiceXMLRequest : Invalid status reply.\n\nstatus=" + oXMLHttp.status.toString() + " : " + oXMLHttp.statusText + ";\n\nPlease report this to your System Administrator");
            alert("WebServiceXMLRequest : Extra Info.\n\nURL=" + sURL + ";\n\nresponseText=" + sReplyXML + ";\n\nPlease report this to your System Administrator");
        }
        else if (sReplyXML.length == 0) {
            alert("WebServiceXMLRequest : Invalid (zero length) reply from server.\n\nURL=" + sURL + ";\n\nstatus=" + oXMLHttp.status.toString() + " : " + oXMLHttp.statusText + ";\n\nPlease report this to your System Administrator");
        }
        else if (sReplyXML.substr(0, 16) == "Server Request Error" || sReplyXML.substr(4, 9) == "<!DOCTYPE") {
            sReplyXML = "<Reply><HRESULT>0</HRESULT><STATUS>8</STATUS></Reply>";
        }
    }
    catch (e) {
        alert("WebServiceXMLRequest : Exception. \nType=" + e.name + "; \nMessage=" + e.Message + ";\n\nPlease report this to your System Administrator");
    }
    return sReplyXML;
}

function IsIDInList(sList, sItem)
{
    var sSearch = "," + sList + ",";
    if (sSearch.indexOf(sItem) >= 0)
        return true;
    return false;
}

function AddItemToList(sList, sItem)
{
    if (sItem != null && sItem != "")
    {
        if (!IsIDInList(sList, sItem))
        {
            if (sList == "")
                sList = sItem;
            else
                sList += "," + sItem;
        }
    }
    return sList;
}

function BuildDateTimeString(milliseconds) {
    var dt = new Date(milliseconds);
    var s = dt.format("yyyy-MM-ddTHH:mm:ss");
    return s;
}

function PEWebServiceRequest(sURL, jsonParams) {
    var sReply = "";
    try {
        var oXMLHttp = new XMLHttpRequest();
        oXMLHttp.open("POST", sURL, false);
        oXMLHttp.setRequestHeader("Content-Type", "application/json; charset=utf-8");
        // need to add ScriptManager to page/control to use JavaScriptSerializer
        var ser = Sys.Serialization.JavaScriptSerializer.serialize(jsonParams);
        oXMLHttp.send(ser);
        var jso = eval('(' + oXMLHttp.responseText + ')');
        sReply = jso.d;
        if (oXMLHttp.status != 200) {
            alert("PEWebServiceRequest : Invalid status reply.\n\nstatus=" + oXMLHttp.status.toString() + " : " + oXMLHttp.statusText + ";\n\nPlease report this to your System Administrator");
            alert("PEWebServiceRequest : Extra Info.\n\nURL=" + sURL + ";\n\nresponseText=" + sReplyXML + ";\n\nPlease report this to your System Administrator");
        }
    }
    catch (e) {
        alert("PEWebServiceRequest : Exception. \nType=" + e.name + "; \nMessage=" + e.Message + ";\n\nPlease report this to your System Administrator");
    }
    return sReply;
}

if(!String.prototype.trim) {   
  String.prototype.trim = function () {   
    return this.replace(/^\s+|\s+$/g,'');   
  };   
}

function ValidateStringAsNumber(sNumberIn, nMaxPreDPDigits, nMaxPostDPDigits, bDPNotAllowed, sTerminators) {
    var jReturn = {};
    var charr = sNumberIn.toString().trim().split("");
    var s = "";
    var bSignAlreadyFound = false;
    var bDPAlreadyFound = false;
    var bDPFound = false;
    var nPreDPDigits = 0;
    var nPostDPDigits = 0;

    outer_loop:
    for (i = 0; i < charr.length; i++) {
        switch (charr[i]) {
            case "+":
            case "-":
                if (bSignAlreadyFound) {
                    jReturn.Error = "Invalid Format - multiple signs";
                    return jReturn;
                }
                bSignAlreadyFound = true;
                s += charr[i];
                break;
            case "0":
            case "1":
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
                if (bDPAlreadyFound == false)
                {
                    nPreDPDigits++;
                    if (nPreDPDigits > nMaxPreDPDigits) {
                        jReturn.error = "Invalid Format - number too large";
                        return jReturn;
                    }
                }
                else
                {
                    nPostDPDigits++;
                    if (nPostDPDigits > nMaxPostDPDigits) {
                        jReturn.error = "Invalid Format - number too many digits after DP";
                        return jReturn;
                    }
                }
                s += charr[i];
                break;
            case ".":
                if (bDPNotAllowed == true) {
                    jReturn.error = "Invalid Format - DP not allowed";
                    return jReturn;
                }
                if (bDPAlreadyFound == true) {
                    jReturn.error = "Invalid Format - Only one DP allowed";
                    return jReturn;
                }
                bDPAlreadyFound = true;
                if (s == "") s = "0";
                s += charr[i];
                break;
            case ",":
                if (bDPAlreadyFound == true) {
                    jReturn.error = "Invalid Format";
                    return jReturn;
                }
                break;
            default:
                if (sTerminators.indexOf(charr[i]) < 0) {
                    jReturn.error = "Invalid character " + charr[i];
                    return jReturn;
                }
                break outer_loop;
        }
    }
    jReturn.value = s;
    return jReturn;
}
    //            Case sDecSep
    //                If bDPNotAllowed Then
    //                    eNumberValidationError = dveDPNotAllowed
    //                    GoTo Exit_Function
    //                End If
    //                If bDPFound Then
    //                    eNumberValidationError = dveInvalidFormat
    //                    GoTo Exit_Function
    //                End If
    //                bDPFound = True
    //                If s = "" Then s = s & "0"
    //                s = s & ch
    //            Case sThouSep
    //                If bDPFound Then
    //                    eNumberValidationError = dveInvalidFormat
    //                    GoTo Exit_Function
    //                End If
    //            Case Else
    //                If InStr(sTerminators, ch) = 0 Then
    //                    eNumberValidationError = dveInvalidChar
    //                    GoTo Exit_Function
    //                Else
    //                    Exit For
    //                End If
    //        End Select
    //    Next
    //    
    //    dblNumberOut = LocaleVal(s)
    //        
    //    If Not IsMissing(dblMin) Then
    //        If dblNumberOut < dblMin Then
    //            If dblMin = 0 Then
    //                eNumberValidationError = dveNegativeNumberInvalid
    //            Else
    //                eNumberValidationError = dveNumberTooSmall
    //            End If
    //        End If
    //    End If
    //    If Not IsMissing(dblMax) Then
    //        If dblNumberOut > dblMax Then
    //            eNumberValidationError = dveNumberTooLarge
    //        End If
    //    End If
    //Exit_Function:

    //    ValidateStringAsNumber = eNumberValidationError
    //    
    //    Exit Function
    //Exception_Error:
    //    eNumberValidationError = dveInvalidFormat
    //    ValidateStringAsNumber = eNumberValidationError
    //End Function 

//function parseIntArr(sIn, delimchar) {
//    var arr = sIn.split(delimchar);
//    for (var i = 0; i < arr.length; i++) { arr[i] = parseInt(arr[i], 10); }
//    return arr;
//}
