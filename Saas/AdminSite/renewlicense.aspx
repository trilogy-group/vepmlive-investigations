<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="renewlicense.aspx.cs" Inherits="AdminSite.renewlicense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Renew License</title>
    <link href="style/licensesManagement.css" rel="stylesheet" />
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <script>
          $( function() {
              $(".datepicker").datepicker({
                  changeMonth: true,
                  changeYear: true,
                  minDate: 0
              });

              $(".readonly").keydown(function (e) {
                  e.preventDefault();
              });

          } );
    </script>
</head>
<body>
    <form id="renewLicenseForm" runat="server">
        <label  id="errorLabel" runat="server" visible="false" style="color:red"></label>
        <br />
    <div>
        <asp:Label ID="Label3" runat="server" Text="New Expiration Date"></asp:Label>
        <input type="text" class="datepicker readonly" runat="server" id="TxtExpirationDate" required="required" />
    </div>
        <br />
        <asp:Button ID="btnRenew" runat="server" Text="Renew" OnClick="btnRenew_Click" />
        <asp:Button id="Button2" runat="server" Text="Cancel" OnClientClick="parent.CloseLicenseModal()"/>
    </form>
</body>
</html>
