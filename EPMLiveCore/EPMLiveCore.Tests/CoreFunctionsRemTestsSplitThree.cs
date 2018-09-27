using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.Specialized.Fakes;
using System.Configuration.Fakes;
using System.Globalization;
using System.Linq;
using System.Net.Fakes;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Fakes;
using EPMLiveCore.SPUtilities.Fakes;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests
{
    public partial class CoreFunctionsRemTests
    {
        private const string GetFeatureUsersMethodName = "getFeatureUsers";
        private const string GetUserCountMethodName = "getUserCount";
        private const string DeleteKeyMethodName = "deleteKey";
        private const string FeatureListMethodName = "featureList";

        private void SetupShimsSplitThree()
        {
            ShimUserManager.ConstructorStringSPPersistedObjectGuid = (_, _1, _2, _3) => new ShimUserManager();
            ShimSPSite.ConstructorString = (_, __) => new ShimSPSite();
            ShimSPSite.AllInstances.OpenWeb = _ => spWeb;
            ShimSPSite.AllInstances.RootWebGet = _ => spWeb;
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPSite.AllInstances.AllowUnsafeUpdatesSetBoolean = (_, __) => { };
            ShimSPWebApplication.AllInstances.JobDefinitionsGet = _ => new ShimSPJobDefinitionCollection();
        }

        [TestMethod]
        public void GetFeatureUsers_WhenCalled_ReturnsArrayList()
        {
            // Arrange
            var validation = 0;
            var arrayList = new ArrayList()
            {
                string.Empty
            };

            ShimSPPersistedObject.AllInstances.GetChildOf1String<UserManager>((_, _1) => null);
            ShimSPPersistedObject.AllInstances.Update = _ =>
            {
                validation = validation + 1;
            };
            spFarm.Update = () =>
            {
                validation = validation + 1;
            };
            ShimUserManager.AllInstances.UserListGet = _ => arrayList;

            // Act
            var actual = (ArrayList)privateObject.Invoke(
                GetFeatureUsersMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { 1 });

            // Assert
            actual.Count.ShouldBe(0);
        }

        [TestMethod]
        public void GetUserCount_ArrayContainsUserNameTrue_ReturnsInt()
        {
            // Arrange
            var arrayList = new ArrayList()
            {
                DummyString,
                DummyString,
                DummyString
            };

            ShimCoreFunctions.getFeatureUsersInt32 = _ => arrayList;

            // Act
            var actual = (int)privateObject.Invoke(
                GetUserCountMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { 1, DummyString, 10 });

            // Assert
            actual.ShouldBe(3);
        }

        [TestMethod]
        public void GetUserCount_ArrayContainsUserNameFalseEmptyString_ReturnsInt()
        {
            // Arrange
            var userlist = $"{DummyString},12345,Dummy,Char";
            var arrayList = new ArrayList()
            {
                string.Empty
            };

            ShimCoreFunctions.getFeatureUsersInt32 = _ => arrayList;
            spWeb.PropertiesGet = () => new ShimSPPropertyBag();
            ShimStringDictionary.AllInstances.ItemGetString = (_, __) => userlist;

            // Act
            var actual = (int)privateObject.Invoke(
                GetUserCountMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { 1, DummyString, 10 });

            // Assert
            actual.ShouldBe(4);
        }

        [TestMethod]
        public void GetUserCount_ArrayContainsUserNameFalseNonEmptyString_ReturnsInt()
        {
            // Arrange
            const string jobName = "WorkEngineActivation";

            var userlist = "Empty";
            var arrayList = new ArrayList()
            {
                $"Not{DummyString}"
            };

            ShimCoreFunctions.getFeatureUsersInt32 = _ => arrayList;
            spWeb.PropertiesGet = () => new ShimSPPropertyBag()
            {
                Update = () => { }
            };
            ShimStringDictionary.AllInstances.ItemGetString = (_, __) => userlist;
            ShimSPPersistedObjectCollection<SPJobDefinition>.AllInstances.GetEnumerator = _ => new List<SPJobDefinition>()
            {
                new StubSPJobDefinition()
                {
                    Name = jobName
                }
                //{
                //    NameGet = () => jobName
                //}.Instance
            }.GetEnumerator();

            // Act
            var actual = (int)privateObject.Invoke(
                GetUserCountMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { 1, DummyString, 10 });

            // Assert
            actual.ShouldBe(1);
        }

        [TestMethod]
        public void DeleteKey_WhenCalled_ModifiesKeys()
        {
            // Arrange
            const string keyString = "EPMLiveKeys";
            const string newKey = "NewKey";
            var keyValue = $"{DummyString}\t{DummyString}\t{newKey}\t{newKey}";
            var validation = false;
            var hashTable = new Hashtable()
            {
                [keyString] = keyValue
            };

            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => hashTable;
            spFarm.Update = () =>
            {
                validation = true;
            };

            // Act
            privateObject.Invoke(
                DeleteKeyMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { DummyString });

            // Assert
            validation.ShouldBeTrue();
        }

        [TestMethod]
        public void FeatureList_WhenCalled_ReturnsStringArray()
        {
            // Arrange
            const string keyString = "EPMLiveKeys";
            var keyValue = $"{DummyString}\t{DummyString}";

            var hashTable = new Hashtable()
            {
                [keyString] = keyValue
            };

            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => hashTable;
            ShimCoreFunctions.farmEncodeString = input => input;

            // Act
            var actual = (string[])privateObject.Invoke(
                FeatureListMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Length.ShouldBe(1),
                () => actual[0].ShouldBe(DummyString));
        }
    }
}