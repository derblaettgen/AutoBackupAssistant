using Ionic.Zip;

namespace AutoBackupAssistant
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFolder = @"C:\Temp\AutoBackupTest";
            string targetZipFile = @"C:\Temp\AutoBackupTest.zip";

            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(sourceFolder);
                zip.Save(targetZipFile);
            }
        }
    }
}
