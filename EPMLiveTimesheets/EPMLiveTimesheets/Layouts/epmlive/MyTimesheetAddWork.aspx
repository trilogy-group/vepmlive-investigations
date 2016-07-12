<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyTimesheetAddWork.aspx.cs" Inherits="TimeSheets.Layouts.epmlive.MyTimesheetAddWork" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    
    <script src="TreeGrid/GridE.js"> </script>
    <link rel="stylesheet" href="modal/modal.css" type="text/css" /> 
    <script type="text/javascript" src="modal/modal.js"></script>
    <script src="MyTimesheetAddWork.js"> </script>

    <style>
        #s4-ribbonrow{ height:140px !important}
    </style>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    <div id="divSearch" style="width:100%;display:none;">

        <h4>Search</h4>
        Field: <asp:DropDownList ID="ddlField" runat="server"></asp:DropDownList> Value: <input type="text" name="txtSearch" id="txtSearch" /> <input type="button" value="Search" onclick="SearchWork()" />
    </div>

    <div style="width:100%">
        <treegrid Data_Url="../../_vti_bin/WorkEngine.asmx" Data_Method="Soap" Data_Function="Execute" Data_Namespace="workengine.com" Data_Param_Function="timesheet_GetWork" Data_Param_Dataxml="<%=sLayoutParam %>"/>
    </div>

    <div align="center" id="divMessage" width="100%" class="dialog"><img style="vertical-align:middle;" src="/_layouts/images/gears_anv4.gif"/>&nbsp;<span id="spnMessage"></span></div>

    <div id="viewNameDiv2" style="display:none;width:200;padding:10px">
        View Name:<br />
        <input type="text" class="ms-input" name="viewname2" id="viewname2"/><br /><br />
        <input type="checkbox" name="chkViewDefault2" id="chkViewDefault2" /> Default View <br /><br />
        <input type="button" value="OK" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, document.getElementById('viewname2').value + '|' + document.getElementById('chkViewDefault2').checked); return false;" class="ms-ButtonHeightWidth" style="width:100px" target="_self" /> &nbsp;

        <input type="button" value="Cancel" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel, 'Cancel clicked'); return false;" class="ms-ButtonHeightWidth" style="width:100px" target="_self" />  
    </div>

    <script language="javascript">
        sLayout = '<%=sLayoutParamShort %>';
        TSUID = '<%=TSUID %>';
        NonWork = <%=NonWork %>;
        OtherWork = <%=OtherWork %>;
        Views = <%=Views %>;
        CurrentView = '<%=CurrentView %>';
        CurrentViewId = '<%=CurrentViewId %>';
        var viewNameDiv2 = document.getElementById("viewNameDiv2");

        siteUrl = '<%=siteurl %>';
        initmb();

        function maximizeWindow(){

            try
            {
                var currentDialog = SP.UI.ModalDialog.get_childDialog();
                if(currentDialog != null){
                    if(!currentDialog.$S_0){
                        currentDialog.$z();
                    }
                }
            }catch(e){}


        }
        document.getElementsByTagName("html")[0].className = "ms-dialog";
    </script>
    
    <asp:Literal ID="litJsHook" runat="server"></asp:Literal>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Add Work
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
    Add Work
</asp:Content>
