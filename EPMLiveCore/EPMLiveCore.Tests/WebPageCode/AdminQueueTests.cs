using System;
using System.Collections.Generic;
using System.Data.SqlClient.Fakes;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.WebPageCode
{
    [TestClass]
    public class AdminQueueTests
    {
        private const int DummyLength = 10;
        private const int DummyJobTime = 24;
        private const int DummyWait = 30;
        private const int DummyMaxQueue = 1024;
        private const int DummyMaxJob = 100;
        private const int DummyTotalJobs = 10;

        private adminqueue _adminQueue;
        private AdoShims _adoShims;
        private IDisposable _context;
        private PrivateObject _privateObject;
        private SharepointShims _sharepointShims;

        private Label _jobLabel;
        private Label _lengthLabel;
        private Label _maxJobLabel;
        private Label _maxQueueLabel;
        private Label _totalJobsLabel;
        private Label _waitLabel;
        private bool _dataBindCalled;

        [TestInitialize]
        public void Setup()
        {
            _context = ShimsContext.Create();
            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();

            _adminQueue = new adminqueue();
            _privateObject = new PrivateObject(_adminQueue);
        }

        [TestCleanup]
        public void TearDown()
        {
            _context = ShimsContext.Create();
        }

        [TestMethod]
        public void GetInfo_EverythingValid_DisposesCorrectly()
        {
            // Arrange
            ArrangeGetInfo(
                new List<bool>
                {
                    true,
                    true
                },
                new List<bool>
                {
                    true,
                    true,
                    true,
                    true,
                    true,
                });

            // Act
            _privateObject.Invoke("GetInfo");

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _lengthLabel.Text.ShouldBe(DummyLength.ToString()),
                () => _jobLabel.Text.ShouldBe(RunShowTime(DummyJobTime)),
                () => _waitLabel.Text.ShouldBe(RunShowTime(DummyWait)),
                () => _maxJobLabel.Text.ShouldBe(RunShowTime(DummyMaxJob)),
                () => _maxQueueLabel.Text.ShouldBe(RunShowTime(DummyMaxQueue)),
                () => _totalJobsLabel.Text.ShouldBe(DummyTotalJobs.ToString()),
                () => _dataBindCalled.ShouldBeTrue(),
                () => _adoShims.CommandsDisposed.Count.ShouldBe(3),
                () => _adoShims.ConnectionsDisposed.Count.ShouldBe(1),
                () => _adoShims.DataReadersDisposed.Count.ShouldBe(2),
                () => _adoShims.DataAdaptersDisposed.Count.ShouldBe(1));
        }

        [TestMethod]
        public void GetInfo_InvalidTotalJobs_DisposesCorrectly()
        {
            // Arrange
            ArrangeGetInfo(
                new List<bool>
                {
                    true,
                    true
                },
                new List<bool>
                {
                    true,
                    true,
                    true,
                    true,
                    false,
                });

            // Act
            _privateObject.Invoke("GetInfo");

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _lengthLabel.Text.ShouldBe(DummyLength.ToString()),
                () => _jobLabel.Text.ShouldBe(RunShowTime(DummyJobTime)),
                () => _waitLabel.Text.ShouldBe(RunShowTime(DummyWait)),
                () => _maxJobLabel.Text.ShouldBe(RunShowTime(DummyMaxJob)),
                () => _maxQueueLabel.Text.ShouldBe(RunShowTime(DummyMaxQueue)),
                () => _totalJobsLabel.Text.ShouldBeEmpty(),
                () => _dataBindCalled.ShouldBeTrue(),
                () => _adoShims.CommandsDisposed.Count.ShouldBe(3),
                () => _adoShims.ConnectionsDisposed.Count.ShouldBe(1),
                () => _adoShims.DataReadersDisposed.Count.ShouldBe(2),
                () => _adoShims.DataAdaptersDisposed.Count.ShouldBe(1));
        }

        [TestMethod]
        public void GetInfo_InvalidMaxQueue_DisposesCorrectly()
        {
            // Arrange
            ArrangeGetInfo(
                new List<bool>
                {
                    true,
                    true
                },
                new List<bool>
                {
                    true,
                    true,
                    true,
                    false,
                    true,
                });

            // Act
            _privateObject.Invoke("GetInfo");

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _lengthLabel.Text.ShouldBe(DummyLength.ToString()),
                () => _jobLabel.Text.ShouldBe(RunShowTime(DummyJobTime)),
                () => _waitLabel.Text.ShouldBe(RunShowTime(DummyWait)),
                () => _maxJobLabel.Text.ShouldBe(RunShowTime(DummyMaxJob)),
                () => _maxQueueLabel.Text.ShouldBeEmpty(),
                () => _totalJobsLabel.Text.ShouldBe(DummyTotalJobs.ToString()),
                () => _dataBindCalled.ShouldBeTrue(),
                () => _adoShims.CommandsDisposed.Count.ShouldBe(3),
                () => _adoShims.ConnectionsDisposed.Count.ShouldBe(1),
                () => _adoShims.DataReadersDisposed.Count.ShouldBe(2),
                () => _adoShims.DataAdaptersDisposed.Count.ShouldBe(1));
        }

        [TestMethod]
        public void GetInfo_InvalidMaxJob_DisposesCorrectly()
        {
            // Arrange
            ArrangeGetInfo(
                new List<bool>
                {
                    true,
                    true
                },
                new List<bool>
                {
                    true,
                    true,
                    false,
                    true,
                    true,
                });

            // Act
            _privateObject.Invoke("GetInfo");

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _lengthLabel.Text.ShouldBe(DummyLength.ToString()),
                () => _jobLabel.Text.ShouldBe(RunShowTime(DummyJobTime)),
                () => _waitLabel.Text.ShouldBe(RunShowTime(DummyWait)),
                () => _maxJobLabel.Text.ShouldBeEmpty(),
                () => _maxQueueLabel.Text.ShouldBe(RunShowTime(DummyMaxQueue)),
                () => _totalJobsLabel.Text.ShouldBe(DummyTotalJobs.ToString()),
                () => _dataBindCalled.ShouldBeTrue(),
                () => _adoShims.CommandsDisposed.Count.ShouldBe(3),
                () => _adoShims.ConnectionsDisposed.Count.ShouldBe(1),
                () => _adoShims.DataReadersDisposed.Count.ShouldBe(2),
                () => _adoShims.DataAdaptersDisposed.Count.ShouldBe(1));
        }

        [TestMethod]
        public void GetInfo_InvalidWait_DisposesCorrectly()
        {
            // Arrange
            ArrangeGetInfo(
                new List<bool>
                {
                    true,
                    true
                },
                new List<bool>
                {
                    true,
                    false,
                    true,
                    true,
                    true,
                });

            // Act
            _privateObject.Invoke("GetInfo");

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _lengthLabel.Text.ShouldBe(DummyLength.ToString()),
                () => _jobLabel.Text.ShouldBe(RunShowTime(DummyJobTime)),
                () => _waitLabel.Text.ShouldBeEmpty(),
                () => _maxJobLabel.Text.ShouldBe(RunShowTime(DummyMaxJob)),
                () => _maxQueueLabel.Text.ShouldBe(RunShowTime(DummyMaxQueue)),
                () => _totalJobsLabel.Text.ShouldBe(DummyTotalJobs.ToString()),
                () => _dataBindCalled.ShouldBeTrue(),
                () => _adoShims.CommandsDisposed.Count.ShouldBe(3),
                () => _adoShims.ConnectionsDisposed.Count.ShouldBe(1),
                () => _adoShims.DataReadersDisposed.Count.ShouldBe(2),
                () => _adoShims.DataAdaptersDisposed.Count.ShouldBe(1));
        }

        [TestMethod]
        public void GetInfo_InvalidJob_DisposesCorrectly()
        {
            // Arrange
            ArrangeGetInfo(
                new List<bool>
                {
                    true,
                    true
                },
                new List<bool>
                {
                    false,
                    true,
                    true,
                    true,
                    true,
                });

            // Act
            _privateObject.Invoke("GetInfo");

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _lengthLabel.Text.ShouldBe(DummyLength.ToString()),
                () => _jobLabel.Text.ShouldBeEmpty(),
                () => _waitLabel.Text.ShouldBe(RunShowTime(DummyWait)),
                () => _maxJobLabel.Text.ShouldBe(RunShowTime(DummyMaxJob)),
                () => _maxQueueLabel.Text.ShouldBe(RunShowTime(DummyMaxQueue)),
                () => _totalJobsLabel.Text.ShouldBe(DummyTotalJobs.ToString()),
                () => _dataBindCalled.ShouldBeTrue(),
                () => _adoShims.CommandsDisposed.Count.ShouldBe(3),
                () => _adoShims.ConnectionsDisposed.Count.ShouldBe(1),
                () => _adoShims.DataReadersDisposed.Count.ShouldBe(2),
                () => _adoShims.DataAdaptersDisposed.Count.ShouldBe(1));
        }

        private void ArrangeGetInfo(List<bool> dataShouldRead, List<bool> dbShouldContain)
        {
            SetAdminQueueFields();

            ShimCoreFunctions.getConnectionStringGuid = _ => "DummyConnectionString";
            ShimContextSelector<SPWebApplication>.AllInstances.CurrentItemGet =
                _ => (SPWebApplication)new ShimSPPersistedObject(new ShimSPWebApplication());
            ShimSPPersistedObject.AllInstances.IdGet = _ => new Guid("41025103102401520120102030405021");

            var dataReadCallCount = 0;
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                var shouldRead = dataShouldRead[dataReadCallCount];
                dataReadCallCount++;
                return shouldRead;
            };
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (_, i) =>
            {
                if (dataReadCallCount == 1)
                {
                    if (i == 0)
                    {
                        return DummyLength;
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 0:
                            return DummyJobTime;
                        case 1:
                            return DummyWait;
                        case 2:
                            return DummyMaxJob;
                        case 3:
                            return DummyMaxQueue;
                        case 4:
                            return DummyTotalJobs;
                        default:
                            return int.MinValue;
                    }
                }
                return int.MinValue;
            };
            ShimSqlDataReader.AllInstances.IsDBNullInt32 = (_, i) => !dbShouldContain[i];
            _dataBindCalled = false;
            ShimGridView.AllInstances.DataBind = _ => _dataBindCalled = true;
        }

        private void SetAdminQueueFields()
        {
            _lengthLabel = new Label();
            _waitLabel = new Label();
            _jobLabel = new Label();
            _maxQueueLabel = new Label();
            _maxJobLabel = new Label();
            _totalJobsLabel = new Label();

            _privateObject.SetField(
                "WebApplicationSelector1",
                (WebApplicationSelector)new ShimContextSelector<SPWebApplication>(new ShimWebApplicationSelector()));

            _privateObject.SetField("lblLength", _lengthLabel);
            _privateObject.SetField("lblWait", _waitLabel);
            _privateObject.SetField("lblJobTime", _jobLabel);
            _privateObject.SetField("lblMaxQueue", _maxQueueLabel);
            _privateObject.SetField("lblMaxJob", _maxJobLabel);
            _privateObject.SetField("lblTotalJobs", _totalJobsLabel);

            _privateObject.SetField("GvItems", (SPGridView)new ShimGridView(new ShimSPGridView()));
        }

        public string RunShowTime(int input)
        {
            return (string)_privateObject.Invoke("showtime",input);
        }
    }
}