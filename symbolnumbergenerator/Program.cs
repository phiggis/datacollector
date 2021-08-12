using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace symbolnumbergenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Bitmap flag = new Bitmap(200, 100);
            Graphics flagGraphics = Graphics.FromImage(flag);
            /*            int red = 0;
                        int white = 11;
                        while (white <= 100)
                        {
                            flagGraphics.FillRectangle(Brushes.Red, 0, red, 200, 10);
                            flagGraphics.FillRectangle(Brushes.White, 0, white, 200, 10);
                            red += 20;
                            white += 20;
                        }*/

            // Setup output format
            var contentType = "image/png";
            // Image width
            const int imageWidth = 100;
            // Image height
            const int imageHeight = 30;
            // Captcha code length
            const int captchaCodeLength = 4;
            // Captcha code string, all the possible chars that can appear in the image.
            const string captchaCodeString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string symbolfolder = @"c:\symbolnumbers";

            if (Directory.Exists(symbolfolder))
            {
                foreach (string file in Directory.GetFiles(symbolfolder))
                {
                    File.Delete(file);
                }
                Directory.Delete(symbolfolder);
            }

            if (!Directory.Exists(symbolfolder))
            {
                Directory.CreateDirectory(symbolfolder);
            }
        

            for (int i = 0; i < 2501; i++)
            {
                // Create the image
                using Bitmap bitmap = new Bitmap(imageWidth, imageHeight);
                // Create the graphics 
                using Graphics graphics = Graphics.FromImage(bitmap);
                // Write bg color
                graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, imageWidth, imageHeight);

                // Font
                using (Font font = new Font(FontFamily.GenericMonospace, 32, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Pixel))
                {
                    for (int j = 0; j < i.ToString().Length; j++)
                    {
                        string counter = i.ToString();
                        switch (counter.Length)
                        {
                            case 1:
                                counter = "000" + counter;
                                break;
                            case 2:
                                counter = "00" + counter;
                                break;

                            case 3:
                                counter = "0" + counter;
                                break;
                            

                        }

                        // Write char to the graphic 
                        graphics.DrawString(counter.ToString(), font, new SolidBrush(Color.White), 0,0);
                        // Save image, image format type is consistent with response content type.
                        bitmap.Save(Path.Combine(symbolfolder, counter + ".png"), System.Drawing.Imaging.ImageFormat.Png);

                    }
                }
            }
        }
        /*
private (byte[] content, string contentType) GenerateCaptchaImage()
{
// Setup output format
var contentType = "image/png";
// Image width
const int imageWidth = 150;
// Image height
const int imageHeight = 50;
// Captcha code length
const int captchaCodeLength = 4;
// Captcha code string, all the possible chars that can appear in the image.
const string captchaCodeString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

Random random = new Random();
// Generate random characters
StringBuilder s = new StringBuilder();
using var ms = new MemoryStream();

// Create the image
using Bitmap bitmap = new Bitmap(imageWidth, imageHeight);
// Create the graphics 
using Graphics graphics = Graphics.FromImage(bitmap);
// Write bg color
graphics.FillRectangle(new SolidBrush(bgColor), 0, 0, imageWidth, imageHeight);

// Add obstructions
using (Pen pen = new Pen(new SolidBrush(obsColor), 2))
{
for (int i = 0; i < 10; i++)
{
graphics.DrawLine(pen, new Point(random.Next(0, imageWidth - 1), random.Next(0, imageHeight - 1)), new Point(random.Next(0, imageWidth - 1), random.Next(0, imageHeight - 1)));
}
}
for (int i = 0; i < 100; i++)
{
bitmap.SetPixel(random.Next(imageWidth), random.Next(imageHeight), Color.FromArgb(random.Next()));
}

// Font
using (Font font = new Font(FontFamily.GenericMonospace, 32, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Pixel))
{
for (int i = 0; i < captchaCodeLength; i++)
{
s.Append(captchaCodeString.Substring(random.Next(0, captchaCodeString.Length - 1), 1));
// Write char to the graphic 
graphics.DrawString(s[s.Length - 1].ToString(), font, new SolidBrush(codeColor), i * 32, random.Next(0, 24));
}
}
// Save image, image format type is consistent with response content type.
bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
return (ms.ToArray(), contentType);
}

}                       */
    }
}
