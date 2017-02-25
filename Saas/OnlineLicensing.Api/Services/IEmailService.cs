using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLive.OnlineLicensing.Api.Services
{
    public interface IEmailService
    {
        bool SendMail(string subject, string title, string accountRef);
    }
}
