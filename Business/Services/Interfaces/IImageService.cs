using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Http;


namespace _final_project.BusinessLogic.Services.Interfaces
{
    public interface IImageService
    {
        public byte[] CreatePicture(IFormFile image);
    }
}
