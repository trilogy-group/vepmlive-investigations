using System;
using System.Xml.Linq;
using PortfolioEngineCore;

namespace WorkEnginePPM.WebServices.Core
{
    internal class Utils
    {
        #region Methods (2) 

        // Internal Methods (2) 

        /// <summary>
        /// Gets the type of the field.
        /// </summary>
        /// <param name="propertyType">Type of the property.</param>
        /// <returns></returns>
        internal static string GetFieldType(Type propertyType)
        {
            return propertyType.IsGenericType &&
                   propertyType.GetGenericTypeDefinition() == typeof (Nullable<>)
                       ? Nullable.GetUnderlyingType(propertyType).Name
                       : propertyType.Name;
        }

        /// <summary>
        /// Sets the result error.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="resultElement">The result element.</param>
        internal static void SetResultError(Exception exception, ref XElement resultElement)
        {
            resultElement.Add(new XAttribute("Status", (int) Response.ExecutionStatus.Failure));

            string message;

            if (exception.GetType() == typeof (PFEException))
            {
                var pfeException = ((PFEException) exception);

                message = string.Format(@"Error ({0}): {1}", pfeException.ExceptionNumber, pfeException.Message);
            }
            else
            {
                message = string.Format(@"Error: {0}", exception.GetBaseMessage());
            }

            resultElement.SetValue(message);
        }

        #endregion Methods 
    }
}