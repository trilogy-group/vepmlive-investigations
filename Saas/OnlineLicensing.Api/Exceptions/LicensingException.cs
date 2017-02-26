using System;

namespace EPMLive.OnlineLicensing.Api.Exceptions
{
    [Serializable]
    public class LicensingException : Exception
    {
        public LicensingException() { }

        public LicensingException(string message) : base(message) { }

        public LicensingException(string format, params object[] args)
        : base(string.Format(format, args)) { }

        public LicensingException(string message, Exception innerException)
        : base(message, innerException) { }
	}
}
