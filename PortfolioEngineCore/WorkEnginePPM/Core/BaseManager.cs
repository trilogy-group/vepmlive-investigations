using System;
using System.Xml.Linq;
using Microsoft.SharePoint;

namespace WorkEnginePPM.Core
{
    public abstract class BaseManager : IDisposable
    {
        #region Constructors (2) 

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseManager" /> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        protected BaseManager(SPWeb spWeb)
        {
            Web = spWeb;

            Username = ConfigFunctions.GetCleanUsername(spWeb);
        }

        /// <summary>
        ///     Releases unmanaged resources and performs other cleanup operations before the
        ///     <see cref="BaseManager" /> is reclaimed by garbage collection.
        /// </summary>
        ~BaseManager()
        {
            Dispose(false);
        }

        #endregion Constructors 

        #region Properties (2) 

        /// <summary>
        ///     Gets the username.
        /// </summary>
        protected string Username
        {
            get;
            private set;
        }

        /// <summary>
        ///     Gets the SP web.
        /// </summary>
        protected SPWeb Web
        {
            get;
            private set;
        }

        #endregion Properties 

        #region Methods (3) 

        // Public Methods (1) 

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected Methods (2) 

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only
        ///     unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (Web == null) return;

            Web.Dispose();
            Web = null;
        }

        /// <summary>
        ///     Validates the response.
        /// </summary>
        /// <param name="element">The element.</param>
        protected virtual void ValidateResponse(XElement element)
        {
            if (element == null) return;

            if (element.Name.LocalName.Equals("Result"))
            {
                XAttribute statusAttribute = element.Attribute("Status");

                if (statusAttribute == null || !statusAttribute.Value.Equals("1") || statusAttribute.Parent == null)
                    return;

                XElement errorElement = statusAttribute.Parent.Element("Error");

                if (errorElement != null) throw new Exception(errorElement.Value);
            }
            else
            {
                foreach (XElement resultElement in element.Descendants("Result"))
                {
                    XAttribute statusAttribute = resultElement != null
                        ? resultElement.Attribute("Status")
                        : element.Attribute("Status");

                    if (statusAttribute == null || !statusAttribute.Value.Equals("1") || statusAttribute.Parent == null)
                        continue;

                    XElement errorElement = statusAttribute.Parent.Element("Error");

                    if (errorElement != null) throw new Exception(errorElement.Value);
                }
            }
        }

        #endregion Methods 
    }
}