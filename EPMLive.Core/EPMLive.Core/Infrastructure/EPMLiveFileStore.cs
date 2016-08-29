using System;
using System.IO;
using System.Linq;
using Microsoft.SharePoint;

namespace EPMLiveCore.Infrastructure
{
    public class EPMLiveFileStore : IDisposable
    {
        #region Fields (4) 

        private const string FILE_STORE_NAME = "EPMLiveFileStore";
        private SPDocumentLibrary _fileStore;
        private SPSite _spSite;
        private SPWeb _spWeb;

        #endregion Fields 

        #region Constructors (2) 

        /// <summary>
        ///     Initializes a new instance of the <see cref="EPMLiveFileStore" /> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public EPMLiveFileStore(SPWeb spWeb)
        {
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                _spSite = new SPSite(spWeb.Site.ID);
                _spWeb = _spSite.OpenWeb(spWeb.ID);

                _fileStore = (SPDocumentLibrary) _spWeb.Lists.TryGetList(FILE_STORE_NAME) ?? CreateFileStore();
            });
        }

        /// <summary>
        ///     Releases unmanaged resources and performs other cleanup operations before the
        ///     <see cref="EPMLiveFileStore" /> is reclaimed by garbage collection.
        /// </summary>
        ~EPMLiveFileStore()
        {
            Dispose(false);
        }

        #endregion Constructors 

        #region Methods (8) 

        // Public Methods (6) 

        /// <summary>
        ///     Adds the specified bytes to the EPM Live file store.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public string Add(byte[] content)
        {
            return Add(content, string.Empty);
        }

        public static byte[] GetBytes(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using(MemoryStream ms = new MemoryStream())
            {
                int read;
                while((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        /// <summary>
        ///     Adds the specified bytes to the EPM Live file store.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="fileExtension">The file extension.</param>
        public string Add(byte[] content, string fileExtension)
        {
            string fileName = Guid.NewGuid().ToString();
            if (!string.IsNullOrEmpty(fileExtension)) fileName += "." + fileExtension.Trim('.');
            _spWeb.AllowUnsafeUpdates = true;
            _spSite.AllowUnsafeUpdates = true;
            _fileStore.RootFolder.Files.Add(fileName, content);
            _fileStore.RootFolder.Update();
            _fileStore.Update();

            return fileName;
        }

        /// <summary>
        ///     Deletes the specified file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public void Delete(string fileName)
        {
            _fileStore.RootFolder.Files.Delete(fileName);
            _fileStore.RootFolder.Update();
            _fileStore.Update();
        }

        /// <summary>
        ///     Gets the specified file bytes.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public byte[] Get(string fileName)
        {
            return GetFile(fileName).OpenBinary();
        }

        /// <summary>
        ///     Gets the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public SPFile GetFile(string fileName)
        {
            return _spWeb.GetFile(_fileStore.RootFolder.Url + "/" + fileName.Trim('/'));
        }

        /// <summary>
        ///     Gets the specified file stream.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public Stream GetStream(string fileName)
        {
            return GetFile(fileName).OpenBinaryStream();
        }

        // Private Methods (2) 

        /// <summary>
        ///     Creates the file store.
        /// </summary>
        /// <returns></returns>
        private SPDocumentLibrary CreateFileStore()
        {
            _spWeb.AllowUnsafeUpdates = true;

            SPListTemplate spListTemplate = _spWeb.ListTemplates["Document Library"];
            SPDocTemplate spDocTemplate =
                (from SPDocTemplate dt in _spWeb.DocTemplates where dt.Type == 100 select dt).FirstOrDefault();

            Guid fileStoreId = _spWeb.Lists.Add(FILE_STORE_NAME, "EPM Live File Store", spListTemplate, spDocTemplate);

            var spDocumentLibrary = (SPDocumentLibrary) _spWeb.Lists[fileStoreId];
            spDocumentLibrary.OnQuickLaunch = false;
            spDocumentLibrary.Hidden = true;
            spDocumentLibrary.Update();

            _spWeb.AllowUnsafeUpdates = false;

            return (SPDocumentLibrary) _spWeb.Lists[FILE_STORE_NAME];
        }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.
        /// </param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_spWeb != null)
                {
                    _spWeb.Dispose();
                    _spWeb = null;
                }

                if (_spSite != null)
                {
                    _spSite.Dispose();
                    _spSite = null;
                }
            }
        }

        #endregion Methods 

        #region Implementation of IDisposable

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}