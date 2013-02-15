<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Snapshot.aspx.cs" Inherits="EPMLiveReportsAdmin.Layouts.EPMLive.Snapshot" DynamicMasterPageFile="~masterurl/default.master" %>

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" Src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" Src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBar" Src="~/_controltemplates/ToolBar.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBarButton" Src="~/_controltemplates/ToolBarButton.ascx" %>
<%@ Register TagPrefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ID="Content4" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    <sharepoint:encodedliteral id="EncodedLiteral1" runat="server" text="EPM Live Snapshot Edit"
        encodemethod='HtmlEncode' />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
    runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="EPM Live - Snapshot Edit"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderPageDescription" runat="server">
    Use this page to Activate and Deactivate a Snapshot. You can also edit the Snapshot
    Title and Period.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <table width="100%">
    <wssuc:InputFormSection ID="InputFormSection1" Title="Snapshot Activation / Deactivation" Description="" runat="server">
        <template_description>
		    In this section you can Activate or Deactivate a Snapshot by checking or unchecking the checkbox.
		    <br />
		</template_description>
        <template_inputformcontrols>
            <wssuc:InputFormControl ID="InputFormControl1" runat="server">
				 <Template_Control>
				   <asp:CheckBox runat="server" ID="activate" TextAlign="Left" Text="Check here to Activate Snapshot"/>
				 </Template_Control>
			</wssuc:InputFormControl>		
          </template_inputformcontrols>
    </wssuc:InputFormSection>
    <wssuc:InputFormSection ID="InputFormSection2" Title="Snapshot Title" Description="" runat="server">
        <template_description>
		    Give a brief description of the Snapshot.
		    <br />
		</template_description>
        <template_inputformcontrols>
        <wssuc:InputFormControl ID="InputFormControl2" runat="server">
				 <Template_Control>
				       <asp:Label ID="Label1" runat="server" Text="Snapshot Title"></asp:Label><br />
                       <asp:TextBox ID="title" runat="server" BackColor="White" Width="300" CssClass="ms-authoringcontrols"></asp:TextBox>
				 </Template_Control>
			</wssuc:InputFormControl>			
			</template_inputformcontrols>
    </wssuc:InputFormSection>
    <wssuc:InputFormSection ID="InputFormSection3" Title="Snapshot Period" Description="" runat="server">
        <template_description>
		    Use to section to edit the Snapshot date.
		    <br />
		</template_description>
        <template_inputformcontrols>
			<wssuc:InputFormControl ID="InputFormControl3" runat="server">
				 <Template_Control>
				    <asp:Label ID="Label2" runat="server" Text="Snapshot Date"></asp:Label><br />
				     <SharePoint:DateTimeControl ID="snapShotDate" runat="server" DateOnly="True" >                    
                     </SharePoint:DateTimeControl>	   			    
                    <br />
				 </Template_Control>
			</wssuc:InputFormControl>
		</template_inputformcontrols>
    </wssuc:InputFormSection>
    <wssuc:ButtonSection ID="ButtonSection1" runat="server">
        <template_buttons>
			<asp:PlaceHolder ID="PlaceHolder1" runat="server">
			    <input class="ms-ButtonHeightWidth" id="saveBtn" accesskey="O" type="submit" value="Save Settings" runat="server"/>
			    <%--<asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="save_Click" Text="Save Settings" id="save" accesskey="" Width="150"/>--%>
			</asp:PlaceHolder>
		</template_buttons>
    </wssuc:ButtonSection>
    </table>
</asp:Content>
