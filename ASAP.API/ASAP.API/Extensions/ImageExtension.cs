using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASAP.API.Extensions
{
    public static class ImageExtension
    {
        public static async Task<string> SaveImage(this IFormFile formFile, string folderName)
        {
            string path = Path.Combine("wwwroot", "Images", folderName, Guid.NewGuid().ToString() + ".jpg");
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(fs);
            }
            
            return path.Replace("wwwroot","");
        }
    }
}
