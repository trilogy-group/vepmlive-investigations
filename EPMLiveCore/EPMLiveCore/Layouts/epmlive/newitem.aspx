<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newitem.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.newitem" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="Create Item" EncodeMethod='HtmlEncode'/>
</asp:Content>

<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	<asp:Label ID="lblTitle" runat="server" Text="Create Item"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
<asp:Panel ID="Panel4" runat="server" Visible="true">
    
</asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
<asp:Panel ID="Panel2" runat="server" Visible="false">
    <font color="red"><asp:Label ID="label1" runat="server"></asp:Label></font>
</asp:Panel>

<script language="javascript">

</script>
                <link rel="STYLESHEET" type="text/css" href="dhtml/xgrid/dhtmlxgrid.css"/>
    <link rel="STYLESHEET" type="text/css" href="dhtml/xgrid/dhtmlxgrid_skins.css"/>

    <script>        _css_prefix = "DHTML/xgrid/"; _js_prefix = "DHTML/xgrid/"; </script>

    <script src="DHTML/xgrid/dhtmlxcommon.js"></script>
    <script src="DHTML/xgrid/dhtmlxgrid.js"></script>
    <script src="DHTML/xgrid/dhtmlxgridcell.js"></script>
    <script src="DHTML/xtreegrid/dhtmlxtreegrid.js"></script>

    <style>.menuTable{background-color:#ffffff;}.contextMenuover, .contextMenudown{background-color:#9ac2e5;}.contextMenuover td{color:#000000;} </style>

<input type="hidden" name="hdnSelectedWorkspace" id="hdnSelectedWorkspace"/>
<input type="hidden" name="baseurl" name="id" value="<%=this.URL%>"/>

<TABLE border="0" cellspacing="0" cellpadding="0" class="ms-propertysheet" width="100%">
	
	<wssuc:InputFormSection ID="InputFormSection1" Title="Select Workspace"
		Description=""
		runat="server" width="10">
		<Template_Description>
		    Select a workspace on which to create your new item.
		                <div  width="600" id="loadinggrid" align="center">
    	        <img src="../images/GEARS_AN.GIF" style="vertical-align: middle;"/> Loading Workspaces...
            </div>
		</Template_Description>
		<Template_InputFormControls>
		    <wssuc:InputFormControl ID="InputFormControl1" LabelText="" runat="server">
                <Template_Control>
                    <div id="grid" style="width:600;display:none;" ></div>
                    <img src="/_layouts/images/blank.gif" width="600" height="1" />
                </Template_Control>
            </wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
    <wssuc:ButtonSection ID="ButtonSection1" runat="server">
		<Template_Buttons>
			<asp:PlaceHolder ID="PlaceHolder1" runat="server">
				<asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" Text="Create Item" id="btnOK" accesskey="" Width="150" OnClientClick="if(!checkUrl()){return;};"/>
			</asp:PlaceHolder>
		</Template_Buttons>
	</wssuc:ButtonSection>
</table>

<script language="javascript">
    mygrid = new dhtmlXGridObject('grid');
    
    mygrid.setImagePath("dhtml/xgrid/imgs/");
    mygrid.setSkin("modern");

    mygrid.setImageSize(1,1);
    mygrid.attachEvent("onXLE",clearLoader);
    mygrid.attachEvent("onRowSelect",mygridChange);
    mygrid.enableAutoHeigth(true);
    mygrid.init();
    
    mygrid.loadXML("getworkspacexml.aspx?List=<%=HttpUtility.HtmlEncode(Request["List"])%>");
    
    function clearLoader(id)
    {
        document.getElementById("grid").style.display = "";
        document.getElementById("loadinggrid").style.display = "none";
    }
    function mygridChange(id)
    {
        document.getElementById("hdnSelectedWorkspace").value=mygrid.getUserData(mygrid.getSelectedRowId(),"NewItemURL");
    }
    function checkUrl()
    {
        if(document.getElementById("hdnSelectedWorkspace").value == "")
        {
            alert('Select a Workspace');
            return false;
        }
        else
        {
            if(mygrid.getUserData(mygrid.getSelectedRowId(),"CanPublish") == "Yes")
            {
                location.href=document.getElementById("hdnSelectedWorkspace").value + "?Source=<%=HttpUtility.UrlEncode(Request["Source"])%>";
            }
            else
            {
                alert('You cannot add an item to the selected workspace');
                return false;
            }
        }
    }
</script>
</asp:Content>

