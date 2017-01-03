<%@ Page Language="C#" AutoEventWireup="true" CodeFile="timeout.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="font-family:Verdana,Arial;font-size:14px;color:#555555;">Your session has timed out. Please refresh the page.</div>
        <script language="javascript">

            var bUrl = document.referrer;
            var slash = bUrl.indexOf("/", 9);
            bUrl = bUrl.substr(0, slash);
            window.parent.postMessage("closed", bUrl);

        </script>
    </div>
    </form>
</body>
</html>