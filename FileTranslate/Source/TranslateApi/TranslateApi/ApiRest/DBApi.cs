<<<<<<< HEAD
﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Clases.ApiRest
{
    public class DBApi
    {

        //public dynamic Post(string url, string json, string autorizacion = null)
        //{
        //    try
        //    {
        //        var client = new RestClient("http://localhost:5000/translate_file");
        //        client.Timeout = -1;
        //        var request = new RestRequest(Method.POST);
        //        request.AddFile("file", "/E:/SFU/Test-20200304T143540Z-001/Test/docs/D00000003.txt");
        //        request.AddParameter("source", "en");
        //        request.AddParameter("target", "zh");
        //        IRestResponse response = client.Execute(request);
        //        Console.WriteLine(response.Content);

        //        if (autorizacion != null)
        //        {
        //            request.AddHeader("Authorization", autorizacion);
        //        }

        //        IRestResponse response = client.Execute(request);

        //        dynamic datos = JsonConvert.DeserializeObject(response.Content);

        //        return datos;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return null;
        //    }
        }


    }
=======
﻿using System;
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
>>>>>>> 91fd57fb9c458de7430dbfee62a124d9714181c0
