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
        [Fact]
        public void GetTargetFolder_ImageExtension_ReturnsImagesfolder()
        {
            
            string ext = ".png";
            string actual = categoryManager.GetTargetFolder(ext);
            Assert.Equal("images", actual);
        }

        [Fact]
        public void GetTargetFolder_dokumentExtension_Returnsdokumentsfolder()
        {
            string ext = ".pdf";
            string actual = categoryManager.GetTargetFolder(ext);
            Assert.Equal("documents", actual);
        }

        [Fact]
        public void GetTargetFolder_powerpointExtension_Returnspowerpointsfolder()
        {
            string ext = ".pptx";
            string actual = categoryManager.GetTargetFolder(ext);
            Assert.Equal("presentations", actual);
        }

        [Fact]
        public void GetTargetFolder_excelExtension_Returnsexcelfolder()
        {
            string ext = ".xlsx";
            string actual = categoryManager.GetTargetFolder(ext);
            Assert.Equal("spreadsheets", actual);
        }

        [Fact]
        public void GetTargetFolder_videoExtension_Returnsvideosfolder()
        {
            string ext = ".mp4";
            string actual = categoryManager.GetTargetFolder(ext);
            Assert.Equal("videos", actual);
        }


        [Fact]
        public void GetTargetFolder_otherExtension_Returnsotherfolder()
        {
            string ext = ".doesnotexist";
            string actual = categoryManager.GetTargetFolder(ext);
            Assert.Equal("other", actual);
        }

        [Fact]
        public void GetTargetFolder_ToUpperdokumentExtension_returnsdocumentsfolder()
        {
            string ext = ".PDF";
            string actual = categoryManager.GetTargetFolder(ext);
            Assert.Equal("documents", actual);
        }
        
        [Fact]
        public void GetTargetFolder_onlyDotExtension()
        {
            string ext = ".";
            string actual = categoryManager.GetTargetFolder(ext);
            Assert.Equal("other", actual);
        }

        [Fact]
        public void GetTargetFolder_ExtensionNULL_returnsothersfolder()
        {
            string ext = null;
            string actual = categoryManager.GetTargetFolder(ext);
            Assert.Equal("other", actual);
        }

        [Fact]
        public void GetTargetFolder_noExtension()
        {
            string ext = "";
            string actual = categoryManager.GetTargetFolder(ext);
            Assert.Equal("other", actual);
        }



    }
}
