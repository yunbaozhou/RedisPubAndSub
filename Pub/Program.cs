using System;
using StackExchange.Redis;

namespace Pub
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConfigurationOptions configurationOptions = new ConfigurationOptions();
            //configurationOptions.Password = "!@#CeeKee";
            //创建连接
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("192.168.1.234:6379,password=!@#CeeKee"))
            {
                ISubscriber sub = redis.GetSubscriber();

                Console.WriteLine("请输入任意字符，输入exit退出");

                string input;

                do
                {
                    input = Console.ReadLine();
                    sub.Publish("messages", input);
                } while (input != "exit");
            }
        }
    }
}
