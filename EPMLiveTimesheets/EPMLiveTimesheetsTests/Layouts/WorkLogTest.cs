using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using TimeSheets;
using TimeSheets.Fakes;
using TimeSheets.Layouts.epmlive;

namespace EPMLiveTimesheets.Tests.Layouts
{
    [TestClass, ExcludeFromCodeCoverage]
    public class WorkLogTest
    {
        private IDisposable _shimsContext;
        private WorkLog _testEntity;
        private PrivateObject _privateObject;

        private const string OnInitMethodName = "OnInit";

        private const string DummyUserName = "DummyUserName";
        private const string DummyUserLoginname = "DummyUserLoginName";
        private static readonly Guid DummySiteId = Guid.NewGuid();

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
            _testEntity = new WorkLog();
            _privateObject = new PrivateObject(_testEntity);

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                SiteGet = () => new ShimSPSite()
                {
                    IDGet = () => DummySiteId
                },
                WebGet = () => new ShimSPWeb()
                {
                    CurrentUserGet = () => new ShimSPUser()
                    {
                        NameGet = () => DummyUserName,
                        LoginNameGet = () => DummyUserLoginname
                    }
                }
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext?.Dispose();
            //_testEntity?.Dispose();
        }

        [TestMethod]
        public void Dispose_Always_DisposesHoursPlaceHolder()
        {
            // Arrange
            var isDisposeCalled = false;
            ShimControl.AllInstances.Dispose = _ =>
            {
                isDisposeCalled = true;
            };

            // Act
            using (var workLog = new WorkLog())
            { }

            // Assert
            isDisposeCalled.ShouldBeTrue();
        }

        [TestMethod]
        public void OnInit_()
        {
            // Arrange
            InitializeUiControls();
            ShimAct.ConstructorSPWeb = (sender, spWeb) => { };
            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = sender => new ShimSPWeb();
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (sender, actFeature) => 0;

            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                QueryStringGet = () => new NameValueCollection()
                {
                    ["ListId"] = "a47633d6-b933-4910-9bc0-ec27c36adfc9",
                    ["ItemId"] = "100"
                }
            };
            ShimPage.AllInstances.ClientScriptGet = sender => new ShimClientScriptManager()
            {
                IsStartupScriptRegisteredTypeString = (type, key) => false,
                RegisterStartupScriptTypeStringString = (type, key, script) => { }
            };


            ShimTSItem.GetWorkTypesGuid = guid => new Dictionary<int, string>()
            {
                { 1, "work" }
            };
            ShimTSItem.GetDelegateForDropDownListSPWebSPUser = (dropDownList, web, user) =>{ };

            // Act
            _privateObject.Invoke(OnInitMethodName, EventArgs.Empty);

            // Assert

        }


        private void InitializeUiControls()
        {
            var allFields = _testEntity.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(field => field.FieldType.IsSubclassOf(typeof(Control)));
            foreach (var control in allFields)
            {
                _privateObject.SetField(control.Name, Activator.CreateInstance(control.FieldType));
            }
        }
    }
}
