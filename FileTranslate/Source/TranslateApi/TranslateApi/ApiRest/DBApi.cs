using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
namespace DBApi
{

    class DBApi
    {
        static async Task Main(string[] args)
        {

            var client = new RestClient("http://localhost:5000/translate_file");
            var request = new RestRequest();
            request.AddFile("file", "/C:/Users/SANTI/OneDrive/Documentos/holaa.txt");
            request.AddParameter("source", "az");
            request.AddParameter("target", "en");
            RestResponse response = await client.ExecuteAsync(request);
            //Console.WriteLine(response.Content);

            var translate = System.Text.Json.JsonSerializer.Deserialize<Translates>(response.Content);
        }
    }


    public class Translates
    {
        public string translatedFileUrl { get; set; }
    }


}