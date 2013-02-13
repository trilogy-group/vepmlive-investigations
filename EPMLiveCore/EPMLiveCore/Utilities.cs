using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPMLiveCore
{
    public static class Utilities
    {
        #region Methods (2) 

        // Public Methods (2) 

        /// <summary>
        /// Composes the caml query.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="op">The op.</param>
        /// <param name="whereClause">The where clause.</param>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public static string ComposeCamlQuery(IList<string> parameters, string op, string whereClause, string query)
        {
            return parameters.Count == 1
                       ? string.Format(whereClause, string.Format(query, parameters[0]))
                       : ComposeCamlQuery(parameters.Skip(1).ToList(), op,
                                          string.Format(whereClause,
                                                        string.Format("<{0}>{1}{{0}}</{0}>", op,
                                                                      string.Format(query, parameters[0]))), query);
        }

        /// <summary>
        /// Decodes the grid data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string DecodeGridData(string data)
        {
            string decodedData = HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(data));

            if (decodedData == null)
            {
                throw new Exception("Unable to decode the grid data.");
            }

            return decodedData;
        }

        #endregion Methods 
    }
}