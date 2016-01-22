<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5" %>
<%@ Page Language="C#" Inherits="EPMLiveCore.PropertiesBag" CodeBehind="EPMLiveCore.PropertiesBag.aspx.cs" MasterPageFile="~/_admin/admin.master" %>    

<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register TagPrefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<script type="text/javascript" src="../../_layouts/15/epmlive/jQueryLibrary/jquery-1.6.2.min.js"></script>
<script type="text/javascript" src="../../_layouts/15/epmlive/jQueryLibrary/xml2json.js"></script>
    <style>
        .ms-viewheadertr {
            height: 20px;
            background-color: #f2f2f2;
            font-weight: bold;
        }
        .h3style {
            font-weight: bold;
        }
    </style>

    <script type="text/javascript">

        var analyticsUrl = '<%= analyticsUrl %>';
        var epmlApiUrl = '<%= epmlApiUrl %>';

        function EditProperty(propType) {

            ToggleControl(propType);

        }

        function SaveProperty(propType) {

            var dataXml = "";
            if (propType == "farm") {
                dataXml = "<Data><Param key=\"PropType\">" + propType + "</Param><Param key=\"UplandAnalyticsURL\">" +
                    $("#txtAnalyticsURL").val() + "</Param></Data>";
            }
            else {
                dataXml = "<Data><Param key=\"PropType\">" + propType + "</Param><Param key=\"WebAppId\">" +
                        "<%= WebApplicationSelector1.CurrentId %>" + "</Param><Param key=\"EPMLiveAPIURL\">" +
                        $("#txtEPMLApiURL").val() + "</Param></Data>";
            }

            $.ajax({
                type: 'POST',
                url: '<%= currentWebUrl %>' + '/_vti_bin/WorkEngine.asmx/Execute',
                headers: {
                    "Accept": "application/json;odata=verbose",
                    "X-RequestDigest": $("#__REQUESTDIGEST").val(),
                    "content-Type": "application/json;odata=verbose"
                },
                data: "{ Function: 'SetPropertiesBagSettings', Dataxml: '" + dataXml + "'}",
                success: function (response) {
                    var result = eval('(' + window.xml2json($.parseXML(response.d), "") + ')');
                    if (result.Result['@Status'] == 0) {
                        if (propType == "farm") {
                            analyticsUrl = $("#txtAnalyticsURL").val();
                        }
                        else {
                            epmlApiUrl = $("#txtEPMLApiURL").val();
                        }
                        ToggleControl(propType);
                    }
                    else {
                        alert("Error occurred while saving property. Please try again.");
                    }
                },
                error: function (response) {
                    alert(response);
                }
            });
        }

        function CancelProperty(propType) {
            if (propType == 'farm') {
                if ($("#txtAnalyticsURL").val() != analyticsUrl) {
                    $("#txtAnalyticsURL").val(analyticsUrl);
                }
            }
            else {
                if ($("#txtEPMLApiURL").val() != epmlApiUrl) {
                    $("#txtEPMLApiURL").val(epmlApiUrl);
                }
            }
            ToggleControl(propType);
        }

        function ToggleControl(propType) {

            if ($("#" + propType + "PropEditDiv").css('display') != 'none') {
                $("#" + propType + "PropEditDiv").hide();
                $("#" + propType + "PropSaveDiv").show();
            }
            else {
                $("#" + propType + "PropEditDiv").show();
                $("#" + propType + "PropSaveDiv").hide();
            }
            if (propType == 'farm') {
                if ($("#txtAnalyticsURL").prop('disabled')) {
                    $("#txtAnalyticsURL").prop('disabled', false);
                }
                else {
                    $("#txtAnalyticsURL").prop('disabled', true);
                }
            }
            else {
                if ($("#txtEPMLApiURL").prop('disabled')) {
                    $("#txtEPMLApiURL").prop('disabled', false);
                }
                else {
                    $("#txtEPMLApiURL").prop('disabled', true);
                }
            }
        }

    </script>

	<%-- Farm Properties --%>    
    <table border="0" cellpadding="10" cellspacing="0" width="700px">
        <tr>
            <td colspan="2">                
                <h3 class="h3style">Farm Properties</h3>                
            </td>
        </tr>
        <tr>
            <td>
                <table class="ms-listviewtable" cellspacing="0" width="100%" cellpadding="2" style="padding-left: 3px; padding-right: 5px;">            
                    <tr>
                        <td class="ms-viewheadertr" width="150px">Property</td>
                        <td class="ms-viewheadertr" width="350px">Value</td>
                        <td class="ms-viewheadertr" width="100px">Action</td>
                    </tr>

                    <tr>
                        <td width="150px">UplandAnalyticsURL</td>
                        <td width="350px">
                            <input type="text" id="txtAnalyticsURL" style="width:325px" disabled="true" value="<%= analyticsUrl %>" />
                        </td>
                        <td width="100px">
                            <div id="farmPropEditDiv">
                                <a href="#" onclick="javascript:EditProperty('farm')">Edit</a>
                            </div>                    
                            <div id="farmPropSaveDiv" style="display:none;">
                                <a href="#" onclick="javascript:SaveProperty('farm')" style="padding-right:8px">Save</a>
                                <a href="#" onclick="javascript:CancelProperty('farm')" style="padding-left:8px">Cancel</a>
                            </div>
                        </td>
                    </tr>                    
                </table>
            </td>
        </tr>
        
    </table>    
        
    <br/><br/><br/> 
        
    <%-- Web Application Properties --%>
    <table border="0" cellpadding="10" cellspacing="0" width="700px">	
        <tr>
            <td colspan="2">
                <h3 class="h3style">Web Application Properties</h3>                
            </td>
        </tr>
        <tr>
			<td>				
				<table>
                    <tr>
                        <td width="100%">
				            <wssuc:inputformsection title="Web Application"
					            description="Select Web Application to set property."
					            runat="server">
				            <Template_InputFormControls>
					            <wssuc:InputFormControl LabelText="" runat="server">
							            <Template_Control>
							            <SharePoint:WebApplicationSelector ID="WebApplicationSelector1" runat="server" AllowChange="true" OnContextChange="WebApplicationSelector1_ContextChange" />
							            </Template_Control>
					            </wssuc:InputFormControl>
				            </Template_InputFormControls>
				            </wssuc:inputformsection>
                        </td>
                    </tr>
			    </table>				
			</td>
		</tr>
        <tr>
            <td>
                <table class="ms-listviewtable" cellspacing="0" cellpadding="2" width="100%" style="padding-left: 3px; padding-right: 5px;">         
                    <tr>
                        <td class="ms-viewheadertr" width="150px">Property</td>
                        <td class="ms-viewheadertr" width="350px">Value</td>
                        <td class="ms-viewheadertr" width="100px">Action</td>
                    </tr>

                    <tr>
                        <td width="150px">EPMLiveAPIURL</td>
                        <td width="350px">
                            <input type="text" id="txtEPMLApiURL" style="width:325px" disabled="true" value="<%= epmlApiUrl %>" />
                        </td>
                        <td width="100px">
                            <div id="webappPropEditDiv">
                                <a href="#" onclick="javascript:EditProperty('webapp')">Edit</a>
                            </div>
                            <div id="webappPropSaveDiv" style="display:none;">
                                <a href="#" onclick="javascript:SaveProperty('webapp')" style="padding-right:8px">Save</a>
                                <a href="#" onclick="javascript:CancelProperty('webapp')" style="padding-left:8px">Cancel</a>
                            </div>
                        </td>
                    </tr>                    
                </table>
            </td>
        </tr>
    </table>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Properties
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    Properties
</asp:Content>
