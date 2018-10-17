using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Xml;
using System.Xml.Fakes;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.Fakes;
using EPMLiveWebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.WebPageCode
{
    [TestClass]
    public class GetGanttTasksTests
    {
        private IDisposable _shimContext;
        private SharepointShims _sharepointShims;
        private AdoShims _adoShims;
        private getgantttasks _getGanttTasks;
        private PrivateObject _getGanttTasksPrivate;
        private const string DummyString = "DummyString";
        private const string PageLoadMethodName = "Page_Load";

        [TestInitialize]
        public void Setup()
        {
            _shimContext = ShimsContext.Create();

            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();

            //Shimgetgantttasks.Constructor = tasks =>
            //{
            //    var shimPage = new ShimPage(tasks)
            //    {
            //        RequestGet = () =>
            //        {
            //            var shimHttpRequest = new ShimHttpRequest()
            //            {
            //                ItemGetString = key =>
            //                {
            //                    if (key == "ignorelistid")
            //                    {
            //                        return "1";
            //                    }
            //                    return "2";
            //                }
            //            };
            //            return shimHttpRequest;
            //        }
            //    };
            //};

            _getGanttTasks = new getgantttasks();
            _getGanttTasksPrivate = new PrivateObject(_getGanttTasks);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        [TestMethod]
        public void ProcessList_FieldTypeUser_Exceuted()
        {
            ProcessList_FieldsProvided_CollectionsField(SPFieldType.User);
        }

        [TestMethod]
        public void ProcessList_FieldTypeNumber_Exceuted()
        {
            ProcessList_FieldsProvided_CollectionsField(SPFieldType.Number);
        }

        public void ProcessList_FieldsProvided_CollectionsField(SPFieldType fieldType)
        {
            // Arrange
            var webId = new Guid("E31FAB68-A8BA-4C68-9DCA-41DD17ABF474");
            var listId = new Guid("4D593B64-51CF-49F0-B566-CDAE35FCDDE0");
            var fieldId = new Guid("CA4AA59C-17EB-4BF1-94B7-960970D07802");
            var parentListId = new Guid("3C2C5B89-4219-44F2-9D5E-4D0F9C489267");

            _sharepointShims.ListShim.IDGet = () => listId;
            _sharepointShims.ListShim.GetItemsSPQuery = query =>
                new ShimSPListItemCollection().Bind(
                    new SPListItem[]
                    {
                        new ShimSPListItem
                        {
                            FieldsGet = () => new ShimSPFieldCollection
                            {
                                GetFieldByInternalNameString = filter => new ShimSPField
                                {
                                    IdGet = () => fieldId,
                                    TypeGet = () => fieldType
                                }
                            },
                            ItemGetGuid = id => fieldId,
                            ParentListGet = () => new ShimSPList
                            {
                                IDGet = () => parentListId
                            }
                        }
                    });

            _sharepointShims.WebShim.IDGet = () => webId;
            _sharepointShims.WebShim.TitleGet = () => "WebTitle1";
            var arguments = new object[]
            {
                (SPWeb)_sharepointShims.WebShim,
                "select",
                (SPList)_sharepointShims.ListShim,
                new SortedList()
            };

            _getGanttTasksPrivate.SetField("filtervalue", fieldId.ToString());
            var arrItems = new SortedList();
            _getGanttTasksPrivate.SetField("arrItems", arrItems);
            var queueAllItems = new Queue();
            _getGanttTasksPrivate.SetField("queueAllItems", queueAllItems);
            var arrGroupFields = new[] { "--SITE--", "" };
            _getGanttTasksPrivate.SetField("arrGroupFields", arrGroupFields);
            var spList = new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = internalName => new ShimSPField
                    {
                        IdGet = () => fieldId,
                        TypeGet = () => fieldType
                    }
                }
            };
            _getGanttTasksPrivate.SetField("list", (SPList)spList);

            Shimgetgantttasks.AllInstances.getFieldSPListItemString = (task, listItem, fieldName) => "group1";

            // Act
            _getGanttTasksPrivate.Invoke(
                "processList",
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy, arguments);

            // Assert
            Assert.AreEqual(1, arrItems.Count);
            var values =
                (string[])arrItems["e31fab68-a8ba-4c68-9dca-41dd17abf474.3c2c5b89-4219-44f2-9d5e-4d0f9c489267.0"];
            Assert.AreEqual(1, values?.Length);
            if (fieldType == SPFieldType.User)
            {
                Assert.AreEqual("WebTitle1\n", values[0]);
            }
            else
            {
                Assert.AreEqual("WebTitle1\ngroup1", values[0]);
            }
            Assert.AreEqual(1, queueAllItems.Count);
        }

        [TestMethod]
        public void PageLoad_OnSuccess_ShouldExecuteCorrectly()
        {
            // Arrange
            var sender = new object();
            ShimPage.AllInstances.ResponseGet = _ => new ShimHttpResponse();
            ShimHttpResponse.AllInstances.CacheGet = _ => new ShimHttpCachePolicy();
            var attributeList = new List<XmlAttribute>();
            var nodeList = new List<XmlNode>();
            const double Average = .168;
            _getGanttTasksPrivate.SetFieldOrProperty("providerEn", new NumberFormatInfo());
            _getGanttTasksPrivate.SetFieldOrProperty("dtProviderEn", new DateTimeFormatInfo());
            _getGanttTasksPrivate.SetFieldOrProperty("workdays", new BitArray(7));
            _getGanttTasksPrivate.SetFieldOrProperty("view", new ShimSPView().Instance);
            _getGanttTasksPrivate.SetFieldOrProperty("list", new ShimSPList().Instance);
            _getGanttTasksPrivate.SetFieldOrProperty("arrAggregationDef", new SortedList());
            _getGanttTasksPrivate.SetFieldOrProperty("arrAggregationVals", new SortedList()
            {
                [$"{DummyString}\n{DummyString}"] = .1321,
                [$"{DummyString}\nAVG"] = Average
            });
            _getGanttTasksPrivate.SetFieldOrProperty("arrColumns", new ArrayList(
                new List<string>
                {
                    DummyString,
                    "AVG",
                    DummyString
                }));
            _getGanttTasksPrivate.SetFieldOrProperty("hshItemNodes", new Hashtable
            {
                [DummyString] = new ShimXmlNode(new ShimXmlDocument())
                {
                    AppendChildXmlNode = node =>
                    {
                        nodeList.Add(node);
                        return node;
                    }
                }.Instance
            });
            ShimSPView.AllInstances.QueryGet = _ => "Dummy Query";
            ShimSPView.AllInstances.AggregationsStatusGet = _ => "On";
            ShimSPView.AllInstances.AggregationsGet = _ => "<B Name=\"Dummy\" Type=\"Dummy\">DummyString</B>";
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => new ShimSPWeb
                {
                    CurrentUserGet = () => new ShimSPUser(),
                    SiteGet = () => new ShimSPSite(),
                    GetListFromUrlString = name => new ShimSPList
                    {
                        ViewsGet = () => new ShimSPViewCollection
                        {
                            ItemGetString = fieldName => new ShimSPView()
                        }
                    }
                },
                SiteGet = () => new ShimSPSite
                {
                    RootWebGet = () => new ShimSPWeb
                    {
                        RegionalSettingsGet = () => new ShimSPRegionalSettings
                        {
                            WorkDayStartHourGet = () => 1,
                            WorkDayEndHourGet = () => 2,
                            WorkDaysGet = () => 5
                        }
                    }
                }
            };
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = name => new ShimSPField()
            };
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            Shimgetgantttasks.AllInstances.getRealFieldSPField = (_, field) => new ShimSPField();
            Shimgetgantttasks.AllInstances.getParamsSPWeb = (_, web) => { };
            Shimgetgantttasks.AllInstances.addHeaderXmlDocument = (_, web) =>
            {
                var doc = new XmlDocument();
                var element = doc.CreateNode(XmlNodeType.Element, "Items", doc.NamespaceURI);
                doc.AppendChild(element);
                return doc;
            };
            Shimgetgantttasks.AllInstances.addItemsXmlDocumentSPWeb = (_, document, web) => document;
            ShimXmlAttributeCollection.AllInstances.AppendXmlAttribute = (_, attribute) => attribute;
            ShimXmlAttributeCollection.AllInstances.ItemOfGetString = (_, attribute) => new ShimXmlAttribute
            {
                ValueGet = () => "STDEV"
            };
            ShimXmlAttributeCollection.AllInstances.AppendXmlAttribute = (_, attribute) =>
            {
                attributeList.Add(attribute);
                return attribute;
            };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimCoreFunctions.getListSettingStringSPList = (name, spList) => "AVG|AVG";

            // Act
            _getGanttTasksPrivate.Invoke(PageLoadMethodName, sender, EventArgs.Empty);
            var documentCompleted = _getGanttTasksPrivate.GetFieldOrProperty("docComplete") as XmlDocument;
            var xmlData = _getGanttTasksPrivate.GetFieldOrProperty("data") as string;

            // Assert
            _getGanttTasks.ShouldSatisfyAllConditions(
                () => documentCompleted.ShouldNotBeNull(),
                () => nodeList.ShouldNotBeEmpty(),
                () => xmlData.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void GetParams_WithValidParameters_ShouldExecuteCorrectly()
        {
            // Arrange
            var web = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetGuid = guid => new ShimSPList
                    {
                        ViewsGet = () => new ShimSPViewCollection
                        {
                            ItemGetString = name => new ShimSPView()
                        }
                    }
                }
            };
            var parameters = new Dictionary<string, string>
            {
                ["List"] = DummyString,
                ["View"] = DummyString,
                ["Executive"] = DummyString,
                ["LType"] = DummyString,
                ["Start"] = DummyString,
                ["Finish"] = DummyString,
                ["Percent"] = DummyString,
                ["WBS"] = DummyString,
                ["Milestone"] = DummyString,
                ["Info"] = DummyString,
                ["RLists"] = $"{DummyString}|{DummyString}",
                ["RSites"] = $"{DummyString},{DummyString}",
                ["FilterField"] = DummyString,
                ["FilterValue"] = DummyString,
                ["AGroups"] = DummyString,
                ["UsePerf"] = bool.TrueString,
                ["UsePopup"] = bool.TrueString
            };
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                ItemGetString = name =>
                {
                    var stringParameters = ConvertDictionaryToStringParams(parameters);
                    var encoded = ASCIIEncoding.ASCII.GetBytes(stringParameters);
                    return Convert.ToBase64String(encoded);
                }
            };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimSPSite.ConstructorString = (_, url) => { };
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb
            {
                GetListFromUrlString = url => new ShimSPList()
            };

            // Act
            _getGanttTasks.getParams(web);
            var list = _getGanttTasksPrivate.GetFieldOrProperty("strlist") as string;
            var view = _getGanttTasksPrivate.GetFieldOrProperty("strview") as string;
            var linktype = _getGanttTasksPrivate.GetFieldOrProperty("linktype") as string;
            var start = _getGanttTasksPrivate.GetFieldOrProperty("start") as string;
            var hshLists = _getGanttTasksPrivate.GetFieldOrProperty("hshLists") as Hashtable;
            var usePerformance = _getGanttTasksPrivate.GetFieldOrProperty("usePerformance") as bool?;
            var usePopup = _getGanttTasksPrivate.GetFieldOrProperty("usePopup") as bool?;

            // Assert
            _getGanttTasks.ShouldSatisfyAllConditions(
                () => list.ShouldNotBeNullOrEmpty(),
                () => list.ShouldBe(DummyString),
                () => view.ShouldNotBeNullOrEmpty(),
                () => view.ShouldBe(DummyString),
                () => linktype.ShouldNotBeNullOrEmpty(),
                () => linktype.ShouldBe(DummyString),
                () => start.ShouldNotBeNullOrEmpty(),
                () => start.ShouldBe(DummyString),
                () => hshLists.ShouldNotBeNull(),
                () => hshLists.Count.ShouldBeGreaterThanOrEqualTo(1),
                () => usePerformance.GetValueOrDefault().ShouldBeTrue(),
                () => usePopup.GetValueOrDefault().ShouldBeTrue());
        }

        [TestMethod]
        public void GetParams_WithNullParameters_ShouldExecuteCorrectly()
        {
            // Arrange
            var web = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetGuid = guid => new ShimSPList
                    {
                        ViewsGet = () => new ShimSPViewCollection
                        {
                            ItemGetString = name => new ShimSPView()
                        }
                    }
                }
            };
            var parameters = new Dictionary<string, string>
            {
                ["List"] = DummyString,
                ["View"] = DummyString,
                ["FilterField"] = DummyString,
                ["FilterValue"] = DummyString,
            };
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                ItemGetString = name =>
                {
                    var stringParameters = ConvertDictionaryToStringParams(parameters);
                    var encoded = ASCIIEncoding.ASCII.GetBytes(stringParameters);
                    return Convert.ToBase64String(encoded);
                }
            };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimSPSite.ConstructorString = (_, url) => { };
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb
            {
                GetListFromUrlString = url => new ShimSPList()
            };

            // Act
            _getGanttTasks.getParams(web);
            var linktype = _getGanttTasksPrivate.GetFieldOrProperty("linktype") as string;
            var start = _getGanttTasksPrivate.GetFieldOrProperty("start") as string;
            var lists = _getGanttTasksPrivate.GetFieldOrProperty("hshLists") as Hashtable;
            var rollupsites = _getGanttTasksPrivate.GetFieldOrProperty("rollupsites") as string[];
            var usePerformance = _getGanttTasksPrivate.GetFieldOrProperty("usePerformance") as bool?;
            var usePopup = _getGanttTasksPrivate.GetFieldOrProperty("usePopup") as bool?;

            // Assert
            _getGanttTasks.ShouldSatisfyAllConditions(
                () => linktype.ShouldBeNull(),
                () => start.ShouldBeNull(),
                () => lists.ShouldNotBeNull(),
                () => lists.Count.ShouldBe(0),
                () => rollupsites.ShouldBeNull(),
                () => usePerformance.GetValueOrDefault().ShouldBeFalse(),
                () => usePopup.GetValueOrDefault().ShouldBeFalse());
        }

        private string ConvertDictionaryToStringParams(IDictionary<string, string> dict)
        {
            var sb = new StringBuilder();
            foreach (var item in dict)
            {
                sb.Append($"{item.Key}\t{item.Value}");
                if (item.Key != dict.Keys.LastOrDefault())
                {
                    sb.Append("\n");
                }
            }
            return sb.ToString();
        }
    }
}
