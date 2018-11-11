using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.Specialized.Fakes;
using System.Linq;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.WebPageCode
{
    using EPMLiveCore.Infrastructure.Fakes;
    using Fakes;

    [TestClass]
    public class ViewPermissionPageTests
    {
        private IDisposable shimsContext;
        private ViewPermissionPage viewPermissionPage;
        private PrivateObject privateObject;
        private string RegisterScriptMethodName = "RegisterScript";
        private string RenderDefaultViewMethodName = "RenderDefaultView";
        private const string DummyString = "DummyString";
        private const string DummyUrl = "/dummy/url/";
        private string GetViewsNotInAnyGroupMethodName = "GetViewsNotInAnyGroup";
        private string RenderOptionsMethodName = "RenderOptions";
        private string RenderAvailableViewsMethodName = "RenderAvailableViews";
        private string PrepareRenderPageMethodName = "PrepareRenderPage";
        private string ClearAllMethodName = "ClearAll";
        private string SaveCustomPermissionMethodName = "SaveCustomPermission";
        private string OnLoadMethodName = "OnLoad";
        private string RenderPageMethodName = "RenderPage";

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            viewPermissionPage = new ViewPermissionPage();
            privateObject = new PrivateObject(viewPermissionPage);
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void RegisterScript_Should_ExecuteCorrectly()
        {
            // Arrange
            var expectedScripts = new List<string>
            {
                "function ComputeFields()",
                "function OptionChange(id,sender)",
                "function CountChecked(id)",
                "function OptionBind(id)",
                "function ComputeHidden(id)",
                "function CheckPermission()",
            };
            var registeredScripts = new List<string>();
            ShimControl.AllInstances.PageGet = _ => new ShimPage
            {
                ClientScriptGet = () => new ShimClientScriptManager
                {
                    RegisterClientScriptBlockTypeStringStringBoolean = (type, key, script, addTags) =>
                    {
                        registeredScripts.Add(script);
                    }
                }
            };

            // Act
            privateObject.Invoke(RegisterScriptMethodName);

            // Assert
            viewPermissionPage.ShouldSatisfyAllConditions(
                () => registeredScripts.ShouldNotBeEmpty(),
                () => expectedScripts.ForEach(script => registeredScripts.Any(p => p.Contains(script))));
        }

        [TestMethod]
        public void RenderDefaultView_Should_ExecuteCorrectly()
        {
            // Arrange
            const int GroupId = 3;
            var views = new List<SPView>
            {
                new ShimSPView
                {
                    UrlGet = () => DummyUrl,
                    TitleGet = () => DummyString
                }
            };
            var defaultViews = new Dictionary<int, string>
            {
                [GroupId] = DummyUrl
            };
            var roleProperties = new Dictionary<int, Dictionary<string, bool>>
            {
                [GroupId] = new Dictionary<string, bool>
                {
                    [DummyUrl] = true,
                    [DummyString] = false
                }
            };
            var expectedContents = new List<string>
            {
                $"<select id=\"Option{GroupId}\" runat=\"server\" style=\"width: 150px;\" onchange=\"javascript:ComputeHidden('{GroupId}');\">",
                $"<option selected=\"selected\" value=\"{DummyUrl}\">{DummyString}</option>"
            };
            privateObject.SetFieldOrProperty("defaultViews", defaultViews);
            privateObject.SetFieldOrProperty("roleProperties", roleProperties);
            privateObject.SetFieldOrProperty("views", views);

            // Act
            var result = privateObject.Invoke(RenderDefaultViewMethodName, GroupId) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => expectedContents.ForEach(c => result.ShouldContain(c)));
        }

        [TestMethod]
        public void GetViewsNotInAnyGroup_Should_ExecuteCorrectly()
        {
            // Arrange
            const string Url = "dummy.org/another/Url";
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => new ShimSPWeb
                {
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetGuid = guid => new ShimSPList
                        {
                            IDGet = () => Guid.NewGuid(),
                        }
                    }
                }
            };
            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb
            {
                PropertiesGet = () => new ShimSPPropertyBag()
            };
            ShimStringDictionary.AllInstances.ItemGetString = (_, name) => $"Dummy|{DummyUrl}";
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                QueryStringGet = () => new NameValueCollection
                {
                    ["List"] = Guid.NewGuid().ToString()
                }
            };
            var views = new List<SPView>
            {
                new ShimSPView
                {
                    UrlGet = () => DummyUrl,
                },
                new ShimSPView
                {
                    UrlGet = () => Url,
                }
            };
            privateObject.SetFieldOrProperty("views", views);

            // Act
            privateObject.Invoke(GetViewsNotInAnyGroupMethodName);
            var viewsNotInGroup = privateObject.GetFieldOrProperty("viewsNotInAnyGroup") as List<string>;

            // Assert
            viewsNotInGroup.ShouldSatisfyAllConditions(
                () => viewsNotInGroup.ShouldNotBeNull(),
                () => viewsNotInGroup.ShouldNotBeEmpty(),
                () => viewsNotInGroup.ShouldContain(Url));
        }

        [TestMethod]
        public void RenderOptions_Should_ReturnExpectedContent()
        {
            // Arrange
            const string DefaultViewContent = "Defaut View Content";
            const string AvailableViewsContent = "Available Views Content";
            var expectedContent = new List<string>
            {
                $"<td class=\"ms-authoringcontrols\">{DefaultViewContent}</td>",
                $"<td class=\"ms-authoringcontrols\">{AvailableViewsContent}</td>",
            };
            ShimViewPermissionPage.AllInstances.RenderDefaultViewInt32 = (_, groupId) => DefaultViewContent;
            ShimViewPermissionPage.AllInstances.RenderAvailableViewsInt32 = (_, groupId) => AvailableViewsContent;

            // Act
            var result = privateObject.Invoke(RenderOptionsMethodName, 1) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => expectedContent.ForEach(content => result.ShouldContain(content)));
        }

        [TestMethod]
        public void RenderAvailableViews_Should_ExecuteCorrectly()
        {
            // Arrange
            const string Url = "/some/url";
            const int GroupId = 6; 
            ShimViewPermissionPage.AllInstances.CurrentListGet = _ => new ShimSPList
            {
                ViewsGet = () => 
                {
                    var list = new List<SPView>
                    {
                        new ShimSPView
                        {
                            HiddenGet = () => false,
                            PersonalViewGet = () => false,
                            UrlGet = () => DummyUrl,
                            TitleGet = () => DummyString
                        },
                        new ShimSPView
                        {
                            HiddenGet = () => false,
                            PersonalViewGet = () => false,
                            UrlGet = () => Url,
                            TitleGet = () => DummyString
                        }
                    };
                    return new ShimSPViewCollection().Bind(list);
                }
            };
            privateObject.SetFieldOrProperty("roleProperties", new Dictionary<int, Dictionary<string, bool>>
            {
                [GroupId] = new Dictionary<string, bool>
                {
                    [DummyUrl] = true
                }
            });
            var expectedContent = new List<string>
            {
                $"<input id=\"Chk{GroupId}{DummyUrl}\" title=\"{DummyString}\" type=\"checkbox\" value=\"{DummyUrl}\" " + 
                $"onclick=\"javascript:OptionChange('{GroupId}','chk{GroupId}{DummyUrl}');\" checked=\"checked\"/> {DummyString}<br/>",

                $"<input id=\"Chk{GroupId}{Url}\" title=\"{DummyString}\" type=\"checkbox\" value=\"{Url}\" " + 
                $"onclick=\"javascript:OptionChange('{GroupId}','chk{GroupId}{Url}');\" /> {DummyString}<br/>"
            };
            // Act
            var result = privateObject.Invoke(RenderAvailableViewsMethodName, GroupId) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => expectedContent.ForEach(content => result.ShouldContain(content)));
        }

        [TestMethod]
        public void PrepareRenderPage_Should_ReturnExpectedContent()
        {
            // Arrange
            const string RenderOptionsContent = "Options Content";
            privateObject.SetFieldOrProperty("roleProperties", new Dictionary<int, Dictionary<string, bool>>
            {
                [1] = new Dictionary<string, bool>
                {
                    [DummyUrl] = true
                }
            });
            var expectedContent = new List<string>
            {
                $"<tr><td valign=\"top\" class=\"ms-sectionheader\" style=\"width:200px;padding-right:15px;\">{DummyString}</td>",
                "<script language=\"javascript\" type=\"text/javascript\">ComputeFields();</script>",
                $"<td class=\"ms-authoringcontrols\">{RenderOptionsContent}</td>"
            };
            ShimViewPermissionPage.AllInstances.CurrentListGet = _ => new ShimSPList
            {
                ParentWebGet = () => new ShimSPWeb
                {
                    GroupsGet = () => new ShimSPGroupCollection
                    {
                        GetByIDInt32 = id => new ShimSPGroup
                        {
                            NameGet = () => DummyString
                        }
                    }
                }
            };
            ShimViewPermissionPage.AllInstances.RenderOptionsInt32 = (_, id) => RenderOptionsContent;

            // Act
            var result = privateObject.Invoke(PrepareRenderPageMethodName) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => expectedContent.ForEach(content => result.ShouldContain(content)));
        }

        [TestMethod]
        public void ClearAll_Should_ExecuteCorrectly()
        {
            // Arrange
            var updateWasCalled = false;
            var removeSafelyWasCalled = false;
            var redirectWasCalled = false;
            ShimViewPermissionPage.AllInstances.CurrentListGet = _ => new ShimSPList
            {
                IDGet = () => Guid.NewGuid(),
                ParentWebGet = () => new ShimSPWeb
                {
                    PropertiesGet = () => new ShimSPPropertyBag
                    {
                        Update = () => 
                        {
                            updateWasCalled = true;
                        }
                    }
                }
            };
            ShimStringDictionary.AllInstances.ContainsKeyString = (_, key) => true;
            ShimStringDictionary.AllInstances.ItemGetString = (_, key) => null;
            ShimCacheStore.CurrentGet = () => new ShimCacheStore
            {
                RemoveSafelyStringStringString = (url, navigation, key) => 
                {
                    removeSafelyWasCalled = true;
                }
            };
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => new ShimSPWeb
                {
                    UrlGet = () => DummyUrl
                }
            };
            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (url, flags, context) =>
            {
                redirectWasCalled = true;
                return true;
            };

            // Act
            privateObject.Invoke(ClearAllMethodName, null, EventArgs.Empty);

            // Assert
            viewPermissionPage.ShouldSatisfyAllConditions(
                () => updateWasCalled.ShouldBeTrue(),
                () => removeSafelyWasCalled.ShouldBeTrue(),
                () => redirectWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void SaveCustomPermission_Should_ExecuteCorrectly()
        {
            // Arrange
            var updateWasCalled = false;
            var removeSafelyWasCalled = false;
            var redirectWasCalled = false;
            ShimHttpContext.CurrentGet = () => new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    ParamsGet = () => new NameValueCollection
                    {
                        ["Hidden1"] = DummyString,
                        ["Hidden2"] = string.Empty,
                    }
                }
            };
            privateObject.SetFieldOrProperty("hiddenFields", new List<int> { 1, 2 });
            ShimViewPermissionPage.AllInstances.CurrentListGet = _ => new ShimSPList
            {
                IDGet = () => Guid.NewGuid(),
                ParentWebGet = () => new ShimSPWeb
                {
                    PropertiesGet = () => new ShimSPPropertyBag
                    {
                        Update = () =>
                        {
                            updateWasCalled = true;
                        }
                    }
                }
            };
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => new ShimSPWeb
                {
                    UrlGet = () => DummyUrl
                }
            };
            ShimStringDictionary.AllInstances.ContainsKeyString = (_, key) => true;
            ShimStringDictionary.AllInstances.ItemGetString = (_, key) => null;
            ShimCacheStore.CurrentGet = () => new ShimCacheStore
            {
                RemoveSafelyStringStringString = (url, navigation, key) =>
                {
                    removeSafelyWasCalled = true;
                }
            };
            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (url, flags, context) =>
            {
                redirectWasCalled = true;
                return true;
            };

            // Act
            privateObject.Invoke(SaveCustomPermissionMethodName, null, EventArgs.Empty);

            // Assert
            viewPermissionPage.ShouldSatisfyAllConditions(
                () => updateWasCalled.ShouldBeTrue(),
                () => removeSafelyWasCalled.ShouldBeTrue(),
                () => redirectWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void OnLoad_ViewPermissionKeyFound_ExecutesCorrectly()
        {
            // Arrange
            var getViewsNotInAnyGroupWasCalled = false;
            var registerScriptWasCalled = false;
            ShimViewPermissionPage.AllInstances.CurrentListGet = _ => new ShimSPList
            {
                IDGet = () => Guid.NewGuid(),
                ViewsGet = () =>
                {
                    var list = new List<SPView>
                    {
                        new ShimSPView
                        {
                            HiddenGet = () => false,
                            PersonalViewGet = () => false,
                            UrlGet = () => DummyUrl
                        }
                    };
                    return new ShimSPViewCollection().Bind(list);
                },
                ParentWebGet = () => new ShimSPWeb
                {
                    PropertiesGet = () => new ShimSPPropertyBag()
                }
            };
            
            ShimStringDictionary.AllInstances.ContainsKeyString = (_, key) => true;
            ShimViewPermissionUtil.ConvertFromStringForPageDictionaryOfInt32DictionaryOfStringBooleanRefDictionaryOfInt32StringRefStringSPList = ConvertFromStringForPage;
            ShimViewPermissionPage.AllInstances.PrepareRenderPage = _ => DummyString;
            ShimViewPermissionPage.AllInstances.GetViewsNotInAnyGroup = _ => 
            {
                getViewsNotInAnyGroupWasCalled = true;
            };
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => new ShimSPWeb
                {
                    UrlGet = () => DummyUrl
                }
            };
            ShimViewPermissionPage.AllInstances.RegisterScript = _ =>
            {
                registerScriptWasCalled = true;
            };

            // Act
            privateObject.Invoke(OnLoadMethodName, EventArgs.Empty);

            // Assert
            viewPermissionPage.ShouldSatisfyAllConditions(
                () => getViewsNotInAnyGroupWasCalled.ShouldBeTrue(),
                () => registerScriptWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void OnLoad_ViewPermissionKeyNotFound_ExecutesCorrectly()
        {
            // Arrange
            var registerScriptWasCalled = false;
            ShimViewPermissionPage.AllInstances.CurrentListGet = _ => new ShimSPList
            {
                IDGet = () => Guid.NewGuid(),
                ViewsGet = () =>
                {
                    var list = new List<SPView>
                    {
                        new ShimSPView
                        {
                            HiddenGet = () => false,
                            PersonalViewGet = () => false,
                            UrlGet = () => DummyUrl
                        }
                    };
                    return new ShimSPViewCollection().Bind(list);
                },
                ParentWebGet = () => new ShimSPWeb
                {
                    PropertiesGet = () => new ShimSPPropertyBag(),
                    GroupsGet = () =>
                    {
                        var list = new List<SPGroupCollection>();
                        return new ShimSPGroupCollection().Bind(list);
                    }
                },
                DefaultViewGet = () => new ShimSPView
                {
                    UrlGet = () => DummyUrl
                }
            };
            ShimStringDictionary.AllInstances.ContainsKeyString = (_, key) => false;
            ShimViewPermissionPage.AllInstances.PrepareRenderPage = _ => DummyString;
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => new ShimSPWeb
                {
                    UrlGet = () => DummyUrl
                }
            };
            ShimViewPermissionPage.AllInstances.RegisterScript = _ =>
            {
                registerScriptWasCalled = true;
            };
            privateObject.SetFieldOrProperty("groups", new List<SPGroup>
            {
                new ShimSPGroup
                {
                    IDGet = () => 1
                }
            });

            // Act
            privateObject.Invoke(OnLoadMethodName, EventArgs.Empty);
            var roleProperties = privateObject.GetFieldOrProperty("roleProperties") as Dictionary<int, Dictionary<string, bool>>;

            // Assert
            viewPermissionPage.ShouldSatisfyAllConditions(
                () => registerScriptWasCalled.ShouldBeTrue(),
                () => roleProperties.ShouldNotBeNull(),
                () => roleProperties.ShouldNotBeEmpty(),
                () => roleProperties.Values.Any(p => p.ContainsKey(DummyString)));
        }

        [TestMethod]
        public void RenderPage_Should_ReturnExpectedContent()
        {
            // Arrange
            privateObject.SetFieldOrProperty("pageRender", DummyString);

            // Act
            var result = privateObject.Invoke(RenderPageMethodName) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private void ConvertFromStringForPage(
            ref Dictionary<int, Dictionary<string, bool>> roleProperties, 
            ref Dictionary<int, string> defaultViews, 
            string value, 
            SPList currentList)
        {
            roleProperties.Add(1, new Dictionary<string, bool>
            {
                [DummyUrl] = true
            });
            defaultViews.Add(1, DummyUrl);
        }
    }
}
