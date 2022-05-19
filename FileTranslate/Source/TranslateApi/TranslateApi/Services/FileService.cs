using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;


namespace TranslateApi.Services
{
    public class FileService : IFileService
    {
        #region Property  
        private IWebHostEnvironment _hostingEnvironment;
        #endregion

        #region Constructor  
        public FileService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        #endregion

        public void Upload(IFormFile file, string subDirectory)
        {
            if (file != null)
            {
                if (!Directory.Exists(subDirectory))
                {
                    Directory.CreateDirectory(subDirectory);
                }
                string projectFileName = file.FileName;
                string filePath = subDirectory + $@"\{projectFileName}";
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }

            }
        }
    }
}
        