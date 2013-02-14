<%@ Assembly Name="EPMLiveWorkPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveWorkPlanner.showgantt" %> 
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Add Outline Code</title>
    <link rel="stylesheet" type="text/css" href="/_layouts/1033/styles/core.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%" height="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                 <table class="ms-menutoolbar" cellpadding="2" cellspacing="0" border="0" width="100%">
                    <tr height="23">
                        <td width="100%"> </td>
                        <td class="ms-toolbar" align="right" width="200" nowrap>
		                    <asp:Label ID="lblZoom" runat="server" Text="Zoom:"/>
                            <asp:HyperLink runat="server" ID="imgZoomIn" ImageUrl="/_layouts/images/ganttzoomin.GIF" NavigateUrl="Javascript:GanttZoomIn();" />
                            <asp:HyperLink runat="server" ID="imgZoomOut" ImageUrl="/_layouts/images/ganttzoomout.GIF" NavigateUrl="Javascript:GanttZoomOut();" />
            			        
		                </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr height="100%">
            <td>
                <OBJECT CLASSID="clsid:5220cb21-c88d-11cf-b347-00aa00a28331" VIEWASTEXT><PARAM NAME="LPKPath" VALUE="/_layouts/epmlive/ex2gantt.lpk"></OBJECT>

                <OBJECT id=G2antt1 style='z-index:-1' classid=clsid:CD481F4D-2D25-4759-803F-752C568F53B7 CODEBASE="/_layouts/epmlive/gantt.cab" height="100%" width=100%></OBJECT>
            </td>
        </tr>
    </table>
   
        
        <SCRIPT LANGUAGE="javascript">
            document.body.onload = function()
            {
                var G2antt1 = document.getElementById("G2antt1");
                G2antt1.BeginUpdate();
                G2antt1.Appearance = 0;
                G2antt1.MarkSearchColumn = 0;
                G2antt1.Chart.PaneWidth(0) = document.getElementById("G2antt1").clientWidth / 2;
                G2antt1.DrawGridLines = 1;
                G2antt1.Chart.DrawGridLines = 1;
                G2antt1.ColumnAutoResize = false;
                G2antt1.Chart.OverviewVisible = 1;
                G2antt1.Chart.OverviewHeight = 24;

                G2antt1.LoadXML("<%=strUrl%>/_layouts/epmlive/getgantttasks.aspx?data=<%=strParams%>&source=" + document.location.href);
                G2antt1.Template = "<%=strTemplate%>";
                G2antt1.EndUpdate();

            }
            </SCRIPT>
            <SCRIPT FOR=G2antt1 EVENT=AnchorClick(Anchor,Options) LANGUAGE=JScript>
                document.location.href=Anchor
            </SCRIPT>
            <%=strFunctions %>
    </div>
     </form>
</body>
</html>