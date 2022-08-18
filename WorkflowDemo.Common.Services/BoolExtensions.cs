using System;

namespace WorkflowDemo.Common.Services
{
    public static class BoolExtensions
    {
        public static T IfTrue<T>(this bool value, Func<T> func)
            => value ? func() : default;

        public static R IfTrue<T, R>(this bool value, Func<T, R> func, T t)
            => value ? func(t) : default;

        public static T IfFalse<T>(this bool value, Func<T> func)
            => value ? default : func();

        public static R IfFalse<T, R>(this bool value, Func<T, R> func, T t)
            => value ? default : func(t);
    }
}