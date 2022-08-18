
namespace WorkflowDemo.Common.Services
{
    public static class ObjectExtensions
    {
        public static string TypeName(this object obj)
            => obj.GetType().Name;
    }
}