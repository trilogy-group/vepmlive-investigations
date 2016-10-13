using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectPublisher2016
{
    internal class Constants
    {
        public const string WR_METHOD_OPTIONS = "OPTIONS";

        public const string FED_AUTH_COOKIE_NAME = "FedAuth";

        public const string CLAIM_HEADER_RETURN_URL = "X-Forms_Based_Auth_Return_Url";
        public const string CLAIM_HEADER_AUTH_REQUIRED = "X-FORMS_BASED_AUTH_REQUIRED";

        // messages
        public const string MSG_REQUIRED_SITE_URL = "The Site URL is required.";
        public const string MSG_NOT_CLAIM_SITE = "70000";

        public const int DEFAULT_POP_UP_WIDTH = 860;
        public const int DEFAULT_POP_UP_HEIGHT = 525;
    }
}
