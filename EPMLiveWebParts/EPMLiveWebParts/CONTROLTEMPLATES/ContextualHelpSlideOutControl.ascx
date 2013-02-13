<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContextualHelpSlideOutControl.ascx.cs" Inherits="EPMLiveWebParts.CONTROLTEMPLATES.EPMLiveWebParts.ContextualHelpSlideOutControl" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<style type="text/css">
    .sidecontentpullout {
        background-color: #EAEAEA;
        color: #999999;
        padding: 5px 3px;
        font-weight: bold;
        text-decoration: Arial, Tahoma;
        -moz-border-radius-bottomleft: 1em;
        -moz-border-radius-topleft: 1em;
        -webkit-border-bottom-left-radius: 1em;
        -webkit-border-top-left-radius: 1em;
        border-bottom-left-radius: 1em;
        border-top-left-radius: 1em;
        border-left-width: 2px;
        border-left-style: solid;
        border-left-color: #CCCCCC;
        border-top-width: 2px;
        border-top-style: solid;
        border-top-color: #CCCCCC;
        border-bottom-width: 2px;
        border-bottom-style: solid;
        border-bottom-color: #CCCCCC;
    }

    .sidecontentpullout:hover {
        background-color: #EAEAEA;
        color: #999999;
    }

    .sidecontent {
        background-color: #EAEAEA;
        color: #999999;
    }

    .sidecontent > div > div {
        padding-left: 10px;
        padding-right: 40px;
    }
</style> 

<script type="text/javascript" src="_layouts/epmlive/jquerylibrary/jquery-1.6.2.min.js"> </script>
<script type="text/javascript" src="_layouts/epmlive/slideout.js"> </script>

<asp:Literal ID="litMessages" runat="server"></asp:Literal>
<asp:Panel ID="ContentPanel" runat="server">
    <div class="sideHelp" id="sideHelp" title="<%= SlideOutTitle %>"> 
        <asp:Literal ID="litContent" runat="server"></asp:Literal>
        <input type="checkbox" onclick="javascript:hideHelp();"/>Do not show this again
    </div>
    <script type="text/javascript">
        function ajaxRequest() {
            var activexmodes = ["Msxml2.XMLHTTP", "Microsoft.XMLHTTP"]; //activeX versions to check for in IE
            if (window.ActiveXObject) { //Test for support for ActiveXObject in IE first (as XMLHttpRequest in IE7 is broken)
                for (var i = 0; i < activexmodes.length; i++) {
                    try {
                        return new ActiveXObject(activexmodes[i]);
                    } catch(e) {
                        //suppress error
                    }
                }
            } else if (window.XMLHttpRequest) // if Mozilla, Safari etc
                return new XMLHttpRequest();

            return false;
        }

        function hideHelp() {
            var request = new ajaxRequest();

            request.onreadystatechange = function() {
                if (request.readyState == 4) {
                    if (request.status == 200) {
                        if (request.responseText.trim() == 'Success') {
                            document.getElementById('sideHelp').style.visibility = 'hidden';
                            document.getElementById('sidecontent_0').style.visibility = 'hidden';
                            document.getElementById('sidecontent_0_pullout').style.visibility = 'hidden';
                        }
                    }
                }
            };

            request.open('GET', '<%= SPContext.Current.Web.ServerRelativeUrl %>/_layouts/epmlive/contextualslideout.aspx?action=hide&slideOutId=<%=SlideOutId%>', true);
            request.send(null);
        }

        var sideOutWidth = 600;
        var sideOutHeight = 300;
        var pullOutOffset = 0;
        var offset = 0;

        var sideHelpDiv = jQuery("#sideHelp");
        var masterSideOutDiv = jQuery("#master-sideout");

        if (masterSideOutDiv.length > 0) {
            var width = document.getElementById('master-sideout').style.width;
            if (width !== undefined && width !== "") { sideOutWidth = masterSideOutDiv.width(); }

            var height = document.getElementById('master-sideout').style.height;
            if (height !== undefined && height !== "") { sideOutHeight = masterSideOutDiv.height(); }

            offset = document.getElementById('master-sideout').style.top;
            if (offset !== "auto" && offset !== "" && offset !== undefined) { pullOutOffset = parseInt(offset.replace( /px/i , "")); }

            masterSideOutDiv.css("width", "");
            masterSideOutDiv.css("height", "");
            masterSideOutDiv.css("position", "");
            masterSideOutDiv.css("top", "");
        }

        sideHelpDiv.height(sideOutHeight);

        $(".sideHelp").sidecontent({
            classmodifier: "sidecontent",
            attachto: "rightside",
            width: sideOutWidth + "px",
            opacity: "1",
            pulloutpadding: "150",
            textdirection: "vertical"
        });

        //pullOutOffset += (sideOutHeight - parseInt(jQuery("#sidecontent_0_pullout").height())) / 2;
        pullOutOffset = <%= SlideOutOffset %>;
        
        jQuery("#sidecontent_0_pullout").css("top", pullOutOffset);

        jQuery("#sidecontent_0").css("top", offset);
        
        jQuery("#sidecontent_0_pullout").click(function() {
            if (parseInt(jQuery("#sidecontent_0_pullout").css("right").replace( /px/i , "")) === 0) {
                jQuery("#sidecontent_0").css("border", "2px solid #CCC");
                jQuery("#sidecontent_0").css("border-right", "none");
            }else {
                jQuery("#sidecontent_0").css("border", "none");
            }
        });
</script>
</asp:Panel>