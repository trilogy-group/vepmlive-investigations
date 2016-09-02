<%@ Page Language="C#" Inherits="System.Web.UI.Page" %> 
<%@ Assembly Name="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Import Namespace="Microsoft.SharePoint.Utilities" %> 
<%@ Import Namespace="Microsoft.SharePoint" %>
<% Response.ContentType = "text/xml"; %>

<wsdl:definitions xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/" xmlns:tm="http://microsoft.com/wsdl/mime/textMatching/" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" xmlns:mime="http://schemas.xmlsoap.org/wsdl/mime/" xmlns:tns="http://epmlive.com/" xmlns:s1="http://microsoft.com/wsdl/types/" xmlns:s="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/" xmlns:http="http://schemas.xmlsoap.org/wsdl/http/" targetNamespace="http://epmlive.com/" xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">
  <wsdl:types>
    <s:schema elementFormDefault="qualified" targetNamespace="http://epmlive.com/">
      <s:import namespace="http://microsoft.com/wsdl/types/" />
      <s:element name="getVersion">
        <s:complexType />
      </s:element>
      <s:element name="getVersionResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="getVersionResult" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getFileVersion">
        <s:complexType />
      </s:element>
      <s:element name="getFileVersionResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="getFileVersionResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="saveTaskFields">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="cfs" type="tns:ArrayOfCustomField" />
            <s:element minOccurs="0" maxOccurs="1" name="delFields" type="tns:ArrayOfString" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfCustomField">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="CustomField" nillable="true" type="tns:CustomField" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="CustomField">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="name" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="displayName" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="wssFieldName" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="locked" type="s:boolean" />
          <s:element minOccurs="1" maxOccurs="1" name="visible" type="s:boolean" />
          <s:element minOccurs="1" maxOccurs="1" name="editable" type="s:boolean" />
          <s:element minOccurs="1" maxOccurs="1" name="fieldType" type="tns:SPFieldType" />
          <s:element minOccurs="1" maxOccurs="1" name="fieldCategory" type="s:int" />
        </s:sequence>
      </s:complexType>
      <s:simpleType name="SPFieldType">
        <s:restriction base="s:string">
          <s:enumeration value="Invalid" />
          <s:enumeration value="Integer" />
          <s:enumeration value="Text" />
          <s:enumeration value="Note" />
          <s:enumeration value="DateTime" />
          <s:enumeration value="Counter" />
          <s:enumeration value="Choice" />
          <s:enumeration value="Lookup" />
          <s:enumeration value="Boolean" />
          <s:enumeration value="Number" />
          <s:enumeration value="Currency" />
          <s:enumeration value="URL" />
          <s:enumeration value="Computed" />
          <s:enumeration value="Threading" />
          <s:enumeration value="Guid" />
          <s:enumeration value="MultiChoice" />
          <s:enumeration value="GridChoice" />
          <s:enumeration value="Calculated" />
          <s:enumeration value="File" />
          <s:enumeration value="Attachments" />
          <s:enumeration value="User" />
          <s:enumeration value="Recurrence" />
          <s:enumeration value="CrossProjectLink" />
          <s:enumeration value="ModStat" />
          <s:enumeration value="Error" />
          <s:enumeration value="ContentTypeId" />
          <s:enumeration value="PageSeparator" />
          <s:enumeration value="ThreadIndex" />
          <s:enumeration value="WorkflowStatus" />
          <s:enumeration value="AllDayEvent" />
          <s:enumeration value="WorkflowEventType" />
          <s:enumeration value="MaxItems" />
        </s:restriction>
      </s:simpleType>
      <s:complexType name="ArrayOfString">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="string" nillable="true" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="saveTaskFieldsResponse">
        <s:complexType />
      </s:element>
      <s:element name="saveProjectFields">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="cfs" type="tns:ArrayOfCustomField" />
            <s:element minOccurs="0" maxOccurs="1" name="delFields" type="tns:ArrayOfString" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="saveProjectFieldsResponse">
        <s:complexType />
      </s:element>
      <s:element name="getTaskCustomFields">
        <s:complexType />
      </s:element>
      <s:element name="getTaskCustomFieldsResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="getTaskCustomFieldsResult" type="tns:ArrayOfCustomField" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getTaskCustomFields2">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="projectServerUrl" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getTaskCustomFields2Response">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="getTaskCustomFields2Result" type="tns:ArrayOfCustomField" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getProjectCustomFields">
        <s:complexType />
      </s:element>
      <s:element name="getProjectCustomFieldsResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="getProjectCustomFieldsResult" type="tns:ArrayOfCustomField" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getProjectCustomFields2">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="projectServerUrl" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getProjectCustomFields2Response">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="getProjectCustomFields2Result" type="tns:ArrayOfCustomField" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getProjectSite">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="projectUID" type="s1:guid" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getProjectSiteResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="getProjectSiteResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getDefaultPublishURL">
        <s:complexType />
      </s:element>
      <s:element name="getDefaultPublishURLResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="getDefaultPublishURLResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="createSite">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="url" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="projectName" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="createSiteResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="createSiteResult" type="s:boolean" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="createSiteWithTemplate">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="url" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="projectName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="template" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="createSiteWithTemplateResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="createSiteWithTemplateResult" type="s:boolean" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="isTaskUpdates">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="projectGuid" type="s1:guid" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="isTaskUpdatesResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="isTaskUpdatesResult" type="s:boolean" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getPublishType">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="projectGuid" type="s1:guid" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getPublishTypeResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="getPublishTypeResult" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="setApprovedTasks">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="taskItems" type="tns:ArrayOfTaskApprovalItem" />
            <s:element minOccurs="1" maxOccurs="1" name="projectGuid" type="s1:guid" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfTaskApprovalItem">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="TaskApprovalItem" nillable="true" type="tns:TaskApprovalItem" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="TaskApprovalItem">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="listItemId" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="approvalStatus" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="approvalNotes" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="taskuid" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="setApprovedTasksResponse">
        <s:complexType />
      </s:element>
      <s:element name="getUpdates">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="projectGuid" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getUpdatesResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="getUpdatesResult" type="tns:ArrayOfUpdateTaskItem" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfUpdateTaskItem">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="UpdateTaskItem" nillable="true" type="tns:UpdateTaskItem" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="UpdateTaskItem">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="taskname" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="taskuid" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="startDate" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="finishDate" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="percentComplete" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="notes" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="listItemId" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="updatefields" type="tns:ArrayOfUpdateFieldItem" />
          <s:element minOccurs="0" maxOccurs="1" name="taskHierarchy" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="ArrayOfUpdateFieldItem">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="UpdateFieldItem" nillable="true" type="tns:UpdateFieldItem" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="UpdateFieldItem">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="displayName" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="value" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="fieldId" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="internalFieldName" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="fieldGuid" type="s1:guid" />
        </s:sequence>
      </s:complexType>
      <s:element name="getAllTaskEnterpriseFieldList">
        <s:complexType />
      </s:element>
      <s:element name="getAllTaskEnterpriseFieldListResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="getAllTaskEnterpriseFieldListResult" type="tns:ArrayOfString" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getAllProjectEnterpriseFieldList">
        <s:complexType />
      </s:element>
      <s:element name="getAllProjectEnterpriseFieldListResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="getAllProjectEnterpriseFieldListResult" type="tns:ArrayOfString" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="publish">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="projectUid" type="s1:guid" />
            <s:element minOccurs="1" maxOccurs="1" name="pubType" type="s:int" />
            <s:element minOccurs="0" maxOccurs="1" name="url" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="publishResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="publishResult" type="s:boolean" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getSiteTemplates">
        <s:complexType />
      </s:element>
      <s:element name="getSiteTemplatesResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="getSiteTemplatesResult" type="tns:ArrayOfString" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getEnterpriseSetting">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="setting" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getEnterpriseSettingResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="getEnterpriseSettingResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
    </s:schema>
    <s:schema elementFormDefault="qualified" targetNamespace="http://microsoft.com/wsdl/types/">
      <s:simpleType name="guid">
        <s:restriction base="s:string">
          <s:pattern value="[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}" />
        </s:restriction>
      </s:simpleType>
    </s:schema>
  </wsdl:types>
  <wsdl:message name="getVersionSoapIn">
    <wsdl:part name="parameters" element="tns:getVersion" />
  </wsdl:message>
  <wsdl:message name="getVersionSoapOut">
    <wsdl:part name="parameters" element="tns:getVersionResponse" />
  </wsdl:message>
  <wsdl:message name="getFileVersionSoapIn">
    <wsdl:part name="parameters" element="tns:getFileVersion" />
  </wsdl:message>
  <wsdl:message name="getFileVersionSoapOut">
    <wsdl:part name="parameters" element="tns:getFileVersionResponse" />
  </wsdl:message>
  <wsdl:message name="saveTaskFieldsSoapIn">
    <wsdl:part name="parameters" element="tns:saveTaskFields" />
  </wsdl:message>
  <wsdl:message name="saveTaskFieldsSoapOut">
    <wsdl:part name="parameters" element="tns:saveTaskFieldsResponse" />
  </wsdl:message>
  <wsdl:message name="saveProjectFieldsSoapIn">
    <wsdl:part name="parameters" element="tns:saveProjectFields" />
  </wsdl:message>
  <wsdl:message name="saveProjectFieldsSoapOut">
    <wsdl:part name="parameters" element="tns:saveProjectFieldsResponse" />
  </wsdl:message>
  <wsdl:message name="getTaskCustomFieldsSoapIn">
    <wsdl:part name="parameters" element="tns:getTaskCustomFields" />
  </wsdl:message>
  <wsdl:message name="getTaskCustomFieldsSoapOut">
    <wsdl:part name="parameters" element="tns:getTaskCustomFieldsResponse" />
  </wsdl:message>
  <wsdl:message name="getTaskCustomFields2SoapIn">
    <wsdl:part name="parameters" element="tns:getTaskCustomFields2" />
  </wsdl:message>
  <wsdl:message name="getTaskCustomFields2SoapOut">
    <wsdl:part name="parameters" element="tns:getTaskCustomFields2Response" />
  </wsdl:message>
  <wsdl:message name="getProjectCustomFieldsSoapIn">
    <wsdl:part name="parameters" element="tns:getProjectCustomFields" />
  </wsdl:message>
  <wsdl:message name="getProjectCustomFieldsSoapOut">
    <wsdl:part name="parameters" element="tns:getProjectCustomFieldsResponse" />
  </wsdl:message>
  <wsdl:message name="getProjectCustomFields2SoapIn">
    <wsdl:part name="parameters" element="tns:getProjectCustomFields2" />
  </wsdl:message>
  <wsdl:message name="getProjectCustomFields2SoapOut">
    <wsdl:part name="parameters" element="tns:getProjectCustomFields2Response" />
  </wsdl:message>
  <wsdl:message name="getProjectSiteSoapIn">
    <wsdl:part name="parameters" element="tns:getProjectSite" />
  </wsdl:message>
  <wsdl:message name="getProjectSiteSoapOut">
    <wsdl:part name="parameters" element="tns:getProjectSiteResponse" />
  </wsdl:message>
  <wsdl:message name="getDefaultPublishURLSoapIn">
    <wsdl:part name="parameters" element="tns:getDefaultPublishURL" />
  </wsdl:message>
  <wsdl:message name="getDefaultPublishURLSoapOut">
    <wsdl:part name="parameters" element="tns:getDefaultPublishURLResponse" />
  </wsdl:message>
  <wsdl:message name="createSiteSoapIn">
    <wsdl:part name="parameters" element="tns:createSite" />
  </wsdl:message>
  <wsdl:message name="createSiteSoapOut">
    <wsdl:part name="parameters" element="tns:createSiteResponse" />
  </wsdl:message>
  <wsdl:message name="createSiteWithTemplateSoapIn">
    <wsdl:part name="parameters" element="tns:createSiteWithTemplate" />
  </wsdl:message>
  <wsdl:message name="createSiteWithTemplateSoapOut">
    <wsdl:part name="parameters" element="tns:createSiteWithTemplateResponse" />
  </wsdl:message>
  <wsdl:message name="isTaskUpdatesSoapIn">
    <wsdl:part name="parameters" element="tns:isTaskUpdates" />
  </wsdl:message>
  <wsdl:message name="isTaskUpdatesSoapOut">
    <wsdl:part name="parameters" element="tns:isTaskUpdatesResponse" />
  </wsdl:message>
  <wsdl:message name="getPublishTypeSoapIn">
    <wsdl:part name="parameters" element="tns:getPublishType" />
  </wsdl:message>
  <wsdl:message name="getPublishTypeSoapOut">
    <wsdl:part name="parameters" element="tns:getPublishTypeResponse" />
  </wsdl:message>
  <wsdl:message name="setApprovedTasksSoapIn">
    <wsdl:part name="parameters" element="tns:setApprovedTasks" />
  </wsdl:message>
  <wsdl:message name="setApprovedTasksSoapOut">
    <wsdl:part name="parameters" element="tns:setApprovedTasksResponse" />
  </wsdl:message>
  <wsdl:message name="getUpdatesSoapIn">
    <wsdl:part name="parameters" element="tns:getUpdates" />
  </wsdl:message>
  <wsdl:message name="getUpdatesSoapOut">
    <wsdl:part name="parameters" element="tns:getUpdatesResponse" />
  </wsdl:message>
  <wsdl:message name="getAllTaskEnterpriseFieldListSoapIn">
    <wsdl:part name="parameters" element="tns:getAllTaskEnterpriseFieldList" />
  </wsdl:message>
  <wsdl:message name="getAllTaskEnterpriseFieldListSoapOut">
    <wsdl:part name="parameters" element="tns:getAllTaskEnterpriseFieldListResponse" />
  </wsdl:message>
  <wsdl:message name="getAllProjectEnterpriseFieldListSoapIn">
    <wsdl:part name="parameters" element="tns:getAllProjectEnterpriseFieldList" />
  </wsdl:message>
  <wsdl:message name="getAllProjectEnterpriseFieldListSoapOut">
    <wsdl:part name="parameters" element="tns:getAllProjectEnterpriseFieldListResponse" />
  </wsdl:message>
  <wsdl:message name="publishSoapIn">
    <wsdl:part name="parameters" element="tns:publish" />
  </wsdl:message>
  <wsdl:message name="publishSoapOut">
    <wsdl:part name="parameters" element="tns:publishResponse" />
  </wsdl:message>
  <wsdl:message name="getSiteTemplatesSoapIn">
    <wsdl:part name="parameters" element="tns:getSiteTemplates" />
  </wsdl:message>
  <wsdl:message name="getSiteTemplatesSoapOut">
    <wsdl:part name="parameters" element="tns:getSiteTemplatesResponse" />
  </wsdl:message>
  <wsdl:message name="getEnterpriseSettingSoapIn">
    <wsdl:part name="parameters" element="tns:getEnterpriseSetting" />
  </wsdl:message>
  <wsdl:message name="getEnterpriseSettingSoapOut">
    <wsdl:part name="parameters" element="tns:getEnterpriseSettingResponse" />
  </wsdl:message>
  <wsdl:portType name="EPMLivePublisherSoap">
    <wsdl:operation name="getVersion">
      <wsdl:input message="tns:getVersionSoapIn" />
      <wsdl:output message="tns:getVersionSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="getFileVersion">
      <wsdl:input message="tns:getFileVersionSoapIn" />
      <wsdl:output message="tns:getFileVersionSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="saveTaskFields">
      <wsdl:input message="tns:saveTaskFieldsSoapIn" />
      <wsdl:output message="tns:saveTaskFieldsSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="saveProjectFields">
      <wsdl:input message="tns:saveProjectFieldsSoapIn" />
      <wsdl:output message="tns:saveProjectFieldsSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="getTaskCustomFields">
      <wsdl:input message="tns:getTaskCustomFieldsSoapIn" />
      <wsdl:output message="tns:getTaskCustomFieldsSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="getTaskCustomFields2">
      <wsdl:input message="tns:getTaskCustomFields2SoapIn" />
      <wsdl:output message="tns:getTaskCustomFields2SoapOut" />
    </wsdl:operation>
    <wsdl:operation name="getProjectCustomFields">
      <wsdl:input message="tns:getProjectCustomFieldsSoapIn" />
      <wsdl:output message="tns:getProjectCustomFieldsSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="getProjectCustomFields2">
      <wsdl:input message="tns:getProjectCustomFields2SoapIn" />
      <wsdl:output message="tns:getProjectCustomFields2SoapOut" />
    </wsdl:operation>
    <wsdl:operation name="getProjectSite">
      <wsdl:input message="tns:getProjectSiteSoapIn" />
      <wsdl:output message="tns:getProjectSiteSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="getDefaultPublishURL">
      <wsdl:input message="tns:getDefaultPublishURLSoapIn" />
      <wsdl:output message="tns:getDefaultPublishURLSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="createSite">
      <wsdl:input message="tns:createSiteSoapIn" />
      <wsdl:output message="tns:createSiteSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="createSiteWithTemplate">
      <wsdl:input message="tns:createSiteWithTemplateSoapIn" />
      <wsdl:output message="tns:createSiteWithTemplateSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="isTaskUpdates">
      <wsdl:input message="tns:isTaskUpdatesSoapIn" />
      <wsdl:output message="tns:isTaskUpdatesSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="getPublishType">
      <wsdl:input message="tns:getPublishTypeSoapIn" />
      <wsdl:output message="tns:getPublishTypeSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="setApprovedTasks">
      <wsdl:input message="tns:setApprovedTasksSoapIn" />
      <wsdl:output message="tns:setApprovedTasksSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="getUpdates">
      <wsdl:input message="tns:getUpdatesSoapIn" />
      <wsdl:output message="tns:getUpdatesSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="getAllTaskEnterpriseFieldList">
      <wsdl:input message="tns:getAllTaskEnterpriseFieldListSoapIn" />
      <wsdl:output message="tns:getAllTaskEnterpriseFieldListSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="getAllProjectEnterpriseFieldList">
      <wsdl:input message="tns:getAllProjectEnterpriseFieldListSoapIn" />
      <wsdl:output message="tns:getAllProjectEnterpriseFieldListSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="publish">
      <wsdl:input message="tns:publishSoapIn" />
      <wsdl:output message="tns:publishSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="getSiteTemplates">
      <wsdl:input message="tns:getSiteTemplatesSoapIn" />
      <wsdl:output message="tns:getSiteTemplatesSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="getEnterpriseSetting">
      <wsdl:input message="tns:getEnterpriseSettingSoapIn" />
      <wsdl:output message="tns:getEnterpriseSettingSoapOut" />
    </wsdl:operation>
  </wsdl:portType>
  <wsdl:binding name="EPMLivePublisherSoap" type="tns:EPMLivePublisherSoap">
    <soap:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="getVersion">
      <soap:operation soapAction="http://epmlive.com/getVersion" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getFileVersion">
      <soap:operation soapAction="http://epmlive.com/getFileVersion" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="saveTaskFields">
      <soap:operation soapAction="http://epmlive.com/saveTaskFields" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="saveProjectFields">
      <soap:operation soapAction="http://epmlive.com/saveProjectFields" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getTaskCustomFields">
      <soap:operation soapAction="http://epmlive.com/getTaskCustomFields" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getTaskCustomFields2">
      <soap:operation soapAction="http://epmlive.com/getTaskCustomFields2" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getProjectCustomFields">
      <soap:operation soapAction="http://epmlive.com/getProjectCustomFields" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getProjectCustomFields2">
      <soap:operation soapAction="http://epmlive.com/getProjectCustomFields2" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getProjectSite">
      <soap:operation soapAction="http://epmlive.com/getProjectSite" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getDefaultPublishURL">
      <soap:operation soapAction="http://epmlive.com/getDefaultPublishURL" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="createSite">
      <soap:operation soapAction="http://epmlive.com/createSite" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="createSiteWithTemplate">
      <soap:operation soapAction="http://epmlive.com/createSiteWithTemplate" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="isTaskUpdates">
      <soap:operation soapAction="http://epmlive.com/isTaskUpdates" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getPublishType">
      <soap:operation soapAction="http://epmlive.com/getPublishType" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="setApprovedTasks">
      <soap:operation soapAction="http://epmlive.com/setApprovedTasks" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getUpdates">
      <soap:operation soapAction="http://epmlive.com/getUpdates" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getAllTaskEnterpriseFieldList">
      <soap:operation soapAction="http://epmlive.com/getAllTaskEnterpriseFieldList" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getAllProjectEnterpriseFieldList">
      <soap:operation soapAction="http://epmlive.com/getAllProjectEnterpriseFieldList" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="publish">
      <soap:operation soapAction="http://epmlive.com/publish" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getSiteTemplates">
      <soap:operation soapAction="http://epmlive.com/getSiteTemplates" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getEnterpriseSetting">
      <soap:operation soapAction="http://epmlive.com/getEnterpriseSetting" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:binding name="EPMLivePublisherSoap12" type="tns:EPMLivePublisherSoap">
    <soap12:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="getVersion">
      <soap12:operation soapAction="http://epmlive.com/getVersion" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getFileVersion">
      <soap12:operation soapAction="http://epmlive.com/getFileVersion" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="saveTaskFields">
      <soap12:operation soapAction="http://epmlive.com/saveTaskFields" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="saveProjectFields">
      <soap12:operation soapAction="http://epmlive.com/saveProjectFields" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getTaskCustomFields">
      <soap12:operation soapAction="http://epmlive.com/getTaskCustomFields" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getTaskCustomFields2">
      <soap12:operation soapAction="http://epmlive.com/getTaskCustomFields2" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getProjectCustomFields">
      <soap12:operation soapAction="http://epmlive.com/getProjectCustomFields" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getProjectCustomFields2">
      <soap12:operation soapAction="http://epmlive.com/getProjectCustomFields2" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getProjectSite">
      <soap12:operation soapAction="http://epmlive.com/getProjectSite" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getDefaultPublishURL">
      <soap12:operation soapAction="http://epmlive.com/getDefaultPublishURL" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="createSite">
      <soap12:operation soapAction="http://epmlive.com/createSite" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="createSiteWithTemplate">
      <soap12:operation soapAction="http://epmlive.com/createSiteWithTemplate" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="isTaskUpdates">
      <soap12:operation soapAction="http://epmlive.com/isTaskUpdates" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getPublishType">
      <soap12:operation soapAction="http://epmlive.com/getPublishType" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="setApprovedTasks">
      <soap12:operation soapAction="http://epmlive.com/setApprovedTasks" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getUpdates">
      <soap12:operation soapAction="http://epmlive.com/getUpdates" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getAllTaskEnterpriseFieldList">
      <soap12:operation soapAction="http://epmlive.com/getAllTaskEnterpriseFieldList" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getAllProjectEnterpriseFieldList">
      <soap12:operation soapAction="http://epmlive.com/getAllProjectEnterpriseFieldList" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="publish">
      <soap12:operation soapAction="http://epmlive.com/publish" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getSiteTemplates">
      <soap12:operation soapAction="http://epmlive.com/getSiteTemplates" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getEnterpriseSetting">
      <soap12:operation soapAction="http://epmlive.com/getEnterpriseSetting" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:service name="EPMLivePublisher">
    <wsdl:port name="EPMLivePublisherSoap" binding="tns:EPMLivePublisherSoap">
	<soap:address location=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(SPWeb.OriginalBaseUrl(Request)),Response.Output); %> />
    </wsdl:port>
    <wsdl:port name="EPMLivePublisherSoap12" binding="tns:EPMLivePublisherSoap12">
	<soap12:address location=<% SPHttpUtility.AddQuote(SPHttpUtility.HtmlEncode(SPWeb.OriginalBaseUrl(Request)),Response.Output); %> />
    </wsdl:port>
  </wsdl:service>
</wsdl:definitions>