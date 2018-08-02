using System;
using System.Collections;
using System.Reflection;
using EPMLive.TestFakes.Utility;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.SharePoint.Fakes;

namespace EPMLiveWebParts.Tests.WebPageCode
{
    [TestClass]
    public class GetgantttasksTests
    {
        private IDisposable _shimContext;
        private SharepointShims _sharepointShims;
        private AdoShims _adoShims;
        private getgantttasks _getGanttTasks;
        private PrivateObject _getGanttTasksPrivate;

        [TestInitialize]
        public void Setup()
        {
            _shimContext = ShimsContext.Create();

            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();

            _getGanttTasks = new getgantttasks();
            _getGanttTasksPrivate = new PrivateObject(_getGanttTasks);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        [TestMethod]
        public void ProcessList_Called_Exceuted()
        {
            // Arrange
            var listId = new Guid("4D593B64-51CF-49F0-B566-CDAE35FCDDE0");
            _sharepointShims.ListShim.IDGet = () => listId;
            _sharepointShims.ListShim.GetItemsSPQuery = query => 
                new ShimSPListItemCollection().Bind(
                    new SPListItem[] 
                    {
                        new ShimSPListItem { }
                    });

            var arguments = new object[] 
            {
                (SPWeb)_sharepointShims.WebShim,
                "select",
                (SPList)_sharepointShims.ListShim,
                new SortedList()
            };

            // Act
            _getGanttTasksPrivate.Invoke("processList", BindingFlags.Instance | BindingFlags.NonPublic, arguments);

            // Assert
        }
    }
}
