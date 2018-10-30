using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests
{
    /// <summary>
    /// UTs for <see cref="ManageableLists"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class ManageableListsTest
    {
        private const string ServerRelativeUrl = "/";
        private const string MethodCreateChildControls = "CreateChildControls";

        private IDisposable _shimsContext;
        private ManageableLists _testEntity;
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
        public void CreateChildControls_Invoke_VerifyMemoryLeak()
        {
            // Arrange
            var controlsConstructorCount = 0;
            var dropDownListDisposeCount = 0;
            ShimDropDownList.Constructor = _ => controlsConstructorCount++;
            ShimLabel.Constructor = _ => controlsConstructorCount++;
            ShimControl.AllInstances.Dispose = control =>
            {
                if (control is DropDownList || control is Label)
                {
                    dropDownListDisposeCount++;
                }
            };

            // Act
            using (_testEntity = new ManageableLists())
            {
                _testEntityPrivate = new PrivateObject(_testEntity);
                _testEntityPrivate.Invoke(MethodCreateChildControls);
            }

            // Assert
            _testEntity.ShouldSatisfyAllConditions(
                () => controlsConstructorCount.ShouldBe(2),
                () => dropDownListDisposeCount.ShouldBe(2));
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
            ShimCoreFunctions.getConfigSettingSPWebString = (web, s) => s;
        }
    }
}