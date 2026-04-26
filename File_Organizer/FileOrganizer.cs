using System;
using System.Collections.Generic;
using System.Text;

namespace File_Organizer
{
    public class FileOrganizer
    {
        private string _rootPath;
        private CategoryManager _categoryManager;
        private Logger _instance = Logger.GetInstance();

        public FileOrganizer(string path, CategoryManager categoryManager)
        { 
            _rootPath = path;
            _categoryManager = categoryManager;
        }

        public void StartOrganizing()
        {
            var files = Directory.GetFiles(_rootPath);
            int filesMoved = 0;
            int filesSkipped = 0;
            int totalFiles = files.Length;
            foreach (string file in files)
            {
                string ext = Path.GetExtension(file);
                string folder = _categoryManager.GetTargetFolder(ext);
                if (MoveFileToFolder(file, folder))
                {
                    filesMoved++;
                }else
                {
                    filesSkipped++;
                }
            }
            _instance.Info($"Total files: {totalFiles}\nMoved: {filesMoved}\nSkipped: {filesSkipped}");

        }

        private bool MoveFileToFolder(string filePath, string targetFolder)
        {
            string fileName = Path.GetFileName(filePath);
            string pathFolder = Path.Combine(_rootPath, targetFolder);
            string finalPath = Path.Combine(pathFolder, fileName);

            _instance.Info($"Moving file: {fileName}");
            if (File.Exists(finalPath))
            {
                _instance.Warning($"The file {fileName} already exists in {targetFolder}");
                return false;
            } 
            
            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(pathFolder);
                _instance.Success($"Created destination Folder: {targetFolder}");
            }
            File.Move(filePath, finalPath);
            _instance.Success($"Moved file: {fileName} to {targetFolder}");
            return true;
        }
    }
}
