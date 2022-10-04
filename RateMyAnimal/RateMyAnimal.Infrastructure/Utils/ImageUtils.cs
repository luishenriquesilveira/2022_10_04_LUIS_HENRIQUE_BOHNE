using System.Drawing;
using System.Drawing.Imaging;

namespace RateMyAnimal.Infrastructure.Utils
{
    public class ImageUtils
    {
        public static byte[] StreamToByteArray(Stream content)
        {
            byte[] imgBytes;
            Image img = Image.FromStream(content);

            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Jpeg);
                imgBytes = ms.ToArray();
            }

            return imgBytes;
        }
    }
}
