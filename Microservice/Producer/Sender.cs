using System;
using System.Text;
using RabbitMQ.Client;

namespace Producer
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare("test", false, false, false, null);

                string message = "hello world rabbit mq test";

                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("","test", null, body);
            }

            Console.WriteLine("press [enter] to exist the sender app--");
            Console.ReadLine();
        }
    }
}