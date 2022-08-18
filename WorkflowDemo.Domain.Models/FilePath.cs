using LanguageExt;

namespace WorkflowDemo.Domain.Models
{
    public class FilePath
    {
        private FilePath(string value)
        {
            Value = value;
        }

        public static FilePath New(string value)
            => value.IsNull()
                ? new FilePath(string.Empty)
                : new FilePath(value);

        private readonly string Value;

        public static bool IsNullOrEmpty(FilePath filePath)
            => filePath.IsNull() ||
               filePath.IsNull() ||
               filePath.Value.Length == 0;
        
        public static implicit operator FilePath(string value)
            => New(value);

        public static implicit operator string(FilePath filePath)
            => filePath.IsNull()
                ? string.Empty
                : filePath.Value;

        public override string ToString()
            => Value;
    }
}