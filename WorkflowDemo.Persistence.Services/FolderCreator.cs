using System;
using System.IO;
using LanguageExt;
using WorkflowDemo.Common.Services;
using WorkflowDemo.Domain.Models;
using static WorkflowDemo.Common.Services.ExceptionExtensions;

namespace WorkflowDemo.Persistence.Services
{
    public class FolderCreator
    {
        public static Either<Exception, Unit> Create(FolderName folder)
        {
            if (FolderName.IsNullOrEmpty(folder))
                return ArgumentNullException(nameof(folder));

            try
            {
               Folder.Path.Concat(folder).Pipe(d => Directory.Exists(d)
                   .IfFalse(() => Directory.CreateDirectory(d)));
            }
            catch (Exception exception)
            {
                return exception;
            }

            return Unit.Default;
        }
    }
}