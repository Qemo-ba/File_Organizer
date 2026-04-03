using System;

namespace File_Organizer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Dictionary wird erstellt... ");
            CategoryManager categoryManager = new CategoryManager();

            Console.WriteLine("\nOrdner für jeweilige Dateitypen wird ermittelt... ");
            Console.WriteLine("\nBilder");
            Console.WriteLine("Ordner für .jpg: " + categoryManager.GetTargetFolder(".jpg"));
            Console.WriteLine("Ordner für .png " + categoryManager.GetTargetFolder(".png"));
            Console.WriteLine("\nDokumente");
            Console.WriteLine("Ordner für .pdf: " + categoryManager.GetTargetFolder(".pdf"));
            Console.WriteLine("Ordner für .docx: " + categoryManager.GetTargetFolder(".docx"));
            Console.WriteLine("\nVideos");
            Console.WriteLine("Ordner für .mp4: " + categoryManager.GetTargetFolder(".mp4"));
            Console.WriteLine("\npowerpoint");
            Console.WriteLine("Ordner für .pptx: " + categoryManager.GetTargetFolder(".pptx"));
            Console.WriteLine("Ordner für .ppt " + categoryManager.GetTargetFolder(".ppt"));
            Console.WriteLine("\nExcel");
            Console.WriteLine("Ordner für .xlsx: " + categoryManager.GetTargetFolder(".xlsx"));
            Console.WriteLine("Ordner für .xls " + categoryManager.GetTargetFolder(".xls"));
        }
    }
}
