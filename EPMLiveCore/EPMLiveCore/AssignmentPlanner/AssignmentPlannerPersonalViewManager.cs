using EPMLiveCore.Infrastructure;

namespace EPMLiveCore.AssignmentPlanner
{
    internal sealed class AssignmentPlannerPersonalViewManager : PersonalGridViewManager
    {
        #region Fields (1) 

        private const string EPMLiveAssignmentPlannerPersonalView = "EPMLiveAssignmentPlannerPersonalView";

        #endregion Fields 

        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignmentPlannerPersonalViewManager"/> class.
        /// </summary>
        public AssignmentPlannerPersonalViewManager()
            : base(EPMLiveAssignmentPlannerPersonalView)
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