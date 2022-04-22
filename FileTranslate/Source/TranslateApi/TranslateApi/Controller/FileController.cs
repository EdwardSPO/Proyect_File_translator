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



        WebClient webClient = new WebClient();
           

#region Upload  
[HttpPost("Upload")]
        public async Task <IActionResult> Upload( [Required] string subDirectory, [Required] IFormFile file,string source, string target)
        {
            WebClient webClient = new WebClient();

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
                    fs.Flush();
                }

                var ruta = @"File/" + System.IO.Path.GetFileName(file.FileName);


                var client = new RestClient("http://localhost:5000/translate_file");
                var request = new RestRequest();
                request.AddFile("file", ruta);
                request.AddParameter("source", source);
                request.AddParameter("target", target);
                RestResponse<DocumentTranslationResponse> response = await client.ExecutePostAsync<DocumentTranslationResponse>(request);

                webClient.DownloadFile(response.Data.TranslatedFileUrl, $"{projectFileName}_translate");
                return Ok(response.Content);
               
            }
            else
            {
                return BadRequest("Archivo no enviado");
            }


        }
        #endregion





        //#region Translate
        //[HttpPost("Translate")]

        //public  async Task<IActionResult> Translate(IFormFile file, string source, string target)
        //{
        //    var ruta = @"File/" + "holaa.txt";
        //        //System.IO.Path.GetFileName(file.FileName); 
               

       
           
        //    var client = new RestClient("http://localhost:5000/translate_file");
        //    var request = new RestRequest();
        //    request.AddFile("file",  ruta);
        //    request.AddParameter("source", source);
        //    request.AddParameter("target", target);
        //    RestResponse<DocumentTranslationResponse> response  = await client.ExecutePostAsync<DocumentTranslationResponse>(request);
        //    return BadRequest(response.Content);

        //    //WebClient webClient = new WebClient();
        //    //try
        //    //{
        //    //    webClient.DownloadFile("http://localhost:5000/download_file/15cd8e8f-6943-42b2-b6b6-9a8a8086ac63.holaa_en.txt", @"NewFolder");
        //    //}
        //    //catch (ArgumentException ae)
        //    //{
        //    //    Console.WriteLine("{0} - {1}", ae.GetType(), ae.Message);
        //    //}


        //}
        //#endregion




        public class DocumentTranslationResponse
        {
            [JsonProperty(PropertyName = "translatedFileUrl")]
            public string TranslatedFileUrl { get; set; }
        }



        #region UploadTranslate  
        [HttpPost("UploadTranslate")]
        public IActionResult UploadTranslate([Required] string direccionDescarga = @"http://localhost:5000/download_file/ef9a2996-d57c-438c-8875-28c836217b60.holaa_en.txt", 
            string rutaDirectorio = @"file")
        {
            WebClient webClient = new WebClient();
            if (webClient != null)
            {

                webClient.DownloadDataAsync(new Uri(direccionDescarga), rutaDirectorio);

                return BadRequest("Archivo enviado");
            }
            else
            {
                return BadRequest("Archivo no enviado");
            }


        }
        #endregion



       
        //try
        //{
        //    webClient.DownloadFile("http://localhost:5000/download_file/15cd8e8f-6943-42b2-b6b6-9a8a8086ac63.holaa_en.txt", @"Nueva carpeta donde va el nuevo archivo");
        //}
        //catch (ArgumentException ae)
        //{
        //    Console.WriteLine("{0} - {1}", ae.GetType(), ae.Message);
        //}











    }
}

  
