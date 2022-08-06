using System;
using System.Threading.Tasks;

namespace Logger
{
    public class ConsoleLogger : Logger
    {
        public override Task Log(LogLevel level, EventModel serverEvent) =>
            Task.Factory.StartNew(() =>
                Console.WriteLine($"{level.ToString().ToUpper()} [{DateTime.Now}]{serverEvent.ToString()}"));
    }
}