
namespace WorkflowDemo.Common.Services
{
    public static class StringExtensions
    {
        public static string Concat(this string @this, string that)
            => @this + that;

        public static string ConcatS(this string @this, string that)
            => @this + " " + that;
    }
}