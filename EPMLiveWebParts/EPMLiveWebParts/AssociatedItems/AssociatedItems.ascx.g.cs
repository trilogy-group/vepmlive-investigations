﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EPMLiveWebParts.AssociatedItems {
    using System.Web.UI.WebControls.Expressions;
    using System.Web.UI.HtmlControls;
    using System.Collections;
    using System.Text;
    using System.Web.UI;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Microsoft.SharePoint.WebPartPages;
    using System.Web.SessionState;
    using System.Configuration;
    using Microsoft.SharePoint;
    using System.Web;
    using System.Web.DynamicData;
    using System.Web.Caching;
    using System.Web.Profile;
    using System.ComponentModel.DataAnnotations;
    using System.Web.UI.WebControls;
    using System.Web.Security;
    using System;
    using Microsoft.SharePoint.Utilities;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    using System.Web.UI.WebControls.WebParts;
    using Microsoft.SharePoint.WebControls;
    
    
    public partial class AssociatedItems {
        
        protected global::System.Web.UI.HtmlControls.HtmlGenericControl associatedItemsDiv;
        
        protected global::System.Web.UI.WebControls.Label lblError;
        
        public static implicit operator global::System.Web.UI.TemplateControl(AssociatedItems target) 
        {
            return target == null ? null : target.TemplateControl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.HtmlControls.HtmlGenericControl @__BuildControlassociatedItemsDiv() {
            global::System.Web.UI.HtmlControls.HtmlGenericControl @__ctrl;
            @__ctrl = new global::System.Web.UI.HtmlControls.HtmlGenericControl("div");
            this.associatedItemsDiv = @__ctrl;
            @__ctrl.ID = "associatedItemsDiv";
            ((System.Web.UI.IAttributeAccessor)(@__ctrl)).SetAttribute("style", "float: left;");
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Label @__BuildControllblError() {
            global::System.Web.UI.WebControls.Label @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Label();
            this.lblError = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "lblError";
            @__ctrl.Text = "This page is not a display form page. Please add this webpart on a display form p" +
                "age.";
            @__ctrl.ForeColor = global::System.Drawing.Color.Red;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControlTree(global::EPMLiveWebParts.AssociatedItems.AssociatedItems @__ctrl) {
            global::System.Web.UI.HtmlControls.HtmlGenericControl @__ctrl1;
            @__ctrl1 = this.@__BuildControlassociatedItemsDiv();
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(@__ctrl1);
            global::System.Web.UI.WebControls.Label @__ctrl2;
            @__ctrl2 = this.@__BuildControllblError();
            @__parser.AddParsedSubObject(@__ctrl2);
            @__ctrl.SetRenderMethodDelegate(new System.Web.UI.RenderMethod(this.@__Render__control1));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__Render__control1(System.Web.UI.HtmlTextWriter @__w, System.Web.UI.Control parameterContainer) {
            @__w.Write(@"
<style type=""text/css"">
    .slidingDiv {
        width: 100%;
        padding: 20px;
        border: 1px thin black;
        -webkit-box-shadow: 0px 3px 20px rgba(50, 50, 50, 0.8);
        -moz-box-shadow: 0px 3px 20px rgba(50, 50, 50, 0.8);
        box-shadow: 0px 3px 20px rgba(50, 50, 50, 0.8);
        position: absolute;
        width: 200px;
        background-color: white;
    }

    .slidingDivClose {
        float: right;
        font-size: large;
    }

    .slidingDivHeader {
        float: left;
        color: black;
        font-size: large;
    }

    .slidingDivAdd {
        float: right;
    }

    .listMainDiv {
        float: left;
        padding: 5px;
        margin-right: 5px;
    }

    .pipeSeperator {
        float: left;
        font-size: large;
    }

    .associateditemscontextmenu {
        list-style: none;
        cursor: pointer;
        position: absolute;
        right:25px;
    }
</style>

<script type=""text/javascript"">

    $(function () {
        fillWebPartData();
    });

    function fillWebPartData() {
        if (dataXml != '') {
            $(""#");
        @__w.Write(associatedItemsDiv.ClientID);

            @__w.Write(@""").hide();
            $(""#associatedItemsLoadDiv"").show();

            EPMLiveCore.WorkEngineAPI.Execute(""GetAssociatedItems"", dataXml, function (response) {
                var divHTML = response.toString().replace(""<Result Status=\""0\"">"", """").replace(""</Result>"", """");
                $(""#");
            @__w.Write(associatedItemsDiv.ClientID);

            @__w.Write("\").html(\"\");\r\n                $(\"#");
            @__w.Write(associatedItemsDiv.ClientID);

            @__w.Write(@""").html(divHTML);
                $("".slidingDiv"").hide();

                $("".listMainDiv"").mouseover(function () {
                    $("".slidingDiv"").hide();
                    $(this).find("".slidingDiv"").show();
                });
                $("".slidingDiv"").mouseover(function () {
                    $(this).show();
                });
                $(""#");
            @__w.Write(associatedItemsDiv.ClientID);

            @__w.Write(@""").mouseout(function () {
                    $("".slidingDiv"").hide();
                });

                window.SP.SOD.notifyScriptLoadedAndExecuteWaitingJobs('EPMLive.Navigation.js');

                $("".associateditemscontextmenu"").each(function () {
                    window.epmLiveNavigation.addContextualMenu($(this), null, true, '-1', { ""delete"": ""fillWebPartData"" });
                });

                $(""#associatedItemsLoadDiv"").hide();
                $(""#");
            @__w.Write(associatedItemsDiv.ClientID);

            @__w.Write("\").show();\r\n                \r\n\r\n            });\r\n        }\r\n    }\r\n\r\n\r\n\r\n\r\n    fu" +
                    "nction showItemUrl(weburl) {\r\n        $.ajax({\r\n            type: \"POST\",\r\n     " +
                    "       url: weburl,\r\n            success: function (ticket) {\r\n                i" +
                    "f (ticket.indexOf(\"General Error\") != 0) {\r\n                    var listInfo = t" +
                    "icket.split(\'|\');\r\n\r\n                    var viewSiteContentUrl = listInfo[0] + " +
                    "\"/_layouts/epmlive/gridaction.aspx?action=associateditems&list=\" + listInfo[3] +" +
                    " \"&field=\" + listInfo[1] + \"&LookupFieldList=\" + listInfo[2] + \"&Source=\" + docu" +
                    "ment.location.href;\r\n                    var options = { url: viewSiteContentUrl" +
                    ", showMaximized: true };\r\n                    SP.SOD.execute(\'SP.UI.Dialog.js\', " +
                    "\'SP.UI.ModalDialog.showModalDialog\', options);\r\n                }\r\n             " +
                    "   else {\r\n                    alert(ticket);\r\n                }\r\n            }\r" +
                    "\n        });\r\n    }\r\n\r\n    function showNewForm(weburl) {\r\n        var options =" +
                    " { url: weburl, showMaximized: false, dialogReturnValueCallback: function (dialo" +
                    "gResult) { fillWebPartData(); } };\r\n        SP.SOD.execute(\'SP.UI.Dialog.js\', \'S" +
                    "P.UI.ModalDialog.showModalDialog\', options);\r\n    }\r\n\r\n    function showItemPopu" +
                    "p(siteurl, webid, listid, itemid) {\r\n        showSharePointPopup(siteurl + \'/_la" +
                    "youts/epmlive/gridaction.aspx?action=getcontextmenus&webid=\' + webid +\r\n        " +
                    "    \'&listid=\' + listid + \'&ID=\' + itemid, null, false, true, null, {\r\n         " +
                    "       gridId: \"myDiv\",\r\n                rowId: \"myDiv\",\r\n                col: \"" +
                    "myDiv\"\r\n            }, 300, 400);\r\n    }\r\n\r\n    function emptyFunction() {\r\n    " +
                    "}\r\n\r\n    function showSharePointPopup(url, title, allowMaximize, showClose, func" +
                    ", funcParams, width, height) {\r\n        if (allowMaximize == null) allowMaximize" +
                    " = true;\r\n        if (showClose == null) showClose = true;\r\n        if (func == " +
                    "null) func = emptyFunction;\r\n\r\n        var options;\r\n\r\n        if (width !== und" +
                    "efined && height !== undefined) {\r\n            options = {\r\n                titl" +
                    "e: title,\r\n                allowMaximize: allowMaximize,\r\n                showCl" +
                    "ose: showClose,\r\n                url: url,\r\n                dialogReturnValueCal" +
                    "lback: Function.createCallback(Function.createDelegate(null, func), funcParams)," +
                    "\r\n                width: width,\r\n                height: height\r\n            };\r" +
                    "\n        } else {\r\n            options = { title: title, allowMaximize: allowMax" +
                    "imize, showClose: showClose, url: url, dialogReturnValueCallback: Function.creat" +
                    "eCallback(Function.createDelegate(null, func), funcParams) };\r\n        }\r\n\r\n    " +
                    "    SP.UI.ModalDialog.showModalDialog(options);\r\n    }\r\n\r\n</script>\r\n\r\n\r\n<div id" +
                    "=\"associatedItemsLoadDiv\" style=\"display: none;\">\r\n    <img src=\"../_layouts/15/" +
                    "epmlive/images/mywork/loading16.gif\" />\r\n</div>\r\n");
            parameterContainer.Controls[0].RenderControl(@__w);
            @__w.Write("\r\n");
            parameterContainer.Controls[1].RenderControl(@__w);
            @__w.Write("\r\n");
        }
        
        private void InitializeControl() {
            this.@__BuildControlTree(this);
            this.Load += new global::System.EventHandler(this.Page_Load);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        protected virtual object Eval(string expression) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        protected virtual string Eval(string expression, string format) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression, format);
        }
    }
}
