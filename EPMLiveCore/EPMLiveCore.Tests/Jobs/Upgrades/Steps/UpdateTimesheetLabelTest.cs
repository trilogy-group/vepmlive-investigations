using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Steps;


namespace EPMLiveCore.Tests.Jobs.Upgrades.Steps
{
    /// <summary>
    /// Summary description for UpdateTimesheetLabelTest
    /// </summary>
    [TestClass]
    public class UpdateTimesheetLabelTest
    {
        private IDisposable _context;
        private UpdateTimesheetLabel _updateTimesheetLabel;
        private bool _itemUpdated;
        private readonly string _oldTitle = "New title is not there";
        private readonly string _newTitle = "To view all the timesheets, you should add yourself into the timesheet manager field explicitly for all the desired resources.";

        [TestInitialize]
        public void Setup()
        {
           
            _context = ShimsContext.Create();
            var spweb = new ShimSPWeb()
            {
                SiteGet = () =>
                {
                    return new ShimSPSite()
                    {
                        WebApplicationGet = () =>
                        {
                            return new ShimSPWebApplication();
                        }
                    };
                }
            };
            _updateTimesheetLabel = new UpdateTimesheetLabel(spweb.Instance, false);
        }
        
        [TestCleanup]
        public void TearDown()
        {
            _context?.Dispose();
        }
        
        [TestMethod]
        public void Perform_When_Title_Updated()
        {
            // Arrange
            SetupShim(_oldTitle);

            // Act
            var result = _updateTimesheetLabel.Perform();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
            Assert.IsTrue(_itemUpdated);
        }

        [TestMethod]
        public void Perform_When_Title_Not_Updated()
        {
            // Arrange
            SetupShim(_newTitle);

            // Act
            var result = _updateTimesheetLabel.Perform();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
            Assert.IsFalse(_itemUpdated);            
        }
       
        public void SetupShim(string labelTitle)
        {
            var _field = new ShimSPField() { DescriptionGet = () => { return labelTitle; } };

            ShimSPField.AllInstances.Update = (_) => { _itemUpdated = true; };
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, _1) => { return _field; };

            ShimSPList.AllInstances.FieldsGet = (_) => { return new ShimSPFieldCollection(); };

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
            ShimSPWeb.AllInstances.GetListString = (_, _1) => { return new ShimSPList(); };

            ShimSPWeb.AllInstances.ListsGet = (_) => { return new ShimSPListCollection(); };
            ShimSPListCollection.AllInstances.ItemGetString = (_, _1) => { return new ShimSPList(); };
           
        }
    }
}
