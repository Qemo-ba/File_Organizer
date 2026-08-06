using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;

namespace File_Organizer
{
    public class Logger
    {
        private static Logger instance;
        private static readonly object _lock = new object();
        private readonly string _logFilePath;

        private Logger() 
        {
            _logFilePath = Path.Combine(AppContext.BaseDirectory, "log.txt");
        }

        public static Logger GetInstance()
        {
            lock (_lock)
            {
                if (instance == null) { instance = new Logger(); }
                return instance;
            }
        }

        public void Info(string message)
        {
            Write(
                "Info",
                message,
                ConsoleColor.Blue
            );
        }

        public void Success(string message)
        {
            Write(
                "Success",
                message,
                ConsoleColor.Green
            );
        }

        public void Warning(string message)
        {
            Write(
                "Warning",
                message,
                ConsoleColor.Yellow
            );
        }

        public void Error(string message)
        {
            Write(
                "Error",
                message,
                ConsoleColor.Red
            );
        }

        private void Write(string level, string message, ConsoleColor color)
        {
            lock (_lock)
            {
                Console.ForegroundColor = color;
                Console.Write($"{level}: ");
                Console.ResetColor();
                Console.WriteLine(message);

                string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
                File.AppendAllText(_logFilePath, line + Environment.NewLine);
            }
        }
    }
}
