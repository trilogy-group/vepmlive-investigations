using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

namespace PortfolioEngineCore.Tests
{
    [TestClass]
    public class PfeJobTest
    {
        [TestMethod]
        public void PfeJob_Should_Be_Saved_In_Queue()
        {
            // Arrange.
            var sut = new PfeJob();
            var dbRepository = Mock.Create<IDbRepository>();
            var msmq = Mock.Create<IMessageQueue>();
            Mock.Arrange(() => dbRepository.QueuePfeJob(Arg.IsAny<PfeJob>())).Returns(1);

            // Act.
            var output = sut.Queue(dbRepository, msmq, "TestPath");

            // Assert.
            Assert.AreEqual(output, 1);
            Mock.Assert(() => msmq.Queue("TestPath"), Occurs.Exactly(1));
        }
    }
}