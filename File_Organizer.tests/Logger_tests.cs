using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Xunit;

namespace File_Organizer.tests
{
    public class Logger_test
    {
        [Fact]
        public void Singelton_Logger_Test()
        {
            Logger log1 = Logger.GetInstance();
            Logger log2 = Logger.GetInstance();
            Assert.Same(log1, log2);
        }

        [Fact]
        public void Logger_ConsoleOutput_Test()
        {
            string nl = Environment.NewLine;
            Logger _instance = Logger.GetInstance();

            var originalOut = Console.Out;
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            _instance.Info("I'm informing");
            _instance.Success("Succes message");
            _instance.Warning("Warn message");
            _instance.Error("Error message");

            var output = stringWriter.ToString();
            Console.SetOut(originalOut);
            Assert.Equal($"Info: I'm informing{nl}Success: Succes message{nl}Warning: Warn message{nl}Error: Error message{nl}", output);
        }

    }
}
