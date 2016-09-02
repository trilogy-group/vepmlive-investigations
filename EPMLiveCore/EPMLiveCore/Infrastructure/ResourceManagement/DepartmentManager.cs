using Microsoft.SharePoint;

namespace EPMLiveCore.Infrastructure
{
    public sealed class DepartmentManager : SPListItemManager
    {
        #region Constructors (1)

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourcePoolManager"/> class.
        /// </summary>
        public DepartmentManager()
            : base("Departments", SPContext.Current.Web.ID, SPContext.Current.Site.ID, "Departments", "Department")
        {
        }

        public DepartmentManager(SPWeb web)
            : base("Departments", web.ID, web.Site.ID, "Departments", "Department")
        {
        }

        #endregion Constructors
    }
}