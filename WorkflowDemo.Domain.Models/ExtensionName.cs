using LanguageExt;

namespace WorkflowDemo.Domain.Models
{
    public class ExtensionName
    {
        private ExtensionName(string value)
        {
            Value = value;
        }

        public static ExtensionName New(string value)
            => value.IsNull() 
                ? new ExtensionName(string.Empty)
                : new ExtensionName(value);

        private readonly string Value;

        public static bool IsNullOrEmpty(ExtensionName extensionName)
            => extensionName.IsNull() || extensionName.IsNull() || extensionName.Value.Length == 0;

        public static implicit operator ExtensionName(string value)
            => New(value);
        
        public static implicit operator string(ExtensionName extensionName)
            => extensionName.IsNull()
                ? string.Empty
                : extensionName.Value;

        public override string ToString()
            => Value;
    }
}