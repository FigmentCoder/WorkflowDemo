using System;
using System.Collections.Generic;

using LanguageExt;
using EAGetMail;

using WorkflowDemo.Domain.Models;

namespace WorkflowDemo.Domain.Interfaces
{
    public delegate Either<Exception, IEnumerable<(FolderName FolderName, IEnumerable<Attachment> Attachments)>> ReadAttachments(
        Func<Imap4Folder, bool> predicate);
}