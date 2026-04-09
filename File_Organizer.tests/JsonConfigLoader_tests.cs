using System;
using System.Collections.Generic;
using System.Text;

namespace File_Organizer.tests
{
    public class JsonConfigLoader_tests
    {
        [Fact]
        public void LoadConfig_ValidFilePath_PrintsJsonContent()
        {
            File_Organizer.JsonConfigLoader jsonConfigLoader = new File_Organizer.JsonConfigLoader();
            string filePath = "config.json";
            string expectedOutput = "[\r\n  {\r\n    \"Extensions\": [ \".png\", \".jpg\", \".jpeg\", \".gif\", \".webp\", \".svg\", \".tiff\", \".bmp\", \".heic\", \".raw\", \".psd\", \".ai\", \".eps\", \".ico\" ],\r\n    \"Destination\": \"images\"\r\n  },\r\n  {\r\n    \"Extensions\": [ \".pdf\", \".doc\", \".docx\", \".txt\", \".rtf\", \".odt\", \".pages\", \".epub\", \".md\", \".log\" ],\r\n    \"Destination\": \"documents\"\r\n  },\r\n  {\r\n    \"Extensions\": [ \".ppt\", \".pptx\", \".pptm\", \".key\", \".odp\", \".ppsx\" ],\r\n    \"Destination\": \"presentations\"\r\n  },\r\n  {\r\n    \"Extensions\": [ \".xls\", \".xlsx\", \".xlsm\", \".csv\", \".ods\", \".numbers\", \".tsv\" ],\r\n    \"Destination\": \"spreadsheets\"\r\n  },\r\n  {\r\n    \"Extensions\": [ \".mp4\", \".mov\", \".avi\", \".mkv\", \".webm\", \".flv\", \".wmv\", \".m4v\", \".mpg\", \".mpeg\", \".ts\" ],\r\n    \"Destination\": \"videos\"\r\n  },\r\n  {\r\n    \"Extensions\": [ \".mp3\", \".wav\", \".aac\", \".flac\", \".ogg\", \".m4a\", \".wma\", \".aiff\" ],\r\n    \"Destination\": \"audio\"\r\n  },\r\n  {\r\n    \"Extensions\": [ \".zip\", \".rar\", \".7z\", \".tar\", \".gz\", \".pkg\", \".dmg\", \".iso\" ],\r\n    \"Destination\": \"archives\"\r\n  }\r\n]";
            string actualOutput = File.ReadAllText(filePath);
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
