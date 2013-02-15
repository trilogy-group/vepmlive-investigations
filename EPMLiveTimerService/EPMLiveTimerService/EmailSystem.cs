using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Net;
using System.Net.Mail;

namespace TimerService
{
    class EmailSystem
    {
        public static void SendFullEmail(string body, string subject, bool hideFrom, SPUser fromUser, SPUser toUser)
        {
            try
            {
                SPAdministrationWebApplication spWebAdmin = Microsoft.SharePoint.Administration.SPAdministrationWebApplication.Local;
                string sMailSvr = spWebAdmin.OutboundMailServiceInstance.Server.Address;

                System.Net.Mail.MailMessage mailMsg = new MailMessage();
                if(hideFrom)
                {
                    mailMsg.From = new MailAddress(spWebAdmin.OutboundMailSenderAddress);
                }
                else
                {
                    if(fromUser.Email == "")
                    {
                        mailMsg.From = new MailAddress(spWebAdmin.OutboundMailSenderAddress, fromUser.Name);
                    }
                    else
                    {
                        mailMsg.From = new MailAddress(fromUser.Email, fromUser.Name);
                    }
                }

                body = body.Replace("{ToUser_Name}", toUser.Name);
                body = body.Replace("{ToUser_Email}", toUser.Email);
                body = body.Replace("{ToUser_Username}", EPMLiveCore.CoreFunctions.GetJustUsername(toUser.LoginName));

                subject = subject.Replace("{ToUser_Name}", toUser.Name);
                subject = subject.Replace("{ToUser_Email}", toUser.Email);
                subject = subject.Replace("{ToUser_Username}", EPMLiveCore.CoreFunctions.GetJustUsername(toUser.LoginName));

                mailMsg.To.Add(new MailAddress(toUser.Email));
                mailMsg.Subject = subject;
                mailMsg.Body = body;
                mailMsg.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient();

                smtpClient.Host = sMailSvr;

                smtpClient.Send(mailMsg);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

    }
}
