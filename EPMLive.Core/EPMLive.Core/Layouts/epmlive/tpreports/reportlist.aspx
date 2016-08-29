<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveCore.reportlist" MasterPageFile="~/_layouts/application.master"%> 

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	EPM Live Time-Phased Data
</asp:Content>
<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	EPM Live Time-Phased Data
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    The following is a list of all time-phased data available
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
    <table border="0" width="550" cellpadding="1" cellspacing="0">
        <tr>
            <td width="250" class="ms-vh2-nofilter">Report name</td>
            <td width="100" class="ms-vh2-nofilter">This Site Only</td>
            <td width="100" class="ms-vh2-nofilter">Rollup</td>
        </tr>
        <tr>
            <td class="ms-vb2">Time-Phased Data by Assignment</td>
            <td class="ms-vb2"><img src="/_layouts/images/XLS16.GIF" /> <asp:LinkButton ID="hltpreport" runat="server" OnCommand="hltpreport_OnClick" Text="Export Data" CommandArgument="tpreport.aspx"></asp:LinkButton></td>
            <td class="ms-vb2"><img src="/_layouts/images/XLS16.GIF" /> <asp:LinkButton ID="hltpreportrollup" runat="server" OnCommand="hltpreport_OnClick" Text="Export Data" CommandArgument="tpreport.aspx?rollup=true"></asp:LinkButton></td>
        </tr>
        <tr>
            <td class="ms-vb2">Remaining Work Capacity By Resource</td>
            <td class="ms-vb2"><img src="/_layouts/images/XLS16.GIF" /> <asp:LinkButton ID="capreport" runat="server" OnCommand="hltpreport_OnClick" Text="Export Data" CommandArgument="capreport.aspx"></asp:LinkButton></td>
            <td class="ms-vb2"><img src="/_layouts/images/XLS16.GIF" /> <asp:LinkButton ID="capreportrollup" runat="server" OnCommand="hltpreport_OnClick" Text="Export Data" CommandArgument="capreport.aspx?rollup=true"></asp:LinkButton></td>
        </tr>
    </table>
</asp:Content>