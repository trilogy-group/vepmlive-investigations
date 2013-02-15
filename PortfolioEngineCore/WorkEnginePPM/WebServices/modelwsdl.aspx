<%@ Page Language="C#" Inherits="System.Web.UI.Page" %> 
<%@ Assembly Name="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Import Namespace="Microsoft.SharePoint.Utilities" %> 
<%@ Import Namespace="Microsoft.SharePoint" %>
<% Response.ContentType = "text/xml"; %>

<wsdl:definitions xmlns:tm="http://microsoft.com/wsdl/mime/textMatching/" xmlns:s="http://www.w3.org/2001/XMLSchema" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" xmlns:http="http://schemas.xmlsoap.org/wsdl/http/" xmlns:tns="WorkEnginePPM" xmlns:mime="http://schemas.xmlsoap.org/wsdl/mime/" xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/" xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/" targetNamespace="WorkEnginePPM" xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">
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
      <s:element name="LoadModelData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="sTicket" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sModel" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sVersions" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sViewID" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LoadModelDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="LoadModelDataResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DoTopGridCheck">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="Row" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DoTopGridCheckResponse">
        <s:complexType />
      </s:element>
      <s:element name="DoBarMoved">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="Row" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sStart" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sFinish" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DoBarMovedResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="DoBarMovedResult" type="tns:ModelBarsChanged" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ModelBarsChanged">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="barsAffected" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="RowID" type="tns:ArrayOfInt" />
          <s:element minOccurs="0" maxOccurs="1" name="Starts" type="tns:ArrayOfString" />
          <s:element minOccurs="0" maxOccurs="1" name="Finishs" type="tns:ArrayOfString" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfInt">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="int" type="s:int" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfString">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="string" nillable="true" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="DoCopyVersion">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sFrom" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sTo" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sPIs" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DoCopyVersionResponse">
        <s:complexType />
      </s:element>
      <s:element name="DoLoadVersion">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sLoad" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DoLoadVersionResponse">
        <s:complexType />
      </s:element>
      <s:element name="DoLoadTarget">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sTarget" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DoLoadTargetResponse">
        <s:complexType />
      </s:element>
      <s:element name="GetTopGridLayout">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetTopGridLayoutResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetTopGridLayoutResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetTopGridData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetTopGridDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetTopGridDataResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetBottomGridLayout">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetBottomGridLayoutResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetBottomGridLayoutResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetBottomGridData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetBottomGridDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetBottomGridDataResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DoShowFTEs">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="FTEMode" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DoShowFTEsResponse">
        <s:complexType />
      </s:element>
      <s:element name="DoPingSession">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DoPingSessionResponse">
        <s:complexType />
      </s:element>
      <s:element name="DoShowGantt">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="GanttMode" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DoShowGanttResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="DoShowGanttResult" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DoSetGroupingFlag">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="GroupMode" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DoSetGroupingFlagResponse">
        <s:complexType />
      </s:element>
      <s:element name="GetModels">
        <s:complexType />
      </s:element>
      <s:element name="GetModelsResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetModelsResult" type="tns:ArrayOfItemDefn" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfItemDefn">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="ItemDefn" nillable="true" type="tns:ItemDefn" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ItemDefn">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="Id" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="Deflt" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="editable" type="s:int" />
        </s:sequence>
      </s:complexType>
      <s:element name="LoadSelectVersions">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="modelID" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LoadSelectVersionsResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="LoadSelectVersionsResult" type="tns:ArrayOfItemDefn" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetFilterGridLayout">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetFilterGridLayoutResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetFilterGridLayoutResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetFilterGridData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetFilterGridDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetFilterGridDataResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SetFilterData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sfilterData" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SetFilterDataResponse">
        <s:complexType />
      </s:element>
      <s:element name="GetTotalGridLayout">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetTotalGridLayoutResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetTotalGridLayoutResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetTotalGridData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetTotalGridDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetTotalGridDataResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetCostTypeCompareGridData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetCostTypeCompareGridDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetCostTypeCompareGridDataResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SetCostTypeCompareData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sCTCmpData" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SetCostTypeCompareDataResponse">
        <s:complexType />
      </s:element>
      <s:element name="GetColumnGridData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetColumnGridDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetColumnGridDataResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SetTotalData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sTotalData" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SetTotalDataResponse">
        <s:complexType />
      </s:element>
      <s:element name="GetSortAndGroup">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetSortAndGroupResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetSortAndGroupResult" type="tns:SortGroupDefn" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="SortGroupDefn">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="DetRows" type="tns:ArrayOfSortRowDefn" />
          <s:element minOccurs="0" maxOccurs="1" name="TotRows" type="tns:ArrayOfSortRowDefn" />
          <s:element minOccurs="0" maxOccurs="1" name="DetFields" type="tns:ArrayOfSortFieldDefn" />
          <s:element minOccurs="0" maxOccurs="1" name="TotFields" type="tns:ArrayOfSortFieldDefn" />
          <s:element minOccurs="1" maxOccurs="1" name="DetFreeze" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="TotFreeze" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="DetShowToLevel" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="TotShowToLevel" type="s:int" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfSortRowDefn">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="SortRowDefn" nillable="true" type="tns:SortRowDefn" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="SortRowDefn">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="fid" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="decf" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="grpf" type="s:int" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfSortFieldDefn">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="SortFieldDefn" nillable="true" type="tns:SortFieldDefn" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="SortFieldDefn">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="fid" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="name" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="selected" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="touched" type="s:boolean" />
        </s:sequence>
      </s:complexType>
      <s:element name="SetSortAndGroup">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="SnG" type="tns:SortGroupDefn" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SetSortAndGroupResponse">
        <s:complexType />
      </s:element>
      <s:element name="GetColumnOrderData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetColumnOrderDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetColumnOrderDataResult" type="tns:SortGroupDefn" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SetColumnOrder">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="SnG" type="tns:SortGroupDefn" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SetColumnOrderResponse">
        <s:complexType />
      </s:element>
      <s:element name="LoadCopyVersionPILists">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="fromVer" type="s:int" />
            <s:element minOccurs="1" maxOccurs="1" name="toVer" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LoadCopyVersionPIListsResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="LoadCopyVersionPIListsResult" type="tns:SortGroupDefn" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetSaveVersions">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetSaveVersionsResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetSaveVersionsResult" type="tns:ArrayOfItemDefn" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetTargetList">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetTargetListResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetTargetListResult" type="tns:ArrayOfItemDefn" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DoSaveVersion">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sVersion" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DoSaveVersionResponse">
        <s:complexType />
      </s:element>
      <s:element name="GetPeriodsandDisplay">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetPeriodsandDisplayResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetPeriodsandDisplayResult" type="tns:PeriodsAndOptions" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="PeriodsAndOptions">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="Periods" type="tns:ArrayOfItemDefn" />
          <s:element minOccurs="1" maxOccurs="1" name="displayStart" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="displayFinish" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="dragStart" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="dragFinish" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="showQTY" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="showWhichQTY" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="showCosts" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="showRHSDecCosts" type="s:int" />
        </s:sequence>
      </s:complexType>
      <s:element name="SetPeriodsandDisplay">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="poa" type="tns:PeriodsAndOptions" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SetPeriodsandDisplayResponse">
        <s:complexType />
      </s:element>
      <s:element name="DoDeleteTarget">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sTarget" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DoDeleteTargetResponse">
        <s:complexType />
      </s:element>
      <s:element name="CreateTarget">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sTargetName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sTargetDesc" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="localTarget" type="s:int" />
            <s:element minOccurs="1" maxOccurs="1" name="lCopyfromTarget" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="CreateTargetResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="CreateTargetResult" type="tns:ItemDefn" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetClientSideCalcData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetClientSideCalcDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetClientSideCalcDataResult" type="tns:CSRatesAndCategory" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="CSRatesAndCategory">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="numberPeriods" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="NamedRates" type="tns:ArrayOfCSNamedRate" />
          <s:element minOccurs="0" maxOccurs="1" name="Categories" type="tns:ArrayOfCSCategoryEntry" />
          <s:element minOccurs="0" maxOccurs="1" name="CatjsonMenu" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Versions" type="tns:ArrayOfItemDefn" />
          <s:element minOccurs="0" maxOccurs="1" name="CostTypes" type="tns:ArrayOfItemDefn" />
          <s:element minOccurs="0" maxOccurs="1" name="CustomFields" type="tns:ArrayOfCustomFieldsDefn" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfCSNamedRate">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="CSNamedRate" nillable="true" type="tns:CSNamedRate" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="CSNamedRate">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="UID" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="ID" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="Level" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Rates" type="tns:ArrayOfDouble" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfDouble">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="double" type="s:double" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfCSCategoryEntry">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="CSCategoryEntry" nillable="true" type="tns:CSCategoryEntry" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="CSCategoryEntry">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="UID" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="ID" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="Level" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="Role_UID" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="Mode" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="PID" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="MC_UID" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="Category" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="UoM" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="FullName" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="MC_Val" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Role_Name" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Rates" type="tns:ArrayOfDouble" />
          <s:element minOccurs="0" maxOccurs="1" name="FTEConv" type="tns:ArrayOfDouble" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfCustomFieldsDefn">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="CustomFieldsDefn" nillable="true" type="tns:CustomFieldsDefn" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="CustomFieldsDefn">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="FieldID" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="LookupOnly" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="LookupID" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="LeafOnly" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="UseFullName" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="LookUp" type="tns:ArrayOfListItemData" />
          <s:element minOccurs="0" maxOccurs="1" name="jsonMenu" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfListItemData">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="ListItemData" nillable="true" type="tns:ListItemData" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ListItemData">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="UID" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="ID" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="Level" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="FullName" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="InActive" type="s:boolean" />
        </s:sequence>
      </s:complexType>
      <s:element name="PrepareTargetData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="targetID" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="PrepareTargetDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="PrepareTargetDataResult" type="tns:CSTargetData" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="CSTargetData">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="targetRows" type="tns:ArrayOfTargetRowData" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfTargetRowData">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="TargetRowData" nillable="true" type="tns:TargetRowData" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="TargetRowData">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="CT_ID" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="BC_UID" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="BC_ROLE_UID" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="BC_SEQ" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="MC_Val" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="CAT_UID" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="CT_Name" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Cat_Name" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Role_Name" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="MC_Name" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="FullCatName" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="CC_Name" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="FullCCName" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Grouping" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="bGroupRow" type="s:boolean" />
          <s:element minOccurs="1" maxOccurs="1" name="m_rt" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="m_rt_name" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="sUoM" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="zCost" type="tns:ArrayOfDouble" />
          <s:element minOccurs="0" maxOccurs="1" name="zValue" type="tns:ArrayOfDouble" />
          <s:element minOccurs="0" maxOccurs="1" name="zFTE" type="tns:ArrayOfDouble" />
          <s:element minOccurs="0" maxOccurs="1" name="OCVal" type="tns:ArrayOfInt" />
          <s:element minOccurs="0" maxOccurs="1" name="Text_OCVal" type="tns:ArrayOfString" />
          <s:element minOccurs="0" maxOccurs="1" name="TXVal" type="tns:ArrayOfString" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetTargetGridLayout">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetTargetGridLayoutResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetTargetGridLayoutResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetTargetGridData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetTargetGridDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetTargetGridDataResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="ReturnVersionAsTarget">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="VersID" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="ReturnVersionAsTargetResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ReturnVersionAsTargetResult" type="tns:CSTargetData" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SaveTargetData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="TargetID" type="s:int" />
            <s:element minOccurs="0" maxOccurs="1" name="targetData" type="tns:CSTargetData" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SaveTargetDataResponse">
        <s:complexType />
      </s:element>
      <s:element name="GetCostViews">
        <s:complexType />
      </s:element>
      <s:element name="GetCostViewsResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetCostViewsResult" type="tns:ArrayOfItemDefn" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DoShowRemTotal">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="showRemFlag" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DoShowRemTotalResponse">
        <s:complexType />
      </s:element>
      <s:element name="GetLegendGridLayout">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetLegendGridLayoutResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetLegendGridLayoutResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetLegendGridData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetLegendGridDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetLegendGridDataResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LoadUserViewData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LoadUserViewDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="LoadUserViewDataResult" type="tns:ArrayOfItemDefn" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DeleteUserViewData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sviewName" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="localflag" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DeleteUserViewDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="DeleteUserViewDataResult" type="tns:ArrayOfItemDefn" />
          </s:sequence>
        </s:complexType>
      </s:element>
     <s:element name="RenameUserViewData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="snewName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sviewName" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="localflag" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="RenameUserViewDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="RenameUserViewDataResult" type="tns:ArrayOfItemDefn" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SaveUserViewData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="sviewName" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="localflag" type="s:int" />
            <s:element minOccurs="0" maxOccurs="1" name="sZoomTo" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SaveUserViewDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="SaveUserViewDataResult" type="tns:ArrayOfItemDefn" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SelectUserViewData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
            <s:element minOccurs="1" maxOccurs="1" name="viewIndex" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="SelectUserViewDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="SelectUserViewDataResult" type="tns:SortGroupDefn" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetCompareStringValue">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Ticket" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetCompareStringValueResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetCompareStringValueResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
    </s:schema>
  </wsdl:types>
  <wsdl:message name="LoadModelDataSoapIn">
    <wsdl:part name="parameters" element="tns:LoadModelData" />
  </wsdl:message>
  <wsdl:message name="LoadModelDataSoapOut">
    <wsdl:part name="parameters" element="tns:LoadModelDataResponse" />
  </wsdl:message>
  <wsdl:message name="DoTopGridCheckSoapIn">
    <wsdl:part name="parameters" element="tns:DoTopGridCheck" />
  </wsdl:message>
  <wsdl:message name="DoTopGridCheckSoapOut">
    <wsdl:part name="parameters" element="tns:DoTopGridCheckResponse" />
  </wsdl:message>
  <wsdl:message name="DoBarMovedSoapIn">
    <wsdl:part name="parameters" element="tns:DoBarMoved" />
  </wsdl:message>
  <wsdl:message name="DoBarMovedSoapOut">
    <wsdl:part name="parameters" element="tns:DoBarMovedResponse" />
  </wsdl:message>
  <wsdl:message name="DoCopyVersionSoapIn">
    <wsdl:part name="parameters" element="tns:DoCopyVersion" />
  </wsdl:message>
  <wsdl:message name="DoCopyVersionSoapOut">
    <wsdl:part name="parameters" element="tns:DoCopyVersionResponse" />
  </wsdl:message>
  <wsdl:message name="DoLoadVersionSoapIn">
    <wsdl:part name="parameters" element="tns:DoLoadVersion" />
  </wsdl:message>
  <wsdl:message name="DoLoadVersionSoapOut">
    <wsdl:part name="parameters" element="tns:DoLoadVersionResponse" />
  </wsdl:message>
  <wsdl:message name="DoLoadTargetSoapIn">
    <wsdl:part name="parameters" element="tns:DoLoadTarget" />
  </wsdl:message>
  <wsdl:message name="DoLoadTargetSoapOut">
    <wsdl:part name="parameters" element="tns:DoLoadTargetResponse" />
  </wsdl:message>
  <wsdl:message name="GetTopGridLayoutSoapIn">
    <wsdl:part name="parameters" element="tns:GetTopGridLayout" />
  </wsdl:message>
  <wsdl:message name="GetTopGridLayoutSoapOut">
    <wsdl:part name="parameters" element="tns:GetTopGridLayoutResponse" />
  </wsdl:message>
  <wsdl:message name="GetTopGridDataSoapIn">
    <wsdl:part name="parameters" element="tns:GetTopGridData" />
  </wsdl:message>
  <wsdl:message name="GetTopGridDataSoapOut">
    <wsdl:part name="parameters" element="tns:GetTopGridDataResponse" />
  </wsdl:message>
  <wsdl:message name="GetBottomGridLayoutSoapIn">
    <wsdl:part name="parameters" element="tns:GetBottomGridLayout" />
  </wsdl:message>
  <wsdl:message name="GetBottomGridLayoutSoapOut">
    <wsdl:part name="parameters" element="tns:GetBottomGridLayoutResponse" />
  </wsdl:message>
  <wsdl:message name="GetBottomGridDataSoapIn">
    <wsdl:part name="parameters" element="tns:GetBottomGridData" />
  </wsdl:message>
  <wsdl:message name="GetBottomGridDataSoapOut">
    <wsdl:part name="parameters" element="tns:GetBottomGridDataResponse" />
  </wsdl:message>
  <wsdl:message name="DoShowFTEsSoapIn">
    <wsdl:part name="parameters" element="tns:DoShowFTEs" />
  </wsdl:message>
  <wsdl:message name="DoShowFTEsSoapOut">
    <wsdl:part name="parameters" element="tns:DoShowFTEsResponse" />
  </wsdl:message>
  <wsdl:message name="DoPingSessionSoapIn">
    <wsdl:part name="parameters" element="tns:DoPingSession" />
  </wsdl:message>
  <wsdl:message name="DoPingSessionSoapOut">
    <wsdl:part name="parameters" element="tns:DoPingSessionResponse" />
  </wsdl:message>
  <wsdl:message name="DoShowGanttSoapIn">
    <wsdl:part name="parameters" element="tns:DoShowGantt" />
  </wsdl:message>
  <wsdl:message name="DoShowGanttSoapOut">
    <wsdl:part name="parameters" element="tns:DoShowGanttResponse" />
  </wsdl:message>
  <wsdl:message name="DoSetGroupingFlagSoapIn">
    <wsdl:part name="parameters" element="tns:DoSetGroupingFlag" />
  </wsdl:message>
  <wsdl:message name="DoSetGroupingFlagSoapOut">
    <wsdl:part name="parameters" element="tns:DoSetGroupingFlagResponse" />
  </wsdl:message>
  <wsdl:message name="GetModelsSoapIn">
    <wsdl:part name="parameters" element="tns:GetModels" />
  </wsdl:message>
  <wsdl:message name="GetModelsSoapOut">
    <wsdl:part name="parameters" element="tns:GetModelsResponse" />
  </wsdl:message>
  <wsdl:message name="LoadSelectVersionsSoapIn">
    <wsdl:part name="parameters" element="tns:LoadSelectVersions" />
  </wsdl:message>
  <wsdl:message name="LoadSelectVersionsSoapOut">
    <wsdl:part name="parameters" element="tns:LoadSelectVersionsResponse" />
  </wsdl:message>
  <wsdl:message name="GetFilterGridLayoutSoapIn">
    <wsdl:part name="parameters" element="tns:GetFilterGridLayout" />
  </wsdl:message>
  <wsdl:message name="GetFilterGridLayoutSoapOut">
    <wsdl:part name="parameters" element="tns:GetFilterGridLayoutResponse" />
  </wsdl:message>
  <wsdl:message name="GetFilterGridDataSoapIn">
    <wsdl:part name="parameters" element="tns:GetFilterGridData" />
  </wsdl:message>
  <wsdl:message name="GetFilterGridDataSoapOut">
    <wsdl:part name="parameters" element="tns:GetFilterGridDataResponse" />
  </wsdl:message>
  <wsdl:message name="SetFilterDataSoapIn">
    <wsdl:part name="parameters" element="tns:SetFilterData" />
  </wsdl:message>
  <wsdl:message name="SetFilterDataSoapOut">
    <wsdl:part name="parameters" element="tns:SetFilterDataResponse" />
  </wsdl:message>
  <wsdl:message name="GetTotalGridLayoutSoapIn">
    <wsdl:part name="parameters" element="tns:GetTotalGridLayout" />
  </wsdl:message>
  <wsdl:message name="GetTotalGridLayoutSoapOut">
    <wsdl:part name="parameters" element="tns:GetTotalGridLayoutResponse" />
  </wsdl:message>
  <wsdl:message name="GetTotalGridDataSoapIn">
    <wsdl:part name="parameters" element="tns:GetTotalGridData" />
  </wsdl:message>
  <wsdl:message name="GetTotalGridDataSoapOut">
    <wsdl:part name="parameters" element="tns:GetTotalGridDataResponse" />
  </wsdl:message>
  <wsdl:message name="GetCostTypeCompareGridDataSoapIn">
    <wsdl:part name="parameters" element="tns:GetCostTypeCompareGridData" />
  </wsdl:message>
  <wsdl:message name="GetCostTypeCompareGridDataSoapOut">
    <wsdl:part name="parameters" element="tns:GetCostTypeCompareGridDataResponse" />
  </wsdl:message>
  <wsdl:message name="SetCostTypeCompareDataSoapIn">
    <wsdl:part name="parameters" element="tns:SetCostTypeCompareData" />
  </wsdl:message>
  <wsdl:message name="SetCostTypeCompareDataSoapOut">
    <wsdl:part name="parameters" element="tns:SetCostTypeCompareDataResponse" />
  </wsdl:message>
  <wsdl:message name="GetColumnGridDataSoapIn">
    <wsdl:part name="parameters" element="tns:GetColumnGridData" />
  </wsdl:message>
  <wsdl:message name="GetColumnGridDataSoapOut">
    <wsdl:part name="parameters" element="tns:GetColumnGridDataResponse" />
  </wsdl:message>
  <wsdl:message name="SetTotalDataSoapIn">
    <wsdl:part name="parameters" element="tns:SetTotalData" />
  </wsdl:message>
  <wsdl:message name="SetTotalDataSoapOut">
    <wsdl:part name="parameters" element="tns:SetTotalDataResponse" />
  </wsdl:message>
  <wsdl:message name="GetSortAndGroupSoapIn">
    <wsdl:part name="parameters" element="tns:GetSortAndGroup" />
  </wsdl:message>
  <wsdl:message name="GetSortAndGroupSoapOut">
    <wsdl:part name="parameters" element="tns:GetSortAndGroupResponse" />
  </wsdl:message>
  <wsdl:message name="SetSortAndGroupSoapIn">
    <wsdl:part name="parameters" element="tns:SetSortAndGroup" />
  </wsdl:message>
  <wsdl:message name="SetSortAndGroupSoapOut">
    <wsdl:part name="parameters" element="tns:SetSortAndGroupResponse" />
  </wsdl:message>
  <wsdl:message name="GetColumnOrderDataSoapIn">
    <wsdl:part name="parameters" element="tns:GetColumnOrderData" />
  </wsdl:message>
  <wsdl:message name="GetColumnOrderDataSoapOut">
    <wsdl:part name="parameters" element="tns:GetColumnOrderDataResponse" />
  </wsdl:message>
  <wsdl:message name="SetColumnOrderSoapIn">
    <wsdl:part name="parameters" element="tns:SetColumnOrder" />
  </wsdl:message>
  <wsdl:message name="SetColumnOrderSoapOut">
    <wsdl:part name="parameters" element="tns:SetColumnOrderResponse" />
  </wsdl:message>
  <wsdl:message name="LoadCopyVersionPIListsSoapIn">
    <wsdl:part name="parameters" element="tns:LoadCopyVersionPILists" />
  </wsdl:message>
  <wsdl:message name="LoadCopyVersionPIListsSoapOut">
    <wsdl:part name="parameters" element="tns:LoadCopyVersionPIListsResponse" />
  </wsdl:message>
  <wsdl:message name="GetSaveVersionsSoapIn">
    <wsdl:part name="parameters" element="tns:GetSaveVersions" />
  </wsdl:message>
  <wsdl:message name="GetSaveVersionsSoapOut">
    <wsdl:part name="parameters" element="tns:GetSaveVersionsResponse" />
  </wsdl:message>
  <wsdl:message name="GetTargetListSoapIn">
    <wsdl:part name="parameters" element="tns:GetTargetList" />
  </wsdl:message>
  <wsdl:message name="GetTargetListSoapOut">
    <wsdl:part name="parameters" element="tns:GetTargetListResponse" />
  </wsdl:message>
  <wsdl:message name="DoSaveVersionSoapIn">
    <wsdl:part name="parameters" element="tns:DoSaveVersion" />
  </wsdl:message>
  <wsdl:message name="DoSaveVersionSoapOut">
    <wsdl:part name="parameters" element="tns:DoSaveVersionResponse" />
  </wsdl:message>
  <wsdl:message name="GetPeriodsandDisplaySoapIn">
    <wsdl:part name="parameters" element="tns:GetPeriodsandDisplay" />
  </wsdl:message>
  <wsdl:message name="GetPeriodsandDisplaySoapOut">
    <wsdl:part name="parameters" element="tns:GetPeriodsandDisplayResponse" />
  </wsdl:message>
  <wsdl:message name="SetPeriodsandDisplaySoapIn">
    <wsdl:part name="parameters" element="tns:SetPeriodsandDisplay" />
  </wsdl:message>
  <wsdl:message name="SetPeriodsandDisplaySoapOut">
    <wsdl:part name="parameters" element="tns:SetPeriodsandDisplayResponse" />
  </wsdl:message>
  <wsdl:message name="DoDeleteTargetSoapIn">
    <wsdl:part name="parameters" element="tns:DoDeleteTarget" />
  </wsdl:message>
  <wsdl:message name="DoDeleteTargetSoapOut">
    <wsdl:part name="parameters" element="tns:DoDeleteTargetResponse" />
  </wsdl:message>
  <wsdl:message name="CreateTargetSoapIn">
    <wsdl:part name="parameters" element="tns:CreateTarget" />
  </wsdl:message>
  <wsdl:message name="CreateTargetSoapOut">
    <wsdl:part name="parameters" element="tns:CreateTargetResponse" />
  </wsdl:message>
  <wsdl:message name="GetClientSideCalcDataSoapIn">
    <wsdl:part name="parameters" element="tns:GetClientSideCalcData" />
  </wsdl:message>
  <wsdl:message name="GetClientSideCalcDataSoapOut">
    <wsdl:part name="parameters" element="tns:GetClientSideCalcDataResponse" />
  </wsdl:message>
  <wsdl:message name="PrepareTargetDataSoapIn">
    <wsdl:part name="parameters" element="tns:PrepareTargetData" />
  </wsdl:message>
  <wsdl:message name="PrepareTargetDataSoapOut">
    <wsdl:part name="parameters" element="tns:PrepareTargetDataResponse" />
  </wsdl:message>
  <wsdl:message name="GetTargetGridLayoutSoapIn">
    <wsdl:part name="parameters" element="tns:GetTargetGridLayout" />
  </wsdl:message>
  <wsdl:message name="GetTargetGridLayoutSoapOut">
    <wsdl:part name="parameters" element="tns:GetTargetGridLayoutResponse" />
  </wsdl:message>
  <wsdl:message name="GetTargetGridDataSoapIn">
    <wsdl:part name="parameters" element="tns:GetTargetGridData" />
  </wsdl:message>
  <wsdl:message name="GetTargetGridDataSoapOut">
    <wsdl:part name="parameters" element="tns:GetTargetGridDataResponse" />
  </wsdl:message>
  <wsdl:message name="ReturnVersionAsTargetSoapIn">
    <wsdl:part name="parameters" element="tns:ReturnVersionAsTarget" />
  </wsdl:message>
  <wsdl:message name="ReturnVersionAsTargetSoapOut">
    <wsdl:part name="parameters" element="tns:ReturnVersionAsTargetResponse" />
  </wsdl:message>
  <wsdl:message name="SaveTargetDataSoapIn">
    <wsdl:part name="parameters" element="tns:SaveTargetData" />
  </wsdl:message>
  <wsdl:message name="SaveTargetDataSoapOut">
    <wsdl:part name="parameters" element="tns:SaveTargetDataResponse" />
  </wsdl:message>
  <wsdl:message name="GetCostViewsSoapIn">
    <wsdl:part name="parameters" element="tns:GetCostViews" />
  </wsdl:message>
  <wsdl:message name="GetCostViewsSoapOut">
    <wsdl:part name="parameters" element="tns:GetCostViewsResponse" />
  </wsdl:message>
  <wsdl:message name="DoShowRemTotalSoapIn">
    <wsdl:part name="parameters" element="tns:DoShowRemTotal" />
  </wsdl:message>
  <wsdl:message name="DoShowRemTotalSoapOut">
    <wsdl:part name="parameters" element="tns:DoShowRemTotalResponse" />
  </wsdl:message>
  <wsdl:message name="GetLegendGridLayoutSoapIn">
    <wsdl:part name="parameters" element="tns:GetLegendGridLayout" />
  </wsdl:message>
  <wsdl:message name="GetLegendGridLayoutSoapOut">
    <wsdl:part name="parameters" element="tns:GetLegendGridLayoutResponse" />
  </wsdl:message>
  <wsdl:message name="GetLegendGridDataSoapIn">
    <wsdl:part name="parameters" element="tns:GetLegendGridData" />
  </wsdl:message>
  <wsdl:message name="GetLegendGridDataSoapOut">
    <wsdl:part name="parameters" element="tns:GetLegendGridDataResponse" />
  </wsdl:message>
  <wsdl:message name="LoadUserViewDataSoapIn">
    <wsdl:part name="parameters" element="tns:LoadUserViewData" />
  </wsdl:message>
  <wsdl:message name="LoadUserViewDataSoapOut">
    <wsdl:part name="parameters" element="tns:LoadUserViewDataResponse" />
  </wsdl:message>
  <wsdl:message name="DeleteUserViewDataSoapIn">
    <wsdl:part name="parameters" element="tns:DeleteUserViewData" />
  </wsdl:message>
  <wsdl:message name="DeleteUserViewDataSoapOut">
    <wsdl:part name="parameters" element="tns:DeleteUserViewDataResponse" />
  </wsdl:message>
  <wsdl:message name="SaveUserViewDataSoapIn">
    <wsdl:part name="parameters" element="tns:SaveUserViewData" />
  </wsdl:message>
  <wsdl:message name="SaveUserViewDataSoapOut">
    <wsdl:part name="parameters" element="tns:SaveUserViewDataResponse" />
  </wsdl:message>
  <wsdl:message name="SelectUserViewDataSoapIn">
    <wsdl:part name="parameters" element="tns:SelectUserViewData" />
  </wsdl:message>
  <wsdl:message name="SelectUserViewDataSoapOut">
    <wsdl:part name="parameters" element="tns:SelectUserViewDataResponse" />
  </wsdl:message>
  <wsdl:portType name="ModelSoap">
    <wsdl:operation name="LoadModelData">
      <wsdl:input message="tns:LoadModelDataSoapIn" />
      <wsdl:output message="tns:LoadModelDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="DoTopGridCheck">
      <wsdl:input message="tns:DoTopGridCheckSoapIn" />
      <wsdl:output message="tns:DoTopGridCheckSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="DoBarMoved">
      <wsdl:input message="tns:DoBarMovedSoapIn" />
      <wsdl:output message="tns:DoBarMovedSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="DoCopyVersion">
      <wsdl:input message="tns:DoCopyVersionSoapIn" />
      <wsdl:output message="tns:DoCopyVersionSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="DoLoadVersion">
      <wsdl:input message="tns:DoLoadVersionSoapIn" />
      <wsdl:output message="tns:DoLoadVersionSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="DoLoadTarget">
      <wsdl:input message="tns:DoLoadTargetSoapIn" />
      <wsdl:output message="tns:DoLoadTargetSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetTopGridLayout">
      <wsdl:input message="tns:GetTopGridLayoutSoapIn" />
      <wsdl:output message="tns:GetTopGridLayoutSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetTopGridData">
      <wsdl:input message="tns:GetTopGridDataSoapIn" />
      <wsdl:output message="tns:GetTopGridDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetBottomGridLayout">
      <wsdl:input message="tns:GetBottomGridLayoutSoapIn" />
      <wsdl:output message="tns:GetBottomGridLayoutSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetBottomGridData">
      <wsdl:input message="tns:GetBottomGridDataSoapIn" />
      <wsdl:output message="tns:GetBottomGridDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="DoShowFTEs">
      <wsdl:input message="tns:DoShowFTEsSoapIn" />
      <wsdl:output message="tns:DoShowFTEsSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="DoPingSession">
      <wsdl:input message="tns:DoPingSessionSoapIn" />
      <wsdl:output message="tns:DoPingSessionSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="DoShowGantt">
      <wsdl:input message="tns:DoShowGanttSoapIn" />
      <wsdl:output message="tns:DoShowGanttSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="DoSetGroupingFlag">
      <wsdl:input message="tns:DoSetGroupingFlagSoapIn" />
      <wsdl:output message="tns:DoSetGroupingFlagSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetModels">
      <wsdl:input message="tns:GetModelsSoapIn" />
      <wsdl:output message="tns:GetModelsSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="LoadSelectVersions">
      <wsdl:input message="tns:LoadSelectVersionsSoapIn" />
      <wsdl:output message="tns:LoadSelectVersionsSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetFilterGridLayout">
      <wsdl:input message="tns:GetFilterGridLayoutSoapIn" />
      <wsdl:output message="tns:GetFilterGridLayoutSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetFilterGridData">
      <wsdl:input message="tns:GetFilterGridDataSoapIn" />
      <wsdl:output message="tns:GetFilterGridDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="SetFilterData">
      <wsdl:input message="tns:SetFilterDataSoapIn" />
      <wsdl:output message="tns:SetFilterDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetTotalGridLayout">
      <wsdl:input message="tns:GetTotalGridLayoutSoapIn" />
      <wsdl:output message="tns:GetTotalGridLayoutSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetTotalGridData">
      <wsdl:input message="tns:GetTotalGridDataSoapIn" />
      <wsdl:output message="tns:GetTotalGridDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetCostTypeCompareGridData">
      <wsdl:input message="tns:GetCostTypeCompareGridDataSoapIn" />
      <wsdl:output message="tns:GetCostTypeCompareGridDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="SetCostTypeCompareData">
      <wsdl:input message="tns:SetCostTypeCompareDataSoapIn" />
      <wsdl:output message="tns:SetCostTypeCompareDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetColumnGridData">
      <wsdl:input message="tns:GetColumnGridDataSoapIn" />
      <wsdl:output message="tns:GetColumnGridDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="SetTotalData">
      <wsdl:input message="tns:SetTotalDataSoapIn" />
      <wsdl:output message="tns:SetTotalDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetSortAndGroup">
      <wsdl:input message="tns:GetSortAndGroupSoapIn" />
      <wsdl:output message="tns:GetSortAndGroupSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="SetSortAndGroup">
      <wsdl:input message="tns:SetSortAndGroupSoapIn" />
      <wsdl:output message="tns:SetSortAndGroupSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetColumnOrderData">
      <wsdl:input message="tns:GetColumnOrderDataSoapIn" />
      <wsdl:output message="tns:GetColumnOrderDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="SetColumnOrder">
      <wsdl:input message="tns:SetColumnOrderSoapIn" />
      <wsdl:output message="tns:SetColumnOrderSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="LoadCopyVersionPILists">
      <wsdl:input message="tns:LoadCopyVersionPIListsSoapIn" />
      <wsdl:output message="tns:LoadCopyVersionPIListsSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetSaveVersions">
      <wsdl:input message="tns:GetSaveVersionsSoapIn" />
      <wsdl:output message="tns:GetSaveVersionsSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetTargetList">
      <wsdl:input message="tns:GetTargetListSoapIn" />
      <wsdl:output message="tns:GetTargetListSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="DoSaveVersion">
      <wsdl:input message="tns:DoSaveVersionSoapIn" />
      <wsdl:output message="tns:DoSaveVersionSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetPeriodsandDisplay">
      <wsdl:input message="tns:GetPeriodsandDisplaySoapIn" />
      <wsdl:output message="tns:GetPeriodsandDisplaySoapOut" />
    </wsdl:operation>
    <wsdl:operation name="SetPeriodsandDisplay">
      <wsdl:input message="tns:SetPeriodsandDisplaySoapIn" />
      <wsdl:output message="tns:SetPeriodsandDisplaySoapOut" />
    </wsdl:operation>
    <wsdl:operation name="DoDeleteTarget">
      <wsdl:input message="tns:DoDeleteTargetSoapIn" />
      <wsdl:output message="tns:DoDeleteTargetSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="CreateTarget">
      <wsdl:input message="tns:CreateTargetSoapIn" />
      <wsdl:output message="tns:CreateTargetSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetClientSideCalcData">
      <wsdl:input message="tns:GetClientSideCalcDataSoapIn" />
      <wsdl:output message="tns:GetClientSideCalcDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="PrepareTargetData">
      <wsdl:input message="tns:PrepareTargetDataSoapIn" />
      <wsdl:output message="tns:PrepareTargetDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetTargetGridLayout">
      <wsdl:input message="tns:GetTargetGridLayoutSoapIn" />
      <wsdl:output message="tns:GetTargetGridLayoutSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetTargetGridData">
      <wsdl:input message="tns:GetTargetGridDataSoapIn" />
      <wsdl:output message="tns:GetTargetGridDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="ReturnVersionAsTarget">
      <wsdl:input message="tns:ReturnVersionAsTargetSoapIn" />
      <wsdl:output message="tns:ReturnVersionAsTargetSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="SaveTargetData">
      <wsdl:input message="tns:SaveTargetDataSoapIn" />
      <wsdl:output message="tns:SaveTargetDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetCostViews">
      <wsdl:input message="tns:GetCostViewsSoapIn" />
      <wsdl:output message="tns:GetCostViewsSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="DoShowRemTotal">
      <wsdl:input message="tns:DoShowRemTotalSoapIn" />
      <wsdl:output message="tns:DoShowRemTotalSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetLegendGridLayout">
      <wsdl:input message="tns:GetLegendGridLayoutSoapIn" />
      <wsdl:output message="tns:GetLegendGridLayoutSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetLegendGridData">
      <wsdl:input message="tns:GetLegendGridDataSoapIn" />
      <wsdl:output message="tns:GetLegendGridDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="LoadUserViewData">
      <wsdl:input message="tns:LoadUserViewDataSoapIn" />
      <wsdl:output message="tns:LoadUserViewDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="DeleteUserViewData">
      <wsdl:input message="tns:DeleteUserViewDataSoapIn" />
      <wsdl:output message="tns:DeleteUserViewDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="SaveUserViewData">
      <wsdl:input message="tns:SaveUserViewDataSoapIn" />
      <wsdl:output message="tns:SaveUserViewDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="SelectUserViewData">
      <wsdl:input message="tns:SelectUserViewDataSoapIn" />
      <wsdl:output message="tns:SelectUserViewDataSoapOut" />
    </wsdl:operation>
  </wsdl:portType>
  <wsdl:binding name="ModelSoap" type="tns:ModelSoap">
    <soap:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="LoadModelData">
      <soap:operation soapAction="WorkEnginePPM/LoadModelData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoTopGridCheck">
      <soap:operation soapAction="WorkEnginePPM/DoTopGridCheck" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoBarMoved">
      <soap:operation soapAction="WorkEnginePPM/DoBarMoved" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoCopyVersion">
      <soap:operation soapAction="WorkEnginePPM/DoCopyVersion" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoLoadVersion">
      <soap:operation soapAction="WorkEnginePPM/DoLoadVersion" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoLoadTarget">
      <soap:operation soapAction="WorkEnginePPM/DoLoadTarget" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetTopGridLayout">
      <soap:operation soapAction="WorkEnginePPM/GetTopGridLayout" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetTopGridData">
      <soap:operation soapAction="WorkEnginePPM/GetTopGridData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetBottomGridLayout">
      <soap:operation soapAction="WorkEnginePPM/GetBottomGridLayout" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetBottomGridData">
      <soap:operation soapAction="WorkEnginePPM/GetBottomGridData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoShowFTEs">
      <soap:operation soapAction="WorkEnginePPM/DoShowFTEs" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoPingSession">
      <soap:operation soapAction="WorkEnginePPM/DoPingSession" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoShowGantt">
      <soap:operation soapAction="WorkEnginePPM/DoShowGantt" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoSetGroupingFlag">
      <soap:operation soapAction="WorkEnginePPM/DoSetGroupingFlag" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetModels">
      <soap:operation soapAction="WorkEnginePPM/GetModels" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LoadSelectVersions">
      <soap:operation soapAction="WorkEnginePPM/LoadSelectVersions" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetFilterGridLayout">
      <soap:operation soapAction="WorkEnginePPM/GetFilterGridLayout" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetFilterGridData">
      <soap:operation soapAction="WorkEnginePPM/GetFilterGridData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SetFilterData">
      <soap:operation soapAction="WorkEnginePPM/SetFilterData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetTotalGridLayout">
      <soap:operation soapAction="WorkEnginePPM/GetTotalGridLayout" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetTotalGridData">
      <soap:operation soapAction="WorkEnginePPM/GetTotalGridData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetCostTypeCompareGridData">
      <soap:operation soapAction="WorkEnginePPM/GetCostTypeCompareGridData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SetCostTypeCompareData">
      <soap:operation soapAction="WorkEnginePPM/SetCostTypeCompareData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetColumnGridData">
      <soap:operation soapAction="WorkEnginePPM/GetColumnGridData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SetTotalData">
      <soap:operation soapAction="WorkEnginePPM/SetTotalData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetSortAndGroup">
      <soap:operation soapAction="WorkEnginePPM/GetSortAndGroup" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SetSortAndGroup">
      <soap:operation soapAction="WorkEnginePPM/SetSortAndGroup" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetColumnOrderData">
      <soap:operation soapAction="WorkEnginePPM/GetColumnOrderData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SetColumnOrder">
      <soap:operation soapAction="WorkEnginePPM/SetColumnOrder" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LoadCopyVersionPILists">
      <soap:operation soapAction="WorkEnginePPM/LoadCopyVersionPILists" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetSaveVersions">
      <soap:operation soapAction="WorkEnginePPM/GetSaveVersions" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetTargetList">
      <soap:operation soapAction="WorkEnginePPM/GetTargetList" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoSaveVersion">
      <soap:operation soapAction="WorkEnginePPM/DoSaveVersion" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetPeriodsandDisplay">
      <soap:operation soapAction="WorkEnginePPM/GetPeriodsandDisplay" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SetPeriodsandDisplay">
      <soap:operation soapAction="WorkEnginePPM/SetPeriodsandDisplay" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoDeleteTarget">
      <soap:operation soapAction="WorkEnginePPM/DoDeleteTarget" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreateTarget">
      <soap:operation soapAction="WorkEnginePPM/CreateTarget" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetClientSideCalcData">
      <soap:operation soapAction="WorkEnginePPM/GetClientSideCalcData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="PrepareTargetData">
      <soap:operation soapAction="WorkEnginePPM/PrepareTargetData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetTargetGridLayout">
      <soap:operation soapAction="WorkEnginePPM/GetTargetGridLayout" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetTargetGridData">
      <soap:operation soapAction="WorkEnginePPM/GetTargetGridData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="ReturnVersionAsTarget">
      <soap:operation soapAction="WorkEnginePPM/ReturnVersionAsTarget" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SaveTargetData">
      <soap:operation soapAction="WorkEnginePPM/SaveTargetData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetCostViews">
      <soap:operation soapAction="WorkEnginePPM/GetCostViews" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoShowRemTotal">
      <soap:operation soapAction="WorkEnginePPM/DoShowRemTotal" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetLegendGridLayout">
      <soap:operation soapAction="WorkEnginePPM/GetLegendGridLayout" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetLegendGridData">
      <soap:operation soapAction="WorkEnginePPM/GetLegendGridData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LoadUserViewData">
      <soap:operation soapAction="WorkEnginePPM/LoadUserViewData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DeleteUserViewData">
      <soap:operation soapAction="WorkEnginePPM/DeleteUserViewData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SaveUserViewData">
      <soap:operation soapAction="WorkEnginePPM/SaveUserViewData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SelectUserViewData">
      <soap:operation soapAction="WorkEnginePPM/SelectUserViewData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:binding name="ModelSoap12" type="tns:ModelSoap">
    <soap12:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="LoadModelData">
      <soap12:operation soapAction="WorkEnginePPM/LoadModelData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoTopGridCheck">
      <soap12:operation soapAction="WorkEnginePPM/DoTopGridCheck" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoBarMoved">
      <soap12:operation soapAction="WorkEnginePPM/DoBarMoved" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoCopyVersion">
      <soap12:operation soapAction="WorkEnginePPM/DoCopyVersion" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoLoadVersion">
      <soap12:operation soapAction="WorkEnginePPM/DoLoadVersion" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoLoadTarget">
      <soap12:operation soapAction="WorkEnginePPM/DoLoadTarget" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetTopGridLayout">
      <soap12:operation soapAction="WorkEnginePPM/GetTopGridLayout" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetTopGridData">
      <soap12:operation soapAction="WorkEnginePPM/GetTopGridData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetBottomGridLayout">
      <soap12:operation soapAction="WorkEnginePPM/GetBottomGridLayout" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetBottomGridData">
      <soap12:operation soapAction="WorkEnginePPM/GetBottomGridData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoShowFTEs">
      <soap12:operation soapAction="WorkEnginePPM/DoShowFTEs" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoPingSession">
      <soap12:operation soapAction="WorkEnginePPM/DoPingSession" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoShowGantt">
      <soap12:operation soapAction="WorkEnginePPM/DoShowGantt" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoSetGroupingFlag">
      <soap12:operation soapAction="WorkEnginePPM/DoSetGroupingFlag" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetModels">
      <soap12:operation soapAction="WorkEnginePPM/GetModels" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LoadSelectVersions">
      <soap12:operation soapAction="WorkEnginePPM/LoadSelectVersions" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetFilterGridLayout">
      <soap12:operation soapAction="WorkEnginePPM/GetFilterGridLayout" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetFilterGridData">
      <soap12:operation soapAction="WorkEnginePPM/GetFilterGridData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SetFilterData">
      <soap12:operation soapAction="WorkEnginePPM/SetFilterData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetTotalGridLayout">
      <soap12:operation soapAction="WorkEnginePPM/GetTotalGridLayout" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetTotalGridData">
      <soap12:operation soapAction="WorkEnginePPM/GetTotalGridData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetCostTypeCompareGridData">
      <soap12:operation soapAction="WorkEnginePPM/GetCostTypeCompareGridData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SetCostTypeCompareData">
      <soap12:operation soapAction="WorkEnginePPM/SetCostTypeCompareData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetColumnGridData">
      <soap12:operation soapAction="WorkEnginePPM/GetColumnGridData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SetTotalData">
      <soap12:operation soapAction="WorkEnginePPM/SetTotalData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetSortAndGroup">
      <soap12:operation soapAction="WorkEnginePPM/GetSortAndGroup" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SetSortAndGroup">
      <soap12:operation soapAction="WorkEnginePPM/SetSortAndGroup" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetColumnOrderData">
      <soap12:operation soapAction="WorkEnginePPM/GetColumnOrderData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SetColumnOrder">
      <soap12:operation soapAction="WorkEnginePPM/SetColumnOrder" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LoadCopyVersionPILists">
      <soap12:operation soapAction="WorkEnginePPM/LoadCopyVersionPILists" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetSaveVersions">
      <soap12:operation soapAction="WorkEnginePPM/GetSaveVersions" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetTargetList">
      <soap12:operation soapAction="WorkEnginePPM/GetTargetList" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoSaveVersion">
      <soap12:operation soapAction="WorkEnginePPM/DoSaveVersion" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetPeriodsandDisplay">
      <soap12:operation soapAction="WorkEnginePPM/GetPeriodsandDisplay" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SetPeriodsandDisplay">
      <soap12:operation soapAction="WorkEnginePPM/SetPeriodsandDisplay" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoDeleteTarget">
      <soap12:operation soapAction="WorkEnginePPM/DoDeleteTarget" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="CreateTarget">
      <soap12:operation soapAction="WorkEnginePPM/CreateTarget" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetClientSideCalcData">
      <soap12:operation soapAction="WorkEnginePPM/GetClientSideCalcData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="PrepareTargetData">
      <soap12:operation soapAction="WorkEnginePPM/PrepareTargetData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetTargetGridLayout">
      <soap12:operation soapAction="WorkEnginePPM/GetTargetGridLayout" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetTargetGridData">
      <soap12:operation soapAction="WorkEnginePPM/GetTargetGridData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="ReturnVersionAsTarget">
      <soap12:operation soapAction="WorkEnginePPM/ReturnVersionAsTarget" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SaveTargetData">
      <soap12:operation soapAction="WorkEnginePPM/SaveTargetData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetCostViews">
      <soap12:operation soapAction="WorkEnginePPM/GetCostViews" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DoShowRemTotal">
      <soap12:operation soapAction="WorkEnginePPM/DoShowRemTotal" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetLegendGridLayout">
      <soap12:operation soapAction="WorkEnginePPM/GetLegendGridLayout" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetLegendGridData">
      <soap12:operation soapAction="WorkEnginePPM/GetLegendGridData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="LoadUserViewData">
      <soap12:operation soapAction="WorkEnginePPM/LoadUserViewData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DeleteUserViewData">
      <soap12:operation soapAction="WorkEnginePPM/DeleteUserViewData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SaveUserViewData">
      <soap12:operation soapAction="WorkEnginePPM/SaveUserViewData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="SelectUserViewData">
      <soap12:operation soapAction="WorkEnginePPM/SelectUserViewData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:service name="Model">
    <wsdl:port name="ModelSoap" binding="tns:ModelSoap">
      <soap:address location=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(SPWeb.OriginalBaseUrl(Request)),Response.Output); %> />
    </wsdl:port>
    <wsdl:port name="ModelSoap12" binding="tns:ModelSoap12">
      <soap12:address location=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(SPWeb.OriginalBaseUrl(Request)),Response.Output); %> />
    </wsdl:port>
  </wsdl:service>
</wsdl:definitions>