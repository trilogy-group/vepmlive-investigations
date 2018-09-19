using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using Shouldly;

namespace PortfolioEngineCore.Tests.Resources
{
    [TestClass]
    public class RPEditorDataTests
    {
        private const string DummyString = "DummyString";
        private const string RPEditorDataFullName = "PortfolioEngineCore.RPEditorData";
        private const string PortfolioEngineCoreDllPath = "PortfolioEngineCore.dll";
        private IDisposable shimContext;

        [TestInitialize]
        public void Initialize()
        {
            shimContext = ShimsContext.Create();
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimContext?.Dispose();
        }

        private static Type RPEditorDataType
        {
            get
            {
                var assembly = Assembly.LoadFrom(PortfolioEngineCoreDllPath);
                var type = assembly.GetTypes().FirstOrDefault(p => p.FullName == RPEditorDataFullName);
                return type;
            }
        }

        private MethodInfo GetPublicStaticMethod(string methodName)
        {
            return RPEditorDataType?.GetMethod(methodName, BindingFlags.Static | BindingFlags.Public);
        }

        private MethodInfo GetPrivateStaticMethod(string methodName)
        {
            return RPEditorDataType?.GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic);
        }

        [TestMethod]
        public void BuildResourcePlanGridXML()
        {
            // Arrange
            var dbAcces = new ShimDBAccess().Instance;
            var planData = new ShimCStruct
            {
                GetIntAttrString = name => 0,
                GetSubStructString = name => new ShimCStruct
                {
                    GetSubStructString = _ => new CStruct(),
                    GetListSortedByAttributeStringString = (itemName, attribute) => new SortedList<string, CStruct>
                    {
                        ["1"] = new ShimCStruct
                        {
                            GetStringAttrString = _ => DummyString
                        },
                        ["2"] = new ShimCStruct
                        {
                            GetStringAttrString = _ => string.Empty
                        }
                    }
                }.Instance
            }.Instance;
            var grid = new CStruct();
            var methodInfo = GetPublicStaticMethod("BuildResourcePlanGridXML");
            ShimCStruct.AllInstances.GetSubStructString = (_, name) => new CStruct();
            ShimCStruct.AllInstances.GetStringString = (_, name) => "1,2,3";
            ShimCStruct.AllInstances.GetStringAttrStringString = (_, name, defaultValue) => "1,2";
            var rpCategoryList = new List<CStruct>
            {
                new ShimCStruct
                {
                    GetSubStructString = _ => new ShimCStruct
                    {

                    },
                    GetIntString = _ => 9007
                },
                new ShimCStruct
                {
                    GetIntString = _ => 9020
                }
            };

            var periodList = new List<CStruct>
            {
                new ShimCStruct
                {
                    GetDateAttrString = _ => DateTime.Now,
                    GetStringAttrString = _ => DummyString
                }
            };
            var planRowList = new List<CStruct>
            {
                new ShimCStruct
                {
                    GetIntString = _ => 1,
                    GetStringAttrString = _ => DummyString
                },
                new ShimCStruct
                {
                    GetIntString = _ => 3,
                    GetStringAttrString = _ => DummyString
                }
            };
            

            ShimCStruct.AllInstances.GetListString = (_, name) =>
            {
                switch (name)
                {
                    case "Field":
                        return GetFieldsList();
                    case "RPCategory":
                        return rpCategoryList;
                    case "Period":
                        return periodList;
                    case "PlanRow":
                        return planRowList;
                    default:
                        return new List<CStruct>();
                }
            };

            // Act
            var result = methodInfo?.Invoke(null, new object[] { dbAcces, planData, grid }) as StatusEnum?;


            // Assert
            result.ShouldNotBeNull();
            result.Value.ShouldBe(StatusEnum.rsSuccess);


        }

        [TestMethod]
        public void GetPlanRowCCRole_ListCCRolesContainsItem_ReturnsCStruct()
        {
            // Arrange
            var method = GetPrivateStaticMethod("GetPlanRowCCRole");
            var planRow = new ShimCStruct
            {
                GetIntString = _ => 1
            }.Instance;
            var listCCRoles = new SortedList<string, CStruct>
            {
                ["1"] = new CStruct() { Value = DummyString }
            };

            var listRoles = new SortedList<string, CStruct>
            {
            };

            // Act
            var result = method?.Invoke(null, new object[] { planRow, listCCRoles, listRoles }) as CStruct;

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetPlanRowCCRole_ListRolesContainsItem_ReturnsCStruct()
        {
            // Arrange
            var method = GetPrivateStaticMethod("GetPlanRowCCRole");
            var planRow = new ShimCStruct
            {
                GetIntString = _ => 1
            }.Instance;
            var listCCRoles = new SortedList<string, CStruct>
            {
            };

            var listRoles = new SortedList<string, CStruct>
            {
                ["1"] = new CStruct() { Value = DummyString, InnerText = DummyString }
            };

            // Act
            var result = method?.Invoke(null, new object[] { planRow, listCCRoles, listRoles }) as CStruct;

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetPlanRowCCRole_ListsDontContainsItem_ReturnsFirstItemFromCCRoles()
        {
            // Arrange
            var method = GetPrivateStaticMethod("GetPlanRowCCRole");
            var planRow = new ShimCStruct
            {
                GetIntString = _ => 2
            }.Instance;
            var listCCRoles = new SortedList<string, CStruct>
            {
                ["1"] = new CStruct() { Value = DummyString, InnerText = DummyString }
            };
            var listRoles = new SortedList<string, CStruct>();

            // Act
            var result = method?.Invoke(null, new object[] { planRow, listCCRoles, listRoles }) as CStruct;

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetPlanRowCCRole_ListsDontContainsItem_ReturnsFirstItemFromRoles()
        {
            // Arrange
            var method = GetPrivateStaticMethod("GetPlanRowCCRole");
            var planRow = new ShimCStruct
            {
                GetIntString = _ => 2
            }.Instance;
            var listCCRoles = new SortedList<string, CStruct>();
            var listRoles = new SortedList<string, CStruct>
            {
                ["1"] = new CStruct() { Value = DummyString, InnerText = DummyString }
            };

            // Act
            var result = method?.Invoke(null, new object[] { planRow, listCCRoles, listRoles }) as CStruct;

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetPlanRowCCRole_EmptyLists_ReturnSNull()
        {
            // Arrange
            var method = GetPrivateStaticMethod("GetPlanRowCCRole");
            var planRow = new ShimCStruct
            {
                GetIntString = _ => 2
            }.Instance;
            var listCCRoles = new SortedList<string, CStruct>();
            var listRoles = new SortedList<string, CStruct>();

            // Act
            var result = method?.Invoke(null, new object[] { planRow, listCCRoles, listRoles }) as CStruct;

            // Assert
            result.ShouldBeNull();
        }

        [TestMethod]
        public void GetLookup_ListContainsItem_ReturnsCStruct()
        {
            // Arrange
            var method = GetPrivateStaticMethod("GetLookup");
            var list = new List<CStruct>
            {
                new ShimCStruct()
                {
                    GetIntString = name => 1
                }
            };
            const int FieldId = 1;

            // Act
            var result = method?.Invoke(null, new object[] { list, FieldId }) as CStruct;

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetLookup_ListDoesntContainItem_ReturnsNull()
        {
            // Arrange
            var method = GetPrivateStaticMethod("GetLookup");
            var list = new List<CStruct>
            {
                new ShimCStruct()
                {
                    GetIntString = name => 3
                }
            };
            const int FieldId = 1;

            // Act
            var result = method?.Invoke(null, new object[] { list, FieldId }) as CStruct;

            // Assert
            result.ShouldBeNull();
        }

        [TestMethod]
        public void FormatPendingNames_PendingNameEmpty_ReturnExpectedValue()
        {
            // Arrange
            var method = GetPrivateStaticMethod("FormatPendingNames");
            var pendingName = string.Empty;

            // Act
            var result = method?.Invoke(null, new object[] { DummyString, pendingName }) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void FormatPendingNames_ResourceNameEmpty_ReturnExpectedValue()
        {
            // Arrange
            var method = GetPrivateStaticMethod("FormatPendingNames");
            var pendingName = string.Empty;

            // Act
            var result = method?.Invoke(null, new object[] { string.Empty, DummyString }) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void FormatPendingNames_ResourceNameNotEmpty_ReturnExpectedValue()
        {
            // Arrange
            var method = GetPrivateStaticMethod("FormatPendingNames");
            var pendingName = string.Empty;
            var expectedValue = $"{DummyString}({DummyString})";

            // Act
            var result = method?.Invoke(null, new object[] { DummyString, DummyString }) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(expectedValue));
        }

        private List<CStruct> GetFieldsList()
        {
            var list = new List<CStruct>
            {
                new ShimCStruct
                {
                    GetBooleanAttrString = _ => true,
                    GetIntAttrString = _ => 9020,
                    GetStringAttrString = _ => DummyString
                },
                new ShimCStruct
                {
                    GetBooleanAttrString = _ => true,
                    GetIntAttrString = _ => 9000,
                    GetStringAttrString = _ => DummyString
                },
                new ShimCStruct
                {
                    GetBooleanAttrString = _ => true,
                    GetIntAttrString = _ => 9014,
                    GetStringAttrString = _ => DummyString
                },
                new ShimCStruct
                {
                    GetBooleanAttrString = _ => true,
                    GetIntAttrString = _ => 9020,
                    GetStringAttrString = _ => DummyString
                },
                new ShimCStruct
                {
                    GetBooleanAttrString = _ => true,
                    GetIntAttrString = _ => 9009,
                    GetStringAttrString = _ => DummyString
                },
                new ShimCStruct
                {
                    GetBooleanAttrString = _ => true,
                    GetIntAttrString = _ => 9008,
                    GetStringAttrString = _ => DummyString
                },
                new ShimCStruct
                {
                    GetBooleanAttrString = _ => true,
                    GetIntAttrString = _ => 9007,
                    GetStringAttrString = _ => DummyString
                },
                new ShimCStruct
                {
                    GetBooleanAttrString = _ => true,
                    GetIntAttrString = _ => 9006,
                    GetStringAttrString = _ => DummyString
                },
                new ShimCStruct
                {
                    GetBooleanAttrString = _ => true,
                    GetIntAttrString = _ => 9015,
                    GetStringAttrString = _ => DummyString
                },
                new ShimCStruct
                {
                    GetBooleanAttrString = _ => true,
                    GetIntAttrString = _ => 9004,
                    GetStringAttrString = _ => DummyString
                },
                new ShimCStruct
                {
                    GetBooleanAttrString = _ => true,
                    GetIntAttrString = _ => 9012,
                    GetStringAttrString = _ => DummyString
                },
                new ShimCStruct
                {
                    GetBooleanAttrString = _ => true,
                    GetIntAttrString = _ => 9013,
                    GetStringAttrString = _ => DummyString
                },
                new ShimCStruct
                {
                    GetBooleanAttrString = _ => true,
                    GetIntAttrString = _ => 9017,
                    GetStringAttrString = _ => DummyString
                },
                new ShimCStruct
                {
                    GetBooleanAttrString = _ => true,
                    GetIntAttrString = _ => 9018,
                    GetStringAttrString = _ => DummyString
                },
                new ShimCStruct
                {
                    GetBooleanAttrString = _ => true,
                    GetIntAttrString = _ => 0,
                    GetStringAttrString = _ => DummyString
                },
                new ShimCStruct
                {
                    GetBooleanAttrString = _ => true,
                    GetIntAttrString = _ => 999,
                    GetStringAttrString = _ => DummyString
                }
            };

            return list;
        }

    }
}
