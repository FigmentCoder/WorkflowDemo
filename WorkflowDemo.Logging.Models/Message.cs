using System;
using LanguageExt;
using WorkflowDemo.Common.Services;

namespace WorkflowDemo.Logging.Models
{
    public class Message
    {
        private Message(string value)
            => Value = value;

        public static Message New(string value)
            => value.IsNull() 
                ? Empty
                : new Message(value);

        public static Message Success
            = New("Success");

        public static Message Fail
            = New("Fail");

        public static Message Starting
            = New("Starting");

        public static Message Stopping
            = New("Stopping");

        public static Message Empty
            = New(string.Empty);

        private readonly string Value;

        public Message ConcatS(Exception exception)
            => Value.ConcatS(exception.ToString());

        public Message Type(Delegate @delegate)
            => Value.ConcatS(@delegate.TypeName());

        public Message Type(Type type)
            => Value.ConcatS(type.Name);

        public static bool IsNullOrEmpty(Message message)
            => message.IsNull() || message.Equals(Empty);

        public static implicit operator Message(string value)
            => New(value);

        public static implicit operator string(Message message)
            => message.IsNull()
                ? string.Empty
                : message.Value;

        public override string ToString()
            => Value;
    }
}