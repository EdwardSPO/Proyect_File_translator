using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using TranslateApi.Services;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace TranslateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        #region Property  
        private readonly IFileService _fileService;
        #endregion

        #region Constructor  
        public FileController(IFileService fileService)
        {
           _fileService = fileService;
        }
       #endregion

        #region Upload  
        [HttpPost("Upload")]
        public IActionResult Upload([Required] IFormFile file, [Required] string subDirectory)
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
                return BadRequest("Archivo enviado");
            }
            else
            {
                return BadRequest("Archivo no enviado");
            }
        }
        #endregion

        #region UploadTranslate  
        [HttpPost("UploadTranslate")]
        public async Task<IActionResult> UploadTranslate([Required] IFormFile file, string source, string target)
        {
            WebClient webClient = new WebClient();

            var ruta = @"File/" + System.IO.Path.GetFileName(file.FileName);
            var client = new RestClient("http://localhost:5000/translate_file");
            var request = new RestRequest();

            request.AddFile("file", ruta);
            request.AddParameter("source", source);
            request.AddParameter("target", target);

            RestResponse<DocumentTranslationResponse> response = await client.ExecutePostAsync<DocumentTranslationResponse>(request);
            return Ok(response.Content);
        }
        #endregion

        public class DocumentTranslationResponse
        {
            [JsonProperty(PropertyName = "translatedFileUrl")]
            public string TranslatedFileUrl { get; set; }
        }
    }
}


