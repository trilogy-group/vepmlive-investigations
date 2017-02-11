using OnlineLicensing.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLicensing.Api
{
    /// <summary>
    /// Class to manage all the acount related options.
    /// </summary>
    public class AccountManager
    {
        /// <summary>
        /// Gets the account reference number.
        /// </summary>
        /// <param name="accountId">The guid of the account to get the reference from.</param>
        /// <returns>Returns the account reference number.</returns>
        public static int GetAccountReference(Guid accountId)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                return context.ACCOUNTs.SingleOrDefault(a => a.account_id == accountId).account_ref;
            }
        }
    }
}
