using System;
using System.Collections.Generic;
using System.Data.SqlClient.Fakes;
using System.Web;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
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
    public class EditTests
    {
        private const string RequestFieldName = "_request";
        private const string HdnFullNameFieldName = "hdnFullName";
        private const string DummyName = "DummyName\\DummySubName";
        private const string RequestValueCollectionFieldName = "_requestValueCollection";
        private const string MWebFieldName = "m_Web";
        private const string TxtNameFieldName = "txtName";
        private const string TxtCategoryFieldName = "txtCategory";
        private const string TxtXmlFieldName = "txtXml";
        private const string PageLoadMethodName = "Page_Load";
        private Dictionary<string, object> _actualParameters;
        private IDisposable _context;
        private edit _edit;
        private PrivateObject _privateEditObject;
        private PrivateObject _privatePageObject;
        private PrivateObject _privateUnsecuredPageObject;

        [TestInitialize]
        public void Setup()
        {
            _context = ShimsContext.Create();
            _edit = new edit();
            _privateEditObject = new PrivateObject(_edit);
            _privatePageObject = new PrivateObject(_edit, new PrivateType(typeof(Page)));
            _privateUnsecuredPageObject = new PrivateObject(_edit, new PrivateType(typeof(UnsecuredLayoutsPageBase)));
        }

        [TestCleanup]
        public void TearDown()
        {
            _context?.Dispose();
        }

        [TestMethod]
        public void PageLoad_Throws_AndProperlyDisposes()
        {
            PageLoad_DisposeTests(true);
        }

        [TestMethod]
        public void PageLoad_NormalExecution_ProperlyDisposes()
        {
            PageLoad_DisposeTests(false);
        }

        [TestMethod]
        public void BtnSaveClick_DisposesProperly()
        {
            using (TestCheck.OpenCloseConnections)
            {
                // Arrange
                SetupShimSecurity();
                SetupEditFields();
                SetupWebProperty();
                SetupSqlCommandAndDataReader(false);
                ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (_1, _2, _3) => true;
                ShimHttpContext.CurrentGet = () => new ShimHttpContext();
                object sender = null;
                EventArgs e = null;

                // Act
                _privateEditObject.Invoke("btnSave_Click", sender, e);

                // Assert
                this.ShouldSatisfyAllConditions(
                    () => _actualParameters.ShouldContainKey("@siteid"),
                    () => _actualParameters.ShouldContainKey("@name"),
                    () => _actualParameters.ShouldContainKey("@xml"),
                    () => _actualParameters.ShouldContainKey("@newname"));
            }
        }

        private void PageLoad_DisposeTests(bool readerShouldThrow)
        {
            using (TestCheck.OpenCloseConnections)
            {
                // Arrange
                SetupShimSecurity();
                SetupSqlCommandAndDataReader(readerShouldThrow);
                SetupEditFields();
                object sender = null;
                EventArgs e = null;

                // Act
                Action action = () => _privateEditObject.Invoke(PageLoadMethodName, sender, e);

                // Assert
                this.ShouldSatisfyAllConditions(
                    () =>
                    {
                        if (readerShouldThrow)
                        {
                            action.ShouldThrow<InvalidOperationException>();
                        }
                        else
                        {
                            action.ShouldNotThrow();
                        }
                    },
                    () => _actualParameters.ShouldContainKey("@siteid"),
                    () => _actualParameters.ShouldContainKey("@name"));
            }
        }

        private void SetupSqlCommandAndDataReader(bool readerShouldThrow)
        {
            _actualParameters = new Dictionary<string, object>();
            ShimSqlCommand.ConstructorStringSqlConnection = (_1, _2, _3) => { };
            ShimSqlCommand.AllInstances.ParametersGet = _ => new ShimSqlParameterCollection();
            ShimSqlParameterCollection.AllInstances.AddWithValueStringObject = (_1, str, value) =>
            {
                _actualParameters.Add(str, value);
                return null;
            };
            SetupWebProperty();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                if (readerShouldThrow)
                {
                    throw new InvalidOperationException("This test Should throw");
                }
                return true;
            };
        }

        private void SetupWebProperty()
        {
            _privateUnsecuredPageObject.SetField(MWebFieldName, (SPWeb)new ShimSPWeb());
            ShimSPWeb.AllInstances.IDGet = _ => Guid.Empty;
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.WebApplicationGet = _ => (SPWebApplication)new ShimSPPersistedObject(new ShimSPWebApplication())
            {
                IdGet = () => Guid.Empty
            };
        }

        private void SetupEditFields()
        {
            _privateEditObject.SetField(RequestFieldName, (HttpRequest)new ShimHttpRequest());
            ShimHttpRequest.AllInstances.ItemGetString = (_, str) =>
            {
                if (str == "name")
                {
                    return DummyName;
                }
                return null;
            };
            _privatePageObject.SetField(RequestValueCollectionFieldName, null);

            _privateEditObject.SetField(HdnFullNameFieldName, (HiddenField)new ShimHiddenField());
            var valueString = string.Empty;
            ShimHiddenField.AllInstances.ValueSetString = (_, str) => valueString = str;
            ShimHiddenField.AllInstances.ValueGet = _ => valueString;

            _privateEditObject.SetField(TxtNameFieldName, new TextBox());
            _privateEditObject.SetField(TxtCategoryFieldName, new TextBox());
            _privateEditObject.SetField(TxtXmlFieldName, new TextBox());
        }

        private static void SetupShimSecurity()
        {
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
        }
    }
}