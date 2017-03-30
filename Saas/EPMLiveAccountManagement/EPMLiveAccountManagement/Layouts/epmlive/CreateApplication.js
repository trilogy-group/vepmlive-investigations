/// <reference path="https://ajax.googleapis.com/ajax/libs/jquery/1.5.2/jquery.min.js" />

(function ($$, $) {
    var searchHandler;

    $(function () {
        InitUILogic();
        GetApplicationTemps();
        $$.FreeSearchHandler.InitVals('lnkOnlineAllCategories', 'divOnlineTempsHolder', 'divOnlineTempHolder', 'divEPMLiveTempFilters');
        $$.FreeSearchHandler.RegisterControlLogic();
    });

    $$.FreeSearchHandler = {

        _returnLeftDivLinkID: null,
        _targetSearchPanelID: null,
        _targetTemplateHolderClass: null,
        _targetLeftDivFilterClass: null,

        InitVals: function (rLnkID, pnlID, className, leftDivFilterClass) {
            $$._returnLeftDivLinkID = rLnkID,
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
            ChangeRightPanelVisibility();
            ClickFirstTemp();

        },

        InitFreeSearchLogic: function () {
            $('#tbFreeSearch').keyup(function () {
                var searchText = $('#tbFreeSearch').val().trim();
                $$.FreeSearchHandler.FilterTemplatesByFreeSearch(searchText);

                //$('.divEPMLiveTempFilters').css('display', 'none');
                $('.' + $$._targetLeftDivFilterClass).css('display', 'none');

                $('#divfreeSearchFilter').css('display', '');
                $('.divSearchBox').css('display', '');
                $('#tbFreeSearch').css('display', '');
                $('#lnkBackToAllItems').css('display', '');
                $('#txtFreeSearch').text('Search results for "' + searchText + '"');
                $('#txtFreeSearch').css('display', '');
                $('#tbFreeSearch').focus();

                return false;
            });
        },

        InitBackToAllItemsLnkLogic: function () {
            $('#lnkBackToAllItems').click(function () {
                $('#divfreeSearchFilter').css('display', 'none');
                $('#txtFreeSearch').css('display', 'none');
                $('#lnkBackToAllItems').css('display', 'none');
                $('.' + $$._targetLeftDivFilterClass).css('display', '');
                $('#' + $$._returnLeftDivLinkID).trigger('click');

                return false;
            });
        },

        RegisterControlLogic: function () {
            $$.FreeSearchHandler.InitFreeSearchLogic();
            $$.FreeSearchHandler.InitBackToAllItemsLnkLogic();
        }
    };

    ConfigureScrollbar = function (control) {

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

    RemoveScrollbar = function () {
        //        $('.slimScrollDiv').each(function () {
        //            $(this).replaceWith($(this).html());
        //        });

        $('.slimScrollDiv').css('display', 'none');
    };

    function InitUILogic() {
        InitMoreInfoLinkLogic();
        InitMoreOptionBtnLogic();
        BindAutoTypeEvents();
    }

    function InitMoreInfoLinkLogic() {
        $('#aMoreInfo')
        .click(function () {
            SwitchToMoreInfo();
            return false;
        })
        .hover(function () {
            $(this).addClass('hoverLink');
        },
            function () {
                $(this).removeClass('hoverLink');
            });
    }

    function SwitchToMoreInfo() {
        var options;
        var tempId = $('#hdnTemplateId').val();

        options = {
            url: moreInfoUrl + 'tempId=' + tempId + '&isonline=true&soltype=sitecollection',
            title: 'More Information',
            allowMaximize: true,
            width: 650,
            height: 500
        };

        SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
    }

    function InitMoreOptionBtnLogic() {
        $('#btnMoreLessOpt').click(function () {
            if ($(this).attr('value') == 'More Options') {
                $(this).attr('value', 'Less Options');
                RemoveScrollbar();
                SwitchToMoreOpt();
            }
            else {
                $(this).attr('value', 'More Options');
                SwitchBackFromMoreOpt();
            }
            return false;
        });
    }

    function SwitchToMoreOpt() {
        // manage center div visibility
        $('#divOnlineTempsHolder').css('display', 'none');
        $('#divMoreOptContainer').css('display', '');
        $('#divExistingWorkspaceContainer').css('display', 'none');
        $('#divEmptyGalleryHTML').css('display', 'none');

        $('.txtAvailableTemplates').css('display', 'none');

        $('.divFilter').css('display', 'none');
    }

    function SwitchBackFromMoreOpt() {
        $('#divOnlineTempsHolder').css('display', 'block');
        $('.divEPMLiveTempFilters').css('display', 'block');
        $('.txtAvailableTemplates').css('display', 'block');

        $('#txtFreeSearch').css('display', 'none');
        $('#lnkBackToAllItems').css('display', 'none');
        $('#divMoreOptContainer').css('display', 'none');
        $('#divExistingWorkspaceContainer').css('display', 'none');

        ConfigureScrollbar($('#divOnlineTempsHolder'));
    }

    function BindAutoTypeEvents() {
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
                var intKeyCode = parseInt(e.keyCode);
                if (intKeyCode >= 65 && intKeyCode <= 90) {
                    canCopy = true;
                }
                else if (intKeyCode != 16 && intKeyCode != 17 && !e.shiftKey &&
                         intKeyCode >= 96 && intKeyCode <= 105) {
                    canCopy = true;
                }
                else if (intKeyCode != 16 && intKeyCode != 17 && !e.shiftKey &&
                         intKeyCode >= 48 && intKeyCode <= 57) {
                    canCopy = true;
                }
                else if (intKeyCode == 32) {
                    canCopy = true;
                }
                else if (intKeyCode == 8) {
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
            var intKeyCode = parseInt(e.keyCode);
            if (intKeyCode >= 65 && intKeyCode <= 90) {
                canCopy = true;
            }
            else if (intKeyCode != 16 && intKeyCode != 17 && !e.shiftKey &&
                         intKeyCode >= 96 && intKeyCode <= 105) {
                canCopy = true;
            }
            else if (intKeyCode != 16 && intKeyCode != 17 && !e.shiftKey &&
                         intKeyCode >= 48 && intKeyCode <= 57) {
                canCopy = true;
            }
            else if (intKeyCode == 8) {
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
                var intKeyCode = parseInt(e.keyCode);
                if (intKeyCode >= 65 && intKeyCode <= 90) {
                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#' + urlBoxId).val($('#hdnSiteUrl').val());
                }
                // detect numpad #
                else if (intKeyCode != 16 && intKeyCode != 17 && !e.shiftKey &&
                         intKeyCode >= 96 && intKeyCode <= 105) {
                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#' + urlBoxId).val($('#hdnSiteUrl').val());
                }
                // detect regular #
                else if (intKeyCode != 16 && intKeyCode != 17 && !e.shiftKey &&
                         intKeyCode >= 48 && intKeyCode <= 57) {

                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#' + urlBoxId).val($('#hdnSiteUrl').val());

                }
                else if (intKeyCode == 32) {
                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#' + urlBoxId).val($('#hdnSiteUrl').val());
                }
                // detect delete
                else if (intKeyCode == 8) {
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
                var intKeyCode = parseInt(e.keyCode);
                if (intKeyCode >= 65 && intKeyCode <= 90) {
                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#tbNewWorkSpaceName').val($('#hdnSiteName').val());
                }
                // detect numpad #
                else if (intKeyCode != 16 && intKeyCode != 17 && !e.shiftKey &&
                         intKeyCode >= 96 && intKeyCode <= 105) {
                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#tbNewWorkSpaceName').val($('#hdnSiteName').val());
                }
                // detect regular #
                else if (intKeyCode != 16 && intKeyCode != 17 && !e.shiftKey &&
                         intKeyCode >= 48 && intKeyCode <= 57) {

                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#tbNewWorkSpaceName').val($('#hdnSiteName').val());

                }
                else if (intKeyCode == 32) {
                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#tbNewWorkSpaceName').val($('#hdnSiteName').val());
                }
                // detect delete
                else if (intKeyCode == 8) {
                    var cleanVal = $(this).val().replace(/[^a-zA-Z 0-9]+/g, '').replace(/\s/g, '');
                    $('#hdnSiteUrl').val(cleanVal);
                    $('#hdnSiteName').val(cleanVal);
                    $('#tbNewWorkSpaceName').val($('#hdnSiteName').val());
                }
            }
        });
    }

    function getSelText() {
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


    function GetApplicationTemps() {

        if (isOnlineTempsLoaded == 'false') {

            var xmlhttp = false;
            if (navigator.appName == 'Microsoft Internet Explorer') {
                xmlhttp = new ActiveXObject('Microsoft.XMLHTTP');
            }
            else {
                xmlhttp = new XMLHttpRequest();
            }

            var query;
            //        if (qsTemplateType != 'template' && qsTemplateType != 'workspace') {
            //            query = "<![CDATA[<Where><And><Eq><FieldRef Name=\"Visible\" /><Value Type=\"Boolean\">1</Value></Eq><And><Eq><FieldRef Name=\"SolutionType\" /><Value Type=\"Choice\">" + qsSolutionType + "</Value></Eq><Eq><FieldRef Name=\"TemplateType\" /><Value Type=\"MultiChoice\">" + qsTemplateType + "</Value></Eq></And></And></Where><OrderBy><FieldRef Name=\"Title\" Ascending=\"True\" /></OrderBy>]]>";
            //        }
            //        else {
            //            if (listName.indexOf('Requests') !== -1) {
            //                query = "<![CDATA[<Where><And><Eq><FieldRef Name=\"Visible\" /><Value Type=\"Boolean\">1</Value></Eq><And><Eq><FieldRef Name=\"SolutionType\" /><Value Type=\"Choice\">" + qsSolutionType + "</Value></Eq><Eq><FieldRef Name=\"TemplateType\" /><Value Type=\"MultiChoice\">project</Value></Eq></And></And></Where><OrderBy><FieldRef Name=\"Title\" Ascending=\"True\" /></OrderBy>]]>";
            //            }
            //            else {
            //                query = "<![CDATA[<Where><And><Eq><FieldRef Name=\"Visible\" /><Value Type=\"Boolean\">1</Value></Eq><Eq><FieldRef Name=\"SolutionType\" /><Value Type=\"Choice\">" + qsSolutionType + "</Value></Eq></And></Where><OrderBy><FieldRef Name=\"Title\" Ascending=\"True\" /></OrderBy>]]>";
            //            }
            //        }

            query = "<![CDATA[<Where><Eq><FieldRef Name=\"SolutionType\" /><Value Type=\"Choice\">SiteCollection</Value></Eq></Where><OrderBy><FieldRef Name=\"Title\" Ascending=\"True\" /></OrderBy>]]>";

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
                    "<Param key=\"SolutionType\">" + qsSolutionType + "</Param>" +
                    "</Data>";


            xmlhttp.open("POST", solutionStoreProxyUrl, true);
            xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4) {
                    if (xmlhttp.status == 200) {
                        try {
                            var oJson = eval('(' + UnescapeHTMLtoXML(xmlhttp.responseText) + ')');
                            if (oJson.error != null) {
                                alert(oJson.error);
                                if (defaultCreateNew == 'local' || defaultCreateNew == 'existing') {
                                    $('#linkNewWorkspace').trigger('click');
                                }
                                else {
                                    SP.UI.ModalDialog.commonModalDialogClose(0, currentWebUrl);
                                }
                            }
                            else {
                                AppendOnlineTemplateDivs(oJson);
                                GetOnlineTempsFilters();
                                DisplayEPMLiveTemps();
                            }
                        }
                        catch (e) {
                            alert(e.Message);
                        }
                    }
                }
            };
            xmlhttp.send("data=" + strData);
        }
        else {
            if ($('#divLoad_LoadingOnlineTemps').css('display') == 'block') {
                ReturnFromLoadingOnlineTemps();
            }
        }
    }

    function IsContractLevelValid(levels) {
        var result = false;
        for (var lvl in levels) {
            if (levels[lvl] == contractLevel) {
                result = true;
            }
        }

        return result;
    }

    function AppendOnlineTemplateDivs(oJson) {
        // clear main div first
        $('#divOnlineTempsHolder').empty();

        for (var template in oJson.Templates) {

            if (contractLevel) {
                var owsLevel = oJson.Templates[template].Levels ? oJson.Templates[template].Levels : ""
                if (owsLevel != "") {
                    var templateLevels = owsLevel.split(';#');
                    if (!IsContractLevelValid(templateLevels)) {
                        continue;
                    }
                }
            }

            var strCats = '';
            var cats = oJson.Templates[template].TemplateCategory.split(';#');
            for (var i = 0; i < cats.length; i++) {
                if (cats[i] != '') {
                    strCats += cats[i] + ', ';
                }
            }
            strCats = strCats.substring(0, strCats.length - 2);

            //        var strTypes = '';
            //        var types = oJson.Templates[template].TemplateType.split(';#');
            //        for (var i = 0; i < types.length; i++) {
            //            if (types[i] != '') {
            //                strTypes += types[i] + ', ';
            //            }
            //        }
            //        strTypes = strTypes.substring(0, strTypes.length - 2);

            var imageUrl = oJson.Templates[template].ImageUrl ? oJson.Templates[template].ImageUrl.replace(',', '').trim() : "/_layouts/EPMLive/Images/blanktemplate.png";
            //        var isRestricted = true;
            //        var owsLevel = oJson.Templates[template].Levels ? oJson.Templates[template].Levels : "";
            //        if (owsLevel != "") {
            //            var templateLevels = owsLevel.split(';#');
            //            isRestricted = !IsTempAvailableToCurrentUser(templateLevels);
            //        }

            //        if (isRestricted) {
            //            imageUrl = "/_layouts/EPMLive/Images/notavailable.png"
            //        }

            // SalesInfo:SW
            var salesInfo = oJson.Templates[template].SalesInfo;

            var divTempHolder = $('#divOnlineTempHolder')
                            .clone()
                            .css('display', 'block')
                            .attr('id', 'divTemplate_' + oJson.Templates[template].Id)
                            .find('#templateId').val(oJson.Templates[template].Id).end()
                            .find('#templateTitle').val(oJson.Templates[template].Title).end()
            //.find('#templateType').val(strTypes).end()
                            .find('#templateCategories').val(strCats).end()
                            .find('#templateDescription').val(oJson.Templates[template].Description).end()
                            .find('#divOnlineTempTitle').html(oJson.Templates[template].Title).end()
                            .find('#templateOnlineFolder').val(oJson.Templates[template].Title).end()
            //.find('#templateLevels').val(owsLevel).end()
                            .find('#templateSalesInfo').val(salesInfo).end()
                            .find('#templateImage').attr('src', imageUrl).end()
                            .wrap('<div></div>')
                            .parent()
                            .html();

            $('#divOnlineTempsHolder').append(divTempHolder);
        }

        WireOnlineTempDivWithLogic();
        ClickFirstTemp();
    }

    function GetOnlineTempsFilters() {
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
        AppendOnlineFilters(onlineTempTypes, onlineTempCategories);
        isOnlineTempsLoaded = 'true';
        $('#lnkOnlineAllCategories').trigger('click');

    }

    function DisplayEPMLiveTemps() {
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

        $('#btnMoreLessOpt').val("More Options");

        $('.divEPMLiveTempFilters').css('display', 'block');
        $('.divFilterBy').css('display', 'none');
        $('#divfreeSearchFilter').css('display', 'none');

        //$('#hdnParentWebUrl').val(parentWebUrl);

        ConfigureScrollbar($('#divOnlineTempsHolder'));
        WireOnlineTempDivWithLogic();
        ClickFirstTemp();

        if ($('#lnkOnlineAllTypes').length > 0) {
            $('#lnkOnlineAllTypes').trigger('click');
        }
        else {
            $('.onlineTypeFilter:first').trigger('click');
        }

        $('#lnkOnlineAllCategories').trigger('click');

        //    if (newItemNameLwrCs == "workspace") {
        //        $('#spanWorkspaceTitle').text('Workspace Name');
        //    }

        //    if (newItemNameLwrCs != "template") {
        //        $('.divEPMLiveTempFilters').css('display', 'none');
        //    }
        //    else {
        //        $('.onlineCategoryFilter').css('display', 'none');
        //        $('.categoryfilter').css('display', 'none');
        //    }
    }

    function ReturnFromLoadingOnlineTemps() {
        // clear loader div
        $('#divLoad_LoadingOnlineTemps').css('display', 'none');

        // left panel visibility
        $('.divLeft').css('display', '');
        $('.divRight').css('display', '');

        $('.divEPMLiveTempFilters').css('display', 'block');
        //$('.categoryfilter').css('display', 'none');
        //$('.onlineCategoryfilter').css('display', 'none');

        $('.divFilterBy').css('display', 'none');
        $('.divSolGalFilters').css('display', 'none');
        $('#divfreeSearchFilter').css('display', 'none');

        // center div visibility
        $('.txtAvailableTemplates').css('display', '');
        $('#divTemplatesHolder').css('display', 'none');
        $('#divOnlineTempsHolder').css('display', 'block');
        $('#divSolGalTempsHolder').css('display', 'none');
        $('#divMoreOptContainer').css('display', 'none');
        $('#divExistingWorkspaceContainer').css('display', 'none');
        $('#divEmptyGalleryHTML').css('display', 'none');

        ConfigureScrollbar($('#divOnlineTempsHolder'));
        WireOnlineTempDivWithLogic();
        ClickFirstTemp();

        // click all categories and types
        $('#lnkOnlineAllTypes').trigger('click');
        $('#lnkOnlineAllCategories').trigger('click');
    }

    function UnescapeHTMLtoXML(escapedHTML) {
        var d = document.createElement("div");
        d.innerHTML = escapedHTML;
        if (!d.innerText) {
            return d.textContent;
        } else {
            return d.innerText;
        }
    }

    // template levels should be an array
    function IsTempAvailableToCurrentUser(templateLevels) {
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

    function WireOnlineTempDivWithLogic() {

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
                ChangeRightPanelVisibility();
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
                $('.divSalesInfo').html(UnescapeHTMLtoXML($(this).find('#templateSalesInfo').val()));
            }

            $(this).siblings().removeClass("selectedTemp");

            if ($(this).hasClass("selectedTemp")) {
            }
            else {
                $(this).addClass("selectedTemp");
            }

        });
    }

    function ClickFirstTemp() {
        // clear all temp information from right panel
        $('.txtTemplateTitle').empty();
        $('.txtTemplateType').empty();
        $('.txtTemplateCategory').empty();
        $('.txtDescription').empty();
        $('#rightDivTemplateImage').attr('src', '/_layouts/epmlive/images/BlankTemplateIcon.png');
        $('.divOnlineTempsHolder .divOnlineTempHolder:visible').first().trigger("click");

    }

    function AppendOnlineFilters(templateTypes, templateCategories) {
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
            ClearAllSelection("onlineCategoryFilter");
            $(this).addClass("selectedLink");
            UpdateSelectedTempCat("All Categories");
            FilterOnlineTemplates();
            return false;
        });

        for (cat in templateCategories) {
            var originalCategoryText = templateCategories[cat];
            if (originalCategoryText != '') {
                var staticCategoryText = originalCategoryText.split(' ').join('');

                var tempCatFilter = $('#filterLinks_model')
                    .clone()
                    .css('display', 'block')
                    .attr('id', 'filterLink_' + staticCategoryText)
                    .find('#lnkOnlineTemps').attr('id', 'lnkOnlineCategoryFilter_' + staticCategoryText)
                                            .removeAttr('target')
                                            .addClass('onlineCategoryFilter')
                                            .text(originalCategoryText)
                                            .end()
                    .wrap("<div></div>")
                    .parent()
                    .html();

                list.append(tempCatFilter);

                $('#lnkOnlineCategoryFilter_' + staticCategoryText).click(function () {
                    ClearAllSelection('onlineCategoryFilter');
                    $(this).addClass('selectedLink');
                    var filterText = $(this).text();
                    UpdateSelectedTempCat(filterText);
                    FilterOnlineTemplates();
                    return false;
                });
            }
        }

        HookupLinkHoverLogic();

        $('#lnkOnlineAllCategories').trigger('click');
    }

    function HookupLinkHoverLogic() {
        $('.sameColorLink').hover(function () {
            $(this).addClass('hoverLink');
        },
        function () {
            $(this).removeClass('hoverLink');
        });
    }



    function UpdateSelectedTempCat(cat) {
        $('#hdnTemplateCategory').val(cat);
    }

    function FilterOnlineTemplates() {
        var cat = $('#hdnTemplateCategory').val();

        if (cat == 'All Categories') {
            $('#divOnlineTempsHolder').find('.divOnlineTempHolder').css('display', 'block');
        }
        else {
            // hide all templates
            $('#divOnlineTempsHolder').find('.divOnlineTempHolder').css('display', 'none');
            // display template by category 
            var qualifiedCats = $('input[id="templateCategories"][value*="' + cat + '"]').parent().css('display', 'block');
        }
        ChangeRightPanelVisibility();
        ClickFirstTemp();
    }

    function FilterOnlineTemplatesByFreeSearch(text) {
        // hide all templates
        $('#divOnlineTempsHolder').find('.divOnlineTempHolder').css('display', 'none');
        // display template by category 
        var qualifiedCats = $('input[id="templateTitle"][value*="' + text + '"]').parent().css('display', 'block');

        ChangeRightPanelVisibility();
        ClickFirstTemp();
    }

    function ClearAllSelection(area) {
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

    function ChangeRightPanelVisibility() {
        if ($('#lnkOnlineAllCategories').hasClass('selectedLink')) {
            if ($('.divOnlineTempsHolder .divOnlineTempHolder:visible').length == 0) {
                $('.divRight div').each(function () {
                    if (!($(this).className == 'divSearchBox' || $(this).attr('id') == 'tbFreeSearch')) {
                        $(this).css('display', 'none');
                    }
                });
            }
            else {
                $('.divRight div').css('display', 'block');
                $('.divRight input').css('display', 'block');
                $('.divSalesInfo').css('display', 'none');
                $('.txtExistingWorkspaceHeading').css('display', 'none');
                $('.txtExistingWorkspaceUrl').css('display', 'none');
            }
        }
    }
})(window.epmLiveCreateApplication = window.epmLiveCreateApplication || {}, window.jQuery);

