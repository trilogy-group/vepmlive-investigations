using EPMLiveCore.Infrastructure;

namespace EPMLiveCore.API
{
    internal sealed class ResourceGridPersonalViewManager : PersonalGridViewManager
    {
        #region Fields (1) 

        private const string EPMLiveResourceGridPersonalView = "EPMLiveResourceGridPersonalView";

        #endregion Fields 

        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGridPersonalViewManager"/> class.
        /// </summary>
        public ResourceGridPersonalViewManager() : base(EPMLiveResourceGridPersonalView)
        {
        }

        #endregion Constructors 

        #region Methods (1) 

        // Public Methods (1) 

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public override void Initialize()
        {
        }

        #endregion Methods 
    }
}