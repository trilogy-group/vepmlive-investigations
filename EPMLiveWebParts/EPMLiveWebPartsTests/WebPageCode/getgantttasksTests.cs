using System;
using System.Collections;
using System.Reflection;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using EPMLive.TestFakes.Utility;
using EPMLiveWebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveWebParts.Tests.WebPageCode
{
    [TestClass]
    public class GetgantttasksTests
    {
        private IDisposable _shimContext;
        private SharepointShims _sharepointShims;
        private AdoShims _adoShims;
        private MockHttpContext _mockHttpContext;
        private getgantttasks _getGanttTasks;
        private PrivateObject _getGanttTasksPrivate;

        [TestInitialize]
        public void Setup()
        {
            _shimContext = ShimsContext.Create();

            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();

            Shimgetgantttasks.Constructor = tasks => 
            {
                var shimPage = new ShimPage(tasks)
                {
                    RequestGet = () => 
                    {
                        var shimHttpRequest = new ShimHttpRequest()
                        {
                            ItemGetString = key => 
                            {
                                if (key == "ignorelistid")
                                {
                                    return "1";
                                }
                                return "2";
                            }
                        };
                        return shimHttpRequest;
                    }
                };
            };

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
            var fieldId = new Guid("CA4AA59C-17EB-4BF1-94B7-960970D07802");

            _sharepointShims.ListShim.IDGet = () => listId;
            _sharepointShims.ListShim.GetItemsSPQuery = query => 
                new ShimSPListItemCollection().Bind(
                    new SPListItem[] 
                    {
                        new ShimSPListItem
                        {
                            FieldsGet = () => new ShimSPFieldCollection
                            {
                                GetFieldByInternalNameString = filter => new ShimSPField
                                {
                                    IdGet = () => fieldId
                                }
                            },
                            ItemGetGuid = id => fieldId
                        }
                    });

            var arguments = new object[] 
            {
                (SPWeb)_sharepointShims.WebShim,
                "select",
                (SPList)_sharepointShims.ListShim,
                new SortedList()
            };

            var method = typeof(getgantttasks).GetMethod(
                "processList",
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy,
                null,
                new[] 
                {
                    typeof(SPWeb),
                    typeof(string),
                    typeof(SPList),
                    typeof(SortedList)
                },
                null);

            // Act
            method.Invoke(_getGanttTasks, arguments);

            //_getGanttTasksPrivate.Invoke("processList", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy, arguments);

            // Assert
        }
    }
}
