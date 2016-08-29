<?xml version="1.0" encoding="utf-8"?>
<discovery xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.xmlsoap.org/disco/">
  <contractRef ref=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(SPWeb.OriginalBaseUrl(Request) + "?wsdl"),Response.Output); %> docRef=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(SPWeb.OriginalBaseUrl(Request)),Response.Output); %> xmlns="http://schemas.xmlsoap.org/disco/scl/" />
  <soap address=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(SPWeb.OriginalBaseUrl(Request)),Response.Output); %> xmlns:q1="workengine.com" binding="q1:WorkEngineSoap" xmlns="http://schemas.xmlsoap.org/disco/soap/" />
  <soap address=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(SPWeb.OriginalBaseUrl(Request)),Response.Output); %> xmlns:q2="workengine.com" binding="q2:WorkEngineSoap12" xmlns="http://schemas.xmlsoap.org/disco/soap/" />
</discovery>