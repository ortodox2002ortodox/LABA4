using System;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace l.r._4
{
    class Task_2
    {
        public static void Task(string directory, string resultDirectory)
        {
            string[] fileName = Directory.GetFiles(directory).Select(Path.GetFileName).ToArray();
            Regex regexExtForImage = new Regex("^((.bmp)|(.gif)|(.tiff?)|(.jpe?g)|(.png))$", RegexOptions.IgnoreCase);
            int n = 0;
            foreach (String i in fileName)
            {
                try
                {
                    if (regexExtForImage.IsMatch(Path.GetFileName(i)))
                    {
                        Bitmap bitmap = (Bitmap)Bitmap.FromFile(i);
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                        bitmap.Save(resultDirectory + i.Split('.')[0] + "-mirrored.gif", ImageFormat.Png);
                    }
                }
                catch (OutOfMemoryException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Картинка збережна в {0}.", resultDirectory);
                    n++;
                }
            }
        }
    }
}

