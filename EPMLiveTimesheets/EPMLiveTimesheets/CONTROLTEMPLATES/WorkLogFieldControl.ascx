<%@ Control Language="C#" %>
<%@ Assembly Name="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" Namespace="Microsoft.SharePoint.WebControls" %>

<SharePoint:RenderingTemplate ID="WorkLogFieldControl" runat="server">
  <Template>
    <script language="javascript">
        function openwindow(wurl) {
            function myCallback(dialogResult, returnValue) { }

            var options = { url: wurl, width: 600, dialogReturnValueCallback: myCallback };

            SP.UI.ModalDialog.showModalDialog(options);
        }
    </script>
    <asp:TextBox ID="TextField" runat="server" Visible="false"  />
    <a href="#" ID="lnkPopup" runat="server" onclick="javascript:return false;" >Enter Hours</a>

  </Template>
</SharePoint:RenderingTemplate>