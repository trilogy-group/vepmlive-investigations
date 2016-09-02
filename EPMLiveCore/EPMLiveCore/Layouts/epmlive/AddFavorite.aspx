<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFavorite.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.AddFavorite" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:content id="PageHead" contentplaceholderid="PlaceHolderAdditionalPageHead" runat="server">

</asp:content>

<asp:content id="Main" contentplaceholderid="PlaceHolderMain" runat="server">
    
    <link href="/_layouts/epmlive/stylesheets/libraries/epmlive/buttons.css" rel="stylesheet">
    <script type="text/javascript">
       

        function cancel() {
            parent.SP.UI.ModalDialog.commonModalDialogClose('', '');
        }

        function add() {
            $.ajax({
                type: 'POST',
                url: epmLive.currentWebFullUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                data: "{ Function: 'AddFavorites', Dataxml: '" +
                    "<Data>" +
                        "<Param key=\"SiteId\"><%=sid%></Param>" +
                        "<Param key=\"WebId\"><%=wid%></Param>" +
                        "<Param key=\"ListId\"><%=listid%></Param>" +
                        "<Param key=\"ListIconClass\">" + epmLive.currentListIcon + "</Param>" +
                        "<Param key=\"ItemId\"><%=itemid%></Param>" +
                        "<Param key=\"FString\"><%=url%></Param>" +
                        "<Param key=\"Type\">1</Param>" +
                        "<Param key=\"UserId\"><%=userid%></Param>" +
                        "<Param key=\"Title\">" + $('#favTitle').val() + "</Param>" +
                    "</Data>" + "' }",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    if (response.d) {
                        var resp = epmLive.parseJson(response.d);
                        var result = resp.Result;

                        if (epmLive.responseIsSuccess(result) && result['#text']) {
                            //onSuccess(result);
                            parent.SP.UI.ModalDialog.commonModalDialogClose(1, '');
                        } else {
                            //onError(response);
                        }
                    } else {
                        //onError(response);
                    }
                },
                error: function (response) {
                    //onError(response);
                }
            });
        }
    </script>
    

    <table>
        <tr>
            <td>
                Title
            </td>
            <td>
                <input id="favTitle" type="text"/>
            </td>
        </tr>
         <tr>
            <td>
                
            </td>
            <td>
                <button type="button" class="epmliveButton" style="float:right;" onclick="add();">Add</button>
                <button type="button" class="epmliveButton" style="float:right;" onclick="cancel();">Cancel</button>
            </td>
        </tr>
    </table>
    
</asp:content>

<asp:content id="PageTitle" contentplaceholderid="PlaceHolderPageTitle" runat="server">
Add Favorite
</asp:content>

<asp:content id="PageTitleInTitleArea" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
Add Favorite
</asp:content>
