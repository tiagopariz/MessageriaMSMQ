using System;
using MessageriaMSMQ.Domain;
using MessageriaMSMQ.Messages;

namespace MessageriaMSMQ.Prompt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MSMQ");
            Console.WriteLine("-------------------------------");

            var person = new Person
            {
                PersonId = Guid.NewGuid(),
                Name = "Tiago Pariz"
            };

            var message = Console.ReadLine();

            Console.WriteLine("\nEnviando mensagem...");

            Send("FROM: " + person.PersonId + " | " + person.Name + "\n" +
                 "MESSAGE: " + message);

            Console.WriteLine("\nMensagem enviada\n");

            Console.ReadKey();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("\nRecebendo mensagem...\n");

            message = Receive();

            Console.WriteLine(message);

            Console.WriteLine("-------------------------------");
            Console.ReadKey();
        }

        private static void Send(string message)
        {
            var msg = new Message(message, @".\private$\PersonDataQueue");
            msg.Send();
        }

        private static string Receive()
        {
            var msg = new Message(@".\private$\PersonDataQueue");
            msg.Receive();
            return msg.Content as string;
        }
    }
}
