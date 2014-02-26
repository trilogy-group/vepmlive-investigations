/// <reference path="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" />
function GenericToolBar(tagId, cfgs) {

    $(document).click(function (e) {
        if (e.target.parentElement.id != "toolbar-search-icon") {
            $('.toolbar-search').css("margin-left", "0px");
        }

        if (clickedOutsideElementClass('dropdown-menu') && clickedOutsideElementClass('dropdown')) {
            $('.dropdown-menu').css('display', 'none');
        }
    });

    //set properties
    var anchorTagId = tagId;
    var mainActionBar = $(document.createElement('div'));
    mainActionBar.addClass('epmliveToolBar collapse navbar-collapse bs-js-navbar-collapse');
    mainActionBar.attr('border-bottom', "1px solid #eeeeee");

    for (var index in cfgs) {
        var blockContents = cfgs[index];
        if (blockContents["placement"] == "left") {
            BuildLeftBlockHTML(mainActionBar, blockContents);
        }
        else {
            BuildRightBlockHTML(mainActionBar, blockContents);
        }
    }

    $('#' + anchorTagId).append(mainActionBar);

    function BuildLeftBlockHTML(mainActionBar, blockContents) {
        var mainActionBar_LeftUl = $(document.createElement('ul'));
        mainActionBar_LeftUl.addClass('nav navbar-nav');
        var contents = blockContents["content"];
        for (var i in contents) {
            var cfg = contents[i];
            var cType = cfg['controlType'];

            switch (cType) {
                case "button":
                    CreateAndAttachButton(cfg, mainActionBar_LeftUl);
                    break;
                case "toolOptions":
                    CreateAndAttachToolOptions(cfg, mainActionBar_LeftUl);
                    break;
                case "reports":
                    CreateAndAttachReports(cfg, mainActionBar_LeftUl);
                default:
                    break;
            }
        }
        mainActionBar.append(mainActionBar_LeftUl);
    }

    function BuildRightBlockHTML(mainActionBar, blockContents) {
        var mainActionBar_RightUl = $(document.createElement('ul'));
        mainActionBar_RightUl.addClass('nav navbar-nav navbar-right');
        var contents = blockContents["content"];

        CreateAndAttachSearch(mainActionBar_RightUl);
        CreateAndAttachFilter(mainActionBar_RightUl);
        CreateAndAttachDefaultSort(mainActionBar_RightUl);


        for (var i in contents) {
            var cfg = contents[i];
            var cType = cfg['controlType'];

            switch (cType) {
                case "groupByFields":
                    CreateAndAttachGroupBy(cfg, mainActionBar_RightUl);
                    break;
                case "selectColumn":
                    CreateAndConfigureSelectColumn(cfg, mainActionBar_RightUl);
                    break;
                case "viewControl":
                    CreateAndConfigureViewControl(cfg, mainActionBar_RightUl);
                    break;
                default:
                    break;
            }
        }

        mainActionBar.append(mainActionBar_RightUl);
    }

    
    //START LEFT SIDE TOOL BAR METHODS
    function CreateAndAttachButton(cfg, ul) {
        var li = $(document.createElement('li'));

        var iconClass = cfg['iconClass'];
        var buttonText = cfg['buttonText'];

        var aContainer = $(document.createElement('a'));
        aContainer.attr('class', 'dropdown-toggle');
        aContainer.attr('href', 'javascript:void(0)');
        var spnImg = $(document.createElement('span'));
        spnImg.attr('class', iconClass);
        var spnLbl = $(document.createElement('span'));
        spnLbl.text(buttonText);

        aContainer.append(spnImg);
        aContainer.append(spnLbl);

        li.append(aContainer);

        AttachEvents(aContainer, cfg['events']);

        ul.append(li);
    }

    function CreateAndAttachToolOptions(cfg, ul) {
        var li = $(document.createElement('li'));
        var aContainer_Tool = $(document.createElement('a'));
        aContainer_Tool.attr('class', 'dropdown-toggle');
        aContainer_Tool.attr('href', 'javascript:void(0)');
        var spnImg = $(document.createElement('span'));
        spnImg.attr('class', 'icon-tools');
        spnImg.attr('style', 'position: relative;padding-right: 5px;font-size: 0.8em;top: 0px');
        var spnLbl = $(document.createElement('span'));
        spnLbl.text('Tools');
        var spnCaret = $(document.createElement('b'));
        spnCaret.attr('class', 'caret');

        aContainer_Tool.append(spnImg);
        aContainer_Tool.append(spnLbl);
        aContainer_Tool.append(spnCaret);
        aContainer_Tool.bind('click', function () {
            $('.dropdown-menu').css('display', 'none');
            toolUl.toggle();
        });

        li.append(aContainer_Tool);

        var toolUl = $(document.createElement('ul'));
        toolUl.addClass('dropdown-menu');

        for (var i in cfg['sections']) {
            var sect = cfg['sections'][i];
            var sHeading = sect['heading'];
            if (sHeading &&
                (sHeading.toLowerCase() != 'none')) {
                var liHeading = $(document.createElement('li'));
                liHeading.attr('class', 'dropdown-header');
                liHeading.text(sHeading);
                toolUl.append(liHeading);
            }
            var liDivider = $(document.createElement('li'));
            liDivider.attr('class', 'divider');
            toolUl.append(liDivider);

            for (var j in sect['options']) {
                var option = sect['options'][j];
                var liOpt = $(document.createElement('li'));
                var aContainer = $(document.createElement('a'));
                aContainer.attr('href', 'javascript:void(0)');
                var spnImg = $(document.createElement('span'));
                spnImg.attr('class', option['iconClass']);
                var spnLbl = $(document.createElement('span'));
                spnLbl.text(option['text']);
                aContainer.append(spnImg);
                aContainer.append(spnLbl);
                AttachEvents(aContainer, option['events']);
                liOpt.append(aContainer);
                toolUl.append(liOpt);
            }
        }

        li.append(toolUl);

        ul.append(li);
    }

    function CreateAndAttachReports(cfg, ul) {
        var li = $(document.createElement('li'));
        var aContainer_Reports = $(document.createElement('a'));
        aContainer_Reports.attr('class', 'dropdown-toggle');
        aContainer_Reports.attr('href', 'javascript:void(0)');
        var spnImg = $(document.createElement('span'));
        spnImg.attr('class', 'icon-pie-3');
        spnImg.attr('style', 'position: relative;padding-right: 5px;font-size: 0.8em;top: 0px');
        var spnLbl = $(document.createElement('span'));
        spnLbl.text('Reporting');
        var spnCaret = $(document.createElement('b'));
        spnCaret.attr('class', 'caret');

        aContainer_Reports.append(spnImg);
        aContainer_Reports.append(spnLbl);
        aContainer_Reports.append(spnCaret);
        aContainer_Reports.bind('click', function () {
            $('.dropdown-menu').css('display', 'none');
            reportsUl.toggle();
        });

        li.append(aContainer_Reports);

        var reportsUl = $(document.createElement('ul'));
        reportsUl.addClass('dropdown-menu');

        for (var i in cfg['reports']) {
            var rep = cfg['reports'][i];
            var liRep = $(document.createElement('li'));
            var aContainer = $(document.createElement('a'));
            aContainer.attr('href', 'javascript:void(0)');
            var spnImg = $(document.createElement('span'));
            spnImg.attr('class', rep['iconClass']);
            var spnLbl = $(document.createElement('span'));
            spnLbl.text(rep['title']);
            aContainer.append(spnImg);
            aContainer.append(spnLbl);
            AttachEvents(aContainer, rep['events']);
            liRep.append(aContainer);
            reportsUl.append(liRep);
        }

        li.append(reportsUl);

        ul.append(li);
    }
    //END LEFT SIDE TOOL BAR METHODS

    //START RIGHT SIDE TOOL BAR METHODS
    function CreateAndAttachSearch(ul) {
        var li = $(document.createElement('li'));

        var input = $(document.createElement('input'));
        input.attr('class', 'toolbar-search');
        input.attr('type', 'text');
        input.attr('placeholder', 'Search');
        input.attr('style', 'margin-left: 0px;');
        li.append(input);

        var aContainer = $(document.createElement('a'));
        aContainer.attr('id', 'toolbar-search-icon');
        aContainer.attr('class', 'nav-icon');
        aContainer.attr('style', 'font-size:.9em;');
        aContainer.attr('title', 'Standard View');
        aContainer.attr('data-placement', 'top');
        aContainer.attr('href', 'javascript:void(0)');
        var spnImg = $(document.createElement('span'));
        spnImg.attr('class', 'icon-search-3');
        aContainer.append(spnImg);
        li.append(aContainer);

        ul.append(li);
    }
    function CreateAndAttachFilter(ul) {
        var li = $(document.createElement('li'));

        var aContainer = $(document.createElement('a'));
        aContainer.attr('id', 'drop1');
        aContainer.attr('class', 'dropdown-toggle nav-icon');
        aContainer.attr('title', 'Standard View');
        aContainer.attr('data-placement', 'top');
        aContainer.attr('href', 'javascript:void(0)');
        var spnImg = $(document.createElement('span'));
        spnImg.attr('class', 'icon-filter');
        aContainer.append(spnImg);
        li.append(aContainer);

        ul.append(li);
    }

    function CreateAndAttachDefaultSort(ul) {
        var li = $(document.createElement('li'));

        var aContainer = $(document.createElement('a'));
        aContainer.attr('class', 'dropdown-toggle nav-icon');
        aContainer.attr('href', 'javascript:void(0)');
        var spnImg = $(document.createElement('span'));
        spnImg.attr('class', 'icon-sort');
        aContainer.append(spnImg);
        aContainer.bind('click', function () {
            
        });

        li.append(aContainer);
        ul.append(li);
    }

    function CreateAndAttachGroupBy(cfg, ul) {
        var li = $(document.createElement('li'));
        li.attr('class', 'dropdown');

        var aContainer = $(document.createElement('a'));
        aContainer.attr('id', 'group-dropdown');
        aContainer.attr('class', 'dropdown-toggle nav-icon');
        aContainer.attr('title', 'Standard View');
        aContainer.attr('data-placement', 'top');
        aContainer.attr('href', 'javascript:void(0)');
        var spnImg = $(document.createElement('span'));
        spnImg.attr('class', 'icon-list-3');
        aContainer.append(spnImg);
        aContainer.bind('click', function () {
            $('.dropdown-menu').css('display', 'none');
            divContainer.toggle();
        });
        
        li.append(aContainer);

        var divContainer = $(document.createElement('div'));
        divContainer.attr('class', 'dropdown-menu no-close grouping-dropdown-menu');
        var groupbyUl = $(document.createElement('ul'));
        var groupbyLiHeader = $(document.createElement('li'));
        groupbyLiHeader.attr('class', 'dropdown-header');
        groupbyLiHeader.text('Group By');
        var groupbyLiDivider = $(document.createElement('li'));
        groupbyLiDivider.attr('class', 'divider');
        groupbyUl.append(groupbyLiHeader);
        groupbyUl.append(groupbyLiDivider);
        divContainer.append(groupbyUl);

        var divGroupingWrapper = $(document.createElement('div'));
        divGroupingWrapper.attr('class', 'grouping-wrapper');
        
        var sAvailableGrps = cfg['availableGroups'];
        var availableGrps = new Array();
        if (sAvailableGrps) {
            availableGrps = sAvailableGrps.split(',');
        }

        if (availableGrps.length == 0) {
            alert('no choice fields');
            return;
        }

        // foreach grouping field we need to render
        var groups = cfg['groups'];
        for (var i in groups) {
            var group = groups[i];

            var divGroupingRow = $(document.createElement('div'));
            divGroupingRow.attr('class', 'grouping-row');

            var divGroupingNumber = $(document.createElement('div'));
            divGroupingNumber.attr('class', 'grouping-number');
            divGroupingNumber.text(parseInt(i) + 1);

            var divGroupingSelect = $(document.createElement('div'));
            divGroupingSelect.attr('class', 'grouping-select');
            var select = $(document.createElement('select'));
            select.addClass('form-control');
            for (var j in availableGrps) {
                var txt = availableGrps[j].split('|')[0];
                var val = availableGrps[j].split('|')[1];
                select.append('<option value="' + val + '">' + txt + '</option>');
            }
            select.val(group['internalName']);
            divGroupingSelect.append(select);

            var divGroupingDelete = $(document.createElement('div'));
            divGroupingDelete.attr('class', 'grouping-delete');
            var aGroupingDelete = $(document.createElement('a'));
            var spanGroupingDelete = $(document.createElement('span'));
            spanGroupingDelete.attr('class', 'fui-cross icon-dropdown');
            aGroupingDelete.append(spanGroupingDelete);
            aGroupingDelete.bind('click', function () {
                $(this).closest('.grouping-row').remove();
                var num = 1;
                $('.grouping-wrapper').children('.grouping-row').each(function () {
                    $(this).find('.grouping-number').first().text(num++);
                });
                if ($('.grouping-wrapper').children('.grouping-row').length == 0) {
                    $('#aGroupBySave').attr('disabled', 'disabled');
                }
            });
            divGroupingDelete.append(aGroupingDelete);

            divGroupingRow.append(divGroupingNumber);
            divGroupingRow.append(divGroupingSelect);
            divGroupingRow.append(divGroupingDelete);
            divGroupingWrapper.append(divGroupingRow);
        }
        divContainer.append(divGroupingWrapper);

        var divGroupingFooter = $(document.createElement('div'));
        divGroupingFooter.attr('class', 'grouping-footer');
        var ulFooterHeading = $(document.createElement('ul'));
        var liFooterDivider = $(document.createElement('li'));
        liFooterDivider.addClass('divider');
        ulFooterHeading.append(liFooterDivider);
        divGroupingFooter.append(ulFooterHeading);

        var divFooterAdd = $(document.createElement('div'));
        divFooterAdd.addClass('grouping-add');
        var aFooterAdd = $(document.createElement('a'));
        aFooterAdd.attr('href', 'javascript:void(0)');
        aFooterAdd.text('Add Grouping');
        aFooterAdd.bind('click', function () {
            var numRows = $('.grouping-wrapper').children('.grouping-row').length;
            if (numRows < 4) {
                var divGroupingWrapper = $('.grouping-wrapper');

                var divGroupingRow = $(document.createElement('div'));
                divGroupingRow.attr('class', 'grouping-row');

                var divGroupingNumber = $(document.createElement('div'));
                divGroupingNumber.attr('class', 'grouping-number');
                divGroupingNumber.text(numRows + 1);

                var divGroupingSelect = $(document.createElement('div'));
                divGroupingSelect.attr('class', 'grouping-select');
                var select = $(document.createElement('select'));
                select.addClass('form-control');
                for (var j in availableGrps) {
                    var txt = availableGrps[j].split('|')[0];
                    var val = availableGrps[j].split('|')[1];
                    select.append('<option value="' + val + '">' + txt + '</option>');
                }
                select.prop('selectedIndex', 0);
                divGroupingSelect.append(select);

                var divGroupingDelete = $(document.createElement('div'));
                divGroupingDelete.attr('class', 'grouping-delete');
                var aGroupingDelete = $(document.createElement('a'));
                var spanGroupingDelete = $(document.createElement('span'));
                spanGroupingDelete.attr('class', 'fui-cross icon-dropdown');
                aGroupingDelete.append(spanGroupingDelete);
                aGroupingDelete.bind('click', function () {
                    $(this).closest('.grouping-row').remove();
                    var num = 1;
                    $('.grouping-wrapper').children('.grouping-row').each(function () {
                        $(this).find('.grouping-number').first().text(num++);
                    });
                    if ($('.grouping-wrapper').children('.grouping-row').length == 0) {
                        $('#aGroupBySave').attr('disabled', 'disabled');
                    }
                });

                divGroupingDelete.append(aGroupingDelete);

                divGroupingRow.append(divGroupingNumber);
                divGroupingRow.append(divGroupingSelect);
                divGroupingRow.append(divGroupingDelete);
                divGroupingWrapper.append(divGroupingRow);

                $('#aGroupBySave').removeAttr('disabled');
            }
            else {
                alert('too many');
            }
        });
        divFooterAdd.append(aFooterAdd);
        divGroupingFooter.append(divFooterAdd);

        var divFooterSave = $(document.createElement('div'));
        divFooterSave.addClass('grouping-save');
        var aFooterSave = $(document.createElement('a'));
        aFooterSave.attr('id', 'aGroupBySave');
        aFooterSave.attr('href', 'javascript:void(0)');
        aFooterSave.text('Save');
        if (divGroupingWrapper.children('.grouping-row').length != 0) {
            aFooterSave.attr('disabled', 'disabled');
        }
        else {
            aFooterSave.removeAttr('disabled');
        }
        divFooterSave.append(aFooterSave);
        divGroupingFooter.append(divFooterSave);

        divContainer.append(divGroupingFooter);

        li.append(divContainer);
        ul.append(li);
    }
    
    function CreateAndConfigureSelectColumn(cfg, ul) {
        var li = $(document.createElement('li'));
        li.attr('class', 'dropdown');

        var aContainer = $(document.createElement('a'));
        aContainer.attr('class', 'dropdown-toggle nav-icon');
        aContainer.attr('href', 'javascript:void(0)');
        var spnImg = $(document.createElement('span'));
        spnImg.attr('class', 'icon-insert-template');
        aContainer.append(spnImg);
        aContainer.bind('click', function () {
            $('.dropdown-menu').css('display', 'none');
            ulSelectColumns.toggle();
        });

        li.append(aContainer);

        var ulSelectColumns = $(document.createElement('ul'));
        ulSelectColumns.attr('class', 'multiselect-container dropdown-menu');
        ulSelectColumns.attr('style', 'max-height: 400px;overflow-y: auto;overflow-x: hidden;');
        var liSelectAll = $(document.createElement('li'));
        
        var aSelectAllChxBx = $(document.createElement('a'));
        aSelectAllChxBx.attr('href', 'javascript:void(0)');
        aSelectAllChxBx.addClass('multiselect-all');
        var lblSelectAllChxBx = $(document.createElement('label'));
        lblSelectAllChxBx.attr('class', 'checkbox');
        var inputChxBx = $(document.createElement('input'));
        inputChxBx.attr('type', 'checkbox');
        inputChxBx.attr('value', 'multiselect-all');
        inputChxBx.text('Select All');
        aSelectAllChxBx.append(lblSelectAllChxBx);
        aSelectAllChxBx.append(inputChxBx);
        liSelectAll.append(aSelectAllChxBx);
        ulSelectColumns.append(liSelectAll);
        //foreach column we add an element, ulSelectColumns.apend(...)


        li.append(ulSelectColumns);
        ul.append(li);
    }

    function CreateAndConfigureViewControl(cfg, ul) {
        var li = $(document.createElement('li'));
        li.attr('class', 'dropdown');

        var aContainer = $(document.createElement('a'));
        aContainer.attr('class', 'dropdown-toggle');
        aContainer.attr('href', 'javascript:void(0)');
        aContainer.text('Health Summary');
        var bCaret = $(document.createElement('b'));
        bCaret.attr('class', 'caret');
        aContainer.append(bCaret);

        aContainer.bind('click', function () {
            $('.dropdown-menu').css('display', 'none');
            ulViews.toggle();
        });

        li.append(aContainer);

        var ulViews = $(document.createElement('ul'));
        ulViews.attr('class', 'dropdown-menu');

        //foreach column we add an element, ulViews.apend(...)

        var liDivider = $(document.createElement('li'));
        liDivider.addClass('divider');
        ulViews.append(liDivider);

        var liRenameView = $(document.createElement('li'));
        var aRenameView = $(document.createElement('a'));
        aRenameView.attr('href', 'javascript:void(0)');
        var spnRenameImg = $(document.createElement('span'));
        spnRenameImg.addClass('icon-pencil icon-dropdown');
        aRenameView.append(spnRenameImg);
        aRenameView.append('Rename View');
        liRenameView.append(aRenameView);
        ulViews.append(liRenameView);

        var liSaveView = $(document.createElement('li'));
        var aSaveView = $(document.createElement('a'));
        aSaveView.attr('href', 'javascript:void(0)');
        var spnSaveImg = $(document.createElement('span'));
        spnSaveImg.addClass('icon-disk icon-dropdown');
        aSaveView.append(spnSaveImg);
        aSaveView.append('Save View');
        liSaveView.append(aSaveView);
        ulViews.append(liSaveView);

        var liDeleteView = $(document.createElement('li'));
        var aDeleteView = $(document.createElement('a'));
        aDeleteView.attr('href', 'javascript:void(0)');
        var spnDeleteImg = $(document.createElement('span'));
        spnDeleteImg.addClass('fui-cross icon-dropdown');
        aDeleteView.append(spnDeleteImg);
        aDeleteView.append('Delete View');
        liDeleteView.append(aDeleteView);
        ulViews.append(liDeleteView);

        li.append(ulViews);
        ul.append(li);
    }
    //END RIGHT SIDE TOOL BAR METHODS
    
    //START HELPER
    function AttachEvents(element, aEvents) {
        for (var i in aEvents) {
            var evt = aEvents[i];
            element.bind(evt['eventName'], evt['logic']);
        }
    }

    function clickedOutsideElement(elemId, event) {
        var theElem = (window.event) ? getEventTarget(window.event) : event.target;
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

    function clickedOutsideElementClass(sClass, event) {
        var theElem = (window.event) ? getEventTarget(window.event) : event.target;
        while (theElem != null) {
            if ($(theElem).attr('class') != null && $(theElem).attr('class').indexOf(sClass) != -1) {
                return false;
            }
            else {
                theElem = theElem.parentNode;
            }
        }
        return true;
    }

    function getEventTarget(evt) {
        var targ = (evt.target) ? evt.target : evt.srcElement;
        if (targ != null) {
            if (targ.nodeType == 3)
                targ = targ.parentNode;
        }
        return targ;
    }
    //END HELPER
};