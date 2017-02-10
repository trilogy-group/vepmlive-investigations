using OnlineLicensing.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLicensing.Api
{
    public class AccountManager
    {
        public static int GetAccountReference(Guid accountId)
        {
            using (var context = ConnectionHelper.CreateLicensingModel("server=win-6j09gf4nbp8;database=EPMLIVEdb;User ID=epmlivedb;Password=MCjhfd4562D^7"))
            {
                return context.ACCOUNTs.SingleOrDefault(a => a.account_id == accountId).account_ref;
            }
        }
    }
}
