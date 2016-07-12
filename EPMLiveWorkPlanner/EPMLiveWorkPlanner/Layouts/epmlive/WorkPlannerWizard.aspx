<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkPlannerWizard.aspx.cs" Inherits="EPMLiveWorkPlanner.Layouts.epmlive.WorkPlannerWizard" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <link rel="stylesheet" href="modal/modal.css" type="text/css" /> 
    <script type="text/javascript" src="modal/modal.js"></script>
    <script src="dhtml/xlayout/dhtmlxcommon.js"></script> 
    <link href="workplannerwizard.css" rel="stylesheet" type="text/css" />

        <style>
        .itemtable
        {
            width: 100%;
            height: 100px;
            margin-bottom: 10px;
            cursor: pointer;
        }
        .itemtable:hover
        {
            background-color: #fafafa;
        }

	.wizardBoxes a
	{
		margin-left:13px;
	}

	.titletd
	{
		vertical-align:top;
		padding-right:5px;
		text-align:left;
	}
    .titletd span {
        font-family:"Open Sans Semi Bold",Helvetica,Arial;        
    }
    .btn
    {
        height: 100% !important;
    }


input[type=checkbox] {
display:none;
}
 
input[type=checkbox] + label
{
background-image:url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACgAAAAQCAYAAABk1z2tAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAA3XAAAN1wFCKJt4AAAAB3RJTUUH3QoREw0jycifHAAAAOlJREFUSMfN1a1KRFEUxfHfDAMjFpOa/QKDYBCLeLfJR7Dqc5gsBoMP4wtYzoVJgoapWm2CRYui5SDDBLmOMOfstg9nL/4s2HtRefXatv2aZbBpml6Xf//V79fu4GDejvxVf9BlKKW0iEtcF3PwF7gFjLCLrXkD9qdghlP9EsYZ7hFnxQBTSjsYp5RWc7+Me2zgDnsR8VLSwQtsYpRS2s7OreEBRxHxWmKLJwFPs2PrGWoFNziIiLdSZ+YHMCLesY8nDHGLk/yuOGCG/MQhznEcER/VHOoJyGdcVZcksyZE15pVv/osrr6+AaojSGl/czSzAAAAAElFTkSuQmCC);
background-position:-24px 0px;
height: 16px;
width: 16px;
display:inline-block;
padding: 0 0 0 0px;
cursor:pointer;
}


input[type=checkbox]:checked + label
{
background-image:url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACgAAAAQCAYAAABk1z2tAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAA3XAAAN1wFCKJt4AAAAB3RJTUUH3QoREw0jycifHAAAAOlJREFUSMfN1a1KRFEUxfHfDAMjFpOa/QKDYBCLeLfJR7Dqc5gsBoMP4wtYzoVJgoapWm2CRYui5SDDBLmOMOfstg9nL/4s2HtRefXatv2aZbBpml6Xf//V79fu4GDejvxVf9BlKKW0iEtcF3PwF7gFjLCLrXkD9qdghlP9EsYZ7hFnxQBTSjsYp5RWc7+Me2zgDnsR8VLSwQtsYpRS2s7OreEBRxHxWmKLJwFPs2PrGWoFNziIiLdSZ+YHMCLesY8nDHGLk/yuOGCG/MQhznEcER/VHOoJyGdcVZcksyZE15pVv/osrr6+AaojSGl/czSzAAAAAElFTkSuQmCC);
background-position:0px 0px;
height: 16px;
width: 16px;
display:inline-block;
padding: 0 0 0 0px;
cursor:pointer;
}


body {
font-family: Open Sans Regular, Helvetica;
}



        
    </style>

    <script language="javascript">

        var sItemID = "<%=sItemID %>";
        var sProjectListId = "<%=sProjectListId %>";
        var sPlannerID = "<%=sPlannerID %>";
        var sProjectType = "<%=sProjectType %>";
        var sTaskListId = "<%=sTaskListId %>";
        var sProjectName = "<%=sProjectName.Replace("\"","&quot;") %>";
        var sSetDefault = "<%=Request["SetDefault"] %>";

        var sSource = "<%=System.Web.HttpUtility.UrlEncode(Request["Source"]) %>";

        function DoPlanner() {

            var val = document.getElementById("<%=ddlChildParent.ClientID %>").value.split('.');

            var url = "gridaction.aspx?action=gotoplannerpc&webid=" + val[0] + "&ID=" + val[2] + "&listid=" + val[1];

            if (sSource != "")
                url += "&source=" + sSource;

            <%if(Request["dodialog"] == "1"){%>
                url += "&isdlg=1";
            <%}%>
            parent.location.href = url;

        }

        function SelectPlanner(planner) {

            var sPlannerInfo = planner.split('|');

            sPlannerID = sPlannerInfo[0];
            sProjectType = sPlannerInfo[1];

            var chkDefault = document.getElementById("chkDefault");
            if (chkDefault)
                sSetDefault = chkDefault.checked

            Redirect();
        }

        function SelectType(type) {

            sProjectType = type;

            Redirect();
        }

        function SelectItemDD(item) {

            sItemID = item;

            Redirect();
        }

        function ApplyTemplate(t) {
            if (t == "-101") {
                location.href = "workplannerwizard.aspx?id=" + sItemID + "&listid=" + sProjectListId + "&Planner=" + sPlannerID + "&PType=" + sProjectType + "&tasklistid=" + sTaskListId + "&SetDefault=" + sSetDefault + "&PCSelected=1&isdlg=1&Upload=1&Source=<%=System.Web.HttpUtility.UrlEncode(Request["Source"])%>";
            }
            else {
                sm("dlgTemplate", 150, 50);
                dhtmlxAjax.post("WorkPlannerAction.aspx", "Action=ApplyTemplate&ID=" + sItemID + "&Planner=" + sPlannerID + "&Template=" + t + "&PType=" + sProjectType + "&ProjectName=" + sProjectName, ApplyTemplateClose);
            }
        }

        function ApplyTemplateClose(loader) {
            if (loader.xmlDoc.responseText != null) {
                if (loader.xmlDoc.responseText != null) {
                    if (loader.xmlDoc.responseText.trim() != "Success")
                        alert(loader.xmlDoc.responseText);
                    else {
                        GoToPlanner();
                    }
                }
                else
                    alert("Response contains no XML");
            }
        }

        function Redirect() {

            location.href = "workplannerwizard.aspx?id=" + sItemID + "&listid=" + sProjectListId + "&Planner=" + sPlannerID + "&PType=" + sProjectType + "&tasklistid=" + sTaskListId + "&SetDefault=" + sSetDefault + "&PCSelected=1&isdlg=1&Source=<%=System.Web.HttpUtility.UrlEncode(Request["Source"])%>";

        }

        function GoToPlanner() {
            if (sPlannerID == "MPP") {
                location.href = "getproject.aspx?id=" + sItemID + "&listid=" + sProjectListId + "&Source=<%=System.Web.HttpUtility.UrlEncode(Request["Source"]) %>";
            }
            else if (sProjectType == "Online") {
                var url = "workplanner.aspx?id=" + sItemID + "&listid=" + sProjectListId + "&Planner=" + sPlannerID + "&PType=" + sProjectType + "&tasklistid=" + sTaskListId + "&SetDefault=" + sSetDefault + "&PCSelected=1&Source=<%=System.Web.HttpUtility.UrlEncode(Request["Source"]) %>";
                   <%if(Request["dodialog"] == "1"){%>
                        url += "&isdlg=1";
                    <%}%>
                parent.location.href = url;
            }
            else {
                location.href = "openmpp.aspx?Planner=" + sPlannerID + "&ProjectName=" + sProjectName + "&listid=" + sProjectListId + "&isdlg=1&Source=<%=System.Web.HttpUtility.UrlEncode(Request["Source"]) %>";
            }
    }

    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    <asp:Panel ID="pnlUpload" runat="server" Visible="false">
        <asp:Label ID="lblUploadError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        Upload Project File: <br/>
        <asp:FileUpload ID="FileUpload" runat="server" /><br /> <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" /> <asp:Button ID="Button1" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
    </asp:Panel>

    <asp:Panel ID="pnlUploadDone" runat="server" Visible="false">
        <script language="javascript">
            GoToPlanner();
        </script>
    </asp:Panel>

    <asp:Panel ID="pnlParentChild" runat="server" Visible="false">

        <div id="div3" style="width:200;padding:10px">
            <table>
                <tr>
                    <td>Select Project: <asp:DropDownList id="ddlChildParent" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td class=ms-sectionline height=2 colSpan=2><IMG alt="" src="/_layouts/images/blank.gif" width=1 height=1></td>
                </tr>

                <tr>
                    <td align="right" colspan="2">
                        <input type="button" value="Go" onclick="DoPlanner();" class="ms-ButtonHeightWidth" style="width:100px"/>
                        <input type="button" value="Cancel" onclick="Close();" class="ms-ButtonHeightWidth" style="width:100px"/>
                    </td>
                </tr>
            </table>
        </div>

    </asp:Panel>

    <asp:Panel ID="pnlPlanner" runat="server" Visible="false">

        <!--<h4>Select Planner</h4><br />-->
        <div style="height:22px;overflow:auto;text-align:center;">
            <input type="checkbox" value="setdefault" id="chkDefault" name="chkDefault" /><label for="chkDefault"></label>
	    <font style="position:relative;top:-1px;color:#666666;">Use as default planner</font>
        </div><br />
        <div style="text-align:center;max-height:600px;overflow:auto;font-family:'Open Sans Regular',Helvetica,Arial;" class="wizardBoxes">
            <%=sOutputHtml %>
        </div>
        
    </asp:Panel>

    <asp:Panel ID="pnlItem" runat="server" Visible="false">
    
        Select Item: 
        <select onchange="SelectItemDD(this.options[this.selectedIndex].value)">
            <%=sOutputHtml %>
        </select>

    </asp:Panel>



    <asp:Panel ID="pnlTemplate" runat="server" Visible="false">
    
        <h4>Select Template</h4><br />

        <%=sOutputHtml %>

        <div id="dlgTemplate" class="dialog">
            <table width="100%">
                <tr>
                    <td align="center" class="ms-sectionheader">
                        <img src="../images/GEARS_ANv4.GIF" style="vertical-align: middle;"/><br />
                        <H3 class="ms-standardheader" id="dlgNormalText">Applying Template...</h3>
                    </td>
                </tr>
                    
            </table>
        </div> 

    </asp:Panel>

    <asp:Panel ID="pnlDone" runat="server" Visible="false">
         <script language="javascript">
             GoToPlanner();
         </script>
    </asp:Panel>

    <script>
        initmb();
    </script>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Planner Wizard
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
    Planner Wizard
</asp:Content>
