using System;

namespace EPMLiveCore.API
{
    public class APIException : Exception
    {
        #region Constructors (1) 

        public APIException(int exceptionNumber, string message)
            : base(message)
        {
            ExceptionNumber = exceptionNumber;
        }

        #endregion Constructors 

        #region Properties (1) 

        public int ExceptionNumber { get; set; }

        #endregion Properties 
    }
}