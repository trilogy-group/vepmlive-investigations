<%@ Page Language="C#" Inherits="System.Web.UI.Page" %> 
<%@ Assembly Name="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Import Namespace="Microsoft.SharePoint.Utilities" %> 
<%@ Import Namespace="Microsoft.SharePoint" %>
<% Response.ContentType = "text/xml"; %>

<discovery xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.xmlsoap.org/disco/">
  <contractRef ref="http://demo.epmlive.com/_layouts/webservice.asmx?wsdl" docRef="http://demo.epmlive.com/_layouts/webservice.asmx" xmlns="http://schemas.xmlsoap.org/disco/scl/" />
  <soap address="http://demo.epmlive.com/_layouts/webservice.asmx" xmlns:q1="PPM.Services" binding="q1:WebServiceSoap" xmlns="http://schemas.xmlsoap.org/disco/soap/" />
  <soap address="http://demo.epmlive.com/_layouts/webservice.asmx" xmlns:q2="PPM.Services" binding="q2:WebServiceSoap12" xmlns="http://schemas.xmlsoap.org/disco/soap/" />
</discovery>