using MTask = WorkflowDemo.Tasks.Runner.MailTask;
using ATask = WorkflowDemo.Tasks.Runner.AttachmentTask;
using static WorkflowDemo.Logging.Models.Message;
using static WorkflowDemo.Tasks.Runner.TaskLogger;
using static System.Console;

namespace WorkflowDemo.Tasks.Runner
{
    internal static class Program
    {
        private static void Main()
        {
            MTask.Start()
                .Bind(_ => ATask
                    .Start())
                .Match(_ => Log(Success),
                       e => Log(Fail.ConcatS(e)));

            ReadKey();
        }
    }
}