using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Web.Fakes;
using System.Web.Script.Serialization.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Xml;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.Fakes;
using EPMLiveWebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public partial class GridListViewTests
    {
        private const string GoogleComUrl = "http://www.google.com";
        private const int DummyInteger = 100;
        private IDisposable _shimsContext;
        private SharepointShims _sharepointShims;

        private GridListView _testable;
        private PrivateObject _testablePrivate;

        private StringBuilder _outputBuilder;
        private StringWriter _outputWriterString;
        private HtmlTextWriter _outputWriterHtml;
        private CultureInfo _currentCulture;

        private string Output
        {
            get
            {
                _outputWriterHtml?.Flush();
                _outputWriterString?.Flush();
                return _outputBuilder.ToString();
            }
        }

        private string _id;
        private string _fullGridId;
        private bool _showSearch;
        private bool _hasSearchResults;
        private string _searchField;
        private string _searchString;

        [TestInitialize]
        public void SetUp()
        {
            _currentCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            _shimsContext = ShimsContext.Create();
            _sharepointShims = SharepointShims.ShimSharepointCalls();

            _testable = new GridListView();
            _testablePrivate = new PrivateObject(_testable);

            SetUpDefaultValues();

            _testablePrivate.SetField("sFullGridId", _fullGridId);
            _testablePrivate.SetField("bShowSearch", _showSearch);
            _testablePrivate.SetField("bHasSearchResults", _hasSearchResults);
            _testablePrivate.SetField("sSearchField", _searchField);
            _testablePrivate.SetField("sSearchValue", _searchString);
            _testablePrivate.SetField("list", _sharepointShims.ListShim.Instance);
            _testablePrivate.SetField("view", _sharepointShims.ViewShim.Instance);
            _testablePrivate.SetField("gSettings", new ShimGridGanttSettings().Instance);
            _testablePrivate.SetField("gvs", new ShimGridViewSession().Instance);
            ShimSPContext.AllInstances.ViewContextGet = _ => new ShimSPViewContext()
            {
                ViewGet = () => _sharepointShims.ViewShim.Instance,
            }.Instance;
            ShimControl.AllInstances.PageGet = _ => new ShimPage()
            {
                RequestGet = () => new ShimHttpRequest().Instance,
            }.Instance;

            _outputBuilder = new StringBuilder();
            _outputWriterString = new StringWriter(_outputBuilder);
            _outputWriterHtml = new HtmlTextWriter(_outputWriterString);
        }

        private void SetUpDefaultValues()
        {
            _id = "test-id";
            _fullGridId = "test-grid-id";
            _showSearch = true;
            _hasSearchResults = true;
            _searchField = "test-search-field";
            _searchString = "test-search-string";
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();

            _outputWriterString.Dispose();
            _outputWriterHtml.Dispose();
            Thread.CurrentThread.CurrentCulture = _currentCulture;
        }

        [TestMethod()]
        public void GetViewsTest_When_propertbag_Is_Null()
        {
            string xml = "<View Name=\"{7591FC7D-8304-42C7-9456-09F4241AC6F8}\" Type=\"HTML\"" +
   "  DisplayName=\"TestView1\" Title=\"DefaultView\" Url=\"Lists/List_Name/File_Name.aspx\"" +
      " BaseViewID=\"1\" >" +
   "<Query>      <GroupBy Collapse=\"FALSE\">         <FieldRef Name=\"Title\" />      </GroupBy>   </Query>" +
   "<ViewFields> <FieldRef Name=\"Attachments\" /> <FieldRef Name=\"LinkTitle\" /><FieldRef Name=\"_x004e_um1\" /><FieldRef Name=\"_x006e_um2\" /><FieldRef Name=\"_x006e_um3\" /> </ViewFields>" +
   "<RowLimit Paged=\"TRUE\">100</RowLimit>" +
   "<Aggregations Value=\"On\">" +
      "<FieldRef Name=\"_x006e_um2\" Type=\"SUM\" />" +
      "<FieldRef Name=\"_x004e_um1\" Type=\"AVG\" />" +
   "</Aggregations>" +
 "</View>";
            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xml);
            PrivateObject objToTestPrivateMethod = new PrivateObject(typeof(GridListView));
            using (var context = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                var list = context.GetOrCreateList("Mainlist", Microsoft.SharePoint.SPListTemplateType.GenericList);

                ShimSPList shimList = new ShimSPList(list)
                {
                    IDGet = () =>
                    {
                        return Guid.Parse("696F0CD4-2EDB-4B75-8AD4-A64689158803");
                    },
                    ParentWebGet = () =>
                    {
                        ShimSPWeb web = new ShimSPWeb(context.Web);
                        web.PropertiesGet = () =>
                         {
                             var propertyBag = new ShimSPPropertyBag();
                             var sd = new ShimStringDictionary(propertyBag);
                             sd.ItemGetString = (key) =>
                             {
                                 return null;
                             };
                             return propertyBag;
                         };
                        return web;
                    }
                };

                ShimJavaScriptSerializer.AllInstances.SerializeObject = (instance, a) =>
                {
                    return "";
                };

                ShimHttpUtility.HtmlDecodeString = (str) =>
                {
                    return "Default View";
                };

                ShimControl.AllInstances.PageGet = (ShimTemplateInstanceAttribute) =>
                {
                    return new ShimPage()
                    {
                        RequestGet = () =>
                        {
                            return new ShimHttpRequest()
                            {
                                UrlGet = () =>
                            {
                                return new Uri("http://win-6j09gf4nbp8/sites/600Release/Lists/Project%20Center/Executive%20Summary.aspx");
                            }
                            };
                        }
                    };
                };

                objToTestPrivateMethod.SetField("list", list);
                string result = Convert.ToString(objToTestPrivateMethod.Invoke("GetViews"));

                Assert.IsTrue(result.Contains("Default View"));
                Assert.IsTrue(result.Contains("/Lists/Mainlist/AllItems.aspx"));
            }
        }
        [TestMethod()]
        public void GetViewsTest_When_propertbag_IsNot_Null()
        {
            string xml = "<View Name=\"{7591FC7D-8304-42C7-9456-09F4241AC6F8}\" Type=\"HTML\"" +
   "  DisplayName=\"TestView1\" Title=\"DefaultView\" Url=\"Lists/List_Name/File_Name.aspx\"" +
      " BaseViewID=\"1\" >" +
   "<Query>      <GroupBy Collapse=\"FALSE\">         <FieldRef Name=\"Title\" />      </GroupBy>   </Query>" +
   "<ViewFields> <FieldRef Name=\"Attachments\" /> <FieldRef Name=\"LinkTitle\" /><FieldRef Name=\"_x004e_um1\" /><FieldRef Name=\"_x006e_um2\" /><FieldRef Name=\"_x006e_um3\" /> </ViewFields>" +
   "<RowLimit Paged=\"TRUE\">100</RowLimit>" +
   "<Aggregations Value=\"On\">" +
      "<FieldRef Name=\"_x006e_um2\" Type=\"SUM\" />" +
      "<FieldRef Name=\"_x004e_um1\" Type=\"AVG\" />" +
   "</Aggregations>" +
 "</View>";
            string Id = "7591FC7D-8304-42C7-9456-09F4241AC6F8";
            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xml);
            PrivateObject objToTestPrivateMethod = new PrivateObject(typeof(GridListView));
            using (var context = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                //ShimSPList list = new ShimSPList();

                //ShimJavaScriptSerializer.AllInstances.SerializeObject = (instance, a) =>
                //{
                //    return "";
                //};
                //ShimSPView.AllInstances.TitleGet = (instance) =>
                //{
                //    return "Default View";
                //};
                //ShimHttpUtility.HtmlDecodeString = (str) =>
                //{
                //    return "Default View";
                //};
                //ShimSPList.AllInstances.ViewsGet = (ShimTemplateInstanceAttribute) =>
                //{
                //    ShimSPViewCollection vcollection = new ShimSPViewCollection();
                //    return vcollection;
                //};
                //ShimSPList.AllInstances.IDGet = (instance) =>
                //{
                //    return Guid.Parse(Id);
                //};
                ////ShimSPSite site = context.Site;
                ////ShimSPWeb web = site.OpenWeb();
                //ShimSPSite.AllInstances.Dispose = (instance) => { };
                //ShimSPWeb.AllInstances.Dispose = (instance) => { };

                //ShimSPList.AllInstances.ParentWebGet = (instance) =>
                //{
                //    return new ShimSPWeb()
                //    {
                //        PropertiesGet = () =>
                //        {
                //            ShimSPPropertyBag spbag = new ShimSPPropertyBag();
                //            //spbag.Add(String.Format("ViewPermissions{0}", list.ID.ToString()), "13#Test#http://win-6j09gf4nbp8/sites/600Release/Lists/Project%20Center/Executive%20Summary.aspx|14#testpath#http://win-6j09gf4nbp8/sites/600Release/Lists/Project%20Center/Executive%20Summary.aspx");
                //            return spbag;
                //        }
                //    };
                //};


                //};
                //ShimSPWeb.AllInstances.GroupsGet = (ShimTemplateInstanceAttribute) =>
                //{
                //    ShimSPGroupCollection groupToReturn = new ShimSPGroupCollection();

                //    return groupToReturn;

                //};
                //ShimSPWeb.AllInstances.UserIsSiteAdminGet = (ShimTemplateInstanceAttribute) =>
                //{
                //    return true;
                //};
                //ShimSPView.AllInstances.UrlGet = (ShimTemplateInstanceAttribute) =>
                //{
                //    return "http://win-6j09gf4nbp8/sites/600Release/Lists/Project%20Center/Executive%20Summary.aspx";
                //};

                //ShimSPGroup.AllInstances.IDGet = (ShimTemplateInstanceAttribute) => { return 13; };
                // ShimControl.AllInstances.PageGet = (ShimTemplateInstanceAttribute) =>
                //{
                //    return new ShimPage()
                //    {
                //        RequestGet = () =>
                //        {
                //            return new ShimHttpRequest()
                //            {
                //                UrlGet = () =>
                //                {
                //                    return new Uri("http://win-6j09gf4nbp8/sites/600Release/Lists/Project%20Center/Executive%20Summary.aspx");
                //                }
                //            };
                //        }
                //    };
                //};
                var list = context.GetOrCreateList("Mainlist", Microsoft.SharePoint.SPListTemplateType.GenericList);

                ShimSPList shimList = new ShimSPList(list)
                {
                    IDGet = () =>
                    {
                        return Guid.Parse("696F0CD4-2EDB-4B75-8AD4-A64689158803");
                    },
                    ParentWebGet = () =>
                    {
                        ShimSPWeb web = new ShimSPWeb(context.Web);
                        web.PropertiesGet = () =>
                        {
                            var propertyBag = new ShimSPPropertyBag();
                            var sd = new ShimStringDictionary(propertyBag);
                            sd.ItemGetString = (key) =>
                            {
                                return "0#YYYY#ViewURL";
                            };
                            return propertyBag;
                        };
                        return web;
                    },
                    ViewsGet = () =>
                    {
                        var views = new ShimSPViewCollection();
                        ShimSPBaseCollection coll = new ShimSPBaseCollection(views);
                        coll.GetEnumerator = () =>
                        {
                            return new TestEnumerator();
                        };
                        return views;
                    }
                };

                ShimJavaScriptSerializer.AllInstances.SerializeObject = (instance, a) =>
                {
                    return "";
                };

                ShimHttpUtility.HtmlDecodeString = (str) =>
                {
                    return "Default View";
                };

                ShimControl.AllInstances.PageGet = (ShimTemplateInstanceAttribute) =>
                {
                    return new ShimPage()
                    {
                        RequestGet = () =>
                        {
                            return new ShimHttpRequest()
                            {
                                UrlGet = () =>
                                {
                                    return new Uri("http://win-6j09gf4nbp8/sites/600Release/Lists/Project%20Center/Executive%20Summary.aspx");
                                }
                            };
                        }
                    };
                };

                ShimSPContext.CurrentGet = () =>
                {
                    return new ShimSPContext()
                    {
                        WebGet = () =>
                        {
                            return new ShimSPWeb()
                            {
                                UserIsSiteAdminGet = () =>
                                {
                                    return true;
                                },
                                GroupsGet = () =>
                                {
                                    var groups = new ShimSPGroupCollection();
                                    ShimSPBaseCollection coll = new ShimSPBaseCollection(groups);
                                    coll.GetEnumerator = () =>
                                    {
                                        return new TestGroupEnumerator();
                                    };
                                    return groups;
                                }
                            };
                        }
                    };
                };


                //ShimSPBaseCollection.AllInstances.GetEnumerator = (a) =>
                //{
                //    if (a.GetType() == typeof(ShimSPGroupCollection))
                //    {
                //        //ShimSPBaseCollection coll = new ShimSPBaseCollection(a);
                //        //coll.GetEnumerator
                //        //var lst = new ArrayList();
                //        //lst.Add(new ShimSPGroup());

                //        return new TestGroupEnumerator();

                //        //return lst.GetEnumerator();
                //    }
                //    else
                //    {
                //        return null;

                //    }
                //};

                objToTestPrivateMethod.SetField("list", list);
                string result = Convert.ToString(objToTestPrivateMethod.Invoke("GetViews"));

                Assert.IsTrue(result.Contains("ViewURL"));

            }
        }

        [TestMethod]
        public void RenderSearch_Always_RendersSearchLoad()
        {
            // Arrange,  Act
            _testablePrivate.Invoke("RenderSearch", _outputWriterHtml, _sharepointShims.WebShim.Instance);

            // Assert
            Assert.IsTrue(Output.Contains($"<div id=\"searchload{_fullGridId}\""));
        }

        [TestMethod]
        public void RenderSearch_Always_RendersSearchDiv()
        {
            // Arrange, Act
            _testablePrivate.Invoke("RenderSearch", _outputWriterHtml, _sharepointShims.WebShim.Instance);

            // Assert
            Assert.IsTrue(Output.Contains($"<div id=\"searchdiv{_fullGridId}\""));
        }

        [TestMethod]
        public void RenderSearch_DisplayableField_AddedToSelectOptions()
        {
            // Arrange
            const string fieldTitle = "test-title";
            const string fieldName = "Title";
            _sharepointShims.FieldShim.ReorderableGet = () => true;
            _sharepointShims.FieldShim.TitleGet = () => fieldTitle;
            _sharepointShims.FieldShim.InternalNameGet = () => fieldName;

            // Act
            _testablePrivate.Invoke("RenderSearch", _outputWriterHtml, _sharepointShims.WebShim.Instance);

            // Assert
            Assert.IsTrue(Output.Contains($"<option value=\"{fieldName}\">{fieldTitle}</option>"));
        }

        [TestMethod]
        public void RenderSearch_DisplayableFieldTypeBoolean_AddedToJson()
        {
            // Arrange
            const string fieldTitle = "test-title";
            const string fieldName = "Title";
            _sharepointShims.FieldShim.ReorderableGet = () => true;
            _sharepointShims.FieldShim.TitleGet = () => fieldTitle;
            _sharepointShims.FieldShim.InternalNameGet = () => fieldName;
            _sharepointShims.FieldShim.TypeGet = () => SPFieldType.Boolean;

            // Act
            _testablePrivate.Invoke("RenderSearch", _outputWriterHtml, _sharepointShims.WebShim.Instance);

            // Assert
            Assert.IsTrue(Output.Contains($"{fieldName}: [ \"Yes\", \"No\" ]"));
        }

        [TestMethod]
        public void RenderSearch_Always_JsonSearchFieldsInitialized()
        {
            // Arrange
            const string fieldTitle = "test-title";
            const string fieldName = "Title";
            _sharepointShims.FieldShim.ReorderableGet = () => true;
            _sharepointShims.FieldShim.TitleGet = () => fieldTitle;
            _sharepointShims.FieldShim.InternalNameGet = () => fieldName;
            _sharepointShims.FieldShim.TypeGet = () => SPFieldType.Boolean;

            // Act
            _testablePrivate.Invoke("RenderSearch", _outputWriterHtml, _sharepointShims.WebShim.Instance);

            // Assert
            Assert.IsTrue(Output.Contains($"var searchfields{_fullGridId} = {{{fieldName}: [ \"Yes\", \"No\" ]}}"));
        }

        [TestMethod]
        public void RenderSearch_Always_FunctionDeclared_switchsearch()
        {
            // Arrange, Act
            _testablePrivate.Invoke("RenderSearch", _outputWriterHtml, _sharepointShims.WebShim.Instance);

            // Assert
            Assert.IsTrue(Output.Contains($"function switchsearch{_fullGridId}()"));
        }

        [TestMethod]
        public void RenderSearch_Always_FunctionDeclared_unSearch()
        {
            // Arrange, Act
            _testablePrivate.Invoke("RenderSearch", _outputWriterHtml, _sharepointShims.WebShim.Instance);

            // Assert
            Assert.IsTrue(Output.Contains($"function unSearch{_fullGridId}()"));
        }

        [TestMethod]
        public void RenderSearch_Always_FunctionDeclared_doSearch()
        {
            // Arrange, Act
            _testablePrivate.Invoke("RenderSearch", _outputWriterHtml, _sharepointShims.WebShim.Instance);

            // Assert
            Assert.IsTrue(Output.Contains($"function doSearch{_fullGridId}()"));
        }

        [TestMethod]
        public void RenderSearch_Always_FunctionDeclared_enablesearcher()
        {
            // Arrange, Act
            _testablePrivate.Invoke("RenderSearch", _outputWriterHtml, _sharepointShims.WebShim.Instance);

            // Assert
            Assert.IsTrue(Output.Contains($"function enablesearcher{_fullGridId}()"));
        }

        [TestMethod]
        public void RenderSearch_Always_FunctionDeclared_searchKeyPress()
        {
            // Arrange, Act
            _testablePrivate.Invoke("RenderSearch", _outputWriterHtml, _sharepointShims.WebShim.Instance);

            // Assert
            Assert.IsTrue(Output.Contains($"function searchKeyPress{_fullGridId}(e)"));
        }

        [TestMethod]
        public void RenderSearch_Always_RunStartupScript()
        {
            // Arrange, Act
            _testablePrivate.Invoke("RenderSearch", _outputWriterHtml, _sharepointShims.WebShim.Instance);

            // Assert
            Assert.IsTrue(Output.Contains($"<script language=\"javascript\">switchsearch{_fullGridId}();</script>"));
        }

        [TestMethod]
        public void RenderSearch_Always_RendersSearchContainer()
        {
            // Arrange, Act
            _testablePrivate.Invoke("RenderSearch", _outputWriterHtml, _sharepointShims.WebShim.Instance);

            // Assert
            Assert.IsTrue(Output.Contains($"<div id=\"search{_testable.ID}\""));
        }

        [TestMethod]
        public void RenderSearch_Always_RendersSearchSelect()
        {
            // Arrange, Act
            _testablePrivate.Invoke("RenderSearch", _outputWriterHtml, _sharepointShims.WebShim.Instance);

            // Assert
            Assert.IsTrue(Output.Contains($"<select id=\"search{_fullGridId}\""));
        }

        [TestMethod]
        public void RenderSearch_Always_RendersSearchTypeSelect()
        {
            // Arrange, Act
            _testablePrivate.Invoke("RenderSearch", _outputWriterHtml, _sharepointShims.WebShim.Instance);

            // Assert
            Assert.IsTrue(Output.Contains($"<select id=\"searchtype{_fullGridId}\" class=\"form-control\">"));
        }

        [TestMethod]
        public void RenderSearch_Always_RendersUnsearch()
        {
            // Arrange, Act
            _testablePrivate.Invoke("RenderSearch", _outputWriterHtml, _sharepointShims.WebShim.Instance);

            // Assert
            Assert.IsTrue(Output.Contains($"<div id=\"unsearch{_fullGridId}\""));
        }

        [TestMethod]
        public void RenderSearch_Always_RendersSearchInput()
        {
            // Arrange, Act
            _testablePrivate.Invoke("RenderSearch", _outputWriterHtml, _sharepointShims.WebShim.Instance);

            // Assert
            Assert.IsTrue(Output.Contains($"<input type=\"text\" id=\"searchtext{_fullGridId}\" value=\"{_searchString}\""));
        }

        [TestMethod]
        public void RenderSearch_Always_RendersSearchButton()
        {
            // Arrange, Act
            _testablePrivate.Invoke("RenderSearch", _outputWriterHtml, _sharepointShims.WebShim.Instance);

            // Assert
            Assert.IsTrue(Output.Contains($"<img onclick=\"doSearch{_fullGridId}()\" src=\"/_layouts/epmlive/images/find_icon.png\"/>"));
        }

        [TestMethod]
        public void RenderGrid_Always_AppendsSwithSearchFunction()
        {
            var shimPeopleEditor = new ShimPeopleEditor();
            var shimPeopleEditorControl = new ShimControl(shimPeopleEditor)
            {
                RenderControlHtmlTextWriter = _ => { }
            };

            ShimGridListView.AllInstances.addGridPropertiesHtmlTextWriterSPWeb = (_1, _2, _3) => { };

            var shimSpWeb = _sharepointShims.WebShim;
            shimSpWeb.UrlGet = () => string.Empty;
            shimSpWeb.ServerRelativeUrlGet = () => string.Empty;
            shimSpWeb.LocaleGet = () => new CultureInfo(DummyInteger);

            var shimSpViewFieldColl = new ShimSPViewFieldCollection();
            var shimSpBaseColl = new ShimSPBaseCollection(shimSpViewFieldColl);
            shimSpBaseColl.GetEnumerator = () => { return new List<string>().GetEnumerator(); };
            _sharepointShims.ViewShim.ViewFieldsGet = () => shimSpViewFieldColl;

            SetupShimHttpContext();

            _testable.ID = _id;
            _testablePrivate.SetField("peMulti", shimPeopleEditor.Instance);
            _testablePrivate.SetField("peSingle", shimPeopleEditor.Instance);

            // Arrange, Act
            _testablePrivate.Invoke("renderGrid", _outputWriterHtml, _sharepointShims.WebShim.Instance);

            // Assert
            Output.ShouldSatisfyAllConditions(
                () => Output.ShouldContain($"function switchsearch{_fullGridId}()"),
                () => Output.ShouldContain($"var loader = document.getElementById('loadinggrid{_id}');"),
                () => Output.ShouldContain($"loadX{_fullGridId}(searcher.options[searcher.selectedIndex].value, searchvalue, searchtype);"));
        }

        private void SetupShimHttpContext()
        {
            var uri = new Uri(GoogleComUrl);

            var shimHttpRequest = new ShimHttpRequest();
            shimHttpRequest.UrlGet = () => uri;

            var shimHttpContext = new ShimHttpContext();
            shimHttpContext.RequestGet = () => shimHttpRequest.Instance;

            ShimHttpContext.CurrentGet = () => shimHttpContext.Instance;
        }
    }

    public class TestEnumerator : IEnumerator
    {
        public SPView[] _spView = new SPView[1];
        int position = -1;
        public TestEnumerator()
        {
            _spView[0] = new ShimSPView()
            {
                TitleGet = () =>
                        {
                            return "Default View";
                        },
                UrlGet = () =>
                {
                    return "ViewURL";
                }
            };

        }

        public object Current
        {
            get
            {
                return _spView[position];
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < _spView.Length);

        }

        public void Reset()
        {

        }
    }

    public class TestGroupEnumerator : IEnumerator
    {
        public SPGroup[] _spGroup = new SPGroup[1];
        int position = -1;
        public TestGroupEnumerator()
        {
            _spGroup[0] = new ShimSPGroup();

        }

        public object Current
        {
            get
            {
                return _spGroup[position];
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < _spGroup.Length);

        }

        public void Reset()
        {

        }
    }
}
