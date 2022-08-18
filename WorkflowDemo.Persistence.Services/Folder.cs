using static System.Configuration.ConfigurationManager;

namespace WorkflowDemo.Persistence.Services
{
    internal static class Folder
    {
        public static readonly string Path = AppSettings["FolderPath"];
    }
}