<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" %> 
<html>

<body>
    <div id="div1">
        asdf
    </div>

    <script language="javascript">

        document.getElementById("div1").innerHTML = window.opener.document.getElementById("ctl00_PlaceHolderMain_txtBody").value;

    </script>
</body>
</html>
