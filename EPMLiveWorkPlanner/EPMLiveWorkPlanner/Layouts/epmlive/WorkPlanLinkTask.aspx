<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkPlanLinkTask.aspx.cs" Inherits="EPMLiveWorkPlanner.Layouts.epmlive.WorkPlanLinkTask" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script src="TreeGrid/GridE.js"> </script>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    <h4>
        <span id="spnDesc">Select the project you would like to link tasks from:</span>
    </h4>
    <br />
    <div id="divProjects" style="width:100%;height:100%">
    </div><br />
    <input type="button" id="btnBack" onclick="LoadProjects()" value="&lt; Back" disabled="true"/>
    <input type="button" id="btnNext" onclick="LoadTasks()" value="Next &gt;" />
    <input type="button" id="btnFinish" onclick="InsertTask()" value="Add Task" style="display:none;"/>

    <script language="javascript">

        var projectid = "";

        function InsertTask()
        {
            var grid = Grids.ExternalProjects;
            var oRows = grid.GetSelRows();
            if(oRows.length > 0)
            {
                if(oRows[0].Def.Name == "Task")
                {
                    var oInfo = new Object();
                    oInfo.Row = oRows[0];
                    oInfo.ProjectID = projectid;

                    parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, oInfo);
                }
                else
                {
                    alert("You may only select a leaf node task.");
                }
            }
            else
            {
                alert('Please select an item');
            }
        }

        function maximizeWindow() {     
            var currentDialog = parent.SP.UI.ModalDialog.get_childDialog();                   
            if(currentDialog != null) 
            {         
                if(!currentDialog.$Q_0) 
                {             
                    currentDialog.$1Y_0();
                }     
            }
        }

        function unMaximizeWindow() {     
            var currentDialog = parent.SP.UI.ModalDialog.get_childDialog();                   
            if(currentDialog != null) 
            {         
                if(currentDialog.$Q_0) 
                {             
                    currentDialog.$1Y_0();
                }     
            }
        }

        function LoadTasks() {

            var grid = Grids.ExternalProjects;
            
            var oRows = grid.GetSelRows();
            if(oRows.length > 0)
            {
                projectid = oRows[0].id;
                grid.Data.Layout.Param.Dataxml = "&lt;Params PlannerID='<%=Request["PlannerID"] %>' ProjectID='" + projectid + "'/&gt;";
                grid.Data.Layout.Param.Functionname = "GetExternalTasks";
                grid.Reload();

                document.getElementById("btnFinish").style.display = "";
                document.getElementById("btnNext").style.display = "none";
                document.getElementById("btnBack").disabled = false;
                document.getElementById("spnDesc").innerHTML = "Select the tasks you would like to add:";
                maximizeWindow();
            }
            else
            {
                alert('Please select an item');
            }
        }

        function LoadProjects()
        {
            unMaximizeWindow();

            var grid = Grids.ExternalProjects;

            grid.Data.Layout.Param.Dataxml = "&lt;Params PlannerID='<%=Request["PlannerID"] %>'/&gt;";
            grid.Data.Layout.Param.Functionname = "GetExternalProjects";
            grid.Reload();

            document.getElementById("btnFinish").style.display = "none";
            document.getElementById("btnNext").style.display = "";
            document.getElementById("btnBack").disabled = true;
            document.getElementById("spnDesc").innerHTML = "Select the project you would like to link tasks from:";
        }


        function doOnLoad() {
            //document.getElementById("divProjects").style.height = getHeight() - 200;
            TreeGrid({ Data: { Url: "BlankTable.xml" }, Layout: { Url: "../../_vti_bin/WorkPlanner.asmx", Method: "Soap", Function: "Execute", Namespace: "workengine.com", Param: { Functionname: "GetExternalProjects", Dataxml: "<%=sPlannerLayoutParam %>"} }, SuppressMessage: 0 }, "divProjects");
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

        _spBodyOnLoadFunctionNames.push("doOnLoad");
    </script>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Insert External Task
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Insert External Task
</asp:Content>
