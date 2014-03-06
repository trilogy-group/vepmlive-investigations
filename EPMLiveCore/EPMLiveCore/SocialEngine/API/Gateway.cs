using EPMLiveCore.API;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine.API
{
    public class Gateway
    {
        #region Methods (1) 

        // Public Methods (1) 

        public string GetActivities(string data, SPWeb spWeb)
        {
            try
            {
                return Response.Success(data);
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        #endregion Methods 
    }
}