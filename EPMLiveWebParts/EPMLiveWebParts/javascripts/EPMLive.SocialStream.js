﻿(function($, Ember, moment) {
    'use strict';

    var SocialEngine = function () {
        var SE = Ember.Application.create({
            rootElement: '#epm-social-stream'
        });

        SE.ApplicationAdapter = DS.RESTAdapter.extend({
            namespace: window.epmLive.currentWebUrl.slice(1) + '/_vti_bin/SocialEngine.svc'
        });

        SE.ConfigureMoment = function() {
            moment.lang('en', {
                calendar: {
                    lastDay: '[Yesterday -]  MMMM D',
                    sameDay: '[Today -] MMMM D',
                    nextDay: '[Tomorrow -] MMMM D',
                    lastWeek: '[Last] dddd [-] MMMM D',
                    nextWeek: 'dddd [-] MMMM D',
                    sameElse: 'MMMM D YYYY'
                }
            });
        };

        SE.ConfigureMoment();

        SE.Day = DS.Model.extend({
            threads: DS.hasMany('thread'),
            
            day: function() {
                return moment(this.get('id')).calendar();
            }.property()
        });

        SE.Thread = DS.Model.extend({
            title: DS.attr(),
            url: DS.attr(),
            kind: DS.attr(),
            itemId: DS.attr(),
            lastActivityOn: DS.attr(),
            day: DS.belongsTo('day'),
            web: DS.belongsTo('web'),
            list: DS.belongsTo('list'),
            activities: DS.hasMany('activity'),

            hasList: function() {
                return this.get('list') !== null;
            }.property(),

            hasItem: function() {
                return this.get('itemId') !== null;
            }.property()
        });

        SE.Activity = DS.Model.extend({
            time: DS.attr(),
            metaData: DS.attr(),
            key: DS.attr(),
            kind: DS.attr(),
            isMassOperation: DS.attr(),
            user: DS.belongsTo('user'),
            thread: DS.belongsTo('thread'),

            date: function() {
                var date = moment(this.get('time'));

                moment.lang('en', {
                    calendar: {
                        lastDay: '[Yesterday]  MMM D',
                        sameDay: '[Today] MMM D',
                        nextDay: '[Tomorrow] MMM D',
                        lastWeek: '[Last] ddd MMM D',
                        nextWeek: 'ddd MMM D',
                        sameElse: 'MMMM D YYYY'
                    }
                });

                date = date.calendar();

                SE.ConfigureMoment();

                return date;
            }.property(),

            fullDateTime: function() {
                return moment(this.get('time')).format('LLLL');
            }.property()
        });

        SE.Web = DS.Model.extend({
            title: DS.attr(),
            url: DS.attr(),
            threads: DS.hasMany('thread'),

            isNotCurrentWorkspace: function () {
                return this.get('id').toLowerCase() !== window.epmLive.currentWebId.toLowerCase();
            }.property()
        });

        SE.List = DS.Model.extend({
            name: DS.attr(),
            url: DS.attr(),
            threads: DS.hasMany('thread')
        });

        SE.User = DS.Model.extend({
            name: DS.attr(),
            account: DS.attr(),
            avatar: DS.attr(),
            activities: DS.hasMany('activity'),

            hasAvatar: function() {
                return this.get('avatar') !== null;
            }.property(),

            displayName: function() {
                if (this.get('id') === window.epmLive.currentUserId) return 'You';
                return this.get('name').split(' ')[0];
            }.property(),

            profileUrl: function() {
                return window.epmLive.currentWebUrl + '/_layouts/15/userdisp.aspx?ID=' + this.get('id');
            }.property()
        });

        SE.IndexRoute = Ember.Route.extend({
            model: function() {
                return this.store.find('activity');
            },
            
            setupController: function(controller, model) {
                controller.set('content', model);
                controller.set('days', this.store.all('day'));
            }
        });

        SE.IndexView = Ember.View.extend({
            tagName: 'ul',
            classNames: ['days']
        });
        
        SE.DayView = Ember.View.extend({
            tagName: 'li',
            classNames: ['day']
        });

        SE.ThreadsView = Ember.View.extend({
            tagName: 'ul',
            classNames: ['threads']
        });

        SE.ThreadView = Ember.View.extend({
            tagName: 'li',
            classNames: ['thread'],
            classNameBindings: ['singleActivityThread'],
            singleActivityThread: Ember.computed.alias('controller.singleActivityThread'),
            
            actions: {
                showDate: function () {
                    this.$().find('span.date').tooltip('show');
                }
            }
        });
        
        SE.ActivitiesView = Ember.View.extend({
            tagName: 'ul',
            classNames: ['activities']
        });
        
        SE.ActivityView = Ember.View.extend({
            tagName: 'li',
            classNames: ['activity']
        });

        SE.ThreadController = Ember.ObjectController.extend({
            singleActivityThread: function() {
                return this.get('activities').get('length') === 1;
            }.property('activities.@each'),

            firstActivity: function() {
                return this.get('activities').get('firstObject');
            }.property('activities.@each')
        });
    };

    var loadSocialEngine = function() {
        if (window.epmLive) {
            Function.prototype.property = function () {
                var ret = Ember.computed(this);
                return ret.property.apply(ret, arguments);
            };
            
            SocialEngine();
        } else {
            window.setTimeout(function() {
                loadSocialEngine();
            }, 1);
        }
    };

    loadSocialEngine();
})(jQuery, Ember, moment);