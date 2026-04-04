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

            if (Directory.Exists(path))
            {

                CategoryManager categoryManager = new CategoryManager();
                FileOrganizer fileOrganizer = new FileOrganizer(path, categoryManager);
                Console.WriteLine("\nDateien werden organisiert... ");
                fileOrganizer.StartOrganizing();
                Console.WriteLine("Dateien wurden organisiert!");
            }
            else 
            {
                Console.WriteLine("Pfad existiert nicht!");
                Console.WriteLine("richtiges pfad eingeben:");
                path = Console.ReadLine();
            }
        }
    }
}
