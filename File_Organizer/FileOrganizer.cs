using System;
using System.Collections.Generic;
using System.Text;

namespace File_Organizer
{
    internal class FileOrganizer
    {
        private string _rootPath;
        private CategoryManager _categoryManager;

        public FileOrganizer(string path, CategoryManager categoryManager)
        { 
            _rootPath = path;
            _categoryManager = categoryManager;
        }

        public void StartOrganizing()
        {
            List<string> files = Directory.GetFiles(_rootPath).ToList<string>();

            foreach (string file in files)
            {
                string ext = Path.GetExtension(file);
                string folder = _categoryManager.GetTargetFolder(ext);
                MoveFileToFolder(file, folder);
            }

        }

        private void MoveFileToFolder(string filePath, string targetFolder)
        {
            string zielOrdner = Path.Combine(_rootPath, targetFolder);
            string zielPfad = Path.Combine(zielOrdner, Path.GetFileName(filePath));

            if (!Directory.Exists(zielOrdner))
            {
                Directory.CreateDirectory(zielOrdner);
                File.Move(filePath, zielPfad);
            } else {
                File.Move(filePath, zielPfad);
            }
        }
    }
}
