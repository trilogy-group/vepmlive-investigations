using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic.Fakes;
using System.Collections.Specialized;
using System.Globalization;
using System.Xml;
using EPMLive.TestFakes.Utility;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveWebParts.Tests.WebPageCode
{
    public partial class GetGanttTasksTests
    {
        private IDisposable _shimContext;
        private SharepointShims _sharepointShims;
        private AdoShims _adoShims;
        private getgantttasks _getGanttTasks;
        private PrivateObject _getGanttTasksPrivate;
        private XmlDocument _xmlDocument;
        private XmlNode _newItemNode;
        private bool _usepopup;
        private string _wbs;
        private string _isMilestone;
        private Hashtable _hshItemNodes;
        private bool _didAddItemFromList;
        private bool _didAddItemFromDataRow;
        private bool _didAddGroups;
        private const string One = "1";
        private const string DummyVal = "DummyVal";
        private const string DummyText = "DummyText";
        private const string DummyFieldName = "DummyFieldName";
        private const string DummyString = "DummyString";
        private const string FieldTitle = "Title";
        private const string ExampleUrl = "http://www.example.com";
        private const string TypeTextXml = "text/xml";
        private const string TypeTextPlain = "text/plain";
        private const string IgnoreListId = "ignorelistid";
        private const string PageLoadMethodName = "Page_Load";
        private const string MethodAddItems = "addItems";
        private const string MethodGetField = "getField";
        private const string MethodAddItem = "addItem";
        private const string DummyListId = "DummyListId";
        private const string WorkspaceUrlView = "WorkspaceUrl";
        private const string DefaultErrorMessage = "DefaultErrorMessage";
        private const string FieldRollupLists = "rolluplists";
        private const string FieldGlobalError = "globalError";
        private const string FieldUsePerformance = "usePerformance";
        private const string FieldFilterField = "filterfield";
        private const string MethodAddGroups = "addGroups";
        private const string MethodSetAggVal = "setAggVal";
        private const string MethodCreateLinks = "createLinks";
        private const string MethodAddHeader = "addHeader";
        private const string FieldMainParent = "ndMainParent";
        private const string TitleSPField = "Title";
        private const string RootXml = "<root></root>";
        private const string FormatDateOnly = "Format='DateOnly'";
        private const string FormatTwoDecimals = "Decimals=\"2\"";
        private const string FormatTwoDecimalsPercentage = "Decimals=\"2\" Percentage=\"TRUE\"";
        private const string TypeText = "Text";
        private const string TypeCurrency = "Currency";
        private const string TypeDateTime = "DateTime";
        private const string TypeNumber = "Number";
        private const string TypeDefault = "Default";
        private const string TypeLookupMulti = "LookupMulti";
        private const string TypeComputed = "Computed";
        private const string TypeTotalRollup = "TotalRollup";
        private const string TypeInvalid = "Invalid";
        private const string MethodFormatField = "formatField";
        private static readonly Guid DefaultWebId = Guid.NewGuid();
        private static readonly Guid DefaultListId = Guid.NewGuid();
        private static readonly Guid DefaultId = Guid.NewGuid();
        private readonly static string NewKey = $"{DummyText}\n{DummyString}";

        [TestInitialize]
        public void Setup()
        {
            _shimContext = ShimsContext.Create();

            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();

            _getGanttTasks = new getgantttasks();
            _getGanttTasksPrivate = new PrivateObject(_getGanttTasks);

            _newItemNode = null;
            _hshItemNodes = null;
            _wbs = DummyVal;
            _usepopup = false;
            _isMilestone = "False";
            _didAddItemFromList = false;
            _didAddItemFromDataRow = false;
            _didAddGroups = false;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        private void PrepareSpListRelatedShims(string listId = null)
        {
            ShimSPListCollection.AllInstances.ItemGetString = (_, key) =>
            {
                switch (key)
                {
                    case "Project Schedules":
                        return new ShimSPDocumentLibrary().Instance;
                    default:
                        return new ShimSPList();
                }
            };
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, __) => new ShimSPList();
            ShimSPListItem.AllInstances.IDGet = _ => 1;
            ShimSPListItem.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPListItem.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPListItem.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPListItem.AllInstances.ContentTypeGet = _ => new ShimSPContentType { NameGet = () => TypeTextXml };
            ShimSPListItem.AllInstances.XmlGet = _ => "<root ows_FileDirRef='ows_FileDirRef' ows_DocIcon='ows_DocIcon' ows_BaseName='ows_BaseName' ows_ContentTypeId='ows_ContentTypeId' ows_PermMask='ows_PermMask'></root>";
            ShimSPListItem.AllInstances.ItemGetString = (_, key) =>
            {
                switch (key)
                {
                    case "Created":
                        return DateTime.Today.ToString();
                    case "CommentCount":
                        return 2;
                    default:
                        return DummyVal;
                }
            };
            ShimSPListItem.AllInstances.ItemGetGuid = (_, __) => DummyVal;

            var listGuid = listId == null ? DefaultListId : new Guid(listId);
            ShimSPList.AllInstances.IDGet = _ => listGuid;
            ShimSPList.AllInstances.TitleGet = _ => DummyVal;
            ShimSPList.AllInstances.ImageUrlGet = _ => $"image.png";
            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb();
            ShimSPList.AllInstances.ContentTypesGet = _ => new ShimSPContentTypeCollection();
            ShimSPList.AllInstances.FormsGet = _ => new ShimSPFormCollection();
            ShimSPList.AllInstances.DefaultViewGet = _ => new ShimSPView();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPList.AllInstances.EnableVersioningGet = _ => true;
            ShimSPList.AllInstances.EnableModerationGet = _ => true;
            ShimSPList.AllInstances.ViewsGet = _ => new ShimSPViewCollection { ItemGetGuid = __ => new ShimSPView() };
            ShimSPList.AllInstances.ItemsGet = _ => new ShimSPListItemCollection();
            ShimSPList.AllInstances.RootFolderGet = _ => new ShimSPFolder();
            ShimSPFolder.AllInstances.NameGet = _ => "Project Center";

            ShimSPListItemCollection.AllInstances.Add = _ => new ShimSPListItem();
            var itemCollection = new ShimSPListItemCollection();
            itemCollection.Bind(new List<SPListItem>
            {
                new ShimSPListItem()
            });
            ShimSPList.AllInstances.GetItemsSPQuery = (_, __) => itemCollection.Instance;
            ShimSPList.AllInstances.GetItemsSPView = (_, __) => itemCollection.Instance;
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, __) => new ShimSPListItem();
        }

        private void PrepareSpFieldRelatedShims(string internalname, SPFieldType fieldType)
        {
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            ShimSPFieldCollection.AllInstances.ContainsFieldWithStaticNameString = (_, __) => true;
            ShimSPFieldCollection.AllInstances.ItemGetGuid = (_, __) => new ShimSPField();

            var fieldId = Guid.NewGuid();
            ShimSPField.AllInstances.IdGet = _ => fieldId;
            ShimSPField.AllInstances.InternalNameGet = _ => internalname;
            ShimSPField.AllInstances.TypeAsStringGet = _ => internalname;
            ShimSPField.AllInstances.TypeGet = _ => fieldType;
            ShimSPField.AllInstances.ReadOnlyFieldGet = _ => false;
            ShimSPField.AllInstances.ShowInEditFormGet = _ => true;
            ShimSPField.AllInstances.SchemaXmlGet = _ => "<root>1</root>";
            ShimSPField.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPField.AllInstances.TitleGet = _ => DummyText;
            ShimSPField.AllInstances.GetFieldValueString = (_, __) => DummyVal;
            ShimSPField.AllInstances.GetFieldValueAsTextObject = (_, __) => DummyVal;
            ShimSPField.AllInstances.GetFieldValueAsHtmlObject = (_, val) => val as string;
            ShimSPFieldLookupValue.ConstructorString = (_, __) => { };
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => 1;
            ShimSPFieldLookupValue.AllInstances.LookupValueGet = _ => DummyVal;
            ShimSPFieldLookupValueCollection.ConstructorString = (instance, _) =>
            {
                var shimFields = new ShimSPFieldLookupValueCollection(instance);
                var list = new List<SPFieldLookupValue> { new ShimSPFieldLookupValue().Instance };
                shimFields.Bind(list as IList<SPFieldLookupValue>);
                var enumerator = list.GetEnumerator();
                ShimList<SPFieldLookupValue>.AllInstances.GetEnumerator = x => enumerator;
            };
            ShimSPFieldUserValue.ConstructorSPWebString = (a, b, c) => { };
            ShimSPFieldUserValue.AllInstances.LookupValueGet = _ => DummyText;
            ShimSPFieldUserValue.AllInstances.UserGet = _ => new ShimSPUser();
            ShimSPFieldUserValueCollection.ConstructorSPWebString = (instance, _, __) =>
            {
                var shimFields = new ShimSPFieldUserValueCollection(instance);
                var list = new List<SPFieldUserValue> { new ShimSPFieldUserValue().Instance };
                shimFields.Bind(list as IList<SPFieldUserValue>);
                var enumerator = list.GetEnumerator();
                ShimList<SPFieldUserValue>.AllInstances.GetEnumerator = x => enumerator;
            };
        }

        private void PrepareSpWebRelatedShims(string webId = null)
        {
            var webGuid = webId == null ? DefaultWebId : new Guid(webId);
            ShimSPWeb.AllInstances.IDGet = _ => webGuid;
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => ExampleUrl;
            ShimSPWeb.AllInstances.UrlGet = _ => ExampleUrl;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPWeb.AllInstances.LanguageGet = _ => 1;
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPWeb.AllInstances.FoldersGet = _ => new ShimSPFolderCollection();
            ShimSPWeb.AllInstances.TitleGet = _ => One;
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.LocaleGet = _ => CultureInfo.InvariantCulture;
            ShimSPWeb.AllInstances.AllUsersGet = _ => new ShimSPUserCollection();
            ShimSPWeb.AllInstances.GetListString = (_, __) => new ShimSPList();

            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, __) => new ShimSPUser
            {
                NameGet = () => DummyText
            };

            var properties = new StringDictionary { { "reportingV2", bool.TrueString } };
            var propertyBag = new ShimSPPropertyBag();
            propertyBag.Bind(properties);
            ShimSPWeb.AllInstances.PropertiesGet = _ => propertyBag.Instance;
            ShimSPSite.AllInstances.UrlGet = _ => ExampleUrl;
        }

        private void PrepareSpUserRelatedShims()
        {
            ShimSPUser.AllInstances.IDGet = _ => 1;
            ShimSPUser.AllInstances.LoginNameGet = _ => DummyText;
            ShimSPUser.AllInstances.NameGet = _ => DummyText;
        }

        private void PrepareSpFileRelatedShims()
        {
            ShimSPFolderCollection.AllInstances.ItemGetString = (_, __) => new ShimSPFolder();
            ShimSPFolder.AllInstances.SubFoldersGet = _ => new ShimSPFolderCollection();
            ShimSPFolder.AllInstances.FilesGet = _ => new ShimSPFileCollection();
            ShimSPFileCollection.AllInstances.ItemGetInt32 = (_, __) => new ShimSPFile();
            ShimSPFile.AllInstances.ServerRelativeUrlGet = _ => ExampleUrl;
        }
    }
}
