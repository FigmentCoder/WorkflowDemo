using System;
using System.Collections.Generic;

using EAGetMail;
using LanguageExt;

using WorkflowDemo.Domain.Models;

namespace WorkflowDemo.Domain.Interfaces
{
    public delegate Either<Exception, Unit> SaveMails(
        FolderName folderName, IEnumerable<Mail> mails);
}