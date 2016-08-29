<%@ Page Language="C#" Inherits="System.Web.UI.Page"%> 
<%@ Assembly Name="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Import Namespace="Microsoft.SharePoint.Utilities" %> 
<%@ Import Namespace="Microsoft.SharePoint" %> 
<% Response.ContentType = "text/xml"; %> 

<?xml version="1.0" encoding="utf-8"?>
<discovery xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://schemas.xmlsoap.org/disco/">
  <contractRef ref="http://demo.epmlive.com/_layouts/ResPlanAnalyzer.asmx?wsdl" docRef="http://demo.epmlive.com/_layouts/ResPlanAnalyzer.asmx" xmlns="http://schemas.xmlsoap.org/disco/scl/" />
  <soap address="http://demo.epmlive.com/_layouts/ResPlanAnalyzer.asmx" xmlns:q1="WorkEnginePPM" binding="q1:ResPlanAnalyzerSoap" xmlns="http://schemas.xmlsoap.org/disco/soap/" />
  <soap address="http://demo.epmlive.com/_layouts/ResPlanAnalyzer.asmx" xmlns:q2="WorkEnginePPM" binding="q2:ResPlanAnalyzerSoap12" xmlns="http://schemas.xmlsoap.org/disco/soap/" />
</discovery>