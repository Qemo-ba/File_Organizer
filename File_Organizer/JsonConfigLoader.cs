using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace File_Organizer
{
    public class JsonConfigLoader
    {

        public static IEnumerable<CategoryConfig> LoadConfig(string filePath)
        {
            if (!File.Exists(filePath))
            { 
                throw new FileNotFoundException($"The configuration file '{filePath}' was not found.");
            }
            try
            {
                var jsonString = File.ReadAllText(filePath);
                var config = JsonSerializer.Deserialize<IEnumerable<CategoryConfig>>(jsonString);
                if (config == null) { throw new ArgumentNullException($"The configuration file '{filePath}' is empty or has an invalid format."); }
                return config;
            } catch (Exception ex)
            {
                throw new Exception($"An error occurred while loading the configuration file '{filePath}': {ex.Message}");
            }                
        }

    }
}
