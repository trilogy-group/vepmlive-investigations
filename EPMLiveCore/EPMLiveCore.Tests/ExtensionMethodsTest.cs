using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO.Compression.Fakes;
using System.IO.Fakes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
        private CultureInfo _currentCulture;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string CompressedDummyString = "CwAAAB+LCAAAAAAABABzKc3NrQwuKcrMSwcAAMWUqgsAAAA=";
        private const string DummyStringBase64 = "RHVtbXlTdHJpbmc=";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimObj = ShimsContext.Create();

            _currentCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObj?.Dispose();
            Thread.CurrentThread.CurrentCulture = _currentCulture;
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
                        },
                        GetItemsSPQuery = __ => new ShimSPListItemCollection
                        {
                            CountGet = () => DummyInt,
                            ItemGetInt32 = index => new ShimSPListItem
                            {
                                ItemGetString = name => DummyInt
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
            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => _web;

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

        [TestMethod]
        public void Sort_WithListBox_ConfirmResult()
        {
            // Arrange
            var listBox = new ListBox();
            listBox.Items.Add("B");
            listBox.Items.Add("A");

            // Act
            ExtensionMethods.Sort(listBox);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => listBox.Items[0].Text.ShouldBe("A"),
                () => listBox.Items[1].Text.ShouldBe("B"));
        }

        [TestMethod]
        public void Sort_WithListControl_ConfirmResult()
        {
            // Arrange
            var listControl = new DropDownList();
            listControl.Items.Add("B");
            listControl.Items.Add("A");

            // Act
            ExtensionMethods.Sort(listControl);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => listControl.Items[0].Text.ShouldBe("A"),
                () => listControl.Items[1].Text.ShouldBe("B"));
        }

        [TestMethod]
        public void StartOfWeek_OnValidCall_ConfirmResult()
        {
            // Arrange
            var date = DateTime.Today;

            // Act
            var result = ExtensionMethods.StartOfWeek(date);

            // Assert
            result.DayOfWeek.ShouldBe(DayOfWeek.Sunday);
        }

        [TestMethod]
        public void ToFriendlyDate_WhenToday_ConfirmResult()
        {
            // Arrange
            var date = DateTime.Today;

            // Act
            var result = ExtensionMethods.ToFriendlyDate(date);

            // Assert
            result.ShouldBe("Today");
        }

        [TestMethod]
        public void ToFriendlyDate_WhenYesterday_ConfirmResult()
        {
            // Arrange
            var date = DateTime.Today.AddDays(-1);

            // Act
            var result = ExtensionMethods.ToFriendlyDate(date);

            // Assert
            result.ShouldBe("Yesterday");
        }

        [TestMethod]
        public void ToFriendlyDate_WhenTomorrow_ConfirmResult()
        {
            // Arrange
            var date = DateTime.Today.AddDays(1);

            // Act
            var result = ExtensionMethods.ToFriendlyDate(date);

            // Assert
            result.ShouldBe("Tomorrow");
        }

        [TestMethod]
        public void ToFriendlyDate_WhensTomorrow_ConfirmResult()
        {
            // Arrange
            var date = DateTime.Today.AddDays(-2);

            // Act
            var result = ExtensionMethods.ToFriendlyDate(date);

            // Assert
            result.ShouldBe(date.DayOfWeek.ToString());
            // TODO
        }
        
        [TestMethod]
        public void SpDecompress_OnValidCall_ConfirmResult()
        {
            // Arrange
            var bytes = Encoding.UTF8.GetBytes(CompressedDummyString);

            // Act
            //var result = ExtensionMethods.SpDecompress(bytes);

            // Assert
            //TODO
        }

        [TestMethod]
        public void GetExtId_OnValidCall_ConfirmResult()
        {
            // Arrange
            SetupShims();

            // Act
            var result = ExtensionMethods.GetExtId(new ShimSPUser().Instance, _web);

            // Assert
            result.ShouldBe(DummyInt);
        }

        [TestMethod]
        public void GetExtId_WhenListIsNull_ConfirmResult()
        {
            // Arrange
            var web = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection()
            };

            // Act
            var result = ExtensionMethods.GetExtId(new ShimSPUser().Instance, web);

            // Assert
            result.ShouldBe(-1);
        }

        [TestMethod]
        public void GetExtId_WhenListItemCountIsZero_ConfirmResult()
        {
            // Arrange
            var web = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    TryGetListString = _ => new ShimSPList
                    {
                        GetItemsSPQuery = query => new ShimSPListItemCollection
                        {
                            CountGet = () => 0
                        }
                    }
                }
            };

            // Act
            var result = ExtensionMethods.GetExtId(new ShimSPUser().Instance, web);

            // Assert
            result.ShouldBe(-2);
        }

        [TestMethod]
        public void GetExtId_WhenListItemValueIsInvalid_ConfirmResult()
        {
            // Arrange
            var web = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    TryGetListString = _ => new ShimSPList
                    {
                        GetItemsSPQuery = query => new ShimSPListItemCollection
                        {
                            CountGet = () => 1,
                            ItemGetInt32 = index => new ShimSPListItem
                            {
                                ItemGetString = item => DummyString
                            }
                        }
                    }
                }
            };

            // Act
            var result = ExtensionMethods.GetExtId(new ShimSPUser().Instance, web);

            // Assert
            result.ShouldBe(-3);
        }
    }
}
