using System;
using System.Linq;
using LanguageExt;
using WorkflowDemo.Domain.Interfaces;
using WorkflowDemo.Domain.Models;
using static WorkflowDemo.Common.Services.ExceptionExtensions;

namespace WorkflowDemo.Tasks.Services
{
    public static class MailTask
    {
        public static Either<Exception, Unit> Start(ReadMails readMails,
            SaveMails saveMails,
            CreateFolder createFolder)
        {
            if (readMails.IsNull())
                return ArgumentNullException(nameof(readMails));

            if (saveMails.IsNull())
                return ArgumentNullException(nameof(saveMails));

            if (createFolder.IsNull())
                return ArgumentNullException(nameof(createFolder));

            return readMails(f => !f.IsIncluded())
                .Bind(ms => ms.Map(m => createFolder(m.FolderName)
                .Bind(_ => saveMails(m.FolderName, m.Mails)))
                .Last());
        }
    }
}