using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PortfolioEngineCore.Tests
{
    [TestClass]
    public class PfeJobTest
    {
        [TestMethod]
        public void PfeJob_Should_Be_Saved_In_Queue()
        {
            var sut = new Fakes.StubPfeJob();
            var messageQueued = false;
            using (ShimsContext.Create())
            {
                var dbrepository = new Fakes.ShimDbRepository()
                {
                    QueuePfeJobPfeJob = (job) => { return 1; }
                };
                var messageQueue = new Fakes.ShimMsmq()
                {
                    QueueString = (input) => messageQueued = true
                };
                var output = sut.Queue(dbrepository.Instance, messageQueue.Instance, "TestPath");
                Assert.AreEqual(output, 1);
                Assert.IsTrue(messageQueued);
            }
        }
    }
}