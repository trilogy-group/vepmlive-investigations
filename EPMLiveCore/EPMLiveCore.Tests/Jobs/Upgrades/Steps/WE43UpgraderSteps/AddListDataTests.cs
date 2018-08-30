using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    [TestClass]
    public class AddListDataTests
    {
        private AddListData _testObj;
        private PrivateObject _privateObj;
        private IDisposable _shimsContext;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            InitializeObjects(true);
        }

        private void InitializeObjects(bool bispfe)
        {
            var data = "data";
            var stepNumber = 1;
            var web = new ShimSPWeb()
            {
                SiteGet = () => new ShimSPSite()
                {
                    IDGet = () => Guid.Empty,
                    WebApplicationGet = () => new ShimSPWebApplication()
                    {
                        FeaturesGet = () => new ShimSPFeatureCollection()
                        {
                            ItemGetGuid = _ => null
                        }.Instance
                    }
                }.Instance
            }.Instance;

            _testObj = new AddListData(web, data, stepNumber, bispfe);
            _privateObj = new PrivateObject(_testObj);
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
        }

        [TestMethod]
        public void ProcessResources_WhenCalled_UpdatesListItem()
        {
            // Arrange
            const string mapId = "mapId";
            const string folderUrl = "folderUrl";

            var actual = false;
            var oResourcePool = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = _ => new ShimSPField()
                },
                ItemsGet = () => new ShimSPListItemCollection()
                {
                    GetEnumerator = () => new List<SPListItem>()
                    {
                        new ShimSPListItem()
                        {
                            IDGet = () => 1
                        }
                    }.GetEnumerator()
                },
                GetItemByIdInt32 = _ => new ShimSPListItem()
                {
                    IDGet = () => 1,
                    ItemGetString = __ => mapId,
                    Update = () =>
                    {
                        actual = true;
                    }
                }
            }.Instance;

            // Act
            _privateObj.Invoke("ProcessResources", BindingFlags.Instance | BindingFlags.NonPublic, new object[] { oResourcePool });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void ProcessNonWork_WhenCalled_UpdatesListItem()
        {
            // Arrange
            const string choice1 = "choice1";

            var actual = false;
            var oResourcePool = new ShimSPList().Instance;

            ShimSPWeb.AllInstances.ListsGet = (spWeb) => new ShimSPListCollection()
            {
                TryGetListString = input =>
                {
                    if (input == "Non Work")
                    {
                        return new ShimSPList()
                        {
                            ItemsGet = () => new ShimSPListItemCollection()
                            {
                                GetDataTable = () =>
                                {
                                    var dTable = new DataTable();

                                    dTable.Columns.Add("Title");
                                    var row = dTable.NewRow();
                                    row["Title"] = $"{choice1}{choice1}";
                                    dTable.Rows.Add(row);

                                    return dTable;
                                },
                                Add = () => new ShimSPListItem()
                                {
                                    ItemGetString = (key) => choice1,
                                    Update = () =>
                                    {
                                        actual = true;
                                    }
                                }
                            }
                        };
                    }

                    return new ShimSPList()
                    {
                        FieldsGet = () => new ShimSPFieldCollection()
                        {
                            GetFieldByInternalNameString = _ => new ShimSPFieldChoice()
                        }
                    };
                }
            };

            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Choice;
            ShimSPFieldMultiChoice.AllInstances.ChoicesGet = _ => new StringCollection()
            {
                choice1
            };

            // Act
            _privateObj.Invoke("ProcessNonWork", BindingFlags.Instance | BindingFlags.NonPublic, new object[] { oResourcePool });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void ProcessWorkHours_bIsPfeTrue_UpdatesAndDeletes()
        {
            // Arrange
            var updateActual = false;
            var deleteActual = false;
            var oResourcePool = new ShimSPList().Instance;

            const bool updateExpected = true;
            const bool deleteExpected = true;

            ShimSPWeb.AllInstances.ListsGet = (spWeb) => new ShimSPListCollection()
            {
                TryGetListString = input =>
                {
                    return new ShimSPList()
                    {
                        ItemsGet = () => new ShimSPListItemCollection()
                        {
                            Add = () => new ShimSPListItem()
                            {
                                ItemGetString = (key) => "someValue",
                                Update = () =>
                                {
                                    updateActual = true;
                                },
                                Delete = () =>
                                {
                                    deleteActual = true;
                                }
                            }
                        }
                    };
                }
            };

            // Act
            _privateObj.Invoke("ProcessWorkHours", BindingFlags.Instance | BindingFlags.NonPublic, new object[] { oResourcePool });

            // Assert
            Assert.AreEqual(updateExpected, updateActual);
            Assert.AreEqual(deleteExpected, deleteActual);
        }

        [TestMethod]
        public void ProcessWorkHours_bIsPfeFalse_UpdatesAndDeletes()
        {
            // Arrange
            var updateActual = false;
            var deleteActual = false;
            var oResourcePool = new ShimSPList().Instance;

            const bool updateExpected = true;
            const bool deleteExpected = false;

            ShimSPWeb.AllInstances.ListsGet = (spWeb) => new ShimSPListCollection()
            {
                TryGetListString = input =>
                {
                    return new ShimSPList()
                    {
                        ItemsGet = () => new ShimSPListItemCollection()
                        {
                            Add = () => new ShimSPListItem()
                            {
                                ItemGetString = (key) => "someValue",
                                Update = () =>
                                {
                                    updateActual = true;
                                },
                                Delete = () =>
                                {
                                    deleteActual = true;
                                }
                            }
                        }
                    };
                }
            };

            InitializeObjects(false);

            // Act
            _privateObj.Invoke("ProcessWorkHours", BindingFlags.Instance | BindingFlags.NonPublic, new object[] { oResourcePool });

            // Assert
            Assert.AreEqual(updateExpected, updateActual);
            Assert.AreEqual(deleteExpected, deleteActual);
        }

        [TestMethod]
        public void ProcessHolidays_bIsPfeTrue_UpdatesAndDeletes()
        {
            // Arrange
            var updateActual = false;
            var deleteActual = false;
            var oResourcePool = new ShimSPList().Instance;

            const bool updateExpected = true;
            const bool deleteExpected = true;

            ShimSPWeb.AllInstances.ListsGet = (spWeb) => new ShimSPListCollection()
            {
                TryGetListString = input =>
                {
                    return new ShimSPList()
                    {
                        ItemsGet = () => new ShimSPListItemCollection()
                        {
                            Add = () => new ShimSPListItem()
                            {
                                ItemGetString = (key) => "someValue",
                                Update = () =>
                                {
                                    updateActual = true;
                                },
                                Delete = () =>
                                {
                                    deleteActual = true;
                                    throw new Exception();
                                }
                            }
                        }
                    };
                }
            };

            // Act
            _privateObj.Invoke("ProcessHolidays", BindingFlags.Instance | BindingFlags.NonPublic, new object[] { oResourcePool });

            // Assert
            Assert.AreEqual(updateExpected, updateActual);
            Assert.AreEqual(deleteExpected, deleteActual);
        }

        [TestMethod]
        public void ProcessHolidays_bIsPfeFalse_Updates()
        {
            // Arrange
            var updateHolidaysActual = false;
            var deleteHolidaysActual = false;
            var updateSchedulesActual = false;
            var deleteSchedulesActual = false;
            var updateListItemActual = false;
            var oResourcePool = new ShimSPList().Instance;

            const bool updateHolidaysExpected = false;
            const bool deleteHolidaysExpected = false;
            const bool updateSchedulesExpected = true;
            const bool deleteSchedulesExpected = false;
            const bool updateListItemExpected = true;

            ShimSPWeb.AllInstances.ListsGet = (spWeb) => new ShimSPListCollection()
            {
                TryGetListString = input =>
                {
                    if (input == "Holidays")
                    {
                        return new ShimSPList()
                        {
                            ItemsGet = () => new ShimSPListItemCollection()
                            {
                                Add = () => new ShimSPListItem()
                                {
                                    ItemGetString = (key) => "someValue",
                                    Update = () =>
                                    {
                                        updateHolidaysActual = true;
                                    },
                                    Delete = () =>
                                    {
                                        deleteHolidaysActual = true;
                                    }
                                },
                                GetEnumerator = () => new List<SPListItem>()
                                {
                                    new ShimSPListItem()
                                    {
                                        ItemGetString = (key) => "someValue",
                                        ItemGetGuid = (guid) => null,
                                        Update = () =>
                                        {
                                            updateListItemActual = true;
                                        }
                                    }
                                }.GetEnumerator()
                            },
                            FieldsGet = () => new ShimSPFieldCollection()
                            {
                                GetFieldByInternalNameString = _ => new ShimSPField()
                                {
                                    IdGet = () => Guid.Empty
                                }
                            }
                        };
                    }

                    return new ShimSPList()
                    {
                        ItemsGet = () => new ShimSPListItemCollection()
                        {
                            Add = () => new ShimSPListItem()
                            {
                                ItemGetString = (key) => "someValue",
                                Update = () =>
                                {
                                    updateSchedulesActual = true;
                                },
                                Delete = () =>
                                {
                                    deleteSchedulesActual = true;
                                }
                            }
                        }
                    };
                }
            };

            ShimSPFieldLookupValue.ConstructorInt32String = (_, _1, _2) => new ShimSPFieldLookupValue();

            InitializeObjects(false);

            // Act
            _privateObj.Invoke("ProcessHolidays", BindingFlags.Instance | BindingFlags.NonPublic, new object[] { oResourcePool });

            // Assert
            Assert.AreEqual(updateHolidaysExpected, updateHolidaysActual);
            Assert.AreEqual(deleteHolidaysExpected, deleteHolidaysActual);
            Assert.AreEqual(updateSchedulesExpected, updateSchedulesActual);
            Assert.AreEqual(deleteSchedulesExpected, deleteSchedulesActual);
            Assert.AreEqual(updateListItemExpected, updateListItemActual);
        }

        [TestMethod]
        public void ProcessRoles_bIsPfeTrue_UpdatesAndDeletes()
        {
            // Arrange
            var updateActual = false;
            var deleteActual = false;
            var deleteListItemActual = false;
            var oResourcePool = new ShimSPList().Instance;

            const bool updateExpected = true;
            const bool deleteExpected = true;
            const bool deleteListItemExpected = true;
            const int itemToBeDeleted = 1;

            ShimSPWeb.AllInstances.ListsGet = (spWeb) => new ShimSPListCollection()
            {
                TryGetListString = input =>
                {
                    return new ShimSPList()
                    {
                        ItemsGet = () => new ShimSPListItemCollection()
                        {
                            Add = () => new ShimSPListItem()
                            {
                                ItemGetString = (key) => "someValue",
                                Update = () =>
                                {
                                    updateActual = true;
                                },
                                Delete = () =>
                                {
                                    deleteActual = true;
                                    throw new Exception();
                                }
                            },
                            GetEnumerator = () => new List<SPListItem>()
                            {
                                new ShimSPListItem()
                                {
                                    IDGet = () => itemToBeDeleted,
                                    ItemGetString = _ => "TEMPROLEDELETEME"
                                }
                            }.GetEnumerator()
                        },
                        GetItemByIdInt32 = (key) => new ShimSPListItem()
                        {
                            Delete = () =>
                            {
                                deleteListItemActual = true;
                            }
                        }
                    };
                }
            };

            // Act
            _privateObj.Invoke("ProcessRoles", BindingFlags.Instance | BindingFlags.NonPublic, new object[] { oResourcePool });

            // Assert
            Assert.AreEqual(updateExpected, updateActual);
            Assert.AreEqual(deleteExpected, deleteActual);
            Assert.AreEqual(deleteListItemExpected, deleteListItemActual);
        }

        [TestMethod]
        public void ProcessRoles_bIsPfeFalse_Updates()
        {
            // Arrange
            var updateActual = false;
            var deleteActual = false;

            var oResourcePool = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = (key) => new ShimSPFieldChoice()
                    {
                    }
                }
            }.Instance;

            const bool updateExpected = true;
            const bool deleteExpected = false;
            const string choice1 = "choice1";

            ShimSPWeb.AllInstances.ListsGet = (spWeb) => new ShimSPListCollection()
            {
                TryGetListString = input =>
                {
                    return new ShimSPList()
                    {
                        ItemsGet = () => new ShimSPListItemCollection()
                        {
                            Add = () => new ShimSPListItem()
                            {
                                ItemGetString = (key) => "someValue",
                                Update = () =>
                                {
                                    updateActual = true;
                                },
                                Delete = () =>
                                {
                                    deleteActual = true;
                                }
                            },
                            GetDataTable = () =>
                            {
                                var dTable = new DataTable();

                                dTable.Columns.Add("Title");
                                var row = dTable.NewRow();
                                row["Title"] = $"{choice1}{choice1}";
                                dTable.Rows.Add(row);

                                return dTable;
                            }
                        }
                    };
                }
            };

            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Choice;
            ShimSPFieldMultiChoice.AllInstances.ChoicesGet = _ => new StringCollection()
            {
                choice1
            };

            InitializeObjects(false);

            // Act
            _privateObj.Invoke("ProcessRoles", BindingFlags.Instance | BindingFlags.NonPublic, new object[] { oResourcePool });

            // Assert
            Assert.AreEqual(updateExpected, updateActual);
            Assert.AreEqual(deleteExpected, deleteActual);
        }

        [TestMethod]
        public void ProcessDepartments_bIsPfeTrue_UpdatesAndDeletes()
        {
            // Arrange
            var updateActual = false;
            var deleteActual = false;
            var deleteListItemActual = false;
            var oResourcePool = new ShimSPList()
            {
                ItemsGet = () => new ShimSPListItemCollection()
                {
                    ItemGetInt32 = (key) => new ShimSPListItem()
                    {
                        IDGet = () => 1,
                        TitleGet = () => "Title"
                    }
                }                
            }.Instance;

            const bool updateExpected = true;
            const bool deleteExpected = true;
            const bool deleteListItemExpected = true;
            const int itemToBeDeleted = 1;

            ShimSPWeb.AllInstances.ListsGet = (spWeb) => new ShimSPListCollection()
            {
                TryGetListString = input =>
                {
                    return new ShimSPList()
                    {
                        ItemsGet = () => new ShimSPListItemCollection()
                        {
                            Add = () => new ShimSPListItem()
                            {
                                ItemGetString = (key) => "someValue",
                                Update = () =>
                                {
                                    updateActual = true;
                                },
                                Delete = () =>
                                {
                                    deleteActual = true;
                                    throw new Exception();
                                }
                            },
                            GetEnumerator = () => new List<SPListItem>()
                            {
                                new ShimSPListItem()
                                {
                                    IDGet = () => itemToBeDeleted,
                                    ItemGetString = _ => "TEMPDEPTDELETEME"
                                }
                            }.GetEnumerator()
                        },
                        GetItemByIdInt32 = (key) => new ShimSPListItem()
                        {
                            Delete = () =>
                            {
                                deleteListItemActual = true;
                            }
                        }
                    };
                }
            };

            ShimSPFieldLookupValue.ConstructorInt32String = (_, _1, _2) => new ShimSPFieldLookupValue();

            // Act
            _privateObj.Invoke("ProcessDepartments", BindingFlags.Instance | BindingFlags.NonPublic, new object[] { oResourcePool });

            // Assert
            Assert.AreEqual(updateExpected, updateActual);
            Assert.AreEqual(deleteExpected, deleteActual);
            Assert.AreEqual(deleteListItemExpected, deleteListItemActual);
        }

        [TestMethod]
        public void ProcessDepartments_bIsPfeFalse_Updates()
        {
            // Arrange
            var updateActual = false;
            var deleteActual = false;

            var oResourcePool = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = (key) => new ShimSPFieldChoice()
                    {
                    }
                }
            }.Instance;

            const bool updateExpected = true;
            const bool deleteExpected = false;
            const string choice1 = "choice1";

            ShimSPWeb.AllInstances.ListsGet = (spWeb) => new ShimSPListCollection()
            {
                TryGetListString = input =>
                {
                    return new ShimSPList()
                    {
                        ItemsGet = () => new ShimSPListItemCollection()
                        {
                            Add = () => new ShimSPListItem()
                            {
                                ItemGetString = (key) => "someValue",
                                Update = () =>
                                {
                                    updateActual = true;
                                },
                                Delete = () =>
                                {
                                    deleteActual = true;
                                }
                            },
                            GetDataTable = () =>
                            {
                                var dTable = new DataTable();

                                dTable.Columns.Add("Title");
                                var row = dTable.NewRow();
                                row["Title"] = $"{choice1}{choice1}";
                                dTable.Rows.Add(row);

                                return dTable;
                            }
                        }
                    };
                }
            };

            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Choice;
            ShimSPFieldMultiChoice.AllInstances.ChoicesGet = _ => new StringCollection()
            {
                choice1
            };

            InitializeObjects(false);

            // Act
            _privateObj.Invoke("ProcessDepartments", BindingFlags.Instance | BindingFlags.NonPublic, new object[] { oResourcePool });

            // Assert
            Assert.AreEqual(updateExpected, updateActual);
            Assert.AreEqual(deleteExpected, deleteActual);
        }

        [TestMethod]
        public void Perform_WhenCalled_ReturnsTrue()
        {
            // Arrange
            const bool expected = true;

            ShimSPWeb.AllInstances.ListsGet = (spWeb) => new ShimSPListCollection()
            {
                TryGetListString = input =>
                {
                    if (input == "Resources")
                    {
                        return new ShimSPList();
                    }

                    return null;
                }
            };

            // Act
            var actual = (bool)_privateObj.Invoke("Perform");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
