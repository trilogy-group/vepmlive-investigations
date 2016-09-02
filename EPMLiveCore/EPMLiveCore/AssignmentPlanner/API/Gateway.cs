using EPMLiveCore.API;
using Microsoft.SharePoint;

namespace EPMLiveCore.AssignmentPlanner.API
{
    public class Gateway
    {
        #region Methods (10) 

        // Public Methods (10) 

        /// <summary>
        /// Deletes the views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public string DeleteViews(string data, SPWeb spWeb)
        {
            try
            {
                var gridManager = new GridManager(spWeb);
                return Response.Success(gridManager.DeleteViews(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Gets the grid data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public string GetGridData(string data, SPWeb spWeb)
        {
            try
            {
                var gridManager = new GridManager(spWeb);
                return gridManager.GetData(data);
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Gets the grid layout.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public string GetGridLayout(string data, SPWeb spWeb)
        {
            try
            {
                var gridManager = new GridManager(spWeb);
                return gridManager.GetLayout(data);
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public string GetModel(string data, SPWeb spWeb)
        {
            try
            {
                var gridManager = new GridManager(spWeb);
                return gridManager.GetModel(data);
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Loads the models.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public string LoadModels(string data, SPWeb spWeb)
        {
            try
            {
                var gridManager = new GridManager(spWeb);
                return Response.Success(gridManager.LoadModels(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Loads the views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public string LoadViews(string data, SPWeb spWeb)
        {
            try
            {
                var gridManager = new GridManager(spWeb);
                return Response.Success(gridManager.LoadViews(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Publishes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public string Publish(string data, SPWeb spWeb)
        {
            try
            {
                var assignmentManager = new AssignmentManager(spWeb);
                return Response.Success(assignmentManager.Publish(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Saves the models.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public string SaveModels(string data, SPWeb spWeb)
        {
            try
            {
                var gridManager = new GridManager(spWeb);
                return Response.Success(gridManager.SaveModels(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Saves the views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public string SaveViews(string data, SPWeb spWeb)
        {
            try
            {
                var gridManager = new GridManager(spWeb);
                return Response.Success(gridManager.SaveViews(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Updates the views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public string UpdateViews(string data, SPWeb spWeb)
        {
            try
            {
                var gridManager = new GridManager(spWeb);
                return Response.Success(gridManager.UpdateViews(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        #endregion Methods 
    }
}