using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.AssignmentPlanner;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.AssignmentPlanner
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class GridManagerTests
    {
        private GridManager testObject;
        private PrivateObject privateObject;
        private IDisposable shimsContext;

        private ShimSPWeb spWeb;

        [TestInitialize]
        public void Setup()
        {
            SetupShims();

            testObject = new GridManager(spWeb);
            privateObject = new PrivateObject(testObject);
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();

            SetupVariables();
        }

        private void SetupVariables()
        {
            spWeb = new ShimSPWeb();
        }
    }
}
