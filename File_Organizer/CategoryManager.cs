using System;
using System.Collections.Generic;
using System.Text;

namespace File_Organizer
{
    internal class CategoryManager
    {
        private Dictionary<string, string> _extensionMapping = new Dictionary<string, string>();

        public CategoryManager() {
            RegisterExtensions("images", ".jpg", ".jpeg", ".png");
            RegisterExtensions("documents", ".pdf", ".docx", ".txt");
            RegisterExtensions("powerpoints", ".pptx", ".ppt");
            RegisterExtensions("excel", ".xlsx", ".xls");
            RegisterExtensions("videos", ".mp4");
            _extensionMapping.SelectMany(kvp => new[] { $"{kvp.Key} => {kvp.Value}" }).ToList().ForEach(Console.WriteLine);
        }

        private void RegisterExtensions(string folder, params string[] extensions)
        {
            foreach (var extension in extensions)
            {
                _extensionMapping.Add(extension.ToLower(), folder);
            }
        }

        public string GetTargetFolder(string extension)
        {
            string ext = extension.ToLower();
            if (_extensionMapping.ContainsKey(ext))
            {
                return _extensionMapping[ext];
            }
            return "other";
        }


    }
}
