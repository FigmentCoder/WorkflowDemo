using System;
using LanguageExt;
using WorkflowDemo.Common.Services;
using WorkflowDemo.Logging.Models;
using WorkflowDemo.Logging.Services;

namespace WorkflowDemo.Tasks.Runner
{
    internal static class TaskLogger
    {
        public static Either<Exception, Unit> Log(Message message)
            => Logger.Log(message).ToEither();
    }
}