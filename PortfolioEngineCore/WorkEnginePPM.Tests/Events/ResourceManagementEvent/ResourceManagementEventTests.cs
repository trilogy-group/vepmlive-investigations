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

namespace WorkEnginePPM.Events.Tests
{
    [TestClass()]
    public class ResourceManagementEventTests
    {
        [TestMethod()]
        public void UpdateUserTest()
        {
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                ShimSPItemEventProperties shimitemeveprop = new ShimSPItemEventProperties()
                {
                    OpenWeb = () =>
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

