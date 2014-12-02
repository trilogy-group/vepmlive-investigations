/// <reference path="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js" />
function GEInit() {
    (function ($$, $, w) {
        var mark = "Type here to search...";
        var dataIsReady = false;
        $(document).ready(function () {

            if (window._LookupFieldsPropsArray) {
                for (var k in window._LookupFieldsPropsArray) {
                    if (window._LookupFieldsPropsArray.hasOwnProperty(k)) {
                        var controlProps = window._LookupFieldsPropsArray[k];

                        HideSPControls(controlProps);

                        if (controlProps.ControlType !== '2') {
                            continue;
                        }

                        SetProperOuterTableCssClass(controlProps.ControlInfo.GenericEntityDivIdRoot);

                        if (!SPControlContainsValue(controlProps.ControlInfo.GenericEntityDivId) && controlProps.Parent == '') {
                            var h = $('#' + controlProps.ControlInfo.GenericEntityDivId).height();
                            $('#' + controlProps.ControlInfo.GenericEntityDivId).append("<img src=\"/_layouts/epmlive/images/LoadingBar.gif\" style=\"vertical-align: middle;float:left;margin-left:5px;margin-top: 2px;\" /><div style=\"float:left;margin-left:5px;color:gray;\">Loading...</div> ");
                            $('#' + controlProps.ControlInfo.GenericEntityDivId).height(h);
                        }

                        if (controlProps.ControlType == '2' && controlProps.Parent !== '' && controlProps.ControlInfo.SingleSelectLookupVal == '') {
                            $('#' + controlProps.ControlInfo.GenericEntityDivId).attr("disabled", true);
                            $('#' + controlProps.ControlInfo.GenericEntityDivId).prop('contenteditable', false);
                            $('#' + controlProps.ControlInfo.GenericEntityDivId).addClass('disabledTb');
                            var index = controlProps.ControlInfo.GenericEntityDivId.lastIndexOf('_');
                            var browseId = controlProps.ControlInfo.GenericEntityDivId.substring(0, index) + '_browse';
                            var addItemId = controlProps.ControlInfo.GenericEntityDivId.substring(0, index) + '_addItem';
                            controlProps.BrowseLinkOnClick = $('#' + browseId).attr('onclick');
                            controlProps.AddItemLinkOnClick = $('#' + addItemId).attr('onclick');
                            $('#' + browseId).removeAttr('onclick');
                            $('#' + browseId).css('cursor', 'default');
                            $('#' + browseId).find('IMG').addClass('disabledImg')
                            $('#' + addItemId).removeAttr('onclick');
                            $('#' + addItemId).css('cursor', 'default');
                            $('#' + addItemId).find('IMG').addClass('disabledImg')

                            if (controlProps.ControlType == '2' && $('#' + controlProps.FieldName + '_ddlShowAll').length > 0) {
                                $('#' + controlProps.FieldName + '_ddlShowAll').addClass('disabledImg');
                            }
                        }
                    }
                }
            }

            if (window._LookupFieldsPropsArray) {
                for (var k in window._LookupFieldsPropsArray) {
                    var controlProps = window._LookupFieldsPropsArray[k];                    
                    FetchData(controlProps, k);
                }
            }
        });

        // _LookupFieldsPropsArray is an array of object formatted as follows:
        // { webid: <web id in string>, listid: <list id in string>, fieldid: < field id in string>, cachedata: <';#' separated string> };
        // return -1 if not found, return cache item index otherwise
        function CheckIfDataExists(controlProps) {
            var objID = -1;
            if (window._LookupFieldsPropsArray) {
                for (var k in window._LookupFieldsPropsArray) {
                    if (window._LookupFieldsPropsArray[k].FieldName == controlProps.FieldName) {
                        objID = k;
                        break;
                    }
                }
            }
            return objID;
        }

        function FetchData(controlProps, k) {

            if (controlProps.Parent !== '' && controlProps.ControlInfo.SingleSelectLookupVal !== '') {
                var parentControlPropsArray = $.grep(window._LookupFieldsPropsArray, function (item) { return item.FieldName == controlProps.Parent });
                var parentControlProps = parentControlPropsArray["0"];
                parentControlProps.ControlInfo.SingleSelectLookupVal = $($('#' + parentControlProps.ControlInfo.GenericEntityDivId).html()).find('div').attr('key');

                var postData = {
                    webid: controlProps.FieldInfo.LookupWebId,
                    listid: controlProps.FieldInfo.LookupListId,
                    fieldid: controlProps.FieldInfo.LookupFieldId,
                    field: controlProps.FieldInfo.LookupField,
                    parent: parentControlProps.FieldName,
                    parentValue: parentControlProps.ControlInfo.SingleSelectLookupVal,
                    parentListField: controlProps.ParentListField
                };
            }
            else {
                var postData = {
                    webid: controlProps.FieldInfo.LookupWebId,
                    listid: controlProps.FieldInfo.LookupListId,
                    fieldid: controlProps.FieldInfo.LookupFieldId,
                    field: controlProps.FieldInfo.LookupField
                };
            }

            $.post(controlProps.ControlInfo.CurWebURL + "/_layouts/epmlive/GenericEntityTypeAheadAjaxHandler.aspx", postData, function (data) {

                SetCache(data, controlProps);

                if (controlProps.ControlType !== '2') {
                    return;
                }

                // remove SharePoint keydown event
                $('#' + controlProps.ControlInfo.GenericEntityDivId).removeAttr("onkeydown");

                $('#' + controlProps.ControlInfo.GenericEntityDivId).unbind('keydown').keydown(function (e) {

                    var index = $(this).attr('CtrlPropArrPos');
                    if (index != undefined && window._LookupFieldsPropsArray) {
                        controlProps = window._LookupFieldsPropsArray[index];
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
                            if (!controlProps.ControlInfo.IsMultiSelect && eleParent.find('SPAN').length > 0) {
                                alert('Only one value is allowed for this lookup field.');
                                return false;
                            }
                        }
                    }

                    switch (e.keyCode) {
                        case 8:
                            var text = $(this).text();
                            var lastChar = text.substr(text.length - 1, 1);
                            if (lastChar == ';') {
                                var tester = $(this).html();
                                var eleParent = null;
                                try {
                                    eleParent = $('<div>' + tester + '</div>');
                                }
                                catch (e) {
                                }

                                if (eleParent != null) {
                                    if (eleParent.find('SPAN').length > 0) {
                                        try {
                                            $(this).children('span:last-child').remove();
                                            $(this).html($(this).html().replace(/;$/, ''));
                                            //$(this).html($(this).html().replace(/(&nbsp;)$/, ''));
                                            //$(this).html($(this).html().replace(/(&nbsp;)$/, ''));
                                        }
                                        catch (e) {
                                        }
                                    }
                                }
                            }

                            break;
                        case 13:
                            if ($('#' + controlProps.FieldName + '_errorText').length > 0) {
                                $('#' + controlProps.FieldName + '_errorText').remove();
                            }
                            var selectedDiv = $('#' + controlProps.ControlInfo.AutoCompleteDivId + ' > div')[controlProps.ControlInfo.CandidateIndex];
                            var ctrlId = $(selectedDiv).attr('id');
                            if (ctrlId === 'autoText_noValue') {
                                return;
                            }
                            //alert('enter key pressed!');  
                            if (!controlProps.ControlInfo.IsMultiSelect) {
                                if (CheckIfDataExists(controlProps) == -1) {
                                    // if data hasn't been loaded, do nothing
                                    return false;
                                }
                                else {
                                    // if data has been loaded, and user highlights something
                                    if (controlProps.ControlInfo.CandidateIndex != -1) {
                                        var selectedDiv = $('#' + controlProps.ControlInfo.AutoCompleteDivId + ' > div')[controlProps.ControlInfo.CandidateIndex];
                                        var newText = $(selectedDiv).html();
                                        controlProps.ControlInfo.SingleSelectDisplayVal = newText;
                                        controlProps.ControlInfo.SingleSelectLookupVal = $(selectedDiv).attr('value');
                                        UpdateSingleSelectPickerValueWOValidation(controlProps, controlProps.ControlInfo.SingleSelectLookupVal);
                                    }
                                    else {
                                        // data has been loaded, and user has not selected anything, just click validate
                                        $('#' + controlProps.ControlInfo.GenericEntityCheckNameId).trigger('click');
                                    }
                                }
                            }
                            else {
                                if (CheckIfDataExists(controlProps) == -1) {
                                    // if data hasn't been loaded, do nothing
                                    return false;
                                }
                                else {
                                    // if data has been loaded, and user highlights something
                                    if (controlProps.ControlInfo.CandidateIndex != -1) {
                                        var selectedDiv = $('#' + controlProps.ControlInfo.AutoCompleteDivId + ' > div')[controlProps.ControlInfo.CandidateIndex];
                                        var newText = $(selectedDiv).html();
                                        var index = $(selectedDiv).attr('value');
                                        UpdateMultiSelectPickerValueWOValidation(controlProps, newText, index);
                                    }
                                    else {
                                        // data has been loaded, and user has not selected anything, just click validate
                                        $('#' + controlProps.ControlInfo.GenericEntityCheckNameId).trigger('click');
                                    }
                                }
                            }

                            e.preventDefault();
                            break;
                    }




                });

                // register keyup event with type ahead logic 
                $('#' + controlProps.ControlInfo.GenericEntityDivId).unbind('keyup').keyup(function (e) {

                    var index = $(this).attr('CtrlPropArrPos');
                    if (index != undefined && window._LookupFieldsPropsArray) {
                        controlProps = window._LookupFieldsPropsArray[index];
                    }

                    switch (e.keyCode) {
                        case 8:
                            if (!SPControlContainsValue($(this).attr('id'))) {
                                RedisableChildren(controlProps);
                            }

                            var sSearch = $(this).html();
                            sSearch = ParseForSearchVal(sSearch);
                            // clearn text for firefox
                            if (sSearch.indexOf('<br>') != -1) {
                                sSearch = sSearch.replace(/<br>/g, '');
                            }

                            sSearch = sSearch.trim();
                            controlProps.ControlInfo.SearchText = sSearch;

                            if (controlProps.ControlInfo.SearchText.length > 0) {
                                // is multi select
                                if (controlProps.ControlInfo.IsMultiSelect ||
                                    // or is single select and does not contain a value already
                                    (!controlProps.ControlInfo.IsMultiSelect && !SPControlContainsValue(controlProps.ControlInfo.GenericEntityDivId))) {

                                    if (controlProps.Parent != '') {
                                        var index = CheckIfDataExists(controlProps);
                                        var cachedata = GetCachedData(index);
                                        BuildDropDownWithCache(cachedata, controlProps);
                                    }
                                    else {
                                        var cacheObjID = CheckIfDataExists(controlProps);
                                        var cachedata = '';
                                        cachedata = GetCachedData(cacheObjID);
                                        cachedata = cachedata.replace(/\n/g, '').replace(/\r/g, '').replace(/\r\n/g, '');
                                        //if (cachedata.trim() != '') {
                                        BuildDropDownWithCache(cachedata, controlProps);
                                        //}
                                    }
                                }
                            }
                            else {
                                RemoveTypeAheadChoiceCandidate(controlProps);
                            }

                            break;
                        case 46:
                            if (!SPControlContainsValue($(this).attr('id'))) {
                                RedisableChildren(controlProps);
                            }

                            var sSearch = $(this).html();
                            sSearch = ParseForSearchVal(sSearch);
                            // clearn text for firefox
                            if (sSearch.indexOf('<br>') != -1) {
                                sSearch = sSearch.replace(/<br>/g, '');
                            }

                            sSearch = sSearch.trim();
                            controlProps.ControlInfo.SearchText = sSearch;

                            if (controlProps.ControlInfo.SearchText.length > 0) {
                                // is multi select
                                if (controlProps.ControlInfo.IsMultiSelect ||
                                    // or is single select and does not contain a value already
                                    (!controlProps.ControlInfo.IsMultiSelect && !SPControlContainsValue(controlProps.ControlInfo.GenericEntityDivId))) {

                                    if (controlProps.Parent != '') {
                                        var index = CheckIfDataExists(controlProps);
                                        var cachedata = GetCachedData(index);
                                        BuildDropDownWithCache(cachedata, controlProps);
                                    }
                                    else {
                                        var cacheObjID = CheckIfDataExists(controlProps);
                                        var cachedata = '';
                                        cachedata = GetCachedData(cacheObjID);
                                        cachedata = cachedata.replace(/\n/g, '').replace(/\r/g, '').replace(/\r\n/g, '');
                                        //if (cachedata.trim() != '') {
                                        BuildDropDownWithCache(cachedata, controlProps);
                                        //}
                                    }
                                }
                            }
                            else {
                                RemoveTypeAheadChoiceCandidate(controlProps);
                            }
                            break;
                        case 38: //up
                            //alert('moved up!');
                            $('.autoText').each(function () {
                                $(this).removeClass('autoTextOnHover');
                            });
                            var targetDiv;
                            if (window.parseInt(controlProps.ControlInfo.CandidateIndex) == 0) {
                                controlProps.ControlInfo.CandidateIndex = '-1';
                                RemoveTypeAheadChoiceCandidate(controlProps);
                            }
                            else if (window.parseInt(controlProps.ControlInfo.CandidateIndex) > -1) {
                                controlProps.ControlInfo.CandidateIndex = (window.parseInt(controlProps.ControlInfo.CandidateIndex) - 1);
                                targetDiv = $('#' + controlProps.ControlInfo.AutoCompleteDivId + ' > div')[controlProps.ControlInfo.CandidateIndex];
                                $(targetDiv).addClass('autoTextOnHover');
                            }
                            if ($(targetDiv).offset() != null) {
                                var sTop = $(targetDiv).offset().top;
                                if (sTop <= $('#' + controlProps.ControlInfo.AutoCompleteDivId).offset().top) {
                                    ScrollCandidateDiv(controlProps.ControlInfo.AutoCompleteDivId, $('#' + controlProps.ControlInfo.AutoCompleteDivId).scrollTop() - 100);
                                }
                            }
                            break;
                        case 40: // down
                            //alert('moved down!');
                            $('.autoText').each(function () {
                                $(this).removeClass('autoTextOnHover');
                            });
                            var targetDiv;

                            if (window.parseInt(controlProps.ControlInfo.CandidateIndex) == $('#' + controlProps.ControlInfo.AutoCompleteDivId + ' > div').length - 1) {
                                targetDiv = $('#' + controlProps.ControlInfo.AutoCompleteDivId + ' > div')[$('#' + controlProps.ControlInfo.AutoCompleteDivId + ' > div').length - 1];
                                $(targetDiv).addClass('autoTextOnHover');
                            }
                            else if (window.parseInt(controlProps.ControlInfo.CandidateIndex) < $('#' + controlProps.ControlInfo.AutoCompleteDivId + ' > div').length) {
                                controlProps.ControlInfo.CandidateIndex = (window.parseInt(controlProps.ControlInfo.CandidateIndex) + 1);
                                targetDiv = $('#' + controlProps.ControlInfo.AutoCompleteDivId + ' > div')[controlProps.ControlInfo.CandidateIndex];
                                $(targetDiv).addClass('autoTextOnHover');
                            }

                            if ($(targetDiv).offset() != null) {
                                var sTop = $(targetDiv).offset().top;
                                if (sTop >= $('#' + controlProps.ControlInfo.AutoCompleteDivId).offset().top + 150) {
                                    ScrollCandidateDiv(controlProps.ControlInfo.AutoCompleteDivId, $('#' + controlProps.ControlInfo.AutoCompleteDivId).scrollTop() + 100);
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
                            controlProps.ControlInfo.SearchText = sSearch;

                            if (controlProps.ControlInfo.SearchText.length > 0) {
                                // is multi select
                                if (controlProps.ControlInfo.IsMultiSelect ||
                                    // or is single select and does not contain a value already
                                    (!controlProps.ControlInfo.IsMultiSelect && !SPControlContainsValue(controlProps.ControlInfo.GenericEntityDivId))) {

                                    if (controlProps.Parent != '') {
                                        var index = CheckIfDataExists(controlProps);
                                        var cachedata = GetCachedData(index);
                                        BuildDropDownWithCache(cachedata, controlProps);
                                    }
                                    else {
                                        var cacheObjID = CheckIfDataExists(controlProps);
                                        var cachedata = '';
                                        cachedata = GetCachedData(cacheObjID);
                                        cachedata = cachedata.replace(/\n/g, '').replace(/\r/g, '').replace(/\r\n/g, '');
                                        //if (cachedata.trim() != '') {
                                        BuildDropDownWithCache(cachedata, controlProps);
                                        //}
                                    }
                                }
                            }
                            else {
                                RemoveTypeAheadChoiceCandidate(controlProps);
                            }

                            break;
                    }
                })

                if (controlProps.ControlType == '2' && $('#' + controlProps.FieldName + '_ddlShowAll').length > 0 && controlProps.Parent == '') {
                    $('#' + controlProps.FieldName + '_ddlShowAll').unbind('click').click(function () {

                        var index = $(this).attr('CtrlPropArrPos');
                        if (index != undefined && window._LookupFieldsPropsArray) {
                            controlProps = window._LookupFieldsPropsArray[index];
                        }

                        //                    if (controlProps.Parent != '') {
                        //                        var index = CheckIfDataExists(controlProps);
                        //                        var cachedata = GetCachedData(index);
                        //                        BuildAllItemsDropDown(cachedata, controlProps);
                        //                    }
                        //                                        else {
                        var cacheObjID = CheckIfDataExists(controlProps);
                        var cachedata = '';

                        if (cacheObjID == -1) {
                            //FetchData(controlProps);
                        }
                        else {
                            cachedata = GetCachedData(cacheObjID);
                            cachedata = cachedata.replace(/\n/g, '').replace(/\r/g, '').replace(/\r\n/g, '');
                            //if (cachedata.trim() != '') {
                            BuildAllItemsDropDown(cachedata, controlProps);
                            //}
                        }

                    });

                    $('#' + controlProps.FieldName + '_ddlShowAll').attr('CtrlPropArrPos', k);
                }


                if ($('#' + controlProps.FieldName + '_ddlShowAll').length > 0 && controlProps.Parent !== '' && controlProps.ControlInfo.SingleSelectLookupVal !== '') {
                    $('#' + controlProps.FieldName + '_ddlShowAll').click(function () {

                        var index = CheckIfDataExists(controlProps);
                        var cachedata = GetCachedData(index);
                        BuildAllItemsDropDown(cachedata, controlProps);

                    });

                    $('#' + controlProps.FieldName + '_ddlShowAll').attr('CtrlPropArrPos', k);
                    $('#' + controlProps.FieldName + '_ddlShowAll').removeClass('disabledImg');
                }

                if (!SPControlContainsValue(controlProps.ControlInfo.GenericEntityDivId) && controlProps.Parent === '') {
                    var h = $('#' + controlProps.ControlInfo.GenericEntityDivId).height();
                    $('#' + controlProps.ControlInfo.GenericEntityDivId).html('<span style="color:#ccc">Type here to search...</span>');
                    $('#' + controlProps.ControlInfo.GenericEntityDivId).height(h);
                }

                $('#' + controlProps.ControlInfo.GenericEntityDivId).mouseenter(function () {
                    if ($(this).html() !== '' && UnescapeHTML($(this).html()).trim() === 'Type here to search...') {
                        var h = $(this).height();
                        $(this).html('');
                        $(this).height(h);
                    }
                });

                $('#' + controlProps.ControlInfo.GenericEntityDivId).mouseout(function () {
                    if (!$(this).is(':focus')) {
                        if (UnescapeHTML($(this).html()) === undefined || UnescapeHTML($(this).html()) === '') {
                            var h = $(this).height();
                            $(this).html('<span style="color:#ccc">Type here to search...</span>');
                            $(this).height(h);
                        }
                    }
                });

                $('#' + controlProps.ControlInfo.GenericEntityDivId).blur(function () {
                    if (UnescapeHTML($(this).html()) === undefined || UnescapeHTML($(this).html()) === '') {
                        var h = $(this).height();
                        $(this).html('<span style="color:#ccc">Type here to search...</span>');
                        $(this).height(h);
                    }
                });

                $('#' + controlProps.ControlInfo.GenericEntityDivId).focus(function () {
                    if ($(this).html() !== '' && UnescapeHTML($(this).html()).trim() === 'Type here to search...') {
                        var h = $(this).height();
                        $(this).html('');
                        $(this).height(h);
                    }
                });

                // set the control prop array index
                // so we can grab the correct set of prop
                // for control
                $('#' + controlProps.ControlInfo.GenericEntityDivId).attr('CtrlPropArrPos', k);
            });
        }

        function SetCache(data, controlProps) {
            var index = CheckIfDataExists(controlProps);
            var controlProps = window._LookupFieldsPropsArray[index];
            controlProps.CachedValue = data;
            // build the drop down on first time
            //BuildDropDownWithCache(data, controlProps);
        }

        function GetCachedData(cacheObjID) {
            var data = '';
            if (window._LookupFieldsPropsArray) {
                data = window._LookupFieldsPropsArray[cacheObjID].CachedValue;
            }
            return data;
        }

        function BuildAllItemsDropDown(cachedata, controlProps) {

            if (controlProps.ControlType == '1') {
                $('#' + controlProps.ControlInfo.DropDownClientId).prop('disabled', false);
            }
            else if (controlProps.ControlType == '2') {
                $('#' + controlProps.ControlInfo.GenericEntityDivId).prop('disabled', false);
            }

            if (controlProps.ControlType == '1') {
                if (cachedata) {
                    if (controlProps.ControlInfo.IsMultiSelect != true) {
                        $('#' + controlProps.ControlInfo.DropDownClientId).empty();
                        var items = cachedata.split(';#');
                        var itemIndex = 0;
                        // get the values that begins with the search text
                        // don't return options that has been selected already
                        for (var i in items) {
                            if (items[i].indexOf('^') != -1) {
                                var itemPair = items[i].split('^^');
                                var opt = "<option value='" + itemPair[0] + "'>" + itemPair[1] + "</option>";
                                $('#' + controlProps.ControlInfo.DropDownClientId).append(opt);
                                $('#' + controlProps.ControlInfo.DropDownClientId).val(itemPair[0]);
                            }
                        }
                    }
                        // if control is a multi-select control
                    else {
                        if (cachedata && cachedata.indexOf(';#') != -1) {
                            $('#' + controlProps.ControlInfo.SelectCandidateId).empty();
                            var items = cachedata.split(';#');
                            // get the values that begins with the search text
                            // don't return options that has been selected already
                            for (var i in items) {
                                var itemPair = items[i].split('^^');
                                if (itemPair[1] != undefined) {
                                    hasMatch = true;
                                    var opt = "<option value='" + itemPair[0] + "'>" + itemPair[1] + "</option>";
                                    $('#' + controlProps.ControlInfo.SelectCandidateId).append(opt);
                                    itemIndex++;
                                }
                            }

                            $('#' + controlProps.ControlInfo.SelectCandidateId).prop('disabled', false);
                            $('#' + controlProps.ControlInfo.AddButtonId).prop('disabled', false);
                            $('#' + controlProps.ControlInfo.RemoveButtonId).prop('disabled', false);
                            $('#' + controlProps.ControlInfo.SelectResultId).prop('disabled', false);
                        }
                    }
                }
            }
            else if (controlProps.ControlType == '2') {
                controlProps.ControlInfo.CandidateIndex = -1;
                var pickerSelections = new Array();
                var hasMatch = false;
                if (cachedata) {

                    RemoveTypeAheadChoiceCandidate(controlProps);

                    var containerDiv = $(document.createElement('div'))
                           .width($('#' + controlProps.ControlInfo.GenericEntityDivId).outerWidth() - 2)
                           .attr('id', controlProps.ControlInfo.AutoCompleteDivId)
                           .addClass('autocomplete')
                           .css('background-color', 'white');

                    containerDiv.css('top', GetFullTop($('#' + controlProps.ControlInfo.GenericEntityDivId)));
                    containerDiv.css('left', GetFullLeft($('#' + controlProps.ControlInfo.GenericEntityDivId)));

                    $('#' + controlProps.ControlInfo.GenericEntityDivId).after(containerDiv);
                    RegisterClickOutsideEvent(controlProps);

                    $('#' + controlProps.ControlInfo.GenericEntityDivId).blur(function () {
                        $(this).css('display', '');
                    });

                    // get the list of options
                    var htmlHolder = $('#' + controlProps.ControlInfo.GenericEntityDivId).html();
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

                    var items = cachedata.split(';#');
                    var itemIndex = 0;

                    // get the values that contains the search text
                    // don't return options that has been selected already
                    for (var i in items) {
                        var itemPair = items[i].split('^^');
                        if (itemPair[1] != undefined &&
                !ArrayContains(pickerSelections, itemPair[1].toLowerCase().trim())) {
                            hasMatch = true;
                            $('#' + controlProps.ControlInfo.AutoCompleteDivId).append("<div class='autoText' id='autoText_" + itemIndex + "' value='" + itemPair[0] + "'>" + itemPair[1] + "</div>");
                            itemIndex++;
                        }
                    }

                    RegisterHoverStyle();

                    $('.autoText').click(function () {
                        if ($(this).attr('id') === 'autoText_noValue') {
                            return;
                        }

                        if ($('#' + controlProps.FieldName + '_errorText').length > 0) {
                            $('#' + controlProps.FieldName + '_errorText').remove();
                        }
                        if (!controlProps.ControlInfo.IsMultiSelect) {
                            var newText = $(this).html();
                            controlProps.ControlInfo.SingleSelectDisplayVal = newText;
                            controlProps.ControlInfo.SingleSelectLookupVal = $(this).attr('value');
                            //UpdateSingleSelectPickerValue(controlProps);
                            var index = $(this).attr('value');
                            UpdateSingleSelectPickerValueWOValidation(controlProps, index);
                        }
                        else {
                            var newText = $(this).html();
                            var index = $(this).attr('value');
                            //UpdateMultiSelectPickerValue(controlProps, newText);
                            controlProps.ControlInfo.SingleSelectDisplayVal = newText;
                            controlProps.ControlInfo.SingleSelectLookupVal = $(this).attr('value');
                            UpdateMultiSelectPickerValueWOValidation(controlProps, newText, index);
                        }
                    });


                }
                    // without cache
                else {
                    RemoveTypeAheadChoiceCandidate(controlProps);

                    var containerDiv = $(document.createElement('div'))
                           .width($('#' + controlProps.ControlInfo.GenericEntityDivId).outerWidth() - 2)
                           .attr('id', controlProps.ControlInfo.AutoCompleteDivId)
                           .addClass('autocomplete')
                           .css('background-color', 'white');

                    containerDiv.css('top', GetFullTop($('#' + controlProps.ControlInfo.GenericEntityDivId)));
                    containerDiv.css('left', GetFullLeft($('#' + controlProps.ControlInfo.GenericEntityDivId)));

                    $('#' + controlProps.ControlInfo.GenericEntityDivId).after(containerDiv);
                    RegisterClickOutsideEvent(controlProps);

                    $('#' + controlProps.ControlInfo.GenericEntityDivId).blur(function () {
                        $(this).css('display', '');
                    });

                    //$('#' + controlProps.ControlInfo.AutoCompleteDivId).append("<div class='autoText' id='autoText_noValue'>No Values To Select</div>");
                    hasMatch = false;
                }

                if (!hasMatch) {
                    $('#' + controlProps.ControlInfo.AutoCompleteDivId).append("<div class='autoText' id='autoText_noValue'>No Values To Select</div>");
                    //RemoveTypeAheadChoiceCandidate(controlProps);
                }
            }
        }

        function BuildDropDownWithCache(cachedata, controlProps) {

            if (controlProps.ControlType == '1') {
                $('#' + controlProps.ControlInfo.DropDownClientId).prop('disabled', false);
            }
            else if (controlProps.ControlType == '2') {
                $('#' + controlProps.ControlInfo.GenericEntityDivId).prop('disabled', false);
            }

            if (controlProps.ControlType == '1') {
                if (cachedata) {
                    if (controlProps.ControlInfo.IsMultiSelect != true) {
                        $('#' + controlProps.ControlInfo.DropDownClientId).empty();
                        var none = "<option value='0'>(none)</option>";
                        $('#' + controlProps.ControlInfo.DropDownClientId).append(none);
                        var items = cachedata.split(';#');
                        var itemIndex = 0;
                        // get the values that begins with the search text
                        // don't return options that has been selected already
                        for (var i in items) {
                            if (items[i].indexOf('^') != -1) {
                                var itemPair = items[i].split('^^');
                                var opt = "<option value='" + itemPair[0] + "'>" + itemPair[1] + "</option>";
                                $('#' + controlProps.ControlInfo.DropDownClientId).append(opt);
                                $('#' + controlProps.ControlInfo.DropDownClientId).val(itemPair[0]);
                            }
                        }
                    }
                        // if control is a multi-select control
                    else {
                        if (cachedata && cachedata.indexOf(';#') != -1) {
                            $('#' + controlProps.ControlInfo.SelectCandidateId).empty();
                            var items = cachedata.split(';#');
                            // get the values that begins with the search text
                            // don't return options that has been selected already
                            for (var i in items) {
                                var itemPair = items[i].split('^^');
                                if (itemPair[1] != undefined) {
                                    hasMatch = true;
                                    var opt = "<option value='" + itemPair[0] + "'>" + itemPair[1] + "</option>";
                                    $('#' + controlProps.ControlInfo.SelectCandidateId).append(opt);
                                    itemIndex++;
                                }
                            }

                            $('#' + controlProps.ControlInfo.SelectCandidateId).prop('disabled', false);
                            $('#' + controlProps.ControlInfo.AddButtonId).prop('disabled', false);
                            $('#' + controlProps.ControlInfo.RemoveButtonId).prop('disabled', false);
                            $('#' + controlProps.ControlInfo.SelectResultId).prop('disabled', false);
                        }
                    }
                }
            }
            else if (controlProps.ControlType == '2') {
                controlProps.ControlInfo.CandidateIndex = -1;
                var pickerSelections = new Array();
                var hasMatch = false;
                if (cachedata) {

                    RemoveTypeAheadChoiceCandidate(controlProps);

                    var containerDiv = $(document.createElement('div'))
                           .width($('#' + controlProps.ControlInfo.GenericEntityDivId).outerWidth() - 2)
                           .attr('id', controlProps.ControlInfo.AutoCompleteDivId)
                           .addClass('autocomplete')
                           .css('background-color', 'white');

                    containerDiv.css('top', GetFullTop($('#' + controlProps.ControlInfo.GenericEntityDivId)));
                    containerDiv.css('left', GetFullLeft($('#' + controlProps.ControlInfo.GenericEntityDivId)));

                    $('#' + controlProps.ControlInfo.GenericEntityDivId).after(containerDiv);
                    RegisterClickOutsideEvent(controlProps);

                    $('#' + controlProps.ControlInfo.GenericEntityDivId).blur(function () {
                        $(this).css('display', '');
                    });

                    // get the list of options
                    var htmlHolder = $('#' + controlProps.ControlInfo.GenericEntityDivId).html();
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

                    var cleanTxt = controlProps.ControlInfo.SearchText.toLowerCase().trim();
                    // firefox inserts <br> 
                    if (cleanTxt.indexOf('<br>') != -1) {
                        cleanTxt = cleanTxt.replace(/<br>/g, '');
                    }
                    cleanTxt = cleanTxt.trim();

                    var items = cachedata.split(';#');
                    var itemIndex = 0;
                    // get the values that begins with the search text
                    // don't return options that has been selected already
                    for (var i in items) {
                        var itemPair = items[i].split('^^');
                        if (itemPair[1] != undefined &&
                itemPair[1].toLowerCase().trim().indexOf(cleanTxt) == 0 &&
                !ArrayContains(pickerSelections, itemPair[1].toLowerCase().trim())) {
                            hasMatch = true;
                            $('#' + controlProps.ControlInfo.AutoCompleteDivId).append("<div class='autoText' id='autoText_" + itemIndex + "' value='" + itemPair[0] + "'>" + itemPair[1] + "</div>");
                            itemIndex++;
                        }
                    }

                    // get the values that contains the search text
                    // don't return options that has been selected already
                    for (var i in items) {
                        var itemPair = items[i].split('^^');
                        if (itemPair[1] != undefined &&
                itemPair[1].toLowerCase().trim().indexOf(cleanTxt) != 0 &&
                itemPair[1].toLowerCase().trim().indexOf(cleanTxt) != -1 &&
                !ArrayContains(pickerSelections, itemPair[1].toLowerCase().trim())) {
                            hasMatch = true;
                            $('#' + controlProps.ControlInfo.AutoCompleteDivId).append("<div class='autoText' id='autoText_" + itemIndex + "' value='" + itemPair[0] + "'>" + itemPair[1] + "</div>");
                            itemIndex++;
                        }
                    }

                    RegisterHoverStyle();

                    $('.autoText').click(function () {
                        if ($(this).attr('id') === 'autoText_noValue') {
                            return;
                        }

                        if ($('#' + controlProps.FieldName + '_errorText').length > 0) {
                            $('#' + controlProps.FieldName + '_errorText').remove();
                        }
                        if (!controlProps.ControlInfo.IsMultiSelect) {
                            var newText = $(this).html();
                            controlProps.ControlInfo.SingleSelectDisplayVal = newText;
                            controlProps.ControlInfo.SingleSelectLookupVal = $(this).attr('value');
                            //UpdateSingleSelectPickerValue(controlProps);
                            var index = $(this).attr('value');
                            UpdateSingleSelectPickerValueWOValidation(controlProps, index);
                        }
                        else {
                            var newText = $(this).html();
                            //UpdateMultiSelectPickerValue(controlProps, newText);
                            var index = $(this).attr('value');
                            controlProps.ControlInfo.SingleSelectDisplayVal = newText;
                            controlProps.ControlInfo.SingleSelectLookupVal = $(this).attr('value');
                            UpdateMultiSelectPickerValueWOValidation(controlProps, newText, index);
                        }
                    });

                }
                    // without cache
                else {
                    RemoveTypeAheadChoiceCandidate(controlProps);

                    var containerDiv = $(document.createElement('div'))
                           .width($('#' + controlProps.ControlInfo.GenericEntityDivId).outerWidth() - 2)
                           .attr('id', controlProps.ControlInfo.AutoCompleteDivId)
                           .addClass('autocomplete')
                           .css('background-color', 'white');

                    containerDiv.css('top', GetFullTop($('#' + controlProps.ControlInfo.GenericEntityDivId)));
                    containerDiv.css('left', GetFullLeft($('#' + controlProps.ControlInfo.GenericEntityDivId)));

                    $('#' + controlProps.ControlInfo.GenericEntityDivId).after(containerDiv);
                    RegisterClickOutsideEvent(controlProps);

                    $('#' + controlProps.ControlInfo.GenericEntityDivId).blur(function () {
                        $(this).css('display', '');
                    });

                    //$('#' + controlProps.ControlInfo.AutoCompleteDivId).append("<div class='autoText' id='autoText_noValue'>No Values To Select</div>");
                    hasMatch = false;
                }

                if (!hasMatch) {
                    $('#' + controlProps.ControlInfo.AutoCompleteDivId).append("<div class='autoText' id='autoText_noValue'>No Values To Select</div>");
                }

            }
        }



        function RegisterHoverStyle() {
            if ($('.autoText').length > 0) {
                $('.autoText').each(function () {
                    $(this).hover(
                        function () {
                            $(this).parent().children().each(function () {
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

        function RegisterClickOutsideEvent(controlProps) {
            document.onclick = function(event) {
                if (clickedOutsideElement(controlProps.ControlInfo.AutoCompleteDivId, event)) {
                    if (clickedOutsideElement(controlProps.FieldName + '_ddlShowAll', event)) {
                        $('#' + controlProps.ControlInfo.AutoCompleteDivId).css('display', 'none');
                    }
                } else {
                    $('#' + controlProps.ControlInfo.AutoCompleteDivId).css('display', '');
                }
            };
        }

        function UpdateSingleSelectPickerValue(controlProps) {

            $('#' + controlProps.ControlInfo.GenericEntityDivId).html('');
            $('#' + controlProps.ControlInfo.GenericEntityDivId).html(controlProps.ControlInfo.SingleSelectDisplayVal);
            $('#' + controlProps.ControlInfo.GenericEntityDivId).css('color', '#000000');

            RemoveTypeAheadChoiceCandidate(controlProps);
            ValidateEntity(controlProps.ControlInfo.GenericEntityCheckNameId);

            UpdateChildrenValues(controlProps);
        }

        function UpdateSingleSelectPickerValueWOValidation(controlProps, index) {

            $('#' + controlProps.ControlInfo.GenericEntityDivId).focus();
            $('#' + controlProps.ControlInfo.GenericEntityDivId).html('');
            var selectedValue = controlProps.ControlInfo.SingleSelectDisplayVal;
            var spEntityStyle = '<span contenteditable="false" title="' + selectedValue + '" class="ms-entity-resolved" tabindex="-1" iscontenttype="true" id="span' + index + '" onmouseover="this.contentEditable=false;" onmouseout="this.contentEditable=true;">' +
	                                '<div description="' + selectedValue + '" isresolved="True" displaytext="' + selectedValue + '" key="' + index + '" id="divEntityData" style="display:none;">' +
		                                '<div style="display:none;" data="">' + selectedValue + '</div>' +
	                                '</div>' +
	                                '<span contenteditable="" oncontextmenu="onContextMenuSpnRw(event,ctx);" onmousedown="onMouseDownRw(event);" tabindex="-1" id="content">' + selectedValue + '</span>' +
                                '</span>';

            //$('#' + controlProps.ControlInfo.GenericEntityDivId).html(spEntityStyle);

            $('#' + controlProps.ControlInfo.GenericEntityDivId).append('&nbsp;');
            $('#' + controlProps.ControlInfo.GenericEntityDivId).append(spEntityStyle);
            $('#' + controlProps.ControlInfo.GenericEntityDivId).append('&nbsp;');
            $('#' + controlProps.ControlInfo.GenericEntityDivId).append(';');
            $('#' + controlProps.ControlInfo.GenericEntityDivId).append('&nbsp;');

            $('#' + controlProps.ControlInfo.GenericEntityDivId).css('color', '#000000');

            RemoveTypeAheadChoiceCandidate(controlProps);
            //ValidateEntity(controlProps.ControlInfo.GenericEntityCheckNameId);

            UpdateChildrenValues(controlProps);
        }

        function UpdateChildrenValues(controlProps) {
            if (window._LookupFieldsPropsArray) {
                for (var k in window._LookupFieldsPropsArray) {
                    var prop = window._LookupFieldsPropsArray[k];
                    if (prop.Parent == controlProps.FieldName) {
                        FetchChildData(controlProps, prop, k);
                    }
                }
            }
        }

        function RedisableChildren(controlProps) {
            if (window._LookupFieldsPropsArray) {
                for (var k in window._LookupFieldsPropsArray) {
                    var prop = window._LookupFieldsPropsArray[k];
                    if (prop.Parent == controlProps.FieldName) {
                        DisableChild(controlProps, prop, k);
                    }
                }
            }
        }

        function DisableChild(controlProps, childControlProp, k) {
            if (childControlProp.Parent !== '' && childControlProp.ControlType === '2') {
                // set html to blank
                var h = $('#' + childControlProp.ControlInfo.GenericEntityDivId).height();
                $('#' + childControlProp.ControlInfo.GenericEntityDivId).html('');
                $('#' + childControlProp.ControlInfo.GenericEntityDivId).height(h);

                $('#' + childControlProp.ControlInfo.GenericEntityDivId).attr('disabled', true);
                $('#' + childControlProp.ControlInfo.GenericEntityDivId).prop('contenteditable', false);
                $('#' + childControlProp.ControlInfo.GenericEntityDivId).addClass('disabledTb');
                var index = childControlProp.ControlInfo.GenericEntityDivId.lastIndexOf('_');
                var browseId = childControlProp.ControlInfo.GenericEntityDivId.substring(0, index) + '_browse';
                var addItemId = childControlProp.ControlInfo.GenericEntityDivId.substring(0, index) + '_addItem';
                childControlProp.BrowseLinkOnClick = $('#' + browseId).attr('onclick');
                childControlProp.AddItemLinkOnClick = $('#' + addItemId).attr('onclick');
                $('#' + browseId).removeAttr('onclick');
                $('#' + browseId).css('cursor', 'default');
                $('#' + browseId).find('IMG').addClass('disabledImg')
                $('#' + addItemId).removeAttr('onclick');
                $('#' + addItemId).css('cursor', 'default');
                $('#' + addItemId).find('IMG').addClass('disabledImg')

                if (childControlProp.ControlType == '2' && $('#' + childControlProp.FieldName + '_ddlShowAll').length > 0) {
                    $('#' + childControlProp.FieldName + '_ddlShowAll').addClass('disabledImg');
                    $('#' + childControlProp.FieldName + '_ddlShowAll').unbind('click');
                }
            }
        }

        function FetchChildData(parentControlProp, childControlProp, k) {

            var postData = {
                webid: childControlProp.FieldInfo.LookupWebId,
                listid: childControlProp.FieldInfo.LookupListId,
                fieldid: childControlProp.FieldInfo.LookupFieldId,
                field: childControlProp.FieldInfo.LookupField,
                parent: parentControlProp.FieldName,
                parentValue: parentControlProp.ControlInfo.SingleSelectLookupVal,
                parentListField: childControlProp.ParentListField
            };

            $.post(childControlProp.ControlInfo.CurWebURL + "/_layouts/epmlive/GenericEntityTypeAheadAjaxHandler.aspx", postData, function (data) {

                if (childControlProp.ControlType == '2') {
                    $('#' + childControlProp.ControlInfo.GenericEntityDivId).removeAttr('disabled');
                    $('#' + childControlProp.ControlInfo.GenericEntityDivId).prop('contenteditable', true);
                    $('#' + childControlProp.ControlInfo.GenericEntityDivId).removeClass('disabledTb');
                    var index = childControlProp.ControlInfo.GenericEntityDivId.lastIndexOf('_');
                    var browseId = childControlProp.ControlInfo.GenericEntityDivId.substring(0, index) + '_browse';
                    var addItemId = childControlProp.ControlInfo.GenericEntityDivId.substring(0, index) + '_addItem';
                    $('#' + browseId).attr('onclick', childControlProp.BrowseLinkOnClick);
                    $('#' + browseId).css('cursor', 'pointer');
                    $('#' + browseId).find('IMG').removeClass('disabledImg')
                    $('#' + addItemId).attr('onclick', childControlProp.AddItemLinkOnClick);
                    $('#' + addItemId).css('cursor', 'pointer');
                    $('#' + addItemId).find('IMG').removeClass('disabledImg')

                    if ($('#' + childControlProp.FieldName + '_ddlShowAll').length > 0) {
                        $('#' + childControlProp.FieldName + '_ddlShowAll').click(function () {

                            if (childControlProp.Parent != '') {
                                var index = CheckIfDataExists(childControlProp);
                                var cachedata = GetCachedData(index);
                                BuildAllItemsDropDown(cachedata, childControlProp);
                            }
                        });

                        $('#' + childControlProp.FieldName + '_ddlShowAll').attr('CtrlPropArrPos', k);
                        $('#' + childControlProp.FieldName + '_ddlShowAll').removeClass('disabledImg');
                    }

                }
                else {
                    if ($('#' + childControlProp.ControlInfo.DropDownClientId).length > 0) {
                        $('#' + childControlProp.ControlInfo.DropDownClientId).removeAttr('disabled');
                        if (childControlProp.Parent != '') {
                            var index = CheckIfDataExists(childControlProp);
                            var cachedata = GetCachedData(index);
                            BuildAllItemsDropDown(cachedata, childControlProp);
                        }
                    }
                }

                $('#' + childControlProp.ControlInfo.GenericEntityDivId).html('');
                $('#' + childControlProp.ControlInfo.GenericEntityDivId).html('<span style="color:gray">Type here to search...</span>');
                SetCache(data, childControlProp);
                BuildDropDownWithCache(data, childControlProp);
            });
        }



        function UpdateAllSingleSelectValsBeforeSafe() {
            if (window._LookupFieldsPropsArray) {
                for (var k in window._LookupFieldsPropsArray) {
                    var controlProps = window._LookupFieldsPropsArray[k];

                    if (!controlProps.ControlInfo.IsMultiSelect) {
                        if (controlProps.ControlType == "1") {
                            var value = $('#' + controlProps.ControlInfo.DropDownClientId).val();
                            controlProps.ControlInfo.SingleSelectLookupVal = value.trim();
                        }
                        else if (controlProps.ControlType == "2") {
                            //                        var html = $('#' + controlProps.ControlInfo.GenericEntityDivId).html();
                            //                        if (html == 'Type here to search...' || html == '0') {
                            //                            $('#' + controlProps.ControlInfo.GenericEntityDivId).html('');
                            //                        }
                            //                        var parent = null;
                            //                        var selection = '';
                            //                        try {
                            //                            parent = $(html).wrap('<DIV></DIV>').parent();
                            //                        }
                            //                        catch (e) {
                            //                        }
                            //                        if (parent != null) {
                            //                            parent.find('SPAN').each(function () {
                            //                                //if (!($(this).text() == 'Type here to search... ' || $(this).text() == '0 ')) {
                            //                                selection = $(this).text();
                            //                                //                        }
                            //                                //                        else {
                            //                                //                            $('#' + controlProps.ControlInfo.GenericEntityDivId).html('');
                            //                                //                        }
                            //                            });
                            //                        }

                            //                        controlProps.ControlInfo.SingleSelectLookupVal = selection.trim();
                        }
                    }
                }
            }
            return true;
        }

        function PostDataBackToSingleSelectLookup() {
            if (window._LookupFieldsPropsArray) {
                for (var k in window._LookupFieldsPropsArray) {
                    var controlProps = window._LookupFieldsPropsArray[k];

                    // post value only for single select lookups
                    if (!controlProps.ControlInfo.IsMultiSelect) {

                        if (controlProps.ControlType == "1") {

                            //                        var lookupDdlId = controlProps.ControlInfo.SourceControlId.substr(0, controlProps.ControlInfo.SourceControlId.lastIndexOf('_')) + '_Lookup';

                            //                        $('#' + lookupDdlId).find('option').each(function () {
                            //                            if ($(this).val() == controlProps.ControlInfo.SingleSelectLookupVal) {
                            //                                $(this).prop('selected', 'selected');
                            //                            }
                            //                            else {
                            //                                $(this).removeAttr('selected');
                            //                            }
                            //                        });
                        }
                        else if (controlProps.ControlType == "2") {

                            // change text value
                            var sourceCtrlSelector = '#' + controlProps.ControlInfo.SourceControlId;

                            if ($(sourceCtrlSelector).length > 0) {
                                $(sourceCtrlSelector).val(controlProps.ControlInfo.SingleSelectLookupVal);

                                // change hidden control value
                                var newHiddenCtrlValue = '0';
                                var hiddenControlID = $(sourceCtrlSelector).attr('optHid');
                                var choicesRaw = $(sourceCtrlSelector).attr('choices');
                                var choices = choicesRaw.split('|');
                                for (var c in choices) {
                                    if (choices[c] == controlProps.ControlInfo.SingleSelectLookupVal) {
                                        newHiddenCtrlValue = choices[parseInt(c)];
                                        break;
                                    }
                                }
                                var hiddenCtrlID = '#' + hiddenControlID;
                                $(hiddenCtrlID).val(newHiddenCtrlValue);
                            }
                                // chrome does not have this control
                                // so we're going to set the new
                                // dropdown value
                            else {
                                var lookupDdlId = controlProps.ControlInfo.SourceControlId;
                                if ((controlProps.Required == 'True'
                                && $('#' + controlProps.ControlInfo.GenericEntityDivId).html().indexOf('SPAN') == -1
                                && $('#' + controlProps.ControlInfo.GenericEntityDivId).html().indexOf('span') == -1) ||
                                (controlProps.Required == 'True'
                                && $('#' + controlProps.ControlInfo.GenericEntityDivId).html().indexOf('Type here to search...') != -1)) {
                                    if (!($('#' + controlProps.FieldName + '_errorText').length > 0)) {
                                        $('#' + controlProps.ControlInfo.GenericEntityDivId).after('<div style=\"clear:both\"></div>')
                                                                                        .after('<div id=\"' + controlProps.FieldName + '_errorText\" class=\"ms-formvalidation\">You must specify a value for this required field.</div>');

                                    }
                                    return false;
                                }
                                else {
                                    if ($('#' + controlProps.ControlInfo.GenericEntityDivId).find('#divEntityData').length > 0) {
                                        var entityKey = $('#' + controlProps.ControlInfo.GenericEntityDivId).find('#divEntityData').first().attr('key');
                                        if (entityKey != $('#' + lookupDdlId).val()) {
                                            if (!($('[id="' + lookupDdlId + '"]').find('option[value="' + entityKey + '"]').length > 0)) {
                                                var index = CheckIfDataExists(controlProps);
                                                var cachedata = GetCachedData(index);
                                                var keyValPairs = cachedata.split(';#');
                                                var newOpt = '';
                                                if (!keyValPairs.length) {
                                                    keyValPairs = [keyValPairs];
                                                }

                                                if (keyValPairs.length > 0) {
                                                    for (k in keyValPairs) {
                                                        var pair = keyValPairs[k];
                                                        if (pair.split('^^')[0] == controlProps.ControlInfo.SingleSelectLookupVal) {
                                                            newOpt = pair;
                                                        }
                                                    }
                                                }

                                                var opt = "<option value='" + newOpt.split('^^')[0] + "'>" + newOpt.split('^^')[1] + "</option>";
                                                $('[id="' + controlProps.ControlInfo.SourceDropDownID + '"]').append(opt);
                                                //$('#' + lookupDdlId).val(controlProps.ControlInfo.SingleSelectLookupVal);
                                            }
                                            else {
                                                $('[id="' + lookupDdlId + '"]').val(entityKey)
                                            }
                                        }
                                    }
                                    else {
                                        $('[id="' + lookupDdlId + '"]').val(0)
                                    }

                                    //                                if (controlProps.ControlInfo.SingleSelectLookupVal != '' &&
                                    //                                    controlProps.ControlInfo.SingleSelectLookupVal != $('#' + lookupDdlId).val()) {

                                    //                                    if (!($('#' + controlProps.ControlInfo.SourceDropDownID).find('option[value=' + controlProps.ControlInfo.SingleSelectLookupVal + ']').length > 0)) {
                                    //                                        var index = CheckIfDataExists(controlProps);
                                    //                                        var cachedata = GetCachedData(index);
                                    //                                        var keyValPairs = cachedata.split(';#');
                                    //                                        var newOpt = '';
                                    //                                        if (!keyValPairs.length) {
                                    //                                            keyValPairs = [keyValPairs];
                                    //                                        }

                                    //                                        if (keyValPairs.length > 0) {
                                    //                                            for (k in keyValPairs) {
                                    //                                                var pair = keyValPairs[k];
                                    //                                                if (pair.split(',')[0] == controlProps.ControlInfo.SingleSelectLookupVal) {
                                    //                                                    newOpt = pair;
                                    //                                                }
                                    //                                            }
                                    //                                        }

                                    //                                        var opt = "<option value='" + newOpt.split(',')[0] + "'>" + newOpt.split(',')[1] + "</option>";
                                    //                                        $('#' + controlProps.ControlInfo.SourceDropDownID).append(opt);
                                    //                                        //$('#' + lookupDdlId).val(controlProps.ControlInfo.SingleSelectLookupVal);
                                    //                                    }
                                    //                                    else {
                                    //                                        $('#' + lookupDdlId).val(controlProps.ControlInfo.SingleSelectLookupVal);
                                    //                                    }
                                    //                                }

                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        function UpdateMultiSelectPickerValue(controlProps, newTextVal) {
            // updates the picker's values
            var clean = $('#' + controlProps.ControlInfo.GenericEntityDivId).html();
            clean = clean.substring(0, clean.lastIndexOf(';') + 1);
            $('#' + controlProps.ControlInfo.GenericEntityDivId).html(clean);
            $('#' + controlProps.ControlInfo.GenericEntityDivId).append(newTextVal);
            RemoveTypeAheadChoiceCandidate(controlProps);
            ValidateEntity(controlProps.ControlInfo.GenericEntityCheckNameId);
        }

        function UpdateMultiSelectPickerValueWOValidation(controlProps, newTextVal, index) {
            // updates the picker's values
            $('#' + controlProps.ControlInfo.GenericEntityDivId).focus();
            var clean = $('#' + controlProps.ControlInfo.GenericEntityDivId).html();
            clean = clean.substring(0, clean.lastIndexOf(';') + 1);
            $('#' + controlProps.ControlInfo.GenericEntityDivId).html(clean);

            var spEntityStyle = '<span contenteditable="false" title="' + newTextVal + '" class="ms-entity-resolved" tabindex="-1" iscontenttype="true" id="span1" onmouseover="this.contentEditable=false;" onmouseout="this.contentEditable=true;">' +
	                                '<div description="' + newTextVal + '" isresolved="True" displaytext="' + newTextVal + '" key="' + index + '" id="divEntityData" style="display:none;">' +
		                                '<div data=""></div>' +
	                                '</div>' +
	                                '<span contenteditable="" oncontextmenu="onContextMenuSpnRw(event,ctx);" onmousedown="onMouseDownRw(event);" tabindex="-1" id="content">' + newTextVal + '</span>' +
                                '</span>';

            $('#' + controlProps.ControlInfo.GenericEntityDivId).append('&nbsp;');
            $('#' + controlProps.ControlInfo.GenericEntityDivId).append(spEntityStyle);
            $('#' + controlProps.ControlInfo.GenericEntityDivId).append('&nbsp;');
            $('#' + controlProps.ControlInfo.GenericEntityDivId).append(';');
            $('#' + controlProps.ControlInfo.GenericEntityDivId).append('&nbsp;');
            RemoveTypeAheadChoiceCandidate(controlProps);
            //ValidateEntity(controlProps.ControlInfo.GenericEntityCheckNameId);

            UpdateChildrenValues(controlProps);
        }

        function PostDataBackToMultiSelectLookup() {
            if (window._LookupFieldsPropsArray) {
                for (var k in window._LookupFieldsPropsArray) {
                    // controlProps is an object created on serverside
                    // its injected from serverside on GenericEntityEditor.cs
                    var controlProps = window._LookupFieldsPropsArray[k];

                    if (controlProps.ControlInfo.IsMultiSelect) {

                        if (controlProps.ControlType == "1") {
                            // selections in picker div, might or might not have been selected previously
                            var pickerSelections = new Array();
                            // unselect all default selection
                            $('#' + controlProps.ControlInfo.SourceSelectCandidateId).trigger('click');
                            $('#' + controlProps.ControlInfo.SourceSelectCandidateId + ' > option').each(function () {
                                $(this).attr('selected', false);
                            });

                            $('#' + controlProps.ControlInfo.SourceSelectResultId).trigger('click');
                            // remove all existing values first-
                            $('#' + controlProps.ControlInfo.SourceSelectResultId + ' > option').each(function () {
                                $(this).attr('selected', true);
                            });

                            // click remove button
                            $('#' + controlProps.ControlInfo.SourceRemoveButtonId).trigger('click');

                            // get the list of options
                            var opts = $('#' + controlProps.ControlInfo.SelectResultId).find('option').each(function () {
                                if (!ArrayContains(pickerSelections, $(this).text())) {
                                    pickerSelections.push($(this).text());
                                }
                            });

                            // select new candIdates
                            $('#' + controlProps.ControlInfo.SourceSelectCandidateId).trigger('click');
                            // select them in selectCandidate listbox
                            $('#' + controlProps.ControlInfo.SourceSelectCandidateId).find('option').each(function () {
                                var titleValue = $(this).attr('title');
                                if (ArrayContains(pickerSelections, titleValue)) {
                                    $(this).attr('selected', true);
                                }
                                else {
                                    $(this).attr('selected', false);
                                }
                            });

                            // press addButton by triggering click
                            $('#' + controlProps.ControlInfo.SourceAddButtonId).trigger('click');
                        }
                        else if (controlProps.ControlType == "2") {
                            // selections in picker div, might or might not have been selected previously
                            var pickerSelections = new Array();
                            // unselect all default selection
                            $('#' + controlProps.ControlInfo.SelectCandidateId).trigger('click');
                            $('#' + controlProps.ControlInfo.SelectCandidateId + ' > option').each(function () {
                                $(this).attr('selected', false);
                            });

                            $('#' + controlProps.ControlInfo.SelectResultId).trigger('click');
                            // remove all existing values first-
                            $('#' + controlProps.ControlInfo.SelectResultId + ' > option').each(function () {
                                $(this).attr('selected', true);
                            });

                            // click remove button
                            $('#' + controlProps.ControlInfo.RemoveButtonId).trigger('click');

                            // get the list of options
                            var htmlHolder = $('#' + controlProps.ControlInfo.GenericEntityDivId).html();
                            $('<div>' + htmlHolder + '</div>').find('SPAN').each(function () {
                                if (!ArrayContains(pickerSelections, $(this).text())) {
                                    pickerSelections.push($(this).text());
                                }
                            });

                            if (controlProps.Required === 'True') {
                                if (!pickerSelections.length) {
                                    if (!($('#' + controlProps.FieldName + '_errorText').length > 0)) {
                                        $('#' + controlProps.ControlInfo.GenericEntityDivId).after('<div style=\"clear:both\"></div>')
                                                                                        .after('<div id=\"' + controlProps.FieldName + '_errorText\" class=\"ms-formvalidation\">You must specify a value for this required field.</div>');

                                    }
                                    return false;
                                }
                            }

                            // select new candidates
                            $('#' + controlProps.ControlInfo.SelectCandidateId).trigger('click');
                            // select them in selectCandidate listbox
                            $('#' + controlProps.ControlInfo.SelectCandidateId + ' > option').each(function () {
                                var titleValue = $(this).attr('title');
                                if (ArrayContains(pickerSelections, titleValue)) {
                                    $(this).attr('selected', true);
                                }
                                else {
                                    $(this).attr('selected', false);
                                }
                            });

                            // press addButton by triggering click
                            $('#' + controlProps.ControlInfo.AddButtonId).trigger('click');
                        }
                    }
                }
            }
            return true;
        }

        function CleanPeopleEditorVals() {
            if (window._wePeopleEditorControlPropertyArray) {
                for (var k in window._wePeopleEditorControlPropertyArray) {
                    var controlProps = window._wePeopleEditorControlPropertyArray[k];
                    if ($('#' + controlProps.wePeopleEditorDivID).html().indexOf('Loading...') != -1) {
                        $('#' + controlProps.wePeopleEditorDivID).html('');
                    }
                }
            }
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

        // fires before form save
        window.PreSaveAction = function () {
            var multiOk = PostDataBackToMultiSelectLookup();
            var updateOk = UpdateAllSingleSelectValsBeforeSafe();
            var singleOk = PostDataBackToSingleSelectLookup();

            CleanPeopleEditorVals();

            if (multiOk && updateOk && singleOk) {
                return true;
            } else {
                return false;
            }
        }

        // ===== HELPER FUNCTIONS =====

        function RemoveTypeAheadChoiceCandidate(controlProps) {
            if ($('#' + controlProps.ControlInfo.AutoCompleteDivId).length > 0) {
                $('#' + controlProps.ControlInfo.AutoCompleteDivId).remove();
            }

            if ($('.autocomplete').length > 0) {
                $('.autocomplete').remove();
            }

            controlProps.ControlInfo.CandidateIndex = -1;
        }

        function ValidateEntity(GenericEntityCheckNameId) {
            setTimeout(function () {
                if ($('#' + GenericEntityCheckNameId)) {
                    $('#' + GenericEntityCheckNameId).trigger('click');
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
                theElem = (window.event) ? GetEventTarget(window.event) : event.target;
            }
            catch (e)
            { }
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
            // if string contains resolved entities
            if (result.indexOf("span>") != -1 || result.indexOf("SPAN>") != -1) {
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
            }
            else {
                var lastSemiColonIndex = result.lastIndexOf(';');
                try {
                    if (lastSemiColonIndex != -1) {
                        result = result.substring(0, lastSemiColonIndex);
                        result = result.trim();
                    }
                }
                catch (e) {
                    result = '';
                }
            }
            return result;
        }

        function HideSPControls(controlProps) {
            if (controlProps.ControlInfo.GenericEntityDivIdRoot != '') {
                // hide SP Control
                $('#' + controlProps.ControlInfo.GenericEntityDivIdRoot).siblings().css('display', 'none');
            }
            if (controlProps.ControlInfo.GenericEntityCheckNameId != '') {
                // hide validation button
                $('#' + controlProps.ControlInfo.GenericEntityCheckNameId).css('display', 'none');
            }

            if (controlProps.ControlInfo.DropDownClientId != '') {
                $('#' + controlProps.ControlInfo.DropDownClientId).parent().siblings().css('display', 'none');
            }

            if (controlProps.ControlInfo.TextBoxClientId != '') {
                $('#' + controlProps.ControlInfo.TextBoxClientId).parent().siblings().css('display', 'none');
            }

            if (controlProps.ControlInfo.DropImageClientId != '') {
                $('#' + controlProps.ControlInfo.DropImageClientId).parent().siblings().css('display', 'none');
            }

        }

        function SetProperOuterTableCssClass(GenericEntityDivIdRoot) {
            $('#' + GenericEntityDivIdRoot + '_OuterTable').addClass("ms-long");
        }

        $$.OpenUrlWithModal = function(urlVal) {
            var options = {
                url: urlVal,
                title: 'Add New Item to Target List',
                allowMaximize: true,
                width: 650,
                height: 500,
                dialogReturnValueCallback: function(dialogResult) {
                    SP.UI.ModalDialog.RefreshPage(dialogResult);
                }
            };

            SP.UI.ModalDialog.showModalDialog(options);
        };

        function UnescapeHTML(escapedHTML) {
            var d = document.createElement("div");
            d.innerHTML = escapedHTML;
            if (!d.innerText) {
                return d.textContent;
            } else {
                return d.innerText;
            }
        }

        function ScrollCandidateDiv(id, newTop) {
            $('#' + id).animate({ scrollTop: newTop }, 'fast');
        }

    }(window.epmLiveGenericEntityEditor = window.epmLiveGenericEntityEditor || {}, jQuery, window));

}
ExecuteOrDelayUntilScriptLoaded(GEInit, "EPMLive.js");


