using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.UI.Fakes;
using System.Web.Fakes;
//using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using System.Xml;
using System.Collections;
using System.Web.Script.Serialization.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using System.Collections.Specialized.Fakes;
using System.Collections.Generic;
using Microsoft.SharePoint;

namespace EPMLiveWebParts.Tests
{
    [TestClass()]
    public class GridListViewTests
    {
        [TestMethod()]
        public void GetViewsTest_When_propertbag_Is_Null()
        {
            string xml = "<View Name=\"{7591FC7D-8304-42C7-9456-09F4241AC6F8}\" Type=\"HTML\"" +
   "  DisplayName=\"TestView1\" Title=\"DefaultView\" Url=\"Lists/List_Name/File_Name.aspx\"" +
      " BaseViewID=\"1\" >" +
   "<Query>      <GroupBy Collapse=\"FALSE\">         <FieldRef Name=\"Title\" />      </GroupBy>   </Query>" +
   "<ViewFields> <FieldRef Name=\"Attachments\" /> <FieldRef Name=\"LinkTitle\" /><FieldRef Name=\"_x004e_um1\" /><FieldRef Name=\"_x006e_um2\" /><FieldRef Name=\"_x006e_um3\" /> </ViewFields>" +
   "<RowLimit Paged=\"TRUE\">100</RowLimit>" +
   "<Aggregations Value=\"On\">" +
      "<FieldRef Name=\"_x006e_um2\" Type=\"SUM\" />" +
      "<FieldRef Name=\"_x004e_um1\" Type=\"AVG\" />" +
   "</Aggregations>" +
 "</View>";
            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xml);
            PrivateObject objToTestPrivateMethod = new PrivateObject(typeof(GridListView));
            using (var context = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                var list = context.GetOrCreateList("Mainlist", Microsoft.SharePoint.SPListTemplateType.GenericList);

                ShimSPList shimList = new ShimSPList(list)
                {
                    IDGet = () =>
                    {
                        return Guid.Parse("696F0CD4-2EDB-4B75-8AD4-A64689158803");
                    },
                    ParentWebGet = () =>
                    {
                        ShimSPWeb web = new ShimSPWeb(context.Web);
                        web.PropertiesGet = () =>
                         {
                             var propertyBag = new ShimSPPropertyBag();
                             var sd = new ShimStringDictionary(propertyBag);
                             sd.ItemGetString = (key) =>
                             {
                                 return null;
                             };
                             return propertyBag;
                         };
                        return web;
                    }
                };

                ShimJavaScriptSerializer.AllInstances.SerializeObject = (instance, a) =>
                {
                    return "";
                };

                ShimHttpUtility.HtmlDecodeString = (str) =>
                {
                    return "Default View";
                };

                ShimControl.AllInstances.PageGet = (ShimTemplateInstanceAttribute) =>
                {
                    return new ShimPage()
                    {
                        RequestGet = () =>
                        {
                            return new ShimHttpRequest()
                            {
                                UrlGet = () =>
                            {
                                return new Uri("http://win-6j09gf4nbp8/sites/600Release/Lists/Project%20Center/Executive%20Summary.aspx");
                            }
                            };
                        }
                    };
                };

                objToTestPrivateMethod.SetField("list", list);
                string result = Convert.ToString(objToTestPrivateMethod.Invoke("GetViews"));

                Assert.IsTrue(result.Contains("Default View"));
                Assert.IsTrue(result.Contains("/Lists/Mainlist/AllItems.aspx"));
            }
        }
        [TestMethod()]
        public void GetViewsTest_When_propertbag_IsNot_Null()
        {
            string xml = "<View Name=\"{7591FC7D-8304-42C7-9456-09F4241AC6F8}\" Type=\"HTML\"" +
   "  DisplayName=\"TestView1\" Title=\"DefaultView\" Url=\"Lists/List_Name/File_Name.aspx\"" +
      " BaseViewID=\"1\" >" +
   "<Query>      <GroupBy Collapse=\"FALSE\">         <FieldRef Name=\"Title\" />      </GroupBy>   </Query>" +
   "<ViewFields> <FieldRef Name=\"Attachments\" /> <FieldRef Name=\"LinkTitle\" /><FieldRef Name=\"_x004e_um1\" /><FieldRef Name=\"_x006e_um2\" /><FieldRef Name=\"_x006e_um3\" /> </ViewFields>" +
   "<RowLimit Paged=\"TRUE\">100</RowLimit>" +
   "<Aggregations Value=\"On\">" +
      "<FieldRef Name=\"_x006e_um2\" Type=\"SUM\" />" +
      "<FieldRef Name=\"_x004e_um1\" Type=\"AVG\" />" +
   "</Aggregations>" +
 "</View>";
            string Id = "7591FC7D-8304-42C7-9456-09F4241AC6F8";
            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xml);
            PrivateObject objToTestPrivateMethod = new PrivateObject(typeof(GridListView));
            using (var context = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                //ShimSPList list = new ShimSPList();

                //ShimJavaScriptSerializer.AllInstances.SerializeObject = (instance, a) =>
                //{
                //    return "";
                //};
                //ShimSPView.AllInstances.TitleGet = (instance) =>
                //{
                //    return "Default View";
                //};
                //ShimHttpUtility.HtmlDecodeString = (str) =>
                //{
                //    return "Default View";
                //};
                //ShimSPList.AllInstances.ViewsGet = (ShimTemplateInstanceAttribute) =>
                //{
                //    ShimSPViewCollection vcollection = new ShimSPViewCollection();
                //    return vcollection;
                //};
                //ShimSPList.AllInstances.IDGet = (instance) =>
                //{
                //    return Guid.Parse(Id);
                //};
                ////ShimSPSite site = context.Site;
                ////ShimSPWeb web = site.OpenWeb();
                //ShimSPSite.AllInstances.Dispose = (instance) => { };
                //ShimSPWeb.AllInstances.Dispose = (instance) => { };

                //ShimSPList.AllInstances.ParentWebGet = (instance) =>
                //{
                //    return new ShimSPWeb()
                //    {
                //        PropertiesGet = () =>
                //        {
                //            ShimSPPropertyBag spbag = new ShimSPPropertyBag();
                //            //spbag.Add(String.Format("ViewPermissions{0}", list.ID.ToString()), "13#Test#http://win-6j09gf4nbp8/sites/600Release/Lists/Project%20Center/Executive%20Summary.aspx|14#testpath#http://win-6j09gf4nbp8/sites/600Release/Lists/Project%20Center/Executive%20Summary.aspx");
                //            return spbag;
                //        }
                //    };
                //};


                //};
                //ShimSPWeb.AllInstances.GroupsGet = (ShimTemplateInstanceAttribute) =>
                //{
                //    ShimSPGroupCollection groupToReturn = new ShimSPGroupCollection();

                //    return groupToReturn;

                //};
                //ShimSPWeb.AllInstances.UserIsSiteAdminGet = (ShimTemplateInstanceAttribute) =>
                //{
                //    return true;
                //};
                //ShimSPView.AllInstances.UrlGet = (ShimTemplateInstanceAttribute) =>
                //{
                //    return "http://win-6j09gf4nbp8/sites/600Release/Lists/Project%20Center/Executive%20Summary.aspx";
                //};

                //ShimSPGroup.AllInstances.IDGet = (ShimTemplateInstanceAttribute) => { return 13; };
                // ShimControl.AllInstances.PageGet = (ShimTemplateInstanceAttribute) =>
                //{
                //    return new ShimPage()
                //    {
                //        RequestGet = () =>
                //        {
                //            return new ShimHttpRequest()
                //            {
                //                UrlGet = () =>
                //                {
                //                    return new Uri("http://win-6j09gf4nbp8/sites/600Release/Lists/Project%20Center/Executive%20Summary.aspx");
                //                }
                //            };
                //        }
                //    };
                //};
                var list = context.GetOrCreateList("Mainlist", Microsoft.SharePoint.SPListTemplateType.GenericList);

                ShimSPList shimList = new ShimSPList(list)
                {
                    IDGet = () =>
                    {
                        return Guid.Parse("696F0CD4-2EDB-4B75-8AD4-A64689158803");
                    },
                    ParentWebGet = () =>
                    {
                        ShimSPWeb web = new ShimSPWeb(context.Web);
                        web.PropertiesGet = () =>
                        {
                            var propertyBag = new ShimSPPropertyBag();
                            var sd = new ShimStringDictionary(propertyBag);
                            sd.ItemGetString = (key) =>
                            {
                                return "0#YYYY#ViewURL";
                            };
                            return propertyBag;
                        };
                        return web;
                    },
                    ViewsGet = () =>
                    {
                        var views = new ShimSPViewCollection();
                        ShimSPBaseCollection coll = new ShimSPBaseCollection(views);
                        coll.GetEnumerator = () =>
                        {
                            return new TestEnumerator();
                        };
                        return views;
                    }
                };

                ShimJavaScriptSerializer.AllInstances.SerializeObject = (instance, a) =>
                {
                    return "";
                };

                ShimHttpUtility.HtmlDecodeString = (str) =>
                {
                    return "Default View";
                };

                ShimControl.AllInstances.PageGet = (ShimTemplateInstanceAttribute) =>
                {
                    return new ShimPage()
                    {
                        RequestGet = () =>
                        {
                            return new ShimHttpRequest()
                            {
                                UrlGet = () =>
                                {
                                    return new Uri("http://win-6j09gf4nbp8/sites/600Release/Lists/Project%20Center/Executive%20Summary.aspx");
                                }
                            };
                        }
                    };
                };

                ShimSPContext.CurrentGet = () =>
                {
                    return new ShimSPContext()
                    {
                        WebGet = () =>
                        {
                            return new ShimSPWeb()
                            {
                                UserIsSiteAdminGet = () =>
                                {
                                    return true;
                                },
                                GroupsGet = () =>
                                {
                                    var groups = new ShimSPGroupCollection();
                                    ShimSPBaseCollection coll = new ShimSPBaseCollection(groups);
                                    coll.GetEnumerator = () =>
                                    {
                                        return new TestGroupEnumerator();
                                    };
                                    return groups;
                                }
                            };
                        }
                    };
                };


                //ShimSPBaseCollection.AllInstances.GetEnumerator = (a) =>
                //{
                //    if (a.GetType() == typeof(ShimSPGroupCollection))
                //    {
                //        //ShimSPBaseCollection coll = new ShimSPBaseCollection(a);
                //        //coll.GetEnumerator
                //        //var lst = new ArrayList();
                //        //lst.Add(new ShimSPGroup());

                //        return new TestGroupEnumerator();

                //        //return lst.GetEnumerator();
                //    }
                //    else
                //    {
                //        return null;

                //    }
                //};

                objToTestPrivateMethod.SetField("list", list);
                string result = Convert.ToString(objToTestPrivateMethod.Invoke("GetViews"));

                Assert.IsTrue(result.Contains("ViewURL"));

            }
        }
    }
    public class TestEnumerator : IEnumerator
    {
        public SPView[] _spView = new SPView[1];
        int position = -1;
        public TestEnumerator()
        {
            _spView[0] = new ShimSPView()
            {
                TitleGet = () =>
                        {
                            return "Default View";
                        },
                UrlGet = () =>
                {
                    return "ViewURL";
                }
            };

        }

        public object Current
        {
            get
            {
                return _spView[position];
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < _spView.Length);

        }

        public void Reset()
        {

        }
    }

    public class TestGroupEnumerator : IEnumerator
    {
        public SPGroup[] _spGroup = new SPGroup[1];
        int position = -1;
        public TestGroupEnumerator()
        {
            _spGroup[0] = new ShimSPGroup();

        }

        public object Current
        {
            get
            {
                return _spGroup[position];
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < _spGroup.Length);

        }

        public void Reset()
        {

        }
    }
}
