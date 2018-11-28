using System.Collections.Generic;
using System.Data;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportingProxy.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests
{
    public partial class FancyDisplayFormTests
    {
        [TestMethod]
        public void FillQuickDetailsSection_FieldsCount7TypeCalculatedInternalNameDue_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(QuickDetailsFieldsCountFieldName, 7);
            _privateObject.SetField(IsLatestVersionFieldName, true);

            ShimCoreFunctions.GetDueFieldSPListItem = listItem => DueComplete;

            var spField = new ShimSPField()
            {
                InternalNameGet = () => "due",
                GetFieldValueAsHtmlObject = objectParam => objectParam.ToString(),
                TypeGet = () => SPFieldType.Calculated
            };

            var spListItem = new ShimSPListItem()
            {
                ItemGetString = itemName => itemName
            };

            // Act
            _privateObject.Invoke(FillQuickDetailsSectionMethodName, spField.Instance, spListItem.Instance);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _sbQuickDetailsContent.ToString().ShouldBe($"</table></td><td style='vertical-align: top'><table class='fancy-col-table'><tr><td></td><td>{DueComplete}</td></tr>"),
                () => _sbQuickDetailsShowAllRegion.ToString().ShouldBe(string.Empty));
        }

        [TestMethod]
        public void FillQuickDetailsSection_FieldsCount28TypeCalculatedInternalNameDue_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(QuickDetailsFieldsCountFieldName, 28);
            _privateObject.SetField(IsLatestVersionFieldName, true);

            ShimCoreFunctions.GetDueFieldSPListItem = listItem => DueComplete;

            var spField = new ShimSPField()
            {
                InternalNameGet = () => "due",
                GetFieldValueAsHtmlObject = objectParam => objectParam.ToString(),
                TypeGet = () => SPFieldType.Calculated
            };

            var spListItem = new ShimSPListItem()
            {
                ItemGetString = itemName => itemName
            };

            // Act
            _privateObject.Invoke(FillQuickDetailsSectionMethodName, spField.Instance, spListItem.Instance);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _sbQuickDetailsContent.ToString().ShouldBe(string.Empty),
                () => _sbQuickDetailsShowAllRegion.ToString().ShouldBe($"</table></td><td style='vertical-align: top'><table class='fancy-col-table'><tr><td></td><td>{DueComplete}</td></tr>"));
        }

        [TestMethod]
        public void FillQuickDetailsSection_FieldsCount7TypeCalculatedInternalNameDaysOverDue_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(QuickDetailsFieldsCountFieldName, 7);
            _privateObject.SetField(IsLatestVersionFieldName, true);

            ShimCoreFunctions.GetDaysOverdueFieldSPListItem = listItem => DaysOverDue;

            var spField = new ShimSPField()
            {
                InternalNameGet = () => "daysoverdue",
                GetFieldValueAsHtmlObject = objectParam => objectParam.ToString(),
                TypeGet = () => SPFieldType.Calculated
            };

            var spListItem = new ShimSPListItem()
            {
                ItemGetString = itemName => itemName
            };

            // Act
            _privateObject.Invoke(FillQuickDetailsSectionMethodName, spField.Instance, spListItem.Instance);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _sbQuickDetailsContent.ToString().ShouldBe($"</table></td><td style='vertical-align: top'><table class='fancy-col-table'><tr><td></td><td>{DaysOverDue}</td></tr>"),
                () => _sbQuickDetailsShowAllRegion.ToString().ShouldBe(string.Empty));
        }

        [TestMethod]
        public void FillQuickDetailsSection_FieldsCount28TypeCalculatedInternalNameDaysOverDue_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(QuickDetailsFieldsCountFieldName, 28);
            _privateObject.SetField(IsLatestVersionFieldName, true);

            ShimCoreFunctions.GetDaysOverdueFieldSPListItem = listItem => DaysOverDue;

            var spField = new ShimSPField()
            {
                InternalNameGet = () => "daysoverdue",
                GetFieldValueAsHtmlObject = objectParam => objectParam.ToString(),
                TypeGet = () => SPFieldType.Calculated
            };

            var spListItem = new ShimSPListItem()
            {
                ItemGetString = itemName => itemName
            };

            // Act
            _privateObject.Invoke(FillQuickDetailsSectionMethodName, spField.Instance, spListItem.Instance);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _sbQuickDetailsContent.ToString().ShouldBe(string.Empty),
                () => _sbQuickDetailsShowAllRegion.ToString().ShouldBe($"</table></td><td style='vertical-align: top'><table class='fancy-col-table'><tr><td></td><td>{DaysOverDue}</td></tr>"));
        }

        [TestMethod]
        public void FillQuickDetailsSection_FieldsCount7TypeCalculatedInternalNameScheduleStatus_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(QuickDetailsFieldsCountFieldName, 7);
            _privateObject.SetField(IsLatestVersionFieldName, true);

            ShimCoreFunctions.GetScheduleStatusFieldSPListItem = listItem => ScheduleStatus;

            var spField = new ShimSPField()
            {
                InternalNameGet = () => "schedulestatus",
                GetFieldValueAsHtmlObject = objectParam => objectParam.ToString(),
                TypeGet = () => SPFieldType.Calculated
            };

            var spListItem = new ShimSPListItem()
            {
                ItemGetString = itemName => itemName
            };

            // Act
            _privateObject.Invoke(FillQuickDetailsSectionMethodName, spField.Instance, spListItem.Instance);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _sbQuickDetailsContent.ToString().ShouldBe($"</table></td><td style='vertical-align: top'><table class='fancy-col-table'><tr><td></td><td><img src='/_layouts/images/{ ScheduleStatus}' /></td></tr>"),
                () => _sbQuickDetailsShowAllRegion.ToString().ShouldBe(string.Empty));
        }

        [TestMethod]
        public void FillQuickDetailsSection_FieldsCount28TypeCalculatedInternalNameScheduleStatus_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(QuickDetailsFieldsCountFieldName, 28);
            _privateObject.SetField(IsLatestVersionFieldName, true);

            ShimCoreFunctions.GetScheduleStatusFieldSPListItem = listItem => ScheduleStatus;

            var spField = new ShimSPField()
            {
                InternalNameGet = () => "schedulestatus",
                GetFieldValueAsHtmlObject = objectParam => objectParam.ToString(),
                TypeGet = () => SPFieldType.Calculated
            };

            var spListItem = new ShimSPListItem()
            {
                ItemGetString = itemName => itemName
            };

            // Act
            _privateObject.Invoke(FillQuickDetailsSectionMethodName, spField.Instance, spListItem.Instance);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _sbQuickDetailsContent.ToString().ShouldBe(string.Empty),
                () => _sbQuickDetailsShowAllRegion.ToString().ShouldBe($"</table></td><td style='vertical-align: top'><table class='fancy-col-table'><tr><td></td><td><img src='/_layouts/images/{ ScheduleStatus}' /></td></tr>"));
        }

        [TestMethod]
        public void FillQuickDetailsSection_FieldsCount7TypeCalculatedInternalNameGif_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(QuickDetailsFieldsCountFieldName, 7);
            _privateObject.SetField(IsLatestVersionFieldName, true);

            var spField = new ShimSPField()
            {
                InternalNameGet = () => ScheduleStatus,
                GetFieldValueAsHtmlObject = objectParam => objectParam.ToString(),
                TypeGet = () => SPFieldType.Calculated
            };

            var spListItem = new ShimSPListItem()
            {
                ItemGetString = itemName => itemName
            };

            // Act
            _privateObject.Invoke(FillQuickDetailsSectionMethodName, spField.Instance, spListItem.Instance);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _sbQuickDetailsContent.ToString().ShouldBe($"</table></td><td style='vertical-align: top'><table class='fancy-col-table'><tr><td></td><td><img src=\"{DummyUrl}/_layouts/images/{ScheduleStatus}\" /></td></tr>"),
                () => _sbQuickDetailsShowAllRegion.ToString().ShouldBe(string.Empty));
        }

        [TestMethod]
        public void FillQuickDetailsSection_FieldsCount28TypeCalculatedInternalNamePng_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(QuickDetailsFieldsCountFieldName, 28);
            _privateObject.SetField(IsLatestVersionFieldName, true);

            var spField = new ShimSPField()
            {
                InternalNameGet = () => PicturePng,
                GetFieldValueAsHtmlObject = objectParam => objectParam.ToString(),
                TypeGet = () => SPFieldType.Calculated
            };

            var spListItem = new ShimSPListItem()
            {
                ItemGetString = itemName => itemName
            };

            // Act
            _privateObject.Invoke(FillQuickDetailsSectionMethodName, spField.Instance, spListItem.Instance);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _sbQuickDetailsContent.ToString().ShouldBe(string.Empty),
                () => _sbQuickDetailsShowAllRegion.ToString().ShouldBe($"</table></td><td style='vertical-align: top'><table class='fancy-col-table'><tr><td></td><td><img src=\"{DummyUrl}/_layouts/images/{PicturePng}\"  /></td></tr>"));
        }

        [TestMethod]
        public void FillQuickDetailsSection_FieldsCount7TypeCalculatedInternalAnything_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(QuickDetailsFieldsCountFieldName, 7);
            _privateObject.SetField(IsLatestVersionFieldName, true);

            var spField = new ShimSPField()
            {
                InternalNameGet = () => DummyString,
                GetFieldValueAsHtmlObject = objectParam => objectParam.ToString(),
                TypeGet = () => SPFieldType.Calculated
            };

            var spListItem = new ShimSPListItem()
            {
                ItemGetString = itemName => itemName
            };

            // Act
            _privateObject.Invoke(FillQuickDetailsSectionMethodName, spField.Instance, spListItem.Instance);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _sbQuickDetailsContent.ToString().ShouldBe($"</table></td><td style='vertical-align: top'><table class='fancy-col-table'><tr><td></td><td>{DummyString}</td></tr>"),
                () => _sbQuickDetailsShowAllRegion.ToString().ShouldBe(string.Empty));
        }

        [TestMethod]
        public void FillQuickDetailsSection_FieldsCount28TypeCalculatedInternalNameAnything_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(QuickDetailsFieldsCountFieldName, 28);
            _privateObject.SetField(IsLatestVersionFieldName, true);

            var spField = new ShimSPField()
            {
                InternalNameGet = () => DummyString,
                GetFieldValueAsHtmlObject = objectParam => objectParam.ToString(),
                TypeGet = () => SPFieldType.Calculated
            };

            var spListItem = new ShimSPListItem()
            {
                ItemGetString = itemName => itemName
            };

            // Act
            _privateObject.Invoke(FillQuickDetailsSectionMethodName, spField.Instance, spListItem.Instance);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _sbQuickDetailsContent.ToString().ShouldBe(string.Empty),
                () => _sbQuickDetailsShowAllRegion.ToString().ShouldBe($"</table></td><td style='vertical-align: top'><table class='fancy-col-table'><tr><td></td><td>{DummyString}</td></tr>"));
        }

        [TestMethod]
        public void FillQuickDetailsSection_FieldsCount7TypeBooleanInternalAnything_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(QuickDetailsFieldsCountFieldName, 7);
            _privateObject.SetField(IsLatestVersionFieldName, true);

            var spField = new ShimSPField()
            {
                InternalNameGet = () => DummyString,
                GetFieldValueAsHtmlObject = objectParam => objectParam.ToString(),
                TypeGet = () => SPFieldType.Boolean
            };

            var spListItem = new ShimSPListItem()
            {
                ItemGetString = itemName => itemName
            };

            // Act
            _privateObject.Invoke(FillQuickDetailsSectionMethodName, spField.Instance, spListItem.Instance);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _sbQuickDetailsContent.ToString().ShouldBe($"</table></td><td style='vertical-align: top'><table class='fancy-col-table'><tr><td></td><td>{DummyString}</td></tr>"),
                () => _sbQuickDetailsShowAllRegion.ToString().ShouldBe(string.Empty));
        }

        [TestMethod]
        public void FillQuickDetailsSection_FieldsCount28TypeBooleanInternalNameAnything_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(QuickDetailsFieldsCountFieldName, 28);
            _privateObject.SetField(IsLatestVersionFieldName, true);

            var spField = new ShimSPField()
            {
                InternalNameGet = () => DummyString,
                GetFieldValueAsHtmlObject = objectParam => objectParam.ToString(),
                TypeGet = () => SPFieldType.Boolean
            };

            var spListItem = new ShimSPListItem()
            {
                ItemGetString = itemName => itemName
            };

            // Act
            _privateObject.Invoke(FillQuickDetailsSectionMethodName, spField.Instance, spListItem.Instance);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _sbQuickDetailsContent.ToString().ShouldBe(string.Empty),
                () => _sbQuickDetailsShowAllRegion.ToString().ShouldBe($"</table></td><td style='vertical-align: top'><table class='fancy-col-table'><tr><td></td><td>{DummyString}</td></tr>"));
        }

        [TestMethod]
        public void FillQuickDetailsSection_FieldsCount14TypeTextInternalNameAnything_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(QuickDetailsFieldsCountFieldName, 14);
            _privateObject.SetField(IsLatestVersionFieldName, true);

            var spField = new ShimSPField()
            {
                InternalNameGet = () => DummyString,
                GetFieldValueAsHtmlObject = objectParam => objectParam.ToString(),
                TypeGet = () => SPFieldType.Text
            };

            var spListItem = new ShimSPListItem()
            {
                ItemGetString = itemName => itemName
            };

            // Act
            _privateObject.Invoke(FillQuickDetailsSectionMethodName, spField.Instance, spListItem.Instance);
            _privateObject.Invoke(ManageHtmlOpeningClosingMethodName);
            _privateObject.Invoke(ShowHideDivsMethodName);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _sbQuickDetailsContent.ToString().ShouldBe(ExpectedDefaultEmptyTable),
                () => _sbQuickDetailsShowAllRegion.ToString().ShouldBe($"<table style='width:100%'><tr><td><table class='fancy-col-table'><tr><td></td><td>{DummyString}</td></tr></table></td></tr></table>"),
                () => _divQuickDetailsContent.Visible.ShouldBeTrue(),
                () => _divQuickDetailsContent.InnerHtml.ShouldBe(_sbQuickDetailsContent.ToString()),
                () => _divShowQuickDetailsHeader.Visible.ShouldBeTrue(),
                () => _divShowQuickDetailsContent.InnerHtml.ShouldBe(_sbQuickDetailsShowAllRegion.ToString()));
        }

        [TestMethod]
        public void FillNarrativeDetailsSection_FieldsCount1AppendOnlyFalse_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(NarrativeDetailsFieldsCountFieldName, 1);

            // Act
            _privateObject.Invoke(FillNarrativeDetailsSectionMethodName, DummyFieldName, DummyFieldValue, (SPListItem)null, false);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _sbNarrativeDetailsContent.ToString().ShouldBe($"<tr><td>{DummyFieldName}</td><td style='width:auto;'>{DummyFieldValue}</td></tr>"),
                () => _sbNarrativeDetailsShowAllRegion.ToString().ShouldBe(string.Empty));
        }

        [TestMethod]
        public void FillNarrativeDetailsSection_FieldsCount2AppendOnlyFalse_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(NarrativeDetailsFieldsCountFieldName, 2);

            // Act
            _privateObject.Invoke(FillNarrativeDetailsSectionMethodName, DummyFieldName, DummyFieldValue, (SPListItem)null, false);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _sbNarrativeDetailsContent.ToString().ShouldBe(ExpectedDefaultEmptyTable),
                () => _sbNarrativeDetailsShowAllRegion.ToString().ShouldBe($"<table class='fancy-col-table'><tr><td>{DummyFieldName}</td><td style='width:auto;'>{DummyFieldValue}</td></tr>"));
        }

        [TestMethod]
        public void FillNarrativeDetailsSection_FieldsCount2AppendOnlyTrueIsLastVersionFalse_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(NarrativeDetailsFieldsCountFieldName, 2);
            _privateObject.SetField(IsLatestVersionFieldName, false);

            _spContext.ListItemVersionGet = () => new ShimSPListItemVersion()
            {
                VersionIdGet = () => DummyVersionIdBigger
            };

            var listItem = new ShimSPListItem()
            {
                VersionsGet = () => new ShimSPListItemVersionCollection()
                {
                    ItemGetInt32 = pos => _listItemVersion
                }.Bind(
                    new SPListItemVersion[]
                    {
                        _listItemVersion
                    })
            };

            var expectedNarrativeDetailsShowAllRegion = new List<string>()
            {
                $"<td>{DummyInternalNameText}</td>",
                "<div><span class=\"ms-noWrap\"><span class=\"ms-spimn-presenceLink\">",
                "<span class=\"ms-spimn-presenceWrapper ms-imnImg ms-spimn-imgSize-10x10\">",
                "<img class=\"ms-spimn-img ms-spimn-presence-disconnected-10x10x32\" src=\"/_layouts/15/images/spimn.png?rev=23\" alt=\"\">",
                "</span></span><span class=\"ms-noWrap ms-imnSpan\"><span class=\"ms-spimn-presenceLink\">",
                "<img class=\"ms-hide\" src=\"/_layouts/15/images/blank.gif?rev = 23\" alt=\"\">",
                $"<a class=\"ms-subtleLink\" onclick=\"GoToLinkOrDialogNewWindow(this); return false;\" href={DummyUrl}/_layouts/15/userdisp.aspx?ID0>{DummyUserName}</a>",
                $"{DummyString}</div>"
            };

            // Act
            _privateObject.Invoke(FillNarrativeDetailsSectionMethodName, DummyInternalNameText, DummyFieldValue, listItem.Instance, true);

            // Assert
            LoadFieldValues();

            var actualNarrativeDetailsShowAllRegion = _sbNarrativeDetailsShowAllRegion.ToString();

            this.ShouldSatisfyAllConditions(
                () => _sbNarrativeDetailsContent.ToString().ShouldBe(ExpectedDefaultEmptyTable),
                () => expectedNarrativeDetailsShowAllRegion.ForEach(c => actualNarrativeDetailsShowAllRegion.ShouldContain(c)));
        }

        [TestMethod]
        public void FillNarrativeDetailsSection_FieldsCount2AppendOnlyTrueIsLastVersionTrue_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(NarrativeDetailsFieldsCountFieldName, 2);
            _privateObject.SetField(IsLatestVersionFieldName, true);

            var listItem = new ShimSPListItem()
            {
                VersionsGet = () => new ShimSPListItemVersionCollection()
                {
                    ItemGetInt32 = pos => _listItemVersion
                }.Bind(
                    new SPListItemVersion[]
                    {
                        _listItemVersion
                    })
            };

            var expectedNarrativeDetailsShowAllRegion = new List<string>()
            {
                $"<td>{DummyInternalNameText}</td>",
                "<div><span class=\"ms-noWrap\"><span class=\"ms-spimn-presenceLink\">",
                "<span class=\"ms-spimn-presenceWrapper ms-imnImg ms-spimn-imgSize-10x10\">",
                "<img class=\"ms-spimn-img ms-spimn-presence-disconnected-10x10x32\" src=\"/_layouts/15/images/spimn.png?rev=23\" alt=\"\">",
                "</span></span><span class=\"ms-noWrap ms-imnSpan\"><span class=\"ms-spimn-presenceLink\">",
                "<img class=\"ms-hide\" src=\"/_layouts/15/images/blank.gif?rev = 23\" alt=\"\">",
                $"<a class=\"ms-subtleLink\" onclick=\"GoToLinkOrDialogNewWindow(this); return false;\" href={DummyUrl}/_layouts/15/userdisp.aspx?ID0>{DummyUserName}</a>",
                $"{DummyString}</div>"
            };

            // Act
            _privateObject.Invoke(FillNarrativeDetailsSectionMethodName, DummyInternalNameText, DummyFieldValue, listItem.Instance, true);
            _privateObject.Invoke(ManageHtmlOpeningClosingMethodName);
            _privateObject.Invoke(ShowHideDivsMethodName);

            // Assert
            LoadFieldValues();

            var actualNarrativeDetailsShowAllRegion = _sbNarrativeDetailsShowAllRegion.ToString();

            this.ShouldSatisfyAllConditions(
                () => _sbNarrativeDetailsContent.ToString().ShouldBe(ExpectedDefaultEmptyTable),
                () => expectedNarrativeDetailsShowAllRegion.ForEach(c => actualNarrativeDetailsShowAllRegion.ShouldContain(c)),
                () => _divNarrativeDetailsContent.Visible.ShouldBeTrue(),
                () => _divNarrativeDetailsContent.InnerHtml.ShouldBe(_sbNarrativeDetailsContent.ToString()),
                () => _divShowNarrativeDetailsHeader.Visible.ShouldBeTrue(),
                () => _divShowNarrativeDetailsContent.InnerHtml.ShouldBe(actualNarrativeDetailsShowAllRegion));
        }

        [TestMethod]
        public void FillPeopleDetailsSection_FieldsCount5UsersFound_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(PeopleDetailsFieldsCountFieldName, 5);
            var fieldValue = $"{DummyId1};#{DummyId2};#{DummyId3}";

            ShimQueryExecutor.AllInstances.ExecuteReportingDBQueryStringIDictionaryOfStringObject = (sender, query, parameters) =>
            {
                var dtUsers = new DataTable();
                dtUsers.Columns.Add("ID");
                dtUsers.Columns.Add("Title");
                dtUsers.Columns.Add("Picture");

                var drUser1 = dtUsers.NewRow();
                drUser1["ID"] = DummyId1;
                drUser1["Title"] = DummyUserTitle1;
                drUser1["Picture"] = string.Empty;
                dtUsers.Rows.Add(drUser1);

                var drUser2 = dtUsers.NewRow();
                drUser2["ID"] = DummyId2;
                drUser2["Title"] = DummyUserTitle2;
                drUser2["Picture"] = DummyUserPictureWithComma;
                dtUsers.Rows.Add(drUser2);

                var drUser3 = dtUsers.NewRow();
                drUser3["ID"] = DummyId3;
                drUser3["Title"] = DummyUserTitle3;
                drUser3["Picture"] = DummyUserPictureWithoutComma;
                dtUsers.Rows.Add(drUser3);

                return dtUsers;
            };

            var expectedPeopleDetailsShowAllRegion = new List<string>()
            {
                $"<td>{DummyFieldName}</td>",
                $"<td style='text-align: right'><img alt='' src='{DummyUrl}/_layouts/epmlive/images/defaultprofilepic.png' class='dispFormUserImage' /></td>",
                $"<td style='vertical-align: middle'><a class'ms-subtleLink' onclick='GoToLinkOrDialogNewWindow(this);return false;' href='{DummyUrl}/_layouts/15/userdisp.aspx?ID={DummyId1}'>{DummyUserTitle1}</a>&nbsp;&nbsp;</td>",
                $"<td style='text-align: right'><img alt='' src='http://dummypicture.org/pic2.png' class='dispFormUserImage' /></td>",
                $"<td style='vertical-align: middle'><a class'ms-subtleLink' onclick='GoToLinkOrDialogNewWindow(this);return false;' href='{DummyUrl}/_layouts/15/userdisp.aspx?ID={DummyId2}'>{DummyUserTitle2}</a>&nbsp;&nbsp;</td>",
                $"<td style='text-align: right'><img alt='' src='{DummyUserPictureWithoutComma}' class='dispFormUserImage' /></td>",
                $"<td style='vertical-align: middle'><a class'ms-subtleLink' onclick='GoToLinkOrDialogNewWindow(this);return false;' href='{DummyUrl}/_layouts/15/userdisp.aspx?ID={DummyId3}'>{DummyUserTitle3}</a>&nbsp;&nbsp;</td>",
                "<td class='dispFormExpandMore'>(more...)</td>",
                "<tr class='ShowMoreRow' style='display: none'>"
            };

            // Act
            _privateObject.Invoke(FillPeopleDetailsSectionMethodName, DummyFieldName, fieldValue);

            // Assert
            LoadFieldValues();
            var actualPeopleDetailsShowAllRegion = _sbPeopleDetailsShowAllRegion.ToString();

            this.ShouldSatisfyAllConditions(
                () => _sbPeopleDetailsContent.ToString().ShouldBe(ExpectedDefaultEmptyTable),
                () => expectedPeopleDetailsShowAllRegion.ForEach(c => actualPeopleDetailsShowAllRegion.ShouldContain(c)));
        }

        [TestMethod]
        public void FillPeopleDetailsSection_FieldsCount3UsersFound_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(PeopleDetailsFieldsCountFieldName, 3);
            var fieldValue = $"{DummyId1};#{DummyId2};#{DummyId3}";

            ShimQueryExecutor.AllInstances.ExecuteReportingDBQueryStringIDictionaryOfStringObject = (sender, query, parameters) =>
            {
                var dtUsers = new DataTable();
                dtUsers.Columns.Add("ID");
                dtUsers.Columns.Add("Title");
                dtUsers.Columns.Add("Picture");

                var drUser1 = dtUsers.NewRow();
                drUser1["ID"] = DummyId1;
                drUser1["Title"] = DummyUserTitle1;
                drUser1["Picture"] = string.Empty;
                dtUsers.Rows.Add(drUser1);

                var drUser2 = dtUsers.NewRow();
                drUser2["ID"] = DummyId2;
                drUser2["Title"] = DummyUserTitle2;
                drUser2["Picture"] = DummyUserPictureWithComma;
                dtUsers.Rows.Add(drUser2);

                var drUser3 = dtUsers.NewRow();
                drUser3["ID"] = DummyId3;
                drUser3["Title"] = DummyUserTitle3;
                drUser3["Picture"] = DummyUserPictureWithoutComma;
                dtUsers.Rows.Add(drUser3);

                return dtUsers;
            };

            var expectedPeopleDetailsContent = new List<string>()
            {
                $"<td>{DummyFieldName}</td>",
                $"<td style='text-align: right'><img alt='' src='{DummyUrl}/_layouts/epmlive/images/defaultprofilepic.png' class='dispFormUserImage' /></td>",
                $"<td style='vertical-align: middle'><a class='ms-subtleLink' onclick='GoToLinkOrDialogNewWindow(this);return false;' href='{DummyUrl}/_layouts/15/userdisp.aspx?ID={DummyId1}'>{DummyUserTitle1}</a>&nbsp;&nbsp;</td>",
                "<td style='text-align: right'><img alt='' src='http://dummypicture.org/pic2.png' class='dispFormUserImage' /></td>",
                $"<td style='vertical-align: middle'><a class='ms-subtleLink' onclick='GoToLinkOrDialogNewWindow(this);return false;' href='{DummyUrl}/_layouts/15/userdisp.aspx?ID={DummyId2}'>{DummyUserTitle2}</a>&nbsp;&nbsp;</td>",
                $"<td style='text-align: right'><img alt='' src='{DummyUserPictureWithoutComma}' class='dispFormUserImage' /></td>",
                $"<td style='vertical-align: middle'><a class='ms-subtleLink' onclick='GoToLinkOrDialogNewWindow(this);return false;' href='{DummyUrl}/_layouts/15/userdisp.aspx?ID={DummyId3}'>{DummyUserTitle3}</a>&nbsp;&nbsp;</td>",
                "<td class='dispFormExpandMore'>(more...)</td>",
                "<tr class='ShowMoreRow' style='display: none'>"
            };

            // Act
            _privateObject.Invoke(FillPeopleDetailsSectionMethodName, DummyFieldName, fieldValue);

            // Assert
            LoadFieldValues();
            var actualPeopleDetailsContent = _sbPeopleDetailsContent.ToString();

            this.ShouldSatisfyAllConditions(
                () => _sbPeopleDetailsShowAllRegion.ToString().ShouldBe(string.Empty),
                () => expectedPeopleDetailsContent.ForEach(c => actualPeopleDetailsContent.ShouldContain(c)));
        }

        [TestMethod]
        public void FillPeopleDetailsSection_FieldsCount5UsersNotFound_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(PeopleDetailsFieldsCountFieldName, 5);
            var fieldValue = "200;#210;#220";

            ShimQueryExecutor.AllInstances.ExecuteReportingDBQueryStringIDictionaryOfStringObject = (sender, query, parameters) => null;

            // Act
            _privateObject.Invoke(FillPeopleDetailsSectionMethodName, DummyFieldName, fieldValue);
            _privateObject.Invoke(ManageHtmlOpeningClosingMethodName);
            _privateObject.Invoke(ShowHideDivsMethodName);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _sbPeopleDetailsContent.ToString().ShouldBe(ExpectedDefaultEmptyTable),
                () => _sbPeopleDetailsShowAllRegion.ToString().ShouldBe($"<table class='fancy-col-table'><tr><td>{DummyFieldName}</td><td>&nbsp;</td><td>&nbsp;</td></tr></tr></table>"),
                () => _divPeopleContent.Visible.ShouldBeTrue(),
                () => _divPeopleContent.InnerHtml.ShouldBe(_sbPeopleDetailsContent.ToString()),
                () => _divPeopleShowAllHeader.Visible.ShouldBeTrue(),
                () => _divPeopleShowAllContent.InnerHtml.ShouldBe(_sbPeopleDetailsShowAllRegion.ToString()));
        }

        [TestMethod]
        public void FillPeopleDetailsSection_FieldsCount3UsersNotFound_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(PeopleDetailsFieldsCountFieldName, 3);
            var fieldValue = "200;#210;#220";

            ShimQueryExecutor.AllInstances.ExecuteReportingDBQueryStringIDictionaryOfStringObject = (sender, query, parameters) => null;

            // Act
            _privateObject.Invoke(FillPeopleDetailsSectionMethodName, DummyFieldName, fieldValue);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _sbPeopleDetailsContent.ToString().ShouldBe($"<tr><td>{DummyFieldName}</td><td>&nbsp;</td><td>&nbsp;</td></tr></tr><tr class='ShowMoreRow' style='display: none'><td>&nbsp;</td></tr></tr>"),
                () => _sbPeopleDetailsShowAllRegion.ToString().ShouldBeNullOrEmpty());
        }

        [TestMethod]
        public void FillDateDetailsSection_FieldsCount5_ChangeProperties()
        {
            // Arrange
            _privateObject.SetField(DatesDetailsFieldsCountFieldName, 5);

            // Act
            _privateObject.Invoke(FillDateDetailsSectionMethodName, DummyFieldName, DummyFieldValue);
            _privateObject.Invoke(ManageHtmlOpeningClosingMethodName);
            _privateObject.Invoke(ShowHideDivsMethodName);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _sbDateDetailsContent.ToString().ShouldBe(ExpectedDefaultEmptyTable),
                () => _sbDateDetailsShowAllRegion.ToString().ShouldBe($"<table class='fancy-col-table'><tr><td>{DummyFieldName}</td><td>{DummyFieldValue}</td></tr></table>"),
                () => _divDatesShowAllHeader.Visible.ShouldBeTrue(),
                () => _divDatesShowAllContent.InnerHtml.ShouldBe(_sbDateDetailsShowAllRegion.ToString()));
        }
    }
}
