using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.UI.WebControls;

namespace EPMLiveCore.Tests.FilteredLookup
{
    [TestClass]
    public class FilteredLookupFieldEditorTests
    {
        private IDisposable shimsContext;
        private FilteredLookupFieldEditor filteredLookupFieldEditor;
        private PrivateObject privateObject;
        private readonly CheckBox CbxAllowMultiValue = new CheckBox();
        private readonly CheckBox CbxUnlimitedLengthInDocLib = new CheckBox();
        private readonly CheckBox CbxRecursiveFilter = new CheckBox();
        private readonly TextBox TxtQueryFilter = new TextBox();


        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            filteredLookupFieldEditor = new FilteredLookupFieldEditor();
            privateObject = new PrivateObject(filteredLookupFieldEditor);
        }

        [TestCleanup]
        public void Clenaup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {

        }

        [TestMethod]
        public void InitializeWithField()
        {
            // Arrange
            ShimUserControl.AllInstances.IsPostBackGet = _ => false;
            var field = new FilteredLookupField(new ShimSPFieldCollection(), "");

            // Act
            filteredLookupFieldEditor.InitializeWithField(field);


            // Assert

        }


    }
}
