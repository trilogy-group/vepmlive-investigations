using System;
using System.Linq;
using System.Xml.Linq;
using EPMLiveCore.API;
using EPMLiveCore.Infrastructure;

namespace EPMLiveCore.AssignmentPlanner
{
    internal sealed class AssignmentPlannerGlobalViewManager : GlobalGridViewManager
    {
        #region Fields (1) 

        private const string EPMLiveAssignmentPlannerGlobalViews = "EPMLiveAssignmentPlannerGlobalViews";
        private const int Version = 3;

        #endregion Fields 

        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignmentPlannerGlobalViewManager"/> class.
        /// </summary>
        public AssignmentPlannerGlobalViewManager()
            : base(EPMLiveAssignmentPlannerGlobalViews)
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
            try
            {
                bool proceed = false;

                GridView gridView = (List.Where(view => view.Id.Equals("dv"))).FirstOrDefault();

                if(gridView==null) proceed = true;

                if (gridView != null && gridView.Version < Version)
                {
                    Remove(gridView);
                    proceed = true;
                }

                if(!proceed) return;

                var panelColElement = new XElement("Col");
                panelColElement.Add(new XAttribute("Name", "Panel"));
                panelColElement.Add(new XAttribute("Width", 14));
                panelColElement.Add(new XAttribute("IsFixedWidth", true));
                panelColElement.Add(new XAttribute("Section", 0));

                var commentCountColElement = new XElement("Col");
                commentCountColElement.Add(new XAttribute("Name", "CommentCount"));
                commentCountColElement.Add(new XAttribute("Width", 25));
                commentCountColElement.Add(new XAttribute("IsFixedWidth", true));
                commentCountColElement.Add(new XAttribute("Section", 0));

                var assigneColElement = new XElement("Col");
                assigneColElement.Add(new XAttribute("Name", "AssignedToText"));
                assigneColElement.Add(new XAttribute("Width", 200));
                assigneColElement.Add(new XAttribute("IsFixedWidth", true));
                assigneColElement.Add(new XAttribute("Section", 0));

                var titleColElement = new XElement("Col");
                titleColElement.Add(new XAttribute("Name", "Title"));
                titleColElement.Add(new XAttribute("Width", 100));
                titleColElement.Add(new XAttribute("IsFixedWidth", false));
                titleColElement.Add(new XAttribute("Section", 0));

                var startDateColElement = new XElement("Col");
                startDateColElement.Add(new XAttribute("Name", "StartDate"));
                startDateColElement.Add(new XAttribute("Width", 100));
                startDateColElement.Add(new XAttribute("IsFixedWidth", true));
                startDateColElement.Add(new XAttribute("Section", 1));

                var dueDateColElement = new XElement("Col");
                dueDateColElement.Add(new XAttribute("Name", "DueDate"));
                dueDateColElement.Add(new XAttribute("Width", 100));
                dueDateColElement.Add(new XAttribute("IsFixedWidth", true));
                dueDateColElement.Add(new XAttribute("Section", 1));

                var workColElement = new XElement("Col");
                workColElement.Add(new XAttribute("Name", "Work"));
                workColElement.Add(new XAttribute("Width", 75));
                workColElement.Add(new XAttribute("IsFixedWidth", true));
                workColElement.Add(new XAttribute("Section", 1));

                var durationColElement = new XElement("Col");
                durationColElement.Add(new XAttribute("Name", "Duration"));
                durationColElement.Add(new XAttribute("Width", 100));
                durationColElement.Add(new XAttribute("IsFixedWidth", true));
                durationColElement.Add(new XAttribute("Section", 1));

                var percentCompleteColElement = new XElement("Col");
                percentCompleteColElement.Add(new XAttribute("Name", "PercentComplete"));
                percentCompleteColElement.Add(new XAttribute("Width", 100));
                percentCompleteColElement.Add(new XAttribute("IsFixedWidth", true));
                percentCompleteColElement.Add(new XAttribute("Section", 1));

                var gColElement = new XElement("Col");
                gColElement.Add(new XAttribute("Name", "G"));
                gColElement.Add(new XAttribute("Width", 100));
                gColElement.Add(new XAttribute("IsFixedWidth", false));
                gColElement.Add(new XAttribute("Section", 2));

                var colsElement = new XElement("Cols");
                colsElement.Add(panelColElement, commentCountColElement, assigneColElement, titleColElement,
                                startDateColElement, dueDateColElement, workColElement, durationColElement,
                                percentCompleteColElement, gColElement);

                var filtersElement = new XElement("Filters");
                filtersElement.Add(new XAttribute("RowVisible", false));

                var groupingElement = new XElement("Grouping", "AssignedToText");
                groupingElement.Add(new XAttribute("RowVisible", false));

                var sortingElement = new XElement("Sorting", "StartDate");

                var viewElement = new XElement("View");
                viewElement.Add(new XAttribute("Id", "dv"));
                viewElement.Add(new XAttribute("Name", "Default View"));
                viewElement.Add(new XAttribute("IsDefault", true));
                viewElement.Add(new XAttribute("IsPersonal", false));

                viewElement.Add(colsElement);
                viewElement.Add(filtersElement);
                viewElement.Add(groupingElement);
                viewElement.Add(sortingElement);

                Add(new GridView { Id = "dv", Version = Version, Definition = viewElement.ToString() });
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(18300, e.Message);
            }
        }

        #endregion Methods 
    }
}