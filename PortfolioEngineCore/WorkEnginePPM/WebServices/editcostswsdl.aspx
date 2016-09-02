
<%@ Page Language="C#" Inherits="System.Web.UI.Page" %> 
<%@ Assembly Name="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Import Namespace="Microsoft.SharePoint.Utilities" %> 
<%@ Import Namespace="Microsoft.SharePoint" %>
<% Response.ContentType = "text/xml"; %>

<wsdl:definitions xmlns:tm="http://microsoft.com/wsdl/mime/textMatching/" xmlns:s="http://www.w3.org/2001/XMLSchema" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" xmlns:http="http://schemas.xmlsoap.org/wsdl/http/" xmlns:tns="WorkEnginePPM" xmlns:mime="http://schemas.xmlsoap.org/wsdl/mime/" xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/" xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/" targetNamespace="WorkEnginePPM" xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">
  <wsdl:types>
    <s:schema elementFormDefault="qualified" targetNamespace="WorkEnginePPM">
      <s:element name="GetPIList">
        <s:complexType />
      </s:element>
      <s:element name="GetPIListResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetPIListResult" type="tns:ArrayOfPI" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfPI">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="PI" nillable="true" type="tns:PI" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="PI">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="Id" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
        </s:sequence>
      </s:complexType>
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
      <s:element name="GetViewList">
        <s:complexType />
      </s:element>
      <s:element name="GetViewListResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetViewListResult" type="tns:ArrayOfView" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfView">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="View" nillable="true" type="tns:View" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="View">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="Uid" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetCostTypes">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Viewuid" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetCostTypesResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetCostTypesResult" type="tns:ArrayOfCostType" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfCostType">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="CostType" nillable="true" type="tns:CostType" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="CostType">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="Id" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="EditMode" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="IncludeNamedRates" type="s:boolean" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetNamedRates">
        <s:complexType />
      </s:element>
      <s:element name="GetNamedRatesResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetNamedRatesResult" type="tns:ArrayOfNamedRateValue" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfNamedRateValue">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="NamedRateValue" nillable="true" type="tns:NamedRateValue" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="NamedRateValue">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="Id" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="EffectiveDate" type="s:dateTime" />
          <s:element minOccurs="1" maxOccurs="1" name="Rate" type="s:double" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetPeriods">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Viewuid" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetPeriodsResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetPeriodsResult" type="tns:ArrayOfPeriod" />
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
          <s:element minOccurs="1" maxOccurs="1" name="Id" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="StartDate" type="s:dateTime" />
          <s:element minOccurs="1" maxOccurs="1" name="FinishDate" type="s:dateTime" />
        </s:sequence>
      </s:complexType>
      <s:element name="CheckInPI">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="Projectid" type="s:int" />
            <s:element minOccurs="0" maxOccurs="1" name="Wepid" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CheckInPIResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="CheckInPIResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetEditCostsLayout">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="Projectid" type="s:int" />
            <s:element minOccurs="1" maxOccurs="1" name="Costtypeid" type="s:int" />
            <s:element minOccurs="0" maxOccurs="1" name="Viewuid" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="Ftemode" type="s:int" />
            <s:element minOccurs="0" maxOccurs="1" name="Wepid" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="Trycheckout" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetEditCostsLayoutResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetEditCostsLayoutResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetEditCostsData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="Projectid" type="s:int" />
            <s:element minOccurs="1" maxOccurs="1" name="Costtypeid" type="s:int" />
            <s:element minOccurs="0" maxOccurs="1" name="Viewuid" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="Ftemode" type="s:int" />
            <s:element minOccurs="0" maxOccurs="1" name="Wepid" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="Trycheckout" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetEditCostsDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetEditCostsDataResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SaveEditCostsData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="sData" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="Projectid" type="s:int" />
            <s:element minOccurs="1" maxOccurs="1" name="Costtypeid" type="s:int" />
            <s:element minOccurs="0" maxOccurs="1" name="Viewuid" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SaveEditCostsDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="SaveEditCostsDataResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
    </s:schema>
  </wsdl:types>
  <wsdl:message name="GetPIListSoapIn">
    <wsdl:part name="parameters" element="tns:GetPIList" />
  </wsdl:message>
  <wsdl:message name="GetPIListSoapOut">
    <wsdl:part name="parameters" element="tns:GetPIListResponse" />
  </wsdl:message>
  <wsdl:message name="CheckStatusSoapIn">
    <wsdl:part name="parameters" element="tns:CheckStatus" />
  </wsdl:message>
  <wsdl:message name="CheckStatusSoapOut">
    <wsdl:part name="parameters" element="tns:CheckStatusResponse" />
  </wsdl:message>
  <wsdl:message name="GetViewListSoapIn">
    <wsdl:part name="parameters" element="tns:GetViewList" />
  </wsdl:message>
  <wsdl:message name="GetViewListSoapOut">
    <wsdl:part name="parameters" element="tns:GetViewListResponse" />
  </wsdl:message>
  <wsdl:message name="GetCostTypesSoapIn">
    <wsdl:part name="parameters" element="tns:GetCostTypes" />
  </wsdl:message>
  <wsdl:message name="GetCostTypesSoapOut">
    <wsdl:part name="parameters" element="tns:GetCostTypesResponse" />
  </wsdl:message>
  <wsdl:message name="GetNamedRatesSoapIn">
    <wsdl:part name="parameters" element="tns:GetNamedRates" />
  </wsdl:message>
  <wsdl:message name="GetNamedRatesSoapOut">
    <wsdl:part name="parameters" element="tns:GetNamedRatesResponse" />
  </wsdl:message>
  <wsdl:message name="GetPeriodsSoapIn">
    <wsdl:part name="parameters" element="tns:GetPeriods" />
  </wsdl:message>
  <wsdl:message name="GetPeriodsSoapOut">
    <wsdl:part name="parameters" element="tns:GetPeriodsResponse" />
  </wsdl:message>
  <wsdl:message name="CheckInPISoapIn">
    <wsdl:part name="parameters" element="tns:CheckInPI" />
  </wsdl:message>
  <wsdl:message name="CheckInPISoapOut">
    <wsdl:part name="parameters" element="tns:CheckInPIResponse" />
  </wsdl:message>
  <wsdl:message name="GetEditCostsLayoutSoapIn">
    <wsdl:part name="parameters" element="tns:GetEditCostsLayout" />
  </wsdl:message>
  <wsdl:message name="GetEditCostsLayoutSoapOut">
    <wsdl:part name="parameters" element="tns:GetEditCostsLayoutResponse" />
  </wsdl:message>
  <wsdl:message name="GetEditCostsDataSoapIn">
    <wsdl:part name="parameters" element="tns:GetEditCostsData" />
  </wsdl:message>
  <wsdl:message name="GetEditCostsDataSoapOut">
    <wsdl:part name="parameters" element="tns:GetEditCostsDataResponse" />
  </wsdl:message>
  <wsdl:message name="SaveEditCostsDataSoapIn">
    <wsdl:part name="parameters" element="tns:SaveEditCostsData" />
  </wsdl:message>
  <wsdl:message name="SaveEditCostsDataSoapOut">
    <wsdl:part name="parameters" element="tns:SaveEditCostsDataResponse" />
  </wsdl:message>
  <wsdl:portType name="EditCostsSoap">
    <wsdl:operation name="GetPIList">
      <wsdl:input message="tns:GetPIListSoapIn" />
      <wsdl:output message="tns:GetPIListSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="CheckStatus">
      <wsdl:input message="tns:CheckStatusSoapIn" />
      <wsdl:output message="tns:CheckStatusSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetViewList">
      <wsdl:input message="tns:GetViewListSoapIn" />
      <wsdl:output message="tns:GetViewListSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetCostTypes">
      <wsdl:input message="tns:GetCostTypesSoapIn" />
      <wsdl:output message="tns:GetCostTypesSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetNamedRates">
      <wsdl:input message="tns:GetNamedRatesSoapIn" />
      <wsdl:output message="tns:GetNamedRatesSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetPeriods">
      <wsdl:input message="tns:GetPeriodsSoapIn" />
      <wsdl:output message="tns:GetPeriodsSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetEditCostsLayout">
      <wsdl:input message="tns:GetEditCostsLayoutSoapIn" />
      <wsdl:output message="tns:GetEditCostsLayoutSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="CheckInPI">
      <wsdl:input message="tns:CheckInPISoapIn" />
      <wsdl:output message="tns:CheckInPISoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetEditCostsData">
      <wsdl:input message="tns:GetEditCostsDataSoapIn" />
      <wsdl:output message="tns:GetEditCostsDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="SaveEditCostsData">
      <wsdl:input message="tns:SaveEditCostsDataSoapIn" />
      <wsdl:output message="tns:SaveEditCostsDataSoapOut" />
    </wsdl:operation>
  </wsdl:portType>
  <wsdl:binding name="EditCostsSoap" type="tns:EditCostsSoap">
    <soap:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="GetPIList">
      <soap:operation soapAction="WorkEnginePPM/GetPIList" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CheckStatus">
      <soap:operation soapAction="WorkEnginePPM/CheckStatus" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetViewList">
      <soap:operation soapAction="WorkEnginePPM/GetViewList" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetCostTypes">
      <soap:operation soapAction="WorkEnginePPM/GetCostTypes" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetNamedRates">
      <soap:operation soapAction="WorkEnginePPM/GetNamedRates" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetPeriods">
      <soap:operation soapAction="WorkEnginePPM/GetPeriods" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CheckInPI">
      <soap:operation soapAction="WorkEnginePPM/CheckInPI" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetEditCostsLayout">
      <soap:operation soapAction="WorkEnginePPM/GetEditCostsLayout" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetEditCostsData">
      <soap:operation soapAction="WorkEnginePPM/GetEditCostsData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SaveEditCostsData">
      <soap:operation soapAction="WorkEnginePPM/SaveEditCostsData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:binding name="EditCostsSoap12" type="tns:EditCostsSoap">
    <soap12:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="GetPIList">
      <soap12:operation soapAction="WorkEnginePPM/GetPIList" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CheckStatus">
      <soap12:operation soapAction="WorkEnginePPM/CheckStatus" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetViewList">
      <soap12:operation soapAction="WorkEnginePPM/GetViewList" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetCostTypes">
      <soap12:operation soapAction="WorkEnginePPM/GetCostTypes" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetNamedRates">
      <soap12:operation soapAction="WorkEnginePPM/GetNamedRates" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetPeriods">
      <soap12:operation soapAction="WorkEnginePPM/GetPeriods" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CheckInPI">
      <soap12:operation soapAction="WorkEnginePPM/CheckInPI" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetEditCostsLayout">
      <soap12:operation soapAction="WorkEnginePPM/GetEditCostsLayout" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetEditCostsData">
      <soap12:operation soapAction="WorkEnginePPM/GetEditCostsData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SaveEditCostsData">
      <soap12:operation soapAction="WorkEnginePPM/SaveEditCostsData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:service name="EditCosts">
    <wsdl:port name="EditCostsSoap" binding="tns:EditCostsSoap">
      <soap:address location=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(SPWeb.OriginalBaseUrl(Request)),Response.Output); %> />
    </wsdl:port>
    <wsdl:port name="EditCostsSoap12" binding="tns:EditCostsSoap12">
      <soap12:address location=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(SPWeb.OriginalBaseUrl(Request)),Response.Output); %> />
    </wsdl:port>
  </wsdl:service>
</wsdl:definitions>