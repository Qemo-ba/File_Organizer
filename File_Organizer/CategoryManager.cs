using System;
using System.Collections.Generic;
using System.Text;

namespace File_Organizer
{
    internal class CategoryManager
    {
        private Dictionary<string, string> _extensionMapping = new Dictionary<string, string>();

        public CategoryManager() {
            RegisterExtensions("images", ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff");
        }

        private void RegisterExtensions(string folder, params string[] extensions)
        {
            foreach (var extension in extensions)
            {
                _extensionMapping.Add(extension.ToLower(), folder);
            }
        }


    }
}
