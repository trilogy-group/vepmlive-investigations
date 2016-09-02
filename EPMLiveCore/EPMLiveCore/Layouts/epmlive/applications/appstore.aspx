<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="appstore.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.applications.appstore" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <script language="javascript">

        function getTop(obj) {
            var posY = obj.offsetTop;

            while (obj.offsetParent) {
                posY = posY + obj.offsetParent.offsetTop;
                if (obj == document.getElementsByTagName('body')[0]) { break }
                else { obj = obj.offsetParent; }
            }

            return posY;
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


        function doOnLoad() {
            document.getElementById("iframe1").style.height = (getHeight() - getTop(document.getElementById("iframe1")) - 10) + "px";

            document.getElementById("iframe1").src = "https://apps.epmlive.com";  
        }

        _spBodyOnLoadFunctionNames.push("doOnLoad");

    </script>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

<iframe src="" id="iframe1" width="100%" height="100%" frameborder="0" scrolling="auto"></iframe>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
EPM Live Applications Store
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
EPM Live Applications Store
</asp:Content>
