using System;
using System.Collections.Generic;
using System.Text;

namespace File_Organizer
{
    public class CategoryManager
    {
        private Dictionary<string, string> _extensionMapping = new Dictionary<string, string>();

        public CategoryManager() {
            RegisterExtensions("images", ".jpg", ".jpeg", ".png");
            RegisterExtensions("documents", ".pdf", ".docx", ".txt");
            RegisterExtensions("powerpoints", ".pptx", ".ppt");
            RegisterExtensions("excel", ".xlsx", ".xls");
            RegisterExtensions("videos", ".mp4");
        }

        private void RegisterExtensions(string folder, params string[] extensions)
        {
            foreach (var extension in extensions)
            {
                _extensionMapping.Add(extension, folder);
            }
        }

        public string GetTargetFolder(string extension)
        {
            if (string.IsNullOrEmpty(extension) || !_extensionMapping.ContainsKey(extension.ToLower()))
            {
                return "other";
            }
            return _extensionMapping[extension.ToLower()];
        }


    }
}
