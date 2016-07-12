<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" Src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" Src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkLog.aspx.cs" Inherits="TimeSheets.Layouts.epmlive.WorkLog" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script type="text/javascript" src="jquery/jquery-1.4.2.js" ></script>
    <% if (false) { %>
    <script src="/jquery-1.4.2-vsdoc.js" type="text/javascript"></script>
    <% } %>
    <title>WorkLog</title>
    <style type="text/css">
    .noborder {
    border:0 none !important;
    height:9px !important;
    }
    .totalHoursException {
    color: Red;
    }
    </style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <asp:Panel ID="pnlMain" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" >
            <tr><td id="onetidPageTitleAreaFrame" class="ms-areaseparator" style="height: 30px;" valign="top" nowrap>
                <table id="onetidPageTitleAreaTable" style="margin-top: 8px; "  border="0" cellspacing="0" cellpadding="0" width="100%">
                    <tbody><tr>
                        <td id="onetidPageTitle" class="ms-pagetitle" height="100%" valign="top">
                            <h2 class="ms-pagetitle" id="h2Title" runat="server"></h2>
                        </td>
                    </tr></tbody>
                </table>
            </td></tr>
            <tr><td height="100%" class="ms-bodyareaframe" vAlign="top">
    
            <asp:Panel id="pnlForm" runat="server" >
    
            <table width="100%" class="ms-formtable" style="margin-top: 8px;" border="0" cellSpacing="0" cellPadding="0">

                <asp:Panel ID="pnlUsers" runat="server" >
                <wssuc:InputFormSection Title="User" Description="" runat="server">
                    <template_description>
                        You are a delegate for other users. Select yourself or another user.
                    </template_description>
                    <template_inputformcontrols>
                        <wssuc:InputFormControl LabelText="Select user" runat="server" >
                             <Template_Control>
                                 <asp:DropDownList id="ddlUsers" runat="server" on></asp:DropDownList>
                             </Template_Control>
                        </wssuc:InputFormControl>
                    </template_inputformcontrols>                
                </wssuc:InputFormSection>    
                </asp:Panel>

                <wssuc:InputFormSection Title="Date" Description="" runat="server">
                    <template_description>
                        Select a date within an existing timesheet period.
                    </template_description>
                    <template_inputformcontrols>
                        <wssuc:InputFormControl LabelText="" runat="server" >
                             <Template_Control>
                                <SharePoint:DateTimeControl ID="dtcDate" runat="server" 
                                    DateOnly="true" 
                                ></SharePoint:DateTimeControl>
                                <div style="color:Red;padding-top:10px;">
                                <asp:Label ID="lblDateMessage" runat="server" ></asp:Label></div>
                             </Template_Control>
                        </wssuc:InputFormControl>
                    </template_inputformcontrols>                
                </wssuc:InputFormSection>    


                <wssuc:InputFormSection Title="Day Hours" Description="" runat="server">
                    <template_description>
                        Enter hours for each work type.
                    </template_description>
                    <template_inputformcontrols>
                        <wssuc:InputFormControl LabelText="Hours:" runat="server" >
                             <Template_Control><table border='0' cellpadding='0' cellspacing='0' class='noborder'>
                                <asp:PlaceHolder ID="phHours" runat="server" ></asp:PlaceHolder>                        
                                </table>
                                <div style="color:Red;padding-top:10px;">
                                <asp:Label ID="lblStatusMessage" runat="server"></asp:Label></div>
                             </Template_Control>
                        </wssuc:InputFormControl>
                    </template_inputformcontrols>   
                </wssuc:InputFormSection>    
        
        
                <wssuc:InputFormSection Title="Item Hours" Description="" runat="server">
                    <template_description>
                        Total hours for this item.
                    </template_description>
                    <template_inputformcontrols>
                        <wssuc:InputFormControl LabelText="Total hours used:" runat="server" >
                             <Template_Control><table border='0' cellpadding='0' cellspacing='0' class='noborder'>
                                <tr class='noborder'><td id="tdChart"  class='noborder'></td></tr></table>
                             </Template_Control>
                        </wssuc:InputFormControl>
                    </template_inputformcontrols>   
                </wssuc:InputFormSection>    
        
        
                <asp:Panel ID="pnlNotes" runat="server">
                <wssuc:InputFormSection Title="Notes" Description="" runat="server">
                    <template_description>
                        Enter notes.
                    </template_description>
                    <template_inputformcontrols>
                        <wssuc:InputFormControl LabelText="" runat="server" >
                             <Template_Control>
                                <SharePoint:InputFormTextBox ID="txtNotes" runat="server" TextMode="MultiLine" Rows="4" Width="240px"></SharePoint:InputFormTextBox>
                             </Template_Control>
                        </wssuc:InputFormControl>
                    </template_inputformcontrols>
                </wssuc:InputFormSection>
                </asp:Panel>
        
                <wssuc:ButtonSection runat="server" ShowStandardCancelButton="false">
                    <template_buttons>
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="ms-ButtonHeightWidth"  />
                        <asp:Button ID="btnSaveClose" runat="server" Text="Save & Close" CssClass="ms-ButtonHeightWidth"/>
                        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="ms-ButtonHeightWidth" OnClientClick="javascript:window.frameElement.commitPopup();return false;" />
                    </template_buttons>
                </wssuc:ButtonSection>
    
                </table>
        
                <script type="text/javascript">
                    
                    //            $(document).ready(function() {

                    //                $(".ms-dtinput").find("a").css("border", "solid red 2px");

                    //                var f = $(".ms-dtinput").find("a")[0];

                    //                //alert(f.getAttributeNode('onclick').value);

                    //                //var s = "javascript: if (dirty && !confirm('Are you sure?')) return false; dirty = false; ";  //+ f.getAttributeNode('onclick').value;
                    //                var s = "javascript:confirm('Are you sure?');"
                    //                //alert(s);

                    //                f.onclick = '';
                    //                f.unbind('click');
                    //                f.click(nick2);
                    //            });
                    //        
                    //        function nick2()
                    //        {
                    //            alert('YES');
                    //        }

                    //            $(".ms-dtinput").find("a").bind("click", function() {
                    //                
                    //                if (dirty && !confirm('Are you sure?')) {
                    //                    return false;
                    //                };
                    //                dirty = false;
                    //            });

                </script>
        
                </asp:Panel>
        
                <asp:panel ID="pnlError" runat="server" visible="false">
                    <div style="color:Red; padding-top:100px; text-align:center;" class="ms-description">
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                        <br /><br />
                        <input type="button" value="Close" class="ms-ButtonHeightWidth" onclick="javascript:window.frameElement.commitPopup();" />
                    </div>
                </asp:panel>
        
        </td></tr></table>
        </asp:Panel>
        <asp:Panel ID="pnlActivate" runat="server" Visible="false">
            <asp:Label ID="lblActivate" runat="server"></asp:Label>
        </asp:Panel>
        <script language="javascript">
            document.getElementById("onetidPageTitleAreaTable").parentNode.noWrap = false;
        </script>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Work Log
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
    Work Log
</asp:Content>
