using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO.Compression.Fakes;
using System.IO.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.ListDefinitions;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ExtensionMethodsTest
    {
        private IDisposable _shimObj;
        private ShimSPWeb _web;
        private ShimSPSite _site;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string CompressedDummyString = "CwAAAB+LCAAAAAAABABzKc3NrQwuKcrMSwcAAMWUqgsAAAA=";
        private const string DummyStringBase64 = "RHVtbXlTdHJpbmc=";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimObj = ShimsContext.Create();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObj?.Dispose();
        }

        private void SetupShims()
        {
            _web = new ShimSPWeb
            {
                IDGet = () => Guid.NewGuid(),
                SiteGet = () => _site,
                ListsGet = () => new ShimSPListCollection
                {
                    TryGetListString = _ => new ShimSPList
                    {
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            GetFieldByInternalNameString = __ => new ShimSPField
                            {
                                TitleGet = () => DummyString
                            }
                        }
                    }
                }.Bind(new SPList[]
                {
                    new ShimSPList()
                })
            };

            _site = new ShimSPSite
            {
                RootWebGet = () => _web,
                UrlGet = () => DummyString
            };

            ShimSPSite.ConstructorString = (_, __) => { };
            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => new ShimSPWeb().Instance;

            ShimSPWeb.AllInstances.Dispose = _ => { };
        }

        [TestMethod]
        public void Compress_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.Compress(DummyString);

            // Assert
            result.ShouldBe(CompressedDummyString);
        }

        [TestMethod]
        public void Decompress_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.Decompress(CompressedDummyString);

            // Assert
            result.ShouldBe(DummyString);
        }

        [TestMethod]
        public void DecodeToBase64_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.DecodeToBase64(DummyStringBase64);

            // Assert
            result.ShouldBe(DummyString);
        }

        [TestMethod]
        public void EncodeToBase64_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.EncodeToBase64(DummyString);

            // Assert
            result.ShouldBe(DummyStringBase64);
        }

        [TestMethod]
        public void IsGuid_WhenGuidIsValid_ReturnTrue()
        {
            // Arrange
            const string guid = "9c5eec12-6896-4422-9f44-15a87f666bc2";

            // Act
            var result = ExtensionMethods.IsGuid(guid);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void IsGuid_WhenGuidIsInValid_ReturnFalse()
        {
            // Arrange, Act
            var result = ExtensionMethods.IsGuid(DummyString);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void Sha1_OnValidCall_ConfirmResult()
        {
            // Arrange
            const string expectedResult = "57F2CCCED4CAD861AABEF3042ACDA1E5BCC51770";

            // Act
            var result = ExtensionMethods.Sha1(DummyString);

            // Assert
            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        public void Slugify_OnValidCall_ConfirmResult()
        {
            // Arrange
            const string testString = "DúmmyString_x002f_";

            // Act
            var result = ExtensionMethods.Slugify(testString);

            // Assert
            result.ShouldBe(DummyString);
        }

        [TestMethod]
        public void ToPrettierName_WithSPWeb_ConfirmResult()
        {
            // Arrange
            const string internalName = "InternalName";

            SetupShims();

            // Act
            var result = ExtensionMethods.ToPrettierName(internalName, _web.Instance);

            // Assert
            result.ShouldBe(DummyString);
        }

        [TestMethod]
        public void ToPrettierName_WithListAndSPWeb_ConfirmResult()
        {
            // Arrange
            const string internalName = "InternalName";
            var list = new List<string> { DummyString };

            SetupShims();

            // Act
            var result = ExtensionMethods.ToPrettierName(internalName, list, _web.Instance);

            // Assert
            result.ShouldBe(DummyString);
        }

        [TestMethod]
        public void ToPrettierName_WithListName_ConfirmResult()
        {
            // Arrange
            const string internalName = "InternalName";
            const string listName = "ListName";

            SetupShims();

            // Act
            var result = ExtensionMethods.ToPrettierName(internalName, listName, _web.Instance);

            // Assert
            result.ShouldBe(DummyString);
        }

        [TestMethod]
        public void Left_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.Left(DummyString, 5);

            // Assert
            result.ShouldBe("Dummy");
        }

        [TestMethod]
        public void Right_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.Right(DummyString, 6);

            // Assert
            result.ShouldBe("String");
        }

        [TestMethod]
        public void Mid_WithStartIndexAndLength_ConfirmResult()
        {
            // Arrange

            // Act
            var result = ExtensionMethods.Mid(DummyString, 2, 3);

            // Assert
            result.ShouldBe("mmy");
        }

        [TestMethod]
        public void Mid_WithStartIndex_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.Mid(DummyString, 2);

            // Assert
            result.ShouldBe("mmyString");
        }

        [TestMethod]
        public void GetContents_OnValidCall_ConfirmResult()
        {
            // Arrange
            var file = new ShimSPFile
            {
                OpenBinaryStream = () => new ShimFileStream()
            }.Instance;

            ShimFileStream.AllInstances.DisposeBoolean = (_, __) => { };

            ShimStreamReader.ConstructorStream = (_, __) => { };
            ShimStreamReader.AllInstances.DisposeBoolean = (_, __) => { };
            ShimStreamReader.AllInstances.ReadToEnd = _ => DummyString;

            // Act
            var result = ExtensionMethods.GetContents(file);

            // Assert
            result.ShouldBe(DummyString);
        }

        [TestMethod]
        public void UpdateContentsAndSave_OnValidCall_ConfirmResult()
        {
            // Arrange
            var fileSaved = false;
            var file = new ShimSPFile
            {
                ParentFolderGet = () => new ShimSPFolder
                {
                    FilesGet = () => new ShimSPFileCollection
                    {
                        AddStringByteArrayBoolean = (_, __, ___) =>
                        {
                            fileSaved = true;
                            return new ShimSPFile();
                        }
                    }
                },
                UrlGet = () => DummyString
            }.Instance;

            // Act
            ExtensionMethods.UpdateContentsAndSave(file, DummyString);

            // Assert
            fileSaved.ShouldBeTrue();
        }

        [TestMethod]
        public void GetViewFile_OnValidCall_ConfirmResult()
        {
            // Arrange
            var list = new ShimSPList
            {
                ParentWebGet = () => new ShimSPWeb
                {
                    GetFileString = _ => new ShimSPFile().Instance
                }
            }.Instance;

            var view = new ShimSPView
            {
                UrlGet = () => DummyString
            }.Instance;

            // Act
            var result = ExtensionMethods.GetViewFile(list, view);

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetListByTemplateId_WhenSPListTemplateType_ConfirmResult()
        {
            // Arrange
            SetupShims();
            ShimSPList.AllInstances.BaseTemplateGet = _ => SPListTemplateType.AccessApp;

            // Act
            var result = ExtensionMethods.GetListByTemplateId(_web, (int)SPListTemplateType.AccessApp);

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetListByTemplateId_WhenEPMLiveLists_ConfirmResult()
        {
            // Arrange
            SetupShims();
            ShimSPList.AllInstances.BaseTemplateGet = _ => SPListTemplateType.AccessApp;

            // Act
            var result = ExtensionMethods.GetListByTemplateId(_web, (int)EPMLiveLists.MyWork);

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetListByTemplateId_WhenInvalidTemplate_ConfirmResult()
        {
            // Arrange
            SetupShims();
            ShimSPList.AllInstances.BaseTemplateGet = _ => SPListTemplateType.AccessApp;

            // Act
            var result = ExtensionMethods.GetListByTemplateId(_web, DummyInt);

            // Assert
            result.ShouldBeNull();
        }

        [TestMethod]
        public void ToTreeList_OnValidCall_ConfirmResult()
        {
            // Arrange
            var count = 0;
            SetupShims();
            ShimSPWeb.AllInstances.WebsGet = _ => new ShimSPWebCollection
            {
                CountGet = () =>
                {
                    count++;
                    return count <= 2 ? 1 : 0;
                },
                ItemGetInt32 = index => new ShimSPWeb
                {
                    IDGet = () => Guid.NewGuid()
                }.Instance
            };

            // Act
            var result = ExtensionMethods.ToTreeList(_web);

            // Assert
            result.Count.ShouldBe(2);
        }
    }
}
