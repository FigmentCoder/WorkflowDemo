using System;
using System.Collections.Generic;

using LanguageExt;
using EAGetMail;

using WorkflowDemo.Domain.Models;

namespace WorkflowDemo.Domain.Interfaces
{
    public delegate Either<Exception, Unit> SaveAttachments(
        FolderName folderName, IEnumerable<Attachment> attachments);
}