using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearInterpolation
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = @"C:\Users\Dell\Desktop\ImageProcessing\peppers_color.tif";
            string outputPath = @"C:\Users\Dell\Desktop\ImageProcessing\testOutput.bmp";

            Bitmap image = new Bitmap(inputPath);
            int width = image.Width;
            int height = image.Height;

            int scalingFactor = 5;

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
                        int x = ((int)Math.Round((double)i / scalingFactor) < width) ? (int)Math.Round((double)i / scalingFactor) : width - 1;
                        int y = ((int)Math.Round((double)j / scalingFactor) < height) ? (int)Math.Round((double)j / scalingFactor) : height - 1;
                        newImage.SetPixel(i, j, image.GetPixel(x, y));

                    }

                }
            }
            newImage.Save(outputPath);
        }
    }
}
