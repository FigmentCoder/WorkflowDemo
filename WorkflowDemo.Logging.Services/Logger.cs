using LanguageExt;
using WorkflowDemo.Logging.Models;
using static System.Console;

namespace WorkflowDemo.Logging.Services
{
    public class Logger
    {
        public static Unit Log(Message message)
        {
            WriteLine(message);
            return Unit.Default;
        }
    }
}