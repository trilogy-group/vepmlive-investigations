<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%>
<%@ Page Language="C#" Inherits="EPMLiveCore.openprojectplan" MasterPageFile="~/_layouts/application.master"%>

<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
    <script language="javascript">
        function editinpj() {
            editDocumentWithProgID2('<%=filePath %>', '', 'SharePoint.OpenDocuments', '0', '<%=webUrl %>', '0');
            
            <%if(String.IsNullOrEmpty(Request["Source"])){ %>
                window.close();
            <%}else if( Request["IsDlg"] == "1"){%>
                parent.location.href = "<%=Request["Source"] %>";
            <%}else{ %>
                location.href = "<%=Request["Source"] %>";
            <%} %>
        }
    </script>

    Opening Project...
    <style>
        .s4-ribbonrow
        {display:none;}
    </style>
</asp:Content>