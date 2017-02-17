using System;
using System.Linq;
using EPMLive.OnlineLicensing.Api.Data;

namespace EPMLive.OnlineLicensing.Api
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
        public int GetAccountReference(Guid accountId)
        {
            using (var context = ConnectionHelper.CreateLicensingModel())
            {
                var account = context.Accounts.SingleOrDefault(a => a.account_id == accountId);
                return account != null ? account.account_ref : 0;
            }
        }

        //TODO: implement account log
        public void AddAccountLog(Guid accountId, Guid userId, string log) { }
    }
}
