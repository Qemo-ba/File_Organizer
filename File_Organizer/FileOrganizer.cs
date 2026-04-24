using System;
using System.Collections.Generic;
using System.Text;

namespace File_Organizer
{
    public class FileOrganizer
    {
        private string _rootPath;
        private CategoryManager _categoryManager;
        Logger _instance = Logger.GetInstance();

        public FileOrganizer(string path, CategoryManager categoryManager)
        { 
            _rootPath = path;
            _categoryManager = categoryManager;
        }

        public void StartOrganizing()
        {
            var files = Directory.GetFiles(_rootPath);

            foreach (string file in files)
            {
                var fileName = Path.GetFileName(file);
                _instance.Info($"The File: {fileName} is being moved");
                string ext = Path.GetExtension(file);
                string folder = _categoryManager.GetTargetFolder(ext);
                MoveFileToFolder(file, folder);
                _instance.Success($"{file} moved to {folder}");
            }

        }

        private void MoveFileToFolder(string filePath, string targetFolder)
        {
            string pathFolder = Path.Combine(_rootPath, targetFolder);
            string finalPath = Path.Combine(pathFolder, Path.GetFileName(filePath));

            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(pathFolder);
                _instance.Success($"Created destination Folder: {targetFolder}");
            }
            File.Move(filePath, finalPath);
        }
    }
}
