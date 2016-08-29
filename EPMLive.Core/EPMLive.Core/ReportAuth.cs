using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Collections;

namespace EPMLiveCore
{
    [System.Runtime.InteropServices.GuidAttribute("CB396C8B-A4E9-4a23-BD02-9307995599AB")]
    public class ReportAuth : SPPersistedObject
    {
        [Persisted]
        private string _username;
        [Persisted]
        private string _password;

        public ReportAuth()
        { }

        protected override bool HasAdditionalUpdateAccess()
        {
            return true;
        }

        public ReportAuth(string name, SPPersistedObject parent, Guid guid) : base(name, parent, guid)
        { _username = "";
        _password = "";
    }

        public override string DisplayName
        {
            get
            {
                return string.Format("UserManager");
            }
        }

        public String Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public String Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }
    }
}
