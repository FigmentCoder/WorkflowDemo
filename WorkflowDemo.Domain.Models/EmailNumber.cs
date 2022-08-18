using LanguageExt;

namespace WorkflowDemo.Domain.Models
{
    public class EmailNumber
    {
        private EmailNumber(int value)
        {
            Value = value;
        }

        public static EmailNumber New(int value)
            => value < 0
            ? new EmailNumber(0)
            : new EmailNumber(value);

        private readonly int Value;

        public static implicit operator EmailNumber(int value)
            => New(value);

        public static implicit operator int(EmailNumber emailNumber)
            => emailNumber.IsNull()
                ? 0
                : emailNumber.Value;

        public override string ToString()
            => Value.ToString();
    }
}