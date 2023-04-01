using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common
{
    public static class FileUtils
    {
        public static string ImageUpload(string folderDir, IFormFile uploadedFile, string oldName = "", bool isDelete = false)
        {
            string fileName = null;
            var path = Path.Combine(Directory.GetCurrentDirectory(), folderDir);

            if (isDelete)
            {
                return DeleteFile(path, oldName);
            }

            if (uploadedFile != null && uploadedFile.Length > 0)
            {
                fileName = Guid.NewGuid().ToString() + "." + uploadedFile.FileName.Split('.').LastOrDefault();

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var filePath = Path.Combine(path, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    uploadedFile.CopyTo(fileStream);
                }

                if (!string.IsNullOrWhiteSpace(oldName))
                    DeleteFile(path, oldName);

                return fileName;
            }

            return oldName;
        }

        public static string FileUpload(string folderDir, IFormFile uploadedFile, string oldName = "", bool isDelete = false)
        {
            string fileName = null;
            var path = Path.Combine(Directory.GetCurrentDirectory(), folderDir);

            if (isDelete && uploadedFile == null)
            {
                return DeleteFile(path, oldName);
            }
            if (uploadedFile != null && uploadedFile.Length > 0)
            {
                fileName = Guid.NewGuid().ToString() + "." + uploadedFile.FileName.Split('.').LastOrDefault();

                Directory.CreateDirectory(path);

                var filePath = Path.Combine(path, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    uploadedFile.CopyTo(fileStream);
                }

                if (!string.IsNullOrWhiteSpace(oldName))
                    DeleteFile(path, oldName);

                return fileName;
            }

            return oldName;
        }

        public static string DeleteFile(string folderDir, string oldName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), folderDir);
            var fileOld = Path.Combine(path, oldName);
            if (File.Exists(fileOld))
                File.Delete(fileOld);
            return string.Empty;
        }
    }
}
