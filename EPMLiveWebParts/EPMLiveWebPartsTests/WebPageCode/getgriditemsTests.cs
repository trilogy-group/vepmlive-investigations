using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPMLiveWebParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using System.Collections.Fakes;
using System.Collections.Generic.Fakes;
using System.DirectoryServices.ActiveDirectory.Fakes;
using Microsoft.SharePoint.Fakes;
using System.Xml;
using Microsoft.SharePoint;

using System.Web.Fakes;
using System.Web.UI.Fakes;
using Microsoft.SharePoint.Administration;
using EPMLiveWebParts.Fakes;
using System.Xml.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Shouldly;

namespace EPMLiveWebParts.Tests
{
    [TestClass()]
    public class getgriditemsTests
    {
        private const string NewGroupString = "Group1\nAtt1\nAtt2";
        private const string Group0 = "Group0\nAtt1";
        private const string SetGroupsStringsMethodName = "SetGroupsStrings";
        private const string DummyFieldName = "DummyFieldName";
        private const string DummyListId = "41201410250102103010204050102030";
        private const string DummyParentWebId = "10201201456320104521021002014563";
        private const string DummyChoices = "DummyChoices";
        private const string DummyListGuid = "47154201369784512014785203694512";
        private const string DummyShowFieldId = "45120178451203125471020140101020";
        private const string DummyWebId = "01203105040708050103578777777777";
        private const string DummyLookupValue = "LookUpValue";
        private const string DummyQuery = "Select From Where";
        private const string DummyListViewFielter = "Field > 5";
        private const string DummyVal = "DummyVal";

        private string _groups;
        private string _xmlAttributeValue;
        private SortedList _sortedList;
        private string _actualChoicesString;
        private string _actualLookupList;
        private string _actualLookupField;
        private string _actualQuery;
        private string _actualListView;

        [TestMethod()]
        public void addItemTest_WhenFieldType_FilterLookUp()
        {
            CommonTestData("FilteredLookup", SPFieldType.User, "WorkspaceUrl", true, false, true, true);
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_Number()
        {
            CommonTestData("Number", SPFieldType.Number, "Number", true, false, true, true);
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_User()
        {
            CommonTestData("Number", SPFieldType.User, "Number", true, false, true, true);
        }

        [TestMethod()]
        public void addItemTest_WhenFieldType_MultiChoice()
        {
            CommonTestData("MultiChoice", SPFieldType.MultiChoice, "MultiChoice", true, false, true, true);
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_Choice()
        {
            CommonTestData("Choice", SPFieldType.Choice, "Choice", true, false, true, true);
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_Lookup()
        {
            CommonTestData("LookupMulti", SPFieldType.Lookup, "Lookup", true, false, true, true);
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_Currency()
        {
            CommonTestData("Currency", SPFieldType.Currency, "Currency", true, false, true, true);
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_Boolean()
        {
            CommonTestData("Boolean", SPFieldType.Boolean, "Boolean", true, false, true, true);
        }


        [TestMethod()]
        public void addItemTest_WhenFieldType_Calculated_ShowPercentage_False()
        {
            CommonTestData("Calculated", SPFieldType.Calculated, "DocIcon", true, false, true, true, false);
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_Calculated()
        {
            CommonTestData("Calculated", SPFieldType.Calculated, "DocIcon", true, false, true, true, false);
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_Calculated_bCleanValues_True()
        {
            CommonTestData("Calculated", SPFieldType.Calculated, "DocIcon", true, false, true, true, false, true);
        }

        [TestMethod()]
        public void addItemTest_WhenFieldType_Text()
        {
            CommonTestData("Text", SPFieldType.Text, "Title", false, true, false, true, true, true);
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_Text_And_bCleanValues_True()
        {
            CommonTestData("Text", SPFieldType.Text, "Title", false, true, false, true, true, true);
        }

        [TestMethod()]
        public void addItemTest_WhenFieldType_Text_And_bCleanValues_false()
        {
            CommonTestData("Text", SPFieldType.Text, "Title", false, true, false, true, true, false);
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_Text_And_bCleanValues_True_WhenLinktype_view()
        {
            CommonTestData("Text", SPFieldType.Text, "Title", false, true, false, true, true, true, "view");
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_Text_And_bCleanValues_false_WhenLinktype_view()
        {
            CommonTestData("Text", SPFieldType.Text, "Title", false, true, false, true, true, false, "view");
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_Text_And_bCleanValues_True_WhenLinktype_edit()
        {
            CommonTestData("Text", SPFieldType.Text, "Title", false, true, false, true, true, true, "edit");
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_Text_And_bCleanValues_false_WhenLinktype_edit()
        {
            CommonTestData("Text", SPFieldType.Text, "Title", false, true, false, true, true, false, "edit");
        }

        [TestMethod()]
        public void addItemTest_WhenFieldType_Text_And_bCleanValues_True_WhenLinktype_workspace()
        {
            CommonTestData("Text", SPFieldType.Text, "Title", false, true, false, true, true, true, "workspace");
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_Text_And_bCleanValues_false_WhenLinktype_workspace()
        {
            CommonTestData("Text", SPFieldType.Text, "Title", false, true, false, true, true, false, "workspace");
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_Text_And_bCleanValues_True_WhenLinktype_workplan()
        {
            CommonTestData("Text", SPFieldType.Text, "Title", false, true, false, true, true, true, "workplan");
        }

        [TestMethod()]
        public void addItemTest_WhenFieldType_Text_And_bCleanValues_false_WhenLinktype_workplan()
        {
            CommonTestData("Text", SPFieldType.Text, "Title", false, true, false, true, true, false, "workplan");
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_Text_And_bCleanValues_True_WhenLinktype_planner()
        {
            CommonTestData("Text", SPFieldType.Text, "Title", false, true, false, true, true, true, "planner");
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_Text_And_bCleanValues_false_WhenLinktype_planner()
        {
            CommonTestData("Text", SPFieldType.Text, "Title", false, true, false, true, true, false, "planner");
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_Text_And_bCleanValues_True_WhenLinktype_tasks()
        {
            CommonTestData("Text", SPFieldType.Text, "Title", false, true, false, true, true, true, "tasks");
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_Text_And_bCleanValues_false_WhenLinktype_tasks()
        {
            CommonTestData("Text", SPFieldType.Text, "Title", false, true, false, true, true, false, "tasks");
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_With_testColumnName()
        {
            CommonTestData("Text", SPFieldType.Text, "testColumnName", false, true, false, true, true, true, "tasks");
        }

        [TestMethod()]
        public void addItemTest_WhenFieldType_Calculated_With_testColumnName_userpopupfalse()
        {
            CommonTestData("Text", SPFieldType.Calculated, "testColumnName", false, true, false, false, true, true, "tasks");
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_User_With_testColumnName_userpopupfalse()
        {
            CommonTestData("Text", SPFieldType.User, "testColumnName", false, true, false, false, true, true, "tasks");
        }
        [TestMethod()]
        public void addItemTest_WhenFieldType_Lookup_With_testColumnName_userpopupfalse()
        {
            CommonTestData("Text", SPFieldType.Lookup, "testColumnName", false, true, false, false, true, true, "tasks");
        }

        private static void CommonTestData(string columnname, SPFieldType fieldtype, string internalname, bool timesheet, bool usepopup, bool editmode, bool showCheckboxes, bool Showpercentage = true, bool bCleanValues = false, string Linktype = "")
        {
            string listId = "F316E11-C842-4440-9918-39A8F1C12DA9";
            string WebID = "1A8F7946-CCA1-4A24-8785-CE8E32D012BE";
            string ID = "5D592B57-C072-4B36-8809-11262120484D";
            string ItemID = "2";
            SortedList arrItems = new SortedList();
            Hashtable hshLists = new Hashtable();
            hshLists.Add("ICON", "test.png");
            arrItems.Add(WebID + "." + listId + "." + ID, new string[] { "Admin" });
            PrivateObject objToTestPrivateMethod = new PrivateObject(typeof(getgriditems));
            objToTestPrivateMethod.SetField("arrItems", arrItems);
            objToTestPrivateMethod.SetField("usewbs", "ItemID");
            objToTestPrivateMethod.SetField("docXml", new XmlDocument());
            objToTestPrivateMethod.SetField("isTimesheet", timesheet);
            objToTestPrivateMethod.SetField("showCheckboxes", showCheckboxes);
            objToTestPrivateMethod.SetField("inEditMode", editmode);
            objToTestPrivateMethod.SetField("usePopup", usepopup);
            objToTestPrivateMethod.SetField("bUseReporting", true);
            objToTestPrivateMethod.SetField("hshLists", hshLists);
            objToTestPrivateMethod.SetField("bCleanValues", bCleanValues);
            objToTestPrivateMethod.SetField("linktype", Linktype);
            objToTestPrivateMethod.SetField("usewbs", "TestColumn");
            Hashtable hshColumnSelectFilter = new Hashtable();
            hshColumnSelectFilter.Add("SiteUrl", "");
            hshColumnSelectFilter.Add("List", "");
            hshColumnSelectFilter.Add("Site", "");
            hshColumnSelectFilter.Add(internalname + "Text", "Text");
            hshColumnSelectFilter.Add("ItemID", "");
            hshColumnSelectFilter.Add("Work", "");
            hshColumnSelectFilter.Add("WorkspaceUrl", "");
            if (!hshColumnSelectFilter.ContainsKey(internalname))
                hshColumnSelectFilter.Add(internalname, "");
            Hashtable hshItemNodes = new Hashtable();
            hshItemNodes.Add("SiteUrl", "");
            hshItemNodes.Add("List", "");
            hshItemNodes.Add("Site", "");
            hshItemNodes.Add(internalname + "Text", "Text");
            hshItemNodes.Add("ItemID", "");
            hshItemNodes.Add("Work", "");
            hshItemNodes.Add("WorkspaceUrl", "");
            if (!hshItemNodes.ContainsKey(internalname))
                hshItemNodes.Add(internalname, "");
            objToTestPrivateMethod.SetField("hshColumnSelectFilter", hshItemNodes);
            ArrayList arlist = new ArrayList();
            arlist.Add("SiteUrl");
            arlist.Add("Title");
            arlist.Add("List");
            arlist.Add("Site");
            arlist.Add("SiteUrl");
            arlist.Add("ItemID");
            arlist.Add("Work");
            arlist.Add("WorkspaceUrl");
            arlist.Add("Edit");
            arlist.Add("LinkTitleNoMenu");
            arlist.Add("LinkTitle");

            objToTestPrivateMethod.SetField("aViewFields", arlist);
            DataTable dt = new DataTable();
            DataRow newRow = dt.NewRow();
            DataColumn newColumn = new DataColumn("CustomerID");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("SiteUrl");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("ItemID");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("Work");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("TestColumn");
            dt.Columns.Add(newColumn);

            newColumn = new DataColumn("_ModerationStatus");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("WebID");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("ListID");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("List");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("ID");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("siteid");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("ParentItem");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("Created");
            dt.Columns.Add(newColumn);

            newColumn = new DataColumn("CommentCount");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("TSDisableItem");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("Commenters");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("Author");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn(internalname);
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("AssignedTo");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn("CommentersRead");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn(internalname + "ID");
            dt.Columns.Add(newColumn);
            newColumn = new DataColumn(internalname + "Text");
            dt.Columns.Add(newColumn);
            if (internalname != "WorkspaceUrl")
            {
                newColumn = new DataColumn("WorkspaceUrl");
                dt.Columns.Add(newColumn);
            }
            if (internalname != "Title")
            {
                newColumn = new DataColumn("Title");
                dt.Columns.Add(newColumn);
            }
            newRow["SiteUrl"] = "";
            newRow["ItemID"] = ItemID;
            newRow["Created"] = DateTime.Now;
            newRow[internalname + "ID"] = "13,14,15,16,17";
            newRow[internalname + "Text"] = "A,B,C,D,E";
            newRow["Title"] = "First Project";
            newRow["Work"] = "";
            if (internalname != "WorkspaceUrl")
                newRow["WorkspaceUrl"] = "http://testURL";
            newRow["WebID"] = WebID;
            newRow["_ModerationStatus"] = "0";
            newRow["ListID"] = listId;
            newRow["ID"] = ID;
            newRow["siteid"] = "";
            newRow["ParentItem"] = "";
            newRow[internalname] = "First project";
            newRow["CommentCount"] = "20";
            newRow["TSDisableItem"] = "";
            newRow["Commenters"] = "";
            newRow["Author"] = "";
            newRow["AssignedTo"] = "2";
            newRow["CommentersRead"] = "";
            newRow["List"] = "ICON";
            newRow["TestColumn"] = "ICON.ICON.ICON";



            using (SPEmulators.SPEmulationContext ctx = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
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
                Shimgetgriditems.AllInstances.addMenusXmlNodeSPListString = (instance, a, b, c) =>
                {

                    XmlNode node = doc.FirstChild;
                    return node;
                };

                Shimgetgriditems.AllInstances.formatFieldStringStringDataRowBoolean = (a, b, c, d, e) => { return "Title"; };
                Shimgetgriditems.GetTaskFileSPWebStringString = (web, str, str2) => { return new ShimSPFile() { ExistsGet = () => { return true; } }; };
                ShimSPField.AllInstances.IdGet = (instance) =>
                {
                    return Guid.Parse("fdc3b2ed-5bf2-4835-a4bc-b885f3396a61");
                };
                ShimSPField.AllInstances.InternalNameGet = (instance) => { return internalname; };
                ShimSPField.AllInstances.TypeGet = (instance) =>
                {
                    return fieldtype;
                };
                ShimSPField.AllInstances.TypeAsStringGet = (instance) =>
                {
                    return columnname;
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
                    fcol.GetFieldByInternalNameString = (a) =>
                    {


                        if (fieldtype == SPFieldType.Number)
                        {
                            ShimSPFieldNumber field = new ShimSPFieldNumber();
                            SPField sfield = (SPField)field;

                            field.ShowAsPercentageGet = () =>
                            {
                                return Showpercentage;
                            };

                            return field;
                        }
                        else if (fieldtype == SPFieldType.Calculated)
                        {
                            ShimSPFieldCalculated field = new ShimSPFieldCalculated();
                            SPField sfield = (SPField)field;

                            field.ShowAsPercentageGet = () =>
                            {
                                return Showpercentage;
                            };

                            return field;
                        }
                        {
                            ShimSPField field = new ShimSPField();
                            field.IdGet = () =>
                            {
                                return Guid.Parse("fdc3b2ed-5bf2-4835-a4bc-b885f3396a61");
                            };
                            field.InternalNameGet = () => { return internalname; };
                            field.TypeGet = () =>
                            {
                                return fieldtype;
                            };
                            field.TypeAsStringGet = () =>
                            {

                                return columnname;
                            };
                            field.SchemaXmlGet = () =>
                            {
                                return "<CHOICES><CHOICE Value = \"Text\" ></CHOICE> <CHOICE Value = \"Text\" ></CHOICE></CHOICES>";

                            };
                            field.GetFieldValueString = (obj) =>
                            {
                                return "";
                            };
                            return field;
                        }
                    };
                    return fcol;
                };


                SPFieldUserValueCollection uvc = new ShimSPFieldUserValueCollection();


                ShimHttpUtility.HtmlEncodeString = (a) => { return a; };
                ShimSPFieldCollection.AllInstances.ContainsFieldWithStaticNameString = (instance, b) =>
                {
                    return true;
                };
                ShimXmlNode.AllInstances.AppendChildXmlNode = (a, b) =>
                {
                    XmlNode node = doc.FirstChild;
                    return node;
                };
                SPList list = new ShimSPList();


                //ShimW


                ShimSPList.AllInstances.ParentWebGet = (instance) =>
                {
                    return new ShimSPWeb()
                    {
                        IDGet = () =>
                        {
                            return Guid.Parse(WebID);
                        }
                      ,
                        CurrentUserGet = () =>
                        {
                            return new ShimSPUser()
                            {
                                IDGet = () =>
                                {
                                    return 0;
                                }
                            };
                        },
                        ServerRelativeUrlGet = () => { return ""; },
                        LanguageGet = () => { return 2; }


                    };

                };

                ShimSPList.AllInstances.EnableModerationGet = (instance) =>
                {
                    return true;
                };
                int i = -1;
                ShimSPListItem.AllInstances.IDGet = (instance) =>
                {
                    return 12;
                };
                ShimSPList.AllInstances.IDGet = (instance) =>
                {
                    return Guid.Parse(ID);
                };


                ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (instance, b) =>
                {
                    return true;
                };
                ShimSPList.AllInstances.GetItemByIdInt32 = (instance, a) =>
                {

                    return new ShimSPListItem()
                    {

                        ItemGetGuid = (guid) =>
                        {
                            i = ++i;
                            return i;

                        }
                    };
                };


                SPFieldUserValueCollection collection = new SPFieldUserValueCollection(list.ParentWeb, "");
                SPFieldUserValue fielduservalue = new SPFieldUserValue();
                fielduservalue.LookupId = 0;
                collection.Add(fielduservalue);

                ShimSPFieldUserValueCollection.ConstructorSPWebString = (instance, web, s) =>
                {
                    ShimSPFieldUserValueCollection collection2 = new ShimSPFieldUserValueCollection();
                    SPFieldUserValue fielduservalue2 = new SPFieldUserValue();
                    fielduservalue.LookupId = 0;
                    collection.Add(fielduservalue);

                };
                objToTestPrivateMethod.SetField("list", list);

                objToTestPrivateMethod.Invoke("addItem", newRow);
                Assert.IsNotNull(newRow);
                Assert.AreEqual(newRow["WebID"], WebID.ToString());
                Assert.AreEqual(newRow["ListID"], listId.ToString());
                Assert.AreEqual(newRow["ID"], ID.ToString());
            }
        }

        [TestMethod()]
        public void formatFieldTest()
        {
            PrivateObject objToTestPrivateMethod = new PrivateObject(typeof(getgriditems));
            using (SPEmulators.SPEmulationContext ctx = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                SPList list = new ShimSPList();
                SPFieldType fieldtype = SPFieldType.User;

                string val = "Test";
                string fieldname = "ProjectManagers";
                DataTable dt = new DataTable();
                dt.Columns.Add("ProjectManagersID");
                dt.Columns.Add("SiteUrl");
                DataRow dr = dt.NewRow();
                dr["ProjectManagersID"] = "40,452";
                dr["SiteUrl"] = "TestUrl";
                bool group = true;
                ShimSPField spfield = new ShimSPField()
                {
                    IdGet = () =>
                    {
                        return Guid.Parse("fdc3b2ed-5bf2-4835-a4bc-b885f3396a61");
                    },
                    InternalNameGet = () => { return fieldname; },
                    TypeGet = () =>
                    {
                        return fieldtype;
                    },
                    TypeAsStringGet = () =>
                    {

                        return fieldname;
                    },
                    SchemaXmlGet = () =>
                    {
                        return "<CHOICES><CHOICE Value = \"Text\" ></CHOICE> <CHOICE Value = \"Text\" ></CHOICE></CHOICES>";

                    },
                    GetFieldValueString = (obj) =>
                    {
                        SPFieldUserValueCollection collection = new SPFieldUserValueCollection(list.ParentWeb, "");
                        SPFieldUserValue fielduservalue = new SPFieldUserValue();
                        fielduservalue.LookupId = 0;
                        collection.Add(fielduservalue);
                        return collection;
                    },
                    GetFieldValueAsTextObject = (obj) => { return val; }
                };
                list = new ShimSPList()
                {
                    ParentWebGet = () =>
                    {

                        return new ShimSPWeb();
                    },
                    FieldsGet = () =>
                    {
                        ShimSPFieldCollection fcol = new ShimSPFieldCollection();
                        fcol.ItemGetGuid = (fid) => { return spfield; };
                        
                        fcol.GetFieldByInternalNameString = (a) =>
                        {


                            if (fieldtype == SPFieldType.Number)
                            {
                                ShimSPFieldNumber field = new ShimSPFieldNumber();
                                SPField sfield = (SPField)field;

                                field.ShowAsPercentageGet = () =>
                                {
                                    return false;
                                };

                                return field;
                            }
                            else if (fieldtype == SPFieldType.Calculated)
                            {
                                ShimSPFieldCalculated field = new ShimSPFieldCalculated();
                                SPField sfield = (SPField)field;

                                field.ShowAsPercentageGet = () =>
                                {
                                    return false;
                                };

                                return field;
                            }
                            {
                                ShimSPField field = new ShimSPField();
                                field.IdGet = () =>
                                {
                                    return Guid.Parse("fdc3b2ed-5bf2-4835-a4bc-b885f3396a61");
                                };
                                field.InternalNameGet = () => { return fieldname; };
                                field.TypeGet = () =>
                                {
                                    return fieldtype;
                                };
                                field.TypeAsStringGet = () =>
                                {

                                    return fieldname;
                                };
                                field.SchemaXmlGet = () =>
                                {
                                    return "<CHOICES><CHOICE Value = \"Text\" ></CHOICE> <CHOICE Value = \"Text\" ></CHOICE></CHOICES>";

                                };
                                field.GetFieldValueString = (obj) =>
                                {
                                    return "";
                                };
                                return field;
                            }
                        };
                        return fcol;
                    }
                };


                ShimSPContext.CurrentGet = () =>
                {
                    return new ShimSPContext()
                    {
                        WebGet = () =>
                           {
                               return new ShimSPWeb()
                               {
                                   AllUsersGet = () =>
                                     {
                                         return new ShimSPUserCollection()
                                         {
                                             GetByIDInt32 = (id) =>
                                             {
                                                 return new ShimSPUser
                                                 {
                                                     NameGet = () =>
                                                     {
                                                         return "Test User";
                                                     }
                                                 };
                                             }
                                         };
                                     }
                               };
                           }
                    };
                };
                Shimgetgriditems.AllInstances.getRealFieldSPField = (instance, field) => { return spfield; };
                objToTestPrivateMethod.SetField("list", list);


                //Arrange when FieldType User and bUseReporting true
                fieldtype = SPFieldType.User;
                objToTestPrivateMethod.SetField("bUseReporting", true);
                //Act
                var result = objToTestPrivateMethod.Invoke("formatField", val, fieldname, dr, group);
                //Assert
                Assert.AreEqual(result, "Test User\nTest User");


                //Arrange when FieldType User and bUseReporting false
                fieldtype = SPFieldType.User;
                objToTestPrivateMethod.SetField("bUseReporting", false);
                //Act
                result = objToTestPrivateMethod.Invoke("formatField", val, fieldname, dr, group);
                //Assert
                Assert.AreEqual(result, "<a href=\"TestUrl/_layouts/userdisp.aspx?ID=0\"></a>");

                //Arrange when FieldType DateTime
                fieldtype = SPFieldType.DateTime;
                val = DateTime.Now.ToString();
                //Act
                result = objToTestPrivateMethod.Invoke("formatField", val, fieldname, dr, group);
                //Assert
                Assert.AreEqual(result, val);


                //Arrange when FieldType Currency
                fieldtype = SPFieldType.Currency;
                val = "Test";
                //Act
                result = objToTestPrivateMethod.Invoke("formatField", val, fieldname, dr, group);
                //Assert
                Assert.AreEqual(result, val);


                //Arrange when FieldType Boolean and Value True
                fieldtype = SPFieldType.Boolean;
                val = "True";
                //Act
                result = objToTestPrivateMethod.Invoke("formatField", val, fieldname, dr, group);
                //Assert
                Assert.AreEqual(result.ToString().ToLower(), "yes");


                //Arrange when FieldType Boolean and Value False
                fieldtype = SPFieldType.Boolean;
                val = "False";
                //Act
                result = objToTestPrivateMethod.Invoke("formatField", val, fieldname, dr, group);
                //Assert
                Assert.AreEqual(result.ToString().ToLower(), "no");

                //Arrange when FieldType Lookup
                fieldtype = SPFieldType.Lookup;
                val = "False";
                //Act
                result = objToTestPrivateMethod.Invoke("formatField", val, fieldname, dr, group);
                //Assert
                Assert.AreEqual(result, "0");

                
            }

        }

        [TestMethod]
        public void SetGroupsStrings_SPFieldTypeUser_Success()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                object[] parameters;
                var privateObject = ArrangeSetGroupsStrings(SPFieldType.User, out parameters);

                // Act
                privateObject.Invoke(SetGroupsStringsMethodName, parameters);

                // Assert
                this.ShouldSatisfyAllConditions(
                    () => ((string[])parameters[3])[0].ShouldBe("Group0\nAtt1\nGroup1"),
                    () => ((string[])parameters[3])[1].ShouldBe("Group0\nAtt1\nAtt1"),
                    () => ((string[])parameters[3])[2].ShouldBe("Group0\nAtt1\nAtt2"));
            }
        }

        [TestMethod]
        public void SetGroupsStrings_SPFieldTypeMultiChoice_Success()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                object[] parameters;
                var privateObject = ArrangeSetGroupsStrings(SPFieldType.MultiChoice, out parameters);

                // Act
                privateObject.Invoke(SetGroupsStringsMethodName, parameters);

                // Assert
                this.ShouldSatisfyAllConditions(
                    () => ((string[])parameters[3])[0].ShouldBe("Group0\nAtt1\nGroup1"),
                    () => ((string[])parameters[3])[1].ShouldBe("Group0\nAtt1\nAtt1"),
                    () => ((string[])parameters[3])[2].ShouldBe("Group0\nAtt1\nAtt2"));
            }
        }

        [TestMethod]
        public void SetGroupsStrings_SPFieldTypeOther_Success()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                object[] parameters;
                var privateObject = ArrangeSetGroupsStrings(SPFieldType.Calculated, out parameters);

                // Act
                privateObject.Invoke(SetGroupsStringsMethodName, parameters);

                // Assert
                this.ShouldSatisfyAllConditions(() => ((string[])parameters[3])[0].ShouldBe(string.Format("{0}\n{1}", Group0, NewGroupString)));
            }
        }

        [TestMethod]
        public void SetGroupsStrings_SPFieldTypeLookup_Success()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                object[] parameters;
                var privateObject = ArrangeSetGroupsStrings(SPFieldType.Lookup, out parameters);

                // Act
                privateObject.Invoke(SetGroupsStringsMethodName, parameters);

                // Assert
                this.ShouldSatisfyAllConditions(
                    () => ((string[])parameters[3])[0].ShouldBe("Group0\nAtt1\nGroup1"),
                    () => ((string[])parameters[3])[1].ShouldBe("Group0\nAtt1\nAtt1"),
                    () => ((string[])parameters[3])[2].ShouldBe("Group0\nAtt1\nAtt2"));
            }
        }

        [TestMethod]
        public void HandleFilteredLookupCase_ValidTypeMultiValueEqualWebGuid_PopulatesDisplayValue()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                object[] parameters;
                var privateObject = ArrangeHandleFilteredLookupCase(true, true, true, true, out parameters);

                // Act
                privateObject.Invoke("HandleFilteredLookupCase", parameters);

                // Assert
                this.ShouldSatisfyAllConditions(
                    () => _actualChoicesString.ShouldBe(DummyChoices),
                    () => ((string)parameters[4]).ShouldBe($"{DummyLookupValue}\t{DummyChoices}"),
                    () => _actualQuery.ShouldBe(DummyQuery),
                    () => _actualListView.ShouldBe(DummyListViewFielter),
                    () => _actualLookupList.ShouldBe(new Guid(DummyListGuid).ToString()),
                    () => _actualLookupField.ShouldBe(new Guid(DummyShowFieldId).ToString()));
            }
        }

        [TestMethod]
        public void HandleFilteredLookupCase_ValidTypeMultiValueDifferentWebGuid_PopulatesDisplayValue()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                object[] parameters;
                var privateObject = ArrangeHandleFilteredLookupCase(true, true, true, false, out parameters);

                // Act
                privateObject.Invoke("HandleFilteredLookupCase", parameters);

                // Assert
                this.ShouldSatisfyAllConditions(
                    () => _actualChoicesString.ShouldBe(DummyChoices),
                    () => ((string)parameters[4]).ShouldBe($"{DummyLookupValue}\t{DummyChoices}"),
                    () => _actualQuery.ShouldBe(DummyQuery),
                    () => _actualListView.ShouldBe(DummyListViewFielter),
                    () => _actualLookupList.ShouldBe(new Guid(DummyListGuid).ToString()),
                    () => _actualLookupField.ShouldBe(new Guid(DummyShowFieldId).ToString()));
            }
        }

        [TestMethod]
        public void HandleFilteredLookupCase_ValidTypeSingleValueEqualWebGuid_PopulatesDisplayValue()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                object[] parameters;
                var privateObject = ArrangeHandleFilteredLookupCase(true, false, true, true, out parameters);

                // Act
                privateObject.Invoke("HandleFilteredLookupCase", parameters);

                // Assert
                this.ShouldSatisfyAllConditions(
                    () => _actualChoicesString.ShouldBe(DummyChoices),
                    () => ((string)parameters[4]).ShouldBe($"{DummyVal}\t{DummyChoices}"),
                    () => _actualQuery.ShouldBe(DummyQuery),
                    () => _actualListView.ShouldBe(DummyListViewFielter),
                    () => _actualLookupList.ShouldBe(new Guid(DummyListGuid).ToString()),
                    () => _actualLookupField.ShouldBe(new Guid(DummyShowFieldId).ToString()));
            }
        }

        [TestMethod]
        public void HandleFilteredLookupCase_ValidTypeSingleValueDifferentWebGuid_PopulatesDisplayValue()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                object[] parameters;
                var privateObject = ArrangeHandleFilteredLookupCase(true, false, true, false, out parameters);

                // Act
                privateObject.Invoke("HandleFilteredLookupCase", parameters);

                // Assert
                this.ShouldSatisfyAllConditions(
                    () => _actualChoicesString.ShouldBe(DummyChoices),
                    () => ((string)parameters[4]).ShouldBe($"{DummyVal}\t{DummyChoices}"),
                    () => _actualQuery.ShouldBe(DummyQuery),
                    () => _actualListView.ShouldBe(DummyListViewFielter),
                    () => _actualLookupList.ShouldBe(new Guid(DummyListGuid).ToString()),
                    () => _actualLookupField.ShouldBe(new Guid(DummyShowFieldId).ToString()));
            }
        }

        private PrivateObject ArrangeSetGroupsStrings(SPFieldType spFieldType, out object[] parameters)
        {
            var privateObject = new PrivateObject(new getgriditems());
            _sortedList = new SortedList();
            ShimSPField.AllInstances.TypeGet = _ => spFieldType;
            string[] groups =
            {
                Group0
            };
            parameters = new object[]
            {
                _sortedList,
                (SPField)new ShimSPField(),
                NewGroupString,
                groups
            };
            return privateObject;
        }

        private PrivateObject ArrangeHandleFilteredLookupCase(
            bool shouldTypeBeValid,
            bool shouldSupportMultipleValues,
            bool shouldFilterBeRecursive,
            bool shouldLookupWebBeEqual,
            out object[] parameters)
        {
            var privateObject = new PrivateObject(new getgriditems());
            privateObject.SetField("inEditMode", true);
            ShimSPField.AllInstances.InternalNameGet = _ => DummyFieldName;
            ShimSPField.AllInstances.TypeAsStringGet = _ => shouldTypeBeValid
                ? "FilteredLookup"
                : string.Empty;

            var shimXmlDocument = new ShimXmlDocument();
            var fieldXmlDocument = new ShimXmlDocument();
            privateObject.SetField("docXml", (XmlDocument)fieldXmlDocument);
            fieldXmlDocument.CreateAttributeString = str => new ShimXmlAttribute();
            ShimXmlAttribute.AllInstances.ValueSetString = (_, str) => _xmlAttributeValue = str;
            ShimXmlNode.AllInstances.SelectSingleNodeString = (node, str) =>
            {
                switch (str)
                {
                    case "Property[Name='QueryFilterAsString']":
                        return new ShimXmlNode(node)
                        {
                            InnerTextGet = () => DummyQuery
                        };
                    case "Property[Name='ListViewFilter']":
                        return new ShimXmlNode(node)
                        {
                                InnerTextGet = () => DummyListViewFielter
                        };
                    case "Property[Name='SupportsMultipleValues']":
                        return new ShimXmlNode(node)
                        {
                            InnerTextGet = () => shouldSupportMultipleValues
                                    ? bool.TrueString
                                    : bool.FalseString
                        };
                    case "Property[Name='IsFilterRecursive']":
                        return new ShimXmlNode(node)
                        {
                                InnerTextGet = () => shouldFilterBeRecursive
                                    ? bool.TrueString
                                    : bool.FalseString
                        };
                    default:
                        return new ShimXmlNode(shimXmlDocument);
                }
            };

            ShimXmlNode.AllInstances.ChildNodesGet = _1 => new StubXmlNodeList
            {
                ItemInt32 = _2 => new ShimXmlNode(shimXmlDocument)
            };
            ShimXmlNode.AllInstances.AttributesGet = _ => new ShimXmlAttributeCollection();
            ShimXmlAttributeCollection.AllInstances.ItemOfGetString = (_1, str) =>
            {
                switch (str)
                {
                    case "List":
                        return new ShimXmlAttribute
                        {
                            ValueGet = () => DummyListGuid
                        };
                    case "ShowField":
                        return new ShimXmlAttribute
                        {
                            ValueGet = () => DummyShowFieldId
                        };
                    case "WebId":
                        return new ShimXmlAttribute
                        {
                            ValueGet = () => DummyWebId
                        };
                    default:
                        return null;
                }
            };

            ShimSPFieldLookupValueCollection.ConstructorString = (collection, _2) =>
            {
                new ShimList<SPFieldLookupValue>(new ShimSPFieldLookupValueCollection(collection))
                {
                    GetEnumerator = () =>
                    {
                        return new List<SPFieldLookupValue>()
                        {
                            new ShimSPFieldLookupValue
                            {
                                ToString = () => DummyLookupValue
                            }
                        }.GetEnumerator();
                    }
                };
            };

            var paramXmlNode = new ShimXmlNode(shimXmlDocument)
            {
                AttributesGet = () => new ShimXmlAttributeCollection
                {
                    AppendXmlAttribute = attribute => attribute
                }
            };
            parameters = new object[]
            {
                (SPField)new ShimSPField(),
                (XmlDocument)shimXmlDocument,
                DummyVal,
                (XmlNode)paramXmlNode,
                string.Empty
            };

            _actualChoicesString = string.Empty;
            var shimHashtable = new ShimHashtable();
            privateObject.SetField("hshComboCells", (Hashtable)shimHashtable);
            shimHashtable.ItemSetObjectObject = (_, obj) => _actualChoicesString = obj.ToString();
            shimHashtable.ItemGetObject = _ => _actualChoicesString;

            privateObject.SetField("list", (SPList)new ShimSPList());

            ShimSPList.AllInstances.IDGet = _ => new Guid(DummyListId);
            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.IDGet = _ => !shouldLookupWebBeEqual ? new Guid(DummyParentWebId) : new Guid(DummyWebId);
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.OpenWebGuid = (_1, _2) => new ShimSPWeb();
            Shimgetgriditems.AllInstances.getLookupListSPWebGuidGuidStringString = (_1, _2, lookupList, lookupField, query, listView) =>
            {
                _actualLookupList = lookupList.ToString();
                _actualLookupField = lookupField.ToString();
                _actualQuery = query;
                _actualListView = listView;
                return DummyChoices;
            };

            return privateObject;
        }
    }
}