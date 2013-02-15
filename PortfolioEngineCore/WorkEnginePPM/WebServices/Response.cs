using System;
using System.Diagnostics;
using PortfolioEngineCore;

namespace WorkEnginePPM
{
    internal class Response
    {
        #region Enums (1) 

        internal enum ExecutionStatus
        {
            Success,
            Failure
        };

        #endregion Enums 

        #region Methods (6) 

        // Private Methods (1) 

        /// <summary>
        /// Generates the response for failure.
        /// </summary>
        /// <param name="exceptionNumber">The exception number.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="isPfeException">if set to <c>true</c> [is pfe exception].</param>
        /// <returns></returns>
        private static string Failure(int exceptionNumber, string errorMessage, bool isPfeException)
        {
            return string.Format(@"<Result Status=""{0}""><Error ID=""{1}"" PfEFailure=""{2}"">{3}</Error></Result>",
                                 (int)ExecutionStatus.Failure, exceptionNumber, isPfeException, "<![CDATA[" + errorMessage + "]]>");
        }

        // Internal Methods (5) 

        /// <summary>
        /// Generates the response for failure.
        /// </summary>
        /// <param name="errorId">The error id.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns></returns>
        internal static string Failure(int errorId, string errorMessage)
        {
            return Failure(errorId, errorMessage, false);
        }

        /// <summary>
        /// Failures the specified error id.
        /// </summary>
        /// <param name="errorId">The error id.</param>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        internal static string Failure(int errorId, Exception exception)
        {
            return Failure(errorId, string.Format("Error: {0}", exception.GetBaseMessage()));
        }

        /// <summary>
        /// Generates the response for failure.
        /// </summary>
        /// <param name="pfeException">The pfe exception.</param>
        /// <returns></returns>
        internal static string PfEFailure(PFEException pfeException)
        {
            return Failure(pfeException.ExceptionNumber, pfeException.GetBaseMessage(), true);
        }

        /// <summary>
        /// Successes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string Success(string data)
        {
            return Success(string.Empty, data);
        }

        /// <summary>
        /// Generates the response for success.
        /// </summary>
        /// <param name="resultMessage">The result message.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string Success(string resultMessage, string data)
        {
            string callingMethodName = new StackFrame(1).GetMethod().Name;

            if (callingMethodName.Equals("Success"))
            {
                callingMethodName = new StackFrame(2).GetMethod().Name;
            }

            return string.Format(@"<{0}><Result Status=""{1}"">{2}</Result>{3}</{0}>", callingMethodName,
                                 (int) ExecutionStatus.Success,
                                 resultMessage, data);
        }

        #endregion Methods 
    }
}