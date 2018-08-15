using System;
using System.Collections.Generic;
using System.ComponentModel.Fakes;
using System.DirectoryServices;
using System.DirectoryServices.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLive.TestFakes.Utility
{
    public class DirectoryShims
    {
        public IList<DirectoryEntry> DirectoryEntriesDisposed { get; }
        public IList<DirectorySearcher> DirectorySearchersDisposed { get; }

        private DirectoryShims()
        {
            DirectoryEntriesDisposed = new List<DirectoryEntry>();
            DirectorySearchersDisposed = new List<DirectorySearcher>();
        }

        public static DirectoryShims ShimDirectoryCalls()
        {
            var shims = new DirectoryShims();
            shims.InitializeStaticShims();
            return shims;
        }

        public void InitializeStaticShims()
        {
            ShimDirectoryEntry.AllInstances.DisposeBoolean = (instance, flag) =>
            {
                DirectoryEntriesDisposed.Add(instance);
            };
            ShimDirectorySearcher.AllInstances.DisposeBoolean = (instance, flag) =>
            {
                DirectorySearchersDisposed.Add(instance);
            };
            ShimComponent.AllInstances.Dispose = instance =>
            {
                var directoryEntry = instance as DirectoryEntry;
                if (directoryEntry != null)
                {
                    DirectoryEntriesDisposed.Add(directoryEntry);
                }

                var directorySearcher = instance as DirectorySearcher;
                if (directorySearcher != null)
                {
                    DirectorySearchersDisposed.Add(directorySearcher);
                }
            };
        }
    }
}
