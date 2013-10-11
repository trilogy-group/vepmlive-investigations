/// <reference path="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js" />
(function ($$, $) {

    $(function () {
        ExecuteOrDelayUntilScriptLoaded($$.SetModalDialogTitle, 'SP.UI.Dialog.js');
        $$.ManageUI();
        $$.ManageUILogic();
        $$.GetEmptyGalleryPlaceHolderContent();
        $('#tbFreeSearch').css('color', '#999999');
    });

    $$.FreeSearchHandler = {

        InitVals: function (rLnkIDs, pnlID, className, leftDivFilterClass) {
            $$._returnLeftDivLinkIDs = rLnkIDs,
            $$._targetSearchPanelID = pnlID,
            $$._targetTemplateHolderClass = className,
            $$._targetLeftDivFilterClass = leftDivFilterClass
        },

        FilterTemplatesByFreeSearch: function (text) {
            if ($('#btnMoreLessOpt').attr('value') == 'Less Options') {
                $('#btnMoreLessOpt').trigger('click');
            }
            // hide all templates
            var targetCats = $('#' + $$._targetSearchPanelID).find('.' + $$._targetTemplateHolderClass).css('display', 'none');
            // display template by category 
            // var qualifiedCats = targetCats.find('input[id="templateTitle"][value:contains("' + text + '")]').parent().css('display', 'block');
            var qualifiedCats = targetCats.find('input[id="templateTitle"]').filter(function () {
                var match = true;
                if (text.length > 0) {
                    match = this.value.toLowerCase().indexOf(text.toLowerCase()) != -1;
                }
                return match;
            }).parent().css('display', 'block');
            $$.ChangeRightPanelVisibility();
            $$.ClickFirstTemp();
        },

        InitFreeSearchLogic: function () {
            $('#tbFreeSearch').keyup(function () {
                var searchText = $('#tbFreeSearch').val().trim();
                if (searchText) {
                    $('#tbFreeSearch').css('color', 'black');
                }
                else {
                    $('#tbFreeSearch').css('color', '#999999');
                }

                $$.FreeSearchHandler.FilterTemplatesByFreeSearch(searchText);

                //$('.divEPMLiveTempFilters').css('display', 'none');
                $('.' + $$._targetLeftDivFilterClass).css('display', 'none');

                if ($('.divWorkSpaceType')) {
                    $('.divWorkSpaceType').css('display', 'none');
                }

                if ($('.divCreateNewWorkspaceFrom')) {
                    $('.divCreateNewWorkspaceFrom').css('display', 'none');
                }

                $('#divfreeSearchFilter').css('display', '');
                $('.divSearchBox').css('display', '');
                $('#tbFreeSearch').css('display', '');
                $('#lnkBackToAllItems').css('display', '');
                $('#txtFreeSearch').text('Search results for "' + searchText + '"');
                $('#txtFreeSearch').css('display', '');

                return false;
            });
        },

        InitBackToAllItemsLnkLogic: function () {
            $('#lnkBackToAllItems').click(function () {
                $('#divfreeSearchFilter').css('display', 'none');
                $('#txtFreeSearch').css('display', 'none');
                $('#lnkBackToAllItems').css('display', 'none');

                if ($('.divWorkSpaceType')) {
                    $('.divWorkSpaceType').css('display', '');
                }

                if ($('.divCreateNewWorkspaceFrom')) {
                    $('.divCreateNewWorkspaceFrom').css('display', '');
                }

                $('#' + $$._targetSearchPanelID).find('.' + $$._targetTemplateHolderClass).css('display', '');

                $('.' + $$._targetLeftDivFilterClass).css('display', '');

                for (var i in $$._returnLeftDivLinkIDs) {
                    $('#' + $$._returnLeftDivLinkIDs[i]).trigger('click');
                }

                //$('#' + $$._returnLeftDivLinkIDs).trigger('click');

                return false;
            });
        },

        RegisterControlLogic: function () {
            $$.FreeSearchHandler.InitFreeSearchLogic();
            $$.FreeSearchHandler.InitBackToAllItemsLnkLogic();
        }
    };

    $$.SetModalDialogTitle = function () {
        if (newItemName == "workspace" || newItemName == "Workspace") {
            window.SP.UI.UIUtility.setInnerText(parent.document.getElementById("dialogTitleSpan"), 'Create Workspace');
        }
        else if (newItemName == "template" || newItemName == "Template") {
            window.SP.UI.UIUtility.setInnerText(parent.document.getElementById("dialogTitleSpan"), 'Create ' + newItemName);
        }
        else {
            window.SP.UI.UIUtility.setInnerText(parent.document.getElementById("dialogTitleSpan"), 'Create ' + newItemName + ' Workspace');
        }
    };

    $$.ManageUI = function () {
        // manage left div html

        switch (window.newItemNameLwrCs) {
            case "project":
                $('.divWorkSpaceType').css('display', 'block');
                $('#spanWorkspaceTitle').text('Project Name');
                break;
            case "template":
                $('.divWorkSpaceType').css('display', 'none');
                $('.titleCreateNewWorkspaceFrom').html('Browse From:');
                $('#spanWorkspaceTitle').text('Template Name');
                break;
            case "workspace":
                $('.divWorkSpaceType').css('display', 'block');
                $('#spanWorkspaceTitle').text('Workspace Name');
                break;
            default:
                $('.divWorkSpaceType').css('display', 'block');
                $('#spanWorkspaceTitle').text(newItemName + ' name');
                break;
        }

        // manage center div html
        switch (window.newItemNameLwrCs) {
            case "project":
                break;
            case "template":
                break;
            case "workspace":
                break;
            default:
                break;
        }

        // manage right div
        switch (window.newItemNameLwrCs) {
            case "project":
                break;
            case "template":
                break;
            case "workspace":
                break;
            default:
                break;
        }
    }

    $$.ManageUILogic = function () {
        // common logic that can be applied to both modes "create project" and "create template"
        $('input[name="rdoTopLink"]:nth(1)').attr('checked', true);
        $('input[name="perms"]:nth(1)').attr('checked', true);
        if (window.newItemNameLwrCs != 'template') {
            $('input[name="rdoIncludeContent"]:nth(1)').attr('checked', true);
        }
        else {
            $('input[name="rdoIncludeContent"]:nth(0)').attr('checked', true);
        }

        // load exiting workspace grid with XML 
        $$.LoadGridWithXML();

        $('#hdnParentWebUrl').val(window.parentWebUrl);
        $('#hdnTemplateType').val('All Types');
        $('#hdnTemplateCategory').val('All Categories');

        $('#aMoreInfo')
        .click(function () {
            $$.SwitchToMoreInfo();
            return false;
        })
        .hover(
            function () {
                $(this).addClass('hoverLink');
            },
            function () {
                $(this).removeClass('hoverLink');
            }
        ).removeAttr('Target');

        $('#tbNewWorkSpaceName').blur(function () {
            if ($$.IsAlphaNumeric($(this).val())) {
                $('#hdnSiteName').val($(this).val());
            }

            if ($$.IsAlphaNumeric($('#' + urlBoxId).val())) {
                $('#hdnSiteUrl').val($('#' + urlBoxId).val());
            }
        });

        $('#' + urlBoxId).blur(function () {
            if ($$.IsAlphaNumeric($(this).val())) {
                $('#hdnSiteUrl').val($(this).val());
            }

            if ($$.IsAlphaNumeric($('#tbNewWorkSpaceName').val())) {
                $('#hdnSiteName').val($('#tbNewWorkSpaceName').val());
            }
        });

        $('#tbNewWorkSpaceName').bind('paste', function (e) {
            window.setTimeout(function () {
                if ($('#' + urlBoxId).val().length == 0 ||
                    $('#hdnSiteUrl').val().length == 0 ||
                    $('#hdnSiteName').val() == $('#hdnSiteUrl').val()) {

                    $('#' + urlBoxId).val($('#tbNewWorkSpaceName').val());
                }

                $('#hdnSiteUrl').val($('#' + urlBoxId).val());
                $('#hdnSiteName').val($('#tbNewWorkSpaceName').val());

            }, 0);
        });

        $('#' + urlBoxId).bind('paste', function (e) {
            window.setTimeout(function () {
                if ($('#tbNewWorkSpaceName').val().length == 0 ||
                    $('#hdnSiteName').val().length == 0 ||
                    $('#hdnSiteUrl').val() == $('#hdnSiteName').val()) {

                    $('#tbNewWorkSpaceName').val($('#' + urlBoxId).val());
                }

                $('#hdnSiteUrl').val($('#' + urlBoxId).val());
                $('#hdnSiteName').val($('#tbNewWorkSpaceName').val());
            }, 0);
        });

        $('#tbNewWorkSpaceName').keydown(function (e) {
            var canCopy = false;
            if ($('#hdnSiteUrl').val() == $('#hdnSiteName').val()) {
                if (e.keyCode >= 65 && e.keyCode <= 90) {
                    canCopy = true;
                }
                else if (e.keyCode != 16 && e.keyCode != 17 && !e.shiftKey &&
                         e.keyCode >= 96 && e.keyCode <= 105) {
                    canCopy = true;
                }
                else if (e.keyCode != 16 && e.keyCode != 17 && !e.shiftKey &&
                         e.keyCode >= 48 && e.keyCode <= 57) {
                    canCopy = true;
                }
                else if (e.keyCode == 32) {
                    canCopy = true;
                }
                else if (e.keyCode == 8) {
                    canCopy = true;
                }
                else if (e.keyCode == 189 && e.shiftKey) {
                    canCopy = true;
                }

                if (canCopy) {
                    $('#hdnSiteUrl').val($(this).val());
                    $('#hdnSiteName').val($(this).val());
                }
            }
        });

        $('#' + urlBoxId).keydown(function (e) {
            var canCopy = false;
            if (e.keyCode >= 65 && e.keyCode <= 90) {
                canCopy = true;
            }
            else if (e.keyCode != 16 && e.keyCode != 17 && !e.shiftKey &&
                         e.keyCode >= 96 && e.keyCode <= 105) {
                canCopy = true;
            }
            else if (e.keyCode != 16 && e.keyCode != 17 && !e.shiftKey &&
                         e.keyCode >= 48 && e.keyCode <= 57) {
                canCopy = true;
            }
            else if (e.keyCode == 189 && e.shiftKey) {
                canCopy = true;
            }
            else if (e.keyCode == 8) {
                canCopy = true;
            }

            if (canCopy) {
                $('#hdnSiteUrl').val($(this).val());
                $('#hdnSiteName').val($(this).val());
            }
            else {
                return false;
            }
        });

        $('#tbNewWorkSpaceName').keyup(function (e) {
            if ($('#hdnSiteUrl').val() == $('#hdnSiteName').val()) {
                // detect alpha
                if (e.keyCode >= 65 && e.keyCode <= 90) {
                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#' + urlBoxId).val($('#hdnSiteUrl').val());
                }
                // detect numpad #
                else if (e.keyCode != 16 && e.keyCode != 17 && !e.shiftKey &&
                         e.keyCode >= 96 && e.keyCode <= 105) {
                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#' + urlBoxId).val($('#hdnSiteUrl').val());
                }
                // detect regular #
                else if (e.keyCode != 16 && e.keyCode != 17 && !e.shiftKey &&
                         e.keyCode >= 48 && e.keyCode <= 57) {

                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#' + urlBoxId).val($('#hdnSiteUrl').val());

                }
                // detect spacebar
                else if (e.keyCode == 32) {
                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#' + urlBoxId).val($('#hdnSiteUrl').val());
                }
                // detect underscore
                else if (e.keyCode == 189 && e.shiftKey) {
                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#' + urlBoxId).val($('#hdnSiteUrl').val());
                }
                // detect delete
                else if (e.keyCode == 8) {
                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#' + urlBoxId).val($('#hdnSiteUrl').val());
                }
            }
        });

        $('#' + urlBoxId).keyup(function (e) {
            if ($('#hdnSiteUrl').val() == $('#hdnSiteName').val()) {
                // detect alpha
                if (e.keyCode >= 65 && e.keyCode <= 90) {
                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#tbNewWorkSpaceName').val($('#hdnSiteName').val());
                }
                // detect numpad #
                else if (e.keyCode != 16 && e.keyCode != 17 && !e.shiftKey &&
                         e.keyCode >= 96 && e.keyCode <= 105) {
                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#tbNewWorkSpaceName').val($('#hdnSiteName').val());
                }
                // detect regular #
                else if (e.keyCode != 16 && e.keyCode != 17 && !e.shiftKey &&
                         e.keyCode >= 48 && e.keyCode <= 57) {

                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#tbNewWorkSpaceName').val($('#hdnSiteName').val());

                }
                // detect spacebar
                else if (e.keyCode == 32) {
                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#tbNewWorkSpaceName').val($('#hdnSiteName').val());
                }
                // detect underscore
                else if (e.keyCode == 189 && e.shiftKey) {
                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#tbNewWorkSpaceName').val($('#hdnSiteName').val());
                }
                // detect delete
                else if (e.keyCode == 8) {
                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#tbNewWorkSpaceName').val($('#hdnSiteName').val());
                }
            }
        });


        $$.getSelText = function () {
            var txt = '';
            if (window.getSelection) {
                txt = window.getSelection();
            }
            else if (document.getSelection) {
                txt = document.getSelection();
            }
            else if (document.selection) {
                txt = document.selection.createRange().text;
            }

            return txt;
        }

        $$.ManageMoreOptionBtnLogic();
        $$.ManageCreateBtnLogic();
        $$.HookupLinkHoverLogic();

        $('#lnkChangeUrlPopup').click(function () {
            var options = {
                url: smallParentUrl,
                title: 'Select parent site',
                allowMaximize: false,
                showClose: false,
                width: 500,
                height: 320,
                dialogReturnValueCallback: Function.createDelegate(null, $$.HandleChangeParentUrlReturn)
            };

            SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
        });

        if (window.defaultCreateNew == 'online' || window.newItemNameLwrCs == 'template') {
            $$.GetOnlineTemps();
        }

        $$.GetTempsFromTempGal();

        // implement mode specific logic
        switch (window.newItemNameLwrCs) {
            case "project":
                break;
            case "template":
                $$.GetTempsFromSolGal();
                break;
            case "workspace":
                break;
            default:
                break;
        }
    }

    $$.GetEmptyGalleryPlaceHolderContent = function () {
        var xmlhttp = false;
        if (navigator.appName == 'Microsoft Internet Explorer') {
            xmlhttp = new ActiveXObject('Microsoft.XMLHTTP');
        }
        else {
            xmlhttp = new XMLHttpRequest();
        }

        xmlhttp.open("GET", "/_layouts/epmlive/EmptyGalleryPlaceHolder.html", true);
        xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState == 4) {
                if (xmlhttp.status == 200) {
                    try {
                        var response = xmlhttp.responseText;
                        $('#divEmptyGalleryHTML').html(response);
                        if ($('#linkSettings').length > 0) {
                            $('#linkSettings').attr('href', currentWebUrl + "/_layouts/epmlive/setup.aspx");
                            $('#linkSettings').css('text-decoration', 'underline');
                        }
                    } catch (e) {
                        window.alert(e.Message);
                    }
                }
            }
        };
        xmlhttp.send(null);
    }

    $$.SetCreateDefault = function () {

        switch (window.defaultCreateNew) {
            case "online":
                $('#lnkOnlineTemps').trigger('click');
                break;
            case "local":
                $('#lnkInstalledTemps').trigger('click');
                break;
            case "existing":
                $('#lnkFromExistingWorkspace').trigger('click');
                break;
        }
    }

    $$.ManageCreateBtnLogic = function () {
        switch (window.newItemNameLwrCs) {
            case "project":
                $('#btnCreate').click(function () {
                    if ($$.IsEmpty($('#tbNewWorkSpaceName').val())) {
                        window.alert('Project name cannot be empty.');
                        return false;
                    }

                    if (!$$.IsAlphaNumeric($('#tbNewWorkSpaceName').val())) {
                        $('#' + moreInfoUrlClientId).val('');
                        window.alert('Project name cannot contain non-alphanumeric characters.');
                        return false;
                    }

                    if ($$.IsEmpty($('#' + urlBoxId).val())) {
                        window.alert('Site url cannot be empty.');
                        return false;
                    }

                    if (!$$.IsAlphaNumeric($('#' + urlBoxId).val())) {
                        $('#' + moreInfoUrlClientId).val('');
                        window.alert('Site url cannot contain non-alphanumeric characters.');
                        return false;
                    }

                    if ($('#linkExistingWorkspace').hasClass('selectedLink') && $('#hdnParentWebUrl').val().length == 0) {
                        window.alert('You must select a workspace');
                        return false;
                    }

                    if ($('#linkExistingWorkspace').hasClass('selectedLink') && $('#hdnParentWebUrl').val() == currentWebRelativeUrl) {
                        window.alert('You cannot create a project on the selected workspace');
                        return false;
                    }

                    var createFrom = $('.ulCreateNewWorkspaceFrom .selectedLink').attr('id');
                    if ($('input[name="rdoIncludeContent"]:nth(0)').length != 0) {
                        window.includeContent = $('input[name="rdoIncludeContent"]:nth(0)')[0].checked;
                    }
                    else {
                        window.includeContent = true;
                    }
                    // hide whole page
                    $('#OuterContainer').css('display', 'none');
                    $('body').css('cursor', 'wait');

                    // change loading text
                    $('#spanMainLoading').html('Creating project...');
                    //$('#spanTxtProjName').text($('#tbNewWorkSpaceName').val().trim() + ' workspace');

                    // display loading icon
                    $('#divLoad_CreateWorkspace').css('display', 'block');
                    $('#div_loading_msg').css('display', 'block');

                    try {
                        if ($('#' + urlBoxId).val().length == 0) {
                            $('#' + urlBoxId).val($('#tbNewWorkSpaceName').val());
                        }
                        if ($('#tbNewWorkSpaceName').val().length == 0) {
                            $('#tbNewWorkSpaceName').val($('#' + urlBoxId).val());
                        }

                        $$.CreateWorkspace();
                    }
                    catch (e) {
                        window.alert(e);
                        $('#OuterContainer').css('display', 'block');
                        $('body').css('cursor', 'auto');
                        $('#linkNewWorkspace').trigger('click');

                        switch (window.createFrom) {
                            case 'lnkOnlineTemps':
                                $('#lnkOnlineTemps').trigger('click');
                                break;
                            case 'lnkInstalledTemps':
                                $('#lnkInstalledTemps').trigger('click');
                                break;
                            case 'lnkFromExistingWorkspace':
                                $('#lnkFromExistingWorkspace').trigger('click');
                                break;
                        }
                        $$.ChangeRightPanelVisibility();
                    }

                    return false;
                });
                break;
            case "template":
                $('#btnCreate').click(function () {
                    if ($$.IsEmpty($('#tbNewWorkSpaceName').val())) {
                        window.alert('Template name cannot be empty.');
                        return false;
                    }

                    if (!$$.IsAlphaNumeric($('#tbNewWorkSpaceName').val())) {
                        $('#' + moreInfoUrlClientId).val('');
                        window.alert('Template name cannot contain non-alphanumeric characters.');
                        return false;
                    }

                    if ($$.IsEmpty($('#' + urlBoxId).val())) {
                        window.alert('Site url cannot be empty.');
                        return false;
                    }

                    if (!$$.IsAlphaNumeric($('#' + urlBoxId).val())) {
                        $('#' + moreInfoUrlClientId).val('');
                        window.alert('Site url cannot contain non-alphanumeric characters.');
                        return false;
                    }

                    if ($('#linkExistingWorkspace').hasClass('selectedLink') && $('#hdnParentWebUrl').val().length == 0) {
                        window.alert('You must select a workspace');
                        return false;
                    }

                    //                if ($('#linkExistingWorkspace').hasClass('selectedLink') && $('#hdnParentWebUrl').val() == currentWebRelativeUrl) {
                    //                    alert('You cannot create a template on the selected workspace');
                    //                    return false;
                    //                }

                    var createFrom = $('.ulCreateNewWorkspaceFrom .selectedLink').attr('id');
                    if ($('input[name="rdoIncludeContent"]:nth(0)').length != 0) {
                        window.includeContent = $('input[name="rdoIncludeContent"]:nth(0)')[0].checked;
                    }
                    else {
                        window.includeContent = true;
                    }

                    // hide whole page
                    $('#OuterContainer').css('display', 'none');
                    $('body').css('cursor', 'wait');
                    // change loading text
                    $('#spanMainLoading').html('Creating template...');
                    //$('#spanTxtProjName').text($('#tbNewWorkSpaceName').val().trim() + ' template');

                    // display loading icon
                    $('#divLoad_CreateWorkspace').css('display', 'block');
                    $('#div_loading_msg').css('display', 'block');

                    try {
                        $$.CreateTemplate();
                    }
                    catch (e) {
                        window.alert(e);
                        $('#OuterContainer').css('display', 'block');
                        $('body').css('cursor', 'auto');
                        $('#linkNewWorkspace').trigger('click');

                        switch (createFrom) {
                            case 'onlineGal':
                                $('#lnkNewTempFrmOnline').trigger('click');
                                break;
                            case 'localGal':
                                $('#lnkNewTempFrmLocal').trigger('click');
                                break;
                            case 'solutionGal':
                                $('#lnkNewTempFrmSolGal').trigger('click');
                                break;
                            case 'existingWorkspace':
                                $('#lnkNewTempFrmExisting').trigger('click');
                                break;
                        }
                        $$.ChangeRightPanelVisibility();
                    }

                    return false;
                });
                break;
            case "workspace":
                $('#btnCreate').click(function () {
                    if ($$.IsEmpty($('#tbNewWorkSpaceName').val())) {
                        window.alert('Workspace name cannot be empty.');
                        return false;
                    }

                    if (!$$.IsAlphaNumeric($('#tbNewWorkSpaceName').val())) {
                        $('#' + moreInfoUrlClientId).val('');
                        window.alert('Workspace name cannot contain non-alphanumeric characters.');

                        return false;
                    }

                    if ($$.IsEmpty($('#' + urlBoxId).val())) {
                        window.alert('Workspace url cannot be empty.');
                        return false;
                    }

                    if (!$$.IsAlphaNumeric($('#' + urlBoxId).val())) {
                        $('#' + moreInfoUrlClientId).val('');
                        window.alert('Site url cannot contain non-alphanumeric characters.');

                        return false;
                    }

                    if ($('#linkExistingWorkspace').hasClass('selectedLink') && $('#hdnParentWebUrl').val().length == 0) {
                        window.alert('You must select a workspace');
                        return false;
                    }

                    if ($('#linkExistingWorkspace').hasClass('selectedLink') && $('#hdnParentWebUrl').val() == currentWebRelativeUrl) {
                        window.alert('You cannot create a project on the selected workspace');
                        return false;
                    }

                    var createFrom = $('.ulCreateNewWorkspaceFrom .selectedLink').attr('id');
                    if ($('input[name="rdoIncludeContent"]:nth(0)').length != 0) {
                        window.includeContent = $('input[name="rdoIncludeContent"]:nth(0)')[0].checked;
                    }
                    else {
                        window.includeContent = true;
                    }

                    // hide whole page
                    $('#OuterContainer').css('display', 'none');
                    $('body').css('cursor', 'wait');
                    // change loading text
                    $('#spanMainLoading').html('Creating workspace...');
                    //$('#spanTxtProjName').text($('#tbNewWorkSpaceName').val().trim() + ' workspace');

                    // display loading icon
                    $('#divLoad_CreateWorkspace').css('display', 'block');
                    $('#div_loading_msg').css('display', 'block');

                    try {
                        $$.CreateWorkspace();
                    }
                    catch (e) {
                        window.alert(e);
                        $('#OuterContainer').css('display', 'block');
                        $('body').css('cursor', 'auto');
                        $('#linkNewWorkspace').trigger('click');

                        switch (createFrom) {
                            case 'lnkOnlineTemps':
                                $('#lnkOnlineTemps').trigger('click');
                                break;
                            case 'lnkInstalledTemps':
                                $('#lnkInstalledTemps').trigger('click');
                                break;
                            case 'lnkFromExistingWorkspace':
                                $('#lnkFromExistingWorkspace').trigger('click');
                                break;
                        }
                        $$.ChangeRightPanelVisibility();
                    }

                    return false;
                });
                break;
            default:
                $('#btnCreate').click(function () {
                    if ($$.IsEmpty($('#tbNewWorkSpaceName').val())) {
                        window.alert(newItemName + ' name cannot be empty.');
                        return false;
                    }

                    if (!$$.IsAlphaNumeric($('#tbNewWorkSpaceName').val())) {
                        $('#' + moreInfoUrlClientId).val('');
                        window.alert(newItemName + ' name cannot contain non-alphanumeric characters.');

                        return false;
                    }

                    if ($$.IsEmpty($('#' + urlBoxId).val())) {
                        window.alert('Site url cannot be empty.');
                        return false;
                    }

                    if (!$$.IsAlphaNumeric($('#' + urlBoxId).val())) {
                        $('#' + moreInfoUrlClientId).val('');
                        window.alert('Site url cannot contain non-alphanumeric characters.');

                        return false;
                    }

                    if ($('#linkExistingWorkspace').hasClass('selectedLink') && $('#hdnParentWebUrl').val().length == 0) {
                        window.alert('You must select a workspace');
                        return false;
                    }

                    if ($('#linkExistingWorkspace').hasClass('selectedLink') && $('#hdnParentWebUrl').val() == currentWebRelativeUrl) {
                        window.alert('You cannot create a project on the selected workspace');
                        return false;
                    }

                    var createFrom = $('.ulCreateNewWorkspaceFrom .selectedLink').attr('id');

                    if ($('input[name="rdoIncludeContent"]:nth(0)').length != 0) {
                        window.includeContent = $('input[name="rdoIncludeContent"]:nth(0)')[0].checked;
                    }
                    else {
                        window.includeContent = true;
                    }

                    // hide whole page
                    $('#OuterContainer').css('display', 'none');
                    $('body').css('cursor', 'wait');

                    // change loading text
                    $('#spanMainLoading').html('Creating ' + newItemName + '...');
                    //$('#spanTxtProjName').text($('#tbNewWorkSpaceName').val().trim() + ' workspace');

                    // display loading icon
                    $('#divLoad_CreateWorkspace').css('display', 'block');
                    $('#div_loading_msg').css('display', 'block');
                    try {
                        $$.CreateWorkspace();
                    }
                    catch (e) {
                        window.alert(e);
                        $('#OuterContainer').css('display', 'block');
                        $('body').css('cursor', 'auto');
                        $('#linkNewWorkspace').trigger('click');

                        switch (createFrom) {
                            case 'lnkOnlineTemps':
                                $('#lnkOnlineTemps').trigger('click');
                                break;
                            case 'lnkInstalledTemps':
                                $('#lnkInstalledTemps').trigger('click');
                                break;
                            case 'lnkFromExistingWorkspace':
                                $('#lnkFromExistingWorkspace').trigger('click');
                                break;
                        }
                        $$.ChangeRightPanelVisibility();
                    }

                    return false;
                });

                break;
        }
    }

    $$.ManageMoreOptionBtnLogic = function () {
        switch (window.newItemNameLwrCs) {
            case "project":
                $('#btnMoreLessOpt').click(function () {

                    if ($(this).attr('value') == 'More Options') {
                        $(this).attr('value', 'Less Options');

                        $$.RemoveScrollbar();
                        $$.SwitchToMoreOpt();
                    }
                    else {
                        $(this).attr('value', 'More Options');
                        $('.txtAvailableTemplates').css('display', '');

                        if ($('#linkNewWorkspace').hasClass('selectedLink') &&
                            $('#lnkOnlineTemps').hasClass('selectedLink')) {

                            $$.RemoveScrollbar();
                            $('#divSolGalTempsHolder').css('display', 'none');
                            $('#divOnlineTempsHolder').css('display', 'block');
                            $('#divOnlineTempsHolder').parent('.slimScrollDiv').css('display', '');
                            $('#divTemplatesHolder').css('display', 'none');
                            $('#divMoreOptContainer').css('display', 'none');
                            $('#divMoreInfoContainer').css('display', 'none');
                            $('#divExistingWorkspaceContainer').css('display', 'none');

                            $('.divFilters').css('display', 'none');
                            $('.divEPMLiveTempFilters').css('display', 'none');
                            //$('#lnkOnlineTemps').trigger('click');
                        }
                        else if ($('#linkNewWorkspace').hasClass('selectedLink') &&
                                 $('#lnkInstalledTemps').hasClass('selectedLink')) {

                            $$.RemoveScrollbar();
                            $('#divSolGalTempsHolder').css('display', 'none');
                            $('#divOnlineTempsHolder').css('display', 'none');
                            $('#divTemplatesHolder').css('display', 'block');
                            $('#divTemplatesHolder').parent('.slimScrollDiv').css('display', '');
                            $('#divMoreOptContainer').css('display', 'none');
                            $('#divMoreInfoContainer').css('display', 'none');
                            $('#divExistingWorkspaceContainer').css('display', 'none');

                            $('.divFilters').css('display', 'none');
                            $('.divFilterBy').css('display', 'none');
                            //$('#lnkInstalledTemps').trigger('click');
                        }
                        else if ($('#linkNewWorkspace').hasClass('selectedLink') &&
                                 $('#lnkFromExistingWorkspace').hasClass('selectedLink')) {

                            $('#linkNewWorkspace').trigger('click');
                            $('#lnkFromExistingWorkspace').trigger('click');
                        }
                    }
                    return false;
                });
                break;
            case "template":
                $('#btnMoreLessOpt').click(function () {
                    if ($(this).attr('value') == 'More Options') {
                        $(this).attr('value', 'Less Options');

                        $$.RemoveScrollbar();
                        $$.SwitchToMoreOpt();
                    }
                    else {
                        $(this).attr('value', 'More Options');
                        $('.txtAvailableTemplates').css('display', '');

                        if ($('#lnkNewTempFrmOnline').hasClass('selectedLink')) {

                            $$.RemoveScrollbar();
                            $('#divSolGalTempsHolder').css('display', 'none');
                            $('#divOnlineTempsHolder').css('display', 'block');
                            $('#divOnlineTempsHolder').parent('.slimScrollDiv').css('display', '');
                            $('#divTemplatesHolder').css('display', 'none');
                            $('#divMoreOptContainer').css('display', 'none');
                            $('#divMoreInfoContainer').css('display', 'none');
                            $('#divExistingWorkspaceContainer').css('display', 'none');

                            $('.divFilters').css('display', 'none');
                            $('.divEPMLiveTempFilters').css('display', 'none');
                            //$('#lnkNewTempFrmOnline').trigger('click');
                        }
                        else if ($('#lnkNewTempFrmLocal').hasClass('selectedLink')) {

                            $$.RemoveScrollbar();
                            $('#divSolGalTempsHolder').css('display', 'none');
                            $('#divOnlineTempsHolder').css('display', 'none');
                            $('#divTemplatesHolder').css('display', 'block');
                            $('#divTemplatesHolder').parent('.slimScrollDiv').css('display', '');
                            $('#divMoreOptContainer').css('display', 'none');
                            $('#divMoreInfoContainer').css('display', 'none');
                            $('#divExistingWorkspaceContainer').css('display', 'none');

                            $('.divFilters').css('display', 'none');
                            $('.divFilterBy').css('display', 'none');

                            //$('#lnkNewTempFrmLocal').trigger('click');
                        }
                        else if ($('#lnkNewTempFrmSolGal').hasClass('selectedLink')) {

                            $$.RemoveScrollbar();
                            $('#divSolGalTempsHolder').css('display', 'block');
                            $('#divSolGalTempsHolder').parent('.slimScrollDiv').css('display', '');
                            $('#divOnlineTempsHolder').css('display', 'none');
                            $('#divTemplatesHolder').css('display', 'none');
                            $('#divMoreOptContainer').css('display', 'none');
                            $('#divMoreInfoContainer').css('display', 'none');
                            $('#divExistingWorkspaceContainer').css('display', 'none');

                            $('.divFilters').css('display', 'none');
                            $('.divSolGalFilters').css('display', 'none');

                            //$('#lnkNewTempFrmSolGal').trigger('click');
                        }
                        else if ($('#lnkNewTempFrmExisting').hasClass('selectedLink')) {
                            $('#lnkNewTempFrmExisting').trigger('click');
                        }
                    }
                    return false;
                });
                break;
            case "workspace":
                $('#btnMoreLessOpt').click(function () {
                    if ($(this).attr('value') == 'More Options') {
                        $(this).attr('value', 'Less Options');
                        $$.RemoveScrollbar();
                        $$.SwitchToMoreOpt();
                    }
                    else {
                        $(this).attr('value', 'More Options');
                        $('.txtAvailableTemplates').css('display', '');

                        if ($('#linkNewWorkspace').hasClass('selectedLink') &&
                $('#lnkOnlineTemps').hasClass('selectedLink')) {

                            $$.RemoveScrollbar();
                            $('#divSolGalTempsHolder').css('display', 'none');
                            $('#divOnlineTempsHolder').css('display', 'block');
                            $('#divOnlineTempsHolder').parent('.slimScrollDiv').css('display', '');
                            $('#divTemplatesHolder').css('display', 'none');
                            $('#divMoreOptContainer').css('display', 'none');
                            $('#divMoreInfoContainer').css('display', 'none');
                            $('#divExistingWorkspaceContainer').css('display', 'none');

                            $('.divFilters').css('display', 'none');
                            $('.divEPMLiveTempFilters').css('display', 'none');
                            //$('#lnkOnlineTemps').trigger('click');
                        }
                        else if ($('#linkNewWorkspace').hasClass('selectedLink') &&
                $('#lnkInstalledTemps').hasClass('selectedLink')) {

                            $$.RemoveScrollbar();
                            $('#divSolGalTempsHolder').css('display', 'none');
                            $('#divOnlineTempsHolder').css('display', 'none');
                            $('#divTemplatesHolder').css('display', 'block');
                            $('#divTemplatesHolder').parent('.slimScrollDiv').css('display', '');
                            $('#divMoreOptContainer').css('display', 'none');
                            $('#divMoreInfoContainer').css('display', 'none');
                            $('#divExistingWorkspaceContainer').css('display', 'none');

                            $('.divFilters').css('display', 'none');
                            $('.divFilterBy').css('display', 'none');

                            //$('#lnkInstalledTemps').trigger('click');
                        }
                        else if ($('#linkNewWorkspace').hasClass('selectedLink') &&
                $('#lnkFromExistingWorkspace').hasClass('selectedLink')) {

                            $('#linkNewWorkspace').trigger('click');
                            $('#lnkFromExistingWorkspace').trigger('click');
                        }
                    }
                    return false;
                });
                break;
            default:
                $('#btnMoreLessOpt').click(function () {
                    if ($(this).attr('value') == 'More Options') {
                        $(this).attr('value', 'Less Options');

                        $$.RemoveScrollbar();
                        $$.SwitchToMoreOpt();
                    }
                    else {
                        $(this).attr('value', 'More Options');

                        if ($('#linkNewWorkspace').hasClass('selectedLink') &&
                $('#lnkOnlineTemps').hasClass('selectedLink')) {

                            $$.RemoveScrollbar();
                            $('#divSolGalTempsHolder').css('display', 'none');
                            $('#divOnlineTempsHolder').css('display', 'block');
                            $('#divOnlineTempsHolder').parent('.slimScrollDiv').css('display', '');
                            $('#divTemplatesHolder').css('display', 'none');
                            $('#divMoreOptContainer').css('display', 'none');
                            $('#divMoreInfoContainer').css('display', 'none');
                            $('#divExistingWorkspaceContainer').css('display', 'none');

                            $('.divFilters').css('display', 'none');
                            $('.divEPMLiveTempFilters').css('display', 'none');

                            //$('#lnkOnlineTemps').trigger('click');
                        }
                        else if ($('#linkNewWorkspace').hasClass('selectedLink') &&
                $('#lnkInstalledTemps').hasClass('selectedLink')) {

                            $$.RemoveScrollbar();
                            $('#divSolGalTempsHolder').css('display', 'none');
                            $('#divOnlineTempsHolder').css('display', 'none');
                            $('#divTemplatesHolder').css('display', 'block');
                            $('#divTemplatesHolder').parent('.slimScrollDiv').css('display', '');
                            $('#divMoreOptContainer').css('display', 'none');
                            $('#divMoreInfoContainer').css('display', 'none');
                            $('#divExistingWorkspaceContainer').css('display', 'none');

                            $('.divFilters').css('display', 'none');
                            $('.divFilterBy').css('display', 'none');

                            //$('#lnkInstalledTemps').trigger('click');
                        }
                        else if ($('#linkNewWorkspace').hasClass('selectedLink') &&
                $('#lnkFromExistingWorkspace').hasClass('selectedLink')) {

                            $('#linkNewWorkspace').trigger('click');
                            $('#lnkFromExistingWorkspace').trigger('click');
                        }
                    }
                    return false;
                });
                break;
        }
    }

    $$.grdExistingWorkSpace = null;
    $$.grdChangeParentUrl = null;

    $$.HookupLinkHoverLogic = function () {
        $('.sameColorLink').hover(function () {
            $(this).addClass('hoverLink');
        },
        function () {
            $(this).removeClass('hoverLink');
        });
    };

    $$.HandleChangeParentUrlReturn = function (result, value) {
        if (result == '1') {
            $('#spanParentSiteUrl').text(value);
            $('#hdnParentWebUrl').val(value);
        }
    };

    $$.LoadGridWithXML = function () {
        window.grdExistingWorkSpace.loadXML("getworkspacexml.aspx?sitecreate=1");
        //grdAlternateParentSites.loadXML("getworkspacexml.aspx");
        //grdChangeParentUrl.loadXML("getworkspacexml.aspx");
    };

    $$.IsAlphaNumeric = function (testStr) {
        var re = /^[a-zA-Z0-9\s]+$/;
        return re.test(testStr);
    };

    $$.IsEmpty = function (testStr) {
        if (!$.trim(testStr).length) {
            return true;
        }
        else {
            return false;
        }
    };

    // plugin to get query string parameters
    $.QueryString = (function (a) {
        if (a == "") return {};
        var b = {};
        for (var i = 0; i < a.length; ++i) {
            var p = a[i].split('=');
            b[p[0]] = decodeURIComponent(p[1].replace(/\+/g, " "));
        }
        return b;
    })(window.location.search.substr(1).split('&'))

    $$.CreateWorkspace = function () {

        var xmlhttp = false;
        if (navigator.appName == 'Microsoft Internet Explorer') {
            xmlhttp = new ActiveXObject('Microsoft.XMLHTTP');
        }
        else {
            xmlhttp = new XMLHttpRequest();
        }

        var result;
        var inheritTopLink;
        var uniquePermission;
        var isNew = $('#hdnIsNewWorkSpace').val();
        var createNewFrom = $('#hdnCreateNewFrom').val();
        var siteTitle = $('#tbNewWorkSpaceName').val().trim();
        var siteUrl = $('#' + urlBoxId).val().trim().replace(/[^a-zA-Z 0-9]+/g, '');
        siteUrl = siteUrl.replace(/\s/g, '');
        var templateId = $('#hdnTemplateId').val();
        var parentWebUrl = $('#hdnParentWebUrl').val();

        if (parentWebUrl == '' || parentWebUrl.length == 0) {
            parentWebUrl = currentWebRelativeUrl;
        }

        if (nav.length > 0) {
            if (nav == "True") {
                inheritTopLink = true;
            }
            else if (nav == "False") {
                inheritTopLink = false;
            }
        }
        else {

            if ($('input[name="rdoTopLink"]:nth(0)').length != 0) {
                inheritTopLink = $('input[name="rdoTopLink"]:nth(0)')[0].checked;
            }
            else {
                inheritTopLink = false;
            }
        }

        if (perms.length > 0) {
            if (perms == "Unique") {
                uniquePermission = true;
            }
            else if (perms == "Same") {
                uniquePermission = false;
            }
        }
        else {
            if ($('input[name="perms"]:nth(1)').length != 0) {
                uniquePermission = $('input[name="perms"]:nth(1)').attr('checked');
            }
            else {
                uniquePermission = true;
            }
        }

        // We should have param data formatted like below
        // fields will vary depending on the type of workspace
        // from online, installed, or existing
        // ====================================================
        //    <![CDATA[<Data>
        //    <Param key="IsNew"></Param>
        //    <Param key="IsTemplate">False</Param>
        //    <Param key="CreateNewFrom"></Param>
        //    <Param key="SiteName"></Param>
        //    <Param key="SiteUrl"></Param>
        //    <Param key="TemplateId"></Param>
        //    <Param key="UniquePermission"></Param>
        //    <Param key="InheritTopLink"></Param>
        //    <Param key="ParentWebUrl"></Param>
        //    <Param key="ListGuid"></Param>
        //    </Data>]]>

        var strData;
        if ($('#lnkInstalledTemps').hasClass('selectedLink')) {

            strData = "<![CDATA[<Data>" +
                    "<Param key=\"IsNew\">" + isNew + "</Param>" +
                    "<Param key=\"IsTemplate\">False</Param>" +
                    "<Param key=\"CreateNewFrom\">" + createNewFrom + "</Param>" +
                    "<Param key=\"SiteTitle\">" + siteTitle + "</Param>" +
                    "<Param key=\"SiteUrl\">" + siteUrl + "</Param>" +
                    "<Param key=\"TemplateId\">" + templateId + "</Param>" +
                    "<Param key=\"UniquePermission\">" + uniquePermission + "</Param>" +
                    "<Param key=\"InheritTopLink\">" + inheritTopLink + "</Param>" +
                    "<Param key=\"ParentWebUrl\">" + parentWebUrl + "</Param>" +
                    "<Param key=\"ListGuid\">" + listUid + "</Param>" +
                    "<Param key=\"CopyFrom\">" + copyFrom + "</Param>" +
                    "<Param key=\"ListName\">" + listName + "</Param>" +
                    "<Param key=\"RListName\">" + rListName + "</Param>" +
                    "<Param key=\"ReqListName\">" + reqListName + "</Param>" +
                    "<Param key=\"DoNotDelRequest\">" + doNotDelRequest + "</Param>" +
                    "<Param key=\"SourceWebUrl\">" + currentWebRelativeUrl + "</Param>" +
                    "<Param key=\"SourceWebId\">" + sourceWebId + "</Param>" +
                    "<Param key=\"CurrentCategory\">" + $('#hdnSelectTempCategories').val() + "</Param>" +
                    "<Param key=\"CurrentTypes\">" + $('#hdnSelectTempTypes').val() + "</Param>" +
                    "<Param key=\"CreateFromLiveTemp\">" + createFromLiveTemp + "</Param>" +
                    "</Data>]]>";
        }
        else if ($('#lnkOnlineTemps').hasClass('selectedLink')) {
            var solutionName = $('#hdnOnlineSolFolder').val();
            strData = "<![CDATA[<Data>" +
                    "<Param key=\"IsNew\">" + isNew + "</Param>" +
                    "<Param key=\"IsTemplate\">False</Param>" +
                    "<Param key=\"CreateNewFrom\">" + createNewFrom + "</Param>" +
                    "<Param key=\"IncludeContent\">false</Param>" +
                    "<Param key=\"SiteTitle\">" + siteTitle + "</Param>" +
                    "<Param key=\"SiteUrl\">" + siteUrl + "</Param>" +
                    "<Param key=\"SolutionName\">" + solutionName + "</Param>" +
                    "<Param key=\"UniquePermission\">" + uniquePermission + "</Param>" +
                    "<Param key=\"InheritTopLink\">" + inheritTopLink + "</Param>" +
                    "<Param key=\"ParentWebUrl\">" + parentWebUrl + "</Param>" +
                    "<Param key=\"ListGuid\">" + listUid + "</Param>" +
                    "<Param key=\"CopyFrom\">" + copyFrom + "</Param>" +
                    "<Param key=\"ListName\">" + listName + "</Param>" +
                    "<Param key=\"RListName\">" + rListName + "</Param>" +
                    "<Param key=\"ReqListName\">" + reqListName + "</Param>" +
                    "<Param key=\"DoNotDelRequest\">" + doNotDelRequest + "</Param>" +
                    "<Param key=\"SourceWebUrl\">" + currentWebRelativeUrl + "</Param>" +
                    "<Param key=\"SourceWebId\">" + sourceWebId + "</Param>" +
                    "<Param key=\"CurrentCategory\">" + $('#hdnSelectTempCategories').val() + "</Param>" +
                    "<Param key=\"CurrentTypes\">" + $('#hdnSelectTempTypes').val() + "</Param>" +
                    "<Param key=\"CreateFromLiveTemp\">" + createFromLiveTemp + "</Param>" +
                    "</Data>]]>";
        }
        else if ($('#lnkFromExistingWorkspace').hasClass('selectedLink')) {


            var targetWebUrl = $('#hdnTargetWebUrl').val();
            strData = "<![CDATA[<Data>" +
                    "<Param key=\"IsNew\">" + isNew + "</Param>" +
                    "<Param key=\"IsTemplate\">False</Param>" +
                    "<Param key=\"CreateNewFrom\">" + createNewFrom + "</Param>" +
                    "<Param key=\"IncludeContent\">" + includeContent + "</Param>" +
                    "<Param key=\"SiteTitle\">" + siteTitle + "</Param>" +
                    "<Param key=\"SiteUrl\">" + siteUrl + "</Param>" +
                    "<Param key=\"TemplateId\">" + templateId + "</Param>" +
                    "<Param key=\"UniquePermission\">" + uniquePermission + "</Param>" +
                    "<Param key=\"InheritTopLink\">" + inheritTopLink + "</Param>" +
                    "<Param key=\"ParentWebUrl\">" + parentWebUrl + "</Param>" +
                    "<Param key=\"TargetWebUrl\">" + targetWebUrl + "</Param>" +
                    "<Param key=\"ListGuid\">" + listUid + "</Param>" +
                    "<Param key=\"CopyFrom\">" + copyFrom + "</Param>" +
                    "<Param key=\"ListName\">" + listName + "</Param>" +
                    "<Param key=\"RListName\">" + rListName + "</Param>" +
                    "<Param key=\"ReqListName\">" + reqListName + "</Param>" +
                    "<Param key=\"DoNotDelRequest\">" + doNotDelRequest + "</Param>" +
                    "<Param key=\"SourceWebUrl\">" + currentWebRelativeUrl + "</Param>" +
                    "<Param key=\"SourceWebId\">" + sourceWebId + "</Param>" +
                    "<Param key=\"CurrentCategory\">" + $('#hdnSelectTempCategories').val() + "</Param>" +
                    "<Param key=\"CurrentTypes\">" + $('#hdnSelectTempTypes').val() + "</Param>" +
                    "<Param key=\"CreateFromLiveTemp\">" + createFromLiveTemp + "</Param>" +
                    "</Data>]]>";
        }

        try {
            var SOAPEnvelope = $$.GetWorkEngineServiceSOAPEnvelope('CreateWorkspace', strData);
            xmlhttp.open('POST', workengineSvcUrl, true);
            xmlhttp.setRequestHeader('Content-Type', 'text/xml;charset=utf-8');
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4) {
                    if (xmlhttp.status == 200) {
                        var xmlDoc = $.parseXML($$.UnescapeHTMLtoXML(xmlhttp.responseText));
                        var $xml = $(xmlDoc);

                        $xml.find("Result").each(function () {
                            if ($(this).attr("Status") == '0') {
                                var url = $xml.find("Result").find("ProjectEditFormUrl").text();

                                if (url.indexOf('?') == -1) {
                                    url = $xml.find("Result").find("ProjectEditFormUrl").text() + '?source=' + $xml.find("Result").find("ServerRelativeUrl").text();
                                }
                                else {
                                    url = $xml.find("Result").find("ProjectEditFormUrl").text() + '&source=' + $xml.find("Result").find("ServerRelativeUrl").text();
                                }

                                redirectURL = url;
                                $('#spanMainLoading').html("You are now being redirected...");
                                $('#div_loading_msg').css('display', 'none');
                                var t = setTimeout("window.parent.location.href = redirectURL;", 3000);
                            }
                            else {
                                var msgFail = $xml.find("Result").text();
                                window.alert(msgFail);

                                // unhide page
                                $('#OuterContainer').css('display', 'block');
                                $('body').css('cursor', 'auto');
                                // hide loading icon
                                $('#divLoad_CreateWorkspace').css('display', 'none');
                                $('#div_loading_msg').css('display', 'none');

                                if ($('#hdnSiteUrl').val() != '') {
                                    $('#' + moreInfoUrlClientId).val($('#hdnSiteUrl').val());
                                }
                                else {
                                    $('#' + moreInfoUrlClientId).val('');
                                }
                            }
                        });
                    }
                }
            };
            xmlhttp.send(SOAPEnvelope);
        }
        catch (e) {
            alert(e.message);
        }
    }



    $$.CreateTemplate = function () {
        var xmlhttp = false;
        if (navigator.appName == 'Microsoft Internet Explorer') {
            xmlhttp = new ActiveXObject('Microsoft.XMLHTTP');
        }
        else {
            xmlhttp = new XMLHttpRequest();
        }

        var result;
        var inheritTopLink;
        var uniquePermission;
        var isNew = $('#hdnIsNewWorkSpace').val();
        var createNewFrom = $('#hdnCreateNewFrom').val();
        var siteTitle = $('#tbNewWorkSpaceName').val(); //.trim().replace(/[^a-zA-Z 0-9]+/g, '');
        //siteTitle = siteTitle.replace(/\s/g, '');
        var siteUrl = $('#' + urlBoxId).val().trim().replace(/[^a-zA-Z 0-9]+/g, '');
        siteUrl = siteUrl.replace(/\s/g, '');
        var templateId = $('#hdnTemplateId').val();
        var parentWebUrl = $('#hdnParentWebUrl').val();

        if (parentWebUrl == ' ') {
            parentWebUrl = currentWebRelativeUrl;
        }

        if (nav.length > 0) {
            if (nav == "True") {
                inheritTopLink = true;
            }
            else if (nav == "False") {
                inheritTopLink = false;
            }
        }
        else {
            if ($('input[name="rdoTopLink"]:nth(0)').length != 0) {
                inheritTopLink = $('input[name="rdoTopLink"]:nth(0)')[0].checked;
            }
            else {
                inheritTopLink = false;
            }
        }

        if (perms.length > 0) {
            if (perms == "Unique") {
                uniquePermission = true;
            }
            else if (perms == "Same") {
                uniquePermission = false;
            }
        }
        else {
            if ($('input[name="perms"]:nth(1)').length != 0) {
                uniquePermission = $('input[name="perms"]:nth(1)').attr('checked');
            }
            else {
                uniquePermission = true;
            }
        }

        // We should have param data formatted like below
        // fields will vary depending on the type of workspace
        // from online, installed, or existing
        // ====================================================
        //    <![CDATA[<Data>
        //    <Param key="IsNew"></Param>
        //    <Param key="IsTemplate">True</Param>
        //    <Param key="CreateNewFrom"></Param>
        //    <Param key="SiteName"></Param>
        //    <Param key="SiteUrl"></Param>
        //    <Param key="TemplateId"></Param>
        //    <Param key="UniquePermission"></Param>
        //    <Param key="InheritTopLink"></Param>
        //    <Param key="ParentWebUrl"></Param>
        //    <Param key="ListGuid"></Param>
        //    </Data>]]>

        var strData;
        if ($('#lnkNewTempFrmOnline').hasClass('selectedLink')) {
            var solutionName = $('#hdnOnlineSolFolder').val();
            strData = "<![CDATA[<Data>" +
                    "<Param key=\"IsNew\">" + isNew + "</Param>" +
                    "<Param key=\"IsTemplate\">True</Param>" +
                    "<Param key=\"CreateNewFrom\">" + createNewFrom + "</Param>" +
                    "<Param key=\"IncludeContent\">false</Param>" +
                    "<Param key=\"SiteTitle\">" + siteTitle + "</Param>" +
                    "<Param key=\"SiteUrl\">" + siteUrl + "</Param>" +
                    "<Param key=\"SolutionName\">" + solutionName + "</Param>" +
                    "<Param key=\"UniquePermission\">" + uniquePermission + "</Param>" +
                    "<Param key=\"InheritTopLink\">" + inheritTopLink + "</Param>" +
                    "<Param key=\"ParentWebUrl\">" + parentWebUrl + "</Param>" +
                    "<Param key=\"ListGuid\">" + listUid + "</Param>" +
                    "<Param key=\"CopyFrom\">" + copyFrom + "</Param>" +
                    "<Param key=\"ListName\">" + listName + "</Param>" +
                    "<Param key=\"RListName\">" + rListName + "</Param>" +
                    "<Param key=\"ReqListName\">" + reqListName + "</Param>" +
                    "<Param key=\"DoNotDelRequest\">" + doNotDelRequest + "</Param>" +
                    "<Param key=\"SourceWebUrl\">" + currentWebRelativeUrl + "</Param>" +
                    "<Param key=\"SourceWebId\">" + sourceWebId + "</Param>" +
                    "<Param key=\"CurrentCategory\">" + $('#hdnSelectTempCategories').val() + "</Param>" +
                    "<Param key=\"CurrentTypes\">" + $('#hdnSelectTempTypes').val() + "</Param>" +
                    "<Param key=\"CreateFromLiveTemp\">" + createFromLiveTemp + "</Param>" +
                    "</Data>]]>";
        }
        else if ($('#lnkNewTempFrmLocal').hasClass('selectedLink')) {
            //        var includeContent;
            //        if ($('input[name="rdoIncludeContent"]:nth(0)').length != 0) {
            //            includeContent = $('input[name="rdoIncludeContent"]:nth(0)').attr('checked');
            //        }
            //        else {
            //            includeContent = true;
            //        }
            strData = "<![CDATA[<Data>" +
                    "<Param key=\"IsNew\">" + isNew + "</Param>" +
                    "<Param key=\"IsTemplate\">True</Param>" +
                    "<Param key=\"CreateNewFrom\">" + createNewFrom + "</Param>" +
                    "<Param key=\"SiteTitle\">" + siteTitle + "</Param>" +
                    "<Param key=\"SiteUrl\">" + siteUrl + "</Param>" +
                    "<Param key=\"TemplateId\">" + templateId + "</Param>" +
                    "<Param key=\"UniquePermission\">" + uniquePermission + "</Param>" +
                    "<Param key=\"InheritTopLink\">" + inheritTopLink + "</Param>" +
                    "<Param key=\"ParentWebUrl\">" + parentWebUrl + "</Param>" +
                    "<Param key=\"ListGuid\">" + listUid + "</Param>" +
                    "<Param key=\"IncludeContent\">" + includeContent + "</Param>" +
                    "<Param key=\"CopyFrom\">" + copyFrom + "</Param>" +
                    "<Param key=\"RListName\">" + rListName + "</Param>" +
                    "<Param key=\"ReqListName\">" + reqListName + "</Param>" +
                    "<Param key=\"DoNotDelRequest\">" + doNotDelRequest + "</Param>" +
                    "<Param key=\"ListName\">" + listName + "</Param>" +
                    "<Param key=\"SourceWebUrl\">" + currentWebRelativeUrl + "</Param>" +
                    "<Param key=\"SourceWebId\">" + sourceWebId + "</Param>" +
                    "<Param key=\"CurrentCategory\">" + $('#hdnSelectTempCategories').val() + "</Param>" +
                    "<Param key=\"CurrentTypes\">" + $('#hdnSelectTempTypes').val() + "</Param>" +
                    "<Param key=\"CreateFromLiveTemp\">" + createFromLiveTemp + "</Param>" +
                    "</Data>]]>";
        }
        else if ($('#lnkNewTempFrmSolGal').hasClass('selectedLink')) {
            var templateInternalName = $('#hdnTemplateInternalName').val();
            strData = "<![CDATA[<Data>" +
                    "<Param key=\"IsNew\">" + isNew + "</Param>" +
                    "<Param key=\"IsTemplate\">True</Param>" +
                    "<Param key=\"CreateNewFrom\">" + createNewFrom + "</Param>" +
                    "<Param key=\"IncludeContent\">false</Param>" +
                    "<Param key=\"SiteTitle\">" + siteTitle + "</Param>" +
                    "<Param key=\"SiteUrl\">" + siteUrl + "</Param>" +
                    "<Param key=\"TemplateId\">" + templateId + "</Param>" +
                    "<Param key=\"UniquePermission\">" + uniquePermission + "</Param>" +
                    "<Param key=\"InheritTopLink\">" + inheritTopLink + "</Param>" +
                    "<Param key=\"ParentWebUrl\">" + parentWebUrl + "</Param>" +
                    "<Param key=\"ListGuid\">" + listUid + "</Param>" +
                    "<Param key=\"TemplateInternalName\">" + templateInternalName + "</Param>" +
                    "<Param key=\"CopyFrom\">" + copyFrom + "</Param>" +
                    "<Param key=\"RListName\">" + rListName + "</Param>" +
                    "<Param key=\"ReqListName\">" + reqListName + "</Param>" +
                    "<Param key=\"DoNotDelRequest\">" + doNotDelRequest + "</Param>" +
                    "<Param key=\"ListName\">" + listName + "</Param>" +
                    "<Param key=\"SourceWebUrl\">" + currentWebRelativeUrl + "</Param>" +
                    "<Param key=\"SourceWebId\">" + sourceWebId + "</Param>" +
                    "<Param key=\"CurrentCategory\">" + $('#hdnSelectTempCategories').val() + "</Param>" +
                    "<Param key=\"CurrentTypes\">" + $('#hdnSelectTempTypes').val() + "</Param>" +
                    "<Param key=\"CreateFromLiveTemp\">" + createFromLiveTemp + "</Param>" +
                    "</Data>]]>";
        }
        else if ($('#lnkNewTempFrmExisting').hasClass('selectedLink')) {
            //        var includeContent;
            //        if ($('input[name="rdoIncludeContent"]:nth(0)').length != 0) {
            //            includeContent = $('input[name="rdoIncludeContent"]:nth(0)').attr('checked');
            //        }
            //        else {
            //            includeContent = true;
            //        }
            var targetWebUrl = $('#hdnTargetWebUrl').val();
            strData = "<![CDATA[<Data>" +
                    "<Param key=\"IsNew\">" + isNew + "</Param>" +
                    "<Param key=\"IsTemplate\">True</Param>" +
                    "<Param key=\"CreateNewFrom\">" + createNewFrom + "</Param>" +
                    "<Param key=\"IncludeContent\">" + includeContent + "</Param>" +
                    "<Param key=\"SiteTitle\">" + siteTitle + "</Param>" +
                    "<Param key=\"SiteUrl\">" + siteUrl + "</Param>" +
                    "<Param key=\"TemplateId\">" + templateId + "</Param>" +
                    "<Param key=\"UniquePermission\">" + uniquePermission + "</Param>" +
                    "<Param key=\"InheritTopLink\">" + inheritTopLink + "</Param>" +
                    "<Param key=\"ParentWebUrl\">" + parentWebUrl + "</Param>" +
                    "<Param key=\"TargetWebUrl\">" + targetWebUrl + "</Param>" +
                    "<Param key=\"ListGuid\">" + listUid + "</Param>" +
                    "<Param key=\"CopyFrom\">" + copyFrom + "</Param>" +
                    "<Param key=\"RListName\">" + rListName + "</Param>" +
                    "<Param key=\"ReqListName\">" + reqListName + "</Param>" +
                    "<Param key=\"DoNotDelRequest\">" + doNotDelRequest + "</Param>" +
                    "<Param key=\"ListName\">" + listName + "</Param>" +
                    "<Param key=\"SourceWebUrl\">" + currentWebRelativeUrl + "</Param>" +
                    "<Param key=\"SourceWebId\">" + sourceWebId + "</Param>" +
                    "<Param key=\"CurrentCategory\">" + $('#hdnSelectTempCategories').val() + "</Param>" +
                    "<Param key=\"CurrentTypes\">" + $('#hdnSelectTempTypes').val() + "</Param>" +
                    "<Param key=\"CreateFromLiveTemp\">" + createFromLiveTemp + "</Param>" +
                    "</Data>]]>";
        }
        try {
            var SOAPEnvelope = $$.GetWorkEngineServiceSOAPEnvelope('CreateWorkspace', strData);
            xmlhttp.open('POST', workengineSvcUrl, true);
            xmlhttp.setRequestHeader('Content-Type', 'text/xml;charset=utf-8');
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4) {
                    if (xmlhttp.status == 200) {
                        var xmlDoc = $.parseXML($$.UnescapeHTMLtoXML(xmlhttp.responseText));
                        var $xml = $(xmlDoc);

                        $xml.find("Result").each(function () {
                            if ($(this).attr("Status") == '0') {
                                var url = $xml.find("Result").find("TemplateEditFormUrl").text();

                                if (url.indexOf('?') == -1) {
                                    url = $xml.find("Result").find("TemplateEditFormUrl").text() + '?source=' + tempGalRedirect;
                                }
                                else {
                                    url = $xml.find("Result").find("TemplateEditFormUrl").text() + '&source=' + tempGalRedirect;
                                }

                                redirectURL = url;
                                $('#spanMainLoading').html("You are now being redirected...");
                                $('#div_loading_msg').css('display', 'none');
                                var t2 = setTimeout("window.parent.location.href = redirectURL;", 3000);
                            }
                            else {
                                var msgFail = $xml.find("Result").text();
                                alert(msgFail);
                                // unhide page
                                $('#OuterContainer').css('display', 'block');
                                $('body').css('cursor', 'auto');
                                // hide loading icon
                                $('#divLoad_CreateWorkspace').css('display', 'none');
                                $('#div_loading_msg').css('display', 'none');

                                $('#' + moreInfoUrlClientId).val('');
                            }
                        });
                    }
                }
            };
            xmlhttp.send(SOAPEnvelope);
        }
        catch (e) {
            alert(e.message);
        }
    }

    $$.AppendTempGalTemplateDivs = function (xml) {
        // clear main div first
        $('#divTemplatesHolder').empty();

        xml.find('Template').each(function () {
            var strCats = '';
            $(this).find('TemplateCategories TemplateCategory').each(function () {
                if ($(this).text()) {
                    strCats += $(this).text() + ", ";
                }
            });

            strCats = strCats.substring(0, strCats.length - 2);

            var divTempHolder = $('#divTemplateHolder')
                            .clone()
                            .css('display', 'block')
                            .attr('id', 'divTemplate_' + $(this).find('Title').text())
                            .find('#templateId').val($(this).attr('Id')).end()
                            .find('#templateTitle').val($(this).find('Title').text()).end()
                            .find('#templateType').val($(this).find('TemplateType').text()).end()
                            .find('#templateCategories').val(strCats).end()
                            .find('#templateDescription').val($(this).find('Description').text()).end()
                            .find('#divTemplateTitle').html($(this).find('Title').text()).end()
                            .find('#templateImage').attr('src', $(this).find('AttachmentUrl').text()).end()
                            .wrap('<div></div>')
                            .parent()
                            .html();

            $('#divTemplatesHolder').append(divTempHolder);
        });

    }

    $$.AppendOnlineTemplateDivs = function (oJson) {
        // clear main div first
        $('#divOnlineTempsHolder').empty();

        for (var template in oJson.Templates) {

            var strCats = '';
            var cats = oJson.Templates[template].TemplateCategory.split(';#');
            for (var i = 0; i < cats.length; i++) {
                if (cats[i] != '') {
                    strCats += cats[i] + ', ';
                }
            }
            strCats = strCats.substring(0, strCats.length - 2);

            var strTypes = '';
            var types = oJson.Templates[template].TemplateType.split(';#');
            for (var i = 0; i < types.length; i++) {
                if (types[i] != '') {
                    strTypes += types[i] + ', ';
                }
            }
            strTypes = strTypes.substring(0, strTypes.length - 2);

            var imageUrl = oJson.Templates[template].ImageUrl ? oJson.Templates[template].ImageUrl.replace(',', '').trim() : "/_layouts/EPMLive/Images/blanktemplate.png";
            var isRestricted = true;
            var owsLevel = oJson.Templates[template].Levels ? oJson.Templates[template].Levels : "";
            if (owsLevel != "") {
                var templateLevels = owsLevel.split(';#');
                isRestricted = !$$.IsTempAvailableToCurrentUser(templateLevels);
            }

            if (isRestricted) {
                imageUrl = "/_layouts/EPMLive/Images/notavailable.png"
            }

            // SalesInfo:SW
            var salesInfo = oJson.Templates[template].SalesInfo;

            var divTempHolder = $('#divOnlineTempHolder')
                            .clone()
                            .css('display', 'block')
                            .attr('id', 'divTemplate_' + oJson.Templates[template].Id)
                            .find('#templateId').val(oJson.Templates[template].Id).end()
                            .find('#templateTitle').val(oJson.Templates[template].Title).end()
                            .find('#templateType').val(strTypes).end()
                            .find('#templateCategories').val(strCats).end()
                            .find('#templateDescription').val(oJson.Templates[template].Description).end()
                            .find('#divOnlineTempTitle').html(oJson.Templates[template].Title).end()
                            .find('#templateOnlineFolder').val(oJson.Templates[template].Title).end()
                            .find('#templateLevels').val(owsLevel).end()
                            .find('#templateSalesInfo').val(salesInfo).end()
                            .find('#templateImage').attr('src', imageUrl).end()
                            .wrap('<div></div>')
                            .parent()
                            .html();

            $('#divOnlineTempsHolder').append(divTempHolder);
        }
    }

    $$.AppendSolGalTemplateDivs = function (xml) {
        // clear main div first
        $('#divSolGalTempsHolder').empty();

        xml.find('Template').each(function () {
            var strCats = '';
            $(this).find('TemplateCategories TemplateCategory').each(function () {
                if ($(this).text()) {
                    strCats += $(this).text() + ", ";
                }
            });

            strCats = strCats.substring(0, strCats.length - 2);

            var imageUrl = $(this).find('AttachmentUrl').text() ? $(this).find('AttachmentUrl').text() : "/_layouts/EPMLive/Images/blanktemplate.png";

            var divTempHolder = $('#divTemplateHolder')
                            .clone()
                            .css('display', 'block')
                            .attr('id', 'divTemplate_' + $(this).find('Title').text())
                            .find('#templateId').val($(this).attr('Id')).end()
                            .find('#templateTitle').val($(this).find('Title').text()).end()
                            .find('#templateType').val($(this).find('TemplateType').text()).end()
                            .find('#templateCategories').val(strCats).end()
                            .find('#templateDescription').val($(this).find('Descripton').text()).end()
                            .find('#divTemplateTitle').html($(this).find('Title').text()).end()
                            .find('#templateInternalName').val($(this).find('TemplateInternalName').text()).end()
                            .find('#templateImage').attr('src', imageUrl).end()
                            .wrap('<div></div>')
                            .parent()
                            .html();

            $('#divSolGalTempsHolder').append(divTempHolder);
        });


    }

    // template levels should be an array
    $$.IsTempAvailableToCurrentUser = function (templateLevels) {
        var userFeatures = featuresList.split(';#');
        for (var i = 0; i < userFeatures.length; i++) {
            if (userFeatures[i] != "") {
                var pos = $.inArray(userFeatures[i], templateLevels);
                if (pos != -1) {
                    return true;
                }
            }
        }
        return false;
    }

    $$.AppendOnlineFilters = function (templateTypes, templateCategories) {
        $('#divOnlineSolStoreFilterLoadingGif').css('display', 'none');

        var list = $('#' + onlineFilterPnlId).find('.ulFilterBy');
        list.empty();

        // insert all types filter
        //    list.append("<li class=\"ms-create-listitem\"><div><a id=\"lnkOnlineAllTypes\" class=\"sameColorLink onlineTypeFilter\" href=\"#\">All Types</a></div></li>");

        //    $('#lnkOnlineAllTypes').click(function () {
        //        ClearAllSelection("onlineTypeFilter");
        //        $(this).addClass("selectedLink");
        //        UpdateSelectedTempType("All Types");
        //        FilterOnlineTemplates();
        //        return false;
        //    });

        //    for (type in templateTypes) {
        //        var originalTypeText = templateTypes[type];
        //        if (originalTypeText != "") {
        //            var staticTypeText = originalTypeText.replace(" ", "");
        //            var tempTypeFilter = $('#filterLinks_model')
        //                                .clone()
        //                                .css('display', 'block')
        //                                .attr('id', 'filterLink_' + staticTypeText)
        //                                .find('#lnkOnlineTemps').attr('id', 'lnkOnlineTypeFilter_' + staticTypeText)
        //                                                        .addClass('onlineTypeFilter')
        //                                                        .text(originalTypeText)
        //                                                        .end()
        //                                .wrap("<div></div>")
        //                                .parent()
        //                                .html();

        //            list.append(tempTypeFilter);

        //            $('#lnkOnlineTypeFilter_' + staticTypeText).click(function () {
        //                ClearAllSelection('onlineTypeFilter');
        //                $(this).addClass('selectedLink');
        //                var filterText = $(this).text();
        //                UpdateSelectedTempType(filterText);
        //                FilterOnlineTemplates();
        //                return false;
        //            });
        //        }
        //    }

        // insert empty link to create space
        //    list.append("<li class=\"ms-create-listitem\"><div style=\"clear:both;height:3px;\"></div></li>");

        // insert all categories filter
        list.append("<li class=\"ms-create-listitem\"><div><a id=\"lnkOnlineAllCategories\" class=\"sameColorLink onlineCategoryFilter\" href=\"#\">All Categories</a></div></li>");

        $('#lnkOnlineAllCategories').click(function () {
            $$.ClearAllSelection("onlineCategoryFilter");
            $(this).addClass("selectedLink");
            $$.UpdateSelectedTempCat("All Categories");
            $$.FilterOnlineTemplates();
            return false;
        });

        for (cat in templateCategories) {
            var originalCategoryText = templateCategories[cat];
            if (originalCategoryText != '') {
                var staticCategoryText = originalCategoryText.replace(" ", "");

                var tempCatFilter = $('#filterLinks_model')
                    .clone()
                    .css('display', 'block')
                    .attr('id', 'filterLink_' + staticCategoryText)
                    .find('#lnkOnlineTemps').attr('id', 'lnkOnlineCategoryFilter_' + staticCategoryText)
                                            .removeAttr('Target')
                                            .addClass('onlineCategoryFilter')
                                            .text(originalCategoryText)
                                            .end()
                    .wrap("<div></div>")
                    .parent()
                    .html();

                list.append(tempCatFilter);

                $('#lnkOnlineCategoryFilter_' + staticCategoryText).click(function () {
                    $$.ClearAllSelection('onlineCategoryFilter');
                    $(this).addClass('selectedLink');
                    var filterText = $(this).text();
                    $$.UpdateSelectedTempCat(filterText);
                    $$.FilterOnlineTemplates();
                    return false;
                });
            }
        }

        $$.HookupLinkHoverLogic();
    }

    $$.AppendTempGalFilters = function (tempsTypes, tempCats) {
        $('#divLocalTempGalFilterLoadingGif').css('display', 'none');
        var list = $('#' + tempGalPnlId).find('.ulFilterBy');
        list.empty();

        // insert all types filter
        //    list.append("<li class=\"ms-create-listitem\"><div class=\"divFilterByLink\"><a id=\"lnkAllTypes\" class=\"sameColorLink typefilter\" href=\"#\" >All Types</a></div></li>");

        //    $('#lnkOnlineAllTypes').click(function () {
        //        ClearAllSelection("typefilters");
        //        $(this).addClass("selectedLink");
        //        UpdateSelectedTempType("All Types");
        //        FilterTempGalTemplates();
        //        return false;
        //    });

        //        for (type in tempsTypes) {
        //            var originalTypeText = tempsTypes[type];
        //        if (originalTypeText != "") {
        //            var staticTypeText = originalTypeText.replace(" ", "");
        //            var tempTypeFilter = $('#filterLinks_model')
        //                                .clone()
        //                                .css('display', 'block')
        //                                .attr('id', 'filterLink_' + staticTypeText)
        //                                .find('#lnkOnlineTemps').attr('id', 'lnkOnlineTypeFilter_' + staticTypeText)
        //                                                        .addClass('onlineTypeFilter')
        //                                                        .text(originalTypeText)
        //                                                        .end()
        //                                .wrap("<div></div>")
        //                                .parent()
        //                                .html();

        //            list.append(tempTypeFilter);

        //            $('#lnkOnlineTypeFilter_' + staticTypeText).click(function () {
        //                ClearAllSelection('onlineTypeFilter');
        //                $(this).addClass('selectedLink');
        //                var filterText = $(this).text();
        //                UpdateSelectedTempType(filterText);
        //                FilterTempGalTemplates();
        //                return false;
        //            });
        //        }
        //    }

        // insert empty link to create space
        //    list.append("<li class=\"ms-create-listitem\"><div style=\"clear:both;height:3px;\"></div></li>");

        // insert all categories filter
        list.append("<li class=\"ms-create-listitem\"><div class=\"divBrowseFromLink\"><a id=\"lnkTempGalAllCategories\" class=\"sameColorLink categoryfilter\" href=\"#\" >All Categories</a></div></li>");

        $('#lnkTempGalAllCategories').click(function () {
            $$.ClearAllSelection("categoryfilters");
            $(this).addClass("selectedLink");
            $$.UpdateSelectedTempCat("All Categories");
            $$.FilterTempGalTemplates();
            return false;
        });

        for (cat in tempCats) {
            var originalCategoryText = tempCats[cat];
            if (originalCategoryText != '') {
                var staticCategoryText = originalCategoryText.replace(" ", "");

                var tempCatFilter = $('#filterLinks_model')
                    .clone()
                    .css('display', 'block')
                    .attr('id', 'filterLink_' + staticCategoryText)
                    .find('#lnkOnlineTemps').attr('id', 'lnkOnlineCategoryFilter_' + staticCategoryText)
                                            .removeAttr('Target')
                                            .addClass('onlineCategoryFilter')
                                            .text(originalCategoryText)
                                            .end()
                    .wrap("<div></div>")
                    .parent()
                    .html();

                list.append(tempCatFilter);

                $('#lnkOnlineCategoryFilter_' + staticCategoryText).click(function () {
                    $$.ClearAllSelection('onlineCategoryFilter');
                    $(this).addClass('selectedLink');
                    var filterText = $(this).text();
                    $$.UpdateSelectedTempCat(filterText);
                    $$.FilterTempGalTemplates();
                    return false;
                });
            }
        }

        $$.HookupLinkHoverLogic();
    }

    $$.AppendSolGalFilters = function (tempCats) {
        $('#divSPSolGalFilterLoadingGif').css('display', 'none');
        var list = $('#' + solGalPanlId).find('.ulFilterBy');
        list.empty();

        // insert all types filter
        //    list.append("<li class=\"ms-create-listitem\"><div class=\"divFilterByLink\"><a id=\"lnkSolGalAllTypes\" class=\"sameColorLink solGalTypeFilter\" href=\"#\" >All Types</a></div></li>");

        //    $('#lnkOnlineAllTypes').click(function () {
        //        ClearAllSelection("solGalTypeFilter");
        //        $(this).addClass("selectedLink");
        //        UpdateSelectedTempType("All Types");
        //        FilterSolGalTemplates();
        //        return false;
        //    });

        // insert "site" type filter
        //    list.append("<li class=\"ms-create-listitem\"><div class=\"divFilterByLink\"><a class=\"sameColorLink solGalTypeFilter\" href=\"#\" >Site</a></div></li>");

        //    $('#lnkOnlineAllTypes').click(function () {
        //        ClearAllSelection("solGalTypeFilter");
        //        $(this).addClass("selectedLink");
        //        UpdateSelectedTempType("Site")
        //        FilterSolGalTemplates();
        //        return false;
        //    });

        // insert empty link to create space
        //    list.append("<li class=\"ms-create-listitem\"><div style=\"clear:both;height:3px;\"></div></li>");

        // insert all categories filter
        list.append("<li class=\"ms-create-listitem\"><div class=\"divBrowseFromLink\"><a id=\"lnkSolGalAllCategories\" class=\"sameColorLink solGalCategoryFilter\" href=\"#\" >All Categories</a></div></li>");

        $('#lnkSolGalAllCategories').click(function () {
            $$.ClearAllSelection("solGalCategoryFilter");
            $(this).addClass("selectedLink");
            $$.UpdateSelectedTempCat("All Categories");
            $$.FilterSolGalTemplates();
            return false;
        });

        for (cat in tempCats) {
            var originalCategoryText = tempCats[cat];
            if (originalCategoryText != '') {
                var staticCategoryText = originalCategoryText.replace(" ", "");

                var tempCatFilter = $('#filterLinks_model')
                    .clone()
                    .css('display', 'block')
                    .attr('id', 'filterLink_' + staticCategoryText)
                    .find('#lnkOnlineTemps').attr('id', 'lnksolGalCategoryFilter_' + staticCategoryText)
                                            .removeAttr('Target')
                                            .addClass('solGalCategoryFilter')
                                            .text(originalCategoryText)
                                            .end()
                    .wrap("<div></div>")
                    .parent()
                    .html();

                list.append(tempCatFilter);

                $('#lnksolGalCategoryFilter_' + staticCategoryText).click(function () {
                    $$.ClearAllSelection('solGalCategoryFilter');
                    $(this).addClass('selectedLink');
                    var filterText = $(this).text();
                    $$.UpdateSelectedTempCat(filterText);
                    $$.FilterSolGalTemplates();
                    return false;
                });
            }
        }

        $$.HookupLinkHoverLogic();
    }

    $$.WireTempDivWithLogic = function () {

        $('.divTemplateHolder').hover(
        function () {
            $(this).addClass('highLightTemplate');
        },
        function () {
            $(this).removeClass('highLightTemplate');
        });

        $('.divTemplatesHolder .divTemplateHolder').click(function () {


            $('div.txtTemplateTitle').text($(this).find('#templateTitle').val());
            $('#rightDivTemplateImage').attr('src', $(this).find('#templateImage').attr('src'));
            $('div.txtTemplateType').text('');
            $('div.txtTemplateType').html('<b>Type:</b> ' + $(this).find('#templateType').val());
            $('#hdnSelectTempTypes').val($(this).find('#templateType').val());
            // clear category text
            $('div.txtTemplateCategory').text('');
            if ($(this).find('#templateCategories').val().trim().length != 0) {
                $('div.txtTemplateCategory').html('<b>Category:</b> ' + $(this).find('#templateCategories').val());
            }

            // clear description
            $('div.txtDescription').text('');
            if ($(this).find('#templateDescription').val().trim().length != 0) {
                //$('div.txtDescription').html('<b>Description:</b> ' + $(this).find('#templateDescription').val());
                $('div.txtDescription').html($(this).find('#templateDescription').val());
            }

            $('#hdnTemplateId').val($(this).find('#templateId').val());
            $(this).siblings().removeClass("selectedTemp");

            if ($(this).hasClass("selectedTemp")) {
            }
            else {
                $(this).addClass("selectedTemp");
            }
        });
    }

    $$.WireSolGalTempDivWithLogic = function () {

        $('#divSolGalTempsHolder .divTemplateHolder').hover(
        function () {
            $(this).addClass('highLightTemplate');
        },
        function () {
            $(this).removeClass('highLightTemplate');
        });

        $('#divSolGalTempsHolder .divTemplateHolder').click(function () {
            $$.ChangeRightPanelVisibility();

            $('div.txtTemplateTitle').text($(this).find('#templateTitle').val());
            $('#rightDivTemplateImage').attr('src', $(this).find('#templateImage').attr('src'));
            $('div.txtTemplateType').text('');
            $('div.txtTemplateType').html('<b>Type:</b> ' + $(this).find('#templateType').val());
            $('#hdnSelectTempTypes').val($(this).find('#templateType').val());
            // clear category text
            $('div.txtTemplateCategory').text('');
            if ($(this).find('#templateCategories').val().trim().length != 0) {
                $('div.txtTemplateCategory').html('<b>Category:</b> ' + $(this).find('#templateCategories').val());
                $('#hdnSelectTempCategories').val($(this).find('#templateCategories').val());
            }

            // clear description
            $('div.txtDescription').text('');
            if ($(this).find('#templateDescription').val().trim().length != 0) {
                //$('div.txtDescription').html('<b>Description:</b> ' + $(this).find('#templateDescription').val());
                $('div.txtDescription').html($(this).find('#templateDescription').val());
            }

            $('#hdnTemplateId').val($(this).find('#templateId').val());
            $('#hdnTemplateInternalName').val($(this).find('#templateInternalName').val());
            $(this).siblings().removeClass("selectedTemp");

            if ($(this).hasClass("selectedTemp")) {
            }
            else {
                $(this).addClass("selectedTemp");
            }
        });
    }

    $$.WireOnlineTempDivWithLogic = function () {

        $('.divOnlineTempHolder').hover(
        function () {
            $(this).addClass('highLightTemplate');
        },
        function () {
            $(this).removeClass('highLightTemplate');
        });

        $('.divOnlineTempHolder').click(function () {
            // if template is available
            if ($(this).find('#templateImage').attr('src') != "/_layouts/EPMLive/Images/notavailable.png") {
                $$.ChangeRightPanelVisibility();
                $('#rightDivTemplateImage').attr('src', $(this).find('#templateImage').attr('src'));
                $('div.txtTemplateTitle').text($(this).find('#templateTitle').val());
                $('div.txtTemplateType').text('');
                $('div.txtTemplateType').html('<b>Type:</b> ' + $(this).find('#templateType').val());
                $('#hdnSelectTempTypes').val($(this).find('#templateType').val());
                // clear category text
                $('div.txtTemplateCategory').text('');
                if ($(this).find('#templateCategories').val().trim().length != 0) {
                    $('div.txtTemplateCategory').html('<b>Category:</b> ' + $(this).find('#templateCategories').val());
                    $('#hdnSelectTempCategories').val($(this).find('#templateCategories').val());
                }
                // clear description
                $('div.txtDescription').text('');
                if ($(this).find('#templateDescription').val().trim().length != 0) {
                    //$('div.txtDescription').html('<b>Description:</b> ' + $(this).find('#templateDescription').val());
                    $('div.txtDescription').html($(this).find('#templateDescription').val());
                }
                $('#hdnTemplateId').val($(this).find('#templateId').val());

                $('#hdnOnlineSolFolder').val($(this).find('#templateOnlineFolder').val());
            }
            // if template is not available
            else {
                $('.divRight div').css('display', 'none');
                $('.divRight input').css('display', 'none');
                $('.divSalesInfo').css('display', 'block');
                $('.divSalesInfo').html($$.UnescapeHTMLtoXML($(this).find('#templateSalesInfo').val()));
            }

            $(this).siblings().removeClass("selectedTemp");

            if ($(this).hasClass("selectedTemp")) {
            }
            else {
                $(this).addClass("selectedTemp");
            }

        });
    }

    $$.ClickFirstTemp = function () {
        // clear all temp information from right panel
        $('.txtTemplateTitle').empty();
        $('.txtTemplateType').empty();
        $('.txtTemplateCategory').empty();
        $('.txtDescription').empty();

        // click first filtered temp
        if ($('#lnkInstalledTemps').hasClass('selectedLink') || $('#lnkNewTempFrmLocal').hasClass('selectedLink')) {
            $('.divTemplatesHolder .divTemplateHolder:visible').first().trigger("click");
        }
        else if ($('#lnkOnlineTemps').hasClass('selectedLink') || $('#lnkNewTempFrmOnline').hasClass('selectedLink')) {
            $('.divOnlineTempsHolder .divOnlineTempHolder:visible').first().trigger("click");
        }
        else if ($('#lnkNewTempFrmSolGal').hasClass('selectedLink')) {
            $('.divSolGalTempsHolder .divTemplateHolder:visible').first().trigger("click");
        }
    }

    $$.ClearAllSelection = function (area) {
        switch (area) {
            case 'workspace':
                $('.divWorkSpaceType a').removeClass("selectedLink");
                break;
            case 'createNewWorkspaceFrom':
                $('.divCreateNewWorkspaceFrom a').removeClass("selectedLink");
                break;
            case 'typefilters':
                $('.typefilter').removeClass("selectedLink");
                break;
            case 'categoryfilters':
                $('.categoryfilter').removeClass("selectedLink");
                break;
            case 'onlineTypeFilter':
                $('.onlineTypeFilter').removeClass("selectedLink");
                break;
            case 'onlineCategoryFilter':
                $('.onlineCategoryFilter').removeClass("selectedLink");
                break;
            case 'solGalTypeFilter':
                $('.solGalTypeFilter').removeClass("selectedLink");
                break;
            case 'solGalCategoryFilter':
                $('.solGalCategoryFilter').removeClass("selectedLink");
                break;
        }
    }

    $$.SetWorkspaceType = function (workspaceType) {
        $('#hdnIsNewWorkSpace').val(workspaceType);
    }

    $$.SetCreateNewFrom = function (type) {
        $('#hdnCreateNewFrom').val(type);
    }

    $$.SetParentWebUrl = function (workspaceType) {
        switch (workspaceType) {
            case 'New':
                $('#hdnIsNewWorkSpace').val("true");
                $('#hdnParentWebUrl').val(parentWebUrl);
                break;
            case 'Existing':
                $('#hdnIsNewWorkSpace').val("false");
                $('#hdnParentWebUrl').val("");
                break;
            default:
                break;
        }

    }

    $$.GetTempsFromTempGal = function () {

        var xmlhttp = false;
        if (navigator.appName == 'Microsoft Internet Explorer') {
            xmlhttp = new ActiveXObject('Microsoft.XMLHTTP');
        }
        else {
            xmlhttp = new XMLHttpRequest();
        }

        var result;
        var templateType = $('#hdnTemplateType').val();
        var templateCategory = $('#hdnTemplateCategory').val();
        var strXmlData;

        if (newItemName == "template" || newItemName == "Template") {
            strXmlData = "<![CDATA[<Data>" +
                     "<Param key=\"Type\">" + templateType + "</Param>" +
                     "<Param key=\"IsTemplate\">true</Param>" +
                     "<Param key=\"CompLevels\">" + compLevels + "</Param>" +
                     "<Param key=\"TemplateType\">" + qsTemplateType + "</Param>" +
                     "<Param key=\"ListName\">" + listName + "</Param>" +
                     "<Param key=\"CreateFromLiveTemp\">" + createFromLiveTemp + "</Param>" +
                     "</Data>]]>";
        }
        else {
            strXmlData = "<![CDATA[<Data>" +
                     "<Param key=\"Type\">" + templateType + "</Param>" +
                     "<Param key=\"CompLevels\">" + compLevels + "</Param>" +
                     "<Param key=\"TemplateType\">" + qsTemplateType + "</Param>" +
                     "<Param key=\"ListName\">" + listName + "</Param>" +
                     "<Param key=\"CreateFromLiveTemp\">" + createFromLiveTemp + "</Param>" +
                     "</Data>]]>";
        }


        var SOAPEnvelope = $$.GetWorkEngineServiceSOAPEnvelope('GetAllTempGalTemps', strXmlData);
        xmlhttp.open('POST', workengineSvcUrl, true);
        xmlhttp.setRequestHeader('Content-Type', 'text/xml;charset=utf-8');
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState == 4) {
                if (xmlhttp.status == 200) {
                    var xmlDoc = $.parseXML($$.UnescapeHTMLtoXML(xmlhttp.responseText));
                    var $xml = $(xmlDoc);

                    $xml.find("Result").each(function () {
                        if ($(this).attr("Status") == '0') {
                            // parse the xml that returns
                            // create div for each template
                            // append to main content
                            if ($xml.find('Result').text().length != 0) {
                                $$.AppendTempGalTemplateDivs($xml);
                                $$.GetTempGalFilters();
                            }

                            if (defaultCreateNew == 'local' || defaultCreateNew == 'existing') {
                                $('#linkNewWorkspace').trigger('click');
                            }
                            // returned xml is empty because 
                            // template gallery does not exist
                            //                        else {
                            //                            $('div.newWorkspace').css('display', 'none');
                            //                        }
                        }
                        else {
                            var msgFail = $xml.find("Result").text();
                            alert(msgFail);
                            // hide local gallery if its empty, missing, or site on list just doesn not exist
                            if (defaultCreateNew == 'local' || defaultCreateNew == 'existing') {
                                $('#linkNewWorkspace').trigger('click');
                            }
                        }
                    });
                }
            }
        };
        xmlhttp.send(SOAPEnvelope);
    }

    $$.GetTempsFromSolGal = function () {
        var xmlhttp = false;
        if (navigator.appName == 'Microsoft Internet Explorer') {
            xmlhttp = new ActiveXObject('Microsoft.XMLHTTP');
        }
        else {
            xmlhttp = new XMLHttpRequest();
        }

        var result;
        var templateType = $('#hdnTemplateType').val();
        var templateCategory = $('#hdnTemplateCategory').val();

        var strXmlData = "<![CDATA[<Data>" +
                     "<Param key=\"Type\">" + templateType + "</Param>" +
                     "</Data>]]>";

        var SOAPEnvelope = $$.GetWorkEngineServiceSOAPEnvelope('GetAllSolGalTemps', strXmlData);
        xmlhttp.open('POST', workengineSvcUrl, true);
        xmlhttp.setRequestHeader('Content-Type', 'text/xml;charset=utf-8');
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState == 4) {
                if (xmlhttp.status == 200) {
                    var xmlDoc = $.parseXML($$.UnescapeHTMLtoXML(xmlhttp.responseText));
                    var $xml = $(xmlDoc);

                    $xml.find("Result").each(function () {
                        if ($(this).attr("Status") == '0') {
                            // parse the xml that returns
                            // create div for each template
                            // append to main content
                            if ($xml.find('Result').text().length != 0) {
                                $$.AppendSolGalTemplateDivs($xml);
                                $$.GetSolGalTempsFilters();
                            }
                            // returned xml is empty because 
                            // template gallery does not exist
                            //                        else {
                            //                            $('div.newWorkspace').css('display', 'none');
                            //                        }
                        }
                        else {
                            var msgFail = $xml.find("Result").text();
                            window.alert(msgFail);
                        }
                    });
                }
            }
        };
        xmlhttp.send(SOAPEnvelope);
    }



    $$.GetWorkEngineServiceSOAPEnvelope = function (functionName, data) {
        var strEnvelope = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                        "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
                            "<soap:Body>" +
                                "<Execute xmlns=\"workengine.com\">" +
                                    "<Function>" + functionName + "</Function>" +
                                    "<Dataxml>" + data + "</Dataxml>" +
                                "</Execute>" +
                            "</soap:Body>" +
                        "</soap:Envelope>";
        return strEnvelope;
    }

    $$.SetupSearchLogic = function (mode) {

        var isCreatingTemp = (newItemNameLwrCs == 'template');

        switch (mode) {
            case "online":
                var ids = new Array();
                ids[0] = 'lnkOnlineAllCategories';
                //ids[1] = 'lnkOnlineTemps';

                if (!isCreatingTemp) {
                    $$.FreeSearchHandler.InitVals(ids, 'divOnlineTempsHolder', 'divOnlineTempHolder', 'divEPMLiveTempFilters');
                }
                else {
                    //$('#lnkNewTempFrmOnline').trigger('click');
                    $$.FreeSearchHandler.InitVals(ids, 'divOnlineTempsHolder', 'divOnlineTempHolder', 'divEPMLiveTempFilters');
                }
                break;
            case "local":
                var ids = new Array();
                ids[0] = 'lnkTempGalAllCategories';
                //ids[1] = 'lnkInstalledTemps';

                if (!isCreatingTemp) {
                    $$.FreeSearchHandler.InitVals(ids, 'divTemplatesHolder', 'divTemplateHolder', 'divFilterBy');
                }
                else {
                    //$('#lnkNewTempFrmOnline').trigger('click');
                    $$.FreeSearchHandler.InitVals(ids, 'divTemplatesHolder', 'divTemplateHolder', 'divFilterBy');
                }
                break;
            case "solgal":
                var ids = new Array();
                ids[0] = 'lnkSolGalAllCategories';

                $$.FreeSearchHandler.InitVals(ids, 'divSolGalTempsHolder', 'divTemplateHolder', 'divSolGalFilters');

                break;
        }

        $$.FreeSearchHandler.RegisterControlLogic();
    };

    $$.GetOnlineTemps = function () {

        if (isOnlineTempsLoaded == 'false') {

            var xmlhttp = false;
            if (navigator.appName == 'Microsoft Internet Explorer') {
                xmlhttp = new ActiveXObject('Microsoft.XMLHTTP');
            }
            else {
                xmlhttp = new XMLHttpRequest();
            }

            //var query = "<![CDATA[<Where><And><Eq><FieldRef Name=\"Visible\" /><Value Type=\"Boolean\">1</Value></Eq><Eq><FieldRef Name=\"SolutionType\" /><Value Type=\"Choice\">" + qsSolutionType + "</Value></Eq></And></Where><OrderBy><FieldRef Name=\"Title\" Ascending=\"True\" /></OrderBy>]]>";
            var query;
            if (qsTemplateType != 'template' && qsTemplateType != 'workspace') {
                query = "<![CDATA[<Where><And><Eq><FieldRef Name=\"Visible\" /><Value Type=\"Boolean\">1</Value></Eq><And><Eq><FieldRef Name=\"SolutionType\" /><Value Type=\"Choice\">" + qsSolutionType + "</Value></Eq><Eq><FieldRef Name=\"TemplateType\" /><Value Type=\"MultiChoice\">" + qsTemplateType + "</Value></Eq></And></And></Where><OrderBy><FieldRef Name=\"Title\" Ascending=\"True\" /></OrderBy>]]>";
            }
            else {
                if (listName.indexOf('Requests') !== -1) {
                    query = "<![CDATA[<Where><And><Eq><FieldRef Name=\"Visible\" /><Value Type=\"Boolean\">1</Value></Eq><And><Eq><FieldRef Name=\"SolutionType\" /><Value Type=\"Choice\">" + qsSolutionType + "</Value></Eq><Eq><FieldRef Name=\"TemplateType\" /><Value Type=\"MultiChoice\">project</Value></Eq></And></And></Where><OrderBy><FieldRef Name=\"Title\" Ascending=\"True\" /></OrderBy>]]>";
                }
                else {
                    query = "<![CDATA[<Where><And><Eq><FieldRef Name=\"Visible\" /><Value Type=\"Boolean\">1</Value></Eq><Eq><FieldRef Name=\"SolutionType\" /><Value Type=\"Choice\">" + qsSolutionType + "</Value></Eq></And></Where><OrderBy><FieldRef Name=\"Title\" Ascending=\"True\" /></OrderBy>]]>";
                }
            }

            var strData = "<Data>" +
                    "<Param key=\"WebSvcName\">List</Param>" +
                    "<Param key=\"WebSvcMethod\">GetListItems</Param>" +
                    "<Param key=\"ListName\">Solutions</Param>" +
                    "<Param key=\"ViewName\"></Param>" +
                    "<Param key=\"Query\">" + query + "</Param>" +
                    "<Param key=\"ViewFields\"></Param>" +
                    "<Param key=\"RowLimit\">100000</Param>" +
                    "<Param key=\"QueryOptions\"></Param>" +
                    "<Param key=\"WebId\"></Param>" +
                    "<Param key=\"CompLevels\">" + compLevels + "</Param>" +
                    "<Param key=\"TemplateType\">" + qsTemplateType + "</Param>" +
                    "<Param key=\"SolutionType\">" + qsSolutionType + "</Param>" +
                    "</Data>";


            xmlhttp.open("POST", solutionStoreProxyUrl, true);
            xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4) {
                    if (xmlhttp.status == 200) {
                        try {
                            var oJson = eval('(' + $$.UnescapeHTMLtoXML(xmlhttp.responseText) + ')');
                            if (oJson.error != null) {
                                window.alert(oJson.error);
                                if (defaultCreateNew == 'local' || defaultCreateNew == 'existing') {
                                    $('#linkNewWorkspace').trigger('click');
                                }
                                else {
                                    SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.commonModalDialogClose', 0, currentWebUrl);
                                }
                            }
                            else {
                                $$.AppendOnlineTemplateDivs(oJson);
                                $$.GetOnlineTempsFilters();
                                $$.DisplayEPMLiveTemps();
                            }
                        }
                        catch (e) {
                            window.alert(e.Message);
                        }
                    }
                }
            };
            xmlhttp.send("data=" + strData);
        }
        else {
            if ($('#divLoad_LoadingOnlineTemps').css('display') == 'block') {
                $$.ReturnFromLoadingOnlineTemps();
            }
        }
    }

    $$.ChangeToLoadingScreen = function () {
        $('.divLeft').css('display', 'none');
        $('.divRight').css('display', 'none');
        $('.txtAvailableTemplates').css('display', 'none');
        $('#divTemplatesHolder').css('display', 'none');
        $('#divOnlineTempsHolder').css('display', 'none');
        $('#divSolGalTempsHolder').css('display', 'none');
        $('#divMoreOptContainer').css('display', 'none');
        $('#divExistingWorkspaceContainer').css('display', 'none');
        $('#divEmptyGalleryHTML').css('display', 'none');

        $('#divLoad_LoadingOnlineTemps').css('display', 'block');
    }

    $$.ReturnFromLoadingOnlineTemps = function () {
        // clear loader div
        $('#divLoad_LoadingOnlineTemps').css('display', 'none');

        // left panel visibility
        $('.divLeft').css('display', '');
        $('.divRight').css('display', '');

        $('.divEPMLiveTempFilters').css('display', 'none');
        //$('.categoryfilter').css('display', 'none');
        //$('.onlineCategoryfilter').css('display', 'none');


        $('.divFilterBy').css('display', 'none');
        $('.divSolGalFilters').css('display', 'none');

        // center div visibility
        $('.txtAvailableTemplates').css('display', '');
        $('#divTemplatesHolder').css('display', 'none');
        $('#divOnlineTempsHolder').css('display', 'block');
        $('#divSolGalTempsHolder').css('display', 'none');
        $('#divMoreOptContainer').css('display', 'none');
        $('#divExistingWorkspaceContainer').css('display', 'none');
        $('#divEmptyGalleryHTML').css('display', 'none');

        $('.imgTemplateIcon').css('display', '');
        $('.templateImage').css('display', '');

        $$.ConfigureScrollbar($('#divOnlineTempsHolder'));
        $$.WireOnlineTempDivWithLogic();
        $$.ClickFirstTemp();

        // click all categories and types
        $('#lnkOnlineAllTypes').trigger('click');
        $('#lnkOnlineAllCategories').trigger('click');
    }

    $$.GetOnlineTempsFilters = function () {
        //    var xmlhttp = false;
        //    if (navigator.appName == 'Microsoft Internet Explorer') {
        //        xmlhttp = new ActiveXObject('Microsoft.XMLHTTP');
        //    }
        //    else {
        //        xmlhttp = new XMLHttpRequest();
        //    }

        //    var strData = "<Data>" +
        //                    "<Param key=\"WebSvcName\">List</Param>" +
        //                    "<Param key=\"WebSvcMethod\">GetList</Param>" +
        //                    "<Param key=\"ListName\">Solutions</Param>" +
        //                    "</Data>";

        //    xmlhttp.open("POST", solutionStoreProxyUrl, true);
        //    xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        //    xmlhttp.onreadystatechange = function () {
        //        if (xmlhttp.readyState == 4) {
        //            if (xmlhttp.status == 200) {
        //                var oJson = eval('(' + UnescapeHTMLtoXML(xmlhttp.responseText) + ')');
        //                AppendOnlineFilters(oJson);
        //                isOnlineTempsLoaded = 'true';
        //                if (newItemNameLwrCs != 'template') {
        //                    $('#linkNewWorkspace').trigger('click');
        //                    $('#lnkOnlineTemps').trigger('click');
        //                }
        //                else {
        //                    $('#lnkNewTempFrmOnline').trigger('click');
        //                }

        //            }
        //        }
        //    };
        //    xmlhttp.send("data=" + strData);

        var onlineTempCategories = new Array();
        var catIndex = 0;
        $('#divOnlineTempsHolder').find('.divOnlineTempHolder').find('input[id="templateCategories"]').each(function () {
            var cats = $(this).val().split(',');
            if (cats.length > 0) {
                for (var i in cats) {
                    // jQuery Utility function to check if value exists in array
                    if ($.inArray(cats[i].trim(), onlineTempCategories) === -1) {
                        onlineTempCategories[catIndex] = cats[i].trim();
                        catIndex++;
                    }
                }
            }
        });
        var onlineTempTypes = new Array();
        var typeIndex = 0;
        $('#divOnlineTempsHolder').find('.divOnlineTempHolder').find('input[id="templateType"]').each(function () {
            var types = $(this).val().split(',');
            if (types.length > 0) {
                for (var i in types) {
                    // jQuery Utility function to check if value exists in array
                    if ($.inArray(types[i].trim(), onlineTempTypes) === -1) {
                        onlineTempTypes[i] = types[i].trim();
                        typeIndex++;
                    }
                }
            }
        });
        $$.AppendOnlineFilters(onlineTempTypes, onlineTempCategories);
        isOnlineTempsLoaded = 'true';
        if (newItemNameLwrCs != 'template') {
            $('#linkNewWorkspace').trigger('click');
            $('#lnkOnlineTemps').trigger('click');
        }
        else {
            $('#lnkNewTempFrmOnline').trigger('click');
        }

    }

    $$.GetTempGalFilters = function () {
        var tempGalTempsTypes = new Array();
        var typeIndex = 0;
        $('#divTemplatesHolder').find('.divTemplateHolder').find('input[id="templateType"]').each(function () {
            var types = $(this).val().split(',');
            if (types.length > 0) {
                for (var i in types) {
                    // jQuery Utility function to check if value exists in array
                    if ($.inArray(types[i].trim(), tempGalTempsTypes) === -1) {
                        tempGalTempsTypes[i] = types[i].trim();
                        typeIndex++;
                    }
                }
            }
        });
        var tempGalTempsCategories = new Array();
        var catIndex = 0;
        $('#divTemplatesHolder').find('.divTemplateHolder').find('input[id="templateCategories"]').each(function () {
            var cats = $(this).val().split(',');
            if (cats.length > 0) {
                for (var i in cats) {
                    // jQuery Utility function to check if value exists in array
                    if ($.inArray(cats[i].trim(), tempGalTempsCategories) === -1) {
                        tempGalTempsCategories[catIndex] = cats[i].trim();
                        catIndex++;
                    }
                }
            }
        });
        $$.AppendTempGalFilters(tempGalTempsTypes, tempGalTempsCategories);
        if (newItemNameLwrCs != 'template' && defaultCreateNew != 'online') {
            $('#linkNewWorkspace').trigger('click');
            $('#lnkInstalledTemps').trigger('click');
        }
        else {
            $('#lnkNewTempFrmLocal').trigger('click');
        }
    }

    $$.GetSolGalTempsFilters = function () {
        //    var solGalTempsTypes = new Array();
        //    var typeIndex = 0;
        //    $('#divSolGalTempsHolder').find('.divTemplateHolder').find('input[id="templateType"]').each(function () {
        //        var types = $(this).val().split(',');
        //        for (var i in types) {
        //            // jQuery Utility function to check if value exists in array
        //            if ($.inArray(types[i].trim(), solGalTempsTypes) === -1) {
        //                solGalTempsTypes[i] = types[i].trim();
        //                typeIndex++;
        //            }
        //        }
        //    });
        //    var solGalTempsCategories = new Array();
        //    var catIndex = 0;
        var solGalTempsCategories = new Array();
        var catIndex = 0;
        $('#divSolGalTempsHolder').find('.divTemplateHolder').find('input[id="templateCategories"]').each(function () {
            var cats = $(this).val().split(',');
            if (cats.length > 0) {
                for (var i in cats) {
                    // jQuery Utility function to check if value exists in array
                    if ($.inArray(cats[i].trim(), solGalTempsCategories) === -1) {
                        solGalTempsCategories[catIndex] = cats[i].trim();
                        catIndex++;
                    }
                }
            }
        });
        $$.AppendSolGalFilters(solGalTempsCategories);
    }

    $$.SelectAllCategory = function (browseFromType) {
        switch (browseFromType) {
            case 'local':
                $('#lnkTempGalAllCategories').trigger('click');
                break;
            case 'solgal':
                $('#lnkSolGalAllCategories').trigger('click');
                break;
        }
    }

    $$.grdExistingWorkSpaceChange = function (url) {
        if ($('#linkExistingWorkspace').hasClass('selectedLink')) {
            $('#hdnParentWebUrl').val(url);
        }

        if ($('#linkNewWorkspace').hasClass('selectedLink') &&
        $('#lnkFromExistingWorkspace').hasClass('selectedLink')) {
            $('#hdnTargetWebUrl').val(url);
        }

        if ($('#lnkNewTempFrmExisting').hasClass('selectedLink')) {
            $('#hdnTargetWebUrl').val(url);
        }

        $('div.txtExistingWorkspaceUrl').empty;
        if (url.length > 0) {
            $('div.txtExistingWorkspaceUrl').text(url);
        }

    }

    $$.createWorkspaceClearLoader = function (id) {
        window.document.getElementById("loadinggrid").style.display = "none";
        window.document.getElementById("htmlGrdExistingWorkspace").style.display = "";
        window.grdExistingWorkSpace.cellWidthType = 'px';
        window.grdExistingWorkSpace.setColWidth(0, '180');
        window.grdExistingWorkSpace.setColWidth(1, '220');
        $$.CheckUserCreateSubSitePerm();
    }

    $$.CheckUserCreateSubSitePerm = function () {
        if (hasCreateSubSitePerm == 'False' || hasCreateSubSitePerm == 'false') {
            window.alert('You don\'t have permission to create subsites on selected workspace, please select a different parent site.');
            $('#lnkFromExistingWorkspace').trigger('click');
            $('#btnMoreLessOpt').trigger('click');
            window.setTimeout("$('#lnkChangeUrlPopup').trigger('click')", 1250);
        }
    }

    $$.UnescapeHTMLtoXML = function (escapedHTML) {
        var d = document.createElement("div");
        d.innerHTML = escapedHTML;
        if (!d.innerText) {
            return d.textContent;
        } else {
            return d.innerText;
        }
    }

    $$.UpdateSelectedTempCat = function (cat) {
        $('#hdnTemplateCategory').val(cat);
    }

    $$.UpdateSelectedTempType = function (type) {
        $('#hdnTemplateType').val(type);
    }

    //function SwitchToMoreInfo() {
    //    var options;
    //    var tempId = $('#hdnTemplateId').val();
    //    if ($('#lnkOnlineTemps').hasClass('selectedLink') ||
    //        $('#lnkNewTempFrmOnline').hasClass('selectedLink')) {
    //        options = {
    //            url: moreInfoUrl + 'tempId=' + tempId + '&isonline=true&soltype=' + qsSolutionType + '&templatetype=' + qsTemplateType,
    //            title: 'More Information',
    //            allowMaximize: true,
    //            width: 650,
    //            height: 500
    //        };
    //    }
    //    else {
    //        options = {
    //            url: moreInfoUrl + 'tempId=' + tempId,
    //            title: 'More Information',
    //            allowMaximize: true,
    //            width: 650,
    //            height: 500
    //        };
    //    }

    //    SP.UI.ModalDialog.showModalDialog(options);
    //}

    $$.SwitchToMoreInfo = function () {
        var options;
        var tempId = $('#hdnTemplateId').val();
        if ($('#lnkOnlineTemps').hasClass('selectedLink') ||
        $('#lnkNewTempFrmOnline').hasClass('selectedLink')) {
            options = {
                url: moreInfoUrl + 'tempId=' + tempId + '&isonline=true&soltype=' + qsSolutionType + '&templatetype=' + qsTemplateType,
                title: 'More Information',
                allowMaximize: true,
                width: 650,
                height: 500
            };
        }
        else {
            options = {
                url: moreInfoUrl + 'tempId=' + tempId,
                title: 'More Information',
                allowMaximize: true,
                width: 650,
                height: 500
            };
        }
        SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
        return false;
    }


    $$.ConfigureScrollbar = function (control) {

        //        $('.slimScrollDiv').each(function () {
        //            $(this).replaceWith($(this).html());
        //        });

        $('.slimScrollDiv').css('display', 'none');

        var slimScrollDiv = control.parent()[0];
        if (slimScrollDiv.className !== 'slimScrollDiv') {
            control.slimScroll({ height: '510px' });
        }

        $(control.parent()[0]).css('display', 'block');

    };

    $$.RemoveScrollbar = function () {
        //        $('.slimScrollDiv').each(function () {
        //            $(this).replaceWith($(this).html());
        //        });

        $('.slimScrollDiv').css('display', 'none');
    };

    $$.SwitchToCreateNewWorkspaceView = function () {
        // manage center div visibility
        $('#divOnlineTempsHolder').css('display', 'none');
        $('#divTemplatesHolder').css('display', 'none');
        $('#divSolGalTempsHolder').css('display', 'none');
        $('#divMoreOptContainer').css('display', 'none');
        $('#divMoreInfoContainer').css('display', 'none');
        $('#divExistingWorkspaceContainer').css('display', 'none');
        $('#divEmptyGalleryHTML').css('display', 'none');

        $('#btnMoreLessOpt').val("More Options");

        $('.divCreateNewWorkspaceFrom').css('display', 'block');

        if (window.newItemNameLwrCs == "template") {
            $('.divFilterBy').css('display', 'none');
        }

        $('#hdnParentWebUrl').val(parentWebUrl);
        $$.ChangeRightPanelVisibility();
    }

    $$.SwitchToExistingWorkspace = function () {
        $$.RemoveScrollbar();

        // manage center div visibility
        $('#divTemplatesHolder').css('display', 'none');
        $('#divOnlineTempsHolder').css('display', 'none');
        $('#divSolGalTempsHolder').css('display', 'none');
        $('#divMoreOptContainer').css('display', 'none');
        $('#divExistingWorkspaceContainer').css('display', 'block');
        $('#divEmptyGalleryHTML').css('display', 'none');

        $('.txtAvailableTemplates').css('display', 'none');

        $('.divRight').css('display', '');

        $('.imgTemplateIcon').css('display', 'none');
        $('.templateImage').css('display', 'none');

        $('.txtTemplateTitle').css('display', 'none');
        $('.txtTemplateType').css('display', 'none');
        $('.txtTemplateCategory').css('display', 'none');
        $('.txtDescription').css('display', 'none');

        $('#aMoreInfo').css('display', 'none');
        $('#btnMoreLessOpt').css('display', 'none');
        $('#btnMoreInfo').css('display', 'none');
        $('.divSalesInfo').css('display', 'none');

        $('.divCreateNewWorkspaceFrom').css('display', 'none');
        $('.divFilterBy').css('display', 'none');
        $('.divEPMLiveTempFilters').css('display', 'none');

        var originalText = $('#spanWorkspaceTitle').text();
        if (newItemNameLwrCs == "workspace") {
            $('#spanWorkspaceTitle').text('Project Name');
        }

        $('#hdnParentWebUrl').val("");
        $$.ChangeRightPanelVisibility();
    }

    $$.DisplayEPMLiveTemps = function () {
        // clear loader
        $('#divLoad_LoadingOnlineTemps').css('display', 'none');

        // show all columns
        $('.divLeft').css('display', 'block');
        $('.divRight').css('display', 'block');

        // manage center div visibility
        $('.txtAvailableTemplates').css('display', '');
        $('#divSolGalTempsHolder').css('display', 'none');
        $('#divOnlineTempsHolder').css('display', 'block');
        $('#divTemplatesHolder').css('display', 'none');
        $('#divMoreOptContainer').css('display', 'none');
        $('#divMoreInfoContainer').css('display', 'none');
        $('#divExistingWorkspaceContainer').css('display', 'none');
        $('#divEmptyGalleryHTML').css('display', 'none');

        $('.imgTemplateIcon').css('display', '');
        $('.templateImage').css('display', '');

        $('#btnMoreLessOpt').val("More Options");

        $('.divEPMLiveTempFilters').css('display', 'none');
        $('.divFilterBy').css('display', 'none');
        $('.divSolGalFilters').css('display', 'none');

        $('#hdnParentWebUrl').val(parentWebUrl);

        $$.ConfigureScrollbar($('#divOnlineTempsHolder'));
        $$.WireOnlineTempDivWithLogic();
        $$.ClickFirstTemp();

        $('#aMoreInfo').css('display', '');

        if ($('#lnkOnlineAllTypes').length > 0) {
            $('#lnkOnlineAllTypes').trigger('click');
        }
        else {
            $('.onlineTypeFilter:first').trigger('click');
        }

        $('#lnkOnlineAllCategories').trigger('click');

        if (newItemNameLwrCs == "workspace") {
            $('#spanWorkspaceTitle').text('Workspace Name');
        }

        //    if (newItemNameLwrCs != "template") {
        //        $('.divEPMLiveTempFilters').css('display', 'none');
        //    }
        //    else {
        //        $('.onlineCategoryFilter').css('display', 'none');
        //        $('.categoryfilter').css('display', 'none');
        //    }
    }

    $$.DisplaySolGalTemps = function () {
        // clear loader
        $('#divLoad_LoadingOnlineTemps').css('display', 'none');

        // show all columns
        $('.divLeft').css('display', '');
        $('.divRight').css('display', '');

        // manage center div visiblity
        $('.txtAvailableTemplates').css('display', '');
        $('#divSolGalTempsHolder').css('display', 'block');
        $('#divOnlineTempsHolder').css('display', 'none');
        $('#divTemplatesHolder').css('display', 'none');
        $('#divMoreOptContainer').css('display', 'none');
        $('#divMoreInfoContainer').css('display', 'none');
        $('#divExistingWorkspaceContainer').css('display', 'none');
        $('#divEmptyGalleryHTML').css('display', 'none');

        $('.imgTemplateIcon').css('display', '');
        $('.templateImage').css('display', '');

        $('#btnMoreLessOpt').val("More Options");

        $('.divEPMLiveTempFilters').css('display', 'none');
        $('.divFilterBy').css('display', 'none');
        $('.divSolGalFilters').css('display', 'none');

        $$.ConfigureScrollbar($('#divSolGalTempsHolder'));
        $$.WireSolGalTempDivWithLogic();
        $('#aMoreInfo').css('display', '');

        $('#hdnParentWebUrl').val(parentWebUrl);
        $('#lnkSolGalAllTypes').trigger('click');
        $('#lnkSolGalAllCategories').trigger('click');

        if (newItemNameLwrCs == "workspace") {
            $('#spanWorkspaceTitle').text('Workspace Name');
        }

        $$.ChangeRightPanelVisibility();

        $('#aMoreInfo').css('display', 'none');

        //    if (newItemNameLwrCs != "template") {
        //        $('.divSolGalFilters').css('display', 'none');
        //    }
        //    else {
        //        $('.solGalCategoryFilter').css('display', 'none');

        //    }
    }

    $$.DisplayInstalledTemps = function () {
        // clear loader
        $('#divLoad_LoadingOnlineTemps').css('display', 'none');

        // show all columns
        $('.divLeft').css('display', '');
        $('.divRight').css('display', '');

        // manage center div visibility
        $('.txtAvailableTemplates').css('display', '');
        $('#divOnlineTempsHolder').css('display', 'none');
        $('#divTemplatesHolder').css('display', 'block');
        $('#divSolGalTempsHolder').css('display', 'none');
        $('#divMoreOptContainer').css('display', 'none');
        $('#divMoreInfoContainer').css('display', 'none');
        $('#divExistingWorkspaceContainer').css('display', 'none');
        $('#divEmptyGalleryHTML').css('display', 'none');

        // change more option button text
        $('#btnMoreLessOpt').val("More Options");

        // manage left panel visibility
        $('.imgTemplateIcon').css('display', '');
        $('.templateImage').css('display', '');
        $('.divCreateNewWorkspaceFrom').css('display', 'block');

        $('#aMoreInfo').css('display', '');

        $$.ConfigureScrollbar($('#divTemplatesHolder'));
        $$.WireTempDivWithLogic();

        if ($('.divTemplatesHolder .divTemplateHolder:visible').length == 0) {
            // show a html that does advertising/explanation or whatever
            $('#divEmptyGalleryHTML').css('display', '');
            $$.ConfigureScrollbar($('#divEmptyGalleryHTML'));
            // hide all the filters
            $('#divTemplatesHolder').css('display', 'none');
            $('.divFilterBy').css('display', 'none');
            $('.divEPMLiveTempFilters').css('display', 'none');
            $('.divSolGalFilters').css('display', 'none');
            $('.divRight').css('display', 'none');
        }
        else {
            $('.divFilterBy').css('display', 'none');
            $('.divEPMLiveTempFilters').css('display', 'none');
            $('.divSolGalFilters').css('display', 'none');
            $('#hdnParentWebUrl').val(parentWebUrl);

            if ($('#lnkAllTypes').length > 0) {
                $('#lnkAllTypes').trigger('click');
            } else {
                $('.typefilter:first').trigger('click');
            }

            $('#lnkAllCategories').trigger('click');
            $('.divRight').css('display', '');
            $('.txtExistingWorkspaceHeading').css('display', 'none');
            $('.txtExistingWorkspaceUrl').css('display', 'none');
            $('.divSalesInfo').css('display', 'none');
        }

        if (newItemNameLwrCs == "workspace") {
            $('#spanWorkspaceTitle').text('Workspace Name');
        }

        //    if (newItemNameLwrCs != "template") {
        //        $('.divFilterBy').css('display', 'none');
        //    }
        //    else {
        //        $('.onlineCategoryFilter').css('display', 'none');
        //        $('.categoryfilter').css('display', 'none');
        //    }
    }

    $$.SwitchToCreateFromExistingWorkspace = function () {
        // clear loader
        $('#divLoad_LoadingOnlineTemps').css('display', 'none');

        // clean up slimscroll objects
        $$.RemoveScrollbar();

        // manage left div visibility
        $('.divFilterBy').css('display', 'none');
        $('.divEPMLiveTempFilters').css('display', 'none');
        $('.divSolGalFilters').css('display', 'none');

        // manage center div visibility
        $('.txtAvailableTemplates').css('display', 'none');
        $('#divTemplatesHolder').css('display', 'none');
        $('#divOnlineTempsHolder').css('display', 'none');
        $('#divSolGalTempsHolder').css('display', 'none');
        $('#divMoreOptContainer').css('display', 'none');
        $('#divExistingWorkspaceContainer').css('display', 'block');
        $('#divEmptyGalleryHTML').css('display', 'none');

        // manage right div visibility
        $('.divRight').css('display', '');

        $('.imgTemplateIcon').css('display', 'none');
        $('.templateImage').css('display', 'none');
        $('.txtTemplateTitle').css('display', 'none');
        $('.txtTemplateType').css('display', 'none');
        $('.txtTemplateCategory').css('display', 'none');
        $('.txtDescription').css('display', 'none');

        $('#aMoreInfo').css('display', 'none');
        $('#btnMoreInfo').css('display', 'none');
        $('.divSalesInfo').css('display', 'none');

        // set more option button text
        $('#btnMoreLessOpt').val("More Options");

        $('#hdnParentWebUrl').val("");

        $$.ChangeRightPanelVisibility();

        if (newItemNameLwrCs == "workspace") {
            $('#spanWorkspaceTitle').text('Workspace Name');
        }
    }

    $$.SwitchToMoreOpt = function () {
        // manage center div visibility
        $('#divTemplatesHolder').css('display', 'none');
        $('#divOnlineTempsHolder').css('display', 'none');
        $('#divSolGalTempsHolder').css('display', 'none');
        $('#divMoreOptContainer').css('display', '');
        $('#divMoreInfoContainer').css('display', 'none');
        $('#divExistingWorkspaceContainer').css('display', 'none');
        $('#divEmptyGalleryHTML').css('display', 'none');

        $('.txtAvailableTemplates').css('display', 'none');

        $('.divFilter').css('display', 'none');

        if ($('#lnkFromExistingWorkspace').hasClass('selectedLink') ||
        $('#lnkNewTempFrmExisting').hasClass('selectedLink') ||
        $('#lnkNewTempFrmLocal').hasClass('selectedLink')) {
            $('#' + includeContentClientId).css('display', '');
        }
        else {
            $('#' + includeContentClientId).css('display', 'none');
        }
    }

    $$.FilterTempGalTemplates = function () {
        var cat = $('#hdnTemplateCategory').val();
        var type = $('#hdnTemplateType').val()

        if ($('#lnkInstalledTemps').hasClass('selectedLink') || $('#lnkNewTempFrmLocal').hasClass('selectedLink')) {
            if (cat == 'All Categories' && type == 'All Types') {
                $('#divTemplatesHolder').find('.divTemplateHolder').css('display', 'block');
            }
            else if (cat == 'All Categories' && type != 'All Types') {
                // hide all templates
                $('#divTemplatesHolder').find('.divTemplateHolder').css('display', 'none');
                // display templates by type
                $('input[id="templateType"][value*="' + type + '"]').parent().css('display', 'block');
            }
            else if (cat != 'All Categories' && type == 'All Types') {
                // hide all templates
                $('#divTemplatesHolder').find('.divTemplateHolder').css('display', 'none');
                // display templates by category
                $('input[id="templateCategories"][value*="' + cat + '"]').parent().css('display', 'block');
            }
            else if (cat != 'All Categories' && type != 'All Types') {
                // hide all templates
                $('#divTemplatesHolder').find('.divTemplateHolder').css('display', 'none');
                // display template by category and type

                var qualifiedCats = $('input[id="templateCategories"][value*="' + cat + '"]').parent();
                qualifiedCats.find('input[id="templateType"][value*="' + type + '"]').parent().css('display', 'block');
            }
        }
        $$.ChangeRightPanelVisibility();
        $$.ClickFirstTemp();

        //$('.categoryfilter').css('display', 'none');
    }

    $$.FilterOnlineTemplates = function () {
        var cat = $('#hdnTemplateCategory').val();
        var type = $('#hdnTemplateType').val()

        if (cat == 'All Categories' && type == 'All Types') {
            $('#divOnlineTempsHolder').find('.divOnlineTempHolder').css('display', 'block');
        }
        else if (cat == 'All Categories' && type != 'All Types') {
            // hide all templates
            $('#divOnlineTempsHolder').find('.divOnlineTempHolder').css('display', 'none');
            // display templates by type
            $('input[id="templateType"][value*="' + type + '"]').parent().css('display', 'block');
        }
        else if (cat != 'All Categories' && type == 'All Types') {
            // hide all templates
            $('#divOnlineTempsHolder').find('.divOnlineTempHolder').css('display', 'none');
            // display templates by category
            $('input[id="templateCategories"][value*="' + cat + '"]').parent().css('display', 'block');
        }
        else if (cat != 'All Categories' && type != 'All Types') {
            // hide all templates
            $('#divOnlineTempsHolder').find('.divOnlineTempHolder').css('display', 'none');
            // display template by category and type
            var qualifiedCats = $('input[id="templateCategories"][value*="' + cat + '"]').parent();
            qualifiedCats.find('input[id="templateType"][value*="' + type + '"]').parent().css('display', 'block');
        }
        $$.ChangeRightPanelVisibility();
        $$.ClickFirstTemp();
        //$('.categoryfilter').css('display', 'none');
    }

    $$.FilterSolGalTemplates = function () {
        var cat = $('#hdnTemplateCategory').val();
        var type = $('#hdnTemplateType').val()

        if (cat == 'All Categories' && type == 'All Types') {
            $('#divSolGalTempsHolder').find('.divTemplateHolder').css('display', 'block');
        }
        else if (cat == 'All Categories' && type != 'All Types') {
            // hide all templates
            $('#divSolGalTempsHolder').find('.divTemplateHolder').css('display', 'none');
            // display templates by type
            $('input[id="templateType"][value*="' + type + '"]').parent().css('display', 'block');
        }
        else if (cat != 'All Categories' && type == 'All Types') {
            // hide all templates
            $('#divSolGalTempsHolder').find('.divTemplateHolder').css('display', 'none');
            // display templates by category
            $('input[id="templateCategories"][value*="' + cat + '"]').parent().css('display', 'block');
        }
        else if (cat != 'All Categories' && type != 'All Types') {
            // hide all templates
            $('#divSolGalTempsHolder').find('.divTemplateHolder').css('display', 'none');
            // display template by category and type
            var qualifiedCats = $('input[id="templateCategories"][value*="' + cat + '"]').parent();
            qualifiedCats.find('input[id="templateType"][value*="' + type + '"]').parent().css('display', 'block');
        }
        $$.ChangeRightPanelVisibility();
        $$.ClickFirstTemp();
        //$('.categoryfilter').css('display', 'none');
    }

    $$.ChangeRightPanelVisibility = function () {
        // When creating project, workspace
        // =========================================
        // user trying to create new workspace
        if ($('#linkNewWorkspace').hasClass('selectedLink')) {
            // hide existing workspace divs
            $('.divRight div').css('display', 'block');
            $('.divRight input').css('display', 'block');
            $('.txtExistingWorkspaceHeading').css('display', 'none');
            $('.txtExistingWorkspaceUrl').css('display', 'none');

            // user clicks on local gallery 
            if ($('#lnkInstalledTemps').hasClass('selectedLink')) {
                if ($('.divTemplatesHolder .divTemplateHolder:visible').length == 0) {
                    $('.divRight div').each(function () {
                        if (!($(this).className == 'divSearchBox' || $(this).attr('id') == 'tbFreeSearch')) {
                            $(this).css('display', 'none');
                        }
                    });
                    $('.divRight input').css('display', 'none');
                }
                else {
                    $('.divRight div').css('display', 'block');
                    $('.divRight input').css('display', 'block');
                    $('.divSalesInfo').css('display', 'none');
                    $('.txtExistingWorkspaceHeading').css('display', 'none');
                    $('.txtExistingWorkspaceUrl').css('display', 'none');
                }
            }
            // user clicks online gallery
            else if ($('#lnkOnlineTemps').hasClass('selectedLink')) {
                if ($('.divOnlineTempsHolder .divOnlineTempHolder:visible').length == 0) {
                    $('.divRight div').each(function () {
                        if (!($(this).className == 'divSearchBox' || $(this).attr('id') == 'tbFreeSearch')) {
                            $(this).css('display', 'none');
                        }
                    });
                    $('.divRight input').css('display', 'none');

                }
                else {
                    $('.divRight div').css('display', 'block');
                    $('.divRight input').css('display', 'block');
                    $('.divSalesInfo').css('display', 'none');
                    $('.txtExistingWorkspaceHeading').css('display', 'none');
                    $('.txtExistingWorkspaceUrl').css('display', 'none');
                }
            }
            // user clicks from existing
            else if ($('#lnkFromExistingWorkspace').hasClass('selectedLink')) {
                $('.divRight div').css('display', 'block');
                $('.txtTemplateTitle').css('display', 'none');
                $('.txtTemplateType').css('display', 'none');
                $('.txtTemplateCategory').css('display', 'none');
                $('.txtDescription').css('display', 'none');
                $('.divRight input').css('display', 'block');
                //$('#btnMoreLessOpt').css('display', 'none');
                $('#btnMoreInfo').css('display', 'none');
                $('.divSalesInfo').css('display', 'none');
                $('.txtExistingWorkspaceHeading').css('display', 'block');
                $('.txtExistingWorkspaceUrl').css('display', 'block');
            }
        }
        // user trying to create new project in existing workspace
        else if ($('#linkExistingWorkspace').hasClass('selectedLink')) {
            $('.divRight div').css('display', 'block');
            $('.txtTemplateTitle').css('display', 'none');
            $('.txtTemplateType').css('display', 'none');
            $('.txtTemplateCategory').css('display', 'none');
            $('.txtDescription').css('display', 'none');
            $('.divRight input').css('display', 'block');
            $('#btnMoreLessOpt').css('display', 'none');
            $('#btnMoreInfo').css('display', 'none');
            $('.divSalesInfo').css('display', 'none');
            $('.txtExistingWorkspaceHeading').css('display', 'block');
            $('.txtExistingWorkspaceUrl').css('display', 'block');
        }

        // When creating templates
        // =======================================    
        // manage visiblity when creating templates
        if ($('#lnkNewTempFrmOnline').hasClass('selectedLink')) {
            $('.divRight div').css('display', 'block');
            $('.divRight input').css('display', 'block');
            $('.divSalesInfo').css('display', 'none');
            $('.txtExistingWorkspaceHeading').css('display', 'none');
            $('.txtExistingWorkspaceUrl').css('display', 'none');
        }
        else if ($('#lnkNewTempFrmLocal').hasClass('selectedLink')) {
            if ($('.divTemplatesHolder .divTemplateHolder:visible').length == 0) {
                $('.divRight div').each(function () {
                    if (!($(this).className == 'divSearchBox' || $(this).attr('id') == 'tbFreeSearch')) {
                        $(this).css('display', 'none');
                    }
                });
                $('.divRight input').css('display', 'none');
            }
            else {
                $('.divRight div').css('display', 'block');
                $('.divRight input').css('display', 'block');
                $('.divSalesInfo').css('display', 'none');
                $('.txtExistingWorkspaceHeading').css('display', 'none');
                $('.txtExistingWorkspaceUrl').css('display', 'none');
            }
        }
        else if ($('#lnkNewTempFrmSolGal').hasClass('selectedLink')) {
            if ($('#divSolGalTempsHolder .divTemplateHolder:visible').length == 0) {
                $('.divRight div').each(function () {
                    if (!($(this).className == 'divSearchBox' || $(this).attr('id') == 'tbFreeSearch')) {
                        $(this).css('display', 'none');
                    }
                });
                $('.divRight input').css('display', 'none');
            }
            else {
                $('.divRight div').css('display', 'block');
                $('.divRight input').css('display', 'block');
                $('.divSalesInfo').css('display', 'none');
                $('.txtExistingWorkspaceHeading').css('display', 'none');
                $('.txtExistingWorkspaceUrl').css('display', 'none');
                //$('#btnMoreLessOpt').css('display', 'none');
                $('#btnMoreInfo').css('display', 'none');
            }
        }
        else if ($('#lnkNewTempFrmExisting').hasClass('selectedLink')) {
            $('.divRight div').css('display', 'block');
            $('.txtTemplateTitle').css('display', 'none');
            $('.txtTemplateType').css('display', 'none');
            $('.txtTemplateCategory').css('display', 'none');
            $('.txtDescription').css('display', 'none');
            $('.divRight input').css('display', 'block');
            $('#btnMoreInfo').css('display', 'none');
            $('.divSalesInfo').css('display', 'none');
            $('.txtExistingWorkspaceHeading').css('display', 'block');
            $('.txtExistingWorkspaceUrl').css('display', 'block');
        }
    }
})(window.epmLiveCreateWorkspace = window.epmLiveCreateWorkspace || {}, window.jQuery);