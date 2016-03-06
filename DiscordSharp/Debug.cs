using System;

namespace DiscordSharp
{
    public class Debug
    {
        public static void Log(LogMessage m, string prefix = "")
        {
            switch (m.Level)
            {
                case MessageLevel.Debug:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case MessageLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case MessageLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case MessageLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }
            Console.Write($"[{prefix}: {m.TimeStamp}]: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(m.Message + "\n");

            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void Log(string message, MessageLevel level = MessageLevel.Debug)
        {
            var m = new LogMessage();
            m.Message = message;
            m.Level = level;
            m.TimeStamp = DateTime.Now;
            Log(m);
        }
    }
    
}
