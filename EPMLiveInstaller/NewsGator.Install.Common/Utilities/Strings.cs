using System.Security;

namespace NewsGator.Install.Common.Utilities
{
    internal static class Strings
    {
        internal static SecureString ToSecureString(this string current)
        {
            if (!string.IsNullOrEmpty(current))
            {
                using (var secure = new SecureString())
                {
                    foreach (var c in current.ToCharArray())
                        secure.AppendChar(c);
                    return secure;
                }
            }
            else
                return null;
        }
    }
}
