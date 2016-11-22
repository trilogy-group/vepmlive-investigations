using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPMLiveCore.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using System.Collections.Specialized.Fakes;
using System.Data.Fakes;
using System.Data;
using WorkEnginePPM.Fakes;
using Microsoft.SharePoint;
using System.Web.Fakes;
using System.Xml.Fakes;
using System.Collections.Generic;
using System.Collections;
using System.Web.SessionState.Fakes;
using System.Diagnostics;
using Microsoft.QualityTools.Testing.Fakes.Shims;
using Microsoft.QualityTools.Testing.Fakes;
using System.Collections.Generic.Fakes;

namespace WorkEnginePPM.Tests
{
    [TestClass]
    public class HelperFunctionsTests
    {
        [TestMethod]
        public void processPortfolioItemTest_NoUpdateNeeded()
        {


            var tblInput = new DataTable();
            tblInput.Columns.Add("ID", typeof(string));
            tblInput.Columns.Add("Value", typeof(string));
            tblInput.Columns.Add("PortfolioItem_Id", typeof(int));

            tblInput.Rows.Add("Team", "1", "1");
            tblInput.Rows.Add("Team1", "2", "2");

            var tblResult = new DataTable();
            tblResult.Columns.Add("EXTID", typeof(string));
            tblResult.Columns.Add("SPID", typeof(string));

            tblResult.Rows.Add("1", "1");
            tblResult.Rows.Add("2", "2");

            bool wasUpdated = false;
            string result = ProcessCommonData(tblInput, tblResult, false, out wasUpdated);

            Assert.IsTrue(result == "<Item ID=\"555\" Error=\"0\"/>");
            Assert.IsTrue(!wasUpdated);
        }

        [TestMethod]
        public void processPortfolioItemTest_UpdateNeeded()
        {


            var tblInput = new DataTable();
            tblInput.Columns.Add("ID", typeof(string));
            tblInput.Columns.Add("Value", typeof(string));
            tblInput.Columns.Add("PortfolioItem_Id", typeof(int));

            tblInput.Rows.Add("Team", "1", "1");
            tblInput.Rows.Add("Team1", "2", "2");

            var tblResult = new DataTable();
            tblResult.Columns.Add("EXTID", typeof(string));
            tblResult.Columns.Add("SPID", typeof(string));

            tblResult.Rows.Add("1", "1");
            tblResult.Rows.Add("2", "2");

            bool wasUpdated = false;
            string result = ProcessCommonData(tblInput, tblResult, true, out wasUpdated);

            Assert.IsTrue(result == "<Item ID=\"555\" Error=\"0\"/>");
            Assert.IsTrue(wasUpdated);

        }

        private static string ProcessCommonData(DataTable tblInput, DataTable tblResult, bool shouldUpdate, out bool wasUpdated)
        {
            bool updated = false;

            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                var sessionState = new Dictionary<string, object>();
                sessionState.Add("ResPoolDt", tblResult);

                ShimHttpContext.CurrentGet = () => new ShimHttpContext();
                ShimHttpContext.AllInstances.SessionGet = (o) =>
                {
                    return new ShimHttpSessionState
                    {
                        ItemGetString = (key) =>
                        {
                            object res = null;
                            sessionState.TryGetValue(key, out res);
                            return res;
                        }
                    };
                };

                ShimSPSite site1 = new ShimSPSite()
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


                ShimSPWeb fakespweb = new ShimSPWeb()
                {
                    IDGet = () =>
                    {
                        return Guid.Parse("D4A8A5A3-5C26-45D0-876C-AC2B4FB86D03");
                    },
                    AllUsersGet = () =>
                    {
                        return new ShimSPUserCollection()
                        {
                            GetByIDInt32 = (id) =>
                            {
                                return new ShimSPUser()
                                {
                                    IDGet = () =>
                                    {
                                        return 12;
                                    },
                                    NameGet = () =>
                                    {
                                        return "name";
                                    }
                                };
                            }
                        };
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
                        return site1;

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
                    },
                    AllowUnsafeUpdatesSetBoolean = (b) => { }

                };

                ShimCoreFunctions.getConfigSettingSPWebString = (w, s) =>
                {
                    return "9925,ProjectManagers,2 | 9930,ProjectManagers,2 | 9902,ProjectFinish,2 | 9901,ProjectStart,2 | 20033,PrioritizationScore,2 | 20014,ProjectType,2 | 20016,State,2 | 20031,ProjectActualCost,1 | 20002,Budget,1 | 21000,Selected,1 | 20032,PlannedBenefit,1 | 20006,ResourcePlanCost,1 | 21001,ResourcePlanHours,1";
                };

                ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (w, s, b) =>
                {
                    return "9925,ProjectManagers,2 | 9930,ProjectManagers,2 | 9902,ProjectFinish,2 | 9901,ProjectStart,2 | 20033,PrioritizationScore,2 | 20014,ProjectType,2 | 20016,State,2 | 20031,ProjectActualCost,1 | 20002,Budget,1 | 21000,Selected,1 | 20032,PlannedBenefit,1 | 20006,ResourcePlanCost,1 | 21001,ResourcePlanHours,1";
                };

                //ShimHelperFunctions.pre

                ShimSPList.AllInstances.TitleGet = (insance) =>
                {
                    return "";
                };

                ShimSPList.AllInstances.ParentWebGet = (insance) =>
                {
                    return fakespweb;
                };

                ShimSPList.AllInstances.GetItemByIdInt32 = (id, id1) =>
                {
                    return new ShimSPListItem()
                    {
                        FieldsGet = () =>
                        {
                            return new ShimSPFieldCollection();
                        },
                        ItemGetString = (s) =>
                        {
                            return new ShimSPField();
                        },
                        ItemSetStringObject = (s, s2) =>
                        {
                        },
                        SystemUpdate = () =>
                        {
                            updated = true;
                        }
                    };
                };

                ShimSPField field = new ShimSPField();
                field.IdGet = () =>
                {
                    return Guid.Parse("fdc3b2ed-5bf2-4835-a4bc-b885f3396a61");
                };
                field.InternalNameGet = () => { return ""; };
                field.TypeGet = () =>
                {
                    return SPFieldType.Number;
                };
                field.TypeAsStringGet = () =>
                {

                    return "";
                };
                field.SchemaXmlGet = () =>
                {
                    return "<CHOICES><CHOICE Value = \"Text\" ></CHOICE> <CHOICE Value = \"Text\" ></CHOICE></CHOICES>";

                };
                field.GetFieldValueString = (obj) =>
                {
                    return "";
                };

               

                ShimSPField.AllInstances.IdGet = (instance) =>
                {
                    return Guid.Parse("fdc3b2ed-5bf2-4835-a4bc-b885f3396a61");
                };
                ShimSPField.AllInstances.InternalNameGet = (instance) => { return ""; };
                ShimSPField.AllInstances.TypeGet = (instance) =>
                {
                    return SPFieldType.Number;
                };
                ShimSPField.AllInstances.TypeAsStringGet = (instance) =>
                {
                    return "";
                };
                ShimSPField.AllInstances.SchemaXmlGet = (instance) =>
                {
                    return "<CHOICES><CHOICE Value = \"Text\" ></CHOICE> <CHOICE Value = \"Text\" ></CHOICE></CHOICES>";

                };
                ShimSPField.AllInstances.GetFieldValueString = (instance, str) =>
                {
                    return "";
                };
                ShimSPList.AllInstances.FieldsGet = (instance) =>
                {
                    ShimSPFieldCollection fcol = new ShimSPFieldCollection();
                    fcol.ContainsFieldString = (str) =>
                    {
                        return true;
                    };
                    fcol.GetFieldByInternalNameString = (a) =>
                    {


                        return field;

                    };
                    return fcol;
                };



                ShimSPListItem.AllInstances.FieldNamesGet = (instance) =>
                {
                    ShimSPFieldCollection fcol = new ShimSPFieldCollection();
                    fcol.ContainsFieldString = (str) =>
                    {
                        return true;
                    };
                    fcol.GetFieldString = (a) =>
                    {
                        return field;
                    };
                    return new string[] { };
                };

                // CODE HAVING THE ISSUE
                ShimSPFieldUserValueCollection uvc = new ShimSPFieldUserValueCollection();
                //ShimSPFieldUserValueCollection.AllInstances.item
                //SPFieldUserValueCollection collection = new SPFieldUserValueCollection(fakespweb, "");
                ShimSPFieldUserValue.AllInstances.LookupValueGet = (instance) =>
                {
                    return "0";
                };

                ShimSPFieldUserValueCollection. Constructor = (instance) =>
                {

                };

                ShimSPFieldUserValueCollection.ConstructorSPWebString = (instance, web, s) =>
                {
                    //var lst = new ShimExSPFieldUserValueCollection(instance);
                    //lst.AddSPFieldUserValue = (value) =>
                    //{

                    //};
                    //ShimSPFieldUserValue
                    // instance = new ShimSPFieldUserValueCollection();
                    //instance.Add (fielduservalue);
                    
                    //System.Collections.Generic.Fakes.StubList<SPFieldUserValue> lst = new System.Collections.Generic.Fakes.StubList<SPFieldUserValue>(instance);
                    //lst.Add = () = { };
                };

                ShimSPFieldUserValueCollection.BehaveAsCurrent();
                ShimHttpUtility.HtmlEncodeString = (a) => { return a; };
                ShimSPFieldCollection.AllInstances.ContainsFieldWithStaticNameString = (instance, b) =>
                {
                    return true;
                };

                bool errors = false;
                wasUpdated = updated;
                return HelperFunctions.processPortfolioItem(fakespweb, new ShimSPList(), "555", tblInput.Select(), "1", out errors);
            }
        }
    }

   
}

