using System.IO;

namespace HomeWorkFiles1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dirDelete = new DirectoryInfo("D://dirDeleting/");
            DeleteFiles(dirDelete);
        }
        static void DeleteFiles(DirectoryInfo dir)
        {
            long size = 0;

            try
            {
                foreach (DirectoryInfo diritem in dir.GetDirectories())
                {
                    DeleteFiles(diritem);
                    var str = diritem.LastAccessTimeUtc;
                    var str2 = DateTime.Now;
                    var diff = str2.Subtract(str).Minutes;
                    if (diff > 30) diritem.Delete();
                }
                foreach (FileInfo file in dir.GetFiles())
                {
                    size += file.Length;
                    var str = file.LastAccessTimeUtc;
                    var str2 = DateTime.Now;
                    var diff = str2.Subtract(str).Minutes;
                    if (diff > 30) file.Delete();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}