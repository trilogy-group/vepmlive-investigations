using System.Data;
using System.Xml;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.API
{
    public partial class ApplicationInstallerTests
    {
        private const string InstallListsWorkflowsMethod = "iInstallListsWorkflows";

        [TestMethod]
        public void InstallListsWorkflows_When_No_TaskList()
        {
            InstallListsWorkflowsCommon(true, false, "Checking Workflows", "name", "Workflow task list (Workflow Tasks) does not exist");
        }

        [TestMethod]
        [Ignore()]
        public void InstallListsWorkflows_When_Veryfy()
        {
            InstallListsWorkflowsCommon(false, true, "Checking Workflows", "name", "Workflow task list (Workflow Tasks) does not exist");
        }

        [TestMethod]
        [Ignore()]
        public void InstallListsWorkflows_When_No_Veryfy()
        {
            InstallListsWorkflowsCommon(false, true, "Checking Workflows", "name", "Workflow task list (Workflow Tasks) does not exist");
        }

        private void InstallListsWorkflowsCommon(
            bool verifyOnly,
            bool returnList,
            string expectedRow03,
            string expectdRow13,
            string expectedRow14)
        {
            // Arrange
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(@"
<root>
    <Workflows>
        <Workflow Name='name' DisplayName='' TaskList='' HistoryList='' Overwrite='true'> 
        </Workflow> 
    </Workflows>
</root>");
            var ndList = xmlDoc.FirstChild;

            _privateObject.SetFieldOrProperty(OWebProp, new ShimSPWeb().Instance);

            ShimSPListCollection.AllInstances.TryGetListString = (a, b) => returnList ? new ShimSPList() : null;

            // Act
            _privateObject.Invoke(InstallListsWorkflowsMethod, new object[] { new ShimSPList().Instance, ndList, 0, true });
            _privateObject.SetFieldOrProperty(VerifyOnlyProp, verifyOnly);

            // Assert
            var dtMessages = _privateObject.GetFieldOrProperty(DTMessagesProp) as DataTable;

            // Assert
            Assert.IsNotNull(dtMessages);
            Assert.AreEqual(2, dtMessages.Rows.Count);
            Assert.AreEqual(expectedRow03, dtMessages.Rows[0][3]);
            Assert.AreEqual(expectdRow13, dtMessages.Rows[1][3]);
            Assert.AreEqual(expectedRow14, dtMessages.Rows[1][4]);
        }
    }
}