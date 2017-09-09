using System;
using System.Drawing;
using System.IO;

namespace PrzetwarzanieZdjec
{
    class Images
    {
        //kopiowanie i ucinanie zdjęć
        public void makeCopy (string[] dir, string newPath)
        {

            for (int i = 0; i < dir.Length; i++)
            {
                Image zdjecie = Image.FromFile(dir[i]);
                Bitmap myBitmap = new Bitmap(dir[i]);
                var height = myBitmap.Height;
                height /= 2;
                Rectangle cloneRect = new Rectangle(new Point(0, 0), new Size(myBitmap.Width, height));
                System.Drawing.Imaging.PixelFormat format = myBitmap.PixelFormat;
                Bitmap cloneBitmap = myBitmap.Clone(cloneRect, format);
                cloneBitmap.Save(newPath + "\\image" + i + ".jpg");
                myBitmap.Dispose();
                cloneBitmap.Dispose();
                zdjecie.Dispose();
            }
            Console.WriteLine("Stworzono kopie zdjęc");
        }
    }
}
