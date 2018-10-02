using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.FilteredLookup
{
    [TestClass]
    public class FilteredLookupFieldEditorTests
    {
        private IDisposable shimsContext;
        private FilteredLookupFieldEditor filteredLookupFieldEditor;
        private PrivateObject privateObject;

        [TestMethod]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            filteredLookupFieldEditor = new FilteredLookupFieldEditor();
            privateObject = new PrivateObject(filteredLookupFieldEditor);
        }

        [TestMethod]
        public void Clenaup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {

        }


    }
}
