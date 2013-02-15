
<%@ Page Language="C#" Inherits="System.Web.UI.Page" %> 
<%@ Assembly Name="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Import Namespace="Microsoft.SharePoint.Utilities" %> 
<%@ Import Namespace="Microsoft.SharePoint" %>
<% Response.ContentType = "text/xml"; %>

<wsdl:definitions xmlns:tm="http://microsoft.com/wsdl/mime/textMatching/" xmlns:s="http://www.w3.org/2001/XMLSchema" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" xmlns:http="http://schemas.xmlsoap.org/wsdl/http/" xmlns:tns="WorkEnginePPM" xmlns:mime="http://schemas.xmlsoap.org/wsdl/mime/" xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/" xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/" targetNamespace="WorkEnginePPM" xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">
  <wsdl:types>
    <s:schema elementFormDefault="qualified" targetNamespace="WorkEnginePPM">
      <s:element name="DoPingSession">
        <s:complexType />
      </s:element>
      <s:element name="DoPingSessionResponse">
        <s:complexType />
      </s:element>
      <s:element name="GetClientPrioritizationData">
        <s:complexType />
      </s:element>
      <s:element name="GetClientPrioritizationDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetClientPrioritizationDataResult" type="tns:PriGridData" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="PriGridData">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="NumCols" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="griddata" type="tns:ArrayOfPriRowData" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfPriRowData">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="PriRowData" nillable="true" type="tns:PriRowData" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="PriRowData">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="rowdata" type="tns:ArrayOfDouble" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfDouble">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="double" type="s:double" />
        </s:sequence>
      </s:complexType>
      <s:element name="SetClientPrioritizationData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="data" type="tns:PriGridData" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SetClientPrioritizationDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="SetClientPrioritizationDataResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetGridLayout">
        <s:complexType />
      </s:element>
      <s:element name="GetGridLayoutResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetGridLayoutResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetGridData">
        <s:complexType />
      </s:element>
      <s:element name="GetGridDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetGridDataResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
    </s:schema>
  </wsdl:types>
  <wsdl:message name="DoPingSessionSoapIn">
    <wsdl:part name="parameters" element="tns:DoPingSession" />
  </wsdl:message>
  <wsdl:message name="DoPingSessionSoapOut">
    <wsdl:part name="parameters" element="tns:DoPingSessionResponse" />
  </wsdl:message>
  <wsdl:message name="GetClientPrioritizationDataSoapIn">
    <wsdl:part name="parameters" element="tns:GetClientPrioritizationData" />
  </wsdl:message>
  <wsdl:message name="GetClientPrioritizationDataSoapOut">
    <wsdl:part name="parameters" element="tns:GetClientPrioritizationDataResponse" />
  </wsdl:message>
  <wsdl:message name="SetClientPrioritizationDataSoapIn">
    <wsdl:part name="parameters" element="tns:SetClientPrioritizationData" />
  </wsdl:message>
  <wsdl:message name="SetClientPrioritizationDataSoapOut">
    <wsdl:part name="parameters" element="tns:SetClientPrioritizationDataResponse" />
  </wsdl:message>
  <wsdl:message name="GetGridLayoutSoapIn">
    <wsdl:part name="parameters" element="tns:GetGridLayout" />
  </wsdl:message>
  <wsdl:message name="GetGridLayoutSoapOut">
    <wsdl:part name="parameters" element="tns:GetGridLayoutResponse" />
  </wsdl:message>
  <wsdl:message name="GetGridDataSoapIn">
    <wsdl:part name="parameters" element="tns:GetGridData" />
  </wsdl:message>
  <wsdl:message name="GetGridDataSoapOut">
    <wsdl:part name="parameters" element="tns:GetGridDataResponse" />
  </wsdl:message>
  <wsdl:portType name="ClientPrioritizationSoap">
    <wsdl:operation name="DoPingSession">
      <wsdl:input message="tns:DoPingSessionSoapIn" />
      <wsdl:output message="tns:DoPingSessionSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetClientPrioritizationData">
      <wsdl:input message="tns:GetClientPrioritizationDataSoapIn" />
      <wsdl:output message="tns:GetClientPrioritizationDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="SetClientPrioritizationData">
      <wsdl:input message="tns:SetClientPrioritizationDataSoapIn" />
      <wsdl:output message="tns:SetClientPrioritizationDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetGridLayout">
      <wsdl:input message="tns:GetGridLayoutSoapIn" />
      <wsdl:output message="tns:GetGridLayoutSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetGridData">
      <wsdl:input message="tns:GetGridDataSoapIn" />
      <wsdl:output message="tns:GetGridDataSoapOut" />
    </wsdl:operation>
  </wsdl:portType>
  <wsdl:binding name="ClientPrioritizationSoap" type="tns:ClientPrioritizationSoap">
    <soap:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="DoPingSession">
      <soap:operation soapAction="WorkEnginePPM/DoPingSession" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetClientPrioritizationData">
      <soap:operation soapAction="WorkEnginePPM/GetClientPrioritizationData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SetClientPrioritizationData">
      <soap:operation soapAction="WorkEnginePPM/SetClientPrioritizationData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetGridLayout">
      <soap:operation soapAction="WorkEnginePPM/GetGridLayout" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetGridData">
      <soap:operation soapAction="WorkEnginePPM/GetGridData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:binding name="ClientPrioritizationSoap12" type="tns:ClientPrioritizationSoap">
    <soap12:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="DoPingSession">
      <soap12:operation soapAction="WorkEnginePPM/DoPingSession" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetClientPrioritizationData">
      <soap12:operation soapAction="WorkEnginePPM/GetClientPrioritizationData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SetClientPrioritizationData">
      <soap12:operation soapAction="WorkEnginePPM/SetClientPrioritizationData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetGridLayout">
      <soap12:operation soapAction="WorkEnginePPM/GetGridLayout" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetGridData">
      <soap12:operation soapAction="WorkEnginePPM/GetGridData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:service name="ClientPrioritization">
    <wsdl:port name="ClientPrioritizationSoap" binding="tns:ClientPrioritizationSoap">
      <soap:address location=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(SPWeb.OriginalBaseUrl(Request)),Response.Output); %> />
    </wsdl:port>
    <wsdl:port name="ClientPrioritizationSoap12" binding="tns:ClientPrioritizationSoap12">
      <soap12:address location=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(SPWeb.OriginalBaseUrl(Request)),Response.Output); %> />
    </wsdl:port>
  </wsdl:service>
</wsdl:definitions>