using Microsoft.SharePoint;

namespace EPMLiveCore.Infrastructure
{
    public abstract class BaseManager
    {
        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseManager"/> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        protected BaseManager(SPWeb spWeb)
        {
            Web = spWeb;
        }

        #endregion Constructors 

        #region Properties (1) 

        /// <summary>
        /// Gets the SP web.
        /// </summary>
        protected SPWeb Web { get; private set; }

        #endregion Properties 
    }
}