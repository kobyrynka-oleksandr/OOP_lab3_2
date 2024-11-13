using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace OOP_lab3_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\C# Projects\OOP_lab3_2\files";
            var files = Directory.GetFiles(path).Where(fileName => !fileName.Contains("-mirrored")).ToArray();

            Regex regexExtForImage = new Regex("^\\.((bmp)|(gif)|(tiff?)|(jpe?g)|(png))$", RegexOptions.IgnoreCase);
            foreach (var fileName in files)
            {
                if (!regexExtForImage.IsMatch(Path.GetExtension(fileName)))
                    continue;

                try
                {
                    string newFileName = Path.Combine(path, $"{Path.GetFileNameWithoutExtension(fileName)}-mirrored.gif");
                    
                    Bitmap bitmap = new Bitmap(fileName);

                    bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    
                    bitmap.Save(newFileName, ImageFormat.Gif);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"File '{fileName}' is not an image. Error: {ex.Message}");
                }
            }
        }
    }
}
