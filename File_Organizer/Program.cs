using System;
using System.Runtime.CompilerServices;

namespace File_Organizer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Geben Sie den Pfad zum Ordner ein, den Sie organisieren möchten:");
            string path = Console.ReadLine();

            while (!Directory.Exists(path))
            {
                Console.WriteLine("Der eingegebene Pfad ist ungültig. Bitte geben Sie einen gültigen Pfad ein:");
                path = Console.ReadLine();
            }

            CategoryManager categoryManager = new CategoryManager();
            FileOrganizer fileOrganizer = new FileOrganizer(path, categoryManager);
            Console.WriteLine("\nDateien werden organisiert... ");
            fileOrganizer.StartOrganizing();
            Console.WriteLine("Dateien wurden organisiert!");
            
        }
    }
}
