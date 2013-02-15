<%@ Page Language="C#" Inherits="System.Web.UI.Page"%> 
<%@ Assembly Name="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Import Namespace="Microsoft.SharePoint.Utilities" %> 
<%@ Import Namespace="Microsoft.SharePoint" %> 
<% Response.ContentType = "text/xml"; %> 

<wsdl:definitions xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/" xmlns:tm="http://microsoft.com/wsdl/mime/textMatching/" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" xmlns:mime="http://schemas.xmlsoap.org/wsdl/mime/" xmlns:tns="WorkEnginePPM" xmlns:s="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/" xmlns:http="http://schemas.xmlsoap.org/wsdl/http/" targetNamespace="WorkEnginePPM" xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">
  <wsdl:types>
    <s:schema elementFormDefault="qualified" targetNamespace="WorkEnginePPM">
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
  <wsdl:portType name="ResPlanAnalyzerSoap">
    <wsdl:operation name="Execute">
      <wsdl:input message="tns:ExecuteSoapIn" />
      <wsdl:output message="tns:ExecuteSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="ExecuteJSON">
      <wsdl:input message="tns:ExecuteJSONSoapIn" />
      <wsdl:output message="tns:ExecuteJSONSoapOut" />
    </wsdl:operation>
  </wsdl:portType>
  <wsdl:binding name="ResPlanAnalyzerSoap" type="tns:ResPlanAnalyzerSoap">
    <soap:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="Execute">
      <soap:operation soapAction="WorkEnginePPM/Execute" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="ExecuteJSON">
      <soap:operation soapAction="WorkEnginePPM/ExecuteJSON" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:binding name="ResPlanAnalyzerSoap12" type="tns:ResPlanAnalyzerSoap">
    <soap12:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="Execute">
      <soap12:operation soapAction="WorkEnginePPM/Execute" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="ExecuteJSON">
      <soap12:operation soapAction="WorkEnginePPM/ExecuteJSON" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:service name="ResPlanAnalyzer">
    <wsdl:port name="ResPlanAnalyzerSoap" binding="tns:ResPlanAnalyzerSoap">
      <soap:address location="http://demo.epmlive.com/_layouts/ResPlanAnalyzer.asmx" />
    </wsdl:port>
    <wsdl:port name="ResPlanAnalyzerSoap12" binding="tns:ResPlanAnalyzerSoap12">
      <soap12:address location="http://demo.epmlive.com/_layouts/ResPlanAnalyzer.asmx" />
    </wsdl:port>
  </wsdl:service>
</wsdl:definitions>