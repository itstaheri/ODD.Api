using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;

namespace Captcha.Service.Generator
{
    public class GenerateImage
    {
        private string captchaText;
        private int width = 400;
        private int height = 100;

        public virtual string CodeToCaptchaImage(string code)
        {
           
            //First declare a bitmap and declare graphic from this bitmap
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            //And create a rectangle to delegete this image graphic 
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, width, height);
            //And create a brush to make some drawings
            HatchBrush hatchBrush = new HatchBrush(HatchStyle.DottedGrid, System.Drawing.Color.Aqua, System.Drawing.Color.White);
            g.FillRectangle(hatchBrush, rect);

            //here we make the text configurations
            GraphicsPath graphicPath = new GraphicsPath();
            //add this string to image with the rectangle delegate
            graphicPath.AddString(code, System.Drawing.FontFamily.GenericMonospace, (int)System.Drawing.FontStyle.Bold, 90, rect, null);
            //And the brush that you will write the text
            hatchBrush = new HatchBrush(HatchStyle.Percent20, System.Drawing.Color.Black, System.Drawing.Color.DarkOliveGreen);
            g.FillPath(hatchBrush, graphicPath);
            //We are adding the dots to the image
            //Random rnd = new Random();
            //for (int i = 0; i < (int)(rect.Width * rect.Height / 50F); i++)
            //{
            //    int x = rnd.Next(width);
            //    int y = rnd.Next(height);
            //    int w = rnd.Next(10);
            //    int h = rnd.Next(10);
            //    g.FillEllipse(hatchBrush, x, y, w, h);
            //}
            //Remove all of variables from the memory to save resource
            hatchBrush.Dispose();
            g.Dispose();
            //return the image to the related component
            using (var ms = new MemoryStream())
            {
                bitmap.Save(ms,ImageFormat.Jpeg);
                //convert byte to base64

                var msArray = ms.ToArray();
                return Convert.ToBase64String(msArray);


            }
        }
    }

    
}