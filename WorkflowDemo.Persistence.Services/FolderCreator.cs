using System;
using System.IO;

using LanguageExt;

using WorkflowDemo.Common.Services;
using WorkflowDemo.Domain.Models;

using static System.IO.Directory;
using static WorkflowDemo.Common.Services.ExceptionExtensions;

namespace WorkflowDemo.Persistence.Services
{
    public class FolderCreator
    {
        public static Either<Exception, Unit> Create(FolderName folder)
        {
            if (FolderName.IsNullOrEmpty(folder))
                return NullException(nameof(folder));

            try
            {
               Folder.Path
                   .Concat(folder)
                   .Pipe(d => Exists(d)
                       .IfFalse(() => CreateDirectory(d)));
            }
            catch (Exception exception)
            {
                return exception;
            }

            return Unit.Default;
        }
    }
}