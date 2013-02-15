
<%@ Page Language="C#" Inherits="System.Web.UI.Page" %> 
<%@ Assembly Name="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Import Namespace="Microsoft.SharePoint.Utilities" %> 
<%@ Import Namespace="Microsoft.SharePoint" %>
<% Response.ContentType = "text/xml"; %>

<wsdl:definitions xmlns:tm="http://microsoft.com/wsdl/mime/textMatching/" xmlns:s="http://www.w3.org/2001/XMLSchema" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" xmlns:http="http://schemas.xmlsoap.org/wsdl/http/" xmlns:tns="PPM.Services" xmlns:mime="http://schemas.xmlsoap.org/wsdl/mime/" xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/" xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/" targetNamespace="PPM.Services" xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">
  <wsdl:types>
    <s:schema elementFormDefault="qualified" targetNamespace="PPM.Services">
      <s:element name="BeginSession">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="sUserName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sPassword" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sNTAuth" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="BeginSessionResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="BeginSessionResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="BeginSessionEx">
        <s:complexType />
      </s:element>
      <s:element name="BeginSessionExResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="BeginSessionExResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="EndSession">
        <s:complexType />
      </s:element>
      <s:element name="EndSessionResponse">
        <s:complexType />
      </s:element>
      <s:element name="XMLRequest">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="sContext" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sRequest" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="XMLRequestResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="XMLRequestResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SessionInfo">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="sItem" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SessionInfoResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="SessionInfoResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
    </s:schema>
  </wsdl:types>
  <wsdl:message name="BeginSessionSoapIn">
    <wsdl:part name="parameters" element="tns:BeginSession" />
  </wsdl:message>
  <wsdl:message name="BeginSessionSoapOut">
    <wsdl:part name="parameters" element="tns:BeginSessionResponse" />
  </wsdl:message>
  <wsdl:message name="BeginSessionExSoapIn">
    <wsdl:part name="parameters" element="tns:BeginSessionEx" />
  </wsdl:message>
  <wsdl:message name="BeginSessionExSoapOut">
    <wsdl:part name="parameters" element="tns:BeginSessionExResponse" />
  </wsdl:message>
  <wsdl:message name="EndSessionSoapIn">
    <wsdl:part name="parameters" element="tns:EndSession" />
  </wsdl:message>
  <wsdl:message name="EndSessionSoapOut">
    <wsdl:part name="parameters" element="tns:EndSessionResponse" />
  </wsdl:message>
  <wsdl:message name="XMLRequestSoapIn">
    <wsdl:part name="parameters" element="tns:XMLRequest" />
  </wsdl:message>
  <wsdl:message name="XMLRequestSoapOut">
    <wsdl:part name="parameters" element="tns:XMLRequestResponse" />
  </wsdl:message>
  <wsdl:message name="SessionInfoSoapIn">
    <wsdl:part name="parameters" element="tns:SessionInfo" />
  </wsdl:message>
  <wsdl:message name="SessionInfoSoapOut">
    <wsdl:part name="parameters" element="tns:SessionInfoResponse" />
  </wsdl:message>
  <wsdl:portType name="WebServiceSoap">
    <wsdl:operation name="BeginSession">
      <wsdl:input message="tns:BeginSessionSoapIn" />
      <wsdl:output message="tns:BeginSessionSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="BeginSessionEx">
      <wsdl:input message="tns:BeginSessionExSoapIn" />
      <wsdl:output message="tns:BeginSessionExSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="EndSession">
      <wsdl:input message="tns:EndSessionSoapIn" />
      <wsdl:output message="tns:EndSessionSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="XMLRequest">
      <wsdl:input message="tns:XMLRequestSoapIn" />
      <wsdl:output message="tns:XMLRequestSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="SessionInfo">
      <wsdl:input message="tns:SessionInfoSoapIn" />
      <wsdl:output message="tns:SessionInfoSoapOut" />
    </wsdl:operation>
  </wsdl:portType>
  <wsdl:binding name="WebServiceSoap" type="tns:WebServiceSoap">
    <soap:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="BeginSession">
      <soap:operation soapAction="PPM.Services/BeginSession" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="BeginSessionEx">
      <soap:operation soapAction="PPM.Services/BeginSessionEx" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="EndSession">
      <soap:operation soapAction="PPM.Services/EndSession" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="XMLRequest">
      <soap:operation soapAction="PPM.Services/XMLRequest" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SessionInfo">
      <soap:operation soapAction="PPM.Services/SessionInfo" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:binding name="WebServiceSoap12" type="tns:WebServiceSoap">
    <soap12:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="BeginSession">
      <soap12:operation soapAction="PPM.Services/BeginSession" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="BeginSessionEx">
      <soap12:operation soapAction="PPM.Services/BeginSessionEx" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="EndSession">
      <soap12:operation soapAction="PPM.Services/EndSession" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="XMLRequest">
      <soap12:operation soapAction="PPM.Services/XMLRequest" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SessionInfo">
      <soap12:operation soapAction="PPM.Services/SessionInfo" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:service name="WebService">
    <wsdl:port name="WebServiceSoap" binding="tns:WebServiceSoap">
      <soap:address location="http://demo.epmlive.com/_layouts/webservice.asmx" />
    </wsdl:port>
    <wsdl:port name="WebServiceSoap12" binding="tns:WebServiceSoap12">
      <soap12:address location="http://demo.epmlive.com/_layouts/webservice.asmx" />
    </wsdl:port>
  </wsdl:service>
</wsdl:definitions>