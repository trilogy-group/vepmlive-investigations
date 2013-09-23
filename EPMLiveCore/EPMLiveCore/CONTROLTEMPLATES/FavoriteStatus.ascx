<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FavoriteStatus.ascx.cs" Inherits="EPMLiveCore.CONTROLTEMPLATES.FavoriteStatus" %>

<div id="EPMLiveFavoriteStatus" style="width: 100px; width: 30px; display: inline-block; vertical-align: middle;">
    
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
    </Sharepoint:StyleBlock>
   
    <span style="display: none;color:#D1D1D1;font-size:18px;" class="icon-star icon-star-disabled" id="favoritesStar" ></span>
</div>


<div id="fav_Add_DivTemp" style="display:none">
        <div style="width:250px;height:95px;padding:10px;"> Title:&nbsp;
        <input id="favTitle" name="favTitle" type="text" value="<%=defaultFavTitle %>" />
        <br />
        <div style="clear:both;height:10px;"></div>
        <input type="button" style="float:left;width:90px;margin-right:5px;" value="OK" onClick="SP.UI.ModalDialog.commonModalDialogClose(1, window.Analytics.getAddFavDynamicValue(this));" class="ms-ButtonHeightWidth" target="_self" />
        <input type="button" style="float:left;width:90px;" value="Cancel" onClick="SP.UI.ModalDialog.commonModalDialogClose(0, 'Cancel clicked');" class="ms-ButtonHeightWidth" target="_self" />
      </div>
</div>
