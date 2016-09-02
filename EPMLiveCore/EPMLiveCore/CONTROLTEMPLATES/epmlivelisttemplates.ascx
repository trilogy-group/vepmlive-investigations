<%@ Control Language="C#"  AutoEventWireup="false"%>
<%@Assembly Name="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@Import Namespace="Microsoft.SharePoint" %>
<%@Register TagPrefix="SharePoint" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" namespace="Microsoft.SharePoint.WebControls"%>
<%@Register TagPrefix="SPHttpUtility" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" namespace="Microsoft.SharePoint.Utilities"%>
<%@ Register TagPrefix="wssuc" TagName="ToolBar" src="~/_controltemplates/ToolBar.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBarButton" src="~/_controltemplates/ToolBarButton.ascx" %>
<%@ Register TagPrefix="ELive" Assembly="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5" namespace="EPMLiveCore" %>
<%@Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5" %>

<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<SharePoint:RenderingTemplate ID="EPMLivePCForm" runat="server">
	<Template>
	
		<SPAN id='part1'>
		    <script type="text/c#" runat="server">
                    void SaveAndRedirectEdit(object sender, System.EventArgs e)
                    {
                        try
                        {
                            SPContext.Current.Item.Update();

                            int id = SPContext.Current.Item.ID;

                            string url = SPContext.Current.List.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl;

                            System.Web.HttpContext.Current.Response.Redirect(url + "?ID=" + id.ToString());
                            
                            
                        }
                        catch(Exception ex)
                        {
                            Response.Write(ex.Message);
                        }
                    }
                              
		            
                </script>
			<SharePoint:InformationBar runat="server"/>
			<wssuc:ToolBar CssClass="ms-formtoolbar" id="toolBarTbltop" RightButtonSeparator="&nbsp;" runat="server">
			        <Template_Buttons>
			            
			        </Template_Buttons>
					<Template_RightButtons>
						<SharePoint:NextPageButton runat="server"/>
						<asp:Button ID="Button2" runat="server" OnClientClick="if (!PreSaveItem()) return false;" Text="Save" CssClass="ms-ButtonHeightWidth" OnClick="SaveAndRedirectEdit"/>
						<SharePoint:SaveButton runat="server" Text="Save &amp; Close"/>
						<SharePoint:GoBackButton runat="server"/>
					</Template_RightButtons>
			</wssuc:ToolBar>
			<SharePoint:FormToolBar runat="server"/>
			<TABLE class="ms-formtable" style="margin-top: 8px;" border=0 cellpadding=0 cellspacing=0 width=100%>
			<SharePoint:ChangeContentType runat="server"/>
			<SharePoint:FolderFormFields runat="server"/>
			<ELive:ListDisplaySettingIterator runat="server"/>
			<SharePoint:ApprovalStatus runat="server"/>
			<SharePoint:FormComponent TemplateName="AttachmentRows" runat="server"/>
			</TABLE>
			<table cellpadding=0 cellspacing=0 width=100%><tr><td class="ms-formline"><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></td></tr></table>
			<br />
			<table cellspacing="0" cellpadding="0" border="0" width="100%">
			    <tr>
			        <td class="ms-linksectionheader" style="padding: 4px;" colspan="4">
					    <h3 class="ms-standardheader">Project Information</h3>
				    </td>
			    </tr>
			    <tr>
			        <td width="130px" valign="top" class="ms-formlabel">
						<H3 class="ms-standardheader">
							<nobr>Start</nobr>
						</H3>
					</td>
					<td width="150px" valign="top" class="ms-formbody">
						<SharePoint:FormField runat="server" id="Start" ControlMode="Display" FieldName="Start"/>
					</td>
                    <td width="130px" valign="top" class="ms-formlabel">
						<H3 class="ms-standardheader">
							<nobr>Actual Start</nobr>
						</H3>
					</td>
					<td width="150px" valign="top" class="ms-formbody">
						<SharePoint:FormField runat="server" id="ActualStart" ControlMode="Display" FieldName="ActualStart"/>
					</td>
			    </tr>
			    <tr>
			        <td width="130px" valign="top" class="ms-formlabel">
						<H3 class="ms-standardheader">
							<nobr>Finish</nobr>
						</H3>
					</td>
					<td width="150px" valign="top" class="ms-formbody">
						<SharePoint:FormField runat="server" id="Finish" ControlMode="Display" FieldName="Finish"/>
					</td>
                    <td width="130px" valign="top" class="ms-formlabel">
						<H3 class="ms-standardheader">
							<nobr>Actual Finish</nobr>
						</H3>
					</td>
					<td width="150px" valign="top" class="ms-formbody">
						<SharePoint:FormField runat="server" id="ActualFinish" ControlMode="Display" FieldName="ActualFinish"/>
					</td>
			    </tr>
			    <tr>
			        <td width="130px" valign="top" class="ms-formlabel">
						<H3 class="ms-standardheader">
							<nobr>Duration</nobr>
						</H3>
					</td>
					<td width="150px" valign="top" class="ms-formbody">
						<SharePoint:FormField runat="server" id="Duration" ControlMode="Display" FieldName="Duration"/>
					</td>
                    <td width="130px" valign="top" class="ms-formlabel">
						<H3 class="ms-standardheader">
							<nobr>Actual Duration</nobr>
						</H3>
					</td>
					<td width="150px" valign="top" class="ms-formbody">
						<SharePoint:FormField runat="server" id="ActualDuration" ControlMode="Display" FieldName="ActualDuration"/>
					</td>
			    </tr>
			        <tr>
						<td width="130px" valign="top" class="ms-formlabel">
							<H3 class="ms-standardheader">
								<nobr>% Complete</nobr>
							</H3>
						</td>
						<td width="150px" valign="top" class="ms-formbody">
							<SharePoint:FormField runat="server" id="PercentComplete" ControlMode="Display" FieldName="PercentComplete" __designer:bind="{ddwrt:DataBind('u',concat('ff18',$Pos),'Value','ValueChanged','ID',ddwrt:EscapeDelims(string(@ID)),'@PercentComplete')}"/>
						</td>
			    </tr>
                <tr>
			        <td width="130px" valign="top" class="ms-formlabel">
						<H3 class="ms-standardheader">
							<nobr>Work</nobr>
						</H3>
					</td>
					<td width="150px" valign="top" class="ms-formbody">
						<SharePoint:FormField runat="server" id="Work" ControlMode="Display" FieldName="Work"/>
					</td>
                    <td width="130px" valign="top" class="ms-formlabel">
						<H3 class="ms-standardheader">
							<nobr>Actual Work</nobr>
						</H3>
					</td>
					<td width="150px" valign="top" class="ms-formbody">
						<SharePoint:FormField runat="server" id="ActualWork" ControlMode="Display" FieldName="ActualWork"/>
					</td>
			    </tr>
			    <tr>
			        <td width="130px" valign="top" class="ms-formlabel">
						<H3 class="ms-standardheader">
							<nobr>Cost</nobr>
						</H3>
					</td>
					<td width="150px" valign="top" class="ms-formbody">
						<SharePoint:FormField runat="server" id="Cost" ControlMode="Display" FieldName="Cost"/>
					</td>
                    <td width="130px" valign="top" class="ms-formlabel">
						<H3 class="ms-standardheader">
							<nobr>Actual Cost</nobr>
						</H3>
					</td>
					<td width="150px" valign="top" class="ms-formbody">
						<SharePoint:FormField runat="server" id="ActualCost" ControlMode="Display" FieldName="ActualCost"/>
					</td>
			    </tr>
                </table>
                <table cellpadding=0 cellspacing=0 width=100%><tr><td class="ms-formline"><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></td></tr></table>
                <br />
			<table cellspacing="0" cellpadding="0" border="0" width="100%">
			    <tr>
			        <td class="ms-linksectionheader" style="padding: 4px;" colspan="4">
					    <h3 class="ms-standardheader">Project Rollup Information</h3>
				    </td>
			    </tr>
			    <tr>
			        <td width="130px" valign="top" class="ms-formlabel">
						<H3 class="ms-standardheader">
							<nobr>Active Tasks</nobr>
						</H3>
					</td>
					<td width="150px" valign="top" class="ms-formbody">
						<SharePoint:FormField runat="server" id="ActiveTasks" ControlMode="Display" FieldName="ActiveTasks"/>
					</td>
                    <td width="130px" valign="top" class="ms-formlabel">
						<H3 class="ms-standardheader">
							<nobr>Overdue Tasks</nobr>
						</H3>
					</td>
					<td width="150px" valign="top" class="ms-formbody">
						<SharePoint:FormField runat="server" id="OverdueTasks" ControlMode="Display" FieldName="OverdueTasks"/>
					</td>
			    </tr>
			    <tr>
			        <td width="130px" valign="top" class="ms-formlabel">
						<H3 class="ms-standardheader">
							<nobr>Active Issues</nobr>
						</H3>
					</td>
					<td width="150px" valign="top" class="ms-formbody">
						<SharePoint:FormField runat="server" id="ActiveIssues" ControlMode="Display" FieldName="ActiveIssues"/>
					</td>
                    <td width="130px" valign="top" class="ms-formlabel">
						<H3 class="ms-standardheader">
							<nobr>Overdue Issues</nobr>
						</H3>
					</td>
					<td width="150px" valign="top" class="ms-formbody">
						<SharePoint:FormField runat="server" id="OverdueIssues" ControlMode="Display" FieldName="OverdueIssues"/>
					</td>
			    </tr>
			    <tr>
			        <td width="130px" valign="top" class="ms-formlabel">
						<H3 class="ms-standardheader">
							<nobr>Active Risks</nobr>
						</H3>
					</td>
					<td width="150px" valign="top" class="ms-formbody">
						<SharePoint:FormField runat="server" id="ActiveRisks" ControlMode="Display" FieldName="ActiveRisks"/>
					</td>
                    <td width="130px" valign="top" class="ms-formlabel">
						<H3 class="ms-standardheader">
							<nobr>Overdue Risks</nobr>
						</H3>
					</td>
					<td width="150px" valign="top" class="ms-formbody">
						<SharePoint:FormField runat="server" id="OverdueRisks" ControlMode="Display" FieldName="OverdueRisks"/>
					</td>
			    </tr>
			</table>
			<table cellpadding=0 cellspacing=0 width=100%><tr><td class="ms-formline"><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></td></tr></table>
			<TABLE cellpadding=0 cellspacing=0 width=100% style="padding-top: 7px"><tr><td width=100%>
			<SharePoint:ItemHiddenVersion runat="server"/>
			<SharePoint:ParentInformationField runat="server"/>
			<SharePoint:InitContentType runat="server"/>
            
			<wssuc:ToolBar CssClass="ms-formtoolbar" id="toolBarTbl" RightButtonSeparator="&nbsp;" runat="server">
					<Template_Buttons>
						<SharePoint:CreatedModifiedInfo runat="server"/>
					</Template_Buttons>
					<Template_RightButtons>
					<asp:Button ID="Button3" runat="server" Text="Save" CssClass="ms-ButtonHeightWidth" OnClick="SaveAndRedirectEdit"/>
						<SharePoint:SaveButton runat="server" Text="Save &amp; Close"/>
						<SharePoint:GoBackButton runat="server"/>
					</Template_RightButtons>
			</wssuc:ToolBar>
			
			</td></tr>
			
			</TABLE>
		</SPAN>
		<SharePoint:AttachmentUpload runat="server"/>
	</Template>
	
</SharePoint:RenderingTemplate>

<SharePoint:RenderingTemplate ID="EPMLivePCNewForm" runat="server">
<Template>
		<SPAN id='part1'>
			<script type="text/c#" runat="server">
            void SaveAndRedirect(object sender, System.EventArgs e)
            {
                try
                {

                    SPContext.Current.Item.Update();
                    int id = SPContext.Current.Item.ID;
                    string url = SPContext.Current.List.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl;
                    System.Web.HttpContext.Current.Response.Redirect(url + "?ID=" + id.ToString());

                }
                catch(Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
	                </script>
			<SharePoint:InformationBar ID="InformationBar1" runat="server"/>
			<wssuc:ToolBar CssClass="ms-formtoolbar" id="toolBarTbltop" RightButtonSeparator="&nbsp;" runat="server">
					<Template_RightButtons>
						<SharePoint:NextPageButton ID="NextPageButton1" runat="server"/>
						<asp:Button runat="server" id="btnSave2" Text="Save" CssClass="ms-ButtonHeightWidth" OnClick="SaveAndRedirect"/>
						<SharePoint:SaveButton runat="server" Text="Save &amp; Close"/>
						<SharePoint:GoBackButton ID="GoBackButton1" runat="server"/>
					</Template_RightButtons>
			</wssuc:ToolBar>
			<SharePoint:FormToolBar ID="FormToolBar1" runat="server"/>
			<TABLE class="ms-formtable" style="margin-top: 8px;" border=0 cellpadding=0 cellspacing=0 width=100%>
			<SharePoint:ChangeContentType ID="ChangeContentType1" runat="server"/>
			<SharePoint:FolderFormFields ID="FolderFormFields1" runat="server"/>
			<ELive:ListDisplaySettingIterator ID="ListDisplaySettingIterator1" runat="server"/>
			<SharePoint:ApprovalStatus ID="ApprovalStatus1" runat="server"/>
			<SharePoint:FormComponent ID="FormComponent1" TemplateName="AttachmentRows" runat="server"/>
			</TABLE>
			<table cellpadding=0 cellspacing=0 width=100%><tr><td class="ms-formline"><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></td></tr></table>
			<TABLE cellpadding=0 cellspacing=0 width=100% style="padding-top: 7px"><tr><td width=100%>
			<SharePoint:ItemHiddenVersion ID="ItemHiddenVersion1" runat="server"/>
			<SharePoint:ParentInformationField ID="ParentInformationField1" runat="server"/>
			<SharePoint:InitContentType ID="InitContentType1" runat="server"/>
			<wssuc:ToolBar CssClass="ms-formtoolbar" id="toolBarTbl" RightButtonSeparator="&nbsp;" runat="server">
					<Template_Buttons>
						<SharePoint:CreatedModifiedInfo ID="CreatedModifiedInfo1" runat="server"/>
					</Template_Buttons>
					<Template_RightButtons>
						<asp:Button runat="server" id="btnSave1" Text="Save" CssClass="ms-ButtonHeightWidth" OnClick="SaveAndRedirect"/>
						<SharePoint:SaveButton runat="server" Text="Save &amp; Close"/>
						<SharePoint:GoBackButton ID="GoBackButton2" runat="server"/>
					</Template_RightButtons>
			</wssuc:ToolBar>
			</td></tr></TABLE>
		</SPAN>
		<SharePoint:AttachmentUpload ID="AttachmentUpload1" runat="server"/>
	</Template>
</SharePoint:RenderingTemplate>

<SharePoint:RenderingTemplate ID="EPMLiveTCEditForm" runat="server">
    <Template>
		<SPAN id='part1'>
			<SharePoint:InformationBar ID="InformationBar3" runat="server"/>
			<wssuc:ToolBar CssClass="ms-formtoolbar" id="toolBarTbltop" RightButtonSeparator="&nbsp;" runat="server">
					<Template_RightButtons>
						<SharePoint:NextPageButton ID="NextPageButton3" runat="server"/>
						<SharePoint:SaveButton ID="SaveButton5" runat="server"/>
						<SharePoint:GoBackButton ID="GoBackButton5" runat="server"/>
					</Template_RightButtons>
			</wssuc:ToolBar>
			<SharePoint:FormToolBar ID="FormToolBar3" runat="server"/>
			<TABLE class="ms-formtable" style="margin-top: 8px;" border=0 cellpadding=0 cellspacing=0 width=100%>
			<SharePoint:ChangeContentType ID="ChangeContentType3" runat="server"/>
			<SharePoint:FolderFormFields ID="FolderFormFields3" runat="server"/>
			<ELive:ListDisplaySettingIterator runat="server"/>
			<SharePoint:ApprovalStatus ID="ApprovalStatus3" runat="server"/>
			<SharePoint:FormComponent ID="FormComponent3" TemplateName="AttachmentRows" runat="server"/>
			</TABLE>
			<table cellpadding=0 cellspacing=0 width=100%><tr><td class="ms-formline"><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></td></tr></table>
			<TABLE cellpadding=0 cellspacing=0 width=100% style="padding-top: 7px"><tr><td width=100%>
			<SharePoint:ItemHiddenVersion ID="ItemHiddenVersion3" runat="server"/>
			<SharePoint:ParentInformationField ID="ParentInformationField3" runat="server"/>
			<SharePoint:InitContentType ID="InitContentType3" runat="server"/>
			<wssuc:ToolBar CssClass="ms-formtoolbar" id="toolBarTbl" RightButtonSeparator="&nbsp;" runat="server">
					<Template_Buttons>
						<SharePoint:CreatedModifiedInfo ID="CreatedModifiedInfo3" runat="server"/>
					</Template_Buttons>
					<Template_RightButtons>
						<SharePoint:SaveButton ID="SaveButton6" runat="server"/>
						<SharePoint:GoBackButton ID="GoBackButton6" runat="server"/>
					</Template_RightButtons>
			</wssuc:ToolBar>
			</td></tr></TABLE>
		</SPAN>
		<SharePoint:AttachmentUpload ID="AttachmentUpload3" runat="server"/>
	</Template>
</SharePoint:RenderingTemplate>

<SharePoint:RenderingTemplate ID="EPMLiveTCNewForm" runat="server">
	<Template>
		<SPAN id='part1'>
		
			<SharePoint:InformationBar ID="InformationBar2" runat="server"/>
			<wssuc:ToolBar CssClass="ms-formtoolbar" id="toolBarTbltop" RightButtonSeparator="&nbsp;" runat="server">
					<Template_RightButtons>
						<SharePoint:NextPageButton ID="NextPageButton2" runat="server"/>
						<SharePoint:SaveButton ID="SaveButton3" runat="server"/>
						<SharePoint:GoBackButton ID="GoBackButton3" runat="server"/>
					</Template_RightButtons>
			</wssuc:ToolBar>
			<SharePoint:FormToolBar ID="FormToolBar2" runat="server"/>
			<TABLE class="ms-formtable" style="margin-top: 8px;" border=0 cellpadding=0 cellspacing=0 width=100%>
			<SharePoint:ChangeContentType ID="ChangeContentType2" runat="server"/>
			<SharePoint:FolderFormFields ID="FolderFormFields2" runat="server"/>
			<ELive:ListDisplaySettingIterator runat="server"/>
			<SharePoint:ApprovalStatus ID="ApprovalStatus2" runat="server"/>
			<SharePoint:FormComponent ID="FormComponent2" TemplateName="AttachmentRows" runat="server"/>
			</TABLE>
			
			<table cellpadding=0 cellspacing=0 width=100%><tr><td class="ms-formline"><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></td></tr></table>
			<TABLE cellpadding=0 cellspacing=0 width=100% style="padding-top: 7px"><tr><td width=100%>
			<SharePoint:ItemHiddenVersion ID="ItemHiddenVersion2" runat="server"/>
			<SharePoint:ParentInformationField ID="ParentInformationField2" runat="server"/>
			<SharePoint:InitContentType ID="InitContentType2" runat="server"/>
			<wssuc:ToolBar CssClass="ms-formtoolbar" id="toolBarTbl" RightButtonSeparator="&nbsp;" runat="server">
					<Template_Buttons>
						<SharePoint:CreatedModifiedInfo ID="CreatedModifiedInfo2" runat="server"/>
					</Template_Buttons>
					<Template_RightButtons>
						<SharePoint:SaveButton ID="SaveButton4" runat="server"/>
						<SharePoint:GoBackButton ID="GoBackButton4" runat="server"/>
					</Template_RightButtons>
			</wssuc:ToolBar>
			</td></tr></TABLE>
		</SPAN>
		<SharePoint:AttachmentUpload ID="AttachmentUpload2" runat="server"/>
	</Template>
	
</SharePoint:RenderingTemplate>