using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace Codelux.NetCore.Utilities
{
    public class BasicCaptchaProvider
    {
        private readonly Random _random = new Random();
        public string CaptchaText { get; private set; }

        public Bitmap CreateCaptchaImage()
        {
            CaptchaText = GetRandomText();

            Bitmap bitmap = new Bitmap(200, 50, PixelFormat.Format32bppArgb);

            Pen pen = new Pen(Color.Yellow);
            Rectangle rectangle = new Rectangle(0, 0, 200, 50);

            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush whiteBrush = new SolidBrush(Color.White);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                int counter = 0;

                graphics.DrawRectangle(pen, rectangle);
                graphics.FillRectangle(blackBrush, rectangle);

                foreach (char character in CaptchaText)
                {
                    graphics.DrawString(character.ToString(), new Font("Georgia", 10 + _random.Next(14, 18)), whiteBrush, new PointF(10 + counter, 10));
                    counter += 20;
                }

                DrawRandomLines(graphics);

                return bitmap;
            }
        }

        private void DrawRandomLines(Graphics g)
        {
            SolidBrush green = new SolidBrush(Color.Green);

            for (int i = 0; i < 20; i++)
                g.DrawLines(new Pen(green, 2), GetRandomPoints());

        }
        private Point[] GetRandomPoints()
        {
            Point[] points =
            {
                new Point(_random.Next(10, 150), _random.Next(10, 150)),
                new Point(_random.Next(10, 100), _random.Next(10, 100))
            };

            return points;
        }

        private string GetRandomText()
        {
            StringBuilder randomText = new StringBuilder();

            string charPool = "abcdefghijklmnopqrstuvwxyz1234567890";

            Random rand = new Random();
            for (int j = 0; j <= 5; j++)
                randomText.Append(charPool[rand.Next(charPool.Length)]);

            return randomText.ToString();
        }
    }
}
