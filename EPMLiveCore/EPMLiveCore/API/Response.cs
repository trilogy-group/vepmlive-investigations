namespace EPMLiveCore.API
{
    public class Response
    {
		#region Methods (2) 

		// Internal Methods (2) 

        /// <summary>
        /// Generates the response for failure.
        /// </summary>
        /// <param name="errorId">The error id.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns></returns>
        public static string Failure(int errorId, string errorMessage)
        {
            return string.Format(@"<Result Status=""{0}""><Error ID=""{1}"">{2}</Error></Result>",
                                 (int) ExecutionStatus.Failure, errorId, errorMessage);
        }

        /// <summary>
        /// Generates the response for success.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        public static string Success(string result)
        {
            return string.Format(@"<Result Status=""{0}"">{1}</Result>", (int) ExecutionStatus.Success,
                                 result);
        }

		#endregion Methods 
    }
}