<%@ Assembly Name="EPMLiveWorkPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveWorkPlanner.edititem" %> 
<%@ OutputCache Location="None" VaryByParam="None" %>

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<head id="Head1" runat="server">
    <link rel="stylesheet" type="text/css" href="/_layouts/1033/styles/core.css"/>
    <%if(Request["Mode"] == "1"){ %>
        <base href="<%=webUrl%>" />
    <%}%>
</head>
<body style="padding:10px">
    <form id="form1" runat="server">
    <div>
            <SharePoint:FormDigest ID="FormDigest1" runat="server"/>
                <WebPartPages:ListFormWebPart ID="ListFormWebPart1" runat="server" __MarkupType="xmlmarkup" WebPart="true" __WebPartId="{CEDA63B2-55BB-4A38-8764-AE64C9B59F9A}" OnInit="ListFormWebPart1_Init">
                <WebPart xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://schemas.microsoft.com/WebPart/v2">
                  <Title></Title>
                  <FrameType>Default</FrameType>
                  <Description />
                  <IsIncluded>true</IsIncluded>
                  <PartOrder>1</PartOrder>
                  <FrameState>Normal</FrameState>
                  <Height />
                  <Width />
                  <AllowRemove>true</AllowRemove>
                  <AllowZoneChange>true</AllowZoneChange>
                  <AllowMinimize>true</AllowMinimize>
                  <AllowConnect>true</AllowConnect>
                  <AllowEdit>true</AllowEdit>
                  <AllowHide>true</AllowHide>
                  <IsVisible>true</IsVisible>
                  <DetailLink />
                  <HelpLink />
                  <HelpMode>Modeless</HelpMode>
                  <Dir>Default</Dir>
                  <PartImageSmall />
                  <MissingAssembly>Cannot import this Web Part.</MissingAssembly>
                  <PartImageLarge />
                  <IsIncludedFilter />
                  <ExportControlledProperties>true</ExportControlledProperties>
                  <ConnectionID>00000000-0000-0000-0000-000000000000</ConnectionID>
                  <ID>g_ceda63b2_55bb_4a38_8764_ae64c9b59f9a</ID>
                  <ListName xmlns="http://schemas.microsoft.com/WebPart/v2/ListForm">{19fcbed7-c7b9-4823-8a8e-2c63bc2fb0bc}</ListName>
                  <ListItemId xmlns="http://schemas.microsoft.com/WebPart/v2/ListForm">0</ListItemId>
                  <ControlMode xmlns="http://schemas.microsoft.com/WebPart/v2/ListForm">Edit</ControlMode>
                  <TemplateName xmlns="http://schemas.microsoft.com/WebPart/v2/ListForm">ListForm</TemplateName>
                  <FormType xmlns="http://schemas.microsoft.com/WebPart/v2/ListForm">6</FormType>
                  <ViewFlag xmlns="http://schemas.microsoft.com/WebPart/v2/ListForm">1048576</ViewFlag>
                </WebPart>
                </WebPartPages:ListFormWebPart>

    </div>
    </form>
    <script language="javascript" type="text/javascript">
        if(<%=pageClose%>)
        {
            //parent.document.getElementById("editItemLoad").style.display="";
            //parent.document.getElementById("frmEditFrame").style.display="none";
            parent.window.hm('edititem');
            //parent.document.getElementById("editItem").style.display="none";
        }
        else
        {
            parent.document.getElementById("editItemLoad").style.display="none";
            parent.document.getElementById("frmEditFrame").style.display="";
        }
        function closePage()
        {
            parent.window.hm('edititem');
            //parent.document.getElementById("editItem").style.display="none";
        }
        document.getElementById("g_ceda63b2_55bb_4a38_8764_ae64c9b59f9a_ctl00_ctl01_ctl00_toolBarTbl").style.display = "none";
        var tags = document.getElementsByTagName("a");
        for (var i=0; i < tags.length; i++) 
        {
            if (tags[i].toString().indexOf("http://") >= 0)
            {
                tags[i].setAttribute("target","_blank");
            }
        }
    </script>
</body>
</html>

