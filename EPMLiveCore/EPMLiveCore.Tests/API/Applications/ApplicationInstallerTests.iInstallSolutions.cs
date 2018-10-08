using System.Data;
using System.Text;
using System.Xml;
using EPMLiveCore.API;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.API
{
    
    public partial class ApplicationInstallerTests
    {
        private const string iInstallSolutionMethod = "iInstallSolutions";

        [TestMethod]
        public void InstallSolutions_When_Found_And_Verify_And_OverWrite()
        {
            iInstallSolutionsCommon(true, true, "fileName", "Checking Solutions and Lists", "fileName", "Solution exists but will upgrade", "fileName", "List template exists but will upgrade");
        }

        [TestMethod]
        public void InstallSolutions_When_Found_And_Verify()
        {
            iInstallSolutionsCommon(true, false, "fileName", "Checking Solutions and Lists", "fileName", "Solution exists and cannot upgrade", "fileName", "List template exists and cannot upgrade");
        }

        [TestMethod]
        public void InstallSolutions_When_Verify()
        {
            iInstallSolutionsCommon(true, false, "fileName1", "Checking Solutions and Lists", "fileName1", string.Empty, "fileName1", string.Empty);
        }

        [TestMethod]
        public void InstallSolutions_When_Installing_And_Found_And_OverWrite()
        {
            iInstallSolutionsCommon(false, true, "fileName", "Installing Solutions and Lists", "fileName", string.Empty, "fileName", "List template upgraded");
        }

        [TestMethod]
        public void InstallSolutions_When_Installing()
        {
            iInstallSolutionsCommon(false, false, "fileName1", "Installing Solutions and Lists", "fileName1", string.Empty, "fileName1", string.Empty);
        }

        [TestMethod]
        public void InstallSolutions_When_Cannot_Upgrade()
        {
            iInstallSolutionsCommon(false, false, "fileName", "Installing Solutions and Lists", "fileName", string.Empty, "fileName", "List template exists and cannot upgrade");
        }

        private void iInstallSolutionsCommon(
            bool verifyOnly,
            bool overWrite,
            string fileName,            
            string expectedRow03,
            string expectedRow13,
            string expectedRow14,
            string expectedRow23,
            string expectedRow24)
        {
            // Arrange
            var appDef = new ApplicationDef();
            var xml = new StringBuilder();
            xml.Append("<root>")
                .Append("<Solutions>")
                .AppendFormat("<Solution FileName='{0}' Overwrite='{1}'>", fileName, overWrite)
                .Append("</Solution>")
                .AppendFormat("<ListTemplate FileName='{0}' Overwrite='{1}'>", fileName, overWrite)
                .Append("</ListTemplate>")
                .Append("</Solutions>")
                .Append("</root>");
            appDef.ApplicationXml.LoadXml(xml.ToString());
            
            _privateObject.SetFieldOrProperty(OWebProp, new ShimSPWeb().Instance);
            _privateObject.SetFieldOrProperty(AppDefProp, appDef);
            _privateObject.SetFieldOrProperty(VerifyOnlyProp, verifyOnly);
            _privateObject.SetFieldOrProperty(ListItemProp, new ShimSPListItem().Instance);

            // Act
            _privateObject.Invoke(iInstallSolutionMethod);
            var dtMessages = _privateObject.GetFieldOrProperty(DTMessagesProp) as DataTable;

            // Assert
            Assert.IsNotNull(dtMessages);
            Assert.AreEqual(3, dtMessages.Rows.Count);
            Assert.AreEqual(expectedRow03, dtMessages.Rows[0][3]);
            Assert.AreEqual(expectedRow13, dtMessages.Rows[1][3]);
            Assert.AreEqual(expectedRow14, dtMessages.Rows[1][4]);
            Assert.AreEqual(expectedRow23, dtMessages.Rows[2][3]);
            Assert.AreEqual(expectedRow24, dtMessages.Rows[2][4]);
        }
    }
}