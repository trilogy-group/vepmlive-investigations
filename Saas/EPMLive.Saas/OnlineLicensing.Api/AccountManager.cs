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
        ILicensingModel _context;
        public AccountManager()
        {
            _context = ConnectionHelper.CreateLicensingModel();
        }

        public AccountManager(ILicensingModel context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the account reference number.
        /// </summary>
        /// <param name="accountId">The guid of the account to get the reference from.</param>
        /// <returns>Returns the account reference number.</returns>
        public int GetAccountReference(Guid accountId)
        {
            var account = _context.Accounts.SingleOrDefault(a => a.account_id == accountId);
            return account != null ? account.account_ref : 0;
        }
    }
}
