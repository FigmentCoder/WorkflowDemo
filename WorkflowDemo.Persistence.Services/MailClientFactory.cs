using System;
using EAGetMail;
using LanguageExt;
using static System.Configuration.ConfigurationManager;

namespace WorkflowDemo.Persistence.Services
{
    internal static class MailClientFactory
    {
        public static Either<Exception, MailClient> MailClient()
        {
            MailClient mailClient;

            try
            {
                mailClient = new MailClient("TryIt");
                mailClient.Connect(MailServer());
            }
            catch (Exception exception)
            {
                return exception;
            }

            return mailClient;
        }

        private static MailServer MailServer()
        {
            return new MailServer(AppSettings["Server"],
                AppSettings["Email"],
                AppSettings["Password"],
                ServerProtocol.Imap4)
            {
                SSLConnection = true,
                Port = 993
            };
        }
    }
}