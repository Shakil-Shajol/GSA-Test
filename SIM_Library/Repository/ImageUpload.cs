using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SIM_Library.Repository
{
    public class FileUpload
    {
        
        public static string Upload(IFormFile file,string folderName,string root)
        {
            string NewImageName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string NewImagePath = Path.Combine(folderName, NewImageName);
            string image = Path.Combine(root, NewImagePath);
            file.CopyTo(new FileStream(image, FileMode.Create));
            return NewImagePath;
        }
        public static string UpdateFile(IFormFile file,string preFilePath,string folderName,string root)
        {
            string NewImagePath = Upload(file, folderName, root);
            Remove(preFilePath, root);
            return NewImagePath;
        }

        public static void Remove(string filePath,string root)
        {
            string imageToDelete = Path.Combine(root, filePath);
            if (File.Exists(imageToDelete))
            {
                try
                {
                    File.Delete(imageToDelete);
                }
                catch (Exception)
                {

                }
                
            }
        }
    }
}
