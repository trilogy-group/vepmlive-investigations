<%@ Assembly Name="TimeSheets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="TimeSheets.gettsreport"%> 

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Timesheet Report</title>
    <link rel="stylesheet" type="text/css" href="/_layouts/1033/styles/core.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="5">
            <tr>
                <td class="ms-descriptiontext">
                    Select a Start and End date to view the timesheet report.
                </td>
            </tr>
            <tr>
                <td class="ms-descriptiontext">
                    Start Date:<br />
                    <SharePoint:DateTimeControl runat="server" DateOnly="true" ID="dtStart"></SharePoint:DateTimeControl>
                </td>
            </tr>
            <tr>
                <td class="ms-descriptiontext">
                    End Date:<br />
                    <SharePoint:DateTimeControl runat="server" DateOnly="true" ID="dtEnd"></SharePoint:DateTimeControl>
                </td>
            </tr>
            <tr>
                <td align="left"><asp:Button runat="server" Text="Run Report" onclick="Button1_Click" CssClass="ms-input"/></td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
