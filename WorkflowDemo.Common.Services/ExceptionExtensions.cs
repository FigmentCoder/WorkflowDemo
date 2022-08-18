using System;

namespace WorkflowDemo.Common.Services
{
    public static class ExceptionExtensions
    {
        public static ArgumentNullException ArgumentNullException(string name)
            => new ArgumentNullException(name);
    }
}