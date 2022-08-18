using WorkflowDemo.Common.Services;
using WorkflowDemo.Domain.Models;

namespace WorkflowDemo.Persistence.Services
{
    internal static class PathReader
    {
        public static FilePath Read(
            FolderName folderName,
            EmailNumber emailNumber,
            ExtensionName extensionName)
            => string
                .Format(folderName + "-" + emailNumber + "." + extensionName)
                .Pipe(fileName => $"{Folder.Path + folderName}\\{fileName}");
    }
}