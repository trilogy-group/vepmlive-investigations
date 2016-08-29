<%@ Assembly Name="EPMLiveWebParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveWebParts.checkresgantt" %> 
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Check Resources</title>
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
                        <td width="100%" class="ms-toolbar" nowrap="true">
                            <div class="ms-buttoninactivehover" onmouseover="this.className='ms-buttonactivehover'" onmouseout="this.className='ms-buttoninactivehover'" onclick="setDates();" style="width:80px">Save Dates</div>
                        </td>
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

                <OBJECT id=G2antt1 style='z-index:-1;' classid=clsid:CD481F4D-2D25-4759-803F-752C568F53B7 CODEBASE="/_layouts/epmlive/gantt.cab" height="100%" width=100%></OBJECT>
                <div id="noitems" style="display:none;" class="ms-vb">There are no items to show in this view.</div>
                <div  width="100%" id="loadinggantt" align="center">
                    <img src="/_layouts/images/gears_anv4.gif" style="vertical-align: middle;"/> Loading Items...
                </div>
            </td>
        </tr>
    </table>
        
        <SCRIPT LANGUAGE="javascript">
        
            var G2antt1;
            var format = '<%=dfmt%>';
            var startfield = '<%=Request["startfield"]%>';
            var endfield = '<%=Request["endfield"]%>';
            function loadGanttXml(){
                try
                {
                    G2antt1.LoadXML("<%=strUrl%>/_layouts/epmlive/getresourcecheckplan.aspx?data=<%=strParams%>&startdate=<%=Request["startdate"]%>&enddate=<%=Request["enddate"]%>&work=<%=Request["work"]%>&title=<%=Request["title"]%>&ignorelistid=<%=Request["listid"]%>&ignoreitemid=<%=Request["itemid"]%>");
                }
                catch(e){}
                G2antt1.Template = "<%=strTemplate%>";
                
                if(G2antt1.Items.ItemCount == 0)
                {
		            document.getElementById("noitems").style.display="";
		            document.getElementById("G2antt1").style.display="none";
	            }
	            else
	            {
                    doSummaryTasks();
                    document.getElementById("G2antt1").style.display="";
                }
                    
                document.getElementById("loadinggantt").style.display="none";
                
                
                   
            }
            
            function getDate(dt)
            {
                var dtRet = format;
                dtRet = dtRet.replace('M',dt.getMonth() + 1);
                dtRet = dtRet.replace('d',dt.getDate());
                dtRet = dtRet.replace('yyyy',dt.getYear());
                return dtRet;
            }
            function findacontrol(FieldName) {   
	            var arr = window.opener.document.getElementsByTagName("!");
	            for (var i=0;i < arr.length; i++ )
	              if (arr[i].innerHTML.indexOf(FieldName) > 0)
		            return arr[i];
            }   
            function setDates()
            {
                var workplanner = "<%=strWorkplanner %>";
                var callback = "<%=strCallBack %>";
                var itemid = "<%=strItemId%>";
                var item = G2antt1.Items(0);
                var d = new Date(G2antt1.Items.ItemBar(item,"",1));
                var start = getDate(d);
                
                d = new Date(G2antt1.Items.ItemBar(item,"",2));
                d.setDate(d.getDate() - 1);
                var end = getDate(d);
                 
                if(callback != "")
                {
                    eval("window.opener." + callback + "('" + start + "','" + end + "')");
                }
                else if(workplanner == "1")
                {
                    window.opener.saveresgantt(itemid,start,end);
                }
                else
                {
                    window.opener.document.getElementById(startfield).value = start;
                    window.opener.document.getElementById(endfield).value = end;
                }
                window.close();
            }
            
            document.body.onload = function()
            {
                G2antt1 = document.getElementById("G2antt1");
                G2antt1.BeginUpdate();
                G2antt1.Appearance = 0;
                G2antt1.MarkSearchColumn = 0;
                G2antt1.Chart.PaneWidth(0) = document.getElementById("G2antt1").clientWidth / 4;
                G2antt1.DrawGridLines = 1;
                G2antt1.Chart.DrawGridLines = 1;
                G2antt1.ColumnAutoResize = false;
                G2antt1.Chart.OverviewVisible = 1;
                G2antt1.Chart.OverviewHeight = 24;
                G2antt1.Chart.HistogramVisible = 1;
                G2antt1.Chart.HistogramHeight = 60;
                G2antt1.Chart.HistogramView = 112;
                
                document.getElementById("G2antt1").style.display="none";
                G2antt1.EndUpdate();
                setTimeout("loadGanttXml()",1);
                
                

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