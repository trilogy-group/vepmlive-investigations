<%@ Assembly Name="EPMLiveWorkPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveWorkPlanner.showerror" %> 
<%@ OutputCache Location="None" VaryByParam="None" %>

<head id="Head1" runat="server">
    <link rel="stylesheet" type="text/css" href="/_layouts/1033/styles/core.css"/>
    
</head>
<body style="padding:10px">
    <form id="form1" runat="server">
    <div>
        <font class="ms-descriptiontext"><b><%=Request["error"] %></b><br /></font>
        <br />
        <p align="right">
            <input type="button" value="Close" onclick="closePage()" />
        </p>
    </div>
    </form>
    <script language="javascript" type="text/javascript">
        parent.document.getElementById("editItemLoad").style.display = "none";
        
        function closePage()
        {
            parent.window.hm('edititem');
        }
        
    </script>
</body>
    