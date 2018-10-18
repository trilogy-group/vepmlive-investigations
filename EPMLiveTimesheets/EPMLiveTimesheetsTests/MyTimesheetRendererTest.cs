using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using TimeSheets;

namespace EPMLiveTimesheets.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class MyTimesheetRendererTest
    {
        [TestMethod]
        public void RenderApprovalToolbar_OnValidCall_WriteToHtmlTextWriter()
        {
            // Arrange
            const string testFullGridId = "TestFullGridId";
            var stringWriter = new StringWriter();
            var properties = new MyTimesheetProperties()
            {
                FullGridId = testFullGridId
            };

            // Act
            using (var htmlTextWriter = new HtmlTextWriter(stringWriter))
            {
                new MyTimesheetRenderer(htmlTextWriter, properties).RenderApprovalToolbar();
            }
            var actualResult = stringWriter.ToString();

            // Assert
            actualResult.ShouldSatisfyAllConditions(
               () => actualResult.ShouldContain($"<div id=\"actionmenu{testFullGridId}\" style=\"width:100%\"></div>"),
               () => actualResult.ShouldContain($"function loadMenu{testFullGridId}"),
               () => actualResult.ShouldContain($"epmLiveGenericToolBar.generateToolBar('actionmenu{testFullGridId}"));
        }
    }
}
