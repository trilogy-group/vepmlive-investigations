using EPMLive.OnlineLicensing.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLive.OnlineLicensing.ApiTests
{
    class TestEmailSender : IEmailService
    {
        private bool _validConfigValues;
        public TestEmailSender(bool validaConfigValues)
        {
            _validConfigValues = validaConfigValues;
        }

       public bool SendMail(string messageFrom, string[] messageTo, string subject, string title, string accountRef)
        {
            return _validConfigValues;
        }
    }
}
