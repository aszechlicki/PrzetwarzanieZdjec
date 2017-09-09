using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.IO.Compression;

namespace PrzetwarzanieZdjec
{
    class DirAction
    {
        private string zipPath;
        private string extractPath;
        private string[] dir;

        public DirAction(string zipPath, string extractPath)
        {
            this.zipPath = zipPath;
            this.extractPath = extractPath;
        }

        public string[] Dir { get => dir; set => dir = value; }

        //pobieranie pliku
        public async Task DownloadZipAsync(string url) {

            using (var client = new HttpClient())
            {
                try
                {
                    var stream = await client.GetStreamAsync(url);
                    var file = new FileInfo(zipPath);
                    var fileStream = file.OpenWrite();
                    await stream.CopyToAsync(fileStream).ContinueWith(res => fileStream.Close());
                    Console.WriteLine("Zakonczono pobieranie");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                
            }
            
        }
        // Wypakowywanie pliku
        public void ExtractZip ()
        {
            ZipFile.ExtractToDirectory(zipPath, extractPath);
            Console.WriteLine("Zakonczone wypakowywanie");
        }

        //pobieranie nazw zdjęć
        public string[] GetFileName ()
        {
            this.Dir = Directory.GetFiles(path: extractPath, searchPattern: "*.jpg", searchOption: SearchOption.AllDirectories);
            return Dir;
        }
        
    }
}
