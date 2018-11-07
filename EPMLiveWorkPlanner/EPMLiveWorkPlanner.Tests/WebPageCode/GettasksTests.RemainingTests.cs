using System;
using System.Collections;
using System.Xml;
using EPMLiveCore.Fakes;
using EPMLiveWorkPlanner.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWorkPlanner.Tests.WebPageCode
{
    public partial class GettasksTests
    {
        private const string GetLookupListMethod = "getLookupList";
        private const string WebField = "web";
        private const string GetSingleLookupMethod = "getSingleLookup";
        private const string GetSingleUserMethod = "getSingleUser";
        private const string PeopleAndGroupsValue = "PeopleAndGroups";
        private const string GetMultiUserMethod = "getMultiUser";
        private const string GroupName = "GroupName";
        private const string WebUserName = "WebUserName";
        private const string UserName = "UserName";
        private const string GetRealFieldMethod = "getRealField";
        private const string ViewField = "view";
        private const string LstTaskCenterField = "lstTaskCenter";
        private const string UseResourcePoolField = "useResourcePool";
        private const string ResourcePoolUrlField = "sResourcePoolUrl";
        private const string ReadOnlyField1 = "ReadOnlyField1";
        private const string ReadOnlyField2 = "ReadOnlyField2";
        private const string ReadOnlyField3 = "ReadOnlyField3";
        private const string CalculatedField1 = "CalculatedField1";
        private const string CalculatedField2 = "CalculatedField2";
        private const string CalculatedField3 = "CalculatedField3";
        private const string NumberField = "NumberField";
        private const string PercentField = "PercentField";
        private const string LookupField = "LookupField";
        private const string LookupMulti = "LookupMulti";
        private const string MultiChoiceField = "MultiChoiceField";
        private const string ChoiceField = "ChoiceField";
        private const string UserField = "UserField";
        private const string UserMulti = "UserMulti";
        private const string DateTimeField = "DateTimeField";
        private const string BooleanField = "BooleanField";
        private const string CurrencyField = "CurrencyField";
        private const string NoteField = "NoteField";
        private const string TaskOrderField = "taskorder";
        private const string ModerationStatusField = "_ModerationStatus";
        private const string WBSField = "WBS";
        private const string OutlineNumberField = "OutlineNumber";
        private const string PredecessorsField = "Predecessors";
        private const string TimesheetHoursField = "TimesheetHours";
        private const string TitleField = "Title";
        private const string ResourceNamesField = "ResourceNames";
        private const string TextField = "TextField";
        private const string AddHeaderMethod = "addHeader";
        private const string LstProjectCenterField = "lstProjectCenter";
        private const string SlResourcesField = "slResources";
        private const string StartDateField = "StartDate";
        private const string DueDateField = "DueDate";
        private const string GetCellDataMethod = "getCellData";
        private const string GetWBSMethod = "getWBS";
        private const string DataField = "data";
        private const string ResourceListField = "sResourceList";
        private const string WpFields = "wpFields";

        [TestMethod]
        public void GetLookupList_OnValidCall_ConfirmResult()
        {
            // Arrange
            var guid = Guid.NewGuid().ToString();

            // Act
            var result = _privateObj.Invoke(GetLookupListMethod, _web.Instance, guid, DummyString);

            // Assert
            result.ShouldBe($"1;#{DummyString}");
        }

        [TestMethod]
        public void GetSingleLookup_OnValidCall_ConfirmResult()
        {
            // Arrange
            var guid = Guid.NewGuid().ToString();
            _privateObj.SetField(WebField, _web.Instance);

            // Act
            var result = _privateObj.Invoke(GetSingleLookupMethod,  guid, DummyString);

            // Assert
            result.ShouldBe($"\r\n<option value=\"1\">{DummyString}</option>");
        }

        [TestMethod]
        public void GetSingleUser_OnValidCall_ConfirmResult()
        {
            // Arrange
            _privateObj.SetField(WebField, _web.Instance);
            SetupUsersAndGroups();

            // Act
            var result = _privateObj.Invoke(GetSingleUserMethod, PeopleAndGroupsValue);

            // Assert
            result.ShouldBe($"\r\n<option value=\"1\">{GroupName}</option>\r\n<option value=\"1\">{UserName}</option>\r\n<option value=\"1\">{WebUserName}</option>");
        }

        [TestMethod]
        public void GetMultiUser_OnValidCall_ConfirmResult()
        {
            // Arrange
            SetupUsersAndGroups();

            // Act
            var result = _privateObj.Invoke(GetMultiUserMethod, PeopleAndGroupsValue, _web.Instance);

            // Assert
            result.ShouldBe($"1;#{GroupName}\n;#{UserName}\n;#{WebUserName}");
        }

        private static void SetupUsersAndGroups()
        {
            ShimSPWeb.AllInstances.GroupsGet = _ => new ShimSPGroupCollection().Bind(new SPGroup[]
                        {
                new ShimSPGroup
                {
                    NameGet = () => GroupName,
                    IDGet = () => DummyInt
                }
                        });
            ShimSPWeb.AllInstances.UsersGet = _ => new ShimSPUserCollection().Bind(new SPUser[]
            {
                new ShimSPUser
                {
                    NameGet = () => WebUserName,
                    IDGet = () => DummyInt
                }
            });
            ShimSPGroup.AllInstances.CanCurrentUserViewMembershipGet = _ => true;
            ShimSPGroup.AllInstances.UsersGet = _ => new ShimSPUserCollection().Bind(new SPUser[]
            {
                new ShimSPUser
                {
                    NameGet = () => UserName,
                    IDGet = () => DummyInt
                }
            });
        }

        [TestMethod]
        public void GetRealField_OnValidCall_ConfirmResult()
        {
            // Arrange
            var expectedField = new ShimSPField().Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Computed;
            ShimSPField.AllInstances.SchemaXmlGet = _ => $"<xml DisplayNameSrcField='{DummyString}'/>";
            ShimSPField.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => expectedField;

            // Act
            var result = _privateObj.Invoke(GetRealFieldMethod, new ShimSPField().Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeSameAs(expectedField));
        }

        [TestMethod]
        public void AddHeader_OnValidCall_ConfirmResult()
        {
            // Arrange
            var document = new XmlDocument();
            document.LoadXml("<xml/>");
            _privateObj.SetField(ViewField, new ShimSPView().Instance);
            _privateObj.SetField(WebField, _web.Instance);
            _privateObj.SetField(LstTaskCenterField, new ShimSPList().Instance);
            _privateObj.SetField(UseResourcePoolField, true);
            _privateObj.SetField(ResourcePoolUrlField, DummyString);
            Shimgettasks.AllInstances.addHeaderXmlDocument = null;
            Shimgettasks.AllInstances.getSingleLookupStringString = (_, _1, _2) => DummyString;
            Shimgettasks.AllInstances.getLookupListSPWebStringString = (_, _1, _2, _3) => DummyString;
            Shimgettasks.AllInstances.getMultiUserStringSPWeb = (_, _1, _2) => DummyString;
            Shimgettasks.AllInstances.getRealFieldSPField = (_, field) => new ShimSPField
            {
                InternalNameGet = () => field.InternalName,
                ReadOnlyFieldGet = () => field.InternalName == ReadOnlyField1 || field.InternalName == ReadOnlyField2 || field.InternalName == ReadOnlyField3,
                TypeGet = () =>
                {
                    switch(field.InternalName)
                    {
                        case ReadOnlyField1:
                        case CalculatedField1:
                        case CalculatedField2:
                        case CalculatedField3:
                            return SPFieldType.Calculated;
                        case ReadOnlyField2:
                        case NumberField:
                        case PercentField:
                            return SPFieldType.Number;
                        case LookupField:
                        case LookupMulti:
                            return SPFieldType.Lookup;
                        case MultiChoiceField:
                            return SPFieldType.MultiChoice;
                        case ChoiceField:
                            return SPFieldType.Choice;
                        case UserField:
                        case UserMulti:
                            return SPFieldType.User;
                        case DateTimeField:
                            return SPFieldType.DateTime;
                        case BooleanField:
                            return SPFieldType.Boolean;
                        case CurrencyField:
                            return SPFieldType.Currency;
                        case NoteField:
                            return SPFieldType.Note;
                        default:
                            return SPFieldType.Text;
                    }
                },
                SchemaXmlGet = () => {
                    switch (field.InternalName)
                    {
                        case ReadOnlyField2:
                        case CalculatedField2:
                            return "<xml ResultType='Number'/>";
                        case PercentField:
                            return $"<xml ResultType='Number' Percentage=\"TRUE\" Decimals='{DummyInt}'/>";
                        default:
                            return $@"<xml ResultType='Text' Mult=""TRUE"" List='{DummyString}' ShowField='{DummyString}' UserSelectionMode='{DummyString}' Decimals='{DummyInt}'>
                                          <CHOICES>
                                             <CHOICE>{DummyString}</CHOICE>
                                          </CHOICES>
                                      </xml>";
                    }
                },
                DescriptionGet = () =>
                {
                    switch (field.InternalName)
                    {
                        case CalculatedField2:
                        case CalculatedField3:
                            return DummyString;
                        default:
                            return "Indicator";
                    }
                },
                TypeAsStringGet = () => field.InternalName,
                TitleGet = () => field.InternalName
            };
            ShimSPView.AllInstances.ViewFieldsGet = _ => new ShimSPViewFieldCollection().Bind(new string[]
            {
                TaskOrderField,
                ModerationStatusField,
                WBSField,
                OutlineNumberField,
                PredecessorsField,
                TimesheetHoursField,
                TitleField,
                ReadOnlyField1,
                ReadOnlyField2,
                ReadOnlyField3,
                ResourceNamesField,
                LookupField,
                LookupMulti,
                MultiChoiceField,
                ChoiceField,
                UserField,
                UserMulti,
                DateTimeField,
                BooleanField,
                CurrencyField,
                PercentField,
                NumberField,
                CalculatedField1,
                CalculatedField2,
                CalculatedField3,
                NoteField,
                TextField
            });
            ShimSPWeb.AllInstances.LocaleGet = _ => new System.Globalization.CultureInfo(1033);
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPList.AllInstances.ItemsGet = _ => new ShimSPListItemCollection().Bind(new SPListItem[]
            {
                new ShimSPListItem()
            });
            ShimSPListItem.AllInstances.TitleGet = _ => DummyString;
            ShimSPListItem.AllInstances.IDGet = _ => DummyInt;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, name) => new ShimSPField
            {
                InternalNameGet = () => name
            };
            ShimSPSite.ConstructorString = (_, __) => new ShimSPSite();
            ShimSPSite.AllInstances.OpenWeb = _ => _web;

            // Act
            var result = (XmlDocument)_privateObj.Invoke(AddHeaderMethod, document);

            // Assert
            var outerXml = result.OuterXml.ToString();
            this.ShouldSatisfyAllConditions(
                () => outerXml.ShouldContain("<head>"),
                () => outerXml.ShouldContain("<afterInit>"),
                () => outerXml.ShouldContain(TaskOrderField),
                () => outerXml.ShouldContain(ModerationStatusField),
                () => outerXml.ShouldContain(WBSField),
                () => outerXml.ShouldContain(OutlineNumberField),
                () => outerXml.ShouldContain(PredecessorsField),
                () => outerXml.ShouldContain(TimesheetHoursField),
                () => outerXml.ShouldContain(TitleField),
                () => outerXml.ShouldContain(ReadOnlyField1),
                () => outerXml.ShouldContain(ReadOnlyField2),
                () => outerXml.ShouldContain(ReadOnlyField3),
                () => outerXml.ShouldContain(ResourceNamesField),
                () => outerXml.ShouldContain(LookupField),
                () => outerXml.ShouldContain(LookupMulti),
                () => outerXml.ShouldContain(MultiChoiceField),
                () => outerXml.ShouldContain(ChoiceField),
                () => outerXml.ShouldContain(UserField),
                () => outerXml.ShouldContain(UserMulti),
                () => outerXml.ShouldContain(DateTimeField),
                () => outerXml.ShouldContain(BooleanField),
                () => outerXml.ShouldContain(CurrencyField),
                () => outerXml.ShouldContain(PercentField),
                () => outerXml.ShouldContain(NumberField),
                () => outerXml.ShouldContain(CalculatedField1),
                () => outerXml.ShouldContain(CalculatedField2),
                () => outerXml.ShouldContain(CalculatedField3),
                () => outerXml.ShouldContain(NoteField),
                () => outerXml.ShouldContain(TextField));
        }

        [TestMethod]
        public void GetCellData_OnValidCall_ConfirmResult()
        {
            // Arrange
            var listGuid = Guid.NewGuid();
            var slResources = new SortedList();
            slResources.Add(DummyString, DummyString);
            _privateObj.SetField(ViewField, new ShimSPView().Instance);
            _privateObj.SetField(LstProjectCenterField, new ShimSPList().Instance);
            _privateObj.SetField(UseResourcePoolField, true);
            _privateObj.SetField(SlResourcesField, slResources);
            Shimgettasks.AllInstances.getCellDataSPListItem = null;
            ShimSPView.AllInstances.ViewFieldsGet = _ => new ShimSPViewFieldCollection().Bind(new string[] 
            {
                StartDateField,
                DueDateField,
                ModerationStatusField,
                ModerationStatusField,
                ModerationStatusField,
                ResourceNamesField,
                UserField,
                DateTimeField,
                PercentField,
                NumberField,
                CalculatedField1,
                CalculatedField2,
                MultiChoiceField,
                LookupField,
                LookupMulti,
                BooleanField,
                CurrencyField,
                TitleField
            });
            ShimSPList.AllInstances.IDGet = _ => listGuid;
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPListItem.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPListItem.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            var count = 0;
            ShimSPListItem.AllInstances.ItemGetGuid = (_, guid) =>
            {
                switch (guid.ToString())
                {
                    case "d39784bb-f5ed-4406-9178-82e5df248ea5":
                        count++;
                        switch (count)
                        {
                            case 1:
                            case 2:
                                return "0";
                            case 3:
                            case 4:
                                return "1";
                            case 5:
                            case 6:
                                return "2";
                            default:
                                return DummyString;
                        }
                    case "db655f49-5d0d-4be8-ab0a-968de394f624":
                        return "2018/01/01";
                    default:
                        return DummyInt.ToString();
                }
            };
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => $"{DummyString},{DummyString}";
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, name) => new ShimSPField
            {
                InternalNameGet = () => name,
                TypeGet = () =>
                {
                    switch (name)
                    {
                        case CalculatedField1:
                        case CalculatedField2:
                            return SPFieldType.Calculated;
                        case PercentField:
                        case NumberField:
                            return SPFieldType.Number;
                        case LookupField:
                        case LookupMulti:
                            return SPFieldType.Lookup;
                        case MultiChoiceField:
                            return SPFieldType.MultiChoice;
                        case UserField:
                            return SPFieldType.User;
                        case DateTimeField:
                            return SPFieldType.DateTime;
                        case BooleanField:
                            return SPFieldType.Boolean;
                        case CurrencyField:
                            return SPFieldType.Currency;
                        default:
                            return SPFieldType.Text;
                    }
                },
                IdGet = () =>
                {
                    switch (name)
                    {
                        case ModerationStatusField:
                            return new Guid("d39784bb-f5ed-4406-9178-82e5df248ea5");
                        case DateTimeField:
                            return new Guid("db655f49-5d0d-4be8-ab0a-968de394f624");
                        default:
                            return Guid.NewGuid();
                    }
                },
                SchemaXmlGet = () => 
                {
                    if (name == PercentField)
                    {
                        return "<xml Percentage=\"TRUE\"/>";
                    }
                    return "<xml/>";
                },
                GetFieldValueAsTextObject = _1 => DummyString,
                DescriptionGet = () => name == CalculatedField1 ? "Indicator" : DummyString,
                TypeAsStringGet = () => name
            };

            // Act
            var result = (string)_privateObj.Invoke(GetCellDataMethod, new ShimSPListItem().Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContain("<cell>Approved</cell>"),
                () => result.ShouldContain("<cell>Rejected</cell>"),
                () => result.ShouldContain("<cell>Pending</cell>"),
                () => result.ShouldContain("<![CDATA[DummyString;#DummyString\nDummyString;#DummyString]]>"),
                () => result.ShouldContain("<cell image=\"blank.gif\">"));
        }

        [TestMethod]
        public void GetWBS_OnValidCall_ConfirmResult()
        {
            // Arrange
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => DummyString;

            // Act
            var result = _privateObj.Invoke(GetWBSMethod, new ShimSPListItem().Instance);

            // Assert
            result.ShouldBe(DummyString);
        }

        [TestMethod]
        public void PageLoad_WhenLstTaskCenterHasItems_ConfirmResult()
        {
            // Arrange
            ShimCoreFunctions.getLockedWebSPWeb = spWeb => Guid.NewGuid();
            var count = 0;
            Shimgettasks.AllInstances.getWBSSPListItem = (_, __) =>
            {
                count++;
                return count == 1 ? DummyString : $"{DummyString}.{DummyString}";
            };
            Shimgettasks.AllInstances.getCellDataSPListItem = (_, __) => string.Empty;
            ShimSPList.AllInstances.GetItemsSPQuery = (_, __) => new ShimSPListItemCollection().Bind(new SPListItem[]
            {
                new ShimSPListItem(),
                new ShimSPListItem(),
                new ShimSPListItem()
            });
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            var countItemGet = 0;
            ShimSPListItem.AllInstances.ItemGetString = (_, __) =>
            {
                countItemGet++;
                return countItemGet == 2 ? null : DummyInt.ToString();
            };

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            var data = ((string)_privateObj.GetField(DataField));
            this.ShouldSatisfyAllConditions(
                () => ((SPList)_privateObj.GetField(LstProjectCenterField)).ID.ShouldBe(_guidProjectCenter),
                () => ((SPList)_privateObj.GetField(LstTaskCenterField)).ID.ShouldBe(_guidTaskCenter),
                () => _privateObj.GetField(UseResourcePoolField).ShouldBe(true),
                () => _privateObj.GetField(ResourcePoolUrlField).ShouldBe("EPMLiveResourceURL"),
                () => _privateObj.GetField(ResourceListField).ShouldBe("EPMLiveResourcePool"),
                () => _privateObj.GetField(WpFields).ShouldBe("EPMLiveWorkPlannerFields"),
                () => data.ShouldContain("<rows><row id=\"_SummaryTask_\" style=\"font-weight:bold;\" open=\"1\" locked=\"1\">"),
                () => data.ShouldContain("<row id=\"0\" style=\"font-weight:bold;\" open=\"1\"><wbs>DummyString</wbs><userdata name=\"wbs\">DummyString</userdata><userdata name=\"taskorder\">1</userdata>"),
                () => data.ShouldContain("<userdata name=\"SharePointId\">0</userdata><userdata name=\"Predecessors\"></userdata><userdata name=\"\">1</userdata><row id=\"0\"><wbs>DummyString.DummyString</wbs>"),
                () => data.ShouldContain("<userdata name=\"wbs\">DummyString.DummyString</userdata><userdata name=\"taskorder\">1</userdata><userdata name=\"SharePointId\">0</userdata>"),
                () => data.ShouldContain("<userdata name=\"Predecessors\">1</userdata><userdata name=\"\">1</userdata><userdata name=\"Duration\">1</userdata><userdata name=\"ActualDuration\">1</userdata></row>"),
                () => data.ShouldContain("<row id=\"0\"><wbs>DummyString.DummyString</wbs><userdata name=\"wbs\">DummyString.DummyString</userdata><userdata name=\"taskorder\">1</userdata>"),
                () => data.ShouldContain("<userdata name=\"SharePointId\">0</userdata><userdata name=\"Predecessors\">1</userdata><userdata name=\"\">1</userdata><userdata name=\"Duration\">1</userdata>"),
                () => data.ShouldContain("<userdata name=\"ActualDuration\">1</userdata></row></row></row></rows>"));
        }
    }
}
