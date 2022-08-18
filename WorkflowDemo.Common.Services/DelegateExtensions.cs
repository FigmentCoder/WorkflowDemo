using System;

namespace WorkflowDemo.Common.Services
{
    public static class DelegateExtensions
    {
        public static string TypeName(this Delegate @delegate)
            => @delegate.Method.DeclaringType?.Name;
    }
}