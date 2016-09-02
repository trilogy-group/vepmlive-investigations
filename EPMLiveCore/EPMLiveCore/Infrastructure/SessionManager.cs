using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EPMLiveCore.Infrastructure
{
    /// <summary>
    ///     SessionManager provides a facade to the ASP.NET Session object.
    ///     All access to Session variables must be through this class.
    /// </summary>
    public static class SessionManager
    {
        # region Private Constants
        //---------------------------------------------------------------------
        
        private const string CURR_LIST = "CurrList";
        //---------------------------------------------------------------------
        # endregion

        # region Public Properties
        //---------------------------------------------------------------------
        /// <summary>
        ///     The Username is the domain name and username of the current user.
        /// </summary>
        public static string Username
        {
            get { return HttpContext.Current.User.Identity.Name; }
        }

        /// <summary>
        ///     CurrList is used to store the current state of the LastList value.
        /// </summary>
        public static string CurrList
        {
            get
            {
                string sList = string.Empty;
                try { sList = HttpContext.Current.Session[CURR_LIST].ToString(); }
                catch { }
                return sList;
            }

            set
            {
                HttpContext.Current.Session[CURR_LIST] = value;
            }
        }
        
        //---------------------------------------------------------------------
        # endregion
    }
}
