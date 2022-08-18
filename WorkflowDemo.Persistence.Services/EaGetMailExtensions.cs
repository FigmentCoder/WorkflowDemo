using System.Collections.Generic;
using EAGetMail;

namespace WorkflowDemo.Persistence.Services
{
    internal static class EaGetMailExtensions
    {
        public static IEnumerable<Mail> GetEmails(this MailClient mailClient)
            => mailClient.GetMailInfos()
                .Map(mailClient.GetMail);

        public static IEnumerable<Attachment> GetAttachments(this MailClient mailClient)
            => GetEmails(mailClient)
                .Bind(mail => mail.Attachments);
    }
}