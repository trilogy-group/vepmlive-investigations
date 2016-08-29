
<%@ Page Language="C#" Inherits="System.Web.UI.Page" %> 
<%@ Assembly Name="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Import Namespace="Microsoft.SharePoint.Utilities" %> 
<%@ Import Namespace="Microsoft.SharePoint" %>
<% Response.ContentType = "text/xml"; %>

<wsdl:definitions xmlns:tm="http://microsoft.com/wsdl/mime/textMatching/" xmlns:s="http://www.w3.org/2001/XMLSchema" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" xmlns:http="http://schemas.xmlsoap.org/wsdl/http/" xmlns:tns="PortfolioEngine" xmlns:mime="http://schemas.xmlsoap.org/wsdl/mime/" xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/" xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/" targetNamespace="PortfolioEngine" xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">
  <wsdl:types>
    <s:schema elementFormDefault="qualified" targetNamespace="PortfolioEngine">
      <s:element name="CheckStatus">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Context" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CheckStatusResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="CheckStatusResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="Execute">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Function" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="Dataxml" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="ExecuteResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ExecuteResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="ExecuteJSON">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Function" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="Dataxml" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="ExecuteJSONResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ExecuteJSONResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
    </s:schema>
  </wsdl:types>
  <wsdl:message name="CheckStatusSoapIn">
    <wsdl:part name="parameters" element="tns:CheckStatus" />
  </wsdl:message>
  <wsdl:message name="CheckStatusSoapOut">
    <wsdl:part name="parameters" element="tns:CheckStatusResponse" />
  </wsdl:message>
  <wsdl:message name="ExecuteSoapIn">
    <wsdl:part name="parameters" element="tns:Execute" />
  </wsdl:message>
  <wsdl:message name="ExecuteSoapOut">
    <wsdl:part name="parameters" element="tns:ExecuteResponse" />
  </wsdl:message>
  <wsdl:message name="ExecuteJSONSoapIn">
    <wsdl:part name="parameters" element="tns:ExecuteJSON" />
  </wsdl:message>
  <wsdl:message name="ExecuteJSONSoapOut">
    <wsdl:part name="parameters" element="tns:ExecuteJSONResponse" />
  </wsdl:message>
  <wsdl:portType name="RPEditorSoap">
    <wsdl:operation name="CheckStatus">
      <wsdl:input message="tns:CheckStatusSoapIn" />
      <wsdl:output message="tns:CheckStatusSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="Execute">
      <wsdl:input message="tns:ExecuteSoapIn" />
      <wsdl:output message="tns:ExecuteSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="ExecuteJSON">
      <wsdl:input message="tns:ExecuteJSONSoapIn" />
      <wsdl:output message="tns:ExecuteJSONSoapOut" />
    </wsdl:operation>
  </wsdl:portType>
  <wsdl:binding name="RPEditorSoap" type="tns:RPEditorSoap">
    <soap:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="CheckStatus">
      <soap:operation soapAction="PortfolioEngine/CheckStatus" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="Execute">
      <soap:operation soapAction="PortfolioEngine/Execute" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="ExecuteJSON">
      <soap:operation soapAction="PortfolioEngine/ExecuteJSON" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:binding name="RPEditorSoap12" type="tns:RPEditorSoap">
    <soap12:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="CheckStatus">
      <soap12:operation soapAction="PortfolioEngine/CheckStatus" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="Execute">
      <soap12:operation soapAction="PortfolioEngine/Execute" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="ExecuteJSON">
      <soap12:operation soapAction="PortfolioEngine/ExecuteJSON" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:service name="RPEditor">
    <wsdl:port name="RPEditorSoap" binding="tns:RPEditorSoap">
      <soap:address location=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(SPWeb.OriginalBaseUrl(Request)),Response.Output); %> />
    </wsdl:port>
    <wsdl:port name="RPEditorSoap12" binding="tns:RPEditorSoap12">
      <soap12:address location=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(SPWeb.OriginalBaseUrl(Request)),Response.Output); %> />
    </wsdl:port>
  </wsdl:service>
</wsdl:definitions>
