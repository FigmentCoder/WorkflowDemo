using System;
using System.Collections.Generic;

using EAGetMail;
using LanguageExt;

using WorkflowDemo.Domain.Models;

namespace WorkflowDemo.Domain.Interfaces
{
    public delegate Either<Exception, IEnumerable<(FolderName FolderName, IEnumerable<Mail> Mails)>> ReadMails(
        Func<Imap4Folder, bool> predicate);
}
