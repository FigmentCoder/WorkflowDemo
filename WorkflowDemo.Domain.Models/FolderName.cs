using LanguageExt;

namespace WorkflowDemo.Domain.Models
{
    public class FolderName
    {
        private FolderName(string value)
        {
            Value = value;
        }

        public static FolderName New(string value)
            => value.IsNull()
                ? new FolderName(string.Empty)
                : new FolderName(value);

        private readonly string Value;

        public static bool IsNullOrEmpty(FolderName folderName)
            => folderName.IsNull() ||
               folderName.IsNull() ||
               folderName.Value.Length == 0;
        
        public static implicit operator FolderName(string value)
            => New(value);

        public static implicit operator string(FolderName folderName)
            => folderName.IsNull()
                ? string.Empty
                : folderName.Value;

        public override string ToString()
            => Value;
    }
}