using System;
using System.Collections.Specialized;
using System.Collections.Specialized.Fakes;
using System.Data.SqlClient.Fakes;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.Fakes;
using EPMLiveCore.Jobs.Applications.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.API
{
    [TestClass]
    public partial class ApplicationInstallerTests
    {
        private IDisposable _shimsObject;
        private AdoShims _shimAdo;
        private PrivateObject _privateObject;
        private ApplicationInstaller _applicationInstaller;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsObject = ShimsContext.Create();
            SharepointShims.ShimSharepointCalls();
            _shimAdo = AdoShims.ShimAdoNetCalls();

            ArrangeShims();

            _applicationInstaller = new ApplicationInstaller(
                string.Empty, 
                new ShimSqlConnection().Instance, 
                new ShimInstallAndConfigure().Instance);

            _privateObject = new PrivateObject(_applicationInstaller);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsObject?.Dispose();
        }

        private void ArrangeShims()
        {
            ShimSPWeb.AllInstances.PropertiesGet = _ => new ShimSPPropertyBag();

            ShimCoreFunctions.setConfigSettingSPWebStringString = (a, b, c) => { };

            ShimSPListItem.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPListItem.AllInstances.ItemGetString = (a, b) => new ShimSPListItem();

            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb();
        }
    }
}