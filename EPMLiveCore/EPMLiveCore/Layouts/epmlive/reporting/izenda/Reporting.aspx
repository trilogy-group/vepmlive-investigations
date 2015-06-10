<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporting.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.Reporting" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <iframe src="redirect.aspx?rn=<%=Request["rn"]%>" id="frmReport" style="width:100%;height:100%">

    </iframe>

    <script language="javascript">
        // Here "addEventListener" is for standards-compliant web browsers and "attachEvent" is for IE Browsers.
        var eventMethod = window.addEventListener ? "addEventListener" : "attachEvent";
        var eventer = window[eventMethod];

        // if 
        //    "attachEvent", then we need to select "onmessage" as the event. 
        // if 
        //    "addEventListener", then we need to select "message" as the event

        var messageEvent = eventMethod == "attachEvent" ? "onmessage" : "message";

        // Listen to message from child IFrame window
        eventer(messageEvent, function (e) {
            if (event.data === "closed") {
                location.reload();
            }
        }, false);

        function setHeight() {
            document.getElementById("frmReport").style.height = (getHeight() - getTop(document.getElementById("frmReport")) - 40) + "px";
        }

        function getHeight() {
            var scnHei;
            if (self.innerHeight) // all except Explorer
            {
                //scnWid = self.innerWidth;
                scnHei = self.innerHeight;
            }
            else if (document.documentElement && document.documentElement.clientHeight) {
                //scnWid = document.documentElement.clientWidth;
                scnHei = document.documentElement.clientHeight;
            }
            else if (document.body) // other Explorers
            {
                //scnWid = document.body.clientWidth;
                scnHei = document.body.clientHeight;
            }
            return scnHei;
        }

        function getWidth() {
            var scnWid;
            if (self.innerHeight) // all except Explorer
            {
                scnWid = self.innerWidth;
                //scnHei = self.innerHeight;
            }
            else if (document.documentElement && document.documentElement.clientHeight) {
                scnWid = document.documentElement.clientWidth;
                //scnHei = document.documentElement.clientHeight;
            }
            else if (document.body) // other Explorers
            {
                scnWid = document.body.clientWidth;
                //scnHei = document.body.clientHeight;
            }
            return scnWid;
        }
        function getTop(obj) {
            var posY = obj.offsetTop;

            while (obj.offsetParent) {
                posY = posY + obj.offsetParent.offsetTop;
                if (obj == document.getElementsByTagName('body')[0]) { break }
                else { obj = obj.offsetParent; }
            }

            return posY;
        }
        _spBodyOnLoadFunctionNames.push("setHeight");
        </script>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
EPM Live Reporting
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
EPM Live Reporting
</asp:Content>
