using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using EPMLiveCore.API;

namespace EPMLiveCore.Infrastructure
{
    public enum GridViewManagerKind
    {
        Global,
        Personal
    }

    public sealed class GridViewManagerFactory : IDisposable
    {
        #region Fields (1) 

        private Dictionary<string, Dictionary<GridViewManagerKind, IGridViewManager>> _gridViewManagers =
            new Dictionary<string, Dictionary<GridViewManagerKind, IGridViewManager>>();

        #endregion Fields 

        #region Constructors (3) 

        /// <summary>
        /// Initializes a new instance of the <see cref="GridViewManagerFactory"/> class.
        /// </summary>
        /// <param name="assemblyFullName">Name of the assembly.</param>
        public GridViewManagerFactory(string assemblyFullName)
        {
            Assembly assembly = Assembly.Load(assemblyFullName);

            IEnumerable<Type> typeEnumerable = assembly.GetTypes()
                .Where(t => t.BaseType != null && t.BaseType.IsAbstract && t.BaseType.Name.Contains("GridViewManager"));

            foreach (Type type in typeEnumerable)
            {
                GridViewManagerKind? kind = null;
                string componentName = string.Empty;

                string typeName = type.Name;

                if (typeName.Contains("Global"))
                {
                    kind = GridViewManagerKind.Global;
                    componentName = typeName.Substring(0, typeName.IndexOf("Global", StringComparison.Ordinal));
                }
                else if (typeName.Contains("Personal"))
                {
                    kind = GridViewManagerKind.Personal;
                    componentName = typeName.Substring(0, typeName.IndexOf("Personal", StringComparison.Ordinal));
                }

                if (kind == null || string.IsNullOrEmpty(componentName)) continue;

                if (!_gridViewManagers.ContainsKey(componentName))
                {
                    _gridViewManagers.Add(componentName, new Dictionary<GridViewManagerKind, IGridViewManager>());
                }

                _gridViewManagers[componentName].Add((GridViewManagerKind) kind,
                                                     (IGridViewManager) Activator.CreateInstance(type));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GridViewManagerFactory"/> class.
        /// </summary>
        public GridViewManagerFactory() : this(Assembly.GetCallingAssembly().FullName)
        {
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="GridViewManagerFactory"/> is reclaimed by garbage collection.
        /// </summary>
        ~GridViewManagerFactory()
        {
            Dispose(false);
        }

        #endregion Constructors 

        #region Methods (4) 

        // Public Methods (2) 

        /// <summary>
        /// Makes the grid view manager.
        /// </summary>
        /// <param name="componentName">Name of the component.</param>
        /// <param name="gridViewManagerKind">Kind of the grid view manager.</param>
        /// <returns></returns>
        public IGridViewManager MakeGridViewManager(string componentName, GridViewManagerKind gridViewManagerKind)
        {
            ValidateRequest(componentName, gridViewManagerKind);
            return _gridViewManagers[componentName][gridViewManagerKind];
        }

        /// <summary>
        /// Makes the grid view manager.
        /// </summary>
        /// <param name="componentName">Name of the component.</param>
        /// <param name="gridView">The grid view.</param>
        /// <returns></returns>
        public IGridViewManager MakeGridViewManager(string componentName, GridView gridView)
        {
            XDocument definitionXml = XDocument.Parse(gridView.Definition);

            if (definitionXml.Root == null)
            {
                throw new APIException((int) Errors.GVFNoRoot, "Cannot find the Root element.");
            }

            XAttribute isPersonalAttribute = definitionXml.Root.Attribute("IsPersonal");

            if (isPersonalAttribute == null)
            {
                throw new APIException((int) Errors.GVFNoIsPersonalAttr, "Cannot find the IsPersonal attribute.");
            }

            return MakeGridViewManager(componentName,
                                       bool.Parse(isPersonalAttribute.Value)
                                           ? GridViewManagerKind.Personal
                                           : GridViewManagerKind.Global);
        }

        // Private Methods (2) 

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(Boolean disposing)
        {
            if (!disposing) return;

            if (_gridViewManagers == null) return;

            _gridViewManagers.Clear();
            _gridViewManagers = null;
        }

        /// <summary>
        /// Validates the request.
        /// </summary>
        /// <param name="componentName">Name of the component.</param>
        /// <param name="gridViewManagerKind">Kind of the grid view manager.</param>
        private void ValidateRequest(string componentName, GridViewManagerKind gridViewManagerKind)
        {
            if (!_gridViewManagers.ContainsKey(componentName))
            {
                throw new APIException((int) Errors.GVFInvalidComponent, "Invalid component name.");
            }

            Dictionary<GridViewManagerKind, IGridViewManager> gridViewManagers = _gridViewManagers[componentName];

            if (!gridViewManagers.ContainsKey(gridViewManagerKind))
            {
                throw new APIException((int) Errors.GVFViewKindNotFound,
                                       string.Format("Cannot find the {0} view manager for {1}",
                                                     gridViewManagerKind.ToString().ToLower(), componentName));
            }
        }

        #endregion Methods 

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}