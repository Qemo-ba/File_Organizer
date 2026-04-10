using System;
using System.Collections.Generic;
using System.Text;

namespace File_Organizer
{
    public class CategoryManager
    {
        private Dictionary<string, string> _extensionMapping = new Dictionary<string, string>();

        public CategoryManager(IEnumerable<CategoryConfig> configData) {
            foreach (var item in configData )
            {
                LoadDictionary(item.Destination, item.Extensions.ToArray());
            }
        }

        private void LoadDictionary(string folder, params string[] extensions)
        {
            foreach (var extension in extensions)
            {
                _extensionMapping.Add(extension, folder);
            }
        }

        public string GetTargetFolder(string extension)
        {
            if (string.IsNullOrEmpty(extension) || !_extensionMapping.ContainsKey(extension.Trim().ToLower()))
            {
                return "other";
            }
            return _extensionMapping[extension.Trim().ToLower()];
        }


    }
}
