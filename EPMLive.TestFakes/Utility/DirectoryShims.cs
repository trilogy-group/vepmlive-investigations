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
        public ShimDirectoryEntry DirectoryEntryShim { get; private set; }
        public ShimSearchResult SearchResultShim { get; private set; }
        public ShimSearchResultCollection SearchResultsShim { get; private set; }

        public IList<DirectoryEntry> DirectoryEntriesDisposed { get; }
        public IList<DirectorySearcher> DirectorySearchersDisposed { get; }

        private DirectoryShims()
        {
            DirectoryEntryShim = InitializeShimDirectoryEntry();
            SearchResultShim = InitializeShimSearchResult();
            SearchResultsShim = InitializeShimSearchResultCollection();

            DirectoryEntriesDisposed = new List<DirectoryEntry>();
            DirectorySearchersDisposed = new List<DirectorySearcher>();
        }

        public ShimDirectoryEntry InitializeShimDirectoryEntry()
        {
            var directoryEntryShim = new ShimDirectoryEntry
            {
                NameGet = () => string.Empty
            };
            return directoryEntryShim;
        }

        public ShimSearchResult InitializeShimSearchResult()
        {
            return new ShimSearchResult
            {
                GetDirectoryEntry = () => DirectoryEntryShim
            };
        }

        public ShimSearchResultCollection InitializeShimSearchResultCollection()
        {
            var result = new ShimSearchResultCollection
            {
                ItemGetInt32 = index => SearchResultShim
            };

            result.Bind(new SearchResult[] { SearchResultShim });
            return result;
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

            ShimDirectorySearcher.AllInstances.FindAll = instance => SearchResultsShim;
        }
    }
}
