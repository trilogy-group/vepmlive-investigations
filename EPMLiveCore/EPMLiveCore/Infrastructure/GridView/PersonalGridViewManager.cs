using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using EPMLiveCore.API;
using Microsoft.SharePoint;

namespace EPMLiveCore.Infrastructure
{
    public abstract class PersonalGridViewManager : IGridViewManager
    {
        #region Constructors (2) 

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalGridViewManager"/> class.
        /// </summary>
        /// <param name="viewKey">The view key.</param>
        protected PersonalGridViewManager(string viewKey)
        {
            SPContext spContext = SPContext.Current;

            Key = viewKey;

            ConnectionString = CoreFunctions.getConnectionString(spContext.Site.WebApplication.Id);

            SiteId = spContext.Site.ID;
            WebId = spContext.Web.ID;
            UserId = spContext.Web.CurrentUser.ID;
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="PersonalGridViewManager"/> is reclaimed by garbage collection.
        /// </summary>
        ~PersonalGridViewManager()
        {
            Dispose(false);
        }

        #endregion Constructors 

        #region Properties (6) 

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        protected string ConnectionString { get; private set; }

        /// <summary>
        /// Gets the site id.
        /// </summary>
        protected Guid SiteId { get; private set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>
        /// The user id.
        /// </value>
        protected int UserId { get; private set; }

        /// <summary>
        /// Gets the web id.
        /// </summary>
        protected Guid WebId { get; private set; }

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
                    IEnumerable<GridView> views = DeserializeViews(GetSerializedViews());

                    return views != null ? views.ToList() : new List<GridView>();
                }
                catch (Exception e)
                {
                    throw new APIException((int) Errors.PersonalGVMList, e.Message);
                }
            }
        }

        #endregion Properties 

        #region Methods (15) 

        // Public Methods (7) 

        /// <summary>
        /// Adds the specified grid view.
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        public virtual void Add(GridView gridView)
        {
            try
            {
                List<GridView> gridViews = GridViewUtils.ResetDefaultGridView(gridView, List);

                Save(gridViews);
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.PersonalGVMAdd, e.Message);
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
        /// Finds the view by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public GridView FindBy(string id)
        {
            GridView gridView = (from v in List where v.Id.Equals(id) select v).FirstOrDefault();

            if (gridView == null)
            {
                throw new APIException((int) Errors.PersonalGVMFindById,
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
                List<GridView> gridViews = List;
                gridViews.RemoveAll(v => v.Id.Equals(gridView.Id));

                Save(gridViews);
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.PersonalGVMRemove, e.Message);
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
                if (FindBy(gridView.Id) != null)
                {
                    Add(gridView);
                }
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.PersonalGVMUpdate, e.Message);
            }
        }

        /// <summary>
        /// Validates the authorization.
        /// </summary>
        /// <param name="loginName">Name of the login.</param>
        /// <returns></returns>
        public virtual bool ValidateAuthorization(string loginName)
        {
            throw new NotImplementedException();
        }

        // Protected Methods (1) 

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(Boolean disposing)
        {
        }

        // Private Methods (7) 

        private IEnumerable<GridView> DeserializeViews(string serializedViews)
        {
            IEnumerable<GridView> views = null;

            if (!string.IsNullOrEmpty(serializedViews))
            {
                var xmlSerializer = new XmlSerializer(typeof (List<GridView>));
                views = (IEnumerable<GridView>) xmlSerializer.Deserialize(new StringReader(serializedViews));
            }

            return views;
        }

        /// <summary>
        /// Executes the specified action with elevated privileges.
        /// </summary>
        /// <param name="action">The action.</param>
        private void ExecuteElevated(Action action)
        {
            SPSecurity.RunWithElevatedPrivileges(() => action());
        }

        /// <summary>
        /// Gets the serialized views.
        /// </summary>
        /// <returns></returns>
        private string GetSerializedViews()
        {
            string serializedViews = null;

            ExecuteElevated(() => GetViews(out serializedViews));

            return serializedViews;
        }

        /// <summary>
        /// Gets the views.
        /// </summary>
        /// <param name="serializedViews">The serialized views.</param>
        private void GetViews(out string serializedViews)
        {
            try
            {
                serializedViews = null;

                using (var sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    var sqlCommand = new SqlCommand("spVGetPersonalView", sqlConnection)
                                         {CommandType = CommandType.StoredProcedure};

                    SqlParameter key = sqlCommand.Parameters.Add("@Key", SqlDbType.NVarChar);
                    SqlParameter userId = sqlCommand.Parameters.Add("@UserId", SqlDbType.Int);
                    SqlParameter webId = sqlCommand.Parameters.Add("@WebId", SqlDbType.UniqueIdentifier);
                    SqlParameter siteId = sqlCommand.Parameters.Add("@SiteId", SqlDbType.UniqueIdentifier);

                    key.Value = Key;
                    userId.Value = UserId;
                    webId.Value = WebId;
                    siteId.Value = SiteId;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        serializedViews = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Value"));
                    }
                }
            }
            catch (SqlException sqlException)
            {
                throw new APIException((int) Errors.PersonalGVMGetViews, sqlException.Message);
            }
        }

        /// <summary>
        /// Saves the specified grid views.
        /// </summary>
        /// <param name="gridViews">The grid views.</param>
        private void Save(List<GridView> gridViews)
        {
            ExecuteElevated(() => SaveViews(gridViews));
        }

        /// <summary>
        /// Saves the views.
        /// </summary>
        /// <param name="gridViews">The grid views.</param>
        private void SaveViews(List<GridView> gridViews)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    string serializedViews = SerializeViews(gridViews);

                    var sqlCommand = new SqlCommand("spVAddOrUpdatePersonalView", sqlConnection)
                                         {CommandType = CommandType.StoredProcedure};

                    SqlParameter key = sqlCommand.Parameters.Add("@Key", SqlDbType.NVarChar);
                    SqlParameter value = sqlCommand.Parameters.Add("@Value", SqlDbType.NText);
                    SqlParameter userId = sqlCommand.Parameters.Add("@UserId", SqlDbType.Int);
                    SqlParameter webId = sqlCommand.Parameters.Add("@WebId", SqlDbType.UniqueIdentifier);
                    SqlParameter siteId = sqlCommand.Parameters.Add("@SiteId", SqlDbType.UniqueIdentifier);

                    key.Value = Key;
                    value.Value = serializedViews;
                    userId.Value = UserId;
                    webId.Value = WebId;
                    siteId.Value = SiteId;

                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw new APIException((int) Errors.PersonalGVMSaveViews, sqlException.Message);
            }
        }

        /// <summary>
        /// Serializes the views.
        /// </summary>
        /// <param name="gridViews">The grid views.</param>
        /// <returns></returns>
        private string SerializeViews(List<GridView> gridViews)
        {
            string serializedViews;

            using (var stringWriter = new StringWriter())
            {
                var xmlSerializer = new XmlSerializer(typeof (List<GridView>));
                xmlSerializer.Serialize(stringWriter, gridViews);

                serializedViews = stringWriter.ToString();
            }

            return serializedViews;
        }

        #endregion Methods 
    }
}