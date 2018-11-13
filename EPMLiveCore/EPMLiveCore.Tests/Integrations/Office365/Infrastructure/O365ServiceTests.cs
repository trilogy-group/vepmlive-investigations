using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Security;
using EPMLiveCore.Integrations.Office365.Infrastructure;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Integrations.Office365.Infrastructure
{
    [TestClass, ExcludeFromCodeCoverage]
    public class O365ServiceTests
    {
        private IDisposable _shimContext;
        private PrivateObject _privateObject;
        private O365Service _o365Service;
        private readonly AESCryptographyService _cryptographyService = new AESCryptographyService();

        private const string MessageFromAppInstalled = "List 'EPMLiveIntegrations' does not exist";

        private const int DummyItemId = 100;
        private const string DummyUserName = "DummyUserName";
        private const string DummySiteUrl = "http://tempuri.org";
        private const string DummyApiUrl = "http://tempapi.org";
        private const string DummyTitle = "DummyTitle";
        private const string DummyTitleStartWithA = "ADummyTitle";
        private const string DummyListName = "DummyListName";
        private const string DummyString = "DummyString";
        private const string GroupHidden = "_Hidden";
        private const string GroupAny = "Any";
        private const string DummyColumn = "DummyColumn";
        private const string DummyIntegrationKey = "DummyIntegrationKey";
        private const string DummyEmail = "dummy@email.com";
        private const int DummyInt = 1;
        private readonly static SecureString DummySecurePassword = "DummyPassword".ToSecureString();
        private readonly static Guid GuidGroupAny = Guid.NewGuid();
        private readonly static Guid GuidGroupHidden = Guid.NewGuid();
        private readonly static Guid IntegrationId = Guid.NewGuid();

        [TestInitialize]
        public void Initialize()
        {
            _shimContext = ShimsContext.Create();
            _o365Service = new O365Service(DummyUserName, DummySecurePassword, DummySiteUrl);
            _privateObject = new PrivateObject(_o365Service);

            ShimClientContext.AllInstances.WebGet = sender => new ShimWeb()
            {
                ListsGet = () => new ShimListCollection()
                {
                    GetByTitleString = title => new ShimList()
                    {
                        GetItemByIdInt32 = id => new ShimListItem()
                        {
                            DeleteObject = () => { }
                        }
                    }
                }
            };
            ShimClientContext.AllInstances.ExecuteQuery = sender => { };
            ShimSharePointOnlineCredentials.ConstructorStringSecureString = (sender, userName, password) => new ShimSharePointOnlineCredentials();

            ShimClientRuntimeContext.AllInstances.LoadOf1M0ExpressionOfFuncOfM0ObjectArray<ClientObject>((sender, client, retrievals) => { });
            ShimClientRuntimeContext.AllInstances.LoadOf1M0ExpressionOfFuncOfM0ObjectArray<List>((sender, client, retrievals) => { });
            ShimClientRuntimeContext.AllInstances.LoadOf1M0ExpressionOfFuncOfM0ObjectArray<ListItem>((sender, client, retrievals) => { });
            ShimClientRuntimeContext.AllInstances.LoadOf1M0ExpressionOfFuncOfM0ObjectArray<ListCollection>((sender, client, retrievals) => { });
            ShimClientRuntimeContext.AllInstances.LoadOf1M0ExpressionOfFuncOfM0ObjectArray<FieldCollection>((sender, client, retrievals) => { });
            ShimClientRuntimeContext.AllInstances.LoadOf1M0ExpressionOfFuncOfM0ObjectArray<ListItemCollection>((sender, client, retrievals) => { });
        }

        [TestCleanup]
        public void Cleanup()
        {
            _shimContext?.Dispose();
        }

        [TestMethod]
        public void DeleteListItemsById_ArrayId_ReturnsO365Result()
        {
            // Arrange
            var itemsId = new[]
            {
                DummyItemId.ToString()
            };

            // Act
            var actualResult = (List<O365Result>)_o365Service.DeleteListItemsById(itemsId, DummyListName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Count.ShouldBe(1),
                () => actualResult[0].ShouldNotBeNull(),
                () => actualResult[0].Success.ShouldBeTrue(),
                () => actualResult[0].TransactionType.ShouldBe(EPMLiveIntegration.TransactionType.DELETE),
                () => actualResult[0].ItemId.ShouldBe(DummyItemId),
                () => actualResult[0].Error.ShouldBeNullOrEmpty());
        }

        [TestMethod]
        public void DeleteListItemsById__ReturnsO365ResultFailDelete_ReturnsO365Result()
        {
            // Arrange
            var itemsId = new[]
            {
                DummyItemId.ToString()
            };

            ShimClientContext.AllInstances.WebGet = sender => new ShimWeb()
            {
                ListsGet = () => new ShimListCollection()
                {
                    GetByTitleString = title => new ShimList()
                    {
                        GetItemByIdInt32 = id => new ShimListItem()
                        {
                            DeleteObject = () =>
                            {
                                throw new Exception();
                            }
                        }
                    }
                }
            };

            // Act
            var actualResult = (List<O365Result>)_o365Service.DeleteListItemsById(itemsId, DummyListName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Count.ShouldBe(1),
                () => actualResult[0].ShouldNotBeNull(),
                () => actualResult[0].Success.ShouldBeFalse(),
                () => actualResult[0].TransactionType.ShouldBe(EPMLiveIntegration.TransactionType.DELETE),
                () => actualResult[0].ItemId.ShouldBe(DummyItemId),
                () => actualResult[0].Error.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void EnsureEPMLiveAppInstalled_LoadList_ReturnsTrue()
        {
            // Arrange, Act
            var actualResult = _o365Service.EnsureEPMLiveAppInstalled();

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void EnsureEPMLiveAppInstalled_LoadListDoesNotExists_ReturnsFalse()
        {
            // Arrange
            ShimClientRuntimeContext.AllInstances.LoadOf1M0ExpressionOfFuncOfM0ObjectArray<List>(
                (sender, client, retrievals) =>
                {
                    throw new Exception(MessageFromAppInstalled);
                });

            // Act
            var actualResult = _o365Service.EnsureEPMLiveAppInstalled();

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void EnsureEPMLiveAppInstalled_LoadListException_ThrowsException()
        {
            // Arrange
            ShimClientRuntimeContext.AllInstances.LoadOf1M0ExpressionOfFuncOfM0ObjectArray<List>(
                (sender, client, retrievals) =>
                {
                    throw new Exception();
                });

            // Act
            Action action = () => _o365Service.EnsureEPMLiveAppInstalled();

            // Assert
            action.ShouldThrow<Exception>().Message.ShouldBe("Exception of type 'System.Exception' was thrown.");
        }

        [TestMethod]
        public void GetIntegratableLists_Called_ReturnsDictionary()
        {
            // Arrange
            ShimClientContext.AllInstances.WebGet = sender => new ShimWeb()
            {
                ListsGet = () => new ShimListCollection()
                {
                    GetByTitleString = title => new ShimList()
                    {
                        GetItemByIdInt32 = id => new ShimListItem()
                        {
                            DeleteObject = () => { }
                        }
                    }
                }.Bind(
                    new List<List>()
                    {
                        new ShimList()
                        {
                            HiddenGet = () => false,
                            TitleGet = () => DummyTitle
                        },
                        new ShimList()
                        {
                            HiddenGet = () => false,
                            TitleGet = () => DummyTitleStartWithA
                        }
                    })
            };

            // Act
            var actualResult = _o365Service.GetIntegratableLists();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Count.ShouldBe(2),
                () => actualResult.ContainsKey(DummyTitle).ShouldBeTrue(),
                () => actualResult[DummyTitle].ShouldBe(DummyTitle),
                () => actualResult.ContainsKey(DummyTitleStartWithA).ShouldBeTrue(),
                () => actualResult[DummyTitleStartWithA].ShouldBe(DummyTitleStartWithA));
        }

        [TestMethod]
        public void GetListFields_Call_ReturnsDictionaryWithoutHiddenGroup()
        {
            // Arrange
            ShimClientContext.AllInstances.WebGet = sender => new ShimWeb()
            {
                ListsGet = () => new ShimListCollection()
                {
                    GetByTitleString = title => new ShimList()
                    {
                        FieldsGet = () => new ShimFieldCollection().Bind(new List<Field>()
                        {
                            new ShimField()
                            {
                                HiddenGet = () => false,
                                GroupGet = () => GroupAny,
                                IdGet = () => GuidGroupAny
                            },
                            new ShimField()
                            {
                                HiddenGet = () => false,
                                GroupGet = () => GroupHidden,
                                IdGet = () => GuidGroupHidden
                            }
                        })
                    }
                }
            };

            // Act
            var actualResult = (List<Field>)_o365Service.GetListFields(DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Count.ShouldBe(1),
                () => actualResult.Find(x => x.Id == GuidGroupAny).ShouldNotBeNull(),
                () => actualResult.Find(x => x.Id == GuidGroupHidden).ShouldBeNull());
        }

        [TestMethod]
        public void GetListItems_Should_AddRowsInDataTable()
        {
            // Arrange
            var userField = new ShimField(
                new ShimFieldLookup(new ShimFieldUser())
                {
                    AllowMultipleValuesGet = () => false
                })
            {
                InternalNameGet = () => "UserField",
                FieldTypeKindGet = () => FieldType.User
            };

            var lookupUser = new ShimField(new ShimFieldLookup()
            {
                AllowMultipleValuesGet = () => false
            })
            {
                InternalNameGet = () => "LookupField",
                FieldTypeKindGet = () => FieldType.Lookup
            };

            var userFieldAllowMultipleValues = new ShimField(new ShimFieldLookup(new ShimFieldUser())
            {
                AllowMultipleValuesGet = () => true
            })
            {
                InternalNameGet = () => "UserField",
                FieldTypeKindGet = () => FieldType.User
            };

            var lookupUserAllowMultipleValues = new ShimField(new ShimFieldLookup()
            {
                AllowMultipleValuesGet = () => true
            })
            {
                InternalNameGet = () => "LookupField",
                FieldTypeKindGet = () => FieldType.Lookup
            };

            ShimClientContext.AllInstances.WebGet = sender => new ShimWeb()
            {
                ListsGet = () => new ShimListCollection()
                {
                    GetByTitleString = title => new ShimList()
                    {
                        GetItemByIdInt32 = id => new ShimListItem()
                        {
                            DeleteObject = () => { }
                        },
                        GetItemsCamlQuery = query => new ShimListItemCollection().Bind(new List<ListItem>()
                        {
                            new ShimListItem()
                            {
                                FieldValuesGet = () =>
                                {
                                    var fieldsValues = new Dictionary<string, object>
                                    {
                                        {
                                            "UserField", new FieldUserValue()
                                            {
                                                LookupId = 123
                                            }
                                        },
                                        { "LookupField", new FieldLookupValue() }
                                    };

                                    return fieldsValues;
                                }
                            }
                        }),
                        FieldsGet = () => new ShimFieldCollection().Bind(
                            new List<Field>()
                            {
                                userField,
                                lookupUser,
                                userFieldAllowMultipleValues,
                                lookupUserAllowMultipleValues
                            })
                    }
                }
            };

            var listName = string.Empty;
            var items = new DataTable();
            items.Columns.Add("UserField", typeof(string));
            var dataRow = items.NewRow();
            dataRow[0] = DummyString;
            items.Rows.Add(dataRow);

            var lastSynchDate = new DateTime(2018, 2, 2);

            // Act
            _o365Service.GetListItems(listName, items, lastSynchDate);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => items.Rows.Count.ShouldBe(2),
                () => ((string)items.Rows[1][0]).ShouldBeNullOrEmpty());
        }

        [TestMethod]
        public void GetListItemsById_Should_AddRowsInDataTable()
        {
            // Arrange
            var userField = new ShimField(
                new ShimFieldLookup(new ShimFieldUser())
                {
                    AllowMultipleValuesGet = () => false
                })
            {
                InternalNameGet = () => "UserField",
                FieldTypeKindGet = () => FieldType.User
            };

            ShimClientContext.AllInstances.WebGet = sender => new ShimWeb()
            {
                ListsGet = () => new ShimListCollection()
                {
                    GetByTitleString = title => new ShimList()
                    {
                        GetItemByIdInt32 = id => new ShimListItem()
                        {
                            FieldValuesGet = () =>
                            {
                                var fieldsValues = new Dictionary<string, object>
                                {
                                    {
                                        "UserField", new FieldUserValue()
                                        {
                                            LookupId = 123
                                        }
                                    }
                                };

                                return fieldsValues;
                            }
                        },
                        FieldsGet = () => new ShimFieldCollection().Bind(
                            new List<Field>()
                            {
                                userField
                            })
                    }
                }
            };

            var listName = string.Empty;
            var items = new DataTable();
            items.Columns.Add("UserField", typeof(string));
            var dataRow = items.NewRow();
            dataRow[0] = DummyString;
            items.Rows.Add(dataRow);

            var itemIds = "1";

            // Act
            _o365Service.GetListItemsById(listName, itemIds, items);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => items.Rows.Count.ShouldBe(2),
                () => ((string)items.Rows[1][0]).ShouldBeNullOrEmpty());
        }

        [TestMethod]
        public void InstallIntegration_PassParameter_UpdateListItemWithParameters()
        {
            // Arrange
            var actualUpdated = false;
            var actualO365List = string.Empty;
            var actualAllowIncoming = false;
            var actualAllowOutgoing = false;
            var actualAllowDeletion = false;
            var actualActive = false;
            var actualIntId = string.Empty;
            var actualControlButtons = string.Empty;
            var actualApiEndpoint = string.Empty;
            var actualIntKey = string.Empty;
            var actualEpmWeb = string.Empty;
            var actualEpmWebUrl = string.Empty;

            ShimClientContext.AllInstances.WebGet = sender => new ShimWeb()
            {
                ListsGet = () => new ShimListCollection()
                {
                    GetByTitleString = title => new ShimList()
                    {
                        GetItemByIdInt32 = id => new ShimListItem()
                        {
                            DeleteObject = () => { }
                        },
                        AddItemListItemCreationInformation = listItemCreationInformation => new ShimListItem()
                        {
                            ItemSetStringObject = (item, newValue) =>
                            {
                                switch (item)
                                {
                                    case "O365List":
                                        actualO365List = (string)newValue;
                                        break;
                                    case "AllowIncoming":
                                        actualAllowIncoming = (bool)newValue;
                                        break;
                                    case "AllowOutgoing":
                                        actualAllowOutgoing = (bool)newValue;
                                        break;
                                    case "AllowDeletion":
                                        actualAllowDeletion = (bool)newValue;
                                        break;
                                    case "Active":
                                        actualActive = (bool)newValue;
                                        break;
                                    case "IntID":
                                        actualIntId = (string)newValue;
                                        break;
                                    case "ControlButtons":
                                        actualControlButtons = (string)newValue;
                                        break;
                                    case "APIEndpoint":
                                        actualApiEndpoint = (string)newValue;
                                        break;
                                    case "IntKey":
                                        actualIntKey = (string)newValue;
                                        break;
                                    case "EPMWeb":
                                        actualEpmWeb = (string)newValue;
                                        break;
                                    case "EPMWebUrl":
                                        actualEpmWebUrl = (string)newValue;
                                        break;
                                    default:
                                        break;
                                }
                            },
                            Update = () => actualUpdated = true
                        }
                    }
                }
            };

            var integrationId = Guid.NewGuid();
            var integrationKey = DummyIntegrationKey;
            var apiUrl = DummyApiUrl;
            var webTitle = DummyTitle;
            var webUrl = DummySiteUrl;
            var enabledFeatures = new ArrayList
            {
                "workplan",
                "comments",
                "associated",
                "costplan",
                "resplan",
                "team"
            };
            var listName = DummyString;
            var allowIncoming = true;
            var allowOutgoing = true;
            var allowDeletion = true;

            // Act
            _o365Service.InstallIntegration(
                integrationId,
                integrationKey,
                apiUrl,
                webTitle,
                webUrl,
                enabledFeatures,
                listName,
                allowIncoming,
                allowOutgoing,
                allowDeletion);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualUpdated.ShouldBeTrue(),
                () => actualO365List.ShouldBe(DummyString),
                () => actualAllowIncoming.ShouldBeTrue(),
                () => actualAllowOutgoing.ShouldBeTrue(),
                () => actualAllowDeletion.ShouldBeTrue(),
                () => actualActive.ShouldBeTrue(),
                () => actualIntId.ShouldBe(integrationId.ToString()),
                () => actualControlButtons.ShouldBe("WorkPlan,Comments,Associated,CostPlan,ResPlan,Team"),
                () => actualApiEndpoint.ShouldBe(DummyApiUrl),
                () => actualIntKey.ShouldBe(DummyIntegrationKey),
                () => actualEpmWeb.ShouldBe(DummyTitle),
                () => actualEpmWebUrl.ShouldBe(DummySiteUrl));
        }

        [TestMethod]
        public void UninstallIntegration_PassParameters_DeleteListItem()
        {
            // Arrange
            var actualDeleteObject = false;
            var integrationKey = DummyIntegrationKey;
            var integrationId = Guid.NewGuid();

            ShimClientContext.AllInstances.WebGet = sender => new ShimWeb()
            {
                ListsGet = () => new ShimListCollection()
                {
                    GetByTitleString = title => new ShimList()
                    {
                        GetItemsCamlQuery = query => new ShimListItemCollection().Bind(new List<ListItem>()
                        {
                            new ShimListItem()
                            {
                                ItemGetString = item =>
                                {
                                    if (item == "IntKey")
                                    {
                                        return _cryptographyService.Encrypt(DummyIntegrationKey);
                                    }

                                    if (item == "IntID")
                                    {
                                        return _cryptographyService.Encrypt(integrationId.ToString());
                                    }

                                    return null;
                                },
                                DeleteObject = () => actualDeleteObject = true
                            },
                        })
                    }
                }
            };

            // Act
            _o365Service.UninstallIntegration(integrationKey, integrationId);

            // Assert
            actualDeleteObject.ShouldBeTrue();
        }

        [TestMethod]
        public void UpsertItems_OnSuccess_ReturnsIEnumerableO365Result()
        {
            // Arrange
            var actualCountUpdated = 0;

            var listName = DummyTitle;
            var dataTable = new DataTable();
            dataTable.Columns.Add("ID");

            var rowWithoutId = dataTable.NewRow();
            dataTable.Rows.Add(rowWithoutId);

            var rowWithId = dataTable.NewRow();
            rowWithId[0] = 10;
            dataTable.Rows.Add(rowWithId);

            ShimClientContext.AllInstances.WebGet = sender => new ShimWeb()
            {
                ListsGet = () => new ShimListCollection()
                {
                    GetByTitleString = title => new ShimList()
                    {
                        AddItemListItemCreationInformation = listItemCreationInformation => new ShimListItem()
                        {
                            ItemSetStringObject = (item, newValue) => { },
                            ItemGetString = item =>
                            {
                                switch (item)
                                {
                                    case "Processed":
                                    case "Success":
                                        return true;
                                    case "ItemID":
                                        return "20";
                                    default:
                                        break;
                                }

                                return null;
                            },
                            Update = () => actualCountUpdated++,
                            DeleteObject = () => { }
                        }
                    }
                }
            };

            // Act
            var actualResult = (List<O365Result>)_o365Service.UpsertItems(listName, IntegrationId, dataTable);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Count.ShouldBe(2),
                () => actualResult[0].ShouldNotBeNull(),
                () => actualResult[0].Success.ShouldBeTrue(),
                () => actualResult[0].TransactionType.ShouldBe(EPMLiveIntegration.TransactionType.INSERT),
                () => actualResult[0].ItemId.ShouldBe(20),
                () => actualResult[0].Error.ShouldBeNullOrEmpty(),
                () => actualResult[1].ShouldNotBeNull(),
                () => actualResult[1].Success.ShouldBeTrue(),
                () => actualResult[1].TransactionType.ShouldBe(EPMLiveIntegration.TransactionType.UPDATE),
                () => actualResult[1].ItemId.ShouldBe(20),
                () => actualResult[1].Error.ShouldBeNullOrEmpty());
        }

        [TestMethod]
        public void UpsertItems_OnFail_ReturnsIEnumerableO365Result()
        {
            // Arrange
            var listName = DummyTitle;
            var dataTable = new DataTable();
            dataTable.Columns.Add("ID");

            var rowWithoutId = dataTable.NewRow();
            dataTable.Rows.Add(rowWithoutId);

            ShimClientContext.AllInstances.WebGet = sender => new ShimWeb()
            {
                ListsGet = () => new ShimListCollection()
            };

            // Act
            var actualResult = (List<O365Result>)_o365Service.UpsertItems(listName, IntegrationId, dataTable);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Count.ShouldBe(1),
                () => actualResult[0].ShouldNotBeNull(),
                () => actualResult[0].Success.ShouldBeFalse(),
                () => actualResult[0].TransactionType.ShouldBe(EPMLiveIntegration.TransactionType.INSERT),
                () => actualResult[0].ItemId.ShouldBeNull(),
                () => actualResult[0].Error.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void GetClientContext_ExceptionNotMessageRemoteName_throwsException()
        {
            // Arrange
            ShimSharePointOnlineCredentials.ConstructorStringSecureString = (sender, userName, password) =>
            {
                throw new Exception(DummyString);
            };

            // Act
            Action action = () => _privateObject.Invoke("GetClientContext", DummySiteUrl);

            // Assert
            action.ShouldThrow<Exception>().Message.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetFieldValue_LookupFields_ReturnsValues()
        {
            // Arrange
            var listItem = new ShimListItem()
            {
                FieldValuesGet = () =>
                    new Dictionary<string, object>()
                    {
                        { DummyColumn, DummyInt }
                    }
            };
            var userFields = new List<string>();
            var multiUserFields = new List<string>();
            var lookupFields = new List<string>()
            {
                DummyColumn
            };
            var multiLookupFields = new List<string>();

            // Act
            var actualResult = _privateObject.Invoke("GetFieldValue", listItem.Instance, DummyColumn, userFields, multiUserFields, lookupFields, multiLookupFields);

            // Assert
            actualResult.ShouldBe(DummyInt);
        }

        [TestMethod]
        public void GetFieldValue_MultiUserFields_ReturnsValues()
        {
            // Arrange
            var listItem = new ShimListItem()
            {
                FieldValuesGet = () =>
                    new Dictionary<string, object>()
                    {
                        { DummyColumn, new object[] { new ShimFieldUserValue().Instance } }
                    }
            };
            var userFields = new List<string>();
            var multiUserFields = new List<string>()
            {
                DummyColumn
            };
            var lookupFields = new List<string>();
            var multiLookupFields = new List<string>();

            ShimClientObjectCollection.AllInstances.CountGet = sender => 1;
            ShimClientObjectCollection<ListItem>.AllInstances.ItemGetInt32 = (sender, id) => new ShimListItem()
            {
                ItemGetString = itemName => DummyEmail
            };
            ShimClientContext.AllInstances.WebGet = sender => new ShimWeb()
            {
                ListsGet = () => new ShimListCollection()
                {
                    GetByTitleString = title => new ShimList()
                    {
                        GetItemByIdInt32 = id => new ShimListItem()
                        {
                            DeleteObject = () => { }
                        },
                        GetItemsCamlQuery = query => new ShimListItemCollection()
                        {
                            GetByIdInt32 = id => new ShimListItem()
                        }.Bind(
                            new List<ListItem>()
                            {
                                new ShimListItem()
                                {
                                    ItemGetString = item => DummyEmail
                                }
                            }),
                        ItemCountGet = () => 1
                    }
                }
            };

            // Act
            var actualResult = _privateObject.Invoke("GetFieldValue", listItem.Instance, DummyColumn, userFields, multiUserFields, lookupFields, multiLookupFields);

            // Assert
            actualResult.ShouldBe(DummyEmail);
        }

        [TestMethod]
        public void GetFieldValue_MultiLookupFields_ReturnsValues()
        {
            // Arrange
            var listItem = new ShimListItem()
            {
                FieldValuesGet = () =>
                    new Dictionary<string, object>()
                    {
                        {
                            DummyColumn, new object[]
                            {
                                new ShimFieldLookupValue() { LookupIdGet = () => 1 }.Instance,
                                new ShimFieldLookupValue() { LookupIdGet = () => 2 }.Instance
                            }
                        }
                    }
            };
            var userFields = new List<string>();
            var multiUserFields = new List<string>();
            var lookupFields = new List<string>();
            var multiLookupFields = new List<string>()
            {
                DummyColumn
            };

            ShimClientContext.AllInstances.WebGet = sender => new ShimWeb()
            {
                ListsGet = () => new ShimListCollection()
                {
                    GetByTitleString = title => new ShimList()
                    {
                        GetItemByIdInt32 = id => new ShimListItem()
                        {
                            DeleteObject = () => { }
                        },
                        GetItemsCamlQuery = query => new ShimListItemCollection()
                        {
                            GetByIdInt32 = id => new ShimListItem()
                        }.Bind(
                            new List<ListItem>()
                            {
                                new ShimListItem()
                                {
                                    ItemGetString = item => DummyEmail
                                }
                            }),
                        ItemCountGet = () => 1
                    }
                }
            };

            // Act
            var actualResult = _privateObject.Invoke("GetFieldValue", listItem.Instance, DummyColumn, userFields, multiUserFields, lookupFields, multiLookupFields);

            // Assert
            actualResult.ShouldBe("1,2");
        }

        [TestMethod]
        public void FillListFields_DataTableWithColumns_AddColumnsOnListExceptId()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable.Columns.Add("id");
            dataTable.Columns.Add($"{DummyColumn}1");
            dataTable.Columns.Add($"{DummyColumn}2");
            dataTable.Columns.Add($"{DummyColumn}3");
            dataTable.Columns.Add($"{DummyColumn}4");

            var fields = new List<string>();

            // Act
            _privateObject.Invoke("FillListFields", dataTable, fields);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => fields.Count.ShouldBe(4),
                () => fields.ShouldNotContain("id"),
                () => fields.ShouldContain($"{DummyColumn}1"),
                () => fields.ShouldContain($"{DummyColumn}2"),
                () => fields.ShouldContain($"{DummyColumn}3"),
                () => fields.ShouldContain($"{DummyColumn}4"));
        }
    }
}