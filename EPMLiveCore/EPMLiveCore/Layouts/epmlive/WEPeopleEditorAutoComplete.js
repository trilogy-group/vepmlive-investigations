/// <reference path="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js" />
function Init() {
    (function ($$, $) {
        var mark = "Type here to search...";
        $(document).ready(function () {

            if (window._wePeopleEditorControlPropertyArray) {
                for (var k in window._wePeopleEditorControlPropertyArray) {
                    var controlProps = window._wePeopleEditorControlPropertyArray[k];

                    if (!SPControlContainsValue(controlProps.wePeopleEditorDivID)) {
                        var h = $('#' + controlProps.wePeopleEditorDivID).height();
                        $('#' + controlProps.wePeopleEditorDivID).append("<img src=\"/_layouts/epmlive/images/LoadingBar.gif\" style=\"vertical-align: middle;float:left;margin-left:5px;margin-top: 2px;\" /><div style=\"float:left;margin-left:5px;color:gray;\">Loading...</div> ");
                        $('#' + controlProps.wePeopleEditorDivID).height(h);
                    }

                    $('#' + controlProps.wePeopleEditorDivID).attr('disabled', true);
                    var index = controlProps.wePeopleEditorDivID.lastIndexOf('_');
                    var checkNameId = controlProps.wePeopleEditorDivID.substring(0, index) + '_checkNames';
                    var browseId = controlProps.wePeopleEditorDivID.substring(0, index) + '_browse';
                    controlProps.checkNamesOnClick = $('#' + checkNameId).attr('onclick');
                    controlProps.browseOnClick = $('#' + browseId).attr('onclick');
                    $('#' + checkNameId).removeAttr('onclick');
                    $('#' + checkNameId).css('cursor', 'default');
                    $('#' + browseId).removeAttr('onclick');
                    $('#' + browseId).css('cursor', 'default');
                }
            }

            // load data
            FetchData();
        });

        // _wePeopleEditorControlGlobalDataCache is an array of object formatted as follows:
        // { webid: <web id in string>, listid: <list id in string>, fieldid: < field id in string>, cachedata: <';#' separated string> };
        // return -1 if not found, return cache item id otherwise
        function CheckIfDataExists() {
            var result = false;
            if (window._wePeopleEditorControlGlobalDataCache.length > 0) {
                result = true;
            }
            return result;
        }

        function FetchData() {
            //var postData = { searchval: controlProps.searchText };
            $.post(window.curWebURL + "/_layouts/epmlive/WEPeopleEditorAjaxHandler.aspx", null, function (data) {
                SetCache(data);

                if (window._wePeopleEditorControlPropertyArray) {
                    for (var k in window._wePeopleEditorControlPropertyArray) {
                        var controlProps = window._wePeopleEditorControlPropertyArray[k];

                        $('#' + controlProps.wePeopleEditorDivID).removeAttr('disabled');
                        var index = controlProps.wePeopleEditorDivID.lastIndexOf('_');
                        var checkNameId = controlProps.wePeopleEditorDivID.substring(0, index) + '_checkNames';
                        var browseId = controlProps.wePeopleEditorDivID.substring(0, index) + '_browse';
                        $('#' + checkNameId).attr('onclick', controlProps.checkNamesOnClick);
                        $('#' + checkNameId).css('cursor', 'pointer');
                        $('#' + browseId).attr('onclick', controlProps.browseOnClick);
                        $('#' + browseId).css('cursor', 'pointer');

                        // remove SharePoint keydown event
                        $('#' + controlProps.wePeopleEditorDivID).removeAttr("onkeydown");

                        $('#' + controlProps.wePeopleEditorDivID).keydown(function (e) {

                            var index = $(this).attr('CtrlPropArrPos');
                            if (index != undefined && window._wePeopleEditorControlPropertyArray) {
                                controlProps = window._wePeopleEditorControlPropertyArray[index];
                            }

                            // test if single lookup field already has a value
                            if ((e.keyCode >= 65 && e.keyCode <= 90) ||
                            (e.keyCode != 16 && e.keyCode != 17 && !e.shiftKey && e.keyCode >= 96 && e.keyCode <= 105) ||
                            (e.keyCode != 16 && e.keyCode != 17 && !e.shiftKey && e.keyCode >= 48 && e.keyCode <= 57)) {
                                var tester = $(this).html();

                                var eleParent = null;
                                try {
                                    eleParent = $('<div>' + tester + '</div>');
                                }
                                catch (e) {
                                }

                                if (eleParent != null) {

                                    if (!controlProps.isMultiSelect && eleParent.find('SPAN').length > 0) {
                                        alert('Only one value is allowed for this lookup field.');
                                        return false;
                                    }
                                }
                            }

                        });

                        // register keyup event with type ahead logic 
                        $('#' + controlProps.wePeopleEditorDivID).keyup(function (e) {

                            var index = $(this).attr('CtrlPropArrPos');
                            if (index != undefined && window._wePeopleEditorControlPropertyArray) {
                                controlProps = window._wePeopleEditorControlPropertyArray[index];
                            }

                            switch (e.keyCode) {
                                case 13:
                                    //alert('enter key pressed!');
                                    if (!controlProps.isMultiSelect) {
                                        // data doesn't exist yet
                                        if (CheckIfDataExists(controlProps) == false) {
                                            // click validate
                                            $('#' + controlProps.wePeopleEdtiorCheckNameID).trigger('click');
                                        }
                                        else {
                                            // if data has been loaded, and user highlights something
                                            if (controlProps.candidateIndex != -1) {
                                                var newText = $('#autoText_' + controlProps.candidateIndex).attr('username');
                                                //var newText = $(selectedDiv).html();
                                                controlProps.singleSelectLookupVal = newText;
                                                UpdateSingleSelectPickerValue(controlProps, newText);
                                            }
                                            // user highlights nothing, just click validate
                                            else {
                                                $('#' + controlProps.wePeopleEdtiorCheckNameID).trigger('click');
                                            }
                                        }
                                    }
                                    else {
                                        // if data hasn't been loaded, do nothing
                                        if (CheckIfDataExists(controlProps) == false) {
                                            $('#' + controlProps.wePeopleEdtiorCheckNameID).trigger('click');
                                        }
                                        else {
                                            // if data has been loaded, and user highlights something
                                            if (controlProps.candidateIndex != -1) {
                                                var newText = $('#autoText_' + controlProps.candidateIndex).attr('username');
                                                //var newText = $(selectedDiv).html();
                                                UpdateMultiSelectPickerValue(controlProps, newText);
                                            }
                                            else {
                                                $('#' + controlProps.wePeopleEdtiorCheckNameID).trigger('click');
                                            }
                                        }

                                    }
                                    e.preventDefault();
                                    break;
                                case 38: //up
                                    //alert('moved up!');
                                    $('.autoText').each(function () {
                                        $(this).removeClass('autoTextOnHover');
                                    });
                                    var targetDiv;
                                    if (window.parseInt(controlProps.candidateIndex) == 0) {
                                        controlProps.candidateIndex = '-1';
                                        RemoveTypeAheadChoiceCandidate(controlProps);
                                    }
                                    else if (window.parseInt(controlProps.candidateIndex) > -1) {
                                        controlProps.candidateIndex = (window.parseInt(controlProps.candidateIndex) - 1);
                                        targetDiv = $('#' + controlProps.autoCompleteDivID + ' > div')[controlProps.candidateIndex];
                                        $(targetDiv).addClass('autoTextOnHover');
                                    }

                                    if ($(targetDiv).offset() != null) {
                                        var sTop = $(targetDiv).offset().top;
                                        if (sTop <= $('#' + controlProps.autoCompleteDivID).offset().top) {
                                            ScrollCandidateDiv(controlProps.autoCompleteDivID, $('#' + controlProps.autoCompleteDivID).scrollTop() - 100);
                                        }
                                    }
                                    break;
                                case 40: // down
                                    //alert('moved down!');
                                    $('.autoText').each(function () {
                                        $(this).removeClass('autoTextOnHover');
                                    });
                                    var targetDiv;
                                    if (window.parseInt(controlProps.candidateIndex) == $('#' + controlProps.autoCompleteDivID + ' > div').length - 1) {
                                        targetDiv = $('#' + controlProps.autoCompleteDivID + ' > div')[++controlProps.candidateIndex];
                                        $(targetDiv).addClass('autoTextOnHover');
                                    }
                                    else if (window.parseInt(controlProps.candidateIndex) < $('#' + controlProps.autoCompleteDivID + ' > div').length) {
                                        controlProps.candidateIndex = (window.parseInt(controlProps.candidateIndex) + 1);
                                        targetDiv = $('#' + controlProps.autoCompleteDivID + ' > div')[controlProps.candidateIndex];
                                        $(targetDiv).addClass('autoTextOnHover');
                                    }

                                    if ($(targetDiv).offset() != null) {
                                        var sTop = $(targetDiv).offset().top;
                                        if (sTop >= $('#' + controlProps.autoCompleteDivID).offset().top + 150) {
                                            ScrollCandidateDiv(controlProps.autoCompleteDivID, $('#' + controlProps.autoCompleteDivID).scrollTop() + 100);
                                        }
                                    }
                                    break;
                                default:
                                    var sSearch = $(this).html();
                                    sSearch = ParseForSearchVal(sSearch);
                                    // clearn text for firefox
                                    if (sSearch.indexOf('<br>') != -1) {
                                        sSearch = sSearch.replace(/<br>/g, '');
                                    }
                                    sSearch = sSearch.trim();
                                    controlProps.searchText = sSearch;
                                    if (controlProps.searchText.length > 0) {
                                        // is multi select
                                        if (controlProps.isMultiSelect ||
                                    (!controlProps.isMultiSelect && !SPControlContainsValue(controlProps.wePeopleEditorDivID))) {

                                            var dataExists = CheckIfDataExists();
                                            var cachedata = '';

                                            if (dataExists == false) {
                                                //FetchData();
                                            }
                                            else {
                                                cachedata = GetCachedData();
                                                BuildDropDownWithCache(cachedata, controlProps);
                                            }
                                        }
                                    }
                                    else {
                                        RemoveTypeAheadChoiceCandidate(controlProps);
                                    }
                                    break;
                            }
                        });

                        if ($('#' + controlProps.wePeopleEditorDivIDRoot + "_browse").length > 0) {
                            var originalJs = $('#' + controlProps.wePeopleEditorDivIDRoot + "_browse").attr('onclick');
                            $('#' + controlProps.wePeopleEditorDivIDRoot + "_browse").attr('onclick', '');
                            var divId = controlProps.wePeopleEditorDivID;
                            $('#' + controlProps.wePeopleEditorDivIDRoot + "_browse").attr('onclick', 'var h = $(\'#' + divId + '\').height();if($(\'#' + divId + '\').html().indexOf(\'Type here to search\') != -1){$(\'#' + divId + '\').html(\'\'); $(\'#' + divId + '\').height(h);}' + originalJs);

                        }

                        if (!SPControlContainsValue(controlProps.wePeopleEditorDivID)) {
                            var h = $('#' + controlProps.wePeopleEditorDivID).height();
                            $('#' + controlProps.wePeopleEditorDivID).html('<span style="color:#ccc">Type here to search...</span>');
                            $('#' + controlProps.wePeopleEditorDivID).height(h);
                        }

                        $('#' + controlProps.wePeopleEditorDivID).mouseenter(function () {
                            if ($(this).html() !== '' && UnescapeHTML($(this).html()).trim() === 'Type here to search...') {
                                var h = $(this).height();
                                $(this).html('');
                                $(this).height(h);
                            }
                        });

                        $('#' + controlProps.wePeopleEditorDivID).mouseout(function () {
                            if (!$(this).is(':focus')) {
                                if (UnescapeHTML($(this).html()) === undefined || UnescapeHTML($(this).html()) === '') {
                                    var h = $(this).height();
                                    $(this).html('<span style="color:#ccc">Type here to search...</span>');
                                    $(this).height(h);
                                }
                            }
                        });

                        $('#' + controlProps.wePeopleEditorDivID).blur(function () {
                            if (!$(this).is(':focus')) {
                                if (UnescapeHTML($(this).html()) === undefined || UnescapeHTML($(this).html()) === '') {
                                    var h = $(this).height();
                                    $(this).html('<span style="color:#ccc">Type here to search...</span>');
                                    $(this).height(h);
                                }
                            }
                        });

                        $('#' + controlProps.wePeopleEditorDivID).focus(function () {
                            if ($(this).html() !== '' && UnescapeHTML($(this).html()).trim() === 'Type here to search...') {
                                var h = $(this).height();
                                $(this).html('');
                                $(this).height(h);
                            }
                        });

                        // set the control prop array index
                        // so we can grab the correct set of prop
                        // for control
                        $('#' + controlProps.wePeopleEditorDivID).attr('CtrlPropArrPos', k);
                    }
                }
            });
        }

        function SetCache(data) {
            var cacheObjLength = window._wePeopleEditorControlGlobalDataCache.length;
            var newCacheObj = { cachedata: data };
            var newItemIndex = cacheObjLength;
            window._wePeopleEditorControlGlobalDataCache[newItemIndex] = newCacheObj;
            // build the drop down on first time
            //BuildDropDownWithCache(data, controlProps);
        }

        function GetCachedData() {
            var data = '';
            if (window._wePeopleEditorControlGlobalDataCache) {
                data = window._wePeopleEditorControlGlobalDataCache[0].cachedata;
            }
            return data;
        }

        function BuildDropDownWithCache(data, controlProps) {
            var pickerSelections = new Array();
            var retVal = data;
            var oJson = eval('(' + retVal.replace(/\\/g, '\\\\') + ')');
            var qualifiedCandidates = new Array();

            var hasMatch = false;

            if (oJson) {

                RemoveTypeAheadChoiceCandidate(controlProps);

                var containerDiv = $(document.createElement('div'))
                           .width($('#' + controlProps.wePeopleEditorDivID).width())
                           .attr('id', controlProps.autoCompleteDivID)
                           .addClass('autocomplete')
                           .css('background-color', 'white');

                containerDiv.css('top', GetFullTop($('#' + controlProps.wePeopleEditorDivID)));
                containerDiv.css('left', GetFullLeft($('#' + controlProps.wePeopleEditorDivID)));

                $('#' + controlProps.wePeopleEditorDivID).after(containerDiv);

                RegisterClickOutsideEvent(controlProps.autoCompleteDivID);

                $('#' + controlProps.wePeopleEditorDivID).blur(function () {
                    $(this).css('display', '');
                });

                // get the list of options
                var htmlHolder = $('#' + controlProps.wePeopleEditorDivID).html();
                htmlHolder = htmlHolder.split('&nbsp').join('').split(';').join('');
                var parent = null;
                try {
                    parent = $('<div>' + htmlHolder + '</div>');
                }
                catch (e) {
                }

                if (parent != null && htmlHolder.length > 0) {
                    parent.find('SPAN').each(function () {
                        pickerSelections.push($(this).text().trim());
                    });
                }

                var itemIndex = 0;

                if (oJson.Result.Team) {
                    for (var index in oJson.Result.Team) {
                        var member = oJson.Result.Team[index];
                        var itemTitle = '';
                        if (member.Title) {
                            itemTitle = member.Title;
                        }
                        var cleanItemTitle = '';
                        if (member.Title) {
                            cleanItemTitle = member.Title.toLowerCase().trim();
                        }
                        var itemUsername = '';
                        if (member.PrincipalType == 'SharePointGroup') {
                            itemUsername = member.SPAccountInfo.substring(member.SPAccountInfo.indexOf('#') + 1);
                        }
                        else {
                            if (member.Username) {
                                itemUsername = member.Username;
                            }
                        }

                        var clnUsername = '';
                        if (member.Username) {
                            clnUsername = member.Username.toLowerCase().trim();
                        }
                        var userEmail = '';
                        if (member.Email) {
                            userEmail = member.Email;
                        }
                        var cleanSearchText = ''
                        if (controlProps.searchText) {
                            cleanSearchText = controlProps.searchText;
                        }

                        // firefox inserts <br> 
                        if (cleanSearchText.indexOf('<br>') != -1) {
                            cleanSearchText = cleanSearchText.replace(/<br>/g, '');
                        }

                        cleanSearchText = cleanSearchText.trim().toLowerCase();

                        if (cleanItemTitle.indexOf(cleanSearchText) == 0 &&
                            !ArrayContains(pickerSelections, cleanItemTitle)) {
                            hasMatch = true;
                            $('#' + controlProps.autoCompleteDivID).append("<div class='autoText' username='" + itemUsername + "' title='Username: " + itemUsername + " | Email: " + userEmail + "' id='autoText_" + itemIndex + "'>" + itemTitle + "</div>");
                            itemIndex++;
                            continue;
                        }

                        // get the values that contains the search text
                        // don't return options that has been selected already
                        if (cleanItemTitle.indexOf(cleanSearchText) != -1 &&
                            !ArrayContains(pickerSelections, cleanItemTitle)) {
                            hasMatch = true;
                            $('#' + controlProps.autoCompleteDivID).append("<div class='autoText' username='" + itemUsername + "' title='Username: " + itemUsername + " | Email: " + userEmail + "' id='autoText_" + itemIndex + "'>" + itemTitle + "</div>");
                            itemIndex++;
                        }
                    }
                }

                RegisterHoverStyle();

                $('.autoText').click(function () {
                    if (!controlProps.isMultiSelect) {
                        var newText = $(this).attr('username');
                        controlProps.singleSelectLookupVal = newText;
                        UpdateSingleSelectPickerValue(controlProps, newText);
                    }
                    else {
                        var newText = $(this).attr('username');
                        UpdateMultiSelectPickerValue(controlProps, newText);
                    }
                });
            }

            if (!hasMatch) {
                RemoveTypeAheadChoiceCandidate(controlProps);
            }
        }

        function RegisterHoverStyle() {
            if ($('.autoText').length > 0) {
                $('.autoText').each(function () {
                    $(this).hover(
                function () {
                    $('.autoTextOnHover').each(function () {
                        $(this).removeClass('autoTextOnHover');
                    });
                    $(this).addClass('autoTextOnHover');
                },
                function () {
                    $(this).removeClass('autoTextOnHover');
                }
            );
                });
            }
        }

        function RegisterClickOutsideEvent(autoCompleteDivID) {
            document.onclick = function (event) {
                if (clickedOutsideElement(autoCompleteDivID, event)) {
                    $('#' + autoCompleteDivID).css('display', 'none');
                }
                else {
                    $('#' + autoCompleteDivID).css('display', '');
                }
            }
        }

        function UpdateAllSingleSelectValsBeforeSafe() {
            if (window._wePeopleEditorControlPropertyArray) {
                for (var k in window._wePeopleEditorControlPropertyArray) {
                    var controlProps = window._wePeopleEditorControlPropertyArray[k];

                    var html = $('#' + controlProps.wePeopleEditorDivID).html();
                    if (html == 'Type here to search...' || html == '0') {
                        $('#' + controlProps.wePeopleEditorDivID).html('');
                    }
                }
            }
        }

        function UpdateSingleSelectPickerValue(controlProps, newTextVal) {
            $('#' + controlProps.wePeopleEditorDivID).html('');
            $('#' + controlProps.wePeopleEditorDivID).html(newTextVal);

            RemoveTypeAheadChoiceCandidate(controlProps);
            ValidateEntity(controlProps.wePeopleEdtiorCheckNameID);
        }

        function UpdateMultiSelectPickerValue(controlProps, newTextVal) {
            // updates the picker's values
            var clean = $('#' + controlProps.wePeopleEditorDivID).html();
            clean = clean.substring(0, clean.lastIndexOf(';') + 1);
            clean = clean.replace(/&nbsp;/, '');
            // clear <p> elements added by having cursor over first user name
            if (clean.indexOf('<P>') != -1 || clean.indexOf('<p>') != -1) {
                clean = clean.replace(/<P>/g, '');
                clean = clean.replace(/<p>/g, '');
            }
            $('#' + controlProps.wePeopleEditorDivID).html('');
            $('#' + controlProps.wePeopleEditorDivID).html(clean + newTextVal);
            RemoveTypeAheadChoiceCandidate(controlProps);
            ValidateEntity(controlProps.wePeopleEdtiorCheckNameID);
        }

        function ArrayContains(array, searchVal) {
            var result = false;
            var cleanSearchVal = searchVal.toLowerCase().trim();
            for (i in array) {
                var arrayVal = array[i].toLowerCase().trim();
                if (arrayVal == cleanSearchVal) {
                    result = true;
                    break;
                }
            }

            return result;
        }

        function UnescapeHTML(escapedHTML) {
            var d = document.createElement("div");
            d.innerHTML = escapedHTML;
            if (!d.innerText) {
                return d.textContent;
            } else {
                return d.innerText;
            }
        }

        // ===== HELPER FUNCTIONS =====

        function RemoveTypeAheadChoiceCandidate(controlProps) {
            if ($('#' + controlProps.autoCompleteDivID).length > 0) {
                $('#' + controlProps.autoCompleteDivID).remove();
            }
            controlProps.candidateIndex = -1;
        }

        function ValidateEntity(wePeopleEdtiorCheckNameID) {
            setTimeout(function () {
                if ($('#' + wePeopleEdtiorCheckNameID)) {
                    $('#' + wePeopleEdtiorCheckNameID).trigger('click');
                }
            }, 0);
        }

        function GetFullTop(obj) {
            var posY = obj.offsetTop;
            while (obj.offsetParent) {
                posY = posY + obj.offsetParent.offsetTop;
                if (obj == document.getElementsByTagName('body')[0]) { break }
                else { obj = obj.offsetParent; }
            }
            return posY;
        }

        function GetFullLeft(obj) {
            var posX = obj.offsetLeft;
            while (obj.offsetParent) {
                posX = posX + obj.offsetParent.offsetLeft;
                if (obj == document.getElementsByTagName('body')[0]) { break }
                else { obj = obj.offsetParent; }
            }
            return posX;
        }

        function clickedOutsideElement(elemId, event) {
            var theElem = null;
            try {
                theElem = (window.event) ? getEventTarget(window.event) : event.target;
            }
            catch (e) { }
            while (theElem != null) {
                if (theElem.id == elemId) {
                    return false;
                }
                else {
                    theElem = theElem.parentNode;
                }
            }
            return true;
        }

        function SPControlContainsValue(ctrlID) {
            var result = false;
            var temp = $('#' + ctrlID).html();
            var tempParent = null;
            try {
                tempParent = $('<div>' + temp + '</div>');
            }
            catch (e) { }

            if (tempParent != null) {
                // if selected value was none, the span
                var length = tempParent.find('SPAN').length;
                var txt = '';
                if (length > 0) {
                    if (tempParent.find('SPAN')[0].innerText) {
                        txt = tempParent.find('SPAN')[0].innerText;
                    }
                    else {
                        txt = tempParent.find('SPAN')[0].textContent;
                    }
                }
            }

            if (tempParent != null && length == 2 && txt.trim() == '0') {
                result = false;
            }
            else if (tempParent != null && tempParent.find('SPAN').length > 0) {
                result = true;
            }

            return result;
        }

        // the parameter is a messy
        // inner html that contains a few
        // spans and the search value we're looking for
        function ParseForSearchVal(str) {
            var result = str;
            result = result.split('&nbsp;').join('');
            var lastSemiColonIndex = result.lastIndexOf(';');
            try {
                if (lastSemiColonIndex != -1) {
                    result = result.substr(lastSemiColonIndex + 1);
                    result = result.trim();
                }
            }
            catch (e) {
                result = '';
            }
            return result;
        }

        function OpenUrlWithModal(urlVal) {
            var options = {
                url: urlVal,
                title: 'Add New Item to Target List',
                allowMaximize: true,
                width: 650,
                height: 500
            };

            SP.UI.ModalDialog.showModalDialog(options);
        }

        function ScrollCandidateDiv(id, newTop) {
            $('#' + id).animate({ scrollTop: newTop }, 'fast');
        }

    } (window.WEPeopleEditor = window.WEPeopleEditor || {}, jQuery));
}
ExecuteOrDelayUntilScriptLoaded(Init, "EPMLive.js");