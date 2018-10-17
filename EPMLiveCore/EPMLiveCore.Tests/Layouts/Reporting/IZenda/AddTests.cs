using System;
using System.ComponentModel.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Web.Fakes;
using System.Web.UI.WebControls;
using EPMLiveCore.Layouts.epmlive.reporting.izenda;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Layouts.Reporting
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class AddTests
    {
        private const string MWebFieldName = "m_Web";
        private const string TxtNameFieldName = "txtName";
        private const string TxtCategoryFieldName = "txtCategory";
        private const string TxtXmlFieldName = "txtXml";
        private const string BtnSaveClick = "btnSave_Click";
        private IDisposable _context;
        private Add _testObject;
        private PrivateObject _privateEditObject;
        private PrivateObject _privateUnsecuredPageObject;

        [TestInitialize]
        public void Setup()
        {
            _context = ShimsContext.Create();
            _testObject = new Add();
            _privateEditObject = new PrivateObject(_testObject);
            _privateUnsecuredPageObject = new PrivateObject(_testObject, new PrivateType(typeof(UnsecuredLayoutsPageBase)));
        }

        [TestCleanup]
        public void TearDown()
        {
            _context?.Dispose();
        }

        [TestMethod]
        public void BtnSaveClick_Invoke_VerifyMemoryLeak()
        {
            // Arrange
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            _privateEditObject.SetField(TxtNameFieldName, new TextBox());
            _privateEditObject.SetField(TxtCategoryFieldName, new TextBox());
            _privateEditObject.SetField(TxtXmlFieldName, new TextBox());
            _privateUnsecuredPageObject.SetField(MWebFieldName, (SPWeb)new ShimSPWeb());
            ShimSPWeb.AllInstances.IDGet = _ => new Guid();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.WebApplicationGet = _ => (SPWebApplication)new ShimSPPersistedObject(new ShimSPWebApplication())
            {
                IdGet = () => Guid.Empty
            };

            var sqlConnectionConstructorCount = 0;
            var sqlConnectionDestructorCount = 0;
            var sqlCommandConstructorCount = 0;
            var sqlCommandDisposeCount = 0;

            ShimSqlConnection.ConstructorString = (instance, _string) => sqlConnectionConstructorCount++;
            ShimSqlConnection.AllInstances.Open = connection => { };
            ShimSqlCommand.ConstructorStringSqlConnection = (_1, _2, _3) => sqlCommandConstructorCount++;
            ShimComponent.AllInstances.Dispose = component =>
            {
                if (component is SqlCommand)
                {
                    sqlCommandDisposeCount++;
                }

                if (component is SqlConnection)
                {
                    sqlConnectionDestructorCount++;
                }
            };

            ShimSqlCommand.AllInstances.ParametersGet = _ => new ShimSqlParameterCollection();
            ShimSqlParameterCollection.AllInstances.AddWithValueStringObject = (_1, str, value) => null;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 0;
            ShimSqlDataReader.AllInstances.Read = reader => false;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (_1, _2, _3) => true;
            ShimHttpContext.CurrentGet = () => new ShimHttpContext();

            // Act
            _privateEditObject.Invoke(BtnSaveClick, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => sqlCommandConstructorCount.ShouldBe(2),
                () => sqlCommandDisposeCount.ShouldBe(2),
                () => sqlConnectionConstructorCount.ShouldBe(1),
                () => sqlConnectionDestructorCount.ShouldBe(1));
        }
    }
}