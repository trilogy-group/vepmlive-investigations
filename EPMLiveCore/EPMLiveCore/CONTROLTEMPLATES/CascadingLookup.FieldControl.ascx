<%@ Control Language="C#" Debug="true" %>
<%@ Assembly Name="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" Namespace="Microsoft.SharePoint.WebControls" %>
<SharePoint:RenderingTemplate ID="CascadingLookupFieldControl" runat="server">
    <Template>
        <asp:DropDownList runat="server" ID="ddlCLField" CssClass="ms-radiotext" />
        <asp:Label runat="server" ID="lblError" CssClass="ms-alerttext" />
    </Template>
</SharePoint:RenderingTemplate>