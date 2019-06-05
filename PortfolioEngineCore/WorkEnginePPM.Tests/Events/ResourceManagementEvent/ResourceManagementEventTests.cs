using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkEnginePPM.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint;
using System.Collections;
using EPMLiveCore.Fakes;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using System.ComponentModel.Fakes;
using Shouldly;
using WorkEnginePPM.Events.Fakes;

namespace WorkEnginePPM.Events.Tests
{
    [TestClass()]
    public class ResourceManagementEventTests
    {
        private IDisposable _shimObject;
        private PrivateObject _privateObject;
        private PrivateType _privateType;
        private ResourceManagementEvent _resourcePoolEvent;
        private const string ItemAdding = "ItemAdding";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimObject = ShimsContext.Create();

            _resourcePoolEvent = new ResourceManagementEvent();
            _privateObject = new PrivateObject(_resourcePoolEvent);
            _privateType = new PrivateType(typeof(ResourceManagementEvent));
        }

        [TestCleanup]
        public void TestClean()
        {
            _shimObject?.Dispose();
        }

        [TestMethod()]
        public void UpdateUserTest()
        {
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                ShimSPItemEventProperties shimitemeveprop = new ShimSPItemEventProperties()
                {
                    WebGet = () =>
                    {
                        ShimSPWeb spweb = new ShimSPWeb();
                        spweb.Dispose = () => { };
                        spweb.ListsGet = () =>
                        {
                            ShimSPListCollection lists = new ShimSPListCollection();
                            lists.ItemGetString = (_s) =>
                            {
                                ShimSPList list = new ShimSPList();
                                //list.TitleGet = () => { return listTitle; };
                                list.GetItemByIdInt32 = (_int) => { return new ShimSPListItem() { HasUniqueRoleAssignmentsGet = () => { return true; } }; };
                                list.ItemCountGet = () => { return 1; };
                                list.FieldsGet = () =>
                                {
                                    ShimSPFieldCollection fldc = new ShimSPFieldCollection();
                                    fldc.ItemGetString = (_str) =>
                                    {
                                        ShimSPField fld = new ShimSPField();

                                        return fld;
                                    };
                                    fldc.ContainsFieldString = (_str2) =>
                                    {
                                        return true;
                                    };
                                    return fldc;

                                };
                                list.GetItemsSPQuery = (spq) =>
                                {
                                    ShimSPListItemCollection splist = new ShimSPListItemCollection();
                                    splist.GetEnumerator = () =>
                                    {
                                        return new TestListEnumerator();
                                    };
                                    return splist;
                                };
                                return list;
                            };
                            return lists;
                        };
                        spweb.SiteGet = () =>
                        {
                            ShimSPSite spsite = new ShimSPSite();
                            spsite.SystemAccountGet = () =>
                            {
                                ShimSPUser spuser = new ShimSPUser();
                                spuser.IDGet = () =>
                                {
                                    return 1245;
                                };

                                ; return spuser;
                            };
                            return spsite;
                        };
                        return spweb;
                        //return new ShimSPWeb() { Dispose = () => { } };
                    },
                    ListItemGet = () =>
                    {
                        ShimSPListItem list = new ShimSPListItem();
                        list.TitleGet = () => { return ""; };
                        list.ItemGetString = (_str) =>
                        {
                            return "";
                        };
                        return list;
                    }
                };
                ShimSPFieldUserValue.AllInstances.UserGet = (spf) =>
                {
                    ShimSPUser spuser = new ShimSPUser();
                    spuser.LoginNameGet = () => { return "testdomain\\test"; };
                    return spuser;
                };
                ShimCoreFunctions.GetRealUserNameString = (str) =>
                {
                    return "testdomain\\test";
                };
                ShimCoreFunctions.getConfigSettingSPWebString = (spw, str) =>
                {
                    return "testpath";
                };
                ShimUtilities.CheckEditResourcePlanPermissionStringString = (srg1, srg2) => { return true; };
                ShimUtilities.ReloadListItemSPListItem = (litem) =>
                {
                    ShimSPListItem listitm = new ShimSPListItem();
                    listitm.ItemSetStringObject = (str,ob) =>
                    {

                    };
                    listitm.SystemUpdateBoolean = (bl) => { };
                    return listitm;
                };
                ResourceManagementEvent.UpdateUser(shimitemeveprop);
            }
        }
        [TestMethod]
        public void ItemAdding_SPItemEventPropertiesIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance };
           
            ShimSqlDataReader.AllInstances.Read = _ => true;
            ShimSqlDataReader.AllInstances.Close = _ => { };
            ShimComponent.AllInstances.Dispose = _ => { };
            ShimResourceManagementEvent.AllInstances.ValidateRequestSPItemEventProperties = (_, _1) => true;
            // Act
            var actualResult = _privateObject.Invoke(
                ItemAdding,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }
    }
    public class TestListEnumerator : IEnumerator
    {
        public SPListItem[] _spList = new SPListItem[1];
        int position = -1;
        public TestListEnumerator()
        {
            ShimSPListItem listitm = new ShimSPListItem();
            listitm.ItemGetString = (colname) =>
            {
                if (colname == "Generic")
                {
                    return "NO";
                }
                else if (colname == "ResourceLevel")
                {
                    return "2";
                }
                else { return ""; }

            };
            _spList[0] = listitm;

        }

        public object Current
        {
            get
            {
                return _spList[position];
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < _spList.Length);

        }

        public void Reset()
        {

        }
    }

}

