<%@ Page Language="C#" Inherits="System.Web.UI.Page" %> 
<%@ Assembly Name="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Import Namespace="Microsoft.SharePoint.Utilities" %> 
<%@ Import Namespace="Microsoft.SharePoint" %>
<% Response.ContentType = "text/xml"; %>

<wsdl:definitions xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/" xmlns:tm="http://microsoft.com/wsdl/mime/textMatching/" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" xmlns:mime="http://schemas.xmlsoap.org/wsdl/mime/" xmlns:tns="http://epmlive.com/" xmlns:s1="http://microsoft.com/wsdl/types/" xmlns:s="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/" xmlns:http="http://schemas.xmlsoap.org/wsdl/http/" targetNamespace="http://epmlive.com/" xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">
    <wsdl:types>
    <s:schema elementFormDefault="qualified" targetNamespace="http://epmlive.com/">
      <s:element name="getConfigSetting">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="setting" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getConfigSettingResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="getConfigSettingResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="saveTimePhasedData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="sUrl" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sProject" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sData" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="saveTimePhasedDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="saveTimePhasedDataResult" type="s:boolean" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getAllValueTypes">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="sUrl" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getAllValueTypesResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="getAllValueTypesResult" type="tns:ArrayOfString" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfString">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="string" nillable="true" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="getAllTimePeriods">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="sUrl" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getAllTimePeriodsResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="getAllTimePeriodsResult" type="tns:ArrayOfPeriod" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfPeriod">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="Period" nillable="true" type="tns:Period" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="Period">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="name" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="start" type="s:dateTime" />
          <s:element minOccurs="1" maxOccurs="1" name="end" type="s:dateTime" />
        </s:sequence>
      </s:complexType>
      <s:element name="getPublisherSettings">
        <s:complexType />
      </s:element>
      <s:element name="getPublisherSettingsResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="getPublisherSettingsResult" type="tns:ArrayOfString" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="canPublishToSite">
        <s:complexType />
      </s:element>
      <s:element name="canPublishToSiteResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="canPublishToSiteResult" type="s:boolean" />
          </s:sequence>
        </s:complexType>
      </s:element>
    </s:schema>
  </wsdl:types>
  <wsdl:message name="getConfigSettingSoapIn">
    <wsdl:part name="parameters" element="tns:getConfigSetting" />
  </wsdl:message>
  <wsdl:message name="getConfigSettingSoapOut">
    <wsdl:part name="parameters" element="tns:getConfigSettingResponse" />
  </wsdl:message>
  <wsdl:message name="saveTimePhasedDataSoapIn">
    <wsdl:part name="parameters" element="tns:saveTimePhasedData" />
  </wsdl:message>
  <wsdl:message name="saveTimePhasedDataSoapOut">
    <wsdl:part name="parameters" element="tns:saveTimePhasedDataResponse" />
  </wsdl:message>
  <wsdl:message name="getAllValueTypesSoapIn">
    <wsdl:part name="parameters" element="tns:getAllValueTypes" />
  </wsdl:message>
  <wsdl:message name="getAllValueTypesSoapOut">
    <wsdl:part name="parameters" element="tns:getAllValueTypesResponse" />
  </wsdl:message>
  <wsdl:message name="getAllTimePeriodsSoapIn">
    <wsdl:part name="parameters" element="tns:getAllTimePeriods" />
  </wsdl:message>
  <wsdl:message name="getAllTimePeriodsSoapOut">
    <wsdl:part name="parameters" element="tns:getAllTimePeriodsResponse" />
  </wsdl:message>
  <wsdl:message name="getPublisherSettingsSoapIn">
    <wsdl:part name="parameters" element="tns:getPublisherSettings" />
  </wsdl:message>
  <wsdl:message name="getPublisherSettingsSoapOut">
    <wsdl:part name="parameters" element="tns:getPublisherSettingsResponse" />
  </wsdl:message>
  <wsdl:message name="canPublishToSiteSoapIn">
    <wsdl:part name="parameters" element="tns:canPublishToSite" />
  </wsdl:message>
  <wsdl:message name="canPublishToSiteSoapOut">
    <wsdl:part name="parameters" element="tns:canPublishToSiteResponse" />
  </wsdl:message>
  <wsdl:portType name="EPMLiveTimePhasedSoap">
    <wsdl:operation name="getConfigSetting">
      <wsdl:input message="tns:getConfigSettingSoapIn" />
      <wsdl:output message="tns:getConfigSettingSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="saveTimePhasedData">
      <wsdl:input message="tns:saveTimePhasedDataSoapIn" />
      <wsdl:output message="tns:saveTimePhasedDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="getAllValueTypes">
      <wsdl:input message="tns:getAllValueTypesSoapIn" />
      <wsdl:output message="tns:getAllValueTypesSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="getAllTimePeriods">
      <wsdl:input message="tns:getAllTimePeriodsSoapIn" />
      <wsdl:output message="tns:getAllTimePeriodsSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="getPublisherSettings">
      <wsdl:input message="tns:getPublisherSettingsSoapIn" />
      <wsdl:output message="tns:getPublisherSettingsSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="canPublishToSite">
      <wsdl:input message="tns:canPublishToSiteSoapIn" />
      <wsdl:output message="tns:canPublishToSiteSoapOut" />
    </wsdl:operation>
  </wsdl:portType>
  <wsdl:binding name="EPMLiveTimePhasedSoap" type="tns:EPMLiveTimePhasedSoap">
    <soap:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="getConfigSetting">
      <soap:operation soapAction="http://epmlive.com/getConfigSetting" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="saveTimePhasedData">
      <soap:operation soapAction="http://epmlive.com/saveTimePhasedData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getAllValueTypes">
      <soap:operation soapAction="http://epmlive.com/getAllValueTypes" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getAllTimePeriods">
      <soap:operation soapAction="http://epmlive.com/getAllTimePeriods" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getPublisherSettings">
      <soap:operation soapAction="http://epmlive.com/getPublisherSettings" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="canPublishToSite">
      <soap:operation soapAction="http://epmlive.com/canPublishToSite" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:binding name="EPMLiveTimePhasedSoap12" type="tns:EPMLiveTimePhasedSoap">
    <soap12:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="getConfigSetting">
      <soap12:operation soapAction="http://epmlive.com/getConfigSetting" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="saveTimePhasedData">
      <soap12:operation soapAction="http://epmlive.com/saveTimePhasedData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getAllValueTypes">
      <soap12:operation soapAction="http://epmlive.com/getAllValueTypes" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getAllTimePeriods">
      <soap12:operation soapAction="http://epmlive.com/getAllTimePeriods" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getPublisherSettings">
      <soap12:operation soapAction="http://epmlive.com/getPublisherSettings" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="canPublishToSite">
      <soap12:operation soapAction="http://epmlive.com/canPublishToSite" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:service name="EPMLiveTimePhased">
    <wsdl:port name="EPMLiveTimePhasedSoap" binding="tns:EPMLiveTimePhasedSoap">
	<soap:address location=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(SPWeb.OriginalBaseUrl(Request)),Response.Output); %> />
    </wsdl:port>
    <wsdl:port name="EPMLiveTimePhasedSoap12" binding="tns:EPMLiveTimePhasedSoap12">
	<soap12:address location=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(SPWeb.OriginalBaseUrl(Request)),Response.Output); %> />
    </wsdl:port>
  </wsdl:service>
</wsdl:definitions>