using System;
using System.Collections.Generic;

namespace WorkflowDemo.Common.Services
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<int, T> action)
        {
            var i = 0;
            foreach (var item in sequence)
            {
                action(i, item);
                i++;
            }
        }

        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (var item in sequence)
            {
                action(item);
            }
        }
    }
}