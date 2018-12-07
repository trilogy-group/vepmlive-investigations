using System;
using System.Collections.Generic;
using System.Collections.Specialized.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Xml;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveSynch.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetTemplatesXmlTests
    {
        private IDisposable _shimContext;
        private GetTemplatesXML _testEntity;
        private PrivateObject _privateObject;

        private const string PageLoadMethodName = "Page_Load";
        private const string AddWebsMethodName = "addWebs";
        private const string AddNonSynchedTemplatesMethodName = "addNonSynchedTemplates";
        private const string AddSynchedTemplatesColumnMethodName = "addSynchedTemplatesColumn";

        private const string DataFieldName = "data";
        private const string DocFieldName = "doc";

        private static readonly Guid DummyGuidWeb = new Guid("6fb34edd-6559-4492-9c2e-2cbd39b62958");
        private static readonly Guid DummyGuidWeb2 = new Guid("375c406e-ef1e-4be9-813a-dc071d7ab480");
        private static readonly Guid DummyGuidSite = new Guid("34bb6a5c-977c-4ce8-b96a-0ff7d0897ece");
        private static readonly DateTime DummyDateTime = new DateTime(2018, 1, 1);
        private const string DummyUrl = "DummyUrl";
        private const string DummyRelativeUrl = "/";
        private const string DummyRelativeUrl2 = "/DummyRelative/";
        private const string DummyUrlWeb = "http://tempuri.org";
        private const string PropertySiteTemplateIds = "EPMLiveSiteTemplateIDs";
        private const string PropertyTemplateId = "EPMLiveTemplateID";
        private const string XmlRowNodeOnly = "<rows></rows>";
        private const string XmlFull = "<rows><head><column type=\"tree\" width=\"298\">Sites</column></head></rows>";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            _testEntity = new GetTemplatesXML();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
            _testEntity?.Dispose();
        }

        [TestMethod]
        public void PageLoad_TTypeTmp1tColOnly_FillDataField()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                SiteGet = () => new ShimSPSite()
                {
                    RootWebGet = () => new ShimSPWeb()
                    {
                        PropertiesGet = () =>
                        {
                            var propertyBag = new ShimSPPropertyBag();
                            var stringDictionary = new ShimStringDictionary(propertyBag)
                            {
                                ItemGetString = key => PropertySiteTemplateIds
                            };
                            return propertyBag;
                        },
                        SiteGet = () => new ShimSPSite()
                        {
                            CatchAccessDeniedExceptionSetBoolean = catchAccess => { }
                        }
                    }
                }
            };

            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                ItemGetString = itemName =>
                {
                    switch (itemName)
                    {
                        case "maxlistsyncdate":
                            return "maxlistsyncdate";
                        case "ttype":
                            return "tmpltcolonly";
                        default:
                            break;
                    }

                    return null;
                }
            };
            ShimPage.AllInstances.ResponseGet = sender => new ShimHttpResponse()
            {
                CacheGet = () => new ShimHttpCachePolicy()
                {
                    SetCacheabilityHttpCacheability = cacheAbility => { }
                },
                ExpiresSetInt32 = expires => { },
                ContentTypeSetString = contentType => { }
            };

            // Act
            _privateObject.Invoke(PageLoadMethodName, this, EventArgs.Empty);

            // Assert
            var actualData = (string)_privateObject.GetField(DataFieldName);

            actualData.ShouldBe("<rows><head><column type=\"tree\" width=\"598\">Sites</column></head></rows>");
        }

        [TestMethod]
        public void PageLoad_TTypeNon_FillDataField()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                SiteGet = () => new ShimSPSite()
                {
                    RootWebGet = () => new ShimSPWeb()
                    {
                        PropertiesGet = () =>
                        {
                            var propertyBag = new ShimSPPropertyBag();
                            var stringDictionary = new ShimStringDictionary(propertyBag)
                            {
                                ItemGetString = key => PropertySiteTemplateIds
                            };
                            return propertyBag;
                        },
                        SiteGet = () => new ShimSPSite()
                        {
                            CatchAccessDeniedExceptionSetBoolean = catchAccess => { }
                        }
                    }
                }
            };

            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                ItemGetString = itemName =>
                {
                    switch (itemName)
                    {
                        case "maxlistsyncdate":
                            return "maxlistsyncdate";
                        case "ttype":
                            return "non";
                        default:
                            break;
                    }

                    return null;
                }
            };
            ShimPage.AllInstances.ResponseGet = sender => new ShimHttpResponse()
            {
                CacheGet = () => new ShimHttpCachePolicy()
                {
                    SetCacheabilityHttpCacheability = cacheAbility => { }
                },
                ExpiresSetInt32 = expires => { },
                ContentTypeSetString = contentType => { }
            };

            // Act
            _privateObject.Invoke(PageLoadMethodName, this, EventArgs.Empty);

            // Assert
            var actualData = (string)_privateObject.GetField(DataFieldName);

            actualData.ShouldBe("<rows><head><column type=\"tree\" width=\"298\">Sites</column></head><row open=\"1\" locked=\"1\" id=\"00000000-0000-0000-0000-000000000000\"><cell image=\"STSICON.GIF\"> &lt;/a&gt;</cell></row></rows>");
        }

        [TestMethod]
        public void PageLoad_TTypeNull_FillDataField()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                SiteGet = () => new ShimSPSite()
                {
                    RootWebGet = () => new ShimSPWeb()
                    {
                        PropertiesGet = () =>
                        {
                            var propertyBag = new ShimSPPropertyBag();
                            var stringDictionary = new ShimStringDictionary(propertyBag)
                            {
                                ItemGetString = key => PropertySiteTemplateIds
                            };
                            return propertyBag;
                        },
                        SiteGet = () => new ShimSPSite()
                        {
                            CatchAccessDeniedExceptionSetBoolean = catchAccess => { }
                        }
                    }
                }
            };

            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                ItemGetString = itemName =>
                {
                    switch (itemName)
                    {
                        case "maxlistsyncdate":
                            return "maxlistsyncdate";
                        case "ttype":
                            return null;
                        default:
                            break;
                    }

                    return null;
                }
            };
            ShimPage.AllInstances.ResponseGet = sender => new ShimHttpResponse()
            {
                CacheGet = () => new ShimHttpCachePolicy()
                {
                    SetCacheabilityHttpCacheability = cacheAbility => { }
                },
                ExpiresSetInt32 = expires => { },
                ContentTypeSetString = contentType => { }
            };

            // Act
            _privateObject.Invoke(PageLoadMethodName, this, EventArgs.Empty);

            // Assert
            var actualData = (string)_privateObject.GetField(DataFieldName);

            actualData.ShouldBe("<rows><head><settings><colwidth>%</colwidth></settings><column type=\"tree\" width=\"25\">Sites</column><column type=\"ro\" width=\"12\" align=\"center\">Edit</column><column type=\"ro\" width=\"12\" align=\"center\">Save</column><column type=\"ro\" width=\"12\" align=\"center\">Rename</column><column type=\"ro\" width=\"12\" align=\"center\">Remove</column><column type=\"ro\" width=\"12\">Save Status</column><column type=\"ro\" width=\"15\">Last Saved</column></head></rows>");
        }

        [TestMethod]
        public void PageLoad_RequestNull_FillDataField()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                SiteGet = () => new ShimSPSite()
                {
                    RootWebGet = () => new ShimSPWeb()
                    {
                        PropertiesGet = () =>
                        {
                            var propertyBag = new ShimSPPropertyBag();
                            var stringDictionary = new ShimStringDictionary(propertyBag)
                            {
                                ItemGetString = key => PropertySiteTemplateIds
                            };
                            return propertyBag;
                        },
                        SiteGet = () => new ShimSPSite()
                        {
                            CatchAccessDeniedExceptionSetBoolean = catchAccess => { }
                        }
                    }
                }
            };

            // Act
            _privateObject.Invoke(PageLoadMethodName, this, EventArgs.Empty);

            // Assert
            var actualData = (string)_privateObject.GetField(DataFieldName);

            actualData.ShouldBe("Request is not available in this context");
        }

        [TestMethod]
        public void AddWebs_WithChild_ReturnsTrueFieldNodeXml()
        {
            // Arrange
            var webChild = new ShimSPWeb()
            {
                IDGet = () => DummyGuidWeb,
                SiteGet = () => new ShimSPSite()
                {
                    RootWebGet = () => new ShimSPWeb()
                    {
                        PropertiesGet = () =>
                        {
                            var propertyBag = new ShimSPPropertyBag();
                            var stringDictionary = new ShimStringDictionary(propertyBag)
                            {
                                ItemGetString = key => DummyGuidWeb.ToString()
                            };
                            return propertyBag;
                        },
                        GetFileString = url => new ShimSPFile(),
                        SiteGet = () => new ShimSPSite()
                        {
                            UrlGet = () => DummyUrl
                        }
                    }
                },
                WebsGet = () => new ShimSPWebCollection().Bind(
                    new List<SPWeb>().AsEnumerable()),
                PropertiesGet = () =>
                {
                    var propertyBag = new ShimSPPropertyBag();
                    var stringDictionary = new ShimStringDictionary(propertyBag)
                    {
                        ItemGetString = key => PropertyTemplateId,
                        ContainsKeyString = keyParam => true
                    };
                    return propertyBag;
                },
                ServerRelativeUrlGet = () => DummyRelativeUrl2
            };

            var web = new ShimSPWeb()
            {
                SiteGet = () => new ShimSPSite()
                {
                    IDGet = () => DummyGuidSite,
                    RootWebGet = () => new ShimSPWeb()
                    {
                        PropertiesGet = () =>
                        {
                            var propertyBag = new ShimSPPropertyBag();
                            var stringDictionary = new ShimStringDictionary(propertyBag)
                            {
                                ItemGetString = key => null
                            };
                            return propertyBag;
                        },
                        GetFileString = url => new ShimSPFile(),
                        SiteGet = () => new ShimSPSite()
                        {
                            UrlGet = () => DummyUrl
                        }
                    }
                },
                WebsGet = () => new ShimSPWebCollection().Bind(
                    new List<SPWeb>
                    {
                        webChild
                    }.AsEnumerable()),
                PropertiesGet = () =>
                {
                    var propertyBag = new ShimSPPropertyBag();
                    var stringDictionary = new ShimStringDictionary(propertyBag)
                    {
                        ItemGetString = key => PropertyTemplateId,
                        ContainsKeyString = keyParam => true
                    };
                    return propertyBag;
                },
                ServerRelativeUrlGet = () => DummyRelativeUrl
            };
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (sender, permissionMask) => true;
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    UrlGet = () => DummyUrlWeb
                }
            };

            var doc = new XmlDocument();
            doc.LoadXml(XmlRowNodeOnly);
            var mainNode = doc.ChildNodes[0];

            _privateObject.SetField(DocFieldName, doc);

            var expectedXml = new List<string>()
            {
                "<rows>",
                "<row open=\"1\" locked=\"1\" id=\"/\">",
                $"<row open=\"1\" locked=\"1\" id=\"{DummyRelativeUrl2}\">",
                "<cell image=\"ICODCT.GIF\"> &lt;/a&gt;</cell>",
                "<cell> &lt;a href='' target='_blank'&gt;Edit&lt;/a&gt;</cell>",
                "<cell> &lt;a href='#' onclick=\"showSaveTemplateForm('');return false\"&gt;Save&lt;/a&gt;</cell>",
                "<cell> &lt;a href='#' onclick=\"showRenameTemplateForm('','');return false\"&gt;Rename&lt;/a&gt;</cell>",
                "<cell> &lt;a href='#' onclick=\"delTemplate('/DummyRelative/');return false\"&gt;Remove&lt;/a&gt;</cell>",
                "<cell align=\"center\" title=\"Based on the date/time of the last Enterprise List Synchronization, it is possible that this template is outdated and a synchronization is recommended.\">&lt;img src=\"/_layouts/images/yellow.gif\" alt=\"\" title=\"Based on the date/time of the last Enterprise List Synchronization, it is possible that this template is outdated and a synchronization is recommended.\" &gt;</cell>",
                "<cell align=\"center\"> </cell>",
                "<cell image=\"STSICON.GIF\"> &lt;/a&gt;</cell>",
                "<cell> </cell>",
                "</row>",
                "</rows>"
            };

            // Act
            var actualResult = (bool)_privateObject.Invoke(AddWebsMethodName, web.Instance, mainNode);

            // Assert
            var actualXml = mainNode.OuterXml;

            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => expectedXml.ForEach(c => actualXml.ShouldContain(c)));
        }

        [TestMethod]
        public void AddWebs_WithoutChild_ReturnsTrueFieldNodeXml()
        {
            // Arrange
            var web = new ShimSPWeb()
            {
                IDGet = () => DummyGuidWeb,
                SiteGet = () => new ShimSPSite()
                {
                    IDGet = () => DummyGuidSite,
                    RootWebGet = () => new ShimSPWeb()
                    {
                        PropertiesGet = () =>
                        {
                            var propertyBag = new ShimSPPropertyBag();
                            var stringDictionary = new ShimStringDictionary(propertyBag)
                            {
                                ItemGetString = key => DummyGuidWeb.ToString()
                            };
                            return propertyBag;
                        },
                        GetFileString = url => new ShimSPFile()
                        {
                            ExistsGet = () => true,
                            TimeLastModifiedGet = () => DummyDateTime
                        },
                        SiteGet = () => new ShimSPSite()
                        {
                            UrlGet = () => DummyUrl
                        }
                    }
                },
                WebsGet = () => new ShimSPWebCollection().Bind(
                    new List<SPWeb>().AsEnumerable()),
                PropertiesGet = () =>
                {
                    var propertyBag = new ShimSPPropertyBag();
                    var stringDictionary = new ShimStringDictionary(propertyBag)
                    {
                        ItemGetString = key => PropertyTemplateId,
                        ContainsKeyString = keyParam => true
                    };
                    return propertyBag;
                },
                ServerRelativeUrlGet = () => DummyRelativeUrl
            };
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (sender, permissionMask) => true;
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    UrlGet = () => DummyUrlWeb
                }
            };

            var doc = new XmlDocument();
            doc.LoadXml(XmlRowNodeOnly);
            var mainNode = doc.ChildNodes[0];

            _privateObject.SetField(DocFieldName, doc);
            _privateObject.SetField("sMaxListSyncDate", "2017,1,1");

            var expectedXml = new List<string>()
            {
                "<rows>",
                "<row open=\"1\" locked=\"1\" id=\"/\">",
                "<cell image=\"ICODCT.GIF\"> &lt;/a&gt;</cell>",
                "<cell> &lt;a href='' target='_blank'&gt;Edit&lt;/a&gt;</cell>",
                "<cell> &lt;a href='#' onclick=\"showSaveTemplateForm('');return false\"&gt;Save&lt;/a&gt;</cell>",
                "<cell> &lt;a href='#' onclick=\"showRenameTemplateForm('','');return false\"&gt;Rename&lt;/a&gt;</cell>",
                "<cell> &lt;a href='#' onclick=\"delTemplate('/');return false\"&gt;Remove&lt;/a&gt;</cell>",
                "<cell align=\"center\" title=\"Based on the date/time of the last Enterprise List Synchronization, this template is up to date.\">&lt;img src=\"/_layouts/images/green.gif\" alt=\"\" title=\"Based on the date/time of the last Enterprise List Synchronization, this template is up to date.\" &gt;</cell>",
                "<cell align=\"center\">1/1/2018 12:00:00 AM</cell></row></rows>"
            };

            // Act
            var actualResult = (bool)_privateObject.Invoke(AddWebsMethodName, web.Instance, mainNode);

            // Assert
            var actualXml = mainNode.OuterXml;

            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => expectedXml.ForEach(c => actualXml.ShouldContain(c)));
        }

        [TestMethod]
        public void AddNonSynchedTemplates_WithChild_ReturnsTrueFieldNodeXml()
        {
            // Arrange
            var webChild = new ShimSPWeb()
            {
                IDGet = () => DummyGuidWeb2,
                WebsGet = () => new ShimSPWebCollection().Bind(
                    new List<SPWeb>().AsEnumerable()),
                PropertiesGet = () =>
                {
                    var propertyBag = new ShimSPPropertyBag();
                    var stringDictionary = new ShimStringDictionary(propertyBag)
                    {
                        ItemGetString = key => null,
                        ContainsKeyString = keyParam => true
                    };
                    return propertyBag;
                },
                SiteGet = () => new ShimSPSite()
                {
                    RootWebGet = () => new ShimSPWeb()
                    {
                        PropertiesGet = () =>
                        {
                            var propertyBag = new ShimSPPropertyBag();
                            var stringDictionary = new ShimStringDictionary(propertyBag)
                            {
                                ItemGetString = key => null
                            };
                            return propertyBag;
                        }
                    }
                }
            };

            var web = new ShimSPWeb()
            {
                IDGet = () => DummyGuidWeb,
                WebsGet = () => new ShimSPWebCollection().Bind(
                    new List<SPWeb>
                    {
                        webChild
                    }.AsEnumerable()),
                PropertiesGet = () =>
                {
                    var propertyBag = new ShimSPPropertyBag();
                    var stringDictionary = new ShimStringDictionary(propertyBag)
                    {
                        ItemGetString = key => DummyGuidSite.ToString(),
                        ContainsKeyString = keyParam => true
                    };
                    return propertyBag;
                },
                SiteGet = () => new ShimSPSite()
                {
                    RootWebGet = () => new ShimSPWeb()
                    {
                        PropertiesGet = () =>
                        {
                            var propertyBag = new ShimSPPropertyBag();
                            var stringDictionary = new ShimStringDictionary(propertyBag)
                            {
                                ItemGetString = key => DummyGuidSite.ToString(),
                                ContainsKeyString = keyParam => true
                            };
                            return propertyBag;
                        }
                    }
                }
            };
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (sender, permissionMask) => true;

            var doc = new XmlDocument();
            doc.LoadXml(XmlFull);
            var mainNode = doc.ChildNodes[0];

            _privateObject.SetField(DocFieldName, doc);

            var expectedXml = new List<string>()
            {
                "<rows>",
                "<head>",
                "<column type=\"tree\" width=\"298\">Sites</column></head>",
                $"<row open=\"1\" locked=\"1\" id=\"{DummyGuidWeb}\">",
                $"<row open=\"1\" locked=\"1\" id=\"{DummyGuidWeb2}\">",
                "<cell image=\"STSICON.GIF\"> &lt;/a&gt;</cell></row>",
                "<cell image=\"STSICON.GIF\"> &lt;/a&gt;</cell></row></rows>"
            };

            // Act
            var actualResult = (bool)_privateObject.Invoke(AddNonSynchedTemplatesMethodName, web.Instance, mainNode);

            // Assert
            var actualXml = mainNode.OuterXml;

            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => expectedXml.ForEach(c => actualXml.ShouldContain(c)));
        }

        [TestMethod]
        public void AddSynchedTemplatesColumn_WithChild_ReturnsTrueFieldNodeXml()
        {
            // Arrange
            var webChild = new ShimSPWeb()
            {
                IDGet = () => DummyGuidWeb2,
                WebsGet = () => new ShimSPWebCollection().Bind(
                    new List<SPWeb>().AsEnumerable()),
                PropertiesGet = () =>
                {
                    var propertyBag = new ShimSPPropertyBag();
                    var stringDictionary = new ShimStringDictionary(propertyBag)
                    {
                        ItemGetString = key => PropertyTemplateId,
                        ContainsKeyString = keyParam => true
                    };
                    return propertyBag;
                },
                SiteGet = () => new ShimSPSite()
                {
                    RootWebGet = () => new ShimSPWeb()
                    {
                        PropertiesGet = () =>
                        {
                            var propertyBag = new ShimSPPropertyBag();
                            var stringDictionary = new ShimStringDictionary(propertyBag)
                            {
                                ItemGetString = key => DummyGuidWeb2.ToString()
                            };
                            return propertyBag;
                        }
                    }
                }
            };

            var web = new ShimSPWeb()
            {
                IDGet = () => DummyGuidWeb,
                WebsGet = () => new ShimSPWebCollection().Bind(
                    new List<SPWeb>
                    {
                        webChild
                    }.AsEnumerable()),
                PropertiesGet = () =>
                {
                    var propertyBag = new ShimSPPropertyBag();
                    var stringDictionary = new ShimStringDictionary(propertyBag)
                    {
                        ItemGetString = key => DummyGuidSite.ToString(),
                        ContainsKeyString = keyParam => false
                    };
                    return propertyBag;
                },
                SiteGet = () => new ShimSPSite()
                {
                    RootWebGet = () => new ShimSPWeb()
                    {
                        PropertiesGet = () =>
                        {
                            var propertyBag = new ShimSPPropertyBag();
                            var stringDictionary = new ShimStringDictionary(propertyBag)
                            {
                                ItemGetString = key => DummyGuidSite.ToString(),
                                ContainsKeyString = keyParam => true
                            };
                            return propertyBag;
                        }
                    }
                }
            };
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (sender, permissionMask) => true;

            var doc = new XmlDocument();
            doc.LoadXml(XmlFull);
            var mainNode = doc.ChildNodes[0];

            _privateObject.SetField(DocFieldName, doc);

            var expectedXml = new List<string>()
            {
                "<rows>",
                "<head>",
                "<column type=\"tree\" width=\"298\">Sites</column></head>",
                "<row open=\"1\" locked=\"1\" id=\"------\">",
                $"<row open=\"1\" locked=\"1\" id=\"{PropertyTemplateId}\">",
                "<cell image=\"ICODCT.GIF\"> &lt;/a&gt;</cell></row>",
                "<cell image=\"STSICON.GIF\"> &lt;/a&gt;</cell></row></rows>"
            };

            // Act
            var actualResult = (bool)_privateObject.Invoke(AddSynchedTemplatesColumnMethodName, web.Instance, mainNode);

            // Assert
            var actualXml = mainNode.OuterXml;

            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => expectedXml.ForEach(c => actualXml.ShouldContain(c)));
        }
    }
}
