using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helper
{
    public static class FileHelper
    {
        public static bool IsImage(IFormFile file)
        {
            return file.Length > 0 && file.ContentType.Contains("image");
        }

        public static string CreateFileName(IFormFile file)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(file.FileName);
            return guid + extension;
        }

        public static string UploadFile(IFormFile file)
        {
            string fileName = CreateFileName(file);

            string path = Path.Combine("wwwroot", IsImage(file) ? "images" : "files" , fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return path;
        }

        public static void RemoveFile(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
