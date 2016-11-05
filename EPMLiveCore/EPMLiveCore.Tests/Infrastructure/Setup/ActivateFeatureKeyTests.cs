using EPMLiveCore.FeatureActivationSvc.Fakes;
using EPMLiveCore.Infrastructure.Setup.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace EPMLiveCore.Infrastructure.Setup.Tests
{
    [TestClass()]
    public class ActivateFeatureKeyTests
    {
        [TestMethod()]
        public void ActivateTest_ActivationSuccessful()
        {
            string result = String.Empty;
            string key = "zbISHHWm7r4SPOusOCuPv2OaBNq0OftnXITUpfpjV39kJWXfdA1YUrXtornB0Wa6";
            using (SPEmulators.SPEmulationContext ctx = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                ActivateFeatureKey activateFeatureKey = new ActivateFeatureKey();

                ShimService.AllInstances.ActivateKeyString = (instance, a) =>
                {
                    return 0;
                };

                ShimActivateFeatureKey.AllInstances.insertKeyString = (instance, a) =>
                {
                    return true;
                };

                ShimActivateFeatureKey.AllInstances.addKeyString = (instance, a) =>
                {
                    return true;
                };

                result = activateFeatureKey.Activate(key);
                Assert.AreEqual(result, "Activation Successful");
            }
        }

        [TestMethod()]
        public void ActivateTest_ActivationFailed()
        {
            string result = String.Empty;
            string key = "zbISHHWm7r4SPOusOCuPv2OaBNq0OftnXITUpfpjV39kJWXfdA1YUrXtornB0Wa6";
            using (SPEmulators.SPEmulationContext ctx = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                ActivateFeatureKey activateFeatureKey = new ActivateFeatureKey();

                ShimService.AllInstances.ActivateKeyString = (instance, a) =>
                {
                    return 0;
                };

                ShimActivateFeatureKey.AllInstances.insertKeyString = (instance, a) =>
                {
                    return false;
                };

                ShimActivateFeatureKey.AllInstances.addKeyString = (instance, a) =>
                {
                    return false;
                };

                result = activateFeatureKey.Activate(key);
                Assert.AreEqual(result, "Activation Failed:<br>");
            }
        }

        [TestMethod()]
        public void ActivateTest_InvalidKey()
        {
            string result = String.Empty;
            string key = "zbISHHWm7r4SPOusOCuPv6ybCkJF0I4wVN+I4M9TqZ72+ZWYGKL58/rTcQmItfLC";
            using (SPEmulators.SPEmulationContext ctx = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                ActivateFeatureKey activateFeatureKey = new ActivateFeatureKey();

                ShimService.AllInstances.ActivateKeyString = (instance, a) =>
                {
                    return 1;
                };

                ShimActivateFeatureKey.AllInstances.insertKeyString = (instance, a) =>
                {
                    return false;
                };

                ShimActivateFeatureKey.AllInstances.addKeyString = (instance, a) =>
                {
                    return false;
                };

                result = activateFeatureKey.Activate(key);
                Assert.AreEqual(result, "Invalid Key");
            }
        }

        [TestMethod()]
        public void ActivateTest_TooManyActivations()
        {
            string result = String.Empty;
            string key = "zbISHHWm7r4SPOusOCuPv6ybCkJF0I4wVN+I4M9TqZ72+ZWYGKL58/rTcQmItfLC";
            using (SPEmulators.SPEmulationContext ctx = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                ActivateFeatureKey activateFeatureKey = new ActivateFeatureKey();

                ShimService.AllInstances.ActivateKeyString = (instance, a) =>
                {
                    return 2;
                };

                ShimActivateFeatureKey.AllInstances.insertKeyString = (instance, a) =>
                {
                    return false;
                };

                ShimActivateFeatureKey.AllInstances.addKeyString = (instance, a) =>
                {
                    return false;
                };

                result = activateFeatureKey.Activate(key);
                Assert.AreEqual(result, "Too many activations");
            }
        }

        [TestMethod()]
        public void ActivateTest_StarActivationSuccessful()
        {
            string result = String.Empty;
            string key = "*";
            using (SPEmulators.SPEmulationContext ctx = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                ActivateFeatureKey activateFeatureKey = new ActivateFeatureKey();

                ShimActivateFeatureKey.AllInstances.insertKeyString = (instance, a) =>
                {
                    return true;
                };

                ShimActivateFeatureKey.AllInstances.addKeyString = (instance, a) =>
                {
                    return true;
                };

                result = activateFeatureKey.Activate(key);
                Assert.AreEqual(result, "Activation Successful");
            }
        }

        [TestMethod()]
        public void ActivateTest_StarActivationFailed()
        {
            string result = String.Empty;
            string key = "*";
            using (SPEmulators.SPEmulationContext ctx = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                ActivateFeatureKey activateFeatureKey = new ActivateFeatureKey();

                ShimActivateFeatureKey.AllInstances.insertKeyString = (instance, a) =>
                {
                    return false;
                };

                ShimActivateFeatureKey.AllInstances.addKeyString = (instance, a) =>
                {
                    return false;
                };

                result = activateFeatureKey.Activate(key);
                Assert.AreEqual(result, "Activation Failed:<br>");
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void ActivateTest_NotImplementedException()
        {
            string result = String.Empty;
            string key = "zbISHHWm7r4SPOusOCuPv6ybCkJF0I4wVN+I4M9TqZ72+ZWYGKL58/rTcQmItfLC";
            using (SPEmulators.SPEmulationContext ctx = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                ActivateFeatureKey activateFeatureKey = new ActivateFeatureKey();

                ShimService.AllInstances.ActivateKeyString = (instance, a) =>
                {
                    throw new NotImplementedException();
                };

                ShimActivateFeatureKey.AllInstances.insertKeyString = (instance, a) =>
                {
                    return false;
                };

                ShimActivateFeatureKey.AllInstances.addKeyString = (instance, a) =>
                {
                    return false;
                };
                result = activateFeatureKey.Activate(key);
            }
        }

    }
}