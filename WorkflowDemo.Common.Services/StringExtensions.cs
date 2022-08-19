
namespace WorkflowDemo.Common.Services
{
    public static class StringExtensions
    {
        public static string Concat(this string left, string right)
            => left + right;

        public static string ConcatS(this string left, string right)
            => left + " " + right;
    }
}