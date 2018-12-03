using System;
using System.Collections;
using System.Collections.Fakes;
using System.Collections.Generic;
using System.Collections.Generic.Fakes;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices.ActiveDirectory.Fakes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Xml;
using System.Xml.Fakes;
using EPMLiveWebParts;
using EPMLiveWebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests
{
    [TestClass(), ExcludeFromCodeCoverage]
    public partial class GetGridItemsTests
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
        private HttpResponse _response;
        private StringWriter _responseWriter;

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