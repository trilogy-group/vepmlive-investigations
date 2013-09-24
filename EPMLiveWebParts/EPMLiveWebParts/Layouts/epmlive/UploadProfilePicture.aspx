<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadProfilePicture.aspx.cs" Inherits="EPMLiveWebParts.Layouts.epmlive.UploadProfilePicture" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <SharePoint:StyleBlock runat="server">
        .profileInput {
            -moz-min-width: 6em;
            -ms-min-width: 6em;
            -o-min-width: 6em;
            -webkit-min-width: 6em;
            min-width: 6em;
            padding: 7px 10px;
            border: 1px solid #ABABAB;
            background-color: #FDFDFD;
            margin-left: 10px;
            font-family: "Segoe UI", "Segoe", Tahoma, Helvetica, Arial, sans-serif;
            font-size: 11px;
            color: #444;
        }

        .profileInput:hover {
            border-color: #92C0E0;
            background-color: #E6F2FA;
            cursor: pointer;
        }

        .profileInput:active {
            border-color: #2A8DD4;
            background-color: #92C0E0;
            cursor: pointer;
        }

        .mainContainer { text-align: right; }

        .buttonContainer {
            padding-top: 20px;
            float: right;
        }

        #pic-frame { text-align: center; }

        #pic-frame > img {
            max-height: 515px;
            max-width: 515px;
        }
    </SharePoint:StyleBlock>

    <SharePoint:ScriptBlock runat="server">
        function closeDialog() {
            parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.cancel, null);
        }
    </SharePoint:ScriptBlock>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <asp:Panel id="UploadPanel" runat="server">
        <div class="mainContainer">
            <div>
                <asp:FileUpload ID="PictureFileUpload" runat="server" Width="500" size="60"/>
            </div>
            <div class="buttonContainer">
                <div>
                    <div>
                        <asp:Button ID="UploadPictureButton" runat="server" Text="Upload" OnClick="UploadPictureButton_Click" CssClass="profileInput" />
                        <input type="button" value="Cancel" onclick=" closeDialog(); " class="profileInput"/>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel id="ResizePanel" Visible="False" runat="server">
        <div id="pic-frame">
            <img id="profile-pic" src="<%= string.Format(@"{0}/EPMLiveFileStore/{1}", Web.Url, FileNameField.Value) %>"/>
        </div>
        <div style="margin-top: 15px; text-align: center;">
            <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="OnSaveButtonClicked" />
        </div>
        <asp:HiddenField ID="FileNameField" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="ResizeInfoField" ClientIDMode="Static" runat="server"></asp:HiddenField>
        
        <SharePoint:ScriptBlock runat="server">
            (function () {
                function prepareImage($pic) {
                    var x1 = 0;
                    var x2 = 0;
                    var y1 = 0;
                    var y2 = 0;

                    var h = $pic.height();
                    var w = $pic.width();

                    x2 = h < w ? h : w;
                    y2 = x2;

                    $(document).ready(function () {
                        $pic.imgAreaSelect({
                            handles: true,
                            aspectRatio: '1:1',
                            x1: x1,
                            x2: x2,
                            y1: y1,
                            y2: y2,
                            onSelectEnd: function (img, selection) {
                                $('#ResizeInfoField').val(w + '|' + h + '|' + selection.width + '|' + selection.height + '|' + selection.x1 + '|' + selection.y1 + '|' + selection.x2 + '|' + selection.y2);
                            }
                        });
                    });
                }

                function tryLoadingImage() {
                    var ready = false;
                    var $pic = $('img#profile-pic');

                    if ($pic.length > 0) {
                        if ($pic.height() > 0) {
                            ready = true;
                        }
                    }
                    
                    if (ready) {
                        prepareImage($pic);
                    } else {
                        window.setTimeout(function () {
                            tryLoadingImage();
                        }, 1);
                    }
                }

                tryLoadingImage();
            })();
        </SharePoint:ScriptBlock>
    </asp:Panel>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Upload Profile Picture
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
    Upload Profile Picture
</asp:Content>