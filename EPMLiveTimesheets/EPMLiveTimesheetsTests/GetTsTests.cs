using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Xml;

namespace TimeSheets.Tests
{
    [TestClass()]
    public class GetTsTests
    {
        [TestMethod()]
        public void processListTest_Without_GroupFields()
        {
            commonTest(false);
        }

        [TestMethod()]
        public void processListTest_With_GroupFields()
        {
            commonTest(true);
        }

        private void commonTest(Boolean groups)
        {
            try
            {
                SortedList arrGTemp = new SortedList();
                PrivateObject objToTestPrivateMethod = new PrivateObject(typeof(getts));
                XmlDocument docXml = new XmlDocument();

                using (SPEmulators.SPEmulationContext ctx = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
                {
                    SPList list = new ShimSPList();
                    SPWeb spWeb = new ShimSPWeb();
                   
                    docXml.LoadXml("<rows></rows>");
                    objToTestPrivateMethod.SetField("docXml", docXml);
                    objToTestPrivateMethod.SetField("period", "1");
                    objToTestPrivateMethod.SetField("ndMainParent", docXml.ChildNodes[0]);
                    objToTestPrivateMethod.SetField("list", list);

                    if (groups)
                    {
                        objToTestPrivateMethod.SetField("arrGroupFields", new string[] { "FirstName", "LastName" });

                        ShimSPField.AllInstances.IdGet = (instance) =>
                        {
                            return Guid.NewGuid();
                        };

                        ShimSPList.AllInstances.FieldsGet = (instance) =>
                        {
                            ShimSPFieldCollection fcol = new ShimSPFieldCollection();
                            fcol.GetFieldByInternalNameString = (internalName) =>
                            {
                                ShimSPField field = new ShimSPField();
                                field.IdGet = () =>
                                {
                                    return Guid.NewGuid();
                                };
                                field.GetFieldValueAsTextObject = (obj) =>
                                {
                                    return internalName;
                                };
                                return field;
                            };
                            return fcol;
                        };
                    }

                    ShimSPList.AllInstances.GetItemsSPQuery = (instance, a) =>
                    {
                        SPListItemEnumerator sPListItemEnumerator = new SPListItemEnumerator();
                        return new ShimSPListItemCollection()
                        {
                            GetEnumerator = () =>
                            {
                                return sPListItemEnumerator;
                            },
                            CountGet = () =>
                            {
                                return sPListItemEnumerator.sPListItems.Length;
                            }
                        };
                    };

                    objToTestPrivateMethod.Invoke("processList", spWeb, arrGTemp);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }



    public class SPListItemEnumerator : IEnumerator
    {
        public SPListItem[] sPListItems = new SPListItem[2];
        int position = -1;
        public SPListItemEnumerator()
        {
            sPListItems[0] = new ShimSPListItem()
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
                }
            };
            sPListItems[1] = new ShimSPListItem()
            {
                ItemGetGuid = (guid) =>
                {
                    return Guid.NewGuid();
                },
                IDGet = () =>
                {
                    return 2;
                },
                TitleGet = () =>
                {
                    return "Brandon Baker";
                }
            };
        }

        public object Current
        {
            get
            {
                return sPListItems[position];
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < sPListItems.Length);

        }

        public void Reset()
        {

        }
    }
}