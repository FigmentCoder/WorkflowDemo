using System;
using LanguageExt;
using WorkflowDemo.Domain.Models;

namespace WorkflowDemo.Domain.Interfaces
{
    public delegate Either<Exception, Unit> CreateFolder(FolderName folder);
}