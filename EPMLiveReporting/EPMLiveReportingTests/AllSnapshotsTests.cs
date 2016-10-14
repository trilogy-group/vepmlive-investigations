using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Fakes;

namespace EPMLiveReportsAdmin.Layouts.EPMLive.Tests
{
    [TestClass()]
    public class AllSnapshotsTests
    {
        [TestMethod()]
        public void RaisePostBackEventTest()
        {
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                string snapshotId = "AE3914B2-C74F-4400-B01F-FE8A9EDF21BA";

                using (ShimsContext.Create())
                {
                    ShimHttpContext.CurrentGet = () =>
                    {
                        return new ShimHttpContext();
                    };
                }

                string resultUrl = string.Empty;

                ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (url, flags, httpContext) =>
                {
                    resultUrl = url;
                    return false;
                };

                
                AllSnapshots allSnapshotPage = new AllSnapshots();
                allSnapshotPage.RaisePostBackEvent(snapshotId);

                Assert.AreEqual(resultUrl, "epmlive/ReportSchedule.aspx?uid=" + snapshotId);                
            }
        }
    }
}