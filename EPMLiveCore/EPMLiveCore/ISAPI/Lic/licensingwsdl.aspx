<%@ Page Language="C#" Inherits="System.Web.UI.Page" %> 
<%@ Assembly Name="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Import Namespace="Microsoft.SharePoint.Utilities" %> 
<%@ Import Namespace="Microsoft.SharePoint" %>
<% Response.ContentType = "text/xml"; %>

<wsdl:definitions xmlns:tm="http://microsoft.com/wsdl/mime/textMatching/" xmlns:s="http://www.w3.org/2001/XMLSchema" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" xmlns:http="http://schemas.xmlsoap.org/wsdl/http/" xmlns:tns="workengine.com" xmlns:mime="http://schemas.xmlsoap.org/wsdl/mime/" xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/" xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/" targetNamespace="workengine.com" xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">
  <wsdl:types>
    <s:schema elementFormDefault="qualified" targetNamespace="workengine.com">
      <s:element name="GetAdminUser">
        <s:complexType />
      </s:element>
      <s:element name="GetAdminUserResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetAdminUserResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SetUserLevel">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="username" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="featureId" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SetUserLevelResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="SetUserLevelResult" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
    </s:schema>
  </wsdl:types>
  <wsdl:message name="GetAdminUserSoapIn">
    <wsdl:part name="parameters" element="tns:GetAdminUser" />
  </wsdl:message>
  <wsdl:message name="GetAdminUserSoapOut">
    <wsdl:part name="parameters" element="tns:GetAdminUserResponse" />
  </wsdl:message>
  <wsdl:message name="SetUserLevelSoapIn">
    <wsdl:part name="parameters" element="tns:SetUserLevel" />
  </wsdl:message>
  <wsdl:message name="SetUserLevelSoapOut">
    <wsdl:part name="parameters" element="tns:SetUserLevelResponse" />
  </wsdl:message>
  <wsdl:portType name="LicensingSoap">
    <wsdl:operation name="GetAdminUser">
      <wsdl:input message="tns:GetAdminUserSoapIn" />
      <wsdl:output message="tns:GetAdminUserSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="SetUserLevel">
      <wsdl:input message="tns:SetUserLevelSoapIn" />
      <wsdl:output message="tns:SetUserLevelSoapOut" />
    </wsdl:operation>
  </wsdl:portType>
  <wsdl:binding name="LicensingSoap" type="tns:LicensingSoap">
    <soap:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="GetAdminUser">
      <soap:operation soapAction="workengine.com/GetAdminUser" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SetUserLevel">
      <soap:operation soapAction="workengine.com/SetUserLevel" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:binding name="LicensingSoap12" type="tns:LicensingSoap">
    <soap12:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="GetAdminUser">
      <soap12:operation soapAction="workengine.com/GetAdminUser" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SetUserLevel">
      <soap12:operation soapAction="workengine.com/SetUserLevel" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:service name="Licensing">
    <wsdl:port name="LicensingSoap" binding="tns:LicensingSoap">
      <soap:address location=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(SPWeb.OriginalBaseUrl(Request)),Response.Output); %> />
    </wsdl:port>
    <wsdl:port name="LicensingSoap12" binding="tns:LicensingSoap12">
      <soap12:address location=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(SPWeb.OriginalBaseUrl(Request)),Response.Output); %> />
    </wsdl:port>
  </wsdl:service>
</wsdl:definitions>