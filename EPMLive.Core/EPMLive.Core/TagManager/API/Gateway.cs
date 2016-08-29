using EPMLiveCore.API;
using Microsoft.SharePoint;

namespace EPMLiveCore.TagManager.API
{
    public class Gateway
    {
        #region Methods (4) 

        // Public Methods (4) 

        /// <summary>
        ///     Adds the tag order.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public string AddTagOrder(string data, SPWeb spWeb)
        {
            try
            {
                var tagManager = new TagManager(spWeb);
                return Response.Success(tagManager.AddTagOrder(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        ///     Gets the tag.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public string GetTag(string data, SPWeb spWeb)
        {
            try
            {
                var tagManager = new TagManager(spWeb);
                return Response.Success(tagManager.GetTag(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        ///     Registers the tag.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public string RegisterTag(string data, SPWeb spWeb)
        {
            try
            {
                var tagManager = new TagManager(spWeb);
                return Response.Success(tagManager.RegisterTag(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        ///     Removes the tag order.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public string RemoveTagOrder(string data, SPWeb spWeb)
        {
            try
            {
                var tagManager = new TagManager(spWeb);
                return Response.Success(tagManager.RemoveTagOrder(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        #endregion Methods 
    }
}