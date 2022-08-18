using System;
using System.Linq;

using LanguageExt;

using WorkflowDemo.Domain.Interfaces;
using WorkflowDemo.Domain.Models;
using static WorkflowDemo.Common.Services.ExceptionExtensions;

namespace WorkflowDemo.Tasks.Services
{
    public static class AttachmentTask
    {
        public static Either<Exception, Unit> Start(
            ReadAttachments readAttachments,
            SaveAttachments saveAttachments,
            CreateFolder createFolder)
        {
            if (readAttachments.IsNull())
                return NullException(nameof(readAttachments));

            if (saveAttachments.IsNull())
                return NullException(nameof(saveAttachments));

            if (createFolder.IsNull())
                return NullException(nameof(createFolder));

            return readAttachments(f => !f.IsIncluded())
                .Bind(ms => ms.Map(m => createFolder(m.FolderName)
                .Bind(_ => saveAttachments(m.FolderName, m.Attachments)))
                .Last());
        }
    }
}