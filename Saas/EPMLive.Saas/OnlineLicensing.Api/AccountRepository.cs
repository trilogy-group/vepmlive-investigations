using System;
using System.Linq;
using EPMLive.OnlineLicensing.Api.Data;

namespace EPMLive.OnlineLicensing.Api
{
    /// <summary>
    /// Class to manage all the acount related options.
    /// </summary>
    public class AccountRepository
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
                var account = context.Accounts.SingleOrDefault(a => a.account_id == accountId);
                if (account != null)
                    return account.account_ref;
            }
            return 0;
        }
    }
}
