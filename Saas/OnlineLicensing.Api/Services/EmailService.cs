using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EPMLive.OnlineLicensing.Api.Services
{
    public class EmailService : IEmailService
    {
        private string _host;
        private int _port;
        private string _user;
        private string _password;
        private bool _enableSsl;
       
        public EmailService(string host, int port, string user, string password, bool enableSsl)
        {
            _host = host;
            _port = port;
            _user = user;
            _password = password;
            _enableSsl = enableSsl;
        }

        /// <summary>
        /// Sends out emails based on some events
        /// </summary>
        /// <returns>Rerurns true if the email was sent. returns false otherwise.</returns>
        public bool SendMail(string messageFrom, string[] messageTo, string subject, string title, string accountRef)
        {
            //TODO: make a body template for updating license
            MailMessage message = new MailMessage
            {
                IsBodyHtml = true,
                From = new MailAddress(messageFrom),
                Subject = subject
            };
           
            foreach (var item in messageTo)
            {
                message.To.Add(item);
            }
            
            try
            {
                message.Body = FormatMessage(title, accountRef) ;

                SmtpClient smtpClient = new SmtpClient(_host, _port);
                NetworkCredential credentials = new NetworkCredential(_user, _password);
                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = _enableSsl;
                smtpClient.Send(message);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private string FormatMessage(string title, string url)
        {
            return string.Format(File.ReadAllText(HttpContext.Current.Server.MapPath(@"~/App_Data/licenseUpdate.txt")),title, url);
        }
    }
}
