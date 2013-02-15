<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="settings.aspx.cs" Inherits="WorkEnginePPM.settings" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<%=strOutput %>

<script language=javascript>
    function getHeight()
    {
        var scnHei;
        if (self.innerHeight) // all except Explorer
	    {
		    //scnWid = self.innerWidth;
		    scnHei = self.innerHeight;
	    }
	    else if (document.documentElement && document.documentElement.clientHeight)
	    {
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

    _spBodyOnLoadFunctionNames.push("Body_OnResize");

    function Body_OnResize()
    {
	    var frm = document.getElementById("frmPPM");
        if(frm)
        {
            frm.style.height= (getHeight() - 25);
        }
    }
</script>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
PortfolioEngine Settings
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
PortfolioEngine Settings
</asp:Content>
