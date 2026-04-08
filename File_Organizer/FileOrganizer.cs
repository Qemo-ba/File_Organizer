using System;
using System.Collections.Generic;
using System.Text;

namespace File_Organizer
{
    public class FileOrganizer
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
            string pathFolder = Path.Combine(_rootPath, targetFolder);
            string finalPath = Path.Combine(pathFolder, Path.GetFileName(filePath));

            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(pathFolder);
                File.Move(filePath, finalPath);
            } else {
                File.Move(filePath, finalPath);
            }
        }
    }
}
