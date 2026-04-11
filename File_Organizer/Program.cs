using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace File_Organizer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IEnumerable<CategoryConfig> configData;
            FileOrganizer fileOrganizer;

            Console.WriteLine("Geben Sie den Pfad zum Ordner ein, den Sie organisieren möchten:");
            string path = Console.ReadLine();

            while (!Directory.Exists(path))
            {
                Console.WriteLine("Der eingegebene Pfad ist ungültig. Bitte geben Sie einen gültigen Pfad ein:");
                path = Console.ReadLine();
            }
            try
            {
                var configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
                configData = JsonConfigLoader.LoadConfig(configFilePath);
                CategoryManager categoryManager = new CategoryManager(configData);
                fileOrganizer = new FileOrganizer(path, categoryManager);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Laden der Konfigurationsdatei: {ex.Message}");
                Console.WriteLine("Das Programm wird beendet.");
                return;
            }
            
            Console.WriteLine("\nDateien werden organisiert... ");
            fileOrganizer.StartOrganizing();
            Console.WriteLine("Dateien wurden organisiert!");
            
        }
    }
}
