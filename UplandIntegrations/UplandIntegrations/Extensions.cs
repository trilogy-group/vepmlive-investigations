using System;
using System.Runtime.InteropServices;
using System.Security;

namespace UplandIntegrations
{
    internal static class Extensions
    {
        #region Methods (2) 

        // Public Methods (2) 

        public static SecureString ToSecureString(this string unsecureString)
        {
            if (string.IsNullOrEmpty(unsecureString))
            {
                throw new ArgumentNullException("unsecureString");
            }

            var secureString = new SecureString();

            foreach (char c in unsecureString)
            {
                secureString.AppendChar(c);
            }

            secureString.MakeReadOnly();

            return secureString;
        }

        public static string ToUnsecureString(this SecureString secureString)
        {
            if (secureString == null)
            {
                throw new ArgumentNullException("secureString");
            }

            IntPtr unmanagedStrPtr = IntPtr.Zero;

            try
            {
                unmanagedStrPtr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedStrPtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedStrPtr);
            }
        }

        #endregion Methods 
    }
}