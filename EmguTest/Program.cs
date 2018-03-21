using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace EmguTest
{
    class Program
    {
       
        static void Main(string[] args)
        {
            var fr = new FRTest();

            foreach (var ic in arrICs)
            {
                fr.TestCrop(new Bitmap(ic));
            }
            

            Console.WriteLine("pause;");
        }

        private static IList<string> arrICs = new List<string>()
        {
            @"path\to\img1",
            @"path\to\img2",
            @"path\to\img3",
            @"path\to\img4",
        };

        private static string path = @"C:\A\test\img.png";
        private static void Test()
        {
            var bitmap = new Bitmap(path);
            var img = EmguHelper.AtomizationImage(bitmap);
            Show(img);

            img = EmguHelper.EmbossmentImage(bitmap);
            Show(img);

            img = EmguHelper.GrayImage(bitmap, 0);
            Show(img);
            img = EmguHelper.GrayImage(bitmap, 1);
            Show(img);
            img = EmguHelper.GrayImage(bitmap, 2);
            Show(img);

            img = EmguHelper.NegativeImage(bitmap);
            Show(img);

            img = EmguHelper.ResizeImage(bitmap, new Size(100, 100));
            Show(img);

            img = EmguHelper.SharpenImage(bitmap);
            Show(img);

            img = EmguHelper.SoftenImage(bitmap);
            Show(img);


            Image<Bgr, byte> img3 = null;
            EmguHelper.ImproveContrast(path, out img3);
            if (img3 != null)
            {
                Show(img3);
            }


            img = EmguHelper.Canny(bitmap);
            Show(img);

            Console.ReadLine();
        }


        public static void Show(Bitmap bmp)
        {
            var img = new Image<Bgr, byte>(bmp);
            ImageViewer.Show(img);
        }
        public static void Show(Image<Bgr,byte> img)
        {
            ImageViewer.Show(img);
        }
        public static void Show(Image<Gray, byte> img)
        {
            ImageViewer.Show(img);
        }

    }
}
