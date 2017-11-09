using System;
using System.Messaging;

namespace MessageriaMSMQ.Messages
{
    public class Message
    {
        public object Content { get; private set; }
        public string Path { get;  }

        public Message(string message, string path = ".")
        {
            Content = message;
            Path = path;
        }
        public Message(string path = ".")
        {
            Path = path;
        }

        public void Send()
        {
            var m = new MessageQueue(Path);
            m.Send(Content);
        }

        public void Receive()
        {
            var mq = new MessageQueue(Path)
            {
                Formatter = new XmlMessageFormatter(new Type[] {typeof(string)})
            };
            var messageReceived = mq.Receive();
            Content = messageReceived?.Body;
        }
    }
}
