using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;

namespace EPMLiveCore.Infrastructure
{
    internal static class GridViewUtils
    {
        #region Methods (2) 

        // Internal Methods (2) 

        /// <summary>
        /// Extracts the views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static IEnumerable<GridView> ExtractViews(string data)
        {
            XDocument viewsXml = XDocument.Parse(data);

            if (viewsXml.Root == null)
            {
                throw new Exception("Cannot find the Root element.");
            }

            var gridViews = new List<GridView>();

            foreach (XElement viewElement in viewsXml.Root.Elements("View"))
            {
                XAttribute idAttribute = viewElement.Attribute("Id");

                if (idAttribute == null)
                {
                    throw new Exception("Cannot find the view Id.");
                }

                gridViews.Add(new GridView {Id = idAttribute.Value, Definition = viewElement.ToString()});
            }

            return gridViews;
        }

        /// <summary>
        /// Resets the default grid view.
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        /// <param name="gridViews">The grid views.</param>
        /// <returns></returns>
        internal static List<GridView> ResetDefaultGridView(GridView gridView, List<GridView> gridViews)
        {
            // ReSharper disable PossibleNullReferenceException

            if (Convert.ToBoolean(XDocument.Parse(gridView.Definition).Root.Attribute("IsDefault").Value))
            {
                var views = new List<GridView>();

                foreach (GridView view in gridViews)
                {
                    if (view.Id.Equals(gridView.Id)) continue;

                    GridView theView = view;

                    XDocument viewXml = XDocument.Parse(theView.Definition);
                    viewXml.Root.Attribute("IsDefault").Value = false.ToString(CultureInfo.InvariantCulture);
                    theView.Definition = viewXml.ToString();

                    views.Add(theView);
                }

                gridViews.Clear();
                gridViews = views;
            }

            gridViews.RemoveAll(v => v.Id.Equals(gridView.Id));
            gridViews.Add(gridView);

            // ReSharper restore PossibleNullReferenceException

            return gridViews;
        }

        #endregion Methods 
    }
}