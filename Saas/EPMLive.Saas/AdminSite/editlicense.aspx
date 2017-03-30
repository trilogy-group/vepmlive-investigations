<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editlicense.aspx.cs" Inherits="AdminSite.editlicense" %>

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
    <form id="newLicenseForm" runat="server">
    <div>
        <label  id="errorLabel" runat="server" visible="false" style="color:red"></label>
        <br />
        <fieldset>
            <legend>License Details Edit</legend>
            <br />

            <asp:Label ID="Label1" runat="server" Text="Select Product"></asp:Label>
            <asp:DropDownList ID="DropDownProductCatalog" runat="server" Enabled="false"></asp:DropDownList>

            <br />

            <asp:Label ID="Label2" runat="server" Text="Activation Date"></asp:Label>
            <input type="text" class="datepicker readonly" runat="server" id="TxtNewActivationDate" required="required" />
           
            <br />

            <asp:Label ID="Label3" runat="server" Text="Expiration Date"></asp:Label>
            <input type="text" class="datepicker readonly" runat="server" id="TxtNewExpirationDate" required="required" />

        </fieldset>

        <br />

        <fieldset>
            <legend>License Features Edit</legend>
            <br />
            
            <div id="featureListInnerDiv" runat="server"></div>

        </fieldset>
        
        <br />

        <asp:Button ID="btnSubmit" runat="server" Text="Extend License" OnClick="btnSubmit_Click" />
        <asp:Button id="Button2" runat="server" Text="Cancel" OnClientClick="parent.CloseEditLicenseModal()"/>
    </div>
    </form>
</body>
</html>

