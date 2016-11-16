using EPMLiveCore.Fakes;
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

namespace EPMLiveCore.Tests.API.MyWork
{
    [TestClass()]
    public class MyWorkTests
    {
        [TestMethod()]
        public void SaveMyWorkGridViewTestForUserWithDesignPermission()
        {
            var result = ProcessNewSaveRequest(true);
            Assert.AreEqual(result, "<MyWork />");
        }

        [TestMethod()]
        public void SaveMyWorkGridViewTestForUserWithoutDesignPermission()
        {
            var result = ProcessNewSaveRequest(false);
            Assert.AreEqual(result, "<MyWork />");
        }

        private string ProcessNewSaveRequest(bool hasPermission)
        {
            PrivateType objToTestPrivateMethod = new PrivateType(typeof(EPMLiveCore.API.MyWork));

            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                ShimSPWeb fakespweb = fakespweb = new ShimSPWeb()
                {
                    IDGet = () =>
                    {
                        return Guid.Parse("D4A8A5A3-5C26-45D0-876C-AC2B4FB86D03");
                    },
                    CurrentUserGet = () =>
                    {
                        return new ShimSPUser()
                        {
                            IDGet = () =>
                            {
                                return 1073741823;
                            }
                        };
                    },
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

                };
                fakespweb.Dispose = () => { };               

                ShimSPSite.ConstructorString = (instance, url) =>
                {
                    ShimSPSite moledInstance = new ShimSPSite(instance);
                    moledInstance.Dispose = () => { };
                    ShimSPSite.AllInstances.OpenWeb = (ins) =>
                    {

                        return fakespweb;
                    };
                };

                ShimSPSite.ConstructorGuid = (instance, url) =>
                {
                    ShimSPSite moledInstance = new ShimSPSite(instance)
                    {
                        IDGet = () =>
                        {
                            return Guid.Parse("D4A8A5A3-5C26-45D0-876C-AC2B4FB86D03");
                        },
                        WebApplicationGet = () =>
                        {
                            var webApp = new ShimSPWebApplication();
                            var persistedObject = new ShimSPPersistedObject(webApp);
                            persistedObject.IdGet = () =>
                            {
                                return Guid.Parse("D4A8A5A3-5C26-45D0-876C-AC2B4FB86DAA");
                            };
                            return webApp;
                        }
                    };
                    moledInstance.Dispose = () => { };
                    ShimSPSite.AllInstances.OpenWeb = (ins) =>
                    {



                        return fakespweb;
                    };
                };

                ShimCoreFunctions.iGetConfigSettingSPWebStringBooleanBoolean = (p1, p2, p3, p4) =>
                {
                    return "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfMyWorkGridView xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <MyWorkGridView>\r\n    <Cols>Flag:30,Work0000Type:131,Project:116,DueDate:100,WorkingOn:85</Cols>\r\n    <Default>false</Default>\r\n    <Filters>0|WorkingOn:1:11</Filters>\r\n    <Grouping>0|</Grouping>\r\n    <Id>7e9399ec83ae91854b600b808918b3c4</Id>\r\n    <LeftCols>Complete:20,CommentCount:36,Priority:25,Title:222</LeftCols>\r\n    <Name>Working On It</Name>\r\n    <Personal>false</Personal>\r\n    <RightCols />\r\n    <Sorting>DueDate</Sorting>\r\n    <HasPermission>false</HasPermission>\r\n  </MyWorkGridView>\r\n  <MyWorkGridView>\r\n    <Cols>Work0000Type:89,StartDate:97,DueDate:131,Status:38,PercentComplete:113,Flag:41,Project:83,WorkingOn:86</Cols>\r\n    <Default>false</Default>\r\n    <Filters>0|</Filters>\r\n    <Grouping>0|Due</Grouping>\r\n    <Id>0007b12319302de33f227d1e08e089be</Id>\r\n    <LeftCols>Complete:20,CommentCount:36,Priority:25,Title:213</LeftCols>\r\n    <Name>My Work by Due</Name>\r\n    <Personal>false</Personal>\r\n    <RightCols />\r\n    <Sorting>DueDate</Sorting>\r\n    <HasPermission>false</HasPermission>\r\n  </MyWorkGridView>\r\n  <MyWorkGridView>\r\n    <Cols>Work0000Type:119,Due:98,StartDate:83,DueDate:112,Work:33,Status:56,PercentComplete:113,Flag:44,WorkingOn:86</Cols>\r\n    <Default>false</Default>\r\n    <Filters>0|</Filters>\r\n    <Grouping>0|Project</Grouping>\r\n    <Id>2ba87d5cf4822160e548843193ad30db</Id>\r\n    <LeftCols>Complete:20,CommentCount:36,Priority:25,Title:140</LeftCols>\r\n    <Name>My Work by Project</Name>\r\n    <Personal>false</Personal>\r\n    <RightCols />\r\n    <Sorting>DueDate,Due</Sorting>\r\n    <HasPermission>false</HasPermission>\r\n  </MyWorkGridView>\r\n  <MyWorkGridView>\r\n    <Cols>DueDate:58,WorkingOn:100</Cols>\r\n    <Default>false</Default>\r\n    <Filters>0|</Filters>\r\n    <Grouping>0|</Grouping>\r\n    <Id>0111d91d9fc6c72b3fe349a55e89048a</Id>\r\n    <LeftCols>Complete:25,CommentCount:36,Priority:25,Title:601</LeftCols>\r\n    <Name>Work Summary</Name>\r\n    <Personal>false</Personal>\r\n    <RightCols />\r\n    <Sorting>DueDate</Sorting>\r\n    <HasPermission>false</HasPermission>\r\n  </MyWorkGridView>\r\n  <MyWorkGridView>\r\n    <Cols />\r\n    <Default>false</Default>\r\n    <Filters>0|</Filters>\r\n    <Grouping>0|</Grouping>\r\n    <Id>57bcc4f29adfe3c1f09d7e29e7128bdb</Id>\r\n    <LeftCols>Complete:25,CommentCount:36,Priority:25,Title:570</LeftCols>\r\n    <Name>gg3</Name>\r\n    <Personal>false</Personal>\r\n    <RightCols>Flag:30,Work0000Type:125,Project:90,DueDate:100,WorkingOn:87</RightCols>\r\n    <Sorting>DueDate</Sorting>\r\n    <HasPermission>true</HasPermission>\r\n  </MyWorkGridView>\r\n  <MyWorkGridView>\r\n    <Cols />\r\n    <Default>false</Default>\r\n    <Filters>0|</Filters>\r\n    <Grouping>0|</Grouping>\r\n    <Id>dv</Id>\r\n    <LeftCols>Complete:25,CommentCount:36,Priority:25,Title:570</LeftCols>\r\n    <Name>Default View</Name>\r\n    <Personal>false</Personal>\r\n    <RightCols>Flag:30,Work0000Type:125,Project:90,DueDate:100,WorkingOn:87</RightCols>\r\n    <Sorting>DueDate</Sorting>\r\n    <HasPermission>true</HasPermission>\r\n  </MyWorkGridView>\r\n  <MyWorkGridView>\r\n    <Cols />\r\n    <Default>true</Default>\r\n    <Filters>0|</Filters>\r\n    <Grouping>0|</Grouping>\r\n    <Id>ec6ef230f1828039ee794566b9c58adc</Id>\r\n    <LeftCols>Complete:25,CommentCount:36,Priority:25,Title:570</LeftCols>\r\n    <Name>p1</Name>\r\n    <Personal>true</Personal>\r\n    <RightCols>Flag:30,Work0000Type:125,Project:90,DueDate:100,WorkingOn:87</RightCols>\r\n    <Sorting>DueDate</Sorting>\r\n    <HasPermission>true</HasPermission>\r\n  </MyWorkGridView>\r\n</ArrayOfMyWorkGridView>";
                };

                ShimSPContext.CurrentGet = () =>
                {
                    return new ShimSPContext()
                    {
                        WebGet = () =>
                        {
                            return fakespweb;
                        }
                    };
                };
               

                ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = (w) =>
                {
                    w();
                };

                ShimCoreFunctions.getConnectionStringGuid = (guid) =>
                {
                    return "Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;";
                };
              
                var openedConnections = 0;
                var closedConnections = 0;

                ShimSqlConnection.ConstructorString = (instance, connString) =>
                {
                    var connection = new ShimSqlConnection(instance);
                    connection.Open = () => { openedConnections++; };
                    connection.Close = () => { closedConnections++; };
                };


                ShimSqlCommand.ConstructorStringSqlConnection = (instance, cmdText, sqlConnection) =>
                {
                    ShimSqlCommand sqlCommand = new ShimSqlCommand(instance);
                    sqlCommand.ParametersGet = () =>
                    {
                        var realSqlCommand = new SqlCommand();
                        return realSqlCommand.Parameters;
                    };

                    sqlCommand.ExecuteScalar = () =>
                    {
                        return "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfMyWorkGridView xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <MyWorkGridView>\r\n    <Cols />\r\n    <Default>false</Default>\r\n    <Filters>0|</Filters>\r\n    <Grouping>0|</Grouping>\r\n    <Id>7d7f7e971ca8152804ad89b891fba0b4</Id>\r\n    <LeftCols>Complete:25,CommentCount:36,Priority:25,Title:554</LeftCols>\r\n    <Name>gg2</Name>\r\n    <Personal>true</Personal>\r\n    <RightCols>Flag:30,Work0000Type:125,Project:90,DueDate:100,WorkingOn:87</RightCols>\r\n    <Sorting>DueDate</Sorting>\r\n    <HasPermission>true</HasPermission>\r\n  </MyWorkGridView>\r\n  <MyWorkGridView>\r\n    <Cols />\r\n    <Default>false</Default>\r\n    <Filters>0|</Filters>\r\n    <Grouping>0|</Grouping>\r\n    <Id>57bcc4f29adfe3c1f09d7e29e7128bdb</Id>\r\n    <LeftCols>Complete:25,CommentCount:36,Priority:25,Title:554</LeftCols>\r\n    <Name>gg3</Name>\r\n    <Personal>true</Personal>\r\n    <RightCols>Flag:30,Work0000Type:125,Project:90,DueDate:100,WorkingOn:87</RightCols>\r\n    <Sorting>DueDate</Sorting>\r\n    <HasPermission>true</HasPermission>\r\n  </MyWorkGridView>\r\n  <MyWorkGridView>\r\n    <Cols />\r\n    <Default>true</Default>\r\n    <Filters>0|</Filters>\r\n    <Grouping>0|</Grouping>\r\n    <Id>ec6ef230f1828039ee794566b9c58adc</Id>\r\n    <LeftCols>Complete:25,CommentCount:36,Priority:25,Title:570</LeftCols>\r\n    <Name>p1</Name>\r\n    <Personal>true</Personal>\r\n    <RightCols>Flag:30,Work0000Type:125,Project:90,DueDate:100,WorkingOn:87</RightCols>\r\n    <Sorting>DueDate</Sorting>\r\n    <HasPermission>true</HasPermission>\r\n  </MyWorkGridView>\r\n</ArrayOfMyWorkGridView>";
                    };

                    sqlCommand.ExecuteNonQuery = () =>
                    {
                        return 1;
                    };
                };

                var data = "<MyWork><View ID=\"73c18c59a39b18382081ec00bb456d43\" Name=\"gg\" Default=\"true\" Personal=\"false\" HasPermission=\""+ hasPermission.ToString() +"\" LeftCols=\"Complete:25,CommentCount:36,Priority:25,Title:570\" Cols=\"\" RightCols=\"Flag:30,Work0000Type:125,Project:90,DueDate:100,WorkingOn:87\" Filters=\"0|\" Grouping=\"0|\" Sorting=\"DueDate\"/></MyWork>";

                string result = "";
                result = objToTestPrivateMethod.InvokeStatic("SaveMyWorkGridView", data) as string;

                Assert.AreEqual(openedConnections, closedConnections);

                return result;
            }
        }
    }
}
