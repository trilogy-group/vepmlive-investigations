using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Web.Caching;
using System.Web.Hosting;

namespace EPMLiveSignals.Infrastructure
{
    internal class SignalRVirtualPathProvider : VirtualPathProvider
    {
        #region Methods (9) 

        // Public Methods (9) 

        public override string CombineVirtualPaths(string basePath, string relativePath)
        {
            return Previous.CombineVirtualPaths(basePath, relativePath);
        }

        public override ObjRef CreateObjRef(Type requestedType)
        {
            return Previous.CreateObjRef(requestedType);
        }

        public override bool DirectoryExists(string virtualDir)
        {
            if (!string.IsNullOrEmpty(virtualDir) && virtualDir.Contains("signalr"))
            {
                return Previous.DirectoryExists(virtualDir.TrimStart('~'));
            }

            try
            {
                return Previous.DirectoryExists(virtualDir);
            }
            catch
            {
                return false;
            }
        }

        public override bool FileExists(string virtualPath)
        {
            return Previous.FileExists(virtualPath);
        }

        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies,
            DateTime utcStart)
        {
            return Previous.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
        }

        public override string GetCacheKey(string virtualPath)
        {
            return Previous.GetCacheKey(virtualPath);
        }

        public override VirtualDirectory GetDirectory(string virtualDir)
        {
            return Previous.GetDirectory(virtualDir);
        }

        public override VirtualFile GetFile(string virtualPath)
        {
            return Previous.GetFile(virtualPath);
        }

        public override string GetFileHash(string virtualPath, IEnumerable virtualPathDependencies)
        {
            return Previous.GetFileHash(virtualPath, virtualPathDependencies);
        }

        #endregion Methods 
    }
}