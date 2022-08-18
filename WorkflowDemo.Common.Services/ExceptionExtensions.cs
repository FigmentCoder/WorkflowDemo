using System;

namespace WorkflowDemo.Common.Services
{
    public static class ExceptionExtensions
    {
        public static ArgumentNullException NullException(string name)
            => new ArgumentNullException(name);
    }
}