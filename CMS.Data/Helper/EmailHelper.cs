using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Port3435.Core.Helper
{
    public class EmailObject
    {
        public List<string> To { get; set; }
        public List<string> Cc { get; set; }
        public List<string> Bcc { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public List<string> Files { get; set; }
        public bool EmbedImage { get; set; } = false;
    }

    public class EmailHelper
    {
        #region Properties

        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
        public bool SmtpEnableSSL { get; set; }
        public string SmtpDisplayName { get; set; }

        #endregion

        #region Constructors

        public EmailHelper()
        {

        }

        public EmailHelper(string stmpServer, int smtpPort, string smtpUser, string smtpPass, bool smtpEnableSSL = false, string smtpDisplayName = "")
        {
            SmtpServer = stmpServer;
            SmtpPort = smtpPort;
            SmtpUser = smtpUser;
            SmtpPass = smtpPass;
            SmtpEnableSSL = smtpEnableSSL;
            SmtpDisplayName = smtpDisplayName;
        }

        #endregion

        #region Methods

        public void SendEmail(EmailObject input)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.Sender = new MailAddress(SmtpUser);
            mailMessage.From = new MailAddress(SmtpUser, SmtpDisplayName);

            char[] delimiters = { ';' };
            //Add To
            foreach (var item in input.To)
                mailMessage.To.Add(item);

            //Add cc
            if (input.Cc != null)
            {
                foreach (var item in input.Cc)
                    mailMessage.CC.Add(item);
            }

            //Add Bcc
            if (input.Bcc != null)
            {
                foreach (var item in input.Bcc)
                    mailMessage.Bcc.Add(item);
            }

            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = input.Subject;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;

            if (input.EmbedImage)
                mailMessage.Body = string.Empty;
            else
                mailMessage.Body = input.Message;

            #region [Add attchments if exists]

            if (input.Files != null)
            {
                foreach (var item in input.Files)
                {
                    if (File.Exists(item))
                    {
                        if (input.EmbedImage)
                        {
                            input.Message = input.Message.Replace("#IMAGE#", "<img border=\"0\" src=cid:ImageContent alt=\"\" />");
                            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(input.Message, null, "text/html");
                            LinkedResource ImageContent = new LinkedResource(item);
                            ImageContent.ContentId = "ImageContent";
                            htmlView.LinkedResources.Add(ImageContent);
                            mailMessage.AlternateViews.Add(htmlView);
                        }
                        else
                        {
                            mailMessage.Attachments.Add(new Attachment(item));
                        }
                    }
                }
            }

            #endregion

            SendEmailObject(mailMessage);
        }

        public void SendEmail(List<string> to,
                              string cc = "",
                              string bcc = "",
                              string subject = "",
                              string message = "",
                              List<string> fileArray = null,
                              bool embedImage = false)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.Sender = new MailAddress(SmtpUser);
            mailMessage.From = new MailAddress(SmtpUser, SmtpDisplayName);

            char[] delimiters = { ';' };
            //Add To
            foreach (var item in to)
            {
                mailMessage.To.Add(item);
            }

            //Add cc
            if (!string.IsNullOrEmpty(cc))
            {
                for (int i = 0; i < cc.Split(delimiters).Length; i++)
                {
                    mailMessage.CC.Add(cc.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)[i].ToString());
                }
            }
            //Add Bcc
            if (!string.IsNullOrEmpty(bcc))
            {
                for (int i = 0; i < bcc.Split(delimiters).Length; i++)
                {
                    mailMessage.Bcc.Add(bcc.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)[i].ToString());
                }
            }

            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = subject;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;

            if (embedImage)
            {
                mailMessage.Body = string.Empty;
            }
            else
            {
                mailMessage.Body = message;
            }

            #region [Add attchments if exists]

            if (fileArray != null)
            {
                foreach (var file in fileArray)
                {
                    if (File.Exists(file))
                    {
                        if (embedImage)
                        {
                            message = message.Replace("#IMAGE#", "<img border=\"0\" src=cid:ImageContent alt=\"\" />");
                            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(message, null, "text/html");
                            LinkedResource ImageContent = new LinkedResource(file);
                            ImageContent.ContentId = "ImageContent";
                            htmlView.LinkedResources.Add(ImageContent);
                            mailMessage.AlternateViews.Add(htmlView);
                        }
                        else
                        {
                            mailMessage.Attachments.Add(new Attachment(file));
                        }
                    }

                }
            }

            #endregion

            SendEmailObject(mailMessage);

        }

        private void SendEmailObject(Object mailMsg)
        {
            MailMessage mailMessage = (MailMessage)mailMsg;

            try
            {
                SmtpClient smtp = new SmtpClient(SmtpServer, SmtpPort);
                smtp.Credentials = new NetworkCredential(SmtpUser, SmtpPass);
                smtp.EnableSsl = SmtpEnableSSL;
                smtp.Send(mailMessage);
                mailMessage.Dispose();
            }
            catch (SmtpException)
            {

            }
        }

        #endregion
    }
}
