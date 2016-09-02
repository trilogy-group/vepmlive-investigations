using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public class Personalization
    {
        #region Methods (2) 

        // Public Methods (2) 

        public string Get(string data, SPWeb spWeb)
        {
            try
            {
                var personalizationManager = new PersonalizationManager(spWeb);
                return Response.Success(personalizationManager.GetPersonalization(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public string Set(string data, SPWeb spWeb)
        {
            try
            {
                var personalizationManager = new PersonalizationManager(spWeb);
                return Response.Success(personalizationManager.SetPersonalization(data));
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        #endregion Methods 
    }
}