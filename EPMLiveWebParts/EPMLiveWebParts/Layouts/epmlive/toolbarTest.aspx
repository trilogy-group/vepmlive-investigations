<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="toolbarTest.aspx.cs" Inherits="EPMLiveWebParts.Layouts.epmlive.toolbarTest" DynamicMasterPageFile="~masterurl/default.master" %>




<asp:content id="PageHead" contentplaceholderid="PlaceHolderAdditionalPageHead" runat="server">
    
</asp:content>

<asp:content id="Main" contentplaceholderid="PlaceHolderMain" runat="server">
    <div id="test" style="width:75%">

    </div>

    <script src="javascripts/EPMLiveGenericToolBar.js"></script>
    <link href="Stylesheets/EPMLiveToolBar.min.css" rel="stylesheet" />
    <script>
        $(function () {
            var cfgs = [
                {
                    'placement': 'left',
                    'content': [
                    // invite button
                    {
                        'controlId': 'btnInvite',
                        'controlType': 'button',
                        'iconClass': 'fui-plus',
                        'value': 'Invite',
                        'events': [
                            {
                                'eventName': 'click',
                                'function': function () { alert('hello'); }
                            }
                        ]
                    },
                    // tools menu
                    {
                        'controlId': 'ddlTools',
                        'controlType': 'dropdown',
                        'title': '',
                        'value': 'Tools',
                        'iconClass': 'icon-tools',
                        'sections': [
                            // Plan section
                            {
                                'heading': 'Plan',
                                'divider': 'yes',
                                'options': [
                                    {
                                        'iconClass': 'icon-pie-3 icon-dropdown',
                                        'text': 'Resource Planner',
                                        'events': [
                                            {
                                                'eventName': 'click',
                                                'function': function () { alert('Plan something...'); }
                                            }
                                        ]
                                    },
                                    {
                                        'iconClass': 'icon-flag-5 icon-dropdown',
                                        'text': 'Assignment Planner',
                                        'events': [
                                            {
                                                'eventName': 'click',
                                                'function': function () { alert('Plan something...'); }
                                            }
                                        ]
                                    }
                                ]
                            },
                            // Analyze section
                            {
                                'heading': 'Analyze',
                                'divider': 'yes',
                                'options': [
                                    {
                                        'iconClass': 'icon-filter-4 icon-dropdown',
                                        'text': 'Analyzer',
                                        'events': [
                                            {
                                                'eventName': 'click',
                                                'function': function () { alert('analyzing something...'); }
                                            }
                                        ]
                                    },
                                    {
                                        'iconClass': 'icon-filter-4 icon-dropdown',
                                        'text': 'Work vs. Capacity',
                                        'events': [
                                            {
                                                'eventName': 'click',
                                                'function': function () { alert('report something...'); }
                                            }
                                        ]
                                    }
                                ]
                            },
                            // Non Header section
                            {
                                'heading': 'none',
                                'divider': 'yes',
                                'options': [
                                    {
                                        'iconClass': 'icon-filter-4 icon-dropdown',
                                        'text': 'Send Notification',
                                        'events': [
                                            {
                                                'eventName': 'click',
                                                'function': function () { alert('notify something...'); }
                                            }
                                        ]
                                    },
                                    {
                                        'iconClass': 'icon-filter-4 icon-dropdown',
                                        'text': 'Export Excel',
                                        'events': [
                                            {
                                                'eventName': 'click',
                                                'function': function () { alert('export something...'); }
                                            }
                                        ]
                                    },
                                    {
                                        'iconClass': 'icon-filter-4 icon-dropdown',
                                        'text': 'Import Excel',
                                        'events': [
                                            {
                                                'eventName': 'click',
                                                'function': function () { alert('import something...'); }
                                            }
                                        ]
                                    }
                                ]
                            }
                        ]
                    },
                    // reports
                    {
                        'controlId': 'ddlReports',
                        'controlType': 'dropdown',
                        'title': '',
                        'value': 'Reporting',
                        'iconClass': 'icon-pie-3',
                        'sections': [
                            {
                                'heading': 'none',
                                'divider': 'no',
                                'options': [
                                    {
                                        'iconClass': 'icon-pie-3 icon-dropdown',
                                        'text': 'Available vs. Planner by Dept',
                                        'events': [
                                            {
                                                'eventName': 'click',
                                                'function': function () { alert('report something'); }
                                            }
                                        ]

                                    },
                                    {
                                        'iconClass': 'icon-flag-5 icon-dropdown',
                                        'text': 'Capacity Heat Map',
                                        'events': [
                                            {
                                                'eventName': 'click',
                                                'function': function () { alert('report something'); }
                                            }
                                        ]
                                    },
                                    {
                                        'iconClass': 'icon-filter-4 icon-dropdown',
                                        'text': 'Comments',
                                        'events': [
                                            {
                                                'eventName': 'click',
                                                'function': function () { alert('report something'); }
                                            }
                                        ]
                                    },
                                    {
                                        'iconClass': 'icon-filter-4 icon-dropdown',
                                        'text': 'Requirements',
                                        'events': [
                                            {
                                                'eventName': 'click',
                                                'function': function () { alert('report something'); }
                                            }
                                        ]
                                    }
                                ]
                            }
                        ]
                    }]
                },
                {
                    'placement': 'right',
                    'content': [
                    //search control
                    {
                        'controlId': 'genericId',
                        'controlType': 'search',
                        'custom': 'yes',
                        'customControlId': ''
                    },
                    //search control
                    {
                        'controlId': 'genericId',
                        'controlType': 'search',
                        'custom': 'no',
                        'events': [{
                            'eventName': 'keypress',
                            'function': function (e) {
                                if (e.keyCode == 13) {
                                    alert('enter key pressed!');
                                }
                            }
                        }]
                    },
                    // filter button
                    {
                        'controlId': 'btnFilter',
                        'controlType': 'button',
                        'iconClass': 'icon-filter',
                        'title': 'none',
                        'events': [
                            {
                                'eventName': 'click',
                                'function': function () { alert('hello'); }
                            }
                        ]
                    },
                    // default sort button
                    {
                        'controlId': 'btnDefaultSort',
                        'controlType': 'button',
                        'iconClass': 'icon-sort',
                        'title': 'none',
                        'events': [
                            {
                                'eventName': 'click',
                                'function': function () { alert('hello'); }
                            }
                        ]
                    },
                    //group by fields
                    {
                        'controlType': 'groupByFields',
                        'availableGroups': 'Field1|Field1|111,Field2|Field2|222,Field3|Field3|333,Field4|Field4|444,Field5|Field5|555',
                        'groups': [
                            {
                                'displayName': 'Field1',
                                'internalName': 'Field1',
                                'id': '111'
                            },
                            {
                                'displayName': 'Field2',
                                'internalName': 'Field2',
                                'id': '222'
                            },
                            {
                                'displayName': 'Field3',
                                'internalName': 'Field3',
                                'id': '333'
                            }
                        ],
                        'saveFunction': function (data) {
                            var txt = '';
                            for (var i in data) {
                                var obj = data[i];
                                txt += ('Key: ' + obj['key'] + '| Value: ' + obj['value'] + ',\r\n');
                            }
                            alert(txt);
                        }
                    },
                    //select columns control
                    {
                        'controlId': 'msColumns',
                        'controlType': 'multiselect',
                        'title': '',
                        'value': '',
                        'iconClass': 'icon-insert-template',
                        'sections': [
                            {
                                'heading': 'Section1',
                                'divider': 'yes',
                                'options':
                                    {
                                        '1': { 'value': 'field1', 'checked': true },
                                        '2': { 'value': 'field2', 'checked': false },
                                        '3': { 'value': 'field3', 'checked': true },
                                    }
                            },
                            {
                                'heading': 'Section2',
                                'divider': 'no',
                                'options':
                                    {
                                        '1': { 'value': 'field1', 'checked': false },
                                        '2': { 'value': 'field2', 'checked': false },
                                        '3': { 'value': 'field3', 'checked': true },
                                    }
                            },
                            {
                                'heading': 'none',
                                'divider': 'yes',
                                'options':
                                    {
                                        '1': { 'value': 'field1', 'checked': true },
                                        '2': { 'value': 'field2', 'checked': false },
                                        '3': { 'value': 'field3', 'checked': true },
                                    }
                            }
                        ],
                        // 'selectedKeys': ['1', '2', '3'],
                        'applyButtonConfig': {
                            'text': 'Apply',
                            'function':
                                // data includes choices and 
                                // selected keys
                                function (data) {
                                    var txt = '';
                                    for (var i in data['sections']) {
                                        var section = data['sections'][i];
                                        var sHeading = section['heading'];
                                        var options = section['options'];
                                        for (var key in options) {
                                            var properties = options[key];
                                            txt += ('Heading: ' + sHeading + '| Key: ' + key + '| Display Value: ' + properties['value'] + ',\r\n');
                                        }
                                    }
                                    txt += data['selectedKeys'];
                                    alert(txt);
                                }

                        },
                        'onchangeFunction':
                           function (data) {
                               var txt = '';
                               for (var i in data['sections']) {
                                   var section = data['sections'][i];
                                   var sHeading = section['heading'];
                                   var options = section['options'];
                                   for (var key in options) {
                                       var properties = options[key];
                                       txt += ('Heading: ' + sHeading + '| Key: ' + key + '| Display Value: ' + properties['value'] + ',\r\n');
                                   }
                               }
                               txt += data['selectedKeys'];
                               alert(txt);
                           }

                    },
                    //view control
                    {
                        'controlId': 'ddlViewControl',
                        'controlType': 'dropdown',
                        'title': 'View:',
                        'value': 'Health Summary',
                        'iconClass': 'none',
                        'sections': [
                            {
                                'heading': 'none',
                                'divider': 'yes',
                                'options': [
                                    {
                                        'iconClass': 'icon-pencil icon-dropdown',
                                        'text': 'Rename View',
                                        'events': [
                                            {
                                                'eventName': 'click',
                                                'function': function () { alert('rename'); }
                                                //add a callback method
                                            }
                                        ]

                                    },
                                    {
                                        'iconClass': 'icon-disk icon-dropdown',
                                        'text': 'Save View',
                                        'events': [
                                            {
                                                'eventName': 'click',
                                                'function': function () { alert('save'); }
                                            }
                                        ]
                                    },
                                    {
                                        'iconClass': 'fui-cross icon-dropdown',
                                        'text': 'Delete View',
                                        'events': [
                                            {
                                                'eventName': 'click',
                                                'function': function () { alert('delete'); }
                                            }
                                        ]
                                    }

                                ]
                            }
                        ]
                    }
                    ]
                }
            ];


            epmLiveGenericToolBar.generateToolBar('test', cfgs);

        });
    </script>

</asp:content>

<asp:content id="PageTitle" contentplaceholderid="PlaceHolderPageTitle" runat="server">
Application Page
</asp:content>

<asp:content id="PageTitleInTitleArea" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
My Application Page
</asp:content>

