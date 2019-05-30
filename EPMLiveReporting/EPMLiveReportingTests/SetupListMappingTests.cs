using System;
using System.Collections.Generic;
using System.Collections.Specialized.Fakes;
using System.Data;
using System.Data.Fakes;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveReportsAdmin.Layouts.EPMLive;
using EPMLiveReportsAdmin.Layouts.EPMLive.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Linq;
using System.Web.UI;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveReportsAdmin.Layouts.EPMLive.Tests
{
    [TestClass()]
    public class SetupListMappingTests
    {
    
        private const string PopulateFieldList = "PopulateFieldList";
        private IDisposable _shimContext;
        private PrivateObject _privateObject;
        private SetupListMapping _setupListMappingObj;
        private List<string> _fields;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            SharepointShims.ShimSharepointCalls();
            _setupListMappingObj = new SetupListMapping();

            _privateObject = new PrivateObject(_setupListMappingObj);

            ArrangeShims();
            InitializeUiControls();
        }

        private void InitializeUiControls()
        {
            var allFields = _setupListMappingObj.GetType()
               .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
               .Where(field => field.FieldType.IsSubclassOf(typeof(Control)));

            foreach (var control in allFields)
            {
                _privateObject.SetField(control.Name, Activator.CreateInstance(control.FieldType));
            }
        }
        [TestMethod]
        public void PopulateFieldListTest()
        {
            // Arrange
            _privateObject.SetFieldOrProperty("_existing", true);
            _privateObject.SetFieldOrProperty("_existingListId", Guid.Empty);

            // Act
            var method = _setupListMappingObj.GetType().GetMethod(PopulateFieldList, BindingFlags.Instance | BindingFlags.NonPublic);
            var result = method.Invoke(_setupListMappingObj, new object[] { });
            var fields = _privateObject.GetField("cblFields", BindingFlags.Instance | BindingFlags.NonPublic);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(fields);
            Assert.IsTrue(((InputFormCheckBoxList)fields).Items.Count > 0);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        private void ArrangeShims()
        {
            _fields = new List<string>();
            _fields.Add("test-field");
            _fields.Add("test-field2");
            _fields.Add("test-field3");
            _fields.Add("test-field4");
            _fields.Add("test-field5");
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimReportBiz.ConstructorGuid = (_reportBiz, _2) =>
            {
            };
            ShimReportBiz.AllInstances.GetListBizGuid = (_reportBiz, _2) =>
            {
                return new ShimListBiz()
                {
                    GetMappedFieldsStrings = () => { return _fields; }
                };
            };
            ShimControl.AllInstances.ControlsGet = _ => new ShimControlCollection();
            ShimCheckBox.Constructor = _ => { };
        }
    }
}