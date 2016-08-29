using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

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
            #region Character Map

            var charMap = new Dictionary<string, string>
                              {
                                  {" ", "_x0020_"},
                                  {"`", "_x0060_"},
                                  {"/", "_x002f_"},
                                  {".", "_x002e_"},
                                  {",", "_x002c_"},
                                  {"?", "_x003f_"},
                                  {">", "_x003e_"},
                                  {"<", "_x003c_"},
                                  {"\\", "_x005c_"},
                                  {"'", "_x0027_"},
                                  {";", "_x003b_"},
                                  {"|", "_x007c_"},
                                  {"\"", "_x0022_"},
                                  {":", "_x003a_"},
                                  {"}", "_x007d_"},
                                  {"{", "_x007b_"},
                                  {"=", "_x003d_"},
                                  {"-", "_x002d_"},
                                  {"+", "_x002b_"},
                                  {")", "_x0029_"},
                                  {"(", "_x0028_"},
                                  {"*", "_x002a_"},
                                  {"&", "_x0026_"},
                                  {"^", "_x005e_"},
                                  {"%", "_x0025_"},
                                  {"$", "_x0024_"},
                                  {"#", "_x0023_"},
                                  {"@", "_x0040_"},
                                  {"!", "_x0021_"},
                                  {"~", "_x007e_"}
                              };

            #endregion

            internalName = charMap.Aggregate(internalName, (current, pair) => current.Replace(pair.Value, pair.Key.ToString()));
            internalName = Regex.Replace(Regex.Replace(internalName, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), @"(\p{Ll})(\P{Ll})", "$1 $2");

            var regex = new Regex(@"[ ]{2,}", RegexOptions.None);

            return regex.Replace(internalName, @" ");
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