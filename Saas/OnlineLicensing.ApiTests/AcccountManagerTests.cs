using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPMLive.OnlineLicensing.Api;

namespace EPMLive.OnlineLicensing.ApiTests
{
    [TestClass]
    public class AcccountManagerTests
    {
        [TestMethod]
        public void GetAccountReference()
        {
            //arrange
            var context = new SampleTestDataGenerator().GenerateLicensingModelWithSampleAccount();
            var accountManager = new AccountManager(context);
            var accountId = Guid.Parse("00000000-0000-0000-0000-000000000000");

            //act
            var result = accountManager.GetAccountReference(accountId);

            //assert
            Assert.AreEqual(11111, result);
        }
    }
}
