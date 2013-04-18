<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadProfilePicture.aspx.cs" Inherits="EPMLiveWebParts.Layouts.epmlive.UploadProfilePicture" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<style>
.profileInput
{
    min-width: 6em;
    padding: 7px 10px;
    border: 1px solid #ABABAB;
    background-color: #FDFDFD;
    background-color: #FDFDFD;
    margin-left: 10px;
    font-family: "Segoe UI","Segoe",Tahoma,Helvetica,Arial,sans-serif;
    font-size: 11px;
    color: #444;
}

.profileInput:hover
{
    border-color: #92C0E0;
    background-color: #E6F2FA;
    cursor:pointer;
}

.profileInput:active
{
    border-color: #2A8DD4;
    background-color: #92C0E0;
    cursor:pointer;
}

.mainContainer
{
    text-align:right;
}


.buttonContainer
{
    padding-top: 20px;
    float:right;
}

</style>

<script type="text/javascript">
    function closeDialog() {
        parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.cancel, null);    
    }

</script>


</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <div class="mainContainer">
        <div>
            <asp:FileUpload ID="PictureFileUpload" runat="server" Width="500" size="60"/>
        </div>
        <div class="buttonContainer">
            <div>
                <div>
                    <asp:Button ID="UploadPictureButton" runat="server" Text="Upload" OnClick="UploadPictureButton_Click" CssClass="profileInput" />
                    <input type="button" value="Cancel" onclick="closeDialog();" class="profileInput"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Upload Profile Picture
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Upload Profile Picture
</asp:Content>

