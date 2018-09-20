using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveWebParts.API.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.API
{
    [TestClass, ExcludeFromCodeCoverage]
    public class WPAPITest
    {
        private IDisposable _shimObject;
        private ShimSPWeb _web;
        private ShimSPSite _site;
        private ShimSPList _list;
        private string _webId;
        private string _siteId;
        private bool _siteCreated;
        private bool _webOpened;
        private bool _gridAPICreated;
        private bool _listItemUpdated;

        private const int DummyInt = 1;
        private const int DummyIntTwo = 2;
        private const double DummyDouble = 1D;
        private const string DummyString = "DummyString";
        private const string WebId = "4a37915c-8b5a-4d43-8167-b21e08b70461";
        private const string SiteId = "f7a29869-98c9-488b-8365-a4d685639dd0";
        private const string ListId = "3afc34c2-26d2-450d-a956-a7f94b92f1d4";
        private const string DateSeparator = "/";
        private const string ResultCDATATag = "<Result Status=\"0\"><![CDATA[<Grid><Changes>";
        private const string FStateField = "FState";
        private const string StateField = "State";
        private const string DateField = "DateField";
        private const string UserField = "UserField";
        private const string LookupField = "LookupField";
        private const string MultiChoiceField = "MultiChoiceField";
        private const string CurrencyField = "CurrencyField";
        private const string NumberField = "NumberField";
        private const string FloatFormat = "$,0.00";
        private const string NumberFormat = ",#0";
        private const string TextValue = "Text";
        private const string DateValue = "Date";
        private const string EnumValue = "Enum";
        private const string FloatValue = "Float";
        private const string DateOnly = "DateOnly";
        private const string ProjectCenter = "Project Center";
        private const string CommentCountValue = "CommentCount";
        private const string CompleteValue = "Complete";

        [TestInitialize]
        public void TestInitialize()
        {
            _siteCreated = false;
            _webOpened = false;
            _gridAPICreated = false;
            _listItemUpdated = false;
            _shimObject = ShimsContext.Create();

            SetupShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        private void SetupShims()
        {
            _list = new ShimSPList
            {
                TitleGet = () => ProjectCenter,
                ParentWebGet = () => _web,
                GetItemByIdInt32 = _ => new ShimSPListItem
                {
                    ItemGetGuid = __ => DummyDouble,
                    ItemGetString = item =>
                    {
                        switch (item)
                        {
                            case CommentCountValue:
                                return DummyDouble;
                            case CompleteValue:
                                return true;
                            default:
                                return DummyString;
                        }
                    },
                    ParentListGet = () => _list,
                    FieldsGet = () => new ShimSPFieldCollection
                    {
                        ContainsFieldString = __ => true
                    },
                    Update = () => _listItemUpdated = true
                },
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name =>
                    {
                        if (name == StateField)
                        {
                            return new ShimSPField
                            {
                                TypeGet = () => SPFieldType.Text
                            };
                        }
                        if (name == DateField)
                        {
                            return new ShimSPFieldDateTime().Instance;
                        }
                        if (name == UserField)
                        {
                            return new ShimSPFieldUser().Instance;
                        }
                        if (name == LookupField)
                        {
                            return new ShimSPFieldLookup
                            {
                                LookupListGet = () => ListId
                            };
                        }
                        if (name == MultiChoiceField)
                        {
                            return new ShimSPFieldMultiChoice
                            {
                                ChoicesGet = () => new StringCollection { DummyString },
                                GetFieldValueString = _ => new ShimSPFieldMultiChoiceValue
                                {
                                    CountGet = () => DummyInt,
                                    ItemGetInt32 = x => DummyString
                                }.Instance
                            }.Instance;
                        }
                        if (name == CurrencyField)
                        {
                            return new ShimSPFieldCurrency
                            {
                                CurrencyLocaleIdGet = () => 1033
                            }.Instance;
                        }

                        return new ShimSPFieldNumber().Instance;
                    },
                    ContainsFieldWithStaticNameString = _ => true
                },
                ItemsGet = () => new ShimSPListItemCollection().Bind(new SPListItem[]
                {
                    new ShimSPListItem
                    {
                        TitleGet = () => DummyString,
                        IDGet = () => DummyInt
                    }
                })
            };

            _site = new ShimSPSite
            {
                IDGet = () => string.IsNullOrWhiteSpace(_siteId) ? Guid.NewGuid() : new Guid(_siteId)
            };

            _web = new ShimSPWeb
            {
                IDGet = () => string.IsNullOrWhiteSpace(_webId) ? Guid.NewGuid() : new Guid(_webId),
                SiteGet = () => _site.Instance,
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetGuid = _ => _list
                },
                CurrentUserGet = () => new ShimSPUser
                {
                    IDGet = () => DummyInt,
                    RegionalSettingsGet = () => new ShimSPRegionalSettings
                    {
                        DateSeparatorGet = () => DateSeparator,
                        DateFormatGet = () => (uint)SPCalendarOrderType.YMD
                    }
                }
            };

            ShimSPSite.ConstructorGuid = (_, __) => _siteCreated = true;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) =>
            {
                _webOpened = true;
                return _web;
            };
            ShimSPSite.AllInstances.Dispose = _ => { };

            ShimSPWeb.AllInstances.Dispose = _ => { };

            ShimSPContext.GetContextSPWeb = _ => new ShimSPContext
            {
                WebGet = () => _web
            };

            ShimSPField.AllInstances.TypeGet = instance =>
            {
                if (instance is SPFieldUser)
                {
                    return SPFieldType.User;
                }
                if (instance is SPFieldLookup)
                {
                    return SPFieldType.Lookup;
                }
                if (instance is SPFieldMultiChoice)
                {
                    return SPFieldType.MultiChoice;
                }
                if (instance is SPFieldCurrency)
                {
                    return SPFieldType.Currency;
                }
                if (instance is SPFieldNumber)
                {
                    return SPFieldType.Number;
                }
                if (instance is SPFieldDateTime)
                {
                    return SPFieldType.DateTime;
                }

                return SPFieldType.Text;
            };
            ShimSPField.AllInstances.GetPropertyString = (_, __) => DateOnly;
            ShimSPField.AllInstances.GetFieldValueAsTextObject = (_, __) => DummyString;
            ShimSPField.AllInstances.GetFieldValueForEditObject = (_, __) => DummyString;

            ShimSPFieldUserValue.ConstructorSPWebString = (_, __, ___) => { };

            ShimSPFieldLookupValue.ConstructorString = (_, __) => { };
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyInt;

            ShimSPFieldLookup.AllInstances.AllowMultipleValuesGet = _ => true;

            ShimGridAPI.ConstructorStringSPWeb = (_, __, ___) => _gridAPICreated = true;
            ShimGridAPI.AllInstances.ToString01 = _ => DummyString;

            ShimCoreFunctions.getListSettingStringSPList = (_, __) =>
                $"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n{true}";

            ShimListDisplayUtils.ConvertFromStringString = _ => new Dictionary<string, Dictionary<string, string>>();

            ShimEditableFieldDisplay.isEditableSPListItemSPFieldDictionaryOfStringDictionaryOfStringString = (_, __, ___) => true;

            ShimAPITeam.GetResourcePoolStringSPWeb = (_, __) => CreateDataTable();
        }

        private DataTable CreateDataTable()
        {
            const string TitleColumn = "Title";
            const string SPIDColumn = "SPID";

            var dataTable = new DataTable();
            dataTable.Columns.Add(TitleColumn);
            dataTable.Columns.Add(SPIDColumn);

            var dataRow = dataTable.NewRow();
            dataRow[TitleColumn] = DummyString;
            dataRow[SPIDColumn] = DummyString;

            dataTable.Rows.Add(dataRow);

            return dataTable;
        }

        [TestMethod]
        public void GetGrid_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = WPAPI.GetGrid(DummyString, _web.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _gridAPICreated.ShouldBeTrue(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetGridRow_WhenDifferentSiteId_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXml();

            // Act
            var result = WPAPI.GetGridRow(xmlString, _web.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _siteCreated.ShouldBeTrue(),
                () => _webOpened.ShouldBeTrue(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ResultCDATATag),
                () => result.ShouldContain($"<I id=\"{DummyInt}\""),
                () => result.ShouldContain($"FState=\"{DummyString}\""),
                () => result.ShouldContain($"DateField=\"{DummyInt}\""),
                () => result.ShouldContain($"UserField=\"{DummyString}\""),
                () => result.ShouldContain($"LookupField=\"{DummyString}\""),
                () => result.ShouldContain($"MultiChoiceField=\"{DummyInt}\""),
                () => result.ShouldContain($"CurrencyField=\"{DummyInt}\""),
                () => result.ShouldContain($"NumberField=\"{DummyInt}\""),
                () => result.ShouldContain($"HasComments=\"{DummyIntTwo}\""));
        }

        [TestMethod]
        public void GetGridRow_WhenDifferentWebId_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXml();
            _siteId = SiteId;

            // Act
            var result = WPAPI.GetGridRow(xmlString, _web.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _siteCreated.ShouldBeFalse(),
                () => _webOpened.ShouldBeTrue(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ResultCDATATag),
                () => result.ShouldContain($"<I id=\"{DummyInt}\""),
                () => result.ShouldContain($"FState=\"{DummyString}\""),
                () => result.ShouldContain($"DateField=\"{DummyInt}\""),
                () => result.ShouldContain($"UserField=\"{DummyString}\""),
                () => result.ShouldContain($"LookupField=\"{DummyString}\""),
                () => result.ShouldContain($"MultiChoiceField=\"{DummyInt}\""),
                () => result.ShouldContain($"CurrencyField=\"{DummyInt}\""),
                () => result.ShouldContain($"NumberField=\"{DummyInt}\""),
                () => result.ShouldContain($"HasComments=\"{DummyIntTwo}\""));
        }

        [TestMethod]
        public void GetGridRow_WhenSiteIdAndWebIdAreEqual_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXml();
            _siteId = SiteId;
            _webId = WebId;

            // Act
            var result = WPAPI.GetGridRow(xmlString, _web.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _siteCreated.ShouldBeFalse(),
                () => _webOpened.ShouldBeFalse(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ResultCDATATag),
                () => result.ShouldContain($"<I id=\"{DummyInt}\""),
                () => result.ShouldContain($"FState=\"{DummyString}\""),
                () => result.ShouldContain($"DateField=\"{DummyInt}\""),
                () => result.ShouldContain($"UserField=\"{DummyString}\""),
                () => result.ShouldContain($"LookupField=\"{DummyString}\""),
                () => result.ShouldContain($"MultiChoiceField=\"{DummyInt}\""),
                () => result.ShouldContain($"CurrencyField=\"{DummyInt}\""),
                () => result.ShouldContain($"NumberField=\"{DummyInt}\""),
                () => result.ShouldContain($"HasComments=\"{DummyIntTwo}\""));
        }

        private string CreateXml()
        {
            var cols = $"{FStateField},{DateField},{UserField},{LookupField},{MultiChoiceField},{CurrencyField},{NumberField}";

            return $@"
                <Root id='{DummyInt}' webid='{WebId}' siteid='{SiteId}' listid='{ListId}' itemid='{DummyInt}' Cols='{cols}'>
                    <Field Name='{FStateField}'>{DummyString}</Field>
                    <Field Name='{DateField}'>{DummyInt}</Field>
                    <Field Name='{UserField}'>{DummyString}</Field>
                    <Field Name='{LookupField}'>{DummyString}</Field>
                    <Field Name='{MultiChoiceField}'>{DummyString}</Field>
                    <Field Name='{CurrencyField}'>{DummyInt}</Field>
                    <Field Name='{NumberField}'>{DummyInt}</Field>
                </Root>";
        }

        [TestMethod]
        public void SetGridRowEdit_WhenDifferentSiteId_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXml();

            // Act
            var result = WPAPI.SetGridRowEdit(xmlString, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _siteCreated.ShouldBeTrue(),
                () => _webOpened.ShouldBeTrue(),
                () => _listItemUpdated.ShouldBeTrue(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ResultCDATATag),
                () => result.ShouldContain($"<I id=\"{DummyInt}\""),
                () => result.ShouldContain($"NumberField=\"{DummyInt}\""),
                () => result.ShouldContain($"FState=\"{DummyInt}\""),
                () => result.ShouldContain($"DateField=\"{DummyInt}\""),
                () => result.ShouldContain($"UserField=\"\""),
                () => result.ShouldContain($"LookupField=\"{DummyInt}\""),
                () => result.ShouldContain($"MultiChoiceField=\"{DummyString}\""),
                () => result.ShouldContain($"CurrencyField=\"{DummyInt}\""),
                () => result.ShouldContain($"HasComments=\"{DummyIntTwo}\""));
        }

        [TestMethod]
        public void SetGridRowEdit_WhenDifferentWebId_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXml();
            _siteId = SiteId;

            // Act
            var result = WPAPI.SetGridRowEdit(xmlString, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _siteCreated.ShouldBeFalse(),
                () => _webOpened.ShouldBeTrue(),
                () => _listItemUpdated.ShouldBeTrue(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ResultCDATATag),
                () => result.ShouldContain($"<I id=\"{DummyInt}\""),
                () => result.ShouldContain($"NumberField=\"{DummyInt}\""),
                () => result.ShouldContain($"FState=\"{DummyInt}\""),
                () => result.ShouldContain($"DateField=\"{DummyInt}\""),
                () => result.ShouldContain($"UserField=\"\""),
                () => result.ShouldContain($"LookupField=\"{DummyInt}\""),
                () => result.ShouldContain($"MultiChoiceField=\"{DummyString}\""),
                () => result.ShouldContain($"CurrencyField=\"{DummyInt}\""),
                () => result.ShouldContain($"HasComments=\"{DummyIntTwo}\""));
        }

        [TestMethod]
        public void SetGridRowEdit_WhenSiteIdAndWebIdAreEqual_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXml();
            _siteId = SiteId;
            _webId = WebId;

            // Act
            var result = WPAPI.SetGridRowEdit(xmlString, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _siteCreated.ShouldBeFalse(),
                () => _webOpened.ShouldBeFalse(),
                () => _listItemUpdated.ShouldBeTrue(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ResultCDATATag),
                () => result.ShouldContain($"<I id=\"{DummyInt}\""),
                () => result.ShouldContain($"NumberField=\"{DummyInt}\""),
                () => result.ShouldContain($"FState=\"{DummyInt}\""),
                () => result.ShouldContain($"DateField=\"{DummyInt}\""),
                () => result.ShouldContain($"UserField=\"\""),
                () => result.ShouldContain($"LookupField=\"{DummyInt}\""),
                () => result.ShouldContain($"MultiChoiceField=\"{DummyString}\""),
                () => result.ShouldContain($"CurrencyField=\"{DummyInt}\""),
                () => result.ShouldContain($"HasComments=\"{DummyIntTwo}\""));
        }

        [TestMethod]
        public void GetGridRowEdit_WhenDifferentSiteId_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXml();

            // Act
            var result = WPAPI.GetGridRowEdit(xmlString, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _siteCreated.ShouldBeTrue(),
                () => _webOpened.ShouldBeTrue(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ResultCDATATag),
                () => result.ShouldContain($"<I id=\"{DummyInt}\""),
                () => result.ShouldContain($"FStateCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"FStateType=\"{TextValue}\""),
                () => result.ShouldContain($"FState=\"{DummyInt}\""),
                () => result.ShouldContain($"DateFieldCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"DateFieldType=\"{DateValue}\""),
                () => result.ShouldContain($"DateFieldFormat=\"yyyy/M/d\""),
                () => result.ShouldContain($"DateField=\"{DummyInt}\""),
                () => result.ShouldContain($"UserFieldCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"UserFieldType=\"{EnumValue}\""),
                () => result.ShouldContain($"UserFieldEnum=\";{DummyString}\""),
                () => result.ShouldContain($"UserFieldEnumKeys=\";{DummyString}\""),
                () => result.ShouldContain($"UserFieldRange=\"{DummyInt}\""),
                () => result.ShouldContain($"UserField=\"\""),
                () => result.ShouldContain($"LookupFieldCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"LookupFieldType=\"{EnumValue}\""),
                () => result.ShouldContain($"LookupFieldEnum=\";{DummyString}\""),
                () => result.ShouldContain($"LookupFieldEnumKeys=\";{DummyInt}\""),
                () => result.ShouldContain($"LookupFieldRange=\"{DummyInt}\""),
                () => result.ShouldContain($"LookupField=\"{DummyInt}\""),
                () => result.ShouldContain($"MultiChoiceFieldCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"MultiChoiceFieldType=\"{EnumValue}\""),
                () => result.ShouldContain($"MultiChoiceFieldEnum=\";{DummyString}\""),
                () => result.ShouldContain($"MultiChoiceFieldRange=\"{DummyInt}\""),
                () => result.ShouldContain($"MultiChoiceField=\"{DummyString}\""),
                () => result.ShouldContain($"CurrencyFieldCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"CurrencyFieldType=\"{FloatValue}\""),
                () => result.ShouldContain($"CurrencyFieldFormat=\"{FloatFormat}\""),
                () => result.ShouldContain($"CurrencyField=\"{DummyInt}\""),
                () => result.ShouldContain($"NumberFieldCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"NumberFieldType=\"{FloatValue}\""),
                () => result.ShouldContain($"NumberFieldFormat=\"{NumberFormat}\""),
                () => result.ShouldContain($"NumberField=\"{DummyInt}\""));
        }

        [TestMethod]
        public void GetGridRowEdit_WhenDifferentWebId_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXml();
            _siteId = SiteId;

            // Act
            var result = WPAPI.GetGridRowEdit(xmlString, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _siteCreated.ShouldBeFalse(),
                () => _webOpened.ShouldBeTrue(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ResultCDATATag),
                () => result.ShouldContain($"<I id=\"{DummyInt}\""),
                () => result.ShouldContain($"FStateCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"FStateType=\"{TextValue}\""),
                () => result.ShouldContain($"FState=\"{DummyInt}\""),
                () => result.ShouldContain($"DateFieldCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"DateFieldType=\"{DateValue}\""),
                () => result.ShouldContain($"DateFieldFormat=\"yyyy/M/d\""),
                () => result.ShouldContain($"DateField=\"{DummyInt}\""),
                () => result.ShouldContain($"UserFieldCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"UserFieldType=\"{EnumValue}\""),
                () => result.ShouldContain($"UserFieldEnum=\";{DummyString}\""),
                () => result.ShouldContain($"UserFieldEnumKeys=\";{DummyString}\""),
                () => result.ShouldContain($"UserFieldRange=\"{DummyInt}\""),
                () => result.ShouldContain($"UserField=\"\""),
                () => result.ShouldContain($"LookupFieldCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"LookupFieldType=\"{EnumValue}\""),
                () => result.ShouldContain($"LookupFieldEnum=\";{DummyString}\""),
                () => result.ShouldContain($"LookupFieldEnumKeys=\";{DummyInt}\""),
                () => result.ShouldContain($"LookupFieldRange=\"{DummyInt}\""),
                () => result.ShouldContain($"LookupField=\"{DummyInt}\""),
                () => result.ShouldContain($"MultiChoiceFieldCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"MultiChoiceFieldType=\"{EnumValue}\""),
                () => result.ShouldContain($"MultiChoiceFieldEnum=\";{DummyString}\""),
                () => result.ShouldContain($"MultiChoiceFieldRange=\"{DummyInt}\""),
                () => result.ShouldContain($"MultiChoiceField=\"{DummyString}\""),
                () => result.ShouldContain($"CurrencyFieldCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"CurrencyFieldType=\"{FloatValue}\""),
                () => result.ShouldContain($"CurrencyFieldFormat=\"{FloatFormat}\""),
                () => result.ShouldContain($"CurrencyField=\"{DummyInt}\""),
                () => result.ShouldContain($"NumberFieldCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"NumberFieldType=\"{FloatValue}\""),
                () => result.ShouldContain($"NumberFieldFormat=\"{NumberFormat}\""),
                () => result.ShouldContain($"NumberField=\"{DummyInt}\""));
        }

        [TestMethod]
        public void GetGridRowEdit_WhenSiteIdAndWebIdAreEqual_ConfirmResult()
        {
            // Arrange
            var xmlString = CreateXml();
            _siteId = SiteId;
            _webId = WebId;

            // Act
            var result = WPAPI.GetGridRowEdit(xmlString, _web);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _siteCreated.ShouldBeFalse(),
                () => _webOpened.ShouldBeFalse(),
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ResultCDATATag),
                () => result.ShouldContain($"<I id=\"{DummyInt}\""),
                () => result.ShouldContain($"FStateCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"FStateType=\"{TextValue}\""),
                () => result.ShouldContain($"FState=\"{DummyInt}\""),
                () => result.ShouldContain($"DateFieldCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"DateFieldType=\"{DateValue}\""),
                () => result.ShouldContain($"DateFieldFormat=\"yyyy/M/d\""),
                () => result.ShouldContain($"DateField=\"{DummyInt}\""),
                () => result.ShouldContain($"UserFieldCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"UserFieldType=\"{EnumValue}\""),
                () => result.ShouldContain($"UserFieldEnum=\";{DummyString}\""),
                () => result.ShouldContain($"UserFieldEnumKeys=\";{DummyString}\""),
                () => result.ShouldContain($"UserFieldRange=\"{DummyInt}\""),
                () => result.ShouldContain($"UserField=\"\""),
                () => result.ShouldContain($"LookupFieldCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"LookupFieldType=\"{EnumValue}\""),
                () => result.ShouldContain($"LookupFieldEnum=\";{DummyString}\""),
                () => result.ShouldContain($"LookupFieldEnumKeys=\";{DummyInt}\""),
                () => result.ShouldContain($"LookupFieldRange=\"{DummyInt}\""),
                () => result.ShouldContain($"LookupField=\"{DummyInt}\""),
                () => result.ShouldContain($"MultiChoiceFieldCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"MultiChoiceFieldType=\"{EnumValue}\""),
                () => result.ShouldContain($"MultiChoiceFieldEnum=\";{DummyString}\""),
                () => result.ShouldContain($"MultiChoiceFieldRange=\"{DummyInt}\""),
                () => result.ShouldContain($"MultiChoiceField=\"{DummyString}\""),
                () => result.ShouldContain($"CurrencyFieldCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"CurrencyFieldType=\"{FloatValue}\""),
                () => result.ShouldContain($"CurrencyFieldFormat=\"{FloatFormat}\""),
                () => result.ShouldContain($"CurrencyField=\"{DummyInt}\""),
                () => result.ShouldContain($"NumberFieldCanEdit=\"{DummyInt}\""),
                () => result.ShouldContain($"NumberFieldType=\"{FloatValue}\""),
                () => result.ShouldContain($"NumberFieldFormat=\"{NumberFormat}\""),
                () => result.ShouldContain($"NumberField=\"{DummyInt}\""));
        }
    }
}
