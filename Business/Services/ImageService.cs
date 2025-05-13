using _final_project.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _final_project.BusinessLogic.Services
{
    public class ImageService : IImageService
    {
        public byte[] CreatePicture(IFormFile image)
        {
            using var ms = new MemoryStream();

            image.CopyTo(ms);

            var imageBytes = ms.ToArray();

            using var inputStream = new MemoryStream(imageBytes);
            using var originalImage = System.Drawing.Image.FromStream(inputStream);

            int thumbWidth = 200;
            int thumbHeight = 200;

            using var thumbnail = originalImage.GetThumbnailImage(thumbWidth, thumbHeight, () => false, IntPtr.Zero);
            using var ms2 = new MemoryStream();
            thumbnail.Save(ms2, ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}
