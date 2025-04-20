using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitObfuscator.Helpers
{
    public static class Logger
    {
        public static void Info(string message) => Log("INFO", message);
        public static void Warn(string message) => Log("WARN", message);
        public static void Error(string message) => Log("ERROR", message);

        private static void Log(string level, string message)
        {
            Console.ForegroundColor = level switch
            {
                "INFO" => ConsoleColor.Green,
                "WARN" => ConsoleColor.Yellow,
                "ERROR" => ConsoleColor.Red,
                _ => ConsoleColor.White
            };
            Console.WriteLine($"[{level}] {message}");
            Console.ResetColor();
        }
    }
}
