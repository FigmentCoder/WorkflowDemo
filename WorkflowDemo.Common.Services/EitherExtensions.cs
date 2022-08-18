using System;
using LanguageExt;
using static LanguageExt.Prelude;

namespace WorkflowDemo.Common.Services
{
    public static class EitherExtensions
    {
        public static Either<Exception, T> Right<T>(T value) 
            => Right<Exception, T>(value);

        public static Either<Exception, T> Left<T>(Exception exception)
            => Left<Exception, T>(exception);

        public static Either<Exception, Unit> ToEither(this Unit unit)
            => unit;
    }
}