/// <reference path="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js" />
function MDInit() {
    (function ($$, $) {

        $(document).ready(function () {

            if (window._LookupFieldsPropsArray) {
                for (var k in window._LookupFieldsPropsArray) {
                    var controlProps = window._LookupFieldsPropsArray[k];

                    HideSPControls(controlProps);
                }
            }
        });

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

        $$.UpdateChildrenValues = function (fieldName) {
            var currentProp = GetPropByFieldName(fieldName);
            if (window._LookupFieldsPropsArray) {
                for (var k in window._LookupFieldsPropsArray) {
                    var prop = window._LookupFieldsPropsArray[k];
                    if (prop.Parent == currentProp.FieldName) {
                        FetchChildData(currentProp, prop, k);
                    }
                }
            }
        }

        function UpdateChildrenValues(controlProps) {
            if (window._LookupFieldsPropsArray) {
                for (var k in window._LookupFieldsPropsArray) {
                    var prop = window._LookupFieldsPropsArray[k];
                    if (prop.Parent == controlProps.FieldName) {
                        FetchChildData(controlProps, prop);
                    }
                }
            }
        }

        function GetPropByFieldName(fieldName) {
            var result = undefined;
            if (window._LookupFieldsPropsArray) {
                for (var k in window._LookupFieldsPropsArray) {
                    var prop = window._LookupFieldsPropsArray[k];
                    if (prop.FieldName == fieldName) {
                        result = prop;
                        break;
                    }
                }
            }
            return result;
        }

        function FetchChildData(currentProp, childControlProp, k) {
            var parentVal = $('#' + currentProp.ControlInfo.DropDownClientId).val();

            var postData = {
                webid: childControlProp.FieldInfo.LookupWebId,
                listid: childControlProp.FieldInfo.LookupListId,
                field: childControlProp.FieldInfo.LookupField,
                fieldId: childControlProp.FieldInfo.LookupFieldId,
                parent: childControlProp.Parent,
                parentValue: parentVal,
                parentListField: childControlProp.ParentListField
            };

            $.post(currentProp.ControlInfo.CurWebURL + "/_layouts/epmlive/GenericEntityTypeAheadAjaxHandler.aspx", postData, function (data) {
                if (childControlProp.ControlType == '2') {
                    $('#' + childControlProp.ControlInfo.GenericEntityDivId).removeAttr('disabled');
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

        function SetCache(data, controlProps) {
            var index = CheckIfDataExists(controlProps);
            var controlProps = window._LookupFieldsPropsArray[index];
            controlProps.CachedValue = data;

            // build the drop down on first time
            //BuildDropDownWithCache(data, controlProps);
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
                           .width($('#' + controlProps.ControlInfo.GenericEntityDivId).width())
                           .attr('id', controlProps.ControlInfo.AutoCompleteDivId)
                           .addClass('autocomplete');

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
                        parent = $(htmlHolder).wrap('<DIV></DIV').parent();
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
                            $('#' + controlProps.ControlInfo.AutoCompleteDivId).append("<div class='autoText' id='autoText_" + itemIndex + "' value='" + itemPair[0] + "' >" + itemPair[1] + "</div>");
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
                            $('#' + controlProps.ControlInfo.AutoCompleteDivId).append("<div class='autoText' id='autoText_" + itemIndex + "'>" + itemPair[1] + "</div>");
                            itemIndex++;
                        }
                    }

                    RegisterHoverStyle();

                    $('.autoText').click(function () {
                        if (!controlProps.ControlInfo.IsMultiSelect) {
                            var newText = $(this).html();
                            controlProps.ControlInfo.SingleSelectLookupVal = $(this).attr("value");
                            controlProps.ControlInfo.SingleSelectDisplayVal = newText;
                            UpdateSingleSelectPickerValue(controlProps);
                        }
                        else {
                            var newText = $(this).html();
                            UpdateMultiSelectPickerValue(controlProps, newText);
                        }
                    });
                }

                if (!hasMatch) {
                    RemoveTypeAheadChoiceCandidate(controlProps);
                }
            }
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
                           .width($('#' + controlProps.ControlInfo.GenericEntityDivId).width())
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
                            UpdateMultiSelectPickerValueWOValidation(controlProps, newText, index);
                        }
                    });


                }
                    // without cache
                else {
                    RemoveTypeAheadChoiceCandidate(controlProps);

                    var containerDiv = $(document.createElement('div'))
                           .width($('#' + controlProps.ControlInfo.GenericEntityDivId).width())
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

        function GetCachedData(cacheObjID) {
            var data = '';
            if (window._LookupFieldsPropsArray) {
                data = window._LookupFieldsPropsArray[cacheObjID].CachedValue;
            }
            return data;
        }

        function RemoveTypeAheadChoiceCandidate(controlProps) {
            if ($('#' + controlProps.ControlInfo.AutoCompleteDivId).length > 0) {
                $('#' + controlProps.ControlInfo.AutoCompleteDivId).remove();
            }

            controlProps.ControlInfo.CandidateIndex = -1;
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

                            // select new candidates
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
                            $(htmlHolder).wrap('<DIV></DIV').parent().find('SPAN').each(function () {
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

        function UpdateSingleSelectPickerValue(controlProps) {

            $('#' + controlProps.ControlInfo.GenericEntityDivId).html('');
            $('#' + controlProps.ControlInfo.GenericEntityDivId).html(controlProps.ControlInfo.SingleSelectDisplayVal);

            RemoveTypeAheadChoiceCandidate(controlProps);
            ValidateEntity(controlProps.ControlInfo.GenericEntityCheckNameID);

            UpdateChildrenValues(controlProps);
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

                            var lookupDdlId = controlProps.ControlInfo.SourceControlId;
                                                    
                            $('SELECT[id="' + lookupDdlId + '"]').find('option').each(function () {
                                if ($(this).val() == controlProps.ControlInfo.SingleSelectLookupVal) {
                                    $(this).prop('selected', 'selected');
                                }
                                else {
                                    $(this).removeAttr('selected');
                                }
                            });
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
                                        newHiddenCtrlValue = choices[parseInt(c) + 1];
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
                                //$('#' + lookupDdlId).val(controlProps.ControlInfo.SingleSelectLookupVal);
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
                                            if (!($('#' + lookupDdlId).find('option[value=' + entityKey + ']').length > 0)) {
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
                                                $('#' + controlProps.ControlInfo.SourceDropDownID).append(opt);
                                                //$('#' + lookupDdlId).val(controlProps.ControlInfo.SingleSelectLookupVal);
                                            }
                                            else {
                                                $('#' + lookupDdlId).val(entityKey)
                                            }
                                        }
                                    }
                                    else {
                                        $('#' + lookupDdlId).val(0)
                                    }
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
            clean = clean.substring(0, clean.lastIndexOf(';'));
            $('#' + controlProps.ControlInfo.GenericEntityDivId).html(clean);
            $('#' + controlProps.ControlInfo.GenericEntityDivId).append(newTextVal);
            RemoveTypeAheadChoiceCandidate(controlProps);
            ValidateEntity(controlProps.ControlInfo.GenericEntityCheckNameID);
        }


        function RegisterClickOutsideEvent(controlProps) {
            document.onclick = function (event) {
                if (clickedOutsideElement(controlProps.ControlInfo.AutoCompleteDivId, event)) {
                    if (clickedOutsideElement(controlProps.FieldName + '_ddlShowAll', event)) {
                        $('#' + controlProps.ControlInfo.AutoCompleteDivId).css('display', 'none');
                    }
                }
                else {
                    $('#' + controlProps.ControlInfo.AutoCompleteDivId).css('display', '');
                }
            }
        }

        // fires before form save
        //        window.PreSaveAction = function () {
        //            PostDataBackToMultiSelectLookup();

        //            UpdateAllSingleSelectValsBeforeSafe();
        //            PostDataBackToSingleSelectLookup();
        //            return true;
        //        }

        // fires before form save
        window.PreSaveAction = function () {
            var multiOk = PostDataBackToMultiSelectLookup();
            var updateOk = UpdateAllSingleSelectValsBeforeSafe();
            var singleOk = PostDataBackToSingleSelectLookup();

            //CleanPeopleEditorVals();

            if (multiOk && updateOk && singleOk) {
                return true;
            } else {
                return false;
            }
        }

        function ValidateEntity(genericEntityCheckNameID) {
            setTimeout(function () {
                if ($('#' + genericEntityCheckNameID)) {
                    $('#' + genericEntityCheckNameID).trigger('click');
                }
            }, 0);
        }

    }(window.ModifiedDropDown = window.ModifiedDropDown || {}, jQuery));
}
ExecuteOrDelayUntilScriptLoaded(MDInit, "EPMLive.js");