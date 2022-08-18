using System;
using LanguageExt;
using WorkflowDemo.Persistence.Services;
using MailTaskP = WorkflowDemo.Tasks.Services.MailTask;
using static WorkflowDemo.Logging.Models.Message;
using static WorkflowDemo.Tasks.Runner.TaskLogger;

namespace WorkflowDemo.Tasks.Runner
{
    internal static class MailTask
    {
        public static Either<Exception, Unit> Start()
            => from _ in Log(Starting.Type(typeof(MailTask)))
               from s in StartP()
               from __ in Log(Stopping.Type(typeof(MailTask)))
               select s;

        private static Either<Exception, Unit> StartP()
            => MailTaskP.Start(MailRepository.Read,
                MailRepository.Save,
                FolderCreator.Create);
    }
}