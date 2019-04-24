using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilinearScaling
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = @"C:\Users\Dell\Desktop\ImageProcessing\peppers_color.tif";
            string outputPath = @"C:\Users\Dell\Desktop\ImageProcessing\testOutput2.bmp";


            Bitmap image = new Bitmap(inputPath);
            int width = image.Width;
            int height = image.Height;

            int scalingFactor = 3;

            int newWidth = width * scalingFactor;
            int newHeight = height * scalingFactor;
            Bitmap newImage = new Bitmap(newWidth, newHeight);


            for (int j = 0; j < newHeight; j++)
            {
                for (int i = 0; i < newWidth; i++)
                {
                    if (i % scalingFactor == 0 && j % scalingFactor == 0)
                    {
                        int x = i / scalingFactor;
                        int y = j / scalingFactor;
                        newImage.SetPixel(i, j, image.GetPixel(x, y));
                    }
                    else
                    {
                        int x1 = i / scalingFactor;
                        int x2 = (((i / scalingFactor) + 1) < width) ? i / scalingFactor : width - 1;

                        int y = j / scalingFactor;

                        Color valueX1 = image.GetPixel(x1, y);
                        Color valueX2 = image.GetPixel(x2, y);
                        byte r1 = (byte)(valueX1.R * ((double)(1 - ((i % scalingFactor) / scalingFactor))) + valueX2.R * ((double)((i % scalingFactor) / scalingFactor)));
                        byte g1 = (byte)(valueX1.G * ((double)(1 - ((i % scalingFactor) / scalingFactor))) + valueX2.G * ((double)((i % scalingFactor) / scalingFactor)));
                        byte b1 = (byte)(valueX1.B * ((double)(1 - ((i % scalingFactor) / scalingFactor))) + valueX2.B * ((double)((i % scalingFactor) / scalingFactor)));




                        newImage.SetPixel(i, j, Color.FromArgb(r1, g1, b1));

                    }

                }
            }
            newImage.Save(outputPath);
        }
    }
}
