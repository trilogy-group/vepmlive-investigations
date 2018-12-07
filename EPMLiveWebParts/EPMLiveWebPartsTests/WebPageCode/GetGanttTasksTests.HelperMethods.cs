using System;
using System.Collections.Generic;
using System.Collections.Generic.Fakes;
using System.Collections.Specialized;
using System.Globalization;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;

namespace EPMLiveWebParts.Tests.WebPageCode
{
    public partial class GetGanttTasksTests
    {
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

            var listGuid = listId == null ? Guid.NewGuid() : new Guid(listId);
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
            var webGuid = webId == null ? Guid.NewGuid() : new Guid(webId);
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
    }
}
