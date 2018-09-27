using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized.Fakes;
using System.Reflection;
using EPMLiveCore.Fakes;
using Microsoft.SharePoint;
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
        private const string EnqueueMethodName = "enqueue";
        private const string EnsureNoDuplicatesMethodName = "EnsureNoDuplicates";
        private const string GetResourceWithDuplicateEmailMethodName = "GetResourceWithDuplicateEmail";

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

        [TestMethod]
        public void Enqueue_WhenCalled_Enques()
        {
            // Arrange
            var validation = true;

            ShimCoreFunctions.enqueueGuidInt32SPSite = (actualGuid, actualInt, actualSite) =>
            {
                validation = validation && actualGuid.Equals(guid);
                validation = validation && actualInt.Equals(1);
            };

            // Act
            privateObject.Invoke(
                EnqueueMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { guid, 1 });

            // Assert
            validation.ShouldBeTrue();
        }

        [TestMethod]
        public void EnsureNoDuplicates_WhenCalled_EnsuresNoDuplicates()
        {
            // Arrange
            var validation = false;
            var properties = new ShimSPItemEventProperties()
            {
                AfterPropertiesGet = () => new ShimSPItemEventDataCollection()
                {
                    ItemGetString = input =>
                    {
                        throw new Exception();
                    }
                },
                ListItemGet = () => new ShimSPListItem()
                {
                    ItemGetString = input =>
                    {
                        if (input.Equals("Generic"))
                        {
                            throw new Exception();
                        }

                        return DummyString;
                    }
                }
            };

            ShimCoreFunctions.GetResourceWithDuplicateEmailSPItemEventPropertiesBooleanBooleanStringSPUserOut =
                (SPItemEventProperties propertiesParam, Boolean isAdd, Boolean isOnline, string sharePointAccount, out SPUser u) =>
                {
                    validation = true;
                    u = null;
                    return new ShimSPListItemCollection()
                    {
                        CountGet = () => 0
                    };
                };

            // Act
            privateObject.Invoke(
                EnsureNoDuplicatesMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { properties.Instance, true, true });

            // Assert
            validation.ShouldBeTrue();
        }

        [TestMethod]
        public void GetResourceWithDuplicateEmail_IsAddTrueisOnlineTrue_ReturnsListItemCollection()
        {
            // Arrange
            const bool isAdd = true;
            const bool isOnline = true;

            var properties = new ShimSPItemEventProperties()
            {
                WebGet = () => spWeb,
                ListGet = () => spList,
                ListItemGet = () => spListItem
            };

            spList.GetItemsSPQuery = _ => new ShimSPListItemCollection()
            {
                CountGet = () => 10,
                ItemGetInt32 = __ => spListItem
            };

            // Act
            var actual = (SPListItemCollection)privateObject.Invoke(
                GetResourceWithDuplicateEmailMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { properties.Instance, isAdd, isOnline, string.Empty, spUser.Instance });

            // Assert
            actual.Count.ShouldBe(10);
        }

        [TestMethod]
        public void GetResourceWithDuplicateEmail_IsAddTrueisOnlineFalse_ReturnsListItemCollection()
        {
            // Arrange
            const bool isAdd = true;
            const bool isOnline = false;

            var properties = new ShimSPItemEventProperties()
            {
                WebGet = () => spWeb,
                ListGet = () => spList,
                ListItemGet = () => spListItem
            };

            spList.GetItemsSPQuery = _ => new ShimSPListItemCollection()
            {
                CountGet = () => 10,
                ItemGetInt32 = __ => spListItem
            };

            // Act
            var actual = (SPListItemCollection)privateObject.Invoke(
                GetResourceWithDuplicateEmailMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { properties.Instance, isAdd, isOnline, string.Empty, spUser.Instance });

            // Assert
            actual.Count.ShouldBe(10);
        }

        [TestMethod]
        public void GetResourceWithDuplicateEmail_IsAddFalseisOnlineTrue_ReturnsListItemCollection()
        {
            // Arrange
            const bool isAdd = false;
            const bool isOnline = true;

            var properties = new ShimSPItemEventProperties()
            {
                WebGet = () => spWeb,
                ListGet = () => spList,
                ListItemGet = () => spListItem
            };

            spList.GetItemsSPQuery = _ => new ShimSPListItemCollection()
            {
                CountGet = () => 10,
                ItemGetInt32 = __ => spListItem
            };

            // Act
            var actual = (SPListItemCollection)privateObject.Invoke(
                GetResourceWithDuplicateEmailMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { properties.Instance, isAdd, isOnline, string.Empty, spUser.Instance });

            // Assert
            actual.Count.ShouldBe(10);
        }

        [TestMethod]
        public void GetResourceWithDuplicateEmail_IsAddFalseisOnlineFalse_ReturnsListItemCollection()
        {
            // Arrange
            const bool isAdd = false;
            const bool isOnline = false;

            var properties = new ShimSPItemEventProperties()
            {
                WebGet = () => spWeb,
                ListGet = () => spList,
                ListItemGet = () => spListItem
            };

            spList.GetItemsSPQuery = _ => new ShimSPListItemCollection()
            {
                CountGet = () => 10,
                ItemGetInt32 = __ => spListItem
            };

            // Act
            var actual = (SPListItemCollection)privateObject.Invoke(
                GetResourceWithDuplicateEmailMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { properties.Instance, isAdd, isOnline, string.Empty, spUser.Instance });

            // Assert
            actual.Count.ShouldBe(10);
        }
    }
}