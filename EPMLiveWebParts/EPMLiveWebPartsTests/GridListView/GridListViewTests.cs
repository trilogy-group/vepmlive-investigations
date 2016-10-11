using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPMLiveWebParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Fakes;
using System.Web.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using System.Xml;
using System.Collections.Specialized;
using System.Collections;
using System.Web.Script.Serialization.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.Utilities;
using Microsoft.QualityTools.Testing.Fakes.Shims;
using Microsoft.QualityTools.Testing.Fakes.Instances;

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
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                SPList list = new ShimSPList();
                ShimSPBaseCollection.AllInstances.GetEnumerator = (a) =>
                {
                    return new TestEnumerator(list, doc);
                };
                ShimJavaScriptSerializer.AllInstances.SerializeObject = (instance, a) =>
                {
                    return "";
                };
                ShimSPView.AllInstances.TitleGet = (instance) =>
                {
                    return "Default View";
                };
                ShimHttpUtility.HtmlDecodeString = (str) =>
                {
                    return "Default View";
                };
                ShimSPList.AllInstances.ViewsGet = (ShimTemplateInstanceAttribute) =>
                {
                    ShimSPViewCollection vcollection = new ShimSPViewCollection();
                    return vcollection;
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
                Assert.IsTrue(result.Contains("Lists/List_Name/File_Name.aspx"));
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
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                SPList list = new ShimSPList();

                ShimJavaScriptSerializer.AllInstances.SerializeObject = (instance, a) =>
                {
                    return "";
                };
                ShimSPView.AllInstances.TitleGet = (instance) =>
                {
                    return "Default View";
                };
                ShimHttpUtility.HtmlDecodeString = (str) =>
                {
                    return "Default View";
                };
                ShimSPList.AllInstances.ViewsGet = (ShimTemplateInstanceAttribute) =>
                {
                    ShimSPViewCollection vcollection = new ShimSPViewCollection();
                    return vcollection;
                };
                ShimSPList.AllInstances.IDGet = (instance) =>
                {
                    return Guid.Parse(Id);
                };
                SPSite site = new SPSite("http://test");
                SPWeb web = site.OpenWeb();
                ShimSPSite.AllInstances.Dispose = (instance) => { };
                ShimSPWeb.AllInstances.Dispose = (instance) => { };

                ShimSPList.AllInstances.ParentWebGet = (instance) =>
                {
                    return new ShimSPWeb()
                    {
                        PropertiesGet = () =>
                        {
                            SPPropertyBag spbag = web.Properties;
                            spbag.Add(String.Format("ViewPermissions{0}", list.ID.ToString()), "13#Test#http://win-6j09gf4nbp8/sites/600Release/Lists/Project%20Center/Executive%20Summary.aspx|14#testpath#http://win-6j09gf4nbp8/sites/600Release/Lists/Project%20Center/Executive%20Summary.aspx");
                            return spbag;
                        }
                    };
                };
                ShimSPBaseCollection.AllInstances.GetEnumerator = (a) =>
                {
                    if (a.GetType() == typeof(SPGroupCollection))
                    {
                        return new TestGroupEnumerator(web);

                    }
                    else
                    {
                        return new TestEnumerator(list, doc);

                    }

                };
                ShimSPWeb.AllInstances.GroupsGet = (ShimTemplateInstanceAttribute) =>
                {
                    SPGroupCollection groupToReturn = new ShimSPGroupCollection();

                    return groupToReturn;

                };
                ShimSPWeb.AllInstances.UserIsSiteAdminGet = (ShimTemplateInstanceAttribute) =>
                {
                    return true;
                };
                ShimSPView.AllInstances.UrlGet = (ShimTemplateInstanceAttribute) =>
                {
                    return "http://win-6j09gf4nbp8/sites/600Release/Lists/Project%20Center/Executive%20Summary.aspx";
                };

                ShimSPGroup.AllInstances.IDGet = (ShimTemplateInstanceAttribute) => { return 13; };
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

                Assert.IsTrue(result.Contains("Executive%20Summary"));
               
            }
        }
    }
    public class TestEnumerator : IEnumerator
    {
        public SPView[] _spView = new SPView[1];
        int position = -1;
        public TestEnumerator(SPList list, XmlDocument doc)
        {
            _spView[0] = new SPView(list, doc);
            _spView[0].Title = "Default View";

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
        public TestGroupEnumerator(SPWeb web)
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
