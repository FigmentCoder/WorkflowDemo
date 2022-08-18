using System;
using LanguageExt;
using WorkflowDemo.Persistence.Services;
using AttachmentTaskP = WorkflowDemo.Tasks.Services.AttachmentTask;
using static WorkflowDemo.Logging.Models.Message;
using static WorkflowDemo.Tasks.Runner.TaskLogger;

namespace WorkflowDemo.Tasks.Runner
{
    internal static class AttachmentTask
    {
        public static Either<Exception, Unit> Start()
            => from _ in Log(Starting.Type(typeof(AttachmentTask)))
               from s in StartP()
               from __ in Log(Stopping.Type(typeof(AttachmentTask)))
               select s;

        private static Either<Exception, Unit> StartP()
            => AttachmentTaskP.Start(
                AttachmentRepository.Read,
                AttachmentRepository.Save,
                FolderCreator.Create);
    }
}