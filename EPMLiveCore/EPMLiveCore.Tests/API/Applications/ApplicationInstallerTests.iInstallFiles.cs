using System.Data;
using System.Text;
using System.Xml;
using EPMLiveCore.API;
using EPMLiveCore.WorkEngineSolutionStoreListSvc.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.API
{
    
    public partial class ApplicationInstallerTests
    {
        private const string iInstallFilesMethod = "iInstallFiles";

        [TestMethod]
        public void InstallFiles()
        {
            iInstallFilesCommon(true, true, "Checking Files", "File: lookupValue", string.Empty);
        }

        private void iInstallFilesCommon(
            bool verifyOnly,
            bool overWrite,            
            string expectedRow03,
            string expectedRow13,
            string expectedRow14)
        {
            // Arrange
            var expectedOuterXml = "<Files><File Name=\"lookupValue\" RemoteFile=\"lookupValue\" Overwrite=\"True\" NoDelete=\"true\" Type=\"lookupValue\" FullFile=\"lookupValue\" /></Files>";
            var appDef = new ApplicationDef();
            var xml = new StringBuilder();
            xml.Append("<root>")
                .Append("<Files>")
                .Append("<File Path='lookupValue' Overwrite='true' NoDelete='true'/>")
                .Append("</Files>")
                .Append("</root>");
            appDef.ApplicationXml.LoadXml(xml.ToString());
            
            _privateObject.SetFieldOrProperty(OWebProp, new ShimSPWeb().Instance);
            _privateObject.SetFieldOrProperty(AppDefProp, appDef);
            _privateObject.SetFieldOrProperty(VerifyOnlyProp, verifyOnly);
            _privateObject.SetFieldOrProperty(ListItemProp, new ShimSPListItem().Instance);

            xml.Clear();
            xml.Append("<root>")
                .Append("<rs:data xmlns:rs='http://www.w3.org/TR/html4/' ItemCount='1'>")
                .Append("<z:row xmlns:z='http://www.w3.org/TR/html4/' ows_FSObjType='ows_FSObjType' ows_FileRef='ows_FileRef' ows_FileLeafRef='ows_FileLeafRef' ows_Title='ows_Title'/>")
                .Append("</rs:data>")
                .Append("</root>");
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml.ToString());

            ShimLists.Constructor = _ => { };
            ShimLists.AllInstances.GetListItemsStringStringXmlNodeXmlNodeStringXmlNodeString = (a, b, c, d, e, f, g, h) => xmlDoc.FirstChild;

            // Act
            var actual = _privateObject.Invoke(iInstallFilesMethod) as XmlNode;
            var dtMessages = _privateObject.GetFieldOrProperty(DTMessagesProp) as DataTable;

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedOuterXml, actual.OuterXml);

            Assert.IsNotNull(dtMessages);
            Assert.AreEqual(2, dtMessages.Rows.Count);
            Assert.AreEqual(expectedRow03, dtMessages.Rows[0][3]);
            Assert.AreEqual(expectedRow13, dtMessages.Rows[1][3]);
            Assert.AreEqual(expectedRow14, dtMessages.Rows[1][4]);
        }
    }
}