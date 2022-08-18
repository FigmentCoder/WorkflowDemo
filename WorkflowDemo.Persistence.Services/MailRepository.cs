using System;
using System.Collections.Generic;
using System.Linq;

using EAGetMail;
using LanguageExt;

using WorkflowDemo.Common.Services;
using WorkflowDemo.Domain.Models;

using static WorkflowDemo.Common.Services.ExceptionExtensions;
using static WorkflowDemo.Persistence.Services.MailClientFactory;

namespace WorkflowDemo.Persistence.Services
{
    public static class MailRepository 
    {
        public static Either<Exception, IEnumerable<(FolderName FolderName, IEnumerable<Mail> Mails)>> Read(
            Func<Imap4Folder, bool> predicate)
        {
            if (predicate.IsNull()) 
                return NullException(nameof(predicate));

            return
                MailClient()
                    .Map(mailClient => mailClient.Imap4Folders
                        .Bind(folder => folder.SubFolders)
                        .Where(predicate)
                        .Map(folder =>
                        {
                            mailClient.SelectFolder(folder);
                            return (FolderName.New(folder.Name), mailClient.GetEmails());
                        }));
        }

        public static Either<Exception, Unit> Save(FolderName folderName, IEnumerable<Mail> mails)
        {
            if (folderName.IsNull()) 
                return NullException(nameof(folderName));
            
            if (mails.IsNull()) 
                return NullException(nameof(mails));

            try
            {
                mails.ForEach((index, mail) => 
                {
                    PathReader.Read(folderName, index, "eml")
                        .Pipe(path => mail.SaveAs(path, true));
                });
            }
            catch (Exception exception)
            {
                return exception;
            }

            return Unit.Default;
        }
    }
}