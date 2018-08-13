using System.Collections.Generic;
using System.IO;
using System.IO.Fakes;

namespace EPMLive.TestFakes.Utility
{
    public class IOShims
    {
        private static IOShims _instance;
        public static IOShims Instance
        {
            get { return _instance ?? (_instance = ShimIO()); }
        }

        public ShimStream StreamShim { get; private set; }

        // (CC-75592, 2018-08-13) Some of the types from mscorlib can not be shimmed, if project is not targeting latest .NET Framework version
        // https://blogs.msdn.microsoft.com/harshjain/2016/12/29/generating-fakes-assembly-for-system-dll-for-test-project/
        // Which prevents of from mocking certain types and interfaces like MemoryStream
        
        public IList<Stream> StreamsCreated { get; private set; }
        public IList<Stream> StreamsDisposed { get; private set; }

        private IOShims()
        {
            StreamShim = new ShimStream(new MemoryStream());

            StreamsCreated = new List<Stream>();
            StreamsDisposed = new List<Stream>();
        }

        public static IOShims ShimIO()
        {
            var result = new IOShims();
            result.InitializeStaticShims();

            return result;
        }

        private void InitializeStaticShims()
        {
            ShimStream.Constructor = instance => StreamsCreated.Add(instance);
            ShimStream.AllInstances.Dispose = instance => StreamsDisposed.Add(instance);
            ShimStream.AllInstances.DisposeBoolean = (instance, flag) => StreamsDisposed.Add(instance);
        }
    }
}
