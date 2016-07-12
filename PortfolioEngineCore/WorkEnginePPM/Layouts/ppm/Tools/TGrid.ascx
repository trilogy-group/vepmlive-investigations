<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TGrid.ascx.cs" Inherits="WorkEnginePPM.TGrid" %>

<asp:ScriptManagerProxy ID="sm1" runat="server">
    <Services>
    </Services>
</asp:ScriptManagerProxy>


<asp:HiddenField ID="hiddenTableData" runat="server"></asp:HiddenField>
<div style="margin-left:4px; margin-right:4px;" id="<%=ClientID%>_tgrid_div" >
<div id="<%=ClientID%>_treegrid_div" style="height:300px;overflow:hidden;"></div>
</div>
<script type="text/javascript">
    try {
        var params = {};
        params.ClientID = '<%=ClientID%>';
        params.treegrid_div = "<%=ClientID%>_treegrid_div";
        params.tg_id = 'tg_<%=UID%>';
        params.tg_uid = '<%=UID%>';
        params.DataTag = '<%=hiddenTableData.ClientID%>';
        window['<%=UID%>'] = new TGrid(params);
    }
    catch (e) {
        alert("TGrid ascx Initialization : " + e.toString());
    }

</script>
