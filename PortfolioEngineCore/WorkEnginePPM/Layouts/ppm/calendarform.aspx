<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="calendarform.aspx.cs" Inherits="WorkEnginePPM.Layouts.ppm3.calendarform" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

<link rel="stylesheet" type="text/css" href="styles/form.css"/>
<script src="general.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="ribbon/ribbon2.css" />
<script src="ribbon/ribbon2.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="Styles/Dialog.css" />
<style type="text/css">
.ms-dialog .ms-bodyareacell {
    padding-left: 0 !important;
    padding-right: 0 !important;
}
.ms-cui-tabBody {
    border-bottom: 1px solid #898D92 !important;
}
</style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<div>
    <div style="display: none;">
        <asp:HiddenField ID="hiddenData" runat="server"></asp:HiddenField>
    </div>
    <asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
    <asp:Panel ID="pnlMain" runat="server" Visible="true">
    <table width="100%" cellspacing="0">
        <tr>
            <td style="height:1px;" width="250" class="topcell"></td>
            <td style="height:1px;" class="topcell"></td>
        </tr>
        <tr style="display:none;">
            <td width="250" class="descriptioncell">
                Field Id
            </td>
            <td class="controlcell">
                <asp:TextBox ID="txtId" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="250" class="descriptioncell">
                Calendar Name
            </td>
            <td class="controlcell">
                <asp:TextBox ID="txtName" runat="server" CssClass="input" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="250" class="descriptioncell">
                Calendar Description
            </td>
            <td class="controlcell">
                <asp:TextBox ID="txtDesc" runat="server" CssClass="input" Width="200px"></asp:TextBox>
            </td>
        </tr>
                   
    </table>
    </asp:Panel>
	<div style="float:right;">
		<div class="button-container" style="float:none;">
		    <asp:Button id="btnOK" text="OK" onclientclick="javascript:dialogEvent('btnOK');" onclick="btnOK_Click" class="button-new green" style="width:75px;" runat="server" />
		    <asp:Button id="btnDelete" text="Delete" onclientclick="javascript:dialogEvent('btnDelete');" onclick="btnDelete_Click" class="button-new green" style="width:75px;" runat="server" />
		    <asp:Button id="btnCancel" text="Cancel" onclientclick="javascript:dialogEvent('btnCancel');" class="button-new silver" style="width:75px;" runat="server" />
		</div>
	</div>
</div>
<script type="text/javascript">

    function dialogEvent(action) {
        switch (action) {
            case "btnOK":
                __doPostBack('<%= btnOK.UniqueID %>', '');
                window.setTimeout("SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, '');", 100);
                break;
            case "btnDelete":
                __doPostBack('<%= btnDelete.UniqueID %>', '');
                window.setTimeout("SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, '');", 100);
                break;
            case "btnCancel":
                window.setTimeout("SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, '');", 100);
                break;
        }
    }
</script>
<script type="text/javascript">
    function OnCostTypeSavedOK() {
        alert("OnCostTypeSavedOK");
        //var popup1 = window.parent.$find('btnShowModalPopup');
        //var btnOK = window.parent.document.getElementById(popup1.get_OkControlID());
        //btnOK.click();
    }
    function OnCostTypeClose() {
        alert("OnCostTypeClose");
        //var popup1 = window.parent.$find('btnShowModalPopup');
        //var btnClose = window.parent.document.getElementById(popup1.get_CancelControlID());
        //btnClose.click();
    }

</script>    
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
<%=DialogTitle %>
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
<%=DialogTitle%>
</asp:Content>