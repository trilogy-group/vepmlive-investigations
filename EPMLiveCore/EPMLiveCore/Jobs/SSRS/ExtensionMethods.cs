using EPMLiveCore.SSRS2010;
using System.Linq;

namespace EPMLiveCore.Jobs.SSRS
{
    public static class ExtensionMethods
    {
        public static Role GetRole(this Role[] roles, string role)
        {
            return roles.Single(x => x.Name == role);
        }
    }
}