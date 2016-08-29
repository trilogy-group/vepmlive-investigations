using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Collections;

namespace EPMLiveCore
{
    [System.Runtime.InteropServices.GuidAttribute("CB396C8B-A4E9-4a23-BD02-9307995599AA")]
    class UserManager : SPPersistedObject 
    {
        [Persisted]
        private string _userslist;

        public UserManager()
        { ;}

        protected override bool HasAdditionalUpdateAccess()
        {
            return true;
        }

        public UserManager(string name, SPPersistedObject parent, Guid guid)
            : base(name, parent, guid)
        { _userslist = ""; }

        public override string DisplayName
        {
            get
            {
                return string.Format("UserManager");
            }
        }

        public ArrayList UserList
        {
            get
            {
                ArrayList arr = new ArrayList();
                arr.AddRange(_userslist.Split(','));

                return arr;
            }
            set
            {
                _userslist = "";
                foreach (string u in (ArrayList)value)
                {
                    if(u != "")
                        _userslist += "," + u;
                }
                if (_userslist.Length > 1 && _userslist[0] == ',')
                    _userslist = _userslist.Substring(1);
            }
        }
    }
}
