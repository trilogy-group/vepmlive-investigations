using System;
using EPMLiveIntegration;

namespace EPMLiveCore.Integrations.Salesforce
{
    public partial class Integrator
    {
        private static void GetAuthParameters(
            WebProperties webProps,
            out string username,
            out string password,
            out string securityToken,
            out bool isSandbox)
        {
            username = webProps.Properties["Username"].ToString();
            if (string.IsNullOrEmpty(username))
            {
                throw new Exception("Please provide the username.");
            }
            password = webProps.Properties["Password"].ToString();
            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("Please provide the password.");
            }
            securityToken = webProps.Properties["SecurityToken"].ToString();
            if (string.IsNullOrEmpty(securityToken))
            {
                throw new Exception("Please provide the security token.");
            }
            try
            {
                isSandbox = bool.Parse(webProps.Properties["Sandbox"].ToString());
            }
            catch
            {
                isSandbox = false;
            }
        }

        private static SfService GetSfService(WebProperties webProps)
        {
            string username;
            string password;
            string securityToken;
            bool isSandbox;

            GetAuthParameters(webProps, out username, out password, out securityToken, out isSandbox);

            return new SfService(username, password, securityToken, isSandbox);
        }

        private string GetMatchingListColumn(string displayName, string internalName, string appNamespace)
        {
            switch (internalName)
            {
                case "Id":
                    return "INTUID";
                case "Name":
                    return "Title";
            }

            if (internalName.Equals(appNamespace + "__EPM_Live_ID__c"))
            {
                return "SPID";
            }

            //@todo: setup matching columns.

            return displayName.Replace("%", "Percent").Replace(" ", string.Empty);
        }
    }
}