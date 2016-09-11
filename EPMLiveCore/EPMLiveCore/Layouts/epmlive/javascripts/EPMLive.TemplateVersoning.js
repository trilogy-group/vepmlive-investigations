(function() {
    'use strict';
    
    function registerTemplateVersoningScript() {
        (function (epmLiveTemplateVersoning, $, $$, undefined) {
            epmLiveTemplateVersoning.statusbar = null;

            function parseValue(value) {
                if (!$$.isGuid(value)) {
                    if (value['#cdata']) {
                        value = value['#cdata'];
                    } else if (value === 'true') {
                        value = true;
                    } else if (value === 'false') {
                        value = false;
                    } else {
                        if (value.indexOf(' ') === -1) {
                            var number = parseInt(value);
                            if (!isNaN(number)) {
                                value = number;
                            }
                        } else {
                            var date = Date.parse(value);
                            if (!isNaN(date)) {
                                value = new Date(value);
                            }
                        }
                    }
                }

                return value;
            }

            function getTemplate(t) {
                var temp;

                if (!t.length) {
                    temp = [t];
                } else {
                    temp = t;
                }

                var template = {};

                for (var i = 0; i < temp.length; i++) {
                    var tmp = temp[i];

                    for (var tp in tmp) {
                        if (tmp.hasOwnProperty(tp)) {
                            var key = tp.replace(/@/, '').toLowerCase();
                            var value = tmp[tp];

                            if (key === 'solution') {
                                var sol;

                                if (!value.length) {
                                    sol = [value];
                                } else {
                                    sol = value;
                                }

                                var solution = {};

                                for (var j = 0; j < sol.length; j++) {
                                    var sln = sol[j];

                                    for (var s in sln) {
                                        if (sln.hasOwnProperty(s)) {
                                            var solutionKey = s.replace(/@/, '').toLowerCase();
                                            var solutionValue = sln[s];

                                            solutionValue = parseValue(solutionValue);

                                            solution[solutionKey] = solutionValue;

                                            if (solutionValue instanceof Date) {
                                                solution[solutionKey + 'datestring'] = sln[s].split(' ', 1)[0];
                                            }
                                        }
                                    }
                                }

                                value = solution;
                            } else {
                                value = parseValue(value);
                            }

                            template[key] = value;

                            if (value instanceof Date) {
                                template[key + 'datestring'] = tmp[tp].split(' ', 1)[0];
                            }
                        }
                    }
                }

                return template;
            }

            function displayTemplateInformation(t) {
                if (epmLiveTemplateVersoning.statusbar) {
                    epmLiveTemplateVersoning.statusbar.remove();
                }

                var solutionSaved = false;

                var title = 'Attention';
                var message = 'This site has been designated as a Template Site.';

                var statusbar = $$.ui.statusbar.add(title, message);

                var template = getTemplate(t);
                var color = 'yellow';

                var solution = template.solution;
                if (solution) {
                    if (solution.createddate) {
                        solutionSaved = true;
                    }
                }

                title = 'Last Saved';

                if (solutionSaved) {
                    message = $$.getFriendlyDateTime(solution.createddate, solution.createddatedatestring);
                } else {
                    message = 'Template has not been saved.';
                }

                message += ' | <div id="EpmLiveTemplateVersoningSaveAction" style="display:inline-block;"><a href="javascript:void(0);" onclick="window.epmLiveTemplateVersoning.promptSaveTemplate();">Save Template</a></div></span>';

                statusbar.append(title, message, null, 'right');
                statusbar.color(color);

                epmLiveTemplateVersoning.statusbar = statusbar;
            }

            function getTemplateInformation() {
                $.ajax({
                    type: 'POST',
                    url: $$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                    data: "{ Function: 'GetTemplateInformation', Dataxml: '' }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',

                    success: function (response) {
                        if (response.d) {
                            var responseJson = $$.parseJson(response.d);

                            if ($$.responseIsSuccess(responseJson.Result)) {
                                var template = responseJson.Result.Template;

                                if (template) {
                                    displayTemplateInformation(template);
                                }
                            } else {
                                $$.logFailure(responseJson.Result);
                            }
                        } else {
                            $$.log('response.d: ' + response.d);
                        }
                    },

                    error: function (error) {
                        $$.log(error);
                    }
                });
            }

            epmLiveTemplateVersoning.saveTemplate = function () {

                function animateSaveStatus(element, prefix) {
                    var html = element.html();

                    var indicator1 = prefix + '';
                    var indicator2 = prefix + '.';
                    var indicator3 = prefix + '..';
                    var indicator4 = prefix + '...';

                    if (html === indicator1) {
                        element.html(indicator2);
                    } else if (html === indicator2) {
                        element.html(indicator3);
                    } else if (html === indicator3) {
                        element.html(indicator4);
                    } else {
                        element.html(indicator1);
                    }
                }

                var saveButton = $('#EpmLiveTemplateVersoningSaveButton');
                saveButton.attr('disabled', 'disabled');

                var cancelButton = $('#EpmLiveTemplateVersoningCancelButton');
                cancelButton.attr('disabled', 'disabled');

                var includeContentCheckbox = $('#EpmLiveTemplateVersoningincludeContentCheckbox');
                includeContentCheckbox.attr('disabled', 'disabled');

                var saveStatusElement = $('#EpmLiveTemplateVersoningSaveStatusMessage');
                var loaderElement = $('#EpmLiveTemplateVersoningSaveStatusProgress');

                loaderElement.show();

                var saveStatusAnimationInterval = setInterval(function () {
                    animateSaveStatus(saveStatusElement, 'Saving');
                }, 500);

                function reportStatus(success) {
                    clearInterval(saveStatusAnimationInterval);

                    var color = 'green';
                    var message = 'Site saved as template successfully.';

                    if (!success) {
                        color = 'red';
                        message = 'Saving the site as template failed.';
                    }

                    loaderElement.hide();

                    saveStatusElement.css('color', color);
                    saveStatusElement.html(message);

                    saveButton.removeAttr('disabled');
                    cancelButton.removeAttr('disabled');
                    includeContentCheckbox.removeAttr('disabled');
                }

                $.post($$.currentWebUrl + '/_layouts/epmlive/SaveCurrentSiteAsTemplate.aspx', { __REQUESTDIGEST: $("#__REQUESTDIGEST").val() }, function (response) {
                    if (response) {
                        if (response.indexOf('SUCCESS') !== -1) {
                            reportStatus(true);
                            getTemplateInformation();
                        } else {
                            reportStatus(false);
                            $$.logFailure(response);
                        }
                    } else {
                        reportStatus(false);
                        $$.log('response: ' + response);
                    }
                });
            };

            $(document).ready(function () {
                LoadSodByKey("sp.js", function () { });
            });

            epmLiveTemplateVersoning.promptSaveTemplate = function () {
                var element = document.createElement('div');
                element.innerHTML = $('#EPMLiveTemplateVersoningSavePrompt').html();

                var options = parent.SP.UI.$create_DialogOptions();

                options.title = 'Save Template';
                options.html = element;
                options.height = 100;
                options.width = 565;
                options.allowMaximize = false;
                options.showClose = false;

                parent.SP.UI.ModalDialog.showModalDialog(options);
            };

            getTemplateInformation();
        }(window.epmLiveTemplateVersoning = window.epmLiveTemplateVersoning || {}, window.jQuery, epmLive));
    }

    ExecuteOrDelayUntilScriptLoaded(registerTemplateVersoningScript, 'EPMLive.js');
})();