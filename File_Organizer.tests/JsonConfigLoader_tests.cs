using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Text.Json;

namespace File_Organizer.tests
{
    public class JsonConfigLoader_tests
    {

        [Fact]
        public void LoadConfig_Fileloading_CreatesObjects_()
        {
            string testFilePath = "C:\\Users\\qemal\\source\\repos\\File_Organizer\\File_Organizer.tests\\test_files\\test_config.json";
            var result = JsonConfigLoader.LoadConfig(testFilePath);
            //File not Null
            Assert.NotNull(result);
            //all objects created correctly
            Assert.Equal(7, result.Count());
            //check first two objects
            Assert.Equal("images", result.ElementAt(0).Destination);
            Assert.Equal(new List<string> { ".png", ".jpg", ".jpeg", ".gif", ".webp", ".svg", ".tiff", ".bmp", ".heic", ".raw", ".psd", ".ai", ".eps", ".ico" }, result.ElementAt(0).Extensions);
            Assert.Equal("documents", result.ElementAt(1).Destination);
            Assert.Equal(new List<string> { ".pdf", ".doc", ".docx", ".txt", ".rtf", ".odt", ".pages", ".epub", ".md", ".log" }, result.ElementAt(1).Extensions);
        }
        [Fact]
        public void LoadConfig_FileNotFound_ThrowsFileNotFoundException()
        {
            string testFilePath = "file_not_found.json";
            Assert.Throws<FileNotFoundException>(() => JsonConfigLoader.LoadConfig(testFilePath));
        }

    }
}
