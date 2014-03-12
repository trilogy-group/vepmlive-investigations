using EPMLiveCore.API;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine.API
{
    public class Gateway
    {
        #region Methods (1) 

        // Public Methods (1) 

        public string ProcessActivity(string data, SPWeb spWeb)
        {
            try
            {
                return SocialEngine.Current.ProcessActivity(data);
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        #endregion Methods 
    }
}