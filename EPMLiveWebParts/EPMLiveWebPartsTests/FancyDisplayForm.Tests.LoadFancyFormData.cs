using System.Collections.Generic;
using EPMLiveCore.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests
{
    public partial class FancyDisplayFormTests
    {
        [TestMethod]
        public void LoadFancyFormData_FieldPropertiesNotNullLastVersionTrueDisplayAlways_ChangeProperties()
        {
            // Arrange
            _spContext.ListGet = () => new ShimSPList()
            {
                EnableVersioningGet = () => true,
                FieldsGet = () => new ShimSPFieldCollection().Bind(
                    new SPField[]
                    {
                        _spFieldText,
                        _spFieldDateTime,
                        _spFieldUser,
                        _spFieldNote
                    }),
                RootFolderGet = () => new ShimSPFolder()
                {
                    UrlGet = () => DummyUrlRootFolder
                }
            };

            _spContext.ListItemGet = () => new ShimSPListItem()
            {
                ItemGetString = itemName =>
                {
                    switch (itemName)
                    {
                        case "Title":
                            return DummyTitle;
                        case DummyInternalNameText:
                            return DummyString;
                        case DummyInternalNameDateTime:
                            return "2018/02/02";
                        case DummyInternalNameNote:
                            return DummyNote;
                        case DummyInternalNameUser:
                            return DummyUser;
                        default:
                            break;
                    }

                    return null;
                },
                ItemGetGuid = guid =>
                {
                    if (guid == SPBuiltInFieldId.Created)
                    {
                        return DummyDateTime;
                    }
                    else if (guid == SPBuiltInFieldId.Author)
                    {
                        return DummyAuthor;
                    }
                    else if (guid == SPBuiltInFieldId.Modified)
                    {
                        return DummyDateTime;
                    }
                    else if (guid == SPBuiltInFieldId.Editor)
                    {
                        return DummyEditor;
                    }

                    return null;
                },
                VersionsGet = () => new ShimSPListItemVersionCollection()
                {
                    ItemGetInt32 = pos => _listItemVersion
                }.Bind(
                    new SPListItemVersion[]
                    {
                        _listItemVersion
                    }),
                ParentListGet = () => new ShimSPList()
                {
                    EnableVersioningGet = () => true
                },
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    ItemGetGuid = guid => new ShimSPField()
                    {
                        GetFieldValueAsHtmlObject = objectParam => objectParam.ToString()
                    }
                },
                AttachmentsGet = () => new ShimSPAttachmentCollection().Bind(
                    new[]
                    {
                        DummyFileName
                    })
            };

            ShimGridGanttSettings.ConstructorSPList = (sender, listParam) =>
            {
                var gridGantt = new ShimGridGanttSettings(sender);
                gridGantt.Instance.DisplaySettings = $"#{DummyInternalNameText}|Display|always#{DummyInternalNameDateTime}|Display|always#{DummyInternalNameUser}|Display|always#{DummyInternalNameNote}|Display|always";
            };

            var expectedDivAttachment = new List<string>()
            {
                $"<a href='{DummyUrl}/{DummyUrlRootFolder}/attachments/0/{DummyFileName}' target='_blank' ID='{DummyFileName}' class='fancybox'>",
                $"<span>&nbsp;{DummyFileName}</span>",
                $"<a href='#' onclick=\"javascript:FancyDispFormClient.DeleteItemAttachment('{DummyUrl}/_layouts/epmlive/gridaction.aspx?action=deleteitemattachment&listid=00000000-0000-0000-0000-000000000000&itemid=0&fname={DummyFileName}');return false;\">"
            };

            // Act
            _privateObject.Invoke(LoadFancyFormDataMethodName);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => expectedDivAttachment.ForEach(c => _divAttachmentDetailsContent.InnerHtml.ShouldContain(c)),
                () => _sbItemDetailsContent.ToString().ShouldBe($"<table style='width:100%'><tr colspan='2'><td>Version: {DummyVersionLabel}</td></tr><tr colspan='2'><td>Created {DummyDateTime.ToString("MM/dd/yyyy HH:mm")} by {DummyAuthor}</td></tr><tr colspan='2'><td>Last modified {DummyDateTime.ToString("MM/dd/yyyy HH:mm")} by {DummyEditor}</td></tr></table>"),
                () => _sbDateDetailsContent.ToString().ShouldBe($"<table style='width:100%;'><tr><td><table class='fancy-col-table'><tr><td>{DummyInternalNameDateTime}</td><td>{DummyDateTime.ToString("M/d/yyyy")}</td></tr>"),
                () => _sbQuickDetailsContent.ToString().ShouldBe($"<table style='width:100%'><tr><td><table class='fancy-col-table'><tr><td>{DummyInternalNameText}</td><td></td></tr>"),
                () => _sbPeopleDetailsContent.ToString().ShouldBe($"<table style='width: 100%'><tr><td><table class='fancy-col-table'><tr><td>{DummyInternalNameUser}</td>"),
                () => _sbNarrativeDetailsContent.ToString().ShouldBe(ExpectedNarrativeStringBuilder));
        }

        [TestMethod]
        public void LoadFancyFormData_FieldPropertiesNotNullLastVersionFalseDisplayWhere_ChangeProperties()
        {
            // Arrange
            _spContext.ListGet = () => new ShimSPList()
            {
                EnableVersioningGet = () => true,
                FieldsGet = () => new ShimSPFieldCollection().Bind(
                    new SPField[]
                    {
                        _spFieldText,
                        _spFieldDateTime,
                        _spFieldUser,
                        _spFieldNote
                    }),
                RootFolderGet = () => new ShimSPFolder()
                {
                    UrlGet = () => DummyUrlRootFolder
                }
            };
            _spContext.ListItemVersionGet = () => new ShimSPListItemVersion()
            {
                VersionIdGet = () => DummyVersionId,
                VersionLabelGet = () => DummyVersionLabel
            };

            _spContext.ListItemGet = () => new ShimSPListItem()
            {
                ItemGetString = itemName =>
                {
                    switch (itemName)
                    {
                        case "Title":
                            return DummyTitle;
                        case DummyInternalNameText:
                            return DummyString;
                        case DummyInternalNameDateTime:
                            return "2018/02/02";
                        case DummyInternalNameNote:
                            return DummyNote;
                        case DummyInternalNameUser:
                            return DummyUser;
                        default:
                            break;
                    }

                    return null;
                },
                ItemGetGuid = guid =>
                {
                    if (guid == SPBuiltInFieldId.Created)
                    {
                        return DummyDateTime;
                    }
                    else if (guid == SPBuiltInFieldId.Author)
                    {
                        return DummyAuthor;
                    }
                    else if (guid == SPBuiltInFieldId.Modified)
                    {
                        return DummyDateTime;
                    }
                    else if (guid == SPBuiltInFieldId.Editor)
                    {
                        return DummyEditor;
                    }
                    else if (guid == SpFieldTextGuid)
                    {
                        return DummyInternalNameText;
                    }

                    return null;
                },
                VersionsGet = () => new ShimSPListItemVersionCollection()
                {
                    ItemGetInt32 = pos => _listItemVersion
                }.Bind(
                    new SPListItemVersion[]
                    {
                        _listItemVersion
                    }),
                ParentListGet = () => new ShimSPList()
                {
                    EnableVersioningGet = () => true
                },
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    ItemGetGuid = guid => new ShimSPField()
                    {
                        GetFieldValueAsHtmlObject = objectParam => objectParam.ToString()
                    },
                    GetFieldByInternalNameString = internalName =>
                    {
                        switch (internalName)
                        {
                            case DummyInternalNameText:
                                return _spFieldText;
                            case DummyInternalNameDateTime:
                                return _spFieldDateTime;
                            case DummyInternalNameUser:
                                return _spFieldUser;
                            case DummyInternalNameNote:
                                return _spFieldNote;
                            default:
                                break;
                        }

                        return null;
                    }
                },
                AttachmentsGet = () => new ShimSPAttachmentCollection().Bind(
                    new[]
                    {
                        DummyFileName
                    })
            };

            ShimGridGanttSettings.ConstructorSPList = (sender, listParam) =>
            {
                var gridGantt = new ShimGridGanttSettings(sender);
                gridGantt.Instance.DisplaySettings = string.Format(
                    $"#{DummyInternalNameText}|Display|where;nothing;{DummyInternalNameText};IsEqualTo;{DummyInternalNameText}#{DummyInternalNameDateTime}|Display|where;nothing;{DummyInternalNameDateTime};IsEqualTo;{DummyInternalNameDateTime}#{DummyInternalNameUser}|Display|where;[Me];condition;group#{DummyInternalNameNote}|Display|where;nothing;{DummyInternalNameNote};IsEqualTo;{DummyInternalNameNote}");
            };

            ShimEditableFieldDisplay.WhereUserStringString = (condition, group) => true;
            ShimEditableFieldDisplay.RenderFieldSPFieldStringStringStringStringStringSPListItem =
                (field, where, conditionField, condition, group, valueCondition, listItem) => true;

            var expectedDivAttachment = new List<string>()
            {
                $"<a href='{DummyUrl}/{DummyUrlRootFolder}/attachments/0/{DummyFileName}' target='_blank' ID='{DummyFileName}' class='fancybox'>",
                $"<span>&nbsp;{DummyFileName}</span>",
            };

            // Act
            _privateObject.Invoke(LoadFancyFormDataMethodName);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => expectedDivAttachment.ForEach(c => _divAttachmentDetailsContent.InnerHtml.ShouldContain(c)),
                () => _sbItemDetailsContent.ToString().ShouldBe($"<table style='width:100%'><tr colspan='2'><td>Version: {DummyVersionLabel}</td></tr><tr colspan='2'><td>Created {DummyDateTime.ToString("MM/dd/yyyy HH:mm")} by {DummyAuthor}</td></tr><tr colspan='2'><td>Last modified {DummyDateTime.ToString("MM/dd/yyyy HH:mm")} by {DummyEditor}</td></tr></table>"),
                () => _sbDateDetailsContent.ToString().ShouldBe($"<table style='width:100%;'><tr><td><table class='fancy-col-table'><tr><td>{DummyInternalNameDateTime}</td><td>{DummyDateTime.ToString("M/d/yyyy")}</td></tr>"),
                () => _sbQuickDetailsContent.ToString().ShouldBe($"<table style='width:100%'><tr><td><table class='fancy-col-table'><tr><td>{DummyInternalNameText}</td><td></td></tr>"),
                () => _sbPeopleDetailsContent.ToString().ShouldBe($"<table style='width: 100%'><tr><td><table class='fancy-col-table'><tr><td>{DummyInternalNameUser}</td>"),
                () => _sbNarrativeDetailsContent.ToString().ShouldBe(ExpectedNarrativeStringBuilder));
        }

        [TestMethod]
        public void LoadFancyFormData_FieldPropertiesNullIsLastVersionTrue_ChangeProperties()
        {
            // Arrange
            _spContext.ListGet = () => new ShimSPList()
            {
                EnableVersioningGet = () => true,
                FieldsGet = () => new ShimSPFieldCollection().Bind(
                    new SPField[]
                    {
                        _spFieldText,
                        _spFieldDateTime,
                        _spFieldUser,
                        _spFieldNote
                    })
            };

            _spContext.ListItemGet = () => new ShimSPListItem()
            {
                ItemGetString = itemName =>
                {
                    switch (itemName)
                    {
                        case "Title":
                            return DummyTitle;
                        default:
                            break;
                    }

                    return null;
                },
                ItemGetGuid = guid =>
                {
                    if (guid == SPBuiltInFieldId.Created)
                    {
                        return DummyDateTime;
                    }
                    else if (guid == SPBuiltInFieldId.Author)
                    {
                        return DummyAuthor;
                    }
                    else if (guid == SPBuiltInFieldId.Modified)
                    {
                        return DummyDateTime;
                    }
                    else if (guid == SPBuiltInFieldId.Editor)
                    {
                        return DummyEditor;
                    }
                    else if (guid == SpFieldTextGuid)
                    {
                        return DummyInternalNameText;
                    }

                    return null;
                },
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    ItemGetGuid = guid => new ShimSPField()
                    {
                        GetFieldValueAsHtmlObject = objectParam => objectParam.ToString()
                    }
                },
                VersionsGet = () => new ShimSPListItemVersionCollection(),
                ParentListGet = () => new ShimSPList()
                {
                    EnableVersioningGet = () => false
                },
                AttachmentsGet = () => new ShimSPAttachmentCollection().Bind(new string[0])
            };

            ShimGridGanttSettings.ConstructorSPList = (sender, listParam) =>
            {
                var gridGantt = new ShimGridGanttSettings(sender);
                gridGantt.Instance.DisplaySettings = string.Empty;
            };

            // Act
            _privateObject.Invoke(LoadFancyFormDataMethodName);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _divAttachmentDetailsContent.InnerHtml.ShouldBe("<div id='attach-wrapper'><table class='fancy-col-table'><tr><td style='color:#bbbbbb;'>There are no attachments, click the \"+\" icon above to upload new attachments.</td></tr></table></div>"),
                () => _sbItemDetailsContent.ToString().ShouldBe($"<table style='width:100%'><tr colspan='2'><td>Created {DummyDateTime.ToString("MM/dd/yyyy HH:mm")} by {DummyAuthor}</td></tr><tr colspan='2'><td>Last modified {DummyDateTime.ToString("MM/dd/yyyy HH:mm")} by {DummyEditor}</td></tr></table>"),
                () => _sbDateDetailsContent.ToString().ShouldBe($"<table style='width:100%;'><tr><td><table class='fancy-col-table'><tr><td>{DummyInternalNameDateTime}</td><td></td></tr>"),
                () => _sbQuickDetailsContent.ToString().ShouldBe($"<table style='width:100%'><tr><td><table class='fancy-col-table'><tr><td>{DummyInternalNameText}</td><td></td></tr>"),
                () => _sbPeopleDetailsContent.ToString().ShouldBe($"<table style='width: 100%'><tr><td><table class='fancy-col-table'><tr><td>{DummyInternalNameUser}</td>"),
                () => _sbNarrativeDetailsContent.ToString().ShouldBe($"<table style='width:100%;'><tr><td><table class='fancy-col-table'><tr><td>{DummyInternalNameNote}</td><td style='width:auto;'></td></tr>"));
        }

        [TestMethod]
        public void LoadFancyFormData_FieldPropertiesNullIsLastVersionFalse_ChangeProperties()
        {
            // Arrange
            _spContext.ListGet = () => new ShimSPList()
            {
                EnableVersioningGet = () => true,
                FieldsGet = () => new ShimSPFieldCollection().Bind(
                    new SPField[]
                    {
                        _spFieldText,
                        _spFieldDateTime,
                        _spFieldUser,
                        _spFieldNote
                    })
            };

            _spContext.ListItemVersionGet = () => new ShimSPListItemVersion()
            {
                VersionIdGet = () => DummyVersionId,
                VersionLabelGet = () => DummyVersionLabel
            };

            _spContext.ListItemGet = () => new ShimSPListItem()
            {
                ItemGetString = itemName =>
                {
                    if (itemName == "Title")
                    {
                        return DummyTitle;
                    }

                    return null;
                },
                ItemGetGuid = guid =>
                {
                    if (guid == SPBuiltInFieldId.Created)
                    {
                        return DummyDateTime;
                    }
                    else if (guid == SPBuiltInFieldId.Author)
                    {
                        return DummyAuthor;
                    }
                    else if (guid == SPBuiltInFieldId.Modified)
                    {
                        return DummyDateTime;
                    }
                    else if (guid == SPBuiltInFieldId.Editor)
                    {
                        return DummyEditor;
                    }
                    else if (guid == SpFieldTextGuid)
                    {
                        return DummyInternalNameText;
                    }

                    return null;
                },
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    ItemGetGuid = guid => new ShimSPField()
                    {
                        GetFieldValueAsHtmlObject = objectParam => objectParam.ToString()
                    }
                },
                VersionsGet = () => new ShimSPListItemVersionCollection()
                {
                    ItemGetInt32 = pos => _listItemVersion
                }.Bind(
                    new SPListItemVersion[]
                    {
                        _listItemVersion
                    }),
                ParentListGet = () => new ShimSPList()
                {
                    EnableVersioningGet = () => false
                },
                AttachmentsGet = () => new ShimSPAttachmentCollection().Bind(new string[0])
            };

            ShimGridGanttSettings.ConstructorSPList = (sender, listParam) =>
            {
                var gridGantt = new ShimGridGanttSettings(sender);
                gridGantt.Instance.DisplaySettings = string.Empty;
            };

            // Act
            _privateObject.Invoke(LoadFancyFormDataMethodName);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _divAttachmentDetailsContent.InnerHtml.ShouldBe("<div id='attach-wrapper'><table class='fancy-col-table'><tr><td style='color:#bbbbbb;'>There are no attachments, click the \"+\" icon above to upload new attachments.</td></tr></table></div>"),
                () => _sbItemDetailsContent.ToString().ShouldBe($"<table style='width:100%'><tr colspan='2'><td>Created {DummyDateTime.ToString("MM/dd/yyyy HH:mm")} by {DummyAuthor}</td></tr><tr colspan='2'><td>Last modified {DummyDateTime.ToString("MM/dd/yyyy HH:mm")} by {DummyEditor}</td></tr></table>"),
                () => _sbDateDetailsContent.ToString().ShouldBe($"<table style='width:100%;'><tr><td><table class='fancy-col-table'><tr><td>{DummyInternalNameDateTime}</td><td>{DummyDateTime.ToString("M/d/yyyy")}</td></tr>"),
                () => _sbQuickDetailsContent.ToString().ShouldBe($"<table style='width:100%'><tr><td><table class='fancy-col-table'><tr><td>{DummyInternalNameText}</td><td></td></tr>"),
                () => _sbPeopleDetailsContent.ToString().ShouldBe($"<table style='width: 100%'><tr><td><table class='fancy-col-table'><tr><td>{DummyInternalNameUser}</td>"),
                () => _sbNarrativeDetailsContent.ToString().ShouldBe(ExpectedNarrativeStringBuilder));
        }

        [TestMethod]
        public void LoadFancyFormData_FieldPropertiesNotNullLastVersionTrueKeyNotFound_ChangeProperties()
        {
            // Arrange
            _spContext.ListGet = () => new ShimSPList()
            {
                EnableVersioningGet = () => true,
                FieldsGet = () => new ShimSPFieldCollection().Bind(
                    new SPField[]
                    {
                        _spFieldText,
                        _spFieldDateTime,
                        _spFieldUser,
                        _spFieldNote
                    }),
                RootFolderGet = () => new ShimSPFolder()
                {
                    UrlGet = () => DummyUrlRootFolder
                }
            };

            _spContext.ListItemGet = () => new ShimSPListItem()
            {
                ItemGetString = itemName =>
                {
                    switch (itemName)
                    {
                        case "Title":
                            return DummyTitle;
                        case DummyInternalNameText:
                            return DummyString;
                        case DummyInternalNameDateTime:
                            return "2018/02/02";
                        case DummyInternalNameNote:
                            return DummyNote;
                        case DummyInternalNameUser:
                            return DummyUser;
                        default:
                            break;
                    }

                    return null;
                },
                ItemGetGuid = guid =>
                {
                    if (guid == SPBuiltInFieldId.Created)
                    {
                        return DummyDateTime;
                    }
                    else if (guid == SPBuiltInFieldId.Author)
                    {
                        return DummyAuthor;
                    }
                    else if (guid == SPBuiltInFieldId.Modified)
                    {
                        return DummyDateTime;
                    }
                    else if (guid == SPBuiltInFieldId.Editor)
                    {
                        return DummyEditor;
                    }

                    return null;
                },
                VersionsGet = () => new ShimSPListItemVersionCollection()
                {
                    ItemGetInt32 = pos => _listItemVersion
                }.Bind(
                    new SPListItemVersion[]
                    {
                        _listItemVersion
                    }),
                ParentListGet = () => new ShimSPList()
                {
                    EnableVersioningGet = () => true
                },
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    ItemGetGuid = guid => new ShimSPField()
                    {
                        GetFieldValueAsHtmlObject = objectParam => objectParam.ToString()
                    }
                },
                AttachmentsGet = () => new ShimSPAttachmentCollection().Bind(
                    new[]
                    {
                        DummyFileName
                    })
            };

            ShimGridGanttSettings.ConstructorSPList = (sender, listParam) =>
            {
                var gridGantt = new ShimGridGanttSettings(sender);
                gridGantt.Instance.DisplaySettings = "#any|Display|always";
            };

            var expectedDivAttachment = new List<string>()
            {
                $"<a href='{DummyUrl}/{DummyUrlRootFolder}/attachments/0/{DummyFileName}' target='_blank' ID='{DummyFileName}' class='fancybox'>",
                $"<span>&nbsp;{DummyFileName}</span>",
                $"<a href='#' onclick=\"javascript:FancyDispFormClient.DeleteItemAttachment('{DummyUrl}/_layouts/epmlive/gridaction.aspx?action=deleteitemattachment&listid=00000000-0000-0000-0000-000000000000&itemid=0&fname={DummyFileName}');return false;\">"
            };

            // Act
            _privateObject.Invoke(LoadFancyFormDataMethodName);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => expectedDivAttachment.ForEach(c => _divAttachmentDetailsContent.InnerHtml.ShouldContain(c)),
                () => _sbItemDetailsContent.ToString().ShouldBe($"<table style='width:100%'><tr colspan='2'><td>Version: {DummyVersionLabel}</td></tr><tr colspan='2'><td>Created {DummyDateTime.ToString("MM/dd/yyyy HH:mm")} by {DummyAuthor}</td></tr><tr colspan='2'><td>Last modified {DummyDateTime.ToString("MM/dd/yyyy HH:mm")} by {DummyEditor}</td></tr></table>"),
                () => _sbDateDetailsContent.ToString().ShouldBe($"<table style='width:100%;'><tr><td><table class='fancy-col-table'><tr><td>{DummyInternalNameDateTime}</td><td>{DummyDateTime.ToString("M/d/yyyy")}</td></tr>"),
                () => _sbQuickDetailsContent.ToString().ShouldBe($"<table style='width:100%'><tr><td><table class='fancy-col-table'><tr><td>{DummyInternalNameText}</td><td></td></tr>"),
                () => _sbPeopleDetailsContent.ToString().ShouldBe($"<table style='width: 100%'><tr><td><table class='fancy-col-table'><tr><td>{DummyInternalNameUser}</td>"),
                () => _sbNarrativeDetailsContent.ToString().ShouldBe(ExpectedNarrativeStringBuilder));
        }

        [TestMethod]
        public void LoadFancyFormData_FieldPropertiesNotNullLastVersionFalseKeyNotFound_ChangeProperties()
        {
            // Arrange
            _spContext.ListGet = () => new ShimSPList()
            {
                EnableVersioningGet = () => true,
                FieldsGet = () => new ShimSPFieldCollection().Bind(
                    new SPField[]
                    {
                        _spFieldText,
                        _spFieldDateTime,
                        _spFieldUser,
                        _spFieldNote
                    }),
                RootFolderGet = () => new ShimSPFolder()
                {
                    UrlGet = () => DummyUrlRootFolder
                }
            };
            _spContext.ListItemVersionGet = () => new ShimSPListItemVersion()
            {
                VersionIdGet = () => DummyVersionId,
                VersionLabelGet = () => DummyVersionLabel
            };

            _spContext.ListItemGet = () => new ShimSPListItem()
            {
                ItemGetString = itemName =>
                {
                    switch (itemName)
                    {
                        case "Title":
                            return DummyTitle;
                        case DummyInternalNameText:
                            return DummyString;
                        case DummyInternalNameDateTime:
                            return "2018/02/02";
                        case DummyInternalNameNote:
                            return DummyNote;
                        case DummyInternalNameUser:
                            return DummyUser;
                        default:
                            break;
                    }

                    return null;
                },
                ItemGetGuid = guid =>
                {
                    if (guid == SPBuiltInFieldId.Created)
                    {
                        return DummyDateTime;
                    }
                    else if (guid == SPBuiltInFieldId.Author)
                    {
                        return DummyAuthor;
                    }
                    else if (guid == SPBuiltInFieldId.Modified)
                    {
                        return DummyDateTime;
                    }
                    else if (guid == SPBuiltInFieldId.Editor)
                    {
                        return DummyEditor;
                    }
                    else if (guid == SpFieldTextGuid)
                    {
                        return DummyInternalNameText;
                    }

                    return null;
                },
                VersionsGet = () => new ShimSPListItemVersionCollection()
                {
                    ItemGetInt32 = pos => _listItemVersion
                }.Bind(
                    new SPListItemVersion[]
                    {
                        _listItemVersion
                    }),
                ParentListGet = () => new ShimSPList()
                {
                    EnableVersioningGet = () => true
                },
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    ItemGetGuid = guid => new ShimSPField()
                    {
                        GetFieldValueAsHtmlObject = objectParam => objectParam.ToString()
                    },
                    GetFieldByInternalNameString = internalName =>
                    {
                        switch (internalName)
                        {
                            case DummyInternalNameText:
                                return _spFieldText;
                            case DummyInternalNameDateTime:
                                return _spFieldDateTime;
                            case DummyInternalNameUser:
                                return _spFieldUser;
                            case DummyInternalNameNote:
                                return _spFieldNote;
                            default:
                                break;
                        }

                        return null;
                    }
                },
                AttachmentsGet = () => new ShimSPAttachmentCollection().Bind(
                    new[]
                    {
                        DummyFileName
                    })
            };

            ShimGridGanttSettings.ConstructorSPList = (sender, listParam) =>
            {
                var gridGantt = new ShimGridGanttSettings(sender);
                gridGantt.Instance.DisplaySettings = "#any|Display|always";
            };

            ShimEditableFieldDisplay.WhereUserStringString = (condition, group) => true;
            ShimEditableFieldDisplay.RenderFieldSPFieldStringStringStringStringStringSPListItem =
                (field, where, conditionField, condition, group, valueCondition, listItem) => true;

            var expectedDivAttachment = new List<string>()
            {
                $"<a href='{DummyUrl}/{DummyUrlRootFolder}/attachments/0/{DummyFileName}' target='_blank' ID='{DummyFileName}' class='fancybox'>",
                $"<span>&nbsp;{DummyFileName}</span>",
            };

            // Act
            _privateObject.Invoke(LoadFancyFormDataMethodName);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => expectedDivAttachment.ForEach(c => _divAttachmentDetailsContent.InnerHtml.ShouldContain(c)),
                () => _sbItemDetailsContent.ToString().ShouldBe($"<table style='width:100%'><tr colspan='2'><td>Version: {DummyVersionLabel}</td></tr><tr colspan='2'><td>Created {DummyDateTime.ToString("MM/dd/yyyy HH:mm")} by {DummyAuthor}</td></tr><tr colspan='2'><td>Last modified {DummyDateTime.ToString("MM/dd/yyyy HH:mm")} by {DummyEditor}</td></tr></table>"),
                () => _sbDateDetailsContent.ToString().ShouldBe($"<table style='width:100%;'><tr><td><table class='fancy-col-table'><tr><td>{DummyInternalNameDateTime}</td><td>{DummyDateTime.ToString("M/d/yyyy")}</td></tr>"),
                () => _sbQuickDetailsContent.ToString().ShouldBe($"<table style='width:100%'><tr><td><table class='fancy-col-table'><tr><td>{DummyInternalNameText}</td><td></td></tr>"),
                () => _sbPeopleDetailsContent.ToString().ShouldBe($"<table style='width: 100%'><tr><td><table class='fancy-col-table'><tr><td>{DummyInternalNameUser}</td>"),
                () => _sbNarrativeDetailsContent.ToString().ShouldBe(ExpectedNarrativeStringBuilder));
        }
    }
}
