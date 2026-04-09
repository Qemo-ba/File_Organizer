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
            if (File.Exists(filePath))
            {
                try
                {
                    var jsonString = File.ReadAllText(filePath);
                    var config = JsonSerializer.Deserialize<IEnumerable<CategoryConfig>>(jsonString);
                    return config;
                } catch (JsonException ex) 
                {
                        throw new JsonException($"Error parsing the configuration file '{filePath}': {ex.Message}");

                } catch (Exception ex)
                {
                    throw new Exception($"An error occurred while loading the configuration file '{filePath}': {ex.Message}");
                }                
            }

            throw new FileNotFoundException($"The configuration file '{filePath}' was not found.");

        }

    }
}
