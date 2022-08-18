using System;

namespace WorkflowDemo.Common.Services
{
    public static class FuncExtensions
    {
        public static Func<T, T> Tap<T>(Action<T> act) 
            => x => { act(x); return x; };

        public static R Pipe<T, R>(this T @this, Func<T, R> func) 
            => func(@this);

        public static T Pipe<T>(this T input, Action<T> func) 
            => Tap(func)(input);
    }
}