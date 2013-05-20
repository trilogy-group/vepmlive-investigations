<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveCore.adminconns" MasterPageFile="~/_admin/admin.master"%> 

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	WorkEngine Settings    
</asp:Content>
<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	WorkEngine Settings
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to set your WorkEngine settings for each web application.
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderId="PlaceHolderAdditionalPageHead" runat="server">

    <script src="/_layouts/epmlive/DHTML/xgrid/dhtmlxcommon.js" type="text/javascript"></script>

    <script language="javascript">
        var divInstall;
        var divRemove;
        var divDatabase;
        var btnDoCreate;
        var divInstallDB; 

        var txtServer;
        var txtDatabase;
        var txtDBUsername;
        var txtDBPassword;

        function InstallSolutions() {

            if(!divInstall)
                divInstall = document.getElementById("divInstall");

            divInstall.style.display = "";

            var options = { html: divInstall, width: 300, height: 80, allowMaximize: false, showClose: true };

            SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);

            dhtmlxAjax.get("/_admin/epmlive/installsolutions.aspx?WEBAPP=<%=webappid %>", DoneInstall);
        }

        function RemoveSolutions() {

            if (!divRemove)
                divRemove = document.getElementById("divRemove");

            divRemove.style.display = "";

            var options = { html: divRemove, width: 300, height: 80, allowMaximize: false, showClose: true };

            SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);

            dhtmlxAjax.get("/_admin/epmlive/removesolutions.aspx?WEBAPP=<%=webappid %>", DoneInstall);
        }

        function DoneInstall(var1) {
            if (var1.xmlDoc.responseText.trim() != "Success")
                alert(var1.xmlDoc.responseText);
            location.href = location.href;
        }

        function CreateDatabase() {
            if (!divDatabase) {
                divDatabase = document.getElementById("divDatabase");
                divDatabase.style.display = "";
                btnDoCreate = document.getElementById("btnDoCreate");
                txtServer = document.getElementById("txtServer");
                txtDatabase = document.getElementById("txtDatabase");
                txtDBUsername = document.getElementById("txtDBUsername");
                txtDBPassword = document.getElementById("txtDBPassword");
            }

            var options = { html: divDatabase, width: 400, height: 400, allowMaximize: false, showClose: true };

            SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
        }

        function DoCreateDatabase() {

            btnDoCreate.disabled = "disabled";


            if (!divInstallDB)
                divInstallDB = document.getElementById("divInstallDB");

            divInstallDB.style.display = "";

            var options = { html: divInstallDB, width: 300, height: 80, allowMaximize: false, showClose: true };

            SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);

            
            dhtmlxAjax.get("/_admin/epmlive/createdatabase.aspx?WEBAPP=<%=webappid %>&Server=" + txtServer.value + "&DB=" + txtDatabase.value + "&username=" + txtDBUsername.value + "&Password=" + txtDBPassword.value, DoneInstall);

        }

    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
	
    <div id="divInstall" style="padding:10px; display:none;">
        <br />
        Please waiting while the solutions are being installed. This may take a few minutes.
        <br />
    </div>

    <div id="divRemove" style="padding:10px; display:none;">
        <br />
        Please waiting while the solutions are being removed. This may take a few minutes.
        <br />
    </div>

    <div id="divInstallDB" style="padding:10px; display:none;">
        <br />
        Please waiting while the database is created.
        <br />
    </div>

    <div id="divDatabase" style="padding:10px; display:none;">
        
        <table width="100%">
            <tr>
                <td>Server:</td>
                <td><input type="text" id="txtServer" /></td>
            </tr>
            <tr>
                <td>Database:</td>
                <td><input type="text" id="txtDatabase" /></td>
            </tr>
            <tr>
                <td colspan="2">Leave section below blank to use trusted authentication (Recommended)</td>
            </tr>
            <tr>
                <td>Username:</td>
                <td><input type="text" id="txtDBUsername" /></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td><input type="password" id="txtDBPassword" /></td>
            </tr>
            <tr>
                <td></td>
                <td><input type="button" onclick="DoCreateDatabase()" id="btnDoCreate" value="Create"/></td>
            </tr>
        </table>

    </div>
    
    <asp:Panel ID="pnlAdmin" runat="server">
	
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
	<wssuc:InputFormSection Title="Web Application"
		Description=""
		runat="server">
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="" runat="server" width="100%">
				 <Template_Control>
				    <SharePoint:WebApplicationSelector ID="WebApplicationSelector1" runat="server" AllowChange="true" OnContextChange="WebApplicationSelector1_ContextChange"    />
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>

	</wssuc:InputFormSection>
	
    <tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
    <tr><td class="ms-linksectionheader" colspan="2"><h3 class="ms-standardheader">Solution Deployment</h3></td></tr>
    </table></td></tr>

    <tr>
        <td colspan="2">
            <table width="400">
                <tr>
                    <td>Solution</td>
                    <td>Status</td>
                </tr>
                <tr>
                    <td>Core</td>
                    <td><%=sCoreStatus %></td>
                </tr>
                <tr>
                    <td>WebParts</td>
                    <td><%=sWPStatus %></td>
                </tr>
                <tr>
                    <td>Timesheets</td>
                    <td><%=sTSStatus %></td>
                </tr>
                <tr>
                    <td>Dashboards</td>
                    <td><%=sDashboardStatus %></td>
                </tr>
                 <tr>
                    <td>PortfolioEngine</td>
                    <td><%=sPFEStatus %></td>
                </tr>
            </table>

            <br />
            
        <TABLE width="100%"><TBODY>
        <TR>
        <TD style="PADDING-BOTTOM: 3px" class=ms-addnew><A id=A1 class=ms-addnew href="javascript:InstallSolutions()">Install Solutions</A> </TD>
        </tr><tr>
        <TD style="PADDING-BOTTOM: 3px" class=ms-addnew><A id=A2 class=ms-addnew href="javascript:RemoveSolutions()">Remove Solutions</A> </TD>
        </TR>
        </TBODY></TABLE>
        </td>
    </tr>


    <tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
    <tr><td class="ms-linksectionheader" colspan="2"><h3 class="ms-standardheader">Database</h3></td></tr>
    </table></td></tr>
    <wssuc:InputFormSection Title="Connection String"
		Description=""
		runat="server">
		<Template_Description>
		    Enter the connection string which you would like to use to connect to the EPMLIVE database.<br /><br />
		    Ex: Server=SERVERNAME;Database=epmlive;Trusted_Connection=True
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Connection String:" runat="server" width="100%" ID="con1">
				 <Template_Control>
				    <asp:TextBox ID="txtConnString" runat="server" Height="100" Width ="390" TextMode="MultiLine" CssClass="ms-input"></asp:TextBox>
				 </Template_Control>
		    </wssuc:InputFormControl>
		    <wssuc:InputFormControl LabelText="Status:" runat="server" width="100%" ID="con2">
				 <Template_Control>
                    <asp:Label ID="lblStatusDyn" runat="server" Text="" Font-Size="X-Small" BorderStyle="None" Width="390px" BackColor="white"></asp:Label>
                    <asp:Button ID="btnInstallDB" runat="server" onClientClick="CreateDatabase();return false;" Visible="false" Text="Create Database"/>
				 </Template_Control>
		    </wssuc:InputFormControl>
            <wssuc:InputFormControl LabelText="Version:" runat="server" width="100%" ID="con3">
				 <Template_Control>
                    <asp:Label ID="lblVersion" runat="server" Text="" Font-Size="X-Small" BorderStyle="None" Width="390px" BackColor="white"></asp:Label>
                    <asp:Button ID="btnUpgrade" runat="server" onClick="btnUpgrade_Click" Visible="false" Text="Upgrade"/>
				 </Template_Control>
		    </wssuc:InputFormControl>
		</Template_InputFormControls>

	</wssuc:InputFormSection>

    <tr><td colspan="2"><table class="ms-toolbar" width="100%" cellpadding="3" style="height:20px">
    <tr><td class="ms-linksectionheader" colspan="2"><h3 class="ms-standardheader">Reporting</h3></td></tr>
    </table></td></tr>
	<wssuc:InputFormSection Title="Reporting Services Configuration"
		Description=""
		runat="server">
		<Template_Description>
		    <b>URL:</b> Enter the URL for your SQL Server Reporting Services.<br />
		    Ex: http://servername/reportserver<br /><br />
		    <b>Default Path:</b> By default the reports are installed on the root of Reporting Services and do not require configuration. If you have installed in a non-default location you will need to 
		    specify that here.<br /><br />
		    <b>Use Integrated Mode:</b> Select this option if your SQL Server Reporting Services uses SharePoint Integrated Mode.<br /><br />
		    <b>Username/Password:</b> If you have multiple WFE's or your SSRS is not installed on your WFE, you will need to specify the web application account credentials here. These credentials will be used to authenticate to SSRS.<br /><br />
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="URL:" runat="server" width="100%">
				 <Template_Control>
				    <asp:TextBox ID="txtReportServer" runat="server" CssClass="ms-input"></asp:TextBox>
				 </Template_Control>
		    </wssuc:InputFormControl>
		    <wssuc:InputFormControl LabelText="Path:" runat="server" width="100%">
				 <Template_Control>
				    <asp:TextBox ID="txtDefaultPath" runat="server" CssClass="ms-input"></asp:TextBox>
				 </Template_Control>
		    </wssuc:InputFormControl>
		    <wssuc:InputFormControl LabelText="Use Integrated Mode:" runat="server" width="100%">
				 <Template_Control>
				    <asp:CheckBox ID="chkIntegrated" runat="server" />
				 </Template_Control>
		    </wssuc:InputFormControl>
		    <wssuc:InputFormControl LabelText="Username:" runat="server" width="100%">
				 <Template_Control>
				    <asp:TextBox ID="txtUsername" runat="server" CssClass="ms-input"></asp:TextBox>
				 </Template_Control>
		    </wssuc:InputFormControl>
            <wssuc:InputFormControl LabelText="Password:" runat="server" width="100%">
				 <Template_Control>
				    <asp:TextBox ID="txtPassword" runat="server" CssClass="ms-input" TextMode=Password></asp:TextBox>
				 </Template_Control>
		    </wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	
	

	<wssuc:ButtonSection runat="server">
		<Template_Buttons>
			<asp:PlaceHolder ID="PlaceHolder1" runat="server">
				<asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Button1_Click" Text="Save Settings" id="Button1" accesskey="" Width="150"/>
			</asp:PlaceHolder>
		</Template_Buttons>
	</wssuc:ButtonSection>
    </table>
    </asp:Panel>
</asp:Content>