<%@ Page Language="C#" Inherits="System.Web.UI.Page" %> 
<%@ Assembly Name="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Import Namespace="Microsoft.SharePoint.Utilities" %> 
<%@ Import Namespace="Microsoft.SharePoint" %>
<% Response.ContentType = "text/xml"; %>

<discovery xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.xmlsoap.org/disco/">
  <contractRef ref="http://epk2008/_layouts/rpeditor.asmx?wsdl" docRef="http://epk2008/_layouts/rpeditor.asmx" xmlns="http://schemas.xmlsoap.org/disco/scl/" />
  <soap address="http://epk2008/_layouts/rpeditor.asmx" xmlns:q1="PortfolioEngine" binding="q1:RPEditorSoap" xmlns="http://schemas.xmlsoap.org/disco/soap/" />
  <soap address="http://epk2008/_layouts/rpeditor.asmx" xmlns:q2="PortfolioEngine" binding="q2:RPEditorSoap12" xmlns="http://schemas.xmlsoap.org/disco/soap/" />
</discovery>