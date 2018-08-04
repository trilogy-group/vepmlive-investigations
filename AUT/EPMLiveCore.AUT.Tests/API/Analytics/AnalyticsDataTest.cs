using System;
using System.Diagnostics.CodeAnalysis;
using Shouldly;
using Should = Shouldly.Should;
using NUnit.Framework;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Extensions;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests for (<see cref="AnalyticsData" />) class
    ///     using generator's artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AnalyticsDataTest : AbstractGenericTest
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AnalyticsData) Initializer

        /// <summary>
        ///    Create parameter or simple data-type using AutoFixture or Activator.
        /// </summary>
        /// <typeparam name="T">Create Given type.</typeparam>
        /// <returns>Returns a type of T</returns>
        [ExcludeFromCodeCoverage]
        private T CreateType<T>()
        {
            Exception exception;
            return CreateType<T>(out exception);
        }

        /// <summary>
        ///    Create parameter or simple data-type using AutoFixture or Activator or Constructor.
        /// </summary>
        /// <typeparam name="T">Create Given type.</typeparam>
        /// <returns>Returns a type of T</returns>
        [ExcludeFromCodeCoverage]
        private T CreateType<T>(out Exception exception)
        {
            return CreateAnalyzer.CreateTypeUsingFixtureOrConstuctor<T>(fixture: Fixture, exception: out exception);
        }

        /// <summary>
        ///    Create <see cref="AnalyticsData" /> class.
        /// </summary>
        /// <returns>Returns a newly created <see cref="AnalyticsData" />.</returns>
        [ExcludeFromCodeCoverage]
        private AnalyticsData Create(bool useFixtureAtFirst = false)
        {
            Exception createException;
            var parameters = CreateOrGetPrameters();
            return Create(createException: out createException, useFixtureAtFirst: useFixtureAtFirst, parameters: parameters);
        }

        /// <summary>
        ///    Create <see cref="AnalyticsData" /> class.
        /// </summary>
        /// <returns>Returns a newly created <see cref="AnalyticsData" />.</returns>
        [ExcludeFromCodeCoverage]
        private AnalyticsData Create(out Exception createException, object[] parameters = null, bool useFixtureAtFirst = false)
        {
            return CreateAnalyzer.Create<AnalyticsData>(fixture: Fixture, exception: out createException, useFixtureAtFirst: useFixtureAtFirst, parameters: parameters);
        }

        /// <summary>
        ///    Create Multiple of <see cref="AnalyticsData" /> classes depending on the given number.
        /// </summary>
        /// <returns>Returns a newly created <see cref="AnalyticsData" />.</returns>
        private AnalyticsData[] CreateMany(out Exception[] createExceptions, out bool isResultsAreNull, int number = 6, object[] parameters = null)
        {
            return CreateAnalyzer.CreateMany<AnalyticsData>(number: number, fixture: Fixture, exceptions: out createExceptions, isResultsAreNull: out isResultsAreNull, parameters: parameters);
        }

        /// <summary>
        ///    Create dynamic parameters for <see cref="AnalyticsData" /> class using AutoFixture.
        ///    Returns null if no parameters present.
        /// </summary>
        /// <returns>Returns a object array if parameters present or else returns null.</returns>
        [ExcludeFromCodeCoverage]
        private object[] CreateOrGetPrameters()
        {
            var xml = CreateType<string>();
            var t = CreateType<AnalyticsType>();
            var a = CreateType<AnalyticsAction>();
            return new object[] {xml, t, a};
        }

        #endregion

        #region Explore Class for Coverage Gain : Class (AnalyticsData)

        /// <summary>
        ///     Regular class (<see cref="AnalyticsData" />) non-public fields explore and verify for coverage gain.
        /// </summary>
        [Test]
        [Category("AUT Initializer")]
        public void AUT_RegularClass_AnalyticsData_NonPublic_Fields_Explore_Verify()
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicFields<AnalyticsData>(Fixture);
        }

        /// <summary>
        ///     Regular class (<see cref="AnalyticsData" />) non-public properties explore and verify for coverage gain.
        /// </summary>
        [Test]
        [Category("AUT Initializer")]
        public void AUT_RegularClass_AnalyticsData_NonPublic_Properties_Explore_Verify()
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicProperties<AnalyticsData>(Fixture);
        }

        /// <summary>
        ///     Regular class (<see cref="AnalyticsData" />) non-public methods explore and verify for coverage gain.
        /// </summary>
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [Category("AUT Initializer")]
        public void AUT_RegularClass_AnalyticsData_NonPublic_Methods_Explore_Verify(int pageNumber = 1, int perPageMethodsToVerify = 3)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyNonPublicMethods<AnalyticsData>(Fixture, pageNumber, perPageMethodsToVerify);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (AnalyticsData) => All Properties and Fields Test

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Class_All_Properties_Getter_Settter_Test()
        {
            // Arrange
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);
            var type = CreateType<AnalyticsType>();
            var action = CreateType<AnalyticsAction>();

            if (analyticsDataInstance != null)
            {
                // Act
                analyticsDataInstance.Type = type;
                analyticsDataInstance.Action = action;

                // Assert
                analyticsDataInstance.Type.ShouldNotBeNull();
                analyticsDataInstance.Action.ShouldNotBeNull();
                analyticsDataInstance.SiteId.ShouldNotBeNull();
                analyticsDataInstance.WebId.ShouldNotBeNull();
                analyticsDataInstance.ListId.ShouldNotBeNull();
                analyticsDataInstance.ListViewUrl.ShouldNotBeNull();
                analyticsDataInstance.FileIsNull.ShouldNotBeNull();
                analyticsDataInstance.ItemId.ShouldNotBeNull();
                analyticsDataInstance.UserId.ShouldNotBeNull();
                analyticsDataInstance.Title.ShouldNotBeNull();
                analyticsDataInstance.Icon.ShouldNotBeNull();
                analyticsDataInstance.FString.ShouldNotBeNull();
                analyticsDataInstance.IsItem.ShouldNotBeNull();
                analyticsDataInstance.IsListView.ShouldNotBeNull();
            }
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticsData) => Property (Action) Property Type Test Except String

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Action_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            const string propertyNameAction = "Action";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);
            var randomString = CreateType<string>();

            if (analyticsDataInstance != null)
            {
                // Act
                var propertyInfo = analyticsDataInstance.GetType().GetProperty(propertyNameAction);

                // Assert
                Should.Throw<ArgumentException>(() => propertyInfo.SetValue(analyticsDataInstance, randomString, null));
            }
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticsData) => Property (Action) Exists tests

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Class_Invalid_Property_ActionNotPresent_Access_Using_Reflexion_Doesnt_Throw_Exception_Test()
        {
            // Arrange
            const string propertyNameAction = "ActionNotPresent";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Assert
                Should.NotThrow(() => analyticsDataInstance.GetType().GetProperty(propertyNameAction));
            }
        }

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Public_Class_Action_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            const string propertyNameAction = "Action";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Arrange
                var propertyInfo  = analyticsDataInstance.GetType().GetProperty(propertyNameAction);

                if (propertyInfo != null && propertyInfo.IsPublicGet())
                {
                    // Act
                    var canRead = propertyInfo.CanRead;

                    // Assert
                    canRead.ShouldBeTrue();
                }
            }
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticsData) => Property (FileIsNull) Exists tests

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Class_Invalid_Property_FileIsNullNotPresent_Access_Using_Reflexion_Doesnt_Throw_Exception_Test()
        {
            // Arrange
            const string propertyNameFileIsNull = "FileIsNullNotPresent";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Assert
                Should.NotThrow(() => analyticsDataInstance.GetType().GetProperty(propertyNameFileIsNull));
            }
        }

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Public_Class_FileIsNull_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            const string propertyNameFileIsNull = "FileIsNull";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Arrange
                var propertyInfo  = analyticsDataInstance.GetType().GetProperty(propertyNameFileIsNull);

                if (propertyInfo != null && propertyInfo.IsPublicGet())
                {
                    // Act
                    var canRead = propertyInfo.CanRead;

                    // Assert
                    canRead.ShouldBeTrue();
                }
            }
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticsData) => Property (FString) Property Type Test Except String

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_FString_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            const string propertyNameFString = "FString";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);
            var randomString = CreateType<string>();

            if (analyticsDataInstance != null)
            {
                // Act
                var propertyInfo = analyticsDataInstance.GetType().GetProperty(propertyNameFString);

                // Assert
                Should.Throw<ArgumentException>(() => propertyInfo.SetValue(analyticsDataInstance, randomString, null));
            }
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticsData) => Property (FString) Exists tests

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Class_Invalid_Property_FStringNotPresent_Access_Using_Reflexion_Doesnt_Throw_Exception_Test()
        {
            // Arrange
            const string propertyNameFString = "FStringNotPresent";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Assert
                Should.NotThrow(() => analyticsDataInstance.GetType().GetProperty(propertyNameFString));
            }
        }

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Public_Class_FString_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            const string propertyNameFString = "FString";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Arrange
                var propertyInfo  = analyticsDataInstance.GetType().GetProperty(propertyNameFString);

                if (propertyInfo != null && propertyInfo.IsPublicGet())
                {
                    // Act
                    var canRead = propertyInfo.CanRead;

                    // Assert
                    canRead.ShouldBeTrue();
                }
            }
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticsData) => Property (Icon) Exists tests

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Class_Invalid_Property_IconNotPresent_Access_Using_Reflexion_Doesnt_Throw_Exception_Test()
        {
            // Arrange
            const string propertyNameIcon = "IconNotPresent";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Assert
                Should.NotThrow(() => analyticsDataInstance.GetType().GetProperty(propertyNameIcon));
            }
        }

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Public_Class_Icon_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            const string propertyNameIcon = "Icon";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Arrange
                var propertyInfo  = analyticsDataInstance.GetType().GetProperty(propertyNameIcon);

                if (propertyInfo != null && propertyInfo.IsPublicGet())
                {
                    // Act
                    var canRead = propertyInfo.CanRead;

                    // Assert
                    canRead.ShouldBeTrue();
                }
            }
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticsData) => Property (IsItem) Exists tests

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Class_Invalid_Property_IsItemNotPresent_Access_Using_Reflexion_Doesnt_Throw_Exception_Test()
        {
            // Arrange
            const string propertyNameIsItem = "IsItemNotPresent";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Assert
                Should.NotThrow(() => analyticsDataInstance.GetType().GetProperty(propertyNameIsItem));
            }
        }

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Public_Class_IsItem_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            const string propertyNameIsItem = "IsItem";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Arrange
                var propertyInfo  = analyticsDataInstance.GetType().GetProperty(propertyNameIsItem);

                if (propertyInfo != null && propertyInfo.IsPublicGet())
                {
                    // Act
                    var canRead = propertyInfo.CanRead;

                    // Assert
                    canRead.ShouldBeTrue();
                }
            }
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticsData) => Property (IsListView) Exists tests

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Class_Invalid_Property_IsListViewNotPresent_Access_Using_Reflexion_Doesnt_Throw_Exception_Test()
        {
            // Arrange
            const string propertyNameIsListView = "IsListViewNotPresent";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Assert
                Should.NotThrow(() => analyticsDataInstance.GetType().GetProperty(propertyNameIsListView));
            }
        }

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Public_Class_IsListView_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            const string propertyNameIsListView = "IsListView";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Arrange
                var propertyInfo  = analyticsDataInstance.GetType().GetProperty(propertyNameIsListView);

                if (propertyInfo != null && propertyInfo.IsPublicGet())
                {
                    // Act
                    var canRead = propertyInfo.CanRead;

                    // Assert
                    canRead.ShouldBeTrue();
                }
            }
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticsData) => Property (ItemId) Exists tests

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Class_Invalid_Property_ItemIdNotPresent_Access_Using_Reflexion_Doesnt_Throw_Exception_Test()
        {
            // Arrange
            const string propertyNameItemId = "ItemIdNotPresent";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Assert
                Should.NotThrow(() => analyticsDataInstance.GetType().GetProperty(propertyNameItemId));
            }
        }

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Public_Class_ItemId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            const string propertyNameItemId = "ItemId";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Arrange
                var propertyInfo  = analyticsDataInstance.GetType().GetProperty(propertyNameItemId);

                if (propertyInfo != null && propertyInfo.IsPublicGet())
                {
                    // Act
                    var canRead = propertyInfo.CanRead;

                    // Assert
                    canRead.ShouldBeTrue();
                }
            }
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticsData) => Property (ListId) Property Type Test Except String

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_ListId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            const string propertyNameListId = "ListId";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);
            var randomString = CreateType<string>();

            if (analyticsDataInstance != null)
            {
                // Act
                var propertyInfo = analyticsDataInstance.GetType().GetProperty(propertyNameListId);

                // Assert
                Should.Throw<ArgumentException>(() => propertyInfo.SetValue(analyticsDataInstance, randomString, null));
            }
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticsData) => Property (ListId) Exists tests

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Class_Invalid_Property_ListIdNotPresent_Access_Using_Reflexion_Doesnt_Throw_Exception_Test()
        {
            // Arrange
            const string propertyNameListId = "ListIdNotPresent";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Assert
                Should.NotThrow(() => analyticsDataInstance.GetType().GetProperty(propertyNameListId));
            }
        }

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Public_Class_ListId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            const string propertyNameListId = "ListId";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Arrange
                var propertyInfo  = analyticsDataInstance.GetType().GetProperty(propertyNameListId);

                if (propertyInfo != null && propertyInfo.IsPublicGet())
                {
                    // Act
                    var canRead = propertyInfo.CanRead;

                    // Assert
                    canRead.ShouldBeTrue();
                }
            }
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticsData) => Property (ListViewUrl) Exists tests

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Class_Invalid_Property_ListViewUrlNotPresent_Access_Using_Reflexion_Doesnt_Throw_Exception_Test()
        {
            // Arrange
            const string propertyNameListViewUrl = "ListViewUrlNotPresent";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Assert
                Should.NotThrow(() => analyticsDataInstance.GetType().GetProperty(propertyNameListViewUrl));
            }
        }

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Public_Class_ListViewUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            const string propertyNameListViewUrl = "ListViewUrl";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Arrange
                var propertyInfo  = analyticsDataInstance.GetType().GetProperty(propertyNameListViewUrl);

                if (propertyInfo != null && propertyInfo.IsPublicGet())
                {
                    // Act
                    var canRead = propertyInfo.CanRead;

                    // Assert
                    canRead.ShouldBeTrue();
                }
            }
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticsData) => Property (SiteId) Property Type Test Except String

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_SiteId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            const string propertyNameSiteId = "SiteId";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);
            var randomString = CreateType<string>();

            if (analyticsDataInstance != null)
            {
                // Act
                var propertyInfo = analyticsDataInstance.GetType().GetProperty(propertyNameSiteId);

                // Assert
                Should.Throw<ArgumentException>(() => propertyInfo.SetValue(analyticsDataInstance, randomString, null));
            }
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticsData) => Property (SiteId) Exists tests

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Class_Invalid_Property_SiteIdNotPresent_Access_Using_Reflexion_Doesnt_Throw_Exception_Test()
        {
            // Arrange
            const string propertyNameSiteId = "SiteIdNotPresent";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Assert
                Should.NotThrow(() => analyticsDataInstance.GetType().GetProperty(propertyNameSiteId));
            }
        }

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Public_Class_SiteId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            const string propertyNameSiteId = "SiteId";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Arrange
                var propertyInfo  = analyticsDataInstance.GetType().GetProperty(propertyNameSiteId);

                if (propertyInfo != null && propertyInfo.IsPublicGet())
                {
                    // Act
                    var canRead = propertyInfo.CanRead;

                    // Assert
                    canRead.ShouldBeTrue();
                }
            }
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticsData) => Property (Title) Exists tests

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Class_Invalid_Property_TitleNotPresent_Access_Using_Reflexion_Doesnt_Throw_Exception_Test()
        {
            // Arrange
            const string propertyNameTitle = "TitleNotPresent";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Assert
                Should.NotThrow(() => analyticsDataInstance.GetType().GetProperty(propertyNameTitle));
            }
        }

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Public_Class_Title_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            const string propertyNameTitle = "Title";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Arrange
                var propertyInfo  = analyticsDataInstance.GetType().GetProperty(propertyNameTitle);

                if (propertyInfo != null && propertyInfo.IsPublicGet())
                {
                    // Act
                    var canRead = propertyInfo.CanRead;

                    // Assert
                    canRead.ShouldBeTrue();
                }
            }
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticsData) => Property (Type) Property Type Test Except String

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Type_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            const string propertyNameType = "Type";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);
            var randomString = CreateType<string>();

            if (analyticsDataInstance != null)
            {
                // Act
                var propertyInfo = analyticsDataInstance.GetType().GetProperty(propertyNameType);

                // Assert
                Should.Throw<ArgumentException>(() => propertyInfo.SetValue(analyticsDataInstance, randomString, null));
            }
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticsData) => Property (Type) Exists tests

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Class_Invalid_Property_TypeNotPresent_Access_Using_Reflexion_Doesnt_Throw_Exception_Test()
        {
            // Arrange
            const string propertyNameType = "TypeNotPresent";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Assert
                Should.NotThrow(() => analyticsDataInstance.GetType().GetProperty(propertyNameType));
            }
        }

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Public_Class_Type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            const string propertyNameType = "Type";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Arrange
                var propertyInfo  = analyticsDataInstance.GetType().GetProperty(propertyNameType);

                if (propertyInfo != null && propertyInfo.IsPublicGet())
                {
                    // Act
                    var canRead = propertyInfo.CanRead;

                    // Assert
                    canRead.ShouldBeTrue();
                }
            }
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticsData) => Property (UserId) Exists tests

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Class_Invalid_Property_UserIdNotPresent_Access_Using_Reflexion_Doesnt_Throw_Exception_Test()
        {
            // Arrange
            const string propertyNameUserId = "UserIdNotPresent";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Assert
                Should.NotThrow(() => analyticsDataInstance.GetType().GetProperty(propertyNameUserId));
            }
        }

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Public_Class_UserId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            const string propertyNameUserId = "UserId";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Arrange
                var propertyInfo  = analyticsDataInstance.GetType().GetProperty(propertyNameUserId);

                if (propertyInfo != null && propertyInfo.IsPublicGet())
                {
                    // Act
                    var canRead = propertyInfo.CanRead;

                    // Assert
                    canRead.ShouldBeTrue();
                }
            }
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticsData) => Property (WebId) Property Type Test Except String

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_WebId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            const string propertyNameWebId = "WebId";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);
            var randomString = CreateType<string>();

            if (analyticsDataInstance != null)
            {
                // Act
                var propertyInfo = analyticsDataInstance.GetType().GetProperty(propertyNameWebId);

                // Assert
                Should.Throw<ArgumentException>(() => propertyInfo.SetValue(analyticsDataInstance, randomString, null));
            }
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticsData) => Property (WebId) Exists tests

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Class_Invalid_Property_WebIdNotPresent_Access_Using_Reflexion_Doesnt_Throw_Exception_Test()
        {
            // Arrange
            const string propertyNameWebId = "WebIdNotPresent";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Assert
                Should.NotThrow(() => analyticsDataInstance.GetType().GetProperty(propertyNameWebId));
            }
        }

        [Test]
        [Category("AUT GetterSetter")]
        public void AUT_AnalyticsData_Public_Class_WebId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            const string propertyNameWebId = "WebId";
            Exception creationException;
            var analyticsDataInstance  = Create(out creationException);

            if (analyticsDataInstance != null)
            {
                // Arrange
                var propertyInfo  = analyticsDataInstance.GetType().GetProperty(propertyNameWebId);

                if (propertyInfo != null && propertyInfo.IsPublicGet())
                {
                    // Act
                    var canRead = propertyInfo.CanRead;

                    // Assert
                    canRead.ShouldBeTrue();
                }
            }
        }

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AnalyticsData) with Parameter Test

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_AnalyticsData_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var t = CreateType<AnalyticsType>();
            var a = CreateType<AnalyticsAction>();
            AnalyticsData instance = null;
            Exception creationException = null;
            Action createAction = ()=> instance = new AnalyticsData(xml, t, a);

            // Act
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            if (creationException == null)
            {
                instance.ShouldNotBeNull();
                instance.ShouldBeOfType<AnalyticsData>();
            }
        }

        [Test]
        [Category("AUT Constructor")]
        public void AUT_Constructor_AnalyticsData_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var t = CreateType<AnalyticsType>();
            var a = CreateType<AnalyticsAction>();
            AnalyticsData instance = null;
            Exception creationException = null;
            Action createAction = ()=> instance = new AnalyticsData(xml, t, a);

            // Act
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            if (creationException == null)
            {
                instance.ShouldNotBeNull();
                Should.NotThrow(createAction);
            }
        }

        #endregion

        #endregion

        #endregion
    }
}