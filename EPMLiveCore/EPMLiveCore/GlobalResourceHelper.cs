using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Web;

namespace EPMLiveCore
{
    public class GlobalResourceHelper
    {   
        public static string GetResourceString(string resourceClass, string key)
        {   
            string value = HttpContext.GetGlobalResourceObject(resourceClass, key).ToString();
            return value;
        }
    }
}
