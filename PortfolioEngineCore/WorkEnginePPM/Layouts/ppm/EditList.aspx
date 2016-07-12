<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditList.aspx.cs" Inherits="WorkEnginePPM.Layouts.ppm.EditList" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    
    <asp:Label ID="lblError" runat="server"></asp:Label>

    <asp:Panel ID="pnlMain" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">

        <wssuc:InputFormSection Title="Enable PortfolioEngine"
		        Description=""
		        runat="server">
		        <Template_Description>
		           Select this option to enable this list for PortfolioEngine
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="" runat="server">
				         <Template_Control>
                            <asp:CheckBox ID="chkEnable" runat="server" AutoPostBack="true" /> Enable
				         </Template_Control>
			        </wssuc:InputFormControl>
		        </Template_InputFormControls>
	        </wssuc:InputFormSection>

            <wssuc:InputFormSection Title="List Field Mapping"
		        Description=""
		        runat="server" id="sectionFieldMapping">
		        <Template_Description>
		           These are the fields that will be pushed from SharePoint to PortfolioEngine
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="" runat="server">
				         <Template_Control>
                            <asp:GridView ID="gvWEToPFE" runat="server" AutoGenerateColumns="False" 
                            EnableModelValidation="True" Width="400px" BackColor="White" 
                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="1" 
                            ForeColor="Black" GridLines="None"
                            onrowdatabound="GridView1_RowDataBound" >
                            <Columns>
                                <asp:BoundField DataField="epkField" HeaderText="PE Field"  HeaderStyle-HorizontalAlign="Left"/>
                                <asp:TemplateField HeaderText="SharePoint Field" ItemStyle-Width="200" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlSPField" runat="server">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="epkFieldId"/>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="#000000" HorizontalAlign="Left" />
                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
				         </Template_Control>
			        </wssuc:InputFormControl>
		        </Template_InputFormControls>
	        </wssuc:InputFormSection>

        <wssuc:InputFormSection Title="Total Field Mappings"
		        Description=""
		        runat="server" id="sectionTotalFields">
		        <Template_Description>
		           These are the totals fields that will be brought in from PortfolioEngine
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="" runat="server">
				         <Template_Control>
                            <asp:GridView ID="gvPFEtoWE" runat="server" AutoGenerateColumns="False" 
                            EnableModelValidation="True" Width="400px" BackColor="White" 
                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="1" 
                            ForeColor="Black" GridLines="None"
                            onrowdatabound="GridView1_RowDataBound" >
                            <Columns>
                                <asp:BoundField DataField="epkField" HeaderText="PE Field"  HeaderStyle-HorizontalAlign="Left"/>
                                <asp:TemplateField HeaderText="SharePoint Field" ItemStyle-Width="200" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlSPField" runat="server">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="epkFieldId"/>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="#000000" HorizontalAlign="Left" />
                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
				         </Template_Control>
			        </wssuc:InputFormControl>
		        </Template_InputFormControls>
	        </wssuc:InputFormSection>
            <wssuc:InputFormSection Title="Available Controls"
		        Description=""
		        runat="server" id="sectionControls">
		        <Template_Description>
		           Select the controls and menus that will be available in SharePoint
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="" runat="server">
				         <Template_Control>
                            <table width="300" border="0">
                                <tr>
                                    <td><input type="checkbox" name="ribbons" value="costs" <%if(arrMenus.Contains("costs")){%>checked<%}%>/> Cost Planner</td>
                                    <td><input type="checkbox" name="nonactivexs" value="costs" <%if(arrNonActiveXs.Contains("costs")){%>checked<%}%>/> Non Active-X</td>
                                </tr>
                                <tr>
                                    <td><input type="checkbox" name="ribbons" value="costanalyzer"  <%if(arrMenus.Contains("costanalyzer")){%>checked<%}%>/> Cost Analyzer</td>
                                    <td><input type="checkbox" name="nonactivexs" value="costanalyzer" <%if(arrNonActiveXs.Contains("costanalyzer")){%>checked<%}%>/> Non Active-X</td>
                                </tr>
                                <tr>
                                    <td><input type="checkbox" name="ribbons" value="costanalyzerv2" <%if(arrMenus.Contains("costanalyzerv2")){%>checked<%}%>/> Cost Analyzer V2</td>
                                </tr>
                                <tr>
                                    <td><input type="checkbox" name="ribbons" value="modeler"  <%if(arrMenus.Contains("modeler")){%>checked<%}%>/> Modeler</td>
                                    <td><input type="checkbox" name="nonactivexs" value="modeler" <%if(arrNonActiveXs.Contains("modeler")){%>checked<%}%>/> Non Active-X</td>
                                </tr>
                                <tr>
                                    <td><input type="checkbox" name="ribbons" value="resplan"  <%if(arrMenus.Contains("resplan")){%>checked<%}%>/> Resource Planner</td>
                                    <td><input type="checkbox" name="nonactivexs" value="resplan" <%if(arrNonActiveXs.Contains("resplan")){%>checked<%}%>/> Non Active-X</td>
                                </tr>
                                <tr>
                                    <td><input type="checkbox" name="ribbons" value="resanalyzer"  <%if(arrMenus.Contains("resanalyzer")){%>checked<%}%>/> Resource Analyzer</td>
                                    <td><input type="checkbox" name="nonactivexs" value="resanalyzer" <%if(arrNonActiveXs.Contains("resanalyzer")){%>checked<%}%>/> Non Active-X</td>
                                </tr>
                                <tr>
                                    <td><input type="checkbox" name="ribbons" value="prioritization"  <%if(arrMenus.Contains("prioritization")){%>checked<%}%>/> Prioritization</td>
                                </tr>
                                <tr>
                                    <td><input type="checkbox" name="ribbons" value="optimizer"  <%if(arrMenus.Contains("optimizer")){%>checked<%}%>/> Optimizer</td>
                                </tr>
                                <tr>
                                    <td><input type="checkbox" name="ribbons" value="portfolio"  <%if(arrMenus.Contains("portfolio")){%>checked<%}%>/> Cost Views</td>
                                </tr>
                            </table>
				         </Template_Control>
			        </wssuc:InputFormControl>
		        </Template_InputFormControls>
	        </wssuc:InputFormSection>

            <wssuc:InputFormSection Title="Cost View"
		        Description=""
		        runat="server" id="sectionCostView">
		        <Template_Description>
		           Select the view that will displayed when editing costs
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="" runat="server">
				         <Template_Control>
                            <asp:DropDownList ID="dllCostView" runat="server"></asp:DropDownList>
				         </Template_Control>
			        </wssuc:InputFormControl>
		        </Template_InputFormControls>
	        </wssuc:InputFormSection>

            <wssuc:InputFormSection Title="Schedule Work Lists"
		        Description=""
		        runat="server" id="sectionWorkLists">
		        <Template_Description>
		           Select the lists you would like to use when pushing schedule work into PortfolioEngine
		        </Template_Description>
		        <Template_InputFormControls>
			        <wssuc:InputFormControl LabelText="" runat="server">
				         <Template_Control>
                            <asp:CheckBoxList ID="chkWorkLists" runat="server">
                            
                            </asp:CheckBoxList>
				         </Template_Control>
			        </wssuc:InputFormControl>
		        </Template_InputFormControls>
	        </wssuc:InputFormSection>

            <wssuc:ButtonSection runat="server">
		        <Template_Buttons>
			        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
				        <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Button1_Click" Text="Save" id="Button1" accesskey="" Width="150"/>
			        </asp:PlaceHolder>
		        </Template_Buttons>
	        </wssuc:ButtonSection>
            <wssawc:FormDigest ID="FormDigest1" runat="server" />
        </table>
    </asp:Panel>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
PortfolioEngine: <%=sListName %>
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
PortfolioEngine: <%=sListName %>
</asp:Content>
