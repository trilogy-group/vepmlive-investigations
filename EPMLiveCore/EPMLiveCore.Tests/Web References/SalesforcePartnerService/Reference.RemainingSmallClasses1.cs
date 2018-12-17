using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.SalesforcePartnerService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SalesforcePartnerService
{
    /// <summary>
    /// Unit Tests for remaining small classes in namespace <see cref="EPMLiveCore.SalesforcePartnerService"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class ReferenceTest1
    {
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;

        [TestMethod]
        public void LeadConvertClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new LeadConvert();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["accountId"] = DummyString,
                ["contactId"] = DummyString,
                ["convertedStatus"] = DummyString,
                ["doNotCreateOpportunity"] = true,
                ["leadId"] = DummyString,
                ["opportunityName"] = DummyString,
                ["overwriteLeadSource"] = true,
                ["ownerId"] = DummyString,
                ["sendNotificationEmail"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void RelatedListClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new RelatedList();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["columns"] = new RelatedListColumn[] { },
                ["custom"] = true,
                ["field"] = DummyString,
                ["label"] = DummyString,
                ["limitRows"] = DummyInt,
                ["name"] = DummyString,
                ["sobject"] = DummyString,
                ["sort"] = new RelatedListSort[] { },
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ChildRelationshipClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new ChildRelationship();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["cascadeDelete"] = true,
                ["childSObject"] = DummyString,
                ["deprecatedAndHidden"] = true,
                ["field"] = DummyString,
                ["relationshipName"] = DummyString,
                ["restrictedDelete"] = true,
                ["restrictedDeleteSpecified"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void EmailClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new Email();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["bccSender"] = true,
                ["emailPriority"] = new EmailPriority(),
                ["replyTo"] = DummyString,
                ["saveAsActivity"] = true,
                ["senderDisplayName"] = DummyString,
                ["subject"] = DummyString,
                ["useSignature"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void LoginResultClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new LoginResult();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["metadataServerUrl"] = DummyString,
                ["passwordExpired"] = true,
                ["sandbox"] = true,
                ["serverUrl"] = DummyString,
                ["sessionId"] = DummyString,
                ["userId"] = DummyString,
                ["userInfo"] = new GetUserInfoResult(),
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void ProcessResultClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new ProcessResult();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["actorIds"] = new string[] { },
                ["entityId"] = DummyString,
                ["errors"] = new Error[] { },
                ["instanceId"] = DummyString,
                ["instanceStatus"] = DummyString,
                ["newWorkitemIds"] = new string[] { },
                ["success"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DescribeLayoutSectionClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new DescribeLayoutSection();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["columns"] = DummyInt,
                ["heading"] = DummyString,
                ["layoutRows"] = new DescribeLayoutRow[] { },
                ["rows"] = DummyInt,
                ["useCollapsibleSection"] = true,
                ["useHeading"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DescribeTabClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new DescribeTab();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["custom"] = true,
                ["iconUrl"] = DummyString,
                ["label"] = DummyString,
                ["miniIconUrl"] = DummyString,
                ["sobjectName"] = DummyString,
                ["url"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void LeadConvertResultClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new LeadConvertResult();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["accountId"] = DummyString,
                ["contactId"] = DummyString,
                ["errors"] = new Error[] { },
                ["leadId"] = DummyString,
                ["opportunityId"] = DummyString,
                ["success"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void RecordTypeMappingClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new RecordTypeMapping();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["available"] = true,
                ["defaultRecordTypeMapping"] = true,
                ["layoutId"] = DummyString,
                ["name"] = DummyString,
                ["picklistsForRecordType"] = new PicklistForRecordType[] { },
                ["recordTypeId"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DescribeDataCategoryGroupResultClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new DescribeDataCategoryGroupResult();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["categoryCount"] = DummyInt,
                ["description"] = DummyString,
                ["label"] = DummyString,
                ["name"] = DummyString,
                ["sobject"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DescribeDataCategoryGroupStructureResultClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new DescribeDataCategoryGroupStructureResult();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["description"] = DummyString,
                ["label"] = DummyString,
                ["name"] = DummyString,
                ["sobject"] = DummyString,
                ["topCategories"] = new DataCategory[] { },
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DescribeLayoutClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new DescribeLayout();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["buttonLayoutSection"] = new DescribeLayoutButton[] { },
                ["detailLayoutSections"] = new DescribeLayoutSection[] { },
                ["editLayoutSections"] = new DescribeLayoutSection[] { },
                ["id"] = DummyString,
                ["relatedLists"] = new RelatedList[] { },
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DescribeLayoutItemClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new DescribeLayoutItem();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["editable"] = true,
                ["label"] = DummyString,
                ["layoutComponents"] = new DescribeLayoutComponent[] { },
                ["placeholder"] = true,
                ["required"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DescribeSoftphoneLayoutCallTypeClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new DescribeSoftphoneLayoutCallType();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["infoFields"] = new DescribeSoftphoneLayoutInfoField[] { },
                ["name"] = DummyString,
                ["screenPopOptions"] = new DescribeSoftphoneScreenPopOption[] { },
                ["screenPopsOpenWithin"] = DummyString,
                ["sections"] = new DescribeSoftphoneLayoutSection[] { },
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DescribeTabSetResultClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new DescribeTabSetResult();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["label"] = DummyString,
                ["logoUrl"] = DummyString,
                ["namespace"] = DummyString,
                ["selected"] = true,
                ["tabs"] = new DescribeTab[] { },
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void EmailFileAttachmentClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new EmailFileAttachment();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["body"] = new byte[] { },
                ["contentType"] = DummyString,
                ["fileName"] = DummyString,
                ["inline"] = true,
                ["inlineSpecified"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void MergeResultClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new MergeResult();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["errors"] = new Error[] { },
                ["id"] = DummyString,
                ["mergedRecordIds"] = new string[] { },
                ["success"] = true,
                ["updatedRelatedIds"] = new string[] { },
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void PicklistEntryClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new PicklistEntry();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["active"] = true,
                ["defaultValue"] = true,
                ["label"] = DummyString,
                ["validFor"] = new byte[] { },
                ["value"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void RelatedListColumnClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new RelatedListColumn();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["field"] = DummyString,
                ["format"] = DummyString,
                ["label"] = DummyString,
                ["lookupId"] = DummyString,
                ["name"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DescribeLayoutComponentClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new DescribeLayoutComponent();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["displayLines"] = DummyInt,
                ["tabOrder"] = DummyInt,
                ["type"] = new layoutComponentType(),
                ["value"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void GetDeletedResultClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new GetDeletedResult();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["deletedRecords"] = new DeletedRecord[] { },
                ["earliestDateAvailable"] = new System.DateTime(),
                ["latestDateCovered"] = new System.DateTime(),
                ["sforceReserved"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void MassEmailMessageClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new MassEmailMessage();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["description"] = DummyString,
                ["targetObjectIds"] = new string[] { },
                ["templateId"] = DummyString,
                ["whatIds"] = new string[] { },
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void QueryResultClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new QueryResult();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["done"] = true,
                ["queryLocator"] = DummyString,
                ["records"] = new sObject[] { },
                ["size"] = DummyInt,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void RecordTypeInfoClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new RecordTypeInfo();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["available"] = true,
                ["defaultRecordTypeMapping"] = true,
                ["name"] = DummyString,
                ["recordTypeId"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void SendEmailErrorClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new SendEmailError();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["fields"] = new string[] { },
                ["message"] = DummyString,
                ["statusCode"] = new StatusCode(),
                ["targetObjectId"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void UpsertResultClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new UpsertResult();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["created"] = true,
                ["errors"] = new Error[] { },
                ["id"] = DummyString,
                ["success"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DataCategoryClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new DataCategory();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["childCategories"] = new DataCategory[] { },
                ["label"] = DummyString,
                ["name"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DescribeGlobalResultClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new DescribeGlobalResult();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["encoding"] = DummyString,
                ["maxBatchSize"] = DummyInt,
                ["sobjects"] = new DescribeGlobalSObjectResult[] { },
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DescribeLayoutButtonClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new DescribeLayoutButton();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["custom"] = true,
                ["label"] = DummyString,
                ["name"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DescribeLayoutResultClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new DescribeLayoutResult();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {

                ["layouts"] = new DescribeLayout[] { },
                ["recordTypeMappings"] = new RecordTypeMapping[] { },
                ["recordTypeSelectorRequired"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DescribeSoftphoneLayoutResultClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new DescribeSoftphoneLayoutResult();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["callTypes"] = new DescribeSoftphoneLayoutCallType[] { },
                ["id"] = DummyString,
                ["name"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        [TestMethod]
        public void DescribeSoftphoneScreenPopOptionClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new DescribeSoftphoneScreenPopOption();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["matchType"] = DummyString,
                ["screenPopData"] = DummyString,
                ["screenPopType"] = DummyString,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }
        [TestMethod]
        public void EmailHeaderClass_Properties_TestGetterAndSetter()
        {
            // Arrange
            var testEntity = new EmailHeader();
            var privateObject = new PrivateObject(testEntity);
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["triggerAutoResponseEmail"] = true,
                ["triggerOtherEmail"] = true,
                ["triggerUserEmail"] = true,
            };

            // Act
            SetProperties(privateObject, propertiesDictionary);

            // Assert
            AssertProperties(privateObject, propertiesDictionary);
        }

        private void SetProperties(PrivateObject privateObject, Dictionary<string, object> propertiesDictionary)
        {
            foreach (var kvp in propertiesDictionary)
            {
                privateObject.SetProperty(kvp.Key, kvp.Value);
            }
        }

        private void AssertProperties(PrivateObject privateObject, Dictionary<string, object> propertiesDictionary)
        {
            var assertions = new List<Action>();
            foreach (var kvp in propertiesDictionary)
            {
                assertions.Add(() => privateObject.GetProperty(kvp.Key).ShouldBe(kvp.Value));
            }
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }
    }
}
