using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using LiveCoreExtensions = EPMLiveCore.ExtensionMethods;

namespace EPMLiveWebParts
{
    public static class ExtensionMethods
    {
        #region Methods (2) 

        // Public Methods (2) 

        /// <summary>
        /// Lower cases the specified val.
        /// </summary>
        /// <param name="val">if set to <c>true</c> [val].</param>
        /// <returns></returns>
        public static string Lc(this bool val)
        {
            return val.ToString().ToLower();
        }

        /// <summary>
        /// Returns prettier name of the field.
        /// </summary>
        /// <param name="internalName">Name of the internal.</param>
        /// <returns></returns>
        public static string ToPrettierName(this string internalName)
        {
            return LiveCoreExtensions.ToPrettierName(internalName);
        }

        /// <summary>
        /// Generates MD5 hash for the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string Md5(this string value)
        {
            byte[] data = Encoding.ASCII.GetBytes(value);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(data);

            return hashData.Aggregate(string.Empty, (current, b) => current + b.ToString("X2")).ToUpper();
        }

        #endregion Methods
    }    
}