namespace File_Organizer.tests
{
    public class CategoryManager_tests
    {
        [Fact]
        public void GetTargetFolder_ImageExtension_ReturnsImagesfolder()
        {
            File_Organizer.CategoryManager categoryManager = new File_Organizer.CategoryManager();
            string ext = ".png";
            string actual = categoryManager.GetTargetFolder(ext);
            Assert.Equal("images", actual);
        }

        [Fact]
        public void GetTargetFolder_dokumentExtension_Returnsdokumentsfolder()
        {
            File_Organizer.CategoryManager categoryManager = new File_Organizer.CategoryManager();
            string ext = ".pdf";
            string actual = categoryManager.GetTargetFolder(ext);
            Assert.Equal("documents", actual);
        }

        [Fact]
        public void GetTargetFolder_powerpointExtension_Returnspowerpointsfolder()
        {
            File_Organizer.CategoryManager categoryManager = new File_Organizer.CategoryManager();
            string ext = ".pptx";
            string actual = categoryManager.GetTargetFolder(ext);
            Assert.Equal("powerpoints", actual);
        }

        [Fact]
        public void GetTargetFolder_excelExtension_Returnsexcelfolder()
        {
            File_Organizer.CategoryManager categoryManager = new File_Organizer.CategoryManager();
            string ext = ".xlsx";
            string actual = categoryManager.GetTargetFolder(ext);
            Assert.Equal("excel", actual);
        }

        [Fact]
        public void GetTargetFolder_videoExtension_Returnsvideosfolder()
        {
            File_Organizer.CategoryManager categoryManager = new File_Organizer.CategoryManager();
            string ext = ".mp4";
            string actual = categoryManager.GetTargetFolder(ext);
            Assert.Equal("videos", actual);
        }


        [Fact]
        public void GetTargetFolder_otherExtension_Returnsotherfolder()
        {
            File_Organizer.CategoryManager categoryManager = new File_Organizer.CategoryManager();
            string ext = ".odt";
            string actual = categoryManager.GetTargetFolder(ext);
            Assert.Equal("other", actual);
        }

        [Fact]
        public void GetTargetFolder_ToUpperdokumentExtension_returnsdocumentsfolder()
        {
            File_Organizer.CategoryManager categoryManager = new File_Organizer.CategoryManager();
            string ext = ".PDF";
            string actual = categoryManager.GetTargetFolder(ext);
            Assert.Equal("documents", actual);
        }
        
        [Fact]
        public void GetTargetFolder_onlyDotExtension()
        {
            File_Organizer.CategoryManager categoryManager = new File_Organizer.CategoryManager();
            string ext = ".";
            string actual = categoryManager.GetTargetFolder(ext);
            Assert.Equal("other", actual);
        }

        [Fact]
        public void GetTargetFolder_ExtensionNULL_returnsothersfolder()
        {
            File_Organizer.CategoryManager categoryManager = new File_Organizer.CategoryManager();
            string ext = null;
            string actual = categoryManager.GetTargetFolder(ext);
            Assert.Equal("other", actual);
        }

        [Fact]
        public void GetTargetFolder_noExtension()
        {
            File_Organizer.CategoryManager categoryManager = new File_Organizer.CategoryManager();
            string ext = "";
            string actual = categoryManager.GetTargetFolder(ext);
            Assert.Equal("other", actual);
        }



    }
}
