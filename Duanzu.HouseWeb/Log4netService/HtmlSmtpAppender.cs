using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Appender;
using System.Net.Mail;
using System.Net;


namespace Log4netService
{
    /// <summary>
    /// FileName: HtmlSmtpAppender.cs
    /// CLRVersion: 4.0.30319.17929
    /// Author: 黄继华
    /// Corporation: 重写SmtpAppender
    /// Description: 发送HTML电子邮件时记录事件发生
    /// DateTime: 2013/06/17 17:38:30
    /// </summary>
    public class HtmlSmtpAppender : SmtpAppender
    {
        /// <summary>Sends an email message</summary>
        protected override void SendEmail(string body)
        {
            CreateSmtpClient().Send(CreateMailMessage(body));
        }

        /// <summary>Creats new SMTP client based on the properties set in the configuration file</summary>
        private SmtpClient CreateSmtpClient()
        {
            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = SmtpHost;
            smtpClient.Port = Port;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            if (string.IsNullOrEmpty(Username))
                smtpClient.Credentials = CredentialCache.DefaultNetworkCredentials;
            else
                smtpClient.Credentials = new NetworkCredential(Username, Password);

            return smtpClient;
        }

        /// <summary>Creats new mail message based on the properties set in the configuration file</summary>
        private MailMessage CreateMailMessage(string body)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(From);
            mailMessage.To.Add(To);
            mailMessage.Subject = Subject;
            mailMessage.Body = body;
            mailMessage.Priority = Priority;
            mailMessage.IsBodyHtml = true;

            return mailMessage;
        }
    }
}
