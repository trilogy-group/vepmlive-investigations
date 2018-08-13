﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Fakes;

namespace EPMLive.TestFakes.Utility
{
    public class CryptographyShims
    {
        public ShimRijndaelManaged RijndaelManagedShim { get; private set; }
        public ShimDeriveBytes DeriveBytesShim { get; private set; }
        public ShimCryptoStream CryptoStreamShim { get; private set; }

        // (CC-75592, 2018-08-13) Some of the types from mscorlib can not be shimmed, if project is not targeting latest .NET Framework version
        // https://blogs.msdn.microsoft.com/harshjain/2016/12/29/generating-fakes-assembly-for-system-dll-for-test-project/
        // Which prevents of from mocking certain types and interfaces like ICryptoTransform

        public IList<RijndaelManaged> RijndaelManagedCreated { get; private set; }
        public IList<SymmetricAlgorithm> SymmetricAlgorithmsDisposed { get; private set; }
        public IList<DeriveBytes> DeriveBytesCreated { get; private set; }
        public IList<DeriveBytes> DeriveBytesDisposed { get; private set; }
        public IList<CryptoStream> CryptoStreamsCreated { get; private set; }

        private CryptographyShims()
        {
            RijndaelManagedShim = new ShimRijndaelManaged();
            DeriveBytesShim = new ShimDeriveBytes(new PasswordDeriveBytes(string.Empty, new byte[0]));
            CryptoStreamShim = new ShimCryptoStream();

            RijndaelManagedCreated = new List<RijndaelManaged>();
            SymmetricAlgorithmsDisposed = new List<SymmetricAlgorithm>();
            DeriveBytesCreated = new List<DeriveBytes>();
            DeriveBytesDisposed = new List<DeriveBytes>();
            CryptoStreamsCreated = new List<CryptoStream>();
        }

        public static CryptographyShims ShimCryptographyCalls()
        {
            var result = new CryptographyShims();
            result.InitializeStaticShims();

            return result;
        }

        private void InitializeStaticShims()
        {
            ShimRijndaelManaged.Constructor = instance => RijndaelManagedCreated.Add(instance);
            ShimSymmetricAlgorithm.AllInstances.Dispose = instance => SymmetricAlgorithmsDisposed.Add(instance);
            ShimSymmetricAlgorithm.AllInstances.DisposeBoolean = (instance, flag) => SymmetricAlgorithmsDisposed.Add(instance);

            ShimDeriveBytes.Constructor = instance => DeriveBytesCreated.Add(instance);
            ShimDeriveBytes.AllInstances.Dispose = instance => DeriveBytesDisposed.Add(instance);

            ShimCryptoStream.ConstructorStreamICryptoTransformCryptoStreamMode = (instance, a, b, c) => CryptoStreamsCreated.Add(instance);
        }

        public bool CheckIfAllRijindaelManagedDisposed()
        {
            return RijndaelManagedCreated.All(pred => SymmetricAlgorithmsDisposed.Contains(pred));
        }

        public bool CheckIfAllDeriveBytesDisposed()
        {
            return DeriveBytesCreated.All(pred => DeriveBytesDisposed.Contains(pred));
        }

        public bool CheckIfAllCryptoStreamsDisposed()
        {
            return CryptoStreamsCreated.All(pred => IOShims.Instance.StreamsDisposed.Contains(pred));
        }
    }
}
