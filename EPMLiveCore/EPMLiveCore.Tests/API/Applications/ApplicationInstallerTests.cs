using System;
using System.Collections.Fakes;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient.Fakes;
using System.IO.Fakes;
using System.Linq;
using System.Net.Fakes;
using System.Xml;
using System.Xml.Fakes;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Jobs.Applications.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveCore.WorkEngineSolutionStoreListSvc.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Navigation;
using Microsoft.SharePoint.Navigation.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.WebPartPages.Fakes;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Workflow.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.API
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
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPWeb.AllInstances.GetFileString = (a, b) => new ShimSPFile();
            ShimSPWeb.AllInstances.GetFolderString = (a, b) => new ShimSPFolder();
            ShimSPWeb.AllInstances.FoldersGet = _ => new ShimSPFolderCollection();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.FeaturesGet = _ => new ShimSPFeatureCollection();
            ShimSPWeb.AllInstances.RootFolderGet = _ => new ShimSPFolder();
            ShimSPWeb.AllInstances.NavigationGet = _ => new ShimSPNavigation();
            ShimSPWeb.AllInstances.AllUsersGet = _ => new ShimSPUserCollection();

            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, __) => new ShimSPUser();

            ShimSPNavigation.AllInstances.QuickLaunchGet = _ => new ShimSPNavigationNodeCollection();
            ShimSPNavigation.AllInstances.TopNavigationBarGet = _ => new ShimSPNavigationNodeCollection();

            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.ConstructorGuidSPUserToken = (_, __, ___) => { };
            ShimSPSite.AllInstances.GetCatalogSPListTemplateType = (a, b) => new ShimSPDocumentLibrary();
            ShimSPSite.AllInstances.SolutionsGet = _ => new ShimSPUserSolutionCollection();
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.FeatureDefinitionsGet = _ => new ShimSPFeatureDefinitionCollection();
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPSite.AllInstances.FeaturesGet = _ => new ShimSPFeatureCollection();

            ShimSPFolderCollection.AllInstances.AddString = (a, b) => new ShimSPFolder();

            ShimSPFolder.AllInstances.ExistsGet = _ => false;
            ShimSPFolder.AllInstances.FilesGet = _ => new ShimSPFileCollection();

            ShimSPFile.AllInstances.ExistsGet = _ => true;
            ShimSPFile.AllInstances.GetLimitedWebPartManagerPersonalizationScope = (a, b) => new ShimSPLimitedWebPartManager();
            ShimSPFile.AllInstances.NameGet = _ => "fileName";
            ShimSPFile.AllInstances.ItemGet = _ => new ShimSPListItem();

            ShimCoreFunctions.setConfigSettingSPWebStringString = (a, b, c) => { };
            ShimCoreFunctions.getConfigSettingSPWebString = (a, b) => true.ToString();

            ShimSPListItem.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPListItem.AllInstances.ItemGetString = (a, b) => new ShimSPListItem();

            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb();
            ShimSPList.AllInstances.TitleGet = _ => "title";
            ShimSPList.AllInstances.ViewsGet = _ => new ShimSPViewCollection();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPList.AllInstances.RootFolderGet = _ => new ShimSPFolder();
            ShimSPList.AllInstances.ItemsGet = _ => new ShimSPListItemCollection();
            ShimSPList.AllInstances.GetItemsSPQuery = (_, __) => new ShimSPListItemCollection();
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, __) => new ShimSPListItem();

            ShimSPListItemCollection.AllInstances.Add = _ => new ShimSPListItem();
            
            ShimSPBaseCollection.AllInstances.GetEnumerator = instance =>
            {
                if (instance is SPFileCollection)
                {
                    var list1 = new List<SPFile>
                    {
                        new ShimSPFile().Instance
                    };
                    return list1.GetEnumerator();
                }

                if (instance is SPUserSolutionCollection)
                {
                    var list2 = new List<SPUserSolution>
                    {
                        new ShimSPUserSolution().Instance
                    };
                    return list2.GetEnumerator();
                }

                if (instance is SPNavigationNodeCollection)
                {
                    return Enumerable.Empty<SPNavigationNode>().GetEnumerator();
                }

                var list = new List<SPWorkflowAssociation>
                {
                    new ShimSPWorkflowAssociation().Instance
                };

                return list.GetEnumerator();
            };

            ShimSPView.AllInstances.UrlGet = _ => string.Empty;
            ShimSPView.AllInstances.TitleGet = _ => "title";
            ShimSPView.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPView.AllInstances.ViewFieldsGet = _ => new ShimSPViewFieldCollection();

            ShimExtensionMethods.GetContentsSPFile = _ => string.Empty;
            ShimExtensionMethods.UpdateContentsAndSaveSPFileString = (_, __) => { };

            ShimSPLimitedWebPartManager.AllInstances.WebPartsGet = _ => new ShimSPLimitedWebPartCollection();
            ShimSPLimitedWebPartManager.AllInstances.WebGet = _ => new ShimSPWeb();

            ShimReadOnlyCollectionBase.AllInstances.GetEnumerator = _ =>
            {
                var list = new List<WebPart>
                {
                    new ShimXsltListFormWebPart().Instance
                };

                return list.GetEnumerator();
            };

            ShimGridGanttSettings.ConstructorSPList = (instance, __) => 
            {
                instance.TotalSettings = "a|b\n";
                instance.Lookups = "a^b|c^d";
            };

            ShimSPFieldMultiChoice.AllInstances.ChoicesGet = _ => new StringCollection();

            ShimWebClient.Constructor = _ => { };
            ShimWebClient.AllInstances.DownloadDataString = (_, __) => new byte[] { 0 };

            ShimSPFileCollection.AllInstances.AddStringByteArray = (_, __, ___) => new ShimSPFile();
            ShimSPFileCollection.AllInstances.ItemGetString = (_, __) => new ShimSPFile();

            ShimSPUserSolutionCollection.AllInstances.AddInt32 = (_, __) => new ShimSPUserSolution();

            ShimSPListCollection.AllInstances.ItemGetGuid = (_, __) => new ShimSPList();

            ShimReporting.ProcessReportDataSourcesSPWebString = (_, __) => { };

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<root/>");
            ShimLists.Constructor = _ => { };
            ShimLists.AllInstances.GetListItemsStringStringXmlNodeXmlNodeStringXmlNodeString = (a, b, c, d, e, f, g, h) => xmlDoc.FirstChild;

            ShimSPNavigationNode.ConstructorStringStringString = (a, b, c, d) => { };
            ShimSPNavigationNode.AllInstances.ChildrenGet = _ => new ShimSPNavigationNodeCollection();
            ShimSPNavigationNode.AllInstances.Update = _ => { };

            ShimSPNavigationNodeCollection.AllInstances.AddAsLastSPNavigationNode = (a, b) => new ShimSPNavigationNode();

            ShimSPPersistedObject.AllInstances.FarmGet = _ => new ShimSPFarm();

            ShimSPFarm.AllInstances.FeatureDefinitionsGet = _ => new ShimSPFeatureDefinitionCollection();

            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();

            ShimReportBiz.ConstructorGuidGuidBoolean = (a, b, c, d) => { };
            ShimReportBiz.AllInstances.GetListBizGuid = (a, b) => new ShimListBiz();
            ShimReportBiz.AllInstances.CreateListBizGuid = (a, b) => new ShimListBiz();

            ShimListBiz.AllInstances.ListNameGet = _ => string.Empty;

            ShimPath.GetDirectoryNameString = _ => string.Empty;
            ShimPath.GetExtensionString = _ => ".txt";

            ShimSPFieldLookupValue.ConstructorString = (_, __) => { };
            ShimSPFieldLookupValue.AllInstances.LookupValueGet = _ => "lookupValue";
        }
    }
}