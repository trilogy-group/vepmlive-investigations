<%@ Assembly Name="EPMLiveWebParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveWebParts.showlisterror" %> 
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
        parent.document.getElementById("frmEditFrame").style.display = "";

        parent.document.getElementById("tblEditItem").style.width = "250";
        parent.document.getElementById("tblEditItem").style.height = "100";
        parent.document.getElementById("editItem").style.top =  200;
        
        parent.document.getElementById("editItem").style.left = getWidth() / 2 - 125;
        
        function closePage()
        {
            parent.document.getElementById("editItem").style.display = "none";
            parent.document.getElementById("editItem").style.top =  150;
            parent.document.getElementById("editItem").style.left = getWidth() / 2 - 350;
            parent.document.getElementById("tblEditItem").style.width = "700";
            parent.document.getElementById("tblEditItem").style.height = "400";
        }
        function getWidth() {
	        
	         if (parseInt(navigator.appVersion)>3) {
             if (navigator.appName=="Netscape") {
              return parent.window.innerWidth-16;
              //winH = window.innerHeight-16;
             }
             if (navigator.appName.indexOf("Microsoft")!=-1) {
              return parent.document.body.offsetWidth-20;
              //winH = document.body.offsetHeight-20;
             }
            }

	    }
    </script>
</body>
    