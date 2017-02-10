<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newlicense.aspx.cs" Inherits="AdminSite.newlicense" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add new license</title>

    <%-- TODO: move this to a separated file? --%>
    <link href="style/licensesManagement.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  
    <script>
          $( function() {
              $(".datepicker").datepicker({
                  changeMonth: true,
                  changeYear: true
              });
          } );
    </script>

</head>
<body>
    <form id="newLicenseForm" runat="server">
    <div>

        <fieldset>
            <legend>License Details</legend>
            <br />

            <asp:Label ID="Label1" runat="server" Text="Select Product"></asp:Label>
            <asp:DropDownList ID="DropDownProductCatalog" runat="server"></asp:DropDownList>

            <br />

            <asp:Label ID="Label2" runat="server" Text="Activation Date"></asp:Label>
            <asp:TextBox class="datepicker" ID="TxtActivationDate" runat="server"></asp:TextBox>

            <br />

            <asp:Label ID="Label3" runat="server" Text="Expiration Date"></asp:Label>
            <asp:TextBox class="datepicker" ID="TxtExpirationDate" runat="server"></asp:TextBox>

        </fieldset>

        <br /><br />

        <fieldset>
            <legend>License Features</legend>
            <br />
            
            <div id="featureListInnerDiv" runat="server"></div>

        </fieldset>
        
        <br />

        <asp:Button ID="Button1" runat="server" Text="Add License" OnClick="btnSubmit_Click" />

    </div>
    </form>
</body>
</html>

