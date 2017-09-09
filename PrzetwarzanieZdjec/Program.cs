using System;
using System.Threading.Tasks;
using System.IO;

namespace PrzetwarzanieZdjec
{
    class Program
    {
        private async Task newMainAsync()
        {
            string zipPath = @".\inmoto.zip";
            string extractPath = @".\tmp";
            string newPath = @".\finalDir";
            string url = "http://www.inmoto.pl/up/Opony-InMoto.zip";
            string[] dirs = null;

            DirectoryInfo di = Directory.CreateDirectory(newPath);
            DirAction dirAction = new DirAction(zipPath, extractPath);
            Images copyImages = new Images();

            Task.WaitAll(dirAction.DownloadZipAsync(url));
            dirAction.ExtractZip();

            dirAction.GetFileName();

            dirs = dirAction.Dir;
            copyImages.makeCopy(dirs, newPath);

            try
            {
                File.Delete(zipPath);
                Console.WriteLine("Usunieto plik Zip");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            dirs = null;
            try
            {
                Directory.Delete(extractPath, true);
                Console.WriteLine("Usunieto folder tymczasowy");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


        }

        static void Main(string[] args)
        {
            new Program().newMainAsync();
            Console.ReadLine();
        }
    }
}
