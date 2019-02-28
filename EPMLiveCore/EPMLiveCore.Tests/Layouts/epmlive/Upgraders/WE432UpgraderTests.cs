using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.Fakes;
using System.Web.UI.HtmlControls;
using System.Web.UI.HtmlControls.Fakes;
using EPMLiveCore.Layouts.epmlive.Upgraders;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Layouts.epmlive.Upgraders
{
    [TestClass, ExcludeFromCodeCoverage]
    public class WE432UpgraderTests
    {
        private const string MessagesText = "_messages";
        private const string LogError = "LogError";
        private const string LogHeader = "LogHeader";
        private const string LogMessage = "LogMessage";
        private const string DummyError = "Error";

        [TestMethod]
        public void WE432Upgrader_Instantiate_VerifyHtmlGenericControlsMemoryLeak()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                var htmlGenericControlConstructorCount = 0;
                var htmlGenericControlDisposedCount = 0;

                ShimHtmlGenericControl.ConstructorString = (control, s) => htmlGenericControlConstructorCount++;
                ShimControl.AllInstances.Dispose = control =>
                {
                    if (control is HtmlGenericControl)
                    {
                        htmlGenericControlDisposedCount++;
                    }
                };
                var htmlGenericControls = new List<HtmlGenericControl>();

                // Act
                using (var testObject = new WE432Upgrader())
                {
                    var privateObject = new PrivateObject(testObject);
                    privateObject.SetFieldOrProperty(MessagesText, htmlGenericControls);
                    privateObject.Invoke(LogError, DummyError);
                    privateObject.Invoke(LogHeader, DummyError);
                    privateObject.Invoke(LogMessage, DummyError);
                }

                // Assert
                this.ShouldSatisfyAllConditions(
                    () => htmlGenericControls.Count.ShouldBe(3),
                    () => htmlGenericControlConstructorCount.ShouldBe(3),
                    () => htmlGenericControlDisposedCount.ShouldBe(3));
            }
        }
    }
}
