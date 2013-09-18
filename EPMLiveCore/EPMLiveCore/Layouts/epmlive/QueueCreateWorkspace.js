/// <reference path="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js" />
/// <reference path="/_layouts/epmlive/javascripts/libraries/knockout-2.2.1.js" />

function registerCreateWorkspace2Script() {

    (function(CWS2, EPMLive, $, k, w, undefined) {

        k.bindingHandlers.fadeVisible = {
            init: function (element, valueAccessor) {
                // Start visible/invisible according to initial value
                var shouldDisplay = valueAccessor();
                $(element).toggle(shouldDisplay);
            },
            update: function (element, valueAccessor) {
                // On update, fade in/out
                var shouldDisplay = valueAccessor();
                shouldDisplay ? $(element).fadeIn(1000) : $(element).fadeOut();
            }
        };
        
        // declare viewmodel
        function CreateWorkspaceViewModel() {
            // DATA - UI related
            var self = this;
            self.notifyId = ko.observable();
            self.isStandAlone = ko.observable(w.isStandAlone);
            self.createDefault = ko.observable(w.createDefault);
            self.onlineAvail = ko.observable(w.onlineAvail);
            self.localAvail = ko.observable(w.localAvail);
            self.workEngineSvcUrl = w.workEngineSvcUrl;
            self.solutionLibPath = w.epmLive.currentWebFullUrl + '/_layouts/EPMLive/SolutionStoreProxy.aspx';
            self.currentView = ko.observable();
            self.marketAppsLoading = ko.observable(true);
            self.downloadedAppsLoading = ko.observable(true);
            self.createFromLiveTemp = ko.observable(w.createFromLiveTemps);
            self.marketApps = ko.observableArray();
            self.downloadedApps = ko.observableArray();
            self.showInProgress = ko.observable(w.showIsInProgressMsg);
            self.shouldShowMarket = ko.computed(function () {
                return !self.marketAppsLoading() && self.currentView() == 'market' && self.showInProgress() == 'false';
            });
            self.shouldShowDownloaded = ko.computed(function () {
                return !self.downloadedAppsLoading() && self.currentView() == 'downloaded' && self.showInProgress() == 'false';
            });
            self.noOnlineTemplate = ko.computed(function() {
                return self.marketApps().length === 0;
            });
            self.noLocalTemplate = ko.computed(function () {
                return self.downloadedApps().length === 0;
            });
            self.hasTempSelected = ko.observable(false);
            
            // DATA - workspace creation related
            self.templateSource = ko.computed(function() {
                if (self.onlineAvail() === 'true' && self.localAvail() === 'true') {
                    if ($('#online').hasClass('slider-selected')) {
                        return 'online';
                    } else {
                        return 'downloaded';
                    }
                }
                else if (self.onlineAvail() === 'true' && self.localAvail() === 'false') {
                    return 'online';
                }
                else if (self.localAvail() === 'true' && self.onlineAvail() === 'false') {
                    return 'downloaded';
                }
            });
            self.solutionName = ko.observable();
            self.templateName = ko.observable();
            self.workspaceUrl = ko.observable();
            self.parentWebUrl = ko.observable();
            self.uniquePermission = ko.observable(w.uniquePerm);
            self.workspaceTitle = ko.observable(w.workspaceTitle);
            self.itemId = ko.observable(w.itemId);
            self.templateItemId = ko.observable(-1);
            self.listGuid = ko.observable(w.listGuid);
            self.listName = ko.observable(w.listName);
            self.compLvls = ko.observable(w.compLvls);
            self.currentWebFullUrl = ko.observable(w.epmLive.currentWebFullUrl);
            self.currentWebId = ko.observable(w.epmLive.currentWebId);
            self.currentSiteId = ko.observable(w.epmLive.currentSiteId);
            

            self.loadMarketAppsParams = ko.computed(function () {
                return "<Data>" +
                            "<Param key=\"WebSvcName\">List</Param>" +
                            "<Param key=\"WebSvcMethod\">GetListItemsInXML</Param>" +
                            "<Param key=\"ListName\">Solutions</Param>" +
                            "<Param key=\"ViewName\"></Param>" +
                            "<Param key=\"ViewFields\"></Param>" +
                            "<Param key=\"RowLimit\">100000</Param>" +
                            "<Param key=\"QueryOptions\"></Param>" +
                            "<Param key=\"CompLevels\">" + self.compLvls() + "</Param>" +
                        "</Data>";
            }, this);

            self.loadDownloadedAppParams = ko.computed(function () {
                return "<Data>" +
                            "<Param key=\"Type\">All Types</Param>" +
                            "<Param key=\"IsTemplate\">true</Param>" +
                            "<Param key=\"TemplateType\">workspace</Param>" +
                            "<Param key=\"CompLevels\">" + self.compLvls() + "</Param>" +
                            "<Param key=\"CreateFromLiveTemp\">" + self.createFromLiveTemp() + "</Param>" +
                        "</Data>";
            }, this);

            self.createWSParams = ko.computed(function () {
                return "<Data>" +
                            "<Param key=\"IsStandAlone\">" + self.isStandAlone() + "</Param>" +
                            "<Param key=\"TemplateSource\">" + self.templateSource() + "</Param>" +
                            "<Param key=\"TemplateItemId\">" + self.templateItemId() + "</Param>" +
                            "<Param key=\"IncludeContent\">True</Param>" +
                            "<Param key=\"SiteTitle\">" + self.workspaceTitle() + "</Param>" +
                            "<Param key=\"SolutionName\">" + self.solutionName() + "</Param>" +
                            "<Param key=\"UniquePermission\">" + self.uniquePermission() + "</Param>" +
                            "<Param key=\"AttachedItemId\">" + self.itemId() + "</Param>" +
                            "<Param key=\"AttachedItemListGuid\">" + self.listGuid() + "</Param>" +
                            "<Param key=\"WebUrl\">" + self.currentWebFullUrl() + "</Param>" +
                            "<Param key=\"WebId\">" + self.currentWebId() + "</Param>" +
                            "<Param key=\"SiteId\">" + self.currentSiteId() + "</Param>" +
                            "<Param key=\"CreatorId\">" + w.creatorId + "</Param>" +
                            "<Param key=\"CreateFromLiveTemp\">" + self.createFromLiveTemp() + "</Param>" +
                        "</Data>";
            }, this);

            // universal variable
            self.propArray = ['Title', 'Description', 'Levels',
                            'SalesInfo', 'TemplateType', 'TemplateCategory',
                            'ImageUrl'];

            // BEHAVIORS
            self.loadMarketApps = function () {
                if (self.marketApps().length === 0) {
                    $.ajax({
                        type: "POST",
                        url: self.solutionLibPath,
                        data: { data: self.loadMarketAppsParams() },
                        success: function(result) {
                            if (result !== "<Templates />") {
                                var oJson = w.epmLive.parseJson(result);
                                // make sure all properties exist, 
                                // so no error occurs when I bind with knockout.js
                                var qualifiedTemps = self.getCleanTempCollection(oJson.Templates.Template);
                                self.marketApps(qualifiedTemps);
                            }
                            self.marketAppsLoading(false);
                            //$('#marketLoading').fadeOut();

                        },
                        error: function(jqXhr, textStatus, errorThrown) {
                            //alert(errorThrown);
                            self.marketAppsLoading(false);
                            //('#marketLoading').fadeOut();
                        }
                    });
                } else {
                    self.marketAppsLoading(false);
                    //('#marketLoading').fadeOut();
                }

                
            };

            self.loadDownloadedApps = function () {
                if (self.downloadedApps().length === 0) {
                    $.ajax({
                        type: "POST",
                        url: self.workEngineSvcUrl,
                        data: "{Function: 'GetAllTempGalTemps', Dataxml: '" + self.loadDownloadedAppParams() + "' }",
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function(result) {
                            if (result.d != '<Result Status=\"0\"><Templates /></Result>') {
                                var oJson = w.epmLive.parseJson(result.d);
                                // make sure all properties exist, 
                                // so no error occurs when I bind with knockout.js
                                var qualifiedTemps = self.getCleanTempCollection(oJson.Result.Templates.Template);
                                self.downloadedApps(qualifiedTemps);
                            }

                            self.downloadedAppsLoading(false);
                            //$('#localLoading').fadeOut();
                        },
                        error: function(jqXhr, textStatus, errorThrown) {
                            //alert(errorThrown);
                            self.downloadedAppsLoading(false);
                            //$('#localLoading').fadeOut();
                        }
                    });
                } else {
                    self.downloadedAppsLoading(false);
                    //$('#localLoading').fadeOut();
                }
                
            };

            //self.loadMarketThenDownloaded = function() {
            //    if (self.marketApps().length === 0) {
            //        $.ajax({
            //            type: "POST",
            //            url: self.solutionLibPath,
            //            data: { data: self.loadMarketAppsParams() },
            //            success: function (result) {
            //                if (result !== "<Templates />") {
            //                    var oJson = w.epmLive.parseJson(result);
            //                    // make sure all properties exist, 
            //                    // so no error occurs when I bind with knockout.js
            //                    var qualifiedTemps = self.getCleanTempCollection(oJson.Templates.Template);
            //                    self.marketApps(qualifiedTemps);
            //                }
            //                self.marketAppsLoading(false);
                            
            //                self.loadDownloadedApps();
            //            },
            //            error: function (jqXhr, textStatus, errorThrown) {
            //                //alert(errorThrown);
            //                self.marketAppsLoading(false);
            //            }
            //        });
            //    } else {
            //        self.marketAppsLoading(false);
            //    }

               
            //};
            
            //self.loadDownloadedThenMarket = function () {
            //    if (self.marketApps().length === 0) {
            //        $.ajax({
            //            type: "POST",
            //            url: self.solutionLibPath,
            //            data: { data: self.loadMarketAppsParams() },
            //            success: function (result) {
            //                if (result !== "<Templates />") {
            //                    var oJson = w.epmLive.parseJson(result);
            //                    // make sure all properties exist, 
            //                    // so no error occurs when I bind with knockout.js
            //                    var qualifiedTemps = self.getCleanTempCollection(oJson.Templates.Template);
            //                    self.marketApps(qualifiedTemps);
            //                }
                            
            //                $('#marketLoading').fadeOut();
            //                self.loadMarketApps();
            //            },
            //            error: function (jqXhr, textStatus, errorThrown) {
            //                //alert(errorThrown);
            //                $('#marketLoading').fadeOut();
            //            }
            //        });
            //    } else {
            //        $('#marketLoading').fadeOut();
            //    }

               
            //};

            self.getCleanTempCollection = function(objColl) {
                var qualifiedTemps = [];
                if ($(objColl).length > 1) {
                    for (var j in objColl) {
                        var temp = objColl[j];
                        if (temp.TemplateType !== undefined &&
                            temp.TemplateType['#cdata'].indexOf("Workspace") != -1) {
                            qualifiedTemps.push(self.GetCleanTemp(temp));
                        }
                    }
                } else if ($(objColl).length == 1) {
                    var temp = objColl;
                    if (temp.TemplateType !== undefined &&
                        temp.TemplateType['#cdata'].indexOf("Workspace") != -1) {
                        qualifiedTemps.push(self.GetCleanTemp(temp));
                    }
                }

                return qualifiedTemps;
            };

            self.GetCleanTemp = function(temp) {
                for (var k in self.propArray) {
                    if (self.propArray[k] == 'ImageUrl') {
                        if (!temp.hasOwnProperty(self.propArray[k]) || temp[self.propArray[k]]['#cdata'] == '') {
                            temp[self.propArray[k]] = [];
                            temp[self.propArray[k]]['#cdata'] = '/_layouts/EPMLive/Images/blanktemplate.png';
                        }
                            // if it has image src, clean it up
                        else {
                            temp[self.propArray[k]]['#cdata'] = temp[self.propArray[k]]['#cdata'].replace(",", "");
                        }
                    } else if (!temp.hasOwnProperty(self.propArray[k])) {
                        temp[self.propArray[k]] = '';
                    }
                }
                return temp;
            };

            self.createWorkspace = function () {
                if (!self.hasTempSelected()) {
                    alert('You must select a template.');
                    return;
                }
                
                if (!self.workspaceTitle().trim()) {
                    alert('You must enter a site title.');
                    return;
                }

                $.ajax({
                    type: "POST",
                    url: self.workEngineSvcUrl,
                    data: "{Function: 'AddAndQueueCreateWorkspaceJob', Dataxml: '" + self.createWSParams() + "' }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (result) {
                        //var r = result;
                        parent.SP.UI.ModalDialog.commonModalDialogClose(1, '');
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        parent.SP.UI.ModalDialog.commonModalDialogClose(-1, errorThrown);
                    }
                });
            };

            self.gotoTemplate = function(data, event) {
                // UI behavior
                var target = (event.currentTarget) ? event.currentTarget : event.srcElement;
                $('.template').removeClass('template-selected');
                $(target).addClass('template-selected');

                // DATA setting
                if (self.currentView() === "market") {
                    self.solutionName($(target).find('#templateOnlineFolder').val());
                } else if (self.currentView() === "downloaded") {
                    self.templateItemId($(target).find('#localTemplateId').val());
                }

                self.hasTempSelected(true);
            };

            self.AutosizeDialog = function() {
                //resize dialog if we are in one    
                var dlg = parent.SP.UI.ModalDialog.get_childDialog();
                if (dlg != null) {
                    try {
                        dlg.autoSize();
                        var dlgWin = $(".ms-dlgContent", w.parent.document);
                        dlgWin.css({
                            top: ($(w.top).height() / 2 - dlgWin.height() / 2) + "px",
                            left: $(w.top).width() / 2 - dlgWin.width() / 2
                        });
                    } catch(e) {
                    }
                }
            };


            self.cancelCreation = function() {
                parent.SP.UI.ModalDialog.commonModalDialogClose('', '');
            };

            self.toggle = function (data, event) {
                self.hasTempSelected(false);
                var target = (event.currentTarget) ? event.currentTarget : event.srcElement;
                if (target.id == "online" && !$(target).hasClass("slider-selected")) {
                    $(".slider").animate({ "margin-left": '0' }, "fast");
                    $(".toggleButton").removeClass("slider-selected");
                    $(target).addClass("slider-selected");

                    $('#localTemplates').hide();
                    $('#localTemplates').parent().hide();
                    $('#onlineTemplates').show();
                    $('#onlineTemplates').parent().show('slide', { direction: 'right' }, 500);
                    self.currentView('market');
                    //$('#marketLoading').fadeOut();
                }

                if (target.id == "local" && !$(target).hasClass("slider-selected")) {
                    $(".slider").animate({ "margin-left": '65' }, "fast");
                    $(".toggleButton").removeClass("slider-selected");
                    $(target).addClass("slider-selected");

                    $('#onlineTemplates').hide();
                    $('#onlineTemplates').parent().hide();
                    $('#localTemplates').show();
                    $('#localTemplates').parent().show('slide', { direction: 'left' }, 500);
                    self.currentView('downloaded');
                    //$('#localLoading').fadeOut();
                }
            };

            self.pageInit = function () {
                $('#onlineTemplates').slimScroll({
                    height: '220px',
                    width: '850px'
                });
               
                $('#localTemplates').slimScroll({
                    height: '220px',
                    width: '850px'
                });

                if (self.onlineAvail() === 'true' && self.localAvail() === 'true') {
                    self.loadMarketApps();
                    self.loadDownloadedApps();
                    if (self.createDefault() === 'online') {
                        
                        self.currentView('market');
                        $(".toggleButton").removeClass("slider-selected");
                        $('#online').addClass('slider-selected');
                        $(".slider").css('margin-left', '0px');
                        $('#localTemplates').hide();
                        $('#localTemplates').parent().hide();
                        
                        $('#onlineTemplates').show();
                        $('#onlineTemplates').parent().show();

                        //self.loadMarketThenDownloaded();
                    }
                    else if (self.createDefault() === 'local') {
                        self.currentView('downloaded');
                        $(".toggleButton").removeClass("slider-selected");
                        $('#local').addClass('slider-selected');
                        $(".slider").css('margin-left', '65px');
                        $('#localTemplates').show();
                        $('#localTemplates').parent().show();
                        
                        $('#onlineTemplates').hide();
                        $('#onlineTemplates').parent().hide();
                        
                        //self.loadDownloadedThenMarket();
                    }
                }
                else if (self.onlineAvail() === 'true' && self.localAvail() === 'false') {
                    self.currentView('market');
                    $('#localTemplates').hide();
                    $('#localTemplates').parent().hide();
                    self.loadMarketApps();
                }
                else if (self.localAvail() === 'true' && self.onlineAvail() === 'false') {
                    self.currentView('downloaded');
                    $('#onlineTemplates').hide();
                    $('#onlineTemplates').parent().hide();
                    self.loadDownloadedApps();
                }
              
                if (self.showInProgress() === 'true') {
                    $('#divProgress').show();
                }

                $('.titleInput').focus();
            };

            self.pageInit();
        }



        // apply bindings
        k.applyBindings(new CreateWorkspaceViewModel(), document.getElementById('OuterContainer'));

    })(window.CreateWS2 = window.CreateWS2 || {}, window.epmLive, window.jQuery, window.ko, window);

}
ExecuteOrDelayUntilScriptLoaded(registerCreateWorkspace2Script, 'EPMLive.js');