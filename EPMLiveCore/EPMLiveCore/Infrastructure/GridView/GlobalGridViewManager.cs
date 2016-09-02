using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using EPMLiveCore.API;
using Microsoft.SharePoint;

namespace EPMLiveCore.Infrastructure
{
    public abstract class GlobalGridViewManager : IGridViewManager
    {
        #region Constructors (2) 

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalGridViewManager"/> class.
        /// </summary>
        /// <param name="viewKey">The view key.</param>
        protected GlobalGridViewManager(string viewKey)
        {
            Key = viewKey;
            LoginName = SPContext.Current.Web.CurrentUser.LoginName;
            ConfigWeb = Utils.GetConfigWeb();
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="GlobalGridViewManager"/> is reclaimed by garbage collection.
        /// </summary>
        ~GlobalGridViewManager()
        {
            Dispose(false);
        }

        #endregion Constructors 

        #region Properties (4) 

        /// <summary>
        /// Gets the config web.
        /// </summary>
        protected SPWeb ConfigWeb { get; private set; }

        /// <summary>
        /// Gets the name of the login.
        /// </summary>
        /// <value>
        /// The name of the login.
        /// </value>
        protected string LoginName { get; private set; }

        /// <summary>
        /// Gets the key.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Gets the list.
        /// </summary>
        public virtual List<GridView> List
        {
            get
            {
                try
                {
                    IEnumerable<GridView> views = null;

                    SPWeb configWeb = ConfigWeb;

                    using (configWeb)
                    {
                        string serializedViews = CoreFunctions.getConfigSetting(configWeb, Key);

                        if (!string.IsNullOrEmpty(serializedViews))
                        {
                            var xmlSerializer = new XmlSerializer(typeof (List<GridView>));
                            views = (IEnumerable<GridView>) xmlSerializer.Deserialize(new StringReader(serializedViews));
                        }
                    }

                    return views != null ? views.ToList() : new List<GridView>();
                }
                catch (Exception e)
                {
                    throw new APIException((int) Errors.GlobalGVMList, e.Message);
                }
            }
        }

        #endregion Properties 

        #region Methods (11) 

        // Public Methods (7) 

        /// <summary>
        /// Adds the specified grid view.
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        public virtual void Add(GridView gridView)
        {
            try
            {
                if (!ValidateAuthorization())
                {
                    throw new APIException((int) Errors.GlobalGVMAddNoPermission,
                                           string.Format("{0} does not have permission to add a global view.", LoginName));
                }

                SPWeb configWeb = ConfigWeb;

                using (configWeb)
                {
                    List<GridView> gridViews = GridViewUtils.ResetDefaultGridView(gridView, List);

                    Save(configWeb, gridViews);
                }
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.GlobalGVMAdd, e.Message);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finds the grid view by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public GridView FindBy(string id)
        {
            GridView gridView = (from v in List where v.Id.Equals(id) select v).FirstOrDefault();

            if (gridView == null)
            {
                throw new APIException((int) Errors.GlobalGVMFindById,
                                       string.Format("Cannot find the global view with ID: {0}", id));
            }

            return gridView;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns></returns>
        public abstract void Initialize();

        /// <summary>
        /// Removes the specified grid view.
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        public virtual void Remove(GridView gridView)
        {
            try
            {
                if (!ValidateAuthorization())
                {
                    throw new APIException((int) Errors.GlobalGVMRemoveNoAccess,
                                           string.Format("{0} does not have permission to delete a global view.",
                                                         LoginName));
                }

                SPWeb configWeb = ConfigWeb;

                using (configWeb)
                {
                    List<GridView> gridViews = List;
                    gridViews.RemoveAll(v => v.Id.Equals(gridView.Id));

                    Save(configWeb, gridViews);
                }
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.GlobalGVMRemove, e.Message);
            }
        }

        /// <summary>
        /// Updates the specified grid view.
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        public void Update(GridView gridView)
        {
            try
            {
                if (!ValidateAuthorization())
                {
                    throw new APIException((int) Errors.GlobalGVMUpdateNoAccess,
                                           string.Format("{0} does not have permission to update a global view.",
                                                         LoginName));
                }

                if (FindBy(gridView.Id) != null)
                {
                    Add(gridView);
                }
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.GlobalGVMUpdate, e.Message);
            }
        }

        /// <summary>
        /// Validates the authorization.
        /// </summary>
        /// <param name="loginName">Name of the login.</param>
        /// <returns></returns>
        public virtual bool ValidateAuthorization(string loginName)
        {
            try
            {
                return ConfigWeb.DoesUserHavePermissions(loginName, SPBasePermissions.AddAndCustomizePages);
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.GlobalGVMValidateAuthorization, e.Message);
            }
        }

        // Protected Methods (2) 

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(Boolean disposing)
        {
            if (!disposing) return;

            if (ConfigWeb == null) return;

            ConfigWeb.Dispose();
            ConfigWeb = null;
        }

        /// <summary>
        /// Validates the authorization.
        /// </summary>
        /// <returns></returns>
        protected bool ValidateAuthorization()
        {
            return ValidateAuthorization(LoginName);
        }

        // Private Methods (2) 

        /// <summary>
        /// Serializes and adds the list of grid views to the property bag at the config level.
        /// </summary>
        /// <param name="configWeb">The config web.</param>
        /// <param name="gridViews">The grid views.</param>
        private void Save(SPWeb configWeb, List<GridView> gridViews)
        {
            using (var stringWriter = new StringWriter())
            {
                var xmlSerializer = new XmlSerializer(typeof (List<GridView>));
                xmlSerializer.Serialize(stringWriter, gridViews);

                string setting = stringWriter.ToString();
                SPSecurity.RunWithElevatedPrivileges(() => SetConfigSetting(setting, configWeb));
            }
        }

        /// <summary>
        /// Sets the config setting.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <param name="configWeb">The config web.</param>
        private void SetConfigSetting(string setting, SPWeb configWeb)
        {
            configWeb.AllowUnsafeUpdates = true;
            CoreFunctions.setConfigSetting(configWeb, Key, setting);
            configWeb.AllowUnsafeUpdates = false;
        }

        #endregion Methods 
    }
}