using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.HtmlControls;
using System.Web.UI.HtmlControls.Fakes;
using System.Web.UI.WebControls;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public partial class FancyDisplayFormTests
    {
        private IDisposable _shimContext;
        private FancyDisplayForm _testEntity;
        private PrivateObject _privateObject;
        private ShimHttpRequest _request;
        private ShimSPContext _spContext;

        private const string PageLoadMethodName = "Page_Load";
        private const string BtnCancelClickMethodName = "btnCancel_Click";
        private const string LoadFancyFormDataMethodName = "LoadFancyFormData";
        private const string FillDateDetailsSectionMethodName = "FillDateDetailsSection";
        private const string FillPeopleDetailsSectionMethodName = "FillPeopleDetailsSection";
        private const string FillNarrativeDetailsSectionMethodName = "FillNarrativeDetailsSection";
        private const string FillQuickDetailsSectionMethodName = "FillQuickDetailsSection";
        private const string ManageHtmlOpeningClosingMethodName = "ManageHTMLOpeningClosing";
        private const string ShowHideDivsMethodName = "ShowHideDivs";
        private const string LoadAssociatedItemsMethodName = "LoadAssociatedItems";
        private const string OnPreRenderMethodName = "OnPreRender";
        private const string CreateChildControlsMethodName = "CreateChildControls";
        private const string RenderMethodName = "Render";

        private HtmlGenericControl _divFancyDispFormAssociatedItemsContent;
        private HtmlGenericControl _divQuickDetailsContent;
        private HtmlGenericControl _divShowQuickDetailsHeader;
        private HtmlGenericControl _divShowQuickDetailsContent;
        private HtmlGenericControl _divNarrativeDetailsContent;
        private HtmlGenericControl _divShowNarrativeDetailsHeader;
        private HtmlGenericControl _divShowNarrativeDetailsContent;
        private HtmlGenericControl _divPeopleContent;
        private HtmlGenericControl _divPeopleShowAllHeader;
        private HtmlGenericControl _divPeopleShowAllContent;
        private HtmlGenericControl _divDatesContent;
        private HtmlGenericControl _divDatesShowAllHeader;
        private HtmlGenericControl _divItemDetailParent;
        private HtmlGenericControl _divAttachmentDetails;
        private HtmlGenericControl _divAttachmentDetailsContent;
        private HtmlGenericControl _divDatesShowAllContent;
        private HtmlTableCell _divQuickDetailsParent;
        private HtmlTableCell _divNarrativeDetailsParent;
        private HtmlTableCell _divPeopleDetailsParent;
        private HtmlTableCell _divDateDetailsParent;
        private HtmlTableCell _divFancyDispFormParent;
        private Button _btnCancel1;
        private Button _btnCancel2;
        private HtmlInputHidden _hiddenListId;
        private HtmlInputHidden _hiddenItemId;
        private HtmlInputHidden _hiddenSourceUrl;
        private HtmlInputHidden _hiddenWebUrl;
        private StringBuilder _sbItemDetailsContent;
        private StringBuilder _sbDateDetailsContent;
        private StringBuilder _sbQuickDetailsContent;
        private StringBuilder _sbPeopleDetailsContent;
        private StringBuilder _sbNarrativeDetailsContent;
        private StringBuilder _sbDateDetailsShowAllRegion;
        private StringBuilder _sbPeopleDetailsShowAllRegion;
        private StringBuilder _sbNarrativeDetailsShowAllRegion;
        private StringBuilder _sbQuickDetailsShowAllRegion;
        private const string DivFancyDispFormAssociatedItemsContentFieldName = "divFancyDispFormAssociatedItemsContent";
        private const string DivQuickDetailsContentFieldName = "divQuickDetailsContent";
        private const string DivShowQuickDetailsHeaderFieldName = "divShowQuickDetailsHeader";
        private const string DivShowQuickDetailsContentFieldName = "divShowQuickDetailsContent";
        private const string DivNarrativeDetailsContentFieldName = "divNarrativeDetailsContent";
        private const string DivShowNarrativeDetailsHeaderFieldName = "divShowNarrativeDetailsHeader";
        private const string DivShowNarrativeDetailsContentFieldName = "divShowNarrativeDetailsContent";
        private const string DivPeopleContentFieldName = "divPeopleContent";
        private const string DivPeopleShowAllHeaderFieldName = "divPeopleShowAllHeader";
        private const string DivPeopleShowAllContentFieldName = "divPeopleShowAllContent";
        private const string DivDatesContentFieldName = "divDatesContent";
        private const string DivDatesShowAllHeaderFieldName = "divDatesShowAllHeader";
        private const string DivItemDetailParentFieldName = "divItemDetailParent";
        private const string DivDatesShowAllContentFieldName = "divDatesShowAllContent";
        private const string DivAttachmentDetailsFieldName = "divAttachmentDetails";
        private const string DivAttachmentDetailsContentFieldName = "divAttachmentDetailsContent";
        private const string DivQuickDetailsParentFieldName = "divQuickDetailsParent";
        private const string DivNarrativeDetailsParentFieldName = "divNarrativeDetailsParent";
        private const string DivPeopleDetailsParentFieldName = "divPeopleDetailsParent";
        private const string DivDateDetailsParentFieldName = "divDateDetailsParent";
        private const string DivFancyDispFormParentFieldName = "divFancyDispFormParent";
        private const string BtnCancel1FieldName = "btnCancel1";
        private const string BtnCancel2FieldName = "btnCancel2";
        private const string HiddenListIdFieldName = "hiddenListId";
        private const string HiddenItemIdFieldName = "hiddenItemId";
        private const string HiddenSourceUrlFieldName = "hiddenSourceUrl";
        private const string HiddenWebUrlFieldName = "hiddenWebUrl";
        private const string SbItemDetailsContentFieldName = "sbItemDetailsContent";
        private const string SbDateDetailsContentFieldName = "sbDateDetailsContent";
        private const string SbQuickDetailsContentFieldName = "sbQuickDetailsContent";
        private const string SbPeopleDetailsContentFieldName = "sbPeopleDetailsContent";
        private const string SbNarrativeDetailsContentFieldName = "sbNarrativeDetailsContent";
        private const string SbDateDetailsShowAllRegionFieldName = "sbDateDetailsShowAllRegion";
        private const string DatesDetailsFieldsCountFieldName = "datesDetailsFieldsCount";
        private const string PeopleDetailsFieldsCountFieldName = "peopleDetailsFieldsCount";
        private const string SbPeopleDetailsShowAllRegionFieldName = "sbPeopleDetailsShowAllRegion";
        private const string NarrativeDetailsFieldsCountFieldName = "narrativeDetailsFieldsCount";
        private const string SbNarrativeDetailsShowAllRegionFieldName = "sbNarrativeDetailsShowAllRegion";
        private const string IsLatestVersionFieldName = "isLatestVersion";
        private const string SbQuickDetailsShowAllRegionFieldName = "sbQuickDetailsShowAllRegion";
        private const string QuickDetailsFieldsCountFieldName = "quickDetailsFieldsCount";

        private IList<string> _actualResponseWrite;
        private string _actualResponseRedirectUrl;
        private bool _actualResponseFlush;
        private bool _actualResponseEnd;

        private const int DummyVersionId = 100;
        private const int DummyVersionIdBigger = 101;
        private const int DummyLookupId = 110;
        private const int DummyId1 = 200;
        private const int DummyId2 = 210;
        private const int DummyId3 = 220;
        private const string DummyString = "DummyString";
        private const string DummyViewUrl = "http://tempuri.org/View";
        private const string DummyUrl = "http://tempuri.org";
        private const string DummyUrl2 = "http://tempuri.org2";
        private const string DummyTitle = "DummyTitle";
        private const string DummyItemId = "7";
        private const string DummyInternalNameText = "DummyInternalNameText";
        private const string DummyInternalNameDateTime = "DummyInternalNameDateTime";
        private const string DummyInternalNameUser = "DummyInternalNameUser";
        private const string DummyInternalNameNote = "DummyInternalNameNote";
        private const string DummyVersionLabel = "DummyVersionLabel";
        private const string DummyFileName = "DummyFileName";
        private const string DummyUrlRootFolder = "DummyUrlRootFolder";
        private const string DummyUser = "DummyUser";
        private const string DummyNote = "DummyNote";
        private const string DummyAuthor = "DummyAuthor";
        private const string DummyEditor = "DummyEditor";
        private const string DummyUserName = "DummyUserName";
        private const string DummyFieldName = "DummyFieldName";
        private const string DummyFieldValue = "DummyFieldValue";
        private const string DummyUserTitle1 = "DummyUserTitle1";
        private const string DummyUserTitle2 = "DummyUserTitle2";
        private const string DummyUserTitle3 = "DummyUserTitle3";
        private const string DummyUserPictureWithComma = "http://dummypicture.org/pic2.png, anything";
        private const string DummyUserPictureWithoutComma = "http://dummypicture.org/pic.png";
        private const string DueComplete = "Completed";
        private const string DaysOverDue = "17";
        private const string ScheduleStatus = "checkmark.gif";
        private const string PicturePng = "checkmark.png";
        private static readonly Guid SpFieldTextGuid = Guid.NewGuid();
        private static readonly Guid SpFieldDateTimeGuid = Guid.NewGuid();
        private static readonly Guid SpFieldUserGuid = Guid.NewGuid();
        private static readonly Guid SpFieldNoteGuid = Guid.NewGuid();
        private static readonly Guid DummyListId = Guid.NewGuid();
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private static readonly DateTime DummyDateTime = new DateTime(2018, 2, 2);
        private static readonly DateTime DummyDateTimeCreated = new DateTime(2017, 2, 2);
        private ShimSPField _spFieldText;
        private ShimSPField _spFieldDateTime;
        private ShimSPField _spFieldUser;
        private ShimSPField _spFieldNote;
        private ShimSPListItemVersion _listItemVersion;
        private SPControlMode _actualControlMode;

        private const string ExpectedDefaultEmptyTable = "</table></td></tr></table>";
        private const string ExpectedNarrativeStringBuilder = "<table style='width:100%;'><tr><td><table class='fancy-col-table'><tr><td>DummyInternalNameNote</td><td style='width:auto;'><div><div><span class=\"ms-noWrap\"><span class=\"ms-spimn-presenceLink\"><span class=\"ms-spimn-presenceWrapper ms-imnImg ms-spimn-imgSize-10x10\"><img class=\"ms-spimn-img ms-spimn-presence-disconnected-10x10x32\" src=\"/_layouts/15/images/spimn.png?rev=23\" alt=\"\"></span></span><span class=\"ms-noWrap ms-imnSpan\"><span class=\"ms-spimn-presenceLink\"><img class=\"ms-hide\" src=\"/_layouts/15/images/blank.gif?rev = 23\" alt=\"\"></span><a class=\"ms-subtleLink\" onclick=\"GoToLinkOrDialogNewWindow(this); return false;\" href=http://tempuri.org/_layouts/15/userdisp.aspx?ID0>DummyUserName</a></span></span> (2/2/2017 12:00:00 AM): DummyNote</div></div></td></tr>";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            _testEntity = new FancyDisplayForm();
            _privateObject = new PrivateObject(_testEntity);

            _request = new ShimHttpRequest()
            {
                ItemGetString = itemName =>
                {
                    if (itemName == "ID")
                    {
                        return DummyItemId;
                    }

                    return null;
                }
            };
            ShimPage.AllInstances.RequestGet = sender => _request;
            ShimPage.AllInstances.ResponseGet = sender => new ShimHttpResponse();

            _actualResponseWrite = new List<string>();
            ShimHttpResponse.AllInstances.WriteString = (sender, writeParam) => _actualResponseWrite.Add(writeParam);
            ShimHttpResponse.AllInstances.Flush = sender => _actualResponseFlush = true;
            ShimHttpResponse.AllInstances.End = sender => _actualResponseEnd = true;
            ShimHttpResponse.AllInstances.RedirectString = (sender, url) => _actualResponseRedirectUrl = url;

            _spContext = new ShimSPContext()
            {
                ListGet = () => new ShimSPList()
                {
                    IDGet = () => DummyGuid,
                    DefaultViewUrlGet = () => DummyViewUrl
                },
                WebGet = () => new ShimSPWeb()
                {
                    UrlGet = () => DummyUrl,
                    CurrentUserGet = () => new ShimSPUser()
                    {
                        RegionalSettingsGet = () => new ShimSPRegionalSettings()
                        {
                            LocaleIdGet = () => 1033
                        }
                    }
                },
                FormContextGet = () => new ShimSPFormContext()
                {
                    FormModeSetSPControlMode = controlMode => _actualControlMode = controlMode
                }
            };

            ShimSPContext.CurrentGet = () => _spContext;

            ShimScriptManager.GetCurrentPage = pageParam => new ShimScriptManager()
            {
                ServicesGet = () => new ServiceReferenceCollection()
            };

            ShimControl.AllInstances.PageGet = sender => new ShimPage();
            ShimHttpContext.CurrentGet = () => new ShimHttpContext()
            {
                RequestGet = () => _request,
                ResponseGet = () => new ShimHttpResponse()
            };

            _privateObject.Invoke("OnInit", EventArgs.Empty);

            _spFieldText = new ShimSPField()
            {
                IdGet = () => SpFieldTextGuid,
                HiddenGet = () => false,
                InternalNameGet = () => DummyInternalNameText,
                TitleGet = () => DummyInternalNameText,
                TypeGet = () => SPFieldType.Text,
                GetFieldValueAsTextObject = fieldValue => fieldValue.ToString()
            };

            _spFieldDateTime = new ShimSPField()
            {
                IdGet = () => SpFieldDateTimeGuid,
                HiddenGet = () => false,
                InternalNameGet = () => DummyInternalNameDateTime,
                TitleGet = () => DummyInternalNameDateTime,
                TypeGet = () => SPFieldType.DateTime,
                ParentListGet = () => new ShimSPList()
                {
                    EnableVersioningGet = () => true
                }
            };
            _spFieldUser = new ShimSPField()
            {
                IdGet = () => SpFieldUserGuid,
                HiddenGet = () => false,
                InternalNameGet = () => DummyInternalNameUser,
                TitleGet = () => DummyInternalNameUser,
                TypeGet = () => SPFieldType.User,
                ParentListGet = () => new ShimSPList()
                {
                    EnableVersioningGet = () => true
                }
            };
            _spFieldNote = new ShimSPField(
                new ShimSPFieldMultiLineText()
                {
                    AppendOnlyGet = () => true
                })
            {
                IdGet = () => SpFieldNoteGuid,
                HiddenGet = () => false,
                InternalNameGet = () => DummyInternalNameNote,
                TitleGet = () => DummyInternalNameNote,
                TypeGet = () => SPFieldType.Note,
                ParentListGet = () => new ShimSPList()
                {
                    EnableVersioningGet = () => true
                }
            };

            var createdBy = new ShimSPFieldUserValue()
            {
                UserGet = () => new ShimSPUser()
                {
                    NameGet = () => DummyUserName
                }
            };
            createdBy.Instance.LookupId = DummyLookupId;

            _listItemVersion = new ShimSPListItemVersion()
            {
                VersionIdGet = () => DummyVersionId,
                ItemGetString = itemName =>
                {
                    switch (itemName)
                    {
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
                VersionLabelGet = () => DummyVersionLabel,
                CreatedByGet = () => createdBy,
                CreatedGet = () => DummyDateTimeCreated
            };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _testEntity?.Dispose();
            _shimContext?.Dispose();
        }

        [TestMethod]
        public void OnPreRender_Should_ChangeFormMode()
        {
            // Arrange
            var actualCountRegisterScriptFile = 0;

            ShimSPPageContentManager.RegisterScriptFilePageStringBooleanBooleanStringString =
                (page, name, localizable, defer, language, uiVersion) => actualCountRegisterScriptFile++;

            // Act
            _privateObject.Invoke(OnPreRenderMethodName, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualCountRegisterScriptFile.ShouldBe(1),
                () => _actualControlMode.ShouldBe(SPControlMode.Display));
        }

        [TestMethod]
        public void CreateChildControls_ScriptManagerNull_CreateNewScriptManagerAddedOnControl()
        {
            // Arrange
            var actualAddedControl = false;
            ShimScriptManager.GetCurrentPage = pageParam => null;

            ShimControl.AllInstances.ControlsGet = sender => new ShimControlCollection()
            {
                AddControl = control => actualAddedControl = true
            };
            ShimControl.AllInstances.PageGet = sender => new ShimPage()
            {
                FormGet = () => new ShimHtmlForm()
            };

            // Act
            _privateObject.Invoke(CreateChildControlsMethodName);

            // Assert
            actualAddedControl.ShouldBeTrue();
        }

        [TestMethod]
        public void Render_Should_WriteHtmltextWriter()
        {
            // Arrange
            ShimListCommands.GetAssociatedListsSPList = listParam => new ArrayList()
            {
                new AssociatedListInfo()
                {
                    Title = DummyTitle,
                    ListId = DummyListId
                }
            };

            var actualCountRenderControl = 0;
            var stringBuilder = new StringBuilder();
            var writer = new ShimHtmlTextWriter
            {
                WriteString = content => stringBuilder.Append(content)
            };

            ShimControl.AllInstances.RenderControlHtmlTextWriter = (sender, writerParam) => actualCountRenderControl++;

            var expectedWriter = new List<string>()
            {
                $"url: $(\"#hiddenWebUrl\").val() + \"/_layouts/epmlive/AttachFileMulti.aspx?ListId=\" + $(\"#hiddenListId\").val() + \"&ItemId=\" + $(\"#hiddenItemId\").val() + \"&isdlg=1&Source=\" + $(\"#hiddenSourceUrl\").val(),",
                $"var viewSiteContentUrl = $(\"#hiddenWebUrl\").val() + \"/_layouts/epmlive/gridaction.aspx?action=deleteitemattachment&listid=\" + listInfo[0] + \"&itemid=\" + listInfo[1] + \"&fname=\" + listInfo[2] + \"&Source=\" + document.location.href;",
                $"url: \"http://tempuri.org/_vti_bin/WorkEngine.asmx/Execute\",",
                "data: \"{Function : 'GetFancyFormAssociatedItemAttachments' , Dataxml: '<FancyFormAssociatedItemAttachments><FancyFormListID></FancyFormListID><FancyFormItemID></FancyFormItemID></FancyFormAssociatedItemAttachments>'}\",",
            };

            _privateObject.Invoke(PageLoadMethodName, this, EventArgs.Empty);

            // Act
            _privateObject.Invoke(RenderMethodName, writer.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualCountRenderControl.ShouldBe(5));
        }

        [TestMethod]
        public void PageLoad_itemIdNotNullOrEmpty_ChangeProperties()
        {
            // Arrange
            ShimListCommands.GetAssociatedListsSPList = listParam => new ArrayList()
            {
                new AssociatedListInfo()
                {
                    Title = DummyTitle,
                    ListId = DummyListId
                }
            };

            var expectedContentFromDiv = new List<string>()
            {
                $"<td>{DummyTitle}</td>",
                $"<div id='div_{DummyListId}' class='listMainDiv'><span class='badge'>0</span>"
            };

            // Act
            _privateObject.Invoke(PageLoadMethodName, this, EventArgs.Empty);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => expectedContentFromDiv.ForEach(c => _divFancyDispFormAssociatedItemsContent.InnerHtml.ShouldContain(c)),
                () => _divFancyDispFormAssociatedItemsContent.Visible.ShouldBeTrue(),
                () => _divQuickDetailsContent.Visible.ShouldBeFalse(),
                () => _divShowQuickDetailsHeader.Visible.ShouldBeFalse(),
                () => _divNarrativeDetailsContent.Visible.ShouldBeFalse(),
                () => _divShowNarrativeDetailsHeader.Visible.ShouldBeFalse(),
                () => _divPeopleContent.Visible.ShouldBeFalse(),
                () => _divPeopleShowAllHeader.Visible.ShouldBeFalse(),
                () => _divDatesContent.Visible.ShouldBeFalse(),
                () => _divDatesShowAllHeader.Visible.ShouldBeFalse(),
                () => _divItemDetailParent.InnerHtml.ShouldBe(string.Empty),
                () => _divQuickDetailsParent.Visible.ShouldBeFalse(),
                () => _divNarrativeDetailsParent.Visible.ShouldBeFalse(),
                () => _divPeopleDetailsParent.Visible.ShouldBeFalse(),
                () => _divDateDetailsParent.Visible.ShouldBeFalse(),
                () => _btnCancel1.Visible.ShouldBeTrue(),
                () => _btnCancel2.Visible.ShouldBeTrue(),
                () => _hiddenListId.Value.ShouldBe(DummyGuid.ToString()),
                () => _hiddenItemId.Value.ShouldBe(DummyItemId),
                () => _hiddenSourceUrl.Value.ShouldBe(DummyViewUrl),
                () => _hiddenWebUrl.Value.ShouldBe(DummyUrl));
        }

        [TestMethod]
        public void PageLoad_itemIdNotNull_ChangeProperties()
        {
            // Arrange
            _request.ItemGetString = itemName => null;

            ShimListCommands.GetAssociatedListsSPList = listParam => new ArrayList()
            {
                new AssociatedListInfo()
                {
                    Title = DummyTitle,
                    ListId = DummyListId
                }
            };

            // Act
            _privateObject.Invoke(PageLoadMethodName, this, EventArgs.Empty);

            // Assert
            LoadFieldValues();

            this.ShouldSatisfyAllConditions(
                () => _divFancyDispFormAssociatedItemsContent.Visible.ShouldBeFalse(),
                () => _btnCancel1.Visible.ShouldBeFalse(),
                () => _btnCancel2.Visible.ShouldBeFalse(),
                () => _hiddenListId.Value.ShouldBe(string.Empty),
                () => _hiddenItemId.Value.ShouldBe(string.Empty),
                () => _hiddenSourceUrl.Value.ShouldBe(string.Empty),
                () => _hiddenWebUrl.Value.ShouldBe(string.Empty));
        }

        [TestMethod]
        public void BtnCancelClick_IsDlgNotNull_FillResponse()
        {
            // Arrange
            _request.QueryStringGet = () => new NameValueCollection
            {
                ["IsDlg"] = DummyString
            };

            // Act
            _privateObject.Invoke(BtnCancelClickMethodName, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _actualResponseWrite.ShouldContain("<script type='text/javascript'>window.frameElement.commitPopup()</script>"),
                () => _actualResponseFlush.ShouldBeTrue(),
                () => _actualResponseEnd.ShouldBeTrue());
        }

        [TestMethod]
        public void BtnCancelClick_IsDlgNullSourceNull_Redirect()
        {
            // Arrange
            _request.QueryStringGet = () => new NameValueCollection
            {
                ["IsDlg"] = null,
                ["Source"] = null
            };

            // Act
            _privateObject.Invoke(BtnCancelClickMethodName, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _actualResponseRedirectUrl.ShouldBe(DummyUrl),
                () => _actualResponseWrite.ShouldBeEmpty(),
                () => _actualResponseFlush.ShouldBeFalse(),
                () => _actualResponseEnd.ShouldBeFalse());
        }

        [TestMethod]
        public void BtnCancelClick_IsDlgNullSourceNotNull_Redirect()
        {
            // Arrange
            _request.QueryStringGet = () => new NameValueCollection
            {
                ["IsDlg"] = null,
                ["Source"] = DummyString
            };
            _request.ItemGetString = itemName => DummyUrl2;

            // Act
            _privateObject.Invoke(BtnCancelClickMethodName, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _actualResponseRedirectUrl.ShouldBe(DummyUrl2),
                () => _actualResponseWrite.ShouldBeEmpty(),
                () => _actualResponseFlush.ShouldBeFalse(),
                () => _actualResponseEnd.ShouldBeFalse());
        }

        [TestMethod]
        public void LoadAssociatedItems_EmptyAssociatedList_ChangeProperties()
        {
            // Arrange
            ShimListCommands.GetAssociatedListsSPList = listItem => new ArrayList();

            // Act
            _privateObject.Invoke(LoadAssociatedItemsMethodName);

            // Assert
            LoadFieldValues();

            _divFancyDispFormParent.Visible.ShouldBeFalse();
        }

        private void LoadFieldValues()
        {
            _divFancyDispFormAssociatedItemsContent = (HtmlGenericControl)_privateObject.GetField(DivFancyDispFormAssociatedItemsContentFieldName);
            _divQuickDetailsContent = (HtmlGenericControl)_privateObject.GetField(DivQuickDetailsContentFieldName);
            _divShowQuickDetailsHeader = (HtmlGenericControl)_privateObject.GetField(DivShowQuickDetailsHeaderFieldName);
            _divShowQuickDetailsContent = (HtmlGenericControl)_privateObject.GetField(DivShowQuickDetailsContentFieldName);
            _divNarrativeDetailsContent = (HtmlGenericControl)_privateObject.GetField(DivNarrativeDetailsContentFieldName);
            _divShowNarrativeDetailsHeader = (HtmlGenericControl)_privateObject.GetField(DivShowNarrativeDetailsHeaderFieldName);
            _divShowNarrativeDetailsContent = (HtmlGenericControl)_privateObject.GetField(DivShowNarrativeDetailsContentFieldName);
            _divPeopleContent = (HtmlGenericControl)_privateObject.GetField(DivPeopleContentFieldName);
            _divPeopleShowAllHeader = (HtmlGenericControl)_privateObject.GetField(DivPeopleShowAllHeaderFieldName);
            _divPeopleShowAllContent = (HtmlGenericControl)_privateObject.GetField(DivPeopleShowAllContentFieldName);
            _divDatesContent = (HtmlGenericControl)_privateObject.GetField(DivDatesContentFieldName);
            _divDatesShowAllHeader = (HtmlGenericControl)_privateObject.GetField(DivDatesShowAllHeaderFieldName);
            _divItemDetailParent = (HtmlGenericControl)_privateObject.GetField(DivItemDetailParentFieldName);
            _divDatesShowAllContent = (HtmlGenericControl)_privateObject.GetField(DivDatesShowAllContentFieldName);
            _divQuickDetailsParent = (HtmlTableCell)_privateObject.GetField(DivQuickDetailsParentFieldName);
            _divNarrativeDetailsParent = (HtmlTableCell)_privateObject.GetField(DivNarrativeDetailsParentFieldName);
            _divPeopleDetailsParent = (HtmlTableCell)_privateObject.GetField(DivPeopleDetailsParentFieldName);
            _divDateDetailsParent = (HtmlTableCell)_privateObject.GetField(DivDateDetailsParentFieldName);
            _divFancyDispFormParent = (HtmlTableCell)_privateObject.GetField(DivFancyDispFormParentFieldName);
            _btnCancel1 = (Button)_privateObject.GetField(BtnCancel1FieldName);
            _btnCancel2 = (Button)_privateObject.GetField(BtnCancel2FieldName);
            _hiddenListId = (HtmlInputHidden)_privateObject.GetField(HiddenListIdFieldName);
            _hiddenItemId = (HtmlInputHidden)_privateObject.GetField(HiddenItemIdFieldName);
            _hiddenSourceUrl = (HtmlInputHidden)_privateObject.GetField(HiddenSourceUrlFieldName);
            _hiddenWebUrl = (HtmlInputHidden)_privateObject.GetField(HiddenWebUrlFieldName);
            _divAttachmentDetails = (HtmlGenericControl)_privateObject.GetField(DivAttachmentDetailsFieldName);
            _divAttachmentDetailsContent = (HtmlGenericControl)_privateObject.GetField(DivAttachmentDetailsContentFieldName);
            _sbItemDetailsContent = (StringBuilder)_privateObject.GetField(SbItemDetailsContentFieldName);
            _sbDateDetailsContent = (StringBuilder)_privateObject.GetField(SbDateDetailsContentFieldName);
            _sbQuickDetailsContent = (StringBuilder)_privateObject.GetField(SbQuickDetailsContentFieldName);
            _sbPeopleDetailsContent = (StringBuilder)_privateObject.GetField(SbPeopleDetailsContentFieldName);
            _sbNarrativeDetailsContent = (StringBuilder)_privateObject.GetField(SbNarrativeDetailsContentFieldName);
            _sbDateDetailsShowAllRegion = (StringBuilder)_privateObject.GetField(SbDateDetailsShowAllRegionFieldName);
            _sbPeopleDetailsShowAllRegion = (StringBuilder)_privateObject.GetField(SbPeopleDetailsShowAllRegionFieldName);
            _sbNarrativeDetailsShowAllRegion = (StringBuilder)_privateObject.GetField(SbNarrativeDetailsShowAllRegionFieldName);
            _sbQuickDetailsShowAllRegion = (StringBuilder)_privateObject.GetField(SbQuickDetailsShowAllRegionFieldName);
        }
    }
}
