using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace File_Organizer
{
    public class Logger
    {
        private static Logger instance;

        private Logger() { }

        public static Logger GetInstance()
        {
            if (instance == null) { instance = new Logger(); }
            return instance;
        }

        public void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Info: ");
            Console.ResetColor();
            Console.WriteLine(message);
        }

        public void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Success: ");
            Console.ResetColor();
            Console.WriteLine(message);
            
        }

        public void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Warning: ");
            Console.ResetColor();
            Console.WriteLine(message);


        }

        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Error: ");
            Console.ResetColor();
            Console.WriteLine(message);
            
        }

    }
}
