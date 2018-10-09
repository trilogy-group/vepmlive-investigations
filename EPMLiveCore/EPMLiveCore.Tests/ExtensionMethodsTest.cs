using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Fakes;
using System.Globalization;
using System.IO.Compression.Fakes;
using System.IO.Fakes;
using System.Text;
using System.Threading;
using System.Web.UI.WebControls;
using EPMLiveCore.Controls.Navigation.Fakes;
using EPMLiveCore.ListDefinitions;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.WebPartPages.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
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
        private const double DummyDouble = 1D;
        private const decimal DummyDecimal = 1M;
        private const long DummyLong = 1L;
        private const float DummyFloat = 1F;
        private const char DummyChar = 'A';
        private const short DummyShort = 1;
        private const ushort DummyUShort = 1;
        private const uint DummyUInt = 1;
        private const ulong DummyULong = 1;
        private const byte DummyByte = new byte();
        private const sbyte DummySByte = new sbyte();
        private const bool DummyBool = true;
        private const int DummyUnixTime = 1514764800;
        private const int LocaleId = 1033;
        private const string InternalName = "InternalName";
        private const string BString = "B";
        private const string AString = "A";
        private const string TimeFormat = "hh:mm:ss tt";
        private const string DateFormat = "M/dd/yyyy";

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
                                ItemGetString = name => DummyInt,
                                IDGet = () => DummyInt
                            }
                        }
                    }
                }.Bind(new SPList[]
                {
                    new ShimSPList()
                }),
                CurrentUserGet = () => new ShimSPUser
                {
                    RegionalSettingsGet = () => new ShimSPRegionalSettings
                    {
                        LocaleIdGet = () => LocaleId,
                        TimeZoneGet = () => new ShimSPTimeZone
                        {
                            UTCToLocalTimeDateTime = date => date
                        }
                    }
                }
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
            SetupShims();

            // Act
            var result = ExtensionMethods.ToPrettierName(InternalName, _web.Instance);

            // Assert
            result.ShouldBe(DummyString);
        }

        [TestMethod]
        public void ToPrettierName_WithListAndSPWeb_ConfirmResult()
        {
            // Arrange
            var list = new List<string> { DummyString };

            SetupShims();

            // Act
            var result = ExtensionMethods.ToPrettierName(InternalName, list, _web.Instance);

            // Assert
            result.ShouldBe(DummyString);
        }

        [TestMethod]
        public void ToPrettierName_WithListName_ConfirmResult()
        {
            // Arrange
            const string listName = "ListName";

            SetupShims();

            // Act
            var result = ExtensionMethods.ToPrettierName(InternalName, listName, _web.Instance);

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
            listBox.Items.Add(BString);
            listBox.Items.Add(AString);

            // Act
            ExtensionMethods.Sort(listBox);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => listBox.Items[0].Text.ShouldBe(AString),
                () => listBox.Items[1].Text.ShouldBe(BString));
        }

        [TestMethod]
        public void Sort_WithListControl_ConfirmResult()
        {
            // Arrange
            var listControl = new DropDownList();
            listControl.Items.Add(BString);
            listControl.Items.Add(AString);

            // Act
            ExtensionMethods.Sort(listControl);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => listControl.Items[0].Text.ShouldBe(AString),
                () => listControl.Items[1].Text.ShouldBe(BString));
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
        public void ToFriendlyDate_WhenBeforeLastWeek_ConfirmResult()
        {
            // Arrange
            var date = DateTime.Today.AddDays(-25);

            // Act
            var result = ExtensionMethods.ToFriendlyDate(date);

            // Assert
            result.ShouldBe(date.ToString("MMM d"));
        }

        [TestMethod]
        public void ToFriendlyDate_WhenBeforeThisWeek_ConfirmResult()
        {
            // Arrange
            var date = new DateTime(2018, 9, 13);
            var dayOfWeek = date.DayOfWeek;

            ShimDateTime.TodayGet = () => new DateTime(2018, 9, 20);

            // Act
            var result = ExtensionMethods.ToFriendlyDate(date);

            // Assert
            result.ShouldBe($"Last {dayOfWeek}");
        }

        [TestMethod]
        public void ToFriendlyDate_WhenInThisWeek_ConfirmResult()
        {
            // Arrange
            var date = new DateTime(2018, 9, 17);

            ShimDateTime.TodayGet = () => new DateTime(2018, 9, 20);

            // Act
            var result = ExtensionMethods.ToFriendlyDate(date);

            // Assert
            result.ShouldBe(date.DayOfWeek.ToString());
        }

        [TestMethod]
        public void ToFriendlyDate_WhenAfterTomorrow_ConfirmResult()
        {
            // Arrange
            var date = new DateTime(2018, 9, 22);
            var dayOfWeek = date.DayOfWeek;

            ShimDateTime.TodayGet = () => new DateTime(2018, 9, 20);

            // Act
            var result = ExtensionMethods.ToFriendlyDate(date);

            // Assert
            result.ShouldBe($"This {dayOfWeek}");
        }

        [TestMethod]
        public void ToFriendlyDate_WhenInNextWeek_ConfirmResult()
        {
            // Arrange
            var date = new DateTime(2018, 9, 28);
            var dayOfWeek = date.DayOfWeek;

            ShimDateTime.TodayGet = () => new DateTime(2018, 9, 20);

            // Act
            var result = ExtensionMethods.ToFriendlyDate(date);

            // Assert
            result.ShouldBe($"Next {dayOfWeek}");
        }

        [TestMethod]
        public void ToFriendlyDate_WhenAfterNextWeek_ConfirmResult()
        {
            // Arrange
            var date = new DateTime(2018, 10, 2);

            ShimDateTime.TodayGet = () => new DateTime(2018, 9, 20);

            // Act
            var result = ExtensionMethods.ToFriendlyDate(date);

            // Assert
            result.ShouldBe(date.ToString("MMM d"));
        }

        [TestMethod]
        public void ToFriendlyDateAndTime_WhenToday_ConfirmResult()
        {
            // Arrange
            var date = DateTime.Now;
            var time = new DateTime(date.TimeOfDay.Ticks).ToString(TimeFormat);

            // Act
            var result = ExtensionMethods.ToFriendlyDateAndTime(date);

            // Assert
            result.ShouldBe($"Today at {time}");
        }

        [TestMethod]
        public void ToFriendlyDateAndTime_WhenYesterday_ConfirmResult()
        {
            // Arrange
            var today = new DateTime(2018, 9, 20);
            var date = today.AddDays(-1);
            var time = new DateTime(date.TimeOfDay.Ticks).ToString(TimeFormat);

            ShimDateTime.TodayGet = () => today;

            // Act
            var result = ExtensionMethods.ToFriendlyDateAndTime(date);

            // Assert
            result.ShouldBe($"Yesterday at {time}");
        }

        [TestMethod]
        public void ToFriendlyDateAndTime_WhenTomorrow_ConfirmResult()
        {
            // Arrange
            var date = DateTime.Now.AddDays(1);
            var time = new DateTime(date.TimeOfDay.Ticks).ToString(TimeFormat);

            // Act
            var result = ExtensionMethods.ToFriendlyDateAndTime(date);

            // Assert
            result.ShouldBe($"Tomorrow at {time}");
        }

        [TestMethod]
        public void ToFriendlyDateAndTime_WhenBeforeLastWeek_ConfirmResult()
        {
            // Arrange
            var date = DateTime.Now.AddDays(-25);
            var time = new DateTime(date.TimeOfDay.Ticks).ToString(TimeFormat);
            var dateToString = date.ToString(DateFormat);

            // Act
            var result = ExtensionMethods.ToFriendlyDateAndTime(date);

            // Assert
            result.ShouldBe($"{dateToString} at {time}");
        }

        [TestMethod]
        public void ToFriendlyDateAndTime_WhenBeforeThisWeek_ConfirmResult()
        {
            // Arrange
            var date = new DateTime(2018, 9, 13, 10, 10, 10);
            var time = new DateTime(date.TimeOfDay.Ticks).ToString(TimeFormat);
            var dayOfWeek = date.DayOfWeek;

            ShimDateTime.TodayGet = () => new DateTime(2018, 9, 20);

            // Act
            var result = ExtensionMethods.ToFriendlyDateAndTime(date);

            // Assert
            result.ShouldBe($"Last {dayOfWeek} at {time}");
        }

        [TestMethod]
        public void ToFriendlyDateAndTime_WhenInThisWeek_ConfirmResult()
        {
            // Arrange
            var date = new DateTime(2018, 9, 17, 10, 10, 10);
            var time = new DateTime(date.TimeOfDay.Ticks).ToString(TimeFormat);
            var dayOfWeek = date.DayOfWeek;

            ShimDateTime.TodayGet = () => new DateTime(2018, 9, 20);

            // Act
            var result = ExtensionMethods.ToFriendlyDateAndTime(date);

            // Assert
            result.ShouldBe($"{dayOfWeek} at {time}");
        }

        [TestMethod]
        public void ToFriendlyDateAndTime_WhenAfterTomorrow_ConfirmResult()
        {
            // Arrange
            var date = new DateTime(2018, 9, 22, 10, 10, 10);
            var time = new DateTime(date.TimeOfDay.Ticks).ToString(TimeFormat);
            var dayOfWeek = date.DayOfWeek;

            ShimDateTime.TodayGet = () => new DateTime(2018, 9, 20);

            // Act
            var result = ExtensionMethods.ToFriendlyDateAndTime(date);

            // Assert
            result.ShouldBe($"This {dayOfWeek} at {time}");
        }

        [TestMethod]
        public void ToFriendlyDateAndTime_WhenInNextWeek_ConfirmResult()
        {
            // Arrange
            var date = new DateTime(2018, 9, 28, 10, 10, 10);
            var time = new DateTime(date.TimeOfDay.Ticks).ToString(TimeFormat);
            var dayOfWeek = date.DayOfWeek;

            ShimDateTime.TodayGet = () => new DateTime(2018, 9, 20);

            // Act
            var result = ExtensionMethods.ToFriendlyDateAndTime(date);

            // Assert
            result.ShouldBe($"Next {dayOfWeek} at {time}");
        }

        [TestMethod]
        public void ToFriendlyDateAndTime_WhenAfterNextWeek_ConfirmResult()
        {
            // Arrange
            var date = new DateTime(2018, 10, 2, 10, 10, 10);
            var time = new DateTime(date.TimeOfDay.Ticks).ToString(TimeFormat);
            var dateToString = date.ToString(DateFormat);

            ShimDateTime.TodayGet = () => new DateTime(2018, 9, 20);

            // Act
            var result = ExtensionMethods.ToFriendlyDateAndTime(date);

            // Assert
            result.ShouldBe($"{dateToString} at {time}");
        }

        [TestMethod]
        public void ToFriendlyDateAndTimeSPWeb_WhenToday_ConfirmResult()
        {
            // Arrange
            var timeFormatPattern = CultureInfo.GetCultureInfo(Convert.ToInt32(LocaleId)).DateTimeFormat.LongTimePattern;
            var date = DateTime.Now;
            var time = new DateTime(date.TimeOfDay.Ticks).ToString(timeFormatPattern);
            SetupShims();

            // Act
            var result = ExtensionMethods.ToFriendlyDateAndTime(date, _web);

            // Assert
            result.ShouldBe($"Today at {time}");
        }

        [TestMethod]
        public void ToFriendlyDateAndTimeSPWeb_WhenYesterday_ConfirmResult()
        {
            // Arrange
            var timeFormatPattern = CultureInfo.GetCultureInfo(Convert.ToInt32(LocaleId)).DateTimeFormat.LongTimePattern;
            var today = new DateTime(2018, 9, 20);
            var date = today.AddDays(-1);
            var time = new DateTime(date.TimeOfDay.Ticks).ToString(timeFormatPattern);
            SetupShims();

            ShimDateTime.TodayGet = () => today;

            // Act
            var result = ExtensionMethods.ToFriendlyDateAndTime(date, _web);

            // Assert
            result.ShouldBe($"Yesterday at {time}");
        }

        [TestMethod]
        public void ToFriendlyDateAndTimeSPWeb_WhenTomorrow_ConfirmResult()
        {
            // Arrange
            var timeFormatPattern = CultureInfo.GetCultureInfo(Convert.ToInt32(LocaleId)).DateTimeFormat.LongTimePattern;
            var date = DateTime.Now.AddDays(1);
            var time = new DateTime(date.TimeOfDay.Ticks).ToString(timeFormatPattern);
            SetupShims();

            // Act
            var result = ExtensionMethods.ToFriendlyDateAndTime(date, _web);

            // Assert
            result.ShouldBe($"Tomorrow at {time}");
        }

        [TestMethod]
        public void ToFriendlyDateAndTimeSPWeb_WhenBeforeLastWeek_ConfirmResult()
        {
            // Arrange
            var dateFormatPattern = CultureInfo.GetCultureInfo(Convert.ToInt32(LocaleId)).DateTimeFormat.ShortDatePattern;
            var timeFormatPattern = CultureInfo.GetCultureInfo(Convert.ToInt32(LocaleId)).DateTimeFormat.LongTimePattern;
            var date = DateTime.Now.AddDays(-25);
            var time = new DateTime(date.TimeOfDay.Ticks).ToString(timeFormatPattern);
            var dateToString = date.ToString(dateFormatPattern);
            SetupShims();

            // Act
            var result = ExtensionMethods.ToFriendlyDateAndTime(date, _web);

            // Assert
            result.ShouldBe($"{dateToString} at {time}");
        }

        [TestMethod]
        public void ToFriendlyDateAndTimeSPWeb_WhenBeforeThisWeek_ConfirmResult()
        {
            // Arrange
            var timeFormatPattern = CultureInfo.GetCultureInfo(Convert.ToInt32(LocaleId)).DateTimeFormat.LongTimePattern;
            var date = new DateTime(2018, 9, 13, 10, 10, 10);
            var time = new DateTime(date.TimeOfDay.Ticks).ToString(timeFormatPattern);
            var dayOfWeek = date.DayOfWeek;
            SetupShims();

            ShimDateTime.TodayGet = () => new DateTime(2018, 9, 20);

            // Act
            var result = ExtensionMethods.ToFriendlyDateAndTime(date, _web);

            // Assert
            result.ShouldBe($"Last {dayOfWeek} at {time}");
        }

        [TestMethod]
        public void ToFriendlyDateAndTimeSPWeb_WhenInThisWeek_ConfirmResult()
        {
            // Arrange
            var timeFormatPattern = CultureInfo.GetCultureInfo(Convert.ToInt32(LocaleId)).DateTimeFormat.LongTimePattern;
            var date = new DateTime(2018, 9, 17, 10, 10, 10);
            var time = new DateTime(date.TimeOfDay.Ticks).ToString(timeFormatPattern);
            var dayOfWeek = date.DayOfWeek;
            SetupShims();

            ShimDateTime.TodayGet = () => new DateTime(2018, 9, 20);

            // Act
            var result = ExtensionMethods.ToFriendlyDateAndTime(date, _web);

            // Assert
            result.ShouldBe($"{dayOfWeek} at {time}");
        }

        [TestMethod]
        public void ToFriendlyDateAndTimeSPWeb_WhenAfterTomorrow_ConfirmResult()
        {
            // Arrange
            var timeFormatPattern = CultureInfo.GetCultureInfo(Convert.ToInt32(LocaleId)).DateTimeFormat.LongTimePattern;
            var date = new DateTime(2018, 9, 22, 10, 10, 10);
            var time = new DateTime(date.TimeOfDay.Ticks).ToString(timeFormatPattern);
            var dayOfWeek = date.DayOfWeek;
            SetupShims();

            ShimDateTime.TodayGet = () => new DateTime(2018, 9, 20);

            // Act
            var result = ExtensionMethods.ToFriendlyDateAndTime(date, _web);

            // Assert
            result.ShouldBe($"This {dayOfWeek} at {time}");
        }

        [TestMethod]
        public void ToFriendlyDateAndTimeSPWeb_WhenInNextWeek_ConfirmResult()
        {
            // Arrange
            var timeFormatPattern = CultureInfo.GetCultureInfo(Convert.ToInt32(LocaleId)).DateTimeFormat.LongTimePattern;
            var date = new DateTime(2018, 9, 28, 10, 10, 10);
            var time = new DateTime(date.TimeOfDay.Ticks).ToString(timeFormatPattern);
            var dayOfWeek = date.DayOfWeek;
            SetupShims();

            ShimDateTime.TodayGet = () => new DateTime(2018, 9, 20);

            // Act
            var result = ExtensionMethods.ToFriendlyDateAndTime(date, _web);

            // Assert
            result.ShouldBe($"Next {dayOfWeek} at {time}");
        }

        [TestMethod]
        public void ToFriendlyDateAndTimeSPWeb_WhenAfterNextWeek_ConfirmResult()
        {
            // Arrange
            var dateFormatPattern = CultureInfo.GetCultureInfo(Convert.ToInt32(LocaleId)).DateTimeFormat.ShortDatePattern;
            var timeFormatPattern = CultureInfo.GetCultureInfo(Convert.ToInt32(LocaleId)).DateTimeFormat.LongTimePattern;
            var date = new DateTime(2018, 10, 2, 10, 10, 10);
            var time = new DateTime(date.TimeOfDay.Ticks).ToString(timeFormatPattern);
            var dateToString = date.ToString(dateFormatPattern);
            SetupShims();

            ShimDateTime.TodayGet = () => new DateTime(2018, 9, 20);

            // Act
            var result = ExtensionMethods.ToFriendlyDateAndTime(date, _web);

            // Assert
            result.ShouldBe($"{dateToString} at {time}");
        }

        [TestMethod]
        public void ToRegionalDateTime_OnValidCall_ConfirmResult()
        {
            // Arrange
            var timeToTest = new DateTime(2018, 9, 20, 10, 0, 0);
            SetupShims();

            // Act
            var result = ExtensionMethods.ToRegionalDateTime(timeToTest, _web);

            // Assert
            result.ShouldBe("9/20/2018 10:00:00 AM");
        }

        [TestMethod]
        public void ToDateTime_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.ToDateTime(DummyUnixTime);

            // Assert
            result.ShouldBe(new DateTime(2018, 1, 1, 0, 0, 0));
        }

        [TestMethod]
        public void ToUnixTime_OnValidCall_ConfirmResult()
        {
            // Arrange
            var date = new DateTime(2018, 1, 1, 0, 0, 0);

            // Act
            var result = ExtensionMethods.ToUnixTime(date);

            // Assert
            result.ShouldBe(DummyUnixTime);
        }

        [TestMethod]
        public void Seconds_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.Seconds(DummyInt);

            // Assert
            result.ShouldBe(new TimeSpan(0, 0, 0, DummyInt));
        }

        [TestMethod]
        public void Minutes_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.Minutes(DummyInt);

            // Assert
            result.ShouldBe(new TimeSpan(0, 0, DummyInt, 0));
        }

        [TestMethod]
        public void Hours_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.Hours(DummyInt);

            // Assert
            result.ShouldBe(new TimeSpan(0, DummyInt, 0, 0));
        }

        [TestMethod]
        public void Days_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.Days(DummyInt);

            // Assert
            result.ShouldBe(new TimeSpan(DummyInt, 0, 0, 0));
        }

        [TestMethod]
        public void SpDecompress_OnValidCall_ConfirmResult()
        {
            // Arrange
            var bytes = Encoding.UTF8.GetBytes(CompressedDummyString);
            var count = 0;

            ShimDeflateStream.ConstructorStreamCompressionMode = (_, __, ___) => { };
            ShimDeflateStream.AllInstances.DisposeBoolean = (_, __) => { };
            ShimDeflateStream.AllInstances.ReadByteArrayInt32Int32 = (_, _1, _2, _3) =>
            {
                count++;

                return count == 1 ? DummyInt : 0;
            };

            // Act
            var result = ExtensionMethods.SpDecompress(bytes);

            // Assert
            result.ShouldBe("\0");
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

        [TestMethod]
        public void GetResourcePoolId_WhenListItemCountIsZero_ConfirmResult()
        {
            // Arrange
            var web = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection()
            };

            // Act
            var result = ExtensionMethods.GetResourcePoolId(new ShimSPUser().Instance, web);

            // Assert
            result.ShouldBe(-1);
        }

        [TestMethod]
        public void GetResourcePoolId_WhenListIsNull_ConfirmResult()
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
            var result = ExtensionMethods.GetResourcePoolId(new ShimSPUser().Instance, web);

            // Assert
            result.ShouldBe(-2);
        }

        [TestMethod]
        public void GetResourcePoolId_OnValidCall_ConfirmResult()
        {
            // Arrange
            SetupShims();

            // Act
            var result = ExtensionMethods.GetResourcePoolId(new ShimSPUser().Instance, _web);

            // Assert
            result.ShouldBe(DummyInt);
        }

        [TestMethod]
        public void GetWebPartByTypeName_OnValidCall_ConfirmResult()
        {
            // Arrange
            const string WebPartType = "XsltListViewWebPart";
            var webPartManager = new ShimSPLimitedWebPartManager
            {
                WebPartsGet = () => new ShimSPLimitedWebPartCollection().Bind(new XsltListViewWebPart[] 
                {
                    new ShimXsltListViewWebPart().Instance
                })
            }.Instance;

            // Act
            var result = ExtensionMethods.GetWebPartByTypeName(webPartManager, WebPartType);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeOfType(typeof(XsltListViewWebPart)));
        }

        [TestMethod]
        public void GetWebPartByTypeName_WhenDifferentType_ReturnNull()
        {
            // Arrange
            var webPartManager = new ShimSPLimitedWebPartManager
            {
                WebPartsGet = () => new ShimSPLimitedWebPartCollection().Bind(new XsltListViewWebPart[]
                {
                    new ShimXsltListViewWebPart().Instance
                })
            }.Instance;

            // Act
            var result = ExtensionMethods.GetWebPartByTypeName(webPartManager, DummyString);

            // Assert
            result.ShouldBeNull();
        }

        [TestMethod]
        public void Sort_WithTreeView_ConfirmResult()
        {
            // Arrange
            var treeView = new TreeView();
            treeView.Nodes.Add(new TreeNode(BString));
            treeView.Nodes.Add(new TreeNode(AString));

            // Act
            ExtensionMethods.Sort(treeView);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => treeView.Nodes[0].Text.ShouldBe(AString),
                () => treeView.Nodes[1].Text.ShouldBe(BString));
        }

        [TestMethod]
        public void OlsonName_OnValidCall_ConfirmResult()
        {
            // Arrange
            var timeZone = TimeZoneInfo.Utc;

            // Act
            var result = ExtensionMethods.OlsonName(timeZone);

            // Assert
            result.ShouldBe("Etc/GMT");
        }

        [TestMethod]
        public void GetSize_WhenDoubleType_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.GetSize(DummyDouble);

            // Assert
            result.ShouldBe(sizeof(Double));
        }

        [TestMethod]
        public void GetSize_WhenSingleType_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.GetSize(DummyFloat);

            // Assert
            result.ShouldBe(sizeof(Single));
        }

        [TestMethod]
        public void GetSize_WhenCharType_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.GetSize(DummyChar);

            // Assert
            result.ShouldBe(sizeof(Char));
        }

        [TestMethod]
        public void GetSize_WhenInt16Type_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.GetSize(DummyShort);

            // Assert
            result.ShouldBe(sizeof(Int16));
        }

        [TestMethod]
        public void GetSize_WhenInt32Type_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.GetSize(DummyInt);

            // Assert
            result.ShouldBe(sizeof(Int32));
        }

        [TestMethod]
        public void GetSize_WhenInt64Type_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.GetSize(DummyLong);

            // Assert
            result.ShouldBe(sizeof(Int64));
        }

        [TestMethod]
        public void GetSize_WhenUInt16Type_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.GetSize(DummyUShort);

            // Assert
            result.ShouldBe(sizeof(UInt16));
        }

        [TestMethod]
        public void GetSize_WhenUInt32Type_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.GetSize(DummyUInt);

            // Assert
            result.ShouldBe(sizeof(UInt32));
        }

        [TestMethod]
        public void GetSize_WhenUInt64Type_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.GetSize(DummyULong);

            // Assert
            result.ShouldBe(sizeof(UInt64));
        }

        [TestMethod]
        public void GetSize_WhenDecimalType_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.GetSize(DummyDecimal);

            // Assert
            result.ShouldBe(sizeof(Decimal));
        }

        [TestMethod]
        public void GetSize_WhenByteType_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.GetSize(DummyByte);

            // Assert
            result.ShouldBe(sizeof(Byte));
        }

        [TestMethod]
        public void GetSize_WhenSByteType_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.GetSize(DummySByte);

            // Assert
            result.ShouldBe(sizeof(SByte));
        }

        [TestMethod]
        public void GetSize_WhenBooleanType_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.GetSize(DummyBool);

            // Assert
            result.ShouldBe(sizeof(Boolean));
        }

        [TestMethod]
        public void GetSize_WhenDoubleArrayType_ConfirmResult()
        {
            // Arrange
            var testValue = new double[] { DummyDouble };

            // Act
            var result = ExtensionMethods.GetSize(testValue);

            // Assert
            result.ShouldBe(sizeof(Double) * testValue.Length);
        }

        [TestMethod]
        public void GetSize_WhenSingleArrayType_ConfirmResult()
        {
            // Arrange
            var testValue = new float[] { DummyFloat };

            // Act
            var result = ExtensionMethods.GetSize(testValue);

            // Assert
            result.ShouldBe(sizeof(Single) * testValue.Length);
        }

        [TestMethod]
        public void GetSize_WhenCharArrayType_ConfirmResult()
        {
            // Arrange
            var testValue = new char[] { DummyChar };

            // Act
            var result = ExtensionMethods.GetSize(testValue);

            // Assert
            result.ShouldBe(sizeof(Char) * testValue.Length);
        }

        [TestMethod]
        public void GetSize_WhenInt16ArrayType_ConfirmResult()
        {
            // Arrange
            var testValue = new short[] { DummyShort };

            // Act
            var result = ExtensionMethods.GetSize(testValue);

            // Assert
            result.ShouldBe(sizeof(Int16) * testValue.Length);
        }

        [TestMethod]
        public void GetSize_WhenInt32ArrayType_ConfirmResult()
        {
            // Arrange
            var testValue = new int[] { DummyInt };

            // Act
            var result = ExtensionMethods.GetSize(testValue);

            // Assert
            result.ShouldBe(sizeof(Int32) * testValue.Length);
        }

        [TestMethod]
        public void GetSize_WhenInt64ArrayType_ConfirmResult()
        {
            // Arrange
            var testValue = new long[] { DummyLong };

            // Act
            var result = ExtensionMethods.GetSize(testValue);

            // Assert
            result.ShouldBe(sizeof(Int64) * testValue.Length);
        }

        [TestMethod]
        public void GetSize_WhenUInt16ArrayType_ConfirmResult()
        {
            // Arrange
            var testValue = new ushort[] { DummyUShort };

            // Act
            var result = ExtensionMethods.GetSize(testValue);

            // Assert
            result.ShouldBe(sizeof(UInt16) * testValue.Length);
        }

        [TestMethod]
        public void GetSize_WhenUInt32ArrayType_ConfirmResult()
        {
            // Arrange
            var testValue = new uint[] { DummyUInt };

            // Act
            var result = ExtensionMethods.GetSize(testValue);

            // Assert
            result.ShouldBe(sizeof(UInt32) * testValue.Length);
        }

        [TestMethod]
        public void GetSize_WhenUInt64ArrayType_ConfirmResult()
        {
            // Arrange
            var testValue = new ulong[] { DummyULong };

            // Act
            var result = ExtensionMethods.GetSize(testValue);

            // Assert
            result.ShouldBe(sizeof(UInt64) * testValue.Length);
        }

        [TestMethod]
        public void GetSize_WhenDecimalArrayType_ConfirmResult()
        {
            // Arrange
            var testValue = new decimal[] { DummyDecimal };

            // Act
            var result = ExtensionMethods.GetSize(testValue);

            // Assert
            result.ShouldBe(sizeof(Decimal) * testValue.Length);
        }

        [TestMethod]
        public void GetSize_WhenByteArrayType_ConfirmResult()
        {
            // Arrange
            var testValue = new byte[] { DummyByte };

            // Act
            var result = ExtensionMethods.GetSize(testValue);

            // Assert
            result.ShouldBe(sizeof(Byte) * testValue.Length);
        }

        [TestMethod]
        public void GetSize_WhenSByteArrayType_ConfirmResult()
        {
            // Arrange
            var testValue = new sbyte[] { DummySByte };

            // Act
            var result = ExtensionMethods.GetSize(testValue);

            // Assert
            result.ShouldBe(sizeof(SByte) * testValue.Length);
        }

        [TestMethod]
        public void GetSize_WhenBooleanArrayType_ConfirmResult()
        {
            // Arrange
            var testValue = new bool[] { DummyBool };

            // Act
            var result = ExtensionMethods.GetSize(testValue);

            // Assert
            result.ShouldBe(sizeof(Boolean) * testValue.Length);
        }

        [TestMethod]
        public void GetSize_WhenEnumType_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.GetSize(DayOfWeek.Friday);

            // Assert
            result.ShouldBe(4L);
        }

        [TestMethod]
        public void GetSize_WhenStringType_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.GetSize(DummyString);

            // Assert
            result.ShouldBe(22L);
        }

        [TestMethod]
        public void GetSize_WhenDateTimeValueType_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.GetSize(DateTime.Today);

            // Assert
            result.ShouldBe(0L);
        }

        [TestMethod]
        public void GetSize_WhenEPMLiveQuickLaunchProviderType_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.GetSize(new ShimEPMLiveQuickLaunchProvider().Instance);

            // Assert
            result.ShouldBe(0L);
        }

        [TestMethod]
        public void GetSize_WhenDictionaryType_ConfirmResult()
        {
            // Arrange
            var testValue = new Dictionary<string, string>()
            {
                [DummyString] = DummyString
            };

            // Act
            var result = ExtensionMethods.GetSize(testValue);

            // Assert
            result.ShouldBe(44L);
        }

        [TestMethod]
        public void GetSize_WhenListType_ConfirmResult()
        {
            // Arrange
            var testValue = new List<string>
            {
                DummyString
            };

            // Act
            var result = ExtensionMethods.GetSize(testValue);

            // Assert
            result.ShouldBe(22L);
        }

        [TestMethod]
        public void GetSize_WhenAnotherType_ConfirmResult()
        {
            // Arrange, Act
            var result = ExtensionMethods.GetSize(new DummyClass());

            // Assert
            result.ShouldBe(4L);
        }

        [TestMethod]
        public void AddEnum_OnValidCall_ConfirmResult()
        {
            // Arrange
            var dayOfWeek = DayOfWeek.Monday;

            // Act
            var result = dayOfWeek.Add(DayOfWeek.Tuesday);

            // Assert
            result.ShouldBe(DayOfWeek.Wednesday);
        }
        
        private class DummyClass
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }
}
