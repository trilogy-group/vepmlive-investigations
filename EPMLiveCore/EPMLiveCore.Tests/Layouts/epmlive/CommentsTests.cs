using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.SocialEngine.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Layouts.epmlive
{
    [TestClass, ExcludeFromCodeCoverage]
    public class CommentsTests
    {
        private IDisposable _shimsObject;
        private Comments _testObj;
        private PrivateObject _privateObj;

        private const int DummyIntOne = 1;
        private const int DummyIntTwo = 2;
        private const string DummyUrl = "http://xyz.com";
        private const string DummyString = "DummyString";
        private const string CCPeopleEditor = "CCPeopleEditor";
        private const string PageLoadMethod = "Page_Load";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsObject = ShimsContext.Create();
            _testObj = new Comments();
            _privateObj = new PrivateObject(_testObj);

            InitializeUIControls();

            SetupShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsObject?.Dispose();
        }

        private void InitializeUIControls()
        {
            var allFields = _testObj.GetType()
                                       .GetFields(System.Reflection.BindingFlags.Instance |
                                                  System.Reflection.BindingFlags.NonPublic)
                                       .Where(field => field.FieldType.IsSubclassOf(typeof(Control)) &&
                                                       field.FieldType != typeof(CommentCCPeopleEditor));
            foreach (var control in allFields)
            {
                _privateObj.SetField(control.Name, Activator.CreateInstance(control.FieldType));
            }
            var peopleEditor = new ShimCommentCCPeopleEditor().Instance;
            ShimPeopleEditor.AllInstances.CommaSeparatedAccountsGet = _ => string.Empty;
            _privateObj.SetField(CCPeopleEditor, peopleEditor);
        }

        private void SetupShims()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                SiteGet = () => new ShimSPSite
                {
                    MakeFullUrlString = _ => DummyUrl
                },
                WebGet = () => new ShimSPWeb
                {
                    ServerRelativeUrlGet = () => DummyUrl,
                    UrlGet = () => DummyUrl,
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetGuid = _ => new ShimSPList
                        {
                            TitleGet = () => DummyString,
                            GetItemByIdInt32 = _1 => new ShimSPListItem
                            {
                                ItemGetGuid = _2 => DummyString,
                                FieldsGet = () => new ShimSPFieldCollection
                                {
                                    GetFieldByInternalNameString = name => new ShimSPField
                                    {
                                        IdGet = () => Guid.NewGuid()
                                    },
                                    ItemGetGuid = _2 => new ShimSPFieldUser
                                    {
                                        GetFieldValueString = _3 => new ShimSPFieldUserValue
                                        {
                                            UserGet = () => new ShimSPUser
                                            {
                                                IDGet = () => DummyIntOne
                                            }.Instance
                                        }.Instance
                                    }.Instance
                                }
                            }
                        }
                    },
                    CurrentUserGet = () => new ShimSPUser
                    {
                        IDGet = () => DummyIntOne
                    }
                }
            };

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();

            ShimSPSite.ConstructorString = (_, __) => { };

            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                ParamsGet = () => new NameValueCollection
                {
                    ["listId"] = Guid.NewGuid().ToString(),
                    ["itemid"] = DummyIntOne.ToString()
                }
            };

            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = _ => new ShimSPWeb
            {
                CurrentUserGet = () => new ShimSPUser
                {
                    IDGet = () => DummyIntOne,
                    NameGet = () => DummyString,
                    EmailGet = () => DummyString
                },
                SiteUserInfoListGet = () => new ShimSPList
                {
                    GetItemByIdInt32 = __ => new ShimSPListItem
                    {
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            GetFieldByInternalNameString = ___ => new ShimSPField
                            {
                                IdGet = () => Guid.NewGuid()
                            }
                        },
                        ItemGetGuid = guid => DummyString
                    }
                }
            };

            ShimHttpContext.CurrentGet = () => new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    UrlReferrerGet = () => new Uri(DummyUrl)
                }
            };

            ShimSPWeb.AllInstances.Dispose = _ => { };
            ShimSPSite.AllInstances.Dispose = _ => { };
        }

        [TestMethod]
        public void PageLoad_OnValidCall_ConfirmResult()
        {
            // Arrange
            var listUpdated = false;
            var webUpdated = false;
            var setTransaction = false;
            var systemUpdated = false;
            var fields = new List<string>();
            var counter = 0;
            ShimSPListCollection.AllInstances.TryGetListString = (_, __) =>
            {
                if (counter == 0)
                {
                    counter++;
                    return null;
                }
                else
                {
                    return new ShimSPList
                    {
                        GetItemsSPQuery = query => new ShimSPListItemCollection().Bind
                        (
                            new SPListItem[]
                            {
                                new ShimSPListItem
                                {
                                    FieldsGet = () => new ShimSPFieldCollection
                                    {
                                        ItemGetGuid = guid => new ShimSPFieldUser
                                        {
                                            GetFieldValueString = value => new ShimSPFieldUserValue
                                            {
                                                UserGet = () => new ShimSPUser
                                                {
                                                    IDGet = () => DummyIntOne
                                                }
                                            }.Instance
                                        }.Instance
                                    },
                                    ItemGetGuid = guid => DummyIntOne
                                }
                            }
                        ),
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            GetFieldByInternalNameString = name => new ShimSPField
                            {
                                IdGet = () => Guid.NewGuid()
                            }
                        }
                    };
                }
            };
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    AddStringStringSPListTemplate = (x, y, z) => Guid.NewGuid(),
                    ItemGetGuid = x => new ShimSPList
                    {
                        GetItemByIdInt32 = __ => new ShimSPListItem
                        {
                            IDGet = () => DummyIntOne,
                            ItemGetGuid = ___ => DummyIntTwo,
                            FieldsGet = () => new ShimSPFieldCollection
                            {
                                ItemGetGuid = guid => new ShimSPFieldUser
                                {
                                    GetFieldValueString = value => new ShimSPFieldUserValue
                                    {
                                        UserGet = () => new ShimSPUser
                                        {
                                            IDGet = () => DummyIntOne
                                        }
                                    }.Instance
                                }
                            },
                            WebGet = () => new ShimSPWeb
                            {
                                IDGet = () => Guid.NewGuid()
                            },
                            ParentListGet = () => new ShimSPList
                            {
                                IDGet = () => Guid.NewGuid()
                            }
                        },
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            AddStringSPFieldTypeBoolean = (_1, _2, _3) => _1,
                            GetFieldByInternalNameString = name =>
                            {
                                if (!fields.Contains(name))
                                {
                                    fields.Add(name);
                                    return null;
                                }
                                else
                                {
                                    return new ShimSPFieldMultiLineText();
                                }
                            }
                        },
                        Update = () => listUpdated = true,
                        DefaultViewGet = () => new ShimSPView
                        {
                            ViewFieldsGet = () => new ShimSPViewFieldCollection
                            {
                                AddString = y => { }
                            }
                        }
                    },
                    GetListGuidBooleanBooleanBoolean = (_1, _2, _3, _4) => new ShimSPList
                    {
                        GetItemByIdInt32 = id => new ShimSPListItem
                        {
                            ItemGetString = item => DummyIntOne
                        }
                    }
                },
                Update = () => webUpdated = true,
                AllUsersGet = () => new ShimSPUserCollection
                {
                    GetByIDInt32 = id => new ShimSPUser
                    {
                        NameGet = () => DummyString,
                        LoginNameGet = () => DummyString
                    }
                }
            };
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => true;

            ShimSPFieldUserValueCollection.ConstructorSPWebString = (_, __, ___) => { };

            ShimSPFieldLookupValue.ConstructorString = (_, __) => new ShimSPFieldLookupValue
            {
                LookupIdGet = () => DummyIntOne
            };
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyIntOne;

            ShimSPFieldLookupValueCollection.ConstructorString = (_, __) => { };

            ShimSocialEngineProxy.SetTransactionGuidGuidInt32StringSPWeb = (_1, _2, _3, _4, _5) =>
            {
                setTransaction = true;
                return Guid.NewGuid();
            };

            ShimSPListItem.AllInstances.SystemUpdate = _ => systemUpdated = true;

            ShimSPQuery.Constructor = _ => { };
            
            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => listUpdated.ShouldBeTrue(),
                () => webUpdated.ShouldBeTrue(),
                () => setTransaction.ShouldBeTrue(),
                () => systemUpdated.ShouldBeTrue());
        }
    }
}
