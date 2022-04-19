using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TranslateApi.Services;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using RestSharp;

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
                ////nombre del archivo 
                string projectFileName = file.FileName;

                // La ruta del archivo cargado
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


        #region Translate
        [HttpPost("Translate")]

        public async Task<IActionResult> Translate(string source, string target)
        {


            var client = new RestClient("http://localhost:5000/translate_file");

            var request = new RestRequest();
            request.AddFile("file", @"C:/Users/SANTI/OneDrive/Documentos/holaa.txt");
            request.AddParameter("source", source);
            request.AddParameter("target", target);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
            return BadRequest();
        }
        #endregion










    }

}

  
