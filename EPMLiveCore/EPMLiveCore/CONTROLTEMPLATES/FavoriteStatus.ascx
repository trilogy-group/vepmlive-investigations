<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FavoriteStatus.ascx.cs" Inherits="EPMLiveCore.CONTROLTEMPLATES.FavoriteStatus" %>

<div id="EPMLiveFavoriteStatus" style="width:30px; display:inline-block !important;vertical-align: middle;">
    
    <Sharepoint:StyleBlock runat="server">
        body {
            background-color: #F3F3F3;
        }

        .icon-star-disabled {
            /*font-size: 1.2em;*/
            color: #D1D1D1;
            text-shadow: 0px 1px white;
            cursor: pointer;
        }

        .icon-star-active {
            color: #0072C6 !important;
            cursor: pointer;
        }
        
        <!--[if IE 8]>
        .ms-cui-tt-a{
            width: auto !important;
        }
        
        .ms-cui-tt-span{
            display: block !important;
            padding: 8px 10px !important;
            text-align: center !important;
        }
        <![endif]-->

    </Sharepoint:StyleBlock>
   
    <div>
        <span id="favoritesStar" style="font-size:18px;" ></span>
    </div>
</div>

<div id="fav_Add_DivTemp" style="display:none" style="width: 265px;">
    <div>
        <div style="width: 250px; padding: 5px;"> Title:&nbsp;
            <input type="text" value="" name="favTitle" id="favTitle" style="width:200px;">
            <br>
            <div style="clear: both; height: 20px;"></div>
            <div style="margin-left: 45px;">
                <input type="button" style="float: left; margin-right: 5px; width: 90px;" value="OK" onclick="SP.UI.ModalDialog.commonModalDialogClose(1, window.Analytics.getAddFavDynamicValue(this));" class="ms-ButtonHeightWidth" target="_self">
                <input type="button" style="float:left;width:90px;" value="Cancel" onclick="SP.UI.ModalDialog.commonModalDialogClose(0, 'Cancel clicked');" class="ms-ButtonHeightWidth" target="_self">
            </div>
        </div>
    </div>
</div>

<div id="favItem_Add_DivTemp" style="display:none" style="width: 265px;">
    <div>
        <div style="width: 250px; padding: 5px;"> Title:&nbsp;
            <input type="text" value="" name="favItemTitle" id="favItemTitle" style="width:200px;">
            <br>
            <div style="clear: both; height: 20px;"></div>
            <div style="margin-left: 45px;">
                <input type="button" style="float: left; margin-right: 5px; width: 90px;" value="OK" onclick="SP.UI.ModalDialog.commonModalDialogClose(1, window.Analytics.getAddFavItemFromGridDynamicValue(this));" class="ms-ButtonHeightWidth" target="_self">
                <input type="button" style="float:left;width:90px;" value="Cancel" onclick="SP.UI.ModalDialog.commonModalDialogClose(0, 'Cancel clicked');" class="ms-ButtonHeightWidth" target="_self">
            </div>
        </div>
    </div>
</div>