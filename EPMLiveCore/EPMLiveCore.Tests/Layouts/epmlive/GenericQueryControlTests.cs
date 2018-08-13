using System;
using System.Linq;
using System.Web.UI.Fakes;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Layouts.epmlive
{
    [TestClass]
    public class GenericQueryControlTests
    {
        private const string ServerRelativeUrl = "/";
        private const string FieldControls = "Controls";
        private const string MethodCreateChildControls = "CreateChildControls";

        private IDisposable _shimsContext;
        private GenericQueryControl _testEntity;
        private PrivateObject _testEntityPrivate;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            InitializeSharePoint();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void Dispose_WhenCalled_DisposesSubControls()
        {
            // Arrange
            var disposeCountOfWebControls = 0;
            var disposeCountOfHtmlSelect = 0;
            var disposeCountOfHtmlGenericControl = 0;

            ShimControl.AllInstances.Dispose = instance =>
            {
                try
                {
                    // Table, TableRow, TableCell, ImageButton, DropDownList
                    if (instance is WebControl)
                    {
                        disposeCountOfWebControls++;
                    }
                    else if (instance is HtmlSelect)
                    {
                        disposeCountOfHtmlSelect++;
                    }
                    else if (instance is HtmlGenericControl)
                    {
                        disposeCountOfHtmlGenericControl++;
                    }
                }
                finally
                {
                    ShimsContext.ExecuteWithoutShims(() => instance.Dispose());
                }
            };

            // Act
            using (_testEntity = new GenericQueryControl())
            {
                _testEntityPrivate = new PrivateObject(_testEntity);

                _testEntityPrivate.SetField("propertyBag", new ShimGenericEntityPickerPropertyBag().Instance);
                _testEntityPrivate.Invoke(MethodCreateChildControls);
            }

            // Assert
            _testEntity.ShouldSatisfyAllConditions(
                () => disposeCountOfWebControls.ShouldBe(1),            // 10
                () => disposeCountOfHtmlSelect.ShouldBe(0),             // 1
                () => disposeCountOfHtmlGenericControl.ShouldBe(0));    // 1
        }

        private void InitializeSharePoint()
        {
            var shimSpWeb = new ShimSPWeb()
            {
                ServerRelativeUrlGet = () => ServerRelativeUrl
            };

            var shimSpContext = new ShimSPContext()
            {
                WebGet = () => shimSpWeb
            };

            ShimSPContext.CurrentGet = () => shimSpContext;
            ShimSPContext.AllInstances.SiteGet = context => new ShimSPSite();

            ShimSPSite.AllInstances.OpenWebGuid = (site, guid) => new ShimSPWeb();

            ShimSPWeb.AllInstances.RegionalSettingsGet = web => new ShimSPRegionalSettings();
            ShimSPWeb.AllInstances.ListsGet = web => new ShimSPListCollection();

            ShimSPListCollection.AllInstances.ItemGetGuid = (collection, guid) => new ShimSPList();

            ShimSPList.AllInstances.FieldsGet = list => new ShimSPFieldCollection();

            ShimSPFieldCollection.AllInstances.ItemGetGuid = (collection, s) => new ShimSPField();
            ShimSPFieldCollection.AllInstances.ItemGetString = (collection, s) => new ShimSPField();
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (collection, s) => new ShimSPField();

            ShimSPField.AllInstances.IdGet = field => Guid.Empty;
            ShimSPField.AllInstances.TitleGet = field => string.Empty;

            ShimSPBaseCollection.AllInstances.GetEnumerator = collection => Enumerable.Empty<SPField>().GetEnumerator();

            ShimSPRegionalSettings.AllInstances.IsRightToLeftGet = settings => true;

            ShimGenericQueryControl.AllInstances.WebGet = control => new ShimSPWeb();

            ShimGenericEntityPickerPropertyBag.AllInstances.LookupListIDGet = bag => Guid.Empty;
        }
    }
}