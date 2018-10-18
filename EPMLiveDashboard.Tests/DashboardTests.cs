using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveDashboard.Tests
{
    [TestClass]
    public class DashboardTests
    {
        [TestMethod]
        public void CreateChildControls_Dispose_VerifyMemoryLeak()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                var dropdownListConstructorCount = 0;
                var dropdownListDisposeCount = 0;

                ShimDropDownList.Constructor = _ => dropdownListConstructorCount++;
                ShimControl.AllInstances.Dispose = control =>
                {
                    if (control is DropDownList)
                    {
                        dropdownListDisposeCount++;
                    }
                };

                var spWeb = new ShimSPWeb
                {
                    SiteGet = () => new ShimSPSite()
                };

                ShimSPContext.CurrentGet = () => new ShimSPContext
                {
                    WebGet = () => spWeb
                };

                ShimAct.ConstructorSPWeb = (act, web) => { };
                ShimAct.AllInstances.CheckFeatureLicenseActFeature = (act, feature) => 0;
                ShimSPControl.GetContextWebHttpContext = _ => new ShimSPWeb();

                // Act
                using (var dashBoard = new Dashboard.Dashboard())
                {
                    var privateObject = new PrivateObject(dashBoard);
                    privateObject.Invoke("CreateChildControls");
                }

                // Assert
                this.ShouldSatisfyAllConditions(
                    () => dropdownListConstructorCount.ShouldBeGreaterThanOrEqualTo(2),
                    () => dropdownListDisposeCount.ShouldBeGreaterThanOrEqualTo(2));
            }
        }
    }
}
