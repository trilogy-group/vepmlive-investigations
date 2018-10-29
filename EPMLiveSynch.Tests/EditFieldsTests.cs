using System.Diagnostics.CodeAnalysis;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using EPMLiveSynch.Layouts;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveSynch.Tests
{
    /// <summary>
    /// Unit test class for <see cref="editfields"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class EditFieldsTests
    {
        [TestMethod]
        public void EditFields_Instantiate_VerifyMemoryLeak()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                var buttonConstructorCount = 0;
                var buttonDisposeCount = 0;
                ShimButton.Constructor = button => buttonConstructorCount++;

                ShimControl.AllInstances.Dispose = control =>
                {
                    if (control is Button)
                    {
                        buttonDisposeCount++;
                    }
                };

                // Act
                using (var editFieldsInstance = new editfields())
                {
                    // To confirm dispose pattern is implemented
                    editFieldsInstance.Dispose();
                }

                // Assert
                Assert.AreEqual(buttonConstructorCount, buttonDisposeCount);
                Assert.AreEqual(1, buttonDisposeCount);
            }
        }
    }
}
