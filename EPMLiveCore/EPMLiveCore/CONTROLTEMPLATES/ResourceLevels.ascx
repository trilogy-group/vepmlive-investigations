﻿<%@ Control Language="C#" Debug="true" %>
<%@ Assembly Name="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" Namespace="Microsoft.SharePoint.WebControls" %>
<SharePoint:RenderingTemplate ID="ResourceLevelsFieldControl" runat="server">
    <Template>
        <asp:RadioButtonList ID="ddlLevels" runat="server" ></asp:RadioButtonList>
    </Template>
</SharePoint:RenderingTemplate>