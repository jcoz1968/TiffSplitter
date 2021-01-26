using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiffSplitter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SplitTiff(@"c:\temp\0001.tif");
            Console.Read();
        }

        public static void SplitTiff(string filepath)
        {
            int activePage;
            int pages;

            var dest = @"c:\temp";

            Image image = Image.FromFile(filepath);
            pages = image.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);

            for (int index = 0; index < pages; index++)
            {
                activePage = index + 1;
                image.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, index);
                image.Save(dest + @"\file_" + activePage.ToString() + ".tif", System.Drawing.Imaging.ImageFormat.Tiff);
            }
            image.Dispose();
        }

    }
}
