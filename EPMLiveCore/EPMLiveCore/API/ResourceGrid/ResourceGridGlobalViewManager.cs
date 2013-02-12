using System;
using System.Linq;
using System.Xml.Linq;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Properties;

namespace EPMLiveCore.API
{
    internal sealed class ResourceGridGlobalViewManager : GlobalGridViewManager
    {
        #region Fields (1) 

        private const string EPMLiveResourceGridGlobalViews = "EPMLiveResourceGridGlobalViews";

        #endregion Fields 

        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGridGlobalViewManager"/> class.
        /// </summary>
        public ResourceGridGlobalViewManager() : base(EPMLiveResourceGridGlobalViews)
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
                int version = Convert.ToInt32(Resources.ResourceGridDefaultGlobalViewVersion);
                bool proceed = false;

                GridView gridView = (List.Where(view => view.Id.Equals("dv"))).FirstOrDefault();

                if (gridView == null) proceed = true;

                if (gridView != null && gridView.Version < version)
                {
                    Remove(gridView);
                    proceed = true;
                }

                if (!proceed) return;

                if (List.Exists(v => v.Id.Equals("dv"))) return;

                var panelColElement = new XElement("Col");
                panelColElement.Add(new XAttribute("Name", "Panel"));
                panelColElement.Add(new XAttribute("Width", 14));
                panelColElement.Add(new XAttribute("IsFixedWidth", true));
                panelColElement.Add(new XAttribute("Section", 0));

                var picColElement = new XElement("Col");
                picColElement.Add(new XAttribute("Name", "ProfilePic"));
                picColElement.Add(new XAttribute("Width", 70));
                picColElement.Add(new XAttribute("IsFixedWidth", true));
                picColElement.Add(new XAttribute("Section", 0));

                var titleColElement = new XElement("Col");
                titleColElement.Add(new XAttribute("Name", "Title"));
                titleColElement.Add(new XAttribute("Width", 98));
                titleColElement.Add(new XAttribute("IsFixedWidth", false));
                titleColElement.Add(new XAttribute("Section", 0));

                var colsElement = new XElement("Cols");
                colsElement.Add(panelColElement, picColElement, titleColElement);

                var filtersElement = new XElement("Filters");
                filtersElement.Add(new XAttribute("RowVisible", false));

                var groupingElement = new XElement("Grouping");
                groupingElement.Add(new XAttribute("RowVisible", false));

                var sortingElement = new XElement("Sorting", "Title");

                var viewElement = new XElement("View");
                viewElement.Add(new XAttribute("Id", "dv"));
                viewElement.Add(new XAttribute("Name", "Default View"));
                viewElement.Add(new XAttribute("IsDefault", true));
                viewElement.Add(new XAttribute("IsPersonal", false));

                viewElement.Add(colsElement);
                viewElement.Add(filtersElement);
                viewElement.Add(groupingElement);
                viewElement.Add(sortingElement);

                Add(new GridView {Id = "dv", Version = version, Definition = viewElement.ToString()});
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) ResourceGrid.Errors.RPGVMInitialize, e.Message);
            }
        }

        #endregion Methods 
    }
}