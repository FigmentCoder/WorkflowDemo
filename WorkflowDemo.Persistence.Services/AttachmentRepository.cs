using System;
using System.Collections.Generic;
using System.Linq;

using EAGetMail;
using LanguageExt;

using WorkflowDemo.Common.Services;
using WorkflowDemo.Domain.Models;

using static WorkflowDemo.Common.Services.ExceptionExtensions;
using static WorkflowDemo.Domain.Models.FolderNameConstructor;
using static WorkflowDemo.Persistence.Services.MailClientFactory;

namespace WorkflowDemo.Persistence.Services
{
    public static class AttachmentRepository
    {
        public static Either<Exception, IEnumerable<(FolderName FolderName, IEnumerable<Attachment> Attachments)>> Read(
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
                            return (FolderName(folder.Name), mailClient.GetAttachments());
                        }));
        }

        public static Either<Exception, Unit> Save(
            FolderName folderName, IEnumerable<Attachment> attachments)
        {
            if (folderName.IsNull()) 
                return NullException(nameof(folderName));
            
            if (attachments.IsNull()) 
                return NullException(nameof(attachments));

            try
            {
                attachments.ForEach((emailNumber, attachment) =>
                {
                    PathReader
                        .Read(folderName, emailNumber, "csv")
                        .Pipe(path => attachment.SaveAs(path, true));
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