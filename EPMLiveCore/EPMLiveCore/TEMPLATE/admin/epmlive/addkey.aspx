<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveCore.adminaddkey"%> 
<html>
<head id="Head1" runat="server">
    <title>Add Key</title>
    <link rel="stylesheet" type="text/css" href="/_layouts/1033/styles/core.css"/>
    <script language="javascript">

            function closeme()
            {
                opener.location.href='features.aspx?';
            }
            window.onbeforeunload=closeme;
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="10" cellspacing="0" width="100%" height="100%">
            <tr>
                <td class="ms-linksectionheader" valign="middle" align="center" >
                    <h3 class="ms-standardheader">
                        <asp:Label ID="lblResult" runat="server"></asp:Label>
                    </h3>
                </td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
