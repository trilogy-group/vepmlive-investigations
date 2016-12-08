using EPMLiveCore.Fakes;
using EPMLiveCore.Jobs;
using EPMLiveCore.ReportingProxy.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.Specialized.Fakes;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLiveCore.Tests.Jobs
{
    [TestClass()]
    public class SecurityUpdatesTests
    {
        [TestMethod()]
        public void AddBasicSecurityGroupsTest()
        {
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                var user = new ShimSPUser()
                {
                    IDGet = () =>
                    {
                        return 1073741823;
                    }
                };

                var listitem = new ShimSPListItem()
                {
                    ItemGetGuid = (guid) =>
                    {
                        return Guid.NewGuid();
                    },
                    IDGet = () =>
                    {
                        return 1;
                    },
                    TitleGet = () =>
                    {
                        return "Adam Bar";
                    },
                    SystemUpdate = () => { }
                    ,
                    FieldsGet = () =>
                    {
                        return new ShimSPFieldCollection()
                        {
                            GetFieldByInternalNameString = (s) =>
                            {
                                return new ShimSPField()
                                {
                                    IdGet = () => { return Guid.NewGuid(); }
                                };
                            },
                            ItemGetGuid = (guid) =>
                            {
                                return new ShimSPField()
                                {
                                    IdGet = () => { return Guid.NewGuid(); }
                                };
                            }
                        };
                    },
                    ItemSetGuidObject = (a, b) => { },
                    Update = () => { }
                };

                ShimSPList list = new ShimSPList()
                {
                    ItemsGet = () =>
                    {
                        return new ShimSPListItemCollection()
                        {
                            GetItemByIdInt32 = (id) =>
                            {
                                return listitem;
                            }
                        };
                    }

                };

                ShimCoreFunctions.AddGroupSPWebStringStringSPMemberSPUserString = (a, b, c, d, e, f) => { return "final"; };

                ShimSPWeb fakespweb = fakespweb = new ShimSPWeb()
                {
                    IDGet = () =>
                    {
                        return Guid.Parse("D4A8A5A3-5C26-45D0-876C-AC2B4FB86D03");
                    },
                    CurrentUserGet = () =>
                    {
                        return user;
                    },
                    SiteGroupsGet = () =>
                    {
                        return new ShimSPGroupCollection()
                        {
                            ItemGetString = (id) =>
                            {
                                return new ShimSPGroup()
                                {
                                    NameGet = () => { return Guid.NewGuid().ToString(); }
                                };
                            }
                        };
                    },
                    AllowUnsafeUpdatesSetBoolean = (b) => { },
                    SiteGet = () =>
                    {
                        return new ShimSPSite()
                        {
                            UrlGet = () =>
                            {
                                return "";
                            },
                            OpenWebGuid = (gg) =>
                            {
                                return new ShimSPWeb()
                                {
                                    IDGet = () =>
                                    {
                                        return Guid.Parse("D4A8A5A3-5C26-45D0-876C-AC2B4FB86D03");
                                    },
                                    PropertiesGet = () =>
                                    {
                                        var propertyBag = new ShimSPPropertyBag();
                                        var sd = new ShimStringDictionary(propertyBag);
                                        sd.ItemGetString = (key) =>
                                        {
                                            return "EPMLive_MyWork_Grid_GlobalViews";
                                        };
                                        return propertyBag;
                                    },
                                    SiteGet = () =>
                                    {
                                        return new ShimSPSite()
                                        {
                                            IDGet = () =>
                                            {
                                                return Guid.Parse("D4A8A5A3-5C26-45D0-876C-AC2B4FB86D03");
                                            }
                                        };
                                    },
                                    Dispose = () => { },
                                    AllowUnsafeUpdatesSetBoolean = (b) => { }
                                };
                            },
                            RootWebGet = () =>
                            {
                                return new ShimSPWeb()
                                {
                                    ListsGet = () =>
                                    {
                                        return new ShimSPListCollection()
                                        {
                                            ItemGetString = (s) =>
                                            {
                                                return list;
                                            }
                                        };
                                    },
                                    IDGet = () =>
                                    {
                                        return Guid.Parse("D4A8A5A3-5C26-45D0-876C-AC2B4FB86D03");
                                    }
                                };
                            }
                        };
                    },
                    ParentWebGet = () =>
                    {
                        return null;
                    },
                    PropertiesGet = () =>
                    {
                        var propertyBag = new ShimSPPropertyBag();
                        var sd = new ShimStringDictionary(propertyBag);
                        sd.ItemGetString = (key) =>
                        {
                            return "EPMLiveLockConfig";
                        };
                        return propertyBag;
                    }
                    ,
                    Update = () => { }
                };
                fakespweb.Dispose = () => { };

                var objSecurityUpdates = new SecurityUpdate();
                var dict = objSecurityUpdates.AddBasicSecurityGroups(fakespweb, "title", user, listitem);

                Assert.IsTrue(dict.Count == 3);
            }
        }
    }
}
