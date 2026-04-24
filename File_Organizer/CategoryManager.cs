using System;
using System.Collections.Generic;
using System.Text;

namespace File_Organizer
{
    public class CategoryManager
    {
        private Dictionary<string, string> _extensionMapping = new Dictionary<string, string>();
        Logger _instance = Logger.GetInstance();

        public CategoryManager(IEnumerable<CategoryConfig> configData) {
            if (configData == null) { throw new ArgumentNullException(nameof(configData), "Configuration data cannot be null."); }
            foreach (var item in configData )
            {
                if (item == null || string.IsNullOrEmpty(item.Destination) || item.Extensions == null || item.Extensions.Any(ext => string.IsNullOrEmpty(ext)))
                {
                    throw new ArgumentException("Category configuration cannot be null or empty.", nameof(configData));
                }
                LoadDictionary(item.Destination, item.Extensions.ToArray());
            }
        }

        private void LoadDictionary(string folder, params string[] extensions)
        {
            foreach (var extension in extensions)
            {
                _extensionMapping.Add(extension.ToLower(), folder);
            }
        }

        public string GetTargetFolder(string extension)
        {
            var OptimizedExtension = extension?.ToLower();
            if (string.IsNullOrEmpty(extension) || !_extensionMapping.ContainsKey(OptimizedExtension))
            {
                return "other";
            }
            return _extensionMapping[OptimizedExtension];
        }


    }
}
