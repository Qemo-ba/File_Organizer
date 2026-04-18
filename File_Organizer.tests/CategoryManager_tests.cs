namespace File_Organizer.tests
{
    public class CategoryManager_tests
    {
        CategoryManager categoryManager;
        public CategoryManager_tests() 
        {
             var configData = JsonConfigLoader.LoadConfig("C:\\Users\\qemal\\source\\repos\\File_Organizer\\File_Organizer.tests\\test_files\\test_config.json");
             this.categoryManager = new File_Organizer.CategoryManager(configData);
        }

        [Theory]
        [InlineData(".png", "images")]
        [InlineData(".pdf", "documents")]
        [InlineData(".pptx", "presentations")]
        [InlineData(".xlsx", "spreadsheets")]
        [InlineData(".mp4", "videos")]
        public void GetTargetFolder_ValidExtensions_ReturnsCorrectFolder(string extension, string expectedFolder)
        {
            string actual = categoryManager.GetTargetFolder(extension);
            Assert.Equal(expectedFolder, actual);
        }

        [Theory]
        [InlineData(".PNG", "images")]
        [InlineData(".PDF", "documents")]
        [InlineData(".PPTX", "presentations")]
        [InlineData(".XLSX", "spreadsheets")]
        [InlineData(".MP4", "videos")]
        public void GetTargetFolder_UppercaseExtensions_ReturnsCorrectFolder(string extension, string expectedFolder)
        {
            string actual = categoryManager.GetTargetFolder(extension);
            Assert.Equal(expectedFolder, actual);
        }



        [Theory]
        [InlineData(".doesnotexist")]
        [InlineData(".")]
        [InlineData(null)]
        [InlineData("")]
        public void GetTargetFolder_InvalidExtensions_ReturnsFallbackFolder(string extension) 
        { 
            string actual = categoryManager.GetTargetFolder(extension);
            Assert.Equal("other", actual);
        }



    }
}
